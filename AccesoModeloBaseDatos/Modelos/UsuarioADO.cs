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
        private const string SQL_INSERT_USUARIO = "INSERT INTO Usuarios (UserLogin, Password, IdEmpleado) VALUES ('@userLogin','@password',@idEmp)";
        private const string SQL_SELECT_USUARIOS = "SELECT idUsuario, UserLogin, Password, IdEmpleado FROM Usuarios";
        private const string SQL_UPDATE_USURIO = "UPDATE Usuarios SET UserLogin=@user, Password=@password WHERE IdEmpleado = @idEmp";
        private const string SQL_SELECT_USUARIO = "SELECT * FROM Usuarios WHERE IdEmpleado = @idEmp";
        private const string SQL_SELECT_COUNT = "SELECT COUNT(*) cantUserLogin FROM Usuarios WHERE UserLogin='@userLogin'";
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
                    string sql = SQL_INSERT_USUARIO;
                    sql = sql.Replace("@userLogin", usuario.User).Replace("@password", usuario.Password).Replace("@idEmp", usuario.IdEmpleado.ToString());
                    SqlCommand cmd = new SqlCommand(sql, con);
                    cmd.CommandType = CommandType.Text;
                    accesoDatos.ExecuteCommand(cmd);
                    inserto = true;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    accesoDatos.CloseConnection();
                }
                return inserto;
            }
        }

        public bool UpdateUsuario(Usuario usuario)
        {
            AccesoDatos accesoDatos = new AccesoDatos(coneccionDB);
            bool actualizo = false;
            using (SqlConnection con = accesoDatos.ConnectToDB())
            {
                try
                {
                    string sql = SQL_UPDATE_USURIO;
                    sql = sql.Replace("@userLogin", usuario.User).Replace("@password", usuario.Password);
                    SqlCommand cmd = new SqlCommand(sql, con);
                    cmd.CommandType = CommandType.Text;
                    accesoDatos.ExecuteCommand(cmd);
                    actualizo = true;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    accesoDatos.CloseConnection();
                }
                return actualizo;
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
                    string sql = SQL_SELECT_USUARIO;
                    sql = sql.Replace("@idEmp", idEmp);
                    SqlCommand cmd = new SqlCommand(sql, con);
                    cmd.CommandType = CommandType.Text;                    
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
        public int BuscarUsuario(Usuario usuario)
        {         
            SqlDataReader dr = null;
            AccesoDatos accesoDatos = new AccesoDatos(coneccionDB);
            int cantUserLogin = 0;
            try
            {
                using (SqlConnection con = accesoDatos.ConnectToDB())
                {
                    string sql = SQL_SELECT_COUNT;
                    sql = sql.Replace("@userLogin", usuario.User);
                    SqlCommand cmd = new SqlCommand(sql, con);
                    cmd.CommandType = CommandType.Text;
                    dr = accesoDatos.SelectDataReaderFromSqlCommand(cmd);

                    while (dr.Read())
                    {
                        cantUserLogin = Convert.ToInt32(dr["cantUserLogin"]);
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

            return cantUserLogin;
        }
    }
}
