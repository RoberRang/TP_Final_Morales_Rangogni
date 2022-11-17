using TP_Final_Morales_Rangogni.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using AccesoModeloBaseDatos.Dominio;
using ModeloDeNegocio.Negocio;

namespace TP_Final_Morales_Rangogni
{
    public partial class Acceso : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                Session["EmpleadoLogin"] = null;
            }
        }

        protected void btnIngresar_Click(object sender, EventArgs e)
        {
            Usuario usuario = new Usuario();
            UsuarioNegocio usuarioNegocio = new UsuarioNegocio();
            try
            {
                if (!ValidoControlTextBox(txtUser))
                    return;
                if (!ValidoControlTextBox(txtPassword))
                    return;
                
                usuario.User = txtUser.Text;
                usuario.Password = txtPassword.Text;
                Empleado empleadoLogin = usuarioNegocio.ValidarDatosIngreso(usuario);
                if (empleadoLogin != null)
                {
                    Session.Add("EmpleadoLogin", empleadoLogin);
                    DireccionarEmplado();
                }
                else
                {
                    Session.Add("MensajeError", "Hubo un error con el usuario o password ingresado");
                    Response.Redirect("ErrorWeb.aspx", false);
                }
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
        private void DireccionarEmplado()
        {
            Empleado empleadoLogin = (Empleado)Session["EmpleadoLogin"];
            if (empleadoLogin != null)
            {
                Response.Redirect("SiteDefaultWeb.aspx", false);
                return; 
            }
            Response.Redirect("Default.aspx", false);
        }

        protected void btnFirst_Click(object sender, EventArgs e)
        {
            Empleado empleadoFirst = new Empleado();
            Session.Add("EmpleadoSinLogin", empleadoFirst);
            Response.Redirect("AltaSinUsuarioWeb.aspx", false);
        }
    }
}