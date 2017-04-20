using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBcs
{
    public static class DBWZHelper
    {
      
        private static String connStr = ConfigurationManager.ConnectionStrings["connStrWZ"].ToString();

        

        public static int ExecuteCommand(String sql)
        {

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = sql;
                    cmd.CommandTimeout = 0;
                    int result = cmd.ExecuteNonQuery();
                    return result;
                }

            }
          
        }
        //非查询:sql语句中有参数
        public static int ExecuteCommand(String sql, SqlParameter[] pars)
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = sql;
                    cmd.CommandTimeout = 0;
                    cmd.Parameters.AddRange(pars);  
                    int result = cmd.ExecuteNonQuery();
                    return result;
                }

            }
        }
        //非查询：存储过程中无参数
        public static int ExecuteCommandByProc(String storeProc)
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(storeProc, conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = 0;
                    int result = cmd.ExecuteNonQuery();
                    return result;
                }

            }
        }
        //非查询：存储过程中有参数
        public static int ExecuteCommandByProc(string storeProc, SqlParameter[] pars)
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(storeProc, conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddRange(pars);
                    int result = cmd.ExecuteNonQuery();
                    return result;
                }
            }
        }
 

        //getScalar，单行单列:sql语句无参数
        public static object GetScalar(String sql)
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    object result = cmd.ExecuteScalar();
                    cmd.CommandTimeout = 0;
                    return result;
                }
            }
            
        }
        //getScalar,单行单列：sql语句有参数
        public static object GetScalar(String sql,SqlParameter[] pars)
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddRange(pars);
                    cmd.CommandTimeout = 0;
                    object result = cmd.ExecuteScalar();
                    return result;
                }
            }
        }
        //getScalar，单行单列:存储过程无参数
        public static object GetScalarByProc(String storeProc)
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                
                using (SqlCommand cmd = new SqlCommand(storeProc, conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    object result = cmd.ExecuteScalar();
                    return result;
                }
            }
        }
        //getScalar,单行单列：存储过程有参数
        public static object GetScalarByProc(String storeProc, SqlParameter[] pars)
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
               
                using (SqlCommand cmd = new SqlCommand(storeProc, conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddRange(pars);
                    object result = cmd.ExecuteScalar();
                    return result;
                }
            }
        }


        //查询返回DataTable：sql语句无参数
        public static DataTable GetReader(String sql)
        {

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();

                using (SqlDataAdapter adapter = new SqlDataAdapter(sql, conn))
                {
                    if (!String.IsNullOrEmpty(sql))
                    {
                        DataSet ds = new DataSet();
                     adapter.Fill(ds);
                        if (ds.Tables.Count > 0)
                            return ds.Tables[0];
                        else
                            return null;
                    }
                    else
                        return null;
                }
            }
        }
        //查询返回DataTable:sql语句有参数
        public static DataTable GetReader(String sql, SqlParameter[] pars)
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddRange(pars);
                    using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                    {
                        DataSet ds = new DataSet();
                        adapter.Fill(ds);
                        if (ds.Tables.Count > 0)
                            return ds.Tables[0];
                        else
                            return null;
                    }
                }
            }
        }
        //查询返回DataTable：存储过程无参数
        public static DataTable GetReaderByProc(String storeProc)
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();

                using (SqlCommand cmd = new SqlCommand(storeProc, conn))
                {
                    using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                    {
                        DataSet ds = new DataSet();
                        adapter.Fill(ds);
                        if (ds.Tables.Count > 0)
                            return ds.Tables[0];
                        else
                            return null;
                    }
                }
            }
        }
        //查询返回DataTable:存储过程语句有参数
        public static DataTable GetReaderByProc(String storeProc, SqlParameter[] pars)
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(storeProc, conn))
                {
                    cmd.Parameters.AddRange(pars);
                    using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                    {
                        DataSet ds = new DataSet();
                        adapter.Fill(ds);
                        if (ds.Tables.Count > 0)
                            return ds.Tables[0];
                        else
                            return null;
                    }
                }
            }
        }

    }
}
