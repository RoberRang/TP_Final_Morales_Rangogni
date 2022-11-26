<%@ Page Title="Empleado" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="EmpleadoWeb.aspx.cs" Inherits="TP_Final_Morales_Rangogni.EmpleadoWeb" EnableEventValidation="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContentLogin" runat="server">
    <!--DESDE ACA-->
    <!---Solapas-->
    <div>
        <asp:Menu runat="server" ID="mnvEmpleados" Orientation="Horizontal" OnMenuItemClick="mnEmpleados_MenuItemClick" CssClass="tab-bar a">
            <Items>
                <asp:MenuItem Text="Ver Empleados" Value="0" Selected="true"></asp:MenuItem>
                <asp:MenuItem Text="Nuevo Empleado" Value="1"></asp:MenuItem>
                <asp:MenuItem Text="Editar Empleado" Value="2"></asp:MenuItem>
            </Items>
        </asp:Menu>
    </div>
    <!---Solapa Ver Empleados-->
    <div class="content ">
        <asp:MultiView runat="server" ID="mvwEmpleados" ActiveViewIndex="0">
            <asp:View ID="View0" runat="server">
                <asp:UpdatePanel runat="server" UpdateMode="Conditional" ID="upVerEmpleados">
                    <ContentTemplate>
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
                                    <asp:BoundField HeaderText="Perfil" DataField="idPerfil" />
                                    <asp:BoundField HeaderText="Estado" DataField="Estado" />
                                    <asp:CommandField HeaderText="Editar" ShowSelectButton="true" SelectText="🔥" />
                                </Columns>
                            </asp:GridView>
                        </div>
                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </asp:View>

            <!--Solapa NUEVO EMPLEADO-->
            <asp:View ID="View1" runat="server">
                <asp:UpdatePanel runat="server" ID="UpdatePanel1" UpdateMode="Conditional">

                    <ContentTemplate>
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
                                    <label for="lblPerfil">Pefil</label>
                                    <br />
                                    <br />
                                    <asp:DropDownList ID="ddlPerfilEmp" runat="server" CssClass="dropdown-trigger btn purple lighten-2" Style="margin-top: 10px;" href="#" data-activates="drpdEstado" data-target="drpdEstado">
                                    </asp:DropDownList>
                                </div>
                                <div class="input-field col s4 left-align">
                                    <label for="lblJornada">Jornada</label>
                                    <br />
                                    <br />
                                    <asp:DropDownList ID="ddlJornada" runat="server" CssClass="dropdown-trigger btn purple lighten-2" Style="margin-top: 10px;">
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
                                <a class=" purple white-text btn modal-trigger" href="#modal1">Guardar</a>
                            </div>
                            <div id="modal1" class="modal">
                                <div class="modal-content">
                                    <h4>Atencion</h4>
                                    <p>¿Desea guardar el empleado?</p>
                                </div>
                                <div class="modal-footer">

                                    <asp:Button CssClass="purple white-text btn-small" ID="btnAceptar" OnClick="btnAceptar_Click" runat="server" Text="Aceptar" />

                                    <a href="#!" class="purple white-text modal-close btn-flat">Cancelar</a>
                                </div>
                            </div>
                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>

            </asp:View>
            <!--Solapa EDITAR EMPLEADO-->
            <asp:View ID="View2" runat="server">
                <asp:UpdatePanel runat="server" ID="UpdEditarEmpleado" UpdateMode="Conditional">

                    <ContentTemplate>
                        <br />
                        <br />
                        <div class="row">
                            <div class="col s12">
                                <div class="row">
                                    <div class="input-field col s4">
                                        <asp:TextBox ID="txtEdNombre" runat="server" CssClass="validate" placeholder=""></asp:TextBox>
                                        <label for="lblEdNombre">Nombre</label>
                                    </div>
                                    <div class="input-field col s4">
                                        <asp:TextBox ID="txtEdApellido" runat="server" CssClass="validate" placeholder=""></asp:TextBox>
                                        <label for="lblEdApellido">Apellido</label>
                                    </div>
                                    <div class="input-field col s4">
                                        <asp:TextBox ID="txtEdDni" runat="server" CssClass="validate" placeholder=""></asp:TextBox>
                                        <label for="lblEdDniEmp">Nº Documento</label>
                                    </div>
                                </div>
                            </div>
                            <!--Usuario -->
                            <div class="row">
                                <div class="input-field col s4">
                                    <asp:TextBox ID="txtEdUsuario" runat="server" CssClass="validate" placeholder=""></asp:TextBox>
                                    <label for="lblEdUser">Usuario</label>
                                </div>
                                <!--Contraseña -->
                                <div class="input-field col s4">
                                    <asp:TextBox ID="txtEdPass" runat="server" CssClass="validate" TextMode="Password" placeholder=""></asp:TextBox>
                                    <label for="lblEdPass">Contraseña</label>
                                </div>
                                <div class="input-field col s4">
                                    <asp:TextBox ID="txtEdPass2" runat="server" CssClass="validate" TextMode="Password" placeholder=""></asp:TextBox>
                                    <label for="lblEdPass2">Repetir Contraseña</label>
                                </div>
                            </div>
                            <!--DDL Y ESTADO -->
                            <div class="row">

                                <div class="input-field col s4 left-align">
                                    <label for="lblEdPerfil">Pefil</label>
                                    <br />
                                    <br />
                                    <asp:DropDownList ID="ddlEdPerfil" runat="server" CssClass="dropdown-trigger btn purple lighten-2" Style="margin-top: 10px;" href="#" data-activates="drpdEstado" data-target="drpdEstado">
                                    </asp:DropDownList>
                                </div>
                                <div class="input-field col s4 left-align">
                                    <label for="lblEdJornada">Jornada</label>
                                    <br />
                                    <br />
                                    <asp:DropDownList ID="ddlEdJornada" runat="server" CssClass="dropdown-trigger btn purple lighten-2" Style="margin-top: 10px;">
                                    </asp:DropDownList>
                                </div>
                                <div>
                                    <div class="input-field col s4 center-align">
                                    </div>
                                    <div class="input-field col s4 right-align">
                                        <label for="lblEdEstado">Estado</label>
                                        <br />
                                        <br />
                                        <div class="switch">
                                            <label>
                                                INACTIVO
                            <asp:CheckBox ID="chbEdEstado" runat="server" Checked="true" />

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
                                <a class=" purple white-text btn modal-trigger" href="#modal2">Guardar</a>
                                <a class=" btn modal-trigger purple" runat="server" href="~/EmpleadoWeb">Cancelar</a>
                            </div>
                            <div id="modal2" class="modal">
                                <div class="modal-content">
                                    <h4>Atencion</h4>
                                    <p>¿Desea guardar los cambios?</p>
                                </div>
                                <div class="modal-footer">

                                    <asp:Button CssClass="purple white-text btn-small" ID="btnEditar" OnClick="btnEditar_Click" runat="server" Text="Aceptar" />

                                    <a href="#!" class="purple white-text modal-close btn-flat">Cancelar</a>
                                </div>
                            </div>
                        </div>
                        <!---Fin MODAL Guardar-->

                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </asp:View>
        </asp:MultiView>
    </div>


    <script type="text/javascript" src="js/tabfunciones.js"></script>

    <!--HASTA ACA-->
</asp:Content>
