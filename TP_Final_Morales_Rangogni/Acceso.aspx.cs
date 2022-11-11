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
                usuario.User = txtUser.Text;
                usuario.Password = txtPassword.Text;
                Empleado empleadoLogin = usuarioNegocio.ValidarDatosIngreso(usuario);
                if (empleadoLogin != null)
                {
                    Session.Add("EmpleadoLogin", empleadoLogin);
                    DireccionarEmplado();
                }
                Response.Redirect("Default.aspx");
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        private void DireccionarEmplado()
        {
            Empleado empleadoLogin = (Empleado)Session["EmpleadoLogin"];
            if (empleadoLogin.idTipoPerfil == 1)
            {
                Response.Redirect("EspecialidadWeb.aspx");
            }
            if (empleadoLogin.idTipoPerfil == 2)
            {
                Response.Redirect("MedicoWeb.aspx");
            }
            Response.Redirect("Default.aspx");
        }

    }
}