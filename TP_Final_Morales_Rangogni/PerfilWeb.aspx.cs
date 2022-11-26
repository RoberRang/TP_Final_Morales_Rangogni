using AccesoModeloBaseDatos.Dominio;
using ModeloDeNegocio.Negocio;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TP_Final_Morales_Rangogni.DominioWeb;

namespace TP_Final_Morales_Rangogni
{
    public partial class PerfilWeb : Page
    {
        private  PerfilNegocio perfilNegocio;
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
                    CargarGrillaPerfilesWeb();
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
        
        private void AltaPerfilWeb()
        {
            if (txtDesc.Text.Trim().Equals(""))
                return;
            perfilNegocio = new PerfilNegocio();
            try
            {
                perfilNegocio.AltaPerfil(txtDesc.Text, chbEst.Checked);
            }
            catch (Exception ex)
            {
                Session.Add("MensajeError", ex.ToString());
                Response.Redirect("ErrorWeb.aspx", false);
            }            
            CargarGrillaPerfilesWeb();
        }
        private void ModificarPerfilWeb()
        {
            if (txtDesc.Text.Trim().Equals(""))
                return;
            perfilNegocio = new PerfilNegocio();
            try
            {
                perfilNegocio.AltaPerfil(txtDesc.Text, chbEst.Checked);
            }
            catch (Exception ex)
            {
                Session.Add("MensajeError", ex.ToString());
                Response.Redirect("ErrorWeb.aspx", false);
            }
            CargarGrillaPerfilesWeb();
        }
        private void LimpiarControles()
        {
            txtId.Text = string.Empty;
            txtDesc.Text = "";
            lblAccion.Text = string.Empty;
        }

        protected void iBtnGraba_Click(object sender, ImageClickEventArgs e)
        {
            AltaPerfilWeb();
        }

        protected void btnVerPerfiles_Click(object sender, EventArgs e)
        {
            CargarGrillaPerfilesWeb();
        }

        protected void CargarGrillaPerfilesWeb()
        {
            PerfilNegocio perfilNegocio = new PerfilNegocio();
            List<Perfil> perfiles = perfilNegocio.Perliles();
            Session.Add("Perfiles", perfiles);
            dgvPerfiles.DataSource = perfiles;
            dgvPerfiles.DataBind();
        }

        protected void dgvPerfiles_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                List<Perfil> perfiles = (List<Perfil>)Session["Perfiles"];
                int numRow = Convert.ToInt32(e.CommandArgument);
                GridView gridView = (GridView)sender;
                int id = int.Parse(gridView.Rows[numRow].Cells[0].Text.ToString());
                Perfil perfil = perfiles.Find(x => x.IdPerfil.Equals(id));
                txtId.Text = perfil.IdPerfil.ToString();
                txtId.Enabled = false;
                lblAccion.Text = e.CommandName.ToUpper();
                if (e.CommandName.Equals("Editar"))
                {
                    ActivaDesactivaControlesModal(true);
                    txtDesc.Text = perfil.Descripcion;
                    chbEst.Checked = perfil.Estado;
                }
                if (e.CommandName.Equals("Eliminar"))
                {
                    ActivaDesactivaControlesModal(false);
                    txtDesc.Text = perfil.Descripcion;
                    chbEst.Checked = false;
                }
                mpe.Show();
            }
            catch (Exception ex)
            {
                Session.Add("MensajeError", ex.ToString());
                Response.Redirect("ErrorWeb.aspx", false);
            }
            mpe.Show();
        }

        private void ActivaDesactivaControlesModal(bool est)
        {
            txtDesc.Enabled = est;
        }

        protected void lbtnCargar_Click(object sender, EventArgs e)
        {
            CargarGrillaPerfilesWeb();
        }

        protected void lbtnNuevo_Click(object sender, EventArgs e)
        {
            LimpiarControles();
            txtId.Text = "0";
            txtId.Enabled = true;
            lblAccion.Text = "NUEVO";
            mpe.Show();
        }

        protected void lbtnGraba_Click(object sender, EventArgs e)
        {
            if (lblAccion.Text.Equals("NUEVO"))
                AltaPerfilWeb();
            if (lblAccion.Text.Equals("EDITAR") || lblAccion.Text.Equals("ELIMINAR"))
                ModificarPerfilWeb();
        }
    }
}