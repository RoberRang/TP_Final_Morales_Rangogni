using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using AccesoModeloBaseDatos.Modelos;
using AccesoModeloBaseDatos.Dominio;

namespace ModeloDeNegocio.Negocio
{ 
    public class SituacionTurnoNegocio : SituacionTurno
    {
        private readonly SituacionTurnoADO situacionTurnoAdo;
        public SituacionTurnoNegocio()
        {
            situacionTurnoAdo = new SituacionTurnoADO(ConexionStringDB.ConexionBase());
        }
        public bool AltaSituacion(string situacion, bool estado)
        {
            try
            {
                this.IdSituacion = 0;
                this.Situacion = situacion;
                this.Estado = estado;

                return situacionTurnoAdo.GrabarSituacionTurno(this);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<SituacionTurno> GetSituacionTurnos()
        {
            return situacionTurnoAdo.ListarSituacionTurno();
        }
        public bool ModificarSituacionTurano(int id, string situacion, bool estado)
        {
            try
            {
                this.IdSituacion = id;
                this.Situacion = situacion;
                this.Estado = estado;

                return situacionTurnoAdo.GrabarSituacionTurno(this);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}