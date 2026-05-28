//public variable
let grid01Api;
let grid02Api;
//public variable

//general
function fn01Load() {
    fnAccess('SCM010000', 'View', function (response) {
        if (response[0].oReturn == "1") {
            //Header
            fn01Image();

            //General
            fn01General();

            //Attachment
            fn02Attachment(document.getElementById("ContentPlaceHolder1_hdnMode").value, document.getElementById("ContentPlaceHolder1_hdnID").value);

            //Contractor
            fn03Contractor(document.getElementById("ContentPlaceHolder1_hdnMode").value, document.getElementById("ContentPlaceHolder1_hdnID").value);

            //tinyMCE
            fn0301TinyMCE();

            //Notice
            fn04Attachment(document.getElementById("ContentPlaceHolder1_hdnMode").value, document.getElementById("ContentPlaceHolder1_hdnID").value);
        } else {
            location.replace("MNU000022");
        };
    });
};
//general

//function -  view
function fn01View() {
    window.open("FRM000009-DTL-" + document.getElementById("ContentPlaceHolder1_hdnID").value, "_blank");
};
//function -  view

//function - Image
function fn01Image() {
    $.ajax({
        type: "POST",
        url: "SCM000011.ashx",
        data: {
            'pFormCode': 'SCM010101',
            'pType': 'For Award - Project Image',
            'pID': document.getElementById("ContentPlaceHolder1_hdnID").value
        },
        success: function (response) {
            document.getElementById("div01SubdImg").style = "background-image: url(Assets/media/svg/project/" + response[0].ProjImage + ".svg); background-size: 100% 100%;";
        }
    });
};
//function - Image

//function - General
function fn01General() {
    $.ajax({
        type: "POST",
        url: "SCM000011.ashx",
        data: {
            'pFormCode': 'SCM010101',
            'pType': 'For Award - General',
            'pID': document.getElementById("ContentPlaceHolder1_hdnID").value
        },
        success: function (response) {
            document.getElementById("lbl01ID").innerText = response[0].ID;
            document.getElementById("lbl01FormType").innerText = "Contract Order";
            document.getElementById("lbl01DateRequested").innerText = response[0].DateCreated;
            document.getElementById("lbl01DateRequired").innerText = response[0].DateRequired;
            document.getElementById("lbl01AssignedTo").innerText = response[0].AssignedTo;
            document.getElementById("lbl01EndorsedTo").innerText = response[0].EndorsedTo;
            document.getElementById("lbl01Status").innerText = response[0].Status;
            document.getElementById("lbl01Category").innerText = response[0].Category;
            document.getElementById("lbl01Project").innerText = response[0].Project;

            //show
            fn01ShowFields(response[0].Category);
            //show
        }
    });
};
//function - General

//function - Show Fields
function fn01ShowFields(pCategory) {
    //reset
    document.getElementById("div01House").style.display = "none";
    document.getElementById("div01Batch").style.display = "none";
    document.getElementById("div01Theme").style.display = "none";
    document.getElementById("div01Budget").style.display = "none";

    if (pCategory == "Shell to Premium") {
        document.getElementById("div01House").style.display = "";
    } else if (pCategory == "Shell to Complete") {
        document.getElementById("div01House").style.display = "";
    } else if (pCategory == "Classic to Premium") {
        document.getElementById("div01House").style.display = "";
    } else if (pCategory == "Shell to Classic") {
        document.getElementById("div01House").style.display = "";
    } else if (pCategory == "Structural Consultant - Amenities") {
        document.getElementById("div01Budget").style.display = "";
    } else if (pCategory == "Structural Consultant - House Unit") {
        document.getElementById("div01House").style.display = "";
        document.getElementById("div01Batch").style.display = "";
    } else if (pCategory == "Land Scape Unit") {
        document.getElementById("div01House").style.display = "";
        document.getElementById("div01Budget").style.display = "";
    } else if (pCategory == "Land Scape Project Restoration") {
        document.getElementById("div01Budget").style.display = "";
    } else if (pCategory == "Land Scape Project New") {
        document.getElementById("div01Budget").style.display = "";
    } else if (pCategory == "Interior Designer") {
        document.getElementById("div01House").style.display = "";
        document.getElementById("div01Batch").style.display = "";
        document.getElementById("div01Theme").style.display = "";
    } else if (pCategory == "House Repair") {
        document.getElementById("div01House").style.display = "";
    } else if (pCategory == "House Construction") {
        document.getElementById("div01House").style.display = "";
        document.getElementById("div01Batch").style.display = "";
    } else if (pCategory == "Electrical Consultant") {
        document.getElementById("div01House").style.display = "";
    } else if (pCategory == "DOLE Application - Model House") {
        document.getElementById("div01House").style.display = "";
    } else if (pCategory == "Basic to Complete") {
        document.getElementById("div01House").style.display = "";
    };
};
//function - Show Fields

