using AccesoModeloBaseDatos;
using AccesoModeloBaseDatos.Dominio;
using AccesoModeloBaseDatos.Modelos;
using ModeloDeNegocio.Negocio;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TP_Final_Morales_Rangogni.DominioWeb;

namespace TP_Final_Morales_Rangogni
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void btnVerEmp_Click(object sender, EventArgs e)
        {
            UsuarioNegocio usuarioNegocio = new UsuarioNegocio();
            List<Empleado> empleadosBuscados = usuarioNegocio.Empleados();

            dgEmpleados.DataSource = empleadosBuscados;
            dgEmpleados.DataBind();
        }

        protected void btnVerPac_Click(object sender, EventArgs e)
        {
            PacienteNegocio pacienteNegocio = new PacienteNegocio();
            List<ModeloPacienteWeb> pacientesBuscados = new List<ModeloPacienteWeb>();
            foreach (Paciente paciente in pacienteNegocio.Pacientes())
            {
                ModeloPacienteWeb modeloPaciente = new ModeloPacienteWeb(paciente);
                pacientesBuscados.Add(modeloPaciente);
            }

            dgvPacientes.DataSource = pacientesBuscados;
            dgvPacientes.DataBind();
        }
    }
}