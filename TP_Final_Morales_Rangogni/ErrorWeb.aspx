<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ErrorWeb.aspx.cs" Inherits="TP_Final_Morales_Rangogni.ErrorWeb" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row">
        <div class="input-field col1">
            <h3>HUBO UN ERROR</h3>
            <asp:Label runat="server" ID="lblMensajeError" ></asp:Label>
        </div>
    </div>
</asp:Content>
