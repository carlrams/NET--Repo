<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="FINRTView.aspx.vb" Inherits="NET.FINRTView1" %>
<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=12.0.0.0, Culture=neutral, PublicKeyToken=89845DCD8080CC91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>CIIS</title>
    <link rel="shortcut icon" href="~/Assets/media/logos/favicon.ico" />
    <style>
        html,
        body {height: 100%;margin: 0;}
        .container {height: 100%; /* to see the effect */}
    </style>
</head>
<body>
    <div style="Width:auto;"> 
        <form id="form1" runat="server" style="width:100%; height:100%;">
            <asp:ScriptManager ID="ScriptManager1" runat="server">
            </asp:ScriptManager>
            <rsweb:ReportViewer ID="ReportViewer1" runat="server" Width="100%" Height="100%" AsyncRendering="False" SizeToReportContent="True">
            </rsweb:ReportViewer>
        </form>
    </div>

</body>
</html>

<script>
    document.addEventListener("DOMContentLoaded", function () {
        document.querySelectorAll(".rdlcField").forEach(function (field) {
            const url = field.textContent.trim();
            if (url.startsWith("http") || url.includes("FINRTView")) {
                field.innerHTML = <a href="${url}" target="_self">${url}</a>;
            }
        });
    });
</script> 