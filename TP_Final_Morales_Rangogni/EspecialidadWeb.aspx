<%@ Page Title="Especialidad" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="EspecialidadWeb.aspx.cs" Inherits="TP_Final_Morales_Rangogni.EspecialidadWeb" Debug="true" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContentLogin" runat="server">
    <div class="header bg-blue">
        <h4 class="left-align">Especialidad</h4>
    </div>
    <div class="body bg-gray">
        <asp:Repeater runat="server" ID="rprEspecialidad">
            <ItemTemplate>
                <ul class="collection">
                    <div class="row">
                        <h6 class="left-align">
                            <div class="col s2">
                                <li class="collection-item">
                                    <asp:Label ID="lblId" runat="server" Text="Id: "><%#Eval("IdEspecialidad")%></asp:Label>
                                </li>
                            </div>
                            <div class="col s7">
                                <li class="collection-item">
                                    <asp:Label ID="lblDesc" runat="server" Text="Descripcion: "><%#Eval("Descripcion")%></asp:Label>
                                </li>
                            </div>
                            <div class="col s3">
                                <li class="collection-item">
                                    <asp:Label runat="server" for="chkEspecialidad" ForeColor="" ID="lblChkDesc" Text="Estado: "><%#Eval("Estado")%></asp:Label>
                                </li>
                            </div>
                        </h6>
                    </div>
                </ul>
            </ItemTemplate>
        </asp:Repeater>
        <div class="row">
            <div class="col s12 right-align">
                <a class="btn-floating btn waves-effect modal-trigger waves-light purple right-align" onclick="limpiarModal('NUEVO')" href="#modal1"><i class="material-icons">add</i></a>
                <a class="btn-floating btn waves-effect modal-trigger waves-light purple right-align" onclick="cargarModal('ACTUALIZA')" href="#modal1"><i class="material-icons">border_color</i></a>
                <a class="btn-floating btn waves-effect modal-trigger waves-light purple right-align" onclick="cargarModal('ELIMINA')" href="#modal1"><i class="material-icons">delete_forever</i></a>
            </div>
        </div>
        <div>
            <!-- Modal Structure -->
            <div id="modal1" class="modal">
                <div class="modal-content">
                    <div class="form-group">
                        <div class="row">
                            <div class="col s8">
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
                    </div>
                </div>
                <div class="modal-footer">
                    <div class="row">
                        <div class="col s4 left-align">
                            <asp:Label runat="server" ForeColor="" Font-Bold="true" ID="lblAccion" Text=""></asp:Label>
                        </div>
                        <div class="col s8 right-align">
                            <asp:ImageButton ID="iBtnGraba" CssClass="btn-floating purple" runat="server" OnClick="iBtnGraba_Click" />
                            <asp:ImageButton ID="iBtnCancela" CssClass="btn-floating purple" runat="server" />
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div class="divider"></div>
        <div class="col-md-5">
            <h4>Especialidad</h4>
            <p>
                Permite agregar una nueva especialidad.
            </p>
            <p>
                <a class="btn btn-default" href="/EspecialidadWeb">Especialidad &raquo;</a>
            </p>
        </div>
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
