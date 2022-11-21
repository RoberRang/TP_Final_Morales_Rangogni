using AccesoModeloBaseDatos.Dominio;
using AccesoModeloBaseDatos.Modelos;
using ModeloDeNegocio.Negocio;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics.SymbolStore;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace ModeloDeNegocio
{
    public class TurnoNegocio
    {
        private readonly TurnoADO turnoADO;
        public TurnoNegocio()
        {
            turnoADO = new TurnoADO(ConexionStringDB.ConexionBase());
        }
        public List<Turno> ListaTurnos(int IdMedico, DateTime fechaTurno)
        {
            return turnoADO.ListarTurnosMedicoFecha(IdMedico, fechaTurno);
        }

        public DataTable DataTableTurnosFecha(DateTime fechaTurno)
        {
            return turnoADO.DataTableTurnosFecha(fechaTurno);
        }

        public bool GrabarTurno(Turno turno)
        {
            return turnoADO.GrabarTurno(turno);
        }

        public List<int> TurnosMedicoFecha(int idMedico, DateTime fechaDia)
        {
            List<int> listTurnosDia;
            int totalHorasJonada;
            try
            {
                JornadaNegocio jornadaNegocio = new JornadaNegocio();
                EmpleadoADO empleadoADO = new EmpleadoADO(ConexionStringDB.ConexionBase());
                Empleado empleado = empleadoADO.BuscarEmpleado(idMedico);
                Jornada jornada = jornadaNegocio.BuscarJornada(empleado.idJornada);
                
                List<Turno> turnos = turnoADO.ListarTurnosMedicoFecha(idMedico, fechaDia);
                totalHorasJonada = jornada.Fin - jornada.Inicio;
                if (turnos.Count == totalHorasJonada)
                    return new List<int>();

                //Inicio con todos los horarios posibles para la jornada
                listTurnosDia = new List<int>();
                for (int i = jornada.Inicio; i < jornada.Fin; i++)
                    listTurnosDia.Add(i);

                //si no hay turnos tomados para ese dia estan todos disponibles retorno el total completo
                if (turnos.Count == 0)
                    return listTurnosDia;

                //si hay turnos tomados, saca los turnos de la lista que coinciden
                if (turnos.Count > 0)
                {
                    foreach(Turno turno in turnos)
                    {
                        int horaEncontrada = listTurnosDia.Find(x => x.Equals(turno.Hora));
                        listTurnosDia.Remove(horaEncontrada);
                    }                    
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return listTurnosDia;

        }
    }
}
