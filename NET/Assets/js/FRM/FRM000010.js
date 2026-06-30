//form
var FormCode = "FRM000010";
let grid01Api;
let grid02Api;
let grid03Api;

//SCM - Batch - AG Grid
let grid04Api;

//SCM - Estimate - AG Grid
let grid05Api;

//OSM - Batch - AG Grid
let grid06Api;

//OSM - Estimate - AG Grid
let grid07Api;

//Tag - AG grid
let grid08Api;
//form

//attachment
var FileCount = 0;
//attachment

//validate
function fnFRMValidateRecord(pGroup, pFType, pID, pValue01, pValue02, callBack) {
    $.ajax({
        type: "POST",
        url: "Assets/Handler/FRM/FRM000010HND.ashx",
        data: {
            'pFormCode': 'FRM000010',
            'pType': 'Validate - Record',
            'pID': pID,
            'pValue01': pValue01,
            'pValue02': pValue02,
            'pGroup': pGroup,
            'pFType': pFType
        },
        success: function (response) {
            callBack(response);
        },
    });
};
//validate

//number formatting
function formatNumber(value) {
    return new Intl.NumberFormat('en-US', {
        minimumFractionDigits: 2,
        maximumFractionDigits: 2
    }).format(value);
};
function fnComputeVal() {
    var PurchaseType = document.getElementById("lbl0101PurchaseType").innerText;
    var UpdQty = document.getElementById("tbx0102Qty");
    var UpdPO = document.getElementById("tbx0102ForPO");
    var UpdSR = document.getElementById("tbx0102ForSR");
    var UpdCP = document.getElementById("tbx0102CPQty");
    var UpdCost = document.getElementById("tbx0102Cost");
    var UpdTotal = document.getElementById("tbx0102Total");

    //Condition
    if (PurchaseType.includes("Return")) {
        UpdSR.value = UpdQty.value;
        UpdCP.value = "0.00";
    };
    if (PurchaseType.includes("Transfer")) {
        UpdSR.value = UpdQty.value;
        UpdCP.value = "0.00";
    };

    //For PO
    var POVal = parseFloat(UpdQty.value.replace(',', '')) - (parseFloat(UpdSR.value.replace(',', '')) + parseFloat(UpdCP.value.replace(',', '')));
    var PONewVal = POVal.toFixed(2);
    var POParts = PONewVal.toString().split(".");
    var PONum = POParts[0].replace(/\B(?=(\d{3})+(?!\d))/g, ",") + (POParts[1] ? "." + POParts[1] : "");
    if (PONum == "NaN") {
        PONum = "0.00";
    };
    UpdPO.value = PONum;

    //FOR CP
    var TotVal = parseFloat(UpdCP.value.replace(',', '')) * parseFloat(UpdCost.value.replace(',', ''));
    var TotNewVal = TotVal.toFixed(2);
    var TotParts = TotNewVal.toString().split(".");
    var TotNum = TotParts[0].replace(/\B(?=(\d{3})+(?!\d))/g, ",") + (TotParts[1] ? "." + TotParts[1] : "");
    if (TotNum == "NaN") {
        TotNum = "0.00";
    }
    UpdTotal.value = TotNum;
};
function FormatNumeric(ID) {
    var NumVal = document.getElementById(ID);
    var RawValue = NumVal.value.replace(/,/g, "");
    var Val = parseFloat(RawValue);
    if (isNaN(Val)) {
        NumVal.value = "0.00";
        return;
    }
    var NewVal = Val.toFixed(2);
    var Parts = NewVal.toString().split(".");
    var Num = Parts[0].replace(/\B(?=(\d{3})+(?!\d))/g, ",") + (Parts[1] ? "." + Parts[1] : "");
    NumVal.value = Num;
};
function isNumberKey(e, input) {
    const key = e.key;
    const val = input.value;

    // Allow control keys (backspace, delete, arrows)
    if (e.ctrlKey || e.metaKey || e.altKey || e.keyCode < 32) return true;

    // Allow digits
    if (/[0-9]/.test(key)) return true;

    // Allow one "-" at the start
    if (key === '-' && val.indexOf('-') === -1 && input.selectionStart === 0) {
        return true;
    }

    // Allow one decimal point (but not at start)
    if (key === '.' && val.indexOf('.') === -1) {
        return true;
    }

    // Block everything else
    return false;
};
//number formatting

//general
function fn01Load() {
    fn0101LoadOverview(document.getElementById('ContentPlaceHolder1_hdnMode').value, document.getElementById('ContentPlaceHolder1_hdnID').value);
    fn0201LoadAttachment(document.getElementById('ContentPlaceHolder1_hdnMode').value, document.getElementById('ContentPlaceHolder1_hdnID').value);
    fn0301LoadNotes(document.getElementById('ContentPlaceHolder1_hdnID').value);
    fn0401LoadApprover(document.getElementById('ContentPlaceHolder1_hdnID').value);
    fn0501LoadSubscriber(document.getElementById('ContentPlaceHolder1_hdnID').value);
    fn0601LoadHistory(document.getElementById('ContentPlaceHolder1_hdnID').value);
};
function fn01DisableButtons(pValue) {

    if (pValue == true) {
        document.getElementById("btn0101Find").classList.remove("btn-view");
        document.getElementById("btn0101Refresh").classList.remove("btn-view");
        document.getElementById("btn0101Add").classList.remove("btn-add");
        document.getElementById("btn0101Delete").classList.remove("btn-delete");
        document.getElementById("btn0101Edit").classList.remove("btn-edit");
        document.getElementById("btn98Add").classList.remove("btn-add");
        document.getElementById("btn99Add").classList.remove("btn-add");
        document.getElementById("btn0101Print").classList.remove("btn-tools");
        document.getElementById("btn0101ChangeStatus").classList.remove("btn-secondary");
        document.getElementById("btn03010101Add").classList.remove("btn-add");
        document.getElementById("btn989Add").classList.remove("btn-add");
        document.getElementById("btn11Add").classList.remove("btn-add");
        document.getElementById("div11SCM").classList.remove("btn-add");
        document.getElementById("div11OSM").classList.remove("btn-add");
        const button = document.querySelectorAll('.action-button');
        for (const btn of button) {
            btn.classList.remove("btn-active-light");
            btn.disabled = pValue;
        }
    } else {
        document.getElementById("btn0101Find").classList.add("btn-view");
        document.getElementById("btn0101Refresh").classList.add("btn-view");
        document.getElementById("btn0101Add").classList.add("btn-add");
        document.getElementById("btn0101Delete").classList.add("btn-delete");
        document.getElementById("btn0101Edit").classList.add("btn-edit");
        document.getElementById("btn98Add").classList.add("btn-add");
        document.getElementById("btn99Add").classList.add("btn-add");
        document.getElementById("btn0101Print").classList.add("btn-tools");
        document.getElementById("btn0101ChangeStatus").classList.add("btn-secondary");
        document.getElementById("btn03010101Add").classList.add("btn-add");
        document.getElementById("btn989Add").classList.add("btn-add");
        document.getElementById("btn11Add").classList.add("btn-add");
        document.getElementById("div11SCM").classList.add("btn-add");
        document.getElementById("div11OSM").classList.add("btn-add");
        const button = document.querySelectorAll('.action-button');
        for (const btn of button) {
            btn.classList.add("btn-active-light");
            btn.disabled = pValue;
        }
    }
    document.getElementById("btn0101Find").disabled = pValue;
    document.getElementById("btn0101Refresh").disabled = pValue;
    document.getElementById("btn0101Add").disabled = pValue;
    document.getElementById("btn0101Delete").disabled = pValue;
    document.getElementById("btn0101Edit").disabled = pValue;
    document.getElementById("btn98Add").disabled = pValue;
    document.getElementById("btn99Add").disabled = pValue;
    document.getElementById("btn0101Print").disabled = pValue;
    document.getElementById("btn0101ChangeStatus").disabled = pValue;
    document.getElementById("btn03010101Add").disabled = pValue;
    document.getElementById("btn989Add").disabled = pValue;
    document.getElementById("btn11Add").disabled = pValue;
    document.getElementById("div11SCM").disabled = pValue;
    document.getElementById("div11OSM").disabled = pValue;
};
function fn01Toggle(button) {
    const wrapper = button.closest('.action-toggle-wrapper');
    const toggleMenu = wrapper.querySelector('.toggle-menu');

    // Hide all other toggle menus
    document.querySelectorAll('.toggle-menu').forEach(menu => {
        if (menu !== toggleMenu) menu.classList.add('d-none');
    });

    // Toggle current menu
    if (toggleMenu) {
        const isVisible = !toggleMenu.classList.contains('d-none');
        toggleMenu.classList.toggle('d-none');

        // If now visible, add outside click listener
        if (!isVisible) {
            const outsideClickListener = function (event) {
                if (!wrapper.contains(event.target)) {
                    toggleMenu.classList.add('d-none');
                    document.removeEventListener('click', outsideClickListener);
                }
            };
            setTimeout(() => {
                // Allow this click to finish before listening
                document.addEventListener('click', outsideClickListener);
            }, 0);
        }
    }
};
//general

