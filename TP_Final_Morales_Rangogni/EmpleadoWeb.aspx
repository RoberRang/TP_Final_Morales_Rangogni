<%@ Page Title="Empleado" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="EmpleadoWeb.aspx.cs" Inherits="TP_Final_Morales_Rangogni.EmpleadoWeb" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContentLogin" runat="server">
    <!--DESDE ACA-->
    <!---Solapas-->
    <section>
        <div class="tab-bar">
            <a href="#Empleados">EMPLEADOS</a>
            <a href="#NuevoEmpleado">NUEVO EMPLEADO</a>
            <a href="#solapa3">SOLAPA3</a>
            <a href="#solapa4">SOLAPA4</a>
        </div>

        <!---Solapa Empleados-->

        <div class="content">
            <div class="row">

                <asp:Label Text="Filtrar" runat="server" CssClass="active" />
                <asp:TextBox ID="txtfiltro" runat="server" CssClass="input-field" AutoPostBack="true" OnTextChanged="txtfiltro_TextChanged"></asp:TextBox>
            </div>
            <div class="col-md-5 right-align">
                <br />
                <asp:Button runat="server" ID="btnVerEmp" CssClass="btn btn-default" OnClick="btnVerEmp_Click" Text="Empleados &raquo;" />
                <br />
                <br />
                <asp:GridView ID="dgEmpleados" CssClass="highlight responsive-table" runat="server"
                    AutoGenerateColumns="false" DataKeyNames="Id"
                    OnSelectedIndexChanged="dgEmpleados_SelectedIndexChanged">
                    <Columns>
                        <asp:BoundField HeaderText="Nombre" DataField="Nombres" />
                        <asp:BoundField HeaderText="Apellido" DataField="Apellidos" />
                        <asp:BoundField HeaderText="Dni" DataField="NroDocumento" />
                        <asp:BoundField HeaderText="Perfil" DataField="idTipoPerfil" />
                        <asp:BoundField HeaderText="Estado" DataField="Estado" />

                        <asp:CommandField HeaderText="Editar" ShowSelectButton="true" SelectText="🔥" />

                    </Columns>
                </asp:GridView>
            </div>
        </div>



        <!--Solapa NUEVO EMPLEADO-->
        <div class="content">
             <br />
             <br />
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

                </div>
            </div>
            <!---MODAL GUARDAR--->

            <div class="row">
                <!-- Modal Trigger -->
                <div class="center-align">
                    <a class=" btn modal-trigger" href="#modal1">Guardar</a>
                </div>
                <div id="modal1" class="modal">
                    <div class="modal-content">
                        <h4>Atencion</h4>
                        <p>¿Desea guardar el paciente?</p>
                    </div>
                    <div class="modal-footer">

                        <asp:Button CssClass="waves-effect waves-light btn-small" ID="btnAceptar" OnClick="btnAceptar_Click" runat="server" Text="Aceptar" />

                        <a href="#!" class="modal-close btn-flat">Cancelar</a>
                    </div>
                </div>
            </div>

            <!---Fin MODAL Guardar-->

        </div>
        <!--SOLAPA GENERICA-->
        <div class="content">
            <h2>LISTA TURNOS Y EDITA <span><i class="fas fa-carrot"></i></span></h2>
            <p>Listar turnos(pacientes)/ botons de editar/ .</p>

        </div>
        <!--Fin Solapas-->
    </section>

    <script type="text/javascript" src="js/tabfunciones.js"></script>

    <!--HASTA ACA-->
</asp:Content>
