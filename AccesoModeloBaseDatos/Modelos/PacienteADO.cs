using AccesoModeloBaseDatos.Dominio;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using static System.Net.Mime.MediaTypeNames;

namespace AccesoModeloBaseDatos.Modelos
{
    public class PacienteADO
    {
        private const string SQL_INSERT_PACIENTES = "INSERT INTO pacientes (nombres, apellidos, nrodocumento, fechanacimiento, sexo,fechaalta,estado, telefono, email, imagen) VALUES (@nombres,@apellidos,@nrodocumento, @fechanacimiento, @sexo, @fechaalta, @estado, @telefono, @email, @imagen)";
        private const string SQL_SELECT_PACIENTES = "SELECT  idPaciente,nombres,apellidos,nrodocumento, fechanacimiento, sexo, fechaalta, estado, telefono, email, imagen FROM Pacientes";
        private const string SQL_UPDATE_PACIENTES = "UPDATE pacientes SET nombres='@nombres',apellidos='@apellidos',nrodocumento='@nrodocumento', fechanacimiento=@fechanacimiento, sexo='@sexo', estado=@estado, telefono=@telefono, email='@email', imagen='@imagen' WHERE idPaciente = @idPaciente";
        private const string SQL_SELECT_PACIENTE = "SELECT idPaciente,nombres,apellidos,nrodocumento, fechanacimiento, sexo, fechaalta, estado, telefono, email, imagen FROM Pacientes WHERE NroDocumento = '@nrodocumento'";
        private readonly string coneccionDB;
        public PacienteADO(string coneccion)
        {
            coneccionDB = coneccion;
        }
      
        public bool GrabarPaciente(Paciente paciente)
        {
            bool response;
            try
            {
                if (paciente.IdPaciente.Equals(0)) ///VER ACA EL EQUALS
                    InsertPacienteDB(paciente);
                else
                    UpdatePaciente(paciente);
                response = true;
            }
            catch (Exception)
            {
                response = false;
            }
            return response;
        }

