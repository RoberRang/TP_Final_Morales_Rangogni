<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="PacienteWeb.aspx.cs" Inherits="TP_Final_Morales_Rangogni.PacienteWeb" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContentLogin" runat="server">
    <!---ACA-->
    <section>
        <div class="tab-bar">
            <a href="#fruit">NUEVO PACIENTE</i></span></a>
            <a href="#fruit">PACIENTES</a>
            <a href="#fruit">TURNOS</a>
            <a href="#fruit">SOLAPA 4</a>

        </div>


        <!--ACA SOLAPA AGREGAR PACIENTE-->
        <div class="content">

            <!--imagen-->

            <div>
                <asp:Image ID="imgPaciente" runat="server" CssClass="circle responsive-img" src="https://objetivoligar.com/wp-content/uploads/2017/03/blank-profile-picture-973460_1280-580x580.jpg" />
           </div>
            <div class="file-field input-field">
                <div class="waves-effect waves-light btn-small">
                    <span>Agregar</span>
                    <input type="file" runat="server">
                </div>
                <div class="file-path-wrapper">
                    <asp:TextBox ID="txtImagen" runat="server" CssClass="file-path validate"></asp:TextBox>
                </div>
            </div>




            <!--Telefono -->

            <div class="col s12">
                <div class="row">

                    <div class="input-field col s6">
                        <asp:TextBox ID="txtnombre" runat="server" CssClass="validate" placeholder=""></asp:TextBox>
                        <label for="lblNombre">Nombre</label>
                    </div>

                    <div class="input-field col s6">
                        <asp:TextBox ID="txtApellido" runat="server" CssClass="validate" placeholder=""></asp:TextBox>
                        <label for="lblApellido">Apellido</label>
                    </div>

                </div>
            </div>
            <!--Telefono -->
            <div class="col s12">
                <div class="row">

                    <div class="input-field col s4">
                        <asp:TextBox ID="txtTelefono" runat="server" CssClass="validate" placeholder=""></asp:TextBox>
                        <label for="lblTelefono">Telefono</label>
                    </div>

                    <div class="input-field col s4">
                        <asp:TextBox ID="txtDni" runat="server" CssClass="validate" placeholder=""></asp:TextBox>
                        <label for="lblDniPac">Nº Documento</label>
                    </div>
                    <!--Email -->

                    <div class="input-field col s4">
                        <asp:TextBox ID="txtEmail" runat="server" CssClass="validate" TextMode="Email" placeholder=""></asp:TextBox>
                        <label for="lblEmail">Correo Electronico</label>
                    </div>

                </div>
            </div>
            <!-- ESTADO -->
            <div class="col s12">
                <div class="row">
                    <div class="input-field col s4 left-align">
                        <label for="lblGenero">Genero</label>
                        <br />
                        <br />
                        <asp:DropDownList ID="ddlGenero" runat="server" CssClass="dropdown-trigger btn purple lighten-2" Style="margin-top: 10px;" href="#" data-activates="drpdEstado" data-target="drpdEstado">
                            <asp:ListItem Text="Masculino" />
                            <asp:ListItem Text="Femenino" />
                            <asp:ListItem Text="Otro" />
                        </asp:DropDownList>
                    </div>

                    <div class="input-field col s4 center-align">
                        <label for="lblEstado">Estado</label>
                        <br />
                        <br />
                        <div class="switch">
                            <label>
                                INACTIVO
                      <asp:CheckBox ID="chbEstado" runat="server" Checked="true" />
                                <span class="lever"></span>
                                ACTIVO
                            </label>
                        </div>
                    </div>
                    <!--imagen-->

                    <div class="input-field col s4 right-align">
                        <label for="lblFnac">Fecha de Nacimiento</label>
                        <br />
                        <br />
                        <asp:TextBox ID="txtFecha" runat="server" TextMode="Date" placeholder=""></asp:TextBox>

                    </div>

                </div>
            </div>

            <div class="row">
                <div class="input-field col s12 center-align">
                    <asp:Button CssClass="waves-effect waves-light btn-small" ID="btnAcept" runat="server" OnClick="btnAcept_Click" Text="Aceptar" />
                </div>
            </div>


        </div>
        <!---hasta aca-->

        <!---solapa pacientes-->
        <div class="content">
            

            <div class="col-md-5">


                <asp:GridView ID="dgvPacientes" CssClass="highlight responsive-table" runat="server"></asp:GridView>


                <asp:Button runat="server" ID="btnVerPac" CssClass="btn btn-default" OnClick="btnVerPac_Click" Text="Pacientes &raquo;" />

            </div>

        </div>
        <!---hasta aca-->

        <div class="content">
            <h2>Vegetables <span><i class="fas fa-carrot"></i></span></h2>
            <p>Lorem ipsum dolor sit amet, consectetur adipisicing elit. Iste omnis aliquid ad, ex quisquam, odio vero ipsam quo totam soluta eos repellendus, rerum vel nihil nisi cum numquam, consectetur. Sequi nemo, a. Ad perferendis nostrum explicabo quas tempora esse quae quam atque officia neque, mollitia earum blanditiis alias aperiam molestiae. Sequi nemo, a. Ad perferendis nostrum explicabo quas tempora esse quae quam atque officia neque, mollitia earum blanditiis alias aperiam molestiae.</p>
        </div>
    </section>




    <script>
        tabBars = document.querySelectorAll(".tab-bar a")
        contents = document.querySelectorAll(".content")

        resetTabs()
        contents[0].style = `display: block;`
        tabBars[0].style = `background-color: var(--tab-body-color); color: var(--font-color-dark)`

        tabBars.forEach(function (tabBar, tabBarIndex) {
            tabBar.addEventListener("click", function () {
                resetTabs()
                contents[tabBarIndex].style = `display: block; background-color: var(--tab-body-color); color: var(--font-color-dark);`
                this.style = `background-color: var(--tab-body-color); color: var(--font-color-dark); transition: all .5s`
            })
        })

        function resetTabs() {
            for (let i = 0; i < contents.length; i++) {
                contents[i].style = `display: none; background-color: var(--tab-body-color); color: var(--tab-text-color-light);`
                tabBars[i].style = `background-color: var(--tab-background-color); color: var(--tab-text-color-light); transition: all .5s`
            }
        }

        function checkTab(e) {
            if (e.keyCode === 9) {
                for (let i = 0; i < tabBars.length; i++) {
                    tabBars[i].classList.add('show-outline')
                }
                window.removeEventListener('keydown', checkTab);
            }
        }
        window.addEventListener('keydown', checkTab);
    </script>
</asp:Content>
