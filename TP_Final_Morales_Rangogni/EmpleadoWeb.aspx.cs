using AccesoModeloBaseDatos.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TP_Final_Morales_Rangogni;
using TP_Final_Morales_Rangogni.Negocio;

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
                    buscarTipoPerfil();

                }
            }
            catch (Exception ex)
            {
                throw ex;

            }

        }

        private void buscarTipoPerfil()
        {
            PerfilNegocio perfilNegocio=new PerfilNegocio();
            ddlPerfilEmp.DataSource= perfilNegocio.Perliles();
            ddlPerfilEmp.DataValueField = "idPerfil";
            ddlPerfilEmp.DataTextField = "descripcion";
            ddlPerfilEmp.DataBind();
            
        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {   
            try
            {
                Empleado nuevo = new Empleado();
                nuevo.Nombres = txtnombre.Text;
                nuevo.Apellidos = txtApellido.Text;
                nuevo.NroDocumento = txtDni.Text;
                nuevo.Estado = chbEstado1.Checked;

                //desplegable
                

                ///CREAR METODO negocio.agregar(nuevo);

            }
            catch (Exception ex)
            {
                throw ex;

            }

        }
    }
}