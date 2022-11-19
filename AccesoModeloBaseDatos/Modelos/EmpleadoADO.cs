using AccesoModeloBaseDatos.Dominio;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Xml.Linq;

namespace AccesoModeloBaseDatos.Modelos
{
    public class EmpleadoADO
    {
        private const string SQL_INSERT_EMPLEADOS = "INSERT INTO Empleados (IdPerfil, nombre, apellido, nrodocumento,fechaalta,IdJornada, estado) VALUES (@IdPerfil,@nombre,@apellido,@nrodocumento,@fechaalta,@IdJornada, @estado)";
        private const string SQL_SELECT_EMPLEADOS = "SELECT id, IdPerfil, nombre, apellido, nrodocumento,fechaAlta, IdJornada, estado FROM Empleados";
        private const string SQL_UPDATE_EMPLEADOS = "UPDATE Empleados SET IdPerfil=@IdPerfil, nombre=@nombre, apellido=@apellido, nrodocumento=@nrodocumento, fechaalta=@fechaalta, IdJornada=@IdJornada, estado=@estado WHERE id=@id";
        private const string SQL_SELECT_EMPLEADO = "SELECT id, IdPerfil, nombre, apellido, nrodocumento,fechaAlta,IdJornada, estado FROM Empleados WHERE NroDocumento = '@nrodocumento'";
        private const string SQL_SELECT_EMPLEADO_LOGIN = "SELECT id, IdPerfil, nombre, apellido, nrodocumento,fechaAlta,IdJornada, estado FROM Empleados e INNER JOIN Usuarios u ON e.id = u.IdEmpleado WHERE u.UserLogin= '@UserLogin' AND u.Password = '@Password'";
        private readonly string coneccionDB;
        public EmpleadoADO(string coneccion)
        {
            coneccionDB = coneccion;
        }

        public bool GrabarEmpleado(Empleado empleado)
        {
            bool response;
            try
            {
                if (empleado.ID.Equals(0)) ///VER ACA EL EQUALS
                    InsertEmpleadoDB(empleado);
                else
                    UpdateEmpleado(empleado);
                response = true;
            }
            catch (Exception)
            {
                response = false;
            }
            return response;
        }

        private void InsertEmpleadoDB(Empleado empleado)
        {
            AccesoDatos accesoDatos = new AccesoDatos(coneccionDB);
            using (SqlConnection con = accesoDatos.ConnectToDB())
            {
                try
                {
                    SqlCommand cmd = new SqlCommand(SQL_INSERT_EMPLEADOS, con);
                    cmd.Parameters.AddWithValue("@apellido", empleado.Apellidos);
                    cmd.Parameters.AddWithValue("@IdPerfil", empleado.idPerfil);
                    cmd.Parameters.AddWithValue("@nombre", empleado.Nombres);
                    cmd.Parameters.AddWithValue("@nrodocumento", empleado.NroDocumento);
                    cmd.Parameters.AddWithValue("@fechaalta", empleado.FechaAlta);
                    cmd.Parameters.AddWithValue("@IdJornada", empleado.idJornada);
                    cmd.Parameters.AddWithValue("@estado", empleado.Estado);
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

        private void UpdateEmpleado(Empleado empleado)
        {
            AccesoDatos accesoDatosUpdate = new AccesoDatos(coneccionDB);
            using (SqlConnection con = accesoDatosUpdate.ConnectToDB())
            {
                try
                {
                    SqlCommand cmd = new SqlCommand(SQL_UPDATE_EMPLEADOS, con);
                    cmd.Parameters.AddWithValue("@apellido", empleado.Apellidos);
                    cmd.Parameters.AddWithValue("@IdPerfil", empleado.idPerfil);
                    cmd.Parameters.AddWithValue("@nombre", empleado.Nombres);
                    cmd.Parameters.AddWithValue("@nrodocumento", empleado.NroDocumento);
                    cmd.Parameters.AddWithValue("@fechaalta", empleado.FechaAlta);
                    cmd.Parameters.AddWithValue("@IdJornada", empleado.idJornada);
                    cmd.Parameters.AddWithValue("@estado", empleado.Estado);
                    cmd.CommandType = CommandType.Text;
                    accesoDatosUpdate.ExecuteCommand(cmd);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    accesoDatosUpdate.CloseConnection();
                }
            }
        }

        // Listado de Menus pero lo manejamos por medio de la clase PermisoADO
        public List<Empleado> ListarEmpleados()
        {
            List<Empleado> Lista = new List<Empleado>();
            SqlDataReader dr = null;
            AccesoDatos accesoDatos = new AccesoDatos(coneccionDB);
            try
            {
                using (SqlConnection con = accesoDatos.ConnectToDB())
                {
                    SqlCommand cmd = new SqlCommand(SQL_SELECT_EMPLEADOS, con);
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

        private Empleado CreateObject(SqlDataReader dr)
        {
            Empleado objTEmpleado = new Empleado();
            objTEmpleado.ID = Convert.ToInt32(dr["id"].ToString());
            objTEmpleado.idPerfil = Convert.ToInt32(dr["IdPerfil"].ToString());
            objTEmpleado.Nombres = dr["nombre"].ToString();
            objTEmpleado.Apellidos = dr["apellido"].ToString();
            objTEmpleado.NroDocumento = dr["nrodocumento"].ToString();
            objTEmpleado.FechaAlta = Convert.ToDateTime(dr["fechaAlta"].ToString());
            objTEmpleado.idJornada = Convert.ToInt32(dr["IdJornada"].ToString());
            objTEmpleado.Estado = dr["estado"].ToString().Equals("True") ? true : false;

            return objTEmpleado;
        }
        public Empleado BuscarEmpleado(string documento)
        {
            Empleado empleado = null;
            SqlDataReader dr = null;
            AccesoDatos accesoDatosBusca = new AccesoDatos(coneccionDB);
            try
            {
                using (SqlConnection con = accesoDatosBusca.ConnectToDB())
                {
                    string sql = SQL_SELECT_EMPLEADO;
                    sql = sql.Replace("@nrodocumento", documento);
                    SqlCommand cmd = new SqlCommand(sql, con);
                    cmd.CommandType = CommandType.Text;
                    //cmd.Parameters.AddWithValue("@nrodocumento", documento);
                    dr = accesoDatosBusca.SelectDataReaderFromSqlCommand(cmd);

                    while (dr.Read())
                    {
                        empleado = (CreateObject(dr));
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                accesoDatosBusca.CloseConnection();
            }

            return empleado;
        }

        public Empleado BuscarEmpleadoLogin(Usuario userLogin)
        {
            Empleado empleado = null;
            SqlDataReader dr = null;
            AccesoDatos accesoDatosBusca = new AccesoDatos(coneccionDB);
            try
            {
                using (SqlConnection con = accesoDatosBusca.ConnectToDB())
                {
                    string sql = SQL_SELECT_EMPLEADO_LOGIN;
                    sql = sql.Replace("@UserLogin", userLogin.User).Replace("@Password", userLogin.Password);
                    SqlCommand cmd = new SqlCommand(sql, con);
                    cmd.CommandType = CommandType.Text;
                    dr = accesoDatosBusca.SelectDataReaderFromSqlCommand(cmd);

                    while (dr.Read())
                    {
                        empleado = (CreateObject(dr));
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                accesoDatosBusca.CloseConnection();
            }

            return empleado;
        }

        public void BorrarEmpleado(string nroDocumento)
        {
            throw new NotImplementedException();
        }
    }
}