        private void InsertPacienteDB(Paciente paciente)
        {
            AccesoDatos accesoDatos = new AccesoDatos(coneccionDB);
            using (SqlConnection con = accesoDatos.ConnectToDB())
            {
                try
                {
                   
                    SqlCommand cmd = new SqlCommand(SQL_INSERT_PACIENTES, con);
                    cmd.Parameters.AddWithValue("@apellidos", paciente.Apellidos);                    
                    cmd.Parameters.AddWithValue("@nombres", paciente.Nombres);
                    cmd.Parameters.AddWithValue("@nrodocumento", paciente.NroDocumento);
                    cmd.Parameters.AddWithValue("@fechanacimiento", paciente.FechaNacimiento);
                    cmd.Parameters.AddWithValue("@sexo", paciente.Sexo);
                    cmd.Parameters.AddWithValue("@fechaalta", paciente.FechaAlta);                  
                    cmd.Parameters.AddWithValue("@estado", paciente.Estado);
                    cmd.Parameters.AddWithValue("@telefono", paciente.Telefono);
                    cmd.Parameters.AddWithValue("@email", paciente.Email);
                    cmd.Parameters.AddWithValue("@imagen", paciente.Imagen);
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

        private void UpdatePaciente(Paciente paciente)
        {
            AccesoDatos accesoDatosUpdate = new AccesoDatos(coneccionDB);
            using (SqlConnection con = accesoDatosUpdate.ConnectToDB())
            {
                try
                {   /*
                    SqlCommand cmd = new SqlCommand(SQL_UPDATE_PACIENTES, con);
                    cmd.Parameters.AddWithValue("@apellidos", paciente.Apellidos);
                    cmd.Parameters.AddWithValue("@nombres", paciente.Nombres);
                    cmd.Parameters.AddWithValue("@nrodocumento", paciente.NroDocumento);
                    cmd.Parameters.AddWithValue("@fechanacimiento", paciente.FechaNacimiento);
                    cmd.Parameters.AddWithValue("@sexo", paciente.Sexo);
                    cmd.Parameters.AddWithValue("@fechaalta", paciente.FechaAlta);
                    cmd.Parameters.AddWithValue("@estado", paciente.Estado);
                    cmd.Parameters.AddWithValue("@telefono", paciente.Telefono);
                    cmd.Parameters.AddWithValue("@email", paciente.Email);
                    cmd.Parameters.AddWithValue("@imagen", paciente.Imagen);
                    cmd.CommandType = CommandType.Text;
                    accesoDatosUpdate.ExecuteCommand(cmd);
                    */
                    
                    string sql = SQL_UPDATE_PACIENTES;                   
                    sql = sql.Replace("@idPaciente", paciente.IdPaciente.ToString());
                    sql = sql.Replace("@apellidos", paciente.Apellidos.ToString());
                    sql = sql.Replace("@nombres", paciente.Nombres.ToString());
                    sql = sql.Replace("@nrodocumento", paciente.NroDocumento.ToString());
                    sql = sql.Replace("@fechanacimiento", "'" + paciente.FechaNacimiento.ToString("yyyy-MM-ddThh:mm:ss") + "'");                    
                    sql = sql.Replace("@sexo", paciente.Sexo.ToString());
                    //sql = sql.Replace("@fechaalta", "'" + paciente.FechaAlta.ToString("yyyy-MM-ddThh:mm:ss") + "'");                    
                    sql = sql.Replace("@estado", paciente.Estado.Equals(true) ? "1" : "0"); /// convertir a BIT
                    sql = sql.Replace("@telefono", paciente.Telefono.ToString());
                    sql = sql.Replace("@email", paciente.Email.ToString());
                    sql = sql.Replace("@imagen", paciente.Imagen.ToString());
                    SqlCommand cmd = new SqlCommand(sql, con);
                    cmd.CommandType = CommandType.Text;
                    accesoDatosUpdate.ExecuteCommandString(cmd.CommandText);
                    
                    
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
        public List<Paciente> ListarPacientes()
        {
            List<Paciente> Lista = new List<Paciente>();
            SqlDataReader dr = null;
            AccesoDatos accesoDatos = new AccesoDatos(coneccionDB);
            try
            {
                using (SqlConnection con = accesoDatos.ConnectToDB())
                {
                    SqlCommand cmd = new SqlCommand(SQL_SELECT_PACIENTES, con);
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

        private Paciente CreateObject(SqlDataReader dr)
        {
            Paciente objTPaciente = new Paciente();
            objTPaciente.IdPaciente = Convert.ToInt32(dr["idpaciente"].ToString());           
            objTPaciente.Nombres = dr["nombres"].ToString();
            objTPaciente.Apellidos = dr["apellidos"].ToString();
            objTPaciente.NroDocumento = dr["nrodocumento"].ToString();
            objTPaciente.FechaNacimiento = Convert.ToDateTime(dr["fechaNacimiento"].ToString());
            objTPaciente.Sexo =  dr["sexo"].ToString();
            objTPaciente.FechaAlta = Convert.ToDateTime(dr["fechaAlta"].ToString());
            objTPaciente.Estado = dr["Estado"].ToString().Equals("Activo") ? true : false;
            objTPaciente.Telefono = dr["telefono"].ToString();
            objTPaciente.Email = dr["email"].ToString();
            objTPaciente.Imagen = dr["imagen"].ToString();           

            return objTPaciente;
        }
        public Paciente BuscarPaciente(string documento)
        {
            Paciente paciente = null;
            SqlDataReader dr = null;
            AccesoDatos accesoDatosBusca = new AccesoDatos(coneccionDB);
            try
            {
                using (SqlConnection con = accesoDatosBusca.ConnectToDB())
                {
                    string sql = SQL_SELECT_PACIENTE;
                    sql = sql.Replace("@nrodocumento", documento);
                    SqlCommand cmd = new SqlCommand(sql, con);
                    cmd.CommandType = CommandType.Text;
                    //cmd.Parameters.AddWithValue("@nrodocumento", documento);
                    dr = accesoDatosBusca.SelectDataReaderFromSqlCommand(cmd);

                    while (dr.Read())
                    {
                        paciente = (CreateObject(dr));
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

            return paciente;
        }

        public void BorrarPaciente(string nroDocumento)
        {
            throw new NotImplementedException();
        }
    }
}