//overview
function fn0101LoadOverview(pMode, pID) {
    if (pMode == "ADD") {
        $.ajax({
            type: "POST",
            url: "Assets/Handler/FRM/FRM000010HND.ashx",
            data: {
                'pFormCode': 'FRM000010',
                'pType': 'Get - Record',
                'pID': pID
            },
            success: function (response) {

                //title
                document.getElementById("spn0101Title").innerText = "New Record";
                document.getElementById("spn0101ID").innerText = "0000000000000";
                document.getElementById("spn0101Status").innerText = "New";
                if (document.getElementById("spn0101Status").innerText == "New") {
                    document.getElementById("spn0101Status").setAttribute("class", "badge badge-lg badge-for-new");
                } else if (document.getElementById("spn0101Status").innerText == "Requested") {
                    document.getElementById("spn0101Status").setAttribute("class", "badge badge-lg badge-for-new");
                } else if (document.getElementById("spn0101Status").innerText == "Endorsed") {
                    document.getElementById("spn0101Status").setAttribute("class", "badge badge-lg badge-for-endorsement");
                } else if (document.getElementById("spn0101Status").innerText == "Approved") {
                    document.getElementById("spn0101Status").setAttribute("class", "badge badge-lg badge-for-approval");
                } else if (document.getElementById("spn0101Status").innerText == "Implemented") {
                    document.getElementById("spn0101Status").setAttribute("class", "badge badge-lg badge-for-implementation");
                } else if (document.getElementById("spn0101Status").innerText == "Clarification") {
                    document.getElementById("spn0101Status").setAttribute("class", "badge badge-lg badge-for-clarification");
                } else if (document.getElementById("spn0101Status").innerText == "For Cancellation") {
                    document.getElementById("spn0101Status").setAttribute("class", "badge badge-lg badge-for-cancelled");
                } else if (document.getElementById("spn0101Status").innerText == "Cancelled") {
                    document.getElementById("spn0101Status").setAttribute("class", "badge badge-lg badge-for-cancelled");
                } else if (document.getElementById("spn0101Status").innerText == "Declined") {
                    document.getElementById("spn0101Status").setAttribute("class", "badge badge-lg badge-for-cancelled");
                } else if (document.getElementById("spn0101Status").innerText == "Accepted") {
                    document.getElementById("spn0101Status").setAttribute("class", "badge badge-lg badge-for-closed");
                };
                //title

                //toolbar
                fn01DisableButtons(true);
                document.getElementById("btn0101Delete").classList.add("btn-delete");
                document.getElementById("btn0101Delete").disabled = false;
                document.getElementById("btn0101Edit").classList.add("btn-edit");
                document.getElementById("btn0101Edit").disabled = false;
                document.getElementById("i0101Edit").classList.remove("la-pencil-alt");
                document.getElementById("i0101Edit").classList.add("la-save");
                //toolbar

                //content
                document.getElementById("div0101Detail").style.display = "none";
                document.getElementById("div0101Update").style.display = "";

                document.getElementById("tbx0101ID").value = "0000000000000";
                document.getElementById("tbx0101FormType").value = "Purchase Request";
                document.getElementById("tbx0101DateRequested").value = new Date().toLocaleDateString('en-US', { year: 'numeric', month: '2-digit', day: '2-digit' });
                document.getElementById("tbx0101DateRequired").value = new Date().toLocaleDateString('en-US', { year: 'numeric', month: '2-digit', day: '2-digit' });

                //name
                $.get('Assets/Handler/FRM/FRM000010HND.ashx',
                    {
                        pFormCode: 'FRM000010',
                        pType: 'Get - Employee'
                    },
                    function (response) {
                        document.getElementById("tbx0101RequestedBy").value = response[0].EmpName;
                        document.getElementById("tbx0101AssignedTo").value = response[0].EmpName;
                    });
                //name

                document.getElementById("tbx0101EndorsedTo").value = "-";
                document.getElementById("tbx0101Status").value = "New";
                $('#ddl0101PurchaseType').val('').trigger('change');
                $('#ddl0101ProjectType').val('').trigger('change');
                document.getElementById("hf0101ProjectType").value = "";
                fn0101Purpose('', '');
                fn0101Vehicle('');
                fn0101Category('');
                document.getElementById("tbx0202Category").value = "";
                document.getElementById("tbx0101ActName").value = "";
                document.getElementById("tbx0101ActLocation").value = "";
                document.getElementById("tbx0101ActDate").value = "";
                document.getElementById("tbx0101Estimate").value = "";
                document.getElementById("hf0101Estimate").value = "";
                document.getElementById("tbx0101Project").value = "";
                document.getElementById("hf0101Subdivision").value = "";
                document.getElementById("hf0101Phase").value = "";
                document.getElementById("hf0101Block").value = "";
                document.getElementById("hf0101Lot").value = "";
                fn0101Subdivision('');
                document.getElementById("tbx0101ChargeTo").value = "";
                document.getElementById("hf0101ChargeCode").value = "";
                document.getElementById("hf0101AcctCode").value = "";
                document.getElementById("hf0101Subsidiary").value = "";
                document.getElementById("tbx0101Division").value = "";
                document.getElementById("hf0101DivCode").value = "";
                document.getElementById("tbx0101Department").value = "";
                document.getElementById("hf0101DeptCode").value = "";
                document.getElementById("tbx0101Remarks").value = "";
                //content

                //division & department
                fn0101Division();
                fn0101Department();
                //division & department

                //show fields
                fn0101ShowFields(pMode);
                //show fields

            },
        });
    } else if (pMode == "DTL") {
        $.ajax({
            type: "POST",
            url: "Assets/Handler/FRM/FRM000010HND.ashx",
            data: {
                'pFormCode': 'FRM000010',
                'pType': 'Get - Record',
                'pID': pID
            },
            success: function (response) {
                if (!response || response.length === 0 || !response[0]) {

                    // Title
                    document.getElementById("spn0101Title").innerText = "-";
                    document.getElementById("spn0101ID").innerText = "-";
                    document.getElementById("spn0101Status").innerText = "-";
                    document.getElementById("spn0101Status").setAttribute("class", "badge badge-lg badge-record-new");
                    document.getElementById("spn0101Status").className = "";
                    fn01DisableButtons(false);
                    document.getElementById("btn0101Delete").title = "Remove";
                    document.getElementById("i0101Edit").classList.add("la-pencil-alt");
                    document.getElementById("i0101Edit").classList.remove("la-save");

                    document.getElementById("div0101Detail").style.display = "";
                    document.getElementById("div0101Update").style.display = "none";

                    document.getElementById("lbl0101ID").innerText = "-";
                    document.getElementById("lbl0101FormType").innerText = "-";
                    document.getElementById("lbl0101DateRequested").innerText = "-";
                    document.getElementById("lbl0101DateRequired").innerText = "-";
                    document.getElementById("lbl0101RequestedBy").innerText = "-";
                    document.getElementById("lbl0101AssignedTo").innerText = "-";
                    document.getElementById("lbl0101EndorsedTo").innerText = "-";
                    document.getElementById("lbl0101Status").innerText = "-";
                    document.getElementById("lbl0101PurchaseType").innerText = "-";
                    document.getElementById("lbl0101ProjectType").innerText = "-";
                    document.getElementById("lbl0101Purpose").innerText = "-";
                    document.getElementById("lbl0101Vehicle").innerText = "-";
                    document.getElementById("lbl0101Category").innerText = "-";
                    document.getElementById("lbl0102Category").innerText = "-";
                    document.getElementById("lbl0101ActName").innerText = "-";
                    document.getElementById("lbl0101ActLocation").innerText = "-";
                    document.getElementById("lbl0101ActDate").innerText = "-";
                    document.getElementById("lbl0101Estimate").innerText = "-";
                    document.getElementById("lbl0101Subdivision").innerText = "-";
                    document.getElementById("lbl0101ChargeTo").innerText = "-";
                    document.getElementById("lbl0101Division").innerText = "-";
                    document.getElementById("lbl0101Department").innerText = "-";
                    document.getElementById("lbl0101Remarks").value = "-";
                    //content

                    return;
                }

                //title
                let overall = 0;
                document.getElementById("spn0101Title").innerText = response[0].FormTitle;
                document.getElementById("spn0101ID").innerText = response[0].FormNo;
                document.getElementById("spn0101Status").innerText = response[0].Status;
                if (document.getElementById("spn0101Status").innerText == "New") {
                    document.getElementById("spn0101Status").setAttribute("class", "badge badge-lg badge-for-new");
                } else if (document.getElementById("spn0101Status").innerText == "Requested") {
                    document.getElementById("spn0101Status").setAttribute("class", "badge badge-lg badge-for-new");
                } else if (document.getElementById("spn0101Status").innerText == "Endorsed") {
                    document.getElementById("spn0101Status").setAttribute("class", "badge badge-lg badge-for-endorsement");
                } else if (document.getElementById("spn0101Status").innerText == "Approved") {
                    document.getElementById("spn0101Status").setAttribute("class", "badge badge-lg badge-for-approval");
                } else if (document.getElementById("spn0101Status").innerText == "Implemented") {
                    document.getElementById("spn0101Status").setAttribute("class", "badge badge-lg badge-for-implementation");
                } else if (document.getElementById("spn0101Status").innerText == "Clarification") {
                    document.getElementById("spn0101Status").setAttribute("class", "badge badge-lg badge-for-clarification");
                } else if (document.getElementById("spn0101Status").innerText == "For Cancellation") {
                    document.getElementById("spn0101Status").setAttribute("class", "badge badge-lg badge-for-cancelled");
                } else if (document.getElementById("spn0101Status").innerText == "Cancelled") {
                    document.getElementById("spn0101Status").setAttribute("class", "badge badge-lg badge-for-cancelled");
                } else if (document.getElementById("spn0101Status").innerText == "Declined") {
                    document.getElementById("spn0101Status").setAttribute("class", "badge badge-lg badge-for-cancelled");
                } else if (document.getElementById("spn0101Status").innerText == "Accepted") {
                    document.getElementById("spn0101Status").setAttribute("class", "badge badge-lg badge-for-closed");
                };
                //title

                //toolbar
                document.getElementById("btn0101Delete").title = "Remove";
                document.getElementById("i0101Edit").classList.add("la-pencil-alt");
                document.getElementById("i0101Edit").classList.remove("la-save");
                fn01DisableButtons(false);
                //checkbox

                //content
                document.getElementById("div0101Detail").style.display = "";
                document.getElementById("div0101Update").style.display = "none";

                document.getElementById("lbl0101ID").innerText = response[0].FormNo;
                document.getElementById("lbl0101FormType").innerText = response[0].FormType;
                document.getElementById("lbl0101DateRequested").innerText = response[0].DateCreated;
                document.getElementById("lbl0101DateRequired").innerText = response[0].DateRequired;
                document.getElementById("lbl0101RequestedBy").innerText = response[0].RequestedBy;
                document.getElementById("lbl0101AssignedTo").innerText = response[0].Approver;
                document.getElementById("lbl0101EndorsedTo").innerText = response[0].EndorsedTo;
                document.getElementById("lbl0101Status").innerText = response[0].Status;
                document.getElementById("lbl0101PurchaseType").innerText = response[0].PurchaseType;
                document.getElementById("lbl0101ProjectType").innerText = response[0].ProjType;
                document.getElementById("lbl0101Purpose").innerText = response[0].Purpose;
                document.getElementById("lbl0101Vehicle").innerText = response[0].VehicleName;
                document.getElementById("lbl0101Category").innerText = response[0].ProjType.includes("(Stock Request)") || response[0].ProjType.includes("Advance PO") ? response[0].Category : "";
                document.getElementById("lbl0102Category").innerText = response[0].Purpose.includes("REPAIR AND MAINTENANCE") ? response[0].Category : "";
                document.getElementById("lbl0101ActName").innerText = response[0].ActName;
                document.getElementById("lbl0101ActLocation").innerText = response[0].ActLocation;
                document.getElementById("lbl0101ActDate").innerText = response[0].ActDate;
                document.getElementById("lbl0101Subdivision").innerText = response[0].SubdName;
                document.getElementById("lbl0101Estimate").innerText = response[0].Category.includes("House Construction") ? response[0].CECode + ' - ' + response[0].SubdName : response[0].EstTitle;
                document.getElementById("lbl0101Project").innerText = response[0].Project;
                document.getElementById("lbl0101ChargeTo").innerText = response[0].ChargeName;
                document.getElementById("lbl0101Division").innerText = response[0].DivName;
                document.getElementById("lbl0101Department").innerText = response[0].DeptName;
                document.getElementById("lbl0101Remarks").innerText = response[0].Remarks;
                //content

                //show fields
                fn0101ShowFields(pMode);
                //show fields

                //particular
                fn0102LoadParticular(document.getElementById("ContentPlaceHolder1_hdnMode").value, document.getElementById("ContentPlaceHolder1_hdnID").value);
                //particular

            },
        });
    } else if (pMode == "UPD") {
        $.ajax({
            type: "POST",
            url: "Assets/Handler/FRM/FRM000010HND.ashx",
            data: {
                'pFormCode': 'FRM000010',
                'pType': 'Get - Record',
                'pID': pID
            },
            success: function (response) {

                //title
                document.getElementById("spn0101Title").innerText = response[0].FormTitle;
                document.getElementById("spn0101ID").innerText = response[0].FormNo;
                document.getElementById("spn0101Status").innerText = response[0].Status;
                if (document.getElementById("spn0101Status").innerText == "New") {
                    document.getElementById("spn0101Status").setAttribute("class", "badge badge-lg badge-for-new");
                } else if (document.getElementById("spn0101Status").innerText == "Requested") {
                    document.getElementById("spn0101Status").setAttribute("class", "badge badge-lg badge-for-new");
                } else if (document.getElementById("spn0101Status").innerText == "Endorsed") {
                    document.getElementById("spn0101Status").setAttribute("class", "badge badge-lg badge-for-endorsement");
                } else if (document.getElementById("spn0101Status").innerText == "Approved") {
                    document.getElementById("spn0101Status").setAttribute("class", "badge badge-lg badge-for-approval");
                } else if (document.getElementById("spn0101Status").innerText == "Implemented") {
                    document.getElementById("spn0101Status").setAttribute("class", "badge badge-lg badge-for-implementation");
                } else if (document.getElementById("spn0101Status").innerText == "Clarification") {
                    document.getElementById("spn0101Status").setAttribute("class", "badge badge-lg badge-for-clarification");
                } else if (document.getElementById("spn0101Status").innerText == "For Cancellation") {
                    document.getElementById("spn0101Status").setAttribute("class", "badge badge-lg badge-for-cancelled");
                } else if (document.getElementById("spn0101Status").innerText == "Cancelled") {
                    document.getElementById("spn0101Status").setAttribute("class", "badge badge-lg badge-for-cancelled");
                } else if (document.getElementById("spn0101Status").innerText == "Declined") {
                    document.getElementById("spn0101Status").setAttribute("class", "badge badge-lg badge-for-cancelled");
                } else if (document.getElementById("spn0101Status").innerText == "Accepted") {
                    document.getElementById("spn0101Status").setAttribute("class", "badge badge-lg badge-for-closed");
                };
                //title

                //toolbar
                fn01DisableButtons(true);
                document.getElementById("btn0101Delete").classList.add("btn-delete");
                document.getElementById("btn0101Delete").title = "Cancel";
                document.getElementById("btn0101Delete").disabled = false;
                document.getElementById("btn0101Edit").classList.add("btn-edit");
                document.getElementById("btn0101Edit").disabled = false;
                document.getElementById("i0101Edit").classList.remove("la-pencil-alt");
                document.getElementById("i0101Edit").classList.add("la-save");
                //toolbar

                //content
                document.getElementById("div0101Detail").style.display = "none";
                document.getElementById("div0101Update").style.display = "";

                document.getElementById("tbx0101ID").value = response[0].FormNo;
                document.getElementById("tbx0101FormType").value = response[0].FormType;
                document.getElementById("tbx0101DateRequested").value = response[0].DateCreated;
                document.getElementById("tbx0101DateRequired").value = response[0].DateRequired;
                document.getElementById("tbx0101RequestedBy").value = response[0].RequestedBy;
                document.getElementById("tbx0101AssignedTo").value = response[0].Approver;
                document.getElementById("tbx0101EndorsedTo").value = response[0].EndorsedTo;
                document.getElementById("tbx0101Status").value = response[0].Status;
                $('#ddl0101PurchaseType').val(response[0].PurchaseType).trigger('change');
                $('#ddl0101ProjectType').val(response[0].ProjType).trigger('change');
                fn0101Purpose(response[0].Purpose, response[0].ProjType);
                fn0101Vehicle(response[0].VehicleCode);
                fn0101Category(response[0].ProjType.includes("(Stock Request)") || response[0].ProjType.includes("Advance PO") ? response[0].Category : "");
                document.getElementById("tbx0202Category").value = response[0].Purpose.includes("REPAIR AND MAINTENANCE") ? response[0].Category : "";
                document.getElementById("tbx0101ActName").value = response[0].ActName;
                document.getElementById("tbx0101ActLocation").value = response[0].ActLocation;
                document.getElementById("tbx0101ActDate").value = response[0].ActDate;
                fn0101Subdivision(response[0].SubdCode);
                document.getElementById("tbx0101Estimate").value = response[0].Category.includes("House Construction") ? response[0].CECode + ' - ' + response[0].SubdName : response[0].EstTitle;
                document.getElementById("hf0101Estimate").value = response[0].CECode;
                document.getElementById("tbx0101Project").value = response[0].Project;
                document.getElementById("hf0101Subdivision").value = response[0].SubdCode;
                document.getElementById("hf0101Phase").value = response[0].PhaseCode;
                document.getElementById("hf0101Block").value = response[0].BlockCode;
                document.getElementById("hf0101Lot").value = response[0].LotCode;
                document.getElementById("tbx0101ChargeTo").value = response[0].ChargeName;
                document.getElementById("hf0101ChargeCode").value = response[0].ChargeCode;
                document.getElementById("hf0101AcctCode").value = response[0].AcctCode;
                document.getElementById("hf0101Subsidiary").value = response[0].Misc;
                document.getElementById("tbx0101Division").value = response[0].DivName;
                document.getElementById("hf0101DivCode").value = response[0].DivCode;
                document.getElementById("tbx0101Department").value = response[0].DeptName;
                document.getElementById("hf0101DeptCode").value = response[0].DeptCode;
                document.getElementById("tbx0101Remarks").value = response[0].Remarks;
                //content

                //show fields
                fn0101ShowFields(pMode);
                //show fields

                //particular
                fn0102LoadParticular(document.getElementById("ContentPlaceHolder1_hdnMode").value, document.getElementById("ContentPlaceHolder1_hdnID").value);
                //particular
            },
        });
    }
};
function fn0101Find() {
    $.ajax({
        type: "POST",
        url: "Assets/Handler/FRM/FRM000010HND.ashx",
        data: {
            'pFormCode': 'FRM000010',
            'pType': 'Find - Record',
        },
        success: function (response) {
            $('#table98Find').DataTable().destroy();
            DataTable.types().forEach(type => { DataTable.type(type, 'detect', () => false); });
            DataTable.datetime('MM/DD/YYYY');
            table98Find = $("#table98Find").DataTable({
                processing: true,
                bFilter: true,
                bPaginate: false,
                bInfo: false,
                paging: false,
                lengthChange: false,
                pageLength: 15,
                select: false,
                data: response,
                columns: [
                    { data: 'Bullet' },
                    { data: 'Data' }],
                rowId: 'rowId',
                columnDefs: [
                    { targets: 0, orderable: false, className: 'tbody-nowrap-auto mw-5px min-w-5px' },
                    { targets: 1, orderable: false, className: 'w-100' }
                ],
                order: [],

            });
            $('#tbx01Find').on('keyup', function () { table98Find.search(this.value).draw(); });
            $('#mdl01Find').modal('show');
        },
    });
};
function fn0101Refresh() {
    fn01Load();
};
function fn0101Add() {
    document.getElementById("ContentPlaceHolder1_hdnMode").value = "ADD";
    document.getElementById("ContentPlaceHolder1_hdnID").value = "0000000000000";
    fn01Load();
};
function fn0101Delete() {
    if (document.getElementById('ContentPlaceHolder1_hdnMode').value == "ADD") {
        Cancel_Add_Question();
    } else if (document.getElementById('ContentPlaceHolder1_hdnMode').value == "DTL") {
        fnIfExist('oop_form_hdr', 'f_code', document.getElementById('ContentPlaceHolder1_hdnID').value, function (response) {
            if (response[0].oReturn == "1") {
                Validate(document.getElementById('ContentPlaceHolder1_hdnID').value);
            } else {
                fnAlertOnly('No active form found!', 'warning', 'btn btn-warning');
            };
        });
        function Validate(ID) {
            fnFRMValidateRecord("01Overview", "Delete", ID, "", "", function (response) {
                if (response[0].Msg === "") {
                    Delete_Dtl_Question(ID);
                } else {
                    fnAlertOnly(response[0].Msg, 'error', 'btn btn-danger');
                };
            });

        }
    } else if (document.getElementById('ContentPlaceHolder1_hdnMode').value == "UPD") {
        Cancel_Upd_Question(document.getElementById('ContentPlaceHolder1_hdnID').value);
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
                if (document.getElementById('ContentPlaceHolder1_hdnPrevID').value == "") {
                    document.getElementById('ContentPlaceHolder1_hdnMode').value = "DTL"
                    document.getElementById('ContentPlaceHolder1_hdnID').value = "0000000000000";
                    fn01Load();
                } else {
                    document.getElementById('ContentPlaceHolder1_hdnMode').value = "DTL";
                    document.getElementById('ContentPlaceHolder1_hdnID').value = document.getElementById('ContentPlaceHolder1_hdnPrevID').value;
                    fn01Load();
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
            fn01Delete('FRM000010', 'FRM000010', ID, function (response) {
                if (document.getElementById('ContentPlaceHolder1_hdnPrevID').value == "") {
                    if (window.opener && typeof window.opener.FRMUpdate === 'function') window.opener.FRMUpdate(ID);
                    document.getElementById('ContentPlaceHolder1_hdnMode').value = "DTL";
                    document.getElementById('ContentPlaceHolder1_hdnID').value = "0000000000000";
                    fn01Load();
                    fnAlertOnly('Record successfully removed!', 'success', 'btn btn-success');
                } else if (document.getElementById('ContentPlaceHolder1_hdnPrevID').value == ID) {
                    if (window.opener && typeof window.opener.FRMUpdate === 'function') window.opener.FRMUpdate(ID);
                    document.getElementById('ContentPlaceHolder1_hdnMode').value = "DTL";
                    document.getElementById('ContentPlaceHolder1_hdnID').value = "0000000000000";
                    fn01Load();
                    fnAlertOnly('Record successfully removed!', 'success', 'btn btn-success');
                } else if (document.getElementById('ContentPlaceHolder1_hdnPrevID').value != ID) {
                    document.getElementById('ContentPlaceHolder1_hdnMode').value = "DTL";
                    document.getElementById('ContentPlaceHolder1_hdnID').value = document.getElementById('ContentPlaceHolder1_hdnPrevID').value;
                    document.getElementById('ContentPlaceHolder1_hdnPrevID').value = document.getElementById('ContentPlaceHolder1_hdnPrevID').value;
                    fn01Load();
                    fnAlertOnly('Record successfully removed!', 'success', 'btn btn-success');
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
                document.getElementById('ContentPlaceHolder1_hdnMode').value = "DTL";
                document.getElementById('ContentPlaceHolder1_hdnID').value = ID;
                document.getElementById('ContentPlaceHolder1_hdnPrevID').value = ID;
                fn0101LoadOverview(document.getElementById('ContentPlaceHolder1_hdnMode').value, document.getElementById('ContentPlaceHolder1_hdnID').value);
            }
        });
    };
};
function fn0101Edit() {
    //validate
    if (document.getElementById('ContentPlaceHolder1_hdnMode').value == "ADD") {
        //access
        ValidateFields("");
    } else if (document.getElementById('ContentPlaceHolder1_hdnMode').value == "DTL") {
        //if exisit
        fnIfExist('oop_form_hdr', 'f_code', document.getElementById('ContentPlaceHolder1_hdnID').value, function (response) {
            if (response[0].oReturn == "1") {
                Validate(document.getElementById('ContentPlaceHolder1_hdnID').value);
            } else {
                fnAlertOnly('No active form found!', 'warning', 'btn btn-warning');
            };
        });
        function Validate(ID) {
            fnFRMValidateRecord("01Overview", "Save", ID, "", "", function (response) {
                if (response[0].Msg === "") {
                    Edit_Dtl_Ok_Await(ID);
                } else {
                    fnAlertOnly(response[0].Msg, 'error', 'btn btn-danger');
                };
            });

        }

    } else if (document.getElementById('ContentPlaceHolder1_hdnMode').value == "UPD") {
        //if exisit
        fnIfExist('oop_form_hdr', 'f_code', document.getElementById('ContentPlaceHolder1_hdnID').value, function (response) {
            if (response[0].oReturn == "1") {
                ValidateFields(document.getElementById('ContentPlaceHolder1_hdnID').value);
            } else {
                fnAlertOnly('No active form found!', 'warning', 'btn btn-warning');
            };
        });
    }
    //validate fields
    function ValidateFields(ID) {
        if (document.getElementById("tbx0101DateRequired").value == "") {
            fnAlertOnly('Some field(s) are missing!', 'error', 'btn btn-danger');
        } else if (document.getElementById("tbx0101FormType").value == "") {
            fnAlertOnly('Some field(s) are missing!', 'error', 'btn btn-danger');
        } else if (document.getElementById("ddl0101PurchaseType").options[document.getElementById("ddl0101PurchaseType").selectedIndex].value == "") {
            fnAlertOnly('Some field(s) are missing!', 'error', 'btn btn-danger');
        } else if (document.getElementById("ddl0101ProjectType").options[document.getElementById("ddl0101ProjectType").selectedIndex].value == "") {
            fnAlertOnly('Some field(s) are missing!', 'error', 'btn btn-danger');
        } else if (document.getElementById("ddl0101Purpose").options[document.getElementById("ddl0101Purpose").selectedIndex].value == "") {
            fnAlertOnly('Some field(s) are missing!', 'error', 'btn btn-danger');
        } else if (document.getElementById("ddl0101ProjectType").options[document.getElementById("ddl0101ProjectType").selectedIndex].value.includes("Advance PO") && document.getElementById("ddl0101Category").options[document.getElementById("ddl0101Category").selectedIndex].value == "") {
            fnAlertOnly('Some field(s) are missing!', 'error', 'btn btn-danger');
        } else if (document.getElementById("ddl0101ProjectType").options[document.getElementById("ddl0101ProjectType").selectedIndex].value.includes("Stock Request") && document.getElementById("ddl0101Category").options[document.getElementById("ddl0101Category").selectedIndex].value == "" && document.getElementById("tbx0101Estimate").value == "" && document.getElementById("hf0101Estimate").value == "") {
            fnAlertOnly('Some field(s) are missing!', 'error', 'btn btn-danger');
        } else if (document.getElementById("ddl0101Purpose").options[document.getElementById("ddl0101Purpose").selectedIndex].value.includes("House Construction") && document.getElementById("ddl0101Subdivision").options[document.getElementById("ddl0101Subdivision").selectedIndex].value == "") {
            fnAlertOnly('Some field(s) are missing!', 'error', 'btn btn-danger');
        } else if (document.getElementById("ddl0101Category").options[document.getElementById("ddl0101Category").selectedIndex].value != "" && document.getElementById("tbx0101Estimate").value == "" && document.getElementById("hf0101Estimate").value == "") {
            fnAlertOnly('Some field(s) are missing!', 'error', 'btn btn-danger');
        } else if (document.getElementById("ddl0101Purpose").options[document.getElementById("ddl0101Purpose").selectedIndex].value == "Others - FUEL" && document.getElementById("ddl0101Vehicle").options[document.getElementById("ddl0101Vehicle").selectedIndex].value == "") {
            fnAlertOnly('Some field(s) are missing!', 'error', 'btn btn-danger');
        } else if (document.getElementById("ddl0101Purpose").options[document.getElementById("ddl0101Purpose").selectedIndex].value == "Others - GRASS CUTTER MAINTENANCE" && document.getElementById("ddl0101Subdivision").options[document.getElementById("ddl0101Subdivision").selectedIndex].value == "") {
            fnAlertOnly('Some field(s) are missing!', 'error', 'btn btn-danger');
        } else if (document.getElementById("ddl0101Purpose").options[document.getElementById("ddl0101Purpose").selectedIndex].value == "Others - HOUSE REPAIR" && (document.getElementById("tbx0101Project").value == "" || document.getElementById("hf0101Subdivision").value == "" || document.getElementById("hf0101Phase").value == "" || document.getElementById("hf0101Block").value == "" || document.getElementById("hf0101Lot").value == "")) {
            fnAlertOnly('Some field(s) are missing!', 'error', 'btn btn-danger');
        } else if (document.getElementById("ddl0101Purpose").options[document.getElementById("ddl0101Purpose").selectedIndex].value == "REPAIR AND MAINTENANCE - Aircon" && document.getElementById("tbx0202Category").value == "") {
            fnAlertOnly('Some field(s) are missing!', 'error', 'btn btn-danger');
        } else if (document.getElementById("ddl0101Purpose").options[document.getElementById("ddl0101Purpose").selectedIndex].value == "REPAIR AND MAINTENANCE - Grass Cutter" && document.getElementById("tbx0202Category").value == "") {
            fnAlertOnly('Some field(s) are missing!', 'error', 'btn btn-danger');
        } else if (document.getElementById("ddl0101Purpose").options[document.getElementById("ddl0101Purpose").selectedIndex].value == "REPAIR AND MAINTENANCE - Tools and Equipment" && document.getElementById("tbx0202Category").value == "") {
            fnAlertOnly('Some field(s) are missing!', 'error', 'btn btn-danger');
        } else if (document.getElementById("ddl0101Purpose").options[document.getElementById("ddl0101Purpose").selectedIndex].value == "REPAIR AND MAINTENANCE - Vehicle" && document.getElementById("tbx0202Category").value == "") {
            fnAlertOnly('Some field(s) are missing!', 'error', 'btn btn-danger');
        } else if (document.getElementById("ddl0101Purpose").options[document.getElementById("ddl0101Purpose").selectedIndex].value == "SALES EVENTS AND ACTIVITIES - Sales Events" && (document.getElementById("tbx0101ActName").value == "" || document.getElementById("tbx0101ActLocation").value == "" || document.getElementById("tbx0101ActDate").value == "")) {
            fnAlertOnly('Some field(s) are missing!', 'error', 'btn btn-danger');
        } else if ((document.getElementById("ddl0101ProjectType").options[document.getElementById("ddl0101ProjectType").selectedIndex].value == "Non OSM Project" || document.getElementById("ddl0101ProjectType").options[document.getElementById("ddl0101ProjectType").selectedIndex].value == "OSM Project" || document.getElementById("ddl0101ProjectType").options[document.getElementById("ddl0101ProjectType").selectedIndex].value.includes("Advance PO")) && document.getElementById("tbx0101ChargeTo").value == "") {
            fnAlertOnly('Some field(s) are missing!', 'error', 'btn btn-danger');
        } else if (document.getElementById("tbx0101Remarks").value == "") {
            fnAlertOnly('Some field(s) are missing!', 'error', 'btn btn-danger');
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
                if (document.getElementById('ContentPlaceHolder1_hdnMode').value == "ADD") {
                    Edit_Add_Ok_Await();
                } else if (document.getElementById('ContentPlaceHolder1_hdnMode').value == "DTL") {
                    Edit_Dtl_Ok_Await(ID);
                } else if (document.getElementById('ContentPlaceHolder1_hdnMode').value == "UPD") {
                    fnIfExist('oop_form_hdr', 'f_code', document.getElementById('ContentPlaceHolder1_hdnID').value, function (response) {
                        if (response[0].oReturn == "1") {
                            Edit_Upd_Ok_Await(ID);
                        } else {
                            fnAlertOnly('No active form found!', 'warning', 'btn btn-warning');
                        };
                    });
                }
            }
        });
    };
    function Edit_Add_Ok_Await() {
        fn01DisableButtons(true);
        $.ajax({
            type: "POST",
            url: "Assets/Handler/FRM/FRM000010HND.ashx",
            data: {
                'pFormCode': 'FRM000010',
                'pType': 'Add - Record',
                'pDateRequired': document.getElementById("tbx0101DateRequired").value,
                'pPurchaseType': document.getElementById("ddl0101PurchaseType").options[document.getElementById("ddl0101PurchaseType").selectedIndex].value,
                'pDeptCode': document.getElementById("hf0101DeptCode").value,
                'pProjType': document.getElementById("ddl0101ProjectType").options[document.getElementById("ddl0101ProjectType").selectedIndex].value,
                'pPurpose': document.getElementById("ddl0101Purpose").options[document.getElementById("ddl0101Purpose").selectedIndex].value,
                'pSubdCode': document.getElementById("ddl0101Subdivision").options[document.getElementById("ddl0101Subdivision").selectedIndex].value,
                'pPhase': document.getElementById("hf0101Phase").value,
                'pBlock': document.getElementById("hf0101Block").value,
                'pLot': document.getElementById("hf0101Lot").value,
                'pCarCode': document.getElementById("ddl0101Vehicle").options[document.getElementById("ddl0101Vehicle").selectedIndex].value,
                'pCategory01': document.getElementById("ddl0101Category").options[document.getElementById("ddl0101Category").selectedIndex].value,
                'pCategory02': document.getElementById("tbx0202Category").value,
                'pActName': document.getElementById("tbx0101ActName").value,
                'pActLocation': document.getElementById("tbx0101ActLocation").value,
                'pActDate': document.getElementById("tbx0101ActDate").value,
                'pCECode': document.getElementById("hf0101Estimate").value,
                'pRemarks': document.getElementById("tbx0101Remarks").value,
                'pChargeCode': document.getElementById("hf0101ChargeCode").value,
                'pAcctCode': document.getElementById("hf0101AcctCode").value,
                'pMisc': document.getElementById("hf0101Subsidiary").value,
                'pDivision': document.getElementById("hf0101DivCode").value,
            },

            success: function (response) {
                fnAlertOnly('Record successfully saved.', 'success', 'btn btn-success');
                document.getElementById('ContentPlaceHolder1_hdnMode').value = "DTL"
                document.getElementById('ContentPlaceHolder1_hdnID').value = response[0].oFCode
                document.getElementById('ContentPlaceHolder1_hdnPrevID').value = response[0].oFCode
                fn01Load();
                fn01DisableButtons(false);
            },
        });
    };
    function Edit_Dtl_Ok_Await(ID) {
        document.getElementById('ContentPlaceHolder1_hdnMode').value = "UPD"
        document.getElementById('ContentPlaceHolder1_hdnID').value = ID;
        document.getElementById('ContentPlaceHolder1_hdnPrevID').value = ID;
        fn01Load();
    };
    function Edit_Upd_Ok_Await(ID) {
        $.ajax({
            type: "POST",
            url: "Assets/Handler/FRM/FRM000010HND.ashx",
            data: {
                'pFormCode': 'FRM000010',
                'pType': 'Update - Record',
                'pID': ID,
                'pDateRequired': document.getElementById("tbx0101DateRequired").value,
                'pPurchaseType': document.getElementById("ddl0101PurchaseType").options[document.getElementById("ddl0101PurchaseType").selectedIndex].value,
                'pDeptCode': document.getElementById("hf0101DeptCode").value,
                'pProjType': document.getElementById("ddl0101ProjectType").options[document.getElementById("ddl0101ProjectType").selectedIndex].value,
                'pPurpose': document.getElementById("ddl0101Purpose").options[document.getElementById("ddl0101Purpose").selectedIndex].value,
                'pSubdCode': document.getElementById("ddl0101Subdivision").options[document.getElementById("ddl0101Subdivision").selectedIndex].value,
                'pPhase': document.getElementById("hf0101Phase").value,
                'pBlock': document.getElementById("hf0101Block").value,
                'pLot': document.getElementById("hf0101Lot").value,
                'pCarCode': document.getElementById("ddl0101Vehicle").options[document.getElementById("ddl0101Vehicle").selectedIndex].value,
                'pCategory01': document.getElementById("ddl0101Category").options[document.getElementById("ddl0101Category").selectedIndex].value,
                'pCategory02': document.getElementById("tbx0202Category").value,
                'pActName': document.getElementById("tbx0101ActName").value,
                'pActLocation': document.getElementById("tbx0101ActLocation").value,
                'pActDate': document.getElementById("tbx0101ActDate").value,
                'pCECode': document.getElementById("hf0101Estimate").value,
                'pRemarks': document.getElementById("tbx0101Remarks").value,
                'pChargeCode': document.getElementById("hf0101ChargeCode").value,
                'pAcctCode': document.getElementById("hf0101AcctCode").value,
                'pMisc': document.getElementById("hf0101Subsidiary").value,
                'pDivision': document.getElementById("hf0101DivCode").value
            },
            success: function (response) {
                fnAlertOnly('Record successfully saved.', 'success', 'btn btn-success');
                if (window.opener && typeof window.opener.FRMUpdate === 'function') window.opener.FRMUpdate(ID);
                document.getElementById('ContentPlaceHolder1_hdnMode').value = "DTL"
                document.getElementById('ContentPlaceHolder1_hdnID').value = ID;
                document.getElementById('ContentPlaceHolder1_hdnPrevID').value = ID;
                fn01Load();
            },
        });
    };
};
function fn0101ChangeStatus() {
    fnIfExist('oop_form_hdr', 'f_code', document.getElementById('ContentPlaceHolder1_hdnID').value, function (response) {
        if (response[0].oReturn == "1") {
            FRMValidateRecord(document.getElementById('ContentPlaceHolder1_hdnID').value);
        } else {
            fnAlertOnly('No active form found!', 'warning', 'btn btn-warning');
        };
    });
    function FRMValidateRecord(ID) {
        fnFRMValidateRecord("01Overview", "Status", ID, "", "", function (response) {
            if (response[0].Msg === "") {
                ddl0103ChangeStatus('');
                ddl0103Clarifyto('');
                $('#mdl0103Status').modal('show');
            } else {
                fnAlertOnly(response[0].Msg, 'error', 'btn btn-danger');
            };
        });

    }

};
function ddl0101Status_onchange(pID) {
    if (pID === "Clarify") {
        document.getElementById('pnl01ClarifyTo').style.display = 'inline-flex';
        ddl01ClarifyTo("")
    } else if (pID === "Declined") {
        document.getElementById('spn01Note').classList = 'input-group-text input-group-text-top min-w-150px required';
    } else {
        document.getElementById('pnl01ClarifyTo').style.display = 'none';
        document.getElementById('spn01Note').classList = 'input-group-text input-group-text-top min-w-150px';
    }
};
function ddl01Status(pID) {
    $.ajax({
        type: "POST",
        url: "Assets/Handler/FRM/FRM000010HND.ashx",
        data: {
            'pFunction': 'Get - Record - List',
            'pTblName': 'Status',
            'pPlaceHolder': 'Select a category',
            'pFrmCode': '',
            'pAprType': '',
            'pID': document.getElementById('ContentPlaceHolder1_hdnID').value

        },
        success: function (response) {
            var s = '';
            for (var i = 0; i < response.length; i++) {
                s += '<option value="' + response[i].ID + '">' + response[i].Name + '</option>';
            }
            $("#ddl0101Status").html(s);
            $('#ddl0101Status').val(pID).trigger('change');
        },
    });
};
function ddl0103ChangeStatus(ID) {
    $.ajax({
        type: "POST",
        url: "Assets/Handler/FRM/FRM000010HND.ashx",
        data: {
            'pFunction': 'Dropdown',
            'pType': 'Get - Dropdown - List',
            'pTblName': 'Change_Status',
            'pPlaceHolder': '',
            'pVal01': document.getElementById("ContentPlaceHolder1_hdnID").value,
            'pVal02': ''
        },
        success: function (response) {
            var s = '';
            for (var i = 0; i < response.length; i++) {
                s += '<option value="' + response[i].ID + '">' + response[i].Name + '</option>';
            }
            $("#ddl0103ChangeStatus").html(s);
            $('#ddl0103ChangeStatus').val(ID).trigger('change');
        },
    });
};
function ddl0103ChangeStatus_onchange(ddl0103ChangeStatus) {

    document.getElementById("pnl01ClarifyTo").style.display = "none";
    const ddlStatus = ddl0103ChangeStatus.value;

    if (ddlStatus === "Clarify") {
        document.getElementById("pnl01ClarifyTo").fnstyle.display = "";
    }
    if (ddlStatus === "Declined") {
        document.getElementById("spn01Note").classList.add("required");
    } else {
        document.getElementById("spn01Note").classList.remove("required");
    }
}
function ddl0103Clarifyto(ID) {
    $.ajax({
        type: "POST",
        url: "Assets/Handler/FRM/FRM000010HND.ashx",
        data: {
            'pFunction': 'Dropdown',
            'pType': 'Get - Dropdown - List',
            'pTblName': 'Clarify_To',
            'pPlaceHolder': '',
            'pVal01': document.getElementById("ContentPlaceHolder1_hdnID").value,
            'pVal02': ''
        },
        success: function (response) {
            var s = '';
            for (var i = 0; i < response.length; i++) {
                s += '<option value="' + response[i].ID + '">' + response[i].Name + '</option>';
            }
            $("#ddl0103Clarifyto").html(s);
            $('#ddl0103Clarifyto').val(ID).trigger('change');
        },
    });
};
function fn0101SaveChangeStatus() {
    fnIfExist('oop_form_hdr', 'f_code', document.getElementById('ContentPlaceHolder1_hdnID').value, function (response) {
        if (response[0].oReturn == "1") {
            FRMValidateRecord(document.getElementById('ContentPlaceHolder1_hdnID').value);
        } else {
            fnAlertOnly('No active form found!', 'warning', 'btn btn-warning');
        };
    });
    function FRMValidateRecord(ID) {
        fnFRMValidateRecord("01Overview", "Status", ID, document.getElementById("ddl0103ChangeStatus").options[document.getElementById("ddl0103ChangeStatus").selectedIndex].value, "", function (response) {
            if (response[0].Msg === "") {
                ValidateFields(document.getElementById("ContentPlaceHolder1_hdnID").value);
            } else {
                fnAlertOnly(response[0].Msg, 'error', 'btn btn-danger');
            };
        });

    }
    function ValidateFields(ID) {
        if (document.getElementById("ddl0103ChangeStatus").options[document.getElementById("ddl0103ChangeStatus").selectedIndex].value === "") {
            fnAlertOnly('Some field(s) are missing!', 'error', 'btn btn-danger');
        } else if (document.getElementById("ddl0103ChangeStatus").options[document.getElementById("ddl0103ChangeStatus").selectedIndex].value === "Clarify" && document.getElementById("ddl0103Clarifyto").options[document.getElementById("ddl0103Clarifyto").selectedIndex].value === "") {
            fnAlertOnly('Some field(s) are missing!', 'error', 'btn btn-danger');
        } else if (document.getElementById("ddl0103ChangeStatus").options[document.getElementById("ddl0103ChangeStatus").selectedIndex].value === "Declined" && document.getElementById("tbx0103Note").value === "") {
            fnAlertOnly('Some field(s) are missing!', 'error', 'btn btn-danger');
        }
        else {
            SaveChange_Ok(ID);
        }
    }
    function SaveChange_Ok(ID) {
        $.ajax({
            type: "POST",
            url: "Assets/Handler/FRM/FRM000010HND.ashx",
            data: {
                'pFormCode': 'FRM000010',
                'pType': 'Update - Record Approver',
                'pID': ID,
                'pStatus': document.getElementById("ddl0103ChangeStatus").options[document.getElementById("ddl0103ChangeStatus").selectedIndex].value,
                'pAssignTo': document.getElementById("ddl0103Clarifyto").options[document.getElementById("ddl0103Clarifyto").selectedIndex].value,
                'pRemarks': document.getElementById("tbx0103Note").value,
                'pMention': document.getElementById("hdnMention").value
            },
            success: function (response) {
                fnAlertOnly('Record successfully saved.', 'success', 'btn btn-success');
                document.getElementById('ContentPlaceHolder1_hdnMode').value = 'DTL';
                ddl0103ChangeStatus('');
                ddl0103Clarifyto('');
                document.getElementById("tbx0103Note").value = "";
                document.getElementById("hdnMention").value = "";
                fn01Load();
            }
        });
    }

}
//dropdown
function fn0101Purpose(ID, ProjectType) {
    $.ajax({
        type: "POST",
        url: "Assets/Handler/FRM/FRM000010HND.ashx",
        data: {
            'pFunction': 'Dropdown',
            'pType': 'Get - Dropdown - Filter',
            'pFilter': ProjectType,
            'pTblName': 'Get_Purpose',
            'pPlaceHolder': 'Select Purpose'
        },
        success: function (response) {
            var s = '';
            for (var i = 0; i < response.length; i++) {
                s += '<option value="' + response[i].ID + '">' + response[i].Name + '</option>';
            }
            $("#ddl0101Purpose").html(s);
            $('#ddl0101Purpose').val(ID).trigger('change');
        },
    });
};
function fn0101Vehicle(ID) {
    $.ajax({
        type: "POST",
        url: "Assets/Handler/FRM/FRM000010HND.ashx",
        data: {
            'pFunction': 'Dropdown',
            'pType': 'Get - Dropdown',
            'pTblName': 'Get_Vehicle',
            'pPlaceHolder': 'Select Vehicle'
        },
        success: function (response) {
            var s = '';
            for (var i = 0; i < response.length; i++) {
                s += '<option value="' + response[i].ID + '">' + response[i].Name + '</option>';
            }
            $("#ddl0101Vehicle").html(s);
            $('#ddl0101Vehicle').val(ID).trigger('change');
        },
    });
};
function fn0101Category(ID) {
    $.ajax({
        type: "POST",
        url: "Assets/Handler/FRM/FRM000010HND.ashx",
        data: {
            'pFunction': 'Dropdown',
            'pType': 'Get - Dropdown',
            'pTblName': 'Get_Category',
            'pPlaceHolder': 'Select Category'
        },
        success: function (response) {
            var s = '';
            for (var i = 0; i < response.length; i++) {
                s += '<option value="' + response[i].ID + '">' + response[i].Name + '</option>';
            }
            $("#ddl0101Category").html(s);
            $('#ddl0101Category').val(ID).trigger('change');
        },
    });
};
function fn0101Subdivision(ID) {
    $.ajax({
        type: "POST",
        url: "Assets/Handler/FRM/FRM000010HND.ashx",
        data: {
            'pFunction': 'Dropdown',
            'pType': 'Get - Dropdown',
            'pTblName': 'Get_Subdivision',
            'pPlaceHolder': 'Select Subdivision'
        },
        success: function (response) {
            var s = '';
            for (var i = 0; i < response.length; i++) {
                s += '<option value="' + response[i].ID + '">' + response[i].Name + '</option>';
            }
            $("#ddl0101Subdivision").html(s);
            $('#ddl0101Subdivision').val(ID).trigger('change');
        },
    });
};
//dropdown

