<%@ Page Language="vb" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="AnnotateApi.aspx.vb" Inherits="DocuViewareDemo.AnnotateApi" %>

<%@ Register Assembly="GdPicture.NET.14.WEB.DocuVieware" Namespace="GdPicture14.WEB" TagPrefix="cc1" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div>
        <label>Document ID: </label>
        <input type="text" name="documentId" id="documentId" value="" runat="server" />
        <input type="submit" name="submit" value="submit" />
    </div>
    <br />


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
