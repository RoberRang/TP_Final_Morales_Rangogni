using AccesoModeloBaseDatos.Dominio;
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

        protected void lbtnModal_Click(object sender, EventArgs e)
        {

        }

        protected void lkbGraba_Click(object sender, EventArgs e)
        {

        }
    }
}