//division
function fn0101Division() {
    $.ajax({
        type: "POST",
        url: "Assets/Handler/FRM/FRM000010HND.ashx",
        data: {
            'pFormCode': 'FRM000010',
            'pType': 'Get - Division'
        },
        success: function (response) {
            document.getElementById("tbx0101Division").value = response[0].DivName;
            document.getElementById("hf0101DivCode").value = response[0].DivCode;
        },
    });
};
//department
function fn0101Department() {
    $.ajax({
        type: "POST",
        url: "Assets/Handler/FRM/FRM000010HND.ashx",
        data: {
            'pFormCode': 'FRM000010',
            'pType': 'Get - Department'
        },
        success: function (response) {
            document.getElementById("tbx0101Department").value = response[0].DeptName;
            document.getElementById("hf0101DeptCode").value = response[0].DeptCode;
        },
    });
};
//GL account
function fn0101GLAccount(pPurpose) {
    $.ajax({
        type: "POST",
        url: "Assets/Handler/FRM/FRM000010HND.ashx",
        data: {
            'pFormCode': 'FRM000010',
            'pType': 'Get - GL Account',
            'pPurpose': pPurpose
        },
        success: function (response) {
            //Account
            document.getElementById("hf0101AcctCode").value = response[0].AcctCode;
            //Division
            document.getElementById("tbx0101Division").value = response[0].DivName;
            document.getElementById("hf0101DivCode").value = response[0].DivCode;
            //Department
            document.getElementById("tbx0101Department").value = response[0].DeptName;
            document.getElementById("hf0101DeptCode").value = response[0].DeptCode;
            //Subsidiary
            document.getElementById("hf0101Subsidiary").value = response[0].Subsidiary;
            //Charge
            document.getElementById("hf0101ChargeCode").value = response[0].ChargeCode;
            //Description
            document.getElementById("tbx0101ChargeTo").value = response[0].Description;
        }
    });
};

