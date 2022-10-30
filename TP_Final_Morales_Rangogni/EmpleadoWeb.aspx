<%@ Page Title="Empleado" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EmpleadoWeb.aspx.cs" Inherits="TP_Final_Morales_Rangogni.EmpleadoWeb" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="header bg-blue">
        <h4 class="left-align">Agregar Empleado</h4>
    </div>
    <div class="row">
        <div class="col s12">
            <div class="row">
                <div class="input-field col s12">
                    <asp:TextBox ID="txtnombre" runat="server" CssClass="validate"></asp:TextBox>
                    <label for="lblNombre">Nombre</label>
                </div>
                <div class="input-field col s12">
                    <asp:TextBox ID="txtApellido" runat="server" CssClass="validate"></asp:TextBox>
                    <label for="lblApellido">Apellido</label>
                </div>
            </div>

            <div class="row">
                <div class="input-field col s12">
                    <asp:TextBox ID="txtDni" runat="server" CssClass="validate"></asp:TextBox>
                    <label for="lblDniEmp">Nº Documento</label>
                </div>
            </div>

            <div class="row">
                <div class="input-field col s12">
                    <asp:DropDownList ID="ddlPerfilEmp" runat="server" CssClass="dropdown-trigger btn purple lighten-2" Style="margin-top: 10px;" href="#" data-activates="drpdEstado" data-target="drpdEstado">
                    </asp:DropDownList>
                </div>
                </div>
                
                <div class="row">
                    <div class="input-field col s12">
                        Estado
                    <div class="switch">
                        <label>
                            INACTIVO
                            <asp:CheckBox ID="chbEstado1" runat="server" />

                            <span class="lever"></span>
                            ACTIVO
                        </label>
                    </div>
                    </div>
                </div>
                <div class="row">
                    <div class="input-field col s12">
                        <asp:Button CssClass="waves-effect waves-light btn-small" ID="btnAceptar" OnClick="btnAceptar_Click" runat="server" Text="Aceptar" />
                    </div>
                </div>
        </div>
    </div>
</asp:Content>
