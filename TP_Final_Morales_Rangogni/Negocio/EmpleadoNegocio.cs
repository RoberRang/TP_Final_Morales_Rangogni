using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using TP_Final_Morales_Rangogni.Dominio;
using AccesoModeloBaseDatos.Modelos;
using Microsoft.Ajax.Utilities;
using AccesoModeloBaseDatos.Dominio;

namespace TP_Final_Morales_Rangogni.Negocio
{
    public class EmpleadoNegocio : Empleado
    {
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
    }
}