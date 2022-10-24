using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using AccesoModeloBaseDatos.Dominio;
using AccesoModeloBaseDatos.Modelos;
using Microsoft.Ajax.Utilities;
using TP_Final_Morales_Rangogni.Dominio;

namespace TP_Final_Morales_Rangogni.Negocio
{
    public class EspecialidadNegocio : Especialidad
    {
        private readonly TipoEspecialidadADO tipoEspecialidadADO;
        public EspecialidadNegocio()
        {
            tipoEspecialidadADO = new TipoEspecialidadADO(ConexionStringDB.ConexionBase());
        }
        public bool AltaEspecialidad(string descripcion, bool estado)
        {
            try
            {
                this.IdEspecialidad = 0;
                this.Descripcion = descripcion;
                this.Estado = estado;

                return tipoEspecialidadADO.GrabarEspecialidad(this);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<Especialidad> Especialidades()
        {
            return tipoEspecialidadADO.ListarEspecialidades();
        }
        public bool ModificarEspecialidad(int id, string descripcion, bool estado)
        {
            try
            {
                this.IdEspecialidad = id;
                this.Descripcion = descripcion;
                this.Estado = estado;

                return tipoEspecialidadADO.GrabarEspecialidad(this);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}