//show fields
function fn0101ShowFields(pMode) {
    if (pMode == "ADD" || pMode == "UPD") {
        document.getElementById("div0102Vehicle").style.display = "none";
        document.getElementById("div0201Category").style.display = "none";
        document.getElementById("div0202Category").style.display = "none";
        document.getElementById("div0102ActName").style.display = "none";
        document.getElementById("div0102ActLocation").style.display = "none";
        document.getElementById("div0102ActDate").style.display = "none";
        document.getElementById("div0102Estimate").style.display = "none";
        document.getElementById("div0102Project").style.display = "none";
        document.getElementById("div0102Subdivision").style.display = "none";
        document.getElementById("div0102ChargeTo").style.display = "none";

        //Particular
        //Button
        document.getElementById("btn11Add").style.display = "";
        document.getElementById("div11SCM").style.display = "none";
        document.getElementById("div11OSM").style.display = "none";

        //Table
        document.getElementById("table11Record").style.display = "none";
        document.getElementById("table12Record").style.display = "none";
        //Particular

        //Project Type
        if (document.getElementById("ddl0101ProjectType").options[document.getElementById("ddl0101ProjectType").selectedIndex].value == "Non OSM Project" || document.getElementById("ddl0101ProjectType").options[document.getElementById("ddl0101ProjectType").selectedIndex].value == "OSM Project" || document.getElementById("ddl0101ProjectType").options[document.getElementById("ddl0101ProjectType").selectedIndex].value.includes("Advance PO")) {
            document.getElementById("div0102ChargeTo").style.display = "";
        };

        //Project Type - Advance PO
        if (document.getElementById("ddl0101ProjectType").options[document.getElementById("ddl0101ProjectType").selectedIndex].value == "OSM Project (Advance PO)" || document.getElementById("ddl0101ProjectType").options[document.getElementById("ddl0101ProjectType").selectedIndex].value == "CCI Project (Advance PO)") {
            document.getElementById("div0201Category").style.display = "";
        };

        //Project Type - Stock Request
        if (document.getElementById("ddl0101ProjectType").options[document.getElementById("ddl0101ProjectType").selectedIndex].value == "OSM Project (Stock Request)" || document.getElementById("ddl0101ProjectType").options[document.getElementById("ddl0101ProjectType").selectedIndex].value == "CCI Project (Stock Request)") {
            document.getElementById("div0201Category").style.display = "";
        };

        //Category - House Construction
        if (document.getElementById("ddl0101Category").options[document.getElementById("ddl0101Category").selectedIndex].value == "House Construction" || document.getElementById("ddl0101Category").options[document.getElementById("ddl0101Category").selectedIndex].value == "House Construction - CCI") {
            document.getElementById("div0102Estimate").style.display = "";
            document.getElementById("spn0102Estimate").innerText = "Batch";
            document.getElementById("tbx0101Estimate").placeholder = "Add batch";
            document.getElementById("div0102Subdivision").style.display = "";
            //Table
            document.getElementById("table12Record").style.display = "";
        } else if (document.getElementById("ddl0101Category").options[document.getElementById("ddl0101Category").selectedIndex].value != "" && (document.getElementById("ddl0101Category").options[document.getElementById("ddl0101Category").selectedIndex].value != "House Construction" || document.getElementById("ddl0101Category").options[document.getElementById("ddl0101Category").selectedIndex].value != "House Construction - CCI")) {
            document.getElementById("div0102Estimate").style.display = "";
            document.getElementById("spn0102Estimate").innerText = "Estimate";
            document.getElementById("tbx0101Estimate").placeholder = "Add estimate";
            document.getElementById("table11Record").style.display = "";
        };

        //Project Type - Fuel
        if (document.getElementById("ddl0101Purpose").options[document.getElementById("ddl0101Purpose").selectedIndex].value == "Others - FUEL") {
            document.getElementById("div0102Vehicle").style.display = "";
        };

        //Project Type - Grass Cutter
        if (document.getElementById("ddl0101Purpose").options[document.getElementById("ddl0101Purpose").selectedIndex].value == "Others - GRASS CUTTER MAINTENANCE") {
            document.getElementById("div0102Subdivision").style.display = "";
        };

        //Project Type - House Repair
        if (document.getElementById("ddl0101Purpose").options[document.getElementById("ddl0101Purpose").selectedIndex].value == "Others - HOUSE REPAIR") {
            document.getElementById("div0102Project").style.display = "";
        };

        //Project Type - Marketing Materials
        if (document.getElementById("ddl0101Purpose").options[document.getElementById("ddl0101Purpose").selectedIndex].value == "MARKETING MATERIALS - Events & Activities") {
            document.getElementById("div0102ActName").style.display = "";
            document.getElementById("div0102ActLocation").style.display = "";
            document.getElementById("div0102ActDate").style.display = "";
        };

        //Project Type - REPAIR AND MAINTENANCE - Aircon
        if (document.getElementById("ddl0101Purpose").options[document.getElementById("ddl0101Purpose").selectedIndex].value == "REPAIR AND MAINTENANCE - Aircon") {
            document.getElementById("div0202Category").style.display = "";
            document.getElementById("spn0202Category").innerText = "FFE No.";
            document.getElementById("tbx0202Category").placeholder = "Add ffe no";
        };

        //Project Type - REPAIR AND MAINTENANCE - Grass Cutter
        if (document.getElementById("ddl0101Purpose").options[document.getElementById("ddl0101Purpose").selectedIndex].value == "REPAIR AND MAINTENANCE - Grass Cutter") {
            document.getElementById("div0202Category").style.display = "";
            document.getElementById("spn0202Category").innerText = "Model No.";
            document.getElementById("tbx0202Category").placeholder = "Add model no";
        };

        //Project Type - REPAIR AND MAINTENANCE - Tools and Equipment
        if (document.getElementById("ddl0101Purpose").options[document.getElementById("ddl0101Purpose").selectedIndex].value == "REPAIR AND MAINTENANCE - Tools and Equipment") {
            document.getElementById("div0202Category").style.display = "";
            document.getElementById("spn0202Category").innerText = "Tools";
            document.getElementById("tbx0202Category").placeholder = "Add tools details";
        };

        //Project Type - REPAIR AND MAINTENANCE - Vehicle
        if (document.getElementById("ddl0101Purpose").options[document.getElementById("ddl0101Purpose").selectedIndex].value == "REPAIR AND MAINTENANCE - Vehicle") {
            document.getElementById("div0202Category").style.display = "";
            document.getElementById("spn0202Category").innerText = "Plate No.";
            document.getElementById("tbx0202Category").placeholder = "Add plate no";
        };

    } else if (pMode == "DTL") {
        document.getElementById("div0101Vehicle").style.display = "none";
        document.getElementById("div0101Category").style.display = "none";
        document.getElementById("div0102Category").style.display = "none";
        document.getElementById("div0101ActName").style.display = "none";
        document.getElementById("div0101ActLocation").style.display = "none";
        document.getElementById("div0101ActDate").style.display = "none";
        document.getElementById("div0101Estimate").style.display = "none";
        document.getElementById("div0101Project").style.display = "none";
        document.getElementById("div0101Subdivision").style.display = "none";
        document.getElementById("div0101ChargeTo").style.display = "none";

        //Particular
        //Button
        document.getElementById("btn11Add").style.display = "none";
        document.getElementById("div11SCM").style.display = "none";
        document.getElementById("div11OSM").style.display = "none";

        //Table
        document.getElementById("table11Record").style.display = "none";
        document.getElementById("table12Record").style.display = "none";
        //Particular

        //Project Type
        if (document.getElementById("lbl0101ProjectType").innerText == "Non OSM Project" || document.getElementById("lbl0101ProjectType").innerText == "OSM Project") {
            document.getElementById("btn11Add").style.display = "";
        };
        if (document.getElementById("lbl0101ProjectType").innerText == "Non OSM Project" || document.getElementById("lbl0101ProjectType").innerText == "OSM Project" || document.getElementById("lbl0101ProjectType").innerText.includes("Advance PO")) {
            document.getElementById("div0101ChargeTo").style.display = "";
        };

        //Project Type - Advance PO
        if (document.getElementById("lbl0101ProjectType").innerText == "OSM Project (Advance PO)" || document.getElementById("lbl0101ProjectType").innerText == "CCI Project (Advance PO)") {
            document.getElementById("div0101Category").style.display = "";

            document.getElementById("btn11Add").style.display = "none";
            document.getElementById("div11SCM").style.display = "";
            document.getElementById("div11OSM").style.display = "none";
        };

        //Project Type - Stock Request
        if (document.getElementById("lbl0101ProjectType").innerText == "OSM Project (Stock Request)" || document.getElementById("lbl0101ProjectType").innerText == "CCI Project (Stock Request)") {
            document.getElementById("div0101Category").style.display = "";

            document.getElementById("btn11Add").style.display = "none";
            document.getElementById("div11SCM").style.display = "none";
            document.getElementById("div11OSM").style.display = "";
        };

        //Category - House Construction
        if (document.getElementById("lbl0101Category").innerText == "House Construction" || document.getElementById("lbl0101Category").innerText == "House Construction - CCI") {
            document.getElementById("div0101Estimate").style.display = "";
            document.getElementById("spn0101Estimate").innerText = "Batch";
            document.getElementById("div0101Subdivision").style.display = "";

            document.getElementById("btn11Add").style.display = "none";
            document.getElementById("table12Record").style.display = "";
        } else if (document.getElementById("lbl0101Category").innerText !== "" && (document.getElementById("lbl0101Category").innerText !== "House Construction" || document.getElementById("lbl0101Category").innerText !== "House Construction - CCI")) {
            document.getElementById("div0101Estimate").style.display = "";
            document.getElementById("spn0101Estimate").innerText = "Estimate";

            document.getElementById("btn11Add").style.display = "none";
            document.getElementById("table11Record").style.display = "";
        };

        //Project Type - Fuel
        if (document.getElementById("lbl0101Purpose").innerText == "Others - FUEL") {
            document.getElementById("div0101Vehicle").style.display = "";
        };

        //Project Type - Grass Cutter
        if (document.getElementById("lbl0101Purpose").innerText == "Others - GRASS CUTTER MAINTENANCE") {
            document.getElementById("div0101Subdivision").style.display = "";
        };

        //Project Type - House Repair
        if (document.getElementById("lbl0101Purpose").innerText == "Others - HOUSE REPAIR") {
            document.getElementById("div0101Project").style.display = "";
        };

        //Project Type - Marketing Materials
        if (document.getElementById("lbl0101Purpose").innerText == "MARKETING MATERIALS - Events & Activities") {
            document.getElementById("div0101ActName").style.display = "";
            document.getElementById("div0101ActLocation").style.display = "";
            document.getElementById("div0101ActDate").style.display = "";
        };

        //Project Type - REPAIR AND MAINTENANCE - Aircon
        if (document.getElementById("lbl0101Purpose").innerText == "REPAIR AND MAINTENANCE - Aircon") {
            document.getElementById("div0102Category").style.display = "";
            document.getElementById("spn0102Category").innerText = "FFE No.";
        };

        //Project Type - REPAIR AND MAINTENANCE - Grass Cutter
        if (document.getElementById("lbl0101Purpose").innerText == "REPAIR AND MAINTENANCE - Grass Cutter") {
            document.getElementById("div0102Category").style.display = "";
            document.getElementById("spn0102Category").innerText = "Model No.";
        };

        //Project Type - REPAIR AND MAINTENANCE - Tools and Equipment
        if (document.getElementById("lbl0101Purpose").innerText == "REPAIR AND MAINTENANCE - Tools and Equipment") {
            document.getElementById("div0102Category").style.display = "";
            document.getElementById("spn0102Category").innerText = "Tools";
        };

        //Project Type - REPAIR AND MAINTENANCE - Vehicle
        if (document.getElementById("lbl0101Purpose").innerText == "REPAIR AND MAINTENANCE - Vehicle") {
            document.getElementById("div0102Category").style.display = "";
            document.getElementById("spn0102Category").innerText = "Plate No.";
        };
    }
};

//onchange
function ddl0101PurchaseType_onchange(ddl0101PurchaseType) {
    document.getElementById("ddl0101ProjectType").disabled = true;
    document.getElementById("ddl0101Purpose").disabled = true;
    if (ddl0101PurchaseType.value != "") {
        $('#ddl0101Category').val('').trigger('change');
        $('#ddl0101Purpose').val('').trigger('change');
        $('#ddl0101ProjectType').val('').trigger('change');
        document.getElementById("ddl0101ProjectType").disabled = false;
    };

    //Return
    if (ddl0101PurchaseType.value == "Return") {
        $('#ddl0101ProjectType option[value="OSM Project (Advance PO)"]').prop('disabled', true);
        $('#ddl0101ProjectType option[value="OSM Project (Stock Request)"]').prop('disabled', true);
        $('#ddl0101ProjectType option[value="CCI Project (Advance PO)"]').prop('disabled', true);
        $('#ddl0101ProjectType option[value="CCI Project (Stock Request)"]').prop('disabled', true);
    } else {
        $('#ddl0101ProjectType option[value="OSM Project (Advance PO)"]').prop('disabled', false);
        $('#ddl0101ProjectType option[value="OSM Project (Stock Request)"]').prop('disabled', false);
        $('#ddl0101ProjectType option[value="CCI Project (Advance PO)"]').prop('disabled', false);
        $('#ddl0101ProjectType option[value="CCI Project (Stock Request)"]').prop('disabled', false);
    };
};
function dd0101ProjectType_onchange(ddl0101ProjectType) {
    document.getElementById("ddl0101Purpose").disabled = true;
    if (ddl0101ProjectType.value != "") {
        document.getElementById("ddl0101Purpose").disabled = false;
        fn0101Purpose('', ddl0101ProjectType.value);
        $('#ddl0101Category').val('').trigger('change');
        fn0101ShowFields(document.getElementById("ContentPlaceHolder1_hdnMode").value);
    };
};
function ddl0101Purpose_onchange(ddl0101Purpose) {
    if (ddl0101Purpose.value != "") {
        $('#ddl0101Category').val('').trigger('change');
        fn0101GLAccount(ddl0101Purpose.value);
        fn0101ShowFields(document.getElementById("ContentPlaceHolder1_hdnMode").value);
    };
};
function ddl0101Category_onchange(ddl0101Category) {
    if (ddl0101Category.value != "") {
        document.getElementById("tbx0101Estimate").value = "";
        document.getElementById("hf0101Estimate").value = "";
        fn0101ShowFields(document.getElementById("ContentPlaceHolder1_hdnMode").value);
    };
};

//estimate
function fn0101Estimate() {
    const ddl0101Category = document.getElementById("ddl0101Category").options[document.getElementById("ddl0101Category").selectedIndex].value;
    const ddl0101Subdivision = document.getElementById("ddl0101Subdivision").options[document.getElementById("ddl0101Subdivision").selectedIndex].value;
    const ddl0101ProjectType = document.getElementById("ddl0101ProjectType").options[document.getElementById("ddl0101ProjectType").selectedIndex].value;
    if (ddl0101ProjectType != "") {

        if (ddl0101Category == "House Construction" || ddl0101Category == "House Construction - CCI") {
            if (ddl0101Subdivision == "") {
                fnAlertOnly('Please select a subdivision!', 'error', 'btn btn-danger');
            } else {
                //Ajax
                $.ajax({
                    type: "POST",
                    url: "Assets/Handler/FRM/FRM000010HND.ashx",
                    data: {
                        'pFormCode': 'FRM000010',
                        'pType': 'Get - Batch',
                        'pProjType': ddl0101ProjectType,
                        'pSubdCode': ddl0101Subdivision,
                        'pCategory': ddl0101Category
                    },
                    success: function (response) {
                        //Title
                        document.getElementById("h0101EstimateTitle").innerText = response[0].Title;
                        grid01Api.setGridOption("rowData", response);
                    },
                    complete: function (response) {
                        grid01Api.setGridOption("loading", false);
                    }
                });

                //AG Grid
                let gridDiv = document.querySelector('#table0101Estimate');
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
                            headerName: "Project",
                            field: "Project",
                            filter: 'agTextColumnFilter',
                            tooltipField: "Project",
                            flex: 1,
                            minWidth: 350
                        }
                    ],
                    rowData: [],
                    pagination: false,
                };
                grid01Api = agGrid.createGrid(gridDiv, gridOptions);

                $("#mdl0101Estimate").modal("show");
            }
        } else if (ddl0101Category != "" && (ddl0101Category != "House Construction" || ddl0101Category != "House Construction - CCI")) {
            //Ajax
            $.ajax({
                type: "POST",
                url: "Assets/Handler/FRM/FRM000010HND.ashx",
                data: {
                    'pFormCode': 'FRM000010',
                    'pType': 'Get - Estimate',
                    //'pSubdCode': ddl0101Subdivision,
                    'pSubdCode': '',
                    'pCategory': ddl0101Category
                },
                success: function (response) {
                    //Title
                    document.getElementById("h0101EstimateTitle").innerText = response[0].Title;
                    grid01Api.setGridOption("rowData", response);
                },
                complete: function (response) {
                    grid01Api.setGridOption("loading", false);
                }
            });

            //AG Grid
            let gridDiv = document.querySelector('#table0101Estimate');
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
                        headerName: "Project",
                        field: "Project",
                        filter: 'agTextColumnFilter',
                        tooltipField: "Project",
                        flex: 1,
                        minWidth: 350
                    }
                ],
                rowData: [],
                pagination: false,
            };
            grid01Api = agGrid.createGrid(gridDiv, gridOptions);

            $("#mdl0101Estimate").modal("show");
        };

    };

};
function fn0101AddEstimate(pCode, pTitle, pDivCode, pDivName) {
    //Estimate
    document.getElementById("tbx0101Estimate").value = pTitle;
    document.getElementById("hf0101Estimate").value = pCode;
    //Division
    document.getElementById("tbx0101Division").value = pDivName;
    document.getElementById("hf0101DivCode").value = pDivCode;
    //Department
    document.getElementById("tbx0101Department").value = "INDIRECT DEPARTMENT";
    document.getElementById("hf0101DeptCode").value = "2012000000";
    //Modal
    $("#mdl0101Estimate").modal("hide");
};

//charge to
function fn0101ChargeTo() {
    const hf0101AcctCode = document.getElementById("hf0101AcctCode").value;
    const hf0101Subsidiary = document.getElementById("hf0101Subsidiary").value;
    const ddl0101Purpose = document.getElementById("ddl0101Purpose").options[document.getElementById("ddl0101Purpose").selectedIndex].value;
    if (ddl0101Purpose != "") {
        if (hf0101AcctCode != "" && hf0101Subsidiary != "NO SUBSIDIARY") {
            //AG Grid
            $.ajax({
                type: "POST",
                url: "Assets/Handler/FRM/FRM000010HND.ashx",
                data: {
                    'pFormCode': 'FRM000010',
                    'pType': 'Get - Charging',
                    'pTblFrom': hf0101Subsidiary,
                    'pCode1': hf0101AcctCode,
                    'pCode2': '',
                    'pCode3': '',
                    'pCode4': '',
                    'pCode5': ''
                },
                success: function (response) {
                    document.getElementById("h01Title").innerText = hf0101Subsidiary + " - Search Record";
                    grid02Api.setGridOption("rowData", response);
                },
                complete: function (response) {
                    grid02Api.setGridOption("loading", false);
                }
            });

            //AG Grid
            let gridDiv = document.querySelector('#table0101Charging');
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
                columnDefs: [
                    {
                        headerName: "Action",
                        field: "Action",
                        lockPosition: true,
                        pinned: "left",
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
                        headerName: "Description",
                        field: "Description",
                        filter: 'agTextColumnFilter',
                        tooltipField: "Description",
                        flex: 1,
                        minWidth: 350
                    }
                ],
                rowData: [],
                pagination: false,
            };
            grid02Api = agGrid.createGrid(gridDiv, gridOptions);

            //modal
            $('#mdl0101Charge').modal('show');
        };
    } else {
        fnAlertOnly('Please select a purpose!', 'error', 'btn btn-danger');
    };
};
function fn0101AddChargeTo(pCode, pDescription, pLock) {
    if (pLock == 1) {
        //Charging
        document.getElementById("tbx0101ChargeTo").value = pDescription;
        document.getElementById("hf0101ChargeCode").value = pCode;
        //Modal
        $("#mdl0101Charge").modal("hide");
    } else {
        fnAlertOnly('Record is unlocked, it cannot be used!', 'error', 'btn btn-danger');
    };
};

//project
function fn0101Project() {
    //Ajax
    $.ajax({
        type: "POST",
        url: "Assets/Handler/FRM/FRM000010HND.ashx",
        data: {
            'pFormCode': 'FRM000010',
            'pType': 'Get - Project'
        },
        success: function (response) {
            //Title
            document.getElementById("h0101ProjectTitle").innerText = response[0].Title;
            grid03Api.setGridOption("rowData", response);
        },
        complete: function (response) {
            grid03Api.setGridOption("loading", false);
        }
    });

    //AG Grid
    let gridDiv = document.querySelector('#table0101Project');
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
                headerName: "Project",
                field: "Description",
                filter: 'agTextColumnFilter',
                tooltipField: "Description",
                flex: 1,
                minWidth: 350
            }
        ],
        rowData: [],
        pagination: false,
    };
    grid03Api = agGrid.createGrid(gridDiv, gridOptions);

    $("#mdl0101Project").modal("show");
};
function fn0101AddProject(pSubdCode, pPhase, pBlock, pLot, pDesc) {
    document.getElementById("hf0101Subdivision").value = pSubdCode;
    document.getElementById("hf0101Phase").value = pPhase;
    document.getElementById("hf0101Block").value = pBlock;
    document.getElementById("hf0101Lot").value = pLot;
    document.getElementById("tbx0101Project").value = pDesc;

    //modal
    $("#mdl0101Project").modal("hide");
};

//overview

