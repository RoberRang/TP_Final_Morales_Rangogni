using AccesoModeloBaseDatos.Dominio;
using AccesoModeloBaseDatos.Modelos;
using ModeloDeNegocio;
using ModeloDeNegocio.Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TP_Final_Morales_Rangogni.DominioWeb;

namespace TP_Final_Morales_Rangogni
{
    public partial class EmpleadoWeb : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Session["EmpleadoLogin"] == null)
                {
                    Session.Add("MensajeError", "Acceso sin autorización!");
                    Response.Redirect("ErrorWeb.aspx", false);
                }
                else
                {
                    Empleado empleado = (Empleado)Session["EmpleadoLogin"];
                    ValidarEmpleadoLogin(empleado);
                }
                if (!IsPostBack)
                {
                    buscarTipoPerfil();
                    buscarJornadas();
                    buscarEmpleados();
                }
            }
            catch (Exception ex)
            {
                Session.Add("MensajeError", ex.ToString());
                Response.Redirect("ErrorWeb.aspx", false);

            }
        }

        private void buscarJornadas()
        {
            try
            {
                JornadaNegocio jornadaNegocio = new JornadaNegocio();
                ddlJornada.DataSource = jornadaNegocio.ListarJornadas();
                ddlJornada.DataValueField = "IdJornada";
                ddlJornada.DataTextField = "descripcion";
                ddlJornada.DataBind();
            }
            catch (Exception ex)
            {
                Session.Add("MensajeError", ex.ToString());
                Response.Redirect("ErrorWeb.aspx", false);
            }            
        }

        private void ValidarEmpleadoLogin(Empleado empleado)
        {
            try
            {
                if (empleado.idPerfil != 1)
                    throw new Exception("El Usuario: " + empleado.Nombres + ", " + empleado.Apellidos + " sin acceso!");
            }
            catch (Exception ex)
            {

                Session.Add("MensajeError", ex.Message);
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
                if (txtPass.Text != txtPass2.Text)
                {
                    txtPass.Attributes.Add("placeholder", "Las contraseñas deben ser iguales");
                    txtPass.Focus();
                    txtPass2.Attributes.Add("placeholder", "Las contraseñas deben ser iguales");
                    txtPass2.Focus();
                    return;
                }
                nuevoUser.Nombres = txtnombre.Text;
                nuevoUser.Apellidos = txtApellido.Text;
                nuevoUser.NroDocumento = txtDni.Text;
                nuevoUser.Estado = chbEstado1.Checked;
                //desplegable
                nuevoUser.idPerfil = int.Parse(ddlPerfilEmp.SelectedValue);
                nuevoUser.idJornada = int.Parse(ddlJornada.SelectedValue);
                nuevoUser.User = txtUser.Text;
                nuevoUser.Password = txtPass.Text;

                ///CREAR METODO negocio.agregar(nuevo);
                if (negocio.AltaUsuario(nuevoUser))
                {
                    LimpiarControlesAltaEmpleado();
                    ///cartel alta de empleado completa
                }
            }
            catch (Exception ex)
            {
                Session.Add("MensajeError", ex.ToString());
                Response.Redirect("ErrorWeb.aspx", false);
            }
        }
        private void LimpiarControlesAltaEmpleado()
        {
            txtnombre.Text = "";
            txtApellido.Text = "";
            txtDni.Text="";
            //desplegable
            ddlPerfilEmp.SelectedIndex = 0;
            ddlJornada.SelectedIndex= 0;
            txtUser.Text="";
            txtPass.Text="";
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
            buscarEmpleados();
        }
        protected void buscarEmpleados()
        {
            UsuarioNegocio usuarioNegocio = new UsuarioNegocio();
            List<Empleado> empleadosBuscados = usuarioNegocio.Empleados();
            Session.Add("empleados", empleadosBuscados);
            dgEmpleados.DataSource = empleadosBuscados;
            dgEmpleados.DataBind();
        }

        protected void dgEmpleados_SelectedIndexChanged(object sender, EventArgs e)
        {                     
            int id = (int)dgEmpleados.SelectedDataKey.Value;
            mvwEmpleados.ActiveViewIndex = 2;            
            List<Empleado> filtros = (List<Empleado>)Session["empleados"];
            Empleado filtroEmpleado = filtros.Find(x => x.ID.Equals(id));
            
            txtEdNombre.Text = filtroEmpleado.Nombres;
            txtEdApellido.Text = filtroEmpleado.Apellidos;
            txtEdDni.Text = filtroEmpleado.NroDocumento;
           



        }

        protected void txtfiltro_TextChanged(object sender, EventArgs e)
        {
            List<Empleado> filtro = (List< Empleado>)Session["empleados"];
            List<Empleado> filtroRapido = filtro.FindAll(x => x.Nombres.ToUpper().Contains(txtfiltro.Text.ToUpper()));
            dgEmpleados.DataSource = filtroRapido;
            dgEmpleados.DataBind();
        }

        protected void mnEmpleados_MenuItemClick(object sender, MenuEventArgs e)
        {
            int index = Convert.ToInt32(e.Item.Value);
            mvwEmpleados.ActiveViewIndex = index;
        }
    }
}