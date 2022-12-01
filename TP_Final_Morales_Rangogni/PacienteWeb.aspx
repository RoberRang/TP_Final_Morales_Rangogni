<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="PacienteWeb.aspx.cs" Inherits="TP_Final_Morales_Rangogni.PacienteWeb" EnableEventValidation="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContentLogin" runat="server">

    <!---Solapas-->
    <div>
        <asp:Menu runat="server" ID="mnPacientes" Orientation="Horizontal" OnMenuItemClick="mnPaciente_MenuItemClick" CssClass="tab-bar a">
            <Items>
                <asp:MenuItem Text="Ver Pacientes" Value="0" Selected="true"></asp:MenuItem>
                <asp:MenuItem Text="Nuevo Paciente" Value="1"></asp:MenuItem>
                <asp:MenuItem Text="Editar Paciente" Value="2"></asp:MenuItem>
            </Items>
        </asp:Menu>
    </div>

    <!---Solapa Pacientes-->
    <div class="content ">
        <asp:MultiView runat="server" ID="mvwPacientes" ActiveViewIndex="0">
            <asp:View ID="vwPaciente" runat="server">
                <asp:UpdatePanel runat="server" UpdateMode="Conditional" ID="upVerPacientes">
                    <ContentTemplate>
                        <div class="col s12">
                            <div class="row">
                                <div class="col s4">
                                    <asp:TextBox ID="txtfiltro" runat="server" CssClass="input-field" AutoPostBack="true" OnTextChanged="filtro_TextChanged" placeholder="Filtre por nombre de paciente "></asp:TextBox>
                                </div>
                                <div class="col s4">
                                    <asp:TextBox ID="txtFiltroApellido" runat="server" CssClass="input-field" AutoPostBack="true" OnTextChanged="txtFiltroApellido_TextChanged" placeholder="Filtre por Apellido de paciente "></asp:TextBox>
                                </div>
                                <div class="col s4">
                                    <asp:TextBox ID="txtFiltroDni" runat="server" CssClass="input-field" AutoPostBack="true" OnTextChanged="txtFiltroDni_TextChanged" placeholder="Filtre por Dni de paciente "></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <div class="row left-align ">
                            <asp:Button CssClass="modal-close btn-flat purple white-text" ID="btnLimpiarFiltro" runat="server" OnClick="btnLimpiarFiltro_Click" Text="Limpiar Filtros" />

                        </div>

                        <asp:GridView ID="dgvPacientes" CssClass="highlight responsive-table"
                            runat="server" AutoGenerateColumns="false" DataKeyNames="IdPaciente"
                            OnSelectedIndexChanged="dgvPacientes_SelectedIndexChanged">
                            <Columns>
                                <asp:BoundField HeaderText="Nombre" DataField="Nombres" />
                                <asp:BoundField HeaderText="Apellido" DataField="Apellidos" />
                                <asp:BoundField HeaderText="Dni" DataField="NroDocumento" />
                                <asp:BoundField HeaderText="Telefono" DataField="Telefono" />
                                <asp:BoundField HeaderText="Email" DataField="Email" />
                                <asp:CommandField HeaderText="Editar" ShowSelectButton="true" SelectText="📝" />
                            </Columns>
                        </asp:GridView>
                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </asp:View>
            <!--Solapa NUEVO PACIENTE-->
            <asp:View ID="View1" runat="server">
                <asp:UpdatePanel runat="server" ID="udpNuevoPaciente" UpdateMode="Conditional">
                    <ContentTemplate>
                        <br />
                        <br />
                        <!--imagen-->
                        <div class="center-align responsive-img">
                            <asp:Image ID="imgPaciente" runat="server" CssClass="circle responsive-img" Width="100" src="https://objetivoligar.com/wp-content/uploads/2017/03/blank-profile-picture-973460_1280-580x580.jpg" />
                        </div>
                        <div class="col s12">
                            <div class="row">
                                <div class="col s5">
                                </div>
                                <div class="file-field input-field col s4 center-align">
                                    <div class="waves-effect purple waves-light btn-small">
                                        <i class="material-icons">camera_enhance</i>
                                        <input type="file">
                                    </div>
                                    <div class="file-path-wrapper col s4">
                                        <asp:TextBox ID="txtImagen" runat="server" CssClass="file-path validate"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <!--Nombre y Apellido -->
                        <div class="col s12">
                            <div class="row">
                                <div class="input-field col s6">
                                    <asp:TextBox ID="txtnombre" runat="server" CssClass="validate" placeholder=""></asp:TextBox>
                                    <label for="lblNombre">Nombre</label>
                                </div>
                                <div class="input-field col s6">
                                    <asp:TextBox ID="txtApellido" runat="server" CssClass="validate" placeholder=""></asp:TextBox>
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
                                <div class="input-field col s4">
                                    <asp:TextBox ID="txtDni" runat="server" CssClass="validate" placeholder=""></asp:TextBox>
                                    <label for="lblDniPac">Nº Documento</label>
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
                                <div class="input-field col s4 left-align">
                                    <label for="lblGenero">Genero</label>
                                    <br />
                                    <br />
                                    <asp:DropDownList ID="ddlGenero" runat="server" CssClass="dropdown-trigger btn purple waves-light" Style="margin-top: 10px" href="#" data-activates="drpdEstado" data-target="drpdEstado">
                                        <asp:ListItem Text="Masculino" />
                                        <asp:ListItem Text="Femenino" />
                                        <asp:ListItem Text="Otro" />
                                    </asp:DropDownList>
                                </div>
                                <div class="input-field col s4 left-align">
                                    <label for="lblEstado">Estado</label>
                                    <br />
                                    <br />
                                    <asp:DropDownList ID="ddlEstado" runat="server" CssClass="dropdown-trigger btn purple waves-light" Style="margin-top: 10px" href="#" data-activates="ddldEstado" data-target="ddlEstado">
                                        <asp:ListItem Text="Activo" />
                                        <asp:ListItem Text="Inactivo" />
                                    </asp:DropDownList>
                                </div>
                                <!--Fecha Nacimiento-->
                                <div class="input-field col s4 right-align">
                                    <label for="lblFnac">Fecha de Nacimiento</label>
                                    <br />
                                    <br />
                                    <asp:TextBox ID="txtFecha" runat="server" CssClass="purple white-text center-align" TextMode="Datetime" placeholder=""></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <!---MODAL GUARDAR--->
                        <div class="row">
                            <!-- Modal Trigger -->
                            <div class="center-align">
                                <a class=" btn modal-trigger purple" href="#modal1">Guardar</a>
                                <a class=" btn modal-trigger purple" runat="server" href="~/PacienteWeb">Cancelar</a>
                            </div>
                            <div id="modal1" class="modal">
                                <div class="modal-content">
                                    <h4>Atencion</h4>
                                    <p>¿Desea guardar el paciente?</p>
                                </div>
                                <div class="modal-footer">

                                    <asp:Button CssClass="modal-close btn-flat purple white-text" ID="btnAcept" runat="server" OnClick="btnAcept_Click" Text="Aceptar" />

                                    <a href="#!" class="modal-close purple white-text btn-flat">Cancelar</a>
                                </div>
                            </div>
                        </div>
                        <!---Fin MODAL Guardar-->
                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </asp:View>
            <!---EDITAR PACIENTE-->
            <asp:View ID="View2" runat="server">
                <br />
                <br />
                <!--imagen-->
                <asp:TextBox ID="IdPaciente" runat="server" Visible="false"></asp:TextBox>
                <div class="center-align responsive-img">
                    <asp:Image ID="imgEdPaciente" runat="server" CssClass="circle responsive-img" Width="100" src="https://objetivoligar.com/wp-content/uploads/2017/03/blank-profile-picture-973460_1280-580x580.jpg" />
                </div>
                <div class="col s12">
                    <div class="row">
                        <div class="col s5">
                        </div>
                        <div class="file-field input-field col s4 center-align">
                            <div class="waves-effect purple waves-light btn-small">
                                <i class="material-icons">camera_enhance</i>
                                <input type="file">
                            </div>
                            <div class="file-path-wrapper col s4">
                                <asp:TextBox ID="txtEdImagen" runat="server" CssClass="file-path validate"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                </div>
                <!--Nombre y Apellido -->

                <div class="col s12">
                    <div class="row">
                        <div class="input-field col s6">
                            <asp:TextBox ID="txtEdNombre" runat="server" CssClass="validate" placeholder=""></asp:TextBox>
                            <label for="lblEdNombre">Nombre</label>
                        </div>
                        <div class="input-field col s6">
                            <asp:TextBox ID="txtEdApellido" runat="server" CssClass="validate" placeholder=""></asp:TextBox>
                            <label for="lblEdApellido">Apellido</label>
                        </div>
                    </div>
                </div>
                <!--Telefono -->
                <div class="col s12">
                    <div class="row">
                        <div class="input-field col s4">
                            <asp:TextBox ID="txtEdtelefono" runat="server" CssClass="validate" placeholder=""></asp:TextBox>
                            <label for="lblEdTelefono">Telefono</label>
                        </div>
                        <div class="input-field col s4">
                            <asp:TextBox ID="txtEdDni" runat="server" CssClass="validate" placeholder=""></asp:TextBox>
                            <label for="lblEdDniPac">Nº Documento</label>
                        </div>
                        <!--Email -->
                        <div class="input-field col s4">
                            <asp:TextBox ID="txtEdEmail" runat="server" CssClass="validate" TextMode="Email" placeholder=""></asp:TextBox>
                            <label for="lblEdEmail">Correo Electronico</label>
                        </div>
                    </div>
                </div>
                <!-- ESTADO -->
                <div class="col s12">
                    <div class="row">
                        <div class="input-field col s4 left-align">
                            <label for="lblEdGenero">Genero</label>
                            <br />
                            <br />
                            <asp:DropDownList ID="ddlEdGenero" runat="server" CssClass="dropdown-trigger btn purple waves-light" Style="margin-top: 10px" href="#" data-activates="drpdGenero" data-target="drpdGenero">
                                <asp:ListItem Text="Masculino" />
                                <asp:ListItem Text="Femenino" />
                                <asp:ListItem Text="Otro" />
                            </asp:DropDownList>
                        </div>
                        <!--EDITAR ESTADO--->
                        <div class="input-field col s4 left-align">
                            <label for="lblEdEstado">Estado</label>
                            <br />
                            <br />
                            <asp:DropDownList ID="ddlEdEstado" runat="server" CssClass="dropdown-trigger btn purple waves-light" Style="margin-top: 10px" href="#" data-activates="drpdEstado" data-target="drpdEstado">
                                <asp:ListItem Text="Activo" />
                                <asp:ListItem Text="Inactivo" />
                            </asp:DropDownList>
                        </div>
                        <!--FIN-->
                        <!--Fecha Nacimiento-->
                        <div class="input-field col s4 right-align">
                            <label for="lblEdFnac">Fecha de Nacimiento</label>
                            <br />
                            <br />
                            <asp:TextBox ID="txtEdFnac" runat="server" CssClass="purple white-text center-align" TextMode="Datetime" placeholder=""></asp:TextBox>

                        </div>

                    </div>
                </div>
                <!---MODAL GUARDAR--->


                <div class="row">
                    <!-- Modal Trigger -->
                    <div class="center-align">
                        <a class=" btn modal-trigger purple" href="#modal2">Guardar</a>
                        <a class=" btn modal-trigger purple" runat="server" href="~/PacienteWeb">Cancelar</a>
                    </div>
                    <div id="modal2" class="modal">
                        <div class="modal-content">
                            <h4>Atencion</h4>
                            <p>¿Desea guardar los cambios?</p>
                        </div>
                        <div class="modal-footer">

                            <asp:Button CssClass="modal-close btn-flat purple white-text" ID="btnEditar" runat="server" OnClick="btnAcept_Click" Text="Aceptar" />

                            <a href="#!" class="modal-close purple white-text btn-flat">Cancelar</a>
                        </div>
                    </div>
                </div>

                <!---Fin MODAL Guardar-->



            </asp:View>
        </asp:MultiView>
    </div>



    <script type="text/javascript" src="js/tabfunciones.js"></script>
</asp:Content>
