<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="TurnoWeb.aspx.cs" Inherits="TP_Final_Morales_Rangogni.TurnoWeb" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContentLogin" runat="server">
    <section>
        <div class="tab-bar">
            <a href="#NuevoTurno">NUEVO TURNO</a>
            <a href="#Turnos">TURNOS</a>
            <a href="#SOLAPA 3">SOLAPA 3</a>
            <a href="#SOLAPA 4">SOLAPA 4</a>

        </div>

        <!--SOLAPA NUEVO TURNO-->
        <div class="content">
            <br />
            <br />
            <div class="col s12">
                <div class="row">
                    <div class="file-field input-field col s12">
                        <div class="input-field col s6">
                            <asp:TextBox ID="txtDni" runat="server" CssClass="validate" placeholder=""></asp:TextBox>
                            <label for="lblDniPac">Nº Documento</label>
                        </div>
                        <div class="file-field input-field col s6 center-align">
                            <div class="waves-effect purple waves-light btn-floating btn-small">
                                <i class="material-icons">cached</i>
                                <asp:Button runat="server" ID="btnBuscarPaciente" CssClass="btn-small" OnClick="btnBuscarPaciente_Click" />
                            </div>
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

                    <div class="input-field col s6">
                        <asp:TextBox ID="txtTelefono" runat="server" CssClass="validate" placeholder=""></asp:TextBox>
                        <label for="lblTelefono">Telefono</label>
                    </div>

                    <!--Email -->
                    <div class="input-field col s6">
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
                        <asp:DropDownList ID="ddlEspecialidad" runat="server" CssClass="dropdown-trigger btn purple white-text" Style="margin-top: 5px" href="#" AutoPostBack="true" OnSelectedIndexChanged="ddlEspecialidad_SelectedIndexChanged" data-activates="ddlEpecialidad" data-target="ddlEspcialidad" />
                    </div>
                    <div class="col s4 left-align">
                        <label id="lblMedico" for="ddlMedico">Especialista</label>
                        <asp:DropDownList ID="ddlMedico" runat="server" CssClass="dropdown-trigger btn purple white-text" Style="margin-top: 5px" href="#" data-activates="ddlEpecialidad" data-target="ddlEspcialidad" />
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
                    <a class=" btn modal-trigger purple white-text" href="#modal1">Guardar</a>
                </div>
                <!-- Modal Structure -->

                <div id="modal1" class="modal">
                    <div class="modal-content">
                        <h4>Atencion</h4>
                        <p>¿Desea guardar el turno?</p>
                    </div>
                    <div class="modal-footer">

                        <asp:Button CssClass="modal-close btn-flat purple white-text" ID="btnAcept" runat="server" OnClick="btnAcept_Click" Text="Aceptar" />

                        <a href="#!" class="modal-close btn-flat purple white-text">Cancelar</a>
                    </div>
                </div>
            </div>
        </div>
        <!--SOLAPA LISTADO DE TURNOS-->
        <div class="content">
            <h2>TURNOS <span><i class="fas fa-carrot"></i></span></h2>
            <p>FALTA CARGAR EL LISTADO</p>

        </div>
        <!--SOLAPA LIBRE-->
        <div class="content">
            <h2>SOLAPA 3 <span><i class="fas fa-carrot"></i></span></h2>
            <p>COSAS DE LA VIDA</p>

        </div>
        <!--SOLAPA LIBRE-->
        <div class="content">
            <h2>SOLAPA 4 <span><i class="fas fa-carrot"></i></span></h2>
            <p>AGREGAR .</p>

        </div>


        <!--Fin Solapas-->
    </section>

    <script type="text/javascript" src="js/tabfunciones.js"></script>
</asp:Content>
