using System;

namespace AccesoModeloBaseDatos.Dominio
{
    public class Medico
    {
        public int ID { get; set; }
        public int idTipoPerfil { get; set; }
        public int idTipoEspecialidad { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string NroDocumento { get; set; }
        public DateTime FechaAlta { get; set; }
        public bool Estado { get; set; }

        public Medico() : this(0, 1, 2 , "", "","", false, DateTime.Now) { } //VER EL CONSTRUCTOR IDespecialidad

        public Medico(int id, int idTipoPerfil, int idTipoEspecialidad, string nombres, string apellidos, string nroDocumento, bool Estado, DateTime fechaAlta)
        {
            this.ID = id;
            this.idTipoPerfil = idTipoPerfil;
            this.idTipoEspecialidad = idTipoEspecialidad;
            this.Nombres = nombres;
            this.Apellidos = apellidos;
            this.NroDocumento = nroDocumento;
            this.Estado = Estado;
            this.FechaAlta = fechaAlta;
        }
    }
}
