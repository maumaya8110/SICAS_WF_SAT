using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace SICASBot.Apodaca
{
    public class DB
    {
        public static string connStr = "Data Source=cascoapodaca.dyndns.org;Initial Catalog=SICAS;Persist Security Info=True;User ID=SICASusr;Password=nhtccuag";
        private static SqlConnection conn;

        public static KeyValuePair<string, object> Param(string key, object value)
        {
            return new KeyValuePair<string, object>(key, value);
        }

        private static object Test()
        {
            return Read("tabla x", Param("", ""), Param("", ""));
        }

        public static DataTable Read(string tableName, params KeyValuePair<string, object>[] args)
        {
            Hashtable data = new Hashtable();
            foreach (KeyValuePair<string, object> kp in args)
            {
                data.Add(kp.Key, kp.Value);
            }
            return Select(tableName, data);
        }

        public static object Ident_Current(string tableName)
        {
            string sqlstr = String.Format("SELECT IDENT_CURRENT('{0}');", tableName);
            return QueryScalar(sqlstr);
        }

        public static DateTime GetDate()
        {
            string sqlstr = "SELECT GETDATE()";
            return (DateTime)QueryScalar(sqlstr);
        }

        public static object QueryScalar(string sqlQry, params KeyValuePair<string, object>[] @params)
        {
            SqlCommand command = new SqlCommand();
            command.Connection = new SqlConnection(connStr);
            try
            {
                object result;
                command.Connection.Open();
                command.CommandType = CommandType.Text;
                command.CommandText = sqlQry;
                command.Parameters.Clear();

                foreach (KeyValuePair<string, object> kvp in @params)
                {
                    command.Parameters.AddWithValue(kvp.Key, kvp.Value);
                }

                result = command.ExecuteScalar();
                return result;
            }
            catch 
            {
                throw;
            }
            finally
            {
                command.Connection.Close();
                command.Dispose();
            }
        } // public static object QueryScalar

        public static object QueryScalar(string sqlQry, Hashtable @params)
        {
            SqlCommand command = new SqlCommand();
            command.Connection = new SqlConnection(connStr);
            try
            {
                object result;
                command.Connection.Open();
                command.CommandType = CommandType.Text;
                command.CommandText = sqlQry;
                command.Parameters.Clear();
                foreach (string k in @params.Keys)
                {
                    command.Parameters.AddWithValue(k, @params[k]);
                }
                result = command.ExecuteScalar();
                return result;
            }
            catch 
            {
                throw;
            }
            finally
            {
                command.Connection.Close();
                command.Dispose();
            }
        } // public static object QueryScalar

        public static object QueryScalar(string sqlQry)
        {
            SqlCommand command = new SqlCommand();
            command.Connection = new SqlConnection(connStr);
            try
            {
                command.Connection.Open();
                command.CommandType = CommandType.Text;
                command.CommandText = sqlQry;

                Object Result = command.ExecuteScalar();
                return Result;
            }
            catch 
            {
                throw;
            }
            finally
            {
                command.Connection.Close();
                command.Dispose();
            }
        } // public static object QueryScalar

        public static DataTable Query(string query)
        {
            SqlCommand command = new SqlCommand();
            command.Connection = new SqlConnection(connStr);

            try
            {
                command.Connection.Open();
                command.CommandType = CommandType.Text;
                command.CommandText = query;

                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter(command);
                da.Fill(ds, "SICASDATA");

                return ds.Tables[0];
            }
            catch 
            {
                throw;
            }
            finally
            {
                command.Connection.Close();
                command.Dispose();
            }
        } // public static DataTable Query


        public static DataTable QueryCommand(string m_command, Hashtable m_params)
        {
            SqlCommand command = new SqlCommand();
            command.Connection = new SqlConnection(connStr);

            try
            {
                command.Connection.Open();
                command.CommandType = CommandType.Text;
                command.CommandText = m_command;
                command.Parameters.Clear();

                foreach (string key in m_params.Keys)
                {
                    if (m_params[key] == null)
                    {
                        command.Parameters.AddWithValue(key, DBNull.Value);
                    }
                    else
                    {
                        command.Parameters.AddWithValue(key, m_params[key]);
                    }
                }

                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter(command);
                da.Fill(ds, "SICASDATA");

                return ds.Tables[0];
            }
            catch 
            {
                throw;
            }
            finally
            {
                command.Connection.Close();
                command.Dispose();
            }
        } // public static DataTable QueryCommand

        public static void ExecuteQuery(string execQuery)
        {
            SqlCommand command;
            conn = new SqlConnection(connStr);
            try
            {
                if (conn.State == ConnectionState.Closed) { conn.Open(); }

                command = new SqlCommand(execQuery, conn);
                command.CommandType = CommandType.Text;
                command.CommandText = execQuery;
                command.ExecuteNonQuery();
                command.Dispose();
            }
            catch 
            {
                throw;
            }
            finally
            {
                conn.Close();
            }
        } // public static void ExecuteQuery

        public static void ExecuteCommand(string execQuery, Hashtable m_params)
        {
            SqlCommand command;
            conn = new SqlConnection(connStr);
            try
            {
                if (conn.State == ConnectionState.Closed) { conn.Open(); }

                command = new SqlCommand(execQuery, conn);
                command.CommandType = CommandType.Text;
                command.CommandText = execQuery;
                command.Parameters.Clear();

                foreach (string key in m_params.Keys)
                {
                    command.Parameters.AddWithValue(key, m_params[key]);
                }
                command.ExecuteNonQuery();
                command.Dispose();
            }
            catch 
            {
                throw;
            }
            finally
            {
                conn.Close();
            }
        } // public static void ExecuteCommand

        #region DBHelpers

        public static int InsertRow(string strTabla, Hashtable @params)
        {
            string strSQL = "INSERT INTO " + strTabla + " (";
            int cont = 0;
            foreach (string k in @params.Keys)
            {
                if (cont == 0)
                {
                    strSQL += k;
                }
                else
                {
                    strSQL += "," + k;
                }
                cont += 1;
            }

            strSQL += ") VALUES (";
            cont = 0;

            foreach (string k in @params.Keys)
            {
                if (cont == 0)
                {
                    strSQL += "@" + k;
                }
                else
                {
                    strSQL += ", @" + k;
                }
                cont += 1;
            }

            strSQL += ")";

            SqlCommand command = new SqlCommand();
            command.Connection = new SqlConnection(connStr);

            command.Connection.Open();
            command.Parameters.Clear();
            command.CommandType = CommandType.Text;
            command.CommandText = strSQL;

            foreach (string k in @params.Keys)
            {
                if (@params[k] == null)
                {
                    command.Parameters.AddWithValue("@" + k, DBNull.Value);
                }
                else
                {
                    command.Parameters.AddWithValue("@" + k, @params[k]);
                }
            }

            try
            {
                return command.ExecuteNonQuery();
            }
            catch 
            {
                throw;
            }
            finally
            {
                command.Connection.Close();
                command.Dispose();
            }
        } // public static int InsertRow

        public static DataTable Select(string tablename)
        {
            SqlCommand command = new SqlCommand();
            command.Connection = new SqlConnection(connStr);

            try
            {
                command.Connection.Open();
                command.CommandType = CommandType.Text;
                command.CommandText = "SELECT * FROM " + tablename;
                command.Parameters.Clear();

                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter(command);
                da.Fill(ds, "SICASDATA");

                return ds.Tables[0];
            }
            catch 
            {
                throw;
            }
            finally
            {
                command.Connection.Close();
                command.Dispose();
            }
        }

        public static DataTable Select(string tablename, Hashtable w_params)
        {
            SqlCommand command = new SqlCommand();
            command.Connection = new SqlConnection(connStr);

            try
            {
                command.Connection.Open();
                command.CommandType = CommandType.Text;
                command.CommandText = SelectStatement(tablename, w_params);
                command.Parameters.Clear();

                foreach (string key in w_params.Keys)
                {
                    command.Parameters.AddWithValue(key, w_params[key]);
                }

                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter(command);
                da.Fill(ds, "SICASDATA");

                return ds.Tables[0];
            }
            catch 
            {
                throw;
            }
            finally
            {
                command.Connection.Close();
                command.Dispose();
            }
        }

        public static string SelectStatement(string strTabla, Hashtable @params, Hashtable @whereParams)
        {
            int cont;
            string strSQL = "";
            strSQL += "SELECT ";
            cont = 0;

            foreach (string k in @params.Keys)
            {
                if (cont == 0)
                {
                    strSQL += k;
                }
                else
                {
                    strSQL += ", " + k;
                }
                cont += 1;
            }

            cont = 0;
            strSQL += " FROM " + strTabla + " WHERE ";
            foreach (string k in @whereParams.Keys)
            {
                if (cont == 0)
                {
                    strSQL += k + " = @" + k;
                }
                else
                {
                    strSQL += " AND " + k + " = @" + k;
                }
                cont += 1;
            }

            return strSQL;
        } // End SelectStatement

        public static string SelectStatement(string strTabla, Hashtable @whereParams)
        {
            int cont;
            string strSQL = "";
            strSQL += "SELECT * FROM " + strTabla + " WHERE ";
            cont = 0;

            foreach (string k in @whereParams.Keys)
            {
                if (cont == 0)
                {
                    strSQL += k + " = @" + k;
                }
                else
                {
                    strSQL += " AND " + k + " = @" + k;
                }
                cont += 1;
            }

            return strSQL;
        } // End SelectStatement

        public static int DeleteRow(string strTabla, Hashtable @whereParams)
        {
            string strSQL = "DELETE FROM " + strTabla + " ";
            int cont = 0;

            strSQL += " WHERE ";

            foreach (string k in @whereParams.Keys)
            {
                if (cont == 0)
                {
                    strSQL += k + " = @" + k;
                }
                else
                {
                    strSQL += " AND " + k + " = @" + k;
                }
                cont += 1;
            }

            SqlCommand command = new SqlCommand();
            command.Connection = new SqlConnection(connStr);
            command.Connection.Open();
            command.Parameters.Clear();
            command.CommandType = CommandType.Text;
            command.CommandText = strSQL;

            foreach (string k in @whereParams.Keys)
            {
                if (@whereParams[k] == null)
                {
                    command.Parameters.AddWithValue("@" + k, DBNull.Value);
                }
                else
                {
                    command.Parameters.AddWithValue("@" + k, @whereParams[k]);
                }
            }

            try
            {
                return command.ExecuteNonQuery();
            }
            catch 
            {
                throw;
            }
            finally
            {
                command.Connection.Close();
                command.Dispose();
            }
        } // public static int DeleteRow

        public static int UpdateRow(string strTabla, Hashtable @params)
        {
            string strSQL = "UPDATE " + strTabla + " SET ";
            int cont = 0;
            foreach (string k in @params.Keys)
            {
                if (cont == 0)
                {
                    strSQL += k + " = @" + k;
                }
                else
                {
                    strSQL += ", " + k + " = @" + k;
                }
                cont += 1;
            }

            SqlCommand command = new SqlCommand();
            command.Connection = new SqlConnection(connStr);
            command.Connection.Open();
            command.Parameters.Clear();
            command.CommandType = CommandType.Text;
            command.CommandText = strSQL;

            foreach (string k in @params.Keys)
            {
                if (@params[k] == null)
                {
                    command.Parameters.AddWithValue("@" + k, DBNull.Value);
                }
                else
                {
                    command.Parameters.AddWithValue("@" + k, @params[k]);
                }
            }

            try
            {
                return command.ExecuteNonQuery();
            }
            catch 
            {
                throw;
            }
            finally
            {
                command.Connection.Close();
                command.Dispose();
            }
        } // int UpdateRow


        public static int UpdateRow(string strTabla, Hashtable @params, Hashtable @whereParams)
        {

            string strSQL = "UPDATE " + strTabla + " SET ";
            int cont = 0;
            foreach (string k in @params.Keys)
            {
                if (cont == 0)
                {
                    strSQL += k + " = @" + k;
                }
                else
                {
                    strSQL += ", " + k + " = @" + k;
                }
                cont += 1;
            }

            strSQL += " WHERE ";
            cont = 0;

            foreach (string k in @whereParams.Keys)
            {
                if (cont == 0)
                {
                    strSQL += k + " = @" + k;
                }
                else
                {
                    strSQL += " AND " + k + " = @" + k;
                }
                cont += 1;
            }

            SqlCommand command = new SqlCommand();
            command.Connection = new SqlConnection(connStr);
            command.Connection.Open();
            command.Parameters.Clear();
            command.CommandType = CommandType.Text;
            command.CommandText = strSQL;

            foreach (string k in @params.Keys)
            {
                if (@params[k] == null)
                {
                    command.Parameters.AddWithValue("@" + k, DBNull.Value);
                }
                else
                {
                    command.Parameters.AddWithValue("@" + k, @params[k]);
                }
            }

            foreach (string k in @whereParams.Keys)
            {
                if (@whereParams[k] == null)
                {
                    command.Parameters.AddWithValue("@" + k, DBNull.Value);
                }
                else
                {
                    command.Parameters.AddWithValue("@" + k, @whereParams[k]);
                }
            }

            try
            {
                return command.ExecuteNonQuery();
            }
            catch 
            {
                throw;
            }
            finally
            {
                command.Connection.Close();
                command.Dispose();
            }
        } // int UpdateRow

        #endregion

        #region HasthToStr
        public static string GetStrHash(Hashtable m_params)
        {
            string result = "";
            foreach (string k in m_params.Keys)
            {
                if (result == "")
                {
                    result += k + ":    " + m_params[k];
                }
                else
                {
                    result += "\r\n" + k + ":    " + m_params[k];
                }

            }
            return result;
        }
        #endregion

        /// <summary>
        /// Regresa un entero nulable a partir de una expresión evaluada
        /// </summary>
        /// <param name="expression">La expresión a evaluar</param>
        /// <returns>int?</returns>
        public static int? GetNullableInt32(object expression)
        {
            if (expression == null || Convert.IsDBNull(expression))
            {
                return null;
            }
            else
            {
                if (expression.GetType() == typeof(string))
                {
                    if (string.IsNullOrEmpty((string)expression))
                    {
                        return null;
                    }
                }
                return Convert.ToInt32(expression);
            }
        }

        public static DateTime? GetNullableDateTime(object expression)
        {
            if (expression == null || Convert.IsDBNull(expression))
            {
                return null;
            }
            else
            {
                if (expression.GetType() == typeof(string))
                {
                    if (string.IsNullOrEmpty((string)expression))
                    {
                        return null;
                    }
                }
                return Convert.ToDateTime(expression);
            }
        }

        public static decimal? GetNullableDecimal(object expression)
        {
            if (expression == null || Convert.IsDBNull(expression))
            {
                return null;
            }
            else
            {
                if (expression.GetType() == typeof(string))
                {
                    if (string.IsNullOrEmpty((string)expression))
                    {
                        return null;
                    }
                }
                return Convert.ToDecimal(expression);
            }
        }

        public static Boolean? GetNullableBoolean(object expression)
        {
            if (expression == null || Convert.IsDBNull(expression))
            {
                return null;
            }
            else
            {
                if (expression.GetType() == typeof(string))
                {
                    if (string.IsNullOrEmpty((string)expression))
                    {
                        return null;
                    }
                }
                return Convert.ToBoolean(expression);
            }
        }

        public static Char? GetNullableChar(object expression)
        {
            if (expression == null || Convert.IsDBNull(expression))
            {
                return null;
            }
            else
            {
                if (expression.GetType() == typeof(string))
                {
                    if (string.IsNullOrEmpty((string)expression))
                    {
                        return null;
                    }
                }
                return Convert.ToChar(expression);
            }
        }
    } //    DB Class

} //    End Namespace