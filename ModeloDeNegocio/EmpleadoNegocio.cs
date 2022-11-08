using System;
using System.Collections.Generic;
using AccesoModeloBaseDatos.Modelos;
using AccesoModeloBaseDatos.Dominio;

namespace ModeloDeNegocio.Negocio
{
    public class EmpleadoNegocio : Empleado
    {
        private string MensajeError { get; set; }

        private readonly EmpleadoADO empleadoADO;
        public EmpleadoNegocio()
        {
            empleadoADO = new EmpleadoADO(ConexionStringDB.ConexionBase());
        }
        public bool AltaEmpleado(Empleado empleado)
        {
            bool alta = true;
            try
            {
                Empleado empleadoBuscado = empleadoADO.BuscarEmpleado(empleado.NroDocumento);
                if (empleadoBuscado != null)
                    return false;
                    ///crear validaciones para empleado                
                    empleadoADO.GrabarEmpleado(empleado);
                
                ///grabar la tabla usuario y contraseña (traigo id empleado, crear obj usuario// llamo a usuarioADO para grabarusuario)
                return alta;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<Empleado> Empleados()
        {
            return empleadoADO.ListarEmpleados();
        }
        public bool ModificarEmpleado(Empleado empleado)
        {
            try
            {
                return empleadoADO.GrabarEmpleado(empleado);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool ValidarDatosIngreso(Empleado empleado)
        { /// recibir un objeto, voy chequear en bd que sea valido. DNI, USUARIO

          ///ACA USO MENSAJE DE ERROR SI ES FALSE
            return true;
        }
    }
}