using AccesoModeloBaseDatos.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TP_Final_Morales_Rangogni.Negocio;

namespace AccesoModeloBaseDatos
{
    public partial class PerfilWeb : Page
    {
        private  PerfilNegocio perfilNegocio;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)    
                CargarRepetidorFerfil();
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
                perfilNegocio.AltaPerfil(txtDesc.Text, true);
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
                perfilNegocio.AltaPerfil(txtDesc.Text, true);
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

        protected void btnIngresar_Click(object sender, EventArgs e)
        {
            AltaPerfilWeb();
            
        }
    }
}