using System;

namespace AccesoModeloBaseDatos.Dominio
{
    public class Medico
    {
        public int ID { get; set; }
        public int idEspecialidad { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string NroDocumento { get; set; }
        public bool Estado { get; set; }

        public Medico() : this(0, 0, "", "","", false) { } //VER EL CONSTRUCTOR IDespecialidad

        public Medico(int id, int idEspecialidad, string nombres, string apellidos, string nroDocumento, bool Estado)
        {
            this.ID = id;
            this.idEspecialidad = idEspecialidad;
            this.Nombres = nombres;
            this.Apellidos = apellidos;
            this.NroDocumento = nroDocumento;
            this.Estado = Estado;
        }
    }
}
