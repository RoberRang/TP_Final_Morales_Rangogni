using System;
using System.Collections.Generic;
using AccesoModeloBaseDatos.Modelos;
using AccesoModeloBaseDatos.Dominio;

namespace ModeloDeNegocio.Negocio
{
    public class EmpleadoNegocio : Empleado
    {
        private string MensajeError { get; set; }

        private readonly EmpleadoADO empleadoADO ;
        public EmpleadoNegocio()
        {
            empleadoADO= new EmpleadoADO(ConexionStringDB.ConexionBase());
        }
        public bool AltaEmpleado(Empleado empleado)
        {
            try
            {   
                ///crear validaciones para empleado
                return empleadoADO.GrabarEmpleado(empleado);
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