using AccesoModeloBaseDatos.Dominio;
using AjaxControlToolkit.HtmlEditor;
using ModeloDeNegocio.Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Services.Description;
using System.Web.UI;
using System.Web.UI.WebControls;
using TP_Final_Morales_Rangogni.DominioWeb;

namespace TP_Final_Morales_Rangogni
{
    public partial class PacienteWeb : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Session["EmpleadoLogin"] == null)
                    throw new Exception("Acceso erroneo!");
                else
                {
                    Empleado empleado = (Empleado)Session["EmpleadoLogin"];
                    ValidarEmpleadoLogin(empleado);
                }
                if (!IsPostBack)
                {
                    buscarPacientesWeb();
                }
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
                if (empleado.idPerfil == 3)
                    throw new Exception("El Usuario: " + empleado.Nombres + ", " + empleado.Apellidos + " sin acceso!");
            }
            catch (Exception ex)
            {
                Session.Add("MensajeError", ex.Message);
                Response.Redirect("ErrorWeb.aspx", false);
            }
        }
        protected void btnAcept_Click(object sender, EventArgs e)
        {
            Button btnFuncion = (Button)sender;
            PacienteNegocio negocio = new PacienteNegocio();
            Paciente nuevoPaciente = new Paciente();
            try
            {
                if (btnFuncion.ID != "btnEditar")
                {
                    if (!ValidoControlTextBox(txtnombre))
                        return;
                    if (!ValidoControlTextBox(txtApellido))
                        return;
                    if (!ValidoControlTextBox(txtDni))
                        return;
                    if (!ValidoControlTextBox(txtEmail))
                        return;
                    if (!ValidoControlTextBox(txtFecha))
                        return;

                    nuevoPaciente.Nombres = txtnombre.Text;
                    nuevoPaciente.Apellidos = txtApellido.Text;
                    nuevoPaciente.NroDocumento = txtDni.Text;
                    nuevoPaciente.Telefono = txtTelefono.Text;
                    nuevoPaciente.Email = txtEmail.Text;
                    nuevoPaciente.FechaNacimiento = Convert.ToDateTime(txtFecha.Text);
                    nuevoPaciente.FechaAlta = DateTime.Today;
                    if (ddlEstado.Text == "Activo")
                        nuevoPaciente.Estado = true;
                    else
                        nuevoPaciente.Estado = false;
                    nuevoPaciente.Sexo = ddlGenero.Text;
                }
                else
                {
                    if (!ValidoControlTextBox(txtEdNombre))
                        return;
                    if (!ValidoControlTextBox(txtEdApellido))
                        return;
                    if (!ValidoControlTextBox(txtEdDni))
                        return;
                    if (!ValidoControlTextBox(txtEdEmail))
                        return;
                    if (!ValidoControlTextBox(txtEdFnac))
                        return;
                    nuevoPaciente.IdPaciente = Convert.ToInt32(IdPaciente.Text);
                    nuevoPaciente.Nombres = txtEdNombre.Text;
                    nuevoPaciente.Apellidos = txtEdApellido.Text;
                    nuevoPaciente.NroDocumento = txtEdDni.Text;
                    nuevoPaciente.Telefono = txtEdtelefono.Text;
                    nuevoPaciente.Email = txtEdEmail.Text;
                    nuevoPaciente.FechaNacimiento = Convert.ToDateTime(txtEdFnac.Text);
                    if (ddlEdEstado.Text == "Activo")
                        nuevoPaciente.Estado = true;
                    else
                        nuevoPaciente.Estado = false;
                    nuevoPaciente.Sexo = ddlEdGenero.Text;
                }
                if (btnFuncion.ID == "btnEditar")
                {
                    negocio.ModificarPaciente(nuevoPaciente);
                    buscarPacientesWeb();
                    limpiarControlesEditar();
                    mvwPacientes.ActiveViewIndex = 0;
                }

                if (btnFuncion.ID != "btnEditar")
                {
                    negocio.AltaPaciente(nuevoPaciente);
                    buscarPacientesWeb();
                    limpiarControles();
                }

            }
            catch (Exception ex)
            {
                Session.Add("MensajeError", ex.ToString());
                Response.Redirect("ErrorWeb.aspx", false);

            }
        }
        private void limpiarControlesEditar()
        {
            txtEdNombre.Text = string.Empty;
            txtEdApellido.Text = string.Empty;
            txtEdDni.Text = string.Empty;
            txtEdtelefono.Text = string.Empty;
            txtEdEmail.Text = string.Empty;
            txtEdFnac.Text = string.Empty;
            ddlEdEstado.Text = "Activo";
            ddlEdGenero.Text = "Masculino";
        }
        private void limpiarControles()
        {
            txtnombre.Text = string.Empty;
            txtApellido.Text = string.Empty;
            txtDni.Text = string.Empty;
            txtTelefono.Text = string.Empty;
            txtEmail.Text = string.Empty;
            txtFecha.Text = string.Empty;
            ddlEstado.Text = "Activo";
            ddlGenero.Text = "Masculino";
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
        protected void dgvPacientes_SelectedIndexChanged(object sender, EventArgs e)
        {
            int id = (int)dgvPacientes.SelectedDataKey.Value;
            mvwPacientes.ActiveViewIndex = 2;
            List<ModeloPacienteWeb> filtro = (List<ModeloPacienteWeb>)Session["pacientesWeb"];
            ModeloPacienteWeb filtroRapido = filtro.Find(x => x.IdPaciente.Equals(id));
            IdPaciente.Text = id.ToString();
            txtEdNombre.Text = filtroRapido.Nombres;
            txtEdApellido.Text = filtroRapido.Apellidos;
            txtEdDni.Text = filtroRapido.NroDocumento;
            txtEdEmail.Text = filtroRapido.Email;
            txtEdtelefono.Text = filtroRapido.Telefono;
            txtEdFnac.Text = Convert.ToDateTime(filtroRapido.FechaNacimiento).ToString("yyyy-MM-dd");
            ddlEdGenero.Text = filtroRapido.Sexo;
            ddlEdEstado.Text = filtroRapido.Estado;

        }
        protected void filtro_TextChanged(object sender, EventArgs e)
        {
            List<ModeloPacienteWeb> filtro = (List<ModeloPacienteWeb>)Session["pacientesWeb"];
            List<ModeloPacienteWeb> filtroRapido = filtro.FindAll(x => x.Nombres.ToUpper().Contains(txtfiltro.Text.ToUpper()));
            dgvPacientes.DataSource = filtroRapido;
            dgvPacientes.DataBind();
        }
        protected void buscarPacientesWeb()
        {
            PacienteNegocio pacienteNegocio = new PacienteNegocio();
            List<ModeloPacienteWeb> pacientesBuscados = new List<ModeloPacienteWeb>();
            foreach (Paciente paciente in pacienteNegocio.Pacientes())
            {
                ModeloPacienteWeb modeloPaciente = new ModeloPacienteWeb(paciente);
                pacientesBuscados.Add(modeloPaciente);
            }
            Session.Add("pacientesWeb", pacientesBuscados);
            dgvPacientes.DataSource = pacientesBuscados;
            dgvPacientes.DataBind();

        }
        protected void mnPaciente_MenuItemClick(object sender, MenuEventArgs e)
        {
            int index = Convert.ToInt32(e.Item.Value);
            if (e.Item.Text.Equals("Editar Paciente"))
                return;
            mvwPacientes.ActiveViewIndex = index;
        }
        protected void txtFiltroApellido_TextChanged(object sender, EventArgs e)
        {
            List<ModeloPacienteWeb> filtro = (List<ModeloPacienteWeb>)Session["pacientesWeb"];
            List<ModeloPacienteWeb> filtroRapido = filtro.FindAll(x => x.Apellidos.ToUpper().Contains(txtFiltroApellido.Text.ToUpper()));
            dgvPacientes.DataSource = filtroRapido;
            dgvPacientes.DataBind();

        }
        protected void txtFiltroDni_TextChanged(object sender, EventArgs e)
        {
            List<ModeloPacienteWeb> filtro = (List<ModeloPacienteWeb>)Session["pacientesWeb"];
            List<ModeloPacienteWeb> filtroRapido = filtro.FindAll(x => x.NroDocumento.ToUpper().Contains(txtFiltroDni.Text.ToUpper()));
            dgvPacientes.DataSource = filtroRapido;
            dgvPacientes.DataBind();
        }
        protected void btnLimpiarFiltro_Click(object sender, EventArgs e)
        {
            txtfiltro.Text = "";
            txtFiltroApellido.Text = "";
            txtFiltroDni.Text = "";
            buscarPacientesWeb();
        }
    }
}