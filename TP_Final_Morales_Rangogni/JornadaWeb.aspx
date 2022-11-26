<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="JornadaWeb.aspx.cs" Inherits="TP_Final_Morales_Rangogni.JornadaTurnoWeb" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContentLogin" runat="server">

    <asp:UpdatePanel runat="server" UpdateMode="Conditional" ID="upJornadas">
        <ContentTemplate>
            <div class="tab-bar">
                <a href="#Jornadas">JORNADAS</a>
            </div>
            <div class="content">
                <div class="header bg-blue">
                    <div class="body bg-gray">
                        <asp:GridView ID="dgvJornadas" CssClass="highlight responsive-table" runat="server" DataKeyNames="IdJornada" OnRowCommand="dgvJornadas_RowCommand" AutoGenerateColumns="false">
                            <Columns>
                                <asp:BoundField HeaderText="Id" DataField="IdJornada" />
                                <asp:BoundField HeaderText="Jornada" DataField="Descripcion" />
                                <asp:BoundField HeaderText="Inicio" DataField="Inicio" />
                                <asp:BoundField HeaderText="Fin" DataField="Fin" />
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
                <%--            </ContentTemplate>
        </asp:UpdatePanel>
        <asp:UpdatePanel runat="server" UpdateMode="Conditional" ID="udpModal">
            <ContentTemplate>--%>
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
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
    <script type="text/javascript" src="Scripts/jquery-3.6.0.min.js"></script>
    <script type="text/javascript" src="js/materialize.min.js"></script>
    <script type="text/javascript">
        var launch = false;
        function launchModal() {
            launch = true;
        }
    </script>
</asp:Content>
