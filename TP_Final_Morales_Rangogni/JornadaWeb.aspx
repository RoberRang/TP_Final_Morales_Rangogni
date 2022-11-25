<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="JornadaWeb.aspx.cs" Inherits="TP_Final_Morales_Rangogni.JornadaTurnoWeb" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContentLogin" runat="server">
    <!-- Modal Structure -->
    <div id="modalJornada" class="modal">
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
                    <asp:LinkButton ID="lkbGraba" runat="server" CssClass="btn-floating purple small" OnClick="lkbGraba_Click"><i class="material-icons">border_color</i></asp:LinkButton>
                    <asp:ImageButton ID="iBtnCancela" ImageUrl="~/Imagenes/cancel_black_36dp.jpg" CssClass="btn-floating purple" runat="server" />
                </div>
            </div>
        </div>
    </div>
    <div class="content">
        <div class="header bg-blue">
            <h4 class="left-align">Jornadas</h4>
        </div>
        <div class="body bg-gray">
            <asp:GridView ID="dgvJornadas" CssClass="highlight responsive-table" runat="server" DataKeyNames="IdJornada" OnRowCommand="dgvJornadas_RowCommand" AutoGenerateColumns="false">
                <Columns>
                    <asp:BoundField HeaderText="Jornada" DataField="Descripcion" />
                    <asp:BoundField HeaderText="Inicio" DataField="Inicio" />
                    <asp:BoundField HeaderText="Fin" DataField="Fin" />
                    <asp:ButtonField HeaderText="Editar" ButtonType="Link" CommandName="Editar" ControlStyle-CssClass="btn-floating purple" Text="<i class='material-icons'>border_color</i>" />
                    <asp:ButtonField HeaderText="Eliminar" ButtonType="Link" CommandName="Eliminar" ControlStyle-CssClass="btn-floating purple" Text="<i class='material-icons'>delete_forever</i>" />
                </Columns>
            </asp:GridView>
            <div class="divider"></div>
            <div class="row">
                <div class="col s12 right-align">
                    <asp:LinkButton runat="server" ID="btnVerJornadas" CssClass="btn-floating purple"><i class="material-icons">cached</i></asp:LinkButton>
                    <a class="btn-floating btn waves-effect modal-trigger waves-light purple right-align" onclick="limpiarModal('NUEVO')" href="#modalJornada"><i class="material-icons">add</i></a>
                    <asp:Button ID="Button1" runat="server" CssClass="btn btn-info btn-lg" data-toggle="modal" data-target="#modalJornada" Text="Button" />
                    <asp:LinkButton ID="lbtnModal" runat="server" CssClass="btn-floating purple small" OnClientClick="#modalJornada"><i class="material-icons">border_color</i></asp:LinkButton>

                </div>
            </div>
        </div>
    </div>
    <asp:Button ID="ClientButton" runat="server" Text="Launch Modal Popup (Client)" />
    <asp:Panel ID="ModalPanel" runat="server" Width="500px">
        ASP.NET AJAX is a free framework for quickly creating a new generation of more 
         efficient, more interactive and highly-personalized Web experiences that work 
         across all the most popular browsers.
        <br />
        <asp:Button ID="OKButton" runat="server" Text="Close" />
    </asp:Panel>
    
    <!--<ajaxToolkit:ModalPopupExtender ID="mpe" runat="server" TargetControlId="ClientButton" PopupControlID="ModalPanel" OkControlID="OKButton" />-->
    <script type="text/javascript" src="Scripts/jquery-3.6.0.min.js"></script>
    <script type="text/javascript" src="js/materialize.min.js"></script>
    <script type="text/javascript">
        function limpiarModal(mensaje) {
            document.getElementById('<%= txtDesc.ClientID %>').value = "";
            document.getElementById('<%= lblAccion.ClientID %>').textContent = mensaje;
        }
        function CargarModal() {
            var modJornada = $('#modalJornada');
            modJornada.modal().show();
        }
    </script>

</asp:Content>
