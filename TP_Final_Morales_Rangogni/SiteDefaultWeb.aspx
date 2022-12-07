<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="SiteDefaultWeb.aspx.cs" Inherits="TP_Final_Morales_Rangogni.SiteDefaultWeb" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContentLogin" runat="server">
    <br />
    <br />

    <div class="section purple lighten-1 no-pad-bot z-depth-1 start-splash-section">
        <div class="row">
            <div class="col s4 l3 center-align">
                <br />
                <br />
                <img src="Imagenes/Logo_3.jpg" width="90" />

                <h4 class="white-text start-header-paragraph-text">
                    <span class="white-text text-lighten-1">Clínica MORA</span>
                </h4>


            </div>

            <div class="col s8 l3">
                <div class="splash-image-container">
                    <img src="Imagenes/Imagen1.jpg" class="splash-image">
                </div>
            </div>

        </div>
    </div>

    <div class="row">

        <div class="col s8">
            
            <p>
                Cerrar sesion del sistema al usuario.
            </p>
            <p>
                <a class="modal-close btn-flat purple white-text" href="/Default">Salir &raquo;</a>
            </p>
        </div>


    </div>
</asp:Content>
