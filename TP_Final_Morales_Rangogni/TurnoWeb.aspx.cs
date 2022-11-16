using AccesoModeloBaseDatos.Dominio;
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
    public partial class TurnoWeb : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                CargarDropDawnListEspecialidad();
        }

        protected void btnAcept_Click(object sender, EventArgs e)
        {

        }

        private void CargarDropDawnListEspecialidad()
        {
            try
            {
                EspecialidadNegocio especialidadNegocio = new EspecialidadNegocio();
                List<Especialidad> especialidades = especialidadNegocio.Especialidades();
                ddlEspecialidad.DataSource = especialidades;
                ddlEspecialidad.DataValueField = "IdEspecialidad";
                ddlEspecialidad.DataTextField = "Descripcion";
                ddlEspecialidad.DataBind();
                Session.Add("Especialiadades", especialidades);
            }
            catch (Exception ex)
            {
                Session.Add("MensajeError", ex.ToString());
                Response.Redirect("ErrorWeb.aspx", false);
            }
        }

        protected void btnBuscarPaciente_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtDni.Text.Equals(""))
                {
                    txtDni.Attributes.Add("placeholder", "El campo no debe quedar incompleto");
                    txtDni.Focus();
                }
                    
                PacienteNegocio pacienteNegocio = new PacienteNegocio();
                Paciente paciente = pacienteNegocio.BuscarPaciente(txtDni.Text.Trim());

                if (Session["PacienteTurno"] != null)
                    Session.Remove("PacienteTurno");
                Session.Add("PacienteTurno", paciente);

                if (paciente != null)
                    LlenarControlesPaciente(paciente);

            }
            catch (Exception ex)
            {
                Session.Add("MensajeError", ex.ToString());
                Response.Redirect("ErrorWeb.aspx", false);
            }
        }

        private void LlenarControlesPaciente(Paciente paciente)
        {
            txtDni.Text = paciente.NroDocumento;
            txtnombre.Text = paciente.Nombres;
            txtApellido.Text = paciente.Apellidos;
            txtTelefono.Text = paciente.Telefono;
            txtEmail.Text = paciente.Email;
            
        }

        protected void ddlEspecialidad_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                MedicoNegocio medicoNegocio = new MedicoNegocio();
                List<Medico> medicos = medicoNegocio.Medicos();
                int idEpecialidad = Convert.ToInt32(ddlEspecialidad.SelectedValue);
                List<Medico> medicosCombo =  medicos.FindAll(x => x.idTipoEspecialidad.Equals(idEpecialidad));
                ddlMedico.DataSource = medicosCombo;
                ddlMedico.DataValueField = "ID";
                ddlMedico.DataTextField = "Apellidos";
                ddlMedico.DataBind();
            }
            catch (Exception ex)
            {
                Session.Add("MensajeError", ex.ToString());
                Response.Redirect("ErrorWeb.aspx", false);
            }
        }

        protected void ddlEspecialidad_TextChanged(object sender, EventArgs e)
        {

        }
    }
}