//particular
function fn0102LoadParticular(pMode, pID) {
    //Variable
    const Category = document.getElementById("lbl0101Category").innerText;
    if (Category.includes("House Construction")) {

        //Ajax - Batch
        $.ajax({
            type: "POST",
            url: "Assets/Handler/FRM/FRM000010HND.ashx",
            data: {
                'pFormCode': 'FRM000010',
                'pType': 'Get - Particular - OSM (Batch)',
                'pID': pID
            },
            success: function (response) {
                try {
                    //display loader
                    document.getElementById("div0102LoaderParticular").style.display = "";
                    //display loader

                    if ($.fn.DataTable.isDataTable('#table12Record')) {
                        $('#table12Record').DataTable().clear().destroy();
                    };

                    //disable column type detection
                    DataTable.types().forEach(type => {
                        DataTable.type(type, 'detect', () => false);
                    });
                    //disable column type detection

                    //sort date by yyyy/mm/dd
                    $.fn.dataTable.moment('MM/DD/YYYY');
                    //sort date by yyyy/mm/dd

                    //datatable
                    var table12Record = $("#table12Record").DataTable({
                        processing: true,
                        bFilter: true,
                        bPaginate: false,
                        bInfo: false,
                        scrollCollapse: true,
                        paging: false,
                        lengthChange: false,
                        select: true,
                        data: response,
                        rowCallback: function (row, data, index) {
                            if (data.Scope != '') {
                                $(row).css({
                                    'background-color': '#BFF5C0',
                                    'font-weight': 'bold'
                                });
                            };
                        },
                        columns: [
                            {
                                data: 'Action',
                                render: function (data, type, row) {
                                    if (row.Scope != '') {
                                        return '';
                                    };
                                    return data;
                                }
                            },
                            { data: 'Type' },
                            { data: 'Item' },
                            { data: 'Qty' },
                            { data: 'Unit' },
                            { data: 'BdgtAmt' },
                            { data: 'Status' },
                            { data: 'POQty' },
                            { data: 'SRQty' },
                            { data: 'Remarks' }
                        ],
                        rowId: 'rowId',
                        columnDefs: [
                            {
                                targets: [0, 1],
                                orderable: false
                            },
                            {
                                targets: [3, 5, 7, 8],
                                className: 'dt-body-right',
                                render: $.fn.dataTable.render.number(',', '.', 2)
                            },
                            {
                                targets: [2],
                                className: 'tbody-nowrap-auto'
                            }
                        ],
                        initComplete: function () {
                            this.api().cells().every(function () {
                                var cell = this.node();
                                $(cell).attr('title', $(cell).text());
                            });
                        },
                        ordering: false
                    });
                    //datatable

                    //search
                    $('#tbx1101FindRecord').on('keyup', function () {
                        table12Record.search(this.value).draw();
                    });
                    //search

                    //hide loader
                    document.getElementById("div0102LoaderParticular").style.display = "none";
                    //hide loader

                    //action button
                    if (pMode == "ADD") {
                        const button = document.querySelectorAll('.action-button');
                        for (const btn of button) {
                            btn.classList.remove("btn-active-light");
                            btn.disabled = true;
                        }
                    } else if (pMode == "DTL") {
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

                } catch (err) {
                    console.error('Error initializing DataTable:', err);
                };
            },
        });

    } else {

        //Ajax - Estimate
        $.ajax({
            type: "POST",
            url: "Assets/Handler/FRM/FRM000010HND.ashx",
            data: {
                'pFormCode': 'FRM000010',
                'pType': 'Get - Particular - OSM (Estimate)',
                'pID': pID
            },
            success: function (response) {
                try {
                    //display loader
                    document.getElementById("div0102LoaderParticular").style.display = "";
                    //display loader

                    if ($.fn.DataTable.isDataTable('#table11Record')) {
                        $('#table11Record').DataTable().clear().destroy();
                    };

                    //disable column type detection
                    DataTable.types().forEach(type => {
                        DataTable.type(type, 'detect', () => false);
                    });
                    //disable column type detection

                    //sort date by yyyy/mm/dd
                    $.fn.dataTable.moment('MM/DD/YYYY');
                    //sort date by yyyy/mm/dd

                    //datatable
                    var table11Record = $("#table11Record").DataTable({
                        processing: true,
                        bFilter: true,
                        bPaginate: false,
                        bInfo: false,
                        scrollCollapse: true,
                        paging: false,
                        lengthChange: false,
                        select: true,
                        data: response,
                        rowCallback: function (row, data, index) {
                            if (data.Scope != '') {
                                $(row).css({
                                    'background-color': '#BFF5C0',
                                    'font-weight': 'bold'
                                });
                            };
                        },
                        columns: [
                            {
                                data: 'Action',
                                render: function (data, type, row) {
                                    if (row.Scope != '') {
                                        return '';
                                    };
                                    return data;
                                }
                            },
                            { data: 'Type' },
                            { data: 'Item' },
                            { data: 'Qty' },
                            { data: 'Unit' },
                            { data: 'BdgtAmt' },
                            { data: 'Status' },
                            { data: 'POQty' },
                            { data: 'SRQty' },
                            { data: 'CPQty' },
                            { data: 'CPCost' },
                            { data: 'CPTotal' },
                            { data: 'Remarks' }
                        ],
                        rowId: 'rowId',
                        columnDefs: [
                            {
                                targets: [0],
                                orderable: false
                            },
                            {
                                targets: [3, 5, 7, 8, 9, 10, 11],
                                className: 'dt-body-right',
                                render: $.fn.dataTable.render.number(',', '.', 2)
                            },
                            {
                                targets: [2, 12],
                                className: 'tbody-nowrap-auto'
                            }
                        ],
                        initComplete: function () {
                            this.api().cells().every(function () {
                                var cell = this.node();
                                $(cell).attr('title', $(cell).text());
                            });
                        },
                        createdRow: function (row, data, dataIndex) {
                            $(row).css('cursor', 'pointer');
                        },
                        ordering: false
                    });
                    //datatable

                    //search
                    $('#tbx1101FindRecord').on('keyup', function () {
                        table11Record.search(this.value).draw();
                    });
                    //search

                    //hide loader
                    document.getElementById("div0102LoaderParticular").style.display = "none";
                    //hide loader

                } catch (err) {
                    console.error('Error initializing DataTable:', err);
                };
            },
        });

    }
};
//delete - particular
function fn0102Delete(pID, pSeqNo) {
    //if exists
    fnIfExist('oop_form_hdr', 'f_code', document.getElementById('ContentPlaceHolder1_hdnID').value, function (response) {
        if (response[0].oReturn == "1") {
            Validate(document.getElementById('ContentPlaceHolder1_hdnID').value, pID, pSeqNo);
        } else {
            fnAlertOnly('No active form found!', 'warning', 'btn btn-warning');
        };
    });
    function Validate(ID, pID, pSeqNo) {
        fnFRMValidateRecord("06PRDtl", "Delete", ID, "", "", function (response) {
            if (response[0].Msg === "") {
                Delete_Dtl_Question(pID, pSeqNo);
            } else {
                fnAlertOnly(response[0].Msg, 'error', 'btn btn-danger');
            };
        });

    };
    function Delete_Dtl_Question(pID, pSeqNo) {
        Swal.fire({
            text: 'Remove particular?',
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
                Detele_Ok(pID, pSeqNo);
            }
        });
        function Detele_Ok(pID, pSeqNo) {
            //Ajax
            $.ajax({
                type: "POST",
                url: "Assets/Handler/FRM/FRM000010HND.ashx",
                data: {
                    'pFormCode': 'FRM000010',
                    'pType': 'Delete - Particular',
                    'pID': pID,
                    'pSeqNo': pSeqNo
                },
                success: function (response) {
                    fnAlertOnly('Record successfully removed!', 'success', 'btn btn-success');
                    //Particular
                    fn0102LoadParticular(document.getElementById("ContentPlaceHolder1_hdnMode").value, document.getElementById("ContentPlaceHolder1_hdnID").value);
                }
            });
        };
    };
};
//update - particular
function fn0102Edit(pID, pSeqNo) {
    //if exists
    fnIfExist('oop_form_hdr', 'f_code', document.getElementById('ContentPlaceHolder1_hdnID').value, function (response) {
        if (response[0].oReturn == "1") {
            Validate(pID, pSeqNo);
        } else {
            fnAlertOnly('No active form found!', 'warning', 'btn btn-warning');
        };
    });
    function Validate(pID, pSeqNo) {
        fnFRMValidateRecord("06PRDtl", "Save", pID, "", "", function (response) {
            if (response[0].Msg === "") {
                View_Particular(pID, pSeqNo);
            } else {
                fnAlertOnly(response[0].Msg, 'error', 'btn btn-danger');
            };
        });
    };
    function View_Particular(pID, pSeqNo) {
        //Ajax
        $.ajax({
            type: "POST",
            url: "Assets/Handler/FRM/FRM000010HND.ashx",
            data: {
                'pFormCode': 'FRM000010',
                'pType': 'Get - Particular (Update)',
                'pID': pID,
                'pSeqNo': pSeqNo
            },
            success: function (response) {
                //Condition
                const isHouseConstruction = response[0].Category.includes("House Construction");
                const fields = ["tbx0102Particular", "tbx0102Qty", "tbx0102Unit", "tbx0102Budget"];
                fields.forEach(id => {
                    document.getElementById(id).readOnly = isHouseConstruction;
                });

                //Record
                document.getElementById("tbx0102Particular").value = response[0].Item;
                document.getElementById("tbx0102Qty").value = formatNumber(response[0].Qty);
                document.getElementById("tbx0102Unit").value = response[0].Unit;
                document.getElementById("tbx0102Budget").value = formatNumber(response[0].BdgtAmt);
                $('#ddl0102Status').val(response[0].Status).trigger('change');
                document.getElementById("tbx0102ForPO").value = formatNumber(response[0].POQty);
                document.getElementById("tbx0102ForSR").value = formatNumber(response[0].SRQty);
                document.getElementById("tbx0102CPQty").value = formatNumber(response[0].CPQty);
                document.getElementById("tbx0102Cost").value = formatNumber(response[0].Cost);
                document.getElementById("tbx0102Total").value = formatNumber(response[0].Total);
                document.getElementById("tbx0102Remarks").value = response[0].Remarks;
                document.getElementById("ContentPlaceHolder1_hdnPRSeqNo").value = pSeqNo;

                //Modal
                $('#mdl0102Update').modal("show");
            }
        });
    };
};
function fn0102Update_Ok(Btn) {
    // Disable the clicked button to avoid multiple clicks
    Btn.disabled = true;
    // Show loading indicator
    Btn.setAttribute('data-kt-indicator', 'on');
    //if exists
    fnIfExist('oop_form_hdr', 'f_code', document.getElementById('ContentPlaceHolder1_hdnID').value, function (response) {
        if (response[0].oReturn == "1") {
            Validate(document.getElementById('ContentPlaceHolder1_hdnID').value, document.getElementById('ContentPlaceHolder1_hdnPRSeqNo').value);
        } else {
            fnAlertOnly('No active form found!', 'warning', 'btn btn-warning');
            // Disable the clicked button to avoid multiple clicks
            Btn.disabled = false;
            // Hide loading indication
            Btn.removeAttribute('data-kt-indicator');
        };
    });
    function Validate(pID, pSeqNo) {
        fnFRMValidateRecord("06PRDtl", "Save", pID, "", "", function (response) {
            if (response[0].Msg === "") {
                Validate_Particular(pID, pSeqNo);
            } else {
                fnAlertOnly(response[0].Msg, 'error', 'btn btn-danger');
                // Disable the clicked button to avoid multiple clicks
                Btn.disabled = false;
                // Hide loading indication
                Btn.removeAttribute('data-kt-indicator');
            };
        });
    };
    function Validate_Particular(pID, pSeqNo) {
        if (document.getElementById("tbx0102Particular").value == "") {
            fnAlertOnly('Some fields are missing!', 'warning', 'btn btn-warning');
            // Disable the clicked button to avoid multiple clicks
            Btn.disabled = false;
            // Hide loading indication
            Btn.removeAttribute('data-kt-indicator');
        } else if (document.getElementById("tbx0102Qty").value <= 0) {
            fnAlertOnly('Some fields are missing!', 'warning', 'btn btn-warning');
            // Disable the clicked button to avoid multiple clicks
            Btn.disabled = false;
            // Hide loading indication
            Btn.removeAttribute('data-kt-indicator');
        } else if (document.getElementById("tbx0102Unit").value == "") {
            fnAlertOnly('Some fields are missing!', 'warning', 'btn btn-warning');
            // Disable the clicked button to avoid multiple clicks
            Btn.disabled = false;
            // Hide loading indication
            Btn.removeAttribute('data-kt-indicator');
        } else {
            Update_Particular(pID, pSeqNo);
        }
    };
    function Update_Particular(pID, pSeqNo) {
        Swal.fire({
            text: 'Update particular?',
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
                Update_Ok(pID, pSeqNo);
            } else {
                // Disable the clicked button to avoid multiple clicks
                Btn.disabled = false;
                // Hide loading indication
                Btn.removeAttribute('data-kt-indicator');
            }
        });
        function Update_Ok(pID, pSeqNo) {
            //Ajax
            $.ajax({
                type: "POST",
                url: "Assets/Handler/FRM/FRM000010HND.ashx",
                data: {
                    'pFormCode': 'FRM000010',
                    'pType': 'Update - Particular',
                    'pID': pID,
                    'pSeqNo': pSeqNo,
                    'pItem': document.getElementById("tbx0102Particular").value,
                    'pQty': document.getElementById("tbx0102Qty").value,
                    'pUnit': document.getElementById("tbx0102Unit").value,
                    'pBdgtAmt': document.getElementById("tbx0102Budget").value,
                    'pStatus': document.getElementById("ddl0102Status").options[document.getElementById("ddl0102Status").selectedIndex].value,
                    'pForPO': document.getElementById("tbx0102ForPO").value,
                    'pForSR': document.getElementById("tbx0102ForSR").value,
                    'pForCP': document.getElementById("tbx0102CPQty").value,
                    'pCost': document.getElementById("tbx0102Cost").value,
                    'pTotal': document.getElementById("tbx0102Total").value,
                    'pRemarks': document.getElementById("tbx0102Remarks").value
                },
                success: function (response) {
                    fnAlertOnly('Record successfully updated!', 'success', 'btn btn-success');
                    //Bind
                    fn0102LoadParticular(document.getElementById("ContentPlaceHolder1_hdnMode").value, document.getElementById("ContentPlaceHolder1_hdnID").value);
                    //Modal
                    $('#mdl0102Update').modal("hide");
                }
            });
        };
    };
};
function btn11SCM() {
    //variable
    const pMode = document.getElementById("ContentPlaceHolder1_hdnMode").value;
    const pCategory = document.getElementById("lbl0101Category").innerText;
    const pProjType = document.getElementById("lbl0101ProjectType").innerText;
    if (pMode == "DTL") {

        if (pCategory.includes("House Construction") && pProjType.includes("(Advance PO)")) {

            //Ajax
            $.ajax({
                type: "POST",
                url: "Assets/Handler/FRM/FRM000010HND.ashx",
                data: {
                    'pFormCode': 'FRM000010',
                    'pType': 'Get - Particular - SCM (Batch)',
                    'pID': document.getElementById("ContentPlaceHolder1_hdnID").value
                },
                success: function (response) {
                    grid04Api.setGridOption("rowData", response);
                },
                complete: function (response) {
                    grid04Api.setGridOption("loading", false);
                }
            });

            //AG Grid
            let gridDiv = document.querySelector('#table0101SCMBatch');
            let gridOptions;

            //Destroy
            if (grid04Api) {
                grid04Api.destroy();
                grid04Api = null;
            };

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
                rowSelection: 'multiple',
                suppressRowClickSelection: true,
                loading: true,
                getRowStyle: params => {
                    if (params.data.WBSNo == '') {
                        return { backgroundColor: '#BFF5C0' };
                    }
                    return null;
                },
                onRowSelected: params => {
                    const node = params.node;
                    if (params.node.isSelected()) {
                        node.setDataValue('QtyReq', node.data.Qty3);
                    } else {
                        node.setDataValue('QtyReq', 0);
                    }
                },
                columnDefs: [
                    {
                        headerName: "Action",
                        field: "isChecked",
                        resizable: false,
                        sortable: false,
                        width: 75,
                        checkboxSelection: params => params.data.WBSNo != '',
                        cellStyle: {
                            display: 'flex',
                            justifyContent: 'center',
                            alignItems: 'center'
                        }
                    },
                    {
                        headerName: "Particular",
                        field: "Particular",
                        filter: 'agTextColumnFilter',
                        tooltipField: "Particular",
                        flex: 1,
                        minWidth: 350,
                        cellStyle: params => {
                            if (params.data.WBSNo == '') {
                                return { fontWeight: 'bold' }
                            }
                            return null;
                        }
                    },
                    {
                        headerName: "Qty - Balance",
                        field: "Qty1",
                        tooltipField: "Qty1",
                        width: 150,
                        cellClass: "text-end",
                        cellStyle: { fontWeight: 'bold' },
                        valueFormatter: params => {
                            let value = parseFloat(params.value);
                            if (params.data.WBSNo == '') {
                                return ''
                            }
                            if (isNaN(value)) {
                                value = parseFloat(params.data.Qty1) || 0;
                            }
                            return value.toLocaleString("en-US", {
                                minimumFractionDigits: 2,
                                maximumFractionDigits: 2
                            });
                        },
                    },
                    {
                        headerName: "Qty - Approval",
                        field: "Qty2",
                        tooltipField: "Qty2",
                        width: 150,
                        cellClass: "text-end",
                        cellStyle: { fontWeight: 'bold' },
                        valueFormatter: params => {
                            let value = parseFloat(params.value);
                            if (params.data.WBSNo == '') {
                                return ''
                            }
                            if (isNaN(value)) {
                                value = parseFloat(params.data.Qty2) || 0;
                            }
                            return value.toLocaleString("en-US", {
                                minimumFractionDigits: 2,
                                maximumFractionDigits: 2
                            });
                        },
                    },
                    {
                        headerName: "Qty - Available",
                        field: "Qty3",
                        tooltipField: "Qty3",
                        width: 150,
                        cellClass: "text-end",
                        cellStyle: { fontWeight: 'bold' },
                        valueFormatter: params => {
                            let value = parseFloat(params.value);
                            if (params.data.WBSNo == '') {
                                return ''
                            }
                            if (isNaN(value)) {
                                value = parseFloat(params.data.Qty3) || 0;
                            }
                            return value.toLocaleString("en-US", {
                                minimumFractionDigits: 2,
                                maximumFractionDigits: 2
                            });
                        },
                    },
                    {
                        headerName: "Qty - Request",
                        field: "QtyReq",
                        width: 150,
                        editable: params => params.data.WBSNo != '',
                        cellEditor: 'agNumberCellEditor',
                        cellClass: "text-end text-danger",
                        cellEditorParams: {
                            min: 0,
                        },
                        cellStyle: { fontWeight: 'bold' },
                        valueFormatter: params => {
                            let value = parseFloat(params.value);
                            if (params.data.WBSNo == '') {
                                return ''
                            }
                            if (isNaN(value)) value = 0;
                            return value.toLocaleString("en-US", {
                                minimumFractionDigits: 2,
                                maximumFractionDigits: 2
                            });
                        }
                    },
                    {
                        headerName: "Unit",
                        field: "Unit",
                        filter: 'agTextColumnFilter',
                        tooltipField: "Unit",
                        width: 100,
                        cellRenderer: params => {
                            if (params.data.ItmNo == '') {
                                return '';
                            };
                            return params.value;
                        }
                    },
                    {
                        headerName: "Remarks",
                        field: "Remarks",
                        editable: params => params.data.WBSNo != '',
                    }
                ],
                rowData: [],
                pagination: false,
            };

            grid04Api = agGrid.createGrid(gridDiv, gridOptions);

            //Modal
            $("#mdl0101SCMBatch").modal("show");
        } else if (!pCategory.includes("House Construction") && pProjType.includes("(Advance PO)")) {

        };

    };
};
function fn0102SaveSCMBatch_Ok(Btn) {
    // Disable the clicked button to avoid multiple clicks
    Btn.disabled = true;
    // Show loading indicator
    Btn.setAttribute('data-kt-indicator', 'on');
    //if exists
    fnIfExist('oop_form_hdr', 'f_code', document.getElementById('ContentPlaceHolder1_hdnID').value, function (response) {
        if (response[0].oReturn == "1") {
            Validate(document.getElementById('ContentPlaceHolder1_hdnID').value);
        } else {
            fnAlertOnly('No active form found!', 'warning', 'btn btn-warning');
            // Disable the clicked button to avoid multiple clicks
            Btn.disabled = false;
            // Hide loading indication
            Btn.removeAttribute('data-kt-indicator');
        };
    });
    function Validate(pID) {
        fnFRMValidateRecord("06PRDtl", "Add", pID, "", "", function (response) {
            if (response[0].Msg === "") {
                Add_Particular(pID);
            } else {
                fnAlertOnly(response[0].Msg, 'error', 'btn btn-danger');
                // Disable the clicked button to avoid multiple clicks
                Btn.disabled = false;
                // Hide loading indication
                Btn.removeAttribute('data-kt-indicator');
            };
        });
    };
    function Add_Particular(pID) {
        const selectedRows = grid04Api.getSelectedRows();
        let pItemSrs = selectedRows.map(i =>
            `${i.Particular}©${(parseFloat(i.QtyReq) || 0).toFixed(2)}©${i.Unit}©${i.Remarks || ''}©${i.WBSNo}`
        ).join('®');
        //Condition
        if (pItemSrs) {
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
            }).then((res) => {
                if (res.isConfirmed) {
                    $.ajax({
                        type: "POST",
                        url: "Assets/Handler/FRM/FRM000010HND.ashx",
                        data: {
                            'pFormCode': 'FRM000010',
                            'pType': 'Add - Record (SCM Batch)',
                            'pID': pID,
                            'pItemSrs': pItemSrs
                        },
                        success: async function (response) {
                            //modal
                            $("#mdl0101SCMBatch").modal("hide");
                            //alert
                            fnAlertOnly('Record successfully tagged.', 'success', 'btn btn-success');
                            //Bind
                            fn0102LoadParticular(document.getElementById("ContentPlaceHolder1_hdnMode").value, document.getElementById("ContentPlaceHolder1_hdnID").value);
                            // Disable the clicked button to avoid multiple clicks
                            Btn.disabled = false;
                            // Hide loading indication
                            Btn.removeAttribute('data-kt-indicator');
                        }
                    });
                } else {
                    // Disable the clicked button to avoid multiple clicks
                    Btn.disabled = false;
                    // Hide loading indication
                    Btn.removeAttribute('data-kt-indicator');
                };
            });
        } else {
            fnAlertOnly('No record selected.', 'error', 'btn btn-danger');
            // Disable the clicked button to avoid multiple clicks
            Btn.disabled = false;
            // Hide loading indication
            Btn.removeAttribute('data-kt-indicator');
        }
    };
};
function fn0101ReBindOSMBatch() {
    $.ajax({
        type: "POST",
        url: "Assets/Handler/FRM/FRM000010HND.ashx",
        data: {
            'pFormCode': 'FRM000010',
            'pType': 'Get - OSM Record (Batch)',
            'pID': document.getElementById("ContentPlaceHolder1_hdnID").value
        },
        success: function (response) {
            grid06Api.setGridOption("rowData", response);
        }
    });
};
function btn11OSM() {
    //variable
    const pMode = document.getElementById("ContentPlaceHolder1_hdnMode").value;
    const pCategory = document.getElementById("lbl0101Category").innerText;
    const pProjType = document.getElementById("lbl0101ProjectType").innerText;
    if (pMode == "DTL") {

        if (pCategory.includes("House Construction") && pProjType.includes("(Stock Request)")) {

            //Ajax
            $.ajax({
                type: "POST",
                url: "Assets/Handler/FRM/FRM000010HND.ashx",
                data: {
                    'pFormCode': 'FRM000010',
                    'pType': 'Get - OSM Record (Batch)',
                    'pID': document.getElementById("ContentPlaceHolder1_hdnID").value
                },
                success: function (response) {
                    grid06Api.setGridOption("rowData", response);
                },
                complete: function (response) {
                    grid06Api.setGridOption("loading", false);
                }
            });

            //AG Grid
            let gridDiv = document.querySelector('#table0101OSMBatch');
            let gridOptions;

            //Destroy
            if (grid06Api) {
                grid06Api.destroy();
                grid06Api = null;
            };

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
                getRowStyle: params => {
                    if (params.data.WBSNo == '') {
                        return { backgroundColor: '#BFF5C0' };
                    }
                    return null;
                },
                columnDefs: [
                    {
                        headerName: "Action",
                        field: "Action",
                        sortable: false,
                        resizable: false,
                        lockPosition: true,
                        width: 75,
                        cellRenderer: params => {
                            if (params.data.WBSNo == '') {
                                return '';
                            };
                            return params.value
                        }
                    },
                    {
                        headerName: "Particular",
                        field: "Particular",
                        filter: 'agTextColumnFilter',
                        tooltipField: "Particular",
                        flex: 1,
                        minWidth: 350,
                        cellStyle: params => {
                            if (params.data.WBSNo == '') {
                                return { fontWeight: 'bold' }
                            }
                            return null;
                        }
                    },
                    {
                        headerName: "Unit",
                        field: "Unit",
                        filter: 'agTextColumnFilter',
                        tooltipField: "Unit",
                        width: 100,
                        cellRenderer: params => {
                            if (params.data.WBSNo == '') {
                                return '';
                            };
                            return params.value;
                        }
                    },
                    {
                        headerName: "Qty - Balance",
                        field: "Qty1",
                        tooltipField: "Qty1",
                        width: 150,
                        cellClass: "text-end",
                        cellStyle: { fontWeight: 'bold' },
                        valueFormatter: params => {
                            let value = parseFloat(params.value);
                            if (params.data.WBSNo == '') {
                                return ''
                            }
                            if (isNaN(value)) {
                                value = parseFloat(params.data.Qty1) || 0;
                            }
                            return value.toLocaleString("en-US", {
                                minimumFractionDigits: 2,
                                maximumFractionDigits: 2
                            });
                        },
                    },
                    {
                        headerName: "Qty - Approval",
                        field: "Qty2",
                        tooltipField: "Qty2",
                        width: 150,
                        cellClass: "text-end",
                        cellStyle: { fontWeight: 'bold' },
                        valueFormatter: params => {
                            let value = parseFloat(params.value);
                            if (params.data.WBSNo == '') {
                                return ''
                            }
                            if (isNaN(value)) {
                                value = parseFloat(params.data.Qty2) || 0;
                            }
                            return value.toLocaleString("en-US", {
                                minimumFractionDigits: 2,
                                maximumFractionDigits: 2
                            });
                        },
                    },
                    {
                        headerName: "Qty - Available",
                        field: "Qty3",
                        tooltipField: "Qty3",
                        width: 150,
                        cellClass: "text-end",
                        cellStyle: { fontWeight: 'bold' },
                        valueFormatter: params => {
                            let value = parseFloat(params.value);
                            if (params.data.WBSNo == '') {
                                return ''
                            }
                            if (isNaN(value)) {
                                value = parseFloat(params.data.Qty3) || 0;
                            }
                            return value.toLocaleString("en-US", {
                                minimumFractionDigits: 2,
                                maximumFractionDigits: 2
                            });
                        },
                    },
                    {
                        headerName: "Remarks",
                        field: "Remarks",
                        editable: true
                    }
                ],
                rowData: [],
                pagination: false,
            };

            grid06Api = agGrid.createGrid(gridDiv, gridOptions);

            //Modal
            $("#mdl0101OSMBatch").modal("show");

        } else if (!pCategory.includes("House Construction") && pProjType.includes("(Stock Request)")) {

            //Ajax
            $.ajax({
                type: "POST",
                url: "Assets/Handler/FRM/FRM000010HND.ashx",
                data: {
                    'pFormCode': 'FRM000010',
                    'pType': 'Get - OSM Record (Estimate)',
                    'pID': document.getElementById("ContentPlaceHolder1_hdnID").value
                },
                success: function (response) {
                    grid07Api.setGridOption("rowData", response);
                },
                complete: function (response) {
                    grid07Api.setGridOption("loading", false);
                }
            });

            //AG Grid
            let gridDiv = document.querySelector('#table0101OSMEstimate');
            let gridOptions;

            //Destroy
            if (grid07Api) {
                grid07Api.destroy();
                grid07Api = null;
            };

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
                rowSelection: 'multiple',
                suppressRowClickSelection: true, 
                loading: true,
                getRowStyle: params => {
                    if (params.data.ItmNo == '') {
                        return { backgroundColor: '#BFF5C0' };
                    }
                    return null;
                },
                onRowSelected: params => {
                    const node = params.node;
                    if (params.node.isSelected()) {
                        node.setDataValue('QtyReq', node.data.Qty3);
                    } else {
                        node.setDataValue('QtyReq', 0);
                    }
                },
                columnDefs: [
                    {
                        headerName: "Action",
                        field: "isChecked",
                        resizable: false,
                        sortable: false,
                        width: 75,
                        checkboxSelection: params => params.data.ItmNo != '',
                        cellStyle: {
                            display: 'flex',
                            justifyContent: 'center',
                            alignItems: 'center'
                        }
                    },
                    {
                        headerName: "Particular",
                        field: "Particular",
                        filter: 'agTextColumnFilter',
                        tooltipField: "Particular",
                        flex: 1,
                        minWidth: 350,
                        cellStyle: params => {
                            if (params.data.ItmNo == '') {
                                return { fontWeight: 'bold' }
                            }
                            return null;
                        }
                    },
                    {
                        headerName: "Qty - Balance",
                        field: "Qty1",
                        tooltipField: "Qty1",
                        width: 150,
                        cellClass: "text-end",
                        cellStyle: { fontWeight: 'bold' },
                        valueFormatter: params => {
                            let value = parseFloat(params.value);
                            if (params.data.ItmNo == '') {
                                return ''
                            }
                            if (isNaN(value)) {
                                value = parseFloat(params.data.Qty1) || 0;
                            }
                            return value.toLocaleString("en-US", {
                                minimumFractionDigits: 2,
                                maximumFractionDigits: 2
                            });
                        },
                    },
                    {
                        headerName: "Qty - Approval",
                        field: "Qty2",
                        tooltipField: "Qty2",
                        width: 150,
                        cellClass: "text-end",
                        cellStyle: { fontWeight: 'bold' },
                        valueFormatter: params => {
                            let value = parseFloat(params.value);
                            if (params.data.ItmNo == '') {
                                return ''
                            }
                            if (isNaN(value)) {
                                value = parseFloat(params.data.Qty2) || 0;
                            }
                            return value.toLocaleString("en-US", {
                                minimumFractionDigits: 2,
                                maximumFractionDigits: 2
                            });
                        },
                    },
                    {
                        headerName: "Qty - Available",
                        field: "Qty3",
                        tooltipField: "Qty3",
                        width: 150,
                        cellClass: "text-end",
                        cellStyle: { fontWeight: 'bold' },
                        valueFormatter: params => {
                            let value = parseFloat(params.value);
                            if (params.data.ItmNo == '') {
                                return ''
                            }
                            if (isNaN(value)) {
                                value = parseFloat(params.data.Qty3) || 0;
                            }
                            return value.toLocaleString("en-US", {
                                minimumFractionDigits: 2,
                                maximumFractionDigits: 2
                            });
                        },
                    },
                    {
                        headerName: "Qty - Request",
                        field: "QtyReq",
                        width: 150,
                        editable: params => params.data.ItmNo != '',
                        cellEditor: 'agNumberCellEditor',
                        cellClass: "text-end text-danger",
                        cellEditorParams: {
                            min: 0,
                        },
                        cellStyle: { fontWeight: 'bold', },
                        valueParser: params => {
                            let newValue = parseFloat(params.newValue);
                            const maxValue = parseFloat(params.data.Qty3) || 0;
                            if (isNaN(newValue) || newValue < 0) {
                                return 0;
                            }
                            if (newValue > maxValue) {
                                return maxValue;
                            }
                            return newValue;
                        },
                        valueFormatter: params => {
                            let value = parseFloat(params.value);
                            if (params.data.ItmNo == '') {
                                return ''
                            }
                            if (isNaN(value)) value = 0;
                            return value.toLocaleString("en-US", {
                                minimumFractionDigits: 2,
                                maximumFractionDigits: 2
                            });
                        }
                    },
                    {
                        headerName: "Unit",
                        field: "Unit",
                        filter: 'agTextColumnFilter',
                        tooltipField: "Unit",
                        width: 100,
                        cellRenderer: params => {
                            if (params.data.ItmNo == '') {
                                return '';
                            };
                            return params.value;
                        }
                    },
                    {
                        headerName: "Remarks",
                        field: "Remarks",
                        editable: true
                    }
                ],
                rowData: [],
                pagination: false,
            };

            grid07Api = agGrid.createGrid(gridDiv, gridOptions);

            //Modal
            $("#mdl0101OSMEstimate").modal("show");
        };
    };
};

