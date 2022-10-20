using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoModeloBaseDatos
{
    public class AccesoDatos
    {
        private string connection = string.Empty;
        private SqlConnection connect;
        private SqlCommand command;
        private SqlDataAdapter da;
        private SqlDataReader dr;
        private DataTable dt;
        private DataSet ds;

        public AccesoDatos(string conecionSql)
        {
            connect = new SqlConnection();
            try
            {
                connection = conecionSql;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
        public SqlConnection ConnectToDB()
        {
            if (connect.State != ConnectionState.Open)
            {
                try
                {
                    connect.ConnectionString = connection;
                    connect.Open();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            return connect;
        }
        public void CloseConnection()
        {
            if (connect.State != ConnectionState.Closed)
                connect.Close();
        }
        public string selectstring(string query)
        {
            string cadena = string.Empty;
            try
            {
                ConnectToDB();
                command = new SqlCommand(query, connect);
                cadena = command.ExecuteScalar().ToString();
            }
            catch
            {
                cadena = string.Empty;
            }
            finally
            {
                CloseConnection();
            }
            return cadena;
        }

        public bool ExecuteCommand(string query)
        {
            bool exito;
            try
            {
                ConnectToDB();
                command = new SqlCommand(query, connect);
                command.ExecuteNonQuery();
                exito = true;
            }
            catch
            {
                exito = false;
            }
            finally
            {
                CloseConnection();
            }
            return exito;
        }

        public bool ExecuteStoreProcedure(string namestoreprocedure)
        {
            try
            {
                ConnectToDB();
                command = new SqlCommand(namestoreprocedure, connect);
                command.CommandType = CommandType.StoredProcedure;
                command.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
            finally
            {
                CloseConnection();
            }
        }

        public SqlDataReader SelectDataReaderFromSqlCommand(SqlCommand sqlCommand)
        {
            dr = null;
            try
            {
                ConnectToDB();
                dr = sqlCommand.ExecuteReader();
                return dr;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable SelectDataTableFromStoreProcedure(string namestoreprocedure)
        {
            dt = new DataTable();
            try
            {
                ConnectToDB();
                command = new SqlCommand(namestoreprocedure, connect);//
                command.CommandType = CommandType.StoredProcedure;
                dt = new DataTable();
                da = new SqlDataAdapter();
                da.SelectCommand = command;
                da.Fill(dt);
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                CloseConnection();
            }
        }
        public DataTable SelectDataTable(string query)
        {
            dt = new DataTable();
            try
            {
                ConnectToDB();
                da = new SqlDataAdapter(query, connect);
                da.Fill(dt);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                ConnectToDB();
            }
            return dt;
        }

        public DataSet SelectDataSet(string query, string table)
        {
            ds = new DataSet();
            try
            {
                ConnectToDB();
                da = new SqlDataAdapter(query, connect);
                da.Fill(ds, table);
            }
            catch //(Exception ex)
            {
                // ds = null;
            }
            finally
            {
                CloseConnection();
            }
            return ds;
        }
    }
}
