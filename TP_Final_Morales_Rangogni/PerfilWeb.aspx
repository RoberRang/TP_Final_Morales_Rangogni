<%@ Page Title="About" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="PerfilWeb.aspx.cs" Inherits="TP_Final_Morales_Rangogni.PerfilWeb" Debug="true" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContentLogin" runat="server">
    <asp:UpdatePanel runat="server" UpdateMode="Conditional" ID="upEspecialidad">
        <ContentTemplate>
            <div class="tab-bar">
                <a href="#PERFIL">PERFILES</a>
            </div>
            <div class="content">
                <div class="header bg-blue">
                    <asp:GridView ID="dgvPerfiles" DataKeyNames="IdPerfil" AutoGenerateColumns="false" OnRowCommand="dgvPerfiles_RowCommand" CssClass="highlight responsive-table" runat="server">
                        <Columns>
                            <asp:BoundField HeaderText="Id" DataField="IdPerfil" />
                            <asp:BoundField HeaderText="Jornada" DataField="Descripcion" />
                            <asp:ButtonField HeaderText="Editar" ButtonType="Link" HeaderStyle-Width="100" CommandName="Editar" ControlStyle-CssClass="btn-floating purple" Text="<i class='material-icons'>border_color</i>" />
                            <asp:ButtonField HeaderText="Eliminar" ButtonType="Link" HeaderStyle-Width="100" CommandName="Eliminar" ControlStyle-CssClass="btn-floating purple" Text="<i class='material-icons'>delete_forever</i>" />
                        </Columns>
                    </asp:GridView>
                    <div class="divider"></div>
                    <div class="row">
                        <div class="col s12 right-align">
                            <asp:LinkButton runat="server" ID="lbtnCargar" CssClass="btn-floating purple" OnClick="lbtnCargar_Click" Text=""><i class="material-icons">cached</i></asp:LinkButton>
                            <asp:LinkButton runat="server" ID="lbtnNuevo" class="btn-floating purple small" OnClick="lbtnNuevo_Click"><i class="material-icons">add</i></asp:LinkButton>
                        </div>
                    </div>

                    <!-- Modal Structure -->
                    <asp:Button ID="ClientButton" runat="server" CssClass="modal" Text="Modal" />
                    <asp:Panel ID="ModalPanel" runat="server" Width="500px" CssClass="content">
                        <div class="row">
                            <div class="col s1">
                                <asp:TextBox CssClass="form-control" ID="txtId" runat="server" placeholder="Id"></asp:TextBox>
                            </div>
                            <div class="col s6">
                                <asp:TextBox CssClass="form-control" ID="txtDesc" runat="server" placeholder="Descripción"></asp:TextBox>
                            </div>
                            <div class="col s4">
                                <div class="row">
                                    <div class="input-field">
                                        Estado
                                    <div class="switch">
                                        <label>
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
                                    <asp:LinkButton ID="lbtnGraba" CssClass="btn-floating purple" runat="server" OnClick="lbtnGraba_Click"><i class="material-icons">save</i></asp:LinkButton>
                                    <asp:LinkButton ID="lbtnCancela" CssClass="btn-floating purple" runat="server"><i class="material-icons">cancel</i></asp:LinkButton>
                                </div>
                            </div>
                        </div>
                    </asp:Panel>
                    <ajaxToolkit:ModalPopupExtender ID="mpe" runat="server" TargetControlID="ClientButton" PopupControlID="ModalPanel" OkControlID="lbtnCancela" />
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
    <script type="text/javascript" src="js/tabfunciones.js"></script>
</asp:Content>
