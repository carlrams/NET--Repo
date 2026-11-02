<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MNU000000.Master" CodeBehind="SCM200000.aspx.vb" Inherits="NET.SCM200000" MaintainScrollPositionOnPostback="true" %>
<%@ MasterType VirtualPath="MNU000000.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="content flex-row-fluid" id="kt_content">
    
        <div class="toolbar py-5">
            <div class="container-xxl d-flex flex-stack flex-wrap p-0">
                <div class="page-title d-flex flex-column me-3">
                    <h1 class="d-flex text-white fw-bolder my-1 fs-3">Contract Admin</h1>
                    <ul class="breadcrumb breadcrumb-separatorless fw-bold fs-7 my-1">
                        <li class="breadcrumb-item text-white">Message</li>
                    </ul>
                </div>
            </div>
        </div>

        <div class="d-flex flex-column flex-lg-row align-items-stretch" style="height: 680px; min-height: 680px;">
    
            <div class="flex-column flex-lg-row-auto w-100 w-lg-325px w-xl-400px mb-10 mb-lg-0 h-100">
                <div class="card card-flush h-100 border shadow-sm">
                    <div class="card-header pt-7 pb-4" id="kt_chat_contacts_header">
                        <div class="d-flex flex-column w-100 gap-4">
                            <div class="d-flex align-items-center justify-content-between">
                                <h3 class="card-title fw-bolder text-gray-900 fs-4 m-0">Conversations</h3>
                                <button type="button" class="btn btn-sm btn-primary d-flex align-items-center gap-1" data-bs-toggle="modal" data-bs-target="#mdl01AddMessage">
                                    <span class="svg-icon svg-icon-3">
                                        <svg width="24" height="24" viewBox="0 0 24 24" fill="none" xmlns="http://www.w3.org/2000/svg">
                                            <rect opacity="0.5" x="11.364" y="20.364" width="16" height="2" rx="1" transform="rotate(-90 11.364 20.364)" fill="currentColor" />
                                            <rect x="4.36396" y="11.364" width="16" height="2" rx="1" fill="currentColor" />
                                        </svg>
                                    </span>
                                    <span>New Message</span>
                                </button>
                            </div>
                            <div class="w-100 position-relative">
                                <span class="svg-icon svg-icon-2 svg-icon-lg-1 svg-icon-gray-500 position-absolute top-50 ms-5 translate-middle-y">
                                    <svg width="24" height="24" viewBox="0 0 24 24" fill="none" xmlns="http://www.w3.org/2000/svg">
                                        <rect opacity="0.5" x="17.0365" y="15.1223" width="8.15546" height="2" rx="1" transform="rotate(45 17.0365 15.1223)" fill="currentColor" />
                                        <path d="M11 19C6.55556 19 3 15.4444 3 11C3 6.55556 6.55556 3 11 3C15.4444 3 19 6.55556 19 11C19 15.4444 15.4444 19 11 19ZM11 5C7.53333 5 5 7.53333 5 11C5 14.4667 7.53333 17 11 17C14.4667 17 17 14.4667 17 11C17 7.53333 14.4667 5 11 5Z" fill="currentColor" />
                                    </svg>
                                </span>
                                <input type="text" class="form-control form-control-solid px-15" id="search_contractors" name="search" value="" placeholder="Search contractor..." autocomplete="off" />
                            </div>
                        </div>
                    </div>

                    <div class="card-body pt-2 pb-5 flex-grow-1 overflow-hidden" id="kt_chat_contacts_body">
                        <div class="scroll-y me-n5 pe-5 h-100" id="contractor_contacts_list">
                            <div class="d-flex justify-content-center align-items-center h-100">
                                <div class="spinner-border text-primary" role="status"></div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>

            <div class="flex-lg-row-fluid ms-lg-7 ms-xl-10 h-100">
                <div class="card h-100 border shadow-sm d-flex flex-column" id="kt_chat_messenger">
                    <div class="card-header flex-shrink-0" id="kt_chat_messenger_header">
                        <div class="card-title">
                            <div class="d-flex justify-content-center flex-column me-3">
                                <div class="d-flex align-items-center mb-1">
                                    <span class="fs-4 fw-bold text-gray-900 me-2 lh-1" id="chat_active_contractor_title">Select a Contractor</span>
                                    <span class="badge badge-light-secondary fs-8 d-none" id="chat_active_project_badge"></span>
                                </div>
                                <div class="mb-0 lh-1">
                                    <span class="fs-7 fw-semibold text-muted" id="chat_active_status">No active conversation</span>
                                </div>
                            </div>
                        </div>
                        <div class="card-toolbar">
                            <button class="btn btn-sm btn-icon btn-active-light-primary d-none" id="btn_contractor_profile" data-bs-toggle="tooltip" title="View Contractor Profile">
                                <span class="svg-icon svg-icon-2">
                                    <svg width="24" height="24" viewBox="0 0 24 24" fill="none" xmlns="http://www.w3.org/2000/svg">
                                        <path d="M11 2.37997C11.6 2.07997 12.4 2.07997 13 2.37997L19.4 5.57997C20 5.87997 20.4 6.57997 20.4 7.27997V13.28C20.4 18.08 17.2 22.48 12.4 23.98C12.1 24.08 11.9 24.08 11.6 23.98C6.8 22.48 3.6 18.08 3.6 13.28V7.27997C3.6 6.57997 4 5.87997 4.6 5.57997L11 2.37997Z" fill="currentColor"/>
                                    </svg>
                                </span>
                            </button>
                        </div>
                    </div>

                    <div class="card-body flex-grow-1 overflow-hidden p-6" id="kt_chat_messenger_body">
                        <div class="scroll-y me-n5 pe-5 h-100" data-kt-element="messages">
                            <div class="d-flex flex-column align-items-center justify-content-center h-100 text-center py-20">
                                <div class="symbol symbol-70px symbol-circle bg-light-primary mb-4 p-5">
                                    <span class="svg-icon svg-icon-2hx svg-icon-primary">
                                        <svg width="24" height="24" viewBox="0 0 24 24" fill="none" xmlns="http://www.w3.org/2000/svg">
                                            <path opacity="0.3" d="M20 3H4C2.89543 3 2 3.89543 2 5V16C2 17.1046 2.89543 18 4 18H4.5C5.05228 18 5.5 18.4477 5.5 19V21.5C5.5 22.0523 6.17157 22.3284 6.56066 21.9393L10.5 18H20C21.1046 18 22 17.1046 22 16V5C22 3.89543 21.1046 3 20 3Z" fill="currentColor"/>
                                            <rect x="6" y="7" width="12" height="2" rx="1" fill="currentColor"/>
                                            <rect x="6" y="11" width="8" height="2" rx="1" fill="currentColor"/>
                                        </svg>
                                    </span>
                                </div>
                                <h3 class="fs-5 fw-bolder text-gray-800 mb-1">No conversation selected</h3>
                                <p class="fs-7 text-muted mw-300px mb-0">Select a contractor from the left list to review their messages or send a reply.</p>
                            </div>
                        </div>
                    </div>

                    <div class="card-footer pt-4 pb-6 flex-shrink-0" id="kt_chat_messenger_footer">
                        <div id="divAdminAttachmentPreview" class="d-none align-items-center justify-content-between p-2 mb-3 bg-light rounded border">
                            <div class="d-flex align-items-center gap-2 overflow-hidden">
                                <span class="svg-icon svg-icon-2 svg-icon-primary flex-shrink-0">
                                    <svg width="24" height="24" viewBox="0 0 24 24" fill="none" xmlns="http://www.w3.org/2000/svg">
                                        <path opacity="0.3" d="M19 22H5C4.4 22 4 21.6 4 21V3C4 2.4 4.4 2 5 2H14L20 8V21C20 21.6 19.6 22 19 22Z" fill="currentColor"/>
                                        <path d="M15 8H20L14 2V7C14 7.6 14.4 8 15 8Z" fill="currentColor"/>
                                    </svg>
                                </span>
                                <span id="lblAdminAttachmentName" class="fs-8 fw-semibold text-gray-800 text-truncate mw-250px"></span>
                            </div>
                            <button type="button" id="btnAdminRemoveAttachment" class="btn btn-icon btn-sm btn-active-light-danger w-25px h-25px rounded-circle">
                                <span class="svg-icon svg-icon-3">
                                    <svg width="24" height="24" viewBox="0 0 24 24" fill="none" xmlns="http://www.w3.org/2000/svg">
                                        <rect opacity="0.5" x="6" y="17.3137" width="16" height="2" rx="1" transform="rotate(-45 6 17.3137)" fill="currentColor"/>
                                        <rect x="7.41422" y="6" width="16" height="2" rx="1" transform="rotate(45 7.41422 6)" fill="currentColor"/>
                                    </svg>
                                </span>
                            </button>
                        </div>

                        <textarea class="form-control form-control-flush mb-3 resize-none" rows="2" data-kt-element="input" placeholder="Select a contractor to send a reply..." disabled></textarea>

                        <div class="d-flex align-items-center justify-content-between">
                            <div class="d-flex align-items-center me-2">
                                <button class="btn btn-sm btn-icon btn-active-light-primary me-1" type="button" id="btnAdminAttachFile" data-bs-toggle="tooltip" title="Attach blueprint/PDF or image" disabled>
                                    <span class="svg-icon svg-icon-2">
                                        <svg width="24" height="24" viewBox="0 0 24 24" fill="none" xmlns="http://www.w3.org/2000/svg">
                                            <path opacity="0.3" d="M4.425 19.575C2.525 17.675 2.525 14.575 4.425 12.675L12.625 4.475C13.825 3.275 15.725 3.275 16.925 4.475C18.125 5.675 18.125 7.575 16.925 8.775L9.425 16.275C8.825 16.875 7.825 16.875 7.225 16.275C6.625 15.675 6.625 14.675 7.225 14.075L13.325 7.975C13.725 7.575 14.325 7.575 14.725 7.975C15.125 8.375 15.125 8.975 14.725 9.375L8.625 15.475C8.825 15.675 9.025 15.675 9.225 15.475L16.725 7.975C17.325 7.375 17.325 6.375 16.725 5.775C16.125 5.175 15.125 5.175 14.525 5.775L6.325 13.975C4.825 15.475 4.825 17.875 6.325 19.375C7.825 20.875 10.225 20.875 11.725 19.375L19.925 11.175C20.325 10.775 20.925 10.775 21.325 11.175C21.725 11.575 21.725 12.175 21.325 12.575L13.125 20.775C10.725 23.175 6.825 23.175 4.425 19.575Z" fill="currentColor"/>
                                        </svg>
                                    </span>
                                </button>
                            </div>
                            <button class="btn btn-primary btn-sm px-5" type="button" id="btnAdminSend" disabled>Send Reply</button>
                        </div>
                    </div>
                </div>
            </div>

        </div>

    </div>

    <div class="modal fade" id="mdl01AddMessage" tabindex="-1" aria-hidden="true">
        <div class="modal-dialog modal-dialog-centered mw-650px">
            <div class="modal-content rounded">
                <div class="modal-header pb-0 border-0 justify-content-end">
                    <div class="btn btn-sm btn-icon btn-active-color-primary" data-bs-dismiss="modal">
                        <span class="svg-icon svg-icon-1">
                            <svg width="24" height="24" viewBox="0 0 24 24" fill="none" xmlns="http://www.w3.org/2000/svg">
                                <rect opacity="0.5" x="6" y="17.3137" width="16" height="2" rx="1" transform="rotate(-45 6 17.3137)" fill="currentColor" />
                                <rect x="7.41422" y="6" width="16" height="2" rx="1" transform="rotate(45 7.41422 6)" fill="currentColor" />
                            </svg>
                        </span>
                    </div>
                </div>

                <div class="modal-body scroll-y px-10 px-lg-15 pt-0 pb-15">
                    <div class="mb-13 text-center">
                        <h1 class="mb-3">Start New Conversation</h1>
                        <div class="text-muted fw-semibold fs-5">Compose and broadcast a message directly to a contractor.</div>
                    </div>

                    <div class="d-flex flex-column mb-8 fv-row">
                        <label class="d-flex align-items-center fs-6 fw-semibold mb-2">
                            <span class="required">Contractor</span>
                        </label>
                        <select id="ddl01Contractor" class="form-select form-select-solid border border-danger" data-control="select2" data-hide-search="false" data-dropdown-parent="#mdl01AddMessage"  data-placeholder="Select contractor" name="contractor_id">
                            <option value=""></option>
                        </select>
                    </div>

                    <div class="d-flex flex-column mb-8 fv-row">
                        <label class="required fs-6 fw-semibold mb-2">Message</label>
                        <textarea id="tbx01Message" class="form-control form-control-solid border border-danger" rows="4" name="message_body" placeholder="Write your message here..."></textarea>
                    </div>

                    <div class="text-center">
                        <button type="reset" class="btn btn-light me-3" data-bs-dismiss="modal">Cancel</button>
                        <button type="button" id="kt_modal_new_message_submit" class="btn btn-primary">
                            <span class="indicator-label">Send Message</span>
                        </button>
                    </div>
                </div>
            </div>
        </div>
    </div>

    <script type="text/javascript" src="Assets/js/SCM/SCM200000.js"></script>
    <script type="text/javascript" src="Assets/js/MNU/MNU001000.js"></script>

</asp:Content>
