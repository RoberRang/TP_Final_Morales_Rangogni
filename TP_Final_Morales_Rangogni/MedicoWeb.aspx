<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="MedicoWeb.aspx.cs" Inherits="TP_Final_Morales_Rangogni.MedicoWeb" EnableEventValidation="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContentLogin" runat="server">

    <div>
        <asp:Menu runat="server" ID="mnMedico" Orientation="Horizontal" OnMenuItemClick="mnMedico_MenuItemClick" DynamicMenuItemStyle-CssClass="tab-bar" CssClass="tab-bar">
            <Items>
                <asp:MenuItem Text="Pacientes" Value="0" Selected="true"></asp:MenuItem>
            </Items>
        </asp:Menu>
    </div>

    <div class="content">
        <asp:MultiView runat="server" ID="mvwMedico" ActiveViewIndex="0">
            <!-- PANEL MEDICO -->
            <asp:View ID="View0" runat="server">
                <asp:UpdatePanel runat="server" UpdateMode="Conditional" ID="upMedicos">
                    <ContentTemplate>
                        <h6>FILTROS <span><i class="fas fa-carrot"></i></span></h6>
                        <div class="row">
                            <div class="col s12">
                                <div class="row">
                                    <div class="input-field col s3 left-align">
                                        <asp:TextBox ID="txtFechaTurnos" runat="server" AutoPostBack="true" CssClass="dropdown-trigger purple white-text center-align" TextMode="Date" Style="margin-top: 5px" placeholder="Fecha de Turno"></asp:TextBox>
                                    </div>
                                    <div class="col s4 left-align">
                                        <asp:Label runat="server" ID="lblPacienteGrd" AssociatedControlID="txtfiltroPaciente">Paciente</asp:Label>
                                        <asp:TextBox ID="txtfiltroPaciente" runat="server" CssClass="input-field" AutoPostBack="true"></asp:TextBox>
                                    </div>
                                    <div class="col s4 left-align">
                                        <asp:Label runat="server" ID="lblDniGrd" AssociatedControlID="txtFiltroDNI">DNI</asp:Label>
                                        <asp:TextBox ID="txtFiltroDni" runat="server" CssClass="input-field" AutoPostBack="true"></asp:TextBox>
                                    </div>
                                    <div class="col s1 right-align">
                                        <asp:LinkButton runat="server" ID="lbtnCargaGrd" OnClick="lbtnCargaGrd_Click" CssClass="btn-floating purple small"><i class="material-icons left-align">search</i></asp:LinkButton>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="header bg-blue">
                            <div class="body bg-gray">
                                <asp:GridView ID="dgvMedicos" CssClass="highlight responsive-table" runat="server" DataKeyNames="IdMedico" OnRowCommand="dgvMedicos_RowCommand" AutoGenerateColumns="false">
                                    <Columns>
                                        <asp:BoundField HeaderText="Paciente" DataField="NombrePaciente" />
                                        <asp:BoundField HeaderText="Id Paciente" DataField="IdPaciente" />
                                        <asp:BoundField HeaderText="Hora" DataField="Hora" />
                                        <asp:ButtonField HeaderText="Editar" ButtonType="Link" HeaderStyle-Width="100" CommandName="Editar" ControlStyle-CssClass="btn-floating purple" Text="<i class='material-icons'>border_color</i>" />
                                        <asp:ButtonField HeaderText="Eliminar" ButtonType="Link" HeaderStyle-Width="100" CommandName="Eliminar" ControlStyle-CssClass="btn-floating purple" Text="<i class='material-icons'>delete_forever</i>" />
                                    </Columns>
                                </asp:GridView>


                                <div class="row">
                                    <div class="col s1 right-align">
                                        <asp:LinkButton runat="server" ID="lbtnCargarTurnos" OnClick="lbtnCargaGrd_Click" CssClass="btn-floating purple small"><i class="material-icons">cached</i></asp:LinkButton>
                                    </div>
                                </div>
                            </div>
                            <!-- Modal para edicion -->
                            <asp:Button ID="btnModal" runat="server" CssClass="modal" Text="Modal" />
                            <asp:Panel ID="ModalPanel" runat="server" Width="700px" CssClass="content">
                                <div class="row">
                                    <div class="col s2">
                                        <asp:TextBox CssClass="form-control" Enabled="false" ID="txtId" runat="server" placeholder="Id"></asp:TextBox>
                                    </div>
                                    <div class="col s4">
                                        <asp:TextBox CssClass="form-control" Enabled="false" ID="txtPaciente" runat="server" placeholder="Paciente"></asp:TextBox>
                                    </div>
                                    <div class="col s4">
                                        <asp:TextBox CssClass="form-control" Enabled="false" ID="txtDni" runat="server" placeholder="Medico"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col s4">
                                        <asp:TextBox CssClass="form-control" Enabled="false" ID="txtDia" runat="server" placeholder="Dia"></asp:TextBox>
                                    </div>
                                    <div class="col s4">
                                        <asp:TextBox CssClass="form-control" Enabled="false" ID="txtHora" runat="server" placeholder="Hora"></asp:TextBox>
                                    </div>
                                   
                                </div>
                                <div class="row">
                                    <div class="col s12">
                                        <asp:TextBox ID="txtObservacion" runat="server" CssClass="form-control"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="modal-footer">
                                    <div class="row">
                                        <div class="col s8 left-align">
                                            <asp:Label runat="server" ForeColor="" Font-Bold="true" ID="lblAccion" Text="EDICION SITUACION TURNO"></asp:Label>
                                        </div>
                                        <div class="col s4 right-align">
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


        </asp:MultiView>
    </div>
    <script type="text/javascript" src="js/tabfunciones.js"></script>
</asp:Content>
