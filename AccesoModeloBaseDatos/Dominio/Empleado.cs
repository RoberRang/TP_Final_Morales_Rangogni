using System;
using System.ComponentModel.DataAnnotations;

namespace AccesoModeloBaseDatos.Dominio
{
    public class Empleado
    {
        public int ID { get; set; }
        public int idPerfil { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string NroDocumento { get; set; }
        public DateTime FechaAlta { get; set; }
        public int idJornada { get; set; }
        public bool Estado { get; set; }

        public Empleado() : this(0, 1, "", "", "", false, DateTime.Now, 5) { }

        public Empleado(int id, int idPerfil, string nombres, string apellidos, string nroDocumento, bool Estado, DateTime fechaAlta, int idJornada)
        {
            this.ID = id;
            this.idPerfil = idPerfil;
            this.Nombres = nombres;
            this.Apellidos = apellidos;
            this.NroDocumento = nroDocumento;
            this.Estado = Estado;
            this.FechaAlta = fechaAlta;
            this.idJornada = idJornada;
        }
    }
}
