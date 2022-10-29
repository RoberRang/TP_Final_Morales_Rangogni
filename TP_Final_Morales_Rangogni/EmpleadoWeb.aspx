<%@ Page Title="Empleado" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EmpleadoWeb.aspx.cs" Inherits="TP_Final_Morales_Rangogni.EmpleadoWeb" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row">
        <form class="col s12">
            <div class="row">
                <div class="input-field col s12">
                    <input id="nombreEmp" type="text" class="validate">
                    <label for="lblNombre">Nombre</label>
                </div>
                <div class="input-field col s12">
                    <input id="apellidoEmp" type="text" class="validate">
                    <label for="lblApellido">Apellido</label>
                </div>
            </div>

            <div class="row">
                <div class="input-field col s12">
                    <input id="dniEmp" type="text" class="validate">
                    <label for="lblDniEmp">Nº Documento</label>
                </div>
            </div>

            <div class="row">
                <div class="input-field col s12">
                    Estado
                    <div class="switch">
                        <label>
                            INACTIVO
                             <input type="checkbox">
                            <span class="lever"></span>
                            ACTIVO
                        </label>
                    </div>
                </div>
            </div>
            <div class="row">
                <div class="input-field col s12">
                    <a class="waves-effect waves-light btn-small">Agregar</a>
                </div>
            </div>
        </form>
    </div>
</asp:Content>
