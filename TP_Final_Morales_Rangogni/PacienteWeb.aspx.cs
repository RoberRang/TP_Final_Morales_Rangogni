using AccesoModeloBaseDatos.Dominio;
using ModeloDeNegocio.Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
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

        }

        protected void btnAcept_Click(object sender, EventArgs e)
        {
            PacienteNegocio negocio = new PacienteNegocio();
            Paciente nuevoPaciente = new Paciente();
            try
            {
                if (txtnombre.Text.Equals("") || txtApellido.Text.Equals("") || txtDni.Text.Equals("") || txtEmail.Text.Equals("") || txtTelefono.Text.Equals("") || txtFecha.Text.Equals(""))
                {
                    ValidarControlPaciente();
                    return;
                }

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

                    ///cartel alta de pacinete completa y limpiar controles                

                }

            }
            catch (Exception ex)
            {
                Session.Add("MensajeError", ex.ToString());
                Response.Redirect("ErrorWeb.aspx", false);

            }
        }

        private void ValidarControlPaciente()
        {
            txtnombre.Text = "";
            txtnombre.Attributes.Add("placeholder", "Debe completar los campos obligatorios");
            txtnombre.Focus();            
            
            txtApellido.Text = "";
            txtApellido.Attributes.Add("placeholder", "Debe completar los campos obligatorios");
            txtApellido.Focus();

            txtDni.Text = "";
            txtDni.Attributes.Add("placeholder", "Debe completar los campos obligatorios");
            txtDni.Focus();

            txtTelefono.Text = "";
            txtTelefono.Attributes.Add("placeholder", "Debe completar los campos obligatorios");
            txtTelefono.Focus();

            txtEmail.Text = "";
            txtEmail.Attributes.Add("placeholder", "Debe completar los campos obligatorios");
            txtEmail.Focus();

            txtFecha.Text = "";
            txtFecha.Attributes.Add("placeholder", "Debe completar los campos obligatorios");
            txtFecha.Focus();
        }

        protected void btnVerPac_Click(object sender, EventArgs e)
        {
            PacienteNegocio pacienteNegocio = new PacienteNegocio();
            List<ModeloPacienteWeb> pacientesBuscados = new List<ModeloPacienteWeb>();
            foreach (Paciente paciente in pacienteNegocio.Pacientes())
            {
                ModeloPacienteWeb modeloPaciente = new ModeloPacienteWeb(paciente);
                pacientesBuscados.Add(modeloPaciente);
            }

            dgvPacientes.DataSource = pacientesBuscados;
            dgvPacientes.DataBind();
        }

    }
}