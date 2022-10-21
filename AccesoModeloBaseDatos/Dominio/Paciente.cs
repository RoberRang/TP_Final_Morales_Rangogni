using System;

namespace AccesoModeloBaseDatos.Dominio
{
    public class Paciente
    {
        public int IdPaciente { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public char Sexo { get; set; }
        public string NroDocumento { get; set; }
        public string Telefono { get; set; }
        public bool Estado { get; set; }
        public string Imagen { get; set; }
        public DateTime FechaAlta { get; set; }
        public string Email { get; set; }

        public Paciente() : this(1, "", "", DateTime.MinValue, ' ', "", "", false, "", DateTime.Now, "") { }

        public Paciente(int id, string nombres, string apellidos, DateTime fechaNac, char sexo, string nroDocumento, string telefono,
            bool Estado, string imagen, DateTime fechaAlta, string email)
        {
            this.IdPaciente = id;
            this.Nombres = nombres;
            this.Apellidos = apellidos;
            this.FechaNacimiento = fechaNac;
            this.Sexo = sexo;
            this.NroDocumento = nroDocumento;
            this.Telefono = telefono;
            this.Estado = Estado;
            this.FechaAlta = fechaAlta;
            this.Email = email;
        }

    }
}
