<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="MedicoWeb.aspx.cs" Inherits="TP_Final_Morales_Rangogni.MedicoWeb" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContentLogin" runat="server">
    <ul id="tabs-swipe" class="tabs">
        <li class="tab col s3 purple"><a href="#test-swipe-1" class="white-text">AGENDA</a></li>
        <li class="tab col s3 purple"><a href="#test-swipe-2" class="white-text">PACIENTES</a></li>
    </ul>
    <div id="test-swipe-1" class="col s12 blue">Test 1</div>
    <div id="test-swipe-2" class="col s12 red">Test 2</div>
    <script >
        document.addEventListener('DOMContentLoaded', function () {
            M.AutoInit();
        });
    </script>
</asp:Content>
