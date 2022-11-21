using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoModeloBaseDatos.Dominio
{
    public class Turno
    {
        public int IdTurno { get; set; }
        public int IdMedico { get; set; }
        public int IdPaciente { get; set; }
        public int IdEspecialidad { get; set; }
        public DateTime FechaReserva { get; set; }
        public string Observacion { get; set; }
        public int IdSituacion { get; set; }
        public int Hora { get; set; }

        public Turno() : this(0, 0, 0, 0, DateTime.Now, "", 0, 0)
        {
        }

        public Turno(int idTurno, int idMedico, int idPaciente, int idEspecialidad, DateTime fechaReserva, string observacion, int idSituacion, int hora)
        {
            this.IdTurno = idTurno;            
            this.IdMedico = idMedico;
            this.IdPaciente = idPaciente;
            this.IdEspecialidad = idEspecialidad;
            this.FechaReserva = fechaReserva;
            this.Observacion = observacion;
            this.IdSituacion= idSituacion;
            this.Hora = hora;
        }
    }
}
