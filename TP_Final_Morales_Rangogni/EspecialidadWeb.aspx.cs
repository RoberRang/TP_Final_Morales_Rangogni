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
    public partial class EspecialidadWeb : Page
    {
        private EspecialidadNegocio especialidadNegocio;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarGrillaEspecialidad();
            }
        }

        private void CargarGrillaEspecialidad()
        {
            try
            {
                especialidadNegocio = new EspecialidadNegocio();
                List<Especialidad> especialidad = especialidadNegocio.Especialidades();
                dgvEspecialidad.DataSource = especialidad;
                dgvEspecialidad.DataBind();
                Session.Add("ListaEspecialidad", especialidad);
            }
            catch (Exception ex)
            {
                Session.Add("MensajeError", ex.ToString());
                Response.Redirect("ErrorWeb.aspx", false);
            }
        }

        private void AltaEspecialidadWeb()
        {
            if (txtDesc.Text.Trim().Equals(""))
                return;
            especialidadNegocio = new EspecialidadNegocio();
            try
            {
                especialidadNegocio.AltaEspecialidad(txtDesc.Text, chbEst.Checked);
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
            especialidadNegocio = new EspecialidadNegocio();
            try
            {
                especialidadNegocio.ModificarEspecialidad(Convert.ToInt32(txtId.Text), txtDesc.Text, chbEst.Checked);
            }
            catch (Exception ex)
            {
                Session.Add("MensajeError", ex.ToString());
                Response.Redirect("ErrorWeb.aspx", false);
            }
            CargarGrillaEspecialidad();
        }

        private void LimpiarControles()
        {
            txtDesc.Text = "";
            txtId.Text = "";
            lblAccion.Text = "";
        }

        protected void iBtnGraba_Click(object sender, ImageClickEventArgs e)
        {
            AltaEspecialidadWeb();
        }

        protected void btnCargar_Click(object sender, EventArgs e)
        {

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
                mpe.Show();
            }
            catch (Exception ex) 
            {
                Session.Add("MensajeError", ex.ToString());
                Response.Redirect("ErrorWeb.aspx", false);
            }
        }

        private void ActivaDesactivaControlesModal(bool est)
        {
            txtId.Enabled = est;
            txtDesc.Enabled = est;
        }

        protected void lbtnNuevo_Click(object sender, EventArgs e)
        {
            LimpiarControles();
            txtId.Text = "0";
            txtId.Enabled = false;
            lblAccion.Text = "NUEVO";
            mpe.Show();
        }

        protected void lbtnGraba_Click(object sender, EventArgs e)
        {
            if (lblAccion.Text.Equals("NUEVO"))
                AltaEspecialidadWeb();
            if (lblAccion.Text.Equals("EDITAR") || lblAccion.Text.Equals("ELIMINAR"))
                ModificarEspeciaalidadWeb();
        }
    }
}