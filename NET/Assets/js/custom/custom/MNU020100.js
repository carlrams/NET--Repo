function MNU020100_MarkAllRead() {
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
    $.ajax({
        type: "POST",
        url: "HND000003.ashx",
        data: {
            'FormCode': 'MNU020100',
            'Type': 'Mark All Read'
        },
        success: function (response) {

            //get elements
            var ContentPlaceHolder1_divNotificationNew = document.getElementById("ContentPlaceHolder1_divNotificationNew");
            var ContentPlaceHolder1_divNotificationListNew = document.getElementById("ContentPlaceHolder1_divNotificationListNew");
            var ContentPlaceHolder1_divNotificationPrevious = document.getElementById("ContentPlaceHolder1_divNotificationPrevious");
            var ContentPlaceHolder1_divNotificationListPrevious = document.getElementById("ContentPlaceHolder1_divNotificationListPrevious");
            //get elements

            //update Unread notification
            ContentPlaceHolder1_divNotificationListNew.innerHTML = "";
            //update Unread notification

            //update Read notification
            ContentPlaceHolder1_divNotificationListPrevious.innerHTML = response;
            let text = ContentPlaceHolder1_divNotificationListPrevious.innerText;
            //update Read notification

            //display and hide
            ContentPlaceHolder1_divNotificationNew.style.display = "none";
            if (text == "") {
                ContentPlaceHolder1_divNotificationPrevious.style.display = "none";
            }
            //display hide
        },
    });
}

function MNU020100_MarkAsRead(ID) {
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
    $.ajax({
        type: "POST",
        url: "HND000003.ashx",
        data: {
            'FormCode': 'MNU020100',
            'Type': 'Mark As Read',
            'ID': ID
        },
        success: function (response) {

            //get elements
            var ContentPlaceHolder1_divNotificationNew = document.getElementById("ContentPlaceHolder1_divNotificationNew");
            var ContentPlaceHolder1_divNotificationListNew = document.getElementById("ContentPlaceHolder1_divNotificationListNew");
            var ContentPlaceHolder1_divNotificationPrevious = document.getElementById("ContentPlaceHolder1_divNotificationPrevious");
            var ContentPlaceHolder1_divNotificationListPrevious = document.getElementById("ContentPlaceHolder1_divNotificationListPrevious");
            //get elements

            //update Unread notification
            var ReadDiv = document.getElementById(ID.replace("ReadA", "ReadDiv"));
            ReadDiv.remove();
            let text = ContentPlaceHolder1_divNotificationListNew.innerText;
            //update Unread notification

            //update Read notification
            var CurrentInnerHtml = ContentPlaceHolder1_divNotificationListPrevious.innerHTML;
            var NewInnerHtml = response;
            ContentPlaceHolder1_divNotificationListPrevious.innerHTML = CurrentInnerHtml + ' ' + NewInnerHtml;
            //update Read notification

            //display and hide
            if (text == "") {
                ContentPlaceHolder1_divNotificationNew.style.display = "none";
            }
            ContentPlaceHolder1_divNotificationPrevious.style = "";
            //display hide

        },
    });
}

function MNU020100_MarkAsUnread(ID) {
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
    $.ajax({
        type: "POST",
        url: "HND000003.ashx",
        data: {
            'FormCode': 'MNU020100',
            'Type': 'Mark As Unread',
            'ID': ID
        },
        success: function (response) {

            //get elements
            var ContentPlaceHolder1_divNotificationNew = document.getElementById("ContentPlaceHolder1_divNotificationNew");
            var ContentPlaceHolder1_divNotificationListNew = document.getElementById("ContentPlaceHolder1_divNotificationListNew");
            var ContentPlaceHolder1_divNotificationPrevious = document.getElementById("ContentPlaceHolder1_divNotificationPrevious");
            var ContentPlaceHolder1_divNotificationListPrevious = document.getElementById("ContentPlaceHolder1_divNotificationListPrevious");
            //get elements

            //update Unread notification
            var CurrentInnerHtml = ContentPlaceHolder1_divNotificationListNew.innerHTML;
            var NewInnerHtml = response;
            ContentPlaceHolder1_divNotificationListNew.innerHTML = CurrentInnerHtml + ' ' + NewInnerHtml;
            //update Unread notification

            //update Read notification
            var UnreadDiv = document.getElementById(ID.replace("UnreadA", "UnreadDiv"));
            UnreadDiv.remove();
            let text = ContentPlaceHolder1_divNotificationListPrevious.innerText;
            //update Read notification

            //display and hide
            ContentPlaceHolder1_divNotificationNew.style.display = "";
            if (text == "") {
                ContentPlaceHolder1_divNotificationPrevious.style.display = "none";
            }
            //display hide
        },
    });
}