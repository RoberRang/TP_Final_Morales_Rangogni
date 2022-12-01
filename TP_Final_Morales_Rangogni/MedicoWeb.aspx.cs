using AccesoModeloBaseDatos.Dominio;
using ModeloDeNegocio;
using ModeloDeNegocio.Negocio;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TP_Final_Morales_Rangogni.DominioWeb;

namespace TP_Final_Morales_Rangogni
{
    public partial class MedicoWeb : System.Web.UI.Page
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
                    CargarGrillaEspecialidad();

                    CargarFecha();
                    CargarGrillaTurnos();
                    //CargarSituacionTurno();
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
                if (!(empleado.idPerfil == 1 || empleado.idPerfil == 3))
                    throw new Exception("El Usuario: " + empleado.Nombres + ", " + empleado.Apellidos + " sin acceso!");
            }
            catch (Exception ex)
            {
                Session.Add("MensajeError", ex.ToString());
                Response.Redirect("ErrorWeb.aspx", false);
            }
        }

        private void CargarGrillaEspecialidad()
        {
            try
            {
                EspecialidadNegocio especialidadNegocio = new EspecialidadNegocio();
                Empleado empleado = (Empleado)Session["EmpleadoLogin"];

                List<Especialidad> especialidades = null;
                if (empleado.idPerfil == 1)
                    especialidades = especialidadNegocio.Especialidades();
                if (empleado.idPerfil == 3)
                    especialidades = especialidadNegocio.MedicoEspecialidades(empleado.ID);
                dgvEspecialidad.DataSource = especialidades;
                dgvEspecialidad.DataBind();
                Session.Add("ListaEspecialidad", especialidades);
            }
            catch (Exception ex)
            {
                Session.Add("MensajeError", ex.ToString());
                Response.Redirect("ErrorWeb.aspx", false);
            }
        }

        protected void dgvMedicos_RowCommand(object sender, GridViewCommandEventArgs e)
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
                    throw new Exception("Fallo al seleccionar el truno para editar");
                ///txtId.Text = modeloTurnoWeb.IdTurno.ToString();
               // txtPaciente.Text = modeloTurnoWeb.NombrePaciente.ToString();
                //txtMedico.Text = modeloTurnoWeb.NombreMedico.ToString();
                //txtDia.Text = modeloTurnoWeb.FechaReserva.ToString();
                txtHora.Text = modeloTurnoWeb.Hora.ToString();
                //txtObservacion.Text = modeloTurnoWeb.Observacion.ToString();
                //ddlSituacion.SelectedValue = modeloTurnoWeb.IdSituacion.ToString();
                mpe.Show();
            }
            catch (Exception ex)
            {
                Session.Add("MensajeError", ex.ToString());
                Response.Redirect("ErrorWeb.aspx", false);
            }
        }
        protected void mnMedico_MenuItemClick(object sender, MenuEventArgs e)
        {
            int index = Convert.ToInt32(e.Item.Value);
            mvwMedico.ActiveViewIndex = index;
        }

        protected void dgvEspecialidad_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                List<Especialidad> especialidades = (List<Especialidad>)Session["ListaEspecialidad"];
                int numRow = Convert.ToInt32(e.CommandArgument);
                GridView gridView = (GridView)sender;
                int id = int.Parse(gridView.Rows[numRow].Cells[0].Text.ToString());
                Especialidad especialidad = especialidades.Find(x => x.IdEspecialidad.Equals(id));
                txtIdEspMed.Text = especialidad.IdEspecialidad.ToString();
                txtIdEspMed.Enabled = false;
                Empleado empleado = (Empleado)Session["EmpleadoLogin"];
                txtIdMed.Text = empleado.ID.ToString();
                lblAccionEsp.Text = e.CommandName.ToUpper();
                if (e.CommandName.Equals("Editar"))
                {
                    ActivaDesactivaControlesModal(true);
                    ddlEspecialidad.Items.Clear();
                    ddlEspecialidad.Items.Add(especialidad.Descripcion);
                    chkEstMedEsp.Checked = especialidad.Estado.Equals("Activo") ? true : false;
                }
                mpeEsp.Show();
            }
            catch (Exception ex)
            {
                Session.Add("MensajeError", ex.ToString());
                Response.Redirect("ErrorWeb.aspx", false);
            }
        }

        private void ActivaDesactivaControlesModal(bool est)
        {
            ddlEspecialidad.Enabled = est;
        }


        protected void lkbGraba_Click(object sender, EventArgs e)
        {

        }

        private void LimpiarControles()
        {
            //txtDesc.Text = "";
            txtId.Text = "";
            lblAccion.Text = "";
        }

        protected void lbtnNuevaEsp_Click(object sender, EventArgs e)
        {
            LimpiarControles();
            Empleado empleado = (Empleado)Session["EmpleadoLogin"];
            txtIdMed.Text = empleado.ID.ToString();
            txtIdMed.Enabled = false;
            CargarDropDawnListEspecialidad(true);
            chkEstMedEsp.Checked = true;
            lblAccionEsp.Text = "NUEVO";
            mpeEsp.Show();
        }

        private void CargarDropDawnListEspecialidad(bool nuevo)
        {
            try
            {
                EspecialidadNegocio especialidadNegocio = new EspecialidadNegocio();
                List<Especialidad> especialidades = null;
                if (nuevo)
                    especialidades = especialidadNegocio.Especialidades();
                else
                    especialidades = (List<Especialidad>)Session["ListaEspecialidad"];

                ddlEspecialidad.DataSource = especialidades;
                ddlEspecialidad.DataValueField = "IdEspecialidad";
                ddlEspecialidad.DataTextField = "Descripcion";
                ddlEspecialidad.DataBind();
                ddlEspecialidad.Items.Insert(0, new ListItem("-- Seleccione --", "0"));
                ddlEspecialidad.SelectedIndex = 0;
                txtIdEspMed.Text = ddlEspecialidad.SelectedValue;
                txtIdEspMed.Enabled = false;
            }
            catch (Exception ex)
            {
                Session.Add("MensajeError", ex.ToString());
                Response.Redirect("ErrorWeb.aspx", false);
            }
        }

        protected void lbtnCargarEsp_Click(object sender, EventArgs e)
        {
            CargarGrillaEspecialidad();
        }

        protected void lbtnGrabaEsp_Click(object sender, EventArgs e)
        {
            if (lblAccionEsp.Text.Equals("NUEVO"))
                AltaMedicoEspecialidadWeb();
            if (lblAccionEsp.Text.Equals("EDITAR"))
                ModificarMedicoEspeciaalidadWeb();
        }

        private void AltaMedicoEspecialidadWeb()
        {
            if (txtIdEspMed.Text.Trim().Equals(""))
                return;
            EspecialidadNegocio especialidadNegocio = new EspecialidadNegocio();
            try
            {
                Empleado empleado = (Empleado)Session["EmpleadoLogin"];
                if (empleado.idPerfil != 3)
                    return;
                especialidadNegocio.AltaMedicoEspecialidad(empleado.ID, Convert.ToInt32(txtIdEspMed.Text), chkEstMedEsp.Checked);
            }
            catch (Exception ex)
            {
                Session.Add("MensajeError", ex.ToString());
                Response.Redirect("ErrorWeb.aspx", false);
            }
            CargarGrillaEspecialidad();
        }

        private void ModificarMedicoEspeciaalidadWeb()
        {
            if (txtIdMed.Text.Trim().Equals(""))
                return;
            EspecialidadNegocio especialidadNegocio = new EspecialidadNegocio();
            try
            {
                Empleado empleado = (Empleado)Session["EmpleadoLogin"];
                if (empleado.idPerfil != 3)
                    return;
                especialidadNegocio.ModificarMedicoEspecialidad(Convert.ToInt32(txtIdMed.Text), Convert.ToInt32(txtIdEspMed.Text), chkEstMedEsp.Checked);
            }
            catch (Exception ex)
            {
                Session.Add("MensajeError", ex.ToString());
                Response.Redirect("ErrorWeb.aspx", false);
            }
            CargarGrillaEspecialidad();
        }

        protected void ddlEspecialidad_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtIdEspMed.Text = ddlEspecialidad.SelectedValue;
            mpeEsp.Show();
        }

        protected void lbtnCargarTurnos_Click(object sender, EventArgs e)
        {

        }

        private void FiltrarGrillaTurnos()
        {
            string paciente = txtfiltroPaciente.Text.Trim();
            //string dni = txtFiltroDni.Text.Trim();

            if (Session["TurnosGrdWeb"] == null)
                return;

            List<ModeloTurnoWeb> modeloTurnosWeb = (List<ModeloTurnoWeb>)Session["TurnosGrdWeb"];
            List<ModeloTurnoWeb> modeloTurnosFiltro = modeloTurnosWeb;
            if (!paciente.Equals(""))
                modeloTurnosFiltro = modeloTurnosFiltro.FindAll(x => x.NombrePaciente.ToUpper().Contains(paciente.ToUpper()));
            // if (!dni.Equals(""))
            //   modeloTurnosFiltro = modeloTurnosFiltro.FindAll(x => x.NroDocumento.ToUpper().Contains(dni.ToUpper()));
            dgvMedicos.DataSource = modeloTurnosFiltro;
            dgvMedicos.DataBind();
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
                dgvMedicos.DataSource = gvTurnos;
                dgvMedicos.DataBind();
            }
            catch (Exception ex)
            {
                Session.Add("MensajeError", ex.ToString());
                Response.Redirect("ErrorWeb.aspx", false);
            }

        }

        protected void lbtnCargaGrd_Click(object sender, EventArgs e)
        {
            LinkButton button = (LinkButton)sender;
            CargarGrillaTurnos();
            if (button.ID.Equals("lbtnCargaGrd"))
                FiltrarGrillaTurnos();
        }
        private void CargarFecha()
        {

            txtFechaGrd.Text = DateTime.Today.ToString("yyyy-MM-dd");
        }

    }
}