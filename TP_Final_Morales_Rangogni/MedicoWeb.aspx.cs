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
                if (empleado.idPerfil== 1)
                    especialidades = especialidadNegocio.Especialidades();
                if (empleado.idPerfil == 3)
                    especialidades = especialidadNegocio.EspecialidadesMedico(empleado.ID);
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
                //txtHora.Text = modeloTurnoWeb.Hora.ToString();
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
            List<Especialidad> especialidades = (List<Especialidad>)Session["ListaEspecialidad"];
            int numRow = Convert.ToInt32(e.CommandArgument);
            GridView gridView = (GridView)sender;
            int id = int.Parse(gridView.Rows[numRow].Cells[0].Text.ToString());
            Especialidad especialidad = especialidades.Find(x => x.IdEspecialidad.Equals(id));
            txtId.Text = especialidad.IdEspecialidad.ToString();
            txtId.Enabled = false;
            lblAccion.Text = e.CommandName.ToUpper();
            if (e.CommandName.Equals("Editar"))
            {
                ActivaDesactivaControlesModal(true);
                txtDesc.Text = especialidad.Descripcion;
                chbEst.Checked = especialidad.Estado;
            }
            if (e.CommandName.Equals("Eliminar"))
            {
                ActivaDesactivaControlesModal(false);
                txtDesc.Text = especialidad.Descripcion;
                chbEst.Checked = false;
            }
            mpeEsp.Show();
        }

        private void ActivaDesactivaControlesModal(bool est)
        {
            txtDesc.Enabled = est;
        }

        protected void lbtnModal_Click(object sender, EventArgs e)
        {

        }

        protected void lkbGraba_Click(object sender, EventArgs e)
        {

        }

        private void LimpiarControles()
        {
            txtDesc.Text = "";
            txtId.Text = "";
            lblAccion.Text = "";
        }

        protected void lbtnNuevaEsp_Click(object sender, EventArgs e)
        {
            LimpiarControles();
            Empleado empleado = (Empleado)Session["EmpleadoLogin"];
            txtIdEspMed.Text = empleado.ID.ToString();
            txtIdEspMed.Enabled = false;
            CargarDropDawnListEspecialidad(true);
            chkEstMedEsp.Checked = true;
            lblAccion.Text = "NUEVO";
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
            if (lblAccion.Text.Equals("NUEVO"))
                AltaEspecialidadWeb();
            if (lblAccion.Text.Equals("EDITAR") || lblAccion.Text.Equals("ELIMINAR"))
                ModificarEspeciaalidadWeb();
        }

        private void AltaEspecialidadWeb()
        {
            if (txtDesc.Text.Trim().Equals(""))
                return;
            EspecialidadNegocio especialidadNegocio = new EspecialidadNegocio();
            try
            {
                Empleado empleado = (Empleado)Session["EmpleadoLogin"];
                if (empleado.idPerfil != 3)
                    return;
                especialidadNegocio.AltaMedicoEspecialidad(empleado.ID, Convert.ToInt32(txtIdEspMed.Text), chbEst.Checked);
            } 
            catch (Exception ex)
            {
                Session.Add("MensajeError", ex.ToString());
                Response.Redirect("ErrorWeb.aspx", false);
            }
            CargarGrillaEspecialidad();
        }

        private void ModificarEspeciaalidadWeb()
        {
            if (txtDesc.Text.Trim().Equals(""))
                return;
            EspecialidadNegocio especialidadNegocio = new EspecialidadNegocio();
            try
            {
                Empleado empleado = (Empleado)Session["EmpleadoLogin"];
                if (empleado.idPerfil != 3)
                    return;
                especialidadNegocio.ModificarEspecialidadMedico(Convert.ToInt32(txtId.Text),Convert.ToInt32(txtIdEspMed.Text), chbEst.Checked);
            }
            catch (Exception ex)
            {
                Session.Add("MensajeError", ex.ToString());
                Response.Redirect("ErrorWeb.aspx", false);
            }
            CargarGrillaEspecialidad();
        }

    }
}