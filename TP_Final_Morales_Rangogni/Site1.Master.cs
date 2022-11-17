using AccesoModeloBaseDatos.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TP_Final_Morales_Rangogni
{
    public partial class Site1 : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["EmpleadoLogin"] != null)
            {
                Empleado empLogin = (Empleado)Session["EmpleadoLogin"];
                lblUsuario.Text =  empLogin.Nombres + ", " + empLogin.Apellidos;
            }
            else
                Response.Redirect("Default.aspx", false);
        }
    }
}