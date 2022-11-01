using AccesoModeloBaseDatos.Dominio;
using ModeloDeNegocio.Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TP_Final_Morales_Rangogni
{
    public partial class PerfilWeb : Page
    {
        private  PerfilNegocio perfilNegocio;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarRepetidorFerfil();
                BuscarImagenesControles();
            }
        }

        private void BuscarImagenesControles()
        {
            iBtnGraba.ImageUrl = @"..\Imagenes\save_as_opsz48.jpg";
            iBtnCancela.ImageUrl = @"..\Imagenes\cancel_black_36dp.jpg";
        }

        private void CargarRepetidorFerfil()
        {
            try
            {
                perfilNegocio = new PerfilNegocio();
                List<Perfil> perfils = perfilNegocio.Perliles();
                rprPerfiles.DataSource = perfils;
                rprPerfiles.DataBind();
                Session.Add("ListaPerfil", perfils);
            }
            catch (Exception ex)
            {
                throw ex;
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
                throw ex;
            }
            
            CargarRepetidorFerfil();
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
                throw ex;
            }

            CargarRepetidorFerfil();
        }
        private void LimpiarControles()
        {
            txtDesc.Text = "";
        }

        protected void iBtnGraba_Click(object sender, ImageClickEventArgs e)
        {
            AltaPerfilWeb();
        }
    }
}