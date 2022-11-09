using AccesoModeloBaseDatos;
using AccesoModeloBaseDatos.Dominio;
using AccesoModeloBaseDatos.Modelos;
using ModeloDeNegocio.Negocio;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TP_Final_Morales_Rangogni
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void btnVerEmp_Click(object sender, EventArgs e)
        {
            UsuarioNegocio usuarioNegocio = new UsuarioNegocio();
            List<Empleado> empleadosBuscados = usuarioNegocio.Empleados();

            dgEmpleados.DataSource = empleadosBuscados;
            dgEmpleados.DataBind();
        }
    }
}