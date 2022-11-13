using AccesoModeloBaseDatos.Dominio;
using ModeloDeNegocio;
using ModeloDeNegocio.Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TP_Final_Morales_Rangogni
{
    public partial class JornadaTurnoWeb : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                CargarRepetidorJornada();
        }
        private void CargarRepetidorJornada()
        {
            try
            {
                List<JornadaTurno> jornadaTurnos = new List<JornadaTurno>();
                JornadaNegocio jornadaNegocio = new JornadaNegocio();
                jornadaTurnos = jornadaNegocio.ListarJornadas();
                Session.Add("Jornadas", jornadaTurnos);
                rprJornadas.DataSource = jornadaTurnos;
                rprJornadas.DataBind();
            }
            catch (Exception ex)
            {
                Session.Add("MensajeError", ex.ToString());
                Response.Redirect("ErrorWeb.aspx", false);
            }
        }
        protected void iBtnGraba_Click(object sender, ImageClickEventArgs e)
        {
            AltaJornadaTurno();
        }
        private void AltaJornadaTurno()
        {
            if (txtDesc.Text.Trim().Equals(""))
                return;
            
            try
            {
                JornadaNegocio jornadaNegocio = new JornadaNegocio();
                jornadaNegocio.AltaJornada(txtDesc.Text, chbEst.Checked, Convert.ToInt32(txtIni.Text), Convert.ToInt32(txtFin.Text));
            }
            catch (Exception ex)
            {
                Session.Add("MensajeError", ex.ToString());
                Response.Redirect("ErrorWeb.aspx", false);
            }

        }
    }
}