<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ErrorWeb.aspx.cs" Inherits="TP_Final_Morales_Rangogni.ErrorWeb" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row center-align">
        <h3>HUBO UN ERROR</h3>
    </div>
    <div class="row">
        <div class="col s12">
            <h6>
                <asp:Label runat="server" CssClass="purple-text" ID="lblMensajeError"></asp:Label>
            </h6>
        </div>
    </div>
    <div class="row">
        <div class="col s12">
            <h6>
                <asp:LinkButton runat="server" ID="lbtnDefaultLogin" OnClick="lbtnDefaultLogin_Click" CssClass="btn-floating purple small"><i class="material-icons left-align">undo</i></asp:LinkButton>
            </h6>
        </div>
    </div>
</asp:Content>
