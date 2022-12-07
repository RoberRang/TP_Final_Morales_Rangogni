using AccesoModeloBaseDatos.Dominio;
using AccesoModeloBaseDatos.Modelos;
using ModeloDeNegocio;
using ModeloDeNegocio.Negocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
                    CargarDropDawnListEspecialidad();
                    CargarFecha();
                    CargarGrillaTurnos();
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

        private void CargarFecha()
        {
            txtFechaTurno.Text = DateTime.Now.AddDays(1).ToString("yyyy-MM-dd");
            txtFechaGrd.Text = DateTime.Today.ToString("yyyy-MM-dd");
        }

        private void CargarGrillaTurnos()
        {
            try
            {
                TurnoNegocio turnoNegocio = new TurnoNegocio();
                ModeloGrillaTurnosWeb modeloGrillaTurnosWeb = new ModeloGrillaTurnosWeb();
                DateTime dFechaTurno;
                if (!IsPostBack || txtFechaGrd.Text.Equals(""))
                    dFechaTurno = DateTime.Today;
                else
                    dFechaTurno = Convert.ToDateTime(txtFechaGrd.Text);
                DataTable dtTurnos = turnoNegocio.DataTableTurnosFecha(dFechaTurno);
                List<ModeloTurnoWeb> gvTurnos = modeloGrillaTurnosWeb.ObtenerListaTurnosWebDataTable(dtTurnos);

                if (Session["TurnosGrdWeb"] != null)
                    Session.Remove("TurnosGrdWeb");

                Session.Add("TurnosGrdWeb", gvTurnos);
                dgvTurnos.DataSource = gvTurnos;
                dgvTurnos.DataBind();
            }
            catch (Exception ex)
            {
                Session.Add("MensajeError", ex.ToString());
                Response.Redirect("ErrorWeb.aspx", false);
            }
        }

        protected void btnAcept_Click(object sender, EventArgs e)
        {
            TurnoNegocio turnoNegocio = new TurnoNegocio();
            Turno turno = ControlCamposCompletosTurno();
            if (turno == null)
                return;
            if (!turnoNegocio.GrabarTurno(turno))
            {
                Session.Add("MensajeError", "El Turno no se pudo ingresar");
                Response.Redirect("ErrorWeb.aspx", false);
            }
            //EnviarTurnoCorreo(turno);

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
                    throw new Exception("No se cargo el paciente, compruebe los datos");

                string fechaTurno = txtFechaTurno.Text.Trim();
                fechaTurno = Convert.ToDateTime(fechaTurno).ToString("yyyy-MM-dd ");
                int horaTurno = Convert.ToInt32(ddlHorasTurnos.SelectedValue);
                fechaTurno += Convert.ToInt32(horaTurno).ToString().Length > 1 ? horaTurno.ToString() + ":00:00" : "0" + horaTurno.ToString() + ":00:00";

                nuevoTurno = new Turno();
                nuevoTurno.IdPaciente = paciente.IdPaciente;
                nuevoTurno.FechaReserva = Convert.ToDateTime(fechaTurno);
                nuevoTurno.Hora = Convert.ToInt32(ddlHorasTurnos.SelectedValue);
                nuevoTurno.IdMedico = Convert.ToInt32(ddlMedico.SelectedValue);
                nuevoTurno.IdEspecialidad = Convert.ToInt32(ddlEspecialidad.SelectedValue);
                nuevoTurno.IdSituacion = 1;
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

        private void BuscarPaciente(string dni = "")
        {
            try
            {
                PacienteNegocio pacienteNegocio = new PacienteNegocio();
                Paciente paciente = null;
                if (dni.Equals(""))
                    paciente = pacienteNegocio.BuscarPaciente(txtDni.Text.Trim());
                else
                    paciente = pacienteNegocio.BuscarPaciente(dni);

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
                int idEpecialidad = 0;
                DropDownList ddlWeb = (DropDownList)sender;
                idEpecialidad = Convert.ToInt32(ddlWeb.SelectedValue);

                if (idEpecialidad == 0)
                    return;
                List<Medico> medicos = medicoNegocio.MedicosEspecialidad(idEpecialidad);
                if (medicos.Count == 0)
                {
                    LimpiarMedico();
                    return;
                }
                if (ddlWeb.ID.Equals(ddlEspecialidad.ID))
                {
                    ddlMedico.DataSource = medicos;
                    ddlMedico.DataValueField = "ID";
                    ddlMedico.DataTextField = "Apellidos";
                    ddlMedico.DataBind();
                    ddlMedico.Items.Insert(0, new ListItem("-- Seleccione --", "0"));
                }
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
            txtFechaTurno.Text = DateTime.UtcNow.ToString("yyyy-MM-dd");
            txtFechaTurno.DataBind();
            txtFechaTurno.Focus();
        }

        protected void btnVerTurnos_Click(object sender, EventArgs e)
        {
            TurnoNegocio turnoNegocio = new TurnoNegocio();
            try
            {
                if (!ControlMedicoFecha())
                {
                    ddlMedico.Focus();
                    return;
                }
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

        private bool ControlMedicoFecha()
        {
            bool ok = false;
            if (ddlMedico.Items.Count > 0)
            {
                ok = Convert.ToInt32(ddlMedico.SelectedValue) > 0 ? true : false;
                ok = ok && !txtFechaTurno.Text.Equals("");
            }
            return ok;
        }

        private void EnviarTurnoCorreo(Turno turno)
        {
            ///Probamos con gmail  pass: programacion3 no funciona debido a que hace 3 meses gmail cambio esa funcionalidad que ofrecia
            ///El codigo de envios esta configurado para correo hotmail y user: frgputnalumnos@hotmail.com pass: robertojose1234 pero sigue dando error.
            ///"SocketException: Se produjo un error durante el intento de conexión ya que la parte conectada no respondió adecuadamente tras un periodo de tiempo, 
            ///o bien se produjo un error en la conexión establecida ya que el host conectado no ha podido responder 204.79.197.212:587"

            string fechaturno = turno.FechaReserva.ToString();
            string horaTurno = turno.Hora.ToString();
            string nombrePaciente = txtnombre.Text;
            string emailDestino = txtEmail.Text;
            EmpleadoADO empleadoADO = new EmpleadoADO(ConexionStringDB.ConexionBase());
            Empleado empleado = empleadoADO.BuscarEmpleado(Convert.ToInt32(ddlMedico.SelectedValue));
            string nombreMedico = empleado.Nombres;
            string apellidoMedico = empleado.Apellidos;
            EmailService envio = new EmailService("smtp.live.com", "frgputnalumnos@hotmail.com", "robertojose1234");
            try
            {
                bool envia = envio.EnviarEmail(emailDestino, nombrePaciente, fechaturno, nombreMedico, apellidoMedico, horaTurno);
            }
            catch (Exception ex)
            {
                Session.Add("MensajeError", ex.ToString());
                Response.Redirect("ErrorWeb.aspx", false);
            }
        }

        protected void mnTurnos_MenuItemClick(object sender, MenuEventArgs e)
        {
            int index = Convert.ToInt32(e.Item.Value);
            mvwTurnos.ActiveViewIndex = index;
        }

        protected void btnCargaGrd_Click(object sender, EventArgs e)
        {
            LinkButton button = (LinkButton)sender;
            CargarGrillaTurnos();
            if (button.ID.Equals("lbtnCargaGrd"))
                FiltrarGrillaTurnos();
        }

        private void FiltrarGrillaTurnos()
        {
            string paciente = txtfiltroPaciente.Text.Trim();
            string medico = txtFiltroMedico.Text.Trim();

            if (Session["TurnosGrdWeb"] == null)
                return;

            List<ModeloTurnoWeb> modeloTurnosWeb = (List<ModeloTurnoWeb>)Session["TurnosGrdWeb"];
            List<ModeloTurnoWeb> modeloTurnosFiltro = modeloTurnosWeb;
            if (!medico.Equals(""))
                modeloTurnosFiltro = modeloTurnosFiltro.FindAll(x => x.NombreMedico.ToUpper().Contains(medico.ToUpper()));
            if (!paciente.Equals(""))
                modeloTurnosFiltro = modeloTurnosFiltro.FindAll(x => x.NombrePaciente.ToUpper().Contains(paciente.ToUpper()));
            dgvTurnos.DataSource = modeloTurnosFiltro;
            dgvTurnos.DataBind();
        }

        protected void dgvTurnos_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                int numRow = Convert.ToInt32(e.CommandArgument);
                List<Jornada> jornadaTurnos = (List<Jornada>)Session["Jornadas"];
                GridView gridView = (GridView)sender;
                int idJorn = int.Parse(gridView.Rows[numRow].Cells[0].Text.ToString());
                List<ModeloTurnoWeb> modeloTurnos = (List<ModeloTurnoWeb>)Session["TurnosGrdWeb"];
                ModeloTurnoWeb modeloTurnoWeb = modeloTurnos.Find(x => x.IdTurno.Equals(idJorn));
                if (modeloTurnoWeb == null)
                    throw new Exception("Fallo al seleccionar el turno para editar");
                txtId.Text = modeloTurnoWeb.IdTurno.ToString();
                txtPaciente.Text = modeloTurnoWeb.NombrePaciente.ToString();
                txtMedico.Text = modeloTurnoWeb.NombreMedico.ToString();
                lblIdSituacion.Text = modeloTurnoWeb.IdSituacion.ToString();
                if (lblIdSituacion.Text == "3" || lblIdSituacion.Text == "2" || lblIdSituacion.Text == "5")
                {
                    txtDia.Enabled = false;
                    txtHora.Enabled = false;
                    txtObservacion.Enabled = false;
                    lkbGraba.Visible = false;
                }
                else
                {
                    if (e.CommandName.Equals("Reprogramar"))
                    {   
                        ReprogramarTurno(modeloTurnoWeb);
                        mvwTurnos.ActiveViewIndex = 1;
                        return;
                    }
                    else
                    {
                        lblIdSituacion.Text = modeloTurnoWeb.IdSituacion.ToString();
                        txtDia.Enabled = false;
                        txtHora.Enabled = false;
                        txtObservacion.Enabled = true;
                        lkbGraba.Visible = true;
                    }
                    txtDia.Text = modeloTurnoWeb.FechaReserva.ToString();
                    txtHora.Text = modeloTurnoWeb.Hora.ToString();
                    txtObservacion.Text = modeloTurnoWeb.Observacion.ToString();
                    if (e.CommandName.Equals("Cancelar"))
                    {
                        lblIdSituacion.Text = "3";
                        lkbGraba.Visible = true;
                    }
                }
                mpe.Show();//muestra el modal 
            }
            catch (Exception ex)
            {
                Session.Add("MensajeError", ex.ToString());
                Response.Redirect("ErrorWeb.aspx", false);
            }
        }

        private void ReprogramarTurno(ModeloTurnoWeb modeloTurnoWeb)
        {
            try
            {
                BuscarPaciente(modeloTurnoWeb.NroDocumento);
                TurnoNegocio turnoNegocio = new TurnoNegocio();
                Turno turno = new Turno();
                turno.IdTurno = Convert.ToInt32(modeloTurnoWeb.IdTurno);
                turno.Observacion = modeloTurnoWeb.Observacion;
                turno.IdSituacion = 2;
                if (!turnoNegocio.GrabarTurno(turno))
                {
                    Session.Add("MensajeError", "El Turno no se pudo ingresar");
                    Response.Redirect("ErrorWeb.aspx", false);
                }
            }
            catch (Exception ex)
            {
                Session.Add("MensajeError", ex.Message);
                Response.Redirect("ErrorWeb.aspx", false);
            }
        }

        protected void lkbGraba_Click(object sender, EventArgs e)
        {
            try
            {

                TurnoNegocio turnoNegocio = new TurnoNegocio();
                Turno turno = new Turno();
                turno.IdTurno = Convert.ToInt32(txtId.Text);

                turno.Observacion = txtObservacion.Text;
                turno.IdSituacion = Convert.ToInt32(lblIdSituacion.Text);

                if (turno.IdTurno == 0)
                    return;
                if (!turnoNegocio.GrabarTurno(turno))
                {
                    Session.Add("MensajeError", "El Turno no se pudo ingresar");
                    Response.Redirect("ErrorWeb.aspx", false);
                }              
                CargarGrillaTurnos();
            }
            catch (Exception ex)
            {
                Session.Add("MensajeError", ex.ToString());
                Response.Redirect("ErrorWeb.aspx", false);
            }
        }
    }
}