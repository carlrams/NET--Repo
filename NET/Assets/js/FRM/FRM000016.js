
//variable
var FileCount = 0;
//variable
function fnFRMValidateRecord(pGroup, pFType, pID, pValue,pValue2, callBack) {
    $.ajax({
        type: "POST",
        url: "Assets/Handler/FRM/HNDFRM000016.ashx",
        data: {
            'pFormCode': 'FRM000016',
            'pType': 'Get Msg Alert',
            'pID': pID,
            'pValue': pValue,
            'pValue2': pValue2,
            'pGroup': pGroup,
            'pFType': pFType
        },
        success: function (response) {
            callBack(response);
        },
    });
};
//general
function fn01Load() {
        fn0101LoadOverview(document.getElementById('ContentPlaceHolder1_hdnMode').value, document.getElementById('ContentPlaceHolder1_hdnID').value);
        fn0102LoadMovement(document.getElementById('ContentPlaceHolder1_hdnMode').value, document.getElementById('ContentPlaceHolder1_hdnID').value);
        fn0201LoadAttachment(document.getElementById('ContentPlaceHolder1_hdnMode').value, document.getElementById('ContentPlaceHolder1_hdnID').value);
        fn0301LoadNotes(document.getElementById('ContentPlaceHolder1_hdnID').value);
        fn0401LoadApprover(document.getElementById('ContentPlaceHolder1_hdnID').value);
        fn0501LoadSubscriber(document.getElementById('ContentPlaceHolder1_hdnID').value);
        fn0601LoadHistory(document.getElementById('ContentPlaceHolder1_hdnID').value);
        //fn0102LoadMovementModal(document.getElementById('ContentPlaceHolder1_hdnMode').value, '', document.getElementById('ContentPlaceHolder1_hdnID').value);
};
function fn01DisableButtons(pValue) {
    if (pValue == true) {
        document.getElementById("btn0101Find").classList.remove("btn-view");
        document.getElementById("btn0101Refresh").classList.remove("btn-view");
        document.getElementById("btn0101Add").classList.remove("btn-add");
        document.getElementById("btn0101Delete").classList.remove("btn-delete");
        document.getElementById("btn0101Edit").classList.remove("btn-edit");
        document.getElementById("btn0201Add").classList.remove("btn-add");
        document.getElementById("btn0102Upload").classList.remove("btn-add");
        document.getElementById("btn0301Add").classList.remove("btn-add");
        document.getElementById("btn0102Add").classList.remove("btn-add");
        document.getElementById("btn0401Add").classList.remove("btn-add");
        document.getElementById("btn03010101Add").classList.remove("btn-add");
        document.getElementById("btn0101Print").classList.remove("btn-tools");
        document.getElementById("btn0101ChangeStatus").classList.remove("btn-secondary");
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
        document.getElementById("btn0201Add").classList.add("btn-add");
        document.getElementById("btn0102Upload").classList.add("btn-add");
        document.getElementById("btn0301Add").classList.add("btn-add");
        document.getElementById("btn0102Add").classList.add("btn-add");
        document.getElementById("btn0401Add").classList.add("btn-add");
        document.getElementById("btn03010101Add").classList.add("btn-add");
        document.getElementById("btn0101Print").classList.add("btn-tools");
        document.getElementById("btn0101ChangeStatus").classList.add("btn-secondary");
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
    document.getElementById("btn0201Add").disabled = pValue;
    document.getElementById("btn0102Upload").disabled = pValue;
    document.getElementById("btn0301Add").disabled = pValue;
    document.getElementById("btn0102Add").disabled = pValue;
    document.getElementById("btn0401Add").disabled = pValue;
    document.getElementById("btn03010101Add").disabled = pValue;
    document.getElementById("btn0101Print").disabled = pValue;
    document.getElementById("btn0101ChangeStatus").disabled = pValue;
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
}
//general

//overview
function fn0101LoadOverview(pMode, pID) {
    if (pMode == "ADD") {
        $.ajax({
            type: "POST",
            url: "Assets/Handler/FRM/HNDFRM000016.ashx",
            data: {
                'pFormCode': 'FRM000016',
                'pType': 'Get - FullName',
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
                document.getElementById("div0101EditPayment").style.display = "none";
                document.getElementById("div0101EditPaymentAdd").style.display = "none";
                document.getElementById("div0101Payee").style.display = "none";

                document.getElementById("tbx0101ID").value = "0000000000000";
                document.getElementById("tbx0101FormType").value = "Petty Cash/Revolving Fund";
                document.getElementById("tbx0101DateRequested").value = response[0].DateNow;
                document.getElementById("tbx0101DateRequired").value = response[0].DateNow;
                document.getElementById("tbx0101Requestedby").value = response[0].fullname;
                document.getElementById("tbx0101AssignedTo").value = response[0].fullname;
                document.getElementById("tbx0101EndorsedTo").value = "-";
                document.getElementById("tbx0101Status").value = "New";
                ddl0101Branch('');
                skipFundOnChange = true;
                ddl0101Fund('', '');
                $('#ddl0101Type').val('').trigger('change');
                $('#ddl0101Type option[value="Cash Payment and Cash Liquidation"]').remove();
                $('#ddl0101Type option[value="Cash Payment Only"]').remove();
                ddl0101Department('');
                document.getElementById("ddl0101PayeeType").setAttribute("onchange", "");
                $('#ddl0101PayeeType').val('').trigger('change');
                document.getElementById("ddl0101PayeeType").setAttribute("onchange", "ddl0101PayeeType_onchange(this)");
                ddl0101Payee('', '');
                document.getElementById("tbx0101RefNo").value = "";
                document.getElementById("tbx0101Remarks").value = "";
                document.getElementById("tbx0101DueDate").value = "";
                document.getElementById("cbx0101EditIsPickUp").checked = false;
                document.getElementById("cbx0101EditIsDeposit").checked = false;
                document.getElementById("tbx0101BankName").value = "-";
                document.getElementById("tbx0101AcctName").value = "-";
                document.getElementById("tbx0101AcctNo").value = "-";
                document.getElementById("cbx0101EditWithEWT").checked = false;
                document.getElementById("tbx0101GrossAmt").value = "0.00";
                document.getElementById("tbx0101EWT").value = "0.00";
                document.getElementById("tbx0101NetAmt").value = "0.00";
                //content

            },
        });
    } else if (pMode == "DTL") {
        $.ajax({
            type: "POST",
            url: "Assets/Handler/FRM/HNDFRM000016.ashx",
            data: {
                'pFormCode': 'FRM000016',
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
                    document.getElementById("div0101DetailPayment").style.display = "none";
                    document.getElementById("div0101DetailPaymentAdd").style.display = "none";
                    document.getElementById("div0101DetailPayee").style.display = "none";

                    document.getElementById("lbl0101ID").innerText = "-";
                    document.getElementById("lbl0101FormType").innerText = "-";
                    document.getElementById("lbl0101DateRequested").innerText = "-";
                    document.getElementById("lbl0101DateRequired").innerText = "-";
                    document.getElementById("lbl0101Requestedby").innerText = "-";
                    document.getElementById("lbl0101AssignedTo").innerText = "-";
                    document.getElementById("lbl0101EndorsedTo").innerText = "-";
                    document.getElementById("lbl0101Status").innerText = "-";
                    document.getElementById("lbl0101Branch").innerText = "-";
                    document.getElementById("lbl0101Fund").innerText = "-";
                    document.getElementById("lbl0101Type").innerText = "-";
                    document.getElementById("lbl0101Department").innerText = "-";
                    document.getElementById("lbl0101RefNo").innerText = "-";
                    document.getElementById("lbl0101Remarks").innerText = "-";
                    document.getElementById("lbl0101DueDate").innerText = "-";

                    // Checkboxes
                    document.getElementById("cbx0101IsPickUp").checked = false;
                    document.getElementById("cbx0101IsDeposit").checked = false;
                    document.getElementById("cbx0101WithEWT").checked = false;

                    // Payment detail labels
                    document.getElementById("lbl0101Bankname").innerText = "-";
                    document.getElementById("lbl0101AcctName").innerText = "-";
                    document.getElementById("lbl0101AcctNo").innerText = "-";
                    document.getElementById("lbl0101GrossAmt").innerText = "-";
                    document.getElementById("lbl0101EWT").innerText = "-";
                    document.getElementById("lbl0101NetAmt").innerText = "-";
                    return;
                }
                //title
                document.getElementById("spn0101Title").innerText = response[0].FormTitle;
                document.getElementById("spn0101ID").innerText = response[0].ID;
                document.getElementById("spn0101Status").innerText = response[0].RecordStatus;
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
                document.getElementById("div0101DetailPayment").style.display = "none";
                document.getElementById("div0101DetailPaymentAdd").style.display = "none";
                document.getElementById("div0101DetailPayee").style.display = "none";

                document.getElementById("lbl0101ID").innerText = response[0].ID;
                document.getElementById("lbl0101FormType").innerText = response[0].FormType;
                document.getElementById("lbl0101DateRequested").innerText = response[0].DateCreated;
                document.getElementById("lbl0101DateRequired").innerText = response[0].DateRequired;
                document.getElementById("lbl0101Requestedby").innerText = response[0].RequestedBy;
                document.getElementById("lbl0101AssignedTo").innerText = response[0].AssignedTo;
                document.getElementById("lbl0101EndorsedTo").innerText = response[0].EndorsedTo;
                document.getElementById("lbl0101Status").innerText = response[0].RecordStatus;
                document.getElementById("lbl0101Branch").innerText = response[0].Branch;
                document.getElementById("lbl0101Fund").innerText = response[0].Fund;

                document.getElementById("lbl0101Type").innerText = response[0].Type;
                document.getElementById("lbl0101Department").innerText = response[0].Department;

                document.getElementById("lbl0101PayeeType").innerText = response[0].PayeeType;
                document.getElementById("lbl0101Payee").innerText = response[0].Payor;

                document.getElementById("lbl0101RefNo").innerText = response[0].RefNo;
                document.getElementById("lbl0101Remarks").innerText = response[0].Remarks;
                document.getElementById("lbl0101DueDate").innerText = response[0].DueDate;
                if (response[0].IsPickUp == "1") {
                    document.getElementById("cbx0101IsPickUp").checked = true;
                } else {
                    document.getElementById("cbx0101IsPickUp").checked = false;
                };
                if (response[0].IsDeposit == "1") {
                    document.getElementById("cbx0101IsDeposit").checked = true;
                } else {
                    document.getElementById("cbx0101IsDeposit").checked = false;
                };
                document.getElementById("lbl0101Bankname").innerText = response[0].BankName;
                document.getElementById("lbl0101AcctName").innerText = response[0].AcctName;
                document.getElementById("lbl0101AcctNo").innerText = response[0].AcctNo;
                if (response[0].WithEWT == "1") {
                    document.getElementById("cbx0101WithEWT").checked = true;
                } else {
                    document.getElementById("cbx0101WithEWT").checked = false;
                };
                document.getElementById("lbl0101GrossAmt").innerText = response[0].GrossAmt;
                document.getElementById("lbl0101EWT").innerText = response[0].EWT;
                document.getElementById("lbl0101NetAmt").innerText = response[0].NetAmt;


                // If Type = Cash Advance AND Fund = SCM Fund
                if (response[0].Type === "Cash Advance" && response[0].Fund === "SCM Fund") {
                    document.getElementById("div0101DetailPayment").style.display = "";
                }

                // If Type = Cash Payment AND Fund = SCM Fund
                if (response[0].Type === "Cash Payment" && response[0].Fund === "SCM Fund") {
                    document.getElementById("div0101DetailPayment").style.display = "";
                    document.getElementById("div0101DetailPaymentAdd").style.display = "";
                    document.getElementById("div0101DetailPayee").style.display = "";

                }

            },
        });
    } else if (pMode == "UPD") {
        $.ajax({
            type: "POST",
            url: "Assets/Handler/FRM/HNDFRM000016.ashx",
            data: {
                'pFormCode': 'FRM000016',
                'pType': 'Get - Record',
                'pID': pID
            },
            success: function (response) {
                //title
                document.getElementById("spn0101Title").innerText = response[0].FormTitle;
                document.getElementById("spn0101ID").innerText = response[0].ID;
                document.getElementById("spn0101Status").innerText = response[0].RecordStatus;
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
                document.getElementById("div0101EditPayment").style.display = "none";
                document.getElementById("div0101EditPaymentAdd").style.display = "none";
                document.getElementById("div0101Payee").style.display = "none";

                document.getElementById("tbx0101ID").value = response[0].ID;
                document.getElementById("tbx0101FormType").value = response[0].FormType;
                document.getElementById("tbx0101DateRequested").value = response[0].DateCreated;
                document.getElementById("tbx0101DateRequired").value = response[0].DateRequired;
                document.getElementById("tbx0101Requestedby").value = response[0].RequestedBy;
                document.getElementById("tbx0101AssignedTo").value = response[0].AssignedTo;
                document.getElementById("tbx0101EndorsedTo").value = response[0].EndorsedTo;
                document.getElementById("tbx0101Status").value = response[0].RecordStatus;
                ddl0101Branch(response[0].buss_code, false);


               


                ddl0101Fund(response[0].Fund, response[0].buss_code);
                skipFundOnChange = true;

                $('#ddl0101Type').val(response[0].Type).trigger('change');
                ddl0101Department(response[0].dept_code);
                document.getElementById("ddl0101PayeeType").setAttribute("onchange", "");
                $('#ddl0101PayeeType').val(response[0].PayeeType).trigger('change');
                document.getElementById("ddl0101PayeeType").setAttribute("onchange", "ddl0101PayeeType_onchange(this)");

                ddl0101Payee(response[0].PayorCode, response[0].PayeeType);
                
                document.getElementById("tbx0101RefNo").value = response[0].RefNo;
                document.getElementById("tbx0101Remarks").value = response[0].Remarks;
                document.getElementById("tbx0101DueDate").value = response[0].DueDate;
                if (response[0].IsPickUp == "1") {
                    document.getElementById("cbx0101EditIsPickUp").checked = true;
                } else {
                    document.getElementById("cbx0101EditIsPickUp").checked = false;
                };
                if (response[0].IsDeposit == "1") {
                    document.getElementById("cbx0101EditIsDeposit").checked = true;
                } else {
                    document.getElementById("cbx0101EditIsDeposit").checked = false;
                };
                document.getElementById("tbx0101BankName").value = response[0].BankName;
                document.getElementById("tbx0101AcctName").value = response[0].AcctName;
                document.getElementById("tbx0101AcctNo").value = response[0].AcctNo;
                if (response[0].WithEWT == "1") {
                    document.getElementById("cbx0101EditWithEWT").checked = true;
                    document.getElementById("tbx0101EWT").readOnly = false;
                } else {
                    document.getElementById("cbx0101EditWithEWT").checked = false;
                    document.getElementById("tbx0101EWT").readOnly = true;
                };
                document.getElementById("tbx0101GrossAmt").value = response[0].GrossAmt;
                document.getElementById("tbx0101EWT").value = response[0].EWT;
                document.getElementById("tbx0101NetAmt").value = response[0].NetAmt;

                // If Type = Cash Advance AND Fund = SCM Fund
                if (response[0].Type === "Cash Advance" && response[0].Fund === "SCM Fund") {
                    document.getElementById("div0101EditPayment").style.display = "";
                }

                // If Type = Cash Payment AND Fund = SCM Fund
                if (response[0].Type === "Cash Payment" && response[0].Fund === "SCM Fund") {
                    document.getElementById("div0101EditPayment").style.display = "";
                    document.getElementById("div0101EditPaymentAdd").style.display = "";
                    document.getElementById("div0101Payee").style.display = "";

                    $('#ddl0101Type option[value="Cash Advance"]').remove();
                    $('#ddl0101Type option[value="Cash Liquidation"]').remove();
                }

                //content
                $('#ddl0101Type option[value="Cash Payment and Cash Liquidation"]').remove();
                $('#ddl0101Type option[value="Cash Payment Only"]').remove();
            },
        });
    }
};


