using AccesoModeloBaseDatos.Dominio;
using ModeloDeNegocio.Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services.Description;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TP_Final_Morales_Rangogni
{
    public partial class PacienteWeb : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
     
        }

        protected void btnAcept_Click(object sender, EventArgs e)
        {
            try
            {
                PacienteNegocio negocio = new PacienteNegocio();
                Paciente nuevoPaciente = new Paciente();

                nuevoPaciente.Nombres = txtnombre.Text;
                nuevoPaciente.Apellidos = txtApellido.Text;
                nuevoPaciente.NroDocumento = txtDni.Text;
                nuevoPaciente.Telefono= txtTelefono.Text;
                nuevoPaciente.Email= txtEmail.Text;
                nuevoPaciente.FechaNacimiento = Convert.ToDateTime(txtFecha.Text);
                nuevoPaciente.FechaAlta = DateTime.Today;
                nuevoPaciente.Estado = chbEstado.Checked;
                nuevoPaciente.Imagen= txtImagen.Text;
                nuevoPaciente.Sexo= ddlGenero.Text;
     
                
                if (negocio.AltaPaciente(nuevoPaciente))
                {
                  
                    ///cartel alta de pacinete completa y limpiar controles                

                }
                
            }
            catch (Exception ex)
            {
                throw ex;

            }
        }

    }
}