using AccesoModeloBaseDatos.Dominio;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace AccesoModeloBaseDatos.Modelos
{
    public class MedicoADO
    {
        private const string SQL_INSERT_MEDICOSESPECIALIDAD = "INSERT INTO MedicosEspecialidad (IdMedico,IdEspecialidad,estado) VALUES (@idMedico,@IdEspecialidad,@estado)";
        private const string SQL_SELECT_MEDICOS = "SELECT DISTINCT ms.IdMedico, e.Nombre, e.Apellido, e.NroDocumento, e.Estado FROM Empleados e" +
            " INNER JOIN MedicosEspecialidad ms ON e.Id = ms.IdMedico WHERE e.estado = 1 ";
        private const string SQL_SELECT_ESPECIALIDADMEDICO = "SELECT DISTINCT e.IdEspecialidad, e.Descripcion FROM Especialidad e" +
            " INNER JOIN MedicosEspecialidad ms ON e.IdEspecialidad = ms.IdEspecialidad WHERE sp.estado = 1 ";
        private const string SQL_UPDATE_MEDICOSESPECIALIDAD = "UPDATE MedicosEspecialidad SET IdEspecialidad = @IdEspecialidad, estado=@estado WHERE IdMedico = @IdMedico";
    
        private readonly string coneccionDB;
        public MedicoADO(string coneccion)
        {
            coneccionDB = coneccion;
        }

        public bool GrabarMedicoEspecialidad(Medico medico, bool insert)
        {
            bool response;
            try
            {
                if (insert) ///VER ACA EL EQUALS
                    InsertMedicoEspecialidadDB(medico);
                else
                    UpdateMedico(medico);
                response = true;
            }
            catch (Exception)
            {
                response = false;
            }
            return response;
        }

        private void InsertMedicoEspecialidadDB(Medico medico)
        {
            AccesoDatos accesoDatos = new AccesoDatos(coneccionDB);
            using (SqlConnection con = accesoDatos.ConnectToDB())
            {
                try
                {
                    foreach (var especilidad in medico.Especialidades)
                    {
                        string sql = SQL_INSERT_MEDICOSESPECIALIDAD;
                        sql = sql.Replace("@idMedico", medico.ID.ToString());                        
                        sql = sql.Replace("@IdEspecialidad", especilidad.IdEspecialidad.ToString());
                        sql = sql.Replace("@estado", especilidad.Estado ? "1" : "0");
                        SqlCommand cmd = new SqlCommand(sql, con);
                        cmd.CommandType = CommandType.Text;
                        accesoDatos.ExecuteCommand(cmd);
                    }
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

        private void UpdateMedico(Medico medico)
        {
            AccesoDatos accesoDatos = new AccesoDatos(coneccionDB);
            using (SqlConnection con = accesoDatos.ConnectToDB())
            {
                try
                {
                    foreach (var espcialidad in medico.Especialidades)
                    {
                        SqlCommand cmd = new SqlCommand(SQL_UPDATE_MEDICOSESPECIALIDAD, con);
                        cmd.Parameters.AddWithValue("@IdEspecialidad", espcialidad.IdEspecialidad);
                        cmd.Parameters.AddWithValue("@estado", espcialidad.Estado);
                        cmd.Parameters.AddWithValue("@IdMedico", medico.ID);
                        cmd.CommandType = CommandType.Text;
                        accesoDatos.ExecuteCommand(cmd);
                    }
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

        // Listado de Menus pero lo manejamos por medio de la clase PermisoADO
        public List<Medico> ListarMedicoEspecialidad(int idEspecialidad)
        {
            List<Medico> ListaMedico = new List<Medico>();
            SqlDataReader dr = null;
            AccesoDatos accesoDatos = new AccesoDatos(coneccionDB);
            try
            {
                using (SqlConnection con = accesoDatos.ConnectToDB())
                {                    
                    string sql = SQL_SELECT_MEDICOS;
                    SqlCommand cmd = new SqlCommand(sql, con);
                    cmd.CommandType = CommandType.Text;
                    dr = accesoDatos.SelectDataReaderFromSqlCommand(cmd);

                    while (dr.Read())
                    {
                        ListaMedico.Add(CreateObjectMedico(dr, accesoDatos, con, idEspecialidad));
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
            return ListaMedico;
        }
        private Especialidad CreateObjectEsp(SqlDataReader dr)
        {
            Especialidad especialidad = new Especialidad();
            especialidad.IdEspecialidad = Convert.ToInt32(dr["IdEspecialidad"].ToString());
            especialidad.Descripcion = dr["Description"].ToString();
            especialidad.Estado = dr["estado"].ToString().Equals("True") ? true : false;

            return especialidad;
        }

        private Medico CreateObjectMedico(SqlDataReader dr, AccesoDatos accesoDatos, SqlConnection con, int idEspecialidad = 0)
        {
            Medico objTMedico = new Medico();
            objTMedico.ID = Convert.ToInt32(dr["IdMedico"].ToString());
            objTMedico.Nombres = dr["Nombre"].ToString();
            objTMedico.Apellidos = dr["Apellido"].ToString();
            objTMedico.NroDocumento = dr["NroDocumento"].ToString();
            objTMedico.Estado = dr["Estado"].ToString().Equals("True") ? true : false;

            List<Especialidad> especialidades = new List<Especialidad>();
            string sql = SQL_SELECT_ESPECIALIDADMEDICO;

            if (idEspecialidad != 0)
                sql = sql + " e.IdEspecialidad = " + idEspecialidad.ToString() + " AND ms.IdMedico = " + objTMedico.ID;

            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.CommandType = CommandType.Text;
            dr = accesoDatos.SelectDataReaderFromSqlCommand(cmd);
            while (dr.Read())
            {
                especialidades.Add(CreateObjectEsp(dr));
            }

            objTMedico.Especialidades = especialidades;

            return objTMedico;
        }
        public Medico BuscarMedico(string documento)
        {
            Medico medico = null;
            SqlDataReader dr = null;
            AccesoDatos accesoDatos = new AccesoDatos(coneccionDB);
            try
            {
                using (SqlConnection con = accesoDatos.ConnectToDB())
                {
                    string sql = SQL_SELECT_MEDICOS;
                    sql = sql + " e.nrodocumento = '" + documento + "'";
                    SqlCommand cmd = new SqlCommand(sql, con);
                    cmd.CommandType = CommandType.Text;
                    dr = accesoDatos.SelectDataReaderFromSqlCommand(cmd);

                    while (dr.Read())
                    {
                        medico = (CreateObjectMedico(dr, accesoDatos, con));
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

            return medico;
        }
    }
}