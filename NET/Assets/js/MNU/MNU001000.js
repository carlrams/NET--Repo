//general
function fn01Plugins() {
    $('[data-kt-repeater="select2"]').select2();
    $('[data-kt-repeater="datepicker"]').flatpickr({ dateFormat: "m/d/Y" });
}
function fn01EnterKey(evt, input) {
    try {
        var charCode = (evt.which) ? evt.which : event.keyCode;

        if (charCode == 46) {
            var txt = input.value;
            if (!(txt.indexOf(".") > -1)) {

                return true;
            }
        }
        if (charCode > 31 && (charCode < 48 || charCode > 57))
            return false;

        return true;
    } catch (w) {
        alert(w);
    }
};
function fn01FormatNumeric(input) {
    var RawValue = input.value.replace(/,/g, '');
    var Val = parseFloat(RawValue);
    if (isNaN(Val)) {
        Val = 0;
    }

    var NewVal = Val.toFixed(2);
    var Parts = NewVal.split('.');
    Parts[0] = Parts[0].replace(/\B(?=(\d{3})+(?!\d))/g, ',');
    input.value = Parts.join('.');
};
function fn01FormatInteger(input) {
    var RawValue = input.value.replace(/,/g, '');
    var Val = parseInt(RawValue);
    if (isNaN(Val)) {
        Val = 0;
    }
    input.value = Val;
};
function fn01ClearTime(ID) {
    const $flatpickr = $("#" + ID).flatpickr();
    $flatpickr.clear();

    //date
    $('[data-kt-repeater="datepicker"]').flatpickr({
        dateFormat: "m/d/Y"
    });
    //date

    //date
    $('[data-kt-repeater="timepicker"]').flatpickr({
        enableTime: true,
        noCalendar: true,
        dateFormat: "h:i K"
    });
    //date
};
function fn01AlertOnly(pMessasge, pIcon) {
    const Toast = Swal.mixin({
        toast: true,
        position: 'top-end',
        iconColor: 'white',
        customClass: {
            popup: 'colored-toast',
        },
        showConfirmButton: false,
        timer: 5000,
        timerProgressBar: true,
    })

    Toast.fire({
        icon: pIcon,
        title: pMessasge,
    })
};
function fn01IfExist(pTblName, pClmName, pTblCode, callBack) {
    $.ajax({
        type: "POST",
        url: "Assets/Handler/MNU/MNU001000HND.ashx",
        data: {
            'pFunction': 'Get-Info-01-Exist',
            'pTblName': pTblName,
            'pClmName': pClmName,
            'pTblCode': pTblCode,
        },
        success: function (response) {
            callBack(response);
        },
    });
};
function fn01ValidatePassword(pPassword, callBack) {
    $.ajax({
        type: "POST",
        url: "Assets/Handler/MNU/MNU001000HND.ashx",
        data: {
            'pFunction': 'Validate-Info-01-Password',
            'pPassword': pPassword,
        },
        success: function (response) {
            callBack(response);
        },
    });
};
function fn01Access(pFormCode, pRes, callBack) {
    $.ajax({
        type: "POST",
        url: "Assets/Handler/MNU/MNU001000HND.ashx",
        data: {
            'pFunction': 'Validate-Info-01-Access',
            'pFormCode': pFormCode,
            'pRes': pRes,
        },
        success: function (response) {
            callBack(response);
        },
    });
};
function fn01ValidateRecord(pTblName, pTblCode, pTblVal, pAction, callBack) {
    $.ajax({
        type: "POST",
        url: "Assets/Handler/MNU/MNU001000HND.ashx",
        data: {
            'pFunction': 'Validate-Info-01-Status',
            'pTblName': pTblName,
            'pTblCode': pTblCode,
            'pTblVal': pTblVal,
            'pAction': pAction
        },
        success: function (response) {
            callBack(response);
        },
    });
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
function fn01Lock(pFunction, pTblName, pTblCode, pLock, callBack) {
    $.ajax({
        type: "POST",
        url: "Assets/Handler/MNU/MNU001000HND.ashx",
        data: {
            'pFunction': pFunction,
            'pTblName': pTblName,
            'pTblCode': pTblCode,
            'pLock': pLock,
        },
        success: function (response) {
            callBack(response);
        },
    });
};
function fn01Delete(pFormCode, pTblName, pTblCode, callBack) {
    $.ajax({
        type: "POST",
        url: "Assets/Handler/MNU/MNU001000HND.ashx",
        data: {
            'pFunction': 'Delete-Record-01',
            'pFormCode': pFormCode,
            'pTblName': pTblName,
            'pTblCode': pTblCode
        },
        success: function (response) {
            callBack(response);
        },
    });
};
//general
