<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="TurnoWeb.aspx.cs" Inherits="TP_Final_Morales_Rangogni.TurnoWeb" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContentLogin" runat="server">

    <div class="col s12">
        <div class="row">
            <div class="col s2">
            </div>
            <div class="file-field input-field col s10 center-align">
                <div class="input-field col s8">
                    <h3>Alta Turno Paciente</h3>
                </div>
            </div>
        </div>
    </div>
    <div class="col s12">
        <div class="row">
            <div class="file-field input-field col s6 center-align">
                <div class="input-field col s6">
                    <asp:TextBox ID="txtDni" runat="server" CssClass="validate" placeholder=""></asp:TextBox>
                    <label for="lblDniPac">Nº Documento</label>
                </div>
                <div class="waves-effect purple waves-light btn-small">
                    <i class="material-icons">cached</i>
                    <asp:Button runat="server" ID="btnBuscarPaciente" OnClick="btnBuscarPaciente_Click" />
                </div>
            </div>
        </div>
    </div>

    <!--Telefono -->

    <div class="col s12">
        <div class="row">

            <div class="input-field col s6">
                <asp:TextBox ID="txtnombre" runat="server" CssClass="validate" Enabled="false" placeholder=""></asp:TextBox>
                <label for="lblNombre">Nombre</label>
            </div>

            <div class="input-field col s6">
                <asp:TextBox ID="txtApellido" runat="server" CssClass="validate" Enabled="false" placeholder=""></asp:TextBox>
                <label for="lblApellido">Apellido</label>
            </div>

        </div>
    </div>
    <!--Telefono -->
    <div class="col s12">
        <div class="row">

            <div class="input-field col s4">
                <asp:TextBox ID="txtTelefono" runat="server" CssClass="validate" placeholder=""></asp:TextBox>
                <label for="lblTelefono">Telefono</label>
            </div>

            <!--Email -->
            <div class="input-field col s4">
                <asp:TextBox ID="txtEmail" runat="server" CssClass="validate" TextMode="Email" placeholder=""></asp:TextBox>
                <label for="lblEmail">Correo Electronico</label>
            </div>

        </div>
    </div>
    <!-- ESTADO -->
    <div class="col s12">
        <div class="row">
            <div class="col s4 left-align">
                <label id="lblEspecialidad" for="ddlEspecialidad">Especialidad</label>
                <asp:DropDownList ID="ddlEspecialidad" runat="server" CssClass="dropdown-trigger btn purple lighten-2" Style="margin-top: 5px" href="#" OnTextChanged="ddlEspecialidad_TextChanged" OnSelectedIndexChanged="ddlEspecialidad_SelectedIndexChanged" data-activates="ddlEpecialidad" data-target="ddlEspcialidad" />
            </div>
            <div class="col s4 left-align">
                <label id="lblMedico" for="ddlMedico">Especialista</label>
                <asp:DropDownList ID="ddlMedico" runat="server" CssClass="dropdown-trigger btn purple lighten-2" Style="margin-top: 5px" href="#" data-activates="ddlEpecialidad" data-target="ddlEspcialidad" />
            </div>
            <div class="input-field col s4 right-align">
                <label id="lblFecTurno" for="txtFechaTurno">Fecha del Turno</label>
                <asp:TextBox ID="txtFechaTurno" runat="server" TextMode="Date" placeholder=""></asp:TextBox>
            </div>

        </div>
    </div>
    <div class="col s12">
        <div class="row">

            <div class="input-field col s12">
                <asp:TextBox ID="txtObservaciones" runat="server" CssClass="validate" placeholder=""></asp:TextBox>
                <label for="lblObservaciones">Observaciones</label>
            </div>
        </div>
    </div>
    <!---MODAL--->

    <div class="row">
        <!-- Modal Trigger -->
        <div class="center-align">
            <a class=" btn modal-trigger" href="#modal1">Guardar</a>
        </div>
        <!-- Modal Structure -->

        <div id="modal1" class="modal">
            <div class="modal-content">
                <h4>Atencion</h4>
                <p>¿Desea guardar el paciente?</p>
            </div>
            <div class="modal-footer">

                <asp:Button CssClass="modal-close btn-flat" ID="btnAcept" runat="server" OnClick="btnAcept_Click" Text="Aceptar" />

                <a href="#!" class="modal-close btn-flat">Cancelar</a>
            </div>
        </div>
    </div>
</asp:Content>
