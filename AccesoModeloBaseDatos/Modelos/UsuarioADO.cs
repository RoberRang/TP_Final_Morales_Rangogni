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
    public class UsuarioADO
    {
        private const string SQL_INSERT_USUARIO = "INSERT INTO Usuarios (User, Password, IdEmpleado) VALUES (@user,@password,@idEmp)";
        private const string SQL_SELECT_USUARIOS = "SELECT idUsuario, User, Password, IdEmpleado FROM Usuarios";
        private const string SQL_UPDATE_USURIO = "UPDATE Usuarios SET User=@user, Password=@password WHERE IdEmpleado = @idEmp";
        private const string SQL_SELECT_USUARIO = "SELECT * FROM Usuarios WHERE IdEmpleado = @idEmp";
        private readonly string coneccionDB;
        public UsuarioADO(string coneccion)
        {
            coneccionDB = coneccion;
        }

        public bool InsertUsuarioDB(Usuario usuario)
        {
            AccesoDatos accesoDatos = new AccesoDatos(coneccionDB);
            bool inserto = false;
            using (SqlConnection con = accesoDatos.ConnectToDB())
            {
                try
                {
                    SqlCommand cmd = new SqlCommand(SQL_INSERT_USUARIO, con);
                    cmd.Parameters.AddWithValue("@user", usuario.User);
                    cmd.Parameters.AddWithValue("@nombre", usuario.Password);
                    cmd.Parameters.AddWithValue("@idEmp", usuario.IdEmpleado);
                    cmd.CommandType = CommandType.Text;
                    accesoDatos.ExecuteCommand(cmd);
                    inserto = true;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return inserto;
            }
        }

        private void UpdateUsuario(Usuario usuario)
        {
            AccesoDatos accesoDatos = new AccesoDatos(coneccionDB);
            using (SqlConnection con = accesoDatos.ConnectToDB())
            {
                try
                {
                    SqlCommand cmd = new SqlCommand(SQL_UPDATE_USURIO, con);
                    cmd.Parameters.AddWithValue("@user", usuario.User);
                    cmd.Parameters.AddWithValue("@password", usuario.Password);
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
        public List<Usuario> ListarUsuarios()
        {
            List<Usuario> Lista = new List<Usuario>();
            SqlDataReader dr = null;
            AccesoDatos accesoDatos = new AccesoDatos(coneccionDB);
            try
            {

                using (SqlConnection con = accesoDatos.ConnectToDB())
                {
                    SqlCommand cmd = new SqlCommand(SQL_SELECT_USUARIOS, con);
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

        private Usuario CreateObject(SqlDataReader dr)
        {
            Usuario objTUsuario = new Usuario(Convert.ToInt32(dr["IdUsuario"].ToString()), dr["User"].ToString(),
                dr["Password"].ToString(), Convert.ToInt32(dr["IdEmpleado"].ToString()));
            return objTUsuario;
        }

        public Usuario BuscarUsuario(string idEmp)
        {
            Usuario usuario = null;
            SqlDataReader dr = null;
            AccesoDatos accesoDatos = new AccesoDatos(coneccionDB);
            try
            {
                using (SqlConnection con = accesoDatos.ConnectToDB())
                {
                    SqlCommand cmd = new SqlCommand(SQL_SELECT_USUARIO, con);
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@idEmp", idEmp);
                    dr = accesoDatos.SelectDataReaderFromSqlCommand(cmd);

                    while (dr.Read())
                    {
                        usuario = (CreateObject(dr));
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

            return usuario;
        }
    }
}
