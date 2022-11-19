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
    public class JornadaADO
    {
        private const string SQL_INSERT_JORNADA = "INSERT INTO Jornadas (descripcion, estado, Inicio, Fin) VALUES (@descripcion, @estado, @inicio, @fin)";
        private const string SQL_SELECT_JORNADAS = "SELECT idJornada, Descripcion, Estado, Inicio, Fin FROM Jornadas";
        private const string SQL_UPDATE_JORNADA = "UPDATE Jornadas SET Descripcion = @descripcion, Estado = @estado, Inicio=@inicio, Fin=@fin WHERE IdJornada = @idJornada";
        private readonly string coneccionDB;
        public JornadaADO(string coneccion)
        {
            coneccionDB = coneccion;
        }
        // Crear Perfil
        public bool GrabarJornada(Jornada jornada)
        {

            bool response;
            try
            {
                if (jornada.IdJornada.Equals(0))
                    InsertJornadaDB(jornada);
                else
                    UpdateJornadaDB(jornada);
                response = true;
            }
            catch (Exception)
            {
                response = false;
            }
            return response;
        }

        private void InsertJornadaDB(Jornada jornada)
        {
            AccesoDatos accesoDatos = new AccesoDatos(coneccionDB);
            using (SqlConnection con = accesoDatos.ConnectToDB())
            {
                try
                {
                    string sql = SQL_INSERT_JORNADA;
                    sql = sql.Replace("@descripcion", "'" + jornada.Descripcion + "'");
                    sql = sql.Replace("@estado", jornada.Estado ? "1" : "0");
                    sql = sql.Replace("@inicio", jornada.Inicio.ToString());
                    sql = sql.Replace("@fin", jornada.Fin.ToString());
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

        private void UpdateJornadaDB(Jornada jornada)
        {
            AccesoDatos accesoDatos = new AccesoDatos(coneccionDB);
            using (SqlConnection con = accesoDatos.ConnectToDB())
            {
                try
                {
                    string sql = SQL_UPDATE_JORNADA;
                    sql = sql.Replace("@idJornada", jornada.IdJornada.ToString());
                    sql = sql.Replace("@descripcion", jornada.Descripcion);
                    sql = sql.Replace("@estado", jornada.Estado ? "1" : "0");
                    sql = sql.Replace("@inicio", jornada.Inicio.ToString());
                    sql = sql.Replace("@fin", jornada.Fin.ToString());
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
        public List<Jornada> ListarJornadas()
        {
            List<Jornada> Lista = new List<Jornada>();
            SqlDataReader dr = null;
            AccesoDatos accesoDatos = new AccesoDatos(coneccionDB);
            try
            {

                using (SqlConnection con = accesoDatos.ConnectToDB())
                {
                    SqlCommand cmd = new SqlCommand(SQL_SELECT_JORNADAS, con);
                    cmd.CommandType = CommandType.Text;
                    dr = accesoDatos.SelectDataReaderFromSqlCommand(cmd);

                    while (dr.Read())
                    {
                        Lista.Add(CreateObject(dr));
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

            return Lista;
        }

        private Jornada CreateObject(SqlDataReader dr)
        {
            Jornada jornada = new Jornada();
            jornada.IdJornada = Convert.ToInt32(dr["IdJornada"].ToString());
            jornada.Descripcion = dr["Descripcion"].ToString();
            jornada.Estado = dr["Estado"].ToString().Equals("True") ? true : false;
            jornada.Inicio = Convert.ToInt32(dr["Inicio"].ToString());
            jornada.Fin = Convert.ToInt32(dr["Fin"].ToString());
            return jornada;
        }
    }
}