//function - Validate
function fnFRMValidateRecord(pGroup, pFType, pID, pValue01, pValue02, callBack) {
    $.ajax({
        type: "POST",
        url: "SCM000011.ashx",
        data: {
            'pFormCode': 'SCM010101',
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
//function - Validate

//function - Attachment
function fn02Attachment(pMode, pID) {
    $.ajax({
        type: "POST",
        url: "SCM000011.ashx",
        data: {
            'pFormCode': 'SCM010101',
            'pType': 'Upload - Get Record',
            'pID': pID
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
            url: "SCM000011.ashx",
            data: {
                'pFormCode': "SCM010101",
                'pType': 'Upload - Download',
                'pID': pID,
                'pFileName': pFileName
            },
            success: function (response) {
                window.open(response[0].View, "_blank");
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
            url: "SCM000011.ashx",
            data: {
                'pFormCode': "SCM010101",
                'pType': 'Upload - Delete',
                'pID': pID,
                'pFileName': pFileName
            },
            success: function (response) {
                fnAlertOnly('File successfully removed!', 'success', 'btn btn-success');
                fn02Attachment(document.getElementById('ContentPlaceHolder1_hdnMode').value, pID);
            },
        });
    };
};
//function - Attachment

//function - Contractor
function fn03Contractor(pMode, pID) {
    $.ajax({
        type: "POST",
        url: "SCM000011.ashx",
        data: {
            'pFormCode': 'SCM010101',
            'pType': 'For Award - Get Contractor (List)',
            'pID': pID
        },
        success: function (response) {
            //display loader
            document.getElementById("div0301LoadContractor").style.display = "";
            //display loader

            $('#table0301Contractor').DataTable().destroy();

            //disable column type detection
            DataTable.types().forEach(type => {
                DataTable.type(type, 'detect', () => false);
            });
            //disable column type detection

            //sort date by yyyy/mm/dd
            $.fn.dataTable.moment('MM/DD/YYYY');
            //sort date by yyyy/mm/dd

            //datatable
            var table0301Contractor = $("#table0301Contractor").DataTable({
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
                    { data: 'ConName' },
                    { data: 'TagByName' },
                    { data: 'TagDate' },
                    { data: 'Status' }],
                columnDefs: [{ targets: 0, orderable: false }, { targets: 1, className: 'tbody-nowrap-auto' }, { targets: 2, className: 'tbody-nowrap-auto' }, { targets: 3, className: 'tbody-nowrap-auto' }],
                order: [[2, 'asc']],
            });
            //datatable

            //search
            $('#tbx0301FindContractor').on('keyup', function () {
                table0301Contractor.search(this.value).draw();
            });
            //search

            //hide loader
            document.getElementById("div0301LoadContractor").style.display = "none";
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
function fn03Tag() {
    // Table
    var table0201Attachment = $('#table0201Attachment').DataTable();
    var table0301Contractor = $('#table0301Contractor').DataTable();
    var tbl0301ColStatus = table0301Contractor
        .column(4)
        .data()
        .toArray();
    
    if (table0201Attachment.rows().count() == 0) {
        fnAlertOnly('Some fields are missing!', 'error', 'btn btn-danger');
    } else if (tbl0301ColStatus.includes('Awarded')) {
        fnAlertOnly('Already awarded the project!', 'error', 'btn btn-danger');
    } else {

        //Ajax
        $.ajax({
            type: "POST",
            url: "SCM000011.ashx",
            data: {
                'pFormCode': 'SCM010101',
                'pType': 'For Award - Get Contractor'
            },
            success: function (response) {
                grid01Api.setGridOption("rowData", response);
            },
            complete: function (response) {
                grid01Api.setGridOption("loading", false);
            }
        });

        //AG Grid
        let gridDiv = document.querySelector('#table0301Record');
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
            rowSelection: 'multiple',
            loading: true,
            columnDefs: [

                {
                    headerName: "Action",
                    field: "isChecked",
                    lockPosition: true,
                    resizable: false,
                    sortable: false,
                    width: 75,
                    checkboxSelection: true
                },
                {
                    headerName: "ID",
                    field: "Code",
                    filter: 'agTextColumnFilter',
                    width: 150,
                    tooltipField: "Code",
                    cellStyle: { fontWeight: 'bold' }
                },
                {
                    headerName: "Name",
                    field: "Name",
                    filter: 'agTextColumnFilter',
                    tooltipField: "Name",
                    flex: 1,
                    minWidth: 280
                },
                {
                    headerName: "Type",
                    field: "Type",
                    filter: 'agTextColumnFilter',
                    width: 120,
                    tooltipField: "Type"
                },
                {
                    headerName: "Email",
                    field: "Email",
                    filter: 'agTextColumnFilter',
                    width: 270,
                    tooltipField: "Email"
                },
                {
                    headerName: "Address",
                    field: "Address",
                    filter: 'agTextColumnFilter',
                    width: 280,
                    tooltipField: "Address"
                },

            ],
            rowData: [],
            pagination: false,
        };
        grid01Api = agGrid.createGrid(gridDiv, gridOptions);

        //modal
        $("#mdl0301Record").modal("show");
    }
};
function fn0301Tag_Ok(Btn) {
    // Disable the clicked button to avoid multiple clicks
    Btn.disabled = true;
    // Show loading indicator
    Btn.setAttribute('data-kt-indicator', 'on');
    // Enable
    document.getElementById("fn0301Filter").disabled = false;
    // Remove loading
    document.getElementById("fn0301Filter").removeAttribute('data-kt-indicator');
    // Table
    var table0201Attachment = $('#table0201Attachment').DataTable();
    // Array
    const selectedRows = grid01Api.getSelectedRows();
    let tagList = [];
    selectedRows.forEach(item => {
        tagList.push({
            Code: item.Code,
            Email: item.Email
        });
    });

    if (selectedRows.length == 0) {
        Swal.close();
        fnAlertOnly('Please select a Contractor!', 'error', 'btn btn-danger');
        Btn.disabled = false;
        Btn.removeAttribute('data-kt-indicator');
        return;
    };

    if (table0201Attachment.rows().count() == 0) {
        Swal.close();
        fnAlertOnly('Some fields are missing!', 'error', 'btn btn-danger');
        Btn.disabled = false;
        Btn.removeAttribute('data-kt-indicator');
        return;
    };

    let CodeSrs = tagList.map(i => `${i.Code}`).join('®');
    let EmailSrs = tagList.map(i => `${i.Email}`).join(',');

    if (CodeSrs && EmailSrs) {
        //modal
        $("#mdl0301Filter").modal("show");
        document.getElementById("tbx0301DateFrom").value = "";
        document.getElementById("tbx0301DateTo").value = "";
        document.getElementById("ContentPlaceHolder1_hdnCodeSrs").value = "";
        document.getElementById("ContentPlaceHolder1_hdnEmailSrs").value = "";

        //set
        document.getElementById("ContentPlaceHolder1_hdnCodeSrs").value = CodeSrs;
        document.getElementById("ContentPlaceHolder1_hdnEmailSrs").value = EmailSrs;

        //clear
        Btn.disabled = false;
        Btn.removeAttribute('data-kt-indicator');
    } else {
        //do nothing
        Btn.disabled = false;
        Btn.removeAttribute('data-kt-indicator');
    };
};
function fn0301Filter_Ok(Btn) {
    // Disable the clicked button to avoid multiple clicks
    Btn.disabled = true;
    // Show loading indicator
    Btn.setAttribute('data-kt-indicator', 'on');
    //function
    async function Filter_Ok() {
        await Filter_Ok_Await(Btn);
    };
    // Simulate form submission
    Filter_Ok();
    async function Filter_Ok_Await(Btn) {
        const dateFrom = new Date(document.getElementById("tbx0301DateFrom").value);
        const dateTo = new Date(document.getElementById("tbx0301DateTo").value);
        // validate
        if (dateFrom > dateTo) {
            // Alert
            fnAlertOnly('Please select a valid date range. "Date To" cannot be earlier than "Date From".', 'error', 'btn btn-danger');
            // Disable the clicked button to avoid multiple clicks
            Btn.disabled = false;
            // Hide loading indication
            Btn.removeAttribute('data-kt-indicator');
        } else if (document.getElementById("tbx0301DateFrom").value == "" || document.getElementById("tbx0301DateTo").value == "") {
            // Alert
            fnAlertOnly('Some fields are missing!', 'error', 'btn btn-danger');
            // Disable the clicked button to avoid multiple clicks
            Btn.disabled = false;
            // Hide loading indication
            Btn.removeAttribute('data-kt-indicator');
        } else {
            // process
            return new Promise(resolve => {
                //modal
                $("#mdl0301Filter").modal("hide");
                $("#mdl0301Mail").modal("show");

                //reset using tinyMCe
                tinymce.get('txt0301MailContent').setContent(`
                    <p style="line-height: 2;">Good day!<br><br>You might want to check the unit below:<br>Kindly coordinate with&nbsp;<span style="background-color: #f1c40f;"><em><strong><span style="background-color: #ffff00;">Project Manager</span><span style="background-color: #ffffff;"> </span></strong></em><span style="background-color: #ffffff;">the schedule of site visit.<br>Please see attached files for your reference thank you.<br></span></span></p>
							<table style="border-collapse: collapse; width: 100%; height: 144.688px;" border="1"><colgroup><col style="width: 12.8657%;"><col style="width: 12.2363%;"><col style="width: 12.3855%;"><col style="width: 11.2809%;"><col style="width: 21.7755%;"><col style="width: 29.4561%;"></colgroup>
							<tbody>
							<tr style="height: 36.1719px;">
							<td style="text-align: center;"><strong>SUBD</strong></td>
							<td style="text-align: center;"><strong>PHASE</strong></td>
							<td style="text-align: center;"><strong>BLOCK</strong></td>
							<td style="text-align: center;"><strong>LOT</strong></td>
							<td><strong>TYPE</strong></td>
							<td><strong>AWARD COST</strong></td>
							</tr>
							<tr style="height: 36.1719px;">
							<td style="text-align: center;"><strong>&nbsp;</strong></td>
							<td style="text-align: center;"><strong>&nbsp;</strong></td>
							<td style="text-align: center;"><strong>&nbsp;</strong></td>
							<td style="text-align: center;"><strong>&nbsp;</strong></td>
							<td><strong>&nbsp;</strong></td>
							<td><strong>&nbsp;</strong></td>
							</tr>
							<tr style="height: 36.1719px;">
							<td>&nbsp;</td>
							<td>&nbsp;</td>
							<td>&nbsp;</td>
							<td>&nbsp;</td>
							<td>&nbsp;</td>
							<td>&nbsp;</td>
							</tr>
							<tr style="height: 36.1719px;">
							<td style="text-align: right;" colspan="5"><strong>TOTAL AWARD COST</strong></td>
							<td><strong>0</strong></td>
							</tr>
							</tbody>
							</table>
							<p style="line-height: 2;"><em><strong><span style="background-color: #ffff00;">Materials and Labor contract.</span></strong></em></p>
							<p style="line-height: 2;"><em><strong><span style="background-color: #ffff00;">VAT Inclusive.</span></strong></em></p>
							<p style="line-height: 2;"><span style="background-color: #ffffff;"><em>Note: We will supply the main and service area doors.</em></span></p>
							<p style="line-height: 2;"><span style="background-color: #ffffff;"><em><span style="background-color: #ffff00;">Duration: </span></em><span style="background-color: #ffff00;"><strong>120 Calendar Days</strong></span></span></p>
							<p style="line-height: 2;"><span style="background-color: #ffffff;"><span style="background-color: #ffff00;"><strong>Target Mobilization Date: <em>(Insert date)</em></strong></span></span></p>
							<p style="line-height: 2;"><span style="background-color: #ffffff;">Thank you,</span></p>
							<p style="line-height: 1.2;"><strong><span style="background-color: #ffffff;"><span style="font-size: 14pt;">DISCLAIMER:</span><br>We would like to bring to your attention that this email and its attachment have been sent to various contractors.&nbsp;</span></strong></p>
							<p style="line-height: 1.2;"><strong><span style="background-color: #ffffff;">The first contractor to submit acceptance or express intention to accept the within the specified timeframe will be given preferential privilage for the project.</span></strong></p>
							<p style="line-height: 1.2;"><strong><span style="background-color: #ffffff;">Please note that the amount on the Bill of Quantities (BOQ) and in the body of the email is different because we are supplying the steel doors and their accessories</span></strong></p>
							<p style="line-height: 1.2;"><span style="background-color: #ffffff;">Regards,</span></p>
                            <br>
							<p style="line-height: 1;"><span style="background-color: #ffffff;"><em><strong><span style="background-color: #ffff00;">Name of the Contracts Engineer</span></strong></em></span></p>
							<p style="line-height: 1;"><span style="background-color: #ffffff;"><em>Contracts Engineer</em></span></p>
							<p style="line-height: 1;"><span style="background-color: #ffffff;"><em>CALMAR LAND DEVELOPMENT CORPORATION</em></span></p>
							<p style="line-height: 1;"><span style="background-color: #ffffff;"><em>Maharlika Highway, Kanlurang Mayao Lucena City</em></span></p>
							<p style="line-height: 1;"><span style="background-color: #ffffff;"><em>Telephone: (042) 373-3001 Loc. 207</em></span></p>
							<p style="line-height: 1;"><span style="background-color: #ffffff;"><em>Mobile No.: 093-1074-3738</em></span></p>
							<p style="line-height: 1;"><span style="background-color: #ffffff;"><em>Viber: 093-1074-3738</em></span></p>
                `);

                return Promise.resolve();

            });

        };
    };
};
function fn0301TinyMCE() {

    //tom select
    new TomSelect("#txt0301ComposeCC", {
        persist: false,
        createOnBlur: true,
        maxItems: 10,
        // Manual
        create: function (input) {
            const emailRegex = /^[^\s@]+@[^\s@]+\.[^\s@]+$/;
            if (!emailRegex.test(input)) return false;
            return { value: input, text: input };
        },
        // Dropdown
        load: function (query, callback) {
            if (!query.length) return callback();
            $.ajax({
                url: "SCM000011.ashx",
                type: "GET",
                data: {
                    pFormCode: 'SCM010101',
                    pType: 'For Award - Get Compose Email',
                    pTblName: 'Mstr_EmailList',
                    pPlaceHolder: '',
                    pSearch: query
                },
                success: function (response) {
                    // Convert
                    const results = response.map(item => ({
                        value: item.Name,
                        text: item.Name
                    }));
                    callback(results);
                },
                error: function () {
                    callback();
                }
            });
        },
        onItemAdd: function () {
            this.setTextboxValue('');
        }
    });
    //tom select

    //tinyMCE
    tinymce.init({
        selector: 'textarea#txt0301MailContent',
        license_key: 'gpl',
        promotion: false,
        plugins: [
             "help", "insertdatetime", "lists",
            "preview", "table", "visualblocks",
        ],
        toolbar: "undo redo | styles | bold italic underline strikethrough | alignleft aligncenter alignright alignjustify | bullist numlist outdent indent | link image"
    });
    //tinyMCE
};
function fn0301Send_Ok(Btn) {
    // Disable the clicked button to avoid multiple clicks
    Btn.disabled = true;
    // Show loading indicator
    Btn.setAttribute('data-kt-indicator', 'on');
    const tinyContent = tinymce.get('txt0301MailContent').getContent({ format: 'text' });
    if (!tinyContent || tinyContent.trim() === "") {
        // Alert
        fnAlertOnly('Some fields are missing!', 'error', 'btn btn-danger');
        // Disable the clicked button to avoid multiple clicks
        Btn.disabled = false;
        // Hide loading indication
        Btn.removeAttribute('data-kt-indicator');
    } else {
        if (document.getElementById("ContentPlaceHolder1_hdnCodeSrs").value == "" && document.getElementById("ContentPlaceHolder1_hdnEmailSrs").value == "") {
            // Alert
            fnAlertOnly('Error capturing email!', 'error', 'btn btn-danger');
            // Disable the clicked button to avoid multiple clicks
            Btn.disabled = false;
            // Hide loading indication
            Btn.removeAttribute('data-kt-indicator');
        } else {
            $.ajax({
                type: "POST",
                url: "SCM000011.ashx",
                data: {
                    'pFormCode': 'SCM010101',
                    'pType': 'For Award - Email (COF)',
                    'pID': document.getElementById("ContentPlaceHolder1_hdnID").value,
                    'pCodeSrs': document.getElementById("ContentPlaceHolder1_hdnCodeSrs").value,
                    'pEmailSrs': document.getElementById("ContentPlaceHolder1_hdnEmailSrs").value,
                    'pContent': encodeURIComponent(tinymce.get("txt0301MailContent").getContent()),
                    'pDateFrom': document.getElementById("tbx0301DateFrom").value,
                    'pDateTo': document.getElementById("tbx0301DateTo").value,
                    'pCC': document.getElementById("txt0301ComposeCC").value
                },
                success: function (response) {
                    if (response[0].oReturn != "") {
                        fnAlertOnly(response[0].oReturn, 'warning', 'btn btn-warning');
                        // Disable the clicked button to avoid multiple clicks
                        Btn.disabled = false;
                        // Hide loading indication
                        Btn.removeAttribute('data-kt-indicator');
                    } else {
                        fn01AlertOnly('Sucessfully endorsed a project!', 'success', 'btn btn-success');
                        // Disable the clicked button to avoid multiple clicks
                        Btn.disabled = false;
                        // Hide loading indication
                        Btn.removeAttribute('data-kt-indicator');

                        //modal
                        $("#mdl0301Record").modal("hide");
                        $("#mdl0301Mail").modal("hide");

                        //reset
                        tinymce.get('txt0301MailContent').setContent('');
                        document.getElementById("ContentPlaceHolder1_hdnCodeSrs").value = "";
                        document.getElementById("ContentPlaceHolder1_hdnEmailSrs").value = "";
                        document.getElementById("tbx0301DateFrom").value = "";
                        document.getElementById("tbx0301DateTo").value = "";

                        //bind
                        fn03Contractor(document.getElementById("ContentPlaceHolder1_hdnMode").value, document.getElementById("ContentPlaceHolder1_hdnID").value);
                    }
                }
            });
        };
    };
};
function fn0301View(pCode) {
    // Ajax
    $.ajax({
        type: "POST",
        url: "SCM000011.ashx",
        data: {
            'pFormCode': 'SCM010101',
            'pType': 'For Award - Get Contractor (List - Project)',
            'pCode': pCode
        },
        success: function (response) {
            grid02Api.setGridOption("rowData", response);
        },
        complete: function (response) {
            grid02Api.setGridOption("loading", false);
        }
    });

    // AG Grid
    let gridDiv = document.querySelector('#table0302Record');
    let gridOptions;

    // Destroy old grid if exists
    gridDiv.innerHTML = "";

    const gridTheme = agGrid.themeQuartz.withParams({
        wrapperBorder: true,
        headerRowBorder: false,
    });

    gridOptions = {
        onRowClicked: params => {
            window.open(params.data.Link, '_blank').focus();
        },
        theme: gridTheme,
        suppressCellFocus: true,
        suppressDragLeaveHidesColumns: true,
        enableCellTextSelection: true,
        rowSelection: 'multiple',
        loading: true,
        columnDefs: [

            {
                headerName: "ID",
                field: "ID",
                filter: 'agTextColumnFilter',
                width: 150,
                tooltipField: "ID",
                cellStyle: { fontWeight: 'bold' }
            },
            {
                headerName: "Project",
                field: "Project",
                filter: 'agTextColumnFilter',
                tooltipField: "Project",
                flex: 1,
                minWidth: 220
            },
            {
                headerName: "Category",
                field: "Category",
                filter: 'agTextColumnFilter',
                width: 200,
                tooltipField: "Category"
            },
            {
                headerName: "Contract Price",
                field: "ContractPrice",
                filter: 'agTextColumnFilter',
                cellClass: "text-end",
                width: 180,
                tooltipField: "ContractPrice"
            },
            {
                headerName: "Name",
                field: "Name",
                filter: 'agTextColumnFilter',
                width: 180,
                tooltipField: "Name"
            },
            {
                headerName: "Status",
                field: "Status",
                filter: 'agTextColumnFilter',
                width: 120,
                tooltipField: "Status"
            },
            {
                headerName: "Date",
                field: "Date",
                filter: 'agTextColumnFilter',
                width: 120,
                tooltipField: "Date"
            }

        ],
        rowData: [],
        pagination: false,
    };
    grid02Api = agGrid.createGrid(gridDiv, gridOptions);

    // Modal
    $("#mdl0302Record").modal("show");
};
function fn0301Award(pID, pCode, pStatus) {
    // Table
    var table0401Attachment = $('#table0401Attachment').DataTable();
    var table0301Contractor = $('#table0301Contractor').DataTable();
    var tbl0301ColStatus = table0301Contractor
        .column(4)
        .data()
        .toArray();

    // Validate
    if (table0401Attachment.rows().count() == 0) {
        Swal.close();
        fnAlertOnly('Some fields are missing!', 'error', 'btn btn-danger');
        return;
    } else if (tbl0301ColStatus.includes('Awarded')) {
        Swal.close();
        fnAlertOnly('Already awarded the project!', 'error', 'btn btn-danger');
        return;
    } else if (pStatus == "Cancelled" || pStatus == "Declined") {
        Swal.close();
        fnAlertOnly('Project endorsed was already declined!', 'error', 'btn btn-danger');
        return;
    } else {
        // Swal
        Swal.fire({
            text: 'Proceed in awarding?',
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
                //reset
                document.getElementById("ContentPlaceHolder1_tbx0303Code").value = "";
                document.getElementById("tbx0303NTPNo").value == "";
                document.getElementById("tbx0303NTPDate").value == "";
                document.getElementById("tbx0303POCStart").value == "";

                //set
                document.getElementById("ContentPlaceHolder1_tbx0303Code").value = pCode;

                //modal
                $("#mdl0303Award").modal("show");
            };
        });
    };
};
function fn0301Update(pID, pCode, pStatus) {
    // Table
    var table0401Attachment = $('#table0401Attachment').DataTable();
    var table0301Contractor = $('#table0301Contractor').DataTable();
    var tbl0301ColStatus = table0301Contractor
        .column(4)
        .data()
        .toArray();

    // Validate
    if (table0401Attachment.rows().count() == 0) {
        Swal.close();
        fnAlertOnly('Some fields are missing!', 'error', 'btn btn-danger');
        return;
    } else if (tbl0301ColStatus.includes('Awarded')) {
        Swal.close();
        fnAlertOnly('Already awarded the project!', 'error', 'btn btn-danger');
        return;
    } else if (pStatus == "Cancelled" || pStatus == "Declined") {
        Swal.close();
        fnAlertOnly('Project endorsed was already declined!', 'error', 'btn btn-danger');
        return;
    } else {
        // Ajax
        $.ajax({
            type: "POST",
            url: "SCM000011.ashx",
            data: {
                'pFormCode': 'SCM010101',
                'pType': 'For Award - Get Contractor (Deadline)',
                'pID': pID,
                'pCode': pCode
            },
            success: function (response) {
                document.getElementById("ContentPlaceHolder1_tbx0304Code").value = pCode;
                document.getElementById("tbx0304DateFrom").value = response[0].DateFrom;
                document.getElementById("tbx0304DateTo").value = response[0].DateTo;

                //modal
                $("#mdl0304Update").modal("show");
            }
        });

    };
};
function fn0303Submit_Ok(Btn) {
    // Disable the clicked button to avoid multiple clicks
    Btn.disabled = true;
    // Show loading indicator
    Btn.setAttribute('data-kt-indicator', 'on');

    // Table
    var table0401Attachment = $('#table0401Attachment').DataTable();

    if (document.getElementById("tbx0303NTPNo").value == "") {
        Swal.close();
        fnAlertOnly('Some fields are missing!', 'error', 'btn btn-danger');
        Btn.disabled = false;
        Btn.removeAttribute('data-kt-indicator');
        return;
    } else if (document.getElementById("tbx0303NTPDate").value == "") {
        Swal.close();
        fnAlertOnly('Some fields are missing!', 'error', 'btn btn-danger');
        Btn.disabled = false;
        Btn.removeAttribute('data-kt-indicator');
        return;
    } else if (document.getElementById("tbx0303POCStart").value == "") {
        Swal.close();
        fnAlertOnly('Some fields are missing!', 'error', 'btn btn-danger');
        Btn.disabled = false;
        Btn.removeAttribute('data-kt-indicator');
        return;
    };

    if (table0401Attachment.rows().count() == 0) {
        Swal.close();
        fnAlertOnly('Some fields are missing!', 'error', 'btn btn-danger');
        Btn.disabled = false;
        Btn.removeAttribute('data-kt-indicator');
        return;
    };

    // Ajax
    $.ajax({
        type: "POST",
        url: "SCM000011.ashx",
        data: {
            'pFormCode': 'SCM010101',
            'pType': 'For Award - Get Contractor (Awarded)',
            'pID': document.getElementById("ContentPlaceHolder1_hdnID").value,
            'pCode': document.getElementById("ContentPlaceHolder1_tbx0303Code").value,
            'pNTPNo': document.getElementById("tbx0303NTPNo").value,
            'pNTPDate': document.getElementById("tbx0303NTPDate").value,
            'pPOCStart': document.getElementById("tbx0303POCStart").value
        },
        success: function (response) {
            fn01AlertOnly('Sucessfully awarded a project!', 'success', 'btn btn-success');
            document.getElementById("ContentPlaceHolder1_tbx0303Code").value = "";
            document.getElementById("tbx0303NTPNo").value = "";
            document.getElementById("tbx0303NTPDate").value = "";
            document.getElementById("tbx0303POCStart").value = "";
            //modal
            $("#mdl0303Award").modal("hide");

            //bind
            fn03Contractor(document.getElementById("ContentPlaceHolder1_hdnMode").value, document.getElementById("ContentPlaceHolder1_hdnID").value);
        }
    });

};
function fn0304Submit_Ok(Btn) {
    // Disable the clicked button to avoid multiple clicks
    Btn.disabled = true;
    // Show loading indicator
    Btn.setAttribute('data-kt-indicator', 'on');
    const dateFrom = new Date(document.getElementById("tbx0304DateFrom").value);
    const dateTo = new Date(document.getElementById("tbx0304DateTo").value);

    // Validate
    if (dateFrom > dateTo) {
        // Alert
        fnAlertOnly('Please select a valid date range. "Date To" cannot be earlier than "Date From".', 'error', 'btn btn-danger');
        // Disable the clicked button to avoid multiple clicks
        Btn.disabled = false;
        // Hide loading indication
        Btn.removeAttribute('data-kt-indicator');

    } else if (document.getElementById("tbx0304DateFrom").value == "" || document.getElementById("tbx0304DateTo").value == "") { 
        // Alert
        fnAlertOnly('Some fields are missing!', 'error', 'btn btn-danger');
        // Disable the clicked button to avoid multiple clicks
        Btn.disabled = false;
        // Hide loading indication
        Btn.removeAttribute('data-kt-indicator');

    } else {
        // Swal
        Swal.fire({
            text: 'Update set deadline?',
            icon: 'question',
            iconColor: '#0095e8',
            buttonsStyling: false,
            showCancelButton: true,
            confirmButtonText: "Yes",
            cancelButtonText: 'Cancel',
            focusConfirm: false, 
            returnFocus: false, 
            customClass: {
                confirmButton: 'btn btn-sm btn-info min-w-100px',
                cancelButton: 'btn btn-sm btn-light-danger min-w-100px'
            }
        }).then((result) => {
            if (result.isConfirmed) {

                // Ajax
                $.ajax({
                    type: "POST",
                    url: "SCM000011.ashx",
                    data: {
                        'pFormCode': 'SCM010101',
                        'pType': 'For Award - Update Contractor (Deadline)',
                        'pID': document.getElementById("ContentPlaceHolder1_hdnID").value,
                        'pCode': document.getElementById("ContentPlaceHolder1_tbx0304Code").value,
                        'pDateFrom': document.getElementById("tbx0304DateFrom").value,
                        'pDateTo': document.getElementById("tbx0304DateTo").value
                    },
                    success: function (response) {
                        fn01AlertOnly('Sucessfully updated deadline!', 'success', 'btn btn-success');
                        document.getElementById("ContentPlaceHolder1_tbx0304Code").value = "";
                        document.getElementById("tbx0304DateFrom").value = "";
                        document.getElementById("tbx0304DateTo").value = "";
                        // Disable the clicked button to avoid multiple clicks
                        Btn.disabled = false;
                        // Hide loading indication
                        Btn.removeAttribute('data-kt-indicator');
                        //modal
                        $("#mdl0304Update").modal("hide");
                    }
                });
            } else {
                // Disable the clicked button to avoid multiple clicks
                Btn.disabled = false;
                // Hide loading indication
                Btn.removeAttribute('data-kt-indicator');

            };
        });
    }

};
function fn0301Declined(pID, pCode, pStatus) {
    // Validate
    if (pStatus == "Cancelled" || pStatus == "Declined") {
        fnAlertOnly('Project endorsed was already declined!', 'error', 'btn btn-danger');
    } else if (pStatus == "Awarded") { 
        fnAlertOnly('Already awarded the project!', 'error', 'btn btn-danger');
    } else {
        // Swal
        Swal.fire({
            text: 'Decline project?',
            icon: 'question',
            iconColor: '#0095e8',
            buttonsStyling: false,
            showCancelButton: true,
            confirmButtonText: "Yes",
            cancelButtonText: 'Cancel',
            focusConfirm: false,
            returnFocus: false,
            customClass: {
                confirmButton: 'btn btn-sm btn-info min-w-100px',
                cancelButton: 'btn btn-sm btn-light-danger min-w-100px'
            }
        }).then((result) => {
            if (result.isConfirmed) {

                // Ajax
                $.ajax({
                    type: "POST",
                    url: "SCM000011.ashx",
                    data: {
                        'pFormCode': 'SCM010101',
                        'pType': 'For Award - Update Contractor (Decline)',
                        'pID': pID,
                        'pCode': pCode
                    },
                    success: function (response) {
                        fnAlertOnly('Sucessfully decline the project!', 'success', 'btn btn-success');
                        fn03Contractor(document.getElementById("ContentPlaceHolder1_hdnMode").value, document.getElementById("ContentPlaceHolder1_hdnID").value);
                    }
                });

            };
        });
    }
};
function fn0301ViewNote(pID, pCode) {
    // Ajax
    $.ajax({
        type: "POST",
        url: "SCM000011.ashx",
        data: {
            'pFormCode': 'SCM010101',
            'pType': 'For Award - Get Contractor Note (Decline)',
            'pID': pID,
            'pCode': pCode
        },
        success: function (response) {
            //reset
            document.getElementById("ContentPlaceHolder1_tbx0305Code").value = pCode;
            document.getElementById("tbx0305Note").value = response[0].Note;

            //modal
            $("#mdl0305Note").modal("show");
        }
    });
};
function fn0305ReOpen_Ok(Btn) {
    // Disable the clicked button to avoid multiple clicks
    Btn.disabled = true;
    // Show loading indicator
    Btn.setAttribute('data-kt-indicator', 'on');
    // Swal
    Swal.fire({
        text: 'Re-open status?',
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

            // Ajax
            $.ajax({
                type: "POST",
                url: "SCM000011.ashx",
                data: {
                    'pFormCode': 'SCM010101',
                    'pType': 'For Award - Get Contractor Status (Re-Open)',
                    'pID': document.getElementById("ContentPlaceHolder1_hdnID").value,
                    'pCode': document.getElementById("ContentPlaceHolder1_tbx0305Code").value
                },
                success: function (response) {
                    fnAlertOnly('Sucessfully re-open the project!', 'success', 'btn btn-success');
                    fn03Contractor(document.getElementById("ContentPlaceHolder1_hdnMode").value, document.getElementById("ContentPlaceHolder1_hdnID").value);
                    //modal
                    $("#mdl0305Note").modal("hide");
                }
            });

        } else {
            // Disable the clicked button to avoid multiple clicks
            Btn.disabled = false;
            // Hide loading indication
            Btn.removeAttribute('data-kt-indicator');
        }
    });
};
//function - Contractor

//function - Notice Attachment
function fn04Attachment(pMode, pID) {
    $.ajax({
        type: "POST",
        url: "SCM000011.ashx",
        data: {
            'pFormCode': 'SCM010101',
            'pType': 'Upload - Get Record (Notice)',
            'pID': pID
        },
        success: function (response) {
            //display loader
            document.getElementById("div0401LoaderAttachment").style.display = "";
            //display loader

            $('#table0401Attachment').DataTable().destroy();

            //disable column type detection
            DataTable.types().forEach(type => {
                DataTable.type(type, 'detect', () => false);
            });
            //disable column type detection

            //sort date by yyyy/mm/dd
            $.fn.dataTable.moment('MM/DD/YYYY');
            //sort date by yyyy/mm/dd

            //datatable
            var table0401Attachment = $("#table0401Attachment").DataTable({
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
            $('#tbx0401FindAttachment').on('keyup', function () {
                table0401Attachment.search(this.value).draw();
            });
            //search

            //hide loader
            document.getElementById("div0401LoaderAttachment").style.display = "none";
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
function fn0401Download(pFormCode, pID, pFileName) {
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
            url: "SCM000011.ashx",
            data: {
                'pFormCode': "SCM010101",
                'pType': 'Upload - Download (Notice)',
                'pID': pID,
                'pFileName': pFileName
            },
            success: function (response) {
                window.open(response[0].View, "_blank");
            },
        });
    };
};
function fn0401Delete(pFormCode, pID, pFileName) {
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
            url: "SCM000011.ashx",
            data: {
                'pFormCode': "SCM010101",
                'pType': 'Upload - Delete (Notice)',
                'pID': pID,
                'pFileName': pFileName
            },
            success: function (response) {
                fnAlertOnly('File successfully removed!', 'success', 'btn btn-success');
                fn04Attachment(document.getElementById('ContentPlaceHolder1_hdnMode').value, pID);
            },
        });
    };
};
//function - Notice Attachment

function pageLoad(sender, args) { InitialiseSettings(); }
function InitialiseSettings() {
    jQuery(function ($) {

        //dropdown
        $('[data-kt-repeater="select2"]').select2();
        //dropdown

        //date
        $('[data-kt-repeater="datepicker"]').each(function () {
            // destroy old instance
            if (this._flatpickr) {
                this._flatpickr.destroy();
            }

            flatpickr(this, {
                dateFormat: "m/d/Y",
                allowInput: true,
                clickOpens: false 
            });

            // manual trigger
            $(this).on('mousedown', function (e) {

                // prevent
                e.stopPropagation();

                if (this._flatpickr) {
                    this._flatpickr.open();
                }
            });
        });
        //date

        //dropzone
        Dropzone.autoDiscover = false;

        //attachment
        var myDropzone = new Dropzone("#divDropzone", {
            url: "HND010101.ashx?FormCode=FRM000009&ID=" + document.getElementById("ContentPlaceHolder1_hdnID").value + "&Type=Project",
            autoProcessQueue: false,
            parallelUploads: 5,
            maxFilesize: 10,
            maxFiles: 5,
            acceptedFiles: ".pdf,.PDF",
            addRemoveLinks: true,
            success: function (file, response) {
                var imgName = response;
                file.previewElement.classList.add("dz-success");
                var Btn = document.getElementById('btn9801Add');
                Btn.disabled = false;
                Btn.removeAttribute('data-kt-indicator');
                $('#mdl9801Upload').modal('hide');
                fn02Attachment(document.getElementById('ContentPlaceHolder1_hdnMode').value, document.getElementById('ContentPlaceHolder1_hdnID').value);
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
                    myDropzone.options.url = "HND010101.ashx?FormCode=FRM000009&ID=" + document.getElementById("ContentPlaceHolder1_hdnID").value + "&Type=Project";
                    myDropzone.processQueue();
                    resolve();
                });
            };
        });
        //attachment

        //notice
        var my01Dropzone = new Dropzone("#div01Dropzone", {
            url: "HND010101.ashx?FormCode=FRM000009&ID=" + document.getElementById("ContentPlaceHolder1_hdnID").value + "&Type=Notice",
            autoProcessQueue: false,
            parallelUploads: 5,
            maxFilesize: 10,
            maxFiles: 5,
            acceptedFiles: ".pdf,.PDF",
            addRemoveLinks: true,
            success: function (file, response) {
                var imgName = response;
                file.previewElement.classList.add("dz-success");
                var Btn = document.getElementById('btn9901Add');
                Btn.disabled = false;
                Btn.removeAttribute('data-kt-indicator');
                $('#mdl9901Upload').modal('hide');
                fn04Attachment(document.getElementById('ContentPlaceHolder1_hdnMode').value, document.getElementById('ContentPlaceHolder1_hdnID').value);
                fn01AlertOnly('File successfully uploaded.', 'success', 'btn btn-success');
            },
            error: function (file, response) {
                file.previewElement.classList.add("dz-error");
            }
        });
        my01Dropzone.on("addedfile", function (file) {
            FileCount = FileCount + 1;
        });
        my01Dropzone.on("removedfile", function (file) {
            FileCount = FileCount - 1;
        });
        $('#btn99Add').on('click', function (e) {
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
                        my01Dropzone.removeAllFiles();
                        FileCount = 0;
                        $('#mdl9901Upload').modal('show');
                    } else {
                        fn01AlertOnly(response[0].oReturn, 'error', 'btn btn-danger');
                    }; 0
                });
            }

        });
        $('#btn9901Add').on('click', function (e) {
            if (FileCount > 0) {
                fnFRMValidateRecord("02Files", "Add", document.getElementById('ContentPlaceHolder1_hdnID').value, "", "", function (response) {
                    if (response[0].Msg == "") {
                        btn9901Add();
                    } else {
                        fn01AlertOnly(response[0].oReturn, 'error', 'btn btn-danger');
                    };
                });
            } else {
                fn01AlertOnly('Attach at least one file to proceed!', 'error', 'btn btn-danger');
            };
            async function btn9901Add() {
                var Btn = document.getElementById('btn9901Add');
                Btn.disabled = true;
                Btn.setAttribute('data-kt-indicator', 'on');
                await btn9901Add_Await(Btn);
            };
            async function btn9901Add_Await(Btn) {
                return new Promise(resolve => {
                    my01Dropzone.options.url = "HND010101.ashx?FormCode=FRM000009&ID=" + document.getElementById("ContentPlaceHolder1_hdnID").value + "&Type=Notice";
                    my01Dropzone.processQueue();
                    resolve();
                });
            };
        });
        //notice

        //dropzone

        fn01Load();
    });
};