//Estimate - Function
function fn0102SaveEstimate_Ok(Btn) {
    // Disable the clicked button to avoid multiple clicks
    Btn.disabled = true;
    // Show loading indicator
    Btn.setAttribute('data-kt-indicator', 'on');
    //if exists
    fnIfExist('oop_form_hdr', 'f_code', document.getElementById('ContentPlaceHolder1_hdnID').value, function (response) {
        if (response[0].oReturn == "1") {
            Validate(document.getElementById('ContentPlaceHolder1_hdnID').value);
        } else {
            fnAlertOnly('No active form found!', 'warning', 'btn btn-warning');
            // Disable the clicked button to avoid multiple clicks
            Btn.disabled = false;
            // Hide loading indication
            Btn.removeAttribute('data-kt-indicator');
        };
    });
    function Validate(pID) {
        fnFRMValidateRecord("06PRDtl", "Add", pID, "", "", function (response) {
            if (response[0].Msg === "") {
                Add_Particular(pID);
            } else {
                fnAlertOnly(response[0].Msg, 'error', 'btn btn-danger');
                // Disable the clicked button to avoid multiple clicks
                Btn.disabled = false;
                // Hide loading indication
                Btn.removeAttribute('data-kt-indicator');
            };
        });
    };
    function Add_Particular(pID) {
        const selectedRows = grid07Api.getSelectedRows();
        let pItemSrs = selectedRows.map(i =>
            `${i.ItmNo}©${i.Particular}©${(parseFloat(i.QtyReq) || 0).toFixed(2)}©${i.Unit}©${i.Remarks || ''}`
        ).join('®');
        //Condition
        if (pItemSrs) {
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
            }).then((res) => {
                if (res.isConfirmed) {
                    $.ajax({
                        type: "POST",
                        url: "Assets/Handler/FRM/FRM000010HND.ashx",
                        data: {
                            'pFormCode': 'FRM000010',
                            'pType': 'Add - Record (OSM Estimate)',
                            'pID': pID,
                            'pItemSrs': pItemSrs
                        },
                        success: async function (response) {
                            //modal
                            $("#mdl0101OSMEstimate").modal("hide");
                            //alert
                            fnAlertOnly('Record successfully tagged.', 'success', 'btn btn-success');
                            //Bind
                            fn0102LoadParticular(document.getElementById("ContentPlaceHolder1_hdnMode").value, document.getElementById("ContentPlaceHolder1_hdnID").value);
                            // Disable the clicked button to avoid multiple clicks
                            Btn.disabled = false;
                            // Hide loading indication
                            Btn.removeAttribute('data-kt-indicator');
                        }
                    });
                } else {
                    // Disable the clicked button to avoid multiple clicks
                    Btn.disabled = false;
                    // Hide loading indication
                    Btn.removeAttribute('data-kt-indicator');
                };
            });
        } else {
            fnAlertOnly('No record selected.', 'error', 'btn btn-danger');
            // Disable the clicked button to avoid multiple clicks
            Btn.disabled = false;
            // Hide loading indication
            Btn.removeAttribute('data-kt-indicator');
        }
    };
};

//Batch - Function
function fn0101AddOSM(pWBSNo) {
    let rowData = null;
    grid06Api.forEachNode(node => {
        if (node.data.WBSNo == pWBSNo) {
            rowData = node.data;
        };
    });
    if (rowData) {
        let ItemSrs = '';
        if (rowData.WBSNo != '') {
            ItemSrs = `${rowData.WBSNo}©${rowData.Particular}©${(0).toFixed(2)}©${rowData.Unit}©${rowData.Remarks || ''}`;
        };
        //Add
        if (ItemSrs != '') {
            //Ajax
            $.ajax({
                type: "POST",
                url: "Assets/Handler/FRM/FRM000010HND.ashx",
                data: {
                    'pFormCode': 'FRM000010',
                    'pType': 'Add - Record (OSM Batch)',
                    'pID': document.getElementById("ContentPlaceHolder1_hdnID").value,
                    'pItemSrs': ItemSrs
                },
                success: function (response) {
                    fnAlertOnly('Record successfully saved.', 'success', 'btn btn-success');
                    //Particular
                    fn0102LoadParticular(document.getElementById("ContentPlaceHolder1_hdnMode").value, document.getElementById("ContentPlaceHolder1_hdnID").value);
                    //ReBind
                    fn0101ReBindOSMBatch();
                }
            });
        };
    };
};
function fn0102Tag(pID, pItemNo, pSeqNo) {
    //Ajax
    $.ajax({
        type: "POST",
        url: "Assets/Handler/FRM/FRM000010HND.ashx",
        data: {
            'pFormCode': 'FRM000010',
            'pType': 'Get - Tagging Units',
            'pID': pID,
            'pItemNo': pItemNo
        },
        success: function (response) {
            grid08Api.setGridOption("rowData", response);
        },
        complete: function (response) {
            grid08Api.setGridOption("loading", false);
        }
    });

    //AG Grid
    let gridDiv = document.querySelector('#table0102Tag');
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
                        { colId: 'Qty4', pinned: 'right' },
                        { colId: 'QtyReq', pinned: 'right' }
                    ]
                });
            }
        },
        theme: gridTheme,
        suppressCellFocus: true,
        suppressDragLeaveHidesColumns: true,
        enableCellTextSelection: true,
        rowSelection: 'multiple',
        suppressRowClickSelection: true,
        loading: true,
        onRowSelected: params => {
            const node = params.node;
            if (params.node.isSelected()) {
                node.setDataValue('QtyReq', node.data.Qty3);
            } else {
                node.setDataValue('QtyReq', 0);
            }
        },
        columnDefs: [
            {
                headerName: "Action",
                field: "isChecked",
                resizable: false,
                sortable: false,
                width: 75,
                checkboxSelection: true,
                cellStyle: {
                    display: 'flex',
                    justifyContent: 'center',
                    alignItems: 'center'
                }
            },
            {
                headerName: "Est. Title",
                field: "Title",
                filter: 'agTextColumnFilter',
                tooltipField: "Title",
                flex: 1,
                minWidth: 280
            },
            {
                headerName: "Project",
                field: "Project",
                filter: 'agTextColumnFilter',
                tooltipField: "Project",
                width: 250
            },
            {
                headerName: "Unit",
                field: "Unit",
                filter: 'agTextColumnFilter',
                tooltipField: "Unit",
                width: 100,
                cellRenderer: params => {
                    if (params.data.WBSNo == '') {
                        return '';
                    };
                    return params.value;
                }
            },
            {
                headerName: "Qty - Balance",
                field: "Qty1",
                tooltipField: "Qty1",
                width: 150,
                cellClass: "text-end",
                cellStyle: { fontWeight: 'bold' },
                valueFormatter: params => {
                    let value = parseFloat(params.value);
                    if (isNaN(value)) {
                        value = parseFloat(params.data.Qty1) || 0;
                    }
                    return value.toLocaleString("en-US", {
                        minimumFractionDigits: 2,
                        maximumFractionDigits: 2
                    });
                },
            },
            {
                headerName: "Qty - Approval",
                field: "Qty2",
                tooltipField: "Qty2",
                width: 150,
                cellClass: "text-end",
                cellStyle: { fontWeight: 'bold' },
                valueFormatter: params => {
                    let value = parseFloat(params.value);
                    if (isNaN(value)) {
                        value = parseFloat(params.data.Qty2) || 0;
                    }
                    return value.toLocaleString("en-US", {
                        minimumFractionDigits: 2,
                        maximumFractionDigits: 2
                    });
                },
            },
            {
                headerName: "Qty - Available",
                field: "Qty3",
                tooltipField: "Qty3",
                width: 150,
                cellClass: "text-end",
                cellStyle: { fontWeight: 'bold' },
                valueFormatter: params => {
                    let value = parseFloat(params.value);
                    if (isNaN(value)) {
                        value = parseFloat(params.data.Qty3) || 0;
                    }
                    return value.toLocaleString("en-US", {
                        minimumFractionDigits: 2,
                        maximumFractionDigits: 2
                    });
                },
            },
            {
                headerName: "Qty - Tagged",
                field: "Qty4",
                tooltipField: "Qty4",
                width: 150,
                pinned: "right",
                cellClass: "text-end",
                editable: true,
                cellEditor: 'agNumberCellEditor',
                cellEditorParams: {
                    min: 0,
                },
                cellStyle: { fontWeight: 'bold' },
                valueParser: params => {
                    let newValue = parseFloat(params.newValue);
                    const maxValue = parseFloat(params.data.Qty4) || 0;
                    if (isNaN(newValue) || newValue < 0) {
                        return 0;
                    }
                    if (newValue > maxValue) {
                        return maxValue;
                    }
                    return newValue;
                },
                valueFormatter: params => {
                    let value = parseFloat(params.value);
                    if (isNaN(value)) {
                        value = parseFloat(params.data.Qty2) || 0;
                    }
                    return value.toLocaleString("en-US", {
                        minimumFractionDigits: 2,
                        maximumFractionDigits: 2
                    });
                },
            },
            {
                headerName: "Qty - Request",
                field: "QtyReq",
                width: 150,
                pinned: "right",
                editable: true,
                cellEditor: 'agNumberCellEditor',
                cellClass: "text-end",
                cellEditorParams: {
                    min: 0,
                },
                cellStyle: { fontWeight: 'bold' },
                valueParser: params => {
                    let newValue = parseFloat(params.newValue);
                    const maxValue = parseFloat(params.data.Qty3) || 0;
                    if (isNaN(newValue) || newValue < 0) {
                        return 0;
                    }
                    if (newValue > maxValue) {
                        return maxValue;
                    }
                    return newValue;
                },
                valueFormatter: params => {
                    let value = parseFloat(params.value);
                    if (isNaN(value)) value = 0;
                    return value.toLocaleString("en-US", {
                        minimumFractionDigits: 2,
                        maximumFractionDigits: 2
                    });
                }
            }
        ],
        rowData: [],
        pagination: false,
    };
    grid08Api = agGrid.createGrid(gridDiv, gridOptions);

    $("#mdl0102Tag").modal("show");
};
function fn0102Tag_Ok(Btn) {
    // Disable the clicked button to avoid multiple clicks
    Btn.disabled = true;
    // Show loading indicator
    Btn.setAttribute('data-kt-indicator', 'on');
    //if exists
    fnIfExist('oop_form_hdr', 'f_code', document.getElementById('ContentPlaceHolder1_hdnID').value, function (response) {
        if (response[0].oReturn == "1") {
            Validate(document.getElementById('ContentPlaceHolder1_hdnID').value);
        } else {
            fnAlertOnly('No active form found!', 'warning', 'btn btn-warning');
            // Disable the clicked button to avoid multiple clicks
            Btn.disabled = false;
            // Hide loading indication
            Btn.removeAttribute('data-kt-indicator');
        };
    });
    function Validate(pID) {
        fnFRMValidateRecord("06PRDtl", "Save", pID, "", "", function (response) {
            if (response[0].Msg === "") {
                Tag_Particular(pID);
            } else {
                fnAlertOnly(response[0].Msg, 'error', 'btn btn-danger');
                // Disable the clicked button to avoid multiple clicks
                Btn.disabled = false;
                // Hide loading indication
                Btn.removeAttribute('data-kt-indicator');
            };
        });
    };
    function Tag_Particular(pID) {
        const selectedRows = grid08Api.getSelectedRows();
        let pItemSrs = selectedRows.map(i =>
            `${i.ItemNo}©${i.Particular}©${(i.QtyReq).toFixed(2)}©${i.LotCode}©${i.AcctCode}©${i.DivCode}©${i.DeptCode}©${i.Subsidiary}©${i.Code}`
        ).join('®');
        //Condition
        if (pItemSrs) {
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
            }).then((res) => {
                if (res.isConfirmed) {
                    $.ajax({
                        type: "POST",
                        url: "Assets/Handler/FRM/FRM000010HND.ashx",
                        data: {
                            'pFormCode': 'FRM000010',
                            'pType': 'Update - Particular (Tag)',
                            'pID': pID,
                            'pItemSrs': pItemSrs
                        },
                        success: async function (response) {
                            //modal
                            $("#mdl0102Tag").modal("hide");
                            //alert
                            fnAlertOnly('Record successfully tagged.', 'success', 'btn btn-success');
                            //Bind
                            fn0102LoadParticular(document.getElementById("ContentPlaceHolder1_hdnMode").value, document.getElementById("ContentPlaceHolder1_hdnID").value);
                            // Disable the clicked button to avoid multiple clicks
                            Btn.disabled = false;
                            // Hide loading indication
                            Btn.removeAttribute('data-kt-indicator');
                        }
                    });
                } else {
                    // Disable the clicked button to avoid multiple clicks
                    Btn.disabled = false;
                    // Hide loading indication
                    Btn.removeAttribute('data-kt-indicator');
                };
            });
        } else {
            fnAlertOnly('No record selected.', 'error', 'btn btn-danger');
            // Disable the clicked button to avoid multiple clicks
            Btn.disabled = false;
            // Hide loading indication
            Btn.removeAttribute('data-kt-indicator');
        }
    };
};
function fn0102Return_Ok(Btn) {
    // Disable the clicked button to avoid multiple clicks
    Btn.disabled = true;
    // Show loading indicator
    Btn.setAttribute('data-kt-indicator', 'on');
    //if exists
    fnIfExist('oop_form_hdr', 'f_code', document.getElementById('ContentPlaceHolder1_hdnID').value, function (response) {
        if (response[0].oReturn == "1") {
            Validate(document.getElementById('ContentPlaceHolder1_hdnID').value);
        } else {
            fnAlertOnly('No active form found!', 'warning', 'btn btn-warning');
            // Disable the clicked button to avoid multiple clicks
            Btn.disabled = false;
            // Hide loading indication
            Btn.removeAttribute('data-kt-indicator');
        };
    });
    function Validate(pID) {
        fnFRMValidateRecord("06PRDtl", "Save", pID, "", "", function (response) {
            if (response[0].Msg === "") {
                Return_Particular(pID);
            } else {
                fnAlertOnly(response[0].Msg, 'error', 'btn btn-danger');
                // Disable the clicked button to avoid multiple clicks
                Btn.disabled = false;
                // Hide loading indication
                Btn.removeAttribute('data-kt-indicator');
            };
        });
    };
    function Return_Particular(pID) {
        const selectedRows = grid08Api.getSelectedRows();
        let pItemSrs = selectedRows.map(i =>
            `${i.ItemNo}©${i.Particular}©${(i.Qty4).toFixed(2)}©${i.LotCode}©${i.AcctCode}©${i.DivCode}©${i.DeptCode}©${i.Subsidiary}©${i.Code}`
        ).join('®');
        //Condition
        if (pItemSrs) {
            Swal.fire({
                text: 'Return selected record?',
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
            }).then((res) => {
                if (res.isConfirmed) {
                    $.ajax({
                        type: "POST",
                        url: "Assets/Handler/FRM/FRM000010HND.ashx",
                        data: {
                            'pFormCode': 'FRM000010',
                            'pType': 'Return - Particular (Tag)',
                            'pID': pID,
                            'pItemSrs': pItemSrs
                        },
                        success: async function (response) {
                            //modal
                            $("#mdl0102Tag").modal("hide");
                            //alert
                            fnAlertOnly('Record successfully returned.', 'success', 'btn btn-success');
                            //Bind
                            fn0102LoadParticular(document.getElementById("ContentPlaceHolder1_hdnMode").value, document.getElementById("ContentPlaceHolder1_hdnID").value);
                            // Disable the clicked button to avoid multiple clicks
                            Btn.disabled = false;
                            // Hide loading indication
                            Btn.removeAttribute('data-kt-indicator');
                        }
                    });
                } else {
                    // Disable the clicked button to avoid multiple clicks
                    Btn.disabled = false;
                    // Hide loading indication
                    Btn.removeAttribute('data-kt-indicator');
                };
            });
        } else {
            fnAlertOnly('No record selected.', 'error', 'btn btn-danger');
            // Disable the clicked button to avoid multiple clicks
            Btn.disabled = false;
            // Hide loading indication
            Btn.removeAttribute('data-kt-indicator');
        }
    };
};

