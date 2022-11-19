using AccesoModeloBaseDatos.Dominio;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace AccesoModeloBaseDatos.Modelos
{
    public class MedicoADO
    {
        private const string SQL_INSERT_MEDICOS = "INSERT INTO Medicos (IdMedico,IdEspecialidad,estado) VALUES (@idMedico,@IdEspecialidad,@estado)";
        private const string SQL_SELECT_MEDICOS = "SELECT m.IdMedico, m.IdEspecialidad, e.Nombre, e.Apellido, e.NroDocumento, e.estado FROM Medicos m INNER JOIN Empleados e ON m.IdMedico = e.Id";
        private const string SQL_UPDATE_MEDICOS = "UPDATE Medicos SET IdEspecialidad = @IdEspecialidad WHERE IdMedico = @IdMedico";
        private const string SQL_SELECT_MEDICO = "SELECT m.IdMedico, m.IdEspecialidad, e.Nombre, e.Apellido, e.NroDocumento, e.estado FROM Medicos m INNER JOIN Empleados e ON m.IdMedico = e.Id WHERE e.NroDocumento = '@nrodocumento'";
    
        private readonly string coneccionDB;
        public MedicoADO(string coneccion)
        {
            coneccionDB = coneccion;
        }

        public bool GrabarMedico(Medico medico, bool insert)
        {

            bool response;
            try
            {
                if (insert) ///VER ACA EL EQUALS
                    InsertMedicoDB(medico);
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

        private void InsertMedicoDB(Medico medico)
        {
            AccesoDatos accesoDatos = new AccesoDatos(coneccionDB);
            using (SqlConnection con = accesoDatos.ConnectToDB())
            {
                try
                {
                    string sql = SQL_INSERT_MEDICOS;
                    sql = sql.Replace("@idMedico", medico.ID.ToString());
                    sql = sql.Replace("@IdEspecialidad", medico.idEspecialidad.ToString());
                    sql = sql.Replace("@estado", medico.Estado ? "1" : "0");
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

        private void UpdateMedico(Medico medico)
        {
            AccesoDatos accesoDatos = new AccesoDatos(coneccionDB);
            using (SqlConnection con = accesoDatos.ConnectToDB())
            {
                try
                {
                    SqlCommand cmd = new SqlCommand(SQL_UPDATE_MEDICOS, con);
                    cmd.Parameters.AddWithValue("@apellido", medico.Apellidos);
                    cmd.Parameters.AddWithValue("@IdEspecialidad", medico.idEspecialidad); 
                    cmd.Parameters.AddWithValue("@nombre", medico.Nombres);
                    cmd.Parameters.AddWithValue("@nrodocumento", medico.NroDocumento);
                    cmd.Parameters.AddWithValue("@estado", medico.Estado);
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

        // Listado de Menus pero lo manejamos por medio de la clase PermisoADO
        public List<Medico> ListarMedicos()
        {
            List<Medico> Lista = new List<Medico>();
            SqlDataReader dr = null;
            AccesoDatos accesoDatos = new AccesoDatos(coneccionDB);
            try
            {

                using (SqlConnection con = accesoDatos.ConnectToDB())
                {
                    SqlCommand cmd = new SqlCommand(SQL_SELECT_MEDICOS, con);
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

        private Medico CreateObject(SqlDataReader dr)
        {
            Medico objTMedico = new Medico();
            objTMedico.ID = Convert.ToInt32(dr["IdMedico"].ToString());
            objTMedico.idEspecialidad = Convert.ToInt32(dr["IdEspecialidad"].ToString());       
            objTMedico.Nombres = dr["nombre"].ToString();
            objTMedico.Apellidos = dr["apellido"].ToString();
            objTMedico.NroDocumento = dr["nrodocumento"].ToString();
            objTMedico.Estado = dr["estado"].ToString().Equals("True") ? true : false;

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
                    SqlCommand cmd = new SqlCommand(SQL_SELECT_MEDICO, con);
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@nrodocumento", documento);
                    dr = accesoDatos.SelectDataReaderFromSqlCommand(cmd);

                    while (dr.Read())
                    {
                        medico = (CreateObject(dr));
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