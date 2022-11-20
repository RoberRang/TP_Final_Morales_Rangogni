using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoModeloBaseDatos.Dominio
{
    public class SituacionTurno
    {
        public int IdSituacion { get; set; }
        public string Situacion { get; set; }
        public bool Estado { get; set; }
        public SituacionTurno() { }

        public SituacionTurno(int idSitacion, string situacion, bool estado) 
        {
            IdSituacion = idSitacion;
            Situacion = situacion;
            Estado = estado;
        }
    }
}