//OSM - Upload
function btn11UplOSM() {
    fnAlertOnly('Feature temporarily unavailable.', 'warning', 'btn btn-warning');
};
//particular

//attachment
function fn0201LoadAttachment(pMode, pID) {
    $.ajax({
        type: "POST",
        url: "HNDGEN.ashx",
        data: {
            'pFormCode': 'FRM000010',
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

            //search
            $('#tbx0201FindAttachment').on('keyup', function () {
                table0201Attachment.search(this.value).draw();
            });
            //search

            //hide loader
            document.getElementById("div0201LoaderAttachment").style.display = "none";
            //hide loader

            //action button
            if (pMode == "ADD") {
                const button = document.querySelectorAll('.action-button');
                for (const btn of button) {
                    btn.classList.remove("btn-active-light");
                    btn.disabled = true;
                }
            } else if (pMode == "DTL") {
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
    fnIfExist('oop_form_hdr', 'f_code', document.getElementById('ContentPlaceHolder1_hdnID').value, function (response) {
        if (response[0].oReturn == "1") {
            Download();
        } else {
            fnAlertOnly('No active form found!', 'warning', 'btn btn-warning');
        };
    });
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
                fn0601LoadHistory(pID);
            },
        });
    };
};
function fn0201Delete(pFormCode, pID, pFileName) {
    //if exisit
    fnIfExist('oop_form_hdr', 'f_code', document.getElementById('ContentPlaceHolder1_hdnID').value, function (response) {
        if (response[0].oReturn == "1") {
            Delete_Question(pFormCode, pID, pFileName);
        } else {
            fnAlertOnly('No active form found!', 'warning', 'btn btn-warning');
        };
    });

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
                fnAlertOnly('File successfully removed!', 'success', 'btn btn-success');
                fn0201LoadAttachment(document.getElementById('ContentPlaceHolder1_hdnMode').value, pID);
                fn0601LoadHistory(pID);
            },
        });
    };
};
//attachment

//notes
function fn0301LoadNotes(pID) {
    $.ajax({
        type: "POST",
        url: "HNDGEN.ashx",
        data: {
            'pFormCode': 'FRM000010',
            'pType': 'Notes - Get Record',
            'pID': pID,
        },
        success: function (response) {
            //display loader
            document.getElementById("div0301LoaderNotes").style.display = "";
            //display loader

            $('#table0301Notes').DataTable().destroy();

            //disable column type detection
            DataTable.types().forEach(type => {
                DataTable.type(type, 'detect', () => false);
            });
            //disable column type detection

            //sort date by yyyy/mm/dd
            $.fn.dataTable.moment('MM/DD/YYYY');
            //sort date by yyyy/mm/dd

            //datatable
            var table0301Notes = $("#table0301Notes").DataTable({
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
            //datatable

            //search
            $('#tbx0301FindNotes').on('keyup', function () {
                table0301Notes.search(this.value).draw();
            });
            //search

            //hide loader
            document.getElementById("div0301LoaderNotes").style.display = "none";
            //hide loader

        },
    });
};
function fn0301Add() {
    //if exisit
    fnIfExist('oop_form_hdr', 'f_code', document.getElementById('ContentPlaceHolder1_hdnID').value, function (response) {
        if (response[0].oReturn == "1") {
            Add();
        } else {
            fnAlertOnly('No active form found!', 'warning', 'btn btn-warning');
        };
    });
    //add
    function Add() {
        document.getElementById("tbx0302Note").value = "";
        document.getElementById("hdnMention").value = "";
        $('#mdl0302Notes').modal('show');
    };
};
function fn0301Add_Ok(Btn) {
    //if exisit
    fnIfExist('oop_form_hdr', 'f_code', document.getElementById('ContentPlaceHolder1_hdnID').value, function (response) {
        if (response[0].oReturn == "1") {
            Add_Ok();
        } else {
            fnAlertOnly('No active form found!', 'warning', 'btn btn-warning');
        };
    });
    //add
    async function Add_Ok() {
        // Disable the clicked button to avoid multiple clicks
        Btn.disabled = true;
        // Show loading indicator
        Btn.setAttribute('data-kt-indicator', 'on');
        // Simulate form submission
        await fn0301Add_Ok_Await(Btn);
    }
    function fn0301Add_Ok_Await(Btn) {
        // process
        return new Promise(resolve => {
            //Validate
            if (document.getElementById("tbx0302Note").value == "") {
                fnAlertOnly('Some field(s) are missing!', 'error', 'btn btn-danger');
            } else {
                Add_Ok_Await();
            }
            //add
            function Add_Ok_Await() {
                // Do Billing
                $.ajax({
                    type: "POST",
                    url: "HNDGEN.ashx",
                    data: {
                        'pFormCode': 'FRM000010',
                        'pType': 'Notes - Add',
                        'pID': document.getElementById('ContentPlaceHolder1_hdnID').value,
                        'pNotes': document.getElementById("tbx0302Note").value,
                        'pMention': document.getElementById("hdnMention").value,
                    },
                    success: function (response) {
                        //message
                        fnAlertOnly('Note successfully added.', 'success', 'btn btn-success');
                        document.getElementById("tbx0302Note").value = "";
                        document.getElementById("hdnMention").value = "";
                        fn01Load();

                    },
                });
            };
            // Disable the clicked button to avoid multiple clicks
            Btn.disabled = false;
            // Hide loading indication
            Btn.removeAttribute('data-kt-indicator');
            //resolve
            resolve();
        });
    };
};
//notes

//approval
function fn0401LoadApprover(pID) {
    $.ajax({
        type: "POST",
        url: "Assets/Handler/FRM/FRM000010HND.ashx",
        data: {
            'pFormCode': 'FRM000010',
            'pType': 'Get - Approval Path',
            'pID': pID
        },
        success: function (response) {
            //display loader
            document.getElementById("div0401LoaderApprover").style.display = "";
            //display loader

            $('#table0401Approver').DataTable().destroy();

            //disable column type detection
            DataTable.types().forEach(type => {
                DataTable.type(type, 'detect', () => false);
            });
            //disable column type detection

            //sort date by yyyy/mm/dd
            $.fn.dataTable.moment('MM/DD/YYYY');
            //sort date by yyyy/mm/dd

            var table0401Approver = $("#table0401Approver").DataTable({
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
                    { data: 'Bullet' },
                    { data: 'Action' },
                    { data: 'Type' },
                    { data: 'User' },
                    { data: 'Status' },
                    { data: 'TAT' },
                    { data: 'RFD' }],
                columnDefs: [
                    { targets: 0, orderable: false, className: 'tbody-nowrap-auto mw-5px min-w-5px' },
                    { targets: 1, orderable: false },
                    { targets: 2, orderable: false },
                    { targets: 3, orderable: false },
                    { targets: 4, orderable: false },
                    { targets: 5, orderable: false },
                    { targets: 6, orderable: false, className: 'tbody-nowrap-auto' }
                ]
            });

            //hide loader
            document.getElementById("div0401LoaderApprover").style.display = "none";
            //hide loader

        },
    });
};
function fn0401AddApproval() {
    //if exisit
    fnIfExist('oop_form_hdr', 'f_code', document.getElementById('ContentPlaceHolder1_hdnID').value, function (response) {
        if (response[0].oReturn == "1") {
            FRMValidateRecord();
        } else {
            fnAlertOnly('No active form found!', 'warning', 'btn btn-warning');
        };
    });
    function FRMValidateRecord() {
        fnFRMValidateRecord("04ApprovalPath", "Add", document.getElementById('ContentPlaceHolder1_hdnID').value, "", "", function (response) {
            if (response[0].Msg === "") {
                showModal();
            } else {
                fnAlertOnly(response[0].Msg, 'error', 'btn btn-danger');
            };
        });
    };
    function showModal() {
        $('#mdl0401Aprroval').modal('show');
        document.getElementById("pnl04Type").style.display = "none";
        document.getElementById("pnl04AssignTo").style.display = "none";
        document.getElementById("pnl04NoDays").style.display = "none";
        document.getElementById("pnl04Template").style.display = "none";
        $('#ddl0401AddFrom').val('').trigger('change');
        $('#ddl0401Type').val('').trigger('change');
        ddl0401Approver('', '');
        /*  $('#ddl04Template').val('').trigger('change');*/
        document.getElementById("tbx04NoDays").value = "1.00";
        ddl0401Template();

    };
};
function ddl0401Approver(pfID, pType) {
    // if both are empty → show only blank option
    if ((!pfID || pfID === '') && (!pType || pType === '')) {
        $("#ddl0401Approver").html('<option value="">Select a user</option>');
        $('#ddl0401Approver').val('').trigger('change');
        return; // stop here, no ajax
    }
    $.ajax({
        type: "POST",
        url: "Assets/Handler/FRM/FRM000010HND.ashx",
        data: {
            'pFunction': 'Dropdown',
            'pType': 'Get - Dropdown - List',
            'pTblName': 'Approver_List',
            'pPlaceHolder': '',
            'pVal01': pfID,
            'pVal02': pType
        },
        success: function (response) {
            var s = '';
            for (var i = 0; i < response.length; i++) {
                s += '<option value="' + response[i].ID + '">' + response[i].Name + '</option>';
            }
            $("#ddl0401Approver").html(s);
            $('#ddl0401Approver').val('').trigger('change');
        },
    });
};
function ddl0401Template() {
    $.ajax({
        type: "POST",
        url: "Assets/Handler/FRM/FRM000010HND.ashx",
        data: {
            'pFunction': 'Dropdown',
            'pType': 'Get - Dropdown - List',
            'pTblName': 'Template_List',
            'pPlaceHolder': 'Select a template',
            'pVal01': 'FRM000010',
            'pVal02': ''
        },
        success: function (response) {

            var s = '';
            for (var i = 0; i < response.length; i++) {
                s += '<option value="' + response[i].ID + '">' + response[i].Name + '</option>';
            }
            $("#ddl0401Template").html(s);
            $('#ddl0401Template').val('').trigger('change');
        },
    });
};
function ddl0401AddFrom_onchange(ddl0401AddFrom) {
    const AddForm = ddl0401AddFrom.value;
    document.getElementById("pnl04Type").style.display = "none";
    document.getElementById("pnl04AssignTo").style.display = "none";
    document.getElementById("pnl04NoDays").style.display = "none";
    document.getElementById("pnl04Template").style.display = "none";
    $('#ddl0401Type').val('').trigger('change');
    ddl0401Approver('', '');
    /*  $('#ddl04Template').val('').trigger('change');*/
    document.getElementById("tbx04NoDays").value = "1.00";
    ddl0401Template();

    if (AddForm === "Manual") {
        document.getElementById("pnl04Type").style.display = "";
        $('#ddl0401Type').val('').trigger('change');

        document.getElementById("pnl04AssignTo").style.display = "";
        ddl0401Approver('', '');
        document.getElementById("pnl04NoDays").style.display = "";
        document.getElementById("tbx04NoDays").value = "1.00";
    }

    // Template
    if (AddForm === "Template") {
        document.getElementById("pnl04Template").style.display = "";
        ddl0401Template();
    }
};
function ddl0401Type_onchange(ddl0401Type) {
    ddl0401Approver('FRM000010', ddl0401Type.value);
};
function fn0401AddApprover_Ok(Btn) {
    // Disable the clicked button to avoid multiple clicks
    Btn.disabled = false;
    // Hide loading indication
    Btn.removeAttribute('data-kt-indicator');
    fnIfExist('oop_form_hdr', 'f_code', document.getElementById('ContentPlaceHolder1_hdnID').value, function (response) {
        if (response[0].oReturn == "1") {
            FRMValidateRecord(document.getElementById('ContentPlaceHolder1_hdnID').value);
        } else {
            fnAlertOnly('No active form found!', 'warning', 'btn btn-warning');
            // Disable the clicked button to avoid multiple clicks
            Btn.disabled = false;
            // Hide loading indication
            Btn.removeAttribute('data-kt-indicator');
        };
    });
    function FRMValidateRecord(ID) {
        fnFRMValidateRecord("04ApprovalPath", "Add", document.getElementById('ContentPlaceHolder1_hdnID').value, "", "", function (response) {
            if (response[0].Msg === "") {
                ValidateFields(ID);
            } else {
                fnAlertOnly(response[0].Msg, 'error', 'btn btn-danger');
                // Disable the clicked button to avoid multiple clicks
                Btn.disabled = false;
                // Hide loading indication
                Btn.removeAttribute('data-kt-indicator');
            };
        });
    }
    function ValidateFields(ID) {
        if (document.getElementById("ddl0401AddFrom").options[document.getElementById("ddl0401AddFrom").selectedIndex].value === "") {
            fnAlertOnly('Some field(s) are missing!', 'error', 'btn btn-danger');
            // Disable the clicked button to avoid multiple clicks
            Btn.disabled = false;
            // Hide loading indication
            Btn.removeAttribute('data-kt-indicator');
        } else if (document.getElementById("ddl0401AddFrom").options[document.getElementById("ddl0401AddFrom").selectedIndex].value === "Manual" && document.getElementById("ddl0401Type").options[document.getElementById("ddl0401Type").selectedIndex].value === "") {
            fnAlertOnly('Some field(s) are missing!', 'error', 'btn btn-danger');
            // Disable the clicked button to avoid multiple clicks
            Btn.disabled = false;
            // Hide loading indication
            Btn.removeAttribute('data-kt-indicator');
        } else if (document.getElementById("ddl0401AddFrom").options[document.getElementById("ddl0401AddFrom").selectedIndex].value === "Manual" && document.getElementById("ddl0401Approver").options[document.getElementById("ddl0401Approver").selectedIndex].value === "") {
            fnAlertOnly('Some field(s) are missing!', 'error', 'btn btn-danger');
            // Disable the clicked button to avoid multiple clicks
            Btn.disabled = false;
            // Hide loading indication
            Btn.removeAttribute('data-kt-indicator');
        } else if (document.getElementById("ddl0401AddFrom").options[document.getElementById("ddl0401AddFrom").selectedIndex].value === "Manual" && parseFloat(document.getElementById("tbx04NoDays").value) <= 0) {
            fnAlertOnly('Some field(s) are missing!', 'error', 'btn btn-danger');
            // Disable the clicked button to avoid multiple clicks
            Btn.disabled = false;
            // Hide loading indication
            Btn.removeAttribute('data-kt-indicator');
        } else if (document.getElementById("ddl0401AddFrom").options[document.getElementById("ddl0401AddFrom").selectedIndex].value === "Template" && document.getElementById("ddl0401Template").options[document.getElementById("ddl0401Template").selectedIndex].value === "") {
            fnAlertOnly('Some field(s) are missing!', 'error', 'btn btn-danger');
            // Disable the clicked button to avoid multiple clicks
            Btn.disabled = false;
            // Hide loading indication
            Btn.removeAttribute('data-kt-indicator');
        }
        else {
            SaveApprover(ID);
        }
    }
    function SaveApprover(ID) {
        $.ajax({
            type: "POST",
            url: "Assets/Handler/FRM/FRM000010HND.ashx",
            data: {
                'pFormCode': 'FRM000010',
                'pType': 'Add - Approver',
                'pID': ID,
                'pAddForm': document.getElementById("ddl0401AddFrom").options[document.getElementById("ddl0401AddFrom").selectedIndex].value,
                'pApproverType': document.getElementById("ddl0401Type").options[document.getElementById("ddl0401Type").selectedIndex].value,
                'pApprover': document.getElementById("ddl0401Approver").options[document.getElementById("ddl0401Approver").selectedIndex].value,
                'pNoDays': document.getElementById('tbx04NoDays').value,
                'pTemplate': document.getElementById("ddl0401Template").options[document.getElementById("ddl0401Template").selectedIndex].value
            },
            success: function (response) {
                fnAlertOnly('Record successfully saved.', 'success', 'btn btn-success');
                $('#ddl0401Type').val('').trigger('change');
                ddl0401Approver('', '');
                /*  $('#ddl04Template').val('').trigger('change');*/
                document.getElementById("tbx04NoDays").value = "1.00";
                ddl0401Template();
                fn01Load()
                // Disable the clicked button to avoid multiple clicks
                Btn.disabled = false;
                // Hide loading indication
                Btn.removeAttribute('data-kt-indicator');
            },
        });
    }
};
function fn0401Delete(pSeqNo) {
    //if exisit
    fnIfExist('oop_form_hdr', 'f_code', document.getElementById('ContentPlaceHolder1_hdnID').value, function (response) {
        if (response[0].oReturn == "1") {
            FRMValidateRecord(pSeqNo, document.getElementById('ContentPlaceHolder1_hdnID').value);
        } else {
            fnAlertOnly('No active form found!', 'warning', 'btn btn-warning');
        };
    });
    function FRMValidateRecord(pSeqNo, pID) {
        fnFRMValidateRecord("04ApprovalPath", "Delete", pID, pSeqNo, "", function (response) {
            if (response[0].Msg === "") {
                Delete_Question(pSeqNo, pID);
            } else {
                fnAlertOnly(response[0].Msg, 'error', 'btn btn-danger');
            };
        });
    }
    function Delete_Question(pSeqNo, pID) {
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
                fnIfExist('oop_form_hdr', 'f_code', pID, function (response) {
                    if (response[0].oReturn == "1") {
                        Delete_Ok(pSeqNo, pID);
                    } else {
                        fnAlertOnly('No active form found!', 'warning', 'btn btn-warning');
                    };
                });
            }
        });
    };
    function Delete_Ok(pSeqNo, pID) {
        $.ajax({
            type: "POST",
            url: "Assets/Handler/FRM/FRM000010HND.ashx",
            data: {
                'pFormCode': 'FRM000010',
                'pType': 'Delete - Approver',
                'pSeqno': pSeqNo,
                'pID': pID
            },
            success: function (response) {
                fnAlertOnly('Record successfully removed.', 'success', 'btn btn-success');
                fn01Load();
            },
        });

    };
};
function fn0401Up(pSeqNo) {
    //if exisit
    fnIfExist('oop_form_hdr', 'f_code', document.getElementById('ContentPlaceHolder1_hdnID').value, function (response) {
        if (response[0].oReturn == "1") {
            FRMValidateRecord(pSeqNo, document.getElementById('ContentPlaceHolder1_hdnID').value);
        } else {
            fnAlertOnly('No active form found!', 'warning', 'btn btn-warning');
        };
    });
    function FRMValidateRecord(pSeqNo, pID) {
        fnFRMValidateRecord("04ApprovalPath", "Up", pID, pSeqNo, "", function (response) {
            if (response[0].Msg === "") {
                Up_Ok(pSeqNo, pID);
            } else {
                fnAlertOnly(response[0].Msg, 'error', 'btn btn-danger');
            };
        });
    }

    function Up_Ok(pSeqNo, pID) {
        $.ajax({
            type: "POST",
            url: "Assets/Handler/FRM/FRM000010HND.ashx",
            data: {
                'pFormCode': 'FRM000010',
                'pType': 'Move - Up Record Approver',
                'pSeqno': pSeqNo,
                'pID': pID
            },
            success: function (response) {
                fnAlertOnly('Record successfully moved.', 'success', 'btn btn-success');
                fn01Load();
            },
        });

    };
};
function fn0401Down(pSeqNo) {
    //if exisit
    fnIfExist('oop_form_hdr', 'f_code', document.getElementById('ContentPlaceHolder1_hdnID').value, function (response) {
        if (response[0].oReturn == "1") {
            FRMValidateRecord(pSeqNo, document.getElementById('ContentPlaceHolder1_hdnID').value);
        } else {
            fnAlertOnly('No active form found!', 'warning', 'btn btn-warning');
        };
    });
    function FRMValidateRecord(pSeqNo, pID) {
        fnFRMValidateRecord("04ApprovalPath", "Down", pID, pSeqNo, "", function (response) {
            if (response[0].Msg === "") {
                Up_Ok(pSeqNo, pID);
            } else {
                fnAlertOnly(response[0].Msg, 'error', 'btn btn-danger');
            };
        });
    }
    function Up_Ok(pSeqNo, pID) {
        $.ajax({
            type: "POST",
            url: "Assets/Handler/FRM/FRM000010HND.ashx",
            data: {
                'pFormCode': 'FRM000010',
                'pType': 'Move - Down Record Approver',
                'pSeqno': pSeqNo,
                'pID': pID
            },
            success: function (response) {
                fnAlertOnly('Record successfully moved.', 'success', 'btn btn-success');
                fn01Load();
            },
        });
    };
};
function fn0402UpdateR4D(pSeqNo) {
    //if exisit
    fnIfExist('oop_form_hdr', 'f_code', document.getElementById('ContentPlaceHolder1_hdnID').value, function (response) {
        if (response[0].oReturn == "1") {
            FRMValidateRecord(document.getElementById('ContentPlaceHolder1_hdnID').value, pSeqNo);
        } else {
            fnAlertOnly('No active form found!', 'warning', 'btn btn-warning');
        };
    });
    function FRMValidateRecord(pID, pSeqNo) {
        fnFRMValidateRecord("04ApprovalPath", "Save(ReasonForDelay)", pID, pSeqNo, "", function (response) {
            if (response[0].Msg === "") {
                showModal(pSeqNo);
            } else {
                fnAlertOnly(response[0].Msg, 'error', 'btn btn-danger');
            };
        });
    };
    function showModal(pSeqNo) {
        $('#mdl0402Reason4Delays').modal('show');
        document.getElementById("tbx0402ReasonForDelay").value = "";
        document.getElementById("ContentPlaceHolder1_hdnSeqNo").value = pSeqNo;

    }
};
function fn0402AddReason_Ok(Btn) {
    // Disable the clicked button to avoid multiple clicks
    Btn.disabled = true;
    // Show loading indicator
    Btn.setAttribute('data-kt-indicator', 'on');
    fnIfExist('oop_form_hdr', 'f_code', document.getElementById('ContentPlaceHolder1_hdnID').value, function (response) {
        if (response[0].oReturn == "1") {
            FRMValidateRecord(document.getElementById('ContentPlaceHolder1_hdnID').value, document.getElementById("ContentPlaceHolder1_hdnSeqNo").value);
        } else {
            fnAlertOnly('No active form found!', 'warning', 'btn btn-warning');
            // Disable the clicked button to avoid multiple clicks
            Btn.disabled = false;
            // Hide loading indication
            Btn.removeAttribute('data-kt-indicator');
        };
    });
    function FRMValidateRecord(ID, pSeqNo) {
        fnFRMValidateRecord("04ApprovalPath", "Save(ReasonForDelay)", ID, pSeqNo, "", function (response) {
            if (response[0].Msg == "") {
                ValidateFields(ID, pSeqNo);
            } else {
                fnAlertOnly(response[0].Msg, 'error', 'btn btn-danger');
                // Disable the clicked button to avoid multiple clicks
                Btn.disabled = false;
                // Hide loading indication
                Btn.removeAttribute('data-kt-indicator');
            };
        });
    }
    function ValidateFields(ID, pSeqNo) {
        if (document.getElementById("tbx0402ReasonForDelay").value === "") {
            fnAlertOnly('Some field(s) are missing!', 'error', 'btn btn-danger');
            // Disable the clicked button to avoid multiple clicks
            Btn.disabled = false;
            // Hide loading indication
            Btn.removeAttribute('data-kt-indicator');
        }
        else {
            Upd_Ok(ID, pSeqNo);
        }
    }
    function Upd_Ok(ID, pSeqNo) {
        $.ajax({
            type: "POST",
            url: "Assets/Handler/FRM/FRM000010HND.ashx",
            data: {
                'pFormCode': 'FRM000010',
                'pType': 'Update - Reason',
                'pID': ID,
                'pSeqNo': pSeqNo,
                'pReason': document.getElementById('tbx0402ReasonForDelay').value
            },
            success: function (response) {
                fnAlertOnly('Record successfully saved.', 'success', 'btn btn-success');
                document.getElementById("tbx0402ReasonForDelay").value = "";
                ddl0401Template();
                fn01Load()
                // Disable the clicked button to avoid multiple clicks
                Btn.disabled = false;
                // Hide loading indication
                Btn.removeAttribute('data-kt-indicator');
            },
        });
    }
};
//approval

