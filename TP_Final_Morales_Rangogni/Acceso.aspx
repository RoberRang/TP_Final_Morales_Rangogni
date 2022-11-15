<%@ Page Title="Contact" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="~/Acceso.aspx.cs" Inherits="TP_Final_Morales_Rangogni.Acceso" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <!---ACA--->    
    <div class="card panel center-align">
    <h3>Bienvenido</h3>
        </div>
    
        <div class="col s12 z-depth-6 card-panel">

            
            <div class="row">
                <div class="input-field col s12">
                    <i class="material-icons prefix">mail_outline</i>
                    <asp:TextBox CssClass="form-control" ID="txtUser" runat="server" placeholder="Usuario"></asp:TextBox>

                </div>
            </div>
            <div class="row">
                <div class="input-field col s12">
                    <i class="material-icons prefix">lock_outline</i>
                    <asp:TextBox ID="txtPassword" runat="server" CssClass="form-control" placeholder="Contraseña" TextMode="Password"></asp:TextBox>

                </div>
            </div>
           
            <div class="row">
                <div class="input-field col s12">
                    <asp:Button ID="btnIngresar" CommandName="Login" runat="server" Text="Iniciar Sesión" OnClick="btnIngresar_Click" CssClass="btn waves-effect waves-light col s12" />
                </div>
            </div>
            <div class="row">
                <div class="input-field col s12">
                    <asp:Button ID="btnFirst" CommandName="Login" runat="server" Text="Si no tenes cuenta registrate!" OnClick="btnFirst_Click" CssClass="waves-effect waves-light btn-small" />

                </div>
               
            </div>


        </div>
    
    <!---ACA--->

</asp:Content>
