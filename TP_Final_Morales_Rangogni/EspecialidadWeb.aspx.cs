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
    public partial class EspecialidadWeb : Page
    {
        private EspecialidadNegocio especialidadNegocio;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarRepetidorEspecialidad();
                BuscarImagenesControles();
            }
        }

        private void BuscarImagenesControles()
        {   
            iBtnGraba.ImageUrl = @"..\Imagenes\save_as_opsz48.jpg";
            iBtnCancela.ImageUrl = @"..\Imagenes\cancel_black_36dp.jpg";
        }

        private void CargarRepetidorEspecialidad()
        {
            try
            {
                especialidadNegocio = new EspecialidadNegocio();
                List<Especialidad> especialidad = especialidadNegocio.Especialidades();
                rprEspecialidad.DataSource = especialidad;                
                rprEspecialidad.DataBind();
                Session.Add("ListaEspecialidad", especialidad);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private void AltaEspecialidadWeb()
        {
            if (txtDesc.Text.Trim().Equals(""))
                return;
            especialidadNegocio = new EspecialidadNegocio();
            try
            {
                especialidadNegocio.AltaEspecialidad(txtDesc.Text, true);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            CargarRepetidorEspecialidad();
        }
        private void ModificarEspeciaalidadWeb()
        {
            if (txtDesc.Text.Trim().Equals(""))
                return;
            especialidadNegocio = new EspecialidadNegocio();
            try
            {
                especialidadNegocio.AltaEspecialidad(txtDesc.Text, true);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            CargarRepetidorEspecialidad();
        }
        private void LimpiarControles()
        {
            txtDesc.Text = "";
        }

        protected void iBtnGraba_Click(object sender, ImageClickEventArgs e)
        {
            AltaEspecialidadWeb();
        }
    }
}