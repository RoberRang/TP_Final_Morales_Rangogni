<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="PacienteWeb.aspx.cs" Inherits="TP_Final_Morales_Rangogni.PacienteWeb" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContentLogin" runat="server">
    <!---ACA-->
    <section>
        <div class="tab-bar">
            <a href="#Pacientes">PACIENTES</a>
            <a href="#NuevoPaciente">NUEVO PACIENTE</a>
            <a href="#Turnos">TURNOS</a>
            <a href="#NuevoTurno">NUEVO TURNO</a>

        </div>


        <!---solapa pacientes-->
        <div class="content">
            <div class="row">
             
                        <asp:Label Text="Filtrar" runat="server" CssClass="active"/>
                        <asp:TextBox ID="txtfiltro" runat="server" CssClass="input-field" AutoPostBack="true" OnTextChanged="filtro_TextChanged"></asp:TextBox>
                    </div>

            
            <div class="col-md-5 right-align">
                <br />
                <asp:Button runat="server" ID="btnVerPac" CssClass="btn btn-default" OnClick="btnVerPac_Click" Text="Ver todos &raquo;" />
                <br />
                <br />

                <asp:GridView ID="dgvPacientes" CssClass="highlight responsive-table"
                    runat="server" AutoGenerateColumns="false" DataKeyNames="IdPaciente"
                    OnSelectedIndexChanged="dgvPacientes_SelectedIndexChanged"
                    >
                    <Columns>
                        <asp:BoundField HeaderText="Nombre" DataField="Nombres" />
                        <asp:BoundField HeaderText="Apellido" DataField="Apellidos" />
                        <asp:BoundField HeaderText="Dni" DataField="NroDocumento" />
                        <asp:BoundField HeaderText="Telefono" DataField="Telefono" />
                        <asp:BoundField HeaderText="Email" DataField="Email" />
                        <asp:CommandField HeaderText="Editar" ShowSelectButton="true" SelectText="🔥" />
                            
                    </Columns>



                </asp:GridView>
                




            </div>

        </div>
        <!---hasta aca-->
        <!--ACA SOLAPA NUEVO PACIENTE-->
        <div class="content">
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
                        <div class="waves-effect waves-light btn-small">
                            <i class="material-icons">camera_enhance</i>
                            <input type="file">
                        </div>

                        <div class="file-path-wrapper col s4">
                            <asp:TextBox ID="txtImagen" runat="server" CssClass="file-path validate"></asp:TextBox>
                        </div>

                    </div>
                </div>
            </div>

            <!--Telefono -->

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
                        <asp:DropDownList ID="ddlGenero" runat="server" CssClass="dropdown-trigger btn purple lighten-2" Style="margin-top: 10px" href="#" data-activates="drpdEstado" data-target="drpdEstado">
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
                      <asp:CheckBox ID="chbEstado" runat="server" Checked="true" />
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
                        <asp:TextBox ID="txtFecha" runat="server" TextMode="Date" placeholder=""></asp:TextBox>

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
            <!---hasta aca MODAL-->
           </div>
            <div class="content">
                <h2>LISTA TURNOS Y EDITA <span><i class="fas fa-carrot"></i></span></h2>
                <p>Listar turnos(pacientes)/ botons de editar/ .</p>

            </div>
    </section>

    <script type="text/javascript" src="js/tabfunciones.js"></script>



</asp:Content>
