//form
var FormCode = 'FRM000049'
//form

//For Edit
var originalTbodyClone = originalTbodyClone || null;
//For Edit

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
        fn01Plugins();
        fn01Load();
    });
    jQuery(function ($) {
        Dropzone.autoDiscover = false;
        var myDropzone = new Dropzone("#div98DropZone", {
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
                fn98Load(document.getElementById('ContentPlaceHolder1_hdnID').value);
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
            fn01IfExist('oop_form_hdr', 'f_code', document.getElementById('ContentPlaceHolder1_hdnID').value, function (response) {
                if (response[0].oReturn == "1") {
                    validate();
                } else {
                    fn01AlertOnly('No active form found.', 'warning', 'btn btn-warning');
                };
            });
            function validate() {
                fn13Validate("02Files", "Add", "", function (response) {
                    if (response[0].oReturn == "") {
                        myDropzone.removeAllFiles();
                        FileCount = 0;
                        $('#mdl9801Upload').modal('show');
                    } else {
                        fn01AlertOnly(response[0].oReturn, 'error', 'btn btn-danger');
                    };
                });
            }

        });
        $('#btn9801Add').on('click', function (e) {
            if (FileCount > 0) {
                fn13Validate("02Files", "Add", "", function (response) {
                    if (response[0].oReturn == "") {
                        btn9801Add();
                    } else {
                        fn01AlertOnly(response[0].oReturn, 'error', 'btn btn-danger');
                    };
                });
            } else {
                fn01AlertOnly('Attach at least one file to proceed!', 'error', 'btn btn-danger');
            }
            async function btn9801Add() {
                var Btn = document.getElementById('btn9801Add');
                Btn.disabled = true;
                Btn.setAttribute('data-kt-indicator', 'on');
                await btn9801Add_Await(Btn);
            }
            async function btn9801Add_Await(Btn) {
                return new Promise(resolve => {
                    myDropzone.options.url = "Assets/Handler/MNU/MNU001000HND.ashx?pFunction=Add-Record-98&pFormCode=" + FormCode + "&pID=" + document.getElementById('ContentPlaceHolder1_hdnID').value;
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
function initDateRangePicker(dateFromId, dateToId) {

    const dateFromInput = document.getElementById(dateFromId);
    const dateToInput = document.getElementById(dateToId);

    if (!dateFromInput || !dateToInput) return;

    // Destroy existing Flatpickr instances to avoid duplicates
    if (dateFromInput._flatpickr) dateFromInput._flatpickr.destroy();
    if (dateToInput._flatpickr) dateToInput._flatpickr.destroy();

    let dateToPicker;

    // Initialize Date From with logic to restrict Date To
    const dateFromPicker = flatpickr(dateFromInput, {
        dateFormat: 'm/d/Y',
        defaultDate: dateFromInput.value || null,
        onReady(selectedDates) {
            if (selectedDates.length && dateToPicker) {
                dateToPicker.set('minDate', selectedDates[0]);
            }
        },
        onChange(selectedDates) {
            const minDate = selectedDates.length ? selectedDates[0] : null;
            if (dateToPicker) {
                dateToPicker.set('minDate', minDate);

                if (dateToPicker.selectedDates.length && dateToPicker.selectedDates[0] < minDate) {
                    dateToPicker.clear();
                }
            }
        }
    });

    // Initialize Date To (after Date From)
    dateToPicker = flatpickr(dateToInput, {
        dateFormat: 'm/d/Y'
    });
}
function fn0101DisableButtons(pValue) {
    if (pValue == true) {
        document.getElementById("btn0101Find").classList.remove("btn-view");
        document.getElementById("btn0101Refresh").classList.remove("btn-view");
        document.getElementById("btn0101Add").classList.remove("btn-add");
        document.getElementById("btn0101Delete").classList.remove("btn-delete");
        document.getElementById("btn0101Edit").classList.remove("btn-edit");
        document.getElementById("btn98Add").classList.remove("btn-add");
        document.getElementById("btn99Add").classList.remove("btn-add");
        document.getElementById("btn0101Print").classList.remove("btn-tools");
        document.getElementById("btn0101Status").classList.remove("btn-secondary");
        document.getElementById("btn03010101Add").classList.remove("btn-add");
        document.getElementById("btn989Add").classList.remove("btn-add");
        document.getElementById("btn11Add").classList.remove("btn-add");
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
        document.getElementById("btn0101Status").classList.add("btn-secondary");
        document.getElementById("btn03010101Add").classList.add("btn-add");
        document.getElementById("btn989Add").classList.add("btn-add");
        document.getElementById("btn11Add").classList.add("btn-add");
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
    document.getElementById("btn0101Status").disabled = pValue;
    document.getElementById("btn03010101Add").disabled = pValue;
    document.getElementById("btn989Add").disabled = pValue;
    document.getElementById("btn11Add").disabled = pValue;
};
function fn0101Refresh() {
    fn0101LoadOverview(document.getElementById("ContentPlaceHolder1_hdnMode").value, document.getElementById("ContentPlaceHolder1_hdnID").value)
};
function fn01Load() {
    fn0101LoadOverview(document.getElementById("ContentPlaceHolder1_hdnMode").value, document.getElementById("ContentPlaceHolder1_hdnID").value)
    fn98Load(document.getElementById("ContentPlaceHolder1_hdnID").value);
    fn99Load(document.getElementById("ContentPlaceHolder1_hdnID").value);
    fn989Load(document.getElementById("ContentPlaceHolder1_hdnID").value);
    fn03010101Load(document.getElementById("ContentPlaceHolder1_hdnID").value);
    fn04010101Load(document.getElementById("ContentPlaceHolder1_hdnID").value);
    fn11Load(document.getElementById("ContentPlaceHolder1_hdnID").value);
}
//page

//Header
function fn0101LoadOverview(pMode, pID) {
    if (pMode == "ADD") {
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
        fn0101DisableButtons(true);
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

        var today = new Date();
        var formattedDate = (today.getMonth() + 1).toString().padStart(2, '0') + '/' +
            today.getDate().toString().padStart(2, '0') + '/' +
            today.getFullYear();

        document.getElementById("tbx01ID").value = "0000000000000";
        document.getElementById("tbx01FormType").value = "Gate Pass";
        document.getElementById("tbx01DateRequested").value = formattedDate;
        document.getElementById("tbx01DateRequired").value = formattedDate;
        $.ajax({
            type: "POST",
            url: "Assets/Handler/FRM/FRM000049HND.ashx",
            data: {
                'pFunction': 'Get-CIIS-Name',

            },
            success: function (response) {
                document.getElementById("tbx01RequestedBy").value = response[0].Name;
                document.getElementById("tbx01AssignedTo").value = response[0].Name;
            },
        });
        document.getElementById("tbx01EndorsedTo").value = "-";
        document.getElementById("tbx01Status").value = "New";

        const mm = String(today.getMonth() + 1).padStart(2, '0');
        const dd = String(today.getDate()).padStart(2, '0');
        const yyyy = today.getFullYear();

        document.getElementById("tbx01GPDate").value = `${mm}/${dd}/${yyyy}`;

        ddl01IssuedTo("")
        ddl01Dept("")
        document.getElementById("tbx01Site").value = "";
        document.getElementById("tbx01Location").value = "";
        document.getElementById("tbx01Purpose").value = "";
        document.getElementById("tbx01Notes").value = "";
  

        fn98Load("");
        fn99Load("");
        fn989Load("");
        fn11Load("");
        fn03010101Load("");
        fn04010101Load("");
        //content
    } else if (pMode == "DTL") {

        $.ajax({
            type: "POST",
            url: "Assets/Handler/FRM/FRM000049HND.ashx",
            data: {
                'pFunction': 'Get-Info-0101',
                'pID': pID,
            },
            success: function (response) {
                //title

                if (!response || response.length === 0) {

                    const fields = [
                        "spn0101Title", "spn0101ID", "spn0101Status",
                        "lbl01ID", "lbl01FormType", "lbl01DateRequested",
                        "lbl01DateRequired", "lbl01RequestedBy", "lbl01AssignedTo",
                        "lbl01EndorsedTo", "lbl01Status", "lbl01GPDate",
                        "lbl01IssuedTo", "lbl01Dept", "lbl01Site", "lbl01Location", "lbl01Purpose", "lbl01Note"
                    ];

                    fields.forEach(id => {
                        if (document.getElementById(id)) {
                            document.getElementById(id).innerText = "-";
                        }
                    });


                    //toolbar
                    document.getElementById("i0101Edit").classList.add("la-pencil-alt");
                    document.getElementById("i0101Edit").classList.remove("la-save");
                    fn0101DisableButtons(false);
                    //checkbox

                    //content
                    document.getElementById("div0101Detail").style.display = "";
                    document.getElementById("div0101Update").style.display = "none";
                    // stop execution
                    return;
                }

                document.getElementById("spn0101Title").innerText = response[0].Title;
                document.getElementById("spn0101ID").innerText = response[0].ID;
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
                document.getElementById("i0101Edit").classList.add("la-pencil-alt");
                document.getElementById("i0101Edit").classList.remove("la-save");
                fn0101DisableButtons(false);
                //checkbox

                //content
                document.getElementById("div0101Detail").style.display = "";
                document.getElementById("div0101Update").style.display = "none";

                document.getElementById("lbl01ID").innerText = response[0].ID;
                document.getElementById("lbl01FormType").innerText = response[0].FormType;
                document.getElementById("lbl01DateRequested").innerText = response[0].DateCreated;
                document.getElementById("lbl01DateRequired").innerText = response[0].DateRequired;
                document.getElementById("lbl01RequestedBy").innerText = response[0].RequestedBy;
                document.getElementById("lbl01AssignedTo").innerText = response[0].AssignedTo;
                document.getElementById("lbl01EndorsedTo").innerText = response[0].EndorsedTo;
                document.getElementById("lbl01Status").innerText = response[0].Status;

                document.getElementById("lbl01GPDate").innerText = response[0].GPDate;
                document.getElementById("lbl01IssuedTo").innerText = response[0].IssuedTo;
                document.getElementById("lbl01Dept").innerText = response[0].Dept;
                document.getElementById("lbl01Site").innerText = response[0].Site;
                document.getElementById("lbl01Location").innerText = response[0].Location;
                document.getElementById("lbl01Purpose").innerText = response[0].Purpose;
                document.getElementById("lbl01Note").innerText = response[0].Note;
                //content
            },

        });
    } else if (pMode == "UPD") {
        $.ajax({
            type: "POST",
            url: "Assets/Handler/FRM/FRM000049HND.ashx",
            data: {
                'pFunction': 'Edit-Record-Info-02',
                'pID': pID,
            },
            success: function (response) {
                //title
                document.getElementById("spn0101Title").innerText = response[0].Title;
                document.getElementById("spn0101ID").innerText = response[0].ID;
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
                fn0101DisableButtons(true);
                document.getElementById("btn0101Delete").classList.add("btn-delete");
                document.getElementById("btn0101Delete").disabled = false;
                document.getElementById("btn0101Edit").classList.add("btn-edit");
                document.getElementById("btn0101Edit").disabled = false;
                document.getElementById("i0101Edit").classList.remove("la-pencil-alt");
                document.getElementById("i0101Edit").classList.add("la-save");
                //toolbar

                document.getElementById("div0101Detail").style.display = "none";
                document.getElementById("div0101Update").style.display = "";

                document.getElementById("tbx01ID").value = response[0].ID;
                document.getElementById("tbx01FormType").value = response[0].FormType;
                document.getElementById("tbx01DateRequested").value = response[0].DateCreated;
                document.getElementById("tbx01DateRequired").value = response[0].DateRequired;
                document.getElementById("tbx01RequestedBy").value = response[0].RequestedBy;
                document.getElementById("tbx01AssignedTo").value = response[0].AssignedTo;
                document.getElementById("tbx01EndorsedTo").value = response[0].EndorsedTo;
                document.getElementById("tbx01Status").value = response[0].Status;

                document.getElementById("tbx01GPDate").value = response[0].GPDate;
                ddl01IssuedTo(response[0].IssuedTo)
                ddl01Dept(response[0].Dept)
                document.getElementById("tbx01Site").value = response[0].Site;
                document.getElementById("tbx01Location").value = response[0].Location;
                document.getElementById("tbx01Purpose").value = response[0].Purpose;
                document.getElementById("tbx01Notes").value = response[0].Note;
            },
        });
    }

};
function isNumberKeyNodash(evt) {
    var input = evt.target;   // <-- automatically get the input
    var charCode = evt.which ? evt.which : evt.keyCode;
    var charTyped = String.fromCharCode(charCode);

    if (evt.ctrlKey || evt.metaKey || charCode < 32) return true;

    return charCode >= 48 && charCode <= 57;
}
function isNumberKey(evt) {
    var input = evt.target;   // <-- automatically get the input
    var charCode = evt.which ? evt.which : evt.keyCode;
    var charTyped = String.fromCharCode(charCode);

    if (evt.ctrlKey || evt.metaKey || charCode < 32) return true;

    if (charTyped === '-') {
        return input.selectionStart === 0 && !input.value.includes('-');
    }

    if (charTyped === '.') {
        return !input.value.includes('.');
    }

    return charCode >= 48 && charCode <= 57;
}
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
function fn0101Add() {
    //access
    document.getElementById("ContentPlaceHolder1_hdnMode").value = "ADD";
    document.getElementById("ContentPlaceHolder1_hdnID").value = "000000000000";
    fn0101LoadOverview(document.getElementById("ContentPlaceHolder1_hdnMode").value, document.getElementById("ContentPlaceHolder1_hdnID").value)
}
function fn0101Delete() {
    if (document.getElementById('ContentPlaceHolder1_hdnMode').value == "ADD") {
        Cancel_Add_Question();
    } else if (document.getElementById('ContentPlaceHolder1_hdnMode').value == "DTL") {
        //if exisit
        fn01IfExist('oop_form_hdr', 'f_code', document.getElementById('ContentPlaceHolder1_hdnID').value, function (response) {
            if (response[0].oReturn == "1") {

                Validate(document.getElementById('ContentPlaceHolder1_hdnID').value);
            } else {
                fn01AlertOnly('No active form found.', 'warning', 'btn btn-warning');
            };
        });
        //validate
        function Validate(ID) {
            fn13Validate('01Overview', 'Delete', '', function (response) {
                if (response[0].oReturn == "") {
                    Delete_Dtl_Question(ID);
                } else {
                    fn01AlertOnly(response[0].oReturn, 'warning', 'btn btn-warning');
                };
            });
        };
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
                    document.getElementById("ContentPlaceHolder1_hdnMode").value = "DTL"
                    document.getElementById("ContentPlaceHolder1_hdnID").value = "0000000000000"
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
                fn01ValidateRecord('oop_form_hdr', ID, '', 'Delete', function (response) {
                    if (response[0].oReturn == "") {
                        Detele_Ok(ID);
                    } else {
                        fn01AlertOnly(response[0].oReturn, 'warning', 'btn btn-warning');
                    };
                });
            }
        });
        function Detele_Ok(ID) {
            fn01Delete(FormCode, FormCode, ID, function (response) {
                if (document.getElementById('ContentPlaceHolder1_hdnPrevID').value == "") {

                    if (window.opener && typeof window.opener.FRMUpdate === 'function') window.opener.FRMUpdate(ID);
                    document.getElementById("ContentPlaceHolder1_hdnMode").value = "DTL"
                    document.getElementById("ContentPlaceHolder1_hdnID").value = "0000000000000"
                    fn01Load();
                    fn01AlertOnly('Record successfully removed!', 'success', 'btn btn-success');
                } else if (document.getElementById('ContentPlaceHolder1_hdnPrevID').value == ID) {

                    if (window.opener && typeof window.opener.FRMUpdate === 'function') window.opener.FRMUpdate(ID);
                    document.getElementById("ContentPlaceHolder1_hdnMode").value = "DTL"
                    document.getElementById("ContentPlaceHolder1_hdnID").value = "0000000000000"
                    fn01Load();
                    fn01AlertOnly('Record successfully removed!', 'success', 'btn btn-success');

                } else if (document.getElementById('ContentPlaceHolder1_hdnPrevID').value != ID) {
                    document.getElementById('ContentPlaceHolder1_hdnMode').value = "DTL"
                    document.getElementById('ContentPlaceHolder1_hdnID').value = document.getElementById('ContentPlaceHolder1_hdnPrevID').value
                    document.getElementById('ContentPlaceHolder1_hdnPrevID').value = document.getElementById('ContentPlaceHolder1_hdnPrevID').value
                    fn0101LoadOverview(document.getElementById('ContentPlaceHolder1_hdnMode').value, document.getElementById('ContentPlaceHolder1_hdnID').value);
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
        //access
        ValidateFields("");
    } else if (document.getElementById('ContentPlaceHolder1_hdnMode').value == "DTL") {
        //if exisit
        fn01IfExist('oop_form_hdr', 'f_code', document.getElementById('ContentPlaceHolder1_hdnID').value, function (response) {
            if (response[0].oReturn == "1") {
                Validate();
            } else {
                fn01AlertOnly('No active form found.', 'warning', 'btn btn-warning');
            };
        });
        function Validate() {
            fn13Validate("06DTL", "Status", "", function (response) {
                if (response[0].oReturn == "New") {
                    fn13Validate("01Overview", "Save", "", function (response) {
                        if (response[0].oReturn == "") {
                            Edit_Dtl_Ok_Await(document.getElementById('ContentPlaceHolder1_hdnID').value);
                        } else {
                            fn01AlertOnly(response[0].oReturn, 'error', 'btn btn-danger');
                        };
                    });
                } else {
                    fn01AlertOnly('Access denied!', 'error', 'btn btn-danger');
                };
            });
        }


    } else if (document.getElementById('ContentPlaceHolder1_hdnMode').value == "UPD") {
        //if exisit
        fn01IfExist('oop_form_hdr', 'f_code', document.getElementById('ContentPlaceHolder1_hdnID').value, function (response) {
            if (response[0].oReturn == "1") {
                ValidateFields(document.getElementById('ContentPlaceHolder1_hdnID').value);
            } else {
                window.location.replace("MNU040100");
            };
        });
    }
    //validate fields
    function ValidateFields(ID) {
        if (document.getElementById("ddl01IssuedTo").value == "") {
            fn01AlertOnly('Some field(s) are missing!', 'error', 'btn btn-danger');
        } else if (document.getElementById("ddl01Dept").value == "") {
            fn01AlertOnly('Some field(s) are missing!', 'error', 'btn btn-danger');
        } else if (document.getElementById("tbx01Site").value == "") {
            fn01AlertOnly('Some field(s) are missing!', 'error', 'btn btn-danger');
        } else if (document.getElementById("tbx01Location").value == "") {
            fn01AlertOnly('Some field(s) are missing!', 'error', 'btn btn-danger');
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
                    Edit_Dtl_Ok_Await();
                } else if (document.getElementById('ContentPlaceHolder1_hdnMode').value == "UPD") {
                    Edit_Upd_Ok_Await(ID);
                }
            }
        });
    };
    //do edit
    function Edit_Add_Ok_Await() {
        Swal.fire({
            title: 'Loading...',
            text: 'Please wait while data is being processed.',
            allowOutsideClick: false,
            didOpen: () => {
                Swal.showLoading();
            }
        });
        // Do Billing
        $.ajax({
            type: "POST",
            url: "Assets/Handler/FRM/FRM000049HND.ashx",
            data: {
                'pFunction': 'Save-New-Record-0201',
                'pDateRequired': document.getElementById("tbx01DateRequired").value,
                'pGPDate': document.getElementById("tbx01GPDate").value,
                'pIssuedTo': document.getElementById("ddl01IssuedTo").value,
                'pDept': document.getElementById("ddl01Dept").value,
                'pSite': document.getElementById("tbx01Site").value,
                'pLocation': document.getElementById("tbx01Location").value,
                'pPurpose': document.getElementById("tbx01Purpose").value,
                'pNote': document.getElementById("tbx01Notes").value
              
            },
            success: function (response) {
                swal.close();
                fn01AlertOnly('Record successfully saved.', 'success', 'btn btn-success');
                document.getElementById('ContentPlaceHolder1_hdnMode').value = "DTL"
                document.getElementById('ContentPlaceHolder1_hdnID').value = response.oReturn
                document.getElementById('ContentPlaceHolder1_hdnPrevID').value = response.oReturn
                fn0101LoadOverview(document.getElementById('ContentPlaceHolder1_hdnMode').value, document.getElementById('ContentPlaceHolder1_hdnID').value);
                fn04010101Load(document.getElementById('ContentPlaceHolder1_hdnID').value);
                if (window.opener && typeof window.opener.FRMUpdate === 'function') window.opener.FRMUpdate(response.oReturn);
                fn11Load(document.getElementById('ContentPlaceHolder1_hdnID').value);


            },
            error: function (xhr, status, error) {
                Swal.close();
                fn01AlertOnly('An error occurred: ' + error, 'error', 'btn btn-danger');
            }
        });
    };
    function Edit_Dtl_Ok_Await(ID) {
        document.getElementById('ContentPlaceHolder1_hdnMode').value = "UPD"
        document.getElementById('ContentPlaceHolder1_hdnID').value = ID
        document.getElementById('ContentPlaceHolder1_hdnPrevID').value = ID
        fn0101LoadOverview(document.getElementById('ContentPlaceHolder1_hdnMode').value, document.getElementById('ContentPlaceHolder1_hdnID').value);
        fn04010101Load(document.getElementById('ContentPlaceHolder1_hdnID').value);
    };
    function Edit_Upd_Ok_Await(ID) {
        Swal.fire({
            title: 'Loading...',
            text: 'Please wait while data is being processed.',
            allowOutsideClick: false,
            didOpen: () => {
                Swal.showLoading();
            }
        });
        // Do Billing
        $.ajax({
            type: "POST",
            url: "Assets/Handler/FRM/FRM000049HND.ashx",
            data: {
                'pFunction': 'Update-New-Record-0201',
                'pFrmCode': FormCode,
                'pID': ID,
                'pDateRequired': document.getElementById("tbx01DateRequired").value,
                'pGPDate': document.getElementById("tbx01GPDate").value,
                'pIssuedTo': document.getElementById("ddl01IssuedTo").value,
                'pDept': document.getElementById("ddl01Dept").value,
                'pSite': document.getElementById("tbx01Site").value,
                'pLocation': document.getElementById("tbx01Location").value,
                'pPurpose': document.getElementById("tbx01Purpose").value,
                'pNote': document.getElementById("tbx01Notes").value
               
            },
            success: function (response) {
                swal.close();
                fn01AlertOnly('Record successfully saved.', 'success', 'btn btn-success');
                document.getElementById('ContentPlaceHolder1_hdnMode').value = "DTL"
                document.getElementById('ContentPlaceHolder1_hdnID').value = ID
                document.getElementById('ContentPlaceHolder1_hdnPrevID').value = ID
                fn0101LoadOverview(document.getElementById('ContentPlaceHolder1_hdnMode').value, document.getElementById('ContentPlaceHolder1_hdnID').value);
                fn04010101Load(ID)
                fn11Load(ID);
                if (window.opener && typeof window.opener.FRMUpdate === 'function') window.opener.FRMUpdate(ID);

            },
            error: function (xhr, status, error) {
                Swal.close();
                fn01AlertOnly('An error occurred: ' + error, 'error', 'btn btn-danger');
            }
        });
    };
};
function ddl01IssuedTo(pID) {
    $.ajax({
        type: "POST",
        url: "Assets/Handler/FRM/FRM000049HND.ashx",
        data: {
            'pFunction': 'Get-Record-03-List',
            'pTblName': 'User',
            'pPlaceHolder': 'Select an employee',
            'pFrmCode': '',
            'pAprType': '',
            'pID': ''

        },
        success: function (response) {
            var s = '';
            for (var i = 0; i < response.length; i++) {
                s += '<option value="' + response[i].ID + '">' + response[i].Name + '</option>';
            }
            $("#ddl01IssuedTo").html(s);
            $('#ddl01IssuedTo').val(pID).trigger('change');
        },
    });
}
function ddl01Dept(pID) {
      $.ajax({
        type: "POST",
        url: "Assets/Handler/FRM/FRM000049HND.ashx",
        data: {
            'pFunction': 'Get-Record-03-List',
            'pTblName': 'Department',
            'pPlaceHolder': 'Select department',
            'pFrmCode': '',
            'pAprType': '',
            'pID': ''

        },
        success: function (response) {
            var s = '';
            for (var i = 0; i < response.length; i++) {
                s += '<option value="' + response[i].ID + '">' + response[i].Name + '</option>';
            }
            $("#ddl01Dept").html(s);
            $('#ddl01Dept').val(pID).trigger('change');
        },
    });
}
//Header


//Details - Particular
function ddl03UOM(pID) {
    $.ajax({
        type: "POST",
        url: "Assets/Handler/FRM/FRM000049HND.ashx",
        data: {
            'pFunction': 'Get-Record-03-List',
            'pTblName': 'Mstr_Uom',
            'pPlaceHolder': 'Select Unit',
            'pFrmCode': '',
            'pAprType': '',
            'pID': ''

        },
        success: function (response) {
            var s = '';
            for (var i = 0; i < response.length; i++) {
                s += '<option value="' + response[i].ID + '">' + response[i].Name + '</option>';
            }
            $("#ddl03UOM").html(s);
            $('#ddl03UOM').val(pID).trigger('change');
        },
    });
}
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
function isNumberKey(evt) {
    var input = evt.target;   // <-- automatically get the input
    var charCode = evt.which ? evt.which : evt.keyCode;
    var charTyped = String.fromCharCode(charCode);

    if (evt.ctrlKey || evt.metaKey || charCode < 32) return true;

    if (charTyped === '-') {
        return input.selectionStart === 0 && !input.value.includes('-');
    }

    if (charTyped === '.') {
        return !input.value.includes('.');
    }

    return charCode >= 48 && charCode <= 57;
}
function fn03DisableButtons(pValue) {
    if (pValue == true) {
        document.getElementById("btn03Refresh").classList.remove("btn-view");
        document.getElementById("btn03Add").classList.remove("btn-add");
        document.getElementById("btn03Delete").classList.remove("btn-delete");
        document.getElementById("btn03Edit").classList.remove("btn-edit");
    } else {
        document.getElementById("btn03Refresh").classList.add("btn-view");
        document.getElementById("btn03Add").classList.add("btn-add");
        document.getElementById("btn03Delete").classList.add("btn-delete");
        document.getElementById("btn03Edit").classList.add("btn-edit");
    }
    document.getElementById("btn03Refresh").disabled = pValue;
    document.getElementById("btn03Add").disabled = pValue;
    document.getElementById("btn03Delete").disabled = pValue;
    document.getElementById("btn03Edit").disabled = pValue;
};
function fn11Load(pID) {
    $.ajax({
        type: "POST",
        url: "Assets/Handler/FRM/FRM000049HND.ashx",
        data: {
            'pFunction': 'Get-Particular-11',
            'pID': pID,
        },
        success: function (response) {
            $('#table11Record').DataTable().destroy();
            DataTable.types().forEach(type => { DataTable.type(type, 'detect', () => false); });
            $.fn.dataTable.moment('MM/DD/YYYY');
            var table11Record = $("#table11Record").DataTable({
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
                    { data: 'Action' },
                    { data: 'Particular' },
                    { data: 'Qty' },
                    { data: 'Unit' },
                    { data: 'TagNumber' },
                    { data: 'Loc' },
                    { data: 'IsReturnable' },
                    { data: 'DateReturn' }],
                columnDefs: [
                    { targets: 0, orderable: false },
                    { targets: 1, orderable: false, className: 'tbody-nowrap-auto' },
                    { targets: 2, orderable: false },
                    { targets: 3, orderable: false },
                    { targets: 4, orderable: false, className: 'tbody-nowrap-auto' },
                    { targets: 5, orderable: false, className: 'tbody-nowrap-auto' },
                    { targets: 6, orderable: false },
                    { targets: 7, orderable: false, className: 'tbody-nowrap-auto' }
                ]
            });
        },
    });
};
function fn11Add() {
    fn01IfExist('oop_form_hdr', 'f_code', document.getElementById('ContentPlaceHolder1_hdnID').value, function (response) {
        if (response[0].oReturn == "1") {
            fn13Validate("01Overview", "Save", "", function (response) {
                if (response[0].oReturn == "") {
                    document.getElementById("hdn03Mode").value = "ADD";
                    document.getElementById("hdn03ID").value = document.getElementById("ContentPlaceHolder1_hdnID").value + '-0-0';
                    fn03Load(document.getElementById("hdn03Mode").value, document.getElementById("hdn03ID").value);
                    $('#mdl03View').modal('show');
                } else {
                    fn01AlertOnly(response[0].oReturn, 'error', 'btn btn-danger');
                };
            });
        } else {
            fn01AlertOnly('No active form found.', 'warning', 'btn btn-warning');
        };
    });

};
function fn11View(pMode, pID) {
    fnIfExist('Form_Gatepass_Dtl', 'DTLCode', pID, function (response) {
        if (response[0].oReturn == "1") {
            document.getElementById("hdn03Mode").value = pMode;
            document.getElementById("hdn03ID").value = pID;
            fn03Load(pMode, pID);
        } else {
            window.location.replace("MNU040100");
        };
    });

};
function fn11Delete(pMode, pID) {
    fn01IfExist('Form_Gatepass_Dtl', 'DTLCode', pID, function (response) {
        if (response[0].oReturn == "1") {

            fn13Validate("01Overview", "Save", "", function (response) {
                if (response[0].oReturn == "") {
                    document.getElementById("hdn03Mode").value = pMode;
                    document.getElementById("hdn03ID").value = pID;
                    fn03Delete();
                } else {
                    fn01AlertOnly(response[0].oReturn, 'error', 'btn btn-danger');
                };
            });

        } else {
            window.location.replace("MNU040100");
        };
    });

};
function fn11Edit(pMode, pID) {
    fnIfExist('Form_Gatepass_Dtl', 'DTLCode', pID, function (response) {
        if (response[0].oReturn == "1") {
            fn13Validate("01Overview", "Save", "", function (response) {
                if (response[0].oReturn == "") {
                    fn03Load(pMode, pID)
                    document.getElementById("hdn03Mode").value = pMode;
                    document.getElementById("hdn03ID").value = pID;
                    $('#mdl03View').modal('show');
                } else {
                    fn01AlertOnly(response[0].oReturn, 'error', 'btn btn-danger');
                };
            });

        } else {
            window.location.replace("MNU040100");
        };
    });

};
function onIsReturnChange(el) {
    const val = el.value;

    if (val === "0") { 
        $('#tbx03DateReturn')
            .val('')
            .prop('disabled', true);
        $('#spn03DateReturn')
            .removeClass('required')

    } else if (val === "1") { 
        $('#tbx03DateReturn')
            .val('')
            .prop('disabled', false);
        $('#spn03DateReturn')
            .addClass('required')
    } else {
        $('#tbx03DateReturn')
            .val('')
            .prop('disabled', true);
        $('#spn03DateReturn')
            .removeClass('required')
    }
}
function fn03Load(pMode, pID) {
    if (pMode == "ADD") {
        //title
        document.getElementById("spn03Title").innerText = "New Record";
        document.getElementById("spn03Status").innerText = "-";
        //title

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
        document.getElementById("tbx03Part").value = "";
        document.getElementById("tbx03Qty").value = "";
        ddl03UOM("");
        document.getElementById("tbx03TagNo").value = "";
        document.getElementById("tbx03Loc").value = "";
        $('#ddl03IsReturn').val('').trigger('change');
        document.getElementById("tbx03DateReturn").value = "";
        //content

        //attachment
        LoadOthers();
        //note

    } else if (pMode == "DTL") {
        $.ajax({
            type: "POST",
            url: "Assets/Handler/FRM/FRM000049HND.ashx",
            data: {
                'pFunction': 'Get-Info-03',
                'pID': pID
            },
            success: function (response) {
                //title
                document.getElementById("spn03Title").innerText = response[0].Particular;
                document.getElementById("spn03Status").innerText = response[0].DtlCode;
                //title

                //toolbar
                document.getElementById("i03Edit").classList.add("la-pencil-alt");
                document.getElementById("i03Edit").classList.remove("la-save");
                fn03DisableButtons(false);
                //checkbox

                //content
                document.getElementById("div03Detail").style.display = "";
                document.getElementById("div03Update").style.display = "none";
                document.getElementById("lbl03Part").innerText = response[0].Particular;
                document.getElementById("lbl03Qty").innerText = response[0].Qty;
                document.getElementById("lbl03UOM").innerText = response[0].Unit;
                document.getElementById("lbl03TagNo").innerText = response[0].TagNumber;
                document.getElementById("lbl03Site").innerText = response[0].Loc;
                document.getElementById("lbl03IsReturn").innerText = response[0].IsReturnable;
                document.getElementById("lbl03DateReturn").innerText = response[0].DateReturn;
                //content

                //attachment
                LoadOthers();
                //note

            },
        });
    } else if (pMode == "UPD") {
        $.ajax({
            type: "POST",
            url: "Assets/Handler/FRM/FRM000049HND.ashx",
            data: {
                'pFunction': 'Get-Info-03',
                'pID': pID

            },
            success: function (response) {
                //title
                document.getElementById("spn03Title").innerText = response[0].Particular;
                document.getElementById("spn03Status").innerText = response[0].DtlCode;
                //title

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

                document.getElementById("tbx03Part").value = response[0].Particular;
                document.getElementById("tbx03Qty").value = response[0].Qty;
                ddl03UOM(response[0].UnitCode);
                document.getElementById("tbx03TagNo").value = response[0].TagNumber;
                document.getElementById("tbx03Loc").value = response[0].Loc;
                let isReturnVal = (response[0].IsReturnable === "Yes") ? 1 : 0;
                $('#ddl03IsReturn').val(isReturnVal).trigger('change');
                document.getElementById("tbx03DateReturn").value = response[0].DateReturn;

                //content

                //attachment
                LoadOthers();
                //note
            },
        });
    }

    function LoadOthers() {
        if (pMode == "ADD") { document.getElementById("hdn03IDPrev").value = ""; };
        if (pMode == "DTL") { document.getElementById("hdn03IDPrev").value = pID; };
        if (pMode == "UPD") { document.getElementById("hdn03IDPrev").value = pID; };
    };
};
function fn03Refresh() {
    fn03Load(document.getElementById("hdn03Mode").value, document.getElementById("hdn03ID").value);
};
function fn03Add() {
    fn01IfExist('oop_form_hdr', 'f_code', document.getElementById('ContentPlaceHolder1_hdnID').value, function (response) {
        if (response[0].oReturn == "1") {
            fn13Validate("01Overview", "Save", "", function (response) {
                if (response[0].oReturn == "") {
                    document.getElementById("hdn03Mode").value = "ADD";
                    document.getElementById("hdn03ID").value = "000000000000";
                    fn03Load(document.getElementById("hdn03Mode").value, document.getElementById("hdn03ID").value);
                } else {
                    fn01AlertOnly(response[0].oReturn, 'error', 'btn btn-danger');
                };
            });

        } else {
            fn01AlertOnly('No active form found.', 'warning', 'btn btn-warning');
        };
    });

};
function fn03Delete() {
    if (document.getElementById('hdn03Mode').value == "ADD") {
        fn13Validate("01Overview", "Save", "", function (response) {
            if (response[0].oReturn == "") {
                Cancel_Add_Question();
            } else {
                fn01AlertOnly(response[0].oReturn, 'error', 'btn btn-danger');
            };
        });

    } else if (document.getElementById('hdn03Mode').value == "DTL") {
        fn13Validate("01Overview", "Save", "", function (response) {
            if (response[0].oReturn == "") {
                Delete_Dtl_Question(document.getElementById('hdn03ID').value);
            } else {
                fn01AlertOnly(response[0].oReturn, 'error', 'btn btn-danger');
            };
        });

    } else if (document.getElementById('hdn03Mode').value == "UPD") {
        fn13Validate("01Overview", "Save", "", function (response) {
            if (response[0].oReturn == "") {
                Cancel_Upd_Question(document.getElementById('hdn03ID').value);
            } else {
                fn01AlertOnly(response[0].oReturn, 'error', 'btn btn-danger');
            };
        });

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
                if (document.getElementById('hdn03IDPrev').value == "") {
                    $('#mdl03View').modal('hide');
                } else {
                    document.getElementById('hdn03Mode').value = "DTL"
                    document.getElementById('hdn03ID').value = document.getElementById('hdn03IDPrev').value;
                    document.getElementById('hdn03IDPrev').value = document.getElementById('hdn03IDPrev').value;
                    fn03Load(document.getElementById("hdn03Mode").value, document.getElementById("hdn03ID").value);
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
                fnIfExist('Form_Gatepass_Dtl', 'DTLCode', document.getElementById("hdn03ID").value, function (response) {
                    if (response[0].oReturn == "1") {
                        Detele_Ok(ID);
                    } else {
                        window.location.replace("MNU040100");
                    };
                });

            }
        });
        function Detele_Ok(ID) {

            fn0311Delete(FormCode, document.getElementById("ContentPlaceHolder1_hdnID").value, ID, function (response) {
                if (document.getElementById('hdn03IDPrev').value == "") {
                    fn01AlertOnly('Record successfully removed!', 'success', 'btn btn-danger');
                    fn11Load(document.getElementById("ContentPlaceHolder1_hdnID").value);
                    fn04010101Load(document.getElementById("ContentPlaceHolder1_hdnID").value);
                    $('#mdl03View').modal('hide');

                } else if (document.getElementById('hdn03IDPrev').value == ID) {
                    fn01AlertOnly('Record successfully removed!', 'success', 'btn btn-danger');
                    fn11Load(document.getElementById("ContentPlaceHolder1_hdnID").value);
                    fn04010101Load(document.getElementById("ContentPlaceHolder1_hdnID").value);
                    $('#mdl03View').modal('hide');
                } else if (document.getElementById('hdn03IDPrev').value != ID) {
                    fn01AlertOnly('Record successfully removed!', 'success', 'btn btn-danger');
                    fn11Load(document.getElementById("ContentPlaceHolder1_hdnID").value);
                    fn04010101Load(document.getElementById("ContentPlaceHolder1_hdnID").value);
                    document.getElementById('hdn03Mode').value = "DTL"
                    document.getElementById('hdn03ID').value = document.getElementById('hdn03IDPrev').value
                    document.getElementById('hdn03IDPrev').value = document.getElementById('hdn03IDPrev').value
                    fn03Load(document.getElementById('hdn03Mode').value, document.getElementById('hdn03ID').value);
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
                document.getElementById('hdn03Mode').value = "DTL"
                document.getElementById('hdn03ID').value = ID
                document.getElementById('hdn03IDPrev').value = ID
                fn03Load(document.getElementById('hdn03Mode').value, document.getElementById('hdn03ID').value);
            }
        });
    };
};
function fn0311Delete(pFormCode, pTblName, pTblCode, callBack) {
    $.ajax({
        type: "POST",
        url: "Assets/Handler/FRM/FRM000049HND.ashx",
        async: true,
        data: {
            'pFunction': 'Delete-Record-03',
            'pFrmCode': pFormCode,
            'pTblName': pTblName,
            'pTblCode': pTblCode
        },
        success: function (response) {
            callBack(response);
        },
    });
};
function fn03Edit() {
    //validate
    if (document.getElementById('hdn03Mode').value == "ADD") {
        fn01IfExist('oop_form_hdr', 'f_code', document.getElementById('ContentPlaceHolder1_hdnID').value, function (response) {
            if (response[0].oReturn == "1") {
                fn13Validate("01Overview", "Save", "", function (response) {
                    if (response[0].oReturn == "") {
                        ValidateFields("");
                    } else {
                        fn01AlertOnly(response[0].oReturn, 'error', 'btn btn-danger');
                    };
                });

            } else {
                fn01AlertOnly('No active form found.', 'warning', 'btn btn-warning');
            };
        });

    } else if (document.getElementById('hdn03Mode').value == "DTL") {
        fn13Validate("01Overview", "Save", "", function (response) {
            if (response[0].oReturn == "") {
                Edit_Dtl_Ok_Await(document.getElementById("hdn03ID").value);
            } else {
                fn01AlertOnly(response[0].oReturn, 'error', 'btn btn-danger');
            };
        });

    } else if (document.getElementById('hdn03Mode').value == "UPD") {
        fn13Validate("01Overview", "Save", "", function (response) {
            if (response[0].oReturn == "") {
                ValidateFields(document.getElementById("hdn03ID").value);
            } else {
                fn01AlertOnly(response[0].oReturn, 'error', 'btn btn-danger');
            };
        });

    }
    function ValidateFields(ID) {
        if (document.getElementById("tbx03Part").value == "") {
            fn01AlertOnly('Some field(s) are missing!', 'error', 'btn btn-danger');
        } else if (document.getElementById("tbx03Qty").value == "") {
            fn01AlertOnly('Some field(s) are missing!', 'error', 'btn btn-danger');
        } else if (document.getElementById("ddl03UOM").value == "") {
            fn01AlertOnly('Some field(s) are missing!', 'error', 'btn btn-danger');
        } else if (document.getElementById("tbx03TagNo").value == "") {
            fn01AlertOnly('Some field(s) are missing!', 'error', 'btn btn-danger');
        } else if (document.getElementById("tbx03Loc").value == "") {
            fn01AlertOnly('Some field(s) are missing!', 'error', 'btn btn-danger');
        } else if (document.getElementById("ddl03IsReturn").value == "") {
            fn01AlertOnly('Some field(s) are missing!', 'error', 'btn btn-danger');
        } else if (document.getElementById("ddl03IsReturn").value == "1" && document.getElementById("tbx03DateReturn").value == "") {
            fn01AlertOnly('Some field(s) are missing!', 'error', 'btn btn-danger');
        } else {
            Edit_Question(ID);
        }
    }
    //question.
    async function Edit_Question(ID) {
        const result = await Swal.fire({
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
        });

        if (result.isConfirmed) {
            const mode = document.getElementById('hdn03Mode').value;

            if (mode === "ADD") {
                Edit_Add_Ok_Await();
            } else if (mode === "DTL") {
                Edit_Dtl_Ok_Await(ID);
            } else if (mode === "UPD") {
                Edit_Upd_Ok_Await(ID);
            }
        }
    }

    //do edit

    function Edit_Add_Ok_Await() {
        // Do Billing
        $.ajax({
            type: "POST",
            url: "Assets/Handler/FRM/FRM000049HND.ashx",
            data: {
                'pFunction': 'Add-Record-03',
                'pFrmCode': FormCode,
                'pID': document.getElementById("ContentPlaceHolder1_hdnID").value,
                'pPart': document.getElementById("tbx03Part").value,
                'pQty': document.getElementById("tbx03Qty").value,
                'pUom': document.getElementById("ddl03UOM").value,
                'pTagNo': document.getElementById("tbx03TagNo").value,
                'pLoc': document.getElementById("tbx03Loc").value,
                'pReturn': document.getElementById("ddl03IsReturn").value,
                'pDateReturn': document.getElementById("tbx03DateReturn").value,
            },
            success: function (response) {
                document.getElementById('hdn03Mode').value = "DTL"
                fn01AlertOnly('Record successfully saved.', 'success');
                document.getElementById('hdn03ID').value = response.oReturn
                document.getElementById('hdn03IDPrev').value = response.oReturn
                fn03Load(document.getElementById('hdn03Mode').value, document.getElementById('hdn03ID').value);
                fn11Load(document.getElementById("ContentPlaceHolder1_hdnID").value)
                fn04010101Load(document.getElementById("ContentPlaceHolder1_hdnID").value)
            },
        });
    };
    function Edit_Dtl_Ok_Await(ID) {
        document.getElementById('hdn03Mode').value = "UPD"
        document.getElementById('hdn03ID').value = ID
        document.getElementById('hdn03IDPrev').value = ID
        fn03Load(document.getElementById('hdn03Mode').value, document.getElementById('hdn03ID').value);
    };
    function Edit_Upd_Ok_Await(ID) {
        // Do Billing
        $.ajax({
            type: "POST",
            url: "Assets/Handler/FRM/FRM000049HND.ashx",
            data: {
                'pFunction': 'Update-Record-03',
                'pFrmCode': FormCode,
                'pID': document.getElementById("ContentPlaceHolder1_hdnID").value,
                'pDtlCode': document.getElementById("hdn03ID").value,
                'pPart': document.getElementById("tbx03Part").value,
                'pQty': document.getElementById("tbx03Qty").value,
                'pUom': document.getElementById("ddl03UOM").value,
                'pTagNo': document.getElementById("tbx03TagNo").value,
                'pLoc': document.getElementById("tbx03Loc").value,
                'pReturn': document.getElementById("ddl03IsReturn").value,
                'pDateReturn': document.getElementById("tbx03DateReturn").value,

            },
            success: function (response) {
                fn01AlertOnly('Record successfully saved.', 'success');
                fn11Load(document.getElementById("ContentPlaceHolder1_hdnID").value)
                fn04010101Load(document.getElementById("ContentPlaceHolder1_hdnID").value)
                document.getElementById('hdn03Mode').value = "DTL"
                document.getElementById('hdn03ID').value = ID
                document.getElementById('hdn03IDPrev').value = ID
                fn03Load(document.getElementById('hdn03Mode').value, document.getElementById('hdn03ID').value);
            },
        });
    };
};
//Details - Particular


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
                select: false,
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
    fn01IfExist('oop_form_hdr', 'f_code', document.getElementById('ContentPlaceHolder1_hdnID').value, function (response) {
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
    fn01IfExist('oop_form_hdr', 'f_code', document.getElementById('ContentPlaceHolder1_hdnID').value, function (response) {
        if (response[0].oReturn == "1") {
            Delete_Question(pFormCode, pID, pFileName);
        } else {
            window.location.replace("MNU040100");
        };
    });
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
                fn04010101Load(document.getElementById('ContentPlaceHolder1_hdnID').value);

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
    fn01IfExist('oop_form_hdr', 'f_code', document.getElementById('ContentPlaceHolder1_hdnID').value, function (response) {
        if (response[0].oReturn == "1") {
            Add();
        } else {
            fn01AlertOnly('No active form found.', 'warning', 'btn btn-warning');
        };
    });
    function Add() {
        document.getElementById("tbx9901Note").value = "";
        document.getElementById("hdn99Mention").value = "";
        $('#mdl9901Notes').modal('show');
    };
};
function fn9901Add(Btn) {
    fn01IfExist('oop_form_hdr', 'f_code', document.getElementById('ContentPlaceHolder1_hdnID').value, function (response) {
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
                    'pID': document.getElementById('ContentPlaceHolder1_hdnID').value,
                    'pNotes': document.getElementById("tbx9901Note").value,
                    'pMention': document.getElementById("hdn99Mention").value,
                },
                success: function (response) {
                    fn01AlertOnly('Note successfully added.', 'success');
                    document.getElementById("tbx9901Note").value = "";
                    document.getElementById("hdn99Mention").value = "";
                    fn99Load(document.getElementById('ContentPlaceHolder1_hdnID').value);
                    fn04010101Load(document.getElementById('ContentPlaceHolder1_hdnID').value);
                },
            });
        };
        Btn.disabled = false;
        Btn.removeAttribute('data-kt-indicator');
        resolve();
    });
};
//notes

//Approval Path
function fn989Load(pID) {
    $.ajax({
        type: "POST",
        url: "Assets/Handler/FRM/FRM000049HND.ashx",
        data: {
            'pFunction': 'Get-Record-989',
            'pID': pID,
        },
        success: function (response) {
            $('#table989Record').DataTable().destroy();
            DataTable.types().forEach(type => { DataTable.type(type, 'detect', () => false); });
            $.fn.dataTable.moment('MM/DD/YYYY');
            var table989Record = $("#table989Record").DataTable({
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
/*                    { data: 'Action' },*/
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
                    { targets: 5, orderable: false, className: 'tbody-nowrap-auto' }
                ],
                order: [],
            });
        },
    });
};
function fn989Delete(pSeqNo) {
    fn13Validate("04ApprovalPath", "Delete", pSeqNo, function (response) {
        if (response[0].oReturn == "") {
            Swal.fire({
                text: 'Remove User?',
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
                    Delete_Ok(FormCode, pSeqNo);
                }
            });
            function Delete_Ok(FormCode, pSeqNo) {
                $.ajax({
                    type: "POST",
                    url: "Assets/Handler/FRM/FRM000049HND.ashx",
                    data: {
                        'pFunction': 'Delete-Record-989',
                        'pFrmCode': FormCode,
                        'pID': document.getElementById('ContentPlaceHolder1_hdnID').value,
                        'pSeqNo': pSeqNo,
                    },
                    success: function (response) {
                        fn01AlertOnly('Record successfully removed.', 'success', 'btn btn-success');
                        fn989Load(document.getElementById('ContentPlaceHolder1_hdnID').value);
                        fn04010101Load(document.getElementById('ContentPlaceHolder1_hdnID').value);
                        fn0101LoadOverview(document.getElementById("ContentPlaceHolder1_hdnMode").value, document.getElementById("ContentPlaceHolder1_hdnID").value)
                    },
                });
            };

        } else {
            fn01AlertOnly(response[0].oReturn, 'error', 'btn btn-danger');
        };
    });
};
function fn989Update(pSeqNo) {
    fn13Validate("04ApprovalPath", "Save(ReasonForDelay)", pSeqNo, function (response) {
        if (response[0].oReturn == "") {
            $('#mdl01ReasonForDelay').modal('show');
            document.getElementById('hdnSeqNo').value = pSeqNo
            document.getElementById('tbx04ReasonForDelay').value = "";
        } else {
            fn01AlertOnly(response[0].oReturn, 'error', 'btn btn-danger');
        };
    });
};
function fn989Save() {
    fn13Validate("04ApprovalPath", "Save(ReasonForDelay)", document.getElementById('hdnSeqNo').value, function (response) {
        if (response[0].oReturn == "") {
            $.ajax({
                type: "POST",
                url: "Assets/Handler/FRM/FRM000049HND.ashx",
                data: {
                    'pFunction': 'Save-Record-989',
                    'pFrmCode': FormCode,
                    'pID': document.getElementById('ContentPlaceHolder1_hdnID').value,
                    'pReason': document.getElementById('tbx04ReasonForDelay').value,
                    'pSeqNo': pSeqNo,
                },
                success: function (response) {
                    fn01AlertOnly('Record successfully saved.', 'success', 'btn btn-success');
                    fn989Load(document.getElementById('ContentPlaceHolder1_hdnID').value);
                    fn04010101Load(document.getElementById('ContentPlaceHolder1_hdnID').value);
                    $('#mdl01ReasonForDelay').modal('hide');
                    fn0101LoadOverview(document.getElementById("ContentPlaceHolder1_hdnMode").value, document.getElementById("ContentPlaceHolder1_hdnID").value)
                },
            });
        } else {
            fn01AlertOnly(response[0].oReturn, 'error', 'btn btn-danger');
        };
    });
};
function fn989Up(pSeqNo) {
    fn13Validate("04ApprovalPath", "Up", pSeqNo, function (response) {
        if (response[0].oReturn == "") {
            $.ajax({
                type: "POST",
                url: "Assets/Handler/FRM/FRM000049HND.ashx",
                data: {
                    'pFunction': 'Move-Record-989',
                    'pFrmCode': FormCode,
                    'pID': document.getElementById('ContentPlaceHolder1_hdnID').value,
                    'pSeqNo': pSeqNo,
                    'pAction': "Up",
                },
                success: function (response) {
                    fn01AlertOnly('Record successfully moved.', 'success', 'btn btn-success');
                    fn989Load(document.getElementById('ContentPlaceHolder1_hdnID').value);
                    fn04010101Load(document.getElementById('ContentPlaceHolder1_hdnID').value);
                    fn0101LoadOverview(document.getElementById("ContentPlaceHolder1_hdnMode").value, document.getElementById("ContentPlaceHolder1_hdnID").value)
                },
            });
        } else {
            fn01AlertOnly(response[0].oReturn, 'error', 'btn btn-danger');
        };
    });
};
function fn989Down(pSeqNo) {
    fn13Validate("04ApprovalPath", "Down", pSeqNo, function (response) {
        if (response[0].oReturn == "") {
            $.ajax({
                type: "POST",
                url: "Assets/Handler/FRM/FRM000049HND.ashx",
                data: {
                    'pFunction': 'Move-Record-989',
                    'pFrmCode': FormCode,
                    'pID': document.getElementById('ContentPlaceHolder1_hdnID').value,
                    'pSeqNo': pSeqNo,
                    'pAction': "Down",
                },
                success: function (response) {
                    fn01AlertOnly('Record successfully moved.', 'success', 'btn btn-success');
                    fn989Load(document.getElementById('ContentPlaceHolder1_hdnID').value);
                    fn04010101Load(document.getElementById('ContentPlaceHolder1_hdnID').value);
                    fn0101LoadOverview(document.getElementById("ContentPlaceHolder1_hdnMode").value, document.getElementById("ContentPlaceHolder1_hdnID").value)
                },
            });
        } else {
            fn01AlertOnly(response[0].oReturn, 'error', 'btn btn-danger');
        };
    });
};
function ddl04Type_onchange(pID) {
    document.getElementById('hdnAprType').value = pID
    ddl04Approver("")
}
function fn989AddOpenApprover(pSeqno) {
    fn01IfExist('oop_form_hdr', 'f_code', document.getElementById('ContentPlaceHolder1_hdnID').value, function (response) {
        if (response[0].oReturn == "1")  {
            validate();
        } else {
            fn01AlertOnly('No active form found.', 'warning', 'btn btn-warning');
        };
    });
    function validate() {
        fn13Validate("04ApprovalPath", "Save(Approver)", pSeqno, function (response) {
            if (response[0].oReturn == "") {
                $('#mdl01ApproverOpen').modal('show');
                ddl04OpenAppr("");
                document.getElementById('hdnSeqNo').value = pSeqno
            } else {
                fn01AlertOnly(response[0].oReturn, 'error', 'btn btn-danger');
            };
        });
    }

}
function fn989Add(event) {
    if (event) event.preventDefault();

    fn01IfExist('oop_form_hdr', 'f_code', document.getElementById('ContentPlaceHolder1_hdnID').value, function (response) {
        if (response[0].oReturn == "1") {
            validate();
        } else {
            fn01AlertOnly('No active form found.', 'warning', 'btn btn-warning');
        };
    });
    function validate() {
        fn13Validate("04ApprovalPath", "Add", "", function (response) {
            if (response[0].oReturn == "") {
                $('#mdl01Approver').modal('show');
/*                $('#ddl04AddFrom').val('').trigger('change');*/
                ddl04OpenAppr("");
                ddl04Template("");  
            } else {
                fn01AlertOnly(response[0].oReturn, 'error', 'btn btn-danger');
            };
        });
    }

}
function fn989SaveApproval() {
    fn13Validate("04ApprovalPath", "Add", "", function (response) {
        if (response[0].oReturn == "") {
            ValidateFields();
        } else {
            fn01AlertOnly(response[0].oReturn, 'error', 'btn btn-danger');
        };
    });
    function ValidateFields() {
        if (document.getElementById("ddl04Template").value == "") {
            fn01AlertOnly('Some field(s) are missing!', 'error', 'btn btn-danger');
        } else {
            $.ajax({
                type: "POST",
                url: "Assets/Handler/FRM/FRM000049HND.ashx",
                data: {
                    'pFunction': 'Save-New-Record-989',
                    'pFrmCode': FormCode,
                    'pID': document.getElementById('ContentPlaceHolder1_hdnID').value,
                    'pTypeApr': "Template",
                    'pApprover': "",
                    'pNoDays': "",
                    'pTemplate': document.getElementById('ddl04Template').value,
                    'pAddForm': ""

                },
                success: function (response) {
                    fn01AlertOnly('Record successfully saved.', 'success', 'btn btn-success');
                    fn989Load(document.getElementById('ContentPlaceHolder1_hdnID').value);
                    fn0101LoadOverview(document.getElementById("ContentPlaceHolder1_hdnMode").value, document.getElementById("ContentPlaceHolder1_hdnID").value)
                    fn04010101Load(document.getElementById('ContentPlaceHolder1_hdnID').value);
                    ddl04Template("");
                    $('#mdl01Approver').modal('hide');
                },
            });
        }
    }
}
function fn989SaveOpenApproval() {
    fn13Validate("04ApprovalPath", "Save(Approver)", document.getElementById('hdnSeqNo').value, function (response) {
        if (response[0].oReturn == "") {
            ValidateFields();
        } else {
            fn01AlertOnly(response[0].oReturn, 'error', 'btn btn-danger');
        };
    });
    function ValidateFields() {
        if (document.getElementById("ddl04TempAppr").value == "") {
            fn01AlertOnly('Some field(s) are missing!', 'error', 'btn btn-danger');
        } else {
            $.ajax({
                type: "POST",
                url: "Assets/Handler/FRM/FRM000049HND.ashx",
                data: {
                    'pFunction': 'Save-New-Open-Record-989',
                    'pFrmCode': FormCode,
                    'pID': document.getElementById('ContentPlaceHolder1_hdnID').value,
                    'pTemplate': document.getElementById('ddl04TempAppr').value,
                    'pSeqNo': document.getElementById('hdnSeqNo').value

                },
                success: function (response) {
                    fn01AlertOnly('Record successfully saved.', 'success', 'btn btn-success');
                    fn989Load(document.getElementById('ContentPlaceHolder1_hdnID').value);
                    fn0101LoadOverview(document.getElementById("ContentPlaceHolder1_hdnMode").value, document.getElementById("ContentPlaceHolder1_hdnID").value)
                    fn04010101Load(document.getElementById('ContentPlaceHolder1_hdnID').value);
                    ddl04OpenAppr("");
                    $('#mdl01ApproverOpen').modal('hide');
                },
            });
        }
    }
}
function ddl04AddFrom_onchange(pID) {
    if (pID === "Template") {
        document.getElementById('pnl04Template').style.display = 'inline-flex';
        ddl04Template("");
        document.getElementById('pnl04Type').style.display = 'none';
        document.getElementById('pnl04AssignTo').style.display = 'none';
        document.getElementById('pnl04NoDays').style.display = 'none';
    }
    else if (pID === "Manual") {
        document.getElementById('pnl04Type').style.display = 'inline-flex';
        document.getElementById('pnl04AssignTo').style.display = 'inline-flex';
        document.getElementById('pnl04NoDays').style.display = 'inline-flex';
        document.getElementById('tbx04NoDays').value = "1.00";
        $('#ddl04Type').val('').trigger('change');
        ddl04Approver("");
        document.getElementById('pnl04Template').style.display = 'none';
    } else {
        document.getElementById('pnl04Type').style.display = 'none';
        document.getElementById('pnl04AssignTo').style.display = 'none';
        document.getElementById('pnl04NoDays').style.display = 'none';
        document.getElementById('pnl04Template').style.display = 'none';
    }
}
function ddl04Approver(pID) {
    $.ajax({
        type: "POST",
        url: "Assets/Handler/FRM/FRM000049HND.ashx",
        data: {
            'pFunction': 'Get-Record-03-List',
            'pTblName': 'Approver',
            'pPlaceHolder': 'Select a user',
            'pFrmCode': FormCode,
            'pAprType': document.getElementById('hdnAprType').value,
            'pID': document.getElementById('ContentPlaceHolder1_hdnID').value

        },
        success: function (response) {
            var s = '';
            for (var i = 0; i < response.length; i++) {
                s += '<option value="' + response[i].ID + '">' + response[i].Name + '</option>';
            }
            $("#ddl04Approver").html(s);
            $('#ddl04Approver').val(pID).trigger('change');
        },
    });
}
function ddl04OpenAppr(pID) {
    $.ajax({
        type: "POST",
        url: "Assets/Handler/FRM/FRM000049HND.ashx",
        data: {
            'pFunction': 'Get-Record-03-List',
            'pTblName': 'EmployeeApprover',
            'pPlaceHolder': '',
            'pFrmCode': FormCode,
            'pAprType': document.getElementById('hdnAprType').value,
            'pID': document.getElementById('ContentPlaceHolder1_hdnID').value

        },
        success: function (response) {
            var s = '';
            for (var i = 0; i < response.length; i++) {
                s += '<option value="' + response[i].ID + '">' + response[i].Name + '</option>';
            }
            $("#ddl04TempAppr").html(s);
            $('#ddl04TempAppr').val(pID).trigger('change');
        },
    });
}
function ddl04Template(pID) {
    $.ajax({
        type: "POST",
        url: "Assets/Handler/FRM/FRM000049HND.ashx",
        data: {
            'pFunction': 'Get-Record-03-List',
            'pTblName': 'Template',
            'pPlaceHolder': 'Select a template',
            'pFrmCode': FormCode,
            'pAprType': '',
            'pID': document.getElementById('ContentPlaceHolder1_hdnID').value

        },
        success: function (response) {
            var s = '';
            for (var i = 0; i < response.length; i++) {
                s += '<option value="' + response[i].ID + '">' + response[i].Name + '</option>';
            }
            $("#ddl04Template").html(s);
            $('#ddl04Template').val(pID).trigger('change');
        },
    });
}
//Approval Path

