<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="TP_Final_Morales_Rangogni._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <!--LINEA-->
    <div class="progress">
        <div class="indeterminate red"></div>
    </div>
    <!--TERMINA LINEA-->

    <div class="section white no-pad-top">
        <div class="section purple lighten-1 no-pad-bot z-depth-1 start-splash-section">
            <div class="container start-splash-container">
                <div class="row">
                    <h4 class="white-text start-header-paragraph-text">
                        <span class="white-text text-lighten-1">Medicina aplicada al paciente</span>
                    </h4>
                </div>
                <div class="col s12 l3">
                    <div class="splash-image-container">
                        <img src="Imagenes/Imagen1.jpg" class="splash-image">
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div class="row">
        
        <div class="col-md-5">
            <h4>Acceso</h4>
            <p>
                Ingreso al sistema por medio de un usuario y contraseña.
            </p>
            <p>
                <a class="btn btn-default purple" href="/Acceso">Acceder &raquo;</a>
            </p>
        </div>


    </div>

</asp:Content>
