//load page
function pageLoad(sender, args) { InitialiseSettings(); }
function InitialiseSettings() {
    jQuery(function ($) {
        fn02Load();
        fn02tinyMCE();
    });
}
//load page

//general
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

//load
function fn02Load() {
    //Ajax
    $.ajax({
        type: "POST",
        url: "HNDSCM.ashx",
        data: {
            'FormCode': 'SCM170000',
            'Type': 'Get - Record - Announcement'
        },
        success: function (response) {

            $('#table01Record').DataTable().destroy();

            //disable column type detection
            DataTable.types().forEach(type => {
                DataTable.type(type, 'detect', () => false);
            });
            //disable column type detection

            //sort date by yyyy/mm/dd
            $.fn.dataTable.moment('MM/DD/YYYY');
            //sort date by yyyy/mm/dd

            //datatable
            var table01Record = $("#table01Record").DataTable({
                processing: true,
                bFilter: true,
                bPaginate: true,
                bInfo: false,
                paging: true,
                scrollY: '62.3vh',
                scrollCollapse: true,
                lengthChange: true,
                pageLength: 25,
                select: true,
                data: response,
                columns: [
                    { data: 'Action' },
                    { data: 'Title', className: 'tbody-nowrap-auto' },
                    { data: 'Date', className: 'tbody-nowrap-auto text-end' }
                ],
                rowId: 'rowId',
                columnDefs: [
                    { targets: 0, orderable: false },
                    { targets: 1, orderable: false },
                    { targets: 2, orderable: false }
                ],

            });
            //datatable

            //search
            $('#tbx01Find').on('keyup', function () {
                var value = $(this).val().trim();
                var table = table01Record;

                table.search(value).draw();

                var anyVisible = table.rows({ filter: 'applied' }).data().length > 0;

                var noResult = document.getElementById('noResults');
                if (!anyVisible && value !== '') {
                    noResult.classList.remove('d-none');
                } else {
                    noResult.classList.add('d-none');
                }
            });
            //search

            //hide loader
            document.getElementById("div01Loader").style.display = "none";
            //hide loader
        }
    });
}
function fn02tinyMCE() {
    tinymce.init({
        selector: 'textarea#compose_message',
        highlight_on_focus: false, // Removes the default blue focus outline
        branding: false,      // removes the "Powered by Tiny" text
        statusbar: false,      // removes the entire bottom bar (optional)
        license_key: 'gpl',
        promotion: false,
        plugins: [
            "help", "insertdatetime", "lists",
            "preview", "table", "visualblocks",
        ],
        toolbar: "undo redo | styles | bold italic underline strikethrough | alignleft aligncenter alignright alignjustify | bullist numlist outdent indent | link image",
        init_instance_callback: function (editor) {
            const container = editor.getContainer();
            container.style.border = 'none';
            container.style.boxShadow = 'none';
            container.style.outline = 'none';
            container.style.zIndex = '0';
        }
    });
};
//load

//add
function fn02Add(Mode) {
    if (Mode == "ADD") {
        document.getElementById("compose_title").value = "";
        tinymce.get('compose_message').setContent('');
        document.getElementById("btn02Submit").classList.remove("d-none");
        document.getElementById("btn02Edit").classList.add("d-none");
        $('#mdl01Compose').modal("show");
    }
};
//add

//view
function fn02View(ID) {
    //Ajax
    $.ajax({
        type: "POST",
        url: "HNDSCM.ashx",
        data: {
            'FormCode': 'SCM170000', 
            'Type': 'View - Record - Announcement',
            'pID': ID
        },
        success: function (response) {
            document.getElementById("spn02Title").innerText = response[0].Title;
            document.getElementById("spn02Date").innerText = response[0].Date;
            document.getElementById("div02Content").innerHTML = response[0].Message;
            $("#mdl01View").modal("show");
        }
    });
};
//view

