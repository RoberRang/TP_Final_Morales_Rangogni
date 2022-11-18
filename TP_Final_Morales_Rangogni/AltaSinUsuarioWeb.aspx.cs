using AccesoModeloBaseDatos.Dominio;
using AccesoModeloBaseDatos.Modelos;
using ModeloDeNegocio.Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TP_Final_Morales_Rangogni
{
    public partial class AltaSinUsuarioWeb : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Session["EmpleadoSinLogin"] == null)
                    throw new Exception("Acceso erroneo!");
            }
            catch (Exception ex)
            {
                Session.Add("MensajeError", ex.Message);
                Response.Redirect("ErrorWeb.aspx", false);
            }
        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            UsuarioNegocio negocio = new UsuarioNegocio();
            Usuario nuevoUser = new Usuario();
            try
            {

                if (!ValidoControlTextBox(txtNom))
                    return;
                if (!ValidoControlTextBox(txtApellido))
                    return;
                if (!ValidoControlTextBox(txtDni))
                    return;
                if (!ValidoControlTextBox(txtUser))
                    return;
                if (!ValidoControlTextBox(txtPass))
                    return;
                if (!ValidoControlTextBox(txtPass2))
                    return;
                if (txtPass.Text != txtPass2.Text)
                {
                    txtPass.Attributes.Add("placeholder", "Las contraseñas deben ser iguales");
                    txtPass.Focus();
                    txtPass2.Attributes.Add("placeholder", "Las contraseñas deben ser iguales");
                    txtPass2.Focus();
                    return;
                }
                nuevoUser.Nombres = txtNom.Text;
                nuevoUser.Apellidos = txtApellido.Text;
                nuevoUser.NroDocumento = txtDni.Text;
                nuevoUser.Estado = false;
                //desplegable
                nuevoUser.idTipoPerfil = 3;
                nuevoUser.User = txtUser.Text;
                nuevoUser.Password = txtPass.Text;

                ///CREAR METODO negocio.agregar(nuevo);
                if (negocio.AltaUsuario(nuevoUser))
                {
                    Empleado empNuevo = new Empleado();
                    empNuevo.idTipoPerfil = nuevoUser.idTipoPerfil;
                    empNuevo.Estado = nuevoUser.Estado;
                    empNuevo.NroDocumento = nuevoUser.NroDocumento;
                    empNuevo.Nombres = nuevoUser.Nombres;
                    empNuevo.Apellidos = nuevoUser.Apellidos;

                    Session.Add("EmpleadoLogin", empNuevo);
                    Response.Redirect("SiteDefaultWeb.aspx", false);
                }
                else
                    Response.Redirect("Default.aspx", false);

            }
            catch (Exception ex)
            {
                Session.Add("MensajeError", ex.ToString());
                Response.Redirect("ErrorWeb.aspx", false);

            }

        }

        private bool ValidoControlTextBox(TextBox textBox)
        {
            bool valido = false;
            valido = textBox.Text.Equals("") ? false : true;
            if (!valido)
            {
                textBox.Attributes.Add("placeholder", "El campo no debe quedar incompleto");
                textBox.Focus();
            }
            return valido;
        }

    }
}