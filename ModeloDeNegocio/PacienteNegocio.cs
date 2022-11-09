using System;
using System.Collections.Generic;
using AccesoModeloBaseDatos.Modelos;
using AccesoModeloBaseDatos.Dominio;

namespace ModeloDeNegocio.Negocio
{
    public class PacienteNegocio : Paciente
    {
        private string MensajeError { get; set; }

        private readonly PacienteADO pacienteADO;
        public PacienteNegocio()
        {
            pacienteADO = new PacienteADO(ConexionStringDB.ConexionBase());
        }
        public bool AltaPaciente(Paciente paciente)
        {
            bool alta = true;
            try
            {
                Paciente pacienteBuscado = pacienteADO.BuscarPaciente(paciente.NroDocumento);
                if (pacienteBuscado != null)
                    return false;
                ///crear validaciones para paciente                
                pacienteADO.GrabarPaciente(paciente);

                ///grabar la tabla usuario y contraseña (traigo id paciente, crear obj usuario// llamo a usuarioADO para grabarusuario)
                return alta;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<Paciente> Pacientes()
        {
            return pacienteADO.ListarPacientes();
        }
        public bool ModificarPaciente(Paciente paciente)
        {
            try
            {
                return pacienteADO.GrabarPaciente(paciente);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool ValidarDatosIngreso(Paciente paciente)
        { /// recibir un objeto, voy chequear en bd que sea valido. DNI, USUARIO

          ///ACA USO MENSAJE DE ERROR SI ES FALSE
            return true;
        }
    }
}