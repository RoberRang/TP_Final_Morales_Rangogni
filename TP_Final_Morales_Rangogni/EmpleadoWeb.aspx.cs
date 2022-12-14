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
            Button btnFuncion = (Button)sender;
            UsuarioNegocio negocio = new UsuarioNegocio();
            Usuario nuevoUser = new Usuario();
            try
            {
                if (btnFuncion.ID != "btnEditar")
                {
                    nuevoUser = nuevoEmpleado();
                    if (nuevoUser == null)
                        return;
                  
                    if (negocio.AltaUsuario(nuevoUser))
                    {
                        LimpiarControlesAltaEmpleado();   
                        buscarEmpleados();
                        mvwEmpleados.ActiveViewIndex = 0;
                    }
                }
                else
                {   
                    Usuario usuario = EditarEmpleado();
                    if (usuario == null)
                        throw new Exception("No se cargaron los datos del usuario");
                    if (negocio.ModificarUsuario(usuario))
                    {
                        LimpiarControlesEdicionEmpleado();  
                        buscarEmpleados();
                        mvwEmpleados.ActiveViewIndex = 0;
                    }
                }
            }
            catch (Exception ex)
            {
                Session.Add("MensajeError", ex.ToString());
                Response.Redirect("ErrorWeb.aspx", false);
            }
        }
        private Usuario EditarEmpleado()
        {   
            Usuario editUser = new Usuario();
            if (!ValidoControlTextBox(txtEdNombre))
                return null;
            if (!ValidoControlTextBox(txtEdApellido))
                return null;
            if (!ValidoControlTextBox(txtEdDni))
                return null;
            if (!ValidoControlTextBox(txtEdUsuario))
                return null;
            if (!ValidoControlTextBox(txtEdPass))
                return null;
            if (!ValidoControlTextBox(txtEdPass2))
                return null;
            if (txtEdPass.Text != txtEdPass2.Text)
            {
                txtEdPass.Attributes.Add("placeholder", "Las contraseñas deben ser iguales");
                txtEdPass.Focus();
                txtEdPass2.Attributes.Add("placeholder", "Las contraseñas deben ser iguales");
                txtEdPass2.Focus();
                return null;
            }
            editUser.Nombres = txtEdNombre.Text;
            editUser.Apellidos = txtEdApellido.Text;
            editUser.NroDocumento = txtEdDni.Text;
            editUser.ID = Convert.ToInt32(lblIdEdUser.Text);
            editUser.IdEmpleado = editUser.ID;
            editUser.IdUsuario = editUser.ID;
            editUser.Estado = ddlEdEstado.Text.Equals("Activo") ? true: false;
            editUser.idPerfil = int.Parse(ddlEdPerfil.SelectedValue);
            editUser.idJornada = int.Parse(ddlEdJornada.SelectedValue);
            editUser.User = txtEdUsuario.Text;
            editUser.Password = txtEdPass.Text;
            return editUser;

        }
        private Usuario nuevoEmpleado()
        {
            Usuario nuevoUser = new Usuario();
            if (!ValidoControlTextBox(txtnombre))
                return null;
            if (!ValidoControlTextBox(txtApellido))
                return null;
            if (!ValidoControlTextBox(txtDni))
                return null;
            if (!ValidoControlTextBox(txtUser))
                return null;
            if (!ValidoControlTextBox(txtPass))
                return null;
            if (!ValidoControlTextBox(txtPass2))
                return null;
            if (txtPass.Text != txtPass2.Text)
            {
                txtPass.Attributes.Add("placeholder", "Las contraseñas deben ser iguales");
                txtPass.Focus();
                txtPass2.Attributes.Add("placeholder", "Las contraseñas deben ser iguales");
                txtPass2.Focus();
                return null;
            }
            nuevoUser.Nombres = txtnombre.Text;
            nuevoUser.Apellidos = txtApellido.Text;
            nuevoUser.NroDocumento = txtDni.Text;
            nuevoUser.Estado = ddlEdEstado.Text.Equals("Activo") ? true : false;
            nuevoUser.idPerfil = int.Parse(ddlPerfilEmp.SelectedValue);
            nuevoUser.idJornada = int.Parse(ddlJornada.SelectedValue);
            nuevoUser.User = txtUser.Text;
            nuevoUser.Password = txtPass.Text;
            return nuevoUser;
        }
        private void LimpiarControlesAltaEmpleado()
        {
            txtnombre.Text = "";
            txtApellido.Text = "";
            txtDni.Text = "";        
            ddlPerfilEmp.SelectedIndex = 0;
            ddlJornada.SelectedIndex = 0;
            txtUser.Text = "";
            txtPass.Text = "";
        }
        private void LimpiarControlesEdicionEmpleado()
        {
            txtEdNombre.Text = "";
            txtEdApellido.Text = "";
            txtEdDni.Text = "";            
            ddlEdPerfil.SelectedIndex = 0;
            ddlEdJornada.SelectedIndex = 0;
            txtEdUsuario.Text = "";
            txtEdPass.Text = "";
            txtEdPass2.Text = "";
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
            txtfiltro.Text = "";
            txtFiltroApellido.Text = "";
            txtFiltroDni.Text = "";
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

            List<Empleado> filtros = (List<Empleado>)Session["empleados"];
            Empleado filtroEmpleado = filtros.Find(x => x.ID.Equals(id));
            txtEdNombre.Text = filtroEmpleado.Nombres;
            txtEdApellido.Text = filtroEmpleado.Apellidos;
            txtEdDni.Text = filtroEmpleado.NroDocumento;
            UsuarioNegocio usuarioNegocio = new UsuarioNegocio();
            Usuario usuario = usuarioNegocio.DatosUsuarioLogin(id);
            lblIdEdUser.Text = id.ToString();
            txtEdUsuario.Text = usuario.User;
            txtEdPass.Text = usuario.Password;
            JornadaNegocio jornadaNegocio = new JornadaNegocio();
            ddlEdJornada.DataSource = jornadaNegocio.ListarJornadas();
            ddlEdJornada.DataValueField = "IdJornada";
            ddlEdJornada.DataTextField = "descripcion";
            ddlEdJornada.DataBind();
            ddlEdJornada.SelectedValue = filtroEmpleado.idJornada.ToString();
            PerfilNegocio perfilNegocio = new PerfilNegocio();
            ddlEdPerfil.DataSource = perfilNegocio.Perliles();
            ddlEdPerfil.DataValueField = "idPerfil";
            ddlEdPerfil.DataTextField = "descripcion";
            ddlEdPerfil.DataBind();
            ddlEdPerfil.SelectedValue = filtroEmpleado.idPerfil.ToString();
            mvwEmpleados.ActiveViewIndex = 2;

        }
        protected void txtfiltro_TextChanged(object sender, EventArgs e)
        {
            List<Empleado> filtro = (List<Empleado>)Session["empleados"];
            List<Empleado> filtroRapido = filtro.FindAll(x => x.Nombres.ToUpper().Contains(txtfiltro.Text.ToUpper()));
            dgEmpleados.DataSource = filtroRapido;
            dgEmpleados.DataBind();
        }
        protected void mnEmpleados_MenuItemClick(object sender, MenuEventArgs e)
        {
            int index = Convert.ToInt32(e.Item.Value);
            if (e.Item.Text.Equals("Editar Empleado"))
                return;
            mvwEmpleados.ActiveViewIndex = index;
        }
        protected void btnEditar_Click(object sender, EventArgs e)
        {
            btnAceptar_Click(sender, e);
        }
        protected void txtFiltroApellido_TextChanged(object sender, EventArgs e)
        {
            List<Empleado> filtro = (List<Empleado>)Session["empleados"];
            List<Empleado> filtroRapido = filtro.FindAll(x => x.Apellidos.ToUpper().Contains(txtFiltroApellido.Text.ToUpper()));
            dgEmpleados.DataSource = filtroRapido;
            dgEmpleados.DataBind();
        }
        protected void txtFiltroDni_TextChanged(object sender, EventArgs e)
        {
            List<Empleado> filtro = (List<Empleado>)Session["empleados"];
            List<Empleado> filtroRapido = filtro.FindAll(x => x.NroDocumento.ToUpper().Contains(txtFiltroDni.Text.ToUpper()));
            dgEmpleados.DataSource = filtroRapido;
            dgEmpleados.DataBind();

        }
    }
}