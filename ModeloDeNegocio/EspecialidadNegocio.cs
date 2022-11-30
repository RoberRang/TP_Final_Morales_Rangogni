using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using AccesoModeloBaseDatos.Modelos;
using AccesoModeloBaseDatos.Dominio;

namespace ModeloDeNegocio.Negocio
{ 
    public class EspecialidadNegocio : Especialidad
    {
        private readonly EspecialidadADO tipoEspecialidadADO;
        public EspecialidadNegocio()
        {
            tipoEspecialidadADO = new EspecialidadADO(ConexionStringDB.ConexionBase());
        }
        public bool AltaEspecialidad(string descripcion, bool estado)
        {
            try
            {
                this.IdEspecialidad = 0;
                this.Descripcion = descripcion;
                this.Estado = estado ? "Activo" : "Inactivo";

                return tipoEspecialidadADO.GrabarEspecialidad(this);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool AltaMedicoEspecialidad(int idMedico, int idEsp, bool estado)
        {
            try
            {
                MedicoEspecialidad medicoEspecialidad = new MedicoEspecialidad();
                medicoEspecialidad.IdMedico= idMedico;
                medicoEspecialidad.IdEspecialidad = idEsp;
                medicoEspecialidad.Estado = estado;
                //Validar que la especialidad ya no este cargada para el medico
                if (ControMedicoEspcialidadExiste(idMedico,idEsp))
                    return false;
                return tipoEspecialidadADO.GrabarMedicoEspecialidad(medicoEspecialidad, true);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private bool ControMedicoEspcialidadExiste(int idMedico, int idEsp)
        {
            List<Especialidad> especialidades = tipoEspecialidadADO.ListarMedicoEspecialidades(idMedico);
            Especialidad especialidad = especialidades.Find(x => x.IdEspecialidad.Equals(idEsp));
            if (especialidad != null)
                return true;
            return false;
        }

        public List<Especialidad> Especialidades()
        {
            return tipoEspecialidadADO.ListarEspecialidades();
        }

        public List<Especialidad> MedicoEspecialidades(int idMedico)
        {
            return tipoEspecialidadADO.ListarMedicoEspecialidades(idMedico);
        }
        public bool ModificarEspecialidad(int id, string descripcion, bool estado)
        {
            try
            {
                this.IdEspecialidad = id;
                this.Descripcion = descripcion;
                this.Estado = estado ? "Activo" : "Inactivo";

                return tipoEspecialidadADO.GrabarEspecialidad(this);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool ModificarMedicoEspecialidad(int idMedico, int idEsp, bool estado)
        {
            try
            {
                if (estado.Equals(false) && tipoEspecialidadADO.ListarMedicoEspecialidades(idMedico, true).Count < 2)
                    throw new Exception("Debe tener al menos 1 especialidad activa");

                MedicoEspecialidad medicoEspecialidad = new MedicoEspecialidad();
                medicoEspecialidad.IdMedico = idMedico;
                medicoEspecialidad.IdEspecialidad = idEsp;
                medicoEspecialidad.Estado = estado;

                return tipoEspecialidadADO.GrabarMedicoEspecialidad(medicoEspecialidad, false);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}