//subscriber
function fn0501LoadSubscriber(pID) {
    $.ajax({
        type: "POST",
        url: "Assets/Handler/FRM/FRM000010HND.ashx",
        data: {
            'pFormCode': 'FRM000010',
            'pType': 'Get - Subscriber',
            'pID': pID
        },
        success: function (response) {
            //display loader
            document.getElementById("div0501LoaderSubscriber").style.display = "";
            //display loader
            $('#table0501Subscriber').DataTable().destroy();
            DataTable.types().forEach(type => { DataTable.type(type, 'detect', () => false); });
            $.fn.dataTable.moment('MM/DD/YYYY');
            var table0501Subscriber = $("#table0501Subscriber").DataTable({
                processing: true,
                bFilter: true,
                bPaginate: false,
                bInfo: false,
                scrollCollapse: true,
                paging: false,
                lengthChange: false,
                select: false,
                data: response,
                columns: [
                    { data: 'Bullet' },
                    { data: 'Action' },
                    { data: 'User' }],
                columnDefs: [
                    { targets: 0, orderable: false, className: 'tbody-nowrap-auto mw-5px min-w-5px' },
                    { targets: 1, orderable: false },
                    { targets: 2, orderable: false, className: 'tbody-nowrap-auto' }
                ],
                order: [],
            });

            //search
            $('#tbx03010101Find').on('keyup', function () {
                table0501Subscriber.search(this.value).draw();
            });
            //search

            //hide loader
            document.getElementById("div0501LoaderSubscriber").style.display = "none";
            //hide loader

        },
    });
};
function fn0502AddSubscriber() {
    //if exisit
    fnIfExist('oop_form_hdr', 'f_code', document.getElementById('ContentPlaceHolder1_hdnID').value, function (response) {
        if (response[0].oReturn == "1") {
            FRMValidateRecord(document.getElementById('ContentPlaceHolder1_hdnID').value);
        } else {
            fnAlertOnly('No active form found!', 'warning', 'btn btn-warning');
        };
    });
    function FRMValidateRecord(ID) {
        fnFRMValidateRecord("03Subscribers", "Add", ID, "", "", function (response) {
            if (response[0].Msg === "") {
                showModal();
            } else {
                fnAlertOnly(response[0].Msg, 'error', 'btn btn-danger');
            };
        });
    }
    function showModal() {
        $('#mdl0501AddSubscriber').modal('show')
        ddl0501Subscriber();
    }
};
function ddl0501Subscriber() {
    $.ajax({
        type: "POST",
        url: "Assets/Handler/FRM/FRM000010HND.ashx",
        data: {
            'pFunction': 'Dropdown',
            'pType': 'Get - Dropdown - List',
            'pTblName': 'Subscriber_List',
            'pPlaceHolder': '',
            'pVal01': '',
            'pVal02': ''
        },
        success: function (response) {
            var s = '';
            for (var i = 0; i < response.length; i++) {
                s += '<option value="' + response[i].ID + '">' + response[i].Name + '</option>';
            }
            $("#ddl0501AddUser").html(s);
            $('#ddl0501AddUser').val('').trigger('change');
        },
    });
};
function fn0502AddSubscriber_Ok(Btn) {
    // Disable the clicked button to avoid multiple clicks
    Btn.disabled = true;
    // Show loading indicator
    Btn.setAttribute('data-kt-indicator', 'on');
    // Simulate form submission
    fnIfExist('oop_form_hdr', 'f_code', document.getElementById('ContentPlaceHolder1_hdnID').value, function (response) {
        if (response[0].oReturn == "1") {
            FRMValidateRecord(document.getElementById('ContentPlaceHolder1_hdnID').value);
        } else {
            fnAlertOnly('No active form found!', 'warning', 'btn btn-warning');
            // Disable the clicked button to avoid multiple clicks
            Btn.disabled = false;
            // Hide loading indication
            Btn.removeAttribute('data-kt-indicator');
        };
    });
    function FRMValidateRecord(ID) {
        fnFRMValidateRecord("03Subscribers", "Add", ID, "", "", function (response) {
            if (response[0].Msg === "") {
                ValidateFields(ID);
            } else {
                fnAlertOnly(response[0].Msg, 'error', 'btn btn-danger');
                // Disable the clicked button to avoid multiple clicks
                Btn.disabled = false;
                // Hide loading indication
                Btn.removeAttribute('data-kt-indicator');
            };
        });
    }
    function ValidateFields(ID) {
        if (document.getElementById("ddl0501AddUser").options[document.getElementById("ddl0501AddUser").selectedIndex].value === "") {
            fnAlertOnly('Some field(s) are missing!', 'error', 'btn btn-danger');
            // Disable the clicked button to avoid multiple clicks
            Btn.disabled = false;
            // Hide loading indication
            Btn.removeAttribute('data-kt-indicator');
        }
        else {
            AddUser_Ok(ID);
        }
    }
    function AddUser_Ok(ID) {
        $.ajax({
            type: "POST",
            url: "Assets/Handler/FRM/FRM000010HND.ashx",
            data: {
                'pFormCode': 'FRM000010',
                'pType': 'Add - Subscriber',
                'pID': ID,
                'pMonitorBy': document.getElementById("ddl0501AddUser").options[document.getElementById("ddl0501AddUser").selectedIndex].value
            },
            success: function (response) {
                fnAlertOnly('Record successfully saved.', 'success', 'btn btn-success');
                ddl0501Subscriber();
                fn01Load()
                // Disable the clicked button to avoid multiple clicks
                Btn.disabled = false;
                // Hide loading indication
                Btn.removeAttribute('data-kt-indicator');
            },
        });
    }
};
function fn0501Delete(pMonitorBy) {
    //if exisit
    fnIfExist('oop_form_hdr', 'f_code', document.getElementById('ContentPlaceHolder1_hdnID').value, function (response) {
        if (response[0].oReturn == "1") {
            FRMValidateRecord(pMonitorBy, document.getElementById('ContentPlaceHolder1_hdnID').value);
        } else {
            fnAlertOnly('No active form found!', 'warning', 'btn btn-warning');
        };
    });
    function FRMValidateRecord(pMonitorBy, pID) {
        fnFRMValidateRecord("03Subscribers", "Delete", pID, "", "", function (response) {
            if (response[0].Msg === "") {
                Delete_Question(pMonitorBy, pID);
            } else {
                fnAlertOnly(response[0].Msg, 'error', 'btn btn-danger');
            };
        });
    }
    function Delete_Question(pMonitorBy, pID) {
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
                fnIfExist('oop_form_hdr', 'f_code', pID, function (response) {
                    if (response[0].oReturn == "1") {
                        Delete_Ok(pMonitorBy, pID);
                    } else {
                        fnAlertOnly('No active form found!', 'warning', 'btn btn-warning');
                    };
                });
            }
        });
    };
    function Delete_Ok(pMonitorBy, pID) {
        $.ajax({
            type: "POST",
            url: "Assets/Handler/FRM/FRM000010HND.ashx",
            data: {
                'pFormCode': 'FRM000010',
                'pType': 'Delete - Subscriber',
                'pID': pID,
                'pMonitorBy': pMonitorBy
            },
            success: function (response) {
                fnAlertOnly('Record successfully removed.', 'success', 'btn btn-success');
                fn01Load();
            },
        });

    };
};
//subscriber

//history
function fn0601LoadHistory(pID) {
    $.ajax({
        type: "POST",
        url: "Assets/Handler/FRM/FRM000010HND.ashx",
        data: {
            'pFormCode': 'FRM000010',
            'pType': 'Get - History',
            'pID': pID
        },
        success: function (response) {
            $('#table0601History').DataTable().destroy();
            DataTable.types().forEach(type => { DataTable.type(type, 'detect', () => false); });
            $.fn.dataTable.moment('MM/DD/YYYY');
            var table0601History = $("#table0601History").DataTable({
                processing: true,
                bFilter: true,
                bPaginate: false,
                bInfo: false,
                scrollCollapse: true,
                paging: false,
                lengthChange: false,
                select: false,
                data: response,
                columns: [
                    { data: 'Data' }],
                columnDefs: [
                    { targets: 0, orderable: false, className: 'tbody-nowrap-auto mw-5px min-w-5px' },
                ],
                order: [],
            });
        },
    });
};
//history

//@mention
var mentionUser = [];
var initialMention = [];
var jq = jQuery.noConflict();
//@mention

//master
function pageLoad(sender, args) { InitialiseSettings(); }
function InitialiseSettings() {
    jQuery(function ($) {

        //combobox
        $('[data-kt-repeater="select2"]').select2();
        //combobox

        //date
        $('[data-kt-repeater="datepicker"]').flatpickr({
            dateFormat: "m/d/Y"
        });
        //date

        //dropzone
        Dropzone.autoDiscover = false;
        var myDropzone = new Dropzone("#divDropzone", {
            url: "Assets/Handler/MNU/MNU001000HND.ashx?pFunction=Add-Record-98&pFormCode=" + FormCode + "&pID=" + document.getElementById('ContentPlaceHolder1_hdnID').value,
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
                fn0201LoadAttachment(document.getElementById('ContentPlaceHolder1_hdnMode').value, document.getElementById('ContentPlaceHolder1_hdnID').value);
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
            fnIfExist('oop_form_hdr', 'f_code', document.getElementById('ContentPlaceHolder1_hdnID').value, function (response) {
                if (response[0].oReturn == "1") {
                    Validate(document.getElementById('ContentPlaceHolder1_hdnID').value);
                } else {
                    fn01AlertOnly('No active form found.', 'warning', 'btn btn-warning')
                };
            });
            function Validate(ID) {
                fnFRMValidateRecord("02Files", "Add", ID, "", "", function (response) {
                    if (response[0].Msg == "") {
                        myDropzone.removeAllFiles();
                        FileCount = 0;
                        $('#mdl9801Upload').modal('show');
                    } else {
                        fn01AlertOnly(response[0].oReturn, 'error', 'btn btn-danger');
                    }; 0
                });
            }

        });
        $('#btn9801Add').on('click', function (e) {
            if (FileCount > 0) {
                fnFRMValidateRecord("02Files", "Add", document.getElementById('ContentPlaceHolder1_hdnID').value, "", "", function (response) {
                    if (response[0].Msg == "") {
                        btn9801Add();
                    } else {
                        fn01AlertOnly(response[0].oReturn, 'error', 'btn btn-danger');
                    };
                });
            } else {
                fn01AlertOnly('Attach at least one file to proceed!', 'error', 'btn btn-danger');
            };
            async function btn9801Add() {
                var Btn = document.getElementById('btn9801Add');
                Btn.disabled = true;
                Btn.setAttribute('data-kt-indicator', 'on');
                await btn9801Add_Await(Btn);
            };
            async function btn9801Add_Await(Btn) {
                return new Promise(resolve => {
                    myDropzone.options.url = "Assets/Handler/MNU/MNU001000HND.ashx?pFunction=Add-Record-98&pFormCode=" + FormCode + "&pID=" + document.getElementById('ContentPlaceHolder1_hdnID').value;
                    myDropzone.processQueue();
                    resolve();
                });
            };
        });
        //dropzone

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
                };
                $inputor = jq('.mention').atwho(at_config);
                $inputor.caret('pos', 47);
                $inputor.focus().atwho('run');
                $inputor.on('keydown', function (e) {
                    if (e.keyCode === 8) {
                        handleBackspace();
                    }
                });
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
                };
            };
        };
    });
    jQuery(function ($) {
        fn01Load();
    });
};
//master