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

                    ///cartel alta de pacinete completa y limpiar controles                

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

        protected void dgvPacientes_SelectedIndexChanged(object sender, EventArgs e)
        {
            string id= dgvPacientes.SelectedDataKey.Value.ToString();
            Response.Redirect("PacienteWeb.aspx?id=" + id);// SI MANDO ID VOY A MODIFICAR SI NO VIENE ES POR QUE DOY DE ALTA
        }
    }
}