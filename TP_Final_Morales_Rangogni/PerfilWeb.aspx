<%@ Page Title="About" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="PerfilWeb.aspx.cs" Inherits="TP_Final_Morales_Rangogni.PerfilWeb" Debug="true" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContentLogin" runat="server">
    <section>
        <div class="tab-bar">
            <a href="#Perfil">Perfil</a>
            <a href="#SOLAPA2">Solapa2</a>
            <a href="#SOLAPA3">Solapa3</a>
            <a href="#SOLAPA4">Solapa4</a>

        </div>
        
        <div class="content">
    <div class="header bg-blue">
       
                
                <asp:GridView ID="dgvPerfiles" CssClass="highlight responsive-table" runat="server"></asp:GridView>
    
            <asp:Button runat="server" ID="btnVerPerfiles" CssClass="btn btn-default" OnClick="btnVerPerfiles_Click" Text="Perfiles &raquo;" />
    </div>
    
        <div class="row">
            <div class="col s12 right-align">
                <a class="btn-floating btn waves-effect modal-trigger waves-light purple right-align" onclick="limpiarModal('NUEVO')" href="#modalAdd"><i class="material-icons">add</i></a>
                <a class="btn-floating btn waves-effect modal-trigger waves-light purple right-align" onclick="cargarModal('ACTUALIZA')" href="#modalAdd"><i class="material-icons">border_color</i></a>
                <a class="btn-floating btn waves-effect modal-trigger waves-light purple right-align" onclick="cargarModal('ELIMINA')" href="#modalAdd"><i class="material-icons">delete_forever</i></a>
            </div>
        </div>
        <div>

            <!-- Modal Structure -->
            <div id="modalAdd" class="modal">
                <div class="modal-content">
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
        <div class="jumbotron">
            <h4>PERFIL</h4>
            <p class="lead">Permite agregar un nuevo tipo de perfil</p>
            <p><a href="/PerfilWeb" class="btn btn-primary btn-lg">Perfiles &raquo;</a></p>
        </div>
    </div>
             <!--SOLAPA GENERICA-->
        <div class="content">
            <h2>LISTA TURNOS Y EDITA <span><i class="fas fa-carrot"></i></span></h2>
            <p>Listar turnos(pacientes)/ botons de editar/ .</p>

        </div>
    </section>
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
        <script type="text/javascript" src="js/tabfunciones.js"></script>
</asp:Content>
