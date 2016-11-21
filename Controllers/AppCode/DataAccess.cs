using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;


    public class DataAccess
    {

        public static string ConnectionString
        {
            get
            {
                return ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString.ToString();
            }
        }
        public static SqlParameter AddParamter(String ParameterName, object value, SqlDbType DbType, int size)
        {
            SqlParameter param = new SqlParameter();
            param.ParameterName = ParameterName;
            param.Value = value.ToString();
            param.SqlDbType = DbType;
            param.Size = size;
            param.Direction = ParameterDirection.Input;
            return param;
        }
        public static DataTable ExecuteDTByProduct(string procedureName, SqlParameter[] Params)
        {
            SqlConnection conn = new SqlConnection(ConnectionString);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = procedureName;
            cmd.Parameters.AddRange(Params);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dTable = new DataTable();
            try
            {
                adapter.Fill(dTable);
            }
            catch (Exception ex)
            {

            }
            finally
            {
                adapter.Dispose();
                cmd.Parameters.Clear();
                cmd.Dispose();
                conn.Dispose();
            }
            return dTable;
        }

        public static int ExecuteSQLNonQuery(string SQL)
        {
            SqlConnection conn = new SqlConnection(ConnectionString);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            conn.Open();
            cmd.CommandText = SQL;
            
            cmd.CommandType = CommandType.Text;
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);

            int res = 0;
            try
            {
                cmd.ExecuteNonQuery();
                res = 1;
            }
            catch (Exception ex)
            {
                res = 0;
            }
            finally
            {
                adapter.Dispose();
                cmd.Parameters.Clear();
                cmd.Dispose();
                conn.Close();
            }
            return res;
        }

        public static int ExecuteSQLNonQuery(string SQL , SqlParameter[] param)
        {
            SqlConnection conn = new SqlConnection(ConnectionString);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            conn.Open();
            cmd.CommandText = SQL;
            cmd.Parameters.AddRange( param);

            cmd.CommandType = CommandType.Text;
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);

            int res = 0;
            try
            {
                cmd.ExecuteNonQuery();
                res = 1;
            }
            catch (Exception ex)
            {
                res = 0;
            }
            finally
            {
                adapter.Dispose();
                cmd.Parameters.Clear();
                cmd.Dispose();
                conn.Close();
            }
            return res;
        }

        public static DataTable ExecuteSQLQuery(string SQL)
        {
            SqlConnection conn = new SqlConnection(ConnectionString);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            conn.Open();
            cmd.CommandText = SQL;

            cmd.CommandType = CommandType.Text;
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dTable = new DataTable();
            //int res = 0;
            try
            {
                adapter.Fill(dTable);
                //res = 1;
            }
            catch (Exception ex)
            {
              //  res = 0;
            }
            finally
            {
                adapter.Dispose();
                cmd.Parameters.Clear();
                cmd.Dispose();
                conn.Close();
            }
            return dTable;
        }
    }
