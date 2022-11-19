using System;
using System.Collections.Generic;

namespace AccesoModeloBaseDatos.Dominio
{
    public class Medico
    {
        public int ID { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string NroDocumento { get; set; }
        public List<Especialidad> Especialidades { get; set; }
        public bool Estado { get; set; }

        public Medico() : this(0, new List<Especialidad>(), "", "","", false) { } //VER EL CONSTRUCTOR IDespecialidad

        public Medico(int id, List<Especialidad> especialidades, string nombres, string apellidos, string nroDocumento, bool Estado)
        {
            this.ID = id;
            this.Especialidades = especialidades;
            this.Nombres = nombres;
            this.Apellidos = apellidos;
            this.NroDocumento = nroDocumento;
            this.Estado = Estado;
        }
    }
}
