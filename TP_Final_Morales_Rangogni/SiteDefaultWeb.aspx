<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="SiteDefaultWeb.aspx.cs" Inherits="TP_Final_Morales_Rangogni.SiteDefaultWeb" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContentLogin" runat="server">

    <div class="section purple lighten-1 no-pad-bot z-depth-1 start-splash-section">
        <div class="row">
            <div class="col s4 l3">
                <h4 class="white-text start-header-paragraph-text">
                    <span class="white-text text-lighten-1">Medicina aplicada con eficiencia</span>
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

        <div class="col-md-5">
            <h4>Salir</h4>
            <p>
                Cerrar session al sistema del usuario.
            </p>
            <p>
                <a class="btn btn-default" href="/Default">Salir &raquo;</a>
            </p>
        </div>


    </div>
</asp:Content>
