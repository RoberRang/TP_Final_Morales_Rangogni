using AccesoModeloBaseDatos.Dominio;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoModeloBaseDatos.Modelos
{
    public class TurnoADO
    {
        private const string SQL_INSERT_TURNO = "INSERT INTO Turnos (IdMedico, IdPaciente, IdEspecialidad, FechaReserva, Observacion, IdSituacion, Hora)" +
            " VALUES (@IdEmpleado, @IdPaciente, @IdEspecialidad, @FechaReserva, @Observacion, @IdSituacion, @Hora)";
        private const string SQL_SELECT_TURNOS = "SELECT IdTurnos, IdMedico, IdEspecialidad, IdPaciente, FechaReserva, Observacion, IdSituacion, Hora FROM Turnos";
        private const string SQL_UPDATE_TURNO = "UPDATE Turnos SET Observacion = @Observacion, IdSituacion=@IdSituacion, IdEspecialidad=@IdEspecialidad, Hora=@Hora WHERE IdTurnos = @IdTurno";
        private const string SQL_SELECT_TURNOSDIA = "SELECT t.IdTurnos IdTurno, t.IdMedico, e.Apellido + ', ' + e.Nombre NombreMedico, t.IdPaciente, p.Apellidos + ', ' + p.Nombres NombrePaciente, " +
            "t.IdEspecialidad, es.descripcion, t.FechaReserva, t.Observacion, t.IdSituacion, st.Situacion, t.Hora FROM Turnos t INNER JOIN Empleados e ON t.IdMedico = e.Id INNER JOIN Pacientes P ON t.IdPaciente = p.IdPaciente " +
            "INNER JOIN Especialidad es ON t.IdEspecialidad = es.IdEspecialidad INNER JOIN SituacionTurno st ON t.IdSituacion = st.IdSituacion WHERE CAST(t.FechaReserva AS DATE) = @FechaDia";
        private readonly string coneccionDB;
        public TurnoADO(string coneccion)
        {
            coneccionDB = coneccion;
        }
        // Crear Perfil
        public bool GrabarTurno(Turno turno)
        {

            bool response;
            try
            {
                if (turno.IdTurno.Equals(0))
                    InsertTurnoDB(turno);
                else
                    UpdateTurnoDB(turno);
                response = true;
            }
            catch (Exception)
            {
                response = false;
            }
            return response;
        }

        private void InsertTurnoDB(Turno turno)
        {
            AccesoDatos accesoDatos = new AccesoDatos(coneccionDB);
            using (SqlConnection con = accesoDatos.ConnectToDB())
            {
                try
                {
                    string sql = SQL_INSERT_TURNO;
                    sql = sql.Replace("@IdEmpleado", turno.IdMedico.ToString());
                    sql = sql.Replace("@IdPaciente", turno.IdPaciente.ToString());
                    sql = sql.Replace("@IdEspecialidad", turno.IdEspecialidad.ToString());
                    sql = sql.Replace("@FechaReserva", "'" + turno.FechaReserva.ToString("yyyy-MM-dd hh:mm:ss") + "'");
                    sql = sql.Replace("@Observacion", "'" + turno.Observacion.Trim() + "'");
                    sql = sql.Replace("@IdSituacion", turno.IdSituacion.ToString());
                    sql = sql.Replace("@Hora", turno.Hora.ToString());

                    SqlCommand cmd = new SqlCommand(sql, con);
                    cmd.CommandType = CommandType.Text;
                    accesoDatos.ExecuteCommand(cmd);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    accesoDatos.CloseConnection();
                }
            }
        }

        private void UpdateTurnoDB(Turno turno)
        {
            AccesoDatos accesoDatos = new AccesoDatos(coneccionDB);
            using (SqlConnection con = accesoDatos.ConnectToDB())
            {
                try
                {
                    string sql = SQL_UPDATE_TURNO;
                    sql = sql.Replace("@IdTurnos", turno.IdTurno.ToString());
                    sql = sql.Replace("@IdEspecialidad", turno.IdEspecialidad.ToString());
                    sql = sql.Replace("@IdPaciente", turno.IdPaciente.ToString());
                    sql = sql.Replace("@FechaReserva", "'" + turno.FechaReserva.ToString("yyyy-MM-dd hh:mm:ss") + "'");
                    sql = sql.Replace("@Observacion", turno.Observacion.Trim());
                    sql = sql.Replace("@IdSituacion", turno.IdSituacion.ToString());
                    sql = sql.Replace("@Hora", turno.Hora.ToString());
                    SqlCommand cmd = new SqlCommand(sql, con);
                    cmd.CommandType = CommandType.Text;
                    accesoDatos.ExecuteCommandString(cmd.CommandText);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    accesoDatos.CloseConnection();
                }
            }
        }

        // Listado de Menus pero lo manejamos por medio de la clase PermisoDAO
        public List<Turno> ListarTurnosMedicoFecha(int IdMedico, DateTime fechaTurno)
        {
            List<Turno> ListTurnos = new List<Turno>();
            SqlDataReader dr = null;
            AccesoDatos accesoDatos = new AccesoDatos(coneccionDB);
            try
            {

                using (SqlConnection con = accesoDatos.ConnectToDB())
                {
                    string sql = SQL_SELECT_TURNOS;
                    sql = sql + " WHERE IdMedico = " + IdMedico + " AND CAST(FechaReserva AS DATE) = '" + fechaTurno.ToString("yyyy-MM-dd") + "'";

                    SqlCommand cmd = new SqlCommand(sql, con);
                    cmd.CommandType = CommandType.Text;
                    dr = accesoDatos.SelectDataReaderFromSqlCommand(cmd);

                    while (dr.Read())
                    {
                        ListTurnos.Add(CreateObject(dr));
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                accesoDatos.CloseConnection();
            }

            return ListTurnos;
        }

        public DataTable DataTableTurnosFecha(DateTime fechaTurno)
        {           
            AccesoDatos accesoDatos = new AccesoDatos(coneccionDB);
            DataTable dtRes = null;
            try
            {

                using (SqlConnection con = accesoDatos.ConnectToDB())
                {
                    string sql = SQL_SELECT_TURNOSDIA;
                    sql = sql.Replace("@FechaDia", "'" + fechaTurno.ToString("yyyy-MM-dd") + "'");
                    dtRes = accesoDatos.SelectDataTable(sql);
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                accesoDatos.CloseConnection();
            }

            return dtRes;
        }

        private Turno CreateObject(SqlDataReader dr)
        {
            Turno turno = new Turno();
            turno.IdTurno = Convert.ToInt32(dr["IdTurnos"].ToString());
            turno.IdMedico = Convert.ToInt32(dr["IdMedico"].ToString());
            turno.IdPaciente = Convert.ToInt32(dr["IdPaciente"].ToString());
            turno.IdEspecialidad = Convert.ToInt32(dr["IdEspecialidad"].ToString());
            turno.FechaReserva = Convert.ToDateTime(dr["FechaReserva"]);
            turno.Observacion = dr["Observacion"].ToString();
            turno.IdSituacion = Convert.ToInt32(dr["IdSituacion"].ToString());
            turno.Hora = Convert.ToInt32(dr["Hora"].ToString());
            return turno;
        }

    }
}
