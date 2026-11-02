var jq = jQuery.noConflict();

jq(function () {
    var chatHub = jq.connection.chatHub;
    var contactsContainer = document.getElementById("contractor_contacts_list");
    var messageContainer = document.querySelector("#kt_chat_messenger_body [data-kt-element='messages']");
    var scrollElement = document.querySelector("#kt_chat_messenger_body .scroll-y");
    var titleElement = document.getElementById("chat_active_contractor_title");
    var replyInput = document.querySelector("#kt_chat_messenger_footer textarea");
    var sendButton = document.getElementById("btnAdminSend");
    var searchInput = document.getElementById("search_contractors");
    var attachButton = document.getElementById("btnAdminAttachFile");
    var previewContainer = document.getElementById("divAdminAttachmentPreview");
    var previewFileName = document.getElementById("lblAdminAttachmentName");
    var removeAttachmentButton = document.getElementById("btnAdminRemoveAttachment");

    var currentContractorId = "";
    var adminUploadedFilePath = "";
    var adminUploadedFileName = "";

    var formatTimestamp = function (dateString) {
        if (!dateString) return "";
        var date = new Date(dateString);
        if (isNaN(date.getTime())) return "";

        var today = new Date();
        var isToday = date.getFullYear() === today.getFullYear() &&
            date.getMonth() === today.getMonth() &&
            date.getDate() === today.getDate();

        if (isToday) {
            return date.toLocaleTimeString([], {
                hour: '2-digit',
                minute: '2-digit',
                hour12: true
            });
        } else {
            return date.toLocaleString([], {
                month: 'short',
                day: 'numeric',
                year: 'numeric',
                hour: '2-digit',
                minute: '2-digit',
                hour12: true
            });
        }
    };

    var getInitials = function (name) {
        if (!name) return "CT";
        var parts = name.trim().split(" ");
        if (parts.length >= 2) {
            return (parts[0][0] + parts[1][0]).toUpperCase();
        }
        return name.substring(0, 2).toUpperCase();
    };

    var scrollToBottom = function () {
        if (scrollElement) {
            scrollElement.scrollTop = scrollElement.scrollHeight;
        }
    };

    var renderAttachmentHtml = function (filePath, fileName) {
        if (!filePath) return "";

        var cleanPath = filePath.replace(/^~[\/\\]?/, "");
        var resolvedUrl = cleanPath.startsWith("/") ? cleanPath : "/" + cleanPath;
        var ext = cleanPath.split(".").pop().toLowerCase();
        var isImage = ["jpg", "jpeg", "png"].includes(ext);
        if (isImage) {
            return `
                <div class="mt-3">
                    <a href="${filePath}" target="_blank" class="d-inline-block">
                        <img src="${resolvedUrl}" alt="${fileName || 'Image'}" class="rounded mw-100 mh-200px border shadow-sm" />
                    </a>
                </div>
            `;
        } else {
            return `
                <div class="mt-3">
                    <a href="${resolvedUrl}" target="_blank" class="d-flex align-items-center p-3 rounded bg-white bg-opacity-75 text-hover-primary border shadow-sm text-decoration-none">
                        <span class="svg-icon svg-icon-2hx svg-icon-danger me-3">
                            <svg width="24" height="24" viewBox="0 0 24 24" fill="none" xmlns="http://www.w3.org/2000/svg">
                                <path opacity="0.3" d="M19 22H5C4.4 22 4 21.6 4 21V3C4 2.4 4.4 2 5 2H14L20 8V21C20 21.6 19.6 22 19 22Z" fill="currentColor"/>
                                <path d="M15 8H20L14 2V7C14 7.6 14.4 8 15 8Z" fill="currentColor"/>
                            </svg>
                        </span>
                        <div class="d-flex flex-column overflow-hidden text-start">
                            <span class="fs-7 fw-bold text-gray-800 text-truncate mw-200px">${fileName || 'PDF Document'}</span>
                            <span class="fs-9 text-muted">Click to view/download file</span>
                        </div>
                    </a>
                </div>
            `;
        }
    };

    var renderMessage = function (msg) {
        var isAdmin = msg.SenderType === "Admin";
        var justifyClass = isAdmin ? "justify-content-end" : "justify-content-start";
        var alignClass = isAdmin ? "align-items-end" : "align-items-start";
        var bgClass = isAdmin ? "bg-light-primary text-end" : "bg-light-info text-start";

        var currentActiveName = titleElement ? titleElement.textContent.replace("Contractor: ", "").trim() : "";
        var displayName = msg.Contractor || (msg.SenderID === currentContractorId && currentActiveName ? currentActiveName : msg.SenderID);
        var senderLabel = isAdmin ? "You (Admin)" : displayName;

        var avatarHtml = isAdmin
            ? `<div class="symbol symbol-35px symbol-circle ms-2"><img alt="Admin" src="assets/media/avatars/SYS001000.PNG" /></div>`
            : `<div class="symbol symbol-35px symbol-circle me-2"><span class="symbol-label bg-light-danger text-danger fs-7 fw-bold">${getInitials(displayName)}</span></div>`;

        var msgIdAttr = msg.ID ? `data-message-id="${msg.ID}"` : '';
        var textHtml = msg.Message && msg.Message.trim() ? `<div>${msg.Message}</div>` : '';
        var attachmentHtml = renderAttachmentHtml(msg.AttachmentPath, msg.AttachmentName);

        return `
            <div class="d-flex ${justifyClass} mb-10" ${msgIdAttr}>
                <div class="d-flex flex-column ${alignClass}">
                    <div class="d-flex align-items-center mb-2">
                        ${!isAdmin ? avatarHtml : ''}
                        <div class="${isAdmin ? 'me-2 text-end' : 'ms-1'}">
                            <span class="text-muted fs-8 mb-1">${formatTimestamp(msg.CreatedDate)}</span>
                            <span class="fs-6 fw-bold text-gray-900 text-hover-primary ${isAdmin ? 'ms-1' : 'me-1'}">${senderLabel}</span>
                        </div>
                        ${isAdmin ? avatarHtml : ''}
                    </div>
                    <div class="p-5 rounded ${bgClass} text-gray-900 fw-semibold mw-lg-400px">
                        ${textHtml}
                        ${attachmentHtml}
                    </div>
                </div>
            </div>
        `;
    };

    var renderContactItem = function (item, isActive) {
        var activeClass = isActive ? "bg-light-primary" : "";
        var initials = getInitials(item.Contractor);
        var contractorName = item.Contractor ? item.Contractor : item.SenderID;
        var lastMessage = item.Message ? item.Message : "No messages yet";
        var unreadCount = parseInt(item.UnreadCount, 10) || 0;
        var badgeDisplay = unreadCount > 0 ? (unreadCount > 99 ? "99+" : unreadCount) : "";
        var badgeHiddenClass = unreadCount > 0 ? "" : "d-none";

        return `
            <div class="chat-contact-item d-flex flex-stack py-4 border-bottom border-gray-300 border-bottom-dashed rounded px-3 cursor-pointer ${activeClass}" 
                 data-sender-id="${item.SenderID}" 
                 data-contractor-name="${contractorName}">
                <div class="d-flex align-items-center">
                    <div class="symbol symbol-45px symbol-circle me-3">
                        <span class="symbol-label bg-light-primary text-primary fs-6 fw-bolder">${initials}</span>
                    </div>
                    <div class="ms-1">
                        <span class="fs-6 fw-bold text-gray-900 text-hover-primary mb-1 d-block">${contractorName}</span>
                        <div class="fw-semibold fs-7 text-muted text-truncate mw-175px message-snippet">${lastMessage}</div>
                    </div>
                </div>
                <div class="d-flex flex-column align-items-end ms-2">
                    <span class="text-muted fs-8 mb-1 time-label">${formatTimestamp(item.CreatedDate)}</span>
                    <span class="badge badge-sm badge-circle badge-danger unread-badge ${badgeHiddenClass}">${badgeDisplay}</span>
                </div>
            </div>
        `;
    };

    var loadConversation = function (contractorId) {
        currentContractorId = contractorId.trim();

        replyInput.removeAttribute("disabled");
        replyInput.setAttribute("placeholder", "Type your reply to contractor...");
        sendButton.removeAttribute("disabled");
        if (attachButton) attachButton.removeAttribute("disabled");

        var statusEl = document.getElementById("chat_active_status");
        if (statusEl) statusEl.innerHTML = '<span class="badge badge-success badge-circle w-10px h-10px me-1"></span><span class="fs-7 fw-semibold text-muted">Connected</span>';

        var activeContactEl = contactsContainer.querySelector(`.chat-contact-item[data-sender-id='${currentContractorId}']`);
        if (activeContactEl) {
            var badgeEl = activeContactEl.querySelector(".unread-badge");
            if (badgeEl) {
                badgeEl.textContent = "";
                badgeEl.classList.add("d-none");
            }
        }

        chatHub.server.markAsReadAdmin(currentContractorId);

        messageContainer.innerHTML = `
            <div class="d-flex justify-content-center align-items-center h-100">
                <div class="spinner-border text-primary" role="status"></div>
            </div>
        `;

        chatHub.server.getMessagesByContractor(currentContractorId).done(function (messages) {
            if (messages && messages.length > 0) {
                messageContainer.innerHTML = messages.map(renderMessage).join("");
            } else {
                messageContainer.innerHTML = `
                    <div class="d-flex flex-column align-items-center justify-content-center h-100 text-center py-20">
                        <div class="symbol symbol-60px symbol-circle bg-light-warning mb-3 p-4">
                            <span class="svg-icon svg-icon-2hx svg-icon-warning">
                                <svg width="24" height="24" viewBox="0 0 24 24" fill="none" xmlns="http://www.w3.org/2000/svg">
                                    <rect opacity="0.3" x="2" y="2" width="20" height="20" rx="10" fill="currentColor"/>
                                    <rect x="11" y="14" width="2" height="2" rx="1" fill="currentColor"/>
                                    <rect x="11" y="6" width="2" height="6" rx="1" fill="currentColor"/>
                                </svg>
                            </span>
                        </div>
                        <span class="fs-6 fw-bold text-gray-800 mb-1">No messages found</span>
                        <span class="fs-7 text-muted mw-300px">There are no previous messages recorded with this contractor. Send a reply below to initiate the thread.</span>
                    </div>
                `;
            }
            scrollToBottom();
        }).fail(function (err) {
            console.error(err);
        });
    };

    var loadContractorConversations = function (focusContractorId) {
        var targetId = focusContractorId || currentContractorId || "";

        chatHub.server.getMessageContractor().done(function (data) {
            if (data && data.length > 0) {
                contactsContainer.innerHTML = data.map(function (item) {
                    var isSelected = targetId && (item.SenderID.trim().toLowerCase() === targetId.trim().toLowerCase());
                    return renderContactItem(item, isSelected);
                }).join("");

                if (targetId) {
                    var matched = data.find(function (x) {
                        return x.SenderID.trim().toLowerCase() === targetId.trim().toLowerCase();
                    });
                    if (matched && titleElement) {
                        titleElement.textContent = "Contractor: " + (matched.Contractor || matched.SenderID);
                    }
                } else {
                    currentContractorId = "";
                    if (titleElement) {
                        titleElement.textContent = "Select a Contractor";
                    }

                    messageContainer.innerHTML = `
                        <div class="d-flex flex-column align-items-center justify-content-center h-300px text-center py-20">
                            <span class="svg-icon svg-icon-3tx svg-icon-muted mb-4">
                                <svg width="24" height="24" viewBox="0 0 24 24" fill="none" xmlns="http://www.w3.org/2000/svg">
                                    <path opacity="0.3" d="M20 3H4C2.89543 3 2 3.89543 2 5V16C2 17.1046 2.89543 18 4 18H4.5C5.05228 18 5.5 18.4477 5.5 19V21.5C5.5 22.0523 6.17157 22.3284 6.56066 21.9393L10.5 18H20C21.1046 18 22 17.1046 22 16V5C22 3.89543 21.1046 3 20 3Z" fill="currentColor"/>
                                    <rect x="6" y="7" width="12" height="2" rx="1" fill="currentColor"/>
                                    <rect x="6" y="11" width="8" height="2" rx="1" fill="currentColor"/>
                                </svg>
                            </span>
                            <span class="fs-6 fw-bold text-gray-700">No conversation selected</span>
                            <span class="fs-7 text-muted mt-1">Click a contractor from the left list to view their messages.</span>
                        </div>
                    `;
                }
            } else {
                contactsContainer.innerHTML = `
                    <div class="text-center text-muted fs-7 py-20">
                        No active conversations found.
                    </div>
                `;
            }
        }).fail(function (error) {
            console.error(error);
        });
    };

    var contractorDropdown = jq("#ddl01Contractor");
    var modalMessageInput = document.getElementById("tbx01Message");
    var modalSubmitButton = document.getElementById("kt_modal_new_message_submit");
    var modalElement = document.getElementById("mdl01AddMessage");

    var ddl01Contractor = function () {
        $.ajax({
            type: "POST",
            url: "Assets/Handler/SCM/SCM200000HND.ashx",
            data: {
                'pFormCode': 'SCM200000',
                'pType': 'Get - Dropdown',
                'pTblName': 'Get_Contractor',
                'pPlaceHolder': 'Select Contractor'
            },
            success: function (response) {
                var s = '<option value=""></option>';
                for (var i = 0; i < response.length; i++) {
                    s += '<option value="' + response[i].ID + '">' + response[i].Name + '</option>';
                }
                $("#ddl01Contractor").html(s);
                $('#ddl01Contractor').val('').trigger('change');
            },
        });
    };

    var updateSidebarItem = function (senderId, messageText, createdDate, attachmentName, isIncomingContractorMsg, contractorName) {
        var cleanSenderId = senderId.trim();
        var existingItem = null;

        var allItems = contactsContainer.querySelectorAll(".chat-contact-item");
        allItems.forEach(function (el) {
            if (el.getAttribute("data-sender-id").toLowerCase() === cleanSenderId.toLowerCase()) {
                existingItem = el;
            }
        });

        var displaySnippet = messageText ? messageText.trim() : "";
        if (!displaySnippet && attachmentName) {
            displaySnippet = "📎 " + attachmentName.trim();
        } else if (!displaySnippet) {
            displaySnippet = "📎 Attachment";
        }

        if (existingItem) {
            var snippet = existingItem.querySelector(".message-snippet");
            var time = existingItem.querySelector(".time-label");
            var badgeEl = existingItem.querySelector(".unread-badge");

            if (snippet) snippet.textContent = displaySnippet;
            if (time) time.textContent = formatTimestamp(createdDate);

            if (contractorName && contractorName !== cleanSenderId) {
                var nameEl = existingItem.querySelector(".fs-6.fw-bold");
                if (nameEl) nameEl.textContent = contractorName;
                existingItem.setAttribute("data-contractor-name", contractorName);
            }

            if (isIncomingContractorMsg) {
                var isActive = currentContractorId && (currentContractorId.toLowerCase() === cleanSenderId.toLowerCase());
                if (isActive) {
                    if (badgeEl) {
                        badgeEl.textContent = "";
                        badgeEl.classList.add("d-none");
                    }
                } else if (badgeEl) {
                    var currentCount = parseInt(badgeEl.textContent, 10) || 0;
                    var newCount = currentCount + 1;
                    badgeEl.textContent = newCount > 99 ? "99+" : newCount;
                    badgeEl.classList.remove("d-none");
                }
            }

            contactsContainer.prepend(existingItem);
        } else {
            var emptyPlaceholder = contactsContainer.querySelector(".text-center.text-muted");
            if (emptyPlaceholder) {
                contactsContainer.innerHTML = "";
            }

            var isActive = currentContractorId && (currentContractorId.toLowerCase() === cleanSenderId.toLowerCase());
            var resolvedName = contractorName || cleanSenderId;

            var newItemHtml = renderContactItem({
                SenderID: cleanSenderId,
                Contractor: resolvedName,
                Message: displaySnippet,
                CreatedDate: createdDate,
                UnreadCount: (isIncomingContractorMsg && !isActive) ? 1 : 0
            }, isActive);

            contactsContainer.insertAdjacentHTML("afterbegin", newItemHtml);

            if (!contractorName || contractorName === cleanSenderId) {
                loadContractorConversations(currentContractorId);
            }
        }
    };

    var handleNewMessageSubmit = function () {
        var selectedContractor = contractorDropdown.val();
        var selectedContractorName = contractorDropdown.find("option:selected").text();
        var messageText = modalMessageInput.value.trim();

        if (!selectedContractor) {
            fn01AlertOnly('Some field(s) are missing!', 'error', 'btn btn-danger');
            return;
        }

        if (!messageText) {
            fn01AlertOnly('Some field(s) are missing!', 'error', 'btn btn-danger');
            return;
        }

        modalSubmitButton.setAttribute("data-kt-indicator", "on");
        modalSubmitButton.disabled = true;

        chatHub.server.sendAdminReply(selectedContractor, messageText, "", "").done(function () {
            modalSubmitButton.removeAttribute("data-kt-indicator");
            modalSubmitButton.disabled = false;

            modalMessageInput.value = "";
            contractorDropdown.val("").trigger("change");

            var modalInstance = bootstrap.Modal.getInstance(modalElement);
            if (modalInstance) {
                modalInstance.hide();
            }

            currentContractorId = selectedContractor.trim();
            if (titleElement) {
                titleElement.textContent = "Contractor: " + (selectedContractorName || selectedContractor);
            }

            loadContractorConversations(selectedContractor);
            loadConversation(selectedContractor);
            ddl01Contractor();
        }).fail(function (err) {
            modalSubmitButton.removeAttribute("data-kt-indicator");
            modalSubmitButton.disabled = false;
            console.error(err);
        });
    };

    if (modalSubmitButton) {
        jq(modalSubmitButton).off("click").on("click", function (e) {
            e.preventDefault();
            handleNewMessageSubmit();
        });
    }

    var submitReply = function () {
        if (!currentContractorId) {
            fn01AlertOnly('Please select a contractor first!', 'warning', 'btn btn-warning');
            return;
        }

        var text = replyInput.value.trim();
        if (!text && !adminUploadedFilePath) return;

        sendButton.disabled = true;

        chatHub.server.sendAdminReply(currentContractorId, text, adminUploadedFilePath, adminUploadedFileName).done(function () {
            replyInput.value = "";
            sendButton.disabled = false;

            if (adminDropzone) {
                adminDropzone.removeAllFiles(true);
            }
            adminUploadedFilePath = "";
            adminUploadedFileName = "";

            if (previewContainer) {
                previewContainer.classList.remove("d-flex");
                previewContainer.classList.add("d-none");
            }
            if (previewFileName) previewFileName.textContent = "";

            replyInput.focus();
        }).fail(function (err) {
            sendButton.disabled = false;
            console.error(err);
        });
    };

    Dropzone.autoDiscover = false;

    var adminDropzone = new Dropzone(document.body, {
        url: "Assets/Handler/SCM/SCM200000HND.ashx",
        clickable: "#btnAdminAttachFile",
        acceptedFiles: ".pdf,image/png,image/jpeg,image/jpg",
        maxFiles: 1,
        maxFilesize: 10,
        previewsContainer: false,
        init: function () {
            this.on("addedfile", function (file) {
                while (this.files.length > 1) {
                    this.removeFile(this.files[0]);
                }
            });

            this.on("maxfilesexceeded", function (file) {
                this.removeAllFiles();
                this.addFile(file);
            });

            this.on("sending", function (file, xhr, formData) {
                if (attachButton) attachButton.classList.add("disabled");

                formData.append("pFunction", "Upload - Attachment");
                formData.append("pCode", currentContractorId);
            });

            this.on("success", function (file, response) {
                if (attachButton) attachButton.classList.remove("disabled");

                var res = typeof response === "string" ? JSON.parse(response) : response;
                if (res.status === "success") {
                    adminUploadedFilePath = res.filePath;
                    adminUploadedFileName = res.fileName;

                    if (previewFileName) previewFileName.textContent = res.fileName;
                    if (previewContainer) {
                        previewContainer.classList.remove("d-none");
                        previewContainer.classList.add("d-flex");
                    }
                } else {
                    this.removeFile(file);
                    fn01AlertOnly(res.message || "Failed to upload file.", 'error');
                }
            });

            this.on("error", function (file, errorMessage) {
                if (attachButton) attachButton.classList.remove("disabled");
                this.removeFile(file);
                fn01AlertOnly(typeof errorMessage === "string" ? errorMessage : "Upload failed.", 'error');
            });
        }
    });

    if (removeAttachmentButton) {
        removeAttachmentButton.addEventListener("click", function (e) {
            e.preventDefault();
            if (adminDropzone) {
                adminDropzone.removeAllFiles(true);
            }
            adminUploadedFilePath = "";
            adminUploadedFileName = "";
            if (previewContainer) {
                previewContainer.classList.remove("d-flex");
                previewContainer.classList.add("d-none");
            }
            if (previewFileName) previewFileName.textContent = "";
        });
    }

    chatHub.client.receiveMessage = function (msg) {
        var incomingSender = msg.SenderID ? msg.SenderID.trim().toLowerCase() : "";
        var activeSender = currentContractorId ? currentContractorId.trim().toLowerCase() : "";
        var isFromContractor = msg.SenderType === "Contractor";

        if (incomingSender === activeSender) {
            if (msg.ID && msg.ID !== "0" && messageContainer.querySelector(`[data-message-id="${msg.ID}"]`)) {
                return;
            }

            var allBubbles = messageContainer.querySelectorAll(".d-flex.mb-10 .p-5");
            if (allBubbles.length > 0) {
                var lastBubbleText = allBubbles[allBubbles.length - 1].textContent.trim();
                var incomingText = (msg.Message || "").trim();
                if (incomingText && lastBubbleText === incomingText && !msg.AttachmentPath) {
                    return;
                }
            }

            var emptyNotice = messageContainer.querySelector(".text-center, .py-20, .h-250px, .h-100");
            if (emptyNotice && !emptyNotice.closest(".d-flex.mb-10")) {
                messageContainer.innerHTML = "";
            }

            if (!msg.CreatedDate) {
                msg.CreatedDate = new Date().toISOString();
            }

            if (!msg.Contractor) {
                var contactEl = contactsContainer.querySelector(`.chat-contact-item[data-sender-id='${msg.SenderID.trim()}']`);
                if (contactEl) {
                    msg.Contractor = contactEl.getAttribute("data-contractor-name");
                }
            }

            messageContainer.insertAdjacentHTML("beforeend", renderMessage(msg));
            scrollToBottom();

            if (isFromContractor) {
                chatHub.server.markAsReadAdmin(msg.SenderID);
            }
        }

        updateSidebarItem(msg.SenderID, msg.Message, msg.CreatedDate || new Date().toISOString(), msg.AttachmentName, isFromContractor, msg.Contractor);
    };

    jq(document).on("click", ".chat-contact-item", function () {
        jq(".chat-contact-item").removeClass("bg-light-primary");
        jq(this).addClass("bg-light-primary");

        var senderId = jq(this).data("sender-id");
        var contractorName = jq(this).data("contractor-name");

        if (titleElement) {
            titleElement.textContent = "Contractor: " + contractorName;
        }

        loadConversation(senderId);
    });

    jq(sendButton).off("click").on("click", function (e) {
        e.preventDefault();
        submitReply();
    });

    jq(replyInput).off("keydown").on("keydown", function (e) {
        if (e.key === "Enter" && !e.shiftKey) {
            e.preventDefault();
            submitReply();
        }
    });

    var filterContractors = function () {
        var query = searchInput.value.toLowerCase().trim();
        var contactItems = contactsContainer.querySelectorAll(".chat-contact-item");
        var visibleCount = 0;

        var emptySearchMessage = document.getElementById("no_matching_contractors");
        if (emptySearchMessage) {
            emptySearchMessage.remove();
        }

        contactItems.forEach(function (item) {
            var senderId = (item.getAttribute("data-sender-id") || "").toLowerCase();
            var contractorName = (item.getAttribute("data-contractor-name") || "").toLowerCase();
            var messageSnippet = (item.querySelector(".message-snippet") ? item.querySelector(".message-snippet").textContent : "").toLowerCase();

            if (senderId.includes(query) || contractorName.includes(query) || messageSnippet.includes(query)) {
                item.classList.remove("d-none");
                item.classList.add("d-flex");
                visibleCount++;
            } else {
                item.classList.remove("d-flex");
                item.classList.add("d-none");
            }
        });

        if (visibleCount === 0 && contactItems.length > 0) {
            var noMatchHtml = `
                <div id="no_matching_contractors" class="text-center text-muted fs-7 py-15">
                    No matching contractors found.
                </div>
            `;
            contactsContainer.insertAdjacentHTML("beforeend", noMatchHtml);
        }
    };

    if (searchInput) {
        searchInput.addEventListener("input", filterContractors);
        searchInput.addEventListener("keyup", filterContractors);
    }

    jq.connection.hub.start().done(function () {
        loadContractorConversations();
        ddl01Contractor();
    }).fail(function (reason) {
        console.error(reason);
    });
});