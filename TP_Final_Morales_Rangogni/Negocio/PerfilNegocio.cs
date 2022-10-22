using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using AccesoModeloBaseDatos.Dominio;
using AccesoModeloBaseDatos.Modelos;
using Microsoft.Ajax.Utilities;

namespace TP_Final_Morales_Rangogni.Negocio
{
    public class PerfilNegocio : Perfil
    {
        private readonly TipoPerfilADO tipoPerfilADO;
        public PerfilNegocio()
        {
            tipoPerfilADO = new TipoPerfilADO(ConfigurationManager.ConnectionStrings["ClinicaDB"].ToString());
        }
        public bool AltaPerfil(string descripcion, bool estado)
        {
            try
            {
                this.IdPerfil = 0;
                this.Descripcion = descripcion;
                this.Estado = estado;

                return tipoPerfilADO.GrabarPerfil(this);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<Perfil> Perliles()
        {
            return tipoPerfilADO.ListarPerfiles();
        }
        public bool ModificarPerfil(int id, string descripcion, bool estado)
        {
            try
            {
                this.IdPerfil = id;
                this.Descripcion = descripcion;
                this.Estado = estado;

                return tipoPerfilADO.GrabarPerfil(this);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}