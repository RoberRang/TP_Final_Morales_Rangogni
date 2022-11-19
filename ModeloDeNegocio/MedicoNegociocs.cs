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

        public List<Medico> MedicosEspecialidad(int idEspecialidad)
        {
            return medicoADO.ListarMedicoEspecialidad(idEspecialidad);
        }

        public bool ModificarMedicoEspecialidad(Medico medico, bool esInsert = false)
        {
            try
            {
                return medicoADO.GrabarMedicoEspecialidad(medico, esInsert);
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