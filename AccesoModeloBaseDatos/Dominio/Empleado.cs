using System;

namespace AccesoModeloBaseDatos.Dominio
{
    public class Empleado
    {
        public int ID { get; set; }
        public int idTipoPerfil { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string NroDocumento { get; set; }
        public DateTime FechaAlta { get; set; }
        public bool Estado { get; set; }

        public Empleado() : this(1, 1, "", "", "", false, DateTime.Now) { }

        public Empleado(int id, int idTipoPerfil, string nombre, string apellido, string nroDocumento, bool Estado, DateTime fechaAlta)
        {
            this.ID = id;
            this.idTipoPerfil = idTipoPerfil;
            this.Nombre = nombre;
            this.Apellido = apellido;
            this.NroDocumento = nroDocumento;
            this.Estado = Estado;
            this.FechaAlta = fechaAlta;
        }
    }
}
