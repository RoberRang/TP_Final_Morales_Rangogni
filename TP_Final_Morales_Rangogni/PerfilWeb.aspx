<%@ Page Title="About" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="PerfilWeb.aspx.cs" Inherits="AccesoModeloBaseDatos.PerfilWeb" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="header bg-blue">
        <h3>Perfiles</h3>
    </div>
    <div class="body bg-gray">
        <asp:Repeater runat="server" ID="rprPerfiles">
            <ItemTemplate>
                <ul class="collection with-header">
                    <div class="row">
                        <div class="col s6">
                            <li class="collection-item">
                                <asp:Label ID="lblDesc" runat="server" Text="Descripcion: "> <%#Eval("Descripcion")%></asp:Label>
                            </li>
                        </div>
                        <div class="col s6">
                            <li class="collection-item">
                                <asp:Label runat="server" for="chkPerfil" ForeColor="" ID="lblChkDesc" Text="Estado: "><%#Eval("Estado")%></asp:Label>
                            </li>
                        </div>
                    </div>
                </ul>
            </ItemTemplate>
        </asp:Repeater>
        <div class="form-group">
            <div class="row">
                <div class="col s6">
                    <asp:TextBox CssClass="form-control" ID="txtDesc" runat="server" placeholder="Descripción"></asp:TextBox>
                </div>
                <div class="col s6">
                    <asp:CheckBox ID="chkPerfilIn" runat="server" Checked="false" />
                    <label for="chkPerfilIn" forecolor="" id="lblChkDescIn" text="Estado"></label>
                </div>
            </div>
        </div>
        <asp:Button ID="btnIngresar" CommandName="Login" runat="server" Text="Grabar" CssClass="btn bg-blue btn-block purple" OnClick="btnIngresar_Click" />
    </div>
</asp:Content>
