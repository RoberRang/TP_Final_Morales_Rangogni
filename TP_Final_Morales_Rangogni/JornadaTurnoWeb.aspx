<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="JornadaTurnoWeb.aspx.cs" Inherits="TP_Final_Morales_Rangogni.JornadaTurnoWeb" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContentLogin" runat="server">
    <div class="header bg-blue">
        <h4 class="left-align">Jornada Turnos</h4>
    </div>
    <div class="body bg-gray">
        <asp:Repeater runat="server" ID="rprJornadas">
            <ItemTemplate>
                <ul class="collection">
                    <div class="row">
                        <div class="col s1">
                            <li class="collection-item">
                                <asp:Label ID="lblId" runat="server" Text="Id: "><%#Eval("IdJornada")%></asp:Label>
                                <a href="#!" class="hide" id="alblId"><%#Eval("IdJornada")%></a>
                            </li>
                        </div>
                        <div class="col s5">
                            <li class="collection-item">
                                <asp:Label ID="lblDesc" runat="server" Text="Descripcion: "><%#Eval("Descripcion")%></asp:Label>
                                <a href="#!" class="hide" id="alblDesc"><%#Eval("Descripcion")%></a>
                            </li>
                        </div>
                        <div class="col s1">
                            <li class="collection-item">
                                <asp:Label runat="server" ID="lblEst" Text="Estado: "><%#Eval("Estado")%></asp:Label>
                                <a href="#!" class="hide" id="alblEst"><%#Eval("Estado")%></a>
                            </li>
                        </div>
                        <div class="col s2">
                            <li class="collection-item">
                                <asp:Label runat="server" ID="lblInicio" Text="Inicio: "><%#Eval("Inicio")%></asp:Label>
                                <a href="#!" class="hide" id="alblIni"><%#Eval("Inicio")%></a>
                            </li>
                        </div>
                        <div class="col s2">
                            <li class="collection-item">
                                <asp:Label runat="server" ID="lblFin" Text="Fin: "><%#Eval("Fin")%></asp:Label>
                                <a href="#!" class="hide" id="alblFin"><%#Eval("Fin")%></a>
                            </li>
                        </div>
                        <li class="collection-item">
                            <div class="input-field">
                            <asp:CheckBox runat="server" ID="chkSel" Text="Sel: "></asp:CheckBox>
                                </div>
                        </li>
                    </div>
                    </div>
                </ul>
            </ItemTemplate>
        </asp:Repeater>
        <div class="row">
            <div class="col s12 right-align">
                <a class="btn-floating btn waves-effect modal-trigger waves-light purple right-align" onclick="limpiarModal('NUEVO')" href="#modalAdd"><i class="material-icons">add</i></a>
                <a class="btn-floating btn waves-effect modal-trigger waves-light purple right-align" onclick="cargarModal('ACTUALIZA')" href="#modalAdd"><i class="material-icons">border_color</i></a>
                <a class="btn-floating btn waves-effect modal-trigger waves-light purple right-align" onclick="cargarModal('ELIMINA')" href="#modalAdd"><i class="material-icons">delete_forever</i></a>
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
    <div class="jumbotron">
        <h4>JORNADAS</h4>
        <p class="lead">Listar las jornadas</p>
        <p><a href="/PerfilWeb" class="btn btn-primary btn-lg">Jornadas &raquo;</a></p>
    </div>
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
