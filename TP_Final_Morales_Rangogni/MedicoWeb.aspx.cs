using AccesoModeloBaseDatos.Dominio;
using ModeloDeNegocio;
using ModeloDeNegocio.Negocio;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
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
                if (!(empleado.idPerfil == 1 || empleado.idPerfil == 3))
                    throw new Exception("El Usuario: " + empleado.Nombres + ", " + empleado.Apellidos + " sin acceso!");
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
                txtId.Text = modeloTurnoWeb.IdTurno.ToString();
                txtPaciente.Text = modeloTurnoWeb.NombrePaciente.ToString();
                txtDia.Text = modeloTurnoWeb.FechaReserva.ToString();
                txtHora.Text = modeloTurnoWeb.Hora.ToString();
                txtObservacion.Text = modeloTurnoWeb.Observacion.ToString();
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

        protected void lbtnModal_Click(object sender, EventArgs e)
        {

        }

        protected void lkbGraba_Click(object sender, EventArgs e)
        {

        }

        private void LimpiarControles()
        {

        }
        private void CargarGrillaTurnos()
        {
            try
            {
                TurnoNegocio turnoNegocio = new TurnoNegocio();
                ModeloGrillaTurnosWeb modeloGrillaTurnosWeb = new ModeloGrillaTurnosWeb();
                DateTime dFechaTurno;
                if (!IsPostBack || txtFechaTurnos.Text.Equals(""))
                    dFechaTurno = DateTime.Today;
                else
                    dFechaTurno = Convert.ToDateTime(txtFechaTurnos.Text);
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
        private void FiltrarGrillaTurnos()
        {
            string paciente = txtfiltroPaciente.Text.Trim();
            string dni = txtFiltroDni.Text.Trim();

            if (Session["TurnosGrdWeb"] == null)
                return;

            List<ModeloTurnoWeb> modeloTurnosWeb = (List<ModeloTurnoWeb>)Session["TurnosGrdWeb"];
            List<ModeloTurnoWeb> modeloTurnosFiltro = modeloTurnosWeb;
            if (!dni.Equals(""))
                modeloTurnosFiltro = modeloTurnosFiltro.FindAll(x => x.NombreMedico.ToUpper().Contains(dni.ToUpper()));
            if (!paciente.Equals(""))
                modeloTurnosFiltro = modeloTurnosFiltro.FindAll(x => x.NombrePaciente.ToUpper().Contains(paciente.ToUpper()));
            dgvMedicos.DataSource = modeloTurnosFiltro;
            dgvMedicos.DataBind();
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
            txtFechaTurnos.Text = DateTime.Now.ToString("yyyy-MM-dd");

        }
    }
}