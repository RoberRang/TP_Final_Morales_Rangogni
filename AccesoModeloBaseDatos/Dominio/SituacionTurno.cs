using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoModeloBaseDatos.Dominio
{
    public class SituacionTurno
    {
        public int IidSituacion { get; set; }
        public string Descripcion { get; set; }
        public bool Estado { get; set; }

        public SituacionTurno() : this(0, "", false){ }

        public SituacionTurno(int idSituacion, string descripcion, bool estado)
        {
            this.IidSituacion = idSituacion;
            this.Descripcion = descripcion;
            this.Estado = estado;
        }
    }
}
