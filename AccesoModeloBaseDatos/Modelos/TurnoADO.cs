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
        private const string SQL_INSERT_TURNO = "INSERT INTO Turnos (IdEmpleado, IdPaciente, FechaReserva, Observaciones, IdJornada, Estado, Hora)" +
            " VALUES (@IdEmpleado, @IdPaciente, @FechaReserva, @Observaciones, @IdJornada, @Estado, @Hora)";
        private const string SQL_SELECT_TURNOS = "SELECT IdTurnos, IdEmpleado, IdPaciente, FechaReserva, Observaciones, IdJornada, Estado, Hora FROM Turnos";
        private const string SQL_UPDATE_TURNO = "UPDATE Turnos SET Observaciones = @Observaciones, IdJornada=@IdJornada, Estado=@Estado, Hora=@Hora WHERE IdTurnos = @IdTurno";
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
                    sql = sql.Replace("@IdEmpleado", turno.IdEmpleado.ToString());
                    sql = sql.Replace("@IdPaciente", turno.IdPaciente.ToString());
                    sql = sql.Replace("@FechaReserva", "'" + turno.FechaReserva.ToString("yyyy-MM-dd hh:mm:ss") + "'");
                    sql = sql.Replace("@Observacion", turno.Observacion.Trim());
                    sql = sql.Replace("@IdJornada", turno.IdJornada.ToString());
                    sql = sql.Replace("@Estado", turno.Estado ? "1" : "0");
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

                    sql = sql.Replace("@IdPaciente", turno.IdPaciente.ToString());
                    sql = sql.Replace("@FechaReserva", "'" + turno.FechaReserva.ToString("yyyy-MM-dd hh:mm:ss") + "'");
                    sql = sql.Replace("@Observacion", turno.Observacion.Trim());
                    sql = sql.Replace("@IdJornada", turno.IdJornada.ToString());
                    sql = sql.Replace("@Estado", turno.Estado ? "1" : "0");
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
        public List<Turno> ListarTurnos()
        {
            List<Turno> ListTurnos = new List<Turno>();
            SqlDataReader dr = null;
            AccesoDatos accesoDatos = new AccesoDatos(coneccionDB);
            try
            {

                using (SqlConnection con = accesoDatos.ConnectToDB())
                {
                    SqlCommand cmd = new SqlCommand(SQL_SELECT_TURNOS, con);
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

        private Turno CreateObject(SqlDataReader dr)
        {
            Turno turno = new Turno();
            turno.IdTurno = Convert.ToInt32(dr["IdTurnos"].ToString());
            turno.IdEmpleado = Convert.ToInt32(dr["IdEmpleado"].ToString());
            turno.IdPaciente = Convert.ToInt32(dr["IdPaciente"].ToString());
            turno.FechaReserva = Convert.ToDateTime(dr["FechaReserva"]);
            turno.Observacion = dr["Observacion"].ToString();
            turno.IdJornada = Convert.ToInt32(dr["IdJornada"].ToString());
            turno.Estado = dr["Estado"].ToString().Equals("True") ? true : false;
            turno.Hora = Convert.ToInt32(dr["Hora"].ToString());
            return turno;
        }
    }
}
