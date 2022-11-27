using AccesoModeloBaseDatos.Dominio;
using ModeloDeNegocio.Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Services.Description;
using System.Web.UI;
using System.Web.UI.WebControls;
using TP_Final_Morales_Rangogni.DominioWeb;

namespace TP_Final_Morales_Rangogni
{
    public partial class PacienteWeb : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                buscarPacientesWeb();
            }

        }

        protected void btnAcept_Click(object sender, EventArgs e)
        {
            Button btnFuncion = (Button)sender;
            PacienteNegocio negocio = new PacienteNegocio();
            Paciente nuevoPaciente = new Paciente();
            try
            {
                if (btnFuncion.ID != "btnEditar")
                {
                    if (!ValidoControlTextBox(txtnombre))
                        return;
                    if (!ValidoControlTextBox(txtApellido))
                        return;
                    if (!ValidoControlTextBox(txtDni))
                        return;
                    if (!ValidoControlTextBox(txtEmail))
                        return;
                    if (!ValidoControlTextBox(txtFecha))
                        return;

                    nuevoPaciente.Nombres = txtnombre.Text;
                    nuevoPaciente.Apellidos = txtApellido.Text;
                    nuevoPaciente.NroDocumento = txtDni.Text;
                    nuevoPaciente.Telefono = txtTelefono.Text;
                    nuevoPaciente.Email = txtEmail.Text;
                    nuevoPaciente.FechaNacimiento = Convert.ToDateTime(txtFecha.Text);
                    nuevoPaciente.FechaAlta = DateTime.Today;                    
                    if (ddlEstado.Text == "Activo")
                    {
                        nuevoPaciente.Estado = true;
                    }
                    else
                    {
                        nuevoPaciente.Estado = false;
                    }
                    nuevoPaciente.Imagen = txtImagen.Text;
                    nuevoPaciente.Sexo = ddlGenero.Text;
                }
                else
                {
                    if (!ValidoControlTextBox(txtEdNombre))
                        return;
                    if (!ValidoControlTextBox(txtEdApellido))
                        return;
                    if (!ValidoControlTextBox(txtEdDni))
                        return;
                    if (!ValidoControlTextBox(txtEdEmail))
                        return;
                    if (!ValidoControlTextBox(txtEdFnac))
                        return;
                    nuevoPaciente.IdPaciente = Convert.ToInt32(IdPaciente.Text);
                    nuevoPaciente.Nombres = txtEdNombre.Text;
                    nuevoPaciente.Apellidos = txtEdApellido.Text;
                    nuevoPaciente.NroDocumento = txtEdDni.Text;
                    nuevoPaciente.Telefono = txtEdtelefono.Text;
                    nuevoPaciente.Email = txtEdEmail.Text;
                    nuevoPaciente.FechaNacimiento = Convert.ToDateTime(txtEdFnac.Text);                   
                    if (ddlEdEstado.Text == "Activo")
                    {
                        nuevoPaciente.Estado = true;
                    }
                    else
                    {
                        nuevoPaciente.Estado = false;
                    }
                    nuevoPaciente.Imagen = txtEdImagen.Text;
                    nuevoPaciente.Sexo = ddlEdGenero.Text;
                }
                if (btnFuncion.ID == "btnEditar")
                {
                    negocio.ModificarPaciente(nuevoPaciente);
                    buscarPacientesWeb();
                    ///cartel alta de pacinete completa y limpiar controles                
                   limpiarControlesEditar();
              
                    mvwPacientes.ActiveViewIndex = 0;
                }
               
                if (btnFuncion.ID != "btnEditar")
                {
                    negocio.AltaPaciente(nuevoPaciente);
                    
                    buscarPacientesWeb();
                    ///cartel alta de pacinete completa y limpiar controles                
                    limpiarControles();

                }
           
            }
            catch (Exception ex)
            {
                Session.Add("MensajeError", ex.ToString());
                Response.Redirect("ErrorWeb.aspx", false);

            }
        }

        private void limpiarControlesEditar()
        {   
            txtEdNombre.Text = string.Empty;            
            txtEdApellido.Text = string.Empty;
            txtEdDni.Text = string.Empty;
            txtEdtelefono.Text = string.Empty;              
            txtEdEmail.Text = string.Empty;
            txtEdFnac.Text= string.Empty;
            ddlEdEstado.Text = "Activo";            
            txtEdImagen.Text = string.Empty;
            ddlEdGenero.Text = "Masculino";
        }

        private void limpiarControles()
        {
            txtnombre.Text = string.Empty;
            txtApellido.Text = string.Empty;
            txtDni.Text = string.Empty;
            txtTelefono.Text = string.Empty;
            txtEmail.Text = string.Empty;
            txtFecha.Text = string.Empty;
            ddlEstado.Text = "Activo";         
            txtImagen.Text = string.Empty;
            ddlGenero.Text = "Masculino";
        }

        private bool ValidoControlTextBox(TextBox textBox)
        {
            bool valido = false;
            valido = textBox.Text.Equals("") ? false : true;
            if (!valido)
            {
                textBox.Attributes.Add("placeholder", "El campo no debe quedar incompleto");
                textBox.Focus();
            }
            return valido;
        }

        protected void dgvPacientes_SelectedIndexChanged(object sender, EventArgs e)
        {
            int id = (int)dgvPacientes.SelectedDataKey.Value;
            mvwPacientes.ActiveViewIndex = 2;
            List<ModeloPacienteWeb> filtro = (List<ModeloPacienteWeb>)Session["pacientesWeb"];
            ModeloPacienteWeb filtroRapido = filtro.Find(x => x.IdPaciente.Equals(id));

            IdPaciente.Text = id.ToString();
            txtEdNombre.Text = filtroRapido.Nombres;
            txtEdApellido.Text = filtroRapido.Apellidos;
            txtEdDni.Text = filtroRapido.NroDocumento;
            txtEdEmail.Text = filtroRapido.Email;
            txtEdtelefono.Text = filtroRapido.Telefono;
            txtEdImagen.Text = filtroRapido.Imagen;
            txtEdFnac.Text = filtroRapido.FechaNacimiento;
            ddlEdGenero.Text = filtroRapido.Sexo;
            ddlEdEstado.Text = filtroRapido.Estado;

        }

        protected void filtro_TextChanged(object sender, EventArgs e)
        {
            List<ModeloPacienteWeb> filtro = (List<ModeloPacienteWeb>)Session["pacientesWeb"];
            List<ModeloPacienteWeb> filtroRapido = filtro.FindAll(x => x.Nombres.ToUpper().Contains(txtfiltro.Text.ToUpper()));
            dgvPacientes.DataSource = filtroRapido;
            dgvPacientes.DataBind();
        }
        protected void buscarPacientesWeb()
        {
            PacienteNegocio pacienteNegocio = new PacienteNegocio();
            List<ModeloPacienteWeb> pacientesBuscados = new List<ModeloPacienteWeb>();
            foreach (Paciente paciente in pacienteNegocio.Pacientes())
            {
                ModeloPacienteWeb modeloPaciente = new ModeloPacienteWeb(paciente);
                pacientesBuscados.Add(modeloPaciente);
            }
            Session.Add("pacientesWeb", pacientesBuscados);
            dgvPacientes.DataSource = pacientesBuscados;
            dgvPacientes.DataBind();

        }

        protected void mnPaciente_MenuItemClick(object sender, MenuEventArgs e)
        {
            int index = Convert.ToInt32(e.Item.Value);
            mvwPacientes.ActiveViewIndex = index;
        }

    }
}

