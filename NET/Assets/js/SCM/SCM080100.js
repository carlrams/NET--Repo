
		//variable
		var FileCount = 0;
        //variable

        //numeric
        function formatNumber(value) {
            return new Intl.NumberFormat('en-US', {
                minimumFractionDigits: 2,
                maximumFractionDigits: 2
            }).format(value);
        };
        function fnEnterKeyNumber(event, inputId) {
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
        function fnFormatNumberAddQty(input) {
            var Qty = parseFloat(input.value.replace(/,/g, '')) || 0.00;
            var Cost = parseFloat(document.getElementById("ContentPlaceHolder1_hf010201Cost").value.replace(/,/g, '')) || 0.00;
            var Total = Qty * Cost;
            input.value = formatNumber(Qty);
            document.getElementById("ContentPlaceHolder1_hf010201Total").value = formatNumber(Total);
        };
        function fnFormatNumberUpdQty(input) {

            // Get Qty entered by the user
            var QtyText = input.value.replace(/,/g, '').trim();

            // Get PR Qty
            var PRQtyElement = document.getElementById("tbx010301PRQty");
            var PRQtyText = PRQtyElement ? PRQtyElement.value.replace(/,/g, '').trim() : "";

            // Get Cost
            var CostElement = document.getElementById("ContentPlaceHolder1_hf010301Cost");
            var CostText = CostElement ? CostElement.value.replace(/,/g, '').trim() : "";

            // Convert values to numbers
            var Qty = parseFloat(QtyText);
            var PRQty = parseFloat(PRQtyText);
            var Cost = parseFloat(CostText);

            // If Qty is empty or invalid
            if (isNaN(Qty)) {
                Qty = 0;
            }

            // Only limit Qty if PRQty has a valid value
            if (!isNaN(PRQty) && PRQty > 0) {
                if (Qty > PRQty) {
                    Qty = PRQty;
                }
            }

            // If Cost is empty or invalid
            if (isNaN(Cost)) {
                Cost = 0;
            }

            // Calculate total
            var Total = Qty * Cost;

            // Format Qty
            input.value = formatNumber(Qty);

            // Format Total
            var TotalElement = document.getElementById("ContentPlaceHolder1_hf010301Total");

            if (TotalElement) {
                TotalElement.value = formatNumber(Total);
            }
        }
        function fnFormatNumericIssuance(input, maxQty) {
            const rawVal = input.value.trim();
            let val = parseFloat(rawVal);
            if (isNaN(val) || rawVal === '') {
                input.value = '0.00';
                return;
            };
            if (val >= maxQty) {
                val = maxQty;
            };
            if (val < 0) val = 0;
            input.value = val.toFixed(2);
        }
        //numeric

		//general
		function fn01Load() {
            fnAccess('SCM080000', 'View', function (response) {
                if (response[0].oReturn == "1") {
                    fn0101LoadOverview(document.getElementById('ContentPlaceHolder1_hdnMode').value, document.getElementById('ContentPlaceHolder1_hdnID').value);
                    fn0102LoadParticular(document.getElementById('ContentPlaceHolder1_hdnMode').value, document.getElementById('ContentPlaceHolder1_hdnID').value);
                    fn0201LoadAttachment(document.getElementById('ContentPlaceHolder1_hdnMode').value, document.getElementById('ContentPlaceHolder1_hdnID').value);
                    fn0301LoadNotes(document.getElementById('ContentPlaceHolder1_hdnID').value);
                } else {
                    location.replace("MNU000022");
                };
            });
        };
        function fn01DisableButtons(pValue) {
            if (pValue == true) {
                document.getElementById("btn0101Refresh").classList.remove("btn-view");
                document.getElementById("btn0101Add").classList.remove("btn-add");
                document.getElementById("btn0102Add").classList.add("d-none");
                document.getElementById("btn0101Delete").classList.remove("btn-delete");
                document.getElementById("btn0101Edit").classList.remove("btn-edit");
                document.getElementById("btn0101Lock").classList.remove("btn-lock");
                document.getElementById("btn0101Unlock").classList.remove("btn-lock");
                document.getElementById("btn0101Post").classList.remove("btn-post");
                document.getElementById("btn0101Cancel").classList.remove("btn-cancel");
                document.getElementById("btn0101Tools").classList.remove("btn-secondary");
                document.getElementById("btn0201Add").classList.remove("btn-add");
                document.getElementById("btn0301Add").classList.remove("btn-add");
                const button = document.querySelectorAll('.action-button');
                for (const btn of button) {
                    btn.classList.remove("btn-active-light");
                    btn.disabled = pValue;
                }
            } else {
                document.getElementById("btn0101Refresh").classList.add("btn-view");
                document.getElementById("btn0101Add").classList.add("btn-add");
                document.getElementById("btn0102Add").classList.remove("d-none");
                document.getElementById("btn0102Add").classList.add("btn-add");
                document.getElementById("btn0101Delete").classList.add("btn-delete");
                document.getElementById("btn0101Edit").classList.add("btn-edit");
                document.getElementById("btn0101Lock").classList.add("btn-lock");
                document.getElementById("btn0101Unlock").classList.add("btn-lock");
                document.getElementById("btn0101Post").classList.add("btn-post");
                document.getElementById("btn0101Cancel").classList.add("btn-cancel");
                document.getElementById("btn0101Tools").classList.add("btn-secondary");
                document.getElementById("btn0201Add").classList.add("btn-add");
                document.getElementById("btn0301Add").classList.add("btn-add");
                const button = document.querySelectorAll('.action-button');
                for (const btn of button) {
                    btn.classList.add("btn-active-light");
                    btn.disabled = pValue;
                }
            }
            document.getElementById("btn0101Refresh").disabled = pValue;
            document.getElementById("btn0101Add").disabled = pValue;
            document.getElementById("btn0102Add").disabled = pValue;
            document.getElementById("btn0101Delete").disabled = pValue;
            document.getElementById("btn0101Edit").disabled = pValue;
            document.getElementById("btn0101Lock").disabled = pValue;
            document.getElementById("btn0101Unlock").disabled = pValue;
            document.getElementById("btn0101Post").disabled = pValue;
            document.getElementById("btn0101Cancel").disabled = pValue;
            document.getElementById("btn0101Tools").disabled = pValue;
            document.getElementById("btn0201Add").disabled = pValue;
            document.getElementById("btn0301Add").disabled = pValue;
        };
        function fn01Toggle(button) {
            // Find the closest wrapper and toggle the child menu
            const wrapper = button.closest('.action-toggle-wrapper');
            const toggleMenu = wrapper.querySelector('.toggle-menu');

            // Hide all other open toggle menus first
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
        function ddl0101Type_onchange(ddl0101Type) {
            document.getElementById("spn0101ChargeTo").classList.remove("required");
            $('#ddl0101ChargeTo').val('').trigger('change');
            document.getElementById("ddl0101ChargeTo").disabled = true;
            if (ddl0101Type.options[ddl0101Type.selectedIndex].value != "") {
                document.getElementById("spn0101ChargeTo").classList.add("required");
                ddl0101ChargeTo(ddl0101Type.options[ddl0101Type.selectedIndex].value, '');
                $('#ddl0101ChargeTo').val('').trigger('change');
                document.getElementById("ddl0101ChargeTo").disabled = false;
            };
        };
        function ddl0101ChargeTo(Type, ID) {
            $.ajax({
                type: "POST",
                url: "Assets/Handler/SCM/SCM080100HND.ashx",
                data: {
                    'FormCode': 'SCM080100',
                    'Type': 'Get Record : DTL',
                    'pTblName': 'Trxn_SIHdr(TrxnType)',
                    'pCode': Type,
                    'pPlaceHolder': 'Charge To',
                },
                success: function (response) {
                    var s = '';
                    for (var i = 0; i < response.length; i++) {
                        s += '<option value="' + response[i].ID + '">' + response[i].Name + '</option>';
                    }
                    $("#ddl0101ChargeTo").html(s);
                    $('#ddl0101ChargeTo').val(ID).trigger('change');
                },
            });
        };
        function ddl0101RequestedBy_onchange(ddl0101RequestedBy) {
            $.ajax({
                type: "POST",
                url: "Assets/Handler/SCM/SCM080100HND.ashx",
                data: {
                    'FormCode': 'SCM080100',
                    'Type': 'Stock Issuance : Get SI Location',
                    'pID': ddl0101RequestedBy.options[ddl0101RequestedBy.selectedIndex].value,
                },
                success: function (response) {
                    document.getElementById("ContentPlaceHolder1_hf0101RequestedBy").value = response[0].RequestedBy;
                    document.getElementById("ContentPlaceHolder1_hf0101DeptCode").value = response[0].DeptCode;
                    //document.getElementById("tbx0101DeliverTo").value = document.getElementById("ContentPlaceHolder1_hdnMode") == "UPD" ? response[0].Justification : "";
                    /*document.getElementById("tbx0101DeliverTo").value = response[0].Justification ? response[0].Justification : "";*/
                },
            });
        };
        function chkBox0201SINo(el) {
            if (el.checked) {
                document.getElementById("spn0101Date").classList.add("required");
                document.getElementById("tbx0101Date").value = new Date().toLocaleDateString('en-US', { year: 'numeric', month: '2-digit', day: '2-digit' });
                document.getElementById("spn0101Warehouse").classList.add("required");
                $('#ddl0101Warehouse').val('').trigger('change');
            } else {
                document.getElementById("spn0101Date").classList.remove("required");
                document.getElementById("tbx0101Date").value = "";
                document.getElementById("spn0101Warehouse").classList.remove("required");
                $('#ddl0101Warehouse').val('').trigger('change');
            }
        };
        function chkBox0201GPNo(el) {
            if (el.checked) {
                document.getElementById("spn0101AuthorizedBy").classList.add("required");
                $('#ddl0101AuthorizedBy').val('').trigger('change');
                document.getElementById("spn0101Location").classList.add("required");
                document.getElementById("tbx0101Location").readOnly = false;
            } else {
                document.getElementById("spn0101AuthorizedBy").classList.remove("required");
                $('#ddl0101AuthorizedBy').val('').trigger('change');
                document.getElementById("spn0101Location").classList.remove("required");
                document.getElementById("tbx0101Location").readOnly = true;
                document.getElementById("tbx0101Location").value = "";
            }
        };
		//general

        //overview
        function fn0101LoadOverview(pMode, pID) {
            if (pMode == "ADD") {
                //title
                document.getElementById("spn0101Title").innerText = "New Record";
                document.getElementById("spn0101ID").innerText = "000000000000";
                document.getElementById("spn0101Status").innerText = "New";
                if (document.getElementById("spn0101Status").innerText == "New") {
                    document.getElementById("spn0101Status").setAttribute("class", "badge badge-lg badge-record-new");
                } else if (document.getElementById("spn0101Status").innerText == "Locked") {
                    document.getElementById("spn0101Status").setAttribute("class", "badge badge-lg badge-record-locked");
                } else if (document.getElementById("spn0101Status").innerText == "Unlocked") {
                    document.getElementById("spn0101Status").setAttribute("class", "badge badge-lg badge-record-unlocked");
                } else if (document.getElementById("spn0101Status").innerText == "Posted") {
                    document.getElementById("spn0101Status").setAttribute("class", "badge badge-lg badge-record-posted");
                } else if (document.getElementById("spn0101Status").innerText == "Cancelled") {
                    document.getElementById("spn0101Status").setAttribute("class", "badge badge-lg badge-record-cancelled");
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
                document.getElementById("cbx0101Lock").checked = false;
                document.getElementById("cbx0101Post").checked = false;
                document.getElementById("cbx0101Rvrs").checked = false;
                //toolbar

                //content
                document.getElementById("div0101Detail").style.display = "none";
                document.getElementById("div0101Update").style.display = "";
                $('#ddl0101Type').val('').trigger('change');
                ddl0101Type_onchange(document.getElementById("ddl0101Type"));
                ddl0101Warehouse('');
                document.getElementById("tbx0101DeliverTo").value = "";
                document.getElementById("tbx0101Location").value = "";
                $('#ddl0101Warehouse').val('').trigger('change');
                ddl0101RequestedBy('');
                $('#ddl0101RequestedBy').val('').trigger('change');
                document.getElementById("div0101RequestedBy").classList.remove("d-none");
                document.getElementById("tbx0101RequestedBy").classList.add("d-none");
                ddl0101IssuedBy('');
                $('#ddl0101IssuedBy').val('').trigger('change');
                ddl0101AuthorizedBy('');
                $('#ddl0101AuthorizedBy').val('').trigger('change');
                document.getElementById("tbx0101TrxnNo").value = "";
                document.getElementById("tbx0101Date").value = new Date().toLocaleDateString('en-US', { year: 'numeric', month: '2-digit', day: '2-digit' });
                document.getElementById("tbx0101DateCreated").value = new Date().toLocaleDateString('en-US', { year: 'numeric', month: '2-digit', day: '2-digit' });
                document.getElementById("cbx0201SINo").checked = true;
                document.getElementById("cbx0201GPNo").checked = false; 
                document.getElementById("tbx0101UpdatedByName").value = "";
                document.getElementById("tbx0101UpdatedDate").value = "";
                document.getElementById("tbx0101LockedByName").value = "";
                document.getElementById("tbx0101LockedDate").value = "";
                document.getElementById("tbx0101PostedByName").value = "";
                document.getElementById("tbx0101PostedDate").value = "";
                document.getElementById("tbx0101CancelledByName").value = "";
                document.getElementById("tbx0101CancelledDate").value = "";
                document.getElementById("hdnCECode").value = "";
                document.getElementById("hdnWCode").value = "";
                //content
            } else if (pMode == "DTL") {
                $.ajax({
                    type: "POST",
                    url: "Assets/Handler/SCM/SCM080100HND.ashx",
                    data: {
                        'FormCode': 'SCM080100',
                        'Type': 'Stock Issuance - Get Info : DTL',
                        'pID': pID
                    },
                    success: function (response) {
                        //title
                        document.getElementById("spn0101Title").innerText = response[0].TrxnType;
                        document.getElementById("spn0101ID").innerText = response[0].SICode;
                        document.getElementById("spn0101Status").innerText = response[0].RecordStatus;
                        if (document.getElementById("spn0101Status").innerText == "New") {
                            document.getElementById("spn0101Status").setAttribute("class", "badge badge-lg badge-record-new");
                        } else if (document.getElementById("spn0101Status").innerText == "Locked") {
                            document.getElementById("spn0101Status").setAttribute("class", "badge badge-lg badge-record-locked");
                        } else if (document.getElementById("spn0101Status").innerText == "Unlocked") {
                            document.getElementById("spn0101Status").setAttribute("class", "badge badge-lg badge-record-unlocked");
                        } else if (document.getElementById("spn0101Status").innerText == "Posted") {
                            document.getElementById("spn0101Status").setAttribute("class", "badge badge-lg badge-record-posted");
                        } else if (document.getElementById("spn0101Status").innerText == "Cancelled") {
                            document.getElementById("spn0101Status").setAttribute("class", "badge badge-lg badge-record-cancelled");
                        };
                        //title

                        //toolbar
                        document.getElementById("i0101Edit").classList.add("la-pencil-alt");
                        document.getElementById("i0101Edit").classList.remove("la-save");
                        fn01DisableButtons(false);
                        if (response[0].Lock == "1") {
                            document.getElementById("cbx0101Lock").checked = true;
                        } else {
                            document.getElementById("cbx0101Lock").checked = false;
                        };
                        if (response[0].Post == "1") {
                            document.getElementById("cbx0101Post").checked = true;
                        } else {
                            document.getElementById("cbx0101Post").checked = false;
                        };
                        if (response[0].Rvrs == "1") {
                            document.getElementById("cbx0101Rvrs").checked = true;
                        } else {
                            document.getElementById("cbx0101Rvrs").checked = false;
                        };
                        //checkbox

                        //content
                        document.getElementById("div0101Detail").style.display = "";
                        document.getElementById("div0101Update").style.display = "none";
                        document.getElementById("lbl0101TrxnNo").innerText = response[0].SICode;
                        document.getElementById("lbl0101Type").innerText = response[0].TrxnType;
                        document.getElementById("lbl0101ChargeTo").innerText = response[0].TrxnName;
                        document.getElementById("lbl0101Warehouse").innerText = response[0].WhseName;
                        document.getElementById("ContentPlaceHolder1_hf0101Warehouse").value = response[0].WhseCode;
                        document.getElementById("cbx0101SINo").checked = response[0].SI;
                        document.getElementById("cbx0101GPNo").checked = response[0].GP;
                        document.getElementById("lbl0101SINo").innerText = response[0].SINo;
                        document.getElementById("lbl0101GPNo").innerText = response[0].GPNo;
                        document.getElementById("lbl0101SILocation").innerText = response[0].SILocation;
                        document.getElementById("lbl0101GPLocation").innerText = response[0].GPLocation;
                        document.getElementById("lbl0101Date").innerText = response[0].SIDate;
                        document.getElementById("lbl0101DateCreated").innerText = response[0].SIDateCreated;
                        document.getElementById("lbl0101RequestedBy").innerText = response[0].RequestedByName;
                        document.getElementById("ContentPlaceHolder1_hf0101RequestedByCode").value = response[0].RequestedByCode;
                        document.getElementById("lbl0101IssuedBy").innerText = response[0].IssuedByName;
                        document.getElementById("lbl0101AuthorizedBy").innerText = response[0].AuthorizedByName;
                        document.getElementById("lbl0101UpdatedByName").innerText = (response[0].UpdatedByName == "" || response[0].UpdatedByName == null) ? "-" : response[0].UpdatedByName;
                        document.getElementById("lbl0101UpdatedDate").innerText = (response[0].UpdatedDate == "" || response[0].UpdatedDate == null) ? "-" : response[0].UpdatedDate;
                        document.getElementById("lbl0101LockedByName").innerText = (response[0].LockedByName == "" || response[0].LockedByName == null) ? "-" : response[0].LockedByName;
                        document.getElementById("lbl0101LockedDate").innerText = (response[0].LockedDate == "" || response[0].LockedDate == null) ? "-" : response[0].LockedDate;
                        document.getElementById("lbl0101PostedByName").innerText = (response[0].PostedByName == "" || response[0].PostedByName == null) ? "-" : response[0].PostedByName;
                        document.getElementById("lbl0101PostedDate").innerText = (response[0].PostedDate == "" || response[0].PostedDate == null) ? "-" : response[0].PostedDate;
                        document.getElementById("lbl0101CancelledByName").innerText = (response[0].CancelledByName == "" || response[0].CancelledByName == null) ? "-" : response[0].CancelledByName;
                        document.getElementById("lbl0101CancelledDate").innerText = (response[0].ReversedDate == "" || response[0].ReversedDate == null) ? "-" : response[0].ReversedDate;
                        //content

                    },
                });
            } else if (pMode == "UPD") {
                $.ajax({
                    type: "POST",
                    url: "Assets/Handler/SCM/SCM080100HND.ashx",
                    data: {
                        'FormCode': 'SCM080100',
                        'Type': 'Stock Issuance - Get Info : DTL',
                        'pID': pID
                    },
                    success: function (response) {
                        //title
                        document.getElementById("spn0101Title").innerText = response[0].TrxnType;
                        document.getElementById("spn0101ID").innerText = response[0].SICode;
                        document.getElementById("spn0101Status").innerText = response[0].RecordStatus;
                        if (document.getElementById("spn0101Status").innerText == "New") {
                            document.getElementById("spn0101Status").setAttribute("class", "badge badge-lg badge-record-new");
                        } else if (document.getElementById("spn0101Status").innerText == "Locked") {
                            document.getElementById("spn0101Status").setAttribute("class", "badge badge-lg badge-record-locked");
                        } else if (document.getElementById("spn0101Status").innerText == "Unlocked") {
                            document.getElementById("spn0101Status").setAttribute("class", "badge badge-lg badge-record-unlocked");
                        } else if (document.getElementById("spn0101Status").innerText == "Posted") {
                            document.getElementById("spn0101Status").setAttribute("class", "badge badge-lg badge-record-posted");
                        } else if (document.getElementById("spn0101Status").innerText == "Cancelled") {
                            document.getElementById("spn0101Status").setAttribute("class", "badge badge-lg badge-record-cancelled");
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
                        if (response[0].Lock == "1") {
                            document.getElementById("cbx0101Lock").checked = true;
                        } else {
                            document.getElementById("cbx0101Lock").checked = false;
                        };
                        if (response[0].Post == "1") {
                            document.getElementById("cbx0101Post").checked = true;
                        } else {
                            document.getElementById("cbx0101Post").checked = false;
                        };
                        if (response[0].Rvrs == "1") {
                            document.getElementById("cbx0101Rvrs").checked = true;
                        } else {
                            document.getElementById("cbx0101Rvrs").checked = false;
                        };
                        //toolbar

                        //content
                        document.getElementById("div0101Detail").style.display = "none";
                        document.getElementById("div0101Update").style.display = "";
                        document.getElementById("tbx0101TrxnNo").value = response[0].SICode;
                        document.getElementById("tbx0101Date").value = response[0].SIDate;
                        document.getElementById("tbx0101DateCreated").value = response[0].SIDateCreated;
                        document.getElementById("cbx0201SINo").checked = response[0].SI;
                        document.getElementById("cbx0201GPNo").checked = response[0].GP;
                        document.getElementById("tbx0101SINo").value = response[0].SINo;
                        document.getElementById("tbx0101GPNo").value = response[0].GPNo;
                        document.getElementById("tbx0101DeliverTo").value = response[0].SILocation;
                        document.getElementById("tbx0101Location").value = response[0].GPLocation;
                        //disable
                        document.getElementById("div0101RequestedBy").classList.add("d-none");
                        document.getElementById("tbx0101RequestedBy").classList.remove("d-none");
                        document.getElementById("tbx0101RequestedBy").value = response[0].RequestedByName;
                        document.getElementById("ContentPlaceHolder1_hf0101RequestedBy").value = response[0].RequestedByCode;
                        document.getElementById("ContentPlaceHolder1_hf0101DeptCode").value = response[0].DeptCode;
                        document.getElementById("ContentPlaceHolder1_hf0101PRNo").value = response[0].PRNo;

                        $('#ddl0101Type').val(response[0].TrxnType).trigger('change');
                        ddl0101ChargeTo(response[0].TrxnType, response[0].TrxnCode);
                        ddl0101Warehouse(response[0].WhseCode);
                        ddl0101IssuedBy(response[0].IssuedByCode);
                        ddl0101AuthorizedBy(response[0].AuthorizedByCode);
                        document.getElementById("tbx0101UpdatedByName").value = (response[0].UpdatedByName == "" || response[0].UpdatedByName == null ? "-" : response[0].UpdatedByName);
                        document.getElementById("tbx0101UpdatedDate").value = (response[0].UpdatedDate == "" || response[0].UpdatedDate == null) ? "-" : response[0].UpdatedDate;
                        document.getElementById("tbx0101LockedByName").value = (response[0].LockedByName == "" || response[0].LockedByName == null) ? "-" : response[0].LockedByName;
                        document.getElementById("tbx0101LockedDate").value = (response[0].LockedDate == "" || response[0].LockedDate == null) ? "-" : response[0].LockedDate;
                        document.getElementById("tbx0101PostedByName").value = (response[0].PostedByName == "" || response[0].PostedByName == null) ? "-" : response[0].PostedByName;
                        document.getElementById("tbx0101PostedDate").value = (response[0].PostedDate == "" || response[0].PostedDate == null) ? "-" : response[0].PostedDate;
                        document.getElementById("tbx0101CancelledByName").value = (response[0].CancelledByName == "" || response[0].CancelledByName == null) ? "-" : response[0].CancelledByName;
                        document.getElementById("tbx0101CancelledDate").value = (response[0].ReversedDate == "" || response[0].ReversedDate == null) ? "-" : response[0].ReversedDate;
                        document.getElementById("hdnCECode").value = response[0].CECode;
                        document.getElementById("hdnWCode").value = response[0].WCode;
                        //content

                    },
                });
            };
            function ddl0101Warehouse(ID) {
                $.ajax({
                    type: "POST",
                    url: "Assets/Handler/SCM/SCM080100HND.ashx",
                    data: {
                        'FormCode': 'SCM080100',
                        'Type': 'Get Record',
                        'pTblName': 'Mstr_Warehouse',
                        'pPlaceHolder': 'Warehouse',
                    },
                    success: function (response) {
                        var s = '';
                        for (var i = 0; i < response.length; i++) {
                            s += '<option value="' + response[i].ID + '">' + response[i].Name + '</option>';
                        }
                        $("#ddl0101Warehouse").html(s);
                        $('#ddl0101Warehouse').val(ID).trigger('change');
                    },
                });
            };
            function ddl0101RequestedBy(ID) {
                $.ajax({
                    type: "POST",
                    url: "Assets/Handler/SCM/SCM080100HND.ashx",
                    data: {
                        'FormCode': 'SCM080100',
                        'Type': 'Get Record',
                        'pTblName': 'Mstr_Employee(SR)',
                        'pPlaceHolder': 'Requested By',
                    },
                    success: function (response) {
                        var s = '';
                        for (var i = 0; i < response.length; i++) {
                            s += '<option value="' + response[i].ID + '">' + response[i].Name + '</option>';
                        }
                        $("#ddl0101RequestedBy").html(s);
                        $('#ddl0101RequestedBy').val(ID).trigger('change');
                    },
                });
            };
            function ddl0101IssuedBy(ID) {
                $.ajax({
                    type: "POST",
                    url: "Assets/Handler/SCM/SCM080100HND.ashx",
                    data: {
                        'FormCode': 'SCM080100',
                        'Type': 'Get Record',
                        'pTblName': 'Mstr_Employee',
                        'pPlaceHolder': 'Issued By',
                    },
                    success: function (response) {
                        var s = '';
                        for (var i = 0; i < response.length; i++) {
                            s += '<option value="' + response[i].ID + '">' + response[i].Name + '</option>';
                        }
                        $("#ddl0101IssuedBy").html(s);
                        $('#ddl0101IssuedBy').val(ID).trigger('change');
                    },
                });
            };
            function ddl0101AuthorizedBy(ID) {
                $.ajax({
                    type: "POST",
                    url: "Assets/Handler/SCM/SCM080100HND.ashx",
                    data: {
                        'FormCode': 'SCM080100',
                        'Type': 'Get Record',
                        'pTblName': 'Mstr_Employee',
                        'pPlaceHolder': 'Authorized By',
                    },
                    success: function (response) {
                        var s = '';
                        for (var i = 0; i < response.length; i++) {
                            s += '<option value="' + response[i].ID + '">' + response[i].Name + '</option>';
                        }
                        $("#ddl0101AuthorizedBy").html(s);
                        $('#ddl0101AuthorizedBy').val(ID).trigger('change');
                    },
                });
            };
        };
        function fn0101Refresh() {
            fn01Load();
        };
        function fn0101Add() {
            //access
            fnAccess('SCM080000', 'Add', function (response) {
                if (response[0].oReturn == "1") {
                    Add();
                } else {
                    fnAlertOnly('Access denied!', 'error', 'btn btn-danger');
                };
            });
            function Add() {
                document.getElementById("ContentPlaceHolder1_hdnMode").value = "ADD";
                document.getElementById("ContentPlaceHolder1_hdnID").value = "000000000000";
                fn01Load();
            };
        };
        function fn0101Delete() {
            if (document.getElementById("ContentPlaceHolder1_hdnMode").value == "ADD") {
                Cancel_Add_Question();
            } else if (document.getElementById("ContentPlaceHolder1_hdnMode").value == "DTL") {
                //if exisit
                fnIfExist('ogm_si_hdr', 'si_code', document.getElementById('ContentPlaceHolder1_hdnID').value, function (response) {
                    if (response[0].oReturn == "1") {
                        Access();
                    } else {
                        window.location.replace("MNU040100");
                    };
                });
                //access
                function Access() {
                    //access
                    fnAccess('SCM080000', 'Delete', function (response) {
                        if (response[0].oReturn == "1") {
                            Validate(document.getElementById('ContentPlaceHolder1_hdnID').value);
                        } else {
                            fnAlertOnly('Access denied!', 'error', 'btn btn-danger');
                        };
                    });
                };
                //validate
                function Validate(ID) {
                    fnValidateRecord('Trxn_SIHdr', ID, '', 'Delete', function (response) {
                        if (response[0].oReturn == "") {
                            Delete_Dtl_Question(ID);
                        } else {
                            fnAlertOnly(response[0].oReturn, 'warning', 'btn btn-warning');
                        };
                    });
                };
            } else if (document.getElementById("ContentPlaceHolder1_hdnMode").value == "UPD") {
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
                            window.close();
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
                        fnValidateRecord('Trxn_SIHdr', ID, '', 'Delete', function (response) {
                            if (response[0].oReturn == "") {
                                Detele_Ok(ID);
                            } else {
                                fnAlertOnly(response[0].oReturn, 'warning', 'btn btn-warning');
                            };
                        });
                    }
                });
                function Detele_Ok(ID) {
                    fnDelete('SCM080000', 'Trxn_SIHdr', ID, function (response) {
                        if (document.getElementById('ContentPlaceHolder1_hdnPrevID').value == "") {
                            window.opener && typeof window.opener.fn01Redraw === 'function' ? window.opener.fn01Redraw("Delete", ID) : window.open("SCM080000");
                            window.close();
                        } else if (document.getElementById('ContentPlaceHolder1_hdnPrevID').value == ID) {
                            window.opener && typeof window.opener.fn01Redraw === 'function' ? window.opener.fn01Redraw("Delete", ID) : window.open("SCM080000");
                            window.close();
                        } else if (document.getElementById('ContentPlaceHolder1_hdnPrevID').value != ID) {
                            document.getElementById('ContentPlaceHolder1_hdnMode').value = "DTL";
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
                fnAccess('SCM080000', 'Add', function (response) {
                    if (response[0].oReturn == "1") {
                        ValidateFields("");
                    } else {
                        fnAlertOnly('Access denied!', 'error', 'btn btn-danger');
                    };
                });
            } else if (document.getElementById('ContentPlaceHolder1_hdnMode').value == "DTL") {
                //if exisit
                fnIfExist('ogm_si_hdr', 'si_code', document.getElementById('ContentPlaceHolder1_hdnID').value, function (response) {
                    if (response[0].oReturn == "1") {
                        Access();
                    } else {
                        window.location.replace("MNU040100");
                    };
                });
                //access
                function Access() {
                    //access
                    fnAccess('SCM080000', 'Save', function (response) {
                        if (response[0].oReturn == "1") {
                            Validate(document.getElementById('ContentPlaceHolder1_hdnID').value);
                        } else {
                            fnAlertOnly('Access denied!', 'error', 'btn btn-danger');
                        };
                    });
                };
                //validate
                function Validate(ID) {
                    fnValidateRecord('Trxn_SIHdr', ID, '', 'Save', function (response) {
                        if (response[0].oReturn == "") {
                            Edit_Dtl_Ok_Await(ID);
                        } else {
                            fnAlertOnly(response[0].oReturn, 'warning', 'btn btn-warning');
                        };
                    });
                };
            } else if (document.getElementById('ContentPlaceHolder1_hdnMode').value == "UPD") {
                //if exisit
                fnIfExist('ogm_si_hdr', 'si_code', document.getElementById('ContentPlaceHolder1_hdnID').value, function (response) {
                    if (response[0].oReturn == "1") {
                        Access();
                    } else {
                        window.location.replace("MNU040100");
                    };
                });
                //access
                function Access() {
                    //access
                    fnAccess('SCM080000', 'Save', function (response) {
                        if (response[0].oReturn == "1") {
                            Validate(document.getElementById('ContentPlaceHolder1_hdnID').value);
                        } else {
                            fnAlertOnly('Access denied!', 'error', 'btn btn-danger');
                        };
                    });
                };
                //validate
                function Validate(ID) {
                    fnValidateRecord('Trxn_SIHdr', ID, '', 'Save', function (response) {
                        if (response[0].oReturn == "") {
                            ValidateFields(ID);
                        } else {
                            fnAlertOnly(response[0].oReturn, 'warning', 'btn btn-warning');
                        };
                    });
                };
            }
            //validate fields
            function ValidateFields(ID) {
                if (document.getElementById("ddl0101Type").options[document.getElementById("ddl0101Type").selectedIndex].value == "") {
                    //Alert
                    fnAlertOnly('Some field(s) are missing!', 'error', 'btn btn-danger');
                } else if (document.getElementById("ddl0101ChargeTo").options[document.getElementById("ddl0101ChargeTo").selectedIndex].value == "") {
                    //Alert
                    fnAlertOnly('Some field(s) are missing!', 'error', 'btn btn-danger');
                } else if (document.getElementById("cbx0201SINo").checked == false && document.getElementById("ddl0101Warehouse").options[document.getElementById("ddl0101Warehouse").selectedIndex].value == "") {
                    //Alert
                    fnAlertOnly('Some field(s) are missing!', 'error', 'btn btn-danger');
                } else if (document.getElementById("cbx0201GPNo").checked == true && document.getElementById("ddl0101AuthorizedBy").options[document.getElementById("ddl0101AuthorizedBy").selectedIndex].value == "") {
                    //Alert
                    fnAlertOnly('Some field(s) are missing!', 'error', 'btn btn-danger');
                } else if (document.getElementById("cbx0201GPNo").checked == true && document.getElementById("tbx0101Location").value == "") {
                    //Alert
                    fnAlertOnly('Some field(s) are missing!', 'error', 'btn btn-danger');
                } else if (document.getElementById("ContentPlaceHolder1_hdnMode").value == "ADD" && document.getElementById("ddl0101RequestedBy").options[document.getElementById("ddl0101RequestedBy").selectedIndex].value == "") { 
                    //Alert
                    fnAlertOnly('Some field(s) are missing!', 'error', 'btn btn-danger');
                } else if (document.getElementById("ddl0101IssuedBy").options[document.getElementById("ddl0101IssuedBy").selectedIndex].value == "") {
                    //Alert
                    fnAlertOnly('Some field(s) are missing!', 'error', 'btn btn-danger');
                } else if (document.getElementById("tbx0101DeliverTo").value == "") {
                    //Alert
                    fnAlertOnly('Some field(s) are missing!', 'error', 'btn btn-danger');
                } else if (document.getElementById("cbx0201SINo").checked == true && document.getElementById("tbx0101Date").value == ""  ) {
                    //Alert
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
                            Edit_Dtl_Ok_Await();
                        } else if (document.getElementById('ContentPlaceHolder1_hdnMode').value == "UPD") {
                            fnValidateRecord('Trxn_SIHdr', ID, '', 'Save', function (response) {
                                if (response[0].oReturn == "") {
                                    Edit_Upd_Ok_Await(ID);
                                } else {
                                    fnAlertOnly(response[0].oReturn, 'warning', 'btn btn-warning');
                                };
                            });
                        }
                    }
                });
            };
            //do edit
            function Edit_Add_Ok_Await() {
                // Do Billing
                $.ajax({
                    type: "POST",
                    url: "Assets/Handler/SCM/SCM080100HND.ashx",
                    data: {
                        'FormCode': 'SCM080100',
                        'Type': 'Stock Issuance - Add Record',
                        'pSI': document.getElementById("cbx0201SINo").checked,
                        'pSINo': document.getElementById("tbx0101SINo").value,
                        'pSIDate': document.getElementById("tbx0101Date").value,
                        'pSIDateCreated': document.getElementById("tbx0101DateCreated").value,
                        'pCECode': document.getElementById("hdnCECode").value,
                        'pWCode': document.getElementById("hdnWCode").value,
                        'pTrxnType': document.getElementById("ddl0101Type").options[document.getElementById("ddl0101Type").selectedIndex].value,
                        'pTrxnCode': document.getElementById("ddl0101ChargeTo").options[document.getElementById("ddl0101ChargeTo").selectedIndex].value,
                        'pPRNo': document.getElementById("ddl0101RequestedBy").options[document.getElementById("ddl0101RequestedBy").selectedIndex].value,
                        'pRequestedBy': document.getElementById("ContentPlaceHolder1_hf0101RequestedBy").value,
                        'pWhseCode': document.getElementById("ddl0101Warehouse").options[document.getElementById("ddl0101Warehouse").selectedIndex].value,
                        'pIssuedBy': document.getElementById("ddl0101IssuedBy").options[document.getElementById("ddl0101IssuedBy").selectedIndex].value,
                        'pSILocation': document.getElementById("tbx0101DeliverTo").value,
                        'pGP': document.getElementById("cbx0201GPNo").checked,
                        'pGPNo': document.getElementById("tbx0101GPNo").value,
                        'pGPDate': document.getElementById("tbx0101Date").value,
                        'pAuthorizedBy': document.getElementById("ddl0101AuthorizedBy").options[document.getElementById("ddl0101AuthorizedBy").selectedIndex].value,
                        'pGPLocation': document.getElementById("tbx0101Location").value
                    },
                    success: function (response) {
                        fnAlertOnly('Record successfully saved.', 'success', 'btn btn-success');
                        if (window.opener && typeof window.opener.fn01Redraw === 'function') window.opener.fn01Redraw("Add", response[0].oID);
                        document.getElementById('ContentPlaceHolder1_hdnMode').value = "DTL";
                        document.getElementById('ContentPlaceHolder1_hdnID').value = response[0].oID;
                        document.getElementById('ContentPlaceHolder1_hdnPrevID').value = response[0].oID;
                        fn0101LoadOverview(document.getElementById('ContentPlaceHolder1_hdnMode').value, document.getElementById('ContentPlaceHolder1_hdnID').value);
                        fn0102LoadParticular(document.getElementById('ContentPlaceHolder1_hdnMode').value, document.getElementById('ContentPlaceHolder1_hdnID').value);
                    },
                });
            };
            function Edit_Dtl_Ok_Await(ID) {
                document.getElementById('ContentPlaceHolder1_hdnMode').value = "UPD";
                document.getElementById('ContentPlaceHolder1_hdnID').value = ID;
                document.getElementById('ContentPlaceHolder1_hdnPrevID').value = ID;
                fn0101LoadOverview(document.getElementById('ContentPlaceHolder1_hdnMode').value, document.getElementById('ContentPlaceHolder1_hdnID').value);
            };
            function Edit_Upd_Ok_Await(ID) {
                // Do Update
                $.ajax({
                    type: "POST",
                    url: "Assets/Handler/SCM/SCM080100HND.ashx",
                    data: {
                        'FormCode': 'SCM080100',
                        'Type': 'Stock Issuance - Edit Record',
                        'pID': ID,
                        'pSINo': document.getElementById("tbx0101SINo").value,
                        'pSI': document.getElementById("cbx0201SINo").checked,
                        'pSIDate': document.getElementById("tbx0101Date").value,
                        'pSICreatedDate': document.getElementById("tbx0101DateCreated").value,
                        'pCECode': document.getElementById("hdnCECode").value,
                        'pWCode': document.getElementById("hdnWCode").value,
                        'pTrxnType': document.getElementById("ddl0101Type").options[document.getElementById("ddl0101Type").selectedIndex].value,
                        'pTrxnCode': document.getElementById("ddl0101ChargeTo").options[document.getElementById("ddl0101ChargeTo").selectedIndex].value,
                        'pPRNo': document.getElementById("ContentPlaceHolder1_hf0101PRNo").value,
                        'pRequestedBy': document.getElementById("ContentPlaceHolder1_hf0101RequestedBy").value,
                        'pDeptCode': document.getElementById("ContentPlaceHolder1_hf0101DeptCode").value,
                        'pWhseCode': document.getElementById("ddl0101Warehouse").options[document.getElementById("ddl0101Warehouse").selectedIndex].value,
                        'pIssuedBy': document.getElementById("ddl0101IssuedBy").options[document.getElementById("ddl0101IssuedBy").selectedIndex].value,
                        'pSILocation': document.getElementById("tbx0101DeliverTo").value,
                        'pGP': document.getElementById("cbx0201GPNo").checked,
                        'pGPNo': document.getElementById("tbx0101GPNo").value,
                        'pGPDate': document.getElementById("tbx0101Date").value,
                        'pAuthorizedBy': document.getElementById("ddl0101AuthorizedBy").options[document.getElementById("ddl0101AuthorizedBy").selectedIndex].value,
                        'pGPLocation': document.getElementById("tbx0101Location").value
                    },
                    success: function (response) {
                        fnAlertOnly('Record successfully saved.', 'success', 'btn btn-success');
                        if (window.opener && typeof window.opener.fn01Redraw === 'function') window.opener.fn01Redraw("Edit", ID);
                        document.getElementById('ContentPlaceHolder1_hdnMode').value = "DTL"
                        document.getElementById('ContentPlaceHolder1_hdnID').value = ID
                        document.getElementById('ContentPlaceHolder1_hdnPrevID').value = ID
                        fn0101LoadOverview(document.getElementById('ContentPlaceHolder1_hdnMode').value, document.getElementById('ContentPlaceHolder1_hdnID').value);
                    },
                });
            };
        };
        function fn0101Lock() {
            //if exisit
            fnIfExist('ogm_si_hdr', 'si_code', document.getElementById('ContentPlaceHolder1_hdnID').value, function (response) {
                if (response[0].oReturn == "1") {
                    Access();
                } else {
                    window.location.replace("MNU040100");
                };
            });
            //access
            function Access() {
                fnAccess('SCM080000', 'Lock', function (response) {
                    if (response[0].oReturn == "1") {
                        Validate(document.getElementById('ContentPlaceHolder1_hdnID').value);
                    } else {
                        fnAlertOnly('Access denied!', 'error', 'btn btn-danger');
                    };
                });
            };
            //validate
            function Validate(ID) {
                fnValidateRecord('Trxn_SIHdr', ID, '', 'Lock', function (response) {
                    if (response[0].oReturn == "") {
                        Lock_Question(ID);
                    } else {
                        fnAlertOnly(response[0].oReturn, 'warning', 'btn btn-warning');
                    };
                });
            };
            //lock question
            function Lock_Question(ID) {
                Swal.fire({
                    title: '<span class="fs-6 fw-normal text-gray-700">Lock record?</span>',
                    icon: 'question',
                    html: `<input id="tbx0101LockPassword" type="password" class="form-control form-control-sm" Placeholder="Password" maxlength="20" />`,
                    iconColor: '#009ef7',
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
                        fnValidatePassword(document.getElementById("tbx0101LockPassword").value, function (response) {
                            if (response[0].oReturn == "") {
                                fnValidateRecord('Trxn_SIHdr', ID, '', 'Lock', function (response) {
                                    if (response[0].oReturn == "") {
                                        Lock_Ok(ID);
                                    } else {
                                        fnAlertOnly(response[0].oReturn, 'warning', 'btn btn-warning');
                                    };
                                });
                            } else {
                                fnAlertOnly(response[0].oReturn, 'warning', 'btn btn-warning');
                            };
                        });
                    }
                });
            };
            //lock ok
            function Lock_Ok(ID) {
                fnLock('Lock', 'Trxn_SIHdr', ID, function (response) {
                    fnAlertOnly('Record successfully locked.', 'success', 'btn btn-success');
                    if (window.opener && typeof window.opener.fn01Redraw === 'function') window.opener.fn01Redraw("Edit", ID);
                    fn0101LoadOverview(document.getElementById('ContentPlaceHolder1_hdnMode').value, document.getElementById('ContentPlaceHolder1_hdnID').value);
                });
            }
        };
        function fn0101Unlock() {
            //if exisit
            fnIfExist('ogm_si_hdr', 'si_code', document.getElementById('ContentPlaceHolder1_hdnID').value, function (response) {
                if (response[0].oReturn == "1") {
                    Access();
                } else {
                    window.location.replace("MNU040100");
                };
            });
            //access
            function Access() {
                fnAccess('SCM080000', 'Unlock', function (response) {
                    if (response[0].oReturn == "1") {
                        Validate(document.getElementById('ContentPlaceHolder1_hdnID').value);
                    } else {
                        fnAlertOnly('Access denied!', 'error', 'btn btn-danger');
                    };
                });
            };
            //validate
            function Validate(ID) {
                fnValidateRecord('Trxn_SIHdr', ID, '', 'Unlock', function (response) {
                    if (response[0].oReturn == "") {
                        Unlock_Question(ID);
                    } else {
                        fnAlertOnly(response[0].oReturn, 'warning', 'btn btn-warning');
                    };
                });
            };
            //unlock question
            function Unlock_Question(ID) {
                Swal.fire({
                    title: '<span class="fs-6 fw-normal text-gray-700">Unlock record?</span>',
                    icon: 'question',
                    html: `<input id="tbx0101UnlockPassword" type="password" class="form-control form-control-sm" Placeholder="Password" maxlength="20" />`,
                    iconColor: '#009ef7',
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
                        fnValidatePassword(document.getElementById("tbx0101UnlockPassword").value, function (response) {
                            if (response[0].oReturn == "") {
                                fnValidateRecord('Trxn_SIHdr', ID, '', 'Unlock', function (response) {
                                    if (response[0].oReturn == "") {
                                        Unlock_Ok(ID);
                                    } else {
                                        fnAlertOnly(response[0].oReturn, 'warning', 'btn btn-warning');
                                    };
                                });
                            } else {
                                fnAlertOnly(response[0].oReturn, 'warning', 'btn btn-warning');
                            };
                        });
                    }
                });
            };
            //unlock ok
            function Unlock_Ok(ID) {
                fnLock('Unlock', 'Trxn_SIHdr', ID, function (response) {
                    fnAlertOnly('Record successfully unlocked.', 'success', 'btn btn-success');
                    if (window.opener && typeof window.opener.fn01Redraw === 'function') window.opener.fn01Redraw("Edit", ID);
                    fn0101LoadOverview(document.getElementById('ContentPlaceHolder1_hdnMode').value, document.getElementById('ContentPlaceHolder1_hdnID').value);
                });
            }
        };
        function fn0101Post() {
            //if exisit
            fnIfExist('ogm_si_hdr', 'si_code', document.getElementById('ContentPlaceHolder1_hdnID').value, function (response) {
                if (response[0].oReturn == "1") {
                    Access();
                } else {
                    window.location.replace("MNU040100");
                };
            });
            //access
            function Access() {
                fnAccess('SCM080000', 'Post', function (response) {
                    if (response[0].oReturn == "1") {
                        Validate(document.getElementById('ContentPlaceHolder1_hdnID').value);
                    } else {
                        fnAlertOnly('Access denied!', 'error', 'btn btn-danger');
                    };
                });
            };
            //validate
            function Validate(ID) {
                fnValidateRecord('Trxn_SIHdr', ID, '', 'Post', function (response) {
                    if (response[0].oReturn == "") {
                        Post_Question(ID);
                    } else {
                        fnAlertOnly(response[0].oReturn, 'warning', 'btn btn-warning');
                    };
                });
            };
            //post question
            function Post_Question(ID) {
                Swal.fire({
                    title: '<span class="fs-6 fw-normal text-gray-700">Post record?</span>',
                    icon: 'question',
                    html: `<input id="tbx0101PostPassword" type="password" class="form-control form-control-sm" Placeholder="Password" maxlength="20" />`,
                    iconColor: '#009ef7',
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
                        fnValidatePassword(document.getElementById("tbx0101PostPassword").value, function (response) {
                            if (response[0].oReturn == "") {
                                fnValidateRecord('Trxn_SIHdr', ID, '', 'Post', function (response) {
                                    if (response[0].oReturn == "") {
                                        Post_Ok(ID);
                                    } else {
                                        fnAlertOnly(response[0].oReturn, 'warning', 'btn btn-warning');
                                    };
                                });
                            } else {
                                fnAlertOnly(response[0].oReturn, 'warning', 'btn btn-warning');
                            };
                        });
                    }
                });
            };
            //post ok
            function Post_Ok(ID) {
                //post
                $.ajax({
                    type: "POST",
                    url: "Assets/Handler/SCM/SCM080100HND.ashx",
                    data: {
                        'Type': "Post",
                        'pRecType': "SI",
                        'pTblCode': ID
                    },
                    success: function (response) {
                        fnAlertOnly('Record successfully posted.', 'success', 'btn btn-success');
                        if (window.opener && typeof window.opener.fn01Redraw === 'function') window.opener.fn01Redraw("Edit", ID);
                        fn0101LoadOverview(document.getElementById('ContentPlaceHolder1_hdnMode').value, document.getElementById('ContentPlaceHolder1_hdnID').value);
                        fn0102LoadParticular(document.getElementById('ContentPlaceHolder1_hdnMode').value, document.getElementById('ContentPlaceHolder1_hdnID').value);
                    }
                });
            }
        };
        function fn0101Cancel() {
            //if exisit
            fnIfExist('ogm_si_hdr', 'si_code', document.getElementById('ContentPlaceHolder1_hdnID').value, function (response) {
                if (response[0].oReturn == "1") {
                    Access();
                } else {
                    window.location.replace("MNU040100");
                };
            });
            //access
            function Access() {
                fnAccess('SCM080000', 'Reverse', function (response) {
                    if (response[0].oReturn == "1") {
                        Validate(document.getElementById('ContentPlaceHolder1_hdnID').value);
                    } else {
                        fnAlertOnly('Access denied!', 'error', 'btn btn-danger');
                    };
                });
            };
            //validate
            function Validate(ID) {
                fnValidateRecord('Trxn_SIHdr', ID, '', 'Reverse', function (response) {
                    if (response[0].oReturn == "") {
                        $('#mdl0101Cancel').modal('show');
                    } else {
                        fnAlertOnly(response[0].oReturn, 'warning', 'btn btn-warning');
                    };
                });
            };
        };
        function fn0101Cancel_Ok(Btn) {
            //if exisit
            fnIfExist('ogm_si_hdr', 'si_code', document.getElementById('ContentPlaceHolder1_hdnID').value, function (response) {
                if (response[0].oReturn == "1") {
                    Cancel_Ok();
                } else {
                    window.location.replace("MNU040100");
                };
            });
            async function Cancel_Ok() {
                // Disable the clicked button to avoid multiple clicks
                Btn.disabled = true;
                // Show loading indicator
                Btn.setAttribute('data-kt-indicator', 'on');
                // Simulate form submission
                await fn0101Cancel_Ok_Await(Btn);
            }
        };
        function fn0101Cancel_Ok_Await(Btn) {
            // process
            return new Promise(resolve => {
                //Validate
                if (document.getElementById("tbx0101ReasonDate").value == "" || document.getElementById("tbx0101Reason").value == "") {
                    fnAlertOnly('Some field(s) are missing!', 'error', 'btn btn-danger');
                } else {
                    //Modal
                    $('#mdl0101Cancel').modal('hide');
                    Cancel_Question();
                }
                function Cancel_Question() {
                    Swal.fire({
                        title: '<span class="fs-6 fw-normal text-gray-700">Cancel record?</span>',
                        icon: 'question',
                        html: `<input id="tbx0101CancelPassword" type="password" class="form-control form-control-sm" Placeholder="Password" maxlength="20" />`,
                        iconColor: '#009ef7',
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
                            fnValidatePassword(document.getElementById("tbx0101CancelPassword").value, function (response) {
                                if (response[0].oReturn == "") {
                                    fnValidateRecord('Trxn_SIHdr', document.getElementById('ContentPlaceHolder1_hdnID').value, '', 'Reverse', function (response) {
                                        if (response[0].oReturn == "") {
                                            Add_Cancel_Await();
                                        } else {
                                            fnAlertOnly(response[0].oReturn, 'warning', 'btn btn-warning');
                                        };
                                    });
                                } else {
                                    fnAlertOnly(response[0].oReturn, 'warning', 'btn btn-warning');
                                };
                            });
                        } else {
                            $('#mdl0101Cancel').modal('show');
                        }
                    });
                };
                //add
                function Add_Cancel_Await() {
                    // Do Cancellation
                    $.ajax({
                        type: "POST",
                        url: "Assets/Handler/SCM/SCM080100HND.ashx",
                        data: {
                            'FormCode': 'SCM080100',
                            'Type': 'Stock Issuance - Cancel Record',
                            'pID': document.getElementById('ContentPlaceHolder1_hdnID').value,
                            'pReasonDate': document.getElementById("tbx0101ReasonDate").value,
                            'pReason': document.getElementById("tbx0101Reason").value
                        },
                        success: function (response) {
                            //cancel
                            fnAlertOnly('Record successfully cancelled.', 'success', 'btn btn-success');
                            document.getElementById("tbx0101ReasonDate").value = "";
                            document.getElementById("tbx0101Reason").value = "";
                            if (window.opener && typeof window.opener.fn01Redraw === 'function') window.opener.fn01Redraw("Edit", document.getElementById('ContentPlaceHolder1_hdnID').value);
                            fn0101LoadOverview(document.getElementById('ContentPlaceHolder1_hdnMode').value, document.getElementById('ContentPlaceHolder1_hdnID').value);
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
        function fn0101Tools() {
            $('#mdl010101Tools').modal('show');
        };
        function fn010101_SCM03TLS01() {
            $.ajax({
                type: "POST",
                url: "Assets/Handler/SCM/SCM080100HND.ashx",
                data: {
                    'FormCode': 'SCM080100',
                    'Type': 'PR Find',
                },
                success: function (response) {
                    //display loader
                    document.getElementById("div01010201Loader").style.display = "";
                    //display loader

                    $('#table01010201Record').DataTable().destroy();

                    //disable column type detection
                    DataTable.types().forEach(type => {
                        DataTable.type(type, 'detect', () => false);
                    });
                    //disable column type detection

                    //sort date by yyyy/mm/dd
                    $.fn.dataTable.moment('MM/DD/YYYY');
                    //sort date by yyyy/mm/dd

                    //datatable
                    var table01010201Record = $("#table01010201Record").DataTable({
                        processing: true,
                        bFilter: true,
                        bPaginate: true,
                        bInfo: false,
                        paging: true,
                        lengthChange: true,
                        pageLength: 25,
                        select: true,
                        data: response,
                        columns: [
                            { data: 'Action' },
                            { data: 'PRNo' },
                            { data: 'Status' },
                            { data: 'DateRequired' },
                            { data: 'PurchaseType' },
                            { data: 'Project' },
                            { data: 'Remarks' },
                            { data: 'Requestor' },
                        ],
                        rowId: 'rowId',
                        columnDefs: [
                            {
                                targets: 0, orderable: false
                            },
                            {
                                targets: [4, 5, 6, 7], className: 'tbody-nowrap-auto'
                            }
                        ],
                        orderCellsTop: true,
                    });
                    //datatable

                    //search
                    $('#tbx01010201Find').on('keyup', function () {
                        table01010201Record.search(this.value).draw();
                    });
                    //search

                    //hide loader
                    document.getElementById("div01010201Loader").style.display = "none";
                    //hide loader

                    fnAlertOnly('Record successfully loaded.', 'success', 'btn btn-success');

                    //modal
                    $('#mdl010101Tools').modal('hide');
                    $('#mdl010102PRFind').modal('show');
                },
            });
        };
        function fn010101_SCM03TLS02() {
            $.ajax({
                type: "POST",
                url: "Assets/Handler/SCM/SCM080100HND.ashx",
                data: {
                    'FormCode': 'SCM080100',
                    'Type': 'Stock Issuance - Trasfer Item : SR > PO',
                },
                success: function (response) {
                    //display loader
                    document.getElementById("div01010301Loader").style.display = "";
                    //display loader

                    $('#table01010301Record').DataTable().destroy();

                    //disable column type detection
                    DataTable.types().forEach(type => {
                        DataTable.type(type, 'detect', () => false);
                    });
                    //disable column type detection

                    //sort date by yyyy/mm/dd
                    $.fn.dataTable.moment('MM/DD/YYYY');
                    //sort date by yyyy/mm/dd

                    //datatable
                    var table01010301Record = $("#table01010301Record").DataTable({
                        processing: true,
                        bFilter: true,
                        bPaginate: true,
                        bInfo: false,
                        paging: true,
                        lengthChange: true,
                        pageLength: 25,
                        select: true,
                        data: response,
                        columns: [
                            { data: 'Action' },
                            { data: 'PRNo' },
                            { data: 'DateRequired' },
                            { data: 'Requestor' },
                            { data: 'SeqNo' },
                            { data: 'Item' },
                            { data: 'ForCP' },
                            { data: 'ForCPBalance' },
                            {
                                data: 'Transfer',
                                render: function (data, type, row, meta) {
                                    if (type === "display") {
                                        let rowId = `${row.rowId}`;
                                        let rowVal = parseFloat(row.ForCPBalance).toFixed(2);

                                        //Format Number
                                        let formattedValue = new Intl.NumberFormat('en-US', {
                                            minimumFractionDigits: 2,
                                            maximumFractionDigits: 2
                                        }).format(rowVal);

                                        let textbox = `
                                                    <input prm01010301Transfer="${rowId}" type="text" class="w-100 outline-none text-end border-top-0 border-left-0 border-right-0 border-bottom-2 border-gray-300" Placeholder="Transfer" value="${formattedValue}" onkeypress="return fnEnterKeyNumber(event,this.id)" onblur="fnFormatNumericIssuance(this, ${row.ForCP});" />
                                                `;
                                        return textbox;
                                    }
                                    return data;
                                }
                            },
                            { data: 'Unit' },
                            {
                                data: 'Purchaser',
                                render: function (data, type, row, meta) {
        //                            if (type === "display") {
        //                                let rowId = `${row.rowId}`;
        //                                let selectId = `${meta.row}`; // Unique ID for each row
        //                                let dropdown = `
								//<select id="${selectId}" prm01010301Purchaser="${rowId}" data-dropdown-parent="#mdl010103SRPO" data-kt-repeater="select2" class="form-select form-select-sm form-select-border">
        //                            <option value="">Select Purchaser</option>
        //                        </select>`;

        //                                // Fetch data asynchronously
        //                                $.ajax({
        //                                    type: 'GET',
        //                                    url: 'HNDSCM.ashx',
        //                                    data: {
        //                                        'FormCode': 'SCM060100',
        //                                        'Type': 'Purchaser'
        //                                    },
        //                                    success: function (response) {
        //                                        let options = response.map(item => `<option value="${item.ID}">${item.Name}</option>`).join('');
        //                                        // Update the select dropdown, keeping the default option
        //                                        $(`#${selectId}`).html(`<option value="">Select Purchaser</option>` + options);
        //                                    },
        //                                    error: function () {
        //                                        $(`#${selectId}`).html('<option>Error loading options</option>');
        //                                    }
        //                                });

        //                                return dropdown;
        //                            }
        //                            return data; 
                                    if (type === "display") {
                                        let rowId = `${row.rowId}`;
                                        let dropdown = `
                                                    <select prm01010301Purchaser="${rowId}" data-dropdown-parent="#mdl010103SRPO" data-kt-repeater="select2" class="form-select form-select-sm form-select-border">
                                                        <option value="">Select Purchaser</option>
                                                    </select>`;
                                        return dropdown || "";
                                    }
                                    return data;
                                },
                                createdCell: function (cell, cellData, rowData, rowIndex, colIndex) {

                                    let rowId = rowData.rowId;
                                    let dropdown = $(cell).find('[prm01010301Purchaser="' + rowId + '"]');

                                    // Fetch data asynchronously
                                    $.ajax({
                                        type: 'GET',
                                        url: "Assets/Handler/SCM/SCM080100HND.ashx",
                                        data: {
                                            'FormCode': 'SCM080100',
                                            'Type': 'Purchaser'
                                        },
                                        success: function (response) {
                                            let options = response.map(item => `<option value="${item.ID}">${item.Name}</option>`).join('');
                                            dropdown.html(`<option value="">Select Purchaser</option>` + options);

                                            dropdown.select2();
                                        },
                                        error: function () {
                                            dropdown.html('<option>Error loading options</option>');
                                        }
                                    });
                                }
                            },
                        ],
                        rowId: 'rowId',
                        columnDefs: [
                            {
                                targets: 0,
                                orderable: false
                            },
                            {
                                targets: [6, 7],
                                className: 'dt-body-right',
                                render: $.fn.dataTable.render.number(',', '.', 2)
                            },
                            {
                                targets: [5],
                                className: 'tbody-nowrap-auto'
                            }
                        ],
                        drawCallback: function () {
                            $('[data-kt-repeater="select2"]').select2({
                                width: '100%'
                            });
                        },
                        orderCellsTop: true,
                    });
                    //datatable

                    //search
                    $('#tbx01010301Find').on('keyup', function () {
                        table01010301Record.search(this.value).draw();
                    });
                    //search

                    //hide loader
                    document.getElementById("div01010301Loader").style.display = "none";
                    //hide loader

                    fnAlertOnly('Record successfully loaded.', 'success', 'btn btn-success');

                    //modal
                    $('#mdl010101Tools').modal('hide');
                    $('#mdl010103SRPO').modal('show');
                },
            });
        };
        function fn010101_SCM03TLS03() {
            $.ajax({
                type: "POST",
                url: "Assets/Handler/SCM/SCM080100HND.ashx",
                data: {
                    'FormCode': 'SCM080100',
                    'Type': 'Stock Issuance - Trasfer Item : SR > CP',
                },
                success: function (response) {
                    //display loader
                    document.getElementById("div01010401Loader").style.display = "";
                    //display loader

                    $('#table01010401Record').DataTable().destroy();

                    //disable column type detection
                    DataTable.types().forEach(type => {
                        DataTable.type(type, 'detect', () => false);
                    });
                    //disable column type detection

                    //sort date by yyyy/mm/dd
                    $.fn.dataTable.moment('MM/DD/YYYY');
                    //sort date by yyyy/mm/dd

                    //datatable
                    var table01010401Record = $("#table01010401Record").DataTable({
                        processing: true,
                        bFilter: true,
                        bPaginate: true,
                        bInfo: false,
                        paging: true,
                        lengthChange: true,
                        pageLength: 25,
                        select: true,
                        data: response,
                        columns: [
                            { data: 'Action' },
                            { data: 'PRNo' },
                            { data: 'DateRequired' },
                            { data: 'Requestor' },
                            { data: 'SeqNo' },
                            { data: 'Item' },
                            { data: 'ForCP' },
                            { data: 'ForCPBalance' },
                            {
                                data: 'Transfer',
                                render: function (data, type, row, meta) {
                                    if (type === "display") {
                                        let rowId = `${row.rowId}`;
                                        let rowVal = parseFloat(row.ForCPBalance).toFixed(2);

                                        //Format Number
                                        let formattedValue = new Intl.NumberFormat('en-US', {
                                            minimumFractionDigits: 2,
                                            maximumFractionDigits: 2
                                        }).format(rowVal);

                                        let textbox = `
                                                    <input prm01010401Transfer="${rowId}" type="text" class="w-100 outline-none text-end border-top-0 border-left-0 border-right-0 border-bottom-2 border-gray-300" Placeholder="Transfer" value="${formattedValue}" onkeypress="return fnEnterKeyNumber(event,this.id)" onblur="fnFormatNumericIssuance(this, ${row.ForCP});" />
                                                `;
                                        return textbox;
                                    }
                                    return data;
                                }
                            },
                            { data: 'Unit' },
                        ],
                        rowId: 'rowId',
                        columnDefs: [
                            {
                                targets: 0,
                                orderable: false
                            },
                            {
                                targets: [6, 7],
                                className: 'dt-body-right',
                                render: $.fn.dataTable.render.number(',', '.', 2)
                            },
                            {
                                targets: [5],
                                className: 'tbody-nowrap-auto'
                            }
                        ],
                        orderCellsTop: true,
                    });
                    //datatable

                    //search
                    $('#tbx01010401Find').on('keyup', function () {
                        table01010401Record.search(this.value).draw();
                    });
                    //search

                    //hide loader
                    document.getElementById("div01010401Loader").style.display = "none";
                    //hide loader

                    fnAlertOnly('Record successfully loaded.', 'success', 'btn btn-success');

                    //modal
                    $('#mdl010101Tools').modal('hide');
                    $('#mdl010104SRCP').modal('show');
                },
            });
        };
        function fn010101_SCM03TLS04() {
            //access
            fnAccess('SCM080000', 'Add', function (response) {
                if (response[0].oReturn == "1") {
                    Cancel_Item();
                } else {
                    fnAlertOnly('Access denied!', 'error', 'btn btn-danger');
                };
            });
            //cancel
            function Cancel_Item() {
                $.ajax({
                    type: "POST",
                    url: "Assets/Handler/SCM/SCM080100HND.ashx",
                    data: {
                        'FormCode': 'SCM080100',
                        'Type': 'Stock Issuance - Cancel Item : SR',
                    },
                    success: function (response) {
                        //display loader
                        document.getElementById("div01010501Loader").style.display = "";
                        //display loader

                        $('#table01010501Record').DataTable().destroy();

                        //disable column type detection
                        DataTable.types().forEach(type => {
                            DataTable.type(type, 'detect', () => false);
                        });
                        //disable column type detection

                        //sort date by yyyy/mm/dd
                        $.fn.dataTable.moment('MM/DD/YYYY');
                        //sort date by yyyy/mm/dd

                        //datatable
                        var table01010501Record = $("#table01010501Record").DataTable({
                            processing: true,
                            bFilter: true,
                            bPaginate: true,
                            bInfo: false,
                            paging: true,
                            lengthChange: true,
                            pageLength: 25,
                            select: true,
                            data: response,
                            columns: [
                                { data: 'Action' },
                                { data: 'PRNo' },
                                { data: 'DateRequired' },
                                { data: 'Requestor' },
                                { data: 'SeqNo' },
                                { data: 'Item' },
                                { data: 'ForSR' },
                                { data: 'ForSRBalance' },
                                {
                                    data: 'Cancel',
                                    render: function (data, type, row, meta) {
                                        if (type === "display") {
                                            let rowId = `${row.rowId}`;
                                            let rowVal = parseFloat(row.ForSRBalance).toFixed(2);

                                            //Format Number
                                            let formattedValue = new Intl.NumberFormat('en-US', {
                                                minimumFractionDigits: 2,
                                                maximumFractionDigits: 2
                                            }).format(rowVal);

                                            let textbox = `
                                                    <input prm01010501Cancel="${rowId}" type="text" class="w-100 outline-none text-end border-top-0 border-left-0 border-right-0 border-bottom-2 border-gray-300" Placeholder="Cancel" value="${formattedValue}" onkeypress="return fnEnterKeyNumber(event,this.id)" onblur="fnFormatNumericIssuance(this, ${row.ForSR});" />
                                                `;
                                            return textbox;
                                        }
                                        return data;
                                    }
                                },
                                { data: 'Unit' },
                            ],
                            rowId: 'rowId',
                            columnDefs: [
                                {
                                    targets: 0,
                                    orderable: false
                                },
                                {
                                    targets: [6, 7],
                                    className: 'dt-body-right',
                                    render: $.fn.dataTable.render.number(',', '.', 2)
                                },
                                {
                                    targets: [5],
                                    className: 'tbody-nowrap-auto'
                                }
                            ],
                            orderCellsTop: true,
                        });
                        //datatable

                        //search
                        $('#tbx01010501Find').on('keyup', function () {
                            table01010501Record.search(this.value).draw();
                        });
                        //search

                        //hide loader
                        document.getElementById("div01010501Loader").style.display = "none";
                        //hide loader

                        fnAlertOnly('Record successfully loaded.', 'success', 'btn btn-success');

                        //modal
                        $('#mdl010101Tools').modal('hide');
                        $('#mdl010105CancelSR').modal('show');
                    },
                });
            };
        };
        function fn010101_SCM03RPT00(ID) {
            //access
            fnAccess('SCM080000', 'View', function (response) {
                if (response[0].oReturn == "1") {
                    $.ajax({
                        type: "POST",
                        url: "Assets/Handler/SCM/SCM080100HND.ashx",
                        data: {
                            'FormCode': 'SCM080100',
                            'Type': 'Stock Issuance - Preview Report',
                            'pID': ID,
                            'pReport': "PR",
                            'pCategory': 'PR Printout'
                        },
                        success: function (response) {
                            if (response.status === "success") {
                                window.open(response.viewUrl, '_blank');
                            } else {
                                fnAlertOnly('Error generating report.', 'error', 'btn btn-danger');
                            };
                        }
                    });
                } else {
                    fnAlertOnly('Access denied!', 'error', 'btn btn-danger');
                };
            });
        };
        function fn010101_SCM03RPT01() {
            if (document.getElementById("cbx0101SINo").checked) {
                //access
                fnAccess('SCM080000', 'View', function (response) {
                    if (response[0].oReturn == "1") {
                        $.ajax({
                            type: "POST",
                            url: "Assets/Handler/SCM/SCM080100HND.ashx",
                            data: {
                                'FormCode': 'SCM080100',
                                'Type': 'Stock Issuance - Preview Report',
                                'pID': document.getElementById("ContentPlaceHolder1_hdnID").value,
                                'pReport': "MIS",
                                'pCategory': document.getElementById("lbl0101SILocation").innerText
                            },
                            success: function (response) {
                                if (response.status === "success") {
                                    window.open(response.viewUrl, '_blank');
                                } else {
                                    fnAlertOnly('Error generating report.', 'error', 'btn btn-danger');
                                };
                            }
                        });
                    } else {
                        fnAlertOnly('Access denied!', 'error', 'btn btn-danger');
                    };
                });
            };
        };
        function fn010101_SCM03RPT02() {
            if (document.getElementById("cbx0101GPNo").checked) {
                //access
                fnAccess('SCM080000', 'View', function (response) {
                    if (response[0].oReturn == "1") {
                        $.ajax({
                            type: "POST",
                            url: "Assets/Handler/SCM/SCM080100HND.ashx",
                            data: {
                                'FormCode': 'SCM080100',
                                'Type': 'Stock Issuance - Preview Report',
                                'pID': document.getElementById("ContentPlaceHolder1_hdnID").value,
                                'pReport': "GP",
                                'pCategory': ""
                            },
                            success: function (response) {
                                if (response.status === "success") {
                                    window.open(response.viewUrl, '_blank');
                                } else {
                                    fnAlertOnly('Error generating report.', 'error', 'btn btn-danger');
                                };
                            }
                        });
                    } else {
                        fnAlertOnly('Access denied!', 'error', 'btn btn-danger');
                    };
                });
            };
        };
        function fn010101_SCM03RPT03() {
            //access
            fnAccess('SCM080000', 'View', function (response) {
                if (response[0].oReturn == "1") {
                    $.ajax({
                        type: "POST",
                        url: "Assets/Handler/SCM/SCM080100HND.ashx",
                        data: {
                            'FormCode': 'SCM080100',
                            'Type': 'Stock Issuance - Preview RDLC',
                            'pCategory': 'For Issuance (SR - OSM)'
                        },
                        success: function (response) {
                            if (response.status === "success") {
                                window.open(response.viewUrl, '_blank');
                            } else {
                                fnAlertOnly('Error generating report.', 'error', 'btn btn-danger');
                            };
                        }
                    });
                } else {
                    fnAlertOnly('Access denied!', 'error', 'btn btn-danger');
                };
            });
        };
        function fn010101_SCM03RPT04() {
            //access
            fnAccess('SCM080000', 'View', function (response) {
                if (response[0].oReturn == "1") {
                    $.ajax({
                        type: "POST",
                        url: "Assets/Handler/SCM/SCM080100HND.ashx",
                        data: {
                            'FormCode': 'SCM080100',
                            'Type': 'Stock Issuance - Preview RDLC',
                            'pCategory': 'For Issuance (SR - Non OSM)'
                        },
                        success: function (response) {
                            if (response.status === "success") {
                                window.open(response.viewUrl, '_blank');
                            } else {
                                fnAlertOnly('Error generating report.', 'error', 'btn btn-danger');
                            };
                        }
                    });
                } else {
                    fnAlertOnly('Access denied!', 'error', 'btn btn-danger');
                };
            });
        };
        function fn010101_SCM03RPT05() {
            //access
            fnAccess('SCM080000', 'View', function (response) {
                if (response[0].oReturn == "1") {
                    $.ajax({
                        type: "POST",
                        url: "Assets/Handler/SCM/SCM080100HND.ashx",
                        data: {
                            'FormCode': 'SCM080100',
                            'Type': 'Stock Issuance - Preview RDLC',
                            'pCategory': 'For Issuance (DI)'
                        },
                        success: function (response) {
                            if (response.status === "success") {
                                window.open(response.viewUrl, '_blank');
                            } else {
                                fnAlertOnly('Error generating report.', 'error', 'btn btn-danger');
                            };
                        }
                    });
                } else {
                    fnAlertOnly('Access denied!', 'error', 'btn btn-danger');
                };
            });
        };
        //overview

        //tools
        function fn01010201View(pID) {
            $.ajax({
                type: "POST",
                url: "Assets/Handler/SCM/SCM080100HND.ashx",
                data: {
                    'FormCode': 'SCM080100',
                    'Type': 'PR Find (Trxn)',
                    'pID': pID
                },
                success: function (response) {
                    //display loader
                    document.getElementById("div010501Loader").style.display = "";
                    //display loader

                    $('#table010501Record').DataTable().destroy();

                    //disable column type detection
                    DataTable.types().forEach(type => {
                        DataTable.type(type, 'detect', () => false);
                    });
                    //disable column type detection

                    //sort date by yyyy/mm/dd
                    $.fn.dataTable.moment('MM/DD/YYYY');
                    //sort date by yyyy/mm/dd

                    //datatable
                    var table010501Record = $("#table010501Record").DataTable({
                        processing: true,
                        bFilter: true,
                        bPaginate: false,
                        bInfo: false,
                        paging: false,
                        lengthChange: true,
                        select: true,
                        data: response,
                        columns: [
                            { data: 'Action' },
                            { data: 'Type' },
                            { data: 'No' },
                            { data: 'Date' },
                            { data: 'Post' },
                            { data: 'Rvrs' },
                            { data: 'PreparedBy' },
                        ],
                        rowId: 'rowId',
                        columnDefs: [
                            {
                                targets: [0, 1, 2, 3, 4, 5, 6], orderable: false
                            },
                            {
                                targets: 6, className: 'tbody-nowrap-auto'
                            }
                        ],
                        orderCellsTop: true,
                    });
                    //datatable

                    //search
                    $('#tbx010501Find').on('keyup', function () {
                        table010501Record.search(this.value).draw();
                    });
                    //search

                    //hide loader
                    document.getElementById("div010501Loader").style.display = "none";
                    //hide loader

                    //modal
                    $('#mdl0105Trxn').modal('show');
                },
            });
        };
        //tools

        //transfer
        function fn01010301Transfer_Ok(Btn) {
            // DataTables API 
            var table01010301Record = $('#table01010301Record').DataTable();

            // get all checkboxes across all pages
            var checkBoxes = table01010301Record.$('.cbx01010301SRPO', { page: 'all' });

            // Check if atleast one
            var checkedValues = Array.from(checkBoxes)
                .filter(checkBox => checkBox.checked)
                .map(checkBox => ({
                    PRNo: checkBox.value,
                    SeqNo: checkBox.getAttribute('data-kt-no')
                }));

            if (checkedValues.length > 0) {
                //Array
                let ItemList = [];
                //Loop
                checkedValues.forEach(item => {
                    // Attributes
                    var $tbx01010301Transfer = table01010301Record.$(
                        '[prm01010301Transfer="rowID01010301' + item.PRNo + item.SeqNo + '"]',
                        { page: 'all' }
                    );

                    var $ddl01010301Purchaser = table01010301Record.$(
                        '[prm01010301Purchaser="rowID01010301' + item.PRNo + item.SeqNo + '"]',
                        { page: 'all' }
                    );

                    // Read values safely
                    let transferValue = ($tbx01010301Transfer.length > 0 ? $tbx01010301Transfer.val() : "0");
                    let purchaserValue = ($ddl01010301Purchaser.length > 0 ? $ddl01010301Purchaser.val() : "");

                    //var tbx01010301Transfer = document.querySelector('[prm01010301Transfer="rowID01010301' + item.PRNo + '' + item.SeqNo + '"]');
                    //var ddl01010301Purchaser = document.querySelector('[prm01010301Purchaser="rowID01010301' + item.PRNo + '' + item.SeqNo + '"]');

                    // Push as an object to the array
                    ItemList.push({
                        PRNo: item.PRNo,
                        SeqNo: item.SeqNo,
                        //Transfer: parseFloat(tbx01010301Transfer.value.replace(/,/g, '')),
                        Transfer: transferValue,
                        //Purchaser: ddl01010301Purchaser.value
                        Purchaser: purchaserValue
                    });

                });
                //Format Item
                let ItemSrs = ItemList.map(i =>
                    `${i.PRNo}©${i.SeqNo}©${i.Transfer}©${i.Purchaser}`
                ).join('®');
                let ItemPR = ItemList.map(i => ({
                    PRNo: i.PRNo,
                    SeqNo: i.SeqNo,
                    Transfer: i.Transfer,
                    Purchaser: i.Purchaser
                }));
                //Question
                Transfer_Question(ItemSrs, ItemPR, Btn);
            } else {
                fnAlertOnly('Please select an Item!', 'error', 'btn btn-danger');
                //Disable the clicked button to avoid multiple clicks
                Btn.disabled = false;
                // Hide loading indication
                Btn.removeAttribute('data-kt-indicator');
            };
            //Return Question
            function Transfer_Question(ItemSrs, ItemPR, Btn) {
                Swal.fire({
                    title: '<span class="fs-6 fw-normal text-gray-700">Selected items will permanently be transfered to CP, transfer Item(s)?</span>',
                    html: `<input id="tbx01010301Password" type="password" class="form-control form-control-sm" Placeholder="Password" maxlength="20" />`,
                    icon: 'question',
                    iconColor: '#009ef7',
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
                        fnValidatePassword(document.getElementById("tbx01010301Password").value, function (response) {
                            if (response[0].oReturn == "") {
                                Transfer_Ok(ItemSrs, ItemPR, Btn);
                            } else {
                                fnAlertOnly(response[0].oReturn, 'warning', 'btn btn-warning');
                            };
                        });
                    } else {
                        // Disable the clicked button to avoid multiple clicks
                        Btn.disabled = false;
                        // Hide loading indication
                        Btn.removeAttribute('data-kt-indicator');
                    }
                });
            };
            // Add transfer
            function Transfer_Ok(ItemSrs, ItemPR, Btn) {
                //issuance
                $.ajax({
                    type: "POST",
                    url: "Assets/Handler/SCM/SCM080100HND.ashx",
                    data: {
                        'FormCode': 'SCM080100',
                        'Type': 'Stock Issuance - Add Transfer Item : SR > PO',
                        'pItemSrs': ItemSrs
                    },
                    success: async function (response) {
                        //alert
                        fnAlertOnly('Record successfully transferred.', 'success', 'btn btn-success');
                        // Disable the clicked button to avoid multiple clicks
                        Btn.disabled = false;
                        // Hide loading indication
                        Btn.removeAttribute('data-kt-indicator');
                        // Modal
                        $("#mdl010103SRPO").modal("hide");
                    },
                });
            };
        };
        function fn01010401Transfer_Ok(Btn) {
            // Get all
            //var checkBoxes = document.querySelectorAll('.cbx01010401SRCP');

            // DataTables API (important fix for pagination issue!)
            var table01010401Record = $('#table01010401Record').DataTable();

            // get all checkboxes across all pages
            var checkBoxes = table01010401Record.$('.cbx01010401SRCP', { page: 'all' });

            // Check if atleast one
            var checkedValues = Array.from(checkBoxes)
                .filter(checkBox => checkBox.checked)
                .map(checkBox => ({
                    PRNo: checkBox.value,
                    SeqNo: checkBox.getAttribute('data-kt-no')
                }));

            if (checkedValues.length > 0) {
                //Array
                let ItemList = [];
                //Loop
                checkedValues.forEach(item => {

                    // Selectors must match your HTML attributes!
                    var $tbx01010401Transfer = table01010401Record.$(
                        '[prm01010401Transfer="rowID01010401' + item.PRNo + item.SeqNo + '"]',
                        { page: 'all' }
                    );
                    // Read values safely
                    let transferValue = ($tbx01010401Transfer.length > 0 ? $tbx01010401Transfer.val() : "0");

                    //var tbx01010401Transfer = document.querySelector('[prm01010401Transfer="rowID01010401' + item.PRNo + '' + item.SeqNo + '"]');

                    // Push as an object to the array
                    ItemList.push({
                        PRNo: item.PRNo,
                        SeqNo: item.SeqNo,
                        //Transfer: parseFloat(tbx01010401Transfer.value.replace(/,/g, ''))
                        Transfer: transferValue
                    });

                });
                //Format Item
                let ItemSrs = ItemList.map(i =>
                    `${i.PRNo}©${i.SeqNo}©${i.Transfer}`
                ).join('®');
                let ItemPR = ItemList.map(i => ({
                    PRNo: i.PRNo,
                    SeqNo: i.SeqNo,
                    Transfer: i.Transfer
                }));
                //Question
                Transfer_Question(ItemSrs, ItemPR, Btn);
            } else {
                fnAlertOnly('Please select an Item!', 'error', 'btn btn-danger');
                //Disable the clicked button to avoid multiple clicks
                Btn.disabled = false;
                // Hide loading indication
                Btn.removeAttribute('data-kt-indicator');
            };
            //Return Question
            function Transfer_Question(ItemSrs, ItemPR, Btn) {
                Swal.fire({
                    title: '<span class="fs-6 fw-normal text-gray-700">Selected items will permanently be transfered to CP, transfer Item(s)?</span>',
                    html: `<input id="tbx01010401Password" type="password" class="form-control form-control-sm" Placeholder="Password" maxlength="20" />`,
                    icon: 'question',
                    iconColor: '#009ef7',
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
                        fnValidatePassword(document.getElementById("tbx01010401Password").value, function (response) {
                            if (response[0].oReturn == "") {
                                Transfer_Ok(ItemSrs, ItemPR, Btn);
                            } else {
                                fnAlertOnly(response[0].oReturn, 'warning', 'btn btn-warning');
                            };
                        });
                    } else {
                        // Disable the clicked button to avoid multiple clicks
                        Btn.disabled = false;
                        // Hide loading indication
                        Btn.removeAttribute('data-kt-indicator');
                    }
                });
            };
            // Add transfer
            function Transfer_Ok(ItemSrs, ItemPR, Btn) {
                //issuance
                $.ajax({
                    type: "POST",
                    url: "Assets/Handler/SCM/SCM080100HND.ashx",
                    data: {
                        'FormCode': 'SCM080100',
                        'Type': 'Stock Issuance - Add Transfer Item : SR > CP',
                        'pItemSrs': ItemSrs
                    },
                    success: async function (response) {
                        //alert
                        fnAlertOnly('Record successfully transferred.', 'success', 'btn btn-success');
                        // Disable the clicked button to avoid multiple clicks
                        Btn.disabled = false;
                        // Hide loading indication
                        Btn.removeAttribute('data-kt-indicator');
                        // Modal
                        $("#mdl010104SRCP").modal("hide");
                    },
                });
            };
        };
        function fn01010501Cancel_Ok(Btn) {
            // Get all
            //var checkBoxes = document.querySelectorAll('.cbx01010501CancelSR');

            // DataTables API (important fix for pagination issue!)
            var table01010501Record = $('#table01010501Record').DataTable();

            // get all checkboxes across all pages
            var checkBoxes = table01010501Record.$('.cbx01010501CancelSR', { page: 'all' });

            // Check if atleast one
            var checkedValues = Array.from(checkBoxes)
                .filter(checkBox => checkBox.checked)
                .map(checkBox => ({
                    PRNo: checkBox.value,
                    SeqNo: checkBox.getAttribute('data-kt-no')
                }));

            if (checkedValues.length > 0) {
                //Array
                let ItemList = [];
                //Loop
                checkedValues.forEach(item => {
                    //var tbx01010501Cancel = document.querySelector('[prm01010501Cancel="rowID01010501' + item.PRNo + '' + item.SeqNo + '"]');

                    // Selectors must match your HTML attributes
                    var $tbx01010501Cancel = table01010501Record.$(
                        '[prm01010501Cancel="rowID01010501' + item.PRNo + item.SeqNo + '"]',
                        { page: 'all' }
                    );
                    // Read values safely
                    let cancelValue = ($tbx01010501Cancel.length > 0 ? $tbx01010501Cancel.val() : "0");

                    // Push as an object to the array
                    ItemList.push({
                        PRNo: item.PRNo,
                        SeqNo: item.SeqNo,
                        //Cancel: parseFloat(tbx01010501Cancel.value.replace(/,/g, ''))
                        Cancel: cancelValue
                    });

                });
                //Format Item
                let ItemSrs = ItemList.map(i =>
                    `${i.PRNo}©${i.SeqNo}©${i.Cancel}`
                ).join('®');
                let ItemPR = ItemList.map(i => ({
                    PRNo: i.PRNo,
                    SeqNo: i.SeqNo,
                    Cancel: i.Cancel
                }));
                //Question
                Transfer_Question(ItemSrs, ItemPR, Btn);
            } else {
                fnAlertOnly('Please select an Item!', 'error', 'btn btn-danger');
                //Disable the clicked button to avoid multiple clicks
                Btn.disabled = false;
                // Hide loading indication
                Btn.removeAttribute('data-kt-indicator');
            };
            //Return Question
            function Transfer_Question(ItemSrs, ItemPR, Btn) {
                Swal.fire({
                    title: '<span class="fs-6 fw-normal text-gray-700">Selected items will permanently be cancelled, cancel Item(s)?</span>',
                    html: `<input id="tbx01010501Password" type="password" class="form-control form-control-sm" Placeholder="Password" maxlength="20" />`,
                    icon: 'question',
                    iconColor: '#009ef7',
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
                        fnValidatePassword(document.getElementById("tbx01010501Password").value, function (response) {
                            if (response[0].oReturn == "") {
                                Cancel_Ok(ItemSrs, ItemPR, Btn);
                            } else {
                                fnAlertOnly(response[0].oReturn, 'warning', 'btn btn-warning');
                            };
                        });
                    } else {
                        // Disable the clicked button to avoid multiple clicks
                        Btn.disabled = false;
                        // Hide loading indication
                        Btn.removeAttribute('data-kt-indicator');
                    }
                });
            };
            // Add transfer
            function Cancel_Ok(ItemSrs, ItemPR, Btn) {
                //cancel
                $.ajax({
                    type: "POST",
                    url: "Assets/Handler/SCM/SCM080100HND.ashx",
                    data: {
                        'FormCode': 'SCM080100',
                        'Type': 'Stock Issuance - Add Cancel Item : SR',
                        'pItemSrs': ItemSrs
                    },
                    success: async function (response) {
                        //alert
                        fnAlertOnly('Record successfully cancelled.', 'success', 'btn btn-success');
                        // Disable the clicked button to avoid multiple clicks
                        Btn.disabled = false;
                        // Hide loading indication
                        Btn.removeAttribute('data-kt-indicator');
                        // Modal
                        $("#mdl010105CancelSR").modal("hide");
                    },
                });
            };
        };
        //transfer

        //report
        function fn010501View(pID, pCode, pType) {
            //access
            fnAccess('SCM080000', 'View', function (response) {
                if (response[0].oReturn == "1") {
                    $.ajax({
                        type: "POST",
                        url: "Assets/Handler/SCM/SCM080100HND.ashx",
                        data: {
                            'FormCode': 'SCM070100',
                            'Type': 'Preview Report',
                            'pID': pID,
                            'pCode': pCode,
                            'pType': pType
                        },
                        success: function (response) {
                            if (response.status === "success") {
                                window.open(response.viewUrl, '_blank');
                            } else {
                                fnAlertOnly('Error generating report.', 'error', 'btn btn-danger');
                            };
                        }
                    });
                } else {
                    fnAlertOnly('Access denied!', 'error', 'btn btn-danger');
                };
            });
        };
        //report

        //particular
        function fn0102LoadParticular(pMode, pID) {
            $.ajax({
                type: "POST",
                url: "Assets/Handler/SCM/SCM080100HND.ashx",
                data: {
                    'FormCode': 'SCM080100',
                    'Type': 'Stock Issuance - Particular',
                    'pID': pID
                },
                success: function (response) {
                    //display loader
                    document.getElementById("div0102LoaderParticular").style.display = "";
                    //display loader

                    $('#table0102Particular').DataTable().destroy();

                    //disable column type detection
                    DataTable.types().forEach(type => {
                        DataTable.type(type, 'detect', () => false);
                    });
                    //disable column type detection

                    //sort date by yyyy/mm/dd
                    $.fn.dataTable.moment('MM/DD/YYYY');
                    //sort date by yyyy/mm/dd

                    //datatable
                    var table0102Particular = $("#table0102Particular").DataTable({
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
                            { data: 'No' },
                            { data: 'ItemName' },
                            { data: 'Qty' },
                            { data: 'UMName' },
                            { data: 'Remarks' },
                            { data: 'PRNo' },
                            { data: 'PRSeqNo' },
                            { data: 'PRItem' },
                            { data: 'PRQty' },
                            { data: 'PRUnit' }
                        ],
                        rowId: 'rowId',
                        columnDefs: [
                            {
                                targets: [0],
                                orderable: false
                            },
                            {
                                targets: [3, 9],
                                className: 'dt-body-right',
                                render: $.fn.dataTable.render.number(',', '.', 2)
                            },
                            {
                                targets: [2, 5, 8],
                                className: 'tbody-nowrap-auto'
                            }
                        ],
                        ordering: false
                    });
                    //datatable

                    //search
                    $('#tbx0102FindParticular').on('keyup', function () {
                        table0102Particular.search(this.value).draw();
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
                    } else if (pMode = "DTL") {
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
        function fn0102Redraw(Action, pID, pSeqNo) {
            //update list
            if (Action == "Add" || Action == "Edit") {
                $.ajax({
                    type: "POST",
                    url: "Assets/Handler/SCM/SCM080100HND.ashx",
                    data: {
                        'FormCode': 'SCM080100',
                        'Type': 'Get Record - DTL - Particular : Redraw',
                        'pID': pID,
                        'pSeqNo': pSeqNo
                    },
                    success: function (response) {
                        if (Action == "Add") {
                            //add row
                            var gv01 = $('#table0102Particular').DataTable();
                            gv01.rows().deselect();
                            //last row
                            let lastrowId = "";
                            response.forEach(item => {
                                var row01 = gv01.row.add({
                                    Action: item.Action,
                                    No: item.No,
                                    ItemName: item.ItemName,
                                    Qty: item.Qty,
                                    UMName: item.UMName,
                                    Remarks: item.Remarks,
                                    PRNo: item.PRNo,
                                    PRSeqNo: item.PRSeqNo,
                                    PRItem: item.PRItem,
                                    PRQty: item.PRQty,
                                    PRUnit: item.PRUnit
                                }).draw(false).select();
                                // Set ID for each row
                                $(row01.node()).attr('id', item.rowId);

                                // Keep track of the last row ID to scroll to it later
                                lastRowId = item.rowId;
                            });

                            // Scroll to the last added row
                            if (lastRowId !== '') {
                                let new01 = gv01.row('#' + lastRowId);
                                let index01 = new01.index();
                                var rowNode = gv01.row(index01).node();
                                rowNode.scrollIntoView({ behavior: 'smooth', block: 'center' });
                            };
                        } else if (Action == "Edit") {
                            //edit row
                            var gv01 = $('#table0102Particular').DataTable();
                            gv01.rows().deselect();
                            let row01 = gv01.row('#' + response[0].rowId);
                            let index01 = row01.index();
                            gv01.cell({ row: index01, column: 0 }).data(response[0].Action).draw(false);
                            gv01.cell({ row: index01, column: 1 }).data(response[0].No).draw(false);
                            gv01.cell({ row: index01, column: 2 }).data(response[0].ItemName).draw(false);
                            gv01.cell({ row: index01, column: 3 }).data(response[0].Qty).draw(false);
                            gv01.cell({ row: index01, column: 4 }).data(response[0].UMName).draw(false);
                            gv01.cell({ row: index01, column: 5 }).data(response[0].Remarks).draw(false);
                            gv01.cell({ row: index01, column: 6 }).data(response[0].PRNo).draw(false);
                            gv01.cell({ row: index01, column: 7 }).data(response[0].PRSeqNo).draw(false);
                            gv01.cell({ row: index01, column: 8 }).data(response[0].PRItem).draw(false);
                            gv01.cell({ row: index01, column: 9 }).data(response[0].PRQty).draw(false);
                            gv01.cell({ row: index01, column: 10 }).data(response[0].PRUnit).draw(false);
                            //edit row

                            //select and go to record
                            row01.select();
                            var rowNode = gv01.row(index01).node();
                            rowNode.scrollIntoView({ behavior: 'smooth', block: 'center' });
                            //select and go to record
                        };
                    },
                });
            } else {
                //assigned
                var gv01 = $('#table0102Particular').DataTable();
                let pCode = pID + '' + pSeqNo;
                gv01.row('#rowID0102' + pCode).remove().draw(false);
            };
        };
        async function fn01020201Redraw(Action, PRNo, SeqNo) {
            return new Promise(resolve => {
                //update list
                if (Action == "Add" || Action == "Edit") {
                    $.ajax({
                        type: "POST",
                        url: "Assets/Handler/SCM/SCM080100HND.ashx",
                        data: {
                            'FormCode': 'SCM080100',
                            'Type': 'Get Record - DTL - Particular : PR Redraw',
                            'pRequestor': document.getElementById("ContentPlaceHolder1_hf0101RequestedByCode").value,
                            'pPRNo': PRNo,
                            'pSeqNo': SeqNo
                        },
                        success: function (response) {
                            if (Action == "Add") {
                                //add row
                                var gv01 = $('#table01020201Record').DataTable();
                                gv01.rows().deselect();
                                //last row
                                let lastRowId = "";
                                response.forEach(item => {
                                    var row01 = gv01.row.add(
                                        {
                                            Action: item.Action,
                                            PRNo: item.PRNo,
                                            SeqNo: item.SeqNo,
                                            Item: item.Item,
                                            ForSR: item.ForSR,
                                            ForSRBalance: item.ForSRBalance,
                                            Issuance: item.Issuance,
                                            Unit: item.Unit
                                        }).draw(false).select();
                                    // Set ID for each row
                                    $(row01.node()).attr('id', item.rowId);

                                    // Keep track of the last row ID to scroll to it later
                                    lastRowId = item.rowId;
                                });

                                // Scroll to the last added row
                                if (lastRowId !== '') {
                                    let new01 = gv01.row('#' + lastRowId);
                                    let index01 = new01.index();
                                    var rowNode = gv01.row(index01).node();
                                    rowNode.scrollIntoView({ behavior: 'smooth', block: 'center' });
                                };

                            } else if (Action == "Edit") {
                                //edit row
                                var gv01 = $('#table01020201Record').DataTable();
                                gv01.rows().deselect();

                                response.forEach(item => {
                                    let row01 = gv01.row('#' + item.rowId);
                                    if (row01.length === 0) return; // Skip if row not found

                                    let index01 = row01.index();

                                    gv01.cell({ row: index01, column: 0 }).data(item.Action).draw(false);
                                    gv01.cell({ row: index01, column: 1 }).data(item.PRNo).draw(false);
                                    gv01.cell({ row: index01, column: 2 }).data(item.SeqNo).draw(false);
                                    gv01.cell({ row: index01, column: 3 }).data(item.Item).draw(false);
                                    gv01.cell({ row: index01, column: 4 }).data(item.ForSR).draw(false);
                                    gv01.cell({ row: index01, column: 5 }).data(item.ForSRBalance).draw(false);
                                    gv01.cell({ row: index01, column: 6 }).data(item.Issuance).draw(false);
                                    gv01.cell({ row: index01, column: 7 }).data(item.Unit).draw(false);

                                    //select and scroll to record
                                    row01.select();
                                    var rowNode = gv01.row(index01).node();
                                    rowNode.scrollIntoView({ behavior: 'smooth', block: 'center' });
                                });
                            };
                        },
                    });
                } else {
                    //assigned
                    var gv01 = $('#table01020201Record').DataTable();
                    let Code = PRNo + '' + SeqNo;
                    gv01.row('#rowID01020201' + Code).remove().draw(false);
                };
                resolve();
            });
        };
        async function fn01020202Redraw(Action, IRNo, SeqNo) {
            return new Promise(resolve => {
                //update list
                if (Action == "Add" || Action == "Edit") {
                    $.ajax({
                        type: "POST",
                        url: "Assets/Handler/SCM/SCM080100HND.ashx",
                        data: {
                            'FormCode': 'SCM080100',
                            'Type': 'Get Record - DTL - Particular : DI Redraw',
                            'pRequestor': document.getElementById("ContentPlaceHolder1_hf0101RequestedByCode").value,
                            'pIRNo': IRNo,
                            'pSeqNo': SeqNo
                        },
                        success: function (response) {
                            if (Action == "Add") {
                                //add row
                                var gv01 = $('#table01020202Record').DataTable();
                                gv01.rows().deselect();
                                //last row
                                let lastRowId = "";
                                response.forEach(item => {
                                    var row01 = gv01.row.add(
                                        {
                                            Action: item.Action,
                                            IRNo: item.IRNo,
                                            SeqNo: item.SeqNo,
                                            Item: item.Item,
                                            ForGP: item.ForGP,
                                            ForGPBalance: item.ForGPBalance,
                                            Issuance: item.Issuance,
                                            Unit: item.Unit
                                        }).draw(false).select();
                                    // Set ID for each row
                                    $(row01.node()).attr('id', item.rowId);

                                    // Keep track of the last row ID to scroll to it later
                                    lastRowId = item.rowId;
                                });

                                // Scroll to the last added row
                                if (lastRowId !== '') {
                                    let new01 = gv01.row('#' + lastRowId);
                                    let index01 = new01.index();
                                    var rowNode = gv01.row(index01).node();
                                    rowNode.scrollIntoView({ behavior: 'smooth', block: 'center' });
                                };

                            } else if (Action == "Edit") {
                                //edit row
                                var gv01 = $('#table01020202Record').DataTable();
                                gv01.rows().deselect();

                                response.forEach(item => {
                                    let row01 = gv01.row('#' + item.rowId);
                                    if (row01.length === 0) return;

                                    let index01 = row01.index();

                                    gv01.cell({ row: index01, column: 0 }).data(item.Action).draw(false);
                                    gv01.cell({ row: index01, column: 1 }).data(item.IRNo).draw(false);
                                    gv01.cell({ row: index01, column: 2 }).data(item.SeqNo).draw(false);
                                    gv01.cell({ row: index01, column: 3 }).data(item.Item).draw(false);
                                    gv01.cell({ row: index01, column: 4 }).data(item.ForGP).draw(false);
                                    gv01.cell({ row: index01, column: 5 }).data(item.ForGPBalance).draw(false);
                                    gv01.cell({ row: index01, column: 6 }).data(item.Issuance).draw(false);
                                    gv01.cell({ row: index01, column: 7 }).data(item.Unit).draw(false);

                                    //select and scroll to record
                                    row01.select();
                                    var rowNode = gv01.row(index01).node();
                                    rowNode.scrollIntoView({ behavior: 'smooth', block: 'center' });
                                });
                            };
                        },
                    });
                } else {
                    //assigned
                    var gv01 = $('#table01020202Record').DataTable();
                    let Code = IRNo + '' + SeqNo;
                    gv01.row('#rowID01020202' + Code).remove().draw(false);
                };
                //modal
                resolve();
            });
        };
        function fn0102Add() {
            //if exist
            fnIfExist('ogm_si_hdr', 'si_code', document.getElementById('ContentPlaceHolder1_hdnID').value, function (response) {
                if (response[0].oReturn == "1") {
                    Access();
                } else {
                    window.location.replace("MNU040100");
                };
            });
            //access
            function Access() {
                fnAccess('SCM080000', 'Add', function (response) {
                    if (response[0].oReturn == "1") {
                        Validate(document.getElementById('ContentPlaceHolder1_hdnID').value);
                    } else {
                        fnAlertOnly('Access denied!', 'error', 'btn btn-danger');
                    };
                });
            };
            //validate
            function Validate(ID) {
                fnValidateRecord('Trxn_SIHdr', ID, '', 'Save', function (response) {
                    if (response[0].oReturn == "") {
                        Add();
                    } else {
                        fnAlertOnly(response[0].oReturn, 'warning', 'btn btn-warning');
                    };
                });
            };
            function Add() {
                if (document.getElementById("cbx0101SINo").checked != false) {
                    document.getElementById("tbx010201Item").value = "";
                    document.getElementById("ContentPlaceHolder1_hf010201ItemCode").value = "";
                    document.getElementById("tbx010201Qty").value = "0.00";
                    document.getElementById("ContentPlaceHolder1_hf010201Cost").value = "";
                    document.getElementById("ContentPlaceHolder1_hf010201Total").value = "";
                    document.getElementById("tbx010201UOM").value = "";
                    document.getElementById("ContentPlaceHolder1_hf010201UOMCode").value = "";
                    document.getElementById("tbx010201Remarks").value = "";
                    document.getElementById("tbx010201PRNo").value = "";
                    document.getElementById("tbx010201PRSeqNo").value = "";
                    document.getElementById("tbx010201PRItem").value = "";
                    document.getElementById("tbx010201PRQty").value = "0.00";
                    document.getElementById("tbx010201PRUOM").value = "";
                    $('#mdl0102Add').modal('show');
                };
            };
        };
        function fn010201Item() {
            //item
            $.ajax({
                type: "POST",
                url: "Assets/Handler/SCM/SCM080100HND.ashx",
                data: {
                    'FormCode': 'SCM080100',
                    'Type': 'Stock Issuance - Add Record : Item',
                    'pWarehouse': document.getElementById("ContentPlaceHolder1_hf0101Warehouse").value
                },
                success: function (response) {
                    //display loader
                    document.getElementById("div010401Loader").style.display = "";
                    //display loader

                    $('#table010401Item').DataTable().destroy();

                    //disable column type detection
                    DataTable.types().forEach(type => {
                        DataTable.type(type, 'detect', () => false);
                    });
                    //disable column type detection

                    //sort date by yyyy/mm/dd
                    $.fn.dataTable.moment('MM/DD/YYYY');
                    //sort date by yyyy/mm/dd

                    //datatable
                    var table010401Item = $("#table010401Item").DataTable({
                        processing: true,
                        bFilter: true,
                        bPaginate: true,
                        bInfo: false,
                        paging: true,
                        lengthChange: true,
                        pageLength: 25,
                        select: true,
                        data: response,
                        columns: [
                            { data: 'Action' },
                            { data: 'Code' },
                            { data: 'Lock' },
                            { data: 'ItemName' },
                            { data: 'Qty' },
                            { data: 'UMName' },
                            { data: 'Cost' },
                            { data: 'Total' },
                        ],
                        rowId: 'rowId',
                        columnDefs: [
                            {
                                targets: 0, orderable: false
                            },
                            {
                                targets: [4, 6 ,7],
                                className: 'dt-body-right',
                                render: $.fn.dataTable.render.number(',', '.', 2)
                            },
                            {
                                targets: 3, className: 'tbody-nowrap-auto'
                            }
                        ],
                        order: [[3, 'asc']],
                        orderCellsTop: true,
                    });
                    //datatable

                    //search
                    $('#tbx010401Find').on('keyup', function () {
                        table010401Item.search(this.value).draw();
                    });
                    //search

                    //hide loader
                    document.getElementById("div010401Loader").style.display = "none";
                    //hide loader

                    //modal
                    $('#mdl0104Item').modal('show');
                },
            });
        };
        function fn010201Add_Ok(Btn) {
            //if exisit
            fnIfExist('ogm_si_hdr', 'si_code', document.getElementById('ContentPlaceHolder1_hdnID').value, function (response) {
                if (response[0].oReturn == "1") {
                    Access();
                } else {
                    window.location.replace("MNU040100");
                };
            });
            //access
            function Access() {
                fnAccess('SCM080000', 'Add', function (response) {
                    if (response[0].oReturn == "1") {
                        Validate(document.getElementById('ContentPlaceHolder1_hdnID').value);
                    } else {
                        fnAlertOnly('Access denied!', 'error', 'btn btn-danger');
                    };
                });
            };
            //validate
            function Validate(ID, SeqNo) {
                fnValidateRecord('Trxn_SIHdr', ID, '', 'Save', function (response) {
                    if (response[0].oReturn !== "") {
                        fnAlertOnly(response[0].oReturn,'warning','btn btn-warning' );
                        return;
                    }
                    var Name = document.getElementById("tbx010201Item").value;
                    var qty = parseFloat(document.getElementById("tbx010201Qty").value.replace(/,/g, '')) || 0;
                    var hdnQty = parseFloat(document.getElementById("hdn010201Qty").value.replace(/,/g, '')) || 0;

                    if (Name == "") {
                        fnAlertOnly("Please select an item first.", 'warning', 'btn btn-warning');
                        return;
                    }

                    if (hdnQty == 0) {
                        fnAlertOnly(Name + " has no current Warehouse Item Qty. on hand!", 'warning', 'btn btn-warning');
                        return;
                    }
                    if (qty == 0) {
                        fnAlertOnly("Please enter a quantity greater than 0.", 'warning', 'btn btn-warning');
                        return;
                    }
                    if (qty > hdnQty) {
                        fnAlertOnly( Name + " exceeds the current Warehouse Item Qty. on hand!", 'warning','btn btn-warning');
                        return;
                    }



                    Edit_DTL_Ok(ID);
                });
            }
            //edit
            async function Edit_DTL_Ok(ID) {
                // Disable the clicked button to avoid multiple clicks
                Btn.disabled = true;
                // Show loading indicator
                Btn.setAttribute('data-kt-indicator', 'on');
                // Simulate form submission
                await Edit_DTL_Ok_Await(Btn, ID);
            };
            function Edit_DTL_Ok_Await(Btn, ID) {
                // process
                return new Promise(resolve => {
                    //Validate
                    if (document.getElementById("tbx010201Item").value == "") {
                        //Alert
                        fnAlertOnly('Some field(s) are missing!', 'error', 'btn btn-danger');
                    } else if (document.getElementById("tbx010201Qty").value == "") {
                        //Alert
                        fnAlertOnly('Some field(s) are missing!', 'error', 'btn btn-danger');
                    } else {
                        Edit_DTL_Question(ID);
                    };

                    //question
                    function Edit_DTL_Question(ID) {
                        Swal.fire({
                            text: 'Current record/changes will be saved?',
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
                                fnValidateRecord('Trxn_SIHdr', ID, '', 'Save', function (response) {
                                    if (response[0].oReturn == "") {
                                        Edit_Ok(ID);
                                    } else {
                                        fnAlertOnly(response[0].oReturn, 'warning', 'btn btn-warning');
                                    };
                                });
                            } else {
                                // Disable the clicked button to avoid multiple clicks
                                Btn.disabled = true;
                                // Hide loading indication
                                Btn.removeAttribute('data-kt-indicator');
                            };
                        });
                    };
                    //edit
                    function Edit_Ok(ID) {
                        $.ajax({
                            type: "POST",
                            url: "Assets/Handler/SCM/SCM080100HND.ashx",
                            data: {
                                'FormCode': 'SCM080100',
                                'Type': 'Stock Issuance - Add Record : Particular',
                                'pID': ID,
                                'pType': 'SI',
                                'pItemCode': document.getElementById("ContentPlaceHolder1_hf010201ItemCode").value,
                                'pQty': document.getElementById("tbx010201Qty").value,
                                'pUOMCode': document.getElementById("ContentPlaceHolder1_hf010201UOMCode").value,
                                'pCost': document.getElementById("ContentPlaceHolder1_hf010201Cost").value,
                                'pTotal': document.getElementById("ContentPlaceHolder1_hf010201Total").value,
                                'pRemarks': document.getElementById("tbx010201Remarks").value,
                            },
                            success: function (response) {
                                //add
                                fnAlertOnly('Record successfully updated.', 'success', 'btn btn-success');
                                document.getElementById("tbx010201Item").value = "";
                                document.getElementById("ContentPlaceHolder1_hf010201ItemCode").value = "";
                                document.getElementById("tbx010201Qty").value = "0.00";
                                document.getElementById("ContentPlaceHolder1_hf010201Cost").value = "";
                                document.getElementById("ContentPlaceHolder1_hf010201Total").value = "";
                                document.getElementById("tbx010201UOM").value = "";
                                document.getElementById("ContentPlaceHolder1_hf010201UOMCode").value = "";
                                document.getElementById("tbx010201Remarks").value = "";
                                document.getElementById("tbx010201PRNo").value = "";
                                document.getElementById("tbx010201PRSeqNo").value = "";
                                document.getElementById("tbx010201PRItem").value = "";
                                document.getElementById("tbx010201PRQty").value = "0.00";
                                document.getElementById("tbx010201PRUOM").value = "";
                                fn0102Redraw("Add", response[0].oID, response[0].oSeqNo);
                            },
                        });
                        //modal
                        $('#mdl0102Add').modal('hide');
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
        function fn010202Item(pItemCode, pLock) {
            //validate
            if (pLock == 1) {
                Item(pItemCode);
            } else {
                fnAlertOnly('Record is unlocked, it cannot be used!', 'error', 'btn btn-danger');
            };
            //item
            function Item(pItemCode) {
                //bind
                $.ajax({
                    type: "POST",
                    url: "Assets/Handler/SCM/SCM080100HND.ashx",
                    data: {
                        'FormCode': 'SCM080100',
                        'Type': 'Get Record : Item',
                        'pTblFrom': 'SI',
                        'pItemCode': pItemCode,
                        'pWarehouse': document.getElementById("ContentPlaceHolder1_hf0101Warehouse").value
                    },
                    success: function (response) {
                        document.getElementById("ContentPlaceHolder1_hf010201ItemCode").value = response[0].ItemCode;
                        document.getElementById("tbx010201Item").value = response[0].ItemName;
                        document.getElementById("tbx010201Qty").value = formatNumber(response[0].Qty);
                        document.getElementById("hdn010201Qty").value = formatNumber(response[0].Qty);
                        document.getElementById("ContentPlaceHolder1_hf010201Cost").value = formatNumber(response[0].Cost);
                        document.getElementById("ContentPlaceHolder1_hf010201UOMCode").value = response[0].UMCode;
                        document.getElementById("tbx010201UOM").value = response[0].UMName;
                        let newCost = parseFloat(document.getElementById("tbx010201Qty").value.replace(/,/g, '')) * response[0].Cost;
                        document.getElementById("ContentPlaceHolder1_hf010201Total").value = formatNumber(newCost);
                        //modal
                        $('#mdl0104Item').modal('hide');
                    },
                });
            };
};
        function fn0102AddPR() {
            //if exist
            fnIfExist('ogm_si_hdr', 'si_code', document.getElementById('ContentPlaceHolder1_hdnID').value, function (response) {
                if (response[0].oReturn == "1") {
                    Access();
                } else {
                    window.location.replace("MNU040100");
                };
            });
            //access
            function Access() {
                fnAccess('SCM080000', 'Add', function (response) {
                    if (response[0].oReturn == "1") {
                        Validate(document.getElementById('ContentPlaceHolder1_hdnID').value);
                    } else {
                        fnAlertOnly('Access denied!', 'error', 'btn btn-danger');
                    };
                });
            };
            //validate
            function Validate(ID) {
                fnValidateRecord('Trxn_SIHdr', ID, '', 'Save', function (response) {
                    if (response[0].oReturn == "") {
                        Add();
                    } else {
                        fnAlertOnly(response[0].oReturn, 'warning', 'btn btn-warning');
                    };
                });
            };
            function Add() {
                if (document.getElementById("cbx0101SINo").checked != false) {
                    $.ajax({
                        type: "POST",
                        url: "Assets/Handler/SCM/SCM080100HND.ashx",
                        data: {
                            'FormCode': 'SCM080100',
                            'Type': 'Get Record - DTL - Particular : PR',
                            'pRequestor': document.getElementById("ContentPlaceHolder1_hf0101RequestedByCode").value
                        },
                        beforeSend: function () {
                            // Show Swal loader
                            Swal.fire({
                                title: 'Loading...',
                                text: 'Please wait while data is being processed.',
                                allowOutsideClick: false,
                                didOpen: () => {
                                    Swal.showLoading();
                                }
                            });
                        },
                        success: function (response) {
                            //hide loader
                            document.getElementById("div01020201Loader").style.display = "";
                            //hide loader

                            $('#table01020201Record').DataTable().destroy();

                            //disable column type detection
                            DataTable.types().forEach(type => {
                                DataTable.type(type, 'detect', () => false);
                            });
                            //disable column type detection

                            //sort date by yyyy/mm/dd
                            $.fn.dataTable.moment('MM/DD/YYYY');
                            //sort date by yyyy/mm/dd

                            //datatable
                            var table01020201Record = $("#table01020201Record").DataTable({
                                processing: true,
                                bFilter: true,
                                bPaginate: true,
                                bInfo: false,
                                paging: true,
                                lengthChange: true,
                                pageLength: 25,
                                select: true,
                                data: response,
                                columns: [
                                    { data: 'Action' },
                                    { data: 'PRNo', },
                                    { data: 'SeqNo' },
                                    { data: 'Item' },
                                    { data: 'ForSR' },
                                    { data: 'ForSRBalance' },
                                    { data: 'Issuance',
                                        render: function (data, type, row, meta) {
                                            if (type === "display") {
                                                let rowId = `${row.rowId}`;
                                                let rowVal = parseFloat(row.ForSRBalance).toFixed(2);

                                                //Format Number
                                                let formattedValue = new Intl.NumberFormat('en-US', {
                                                    minimumFractionDigits: 2,
                                                    maximumFractionDigits: 2
                                                }).format(rowVal);

                                                let textbox = `
                                                    <input prm01020201Issuance="${rowId}" type="text" class="w-100 outline-none text-end border-top-0 border-left-0 border-right-0 border-bottom-2 border-gray-300" Placeholder="Issuance" value="${formattedValue}" onkeypress="return fnEnterKeyNumber(event,this.id)" onblur="fnFormatNumericIssuance(this, ${row.ForSR});" />
                                                `;
                                                return textbox;
                                            }
                                            return data;
                                        }
                                    },
                                    { data: 'Unit' },
                                ],
                                drawCallback: function () {
                                    $('[data-kt-repeater="select2"]').select2({
                                        width: '100%'
                                    });
                                },
                                rowId: 'rowId',
                                columnDefs: [
                                    {
                                        targets: [0],
                                        orderable: false,
                                    }
                                    ,
                                    {
                                        targets: [3],
                                        className: 'tbody-nowrap-auto'
                                    },
                                    {
                                        targets: [4, 5, 6],
                                        className: 'dt-body-right',
                                        render: $.fn.dataTable.render.number(',', '.', 2)
                                    }
                                ],
                                order: [[1, 'asc']],
                                orderCellsTop: true,
                            });
                            //datatable

                            //search
                            $('#tbx01020201Find').on('keyup', function () {
                                table01020201Record.search(this.value).draw();
                            });
                            //search

                            //hide loader
                            document.getElementById("div01020201Loader").style.display = "none";
                            //hide loader

                            // close Swal loader when everything is done
                            Swal.close();
                        },
                        error: function () {
                            // close Swal loader if error
                            Swal.close();
                            Swal.fire("Error", "Something went wrong while loading data.", "error");
                        }
                    });
                    //modal
                    $('#mdl010201AddPR').modal('show');
                };
            };
        };
        //async function fn01020201Add_Ok(Btn) {
        //    //access
        //    fnAccess('SCM080000', 'Add', function (response) {
        //        if (response[0].oReturn == "1") {
        //            // Disable the clicked button to avoid multiple clicks
        //            Btn.disabled = true;
        //            // Show loading indicator
        //            Btn.setAttribute('data-kt-indicator', 'on');
        //            // Simulate form submission
        //            fn01020201Add_Ok_Await(Btn);
        //        } else {
        //            fnAlertOnly('Access denied!', 'error', 'btn btn-danger');
        //        };
        //    });
        //    function fn01020201Add_Ok_Await(Btn) {
        //        // DataTables API (important fix for pagination issue!)
        //        var table01020201Record = $('#table01020201Record').DataTable();

        //        // get all checkboxes across all pages
        //        var checkBoxes = table01020201Record.$('.cbxPR01020201', { page: 'all' });

        //        // Check if atleast one
        //        var checkedValues = Array.from(checkBoxes)
        //            .filter(checkBox => checkBox.checked)
        //            .map(checkBox => ({
        //                PRNo: checkBox.value,
        //                SeqNo: checkBox.getAttribute('data-kt-no')
        //            }));

        //        if (checkedValues.length > 0) {
        //            //Array
        //            let ItemList = [];
        //            //Loop
        //            checkedValues.forEach(item => {
        //                // use DataTables API to get the input across all pages
        //                var $tbx = table01020201Record.$(
        //                    '[prm01020201Issuance="rowID01020201' + item.PRNo + item.SeqNo + '"]',
        //                    { page: 'all' }
        //                );

        //                let issuanceValue = $tbx.val();
        //                if (!issuanceValue) issuanceValue = "0";

        //                // Push as an object to the array
        //                ItemList.push({
        //                    PRNo: item.PRNo,
        //                    SeqNo: item.SeqNo,
        //                    Issuance: parseFloat(issuanceValue.replace(/,/g, '')) || 0
        //                });

        //            });
        //            //Format Item
        //            let ItemSrs = ItemList.map(i =>
        //                `${i.PRNo}©${i.SeqNo}©${i.Issuance}`
        //            ).join('®');
        //            let ItemPR = ItemList.map(i => ({
        //                PRNo: i.PRNo,
        //                SeqNo: i.SeqNo,
        //                Issuance: i.Issuance
        //            }));
        //            //Question
        //            Issuance_Question(ItemSrs, ItemPR, Btn);
        //        } else {
        //            fnAlertOnly('Please select an Item!', 'error', 'btn btn-danger');
        //            //Disable the clicked button to avoid multiple clicks
        //            Btn.disabled = false;
        //            // Hide loading indication
        //            Btn.removeAttribute('data-kt-indicator');
        //        };
        //        //Return Question
        //        function Issuance_Question(ItemSrs, ItemPR, Btn) {
        //            Swal.fire({
        //                title: '<span class="fs-6 fw-normal text-gray-700">Adding the selected items will overwrite the existing SI Item(s), add Item(s)?</span>',
        //                icon: 'question',
        //                iconColor: '#009ef7',
        //                buttonsStyling: false,
        //                showCancelButton: true,
        //                confirmButtonText: "Yes",
        //                cancelButtonText: 'Cancel',
        //                customClass: {
        //                    confirmButton: 'btn btn-sm btn-info min-w-100px',
        //                    cancelButton: 'btn btn-sm btn-light-danger min-w-100px'
        //                }
        //            }).then((result) => {
        //                if (result.isConfirmed) {
        //                    fnValidateRecord('Trxn_SIHdr', document.getElementById('ContentPlaceHolder1_hdnID').value, '', 'Save', function (response) {
        //                        if (response[0].oReturn == "") {
        //                            Issuance_Ok(ItemSrs, ItemPR, Btn);
        //                        } else {
        //                            fnAlertOnly(response[0].oReturn, 'warning', 'btn btn-warning');
        //                            // Disable the clicked button to avoid multiple clicks
        //                            Btn.disabled = false;
        //                            // Hide loading indication
        //                            Btn.removeAttribute('data-kt-indicator');
        //                        };
        //                    });
        //                } else {
        //                    // Disable the clicked button to avoid multiple clicks
        //                    Btn.disabled = false;
        //                    // Hide loading indication
        //                    Btn.removeAttribute('data-kt-indicator');
        //                }
        //            });
        //        };
        //        // Add ok
        //        function Issuance_Ok(ItemSrs, ItemPR, Btn) {
        //            //issuance
        //            $.ajax({
        //                type: "POST",
        //                url: "Assets/Handler/SCM/SCM080100HND.ashx",
        //                data: {
        //                    'FormCode': 'SCM080100',
        //                    'Type': 'Add Record - DTL - Particular : PR',
        //                    'pID': document.getElementById("ContentPlaceHolder1_hdnID").value,
        //                    'pItemSrs': ItemSrs,
        //                },
        //                success: async function (response) {
        //                    //alert
        //                    fnAlertOnly('Record successfully saved.', 'success', 'btn btn-success');
        //                    //load
        //                    fn0102LoadParticular(response[0].oAction, document.getElementById("ContentPlaceHolder1_hdnID").value);
        //                    for (let item of ItemPR) {
        //                        await fn01020201Redraw("", item.PRNo, item.SeqNo);
        //                        await fn01020201Redraw("Add", item.PRNo, item.SeqNo);
        //                    };
        //                    $("#mdl010201AddPR").modal("hide");
        //                    // Disable the clicked button to avoid multiple clicks
        //                    Btn.disabled = false;
        //                    // Hide loading indication
        //                    Btn.removeAttribute('data-kt-indicator');
        //                },
        //            });
        //        };
        //    };
        //};
        async function fn01020201Add_Ok(Btn) {
            // Show Swal loader immediately
            Swal.fire({
                title: 'Processing...',
                html: 'Please wait',
                allowOutsideClick: false,
                allowEscapeKey: false,
                didOpen: () => Swal.showLoading()
            });

            //access
            fnAccess('SCM080000', 'Add', function (response) {
                if (response[0].oReturn == "1") {
                    // Disable the clicked button to avoid multiple clicks
                    Btn.disabled = true;
                    // Show loading indicator
                    Btn.setAttribute('data-kt-indicator', 'on');
                    // Proceed
                    fn01020201Add_Ok_Await(Btn);
                } else {
                    Swal.close();
                    fnAlertOnly('Access denied!', 'error', 'btn btn-danger');
                };
            });

            function fn01020201Add_Ok_Await(Btn) {
                // DataTables API (important fix for pagination issue!)
                var table01020201Record = $('#table01020201Record').DataTable();

                // get all checkboxes across all pages
                var checkBoxes = table01020201Record.$('.cbxPR01020201', { page: 'all' });

                // Check if at least one
                var checkedValues = Array.from(checkBoxes)
                    .filter(checkBox => checkBox.checked)
                    .map(checkBox => ({
                        PRNo: checkBox.value,
                        SeqNo: checkBox.getAttribute('data-kt-no')
                    }));

                if (checkedValues.length > 0) {
                    // Array
                    let ItemList = [];
                    // Loop
                    checkedValues.forEach(item => {
                        var $tbx = table01020201Record.$(
                            '[prm01020201Issuance="rowID01020201' + item.PRNo + item.SeqNo + '"]',
                            { page: 'all' }
                        );
                        let issuanceValue = $tbx.val() || "0";
                        ItemList.push({
                            PRNo: item.PRNo,
                            SeqNo: item.SeqNo,
                            Issuance: parseFloat(issuanceValue.replace(/,/g, '')) || 0
                        });
                    });

                    // Format Item
                    let ItemSrs = ItemList.map(i =>
                        `${i.PRNo}©${i.SeqNo}©${i.Issuance}`
                    ).join('®');
                    let ItemPR = ItemList.map(i => ({
                        PRNo: i.PRNo,
                        SeqNo: i.SeqNo,
                        Issuance: i.Issuance
                    }));

                    // Question
                    Issuance_Question(ItemSrs, ItemPR, Btn);

                } else {
                    Swal.close();
                    fnAlertOnly('Please select an Item!', 'error', 'btn btn-danger');
                    Btn.disabled = false;
                    Btn.removeAttribute('data-kt-indicator');
                };

                function Issuance_Question(ItemSrs, ItemPR, Btn) {
                    Swal.close(); // close loader before confirmation
                    Swal.fire({
                        title: '<span class="fs-6 fw-normal text-gray-700">Adding the selected items will overwrite the existing SI Item(s), add Item(s)?</span>',
                        icon: 'question',
                        iconColor: '#009ef7',
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
                            // Show loader again while saving
                            Swal.fire({
                                title: 'Saving...',
                                html: 'Please wait',
                                allowOutsideClick: false,
                                allowEscapeKey: false,
                                didOpen: () => Swal.showLoading()
                            });

                            fnValidateRecord('Trxn_SIHdr', document.getElementById('ContentPlaceHolder1_hdnID').value, '', 'Save', function (response) {
                                if (response[0].oReturn == "") {
                                    Issuance_Ok(ItemSrs, ItemPR, Btn);
                                } else {
                                    Swal.close();
                                    fnAlertOnly(response[0].oReturn, 'warning', 'btn btn-warning');
                                    Btn.disabled = false;
                                    Btn.removeAttribute('data-kt-indicator');
                                };
                            });
                        } else {
                            Btn.disabled = false;
                            Btn.removeAttribute('data-kt-indicator');
                        }
                    });
                };

                function Issuance_Ok(ItemSrs, ItemPR, Btn) {
                    $.ajax({
                        type: "POST",
                        url: "Assets/Handler/SCM/SCM080100HND.ashx",
                        data: {
                            'FormCode': 'SCM080100',
                            'Type': 'Add Record - DTL - Particular : PR',
                            'pID': document.getElementById("ContentPlaceHolder1_hdnID").value,
                            'pItemSrs': ItemSrs,
                        },
                        success: async function (response) {
                            Swal.close();
                            fnAlertOnly('Record successfully saved.', 'success', 'btn btn-success');

                            // Destroy the DataTable before reloading
                            if ($.fn.DataTable.isDataTable('#table01020201Record')) {
                                var table = $('#table01020201Record').DataTable();
                                table.clear().destroy();
                            }
                            $('#table01020201Record tbody').empty();

                            // Reload particulars
                            fn0102LoadParticular(response[0].oAction, document.getElementById("ContentPlaceHolder1_hdnID").value);

                            // Redraw table fresh
                            await fn01020201Redraw();

                            $("#mdl010201AddPR").modal("hide");
                            Btn.disabled = false;
                            Btn.removeAttribute('data-kt-indicator');
                        },
                        error: function () {
                            Swal.close();
                            fnAlertOnly('Error saving record!', 'error', 'btn btn-danger');
                            Btn.disabled = false;
                            Btn.removeAttribute('data-kt-indicator');
                        }
                    });
                };
            };
        };
        function fn0102AddDI() {
            //if exist
            fnIfExist('ogm_si_hdr', 'si_code', document.getElementById('ContentPlaceHolder1_hdnID').value, function (response) {
                if (response[0].oReturn == "1") {
                    Access();
                } else {
                    window.location.replace("MNU040100");
                };
            });
            //access
            function Access() {
                fnAccess('SCM080000', 'Add', function (response) {
                    if (response[0].oReturn == "1") {
                        Validate(document.getElementById('ContentPlaceHolder1_hdnID').value);
                    } else {
                        fnAlertOnly('Access denied!', 'error', 'btn btn-danger');
                    };
                });
            };
            //validate
            function Validate(ID) {
                fnValidateRecord('Trxn_SIHdr', ID, '', 'Save', function (response) {
                    if (response[0].oReturn == "") {
                        Add();
                    } else {
                        fnAlertOnly(response[0].oReturn, 'warning', 'btn btn-warning');
                    };
                });
            };
            function Add() {
                if (document.getElementById("cbx0101SINo").checked != true && document.getElementById("cbx0101GPNo").checked == true) {
                    $.ajax({
                        type: "POST",
                        url: "Assets/Handler/SCM/SCM080100HND.ashx",
                        data: {
                            'FormCode': 'SCM080100',
                            'Type': 'Get Record - DTL - Particular : DI',
                            'pRequestor': document.getElementById("ContentPlaceHolder1_hf0101RequestedByCode").value
                        },
                        beforeSend: function () {
                            Swal.fire({
                                title: 'Loading...',
                                text: 'Please wait while data is being processed.',
                                allowOutsideClick: false,
                                didOpen: () => {
                                    Swal.showLoading();
                                }
                            });
                        },
                        success: function (response) {
                            //hide loader
                            document.getElementById("div01020202Loader").style.display = "";
                            //hide loader

                            $('#table01020202Record').DataTable().destroy();

                            //disable column type detection
                            DataTable.types().forEach(type => {
                                DataTable.type(type, 'detect', () => false);
                            });
                            //disable column type detection

                            //sort date by yyyy/mm/dd
                            $.fn.dataTable.moment('MM/DD/YYYY');
                            //sort date by yyyy/mm/dd

                            //datatable
                            var table01020202Record = $("#table01020202Record").DataTable({
                                processing: true,
                                bFilter: true,
                                bPaginate: true,
                                bInfo: false,
                                paging: true,
                                lengthChange: true,
                                pageLength: 25,
                                select: true,
                                data: response,
                                columns: [
                                    { data: 'Action' },
                                    { data: 'IRNo', },
                                    { data: 'SeqNo' },
                                    { data: 'Item' },
                                    { data: 'ForGP' },
                                    { data: 'ForGPBalance' },
                                    {
                                        data: 'Issuance',
                                        render: function (data, type, row, meta) {
                                            if (type === "display") {
                                                let rowId = `${row.rowId}`;
                                                let rowVal = parseFloat(row.ForGPBalance).toFixed(2);

                                                //Format Number
                                                let formattedValue = new Intl.NumberFormat('en-US', {
                                                    minimumFractionDigits: 2,
                                                    maximumFractionDigits: 2
                                                }).format(rowVal);

                                                let textbox = `
                                                    <input prm01020202Issuance="${rowId}" type="text" class="w-100 outline-none text-end border-top-0 border-left-0 border-right-0 border-bottom-2 border-gray-300" Placeholder="Issuance" value="${formattedValue}" onkeypress="return fnEnterKeyNumber(event,this.id)" onblur="fnFormatNumericIssuance(this, ${row.ForGP});" />
                                                `;
                                                return textbox;
                                            }
                                            return data;
                                        }
                                    },
                                    { data: 'Unit' },
                                ],
                                drawCallback: function () {
                                    $('[data-kt-repeater="select2"]').select2({
                                        width: '100%'
                                    });
                                },
                                rowId: 'rowId',
                                columnDefs: [
                                    {
                                        targets: [0],
                                        orderable: false,
                                    }
                                    ,
                                    {
                                        targets: [3],
                                        className: 'tbody-nowrap-auto'
                                    },
                                    {
                                        targets: [4, 5, 6],
                                        className: 'dt-body-right',
                                        render: $.fn.dataTable.render.number(',', '.', 2)
                                    }
                                ],
                                order: [[1, 'asc']],
                                orderCellsTop: true,
                            });
                            //datatable

                            //search
                            $('#tbx01020202Find').on('keyup', function () {
                                table01020202Record.search(this.value).draw();
                            });
                            //search

                            //hide loader
                            document.getElementById("div01020202Loader").style.display = "none";
                            //hide loader

                            // close Swal loader when everything is done
                            Swal.close();
                        },
                        error: function () {
                            // close Swal loader if error
                            Swal.close();
                            Swal.fire("Error", "Something went wrong while loading data.", "error");
                        }
                    });
                    //modal
                    $('#mdl010202AddDI').modal('show');
                };
            };
        };
        async function fn01020202Add_Ok(Btn) {
            // Show Swal loader immediately
            Swal.fire({
                title: 'Processing...',
                html: 'Please wait',
                allowOutsideClick: false,
                allowEscapeKey: false,
                didOpen: () => Swal.showLoading()
            });

            // access check
            fnAccess('SCM080000', 'Add', function (response) {
                if (response[0].oReturn == "1") {
                    // Disable clicked button to avoid multiple clicks
                    Btn.disabled = true;

                    Btn.setAttribute('data-kt-indicator', 'on');

                    fn01020202Add_Ok_Await(Btn);
                } else {
                    Swal.close();
                    fnAlertOnly('Access denied!', 'error', 'btn btn-danger');
                }
            });
            function fn01020202Add_Ok_Await(Btn) {
                // DataTables API (important fix for pagination issue!)
                var table01020202Record = $('#table01020202Record').DataTable();

                // get all checkboxes across all pages
                var checkBoxes = table01020202Record.$('.cbxDI01020202', { page: 'all' });

                // filter only checked checkboxes
                var checkedValues = Array.from(checkBoxes)
                    .filter(checkBox => checkBox.checked)
                    .map(checkBox => ({
                        IRNo: checkBox.value,
                        SeqNo: checkBox.getAttribute('data-kt-no')
                    }));

                if (checkedValues.length > 0) {
                    // prepare array
                    let ItemList = [];

                    checkedValues.forEach(item => {
                        // use DataTables API to get the input across all pages
                        var $tbx = table01020202Record.$(
                            '[prm01020202Issuance="rowID01020202' + item.IRNo + item.SeqNo + '"]',
                            { page: 'all' }
                        );

                        let issuanceValue = $tbx.val();
                        if (!issuanceValue) issuanceValue = "0";

                        ItemList.push({
                            IRNo: item.IRNo,
                            SeqNo: item.SeqNo,
                            Issuance: parseFloat(issuanceValue.replace(/,/g, '')) || 0
                        });
                    });

                    // format items
                    let ItemSrs = ItemList.map(i =>
                        `${i.IRNo}©${i.SeqNo}©${i.Issuance}`
                    ).join('®');

                    let ItemDI = ItemList.map(i => ({
                        IRNo: i.IRNo,
                        SeqNo: i.SeqNo,
                        Issuance: i.Issuance
                    }));

                    Issuance_Question(ItemSrs, ItemDI, Btn);
                } else {
                    Swal.close();
                    fnAlertOnly('Please select an Item!', 'error', 'btn btn-danger');
                    Btn.disabled = false;
                    Btn.removeAttribute('data-kt-indicator');
                }

                // confirm question
                function Issuance_Question(ItemSrs, ItemDI, Btn) {
                    Swal.close();
                    Swal.fire({
                        title: '<span class="fs-6 fw-normal text-gray-700">Adding the selected items will overwrite the existing GP Item(s), add Item(s)?</span>',
                        icon: 'question',
                        iconColor: '#009ef7',
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
                            // Show loader again while saving
                            Swal.fire({
                                title: 'Saving...',
                                html: 'Please wait',
                                allowOutsideClick: false,
                                allowEscapeKey: false,
                                didOpen: () => Swal.showLoading()
                            });

                            fnValidateRecord('Trxn_SIHdr', document.getElementById('ContentPlaceHolder1_hdnID').value, '', 'Save', function (response) {
                                if (response[0].oReturn == "") {
                                    Issuance_Ok(ItemSrs, ItemDI, Btn);
                                } else {
                                    Swal.close();
                                    fnAlertOnly(response[0].oReturn, 'warning', 'btn btn-warning');
                                    Btn.disabled = false;
                                    Btn.removeAttribute('data-kt-indicator');
                                }
                            });
                        } else {
                            Btn.disabled = false;
                            Btn.removeAttribute('data-kt-indicator');
                        }
                    });
                }

                // final save
                function Issuance_Ok(ItemSrs, ItemDI, Btn) {
                    $.ajax({
                        type: "POST",
                        url: "Assets/Handler/SCM/SCM080100HND.ashx",
                        data: {
                            'FormCode': 'SCM080100',
                            'Type': 'Add Record - DTL - Particular : DI',
                            'pID': document.getElementById("ContentPlaceHolder1_hdnID").value,
                            'pItemSrs': ItemSrs,
                        },
                        success: async function (response) {
                            Swal.close();
                            fnAlertOnly('Record successfully saved.', 'success', 'btn btn-success');

                            // Destroy the DataTable before reloading
                            if ($.fn.DataTable.isDataTable('#table01020202Record')) {
                                var table = $('#table01020202Record').DataTable();
                                table.clear().destroy();
                            }
                            $('#table01020202Record tbody').empty();
                            fn0102LoadParticular(response[0].oAction, document.getElementById("ContentPlaceHolder1_hdnID").value);
                            $("#mdl010202AddDI").modal("hide");
                            Btn.disabled = false;
                            Btn.removeAttribute('data-kt-indicator');
                        },
                        error: function () {
                            Swal.close();
                            fnAlertOnly('Error while saving record.', 'error', 'btn btn-danger');
                            Btn.disabled = false;
                            Btn.removeAttribute('data-kt-indicator');
                        }
                    });
                }
            }
        };
        //async function fn01020202Add_Ok(Btn) {
        //    //access
        //    fnAccess('SCM080000', 'Add', function (response) {
        //        if (response[0].oReturn == "1") {
        //            // Disable the clicked button to avoid multiple clicks
        //            Btn.disabled = true;
        //            // Show loading indicator
        //            Btn.setAttribute('data-kt-indicator', 'on');
        //            // Simulate form submission
        //            fn01020202Add_Ok_Await(Btn);
        //        } else {
        //            fnAlertOnly('Access denied!', 'error', 'btn btn-danger');
        //        };
        //    });
        //    function fn01020202Add_Ok_Await(Btn) {
        //        // Get all
        //        var checkBoxes = document.querySelectorAll('.cbxDI01020202');

        //        // Check if atleast one
        //        var checkedValues = Array.from(checkBoxes)
        //            .filter(checkBox => checkBox.checked)
        //            .map(checkBox => ({
        //                IRNo: checkBox.value,
        //                SeqNo: checkBox.getAttribute('data-kt-no')
        //            }));

        //        if (checkedValues.length > 0) {
        //            //Array
        //            let ItemList = [];
        //            //Loop
        //            checkedValues.forEach(item => {
        //                var tbx01020202Issuance = document.querySelector('[prm01020202Issuance="rowID01020202' + item.IRNo + '' + item.SeqNo + '"]');

        //                // Push as an object to the array
        //                ItemList.push({
        //                    IRNo: item.IRNo,
        //                    SeqNo: item.SeqNo,
        //                    Issuance: parseFloat(tbx01020202Issuance.value.replace(/,/g, ''))
        //                });

        //            });
        //            //Format Item
        //            let ItemSrs = ItemList.map(i =>
        //                `${i.IRNo}©${i.SeqNo}©${i.Issuance}`
        //            ).join('®');
        //            let ItemDI = ItemList.map(i => ({
        //                IRNo: i.IRNo,
        //                SeqNo: i.SeqNo,
        //                Issuance: i.Issuance
        //            }));
        //            //Question
        //            Issuance_Question(ItemSrs, ItemDI, Btn);
        //        } else {
        //            fnAlertOnly('Please select an Item!', 'error', 'btn btn-danger');
        //            //Disable the clicked button to avoid multiple clicks
        //            Btn.disabled = false;
        //            // Hide loading indication
        //            Btn.removeAttribute('data-kt-indicator');
        //        };
        //        //Return Question
        //        function Issuance_Question(ItemSrs, ItemDI, Btn) {
        //            Swal.fire({
        //                title: '<span class="fs-6 fw-normal text-gray-700">Adding the selected items will overwrite the existing GP Item(s), add Item(s)?</span>',
        //                icon: 'question',
        //                iconColor: '#009ef7',
        //                buttonsStyling: false,
        //                showCancelButton: true,
        //                confirmButtonText: "Yes",
        //                cancelButtonText: 'Cancel',
        //                customClass: {
        //                    confirmButton: 'btn btn-sm btn-info min-w-100px',
        //                    cancelButton: 'btn btn-sm btn-light-danger min-w-100px'
        //                }
        //            }).then((result) => {
        //                if (result.isConfirmed) {
        //                    fnValidateRecord('Trxn_SIHdr', document.getElementById('ContentPlaceHolder1_hdnID').value, '', 'Save', function (response) {
        //                        if (response[0].oReturn == "") {
        //                            Issuance_Ok(ItemSrs, ItemDI, Btn);
        //                        } else {
        //                            fnAlertOnly(response[0].oReturn, 'warning', 'btn btn-warning');
        //                        };
        //                    });
        //                } else {
        //                    // Disable the clicked button to avoid multiple clicks
        //                    Btn.disabled = false;
        //                    // Hide loading indication
        //                    Btn.removeAttribute('data-kt-indicator');
        //                }
        //            });
        //        };
        //        // Add ok
        //        function Issuance_Ok(ItemSrs, ItemDI, Btn) {
        //            //issuance
        //            $.ajax({
        //                type: "POST",
        //                url: "Assets/Handler/SCM/SCM080100HND.ashx",
        //                data: {
        //                    'FormCode': 'SCM080100',
        //                    'Type': 'Add Record - DTL - Particular : DI',
        //                    'pID': document.getElementById("ContentPlaceHolder1_hdnID").value,
        //                    'pItemSrs': ItemSrs,
        //                },
        //                success: async function (response) {
        //                    //alert
        //                    fnAlertOnly('Record successfully saved.', 'success', 'btn btn-success');
        //                    //load
        //                    fn0102LoadParticular(response[0].oAction, document.getElementById("ContentPlaceHolder1_hdnID").value);
        //                    //for (let item of ItemDI) {
        //                    //    await fn01020202Redraw("", item.IRNo, item.SeqNo);
        //                    //    await fn01020202Redraw("Add", item.IRNo, item.SeqNo);
        //                    //};
        //                    $("#mdl010202AddDI").modal("hide");
        //                    // Disable the clicked button to avoid multiple clicks
        //                    Btn.disabled = false;
        //                    // Hide loading indication
        //                    Btn.removeAttribute('data-kt-indicator');
        //                },
        //            });
        //        };
        //    };
        //};
        function fn010201Delete(pID, pSeqNo) {
            //if exist
            fnIfExist('ogm_si_hdr', 'si_code', document.getElementById('ContentPlaceHolder1_hdnID').value, function (response) {
                if (response[0].oReturn == "1") {
                    Access();
                } else {
                    window.location.replace("MNU040100");
                };
            });
            //access
            function Access() {
                fnAccess('SCM080000', 'Add', function (response) {
                    if (response[0].oReturn == "1") {
                        Validate(document.getElementById('ContentPlaceHolder1_hdnID').value);
                    } else {
                        fnAlertOnly('Access denied!', 'error', 'btn btn-danger');
                    };
                });
            };
            //validate
            function Validate(ID) {
                fnValidateRecord('Trxn_SIHdr', ID, '', 'Save', function (response) {
                    if (response[0].oReturn == "") {
                        Delete_Question(pID, pSeqNo);
                    } else {
                        fnAlertOnly(response[0].oReturn, 'warning', 'btn btn-warning');
                    };
                });
            };
            //delete question
            function Delete_Question(pID, pSeqNo) {
                Swal.fire({
                    text: 'Delete Item?',
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
                        fnValidateRecord('Trxn_SIHdr', document.getElementById('ContentPlaceHolder1_hdnID').value, '', 'Save', function (response) {
                            if (response[0].oReturn == "") {
                                Delete_Ok(pID, pSeqNo);
                            } else {
                                fnAlertOnly(response[0].oReturn, 'warning', 'btn btn-warning');
                            };
                        });
                    }
                });
            };
            function Delete_Ok(pID, pSeqNo) {
                //delete
                $.ajax({
                    type: "POST",
                    url: "Assets/Handler/SCM/SCM080100HND.ashx",
                    data: {
                        'FormCode': 'SCM080100',
                        'Type': 'Delete Record - DTL - Particular',
                        'pID': pID,
                        'pSeqNo': pSeqNo
                    },
                    success: function (response) {
                        fnAlertOnly('Record successfully deleted.', 'success', 'btn btn-success');
                        fn0102Redraw("", response[0].oID, response[0].oSeqNo);
                    },
                });
            };
        };
        function fn010201Edit(pID, pSeqNo, pType) {
            //if exisit
            fnIfExist('ogm_si_hdr', 'si_code', document.getElementById('ContentPlaceHolder1_hdnID').value, function (response) {
                if (response[0].oReturn == "1") {
                    Access();
                } else {
                    window.location.replace("MNU040100");
                };
            });
            //access
            function Access() {
                fnAccess('SCM080000', 'Add', function (response) {
                    if (response[0].oReturn == "1") {
                        Validate(document.getElementById('ContentPlaceHolder1_hdnID').value);
                    } else {
                        fnAlertOnly('Access denied!', 'error', 'btn btn-danger');
                    };
                });
            };
            //validate
            function Validate(ID) {
                fnValidateRecord('Trxn_SIHdr', ID, '', 'Save', function (response) {
                    if (response[0].oReturn == "") {
                        Edit(pID, pSeqNo, pType);
                    } else {
                        fnAlertOnly(response[0].oReturn, 'warning', 'btn btn-warning');
                    };
                });
            };
            //edit
            function Edit(pID, pSeqNo, pType) {
                //bind
                $.ajax({
                    type: "POST",
                    url: "Assets/Handler/SCM/SCM080100HND.ashx",
                    data: {
                        'FormCode': 'SCM080100',
                        'Type': 'Get Record - DTL - Particular : Edit',
                        'pID': pID,
                        'pSeqNo': pSeqNo
                    },
                    success: function (response) {
                        document.getElementById("ContentPlaceHolder1_hf010301pSeqNo").value = pSeqNo;
                        document.getElementById("hdnType").value = pType;
                        document.getElementById("ContentPlaceHolder1_hf010301ItemCode").value = response[0].ItemCode;
                        document.getElementById("tbx010301Item").value = response[0].ItemName;
                        document.getElementById("tbx010301Qty").value = formatNumber(response[0].Qty);
                        document.getElementById("hdn010301Qty").value = formatNumber(response[0].Qty);
                        document.getElementById("ContentPlaceHolder1_hf010301UOMCode").value = response[0].UMCode;
                        document.getElementById("ContentPlaceHolder1_hf010301Cost").value = response[0].Cost;
                        document.getElementById("ContentPlaceHolder1_hf010301Total").value = response[0].Total;
                        document.getElementById("tbx010301UOM").value = response[0].UMName;
                        document.getElementById("tbx010301Remarks").value = response[0].Remarks;
                        document.getElementById("tbx010301PRNo").value = response[0].PRNo;
                        document.getElementById("tbx010301PRSeqNo").value = response[0].PRSeqNo;
                        document.getElementById("tbx010301PRItem").value = response[0].PRItem;
                        document.getElementById("tbx010301PRQty").value = formatNumber(response[0].PRQty);
                        document.getElementById("tbx010301PRUOM").value = response[0].PRUnit;
                        //modal
                        $('#mdl0103Edit').modal('show');
                    },
                });
            };
        };
        function fn010301Edit_Ok(Btn) {
            //if exisit
            fnIfExist('ogm_si_hdr', 'si_code', document.getElementById('ContentPlaceHolder1_hdnID').value, function (response) {
                if (response[0].oReturn == "1") {
                    Access();
                } else {
                    window.location.replace("MNU040100");
                };
            });
            //access
            function Access() {
                fnAccess('SCM080000', 'Add', function (response) {
                    if (response[0].oReturn == "1") {
                        Validate(document.getElementById('ContentPlaceHolder1_hdnID').value);
                    } else {
                        fnAlertOnly('Access denied!', 'error', 'btn btn-danger');
                    };
                });
            };
            //validate
            function Validate(ID, SeqNo) {
                fnValidateRecord('Trxn_SIHdr', ID, '', 'Save', function (response) {
                    if (response[0].oReturn !== "") {
                        fnAlertOnly(response[0].oReturn, 'warning', 'btn btn-warning');
                        return;
                    }
                    var Name = document.getElementById("tbx010301Item").value;
                    var qty = parseFloat(document.getElementById("tbx010301Qty").value.replace(/,/g, '')) || 0;
                    var hdnQty = parseFloat(document.getElementById("hdn010301Qty").value.replace(/,/g, '')) || 0;


                    if (hdnQty == 0) {
                        fnAlertOnly(Name + " has no current Warehouse Item Qty. on hand!", 'warning', 'btn btn-warning');
                        return;
                    }

                    if (qty == 0) {
                        fnAlertOnly("Please enter a quantity greater than 0.", 'warning', 'btn btn-warning');
                        return;
                    }


                    if (qty > hdnQty) {
                        fnAlertOnly(Name + " exceeds the current Warehouse Item Qty. on hand!", 'warning', 'btn btn-warning');
                        return;
                    }



                    Edit_DTL_Ok(ID);
                });
            }
            //edit
            async function Edit_DTL_Ok(ID) {
                // Disable the clicked button to avoid multiple clicks
                Btn.disabled = true;
                // Show loading indicator
                Btn.setAttribute('data-kt-indicator', 'on');
                // Simulate form submission
                await Edit_DTL_Ok_Await(Btn, ID);
            };
            function Edit_DTL_Ok_Await(Btn, ID) {
                // process
                return new Promise(resolve => {
                    //Validate
                    if (document.getElementById("tbx010301Item").value == "") {
                        //Alert
                        fnAlertOnly('Some field(s) are missing!', 'error', 'btn btn-danger');
                    } else if (document.getElementById("tbx010301Qty").value == "") {
                        //Alert
                        fnAlertOnly('Some field(s) are missing!', 'error', 'btn btn-danger');
                    } else {
                        Edit_DTL_Question(ID);
                    };
                    //question
                    function Edit_DTL_Question(ID) {
                        Swal.fire({
                            text: 'Current record/changes will be saved?',
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
                                fnValidateRecord('Trxn_SIHdr', ID, '', 'Save', function (response) {
                                    if (response[0].oReturn == "") {
                                        Edit_Ok(ID);
                                    } else {
                                        fnAlertOnly(response[0].oReturn, 'warning', 'btn btn-warning');
                                    };
                                });
                            } else {
                                // Disable the clicked button to avoid multiple clicks
                                Btn.disabled = true;
                                // Hide loading indication
                                Btn.removeAttribute('data-kt-indicator');
                            };
                        });
                    };
                    //edit
                    function Edit_Ok(ID) {
                        $.ajax({
                            type: "POST",
                            url: "Assets/Handler/SCM/SCM080100HND.ashx",
                            data: {
                                'FormCode': 'SCM080100',
                                'Type': 'Stock Issuance - Edit Record : Particular',
                                'pID': ID,
                                'pSeqNo': document.getElementById("ContentPlaceHolder1_hf010301pSeqNo").value,
                                'pType': 'SI',
                                'pItemCode': document.getElementById("ContentPlaceHolder1_hf010301ItemCode").value,
                                'pQty': document.getElementById("tbx010301Qty").value,
                                'pUOMCode': document.getElementById("ContentPlaceHolder1_hf010301UOMCode").value,
                                'pCost': document.getElementById("ContentPlaceHolder1_hf010301Cost").value,
                                'pTotal': document.getElementById("ContentPlaceHolder1_hf010301Total").value,
                                'pRemarks': document.getElementById("tbx010301Remarks").value,
                            },
                            success: function (response) {
                                //add
                                fnAlertOnly('Record successfully updated.', 'success', 'btn btn-success');
                                document.getElementById("tbx010301Item").value = "";
                                document.getElementById("ContentPlaceHolder1_hf010301ItemCode").value = "";
                                document.getElementById("tbx010301Qty").value = "0.00";
                                document.getElementById("ContentPlaceHolder1_hf010301Cost").value = "";
                                document.getElementById("ContentPlaceHolder1_hf010301Total").value = "";
                                document.getElementById("tbx010301UOM").value = "";
                                document.getElementById("ContentPlaceHolder1_hf010301UOMCode").value = "";
                                document.getElementById("tbx010301Remarks").value = "";
                                document.getElementById("tbx010301PRNo").value = "";
                                document.getElementById("tbx010301PRSeqNo").value = "";
                                document.getElementById("tbx010301PRItem").value = "";
                                document.getElementById("tbx010301PRQty").value = "0.00";
                                document.getElementById("tbx010301PRUOM").value = "";
                                fn0102Redraw("Edit", response[0].oID, response[0].oSeqNo);
                            },
                        });
                        //modal
                        $('#mdl0103Edit').modal('hide');
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
        function fn010301Item() {
            if (document.getElementById("hdnType").value != "DI") {
                //item
                $.ajax({
                    type: "POST",
                    url: "Assets/Handler/SCM/SCM080100HND.ashx",
                    data: {
                        'FormCode': 'SCM080100',
                        'Type': 'Stock Issuance - Edit Record : Item',
                        'pWarehouse': document.getElementById("ContentPlaceHolder1_hf0101Warehouse").value
                    },
                    success: function (response) {
                        //display loader
                        document.getElementById("div010401Loader").style.display = "";
                        //display loader

                        $('#table010401Item').DataTable().destroy();

                        //disable column type detection
                        DataTable.types().forEach(type => {
                            DataTable.type(type, 'detect', () => false);
                        });
                        //disable column type detection

                        //sort date by yyyy/mm/dd
                        $.fn.dataTable.moment('MM/DD/YYYY');
                        //sort date by yyyy/mm/dd

                        //datatable
                        var table010401Item = $("#table010401Item").DataTable({
                            processing: true,
                            bFilter: true,
                            bPaginate: true,
                            bInfo: false,
                            paging: true,
                            lengthChange: true,
                            pageLength: 25,
                            select: true,
                            data: response,
                            columns: [
                                { data: 'Action' },
                                { data: 'Code' },
                                { data: 'Lock' },
                                { data: 'ItemName' },
                                { data: 'Qty' },
                                { data: 'UMName' },
                                { data: 'Cost' },
                                { data: 'Total' },
                            ],
                            rowId: 'rowId',
                            columnDefs: [
                                {
                                    targets: 0, orderable: false
                                },
                                {
                                    targets: [4, 6, 7],
                                    className: 'dt-body-right',
                                    render: $.fn.dataTable.render.number(',', '.', 2)
                                },
                                {
                                    targets: 3, className: 'tbody-nowrap-auto'
                                }
                            ],
                            order: [[3, 'asc']],
                            orderCellsTop: true,
                        });
                        //datatable

                        //search
                        $('#tbx010401Find').on('keyup', function () {
                            table010401Item.search(this.value).draw();
                        });
                        //search

                        //hide loader
                        document.getElementById("div010401Loader").style.display = "none";
                        //hide loader

                        //modal
                        $('#mdl0104Item').modal('show');
                    },
                });
            };
        };
        function fn010302Item(pItemCode, pLock) {
            //validate
            if (pLock == 1) {
                Item(pItemCode);
            } else {
                fnAlertOnly('Record is unlocked, it cannot be used!', 'error', 'btn btn-danger');
            };
            //item
            function Item(pItemCode) {
                //bind
                $.ajax({
                    type: "POST",
                    url: "Assets/Handler/SCM/SCM080100HND.ashx",
                    data: {
                        'FormCode': 'SCM080100',
                        'Type': 'Get Record : Item',
                        'pTblFrom': 'SI',
                        'pItemCode': pItemCode,
                        'pWarehouse': document.getElementById("ContentPlaceHolder1_hf0101Warehouse").value
                    },
                    success: function (response) {
                        document.getElementById("ContentPlaceHolder1_hf010301ItemCode").value = response[0].ItemCode;
                        document.getElementById("tbx010301Item").value = response[0].ItemName;
                        document.getElementById("tbx010301Qty").value = formatNumber(response[0].Qty);
                        document.getElementById("hdn010301Qty").value = formatNumber(response[0].Qty);
                        document.getElementById("ContentPlaceHolder1_hf010301Cost").value = formatNumber(response[0].Cost);
                        document.getElementById("ContentPlaceHolder1_hf010301UOMCode").value = response[0].UMCode;
                        document.getElementById("tbx010301UOM").value = response[0].UMName;
                        let newCost = parseFloat(document.getElementById("tbx010301Qty").value.replace(/,/g, '')) * response[0].Cost;
                        document.getElementById("ContentPlaceHolder1_hf010301Total").value = formatNumber(newCost);
                        //modal
                        $('#mdl0104Item').modal('hide');
                    },
                });
            };
        };
        //particular

        //attachment
        function fn0201LoadAttachment(pMode, pID) {
            $.ajax({
                type: "POST",
                url: "HNDGEN.ashx",
                data: {
                    'pFormCode': 'SCM080000',
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
            fnIfExist('ogm_si_hdr', 'si_code', document.getElementById('ContentPlaceHolder1_hdnID').value, function (response) {
                if (response[0].oReturn == "1") {
                    Download();
                } else {
                    window.location.replace("MNU040100");
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
                    },
                });
            };
        };
        function fn0201Delete(pFormCode, pID, pFileName) {
            //if exisit
            fnIfExist('ogm_si_hdr', 'si_code', document.getElementById('ContentPlaceHolder1_hdnID').value, function (response) {
                if (response[0].oReturn == "1") {
                    Access();
                } else {
                    window.location.replace("MNU040100");
                };
            });
            //access
            function Access() {
                fnAccess('SCM080000', 'Delete', function (response) {
                    if (response[0].oReturn == "1") {
                        Delete_Question(pFormCode, pID, pFileName);
                    } else {
                        fnAlertOnly('Access denied!', 'error', 'btn btn-danger');
                    };
                });
            };
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
                    },
                });
            };
        };
        //attachment


//notes

        function fn0301LoadNotes(pID) {
    $.ajax({
        type: "POST",
        url: "Assets/Handler/MNU/MNU001000HND.ashx",
        data: {
            'pFunction': 'Get-Record-99',
            'pFormCode': 'SCM080000',
            'pID': pID,
        },
        success: function (response) {
            document.getElementById("div0301LoaderNotes").style.display = "";
            $('#table0301Notes').DataTable().destroy();
            DataTable.types().forEach(type => { DataTable.type(type, 'detect', () => false); });
            $.fn.dataTable.moment('MM/DD/YYYY');
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
            $('#tbx0301FindNotes').on('keyup', function () { table0301Notes.search(this.value).draw(); });
            document.getElementById("div0301LoaderNotes").style.display = "none";
        },
    });
};
        function fn0301Add() {
            //if exisit
            fnIfExist('ogm_si_hdr', 'si_code', document.getElementById('ContentPlaceHolder1_hdnID').value, function (response) {
                if (response[0].oReturn == "1") {
                    Add();
                } else {
                    window.location.replace("MNU040100");
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
            fnIfExist('ogm_si_hdr', 'si_code', document.getElementById('ContentPlaceHolder1_hdnID').value, function (response) {
                if (response[0].oReturn == "1") {
                    Add_Ok();
                } else {
                    window.location.replace("MNU040100");
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
                            'pFormCode': 'SCM080000',
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
                            fn0301LoadNotes(document.getElementById('ContentPlaceHolder1_hdnID').value);
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

        //@mention
        var mentionUser = [];
        var initialMention = [];
        var jq = jQuery.noConflict();
        //@mention

        //load page
        function pageLoad(sender, args) { InitialiseSettings(); }
        function InitialiseSettings() {
            jQuery(function ($) {

                //metion
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
                };
                //metion

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
                    url: "HNDGEN.ashx?pFormCode=SCM080000&pType=Upload&pID=" + document.getElementById('ContentPlaceHolder1_hdnID').value,
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
                    //access
                    fnAccess('SCM080000', 'Add', function (response) {
                        if (response[0].oReturn == "1") {
                            Add();
                        } else {
                            fnAlertOnly('Access denied!', 'error', 'btn btn-danger');
                        };
                    });
                    function Add() {
                        myDropzone.removeAllFiles();
                        FileCount = 0;
                        $('#mdl0202Upload').modal('show');
                    };
                });
                $('#btn0202Add_Ok').on('click', function (e) {
                    //access
                    fnAccess('SCM080000', 'Add', function (response) {
                        if (response[0].oReturn == "1") {
                            Validate();
                        } else {
                            fnAlertOnly('Access denied!', 'error', 'btn btn-danger');
                        };
                    });
                    //validate
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
                            myDropzone.options.url = "HNDGEN.ashx?pFormCode=SCM080000&pType=Upload&pID=" + document.getElementById('ContentPlaceHolder1_hdnID').value;
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
            });
        };
        //load page