function fn0101Find() {
    $.ajax({
        type: "POST",
        url: "Assets/Handler/FRM/HNDFRM000016.ashx",
        data: {
            'pFormCode': 'FRM000016',
            'pType': 'Get - Find - Record',
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

function ddl0101Branch(ID, triggerChange = true) {
    $.ajax({
        type: "POST",
        url: "Assets/Handler/FRM/HNDFRM000016.ashx",
        data: {
            'pFormCode': 'FRM000016',
            'pType': 'Get - Dropdown - List',
            'pTblName': 'Branch_List',
            'pPlaceHolder': 'Select branch',
            'pVal': '',
            'pVal2': ''
        },
        success: function (response) {
            var s = '';
            for (var i = 0; i < response.length; i++) {
                s += '<option value="' + response[i].ID + '">' + response[i].Name + '</option>';
            }
            $("#ddl0101Branch").html(s);
            if (triggerChange) {
                $('#ddl0101Branch').val(ID).trigger('change');
            } else {
                $('#ddl0101Branch').val(ID);
            }
        },
    });
 };
function ddl0101Fund(ID, pVal) {
    $.ajax({
        type: "POST",
        url: "Assets/Handler/FRM/HNDFRM000016.ashx",
        data: {
            'pFormCode': 'FRM000016',
            'pType': 'Get - Dropdown - List',
            'pTblName': 'Fund_List',
            'pPlaceHolder': 'Select fund',
            'pVal': pVal,
            'pVal2': ''
        },
        success: function (response) {
            var s = '';
            for (var i = 0; i < response.length; i++) {
                s += '<option value="' + response[i].ID + '">' + response[i].Name + '</option>';
            }
            $("#ddl0101Fund").html(s);
            $('#ddl0101Fund').val(ID).trigger('change');
        },
    });
};
function ddl0101Department(ID) {
    $.ajax({
        type: "POST",
        url: "Assets/Handler/FRM/HNDFRM000016.ashx",
        data: {
            'pFormCode': 'FRM000016',
            'pType': 'Get - Dropdown - List',
            'pTblName': 'Dept_List',
            'pPlaceHolder': 'Select department',
            'pVal': '',
            'pVal2': ''
        },
        success: function (response) {
            var s = '';
            for (var i = 0; i < response.length; i++) {
                s += '<option value="' + response[i].ID + '">' + response[i].Name + '</option>';
            }
            $("#ddl0101Department").html(s);
            $('#ddl0101Department').val(ID).trigger('change');
        },
    });
};
function ddl0101Payee(ID, pVal) {
    if (!pVal || pVal.trim() === "") {
    $("#ddl0101Payee").html('<option value="">Select payor</option>');
        $('#ddl0101Payee').val('').trigger('change');
        return;
    }
    $.ajax({
        type: "POST",
        url: "Assets/Handler/FRM/HNDFRM000016.ashx",
        data: {
            'pFormCode': 'FRM000016',
            'pType': 'Get - Dropdown - List',
            'pTblName': 'Payee_List',
            'pPlaceHolder': 'Select payor',
            'pVal': pVal,
            'pVal2': ''
        },
        success: function (response) {
            var s = '';
            for (var i = 0; i < response.length; i++) {
                s += '<option value="' + response[i].ID + '">' + response[i].Name + '</option>';
            }
            $("#ddl0101Payee").html(s);
            $('#ddl0101Payee').val(ID).trigger('change');
        }
    });
}


function ddl0101Branch_onchange(ddl0101Branch) {
    const BranchValue = ddl0101Branch.value;
    ddl0101Fund('', BranchValue,false);
};

function ddl0101Fund_onchange(ddl0101Fund) {
    if (skipFundOnChange) {
        skipFundOnChange = false; // reset for future user changes
    return;
    }

    // Your existing code below...
    document.getElementById("div0101EditPayment").style.display = "none";
    document.getElementById("div0101EditPaymentAdd").style.display = "none";
    document.getElementById("div0101Payee").style.display = "none";
    $('#ddl0101PayeeType').val('').trigger('change');
    ddl0101Payee('', '');
    const ddlType = document.getElementById("ddl0101Type");

    ddlType.innerHTML = "";
    let fund = ddl0101Fund.value.trim();

    if (fund === "SCM Fund") {
        ddlType.add(new Option("Cash Payment", "Cash Payment"));
        ddlType.value = "Cash Payment";
        document.getElementById("div0101EditPayment").style.display = "";
        document.getElementById("div0101EditPaymentAdd").style.display = "";
        document.getElementById("div0101Payee").style.display = "";
    }
    else if (fund === "") {
        ddlType.add(new Option("Select type", ""));
    }
    else {
        ddlType.add(new Option("Select type", ""));
        ddlType.add(new Option("Cash Advance", "Cash Advance"));
        ddlType.add(new Option("Cash Liquidation", "Cash Liquidation"));
        ddlType.add(new Option("Cash Payment", "Cash Payment"));
    }
    $('#ddl0101Type').trigger('change');
}


function ddl0101PayeeType_onchange(ddl0101PayeeType) {
    const PayeeValue = ddl0101PayeeType.value;
    ddl0101Payee('', ddl0101PayeeType.value);
};

function cbx0101EditIsDeposit_onchange(cbx0101EditIsDeposit) {
    document.getElementById("tbx0101BankName").value = "-";
    document.getElementById("tbx0101AcctName").value = "-";
    document.getElementById("tbx0101AcctNo").value = "-";

    if (cbx0101EditIsDeposit.checked == true) {
        document.getElementById("tbx0101BankName").readOnly = false;
        document.getElementById("tbx0101AcctName").readOnly = false;
        document.getElementById("tbx0101AcctNo").readOnly = false;
  

    } else {
        document.getElementById("tbx0101BankName").readOnly = true;
        document.getElementById("tbx0101AcctName").readOnly = true;
        document.getElementById("tbx0101AcctNo").readOnly = true;
    }

};
function cbx0101EditWithEWT_onchange(cbx0101EditWithEWT) {
    document.getElementById("tbx0101EWT").value = "0.00";
    if (document.getElementById('ContentPlaceHolder1_hdnMode').value == "ADD") {
        document.getElementById("tbx0101GrossAmt").value = "0.00";
        document.getElementById("tbx0101EWT").value = "0.00";
        document.getElementById("tbx0101NetAmt").value = "0.00";
    }

    if (cbx0101EditWithEWT.checked == true) {
        document.getElementById("tbx0101EWT").readOnly = false;
    } else {
        document.getElementById("tbx0101EWT").readOnly = true;
    }
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
}
//numeric formatting
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
}
function FormatEWT(ID) {
    var tbx01GrossAmt = document.getElementById("tbx0101GrossAmt");
    var tbx01NetAmt = document.getElementById("tbx0101NetAmt");
    var NumVal = document.getElementById(ID);

    var Val = parseFloat(NumVal.value);
    if (isNaN(Val)) Val = 0;

    var NewVal = Val.toFixed(2);
    var Parts = NewVal.split(".");
    var Num = Parts[0].replace(/\B(?=(\d{3})+(?!\d))/g, ",") + "." + Parts[1];

    var Gross = parseFloat(tbx01GrossAmt.value.replace(/,/g, "")) || 0;
    var NetVal = Gross - Val;

    var NetFormatted = NetVal.toFixed(2).replace(/\B(?=(\d{3})+(?!\d))/g, ",");

    tbx01NetAmt.value = Gross === 0 ? "0.00" : NetFormatted;
    NumVal.value = Num;
}
//general
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
                FRMValidateRecord(document.getElementById('ContentPlaceHolder1_hdnID').value);
            } else {
                fnAlertOnly('No active form found!', 'warning', 'btn btn-warning');
            };
        });
        function FRMValidateRecord(ID) {
            fnFRMValidateRecord("01Overview", "Delete", ID,"","", function(response) {
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
            fn01Delete('FRM000016', 'FRM000016', ID, function (response) {
                if (document.getElementById('ContentPlaceHolder1_hdnPrevID').value == "") {
                    if (window.opener && typeof window.opener.FRMUpdate === 'function') window.opener.FRMUpdate(ID);
                    document.getElementById('ContentPlaceHolder1_hdnMode').value = "DTL";
                    document.getElementById('ContentPlaceHolder1_hdnID').value = "0000000000000";
                    fnAlertOnly('Record successfully removed.', 'success', 'btn btn-success');
                    fn01Load();

                } else if (document.getElementById('ContentPlaceHolder1_hdnPrevID').value == ID) {
                    //window.opener && typeof window.opener.FRMUpdate === 'function' ? window.opener.FRMUpdate(ID) : window.open("FRM000016");
                    if (window.opener && typeof window.opener.FRMUpdate === 'function') window.opener.FRMUpdate(ID);
                    document.getElementById('ContentPlaceHolder1_hdnMode').value = "DTL";
                    document.getElementById('ContentPlaceHolder1_hdnID').value = "0000000000000";
                    fnAlertOnly('Record successfully removed.', 'success', 'btn btn-success');
                    fn01Load();

                } else if (document.getElementById('ContentPlaceHolder1_hdnPrevID').value != ID) {
                    document.getElementById('ContentPlaceHolder1_hdnMode').value = "DTL";
                    document.getElementById('ContentPlaceHolder1_hdnID').value = document.getElementById('ContentPlaceHolder1_hdnPrevID').value;
                    document.getElementById('ContentPlaceHolder1_hdnPrevID').value = document.getElementById('ContentPlaceHolder1_hdnPrevID').value;
                    fnAlertOnly('Record successfully removed.', 'success', 'btn btn-success');
                    fn01Load();

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
                document.getElementById('ContentPlaceHolder1_hdnMode').value = "DTL"
                document.getElementById('ContentPlaceHolder1_hdnID').value = ID
                document.getElementById('ContentPlaceHolder1_hdnPrevID').value = ID
                fn0101LoadOverview(document.getElementById('ContentPlaceHolder1_hdnMode').value, document.getElementById('ContentPlaceHolder1_hdnID').value);
            }
        });
    };
};
function fn0101Edit() {
    //validate
    if (document.getElementById('ContentPlaceHolder1_hdnMode').value == "ADD") {
        fnFRMValidateRecord("01Overview", "Save (Reference)", "", document.getElementById("ddl0101Type").options[document.getElementById("ddl0101Type").selectedIndex].value, document.getElementById("tbx0101RefNo").value, function (response) {
                if (response[0].Msg === "") {
                    ValidateFields("");
                } else {
                    fnAlertOnly(response[0].Msg, 'error', 'btn btn-danger');
                };
            });

     
    } else if (document.getElementById('ContentPlaceHolder1_hdnMode').value == "DTL") {
    //if exisit
        fnIfExist('oop_form_hdr', 'f_code', document.getElementById('ContentPlaceHolder1_hdnID').value, function (response) {
            if (response[0].oReturn == "1") {
                FRMValidateRecord(document.getElementById('ContentPlaceHolder1_hdnID').value);
            } else {
                fnAlertOnly('No active form found!', 'warning', 'btn btn-warning');
            };
        });
        function FRMValidateRecord(ID) {
            fnFRMValidateRecord("01Overview", "Save", ID,"","", function(response) {
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
                FRMValidateRecord(document.getElementById('ContentPlaceHolder1_hdnID').value);
            } else {
                fnAlertOnly('No active form found!', 'warning', 'btn btn-warning');
            };
        });

        function FRMValidateRecord(ID) {
            fnFRMValidateRecord("01Overview", "Save (UPD)", ID, document.getElementById("ddl0101Type").options[document.getElementById("ddl0101Type").selectedIndex].value, document.getElementById("tbx0101RefNo").value, function (response) {
                if (response[0].Msg === "") {
                    ValidateFields(ID);
                } else {
                    fnAlertOnly(response[0].Msg, 'error', 'btn btn-danger');
                };
            });

        }

    }
    //validate fields
    function ValidateFields(ID) {
        if (document.getElementById("tbx0101DateRequired").value == "") {
            fnAlertOnly('Some field(s) are missing!', 'error', 'btn btn-danger');
        } else if (document.getElementById("tbx0101FormType").value == "") {
            fnAlertOnly('Some field(s) are missing!', 'error', 'btn btn-danger');
        } else if (document.getElementById("ddl0101Branch").options[document.getElementById("ddl0101Branch").selectedIndex].value == "") {
            fnAlertOnly('Some field(s) are missing!', 'error', 'btn btn-danger');
        } else if (document.getElementById("ddl0101Fund").options[document.getElementById("ddl0101Fund").selectedIndex].value == "") {
            fnAlertOnly('Some field(s) are missing!', 'error', 'btn btn-danger');
        } else if (document.getElementById("ddl0101Type").options[document.getElementById("ddl0101Type").selectedIndex].value == "") {
            fnAlertOnly('Some field(s) are missing!', 'error', 'btn btn-danger');
        } else if (document.getElementById("ddl0101Department").options[document.getElementById("ddl0101Department").selectedIndex].value == "") {
            fnAlertOnly('Some field(s) are missing!', 'error', 'btn btn-danger');
        } else if (document.getElementById("tbx0101RefNo").value == "") {
            fnAlertOnly('Some field(s) are missing!', 'error', 'btn btn-danger');
        } else if (document.getElementById("tbx0101Remarks").value == "") {
            fnAlertOnly('Some field(s) are missing!', 'error', 'btn btn-danger');
        } else if (document.getElementById("ddl0101Type").options[document.getElementById("ddl0101Type").selectedIndex].value === "Cash Payment" && document.getElementById("ddl0101Fund").options[document.getElementById("ddl0101Fund").selectedIndex].value === "SCM Fund" && document.getElementById("tbx0101DueDate").value === "" ) {
            fnAlertOnly('Some field(s) are missing1!', 'error', 'btn btn-danger');
        } else if (document.getElementById("ddl0101Type").options[document.getElementById("ddl0101Type").selectedIndex].value === "Cash Payment" && document.getElementById("ddl0101Fund").options[document.getElementById("ddl0101Fund").selectedIndex].value === "SCM Fund" && document.getElementById("cbx0101EditIsDeposit").checked === true && (document.getElementById("tbx0101BankName").value === "" || document.getElementById("tbx0101AcctName").value === "" || document.getElementById("tbx0101AcctNo").value === "") ) {
            fnAlertOnly('Some field(s) are missing2!', 'error', 'btn btn-danger');
        } else if (document.getElementById("ddl0101Type").options[document.getElementById("ddl0101Type").selectedIndex].value === "Cash Payment" && document.getElementById("ddl0101Fund").options[document.getElementById("ddl0101Fund").selectedIndex].value === "SCM Fund" && document.getElementById("cbx0101EditWithEWT").checked === true && document.getElementById("tbx0101EWT").value === "") {
            fnAlertOnly('Some field(s) are missing3!', 'error', 'btn btn-danger');
        } else if (document.getElementById("ddl0101Fund").options[document.getElementById("ddl0101Fund").selectedIndex].value === "SCM Fund" && (document.getElementById("ddl0101Payee").options[document.getElementById("ddl0101Payee").selectedIndex].value === "" || document.getElementById("ddl0101PayeeType").options[document.getElementById("ddl0101PayeeType").selectedIndex].value === "" )) {
            fnAlertOnly('Some field(s) are missing4!', 'error', 'btn btn-danger');
        }
        else {
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
            url: "Assets/Handler/FRM/HNDFRM000016.ashx",
            data: {
                'pFormCode': 'FRM000016',
                'pType': 'Add - Record',
                'pDateRequired': document.getElementById("tbx0101DateRequired").value,
                'pPCType': document.getElementById("ddl0101Type").options[document.getElementById("ddl0101Type").selectedIndex].value,
                'pFund': document.getElementById("ddl0101Fund").options[document.getElementById("ddl0101Fund").selectedIndex].value,
                'pBrnchCode': document.getElementById("ddl0101Branch").options[document.getElementById("ddl0101Branch").selectedIndex].value,
                'pDeptCode': document.getElementById("ddl0101Department").options[document.getElementById("ddl0101Department").selectedIndex].value,
                'pPayeeType': document.getElementById("ddl0101PayeeType").options[document.getElementById("ddl0101PayeeType").selectedIndex].value,
                'pPayor': document.getElementById("ddl0101Payee").options[document.getElementById("ddl0101Payee").selectedIndex].value,
                'pRefNo': document.getElementById("tbx0101RefNo").value,
                'pRemarks': document.getElementById("tbx0101Remarks").value,
                'pDueDate': document.getElementById("tbx0101DueDate").value,
                'pIsPIckUp': document.getElementById("cbx0101EditIsPickUp").checked == true ? 1 : 0,
                'pIsDeposit': document.getElementById("cbx0101EditIsDeposit").checked == true ? 1 : 0,
                'pBankName': document.getElementById("tbx0101BankName").value,
                'pAcctName': document.getElementById("tbx0101AcctName").value,
                'pAcctNo': document.getElementById("tbx0101AcctNo").value,
                'pWithEWT': document.getElementById("cbx0101EditWithEWT").checked == true ? 1 : 0,
                'pGrossAmt': document.getElementById("tbx0101GrossAmt").value,
                'pEWT': document.getElementById("tbx0101EWT").value,
                'pNetAmt': document.getElementById("tbx0101NetAmt").value
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
        document.getElementById('ContentPlaceHolder1_hdnID').value = ID
        document.getElementById('ContentPlaceHolder1_hdnPrevID').value = ID
        fn01Load();
    };
    function Edit_Upd_Ok_Await(ID) {
        $.ajax({
            type: "POST",
            url: "Assets/Handler/FRM/HNDFRM000016.ashx",
            data: {
                'pFormCode': 'FRM000016',
                'pType': 'Upd - Record',
                'pID': ID,
                'pDateRequired': document.getElementById("tbx0101DateRequired").value,
                'pPCType': document.getElementById("ddl0101Type").options[document.getElementById("ddl0101Type").selectedIndex].value,
                'pFund': document.getElementById("ddl0101Fund").options[document.getElementById("ddl0101Fund").selectedIndex].value,
                'pBrnchCode': document.getElementById("ddl0101Branch").options[document.getElementById("ddl0101Branch").selectedIndex].value,
                'pDeptCode': document.getElementById("ddl0101Department").options[document.getElementById("ddl0101Department").selectedIndex].value,
                'pPayeeType': document.getElementById("ddl0101PayeeType").options[document.getElementById("ddl0101PayeeType").selectedIndex].value,
                'pPayor': document.getElementById("ddl0101Payee").options[document.getElementById("ddl0101Payee").selectedIndex].value,
                'pRefNo': document.getElementById("tbx0101RefNo").value,
                'pRemarks': document.getElementById("tbx0101Remarks").value,
                'pDueDate': document.getElementById("tbx0101DueDate").value,
                'pIsPIckUp': document.getElementById("cbx0101EditIsPickUp").checked == true ? 1 : 0,
                'pIsDeposit': document.getElementById("cbx0101EditIsDeposit").checked == true ? 1 : 0,
                'pBankName': document.getElementById("tbx0101BankName").value,
                'pAcctName': document.getElementById("tbx0101AcctName").value,
                'pAcctNo': document.getElementById("tbx0101AcctNo").value,
                'pWithEWT': document.getElementById("cbx0101EditWithEWT").checked == true ? 1 : 0,
                'pGrossAmt': document.getElementById("tbx0101GrossAmt").value,
                'pEWT': document.getElementById("tbx0101EWT").value,
                'pNetAmt': document.getElementById("tbx0101NetAmt").value
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

function fn0101Print() {
    fnIfExist('oop_form_hdr', 'f_code', document.getElementById('ContentPlaceHolder1_hdnID').value, function (response) {
        if (response[0].oReturn == "1") {
            Print();
        } else {
            fnAlertOnly('No active form found!', 'warning', 'btn btn-warning');
        };
    });
    function Print() {
        $.ajax({
            type: "POST",
            url: "Assets/Handler/FRM/HNDFRM000016.ashx",
            data: {
                'pFormCode': 'FRM000016',
                'pType': 'FRM000016 RPT',
                'pID': document.getElementById("ContentPlaceHolder1_hdnID").value,
                'plblFund': document.getElementById("lbl0101Fund").innerText,
                'plblType': document.getElementById("lbl0101Type").innerText,
                'pBranch': document.getElementById("lbl0101Branch").innerText
            },
            success: function (response) {
                if (response.status === "success") {
                    window.open(response.viewUrl, '_blank');
                } else {
                    fnAlertOnly('Error generating report.', 'error', 'btn btn-danger');
                };
            }
        });
    }
   
}
function ddl0103ChangeStatus(ID) {
    $.ajax({
        type: "POST",
        url: "Assets/Handler/FRM/HNDFRM000016.ashx",
        data: {
            'pFormCode': 'FRM000016',
            'pType': 'Get - Dropdown - List',
            'pTblName': 'Change_Status',
            'pPlaceHolder': '',
            'pVal': document.getElementById("ContentPlaceHolder1_hdnID").value,
            'pVal2': ''
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
function ddl0103Clarifyto(ID) {
    $.ajax({
        type: "POST",
        url: "Assets/Handler/FRM/HNDFRM000016.ashx",
        data: {
            'pFormCode': 'FRM000016',
            'pType': 'Get - Dropdown - List',
            'pTblName': 'Clarify_To',
            'pPlaceHolder': '',
            'pVal': document.getElementById("ContentPlaceHolder1_hdnID").value,
            'pVal2': ''
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
function fn0101ChangeStatus() {
    fnIfExist('oop_form_hdr', 'f_code', document.getElementById('ContentPlaceHolder1_hdnID').value, function (response) {
        if (response[0].oReturn == "1") {
            FRMValidateRecord(document.getElementById('ContentPlaceHolder1_hdnID').value);
        } else {
            fnAlertOnly('No active form found!', 'warning', 'btn btn-warning');
        };
    });
    function FRMValidateRecord(ID) {
        fnFRMValidateRecord("01Overview", "Status", ID, "","", function (response) {
            if (response[0].Msg === "") {
                ddl0103ChangeStatus('');
                ddl0103Clarifyto('');
                $('#mdl0103Status').modal('show');
            } else {
                fnAlertOnly(response[0].Msg, 'error', 'btn btn-danger');
            };
        });

    }
   
}
function ddl0103ChangeStatus_onchange(ddl0103ChangeStatus) {

    document.getElementById("pnl01ClarifyTo").style.display = "none";
    const ddlStatus = ddl0103ChangeStatus.value;


    if (ddlStatus === "Clarify") {
        document.getElementById("pnl01ClarifyTo").style.display = "";
    }
    if (ddlStatus === "Declined") {
        document.getElementById("spn01Note").classList.add("required");
    } else {
        document.getElementById("spn01Note").classList.remove("required");
    }
}
function fn0101SaveChangeStatus() {
    fnIfExist('oop_form_hdr', 'f_code', document.getElementById('ContentPlaceHolder1_hdnID').value, function (response) {
        if (response[0].oReturn == "1") {
            FRMValidateRecord(document.getElementById('ContentPlaceHolder1_hdnID').value);
        } else {
            fnAlertOnly('No active form found!', 'warning', 'btn btn-warning');
        };
    });
    function FRMValidateRecord(ID) {
        fnFRMValidateRecord("01Overview", "Status", ID, document.getElementById("ddl0103ChangeStatus").options[document.getElementById("ddl0103ChangeStatus").selectedIndex].value,"", function (response) {
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
        } else if (document.getElementById("ddl0103ChangeStatus").options[document.getElementById("ddl0103ChangeStatus").selectedIndex].value === "Declined" && document.getElementById("tbx0103Note").value === ""){
            fnAlertOnly('Some field(s) are missing!', 'error', 'btn btn-danger');
        } 
        else {
            SaveChange_Ok(ID);
        }
    }
    function SaveChange_Ok(ID) {
        $.ajax({
            type: "POST",
            url: "Assets/Handler/FRM/HNDFRM000016.ashx",
            data: {
                'pFormCode': 'FRM000016',
                'pType': 'Change Status',
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
//movement
function fn0102LoadMovement(pMode, pID) {
    $.ajax({
        type: "POST",
        url: "Assets/Handler/FRM/HNDFRM000016.ashx",
        data: {
            'pFormCode': 'FRM000016',
            'pType': 'Get Record - DTL - Movement',
            'pID': pID,
        },
        success: function (response) {
            //display loader
            document.getElementById("div0102LoaderMovement").style.display = "";
            //display loader

            $('#table0102Movement').DataTable().destroy();

            //disable column type detection
            DataTable.types().forEach(type => {
                DataTable.type(type, 'detect', () => false);
            });
            //disable column type detection

            //sort date by yyyy/mm/dd
            $.fn.dataTable.moment('MM/DD/YYYY');
            //sort date by yyyy/mm/dd

            //datatable
            var table0102Movement = $("#table0102Movement").DataTable({
                scrollY: "62.5vh",
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
                    { data: 'Item' },
                    { data: 'Qty' },
                    { data: 'Unit' },
                    { data: 'Amount' },
                    { data: 'Division' },
                    { data: 'Expense' },
                    { data: 'Subsidiary' },
                    { data: 'Code' }],
                rowId: 'rowId',
                columnDefs: [{ targets: 0, orderable: false }, { targets: 1, orderable: false, className: 'tbody-nowrap-auto' }, { targets: 2, orderable: false, className: 'tbody-nowrap-auto' }, { targets: 3, orderable: false, className: 'tbody-nowrap-auto' }, { targets: 4, orderable: false, className: 'tbody-nowrap-auto dt-body-right', render: $.fn.dataTable.render.number(',', '.', 2) }, { targets: 5, orderable: false, className: 'tbody-nowrap-auto' }, { targets: 6, orderable: false, className: 'tbody-nowrap-auto' }, { targets: 7, orderable: false, className: 'tbody-nowrap-auto' }, { targets: 8, orderable: false, className: 'tbody-nowrap-auto' }],
                footerCallback: function (row, data, start, end, display) {
                    var api = this.api();
                    // Calculate the total
                    var totalValue = api.column(4).data().reduce(function (a, b) {
                        return a + b; // Sum the values
                    }, 0);

                    // Update the footer with the total value
                    var totalVal = totalValue.toLocaleString("en-US", { minimumFractionDigits: 2, maximumFractionDigits: 2 });
                    $(api.column(4).footer()).html(totalVal);

           
                },
                ordering: false

            });
            //datatable

            //search
            $('#tbx0102FindMovement').on('keyup', function () {
                table0102Movement.search(this.value).draw();
            });
            //search

            //hide loader
            document.getElementById("div0102LoaderMovement").style.display = "none";
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
function ddl0102CLDivision(ID) {
    $.ajax({
        type: "POST",
        url: "Assets/Handler/FRM/HNDFRM000016.ashx",
        data: {
            'pFormCode': 'FRM000016',
            'pType': 'Get - Dropdown - List',
            'pTblName': 'Division_List',
            'pPlaceHolder': 'Select division',
            'pVal': '',
            'pVal2': ''
        },
        success: function (response) {
            var s = '';
            for (var i = 0; i < response.length; i++) {
                s += '<option value="' + response[i].ID + '">' + response[i].Name + '</option>';
            }
            $("#ddl0102CLDivision").html(s);
            $('#ddl0102CLDivision').val(ID).trigger('change');
        },
    });
};
function ddl0102CLExpense(ID, pVal, pVal2) {
    $.ajax({
        type: "POST",
        url: "Assets/Handler/FRM/HNDFRM000016.ashx",
        data: {
            'pFormCode': 'FRM000016',
            'pType': 'Get - Dropdown - List',
            'pTblName': 'Expense_List',
            'pPlaceHolder': 'Select expense',
            'pVal': pVal,
            'pVal2': pVal2
        },
        success: function (response) {
            var s = '';
            for (var i = 0; i < response.length; i++) {
                s += '<option value="' + response[i].ID + '">' + response[i].Name + '</option>';
            }
            $("#ddl0102CLExpense").html(s);
            $('#ddl0102CLExpense').val(ID).trigger('change');
        },
    });
};
function fnGetValue(pExpense, callBack) {
    $.ajax({
        type: "POST",
        url: "Assets/Handler/FRM/HNDFRM000016.ashx",
        data: {
            'pFormCode': 'FRM000016',
            'pType': 'Get - Description',
            'pExpense': pExpense
        },
        success: function (response) {
            callBack(response);
        },
    });
};

function ddl0102CLDescription(ID, pVal) {
    $.ajax({
        type: "POST",
        url: "Assets/Handler/FRM/HNDFRM000016.ashx",
        data: {
            'pFormCode': 'FRM000016',
            'pType': 'Get - Dropdown - List',
            'pTblName': 'Description_List',
            'pPlaceHolder': 'Select description',
            'pVal': pVal,
            'pVal2': ''
        },
        success: function (response) {
            var s = '';
            for (var i = 0; i < response.length; i++) {
                s += '<option value="' + response[i].ID + '">' + response[i].Name + '</option>';
            }
            $("#ddl0102CLSubsidiary").html(s);
            $('#ddl0102CLSubsidiary').val(ID).trigger('change');

        },
    });
};

function ddl0102CLExpense_onchange(ddl0102CLExpense) {
    if (skipExpenseOnChange) {
        skipExpenseOnChange = false;
        return;
    }

    const expense = ddl0102CLExpense.value;
   
    
    if (expense !== "") {
        fnGetValue(expense, function (response) {
            document.getElementById("hdnCLSub").value = response[0].subsidiary;
            ddl0102CLDescription('', expense);
        });
    } else {
        ddl0102CLDescription('', '');
        document.getElementById("hdnCLSub").value = "";
    }

}
function updToDTL() {
    document.getElementById('ContentPlaceHolder1_hdnMode').value = 'DTL';
};
function fn0102LoadMovementModal(pMode, pSeqNo, pID) {

    if (pMode == "ADD") {
        document.getElementById("spn0102parTitle").innerText = "Add Particular";
        document.getElementById("tbx0102Particular").value = "";
        document.getElementById("tbx0102Qty").value = "0.00";
        document.getElementById("tbx0102Unit").value = "";
        document.getElementById("tbx0102Amount").value = "0.00";
        document.getElementById("divPaymentOnly").style.display = "none";
        document.getElementById("divPaymentLiquidation").style.display = "none";
        document.getElementById("divPaymentDtlAddCA").style.display = "none";
        document.getElementById("tbx0102CADivision").value = "-";
        document.getElementById("tbx0102CAExpense").value = "-";
        document.getElementById("tbx0102CASubsidiary").value = "-";
        document.getElementById("tbx0102CASubsidiarycode").value = "-";
        document.getElementById("hdnCLSub").value = "-";
        document.getElementById("divPaymentDtlAddCL").style.display = "none";
        ddl0102CLExpense('', document.getElementById("lbl0101Fund").innerText, document.getElementById('ContentPlaceHolder1_hdnID').value);
        ddl0102CLDivision('');
        ddl0102CLDescription('', '')
        if (document.getElementById("lbl0101Type").innerText === "Cash Advance") {
            document.getElementById("divPaymentDtlAddCA").style.display = "";
      
        }
        skipExpenseOnChange = true;
        if (document.getElementById("lbl0101Type").innerText === "Cash Payment") {
            document.getElementById("divPaymentDtlAddCL").style.display = "";
            document.getElementById("divPaymentOnly").style.display = "";
            document.getElementById("divPaymentLiquidation").style.display = "none";
        }
        if (document.getElementById("lbl0101Type").innerText === "Cash Liquidation") {
            document.getElementById("divPaymentDtlAddCL").style.display = "";
            document.getElementById("divPaymentOnly").style.display = "none";
            document.getElementById("divPaymentLiquidation").style.display = "";
        }


    } else if (pMode == "UPD") {
        $.ajax({
            type: "POST",
            url: "Assets/Handler/FRM/HNDFRM000016.ashx",
            data: {
                'pFormCode': 'FRM000016',
                'pType': 'Get Record - DTL - Movement - Modal',
                'pID': pID,
                'pSeqNo': pSeqNo
            },
            success: function (response) {
                document.getElementById("spn0102parTitle").innerText = "Edit Particular";
                document.getElementById("tbx0102Particular").value = response[0].Item;
                document.getElementById("tbx0102Qty").value = response[0].Qty;
                document.getElementById("tbx0102Unit").value = response[0].Unit;
                document.getElementById("tbx0102Amount").value = response[0].Amount;
                document.getElementById("divPaymentOnly").style.display = "none";
                document.getElementById("divPaymentLiquidation").style.display = "none";
                document.getElementById("divPaymentDtlAddCA").style.display = "none";
                document.getElementById("divPaymentDtlAddCL").style.display = "none";
                ddl0102CLExpense(response[0].Expense, document.getElementById("lbl0101Fund").innerText, document.getElementById('ContentPlaceHolder1_hdnID').value);
                ddl0102CLDivision(response[0].Division);
                skipExpenseOnChange = true;
                ddl0102CLDescription(response[0].Code, response[0].Expense);

                document.getElementById("hdnCLSub").value = response[0].Subsidiary;
                if (document.getElementById("lbl0101Type").innerText === "Cash Advance") {
                    document.getElementById("divPaymentDtlAddCA").style.display = "";

                }

                if (document.getElementById("lbl0101Type").innerText === "Cash Payment") {
                    document.getElementById("divPaymentDtlAddCL").style.display = "";
                    document.getElementById("divPaymentOnly").style.display = "";
                    document.getElementById("divPaymentLiquidation").style.display = "none";
                }
                if (document.getElementById("lbl0101Type").innerText === "Cash Liquidation") {
                    document.getElementById("divPaymentDtlAddCL").style.display = "";
                    document.getElementById("divPaymentOnly").style.display = "none";
                    document.getElementById("divPaymentLiquidation").style.display = "";
                }


            },
        });
    }
          
};

function fn0102Add() {
    fnIfExist('oop_form_hdr', 'f_code', document.getElementById('ContentPlaceHolder1_hdnID').value, function (response) {
        if (response[0].oReturn == "1") {
            FRMValidateRecord();
        } else {
            fnAlertOnly('No active form found!', 'warning', 'btn btn-warning');
        };
    });
     function FRMValidateRecord() {
         fnFRMValidateRecord("06PCDtl", "Add", document.getElementById('ContentPlaceHolder1_hdnID').value, "","", function (response) {
            if (response[0].Msg === "") {
                document.getElementById("ContentPlaceHolder1_hdnMode").value = "ADD";
                fn0102LoadMovementModal(document.getElementById('ContentPlaceHolder1_hdnMode').value, '', document.getElementById('ContentPlaceHolder1_hdnID').value);
                $('#mdl0102Add').modal('show');
            } else {
                fnAlertOnly(response[0].Msg, 'error', 'btn btn-danger');
            };
        });
    }
};
function fn0102Edit(pSeqNo,pID) {
    fnIfExist('oop_form_hdr', 'f_code', pID, function (response) {
        if (response[0].oReturn == "1") {
            FRMValidateRecord(pSeqNo, pID);
        } else {
            fnAlertOnly('No active form found!', 'warning', 'btn btn-warning');
        };
    });
    function FRMValidateRecord(pSeqNo, pID) {
        fnFRMValidateRecord("06PCDtl", "Save", pID, "","", function (response) {
            if (response[0].Msg === "") {
                Edit(pSeqNo);
            } else {
                fnAlertOnly(response[0].Msg, 'error', 'btn btn-danger');
            };
        });

    }
    function Edit(pSeqNo) {
        document.getElementById("ContentPlaceHolder1_hdnMode").value = "UPD";
        document.getElementById("ContentPlaceHolder1_hdnSeqNo").value = pSeqNo;
        fn0102LoadMovementModal(document.getElementById('ContentPlaceHolder1_hdnMode').value, pSeqNo, document.getElementById('ContentPlaceHolder1_hdnID').value);
        $('#mdl0102Add').modal('show');
    };
};
function fn0102Edit_OK(Btn) {

    //validate
    if (document.getElementById('ContentPlaceHolder1_hdnMode').value == "ADD") {
        fnIfExist('oop_form_hdr', 'f_code', document.getElementById('ContentPlaceHolder1_hdnID').value, function (response) {
            if (response[0].oReturn == "1") {
                FRMValidateRecord(document.getElementById('ContentPlaceHolder1_hdnID').value);
            } else {
                fnAlertOnly('No active form found!', 'warning', 'btn btn-warning');
            };
        });

        function FRMValidateRecord(pID) {
            fnFRMValidateRecord("06PCDtl", "Add", pID, "","", function (response) {
                if (response[0].Msg === "") {
                    ValidateFields(pID);
                } else {
                    fnAlertOnly(response[0].Msg, 'error', 'btn btn-danger');
                };
            });

        }

    } else if (document.getElementById('ContentPlaceHolder1_hdnMode').value == "UPD") {
    //if exisit
        fnIfExist('oop_form_hdr', 'f_code', document.getElementById('ContentPlaceHolder1_hdnID').value, function (response) {
            if (response[0].oReturn == "1") {
                FRMValidateRecord(document.getElementById('ContentPlaceHolder1_hdnID').value);
            } else {
                fnAlertOnly('No active form found!', 'warning', 'btn btn-warning');
            };
        });
        function FRMValidateRecord(pID) {
            fnFRMValidateRecord("06PCDtl", "Save", pID, "","", function (response) {
                if (response[0].Msg === "") {
                    ValidateFields(pID);
                } else {
                    fnAlertOnly(response[0].Msg, 'error', 'btn btn-danger');
                };
            });

        }
    }
    //validate fields
    function ValidateFields(ID) {
        if (document.getElementById("tbx0102Particular").value == "") {
            fnAlertOnly('Some field(s) are missing!', 'error', 'btn btn-danger');
        } else if (document.getElementById("tbx0102Qty").value <= 0 || "") {
            fnAlertOnly('Some field(s) are missing!', 'error', 'btn btn-danger');
        } else if (document.getElementById("tbx0102Unit").value == "") {
            fnAlertOnly('Some field(s) are missing!', 'error', 'btn btn-danger');
        } else if (document.getElementById("tbx0102Amount").value <= 0 || "") {
            fnAlertOnly('Some field(s) are missing!', 'error', 'btn btn-danger');
        } else if (document.getElementById("lbl0101Type").innerText === "Cash Liquidation" && document.getElementById("ddl0102CLDivision").options[document.getElementById("ddl0102CLDivision").selectedIndex].value === "") {
            fnAlertOnly('Some field(s) are missing!', 'error', 'btn btn-danger');
        } else if (document.getElementById("lbl0101Type").innerText === "Cash Liquidation" && document.getElementById("ddl0102CLExpense").options[document.getElementById("ddl0102CLExpense").selectedIndex].value === "") {
            fnAlertOnly('Some field(s) are missing!', 'error', 'btn btn-danger');
        } else if (document.getElementById("lbl0101Type").innerText === "Cash Liquidation" && document.getElementById("hdnCLSub").value == "") {
            fnAlertOnly('Some field(s) are missing!', 'error', 'btn btn-danger');
        } else if (document.getElementById("lbl0101Type").innerText === "Cash Liquidation" && document.getElementById("hdnCLSub").value === "MISCELLANEOUS" && document.getElementById("ddl0102CLSubsidiary").options[document.getElementById("ddl0102CLSubsidiary").selectedIndex].value === "") {
            fnAlertOnly('Some field(s) are missing!', 'error', 'btn btn-danger');
        } else if (document.getElementById("lbl0101Type").innerText === "Cash Liquidation" && document.getElementById("hdnCLSub").value === "MODEL HOUSE" && document.getElementById("ddl0102CLSubsidiary").options[document.getElementById("ddl0102CLSubsidiary").selectedIndex].value === "") {
            fnAlertOnly('Some field(s) are missing!', 'error', 'btn btn-danger');
        } else if (document.getElementById("lbl0101Type").innerText === "Cash Liquidation" && document.getElementById("hdnCLSub").value === "PHASE" && document.getElementById("ddl0102CLSubsidiary").options[document.getElementById("ddl0102CLSubsidiary").selectedIndex].value === "") {
            fnAlertOnly('Some field(s) are missing!', 'error', 'btn btn-danger');
        } else if (document.getElementById("lbl0101Type").innerText === "Cash Liquidation" && document.getElementById("hdnCLSub").value === "SUBDIVISION" && document.getElementById("ddl0102CLSubsidiary").options[document.getElementById("ddl0102CLSubsidiary").selectedIndex].value === "") {
            fnAlertOnly('Some field(s) are missing!', 'error', 'btn btn-danger');
        } 
        else {
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
                    fnIfExist('oop_form_hdr', 'f_code', document.getElementById('ContentPlaceHolder1_hdnID').value, function (response) {
                        if (response[0].oReturn == "1") {
                            Edit_Add_Ok_Await(ID);
                        } else {
                            fnAlertOnly('No active form found!', 'warning', 'btn btn-warning');
                        };
                    });

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

    //do edit
    function Edit_Add_Ok_Await(ID) {
        Btn.disabled = true;
        // Show loading indicator
        Btn.setAttribute('data-kt-indicator', 'on');

        $.ajax({
            type: "POST",
            url: "Assets/Handler/FRM/HNDFRM000016.ashx",
            data: {
                'pFormCode': 'FRM000016',
                'pType': 'Add - Record DTL',
                'pID': ID,
                'pItem': document.getElementById("tbx0102Particular").value,
                'pQty': document.getElementById("tbx0102Qty").value,
                'pUnit': document.getElementById("tbx0102Unit").value,
                'pAmount': document.getElementById("tbx0102Amount").value,
                'pPType': document.getElementById("lbl0101Type").innerText,
                'pdivision':  document.getElementById("ddl0102CLDivision").options[document.getElementById("ddl0102CLDivision").selectedIndex].value ,
                'pExpense': document.getElementById("ddl0102CLExpense").options[document.getElementById("ddl0102CLExpense").selectedIndex].value,
                'psubsidiary': document.getElementById("ddl0102CLSubsidiary").options[document.getElementById("ddl0102CLSubsidiary").selectedIndex].value,
                'pCLSub': document.getElementById("hdnCLSub").value,
                'pEWT': document.getElementById("lbl0101EWT").innerText
            },
            success: function (response) {
                fnAlertOnly('Record successfully saved.', 'success', 'btn btn-success');
                fn0102LoadMovement("DTL", document.getElementById('ContentPlaceHolder1_hdnID').value);
                fn0102LoadMovementModal("ADD", "", ID)
                fn0101LoadOverview("DTL", document.getElementById('ContentPlaceHolder1_hdnID').value);
                fn0601LoadHistory(document.getElementById('ContentPlaceHolder1_hdnID').value);
                Btn.disabled = false;
                Btn.removeAttribute('data-kt-indicator');
             
            },
        });
    };
    function Edit_Upd_Ok_Await(ID) {
        // Do Billing
            
        $.ajax({
            type: "POST",
            url: "Assets/Handler/FRM/HNDFRM000016.ashx",
            data: {
                'pFormCode': 'FRM000016',
                'pType': 'Upd - Record DTL',
                'pSeqno': document.getElementById("ContentPlaceHolder1_hdnSeqNo").value,
                'pID': document.getElementById('ContentPlaceHolder1_hdnID').value,
                'pItem': document.getElementById("tbx0102Particular").value,
                'pQty': document.getElementById("tbx0102Qty").value,
                'pUnit': document.getElementById("tbx0102Unit").value,
                'pAmount': document.getElementById("tbx0102Amount").value,
                'pPType': document.getElementById("lbl0101Type").innerText,
                'pdivision': document.getElementById("ddl0102CLDivision").options[document.getElementById("ddl0102CLDivision").selectedIndex].value,
                'pExpense': document.getElementById("ddl0102CLExpense").options[document.getElementById("ddl0102CLExpense").selectedIndex].value,
                'psubsidiary': document.getElementById("ddl0102CLSubsidiary").options[document.getElementById("ddl0102CLSubsidiary").selectedIndex].value,
                'pCLSub': document.getElementById("hdnCLSub").value,
                'pEWT': document.getElementById("lbl0101EWT").value
            },
            success: function (response) {
                fnAlertOnly('Record successfully saved.', 'success', 'btn btn-success');
                document.getElementById('ContentPlaceHolder1_hdnMode').value = "DTL"
                fn0102LoadMovement(document.getElementById('ContentPlaceHolder1_hdnMode').value, document.getElementById('ContentPlaceHolder1_hdnID').value);
                $('#mdl0102Add').modal('hide');
                fn0101LoadOverview("DTL", document.getElementById('ContentPlaceHolder1_hdnID').value);
                fn0601LoadHistory(document.getElementById('ContentPlaceHolder1_hdnID').value);
            },
        });
    };
};


function fn0102UploadClear() {
    // Reset file and table
    document.getElementById("excelFileInput").value = "";
    document.getElementById("ExcelTextBoxX").value = "";
    if ($.fn.DataTable.isDataTable('#table03Record')) {
        $('#table03Record').DataTable().clear().destroy();
    }
    $('#table03Record tbody').empty();
}

function fn0102Upload() {
    // Reset file and table
    document.getElementById("excelFileInput").value = "";
    document.getElementById("ExcelTextBoxX").value = "";
    fnFRMValidateRecord("06PCDtl", "Upload", document.getElementById('ContentPlaceHolder1_hdnID').value, document.getElementById("lbl0101Type").innerText, document.getElementById("lbl0101Fund").innerText, function (response) {
        if (response[0].Msg == "") {
            if ($.fn.DataTable.isDataTable('#table03Record')) {
                $('#table03Record').DataTable().clear().destroy();
            }

            $('#table03Record tbody').empty();
            $('#mdl0102UploadExcel').modal('show');
        } else {
            fnAlertOnly(response[0].Msg, 'error', 'btn btn-danger');
        };
    });

}
function showLoadingOverlay() {
    document.getElementById("loadingOverlay").classList.remove("d-none");
    $("#btnCancelModal, #btnOkModal, #btnCloseModal").prop("disabled", true);
}

function hideLoadingOverlay() {
    document.getElementById("loadingOverlay").classList.add("d-none");
    $("#btnCancelModal, #btnOkModal, #btnCloseModal").prop("disabled", false);
}
// 🔹 File input change event
document.getElementById("excelFileInput").addEventListener("change", function (e) {
    const file = e.target.files[0];
    if (!file) return;

    document.getElementById("ExcelTextBoxX").value = file.name;
    showLoadingOverlay();

    const reader = new FileReader();

    reader.onload = async function (e) {
        try {
            const data = new Uint8Array(e.target.result);
            const workbook = XLSX.read(data, { type: "array" });
            const sheet = workbook.Sheets[workbook.SheetNames[0]];
            if (!sheet) {
                hideLoadingOverlay();
                fnAlertOnly("No sheet found in Excel file.", "error", "btn btn-danger");
                return;
            }

            // ✅ Read Excel exactly as-is (row order preserved)
            const rowsData = XLSX.utils.sheet_to_json(sheet, {
                header: 1,
                defval: "",
                blankrows: true
            });
            if (rowsData.length <= 1) {
                hideLoadingOverlay();
                fnAlertOnly("No data found in Excel file.", "warning", "btn btn-warning");
                return;
            }
            const rows = [];
            for (let i = 1; i < rowsData.length; i++) {
                const r = rowsData[i];
                if (!r[0]) continue; // skip if Particular is empty

                const cleanNumber = (val) => {
                    if (typeof val === "number") return val;
                    if (typeof val === "string") {
                        const num = val.replace(/[^0-9.-]/g, "");
                        return parseFloat(num) || 0;
                    }
                    return 0;
                };
                const QtyNum = cleanNumber(r[1]);
                const AmtNum = cleanNumber(r[3]);

                rows.push({
                    Particular: r[0],
                    Qty: QtyNum,
                    Unit: r[2],
                    Amount: AmtNum.toLocaleString("en-US", { minimumFractionDigits: 2 }),
                    Division: r[4],
                    Expense: r[5],
                    Subsidiary: r[6],
                    Code: r[7],
                    Status: "Checking..."
                });
            }


            if (rows.length === 0) {
                hideLoadingOverlay();
                fnAlertOnly("No valid rows found in Excel file.", "warning", "btn btn-warning");
                return;
            }

            const validated = await validateRows(rows);
            showTable(validated);

        } catch (err) {
            fnAlertOnly("Error: " + err.message, "error", "btn btn-danger");
        } finally {
            hideLoadingOverlay();
        }
    };

    reader.readAsArrayBuffer(file);
});

// 🔹 Validate each row (AJAX)
async function validateRows(rows) {
  
    const validated = [];

    for (const r of rows) {
        await $.ajax({
            type: "POST",
            url: "Assets/Handler/FRM/HNDFRM000016.ashx",
            dataType: "json",
            data: {
                pFormCode: "FRM000016",
                pType: "Conf Petty Cash Entry",
                pItem: r.Particular,
                pQty: r.Qty,
                pUnit: r.Unit,
                pAmount: r.Amount.replace(/,/g, ""),
                pDivision: r.Division,
                pExpense: r.Expense,
                pSubsidiary: r.Subsidiary,
                pCode: r.Code
            },
            success: function (response) {
                const rec = response[0];
                r.Status = rec.oStatus;
                r.DivCode = rec.oDivCode;
                r.ExpCode = rec.oExpenseCode;
                r.SubCode = rec.oSubsidiary;
                r.CodeNum = rec.oCode;
                validated.push(r);
            },
            error: function () {
                r.Status = "Error";
                validated.push(r);
            }
        });
    }
    return validated;
}

// 🔹 Display table
function showTable(rows) {
    $('#table03Record').DataTable({
        scrollY: "70vh",
        scrollCollapse: true,
        fixedHeader: true,
        bDestroy: true,
        bInfo: false,
        paging: false,
        ordering: false, // ✅ Disable sorting to keep Excel order
        data: rows,
        autoWidth: false,
        columns: [
            { data: "Particular" },
            { data: "Qty" },
            { data: "Unit" },
            { data: "Amount" },
            { data: "Division" },
            { data: "Expense" },
            { data: "Subsidiary" },
            { data: "Code" },
            { data: "Status" }
        ],
        columnDefs: [
            { targets: [0, 2, 4, 5, 6, 7, 8], className: 'tbody-nowrap-auto' },
            { targets: 1, className: 'dt-body-center' },
            { targets: 3, className: 'dt-body-right' }
        ],
        createdRow: function (row, data) {
            $(row).find("td").css({
                "white-space": "nowrap",
                "vertical-align": "middle"
            });

            if (data.Status?.toLowerCase() === "invalid") {
                $(row).css("background-color", "#ffe6e6");
            } else if (data.Status?.toLowerCase() === "valid") {
                $(row).css("background-color", "#e6ffe6");
            }
        }
    });
}

async function fn0102UploadExcelSave() {

    showLoadingOverlay();

    const rows = $("#table03Record").DataTable().rows().data().toArray();

    if (rows.length === 0) {
        hideLoadingOverlay();
        fnAlertOnly("No data found!", "warning", "btn btn-warning");
        return;
    }

    const hasInvalid = rows.some(r => r.Status.toLowerCase() === "invalid");
    if (hasInvalid) {
        hideLoadingOverlay();
        fnAlertOnly("One or more records are invalid!", "warning", "btn btn-warning");
        return;
    }

    const upID = document.getElementById("ContentPlaceHolder1_hdnID").value;

    try {

        for (let i = 0; i < rows.length; i++) {

            const r = rows[i];

            const amount = parseFloat(r.Amount.replace(/,/g, "")) || 0;

            await $.ajax({
                type: "POST",
                url: "/Assets/Handler/FRM/HNDFRM000016.ashx",
                data: {
                    pFormCode: "FRM000016",
                    pType: "Add - Record DTL",
                    pPType: document.getElementById("lbl0101Type").innerText,
                    pID: upID,
                    pItem: r.Particular,
                    pQty: r.Qty,
                    pUnit: r.Unit,
                    pAmount: amount,
                    pDivision: r.DivCode || "",
                    pExpense: r.ExpCode || "",
                    pSubsidiary: r.CodeNum || "",
                    pCLSub: r.SubCode || "",
                    pEWT: 0
                }
            });

        }

        fn0102LoadMovement("DTL", upID);

        hideLoadingOverlay();

        fnAlertOnly("Record successfully saved.", "success", "btn btn-success");
        $('#mdl0102UploadExcel').modal('hide');

    }
    catch (err) {
        hideLoadingOverlay();
        fnAlertOnly("Error saving data: " + err.message, "error", "btn btn-danger");
    }
}


function fn0102Delete(pSeqNo, pID) {
    //if exisit
    fnIfExist('oop_form_hdr', 'f_code', document.getElementById('ContentPlaceHolder1_hdnID').value, function (response) {
        if (response[0].oReturn == "1") {
            FRMValidateRecord(pSeqNo, pID);
        } else {
            fnAlertOnly('No active form found!', 'warning', 'btn btn-warning');
        };
    });
    function FRMValidateRecord(pSeqNo, pID) {
        fnFRMValidateRecord("06PCDtl", "Delete", pID, "","", function (response) {
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
            url: "Assets/Handler/FRM/HNDFRM000016.ashx",
            data: {
                'pFormCode': 'FRM000016',
                'pType': 'Delete Record DTL',
                'pSeqno': pSeqNo,
                'pID': pID,
                'pEWT': document.getElementById("lbl0101EWT").innerText,
            },
            success: function (response) {
                fnAlertOnly('Particular successfully removed.', 'success', 'btn btn-success');
                fn0102LoadMovement("DTL", document.getElementById('ContentPlaceHolder1_hdnID').value);
                fn0101LoadOverview("DTL", document.getElementById('ContentPlaceHolder1_hdnID').value);
                fn0601LoadHistory(document.getElementById('ContentPlaceHolder1_hdnID').value);
            },
        });
              
    };
};
//asset


//attachment
function fn0201LoadAttachment(pMode, pID) {
    $.ajax({
        type: "POST",
        url: "HNDGEN.ashx",
        data: {
            'pFormCode': 'FRM000016',
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

//approver
function fn0401LoadApprover(pID) {
    $.ajax({
        type: "POST",
        url: "Assets/Handler/FRM/HNDFRM000016.ashx",
        data: {
            'pFormCode': 'FRM000016',
            'pType': 'Get - Record - Approver',
            'pID': pID,
        },
        success: function (response) {
            //display loader
            document.getElementById("div0401LoaderApprover").style.display = "";
            //display loader
            $('#table0401Approver').DataTable().destroy();
            DataTable.types().forEach(type => { DataTable.type(type, 'detect', () => false); });
            $.fn.dataTable.moment('MM/DD/YYYY');
            var table989Record = $("#table0401Approver").DataTable({
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
                ],
                order: [],
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
        fnFRMValidateRecord("04ApprovalPath", "Add", document.getElementById('ContentPlaceHolder1_hdnID').value, "","", function (response) {
            if (response[0].Msg === "") {
                showModal();
            } else {
                fnAlertOnly(response[0].Msg, 'error', 'btn btn-danger');
            };
        });
    }
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

    }
}
function ddl0401Approver(pfID, pType) {
    // if both are empty → show only blank option
    if ((!pfID || pfID === '') && (!pType || pType === '')) {
        $("#ddl0401Approver").html('<option value="">Select a user</option>');
        $('#ddl0401Approver').val('').trigger('change');
        return; // stop here, no ajax
    }
    $.ajax({
        type: "POST",
        url: "Assets/Handler/FRM/HNDFRM000016.ashx",
        data: {
            'pFormCode': 'FRM000016',
            'pType': 'Get - Dropdown - List',
            'pTblName': 'Approver_List',
            'pPlaceHolder': '',
            'pVal': pfID,
            'pVal2': pType
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
        url: "Assets/Handler/FRM/HNDFRM000016.ashx",
        data: {
            'pFormCode': 'FRM000016',
            'pType': 'Get - Dropdown - List',
            'pTblName': 'Template_List',
            'pPlaceHolder': 'Select a template',
            'pVal': 'FRM000016',
            'pVal2': ''
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
    const AddForm = ddl0401AddFrom.value
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
}
function ddl0401Type_onchange(ddl0401Type) {
    ddl0401Approver('FRM000016', ddl0401Type.value);
}
function fn0401AddApprover_OK(Btn) {
    fnIfExist('oop_form_hdr', 'f_code', document.getElementById('ContentPlaceHolder1_hdnID').value, function (response) {
        if (response[0].oReturn == "1") {
            FRMValidateRecord(document.getElementById('ContentPlaceHolder1_hdnID').value);
        } else {
            fnAlertOnly('No active form found!', 'warning', 'btn btn-warning');
        };
    });
    function FRMValidateRecord(ID) {
        fnFRMValidateRecord("04ApprovalPath", "Add", document.getElementById('ContentPlaceHolder1_hdnID').value, "","", function (response) {
            if (response[0].Msg === "") {
                ValidateFields(ID);
            } else {
                fnAlertOnly(response[0].Msg, 'error', 'btn btn-danger');
            };
        });
    }
    function ValidateFields(ID) {
        if (document.getElementById("ddl0401AddFrom").options[document.getElementById("ddl0401AddFrom").selectedIndex].value === "") {
            fnAlertOnly('Some field(s) are missing!', 'error', 'btn btn-danger');
        } else if (document.getElementById("ddl0401AddFrom").options[document.getElementById("ddl0401AddFrom").selectedIndex].value === "Manual" && document.getElementById("ddl0401Type").options[document.getElementById("ddl0401Type").selectedIndex].value === "") {
            fnAlertOnly('Some field(s) are missing!', 'error', 'btn btn-danger');
        } else if (document.getElementById("ddl0401AddFrom").options[document.getElementById("ddl0401AddFrom").selectedIndex].value === "Manual" && document.getElementById("ddl0401Approver").options[document.getElementById("ddl0401Approver").selectedIndex].value === "") {
            fnAlertOnly('Some field(s) are missing!', 'error', 'btn btn-danger');
        } else if (document.getElementById("ddl0401AddFrom").options[document.getElementById("ddl0401AddFrom").selectedIndex].value === "Manual" && parseFloat(document.getElementById("tbx04NoDays").value) <= 0) {
            fnAlertOnly('Some field(s) are missing!', 'error', 'btn btn-danger');
        } else if (document.getElementById("ddl0401AddFrom").options[document.getElementById("ddl0401AddFrom").selectedIndex].value === "Template" && document.getElementById("ddl0401Template").options[document.getElementById("ddl0401Template").selectedIndex].value === "") {
            fnAlertOnly('Some field(s) are missing!', 'error', 'btn btn-danger');
        }
        else {
            SaveApprover(ID);
        }
    }
    function SaveApprover(ID) {
        $.ajax({
            type: "POST",
            url: "Assets/Handler/FRM/HNDFRM000016.ashx",
            data: {
                'pFormCode': 'FRM000016',
                'pType': 'Add - Record - Approver',
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
            },
        });
    }
}
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
        fnFRMValidateRecord("04ApprovalPath", "Delete", pID, pSeqNo,"", function (response) {
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
            url: "Assets/Handler/FRM/HNDFRM000016.ashx",
            data: {
                'pFormCode': 'FRM000016',
                'pType': 'Delete Record Approver',
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
        fnFRMValidateRecord("04ApprovalPath", "Up", pID, pSeqNo,"", function (response) {
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
            url: "Assets/Handler/FRM/HNDFRM000016.ashx",
            data: {
                'pFormCode': 'FRM000016',
                'pType': 'Up Record Approver',
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
        fnFRMValidateRecord("04ApprovalPath", "Down", pID, pSeqNo,"", function (response) {
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
            url: "Assets/Handler/FRM/HNDFRM000016.ashx",
            data: {
                'pFormCode': 'FRM000016',
                'pType': 'Down Record Approver',
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
            FRMValidateRecord(pSeqNo);
        } else {
            fnAlertOnly('No active form found!', 'warning', 'btn btn-warning');
        };
    });
    function FRMValidateRecord(pSeqNo) {
        fnFRMValidateRecord("04ApprovalPath", "Save(ReasonForDelay)", document.getElementById('ContentPlaceHolder1_hdnID').value, pSeqNo,"", function (response) {
            if (response[0].Msg === "") {
                showModal(pSeqNo);
            } else {
                fnAlertOnly(response[0].Msg, 'error', 'btn btn-danger');
            };
        });
    }
    function showModal(pSeqNo) {
        $('#mdl0402Reason4Delays').modal('show')
        document.getElementById("tbx0402ReasonForDelay").value = "";
        document.getElementById("ContentPlaceHolder1_hdnSeqNo").value = pSeqNo;

    }
}
function fn0402AddReason_OK(Btn) {
    fnIfExist('oop_form_hdr', 'f_code', document.getElementById('ContentPlaceHolder1_hdnID').value, function (response) {
        if (response[0].oReturn == "1") {
            FRMValidateRecord(document.getElementById('ContentPlaceHolder1_hdnID').value, document.getElementById("ContentPlaceHolder1_hdnSeqNo").value);
        } else {
            fnAlertOnly('No active form found!', 'warning', 'btn btn-warning');
        };
    });
    function FRMValidateRecord(ID,pSeqNo) {
        fnFRMValidateRecord("04ApprovalPath", "Save(ReasonForDelay)", ID, pSeqNo,"", function (response) {
            if (response[0].Msg === "") {
                ValidateFields(ID, pSeqNo);
            } else {
                fnAlertOnly(response[0].Msg, 'error', 'btn btn-danger');
            };
        });
    }
    function ValidateFields(ID, pSeqNo) {
        if (document.getElementById("tbx0402ReasonForDelay").value === "") {
            fnAlertOnly('Some field(s) are missing!', 'error', 'btn btn-danger');
        } 
        else {
            Upd_Ok(ID, pSeqNo);
        }
    }
    function Upd_Ok(ID, pSeqNo) {
        $.ajax({
            type: "POST",
            url: "Assets/Handler/FRM/HNDFRM000016.ashx",
            data: {
                'pFormCode': 'FRM000016',
                'pType': 'Reason - For - Delay',
                'pID': ID,
                'pSeqNo': pSeqNo,
                'pReason': document.getElementById('tbx0402ReasonForDelay').value
            },
            success: function (response) {
                fnAlertOnly('Record successfully saved.', 'success', 'btn btn-success');
                document.getElementById("tbx0402ReasonForDelay").value = "";
                ddl0401Template();
                fn01Load()
            },
        });
    }
}

function fn0301LoadNotes(pID) {
    $.ajax({
        type: "POST",
        url: "HNDGEN.ashx",
        data: {
            'pFormCode': 'FRM000016',
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
function fn0302Add_Ok(Btn) {
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
    await fn0302Add_Ok_Await(Btn);
            }
        };
function fn0302Add_Ok_Await(Btn) {
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
            'pFormCode': 'FRM000016',
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
//notes

//subscriber
function fn0501LoadSubscriber(pID) {
    $.ajax({
        type: "POST",
        url: "Assets/Handler/FRM/HNDFRM000016.ashx",
        data: {
            'pFormCode': 'FRM000016',
            'pType': 'Get - Record - Subscriber',
            'pID': pID,
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
            //hide loader
            document.getElementById("div0501LoaderSubscriber").style.display = "none";
            //hide loader

        },
    });
};
//subscriber

function fn0502AddSbuscriber() {
    //if exisit
    fnIfExist('oop_form_hdr', 'f_code', document.getElementById('ContentPlaceHolder1_hdnID').value, function (response) {
        if (response[0].oReturn == "1") {
            FRMValidateRecord(document.getElementById('ContentPlaceHolder1_hdnID').value);
        } else {
            fnAlertOnly('No active form found!', 'warning', 'btn btn-warning');
        };
    });
    function FRMValidateRecord(ID) {
        fnFRMValidateRecord("03Subscribers", "Add", ID, "","", function (response) {
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
}
function ddl0501Subscriber() {

    $.ajax({
        type: "POST",
        url: "Assets/Handler/FRM/HNDFRM000016.ashx",
        data: {
            'pFormCode': 'FRM000016',
            'pType': 'Get - Dropdown - List',
            'pTblName': 'Subscriber_List',
            'pPlaceHolder': '',
            'pVal': '',
            'pVal2': ''
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
function fn0502AddSubscriber_OK(Btn) {
    fnIfExist('oop_form_hdr', 'f_code', document.getElementById('ContentPlaceHolder1_hdnID').value, function (response) {
        if (response[0].oReturn == "1") {
            FRMValidateRecord(document.getElementById('ContentPlaceHolder1_hdnID').value);
        } else {
            fnAlertOnly('No active form found!', 'warning', 'btn btn-warning');
        };
    });
    function FRMValidateRecord(ID) {
        fnFRMValidateRecord("03Subscribers", "Add", ID, "","", function (response) {
            if (response[0].Msg === "") {
                ValidateFields(ID);
            } else {
                fnAlertOnly(response[0].Msg, 'error', 'btn btn-danger');
            };
        });
    }
    function ValidateFields(ID) {
        if (document.getElementById("ddl0501AddUser").options[document.getElementById("ddl0501AddUser").selectedIndex].value === "") {
            fnAlertOnly('Some field(s) are missing!', 'error', 'btn btn-danger');
        }
        else {
            AddUser_Ok(ID);
        }
    }
    function AddUser_Ok(ID) {
        $.ajax({
            type: "POST",
            url: "Assets/Handler/FRM/HNDFRM000016.ashx",
            data: {
                'pFormCode': 'FRM000016',
                'pType': 'Add - User - Subscriber',
                'pID': ID,
                'pMonitorBy': document.getElementById("ddl0501AddUser").options[document.getElementById("ddl0501AddUser").selectedIndex].value
            },
            success: function (response) {
                fnAlertOnly('Record successfully saved.', 'success', 'btn btn-success');
                ddl0501Subscriber();
                fn01Load()
            },
        });
    }
}
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
        fnFRMValidateRecord("03Subscribers", "Delete", pID, "","", function (response) {
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
            url: "Assets/Handler/FRM/HNDFRM000016.ashx",
            data: {
                'pFormCode': 'FRM000016',
                'pType': 'Delete - User - Subscriber',
                'pID': pID,
                'pMonitoredBy': pMonitorBy
            },
            success: function (response) {
                fnAlertOnly('Record successfully removed.', 'success', 'btn btn-success');
                fn01Load();
            },
        });

    };
};
//History
function fn0601LoadHistory(pID) {
    $.ajax({
        type: "POST",
        url: "Assets/Handler/FRM/HNDFRM000016.ashx",
        data: {
            'pFormCode': 'FRM000016',
            'pType': 'Get - Record - History',
            'pID': pID,
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
//History

//fixed column header alignment
$(document).ready(function () {
    $('#ul0101Nav a.nav-link').on('shown.bs.tab', function (e) {
        $($.fn.dataTable.tables(true)).css('width', '100%');
        $($.fn.dataTable.tables(true)).DataTable().columns.adjust().draw();
    });
});
//fixed column header alignment

//@mention
var mentionUser = [];
var initialMention = [];
var jq = jQuery.noConflict();
//@mention

//load page
//seen
function Seen() {
    $.ajax({
        type: "POST",
        url: "Assets/Handler/FRM/HNDFRM000016.ashx",
        data: {
            'pFormCode': 'FRM000016',
            'pType': 'Seen',
            'pID': document.getElementById('ContentPlaceHolder1_hdnID').value
        },
        success: function (response) {
        
        },
    });
};
//seen

function pageLoad(sender, args) {InitialiseSettings(); }
function InitialiseSettings() {
    jQuery(function ($) {

        //metion        jq.fn.atwho.debug = true;
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
                            $('#hdnMention').val(initialMention.join(','));
                            return '@' + value;
                        },
                    }
                }
                $inputor = jq('.mention').atwho(at_config);
                $inputor.caret('pos', 47);
                $inputor.focus().atwho('run');
                // for removing mention
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
                        // Extract mention text to be removed
                        var mentionText = inputValue.substring(mentionStart, cursorPosition);

                        // Find and remove mention from mentionUser array
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
        };        //metion

        //combobox
        $('[data-kt-repeater="select2"]').select2();
        //combobox

        //date
        $('[data-kt-repeater="datepicker"]').flatpickr({
            dateFormat: "m/d/Y"
        });
        //date

        //upload
        Dropzone.autoDiscover = false;
        var myDropzone = new Dropzone("#DropZone", {
            url: "HNDGEN.ashx?pFormCode=FRM000016&pType=Upload&pID=" + document.getElementById('ContentPlaceHolder1_hdnID').value.replace("#", "No"),
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
                $('#mdl0202Upload').modal('hide');
                //load attachment
                fn0201LoadAttachment(document.getElementById('ContentPlaceHolder1_hdnMode').value, document.getElementById('ContentPlaceHolder1_hdnID').value);
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
            fnIfExist('oop_form_hdr', 'f_code', document.getElementById('ContentPlaceHolder1_hdnID').value, function (response) {
                if (response[0].oReturn == "1") {
                    Add();
                } else {
                    fnAlertOnly('No active form found!', 'warning', 'btn btn-warning');
                };
            });
            function Add() {
                myDropzone.removeAllFiles();
                FileCount = 0;
                $('#mdl0202Upload').modal('show');
            };
        });
        $('#btn0202Add_Ok').on('click', function (e) {
            fnIfExist('oop_form_hdr', 'f_code', document.getElementById('ContentPlaceHolder1_hdnID').value, function (response) {
                if (response[0].oReturn == "1") {
                    Validate();
                } else {
                    fnAlertOnly('No active form found!', 'warning', 'btn btn-warning');
                };
            });
            function Validate() {
                if (FileCount > 0) {
                    btn0202Add_Ok();
                } else {
                    fnAlertOnly('Attach at least one file to proceed!', 'error', 'btn btn-danger');
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
                    myDropzone.options.url = "HNDGEN.ashx?pFormCode=FRM000016&pType=Upload&pID=" + document.getElementById('ContentPlaceHolder1_hdnID').value.replace("#", "No");
                    myDropzone.processQueue();
                    //resolve
                    resolve();
                });
            }
        });
        //upload
    });
jQuery(function ($) {
    fn01Load();
    Seen();
    });
}
