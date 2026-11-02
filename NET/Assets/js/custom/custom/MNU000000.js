
function MarkAllRead() {
    $.ajax({
        type: "POST",
        url: "HND000003.ashx",
        data: {
            'FormCode': 'MNU000000',
            'Type': 'Mark All Read'
        },
        success: function (response) {

            //get elements
            var spnNotifier = document.getElementById("spnNotifier");
            var divNotificationNothing = document.getElementById("divNotificationNothing");
            var divNotificationNew = document.getElementById("divNotificationNew");
            var divNotificationListNew = document.getElementById("divNotificationListNew");
            var divNotificationPrevious = document.getElementById("divNotificationPrevious");
            var divNotificationListPrevious = document.getElementById("divNotificationListPrevious");
            //get elements

            //update Unread notification
            divNotificationListNew.innerHTML = "";
            //update Unread notification

            //update Read notification
            divNotificationListPrevious.innerHTML = response;
            let text = divNotificationListPrevious.innerText;
            //update Read notification

            //display and hide
            spnNotifier.style.display = "none";
            divNotificationNothing.style.display = "";
            divNotificationNew.style.display = "none";
            if (text == "") {
                divNotificationPrevious.style.display = "none";
            }
            //display hide
        },
    });
}

function MarkAsRead(ID) {
    $.ajax({
        type: "POST",
        url: "HND000003.ashx",
        data: {
            'FormCode': 'MNU000000',
            'Type': 'Mark As Read',
            'ID': ID
        },
        success: function (response) {

            //get elements
            var spnNotifier = document.getElementById("spnNotifier");
            var divNotificationNothing = document.getElementById("divNotificationNothing");
            var divNotificationNew = document.getElementById("divNotificationNew");
            var divNotificationListNew = document.getElementById("divNotificationListNew");
            var divNotificationPrevious = document.getElementById("divNotificationPrevious");
            var divNotificationListPrevious = document.getElementById("divNotificationListPrevious");
            //get elements

            //update Unread notification
            var ReadDiv = document.getElementById(ID.replace("ReadA", "ReadDiv"));
            ReadDiv.remove();
            let text = divNotificationListNew.innerText;
            //update Unread notification

            //update Read notification
            var CurrentInnerHtml = divNotificationListPrevious.innerHTML;
            var NewInnerHtml = response;
            divNotificationListPrevious.innerHTML = CurrentInnerHtml + ' ' + NewInnerHtml;
            //update Read notification

            //display and hide
            if (text == "") {
                spnNotifier.style.display = "none";
                divNotificationNothing.style.display = "";
                divNotificationNew.style.display = "none";
            }
            divNotificationPrevious.style = "";
            //display hide

        },
    });
}

function MarkAsUnread(ID) {
    $.ajax({
        type: "POST",
        url: "HND000003.ashx",
        data: {
            'FormCode': 'MNU000000',
            'Type': 'Mark As Unread',
            'ID': ID
        },
        success: function (response) {

            //get elements
            var spnNotifier = document.getElementById("spnNotifier");
            var divNotificationNothing = document.getElementById("divNotificationNothing");
            var divNotificationNew = document.getElementById("divNotificationNew");
            var divNotificationListNew = document.getElementById("divNotificationListNew");
            var divNotificationPrevious = document.getElementById("divNotificationPrevious");
            var divNotificationListPrevious = document.getElementById("divNotificationListPrevious");
            //get elements

            //update Unread notification
            var CurrentInnerHtml = divNotificationListNew.innerHTML;
            var NewInnerHtml = response;
            divNotificationListNew.innerHTML = CurrentInnerHtml + ' ' + NewInnerHtml;
            //update Unread notification

            //update Read notification
            var UnreadDiv = document.getElementById(ID.replace("UnreadA", "UnreadDiv"));
            UnreadDiv.remove();
            let text = divNotificationListPrevious.innerText;
            //update Read notification

            //display and hide
            spnNotifier.style.display = "";
            divNotificationNothing.style.display = "none";
            divNotificationNew.style.display = "";
            if (text == "") {
                divNotificationPrevious.style.display = "none";
            }
            //display hide
        },
    });
}

function fnIfExist(pTblName, pClmName, pTblCode, callBack) {
    $.ajax({
        type: "POST",
        url: "HNDGEN.ashx",
        data: {
            'pType': 'If Exist',
            'pTblName': pTblName,
            'pClmName': pClmName,
            'pTblCode': pTblCode,
        },
        success: function (response) {
            callBack(response);
        },
    });
}

function fnAccess(pFormCode, pRes, callBack) {
    $.ajax({
        type: "POST",
        url: "HNDGEN.ashx",
        data: {
            'pType': 'Restriction',
            'pFormCode': pFormCode,
            'pRes': pRes,
        },
        success: function (response) {
            callBack(response);
        },
    });
}

function fnValidateRecord(pTblName, pTblCode, pTblVal, pAction, callBack) {
    $.ajax({
        type: "POST",
        url: "HNDGEN.ashx",
        data: {
            'pType': 'Validate - Record',
            'pTblName': pTblName,
            'pTblCode': pTblCode,
            'pTblVal': pTblVal,
            'pAction': pAction
        },
        success: function (response) {
            callBack(response);
        },
    });
}

function fnValidatePassword(pPassword, callBack) {
    $.ajax({
        type: "POST",
        url: "HNDGEN.ashx",
        data: {
            'pType': 'Validate - Password',
            'pPassword': pPassword,
        },
        success: function (response) {
            callBack(response);
        },
    });
}

function fnAlertOnly(pMessasge, pIcon, pClass) {
    const Toast = Swal.mixin({
        toast: true,
        position: 'top-end',
        iconColor: 'white',
        customClass: {
            popup: 'colored-toast',
        },
        showConfirmButton: false,
        showCloseButton: true,
        timer: 5000,
        timerProgressBar: true,
    })

    Toast.fire({
        icon: pIcon,
        title: pMessasge,
    })
};

function fnDelete(pFormCode, pTblName, pTblCode, callBack) {
    $.ajax({
        type: "POST",
        url: "HNDGEN.ashx",
        data: {
            'pType': 'Delete',
            'pFormCode': pFormCode,
            'pTblName': pTblName,
            'pTblCode': pTblCode
        },
        success: function (response) {
            callBack(response);
        },
    });
};

function fnLock(pType, pTblName, pTblCode, callBack) {
    $.ajax({
        type: "POST",
        url: "HNDGEN.ashx",
        data: {
            'pType': pType,
            'pTblName': pTblName,
            'pTblCode': pTblCode,
        },
        success: function (response) {
            callBack(response);
        },
    });
};

function fnEnterKey(evt, input) {
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

function fnFormatNumeric(input) {
    var RawValue = input.value.replace(/,/g, '');
    var Val = parseFloat(RawValue);
    if (isNaN(Val)) {
        Val = 0;
    }

    var NewVal = Val.toFixed(2);
    var Parts = NewVal.split('.');
    Parts[0] = Parts[0].replace(/\B(?=(\d{3})+(?!\d))/g, ',');
    input.value = Parts.join('.');
}

function fnClearTime(ID) {
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