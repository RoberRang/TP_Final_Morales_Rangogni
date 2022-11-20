using AccesoModeloBaseDatos.Dominio;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace AccesoModeloBaseDatos.Modelos
{
    public class SituacionTurnoADO
    {
        private const string SQL_INSERT_SITUACIONTURNO = "INSERT INTO SituacionTurno (Situacion, Estado) VALUES (@Situacion, @Estado)";
        private const string SQL_SELECT_SITUACIONTURNO = "SELECT IdSituacion, Situacion, Estado FROM SituacionTurno";
        private const string SQL_UPDATE_SITUACIONTURNO = "UPDATE SituacionTurno SET Situacion = @Situacion, Estado = @Estado WHERE IdSituacion = @IdSituacion";
        private readonly string coneccionDB;
        public SituacionTurnoADO(string coneccion)
        {
            coneccionDB = coneccion;
        }
        // Crear Perfil
        public bool GrabarSituacionTurno(SituacionTurno situacionTurno)
        {

            bool response;
            try
            {
                if (situacionTurno.IdSituacion.Equals(0))
                    InsertSituacionDB(situacionTurno);
                else
                    UpdateSituacionDB(situacionTurno);
                response = true;
            }
            catch (Exception)
            {
                response = false;
            }
            return response;
        }

        private void InsertSituacionDB(SituacionTurno situacionTurno)
        {
            AccesoDatos accesoDatos = new AccesoDatos(coneccionDB);
            using (SqlConnection con = accesoDatos.ConnectToDB())
            {
                try
                {
                    SqlCommand cmd = new SqlCommand(SQL_INSERT_SITUACIONTURNO, con);
                    cmd.Parameters.AddWithValue("@Situacion", situacionTurno.Situacion);
                    cmd.Parameters.AddWithValue("@Estado", situacionTurno.Estado);
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

        private void UpdateSituacionDB(SituacionTurno situacionTurno)
        {
            AccesoDatos accesoDatos = new AccesoDatos(coneccionDB);
            using (SqlConnection con = accesoDatos.ConnectToDB())
            {
                try
                {
                    SqlCommand cmd = new SqlCommand(SQL_UPDATE_SITUACIONTURNO, con);
                    cmd.Parameters.AddWithValue("@IdSituacion", situacionTurno.IdSituacion);
                    cmd.Parameters.AddWithValue("@Situacion", situacionTurno.Situacion);
                    cmd.Parameters.AddWithValue("@Estado", situacionTurno.Estado);
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
        public List<SituacionTurno> ListarSituacionTurno()
        {
            List<SituacionTurno> Lista = new List<SituacionTurno>();
            SqlDataReader dr = null;
            AccesoDatos accesoDatos = new AccesoDatos(coneccionDB);
            try
            {

                using (SqlConnection con = accesoDatos.ConnectToDB())
                {
                    SqlCommand cmd = new SqlCommand(SQL_SELECT_SITUACIONTURNO, con);
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

        private SituacionTurno CreateObject(SqlDataReader dr)
        {
            SituacionTurno objSituacion = new SituacionTurno();
            objSituacion.IdSituacion = Convert.ToInt32(dr["IdSituacion"].ToString());
            objSituacion.Situacion = dr["Situacion"].ToString();
            objSituacion.Estado = dr["Estado"].ToString().Equals("True") ? true : false;

            return objSituacion;
        }
    }
}
