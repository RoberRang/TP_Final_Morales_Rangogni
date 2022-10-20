using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AccesoModeloBaseDatos.Dominio
{
    public class TipoPerfil
    {
        public int IdPerfil { get; set; }
        public string Descripcion { get; set; }
        public bool Estado { get; set; }

        public TipoPerfil()
        {
        }

        public TipoPerfil(int ID, string Descripcion, bool Estado)
        {
            IdPerfil = ID;
            this.Descripcion = Descripcion;
            this.Estado = Estado;
        }
    }
}