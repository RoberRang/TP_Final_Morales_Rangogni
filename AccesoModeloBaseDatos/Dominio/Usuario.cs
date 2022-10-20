using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AccesoModeloBaseDatos.Dominio
{
    public class Usuario : Empleado
    {
        public int IdUsuario { get; set; }
        public string user { get; set; }
        public string password { get; set; }
        public bool estado { get; set; }

        public string TipUser { get; set; }

        public Usuario() : base()
        {

        }

        public Usuario(int IdUsuario, string user, string password, bool estado, string TipUser)
            : base(0, new TipoPerfil(), "", "", "", "", true, "", "", "")
        {
            this.IdUsuario = IdUsuario;
            this.user = user;
            this.password = password;
            this.estado = estado;
            this.TipUser = TipUser;
        }
    }
}