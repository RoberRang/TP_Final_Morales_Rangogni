using System;

namespace AccesoModeloBaseDatos.Dominio
{
    public class Empleado
    {
        public int ID { get; set; }
        public int idTipoPerfil { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string NroDocumento { get; set; }
        public DateTime FechaAlta { get; set; }
        public bool Estado { get; set; }

        public Empleado() : this(1, 1, "", "", "", false, DateTime.Now) { }

        public Empleado(int id, int idTipoPerfil, string nombres, string apellidos, string nroDocumento, bool Estado, DateTime fechaAlta)
        {
            this.ID = id;
            this.idTipoPerfil = idTipoPerfil;
            this.Nombres = nombres;
            this.Apellidos = apellidos;
            this.NroDocumento = nroDocumento;
            this.Estado = Estado;
            this.FechaAlta = fechaAlta;
        }
    }
}
