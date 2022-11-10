<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="PacienteWeb.aspx.cs" Inherits="TP_Final_Morales_Rangogni.PacienteWeb" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="header bg-blue">
        <h4 class="left-align">Agregar Paciente</h4>
    </div>
    <!--imagen-->
    <div class="col s12">
        <div class="row">
            <div class="file-field input-field col s4 circle responsive-img">
                <asp:Image ID="imgPaciente" runat="server" CssClass="circle responsive-img" src="https://objetivoligar.com/wp-content/uploads/2017/03/blank-profile-picture-973460_1280-580x580.jpg" />

                <div class="file-field input-field">
                    <div class="btn">
                        <span>Agregar</span>
                        <input type="file" runat="server">
                    </div>
                    <div class="file-path-wrapper">
                        <asp:TextBox ID="txtImagen" runat="server" CssClass="file-path validate"></asp:TextBox>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <!--Telefono -->

    <div class="col s12">
        <div class="row">

            <div class="input-field col s6">
                <asp:TextBox ID="txtnombre" runat="server" CssClass="validate"></asp:TextBox>
                <label for="lblNombre">Nombre</label>
            </div>

            <div class="input-field col s6">
                <asp:TextBox ID="txtApellido" runat="server" CssClass="validate"></asp:TextBox>
                <label for="lblApellido">Apellido</label>
            </div>

        </div>
    </div>
    <!--Telefono -->
    <div class="col s12">
        <div class="row">

            <div class="input-field col s4">
                <asp:TextBox ID="txtTelefono" runat="server" CssClass="validate"></asp:TextBox>
                <label for="lblTelefono">Telefono</label>
            </div>

            <div class="input-field col s4">
                <asp:TextBox ID="txtDni" runat="server" CssClass="validate"></asp:TextBox>
                <label for="lblDniPac">Nº Documento</label>
            </div>
            <!--Email -->

            <div class="input-field col s4">
                <asp:TextBox ID="txtEmail" runat="server" CssClass="validate" TextMode="Email"></asp:TextBox>
                <label for="lblEmail">Correo Electronico</label>
            </div>

        </div>
    </div>
    <!-- ESTADO -->
    <div class="col s12">
        <div class="row">
           <div class="input-field col s4 left-align">
                <label for="lblGenero">Genero</label>
                <br />
                <br />
                <asp:DropDownList ID="ddlGenero" runat="server" CssClass="dropdown-trigger btn purple lighten-2" Style="margin-top: 10px;" href="#" data-activates="drpdEstado" data-target="drpdEstado">
                     <asp:ListItem Text="Masculino" />
                     <asp:ListItem Text="Femenino" />
                     <asp:ListItem Text="Otro" />
                    </asp:DropDownList>
            </div>
            
            <div class="input-field col s4 center-align">
                <label for="lblEstado">Estado</label>
                <br />
                <br />
                <div class="switch">
                    <label>
                        INACTIVO
                      <asp:CheckBox ID="chbEstado" runat="server" />
                        <span class="lever"></span>
                        ACTIVO
                    </label>
                </div>
            </div>
            <!--imagen-->

            <div class="input-field col s4 right-align">
                   <label for="lblFnac">Fecha de Nacimiento</label>
                 <br />
                <br />
                <asp:TextBox ID="txtFecha" runat="server" TextMode="Date"></asp:TextBox>
             
            </div>

        </div>
    </div>


    <div class="row">
        <div class="input-field col s12 center-align">
            <asp:Button CssClass="waves-effect waves-light btn-small" ID="btnAcept" runat="server" OnClick="btnAcept_Click" Text="Aceptar" />
        </div>
    </div>


</asp:Content>
