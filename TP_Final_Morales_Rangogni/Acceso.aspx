<%@ Page Title="Contact" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="~/Acceso.aspx.cs" Inherits="AccesoModeloBaseDatos.Acceso" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="form-box" id="login-box">
        <asp:Login ID="UserAccess" runat="server"  EnableViewState="false" OnAuthenticate="LoginUser_Authenticate" Width="100%">
            <LayoutTemplate>
                <div class="header bg-blue">Bienvenido</div>
                <div class="body bg-gray">
                    <div class="form-group">
                        <asp:TextBox cssClass="form-control" ID="UserName" runat="server" placeholder="Usuario"></asp:TextBox>
                    </div>
                    <div class="form-group">
                        <asp:TextBox ID="Password" runat="server" cssClass="form-control" placeholder="Contraseña" TextMode="Password"></asp:TextBox>
                    </div>
                </div>
                <div class="footer">
                    <asp:Button ID="btnIngresar" CommandName="Login" runat="server" Text="Iniciar Sesión" cssClass="btn bg-blue btn-block purple" />
                </div>
            </LayoutTemplate>
        </asp:Login>
    </div>
</asp:Content>


