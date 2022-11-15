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
        public int IdEmpleado { get; set; }
        public int IdPaciente { get; set; }
        public DateTime FechaReserva { get; set; }
        public string Observacion { get; set; }
        public int IdJornada { get; set; }
        public bool Estado { get; set; }
        public int Hora { get; set; }

        public Turno() : this(0, 0, 0, DateTime.Now, "", 0, false, 0)
        {
        }

        public Turno(int idTurno, int idEmp, int idPaciente, DateTime fechaReserva, string observacion, int idJornada, bool estado, int hora)
        {
            this.IdTurno = idTurno;            
            this.IdEmpleado = idEmp;
            this.IdPaciente = idPaciente;
            this.FechaReserva = fechaReserva;
            this.Observacion = observacion;
            this.IdJornada= idJornada;
            this.Estado = estado;
            this.Hora = hora;
        }
    }
}
