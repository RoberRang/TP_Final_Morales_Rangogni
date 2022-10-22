<%@ Page Title="About" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="PerfilWeb.aspx.cs" Inherits="AccesoModeloBaseDatos.PerfilWeb" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="header bg-blue">
        <h3>Perfiles</h3>
    </div>
    <div class="body bg-gray">
        <asp:Repeater runat="server" ID="rprPerfiles">
            <ItemTemplate>
                <ul class="collection with-header">
                    <li class="collection-item">
                        <asp:Label ID="lblDesc" Text="" runat="server"> <%#Eval("Descripcion")%></asp:Label>
                    </li>
                    <li class="collection-item">
                        <asp:CheckBox ID="chkPerfil" runat="server" />
                    </li>
                </ul>
            </ItemTemplate>
        </asp:Repeater>
        <div class="form-group">
            <asp:TextBox CssClass="form-control" ID="txtDesc" runat="server" placeholder="Descripción"></asp:TextBox>
        </div>
        <asp:Button ID="btnIngresar" CommandName="Login" runat="server" Text="Grabar" CssClass="btn bg-blue btn-block purple" OnClick="btnIngresar_Click" />
    </div>
</asp:Content>
