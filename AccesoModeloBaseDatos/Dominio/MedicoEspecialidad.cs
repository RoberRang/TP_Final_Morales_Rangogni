using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoModeloBaseDatos.Dominio
{
    public class MedicoEspecialidad
    {
        public int IdMedico { get; set; }
        public int IdEspecialidad { get; set; }
        public bool Estado { get; set; }

        public MedicoEspecialidad() : this(0, 0, false) { }

        public MedicoEspecialidad(int idMedico, int idEspecialidad, bool Estado)
        {
            this.IdMedico = idMedico;
            this.IdEspecialidad = idEspecialidad;
            this.Estado = Estado;
        }
    }
}
