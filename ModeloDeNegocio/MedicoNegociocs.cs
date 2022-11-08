using System;
using System.Collections.Generic;
using AccesoModeloBaseDatos.Modelos;
using AccesoModeloBaseDatos.Dominio;

namespace ModeloDeNegocio.Negocio
{
    public class MedicoNegocio : Medico
    {
        private string MensajeError { get; set; }

        private readonly MedicoADO empleadoADO;
        public MedicoNegocio()
        {
            empleadoADO = new MedicoADO(ConexionStringDB.ConexionBase());
        }
        public bool AltaMedico(Medico empleado)
        {
            bool alta = true;
            try
            {
                Medico empleadoBuscado = empleadoADO.BuscarMedico(empleado.NroDocumento);
                if (empleadoBuscado != null)
                    return false;
                ///crear validaciones para empleado                
                empleadoADO.GrabarMedico(empleado);

                ///grabar la tabla usuario y contraseña (traigo id empleado, crear obj usuario// llamo a usuarioADO para grabarusuario)
                return alta;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<Medico> Medicos()
        {
            return empleadoADO.ListarMedicos();
        }
        public bool ModificarMedico(Medico empleado)
        {
            try
            {
                return empleadoADO.GrabarMedico(empleado);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool ValidarDatosIngreso(Medico empleado)
        { /// recibir un objeto, voy chequear en bd que sea valido. DNI, USUARIO

          ///ACA USO MENSAJE DE ERROR SI ES FALSE
            return true;
        }
    }
}