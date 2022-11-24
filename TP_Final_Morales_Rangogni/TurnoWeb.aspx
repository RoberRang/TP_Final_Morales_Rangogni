<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="TurnoWeb.aspx.cs" Inherits="TP_Final_Morales_Rangogni.TurnoWeb" EnableEventValidation="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContentLogin" runat="server">
    <div>
        <asp:Menu runat="server" ID="mnTurnos" Orientation="Horizontal" OnMenuItemClick="mnTurnos_MenuItemClick" CssClass="tab-bar">
            <Items>
                <asp:MenuItem Text="Nuevo Turno" Value="0" Selected="true"></asp:MenuItem>
                <asp:MenuItem Text="Ver Turnos" Value="1"></asp:MenuItem>
                <asp:MenuItem Text="Editar Turnos" Value="2"></asp:MenuItem>
            </Items>
        </asp:Menu>
    </div>
    <div class="content ">
        <asp:MultiView runat="server" ID="mvwTurnos" ActiveViewIndex="0">
            <asp:View ID="View0" runat="server">
                <asp:UpdatePanel runat="server" UpdateMode="Conditional" ID="upNuevoTurno">
                    <ContentTemplate>
                        <!--SOLAPA NUEVO TURNO-->
                        <div class="row">
                            <div class="input-field left-align col s6">
                                <asp:TextBox ID="txtDni" runat="server" placeholder="Documento"></asp:TextBox>
                            </div>
                            <div class="col s1 waves-effect purple waves-light btn-small">
                                <i class="material-icons">cached</i>
                                <asp:Button runat="server" ID="btnBuscar" CssClass="col s1 center-block btn-large purple" OnClick="btnBuscar_Click" />
                            </div>
                        </div>
                        <!--Nombre -->
                        <div class="col s12">
                            <div class="row">
                                <div class="input-field col s6">
                                    <asp:TextBox ID="txtnombre" runat="server" Enabled="false" placeholder="Nombre"></asp:TextBox>
                                </div>
                                <!--Apellido -->
                                <div class="input-field col s6">
                                    <asp:TextBox ID="txtApellido" runat="server" Enabled="false" placeholder="Apellido"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <!--Telefono -->
                        <div class="col s12">
                            <div class="row">
                                <div class="input-field col s6">
                                    <asp:TextBox ID="txtTelefono" runat="server" CssClass="validate" placeholder="Telefono"></asp:TextBox>
                                </div>
                                <!--Email -->
                                <div class="input-field col s6">
                                    <asp:TextBox ID="txtEmail" runat="server" CssClass="validate" TextMode="Email" placeholder="Correo Electronico"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <div class="col s12">
                            <div class="row">
                                <div class="col s4 left-align">
                                    <label id="lblEspecialidad" for="ddlEspecialidad">Especialidad</label>
                                    <asp:DropDownList ID="ddlEspecialidad" runat="server" CssClass="dropdown-trigger btn purple white-text" Style="margin-top: 5px" AutoPostBack="true" OnSelectedIndexChanged="ddlEspecialidad_SelectedIndexChanged" data-activates="ddlEpecialidad" data-target="ddlMedico" />
                                </div>
                                <div class="col s4 left-align">
                                    <label id="lblMedico" for="ddlMedico">Especialista</label>
                                    <asp:DropDownList ID="ddlMedico" runat="server" CssClass="dropdown-trigger btn purple white-text" AutoPostBack="true" OnSelectedIndexChanged="ddlMedico_SelectedIndexChanged" Style="margin-top: 5px" data-activates="ddlMedico" data-target="ddlTurnos" />
                                </div>
                                <div class="input-field col s3 left-align">
                                    <asp:TextBox ID="txtFechaTurno" runat="server" AutoPostBack="true" CssClass="purple white-text center-align" TextMode="Date" Style="margin-top: 5px" placeholder="Fecha para el turno"></asp:TextBox>
                                </div>
                                <div class="col s1 waves-effect small waves-light btn-small purple">
                                    <i class="material-icons left-align">search</i>
                                    <asp:Button runat="server" ID="btnVerTurnos" OnClick="btnVerTurnos_Click" CssClass="col s1 right-align btn-large purple" />
                                </div>
                            </div>
                        </div>
                        <div class="col s12">
                            <div class="row">
                                <div class="input-field col s1">
                                    <asp:TextBox ID="txtCantTurnos" Enabled="false" runat="server" CssClass="validate" placeholder="Disp."></asp:TextBox>
                                </div>
                                <div class="col s2 left-align">
                                    <label id="lblTurno" for="ddlHorasTurnos">Hora</label>
                                    <asp:DropDownList ID="ddlHorasTurnos" runat="server" CssClass="dropdown-trigger btn purple white-text" data-activates="ddlHorasTurnos" />
                                </div>
                                <div class="input-field col s9">
                                    <asp:TextBox ID="txtObservaciones" runat="server" CssClass="validate" placeholder="Observaciones"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <!---MODAL--->
                        <div class="row">
                            <!-- Modal Trigger -->
                            <div class="center-align">
                                <a class=" btn modal-trigger purple white-text" href="#modal1">Guardar</a>
                            </div>
                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </asp:View>

            <!--SOLAPA LISTADO DE TURNOS-->
            <asp:View ID="View1" runat="server">
                <asp:UpdatePanel runat="server" ID="udpGrillaTurnos" UpdateMode="Conditional">
                    <ContentTemplate>
                        <h6>FILTROS <span><i class="fas fa-carrot"></i></span></h6>
                        <div class="row">
                            <div class="col s12">
                                <div class="row">
                                    <div class="input-field col s3 left-align">
                                        <asp:TextBox ID="txtFechaGrd" runat="server" AutoPostBack="true" CssClass="dropdown-trigger purple white-text center-align" TextMode="Date" Style="margin-top: 5px" placeholder="Fecha de Turno"></asp:TextBox>
                                    </div>
                                    <div class="col s4 left-align">
                                        <asp:Label runat="server" ID="lblPacienteGrd" AssociatedControlID="txtfiltroPaciente">Paciente</asp:Label>
                                        <asp:TextBox ID="txtfiltroPaciente" runat="server" CssClass="input-field" AutoPostBack="true"></asp:TextBox>
                                    </div>
                                    <div class="col s4 left-align">
                                        <asp:Label runat="server" ID="lblMedGrd" AssociatedControlID="txtFiltroMedico">Medico</asp:Label>
                                        <asp:TextBox ID="txtFiltroMedico" runat="server" CssClass="input-field" AutoPostBack="true"></asp:TextBox>
                                    </div>
                                    <div class="col s1 waves-effect small waves-light btn-small purple">
                                        <i class="material-icons left-align">search</i>
                                        <asp:Button runat="server" ID="btnCargaGrd" OnClick="btnCargaGrd_Click" CssClass="col s1 right-align btn-large purple" />
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="body bg-gray">
                            <asp:GridView ID="dgvTurnos" CssClass="highlight responsive-table" DataKeyNames="IdTurno" AutoGenerateColumns="false" runat="server" OnSelectedIndexChanged="dgvTurnos_SelectedIndexChanged">
                                <Columns>
                                    <asp:BoundField HeaderText="Paciente" DataField="NombrePaciente" />
                                    <asp:BoundField HeaderText="Medico" DataField="NombreMedico" />
                                    <asp:BoundField HeaderText="Situacion" DataField="Situacion" />
                                    <asp:BoundField HeaderText="Hora" DataField="Hora" />
                                    <asp:CommandField HeaderText="Editar" ShowSelectButton="true" SelectText="#" />
                                </Columns>
                            </asp:GridView>
                            <div class="row">
                                <div class="waves-effect purple waves-light btn-floating btn-small">
                                    <i class="material-icons">cached</i>
                                    <asp:Button runat="server" ID="btnCargarTurnos" CssClass="col s1 right-align btn-large purple" Text="Perfiles &raquo;" />
                                </div>
                            </div>
                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </asp:View>
            <asp:View ID="View2" runat="server">
                <asp:UpdatePanel runat="server" UpdateMode="Conditional" ID="UpdatePanel1">
                    <ContentTemplate>
                        <div class="input-field col s9">
                            <asp:TextBox ID="txtDetalleTurno" runat="server" CssClass="validate" placeholder="Detalle"></asp:TextBox>
                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </asp:View>
        </asp:MultiView>

        <!--Fin Solapas-->
        <!-- Modal Structure -->
        <div id="modal1" class="modal">
            <div class="modal-content">
                <h4>Detalle Turno</h4>
                <p>¿Desea guardar el turno?</p>
            </div>
            <div class="modal-footer">
                <asp:Button CssClass="modal-close btn-flat purple white-text" ID="btnAcept" runat="server" OnClick="btnAcept_Click" Text="Aceptar" />
                <a href="#!" class="modal-close btn-flat purple white-text">Cancelar</a>
            </div>
        </div>
    </div>
    <script type="text/javascript" src="js/tabfunciones.js"></script>
</asp:Content>
