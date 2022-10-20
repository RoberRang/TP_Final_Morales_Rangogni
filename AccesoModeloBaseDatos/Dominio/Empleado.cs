using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AccesoModeloBaseDatos.Dominio
{
    public class Empleado
    {
        public int ID { get; set; }
        public TipoPerfil RTipoEmpleado { get; set; }
        public string Nombre { get; set; }
        public string ApPaterno { get; set; }
        public string ApMaterno { get; set; }
        public string NroDocumento { get; set; }
        public bool Estado { get; set; }
        public string Imagen { get; set; }
        public string Usuario { get; set; }
        public string Clave { get; set; }

        public Empleado() : this(0, new TipoPerfil(), "", "", "", "", false, "", "", "") { }

        public Empleado(int ID, TipoPerfil RTipoEmpleado, string Nombre, string ApPaterno, string ApMaterno, string NroDocumento, bool Estado, string Imagen, string Usuario, string Clave)
        {
            this.ID = ID;
            this.RTipoEmpleado = RTipoEmpleado;
            this.Nombre = Nombre;
            this.ApPaterno = ApPaterno;
            this.ApMaterno = ApMaterno;
            this.NroDocumento = NroDocumento;
            this.Estado = Estado;
            this.Imagen = Imagen;
            this.Usuario = Usuario;
            this.Clave = Clave;
        }
    }
}