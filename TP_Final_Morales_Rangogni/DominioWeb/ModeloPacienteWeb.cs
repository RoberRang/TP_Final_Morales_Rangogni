using AccesoModeloBaseDatos.Dominio;
using System;

namespace TP_Final_Morales_Rangogni.DominioWeb
{
    public class ModeloPacienteWeb
    {
        public int IdPaciente { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string NroDocumento { get; set; }
        public string FechaNacimiento { get; set; }
        public string Sexo { get; set; }
        public DateTime FechaAlta { get; set; }
        public string Estado { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }
        public string Imagen { get; set; }

        public ModeloPacienteWeb(Paciente paciente) { 
            
            IdPaciente=paciente.IdPaciente;
            Nombres=paciente.Nombres;
            Apellidos=paciente.Apellidos;
            NroDocumento=paciente.NroDocumento;
            FechaNacimiento = paciente.FechaNacimiento.ToString("dd-MM-yyyy");
            Sexo= paciente.Sexo;
            FechaAlta = paciente.FechaAlta; //.ToString("dd-MM-yyyy");
            Estado = Convert.ToString(paciente.Estado?"Activo":"Inactivo");
            Telefono = paciente.Telefono; 
            Email= paciente.Email;
            Imagen= paciente.Imagen;
        }
    }
   
}