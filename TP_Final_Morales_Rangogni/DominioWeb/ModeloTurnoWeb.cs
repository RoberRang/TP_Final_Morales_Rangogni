using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TP_Final_Morales_Rangogni.DominioWeb
{
    public class ModeloTurnoWeb
    {
        public int IdTurno { get; set; }
        public int IdMedico { get; set; }
        public string NombreMedico { get; set; }
        public int IdPaciente { get; set; }
        public string NombrePaciente { get; set; }
        public DateTime FechaReserva { get; set; }
        public string Observacion { get; set; }
        public int IdSituacion { get; set; }
        public string Situacion { get; set; }
        public int Hora { get; set; }
    }
}