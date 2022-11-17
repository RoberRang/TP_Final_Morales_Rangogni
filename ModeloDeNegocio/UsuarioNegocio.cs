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
        public bool AltaUsuario(Usuario usuario, int idEspecialidad = 1)
        {
            bool alta = true;
            try
            {
                UsuarioADO usuarioADO = new UsuarioADO(ConexionStringDB.ConexionBase());
                Empleado empleadoBuscado = empleadoADO.BuscarEmpleado(usuario.NroDocumento);
                int cantUsuarioLogin = usuarioADO.BuscarUsuario(usuario);
                if (empleadoBuscado != null || cantUsuarioLogin > 0)
                    return false;
                ///crear validaciones para empleado                
                if (empleadoADO.GrabarEmpleado(usuario))
                {
                    //busco empleado creado
                    empleadoBuscado = empleadoADO.BuscarEmpleado(usuario.NroDocumento);
                    usuario.IdEmpleado = empleadoBuscado.ID;

                    if (!usuarioADO.InsertUsuarioDB(usuario))
                        empleadoADO.BorrarEmpleado(empleadoBuscado.NroDocumento);
                    if (usuario.idTipoPerfil.Equals(2))
                    {
                        Medico medico = new Medico();
                        medico.ID = empleadoBuscado.ID;
                        medico.idEspecialidad = idEspecialidad;
                        medico.Estado = usuario.Estado;
                        MedicoADO medicoADO = new MedicoADO(ConexionStringDB.ConexionBase());
                        medicoADO.GrabarMedico(medico, true);
                    }
                }

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
        public Empleado ValidarDatosIngreso(Usuario user)
        {

            Empleado empleado = empleadoADO.BuscarEmpleadoLogin(user);

            return empleado;
        }
    }
}