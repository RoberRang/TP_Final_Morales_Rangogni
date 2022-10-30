using AccesoModeloBaseDatos.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TP_Final_Morales_Rangogni;

namespace TP_Final_Morales_Rangogni
{
    public partial class EmpleadoWeb : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {

                }
            }
            catch (Exception ex)
            {
                Session.Add("Error", ex);

            }

        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                Empleado nuevo = new Empleado();
                nuevo.Nombres = txtnombre.Text;
                nuevo.Apellidos = txtApellido.Text;
                nuevo.NroDocumento = txtDni.Text;
                nuevo.Estado = chbEstado.Checked;

                //desplegable
                

                ///CREAR METODO negocio.agregar(nuevo);

            }
            catch (Exception ex)
            {
                Session.Add("Error", ex);

            }

        }
    }
}