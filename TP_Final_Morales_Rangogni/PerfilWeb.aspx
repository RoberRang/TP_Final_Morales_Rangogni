<%@ Page Title="About" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="PerfilWeb.aspx.cs" Inherits="AccesoModeloBaseDatos.PerfilWeb" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="header bg-blue">
        <h4 class="left-align">Perfiles</h4>
    </div>
    <div class="body bg-gray">
        <asp:Repeater runat="server" ID="rprPerfiles">
            <itemtemplate>
                <ul class="collection with-header">
                    <div class="row">
                        <h6 class="left-align">
                            <div class="col s2">
                                <li class="collection-item">
                                    <asp:Label ID="lblId" runat="server" Text="Id: "><%#Eval("IdPerfil")%></asp:Label>
                                </li>
                            </div>
                            <div class="col s7">
                                <li class="collection-item">
                                    <asp:Label ID="lblDesc" runat="server" Text="Descripcion: "><%#Eval("Descripcion")%></asp:Label>
                                </li>
                            </div>
                            <div class="col s3">
                                <li class="collection-item">
                                    <asp:Label runat="server" for="chkPerfil" ForeColor="" ID="lblChkDesc" Text="Estado: "><%#Eval("Estado")%></asp:Label>
                                </li>
                            </div>
                        </h6>
                    </div>
                </ul>
            </itemtemplate>
        </asp:Repeater>
        <div class="divider"></div>
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
