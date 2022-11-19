using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoModeloBaseDatos.Dominio
{
    public class Jornada
    {
        public int IdJornada { get; set; }
        public string Descripcion { get; set; }
        public bool Estado { get; set; }
        public int Inicio { get; set; }
        public int Fin { get; set; }

        public Jornada() : this(0, "", false, 0, 0) { }

        public Jornada(int idJornada, string descripcion, bool estado, int inicio, int fin)
        {
            this.IdJornada = idJornada;
            this.Descripcion = descripcion;
            this.Estado = estado;
            this.Inicio = inicio;
            this.Fin = fin;
        }
    }
}
