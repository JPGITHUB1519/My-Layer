﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace Data
{
    public class dbconnection
    {
        public string connection_string = Data.Properties.Settings.Default.cn;

        // normal ejecuta
        public static DataSet ejecuta(string query)
        {
            DataSet ds = new DataSet();
            SqlConnection con = new SqlConnection();
            con.ConnectionString = Data.Properties.Settings.Default.cn;
            try
            {
                con.Open();
                SqlDataAdapter da = new SqlDataAdapter(query, con);
                da.Fill(ds);
            }
            catch (Exception ex)
            {
                ds = null;
            }
            finally
            {
                if (con.State == ConnectionState.Open) con.Close();
            }

            return ds;
        }

        /* this method take string and a dictionary[parameter_name, values] and return
          a dataset with the result of the query */
        public static DataSet execute_query(string query, Dictionary<string, object> parameters)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = Data.Properties.Settings.Default.cn;
            SqlCommand cmd = new SqlCommand();
            DataSet ds = new DataSet();

            try
            {
                con.Open();
                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = query;
                if (parameters != null)
                {
                    // adding parameters to the commands
                    foreach (KeyValuePair<string, object> kvp in parameters)
                    {
                        cmd.Parameters.Add(new SqlParameter(kvp.Key, kvp.Value));
                    }
                }

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(ds);
            }
            catch (Exception ex)
            {
                ds = null;
            }
            finally
            {
                if (con.State == ConnectionState.Open) con.Close();
            }

            return ds;
        }

        // the same execute method but overrided for no parameters query
        public static DataSet execute_query(string query)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = Data.Properties.Settings.Default.cn;
            SqlCommand cmd = new SqlCommand();
            DataSet ds = new DataSet();

            try
            {
                con.Open();
                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = query;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(ds);
            }
            catch (Exception ex)
            {
                ds = null;
            }
            finally
            {
                if (con.State == ConnectionState.Open) con.Close();
            }

            return ds;
        }
    }
}
