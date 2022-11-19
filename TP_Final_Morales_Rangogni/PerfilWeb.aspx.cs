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
                    buscarPerfilesWeb();
                    BuscarImagenesControles();
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
        private void BuscarImagenesControles()
        {
            iBtnGraba.ImageUrl = @"..\Imagenes\save_as_opsz48.jpg";
            iBtnCancela.ImageUrl = @"..\Imagenes\cancel_black_36dp.jpg";
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
            
            buscarPerfilesWeb();
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

            buscarPerfilesWeb();
        }
        private void LimpiarControles()
        {
            txtDesc.Text = "";
        }

        protected void iBtnGraba_Click(object sender, ImageClickEventArgs e)
        {
            AltaPerfilWeb();
        }

        protected void btnVerPerfiles_Click(object sender, EventArgs e)
        {
            buscarPerfilesWeb();
        }

        protected void buscarPerfilesWeb()
        {
            PerfilNegocio perfilNegocio = new PerfilNegocio();
            List<Perfil> perfils = perfilNegocio.Perliles();
            Session.Add("perfils", perfils);
            dgvPerfiles.DataSource = perfils;
            dgvPerfiles.DataBind();
        }
    }
}