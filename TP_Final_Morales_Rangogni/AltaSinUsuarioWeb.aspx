<%@ Page Title="Empleado" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AltaSinUsuarioWeb.aspx.cs" Inherits="TP_Final_Morales_Rangogni.AltaSinUsuarioWeb" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="header bg-blue">
        <h4 class="left-align">Ingreso sin login</h4>
    </div>
    <div class="row">
        <div class="col s12">
            <div class="row">
                <div class="input-field col s4">
                    <asp:Label runat="server" AssociatedControlID="txtNom" CssClass="grey-text" ID="lblNom">Nombre</asp:Label>
                    <asp:TextBox ID="txtNom" runat="server" CssClass="validate" placeholder=""></asp:TextBox>
                </div>
                <div class="input-field col s4">
                    <asp:Label runat="server" ID="lblApe" CssClass="grey-text" AssociatedControlID="txtApellido">Apellido</asp:Label>
                    <asp:TextBox ID="txtApellido" runat="server" CssClass="validate" placeholder=""></asp:TextBox>                    
                </div>
                <div class="input-field col s4">
                    <asp:Label runat="server" ID="lblDni" CssClass="grey-text" AssociatedControlID="txtDni">Nº Documento</asp:Label>
                    <asp:TextBox ID="txtDni" runat="server" CssClass="validate" placeholder=""></asp:TextBox>
                </div>
            </div>
        </div>
        <!--Usuario -->
        <div class="row">
            <div class="input-field col s4">
                <asp:Label runat="server" ID="lblUser" CssClass="grey-text" AssociatedControlID="txtUser">Usuario</asp:Label>
                <asp:TextBox ID="txtUser" runat="server" CssClass="validate" placeholder=""></asp:TextBox>
            </div>
            <!--Contraseña -->
            <div class="input-field col s4">
                <asp:Label runat="server" ID="lblPass" CssClass="grey-text" AssociatedControlID="txtPass">Contraseña</asp:Label>
                <asp:TextBox ID="txtPass" runat="server" CssClass="validate" TextMode="Password" placeholder=""></asp:TextBox>
                
            </div>
            <div class="input-field col s4">
                <asp:Label runat="server" id="lblPass2" AssociatedControlID="txtPass2">Repetir Contraseña</asp:Label>
                <asp:TextBox ID="txtPass2" runat="server" CssClass="validate" TextMode="Password" placeholder=""></asp:TextBox>
                
            </div>
        </div>
        <div class="row">
            
            <div class="row">
                <div class="input-field col s12 center-align">
                    <asp:Button CssClass="waves-effect waves-light btn-small purple" ID="btnAceptar" OnClick="btnAceptar_Click" runat="server" Text="Aceptar" />
                </div>
            </div>
        </div>
    </div>
</asp:Content>