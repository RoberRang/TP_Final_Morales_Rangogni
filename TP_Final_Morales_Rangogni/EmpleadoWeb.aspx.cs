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
                Session.Add("MensajeError", ex.ToString());
                Response.Redirect("ErrorWeb.aspx", false);

            }
        }

        private void buscarTipoPerfil()
        {
            PerfilNegocio perfilNegocio = new PerfilNegocio();
            ddlPerfilEmp.DataSource = perfilNegocio.Perliles();
            ddlPerfilEmp.DataValueField = "idPerfil";
            ddlPerfilEmp.DataTextField = "descripcion";
            ddlPerfilEmp.DataBind();

        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            UsuarioNegocio negocio = new UsuarioNegocio();
            Usuario nuevoUser = new Usuario();
            try
            {
                if (!ValidoControlTextBox(txtnombre))
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

                nuevoUser.Nombres = txtnombre.Text;
                nuevoUser.Apellidos = txtApellido.Text;
                nuevoUser.NroDocumento = txtDni.Text;
                nuevoUser.Estado = chbEstado1.Checked;
                //desplegable
                nuevoUser.idTipoPerfil = int.Parse(ddlPerfilEmp.SelectedValue);
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

        protected void btnVerEmp_Click(object sender, EventArgs e)
        {
            UsuarioNegocio usuarioNegocio = new UsuarioNegocio();
            List<Empleado> empleadosBuscados = usuarioNegocio.Empleados();

            dgEmpleados.DataSource = empleadosBuscados;
            dgEmpleados.DataBind();
        }
    }
}