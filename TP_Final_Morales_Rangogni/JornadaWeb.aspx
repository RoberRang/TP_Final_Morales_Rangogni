<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="JornadaWeb.aspx.cs" Inherits="TP_Final_Morales_Rangogni.JornadaTurnoWeb" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContentLogin" runat="server">
    <div class="content">
        <div class="header bg-blue">
            <h4 class="left-align">Jornadas</h4>
        </div>
        <div class="body bg-gray">
            <asp:GridView ID="dgvJornadas" CssClass="highlight responsive-table" runat="server"></asp:GridView>
            <div class="waves-effect purple waves-light btn-floating btn-small">
                <i class="material-icons">cached</i>
                <asp:Button runat="server" ID="btnVerJornadas" CssClass="btn-floating" OnClick="btnVerJornadas_Click" Text="Perfiles &raquo;" />
            </div>
            <div class="row">
                <div class="col s12 right-align">
                    <a class="btn-floating btn waves-effect modal-trigger waves-light purple right-align" onclick="limpiarModal('NUEVO')" href="#modalAdd"><i class="material-icons">add</i></a>
                    <a class="btn-floating btn waves-effect modal-trigger waves-light purple right-align" onclick="cargarModal('ACTUALIZA')" href="#modalAdd"><i class="material-icons">border_color</i></a>
                    <a class="btn-floating btn waves-effect modal-trigger waves-light purple right-align" onclick="cargarModal('ELIMINA')" href="#modalAdd"><i class="material-icons">delete_forever</i></a>
                </div>
            </div>
        </div>
        <!-- Modal Structure -->
        <div id="modalAdd" class="modal">
            <div class="modal-content">
                <div class="row">
                    <div class="col s8">
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
            </div>
            <div class="modal-footer">
                <div class="row">
                    <div class="col s4 left-align">
                        <asp:Label runat="server" ForeColor="" Font-Bold="true" ID="lblAccion" Text=""></asp:Label>
                    </div>
                    <div class="col s8 right-align">
                        <asp:ImageButton ID="iBtnGraba" ImageUrl="~/Imagenes/save_as_opsz48.jpg" CssClass="btn-floating purple" runat="server" OnClick="iBtnGraba_Click" />
                        <asp:ImageButton ID="iBtnCancela" ImageUrl="~/Imagenes/cancel_black_36dp.jpg" CssClass="btn-floating purple" runat="server" />
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div class="divider"></div>
    <script>
        function limpiarModal(mensaje) {
            document.getElementById('<%= txtDesc.ClientID %>').value = "";
            document.getElementById('<%= lblAccion.ClientID %>').textContent = mensaje;
        }
        function cargarModal(mensaje) {
            document.getElementById('<%= lblAccion.ClientID %>').textContent = mensaje;
            let valDesc = document.getElementById('alblDesc').textContent;
            document.getElementById('<%= txtDesc.ClientID %>').value = valDesc;
        }
    </script>
</asp:Content>
