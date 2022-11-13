using System;
using System.Collections.Generic;
using AccesoModeloBaseDatos.Modelos;
using AccesoModeloBaseDatos.Dominio;

namespace ModeloDeNegocio.Negocio
{
    public class MedicoNegocio : Medico
    {
        private string MensajeError { get; set; }

        private readonly MedicoADO medicoADO;
        public MedicoNegocio()
        {
            medicoADO = new MedicoADO(ConexionStringDB.ConexionBase());
        }
        public bool AltaMedico(Medico medico)
        {
            bool alta = true;
            try
            {
                Medico medicoBuscado = medicoADO.BuscarMedico(medico.NroDocumento);
                if (medicoBuscado != null)
                    return false;
                ///crear validaciones para medico                
                medicoADO.GrabarMedico(medico, true);

                ///grabar la tabla usuario y contraseña (traigo id medico, crear obj usuario// llamo a usuarioADO para grabarusuario)
                return alta;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<Medico> Medicos()
        {
            return medicoADO.ListarMedicos();
        }
        public bool ModificarMedico(Medico medico)
        {
            try
            {
                return medicoADO.GrabarMedico(medico, false);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool ValidarDatosIngreso(Medico medico)
        { /// recibir un objeto, voy chequear en bd que sea valido. DNI, USUARIO

          ///ACA USO MENSAJE DE ERROR SI ES FALSE
            return true;
        }
    }
}