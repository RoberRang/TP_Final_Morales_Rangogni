using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoModeloBaseDatos.Dominio
{
    public class Especialidad
    {
        public int IdEspecialidad { get; set; }
        public string Descripcion { get; set; }
        public bool Estado { get; set; }

        public Especialidad() : this(1, "Clinica", false) { }

        public Especialidad(int IdEspecialidad, string Descripcion, bool Estado)
        {
            this.IdEspecialidad = IdEspecialidad;
            this.Descripcion = Descripcion;
            this.Estado = Estado;
        }
    }
}
