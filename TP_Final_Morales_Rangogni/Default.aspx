<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="TP_Final_Morales_Rangogni._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <h4>PERFIL</h4>
        <p class="lead">Permite agregar un nuevo tipo de perfil</p>
        <p><a href="/PerfilWeb" class="btn btn-primary btn-lg">Perfiles &raquo;</a></p>
    </div>

    <div class="row">
        <div class="col-md-4">
            <h4>Especialidad</h4>
            <p>
               Permite agregar una nueva especialidad.
            </p>
            <p>
                <a class="btn btn-default" href="/EspecialidadWeb">Especialidad &raquo;</a>
            </p>
        </div>
        <div class="col-md-4">
            <h4>Acceso</h4>
            <p>
                Ingreso al sistema por medio de un usuario y contraseña.
            </p>
            <p>
                <a class="btn btn-default" href="/Acceso">Acceso &raquo;</a>
            </p>
        </div>
        <div class="col-md-4">
            <h4>Empleado</h4>
            <p>
               Permite cargar los datos de los empleados.
                <asp:GridView ID="dgEmpleados" runat="server"></asp:GridView>
            </p>
            <p> 
                <asp:Button runat="server" ID="btnVerEmp" cssclass="btn btn-default" OnClick="btnVerEmp_Click" text="Empleados &raquo;" />
            </p>
        </div>
    </div>

</asp:Content>
