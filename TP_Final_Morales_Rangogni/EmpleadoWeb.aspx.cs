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
                EmpleadoNegocio negocio=new EmpleadoNegocio();
                Empleado nuevo = new Empleado();

                nuevo.Nombres = txtnombre.Text;
                nuevo.Apellidos = txtApellido.Text;
                nuevo.NroDocumento = txtDni.Text;
                nuevo.Estado = chbEstado1.Checked;
                //desplegable
                nuevo.idTipoPerfil =int.Parse (ddlPerfilEmp.SelectedValue);

               
                ///CREAR METODO negocio.agregar(nuevo);
                negocio.AltaEmpleado(nuevo);
                ///cartel alta de empleado completa y limpiar controles                
            }
            catch (Exception ex)
            {
                throw ex;

            }

        }
    }
}