//Subscriber
function fn03010101Load(pID) {
    $.ajax({
        type: "POST",
        url: "Assets/Handler/FRM/FRM000049HND.ashx",
        data: {
            'pFunction': 'Get-Record-03010101',
            'pID': pID,
        },
        success: function (response) {
            $('#table03010101Record').DataTable().destroy();
            DataTable.types().forEach(type => { DataTable.type(type, 'detect', () => false); });
            $.fn.dataTable.moment('MM/DD/YYYY');
            var table03010101Record = $("#table03010101Record").DataTable({
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
                    { targets: 2, orderable: false }
                ],
                order: [],
            });
            $('#tbx03010101Find').on('keyup', function () { table03010101Record.search(this.value).draw(); });
        },
    });
};
function fn03010101AddUser() {
    fn01IfExist('oop_form_hdr', 'f_code', document.getElementById('ContentPlaceHolder1_hdnID').value, function (response) {
        if (response[0].oReturn == "1") {
            validate();
        } else {
            fn01AlertOnly('No active form found.', 'warning', 'btn btn-warning');
        };
    });
    function validate() {
        fn13Validate("03Subscribers", "Add", "", function (response) {
            if (response[0].oReturn == "") {
                $('#mdl01User').modal('show');
                ddl03User("")
            } else {
                fn01AlertOnly(response[0].oReturn, 'error', 'btn btn-danger');
            };
        });
    }

}
function fn03010101SaveUser() {
    fn13Validate("03Subscribers", "Add", "", function (response) {
        if (response[0].oReturn == "") {
            ValidateFields();
        } else {
            fn01AlertOnly(response[0].oReturn, 'error', 'btn btn-danger');
        };
    });
    function ValidateFields() {
        if (document.getElementById("ddl03User").value == "") {
            fn01AlertOnly('Some field(s) are missing!', 'error', 'btn btn-danger');
        } else {
            Save_Ok();
        }
    }
    function Save_Ok() {
        fn13Validate("03Subscribers", "Add", "", function (response) {
            if (response[0].oReturn == "") {
                $.ajax({
                    type: "POST",
                    url: "Assets/Handler/FRM/FRM000052HND.ashx",
                    data: {
                        'pFunction': 'Save-New-Record-03010101',
                        'pFrmCode': FormCode,
                        'pID': document.getElementById('ContentPlaceHolder1_hdnID').value,
                        'pUser': document.getElementById('ddl03User').value,

                    },
                    success: function (response) {
                        fn01AlertOnly('Record successfully saved.', 'success', 'btn btn-success');
                        ddl03User("")
                        fn03010101Load(document.getElementById('ContentPlaceHolder1_hdnID').value);
                        fn04010101Load(document.getElementById('ContentPlaceHolder1_hdnID').value);
                        fn0101LoadOverview(document.getElementById("ContentPlaceHolder1_hdnMode").value, document.getElementById("ContentPlaceHolder1_hdnID").value)
                    },
                });
            } else {
                fn01AlertOnly(response[0].oReturn, 'error', 'btn btn-danger');
            };
        });
    };
}
function fn03010101Delete(pUser) {
    fn13Validate("03Subscribers", "Delete", pUser, function (response) {
        if (response[0].oReturn == "") {
            Swal.fire({
                text: 'Remove User?',
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
                    fn13Validate("03Subscribers", "Delete", pUser, function (response) {
                        if (response[0].oReturn == "") {
                            Delete_Ok(FormCode, pUser);
                        } else {
                            fn01AlertOnly(response[0].oReturn, 'error', 'btn btn-danger');
                        };
                    });
                }
            });
            function Delete_Ok(FormCode, pUser) {
                $.ajax({
                    type: "POST",
                    url: "Assets/Handler/FRM/FRM000049HND.ashx",
                    data: {
                        'pFunction': 'Delete-Record-03010101',
                        'pFrmCode': FormCode,
                        'pID': document.getElementById('ContentPlaceHolder1_hdnID').value,
                        'pUser': pUser,
                    },
                    success: function (response) {
                        fn01AlertOnly('Record successfully removed.', 'success', 'btn btn-success');
                        fn03010101Load(document.getElementById('ContentPlaceHolder1_hdnID').value);
                        fn04010101Load(document.getElementById('ContentPlaceHolder1_hdnID').value);
                        fn0101LoadOverview(document.getElementById("ContentPlaceHolder1_hdnMode").value, document.getElementById("ContentPlaceHolder1_hdnID").value)
                    },
                });
            };

        } else {
            fn01AlertOnly(response[0].oReturn, 'error', 'btn btn-danger');
        };
    });
};
function ddl03User(pID) {
    $.ajax({
        type: "POST",
        url: "Assets/Handler/FRM/FRM000049HND.ashx",
        data: {
            'pFunction': 'Get-Record-03-List',
            'pTblName': 'User',
            'pPlaceHolder': 'Select a user',
            'pFrmCode': '',
            'pAprType': '',
            'pID': document.getElementById('ContentPlaceHolder1_hdnID').value

        },
        success: function (response) {
            var s = '';
            for (var i = 0; i < response.length; i++) {
                s += '<option value="' + response[i].ID + '">' + response[i].Name + '</option>';
            }
            $("#ddl03User").html(s);
            $('#ddl03User').val(pID).trigger('change');
        },
    });
}
//Subscriber

