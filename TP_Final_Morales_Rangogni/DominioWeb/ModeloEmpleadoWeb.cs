using AccesoModeloBaseDatos.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TP_Final_Morales_Rangogni.DominioWeb
{
    public class ModeloEmpleadoWeb
    {
        public int ID { get; set; }
        public int idPerfil { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string NroDocumento { get; set; }
        public DateTime FechaAlta { get; set; }
        public int idJornada { get; set; }
        public bool Estado { get; set; }


        public ModeloEmpleadoWeb(Empleado empleado)
        {

            ID = empleado.ID;
            Nombres = empleado.Nombres;
            Apellidos = empleado.Apellidos;
            NroDocumento = empleado.NroDocumento;
            idPerfil = empleado.idPerfil;
            idJornada = empleado.idJornada;
            FechaAlta = empleado.FechaAlta;
            Estado = empleado.Estado;

        }
    }
}