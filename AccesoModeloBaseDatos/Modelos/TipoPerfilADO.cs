using AccesoModeloBaseDatos.Dominio;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace AccesoModeloBaseDatos.Modelos
{
    public class TipoPerfilADO
    {
        private const string SQL_INSERT_PERFIL = "INSERT INTO perfiles (descripcion, estado) VALUES (@descripcion, @estado)";
        private const string SQL_SELECT_PERFIL = "SELECT idPerfil, descripcion, estado FROM perfiles";
        private readonly string coneccionDB;
        public TipoPerfilADO(string coneccion)
        {
            coneccionDB = coneccion;
        }
        // Crear Perfil
        public bool RegistrarEliminarPerfil(TipoPerfil objPerfil)
        {
            AccesoDatos accesoDatos = new AccesoDatos(coneccionDB);
            using (SqlConnection con = accesoDatos.ConnectToDB())
            {
                bool response;
                try
                {
                    SqlCommand cmd = new SqlCommand(SQL_INSERT_PERFIL, con);
                    cmd.Parameters.AddWithValue("@descripcion", objPerfil.Descripcion);
                    cmd.Parameters.AddWithValue("@estado", objPerfil.Estado);
                    cmd.CommandType = CommandType.Text;
                    accesoDatos.ExecuteCommand(cmd.CommandText);

                    response = true;
                }
                catch (Exception)
                {
                    response = false;
                }
                finally
                {
                    accesoDatos.CloseConnection();
                }
                return response;
            }
        }

        // Listado de Menus pero lo manejamos por medio de la clase PermisoDAO
        public List<TipoPerfil> ListarPerfiles()
        {
            List<TipoPerfil> Lista = new List<TipoPerfil>();
            SqlDataReader dr = null;
            AccesoDatos accesoDatos = new AccesoDatos(coneccionDB);
            try
            {

                using (SqlConnection con = accesoDatos.ConnectToDB())
                {
                    SqlCommand cmd = new SqlCommand(SQL_SELECT_PERFIL, con);
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

        private TipoPerfil CreateObject(SqlDataReader dr)
        {
            TipoPerfil objTPerfil = new TipoPerfil();
            objTPerfil.IdPerfil = Convert.ToInt32(dr["idPerfil"].ToString());
            objTPerfil.Descripcion = dr["descripcion"].ToString();
            objTPerfil.Estado = dr["isSubMenu"].ToString().Equals("1") ? true : false;

            return objTPerfil;
        }

    }
}
