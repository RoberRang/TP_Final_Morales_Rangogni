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
                    CargarGrillaJornada();
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
        private void CargarGrillaJornada()
        {
            try
            {
                List<Jornada> jornadaTurnos = new List<Jornada>();
                JornadaNegocio jornadaNegocio = new JornadaNegocio();
                jornadaTurnos = jornadaNegocio.ListarJornadas();
                Session.Add("Jornadas", jornadaTurnos);
                dgvJornadas.DataSource = jornadaTurnos;
                dgvJornadas.DataBind();
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
            if (ValidoControlTextBox(txtDesc))
                return;
            if (ValidoControlTextBox(txtIni))
                return;
            if (ValidoControlTextBox(txtFin))
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

        private bool ValidoControlTextBox(TextBox textBox)
        {
            bool valido = textBox.Text.Equals("") ? false : true;
            if (!valido)
            {
                textBox.Attributes.Add("placeholder", "El campo no debe quedar incompleto");
                textBox.Focus();
            }
            return valido;
        }

        protected void btnVerJornadas_Click(object sender, EventArgs e)
        {
            CargarGrillaJornada();
        }

        protected void lkbGraba_Click(object sender, EventArgs e)
        {

        }

        protected void dgvJornadas_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            txtDesc.Text = e.CommandArgument.ToString();
            ClientScript.RegisterStartupScript(this.GetType(), "Popup", "CargarModal();", true);
            //ScriptManager.RegisterStartupScript(this, this.GetType(), "ModalAdd", "cargarModal();", true);
        }
    }
}