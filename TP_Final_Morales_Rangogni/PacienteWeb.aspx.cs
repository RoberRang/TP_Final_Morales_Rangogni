using AccesoModeloBaseDatos.Dominio;
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
            if (!IsPostBack)
            {
                buscarPacientesWeb();
            }           
          
        }

        protected void btnAcept_Click(object sender, EventArgs e)
        {
            PacienteNegocio negocio = new PacienteNegocio();
            Paciente nuevoPaciente = new Paciente();
            try
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
                nuevoPaciente.Estado = chbEstado.Checked;
                nuevoPaciente.Imagen = txtImagen.Text;
                nuevoPaciente.Sexo = ddlGenero.Text;


                if (negocio.AltaPaciente(nuevoPaciente))
                {   
                    buscarPacientesWeb();
                    ///cartel alta de pacinete completa y limpiar controles                
                    limpiarControles();
                }
                else
                {
                    ///cartel de el paciente ya existe, desea editarlo?,  mostrar el paciente y dar opcion de editarlo
                    Response.Redirect("ErrorWeb.aspx", false);
                }
            }
            catch (Exception ex)
            {
                Session.Add("MensajeError", ex.ToString());
                Response.Redirect("ErrorWeb.aspx", false);

            }
        }

        private void limpiarControles()
        {
            txtnombre.Text = string.Empty;
            txtApellido.Text = string.Empty;
            txtDni.Text = string.Empty;
            txtTelefono.Text = string.Empty;
            txtEmail.Text = string.Empty;
            txtFecha.Text = string.Empty;
            chbEstado.Checked = true;
            txtImagen.Text = string.Empty;
            ddlGenero.Text = string.Empty;
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

        protected void btnVerPac_Click(object sender, EventArgs e)
        {

        }

        protected void dgvPacientes_SelectedIndexChanged(object sender, EventArgs e)
        {
            int id = (int)dgvPacientes.SelectedDataKey.Value;
            mvwPacientes.ActiveViewIndex = 2;
            List<ModeloPacienteWeb> filtro = (List<ModeloPacienteWeb>)Session["pacientesWeb"];
            ModeloPacienteWeb filtroRapido = filtro.Find(x => x.IdPaciente.Equals(id));
            txtEdNombre.Text = filtroRapido.Nombres;
            txtEdApellido.Text = filtroRapido.Apellidos;
            txtEdDni.Text = filtroRapido.NroDocumento;
            txtEdEmail.Text= filtroRapido.Email;           
            txtEdtelefono.Text=filtroRapido.Telefono;
            txtEdImagen.Text = filtroRapido.Imagen;
            txtEdFnac.Text = filtroRapido.FechaNacimiento;
            ddlEdGenero.Text = filtroRapido.Sexo;
            if (filtroRapido.Estado == "Activo")
            {
                chbEdEstado.Checked = true;
            }
            else
            {
                chbEdEstado.Checked = false;
            }

            ///Response.Redirect("PacienteWeb#NuevoPaciente?id=" + id);// SI MANDO ID VOY A MODIFICAR SI NO VIENE ES POR QUE DOY DE ALTA
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
            mvwPacientes.ActiveViewIndex = index;
        }

    }
}

