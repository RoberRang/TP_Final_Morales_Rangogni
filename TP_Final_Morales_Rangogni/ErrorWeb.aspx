<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ErrorWeb.aspx.cs" Inherits="TP_Final_Morales_Rangogni.ErrorWeb" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row">
        <div class="input-field col s6">
            <h1>HUBO UN ERROR</h1>
            <asp:Label runat="server" ID="lblMensajeError" ></asp:Label>
        </div>
    </div>
</asp:Content>
