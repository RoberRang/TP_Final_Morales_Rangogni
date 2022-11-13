using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoModeloBaseDatos.Dominio
{
    public class JornadaTurno
    {
        public int IdJornada { get; set; }
        public string Descripcion { get; set; }
        public bool Estado { get; set; }
        public int Inicio { get; set; }
        public int Fin { get; set; }

        public JornadaTurno() : this(0, "", false, 0, 0) { }

        public JornadaTurno(int idJornada, string descripcion, bool estado, int inicio, int fin)
        {
            this.IdJornada = idJornada;
            this.Descripcion = descripcion;
            this.Estado = estado;
            this.Inicio = inicio;
            this.Fin = fin;
        }
    }
}
