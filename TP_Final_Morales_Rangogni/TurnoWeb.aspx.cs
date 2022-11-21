using AccesoModeloBaseDatos.Dominio;
using AccesoModeloBaseDatos.Modelos;
using ModeloDeNegocio;
using ModeloDeNegocio.Negocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
            {
                CargarDropDawnListEspecialidad();
                CargarFecha();
            }
        }

        private void CargarFecha()
        {
            txtFechaTurno.Text = DateTime.Now.ToString("d");
        }

        protected void btnAcept_Click(object sender, EventArgs e)
        {
            TurnoNegocio turnoNegocio = new TurnoNegocio();
            Turno turno = ControlCamposCompletosTurno();
            if (!turnoNegocio.GrabarTurno(turno))
            {
                Session.Add("MensajeError", "El Turno no se pudo ingresar");
                Response.Redirect("ErrorWeb.aspx", false);
            }
            EnviarTurnoCorreo(turno);

            LimpiarControles();
        }

        private void LimpiarControles()
        {
            txtDni.Text = "";
            txtnombre.Text = "";
            txtApellido.Text = "";
            txtTelefono.Text = "";
            txtEmail.Text = "";
            txtCantTurnos.Text = "";
            txtObservaciones.Text = "";
            CargarDropDawnListEspecialidad();
            LimpiarMedico();
        }

        private void LimpiarMedico()
        {
            ddlMedico.Items.Clear();
            ddlMedico.DataSource = null;
            ddlMedico.DataBind();
            ddlMedico.Items.Insert(0, new ListItem("-- Sin Espcialista --", "0"));
            return;
        }
        private void LimpiarHorasTurnos()
        {
            ddlHorasTurnos.Items.Clear();
            ddlHorasTurnos.DataSource = null;
            ddlHorasTurnos.DataBind();
            ddlHorasTurnos.Items.Insert(0, new ListItem(" Elejir ", "0"));
            return;
        }

        private Turno ControlCamposCompletosTurno()
        {
            Turno nuevoTurno = null;
            try
            {
                PacienteNegocio pacienteNegocio = new PacienteNegocio();
                Paciente paciente = pacienteNegocio.BuscarPaciente(txtDni.Text);
                if (paciente == null)
                    return null;

                string fechaTurno = txtFechaTurno.Text.Trim();
                fechaTurno = Convert.ToDateTime(fechaTurno).ToString("yyyy-MM-dd ");
                int horaTurno = Convert.ToInt32(ddlHorasTurnos.SelectedValue);
                fechaTurno += Convert.ToInt32(horaTurno).ToString().Length > 1 ? horaTurno.ToString() + ":00:00" : "0" + horaTurno.ToString() + ":00:00";

                nuevoTurno = new Turno();
                nuevoTurno.IdPaciente = paciente.IdPaciente;
                nuevoTurno.FechaReserva = Convert.ToDateTime(fechaTurno);
                nuevoTurno.Hora = Convert.ToInt32(ddlHorasTurnos.SelectedValue);
                nuevoTurno.IdEmpleado = Convert.ToInt32(ddlMedico.SelectedValue);
                nuevoTurno.IdSituacion = 1;
                nuevoTurno.Estado = true;
                nuevoTurno.Observacion = txtObservaciones.Text.Trim();

            }
            catch (Exception ex)
            {
                Session.Add("MensajeError", ex.ToString());
                Response.Redirect("ErrorWeb.aspx", false);
            }
            return nuevoTurno;
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
                ddlEspecialidad.Items.Insert(0, new ListItem("-- Seleccione --", "0"));
                ddlEspecialidad.SelectedIndex = 0;
                Session.Add("Especialiadades", especialidades);
            }
            catch (Exception ex)
            {
                Session.Add("MensajeError", ex.ToString());
                Response.Redirect("ErrorWeb.aspx", false);
            }
        }

        private void BuscarPaciente()
        {
            try
            {
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
                int idEpecialidad = Convert.ToInt32(ddlEspecialidad.SelectedValue);
                if (idEpecialidad == 0)
                    return;
                List<Medico> medicos = medicoNegocio.MedicosEspecialidad(idEpecialidad);
                if (medicos.Count == 0)
                {
                    LimpiarMedico();
                    return;
                }
                ddlMedico.DataSource = medicos;
                ddlMedico.DataValueField = "ID";
                ddlMedico.DataTextField = "Apellidos";
                ddlMedico.DataBind();
                ddlMedico.Items.Insert(0, new ListItem("-- Seleccione --", "0"));
            }
            catch (Exception ex)
            {
                Session.Add("MensajeError", ex.ToString());
                Response.Redirect("ErrorWeb.aspx", false);
            }
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            if (txtDni.Text.Equals(""))
            {
                txtDni.Attributes.Add("placeholder", "El campo no debe quedar incompleto");
                txtDni.Focus();
                return;
            }
            BuscarPaciente();
        }

        protected void ddlMedico_SelectedIndexChanged(object sender, EventArgs e)
        {

            txtFechaTurno.Text = DateTime.UtcNow.ToString("d");
            txtFechaTurno.DataBind();
            txtFechaTurno.Focus();
        }

        protected void btnVerTurnos_Click(object sender, EventArgs e)
        {
            TurnoNegocio turnoNegocio = new TurnoNegocio();
            try
            {
                List<int> horasTurnos = turnoNegocio.TurnosMedicoFecha(Convert.ToInt32(ddlMedico.SelectedValue), Convert.ToDateTime(txtFechaTurno.Text.Trim()));
                txtCantTurnos.Text = horasTurnos.Count.ToString();
                txtCantTurnos.DataBind();
                txtCantTurnos.Focus();
                ddlHorasTurnos.DataSource = horasTurnos;
                ddlHorasTurnos.DataBind();
                ddlHorasTurnos.Items.Insert(0, new ListItem(" Elejir ", "0"));
            }
            catch (Exception ex)
            {
                Session.Add("MensajeError", ex.ToString());
                Response.Redirect("ErrorWeb.aspx", false);
            }

        }
        private void EnviarTurnoCorreo(Turno turno)
        {
            ///Para probar que el envio fue correcto ingresar a gmail user: progamationiiigmail.com y pass: programacion3
            string fechaturno = turno.FechaReserva.ToString();
            string horaTurno = turno.Hora.ToString();
            string nombrePaciente = txtnombre.Text;
            string emailDestino = txtEmail.Text;
            EmpleadoADO empleadoADO = new EmpleadoADO(ConexionStringDB.ConexionBase());
            Empleado empleado = empleadoADO.BuscarEmpleado(Convert.ToInt32(ddlMedico.SelectedValue));
            string nombreMedico = empleado.Nombres;
            string apellidoMedico = empleado.Apellidos;
            EmailService envio = new EmailService();
            envio.armarcorreo(emailDestino, nombrePaciente, fechaturno, nombreMedico, apellidoMedico, horaTurno);
            try
            {
                envio.enviarEmail();
            }
            catch (Exception ex)
            {

                Session.Add("MensajeError", ex.ToString());
                Response.Redirect("ErrorWeb.aspx", false);
            }
        }
    }
}