//History
function fn04010101Load(pID) {
    $.ajax({
        type: "POST",
        url: "Assets/Handler/FRM/FRM000049HND.ashx",
        data: {
            'pFunction': 'Get-Record-04010101',
            'pID': pID,
            'pFrmCode': FormCode
        },
        success: function (response) {
            $('#table04010101Record').DataTable().destroy();
            DataTable.types().forEach(type => { DataTable.type(type, 'detect', () => false); });
            $.fn.dataTable.moment('MM/DD/YYYY');
            var table04010101Record = $("#table04010101Record").DataTable({
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
                    { targets: 0, orderable: false }
                ],
                order: [],
            });
        },
    });
};
//History

//Validate
function fn13Validate(pTblGroup, pTblType, pTblVal, callBack) {
    $.ajax({
        type: "POST",
        url: "Assets/Handler/FRM/FRM000049HND.ashx",
        async: true,
        data: {
            'pFunction': 'Validate',
            'pID': document.getElementById('ContentPlaceHolder1_hdnID').value,
            'Group': pTblGroup,
            'Type': pTblType,
            'Value': pTblVal,
        },
        success: function (response) {
            callBack(response);
        },
    });
};
//Validate

//Find Record
function fn0101FindRecord() {
    $.ajax({
        type: "POST",
        url: "Assets/Handler/FRM/FRM000049HND.ashx",
        async: true,
        data: {
            'pFunction': 'Find-Record'
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
//Find Record

//Report
function fn0101_AMD03RPT01() {
    //if exisit
    fn01IfExist('oop_form_hdr', 'f_code', document.getElementById('ContentPlaceHolder1_hdnID').value, function (response) {
        if (response[0].oReturn == "1") {
            fn13Validate("01Overview", "PrintStatus", "", function (response) {
                if (response[0].oReturn == "") {
                    $.ajax({
                        type: "POST",
                        url: "Assets/Handler/FRM/FRM000049HND.ashx",
                        data: {
                            'pFunction': 'Generate-Report-0101',
                            'pID': document.getElementById("ContentPlaceHolder1_hdnID").value
                        },
                        success: function (response) {
                            if (response.status === "success") {
                                window.open(response.viewUrl, '_blank');
                            } else {
                                fnAlertOnly('Error generating report.', 'error', 'btn btn-danger');
                            }
                        }
                    });
                } else {
                    fn01AlertOnly(response[0].oReturn, 'error', 'btn btn-danger');
                };
            });

        } else {
            fn01AlertOnly('No active form found.', 'warning', 'btn btn-warning');
        };
    });
}
//Report

//Status
function fn0101ChangeStatus() {
    //if exisit
    fn01IfExist('oop_form_hdr', 'f_code', document.getElementById('ContentPlaceHolder1_hdnID').value, function (response) {
        if (response[0].oReturn == "1") {
            fn13Validate("01Overview", "Status", '', function (response) {
                if (response[0].oReturn == "") {
                    $('#mdl01Status').modal('show');
                    ddl01Status("")
                    document.getElementById("tbx01Note").value
                } else {
                    fn01AlertOnly(response[0].oReturn, 'error', 'btn btn-danger');
                };
            });
        } else {
            fn01AlertOnly('No active form found.', 'warning', 'btn btn-warning');
        };
    });
}
function ddl01Status_onchange(pID) {
    if (pID === "Clarify") {
        document.getElementById('pnl01ClarifyTo').style.display = 'inline-flex';
        ddl01ClarifyTo("")
    } else if (pID === "Declined") {
        document.getElementById('spn01Note').classList = 'input-group-text input-group-text-top min-w-150px required';
    } else {
        document.getElementById('pnl01ClarifyTo').style.display = 'none';
        document.getElementById('spn01Note').classList = 'input-group-text input-group-text-top min-w-150px';
    }
}
function ddl01Status(pID) {
    $.ajax({
        type: "POST",
        url: "Assets/Handler/FRM/FRM000049HND.ashx",
        data: {
            'pFunction': 'Get-Record-03-List',
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
            $("#ddl01Status").html(s);
            $('#ddl01Status').val(pID).trigger('change');
        },
    });
}
function ddl01ClarifyTo(pID) {
    $.ajax({
        type: "POST",
        url: "Assets/Handler/FRM/FRM000049HND.ashx",
        data: {
            'pFunction': 'Get-Record-03-List',
            'pTblName': 'Clarify',
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
            $("#ddl01ClarifyTo").html(s);
            $('#ddl01ClarifyTo').val(pID).trigger('change');
        },
    });
}
function fn88SaveStatus() {
    fn13Validate("01Overview", "Status", document.getElementById("ddl01Status").value, function (response) {
        if (response[0].oReturn == "") {
            if (document.getElementById("ddl01Status").value == "") {
                fn01AlertOnly('Some field(s) are missing!', 'error', 'btn btn-danger');
            } else if (document.getElementById("ddl01Status").value == "Clarify" && document.getElementById("ddl01ClarifyTo").value == "") {
                fn01AlertOnly('Some field(s) are missing!', 'error', 'btn btn-danger');
            } else if (document.getElementById("ddl01Status").value == "Declined" && document.getElementById("tbx01Note").value == "") {
                fn01AlertOnly('Some field(s) are missing!', 'error', 'btn btn-danger');
            } else if (document.getElementById("ddl01Status").value == "Cancelled" && document.getElementById("tbx01Note").value == "") {
                fn01AlertOnly('Some field(s) are missing!', 'error', 'btn btn-danger');
            } else {
                Validate(document.getElementById('ContentPlaceHolder1_hdnID').value);
            }

            function Validate(ID) {
                fn13Validate("01Overview", "Status", document.getElementById("ddl01Status").value, function (response) {
                    if (response[0].oReturn == "") {
                        $.ajax({
                            type: "POST",
                            url: "Assets/Handler/FRM/FRM000049HND.ashx",
                            data: {
                                'pFunction': 'Update-Record-Status-88',
                                'pFrmCode': FormCode,
                                'pID': document.getElementById('ContentPlaceHolder1_hdnID').value,
                                'pStatus': document.getElementById("ddl01Status").value,
                                'pAssignto': document.getElementById("ddl01ClarifyTo").value,
                                'pRemarks': document.getElementById("tbx01Note").value,
                                'pMention': document.getElementById("hdn99Mention").value
                            },
                            success: function (response) {
                                $('#mdl01Status').modal('hide');
                                ddl01Status("")
                                document.getElementById("tbx01Note").value
                                fn01AlertOnly('Record successfully saved.', 'success', 'btn btn-success');
                                fn989Load(document.getElementById('ContentPlaceHolder1_hdnID').value);
                                fn04010101Load(document.getElementById('ContentPlaceHolder1_hdnID').value);
                                fn0101LoadOverview(document.getElementById("ContentPlaceHolder1_hdnMode").value, document.getElementById("ContentPlaceHolder1_hdnID").value)
                            },
                        });
                    } else {
                        fn01AlertOnly(response[0].oReturn, 'error', 'btn btn-danger');
                    };
                });
                    }
        } else {
            fn01AlertOnly(response[0].oReturn, 'error', 'btn btn-danger');
        };
    });
}
//Status