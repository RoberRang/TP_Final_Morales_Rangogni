using System;
using System.Collections.Generic;
using AccesoModeloBaseDatos.Modelos;
using AccesoModeloBaseDatos.Dominio;

namespace ModeloDeNegocio.Negocio
{
    public class UsuarioNegocio : Usuario
    {
        private string MensajeError { get; set; }

        private readonly EmpleadoADO empleadoADO;
        public UsuarioNegocio()
        {
            empleadoADO = new EmpleadoADO(ConexionStringDB.ConexionBase());
        }
        public bool AltaUsuario(Usuario usuario)
        {
            bool alta = true;
            try
            {
                Empleado empleadoBuscado = empleadoADO.BuscarEmpleado(usuario.NroDocumento);
                if (empleadoBuscado != null)
                    return false;
                ///crear validaciones para empleado                
                if ( empleadoADO.GrabarEmpleado(usuario))
                {
                    //busco empleado creado
                    empleadoBuscado = empleadoADO.BuscarEmpleado(usuario.NroDocumento);
                    usuario.IdUsuario = empleadoBuscado.ID;
                    UsuarioADO usuarioADO = new UsuarioADO(ConexionStringDB.ConexionBase());
                    if (!usuarioADO.InsertUsuarioDB(usuario))
                        empleadoADO.BorrarEmpleado(empleadoBuscado.NroDocumento);


                }

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