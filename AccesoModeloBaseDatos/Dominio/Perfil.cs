namespace AccesoModeloBaseDatos.Dominio
{
    public class Perfil
    {
        public int IdPerfil { get; set; }
        public string Descripcion { get; set; }
        public bool Estado { get; set; }

        public Perfil()
        {
        }

        public Perfil(int ID, string Descripcion, bool Estado)
        {
            IdPerfil = ID;
            this.Descripcion = Descripcion;
            this.Estado = Estado;
        }
    }
}