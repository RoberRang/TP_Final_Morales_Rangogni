<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="MedicoWeb.aspx.cs" Inherits="TP_Final_Morales_Rangogni.MedicoWeb" EnableEventValidation="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContentLogin" runat="server">

    <div>
        <asp:Menu runat="server" ID="mnMedico" Orientation="Horizontal" OnMenuItemClick="mnMedico_MenuItemClick" DynamicMenuItemStyle-CssClass="tab-bar" CssClass="tab-bar">
            <Items>
                <asp:MenuItem Text="Pacientes" Value="0" Selected="true"></asp:MenuItem>
                <asp:MenuItem Text="Especialidad" Value="1"></asp:MenuItem>
            </Items>
        </asp:Menu>
    </div>

    <div class="content">
        <asp:MultiView runat="server" ID="mvwMedico" ActiveViewIndex="0">
            <!-- PANEL MEDICO -->
            <asp:View ID="View0" runat="server">
                <asp:UpdatePanel runat="server" UpdateMode="Conditional" ID="upMedicos">
                    <ContentTemplate>
                        <div class="header bg-blue">
                            <div class="body bg-gray">
                                <asp:GridView ID="dgvMedicos" CssClass="highlight responsive-table" runat="server" DataKeyNames="IdMedico" OnRowCommand="dgvMedicos_RowCommand" AutoGenerateColumns="false">
                                    <Columns>
                                        <asp:BoundField HeaderText="Nombre" DataField="Nombres" />
                                        <asp:BoundField HeaderText="Apellido" DataField="Apellidos" />
                                        <asp:BoundField HeaderText="Dni" DataField="Inicio" />
                                        <asp:BoundField HeaderText="Hora" DataField="Hora" />
                                        <asp:ButtonField HeaderText="Editar" ButtonType="Link" HeaderStyle-Width="100" CommandName="Editar" ControlStyle-CssClass="btn-floating purple" Text="<i class='material-icons'>border_color</i>" />
                                        <asp:ButtonField HeaderText="Eliminar" ButtonType="Link" HeaderStyle-Width="100" CommandName="Eliminar" ControlStyle-CssClass="btn-floating purple" Text="<i class='material-icons'>delete_forever</i>" />
                                    </Columns>
                                </asp:GridView>
                                <div class="divider"></div>
                                <div class="row">
                                    <div class="col s12 right-align">
                                        <asp:LinkButton runat="server" ID="btnVerJornadas" CssClass="btn-floating purple"><i class="material-icons">cached</i></asp:LinkButton>
                                        <asp:LinkButton ID="lbtnModal" runat="server" CssClass="btn-floating purple small" OnClick="lbtnModal_Click"><i class="material-icons">add</i></asp:LinkButton>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <!-- Modal Structure -->
                        <asp:Button ID="ClientButton" runat="server" CssClass="modal" Text="Modal" />
                        <asp:Panel ID="ModalPanel" runat="server" Width="500px" CssClass="content">
                            <div class="row">
                                <div class="col s2">
                                    <asp:TextBox CssClass="form-control" Enabled="false" ID="txtId" runat="server" placeholder="Id"></asp:TextBox>
                                </div>
                                <div class="col s6">
                                    <asp:TextBox CssClass="form-control" ID="txtDesc" runat="server" placeholder="Descripción"></asp:TextBox>
                                </div>
                                <div class="col s2">
                                    <asp:TextBox CssClass="form-control" ID="txtIni" runat="server" placeholder="Inicio"></asp:TextBox>
                                </div>
                                <div class="col s2">
                                    <asp:TextBox CssClass="form-control" ID="txtFin" runat="server" placeholder="Fin"></asp:TextBox>
                                </div>
                                <div class="col s4">
                                    <div class="row">
                                        <div class="input-field">
                                            <h6>Estado</h6>
                                            <div class="switch">
                                                <label id="lblEstado">
                                                    INACTIVO
                                            <asp:CheckBox ID="chbEst" runat="server" />
                                                    <span class="lever"></span>
                                                    ACTIVO
                                                </label>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="modal-footer">
                                <div class="row">
                                    <div class="col s4 left-align">
                                        <asp:Label runat="server" ForeColor="" Font-Bold="true" ID="lblAccion" Text=""></asp:Label>
                                    </div>
                                    <div class="col s8 right-align">
                                        <asp:LinkButton ID="lkbGraba" runat="server" CssClass="btn-floating purple small" OnClick="lkbGraba_Click"><i class="material-icons">save</i></asp:LinkButton>
                                        <asp:LinkButton ID="lbtnCancela" CssClass="btn-floating purple" runat="server"><i class="material-icons">cancel</i></asp:LinkButton>
                                    </div>
                                </div>
                            </div>
                        </asp:Panel>
                        <ajaxToolkit:ModalPopupExtender ID="mpe" runat="server" TargetControlID="ClientButton" PopupControlID="ModalPanel" OkControlID="lbtnCancela" />
                    </ContentTemplate>
                </asp:UpdatePanel>
            </asp:View>
            <!-- PANEL ESPECIALIDAD -->
            <asp:View ID="View1" runat="server">
                <asp:UpdatePanel runat="server" UpdateMode="Conditional" ID="upEspecialidad">
                    <ContentTemplate>
                        <asp:GridView ID="dgvEspecialidad" DataKeyNames="IdEspecialidad" AutoGenerateColumns="false" OnRowCommand="dgvEspecialidad_RowCommand" CssClass="highlight responsive-table" runat="server">
                            <Columns>
                                <asp:BoundField HeaderText="Id" DataField="IdEspecialidad" />
                                <asp:BoundField HeaderText="Descripcion" DataField="Descripcion" />
                                <asp:BoundField HeaderText="Estado" DataField="Estado" />
                                <asp:ButtonField HeaderText="Editar" ButtonType="Link" HeaderStyle-Width="100" CommandName="Editar" ControlStyle-CssClass="btn-floating purple" Text="<i class='material-icons'>border_color</i>" />
                            </Columns>
                        </asp:GridView>
                        <div class="divider"></div>
                        <div class="row">
                            <div class="col s12 right-align">
                                <asp:LinkButton runat="server" ID="lbtnCargarEsp" CssClass="btn-floating purple" OnClick="lbtnCargarEsp_Click" Text=""><i class="material-icons">cached</i></asp:LinkButton>
                                <asp:LinkButton runat="server" ID="lbtnNuevaEsp" class="btn-floating purple small" OnClick="lbtnNuevaEsp_Click"><i class="material-icons">add</i></asp:LinkButton>
                            </div>
                        </div>
                        <!-- Modal Especialidad -->
                        <asp:Button ID="btnEspMed" runat="server" CssClass="modal" Text="Modal" />
                        <asp:Panel ID="ModalPanelEsp" runat="server" Width="700px" CssClass="content">
                            <div class="row">
                                <div class="col s2">
                                    <asp:TextBox CssClass="form-control" ID="txtIdMed" Visible="false" runat="server" placeholder="IdMed"></asp:TextBox>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col s2">
                                    <asp:TextBox CssClass="form-control" ID="txtIdEspMed" runat="server" placeholder="IdEsp"></asp:TextBox>
                                </div>
                                <div class="col s6 left-align">
                                    <asp:Label runat="server" ID="lblEspecialidad" Visible="false"></asp:Label>
                                    <asp:DropDownList ID="ddlEspecialidad" runat="server" OnSelectedIndexChanged="ddlEspecialidad_SelectedIndexChanged" CssClass="dropdown-trigger btn purple white-text" Style="margin-top: 5px" AutoPostBack="true" data-activates="ddlEpecialidad" />
                                </div>
                                <div class="col ss4">
                                    <div class="row">
                                        <div class="input-field">
                                            Estado
                                        <div class="switch">
                                            <label>
                                                INACTIVO
                                                <asp:CheckBox ID="chkEstMedEsp" runat="server" />
                                                <span class="lever"></span>
                                                ACTIVO
                                            </label>
                                        </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="modal-footer">
                                <div class="row">
                                    <div class="col s4 left-align">
                                        <asp:Label runat="server" ForeColor="" Font-Bold="true" ID="lblAccionEsp" Text=""></asp:Label>
                                    </div>
                                    <div class="col s8 right-align">
                                        <asp:LinkButton ID="lbtnGrabaEsp" CssClass="btn-floating purple" runat="server" OnClick="lbtnGrabaEsp_Click"><i class="material-icons">save</i></asp:LinkButton>
                                        <asp:LinkButton ID="lbtnCancelEsp" CssClass="btn-floating purple" runat="server"><i class="material-icons">cancel</i></asp:LinkButton>
                                    </div>
                                </div>
                            </div>
                        </asp:Panel>
                        <ajaxToolkit:ModalPopupExtender ID="mpeEsp" runat="server" TargetControlID="btnEspMed" PopupControlID="ModalPanelEsp" OkControlID="lbtnCancelEsp" />
                    </ContentTemplate>
                </asp:UpdatePanel>
            </asp:View>
        </asp:MultiView>
    </div>
    <script type="text/javascript" src="js/tabfunciones.js"></script>
</asp:Content>
