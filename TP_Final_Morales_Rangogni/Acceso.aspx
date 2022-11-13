<%@ Page Title="Contact" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="~/Acceso.aspx.cs" Inherits="TP_Final_Morales_Rangogni.Acceso" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="form-box" id="login-box">
        <layouttemplate>
            <div class="header bg-blue">
                <h3>Bienvenido</h3>
            </div>
            <div class="body bg-gray">
                <div class="form-group">
                    <asp:TextBox CssClass="form-control" ID="txtUser" runat="server" placeholder="Usuario"></asp:TextBox>
                </div>
                <div class="form-group">
                    <asp:TextBox ID="txtPassword" runat="server" CssClass="form-control" placeholder="Contraseña" TextMode="Password"></asp:TextBox>
                </div>
            </div>
            <div class="footer">
                <div class="row">
                    <div class="col s6">
                        <asp:Button ID="btnIngresar" CommandName="Login" runat="server" Text="Iniciar Sesión" OnClick="btnIngresar_Click" CssClass="btn bg-blue btn-block purple" />
                    </div>
                    <div class="col s6">
                        <asp:Button ID="btnFirst" CommandName="Login" runat="server" Text="Acceso primera vez" OnClick="btnFirst_Click" CssClass="waves-effect waves-teal btn-flat" />
                    </div>
                </div>
            </div>
        </layouttemplate>
    </div>
</asp:Content>


