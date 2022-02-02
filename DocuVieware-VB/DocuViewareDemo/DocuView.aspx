<%@ Page Language="vb" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="DocuView.aspx.vb" Inherits="DocuViewareDemo.DocuView" %>

<%@ Register Assembly="GdPicture.NET.14.WEB.DocuVieware" Namespace="GdPicture14.WEB" TagPrefix="cc1" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    
        <cc1:DocuVieware ID="DocuVieware1" runat="server"
            Height="800px"
            Width="1000px" />
    

    <script>
        function RegisterOnNewDocumentLoadedOnDocuViewareAPIReady() {
            if (typeof DocuViewareAPI !== 'undefined' && DocuViewareAPI.IsInitialized('DocuVieware1')) {
                DocuViewareAPI.RegisterOnNewDocumentLoaded('DocuVieware1', function () { DocuViewareAPI.SelectAnnotationsSnapIn('DocuVieware1') });
            }
            else {
                setTimeout(function () { RegisterOnNewDocumentLoadedOnDocuViewareAPIReady() }, 10);
            }
        }
        window.onload = function (e) {
            RegisterOnNewDocumentLoadedOnDocuViewareAPIReady();
        }
        function saveToStream() {
            alert("Onclick Event");
        }
    </script>
</asp:Content>

