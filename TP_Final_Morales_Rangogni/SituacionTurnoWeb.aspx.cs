using AccesoModeloBaseDatos.Dominio;
using ModeloDeNegocio.Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Authentication.ExtendedProtection;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TP_Final_Morales_Rangogni
{
    public partial class SituacionTurnoWeb : Page
    {
        private SituacionTurnoNegocio situacionTurnoNegocio;
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
                    CargarGrillaSituacion();
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
                if (empleado.idPerfil != 1)
                    throw new Exception("El Usuario: " + empleado.Nombres + ", " + empleado.Apellidos + " sin acceso!");
            }
            catch (Exception ex)
            {
                Session.Add("MensajeError", ex.ToString());
                Response.Redirect("ErrorWeb.aspx", false);
            }
        }

        private void CargarGrillaSituacion()
        {
            try
            {
                situacionTurnoNegocio = new SituacionTurnoNegocio();
                List<SituacionTurno> situacionesTurno = situacionTurnoNegocio.GetSituacionTurnos();
                dgvSituacion.DataSource = situacionesTurno;
                dgvSituacion.DataBind();
                Session.Add("ListaSituacionesTurno", situacionesTurno);
            }
            catch (Exception ex)
            {
                Session.Add("MensajeError", ex.ToString());
                Response.Redirect("ErrorWeb.aspx", false);
            }
        }

        private void AltaSituacionTurno()
        {
            if (txtDesc.Text.Trim().Equals(""))
                return;
            situacionTurnoNegocio = new SituacionTurnoNegocio();
            try
            {
                situacionTurnoNegocio.AltaSituacion(txtDesc.Text, chbEst.Checked);
            }
            catch (Exception ex)
            {
                Session.Add("MensajeError", ex.ToString());
                Response.Redirect("ErrorWeb.aspx", false);
            }
            CargarGrillaSituacion();
        }

        private void ModificarSituacionTurno()
        {
            if (txtDesc.Text.Trim().Equals(""))
                return;
            situacionTurnoNegocio = new SituacionTurnoNegocio();
            try
            {
                situacionTurnoNegocio.ModificarSituacionTurno(Convert.ToInt32(txtId.Text), txtDesc.Text, chbEst.Checked);
            }
            catch (Exception ex)
            {
                Session.Add("MensajeError", ex.ToString());
                Response.Redirect("ErrorWeb.aspx", false);
            }
            CargarGrillaSituacion();
        }

        private void LimpiarControles()
        {
            txtDesc.Text = "";
            txtId.Text = "";
            lblAccion.Text = "";
        }

        protected void iBtnGraba_Click(object sender, ImageClickEventArgs e)
        {
            AltaSituacionTurno();
        }

        protected void btnCargar_Click(object sender, EventArgs e)
        {
            CargarGrillaSituacion();
        }

        private void ActivaDesactivaControlesModal(bool est)
        {
            txtDesc.Enabled = est;
        }

        protected void lbtnNuevo_Click(object sender, EventArgs e)
        {
            LimpiarControles();
            txtId.Text = "0";
            txtId.Enabled = false;
            chbEst.Checked = true;
            lblAccion.Text = "NUEVO";
            mpe.Show();
        }

        protected void lbtnGraba_Click(object sender, EventArgs e)
        {
            if (lblAccion.Text.Equals("NUEVO"))
                AltaSituacionTurno();
            if (lblAccion.Text.Equals("EDITAR") || lblAccion.Text.Equals("ELIMINAR"))
                ModificarSituacionTurno();
        }

        protected void dgvSituacion_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                List<SituacionTurno> situacionesTurno = (List<SituacionTurno>)Session["ListaSituacionesTurno"];
                int numRow = Convert.ToInt32(e.CommandArgument);
                GridView gridView = (GridView)sender;
                int id = int.Parse(gridView.Rows[numRow].Cells[0].Text.ToString());
                SituacionTurno situacionTurno = situacionesTurno.Find(x => x.IdSituacion.Equals(id));
                txtId.Text = situacionTurno.IdSituacion.ToString();
                txtId.Enabled = false;
                lblAccion.Text = e.CommandName.ToUpper();
                if (e.CommandName.Equals("Editar"))
                {
                    ActivaDesactivaControlesModal(true);
                    txtDesc.Text = situacionTurno.Situacion;
                    chbEst.Checked = situacionTurno.Estado;
                }
                if (e.CommandName.Equals("Eliminar"))
                {
                    ActivaDesactivaControlesModal(false);
                    txtDesc.Text = situacionTurno.Situacion;
                    chbEst.Checked = false;
                }
                mpe.Show();
            }
            catch (Exception ex)
            {
                Session.Add("MensajeError", ex.ToString());
                Response.Redirect("ErrorWeb.aspx", false);
            }
        }
    }
}