using AccesoModeloBaseDatos.Dominio;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace AccesoModeloBaseDatos.Modelos
{
    public class EspecialidadADO
    {
        private const string SQL_INSERT_ESPECIALIDAD = "INSERT INTO Especialidad (Descripcion, Estado) VALUES (@descripcion, @estado)";
        private const string SQL_INSERT_MEDICOESPECIALIDAD = "INSERT INTO MedicosEspecialidad (IdMedico,IdEspecialidad, Estado) VALUES (@idMedico, @idEspecialidad, @estado)";
        private const string SQL_SELECT_ESPECIALIDADES = "SELECT IdEspecialidad, Descripcion, Estado FROM Especialidad";
        private const string SQL_SELECT_MEDICOESPECIALIDADES = "SELECT e.IdEspecialidad, e.Descripcion, e.Estado FROM Especialidad e INNER JOIN MedicosEspecialidad me ON e.IdEspecialidad = me.IdEspecialidad WHERE me.IdMedico = @idMedico";
        private const string SQL_UPDATE_ESPECIALIDAD = "UPDATE Especialidad SET Descripcion = @descripcion, Estado = @estado WHERE IdEspecialidad = @idEspecialidad";
        private const string SQL_UPDATE_MEDICOESPECIALIDAD = "UPDATE MedicosEspecialidad SET Estado = @estado WHERE IdMedico = @idMedico AND IdEspecialidad = @idEspecialidad";
        private readonly string coneccionDB;
        public EspecialidadADO(string coneccion)
        {
            coneccionDB = coneccion;
        }
        // Crear Especialidad
        public bool GrabarEspecialidad(Especialidad especialidad)
        {

            bool response;
            try
            {
                if (especialidad.IdEspecialidad.Equals(0))
                    InsertEspecialidadDB(especialidad);
                else
                    UpdateEspecialidad(especialidad);
                response = true;
            }
            catch (Exception)
            {
                response = false;
            }
            return response;
        }

        public bool GrabarMedicoEspecialidad(MedicoEspecialidad medicoEspecialidad, bool nueva)
        {
            bool response;
            try
            {
                if (nueva)
                    InsertMedicoEspecialidadDB(medicoEspecialidad);
                else
                    UpdateMedicoEspecialidadDB(medicoEspecialidad);
                response = true;
            }
            catch (Exception)
            {
                response = false;
            }
            return response;
        }

        private void InsertEspecialidadDB(Especialidad especialidad)
        {
            AccesoDatos accesoDatos = new AccesoDatos(coneccionDB);
            using (SqlConnection con = accesoDatos.ConnectToDB())
            {
                try
                {
                    SqlCommand cmd = new SqlCommand(SQL_INSERT_ESPECIALIDAD, con);
                    cmd.Parameters.AddWithValue("@descripcion", especialidad.Descripcion);
                    cmd.Parameters.AddWithValue("@estado", especialidad.Estado);
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

        private void InsertMedicoEspecialidadDB(MedicoEspecialidad medicoEspecialidad)
        {
            AccesoDatos accesoDatos = new AccesoDatos(coneccionDB);
            using (SqlConnection con = accesoDatos.ConnectToDB())
            {
                try
                {
                    SqlCommand cmd = new SqlCommand(SQL_INSERT_MEDICOESPECIALIDAD, con);
                    cmd.Parameters.AddWithValue("@idMedico", medicoEspecialidad.IdMedico );
                    cmd.Parameters.AddWithValue("@idEspecialidad", medicoEspecialidad.IdEspecialidad);
                    cmd.Parameters.AddWithValue("@estado", medicoEspecialidad.Estado);
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

        private void UpdateEspecialidad(Especialidad especialidad)
        {
            AccesoDatos accesoDatos = new AccesoDatos(coneccionDB);
            using (SqlConnection con = accesoDatos.ConnectToDB())
            {
                try
                {
                    SqlCommand cmd = new SqlCommand(SQL_UPDATE_ESPECIALIDAD, con);
                    cmd.Parameters.AddWithValue("@idEspecialidad", especialidad.IdEspecialidad);
                    cmd.Parameters.AddWithValue("@descripcion", especialidad.Descripcion);
                    cmd.Parameters.AddWithValue("@estado", especialidad.Estado);
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

        private void UpdateMedicoEspecialidadDB(MedicoEspecialidad medicoEspecialidad)
        {
            AccesoDatos accesoDatos = new AccesoDatos(coneccionDB);
            using (SqlConnection con = accesoDatos.ConnectToDB())
            {
                try
                {
                    SqlCommand cmd = new SqlCommand(SQL_INSERT_MEDICOESPECIALIDAD, con);
                    cmd.Parameters.AddWithValue("@idMedico", medicoEspecialidad.IdMedico);
                    cmd.Parameters.AddWithValue("@idEspecialidad", medicoEspecialidad.IdEspecialidad);
                    cmd.Parameters.AddWithValue("@estado", medicoEspecialidad.Estado);
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

        // Listado de Menus pero lo manejamos por medio de la clase PermisoDAO
        public List<Especialidad> ListarEspecialidades()
        {
            List<Especialidad> Lista = new List<Especialidad>();
            SqlDataReader dr = null;
            AccesoDatos accesoDatos = new AccesoDatos(coneccionDB);
            try
            {
                using (SqlConnection con = accesoDatos.ConnectToDB())
                {
                    SqlCommand cmd = new SqlCommand(SQL_SELECT_ESPECIALIDADES, con);
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

        public List<Especialidad> ListarMedicoEspecialidades(int idMedico, bool activa = true)
        {
            List<Especialidad> Lista = new List<Especialidad>();
            SqlDataReader dr = null;
            AccesoDatos accesoDatos = new AccesoDatos(coneccionDB);
            try
            {
                using (SqlConnection con = accesoDatos.ConnectToDB())
                {
                    string sql = SQL_SELECT_MEDICOESPECIALIDADES;
                    sql = sql.Replace("@idMedico", idMedico.ToString());
                    if (activa)
                        sql += " AND me.Estado = 1";
                    SqlCommand cmd = new SqlCommand(sql, con);
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

        private Especialidad CreateObject(SqlDataReader dr)
        {
            Especialidad objTEspecialidad = new Especialidad();
            objTEspecialidad.IdEspecialidad = Convert.ToInt32(dr["idEspecialidad"].ToString());
            objTEspecialidad.Descripcion = dr["descripcion"].ToString();
            objTEspecialidad.Estado = dr["estado"].ToString().Equals("True") ? "Activo" : "Inactivo";

            return objTEspecialidad;
        }

    }
}

