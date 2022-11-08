using AccesoModeloBaseDatos.Dominio;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace AccesoModeloBaseDatos.Modelos
{
    public class MedicoADO
    {
        private const string SQL_INSERT_MEDICOS = "INSERT INTO medicos (idtipoperfil,idtipoespecialidad, nombre, apellido, nrodocumento,fechaalta, estado) VALUES (@idtipoperfil,@idtipoespecialidad,@nombre,@apellido,@nrodocumento,@fechaalta, @estado)";
        private const string SQL_SELECT_MEDICOS = "SELECT id, idtipoperfil, idtipoespecialidad, nombre, apellido, nrodocumento,fechaAlta, estado FROM Medicos";
        private const string SQL_UPDATE_MEDICOS = "UPDATE medicos SET idtipoperfil=@idtipoperfil, idtipoespecialidad= @idtipoespecialidad nombre=@nombre, apellido=@apellido, nrodocumento=@nrodocumento, fechaalta=@fechaalta, estado = @estado WHERE id = @id";
        private const string SQL_SELECT_MEDICO = "SELECT * from medicos where NroDocumento = '@nrodocumento'";
    
        private readonly string coneccionDB;
        public MedicoADO(string coneccion)
        {
            coneccionDB = coneccion;
        }

        public bool GrabarMedico(Medico medico)
        {

            bool response;
            try
            {
                if (medico.ID.Equals(0)) ///VER ACA EL EQUALS
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
                    SqlCommand cmd = new SqlCommand(SQL_INSERT_MEDICOS, con);
                    cmd.Parameters.AddWithValue("@apellido", medico.Apellidos);                   
                    cmd.Parameters.AddWithValue("@idTipoPerfil", medico.idTipoPerfil);
                    cmd.Parameters.AddWithValue("@idtipoespecialidad", medico.idTipoEspecialidad); 
                    cmd.Parameters.AddWithValue("@nombre", medico.Nombres);
                    cmd.Parameters.AddWithValue("@nrodocumento", medico.NroDocumento);
                    cmd.Parameters.AddWithValue("@fechaalta", medico.FechaAlta);
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

        private void UpdateMedico(Medico medico)
        {
            AccesoDatos accesoDatos = new AccesoDatos(coneccionDB);
            using (SqlConnection con = accesoDatos.ConnectToDB())
            {
                try
                {
                    SqlCommand cmd = new SqlCommand(SQL_UPDATE_MEDICOS, con);
                    cmd.Parameters.AddWithValue("@apellido", medico.Apellidos);
                    cmd.Parameters.AddWithValue("@idTipoPerfil", medico.idTipoPerfil);
                    cmd.Parameters.AddWithValue("@idtipoespecialidad", medico.idTipoEspecialidad); 
                    cmd.Parameters.AddWithValue("@nombre", medico.Nombres);
                    cmd.Parameters.AddWithValue("@nrodocumento", medico.NroDocumento);
                    cmd.Parameters.AddWithValue("@fechaalta", medico.FechaAlta);
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
            objTMedico.ID = Convert.ToInt32(dr["id"].ToString());
            objTMedico.idTipoPerfil = Convert.ToInt32(dr["idtipoperfil"].ToString());
            objTMedico.idTipoEspecialidad = Convert.ToInt32(dr["idtipoespecialidad"].ToString());       
            objTMedico.Nombres = dr["nombre"].ToString();
            objTMedico.Apellidos = dr["apellido"].ToString();
            objTMedico.NroDocumento = dr["nrodocumento"].ToString();
            objTMedico.FechaAlta = Convert.ToDateTime(dr["fechaAlta"].ToString());
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