<%@ Page Title="Empleado" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EmpleadoWeb.aspx.cs" Inherits="TP_Final_Morales_Rangogni.EmpleadoWeb" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="header bg-blue">
        <h4 class="left-align">Agregar Empleado</h4>
    </div>
    <div class="row">
        <div class="col s12">
            <div class="row">
                <div class="input-field col s4">
                    <asp:TextBox ID="txtnombre" runat="server" CssClass="validate" placeholder=""></asp:TextBox>
                    <label for="lblNombre">Nombre</label>
                </div>
                <div class="input-field col s4">
                    <asp:TextBox ID="txtApellido" runat="server" CssClass="validate" placeholder=""></asp:TextBox>
                    <label for="lblApellido">Apellido</label>
                </div>
                <div class="input-field col s4">
                    <asp:TextBox ID="txtDni" runat="server" CssClass="validate" placeholder=""></asp:TextBox>
                    <label for="lblDniEmp">Nº Documento</label>
                </div>
            </div>
        </div>
        <!--Usuario -->
        <div class="row">
            <div class="input-field col s4">
                <asp:TextBox ID="txtUser" runat="server" CssClass="validate" placeholder=""></asp:TextBox>
                <label for="lblUser">Usuario</label>
            </div>
            <!--Contraseña -->
            <div class="input-field col s4">
                <asp:TextBox ID="txtPass" runat="server" CssClass="validate" TextMode="Password" placeholder=""></asp:TextBox>
                <label for="lblPass">Contraseña</label>
            </div>
            <div class="input-field col s4">
                <asp:TextBox ID="txtPass2" runat="server" CssClass="validate" TextMode="Password" placeholder=""></asp:TextBox>
                <label for="lblPass2">Repetir Contraseña</label>
            </div>
        </div>
        <!--DDL Y ESTADO -->
        <div class="row">

            <div class="input-field col s4 left-align">
                <label for="lblPerfil">Tipo Pefil</label>
                <br />
                <br />
                <asp:DropDownList ID="ddlPerfilEmp" runat="server" CssClass="dropdown-trigger btn purple lighten-2" Style="margin-top: 10px;" href="#" data-activates="drpdEstado" data-target="drpdEstado">
                </asp:DropDownList>
            </div>
            <div>
                <div class="input-field col s4 center-align">
                </div>
                <div class="input-field col s4 right-align">
                    <label for="lblEstado">Estado</label>
                    <br />
                    <br />
                    <div class="switch">
                        <label>
                            INACTIVO
                            <asp:CheckBox ID="chbEstado1" runat="server" Checked="true" />

                            <span class="lever"></span>
                            ACTIVO
                        </label>
                    </div>
                </div>
            </div>
            <div class="row">
                <div class="input-field col s12 center-align">
                    <asp:Button CssClass="waves-effect waves-light btn-small" ID="btnAceptar" OnClick="btnAceptar_Click" runat="server" Text="Aceptar" />
                </div>
            </div>
        </div>
    </div>
    <div class="col-md-5">
        <h4>Empleado</h4>
        <p>
            Permite ver los datos de los empleados.
                <asp:GridView ID="dgEmpleados" CssClass="highlight responsive-table" runat="server"></asp:GridView>
        </p>
        <p>
            <asp:Button runat="server" ID="btnVerEmp" CssClass="btn btn-default" OnClick="btnVerEmp_Click" Text="Empleados &raquo;" />
        </p>
    </div>
</asp:Content>