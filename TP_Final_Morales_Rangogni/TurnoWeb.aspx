<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="TurnoWeb.aspx.cs" Inherits="TP_Final_Morales_Rangogni.TurnoWeb" EnableEventValidation="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContentLogin" runat="server">
    <div>
        <asp:Menu runat="server" ID="mnTurnos" Orientation="Horizontal" OnMenuItemClick="mnTurnos_MenuItemClick" DynamicMenuItemStyle-CssClass="tab-bar" CssClass="tab-bar">
            <Items>
                <asp:MenuItem Text="Ver Turnos" Value="0" Selected="true"></asp:MenuItem>
                <asp:MenuItem Text="Nuevo Turno" Value="1"></asp:MenuItem>
            </Items>
        </asp:Menu>
    </div>
    <div class="content ">
        <asp:MultiView runat="server" ID="mvwTurnos" ActiveViewIndex="0">
            <!--SOLAPA LISTADO DE TURNOS-->
            <asp:View ID="View0" runat="server">
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
                                    <div class="col s1 right-align">
                                        <asp:LinkButton runat="server" ID="lbtnCargaGrd" OnClick="btnCargaGrd_Click" CssClass="btn-floating purple small"><i class="material-icons left-align">search</i></asp:LinkButton>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="body bg-gray">
                            <asp:GridView ID="dgvTurnos" CssClass="highlight responsive-table center-align" DataKeyNames="IdTurno" AutoGenerateColumns="false" runat="server" OnRowCommand="dgvTurnos_RowCommand">
                                <Columns>
                                    <asp:BoundField HeaderText="ID" DataField="IdTurno" />
                                    <asp:BoundField HeaderText="Paciente" DataField="NombrePaciente" />
                                    <asp:BoundField HeaderText="Medico" DataField="NombreMedico" />
                                    <asp:BoundField HeaderText="Situacion" DataField="Situacion" />
                                    <asp:BoundField HeaderText="Hora" DataField="Hora" />
                                    <asp:ButtonField HeaderText="Editar" ButtonType="Link" HeaderStyle-Width="110" CommandName="Editar" ControlStyle-CssClass="btn-floating purple" Text="<i class='material-icons'>border_color</i>" />
                                    <asp:ButtonField HeaderText="Reprogramar" ButtonType="Link" HeaderStyle-Width="120" CommandName="Reprogramar" ControlStyle-CssClass="btn-floating purple" Text="<i class='material-icons'>date_range</i>" />
                                    <asp:ButtonField HeaderText="Cancelar" ButtonType="Link" HeaderStyle-Width="20" CommandName="Cancelar" ControlStyle-CssClass="btn-floating purple" Text="<i class='material-icons'>cancel</i>" />
                                </Columns>
                            </asp:GridView>
                            <div class="row">
                                <div class="col s1 right-align">
                                    <asp:LinkButton runat="server" ID="lbtnCargarTurnos" OnClick="btnCargaGrd_Click" CssClass="btn-floating purple small"><i class="material-icons">cached</i></asp:LinkButton>
                                </div>
                            </div>
                        </div>
                        <!-- Modal para edicion -->
                        <asp:Button ID="btnModal" runat="server" CssClass="modal" Text="Modal" />
                        <asp:Panel ID="ModalPanel" runat="server" Width="700px" CssClass="content">
                            <div class="row">
                                <div class="col s11 center-align">
                                    <asp:Label runat="server" ForeColor="" Font-Bold="true" ID="lblAccion" Text="Modificacion de turno"></asp:Label>
                                </div>
                                <div class="col s1">
                                    <asp:TextBox CssClass="form-control" Enabled="false" Visible="false" ID="txtId" runat="server" placeholder="Id"></asp:TextBox>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col s8 left-align">
                                    <asp:Label runat="server" CssClass="flow-text purple-text" ForeColor="" Font-Bold="true" ID="LblnombrePaciente" Text="Paciente: "></asp:Label>
                                </div>
                                <div class="col s4">
                                    <asp:TextBox CssClass="form-control center-align" Enabled="false" ID="txtPaciente" runat="server" placeholder="Paciente"></asp:TextBox>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col s8 left-align">
                                    <asp:Label runat="server" CssClass="flow-text purple-text" ForeColor="" Font-Bold="true" ID="LblnombreMedico" Text="Medico: "></asp:Label>
                                </div>
                                <div class="col s4">
                                    <asp:TextBox CssClass="form-control center-align" Enabled="false" ID="txtMedico" runat="server" placeholder="Medico"></asp:TextBox>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col s8 left-align">
                                    <asp:Label runat="server" CssClass="flow-text purple-text" ForeColor="" Font-Bold="true" ID="lblDia" Text="Dia: "></asp:Label>
                                </div>
                                <div class="col s4">
                                    <asp:TextBox CssClass="form-control center-align" Enabled="false" ID="txtDia" runat="server" placeholder="Dia"></asp:TextBox>
                                </div>
                            </div>
                            <div class="row">
                                  <div class="col s8 left-align">
                                    <asp:Label runat="server" CssClass="flow-text purple-text" ForeColor="" Font-Bold="true" ID="Label1" Text="Hora: "></asp:Label>
                                </div>
                                <div class="col s4">
                                    <asp:TextBox CssClass="form-control center-align" Enabled="false" ID="txtHora" runat="server" placeholder="Hora"></asp:TextBox>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col s4">
                                    <asp:Label CssClass="form-control" Visible="true" Enabled="false" ID="lblIdSituacion" runat="server" placeholder=""></asp:Label>
                                </div>
                            </div>
                          <div class="row">
                              <div class="col s8 left-align">
                                    <asp:Label runat="server" CssClass="flow-text purple-text" ForeColor="" Font-Bold="true" ID="Label2" Text="Observaciones: "></asp:Label>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col s12">
                                    <asp:TextBox ID="txtObservacion" runat="server" CssClass="form-control"></asp:TextBox>
                                </div>
                            </div>
                            <div class="modal-footer">
                                <div class="row">
                                    <div class="col s12 right-align">
                                        <asp:LinkButton ID="lkbGraba" runat="server" OnClick="lkbGraba_Click" CssClass="btn-floating purple small"><i class="material-icons">save</i></asp:LinkButton>
                                        <asp:LinkButton ID="lbtnCancela" CssClass="btn-floating purple" runat="server"><i class="material-icons">cancel</i></asp:LinkButton>
                                    </div>
                                </div>
                            </div>
                        </asp:Panel>
                        <ajaxToolkit:ModalPopupExtender ID="mpe" runat="server" TargetControlID="btnModal" PopupControlID="ModalPanel" OkControlID="lbtnCancela" />
                    </ContentTemplate>
                </asp:UpdatePanel>
            </asp:View>

            <asp:View ID="View1" runat="server">
                <asp:UpdatePanel runat="server" UpdateMode="Conditional" ID="upNuevoTurno">
                    <ContentTemplate>
                        <!--SOLAPA NUEVO TURNO-->
                        <div class="row">
                            <div class="input-field left-align col s6">
                                <asp:TextBox ID="txtDni" runat="server" placeholder="Documento"></asp:TextBox>
                            </div>
                            <div class="col s1 right-align">
                                <asp:LinkButton runat="server" ID="lbtnBuscar" CssClass="btn-floating purple small" OnClick="btnBuscar_Click"><i class="material-icons">search</i></asp:LinkButton>
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
                                    <asp:TextBox ID="txtTelefono" runat="server" CssClass="validate" Enabled="false" placeholder="Telefono"></asp:TextBox>
                                </div>
                                <!--Email -->
                                <div class="input-field col s6">
                                    <asp:TextBox ID="txtEmail" runat="server" CssClass="validate" TextMode="Email" Enabled="false" placeholder="Correo Electronico"></asp:TextBox>
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
                                <div class="col s1 right-align">
                                    <asp:LinkButton runat="server" ID="lbtnVerTurnos" OnClick="btnVerTurnos_Click" CssClass="btn-floating purple small"><i class="material-icons left-align">search</i></asp:LinkButton>
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
