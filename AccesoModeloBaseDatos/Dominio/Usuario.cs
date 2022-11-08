using System;

namespace AccesoModeloBaseDatos.Dominio
{
    public class Usuario : Empleado
    {
        public int IdUsuario { get; set; }
        public string User { get; set; }
        public string Password { get; set; }
        public int IdEmpleado { get; set; }
        public Usuario() { }
        public Usuario(int IdUsuario, string user, string password, int idEmp)
        {
            this.IdUsuario = IdUsuario;
            this.User = user;
            this.Password = password;
            this.IdEmpleado = idEmp;
        }
    }
}