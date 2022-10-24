<%@ Page Title="Contact" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AbmPerfil.aspx.cs" Inherits="AccesoModeloBaseDatos.Contact" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div>
        <asp:Label ID="lblDesc" runat="server" Text="Descripcion"></asp:Label>
        <asp:TextBox ID="txtDesc" cssclass="amber" runat="server"></asp:TextBox>
    </div>
    <div>
        <asp:Label ID="lblEstado" runat="server" Text="Estado"></asp:Label>
        <asp:CheckBox ID="chbEstado" cssclass="filled-in red" runat="server"></asp:CheckBox>

        <p>
            <label>
                <input type="checkbox" class="filled-in" checked="checked" />
                <span>Filled in</span>
            </label>
        </p>

    </div>

</asp:Content>