//edit
function fn02Edit(ID, Mode) {
    if (Mode == "UPD") {
        $.ajax({
            type: "POST",
            url: "HNDSCM.ashx",
            data: {
                'FormCode': 'SCM170000',
                'Type': 'View - Record - Announcement',
                'pID': ID
            },
            success: function (response) {
                document.getElementById("hdnID").value = ID;
                document.getElementById("compose_title").value = response[0].Title;
                tinymce.get('compose_message').setContent(response[0].Message);
                document.getElementById("btn02Submit").classList.add("d-none");
                document.getElementById("btn02Edit").classList.remove("d-none");
                $('#mdl01Compose').modal("show");
            }
        });
    };
};
function fn02Edit_Ok(Btn) {
    // Disable the clicked button to avoid multiple clicks
    Btn.disabled = true;
    // Show loading indicator
    Btn.setAttribute('data-kt-indicator', 'on');
    //variable
    const compose = tinymce.get('compose_message').getContent({ format: 'text' });
    if (document.getElementById("compose_title").value == "") {
        fnAlertOnly('Title field is missing!', 'error', 'btn btn-error');
        // Disable the clicked button to avoid multiple clicks
        Btn.disabled = false;
        // Hide loading indication
        Btn.removeAttribute('data-kt-indicator');
    } else if (!compose || compose.trim() == "") {
        fnAlertOnly('Announcement content field is missing!', 'error', 'btn btn-error');
        // Disable the clicked button to avoid multiple clicks
        Btn.disabled = false;
        // Hide loading indication
        Btn.removeAttribute('data-kt-indicator');
    } else {
        Update_Question();
    };
    function Update_Question() {
        Swal.fire({
            text: 'Update announcement?',
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
                Update_Ok_Await()
            } else {
                // Disable the clicked button to avoid multiple clicks
                Btn.disabled = false;
                // Hide loading indication
                Btn.removeAttribute('data-kt-indicator');
            }
        });
    };
    function Update_Ok_Await() {
        //Ajax
        $.ajax({
            type: "POST",
            url: "HNDSCM.ashx",
            data: {
                'FormCode': 'SCM170000',
                'Type': 'Update - Record - Announcement',
                'pID': document.getElementById("hdnID").value,
                'pTitle': document.getElementById("compose_title").value,
                'pMessage': encodeURIComponent(tinymce.get("compose_message").getContent())
            },
            success: function (response) {
                fnAlertOnly('Announcement successfully updated!', 'success', 'btn btn-success');
                document.getElementById("hdnID").value = "";
                document.getElementById("compose_title").value = "";
                tinymce.get('compose_message').setContent('');
                fn02Load();
                $("#mdl01Compose").modal("hide");
                // Disable the clicked button to avoid multiple clicks
                Btn.disabled = false;
                // Hide loading indication
                Btn.removeAttribute('data-kt-indicator');
            }
        });
    };
};
//edit

//delete
function fn02Delete(ID) {
    Swal.fire({
        text: 'Delete announcement?',
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
            Delete_Ok_Await(ID)
        }
    });
    function Delete_Ok_Await(ID) {
        //Ajax
        $.ajax({
            type: "POST",
            url: "HNDSCM.ashx",
            data: {
                'FormCode': 'SCM170000',
                'Type': 'Delete - Record - Announcement',
                'pID': ID
            },
            success: function (response) {
                fnAlertOnly('Announcement successfully deleted!', 'success', 'btn btn-success');
                fn02Load();
            }
        });
    };
};
//delete

//submit
function fn02Submit(Btn) {
    // Disable the clicked button to avoid multiple clicks
    Btn.disabled = true;
    // Show loading indicator
    Btn.setAttribute('data-kt-indicator', 'on');
    //variable
    const compose = tinymce.get('compose_message').getContent({ format: 'text' });
    if (document.getElementById("compose_title").value == "") {
        fnAlertOnly('Title field is missing!', 'error', 'btn btn-error');
        // Disable the clicked button to avoid multiple clicks
        Btn.disabled = false;
        // Hide loading indication
        Btn.removeAttribute('data-kt-indicator');
    } else if (!compose || compose.trim() == "") {
        fnAlertOnly('Announcement content field is missing!', 'error', 'btn btn-error');
        // Disable the clicked button to avoid multiple clicks
        Btn.disabled = false;
        // Hide loading indication
        Btn.removeAttribute('data-kt-indicator');
    } else {
        Save_Question();
    };
    function Save_Question() {
        Swal.fire({
            text: 'Submit announcement?',
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
                Submit_Ok_Await()
            } else {
                // Disable the clicked button to avoid multiple clicks
                Btn.disabled = false;
                // Hide loading indication
                Btn.removeAttribute('data-kt-indicator');
            }
        });
    };
    function Submit_Ok_Await() {
        //Ajax
        $.ajax({
            type: "POST",
            url: "HNDSCM.ashx",
            data: {
                'FormCode': 'SCM170000', 
                'Type': 'Submit - Announcement',
                'pTitle': document.getElementById("compose_title").value,
                'pMessage': encodeURIComponent(tinymce.get("compose_message").getContent())
            },
            success: function (response) {
                fnAlertOnly('Announcement successfully submitted!', 'success', 'btn btn-success');
                document.getElementById("compose_title").value = "";
                tinymce.get('compose_message').setContent('');
                fn02Load();
                $("#mdl01Compose").modal("hide");
                // Disable the clicked button to avoid multiple clicks
                Btn.disabled = false;
                // Hide loading indication
                Btn.removeAttribute('data-kt-indicator');
            }
        });
    };
};
//submit