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
                UsuarioNegocio negocio=new UsuarioNegocio();
                Usuario nuevoUser = new Usuario();
                
                nuevoUser.Nombres = txtnombre.Text;
                nuevoUser.Apellidos = txtApellido.Text;
                nuevoUser.NroDocumento = txtDni.Text;
                nuevoUser.Estado = chbEstado1.Checked;
                //desplegable
                nuevoUser.idTipoPerfil =int.Parse (ddlPerfilEmp.SelectedValue);
                nuevoUser.User = txtUser.Text;
                nuevoUser.Password = txtPass.Text; 
               
                ///CREAR METODO negocio.agregar(nuevo);
                if (negocio.AltaUsuario(nuevoUser))
                {
                    ///cartel alta de empleado completa y limpiar controles                

                }
            }
            catch (Exception ex)
            {
                throw ex;

            }

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