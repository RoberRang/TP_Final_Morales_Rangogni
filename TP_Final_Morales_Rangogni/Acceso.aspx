<%@ Page Title="Contact" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="~/Acceso.aspx.cs" Inherits="AccesoModeloBaseDatos.Acceso" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="form-box" id="login-box">
        <asp:Login ID="UserAccess" runat="server"  EnableViewState="false" OnAuthenticate="UserAccess_Authenticate" Width="100%">
            <LayoutTemplate>
                <div class="header bg-blue">Bienvenido</div>
                <div class="body bg-gray">
                    <div class="form-group">
                        <asp:TextBox ID="UserName" runat="server" CssClass="form-control" placeholder="Usuario"></asp:TextBox>
                    </div>
                    <div class="form-group">
                        <asp:TextBox ID="Password" runat="server" CssClass="form-control" placeholder="Contraseña" TextMode="Password"></asp:TextBox>
                    </div>
                </div>
                <div class="footer">
                    <asp:Button ID="btnIngresar" CommandName="Login" runat="server" Text="Iniciar Sesión" CssClass="btn bg-blue btn-block" />
                </div>
            </LayoutTemplate>
        </asp:Login>
        <asp:Login ID="Login1" runat="server"></asp:Login>
    </div>
</asp:Content>


