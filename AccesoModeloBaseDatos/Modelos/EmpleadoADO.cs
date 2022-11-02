using AccesoModeloBaseDatos.Dominio;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace AccesoModeloBaseDatos.Modelos
{
    public class EmpleadoADO
    {
        private const string SQL_INSERT_EMPLEADOS = "INSERT INTO empleados (idtipoperfil, nombre, apellido, nrodocumento,fechaalta, estado) VALUES (@idtipoperfil,@nombre,@apellido,@nrodocumento,@fechaalta, @estado)";
        private const string SQL_SELECT_EMPLEADOS = "SELECT id, idtipoperfil, nombre, apellido, nrodocumento,fechaAlta, estado FROM Empleados";
        private const string SQL_UPDATE_EMPLEADOS = "UPDATE empleados SET idtipoperfil=@idtipoperfil, nombre=@nombre, apellido=@apellido, nrodocumento=@nrodocumento, fechaalta=@fechaalta, estado = @estado WHERE id = @id";
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
                if (empleado.ID.Equals(1)) ///VER ACA EL EQUALS
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
                    cmd.Parameters.AddWithValue("@idTipoPerfil", empleado.idTipoPerfil);
                    cmd.Parameters.AddWithValue("@nombre", empleado.Nombres);
                    cmd.Parameters.AddWithValue("@nrodocumento", empleado.NroDocumento);
                    cmd.Parameters.AddWithValue("@fechaalta", empleado.FechaAlta);
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
            AccesoDatos accesoDatos = new AccesoDatos(coneccionDB);
            using (SqlConnection con = accesoDatos.ConnectToDB())
            {
                try
                {
                    SqlCommand cmd = new SqlCommand(SQL_UPDATE_EMPLEADOS, con);
                    cmd.Parameters.AddWithValue("@apellido", empleado.Apellidos);
                    cmd.Parameters.AddWithValue("@idTipoPerfil", empleado.idTipoPerfil);
                    cmd.Parameters.AddWithValue("@nombre", empleado.Nombres);
                    cmd.Parameters.AddWithValue("@nrodocumento", empleado.NroDocumento);
                    cmd.Parameters.AddWithValue("@fechaalta", empleado.FechaAlta);
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
            objTEmpleado.idTipoPerfil = Convert.ToInt32(dr["idtipoperfil"].ToString());
            objTEmpleado.Nombres = dr["nombre"].ToString();
            objTEmpleado.Apellidos = dr["apellido"].ToString();
            objTEmpleado.NroDocumento = dr["nrodocumento"].ToString();
            objTEmpleado.FechaAlta = Convert.ToDateTime(dr["fechaAlta"].ToString());
            objTEmpleado.Estado = dr["estado"].ToString().Equals("True") ? true : false;

            return objTEmpleado;
        }
    }
}