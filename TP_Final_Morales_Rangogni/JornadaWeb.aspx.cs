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

        private void AltaJornadaTurno()
        {
            if (!ValidoControlTextBox(txtDesc))
                return;
            if (!ValidoControlTextBox(txtIni))
                return;
            if (!ValidoControlTextBox(txtFin))
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

        private void ActualizaJornadaTurno()
        {
            
            if (!ValidoControlTextBox(txtDesc))
                return;
            if (!ValidoControlTextBox(txtIni))
                return;
            if (!ValidoControlTextBox(txtFin))
                return;
            try
            {
                JornadaNegocio jornadaNegocio = new JornadaNegocio();
                jornadaNegocio.ModificarJornada(Convert.ToInt32(txtId.Text), txtDesc.Text,chbEst.Checked,Convert.ToInt32(txtIni.Text), Convert.ToInt32(txtFin.Text));                
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
            if (lblAccion.Text.Equals("NUEVO"))
                AltaJornadaTurno();
            if (lblAccion.Text.Equals("EDITAR") || lblAccion.Text.Equals("ELIMINAR"))
                ActualizaJornadaTurno();

            CargarGrillaJornada();
        }

        protected void dgvJornadas_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            List<Jornada> jornadaTurnos = (List<Jornada>)Session["Jornadas"];
            int numRow = Convert.ToInt32(e.CommandArgument);
            GridView gridView = (GridView)sender;            
            int idJorn = int.Parse(gridView.Rows[numRow].Cells[0].Text.ToString());
            Jornada jornada = jornadaTurnos.Find(x => x.IdJornada.Equals(idJorn));
            txtId.Text = jornada.IdJornada.ToString();
            txtId.Enabled = false;
            lblAccion.Text = e.CommandName.ToUpper();
            if (e.CommandName.Equals("Editar"))
            {
                ActivaDesactivaControlesModal(true);
                txtDesc.Text = jornada.Descripcion;
                txtFin.Text = jornada.Fin.ToString();
                txtIni.Text = jornada.Inicio.ToString();
                chbEst.Checked = jornada.Estado;
            }
            if (e.CommandName.Equals("Eliminar"))
            {
                ActivaDesactivaControlesModal(false);
                txtDesc.Text = jornada.Descripcion;
                txtFin.Text = jornada.Fin.ToString();
                txtIni.Text = jornada.Inicio.ToString();
                chbEst.Checked = false;
            }
            mpe.Show();            
        }

        protected void lbtnModal_Click(object sender, EventArgs e)
        {
            ActivaDesactivaControlesModal(true);
            lblAccion.Text = "NUEVO";
            txtId.Text = "";
            txtDesc.Text = "";
            txtFin.Text = "";
            txtIni.Text = "";
            chbEst.Checked = true;
            mpe.Show();
        }

        private void ActivaDesactivaControlesModal(bool est)
        {
            txtDesc.Enabled = est;
            txtFin.Enabled = est;
            txtIni.Enabled = est;
        }
    }
}