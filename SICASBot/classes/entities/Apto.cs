using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace SICASBot.Apto
{    

    public class DB
    {
        public static string connStr = "Data Source=cascoap.dyndns.org;Initial Catalog=SICAS;Persist Security Info=True;User ID=SICASusr;Password=nhtccuag";
        //public static string connStr = "Data Source=(local)\\SQLEXPRESS;Initial Catalog=SICASAERO;Persist Security Info=True;User ID=SICASusr;Password=nhtccuag";
        //public static string connStr = "Data Source=sicas.casco.com.mx;Initial Catalog=SICASAERO;Persist Security Info=True;User ID=SICASusr;Password=nhtccuag";
        
        private static SqlConnection conn;

        public static IEnumerable<T> QueryList<T>(string sqlqry, string column)
        {
            DataTable dt = Query(sqlqry);
            List<T> list = new List<T>();

            foreach (DataRow dr in dt.Rows)
            {
                list.Add((T)dr[column]);
            }

            return list;
        }

        public static IEnumerable<T> QueryList<T>(string sqlqry, string column, params KeyValuePair<string, object>[] args)
        {
            DataTable dt = QueryCommand(sqlqry, GetParams(args));
            List<T> list = new List<T>();

            foreach (DataRow dr in dt.Rows)
            {
                list.Add((T)dr[column]);
            }

            return list;
        }

        public static byte[] PwdEncrypt(string pwd)
        {
            return (byte[])QueryScalar(String.Format("SELECT PWDENCRYPT('{0}')", pwd));
        }

        public static bool Exists(string tableName, params KeyValuePair<string, object>[] args)
        {
            Hashtable data = new Hashtable();
            foreach (KeyValuePair<string, object> kp in args)
            {
                data.Add(kp.Key, kp.Value);
            }

            if (GetCount(tableName, data) == 0) return false;
            return true;
        }

        public static KeyValuePair<string, object> Param(string key, object value)
        {
            return new KeyValuePair<string, object>(key, value);
        }

        public static DataTable Read(string tableName, string filter, string sort, params KeyValuePair<string, object>[] args)
        {
            return QueryCommand(SelectStatement(tableName, filter, sort), GetParams(args));
        }

        public static DataTable Read(string tableName, int top, string filter, string sort, params KeyValuePair<string, object>[] args)
        {
            return QueryCommand(SelectStatement(tableName, top, filter, sort), GetParams(args));
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

        public static int IdentityInsertRow(string strTabla, Hashtable @params)
        {
            string strSQL = String.Format("SET IDENTITY_INSERT {0} ON \r\n INSERT INTO {0} (", strTabla);
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

            strSQL += String.Format(") \r\n SET IDENTITY_INSERT {0} OFF", strTabla);

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

        public static int GetCount(string tablename)
        {
            SqlCommand command = new SqlCommand();
            command.Connection = new SqlConnection(connStr);

            try
            {
                command.Connection.Open();
                command.CommandType = CommandType.Text;
                command.CommandText = SelectCountStatement(tablename);
                command.Parameters.Clear();

                Object Result = command.ExecuteScalar();
                return (int)Result;
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


        public static int GetCount(string tablename, Hashtable w_params)
        {
            SqlCommand command = new SqlCommand();
            command.Connection = new SqlConnection(connStr);

            try
            {
                command.Connection.Open();
                command.CommandType = CommandType.Text;
                command.CommandText = SelectCountStatement(tablename, w_params);
                command.Parameters.Clear();

                foreach (string key in w_params.Keys)
                {
                    command.Parameters.AddWithValue(key, w_params[key]);
                }

                Object Result = command.ExecuteScalar();
                return (int)Result;
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

        public static string SelectStatement(string strTabla, int top, string filter, string sort)
        {
            string strSQL = "";

            strSQL += "SELECT TOP " + top.ToString() + " * FROM " + strTabla + " WHERE " + filter;

            if (!String.IsNullOrEmpty(sort)) strSQL += " ORDER BY " + sort;

            return strSQL;

        } // End SelectStatement

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

        public static string SelectStatement(string strTabla, string filter, string sort)
        {
            string strSQL = "";
            strSQL += "SELECT * FROM " + strTabla + " WHERE " + filter;
            if (!String.IsNullOrEmpty(sort)) strSQL += " ORDER BY " + sort;
            return strSQL;
        } // End SelectStatement

        public static string SelectScalarStatement(string strTabla, string strCampo, Hashtable @whereParams)
        {
            int cont;
            string strSQL = "";
            strSQL += "SELECT " + strCampo + " FROM " + strTabla + " WHERE ";
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

        public static string SelectCountStatement(string strTabla)
        {
            //int cont;
            string strSQL = "";
            strSQL += "SELECT COUNT(*) FROM " + strTabla;

            return strSQL;
        } // End SelectStatement

        public static string SelectCountStatement(string strTabla, Hashtable @whereParams)
        {
            int cont;
            string strSQL = "";
            strSQL += "SELECT COUNT(*) FROM " + strTabla + " WHERE ";
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

        public static Hashtable GetParams(params KeyValuePair<string, object>[] args)
        {
            Hashtable m_params = new Hashtable();
            foreach (KeyValuePair<string, object> kvp in args)
            {
                m_params.Add(kvp.Key, kvp.Value);
            }

            return m_params;
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

        public static Guid? GetNullableGuid(object expression)
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
                
                return new Guid(Convert.ToString(expression));
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

    namespace Entities
    {

        public class AjustesKm
        {

            public AjustesKm()
            {
            }

            public AjustesKm(int folio, int unidad, int kilometraje, string motivo, DateTime fecha, string usuario)
            {
                this.Folio = folio;
                this.Unidad = unidad;
                this.Kilometraje = kilometraje;
                this.Motivo = motivo;
                this.Fecha = fecha;
                this.Usuario = usuario;
            }

            private int _Folio;
            public int Folio
            {
                get { return _Folio; }
                set { _Folio = value; }
            }

            private int _Unidad;
            public int Unidad
            {
                get { return _Unidad; }
                set { _Unidad = value; }
            }

            private int _Kilometraje;
            public int Kilometraje
            {
                get { return _Kilometraje; }
                set { _Kilometraje = value; }
            }

            private string _Motivo;
            public string Motivo
            {
                get { return _Motivo; }
                set { _Motivo = value; }
            }

            private DateTime _Fecha;
            public DateTime Fecha
            {
                get { return _Fecha; }
                set { _Fecha = value; }
            }

            private string _Usuario;
            public string Usuario
            {
                get { return _Usuario; }
                set { _Usuario = value; }
            }

            public int Create()
            {
                Hashtable m_params = new Hashtable();
                m_params.Add("Folio", this.Folio);
                m_params.Add("Unidad", this.Unidad);
                m_params.Add("Kilometraje", this.Kilometraje);
                m_params.Add("Motivo", this.Motivo);
                m_params.Add("Fecha", this.Fecha);
                m_params.Add("Usuario", this.Usuario);

                return DB.InsertRow("AjustesKm", m_params);
            } // End Create

            public static List<AjustesKm> Read()
            {
                List<AjustesKm> list = new List<AjustesKm>();
                DataTable dt = DB.Select("AjustesKm");
                foreach (DataRow dr in dt.Rows)
                {
                    list.Add(new AjustesKm(Convert.ToInt32(dr["Folio"]), Convert.ToInt32(dr["Unidad"]), Convert.ToInt32(dr["Kilometraje"]), Convert.ToString(dr["Motivo"]), Convert.ToDateTime(dr["Fecha"]), Convert.ToString(dr["Usuario"])));
                }

                return list;
            } // End Read

            public int Update()
            {
                Hashtable m_params = new Hashtable();
                Hashtable w_params = new Hashtable();
                m_params.Add("Folio", this.Folio);
                m_params.Add("Unidad", this.Unidad);
                m_params.Add("Kilometraje", this.Kilometraje);
                m_params.Add("Motivo", this.Motivo);
                m_params.Add("Fecha", this.Fecha);
                m_params.Add("Usuario", this.Usuario);

                return DB.UpdateRow("AjustesKm", m_params, w_params);
            } // End Update

            public int Delete()
            {
                Hashtable w_params = new Hashtable();

                return DB.DeleteRow("AjustesKm", w_params);
            } // End Delete

        } //End Class AjustesKm

        public class Auditoria
        {

            public Auditoria()
            {
            }

            public Auditoria(int folio, string catalago, string accion, string usuario, string detalles, DateTime? fecha)
            {
                this.Folio = folio;
                this.Catalago = catalago;
                this.Accion = accion;
                this.Usuario = usuario;
                this.Detalles = detalles;
                this.Fecha = fecha;
            }

            private int _Folio;
            public int Folio
            {
                get { return _Folio; }
                set { _Folio = value; }
            }

            private string _Catalago;
            public string Catalago
            {
                get { return _Catalago; }
                set { _Catalago = value; }
            }

            private string _Accion;
            public string Accion
            {
                get { return _Accion; }
                set { _Accion = value; }
            }

            private string _Usuario;
            public string Usuario
            {
                get { return _Usuario; }
                set { _Usuario = value; }
            }

            private string _Detalles;
            public string Detalles
            {
                get { return _Detalles; }
                set { _Detalles = value; }
            }

            private DateTime? _Fecha;
            public DateTime? Fecha
            {
                get { return _Fecha; }
                set { _Fecha = value; }
            }

            public int Create()
            {
                Hashtable m_params = new Hashtable();
                if (!AppHelper.IsNullOrEmpty(this.Catalago)) m_params.Add("Catalago", this.Catalago);
                if (!AppHelper.IsNullOrEmpty(this.Accion)) m_params.Add("Accion", this.Accion);
                if (!AppHelper.IsNullOrEmpty(this.Usuario)) m_params.Add("Usuario", this.Usuario);
                if (!AppHelper.IsNullOrEmpty(this.Detalles)) m_params.Add("Detalles", this.Detalles);
                if (!AppHelper.IsNullOrEmpty(this.Fecha)) m_params.Add("Fecha", this.Fecha);

                return DB.InsertRow("Auditoria", m_params);
            } // End Create

            public static List<Auditoria> Read()
            {
                List<Auditoria> list = new List<Auditoria>();
                DataTable dt = DB.Select("Auditoria");
                foreach (DataRow dr in dt.Rows)
                {
                    list.Add(new Auditoria(Convert.ToInt32(dr["Folio"]), Convert.ToString(dr["Catalago"]), Convert.ToString(dr["Accion"]), Convert.ToString(dr["Usuario"]), Convert.ToString(dr["Detalles"]), DB.GetNullableDateTime(dr["Fecha"])));
                }

                return list;
            } // End Read

            public static Auditoria Read(int folio)
            {
                Hashtable w_params = new Hashtable();
                w_params.Add("Folio", folio);
                DataTable dt = DB.Select("Auditoria", w_params);
                if (dt.Rows.Count == 0)
                {
                    throw new Exception("No existe Auditoria con los criterios de búsqueda especificados.");
                }
                DataRow dr = dt.Rows[0];
                return new Auditoria(Convert.ToInt32(dr["Folio"]), Convert.ToString(dr["Catalago"]), Convert.ToString(dr["Accion"]), Convert.ToString(dr["Usuario"]), Convert.ToString(dr["Detalles"]), DB.GetNullableDateTime(dr["Fecha"]));
            } // End Read

            public int Update()
            {
                Hashtable m_params = new Hashtable();
                Hashtable w_params = new Hashtable();
                w_params.Add("Folio", this.Folio);
                if (!AppHelper.IsNullOrEmpty(this.Catalago)) m_params.Add("Catalago", this.Catalago);
                if (!AppHelper.IsNullOrEmpty(this.Accion)) m_params.Add("Accion", this.Accion);
                if (!AppHelper.IsNullOrEmpty(this.Usuario)) m_params.Add("Usuario", this.Usuario);
                if (!AppHelper.IsNullOrEmpty(this.Detalles)) m_params.Add("Detalles", this.Detalles);
                if (!AppHelper.IsNullOrEmpty(this.Fecha)) m_params.Add("Fecha", this.Fecha);

                return DB.UpdateRow("Auditoria", m_params, w_params);
            } // End Update

            public int Delete()
            {
                Hashtable w_params = new Hashtable();
                w_params.Add("Folio", this.Folio);

                return DB.DeleteRow("Auditoria", w_params);
            } // End Delete

        } //End Class Auditoria

        public class AutenticacionEbssa
        {

            public AutenticacionEbssa()
            {
            }

            public AutenticacionEbssa(string clave, string pwd)
            {
                this.Clave = clave;
                this.Pwd = pwd;
            }

            private string _Clave;
            public string Clave
            {
                get { return _Clave; }
                set { _Clave = value; }
            }

            private string _Pwd;
            public string Pwd
            {
                get { return _Pwd; }
                set { _Pwd = value; }
            }

            public int Create()
            {
                Hashtable m_params = new Hashtable();
                m_params.Add("Clave", this.Clave);
                m_params.Add("Pwd", this.Pwd);

                return DB.InsertRow("AutenticacionEbssa", m_params);
            } // End Create

            public static List<AutenticacionEbssa> Read()
            {
                List<AutenticacionEbssa> list = new List<AutenticacionEbssa>();
                DataTable dt = DB.Select("AutenticacionEbssa");
                foreach (DataRow dr in dt.Rows)
                {
                    list.Add(new AutenticacionEbssa(Convert.ToString(dr["Clave"]), Convert.ToString(dr["Pwd"])));
                }

                return list;
            } // End Read

            public int Update()
            {
                Hashtable m_params = new Hashtable();
                Hashtable w_params = new Hashtable();
                m_params.Add("Clave", this.Clave);
                m_params.Add("Pwd", this.Pwd);

                return DB.UpdateRow("AutenticacionEbssa", m_params, w_params);
            } // End Update

            public int Delete()
            {
                Hashtable w_params = new Hashtable();

                return DB.DeleteRow("AutenticacionEbssa", w_params);
            } // End Delete

        } //End Class AutenticacionEbssa

        public class Avales
        {

            public Avales()
            {
            }

            public Avales(int conductor, string apellidopaterno, string apellidomaterno, string nombre, string calle, string numerocasa, string entrecalles, string colonia, string municipio, string estado, string telefono, string parentesco)
            {
                this.Conductor = conductor;
                this.ApellidoPaterno = apellidopaterno;
                this.ApellidoMaterno = apellidomaterno;
                this.Nombre = nombre;
                this.Calle = calle;
                this.NumeroCasa = numerocasa;
                this.EntreCalles = entrecalles;
                this.Colonia = colonia;
                this.Municipio = municipio;
                this.Estado = estado;
                this.Telefono = telefono;
                this.Parentesco = parentesco;
            }

            private int _Conductor;
            public int Conductor
            {
                get { return _Conductor; }
                set { _Conductor = value; }
            }

            private string _ApellidoPaterno;
            public string ApellidoPaterno
            {
                get { return _ApellidoPaterno; }
                set { _ApellidoPaterno = value; }
            }

            private string _ApellidoMaterno;
            public string ApellidoMaterno
            {
                get { return _ApellidoMaterno; }
                set { _ApellidoMaterno = value; }
            }

            private string _Nombre;
            public string Nombre
            {
                get { return _Nombre; }
                set { _Nombre = value; }
            }

            private string _Calle;
            public string Calle
            {
                get { return _Calle; }
                set { _Calle = value; }
            }

            private string _NumeroCasa;
            public string NumeroCasa
            {
                get { return _NumeroCasa; }
                set { _NumeroCasa = value; }
            }

            private string _EntreCalles;
            public string EntreCalles
            {
                get { return _EntreCalles; }
                set { _EntreCalles = value; }
            }

            private string _Colonia;
            public string Colonia
            {
                get { return _Colonia; }
                set { _Colonia = value; }
            }

            private string _Municipio;
            public string Municipio
            {
                get { return _Municipio; }
                set { _Municipio = value; }
            }

            private string _Estado;
            public string Estado
            {
                get { return _Estado; }
                set { _Estado = value; }
            }

            private string _Telefono;
            public string Telefono
            {
                get { return _Telefono; }
                set { _Telefono = value; }
            }

            private string _Parentesco;
            public string Parentesco
            {
                get { return _Parentesco; }
                set { _Parentesco = value; }
            }

            public int Create()
            {
                Hashtable m_params = new Hashtable();
                m_params.Add("Conductor", this.Conductor);
                m_params.Add("ApellidoPaterno", this.ApellidoPaterno);
                m_params.Add("ApellidoMaterno", this.ApellidoMaterno);
                m_params.Add("Nombre", this.Nombre);
                m_params.Add("Calle", this.Calle);
                m_params.Add("NumeroCasa", this.NumeroCasa);
                if (!AppHelper.IsNullOrEmpty(this.EntreCalles)) m_params.Add("EntreCalles", this.EntreCalles);
                m_params.Add("Colonia", this.Colonia);
                m_params.Add("Municipio", this.Municipio);
                m_params.Add("Estado", this.Estado);
                m_params.Add("Telefono", this.Telefono);
                if (!AppHelper.IsNullOrEmpty(this.Parentesco)) m_params.Add("Parentesco", this.Parentesco);

                return DB.InsertRow("Avales", m_params);
            } // End Create

            public static List<Avales> Read()
            {
                List<Avales> list = new List<Avales>();
                DataTable dt = DB.Select("Avales");
                foreach (DataRow dr in dt.Rows)
                {
                    list.Add(new Avales(Convert.ToInt32(dr["Conductor"]), Convert.ToString(dr["ApellidoPaterno"]), Convert.ToString(dr["ApellidoMaterno"]), Convert.ToString(dr["Nombre"]), Convert.ToString(dr["Calle"]), Convert.ToString(dr["NumeroCasa"]), Convert.ToString(dr["EntreCalles"]), Convert.ToString(dr["Colonia"]), Convert.ToString(dr["Municipio"]), Convert.ToString(dr["Estado"]), Convert.ToString(dr["Telefono"]), Convert.ToString(dr["Parentesco"])));
                }

                return list;
            } // End Read

            public int Update()
            {
                Hashtable m_params = new Hashtable();
                Hashtable w_params = new Hashtable();
                m_params.Add("Conductor", this.Conductor);
                m_params.Add("ApellidoPaterno", this.ApellidoPaterno);
                m_params.Add("ApellidoMaterno", this.ApellidoMaterno);
                m_params.Add("Nombre", this.Nombre);
                m_params.Add("Calle", this.Calle);
                m_params.Add("NumeroCasa", this.NumeroCasa);
                if (!AppHelper.IsNullOrEmpty(this.EntreCalles)) m_params.Add("EntreCalles", this.EntreCalles);
                m_params.Add("Colonia", this.Colonia);
                m_params.Add("Municipio", this.Municipio);
                m_params.Add("Estado", this.Estado);
                m_params.Add("Telefono", this.Telefono);
                if (!AppHelper.IsNullOrEmpty(this.Parentesco)) m_params.Add("Parentesco", this.Parentesco);

                return DB.UpdateRow("Avales", m_params, w_params);
            } // End Update

            public int Delete()
            {
                Hashtable w_params = new Hashtable();

                return DB.DeleteRow("Avales", w_params);
            } // End Delete

        } //End Class Avales

        public class BitacoraSupervisores
        {

            public BitacoraSupervisores()
            {
            }

            public BitacoraSupervisores(int folio, string usuario, DateTime fecha, string comentarios)
            {
                this.Folio = folio;
                this.Usuario = usuario;
                this.Fecha = fecha;
                this.Comentarios = comentarios;
            }

            private int _Folio;
            public int Folio
            {
                get { return _Folio; }
                set { _Folio = value; }
            }

            private string _Usuario;
            public string Usuario
            {
                get { return _Usuario; }
                set { _Usuario = value; }
            }

            private DateTime _Fecha;
            public DateTime Fecha
            {
                get { return _Fecha; }
                set { _Fecha = value; }
            }

            private string _Comentarios;
            public string Comentarios
            {
                get { return _Comentarios; }
                set { _Comentarios = value; }
            }

            public int Create()
            {
                Hashtable m_params = new Hashtable();
                m_params.Add("Usuario", this.Usuario);
                m_params.Add("Fecha", this.Fecha);
                m_params.Add("Comentarios", this.Comentarios);

                return DB.InsertRow("BitacoraSupervisores", m_params);
            } // End Create

            public static List<BitacoraSupervisores> Read()
            {
                List<BitacoraSupervisores> list = new List<BitacoraSupervisores>();
                DataTable dt = DB.Select("BitacoraSupervisores");
                foreach (DataRow dr in dt.Rows)
                {
                    list.Add(new BitacoraSupervisores(Convert.ToInt32(dr["Folio"]), Convert.ToString(dr["Usuario"]), Convert.ToDateTime(dr["Fecha"]), Convert.ToString(dr["Comentarios"])));
                }

                return list;
            } // End Read

            public static BitacoraSupervisores Read(int folio)
            {
                Hashtable w_params = new Hashtable();
                w_params.Add("Folio", folio);
                DataTable dt = DB.Select("BitacoraSupervisores", w_params);
                if (dt.Rows.Count == 0)
                {
                    throw new Exception("No existe BitacoraSupervisores con los criterios de búsqueda especificados.");
                }
                DataRow dr = dt.Rows[0];
                return new BitacoraSupervisores(Convert.ToInt32(dr["Folio"]), Convert.ToString(dr["Usuario"]), Convert.ToDateTime(dr["Fecha"]), Convert.ToString(dr["Comentarios"]));
            } // End Read

            public int Update()
            {
                Hashtable m_params = new Hashtable();
                Hashtable w_params = new Hashtable();
                w_params.Add("Folio", this.Folio);
                m_params.Add("Usuario", this.Usuario);
                m_params.Add("Fecha", this.Fecha);
                m_params.Add("Comentarios", this.Comentarios);

                return DB.UpdateRow("BitacoraSupervisores", m_params, w_params);
            } // End Update

            public int Delete()
            {
                Hashtable w_params = new Hashtable();
                w_params.Add("Folio", this.Folio);

                return DB.DeleteRow("BitacoraSupervisores", w_params);
            } // End Delete

        } //End Class BitacoraSupervisores

        public class BoletosAeropuerto
        {

            public BoletosAeropuerto()
            {
            }

            public BoletosAeropuerto(string codigo, int foliodiario, int? caja, int zona, int? referencia, 
                int claseservicio, int tiposervicio, int tipopago, decimal precio, DateTime fecha, 
                int? foliodiarioebssa, Guid? codigoseguridadebssa, bool? pagadoebssa, int status, 
                string foliocortesia, decimal? montocortesia, string usuario)
            {
                this.Codigo = codigo;
                this.Codigo = codigo;
                this.FolioDiario = foliodiario;
                this.Caja = caja;
                this.Zona = zona;
                this.Referencia = referencia;
                this.ClaseServicio = claseservicio;
                this.TipoServicio = tiposervicio;
                this.TipoPago = tipopago;
                this.Precio = precio;
                this.Fecha = fecha;
                this.FolioDiarioEbssa = foliodiarioebssa;
                this.CodigoSeguridadEbssa = codigoseguridadebssa;
                this.PagadoEbssa = pagadoebssa;
                this.Status = status;
                this.FolioCortesia = foliocortesia;
                this.MontoCortesia = montocortesia;
                this.Usuario = usuario;

                this.LoadRelations();
            }

            private string _Codigo;
            public string Codigo
            {
                get { return _Codigo; }
                set { _Codigo = value; }
            }

            private int _FolioDiario;
            public int FolioDiario
            {
                get { return _FolioDiario; }
                set { _FolioDiario = value; }
            }

            private int? _Caja;
            public int? Caja
            {
                get { return _Caja; }
                set { _Caja = value; }
            }

            private int _Zona;
            public int Zona
            {
                get { return _Zona; }
                set { _Zona = value; }
            }

            private int? _Referencia;
            public int? Referencia
            {
                get { return _Referencia; }
                set { _Referencia = value; }
            }

            private int _ClaseServicio;
            public int ClaseServicio
            {
                get { return _ClaseServicio; }
                set { _ClaseServicio = value; }
            }

            private int _TipoServicio;
            public int TipoServicio
            {
                get { return _TipoServicio; }
                set { _TipoServicio = value; }
            }

            private int _TipoPago;
            public int TipoPago
            {
                get { return _TipoPago; }
                set { _TipoPago = value; }
            }

            private decimal _Precio;
            public decimal Precio
            {
                get { return _Precio; }
                set { _Precio = value; }
            }

            private DateTime _Fecha;
            public DateTime Fecha
            {
                get { return _Fecha; }
                set { _Fecha = value; }
            }

            private int? _FolioDiarioEbssa;
            public int? FolioDiarioEbssa
            {
                get { return _FolioDiarioEbssa; }
                set { _FolioDiarioEbssa = value; }
            }

            private Guid? _CodigoSeguridadEbssa;
            public Guid? CodigoSeguridadEbssa
            {
                get { return _CodigoSeguridadEbssa; }
                set { _CodigoSeguridadEbssa = value; }
            }

            private bool? _PagadoEbssa;
            public bool? PagadoEbssa
            {
                get { return _PagadoEbssa; }
                set { _PagadoEbssa = value; }
            }

            private int _Status;
            public int Status
            {
                get { return _Status; }
                set { _Status = value; }
            }

            private string _FolioCortesia;
            public string FolioCortesia
            {
                get { return _FolioCortesia; }
                set { _FolioCortesia = value; }
            }

            private decimal? _MontoCortesia;
            public decimal? MontoCortesia
            {
                get { return _MontoCortesia; }
                set { _MontoCortesia = value; }
            }

            private string _Usuario;
            public string Usuario
            {
                get { return _Usuario; }
                set { _Usuario = value; }
            }

            public int Create()
            {
                Hashtable m_params = new Hashtable();
                m_params.Add("Codigo", this.Codigo);
                m_params.Add("Codigo", this.Codigo);
                m_params.Add("FolioDiario", this.FolioDiario);
                if (!AppHelper.IsNullOrEmpty(this.Caja)) m_params.Add("Caja", this.Caja);
                m_params.Add("Zona", this.Zona);
                if (!AppHelper.IsNullOrEmpty(this.Referencia)) m_params.Add("Referencia", this.Referencia);
                m_params.Add("ClaseServicio", this.ClaseServicio);
                m_params.Add("TipoServicio", this.TipoServicio);
                m_params.Add("TipoPago", this.TipoPago);
                m_params.Add("Precio", this.Precio);
                m_params.Add("Fecha", this.Fecha);
                if (!AppHelper.IsNullOrEmpty(this.FolioDiarioEbssa)) m_params.Add("FolioDiarioEbssa", this.FolioDiarioEbssa);
                if (!AppHelper.IsNullOrEmpty(this.CodigoSeguridadEbssa)) m_params.Add("CodigoSeguridadEbssa", this.CodigoSeguridadEbssa);
                if (!AppHelper.IsNullOrEmpty(this.PagadoEbssa)) m_params.Add("PagadoEbssa", this.PagadoEbssa);
                m_params.Add("Status", this.Status);
                if (!AppHelper.IsNullOrEmpty(this.FolioCortesia)) m_params.Add("FolioCortesia", this.FolioCortesia);
                if (!AppHelper.IsNullOrEmpty(this.MontoCortesia)) m_params.Add("MontoCortesia", this.MontoCortesia);
                if (!AppHelper.IsNullOrEmpty(this.Usuario)) m_params.Add("Usuario", this.Usuario);

                return DB.InsertRow("BoletosAeropuerto", m_params);
            } // End Create

            public static List<BoletosAeropuerto> Read()
            {
                List<BoletosAeropuerto> list = new List<BoletosAeropuerto>();
                DataTable dt = DB.Select("BoletosAeropuerto");
                foreach (DataRow dr in dt.Rows)
                {
                    list.Add(new BoletosAeropuerto(Convert.ToString(dr["Codigo"]), Convert.ToInt32(dr["FolioDiario"]), DB.GetNullableInt32(dr["Caja"]), Convert.ToInt32(dr["Zona"]), DB.GetNullableInt32(dr["Referencia"]), Convert.ToInt32(dr["ClaseServicio"]), Convert.ToInt32(dr["TipoServicio"]), Convert.ToInt32(dr["TipoPago"]), Convert.ToDecimal(dr["Precio"]), Convert.ToDateTime(dr["Fecha"]), DB.GetNullableInt32(dr["FolioDiarioEbssa"]), DB.GetNullableGuid(dr["CodigoSeguridadEbssa"]), DB.GetNullableBoolean(dr["PagadoEbssa"]), Convert.ToInt32(dr["Status"]), Convert.ToString(dr["FolioCortesia"]), DB.GetNullableDecimal(dr["MontoCortesia"]), Convert.ToString(dr["Usuario"])));
                }

                return list;
            } // End Read

            public static BoletosAeropuerto Read(string codigo)
            {
                Hashtable w_params = new Hashtable();
                w_params.Add("Codigo", codigo);
                DataTable dt = DB.Select("BoletosAeropuerto", w_params);
                if (dt.Rows.Count == 0)
                {
                    throw new Exception("No existe BoletosAeropuerto con los criterios de búsqueda especificados.");
                }
                DataRow dr = dt.Rows[0];
                return new BoletosAeropuerto(Convert.ToString(dr["Codigo"]), Convert.ToInt32(dr["FolioDiario"]), DB.GetNullableInt32(dr["Caja"]), Convert.ToInt32(dr["Zona"]), DB.GetNullableInt32(dr["Referencia"]), Convert.ToInt32(dr["ClaseServicio"]), Convert.ToInt32(dr["TipoServicio"]), Convert.ToInt32(dr["TipoPago"]), Convert.ToDecimal(dr["Precio"]), Convert.ToDateTime(dr["Fecha"]), DB.GetNullableInt32(dr["FolioDiarioEbssa"]), DB.GetNullableGuid(dr["CodigoSeguridadEbssa"]), DB.GetNullableBoolean(dr["PagadoEbssa"]), Convert.ToInt32(dr["Status"]), Convert.ToString(dr["FolioCortesia"]), DB.GetNullableDecimal(dr["MontoCortesia"]), Convert.ToString(dr["Usuario"]));
            } // End Read

            public static List<BoletosAeropuerto> Read(params KeyValuePair<string, object>[] args)
            {
                DataTable dt = DB.Read("BoletosAeropuerto", args);
                List<BoletosAeropuerto> list = new List<BoletosAeropuerto>();                
                foreach (DataRow dr in dt.Rows)
                {
                    list.Add(new BoletosAeropuerto(Convert.ToString(dr["Codigo"]), Convert.ToInt32(dr["FolioDiario"]), DB.GetNullableInt32(dr["Caja"]), Convert.ToInt32(dr["Zona"]), DB.GetNullableInt32(dr["Referencia"]), Convert.ToInt32(dr["ClaseServicio"]), Convert.ToInt32(dr["TipoServicio"]), Convert.ToInt32(dr["TipoPago"]), Convert.ToDecimal(dr["Precio"]), Convert.ToDateTime(dr["Fecha"]), DB.GetNullableInt32(dr["FolioDiarioEbssa"]), DB.GetNullableGuid(dr["CodigoSeguridadEbssa"]), DB.GetNullableBoolean(dr["PagadoEbssa"]), Convert.ToInt32(dr["Status"]), Convert.ToString(dr["FolioCortesia"]), DB.GetNullableDecimal(dr["MontoCortesia"]), Convert.ToString(dr["Usuario"])));
                }

                return list;
            } // End Read

            public static bool Read(out BoletosAeropuerto boletosaeropuerto, int top, string filter, string sort, params KeyValuePair<string, object>[] args)
            {
                DataTable dt = DB.Read("BoletosAeropuerto", top, filter, sort, args);
                if (dt.Rows.Count == 0)
                {
                    boletosaeropuerto = null;
                    return false;
                }
                DataRow dr = dt.Rows[0];
                boletosaeropuerto = new BoletosAeropuerto(Convert.ToString(dr["Codigo"]), Convert.ToInt32(dr["FolioDiario"]), DB.GetNullableInt32(dr["Caja"]), Convert.ToInt32(dr["Zona"]), DB.GetNullableInt32(dr["Referencia"]), Convert.ToInt32(dr["ClaseServicio"]), Convert.ToInt32(dr["TipoServicio"]), Convert.ToInt32(dr["TipoPago"]), Convert.ToDecimal(dr["Precio"]), Convert.ToDateTime(dr["Fecha"]), DB.GetNullableInt32(dr["FolioDiarioEbssa"]), DB.GetNullableGuid(dr["CodigoSeguridadEbssa"]), DB.GetNullableBoolean(dr["PagadoEbssa"]), Convert.ToInt32(dr["Status"]), Convert.ToString(dr["FolioCortesia"]), DB.GetNullableDecimal(dr["MontoCortesia"]), Convert.ToString(dr["Usuario"]));
                return true;
            } // End Read

            public int Update()
            {
                Hashtable m_params = new Hashtable();
                Hashtable w_params = new Hashtable();
                m_params.Add("Codigo", this.Codigo);
                w_params.Add("Codigo", this.Codigo);
                m_params.Add("FolioDiario", this.FolioDiario);
                if (!AppHelper.IsNullOrEmpty(this.Caja)) m_params.Add("Caja", this.Caja);
                m_params.Add("Zona", this.Zona);
                if (!AppHelper.IsNullOrEmpty(this.Referencia)) m_params.Add("Referencia", this.Referencia);
                m_params.Add("ClaseServicio", this.ClaseServicio);
                m_params.Add("TipoServicio", this.TipoServicio);
                m_params.Add("TipoPago", this.TipoPago);
                m_params.Add("Precio", this.Precio);
                m_params.Add("Fecha", this.Fecha);
                if (!AppHelper.IsNullOrEmpty(this.FolioDiarioEbssa)) m_params.Add("FolioDiarioEbssa", this.FolioDiarioEbssa);
                if (!AppHelper.IsNullOrEmpty(this.CodigoSeguridadEbssa)) m_params.Add("CodigoSeguridadEbssa", this.CodigoSeguridadEbssa);
                if (!AppHelper.IsNullOrEmpty(this.PagadoEbssa)) m_params.Add("PagadoEbssa", this.PagadoEbssa);
                m_params.Add("Status", this.Status);
                if (!AppHelper.IsNullOrEmpty(this.FolioCortesia)) m_params.Add("FolioCortesia", this.FolioCortesia);
                if (!AppHelper.IsNullOrEmpty(this.MontoCortesia)) m_params.Add("MontoCortesia", this.MontoCortesia);
                if (!AppHelper.IsNullOrEmpty(this.Usuario)) m_params.Add("Usuario", this.Usuario);

                return DB.UpdateRow("BoletosAeropuerto", m_params, w_params);
            } // End Update

            public int Delete()
            {
                Hashtable w_params = new Hashtable();
                w_params.Add("Codigo", this.Codigo);

                return DB.DeleteRow("BoletosAeropuerto", w_params);
            } // End Delete

            private CarrerasAeropuerto _Carrera;
            public CarrerasAeropuerto Carrera
            { 
                get { return _Carrera; }
            }

            private PagoBoletos _Pago;
            public PagoBoletos Pago
            {
                get { return _Pago; }
            }

            private ControlCajas _ControlCaja;
            public ControlCajas ControlCaja
            {
                get { return _ControlCaja; }
            }

            private void LoadRelations()
            {
                this._Carrera = CarrerasAeropuerto.Read(this.Codigo);
                this._Pago = PagoBoletos.Read(this.Codigo);
                this._ControlCaja =
                    ControlCajas.Read(
                        @" ( @Fecha BETWEEN FechaInicioCaja AND FechaCorteCaja ) AND
                            ( Usuario = @Usuario ) ", DB.Param("@Fecha", this.Fecha),
                                                    DB.Param("@Usuario", this.Usuario));
            }

        } //End Class BoletosAeropuerto

        public class BoletosConsultadosAuditoria
        {

            public BoletosConsultadosAuditoria()
            {
            }

            public BoletosConsultadosAuditoria(int? auditoria, string boleto, DateTime? fecha)
            {
                this.Auditoria = auditoria;
                this.Boleto = boleto;
                this.Fecha = fecha;
            }

            private int? _Auditoria;
            public int? Auditoria
            {
                get { return _Auditoria; }
                set { _Auditoria = value; }
            }

            private string _Boleto;
            public string Boleto
            {
                get { return _Boleto; }
                set { _Boleto = value; }
            }

            private DateTime? _Fecha;
            public DateTime? Fecha
            {
                get { return _Fecha; }
                set { _Fecha = value; }
            }

            public int Create()
            {
                Hashtable m_params = new Hashtable();
                if (!AppHelper.IsNullOrEmpty(this.Auditoria)) m_params.Add("Auditoria", this.Auditoria);
                if (!AppHelper.IsNullOrEmpty(this.Boleto)) m_params.Add("Boleto", this.Boleto);
                if (!AppHelper.IsNullOrEmpty(this.Fecha)) m_params.Add("Fecha", this.Fecha);

                return DB.InsertRow("BoletosConsultadosAuditoria", m_params);
            } // End Create

            public static List<BoletosConsultadosAuditoria> Read()
            {
                List<BoletosConsultadosAuditoria> list = new List<BoletosConsultadosAuditoria>();
                DataTable dt = DB.Select("BoletosConsultadosAuditoria");
                foreach (DataRow dr in dt.Rows)
                {
                    list.Add(new BoletosConsultadosAuditoria(DB.GetNullableInt32(dr["Auditoria"]), Convert.ToString(dr["Boleto"]), DB.GetNullableDateTime(dr["Fecha"])));
                }

                return list;
            } // End Read

            

            public int Update()
            {
                Hashtable m_params = new Hashtable();
                Hashtable w_params = new Hashtable();
                if (!AppHelper.IsNullOrEmpty(this.Auditoria)) m_params.Add("Auditoria", this.Auditoria);
                if (!AppHelper.IsNullOrEmpty(this.Boleto)) m_params.Add("Boleto", this.Boleto);
                if (!AppHelper.IsNullOrEmpty(this.Fecha)) m_params.Add("Fecha", this.Fecha);

                return DB.UpdateRow("BoletosConsultadosAuditoria", m_params, w_params);
            } // End Update

            public int Delete()
            {
                Hashtable w_params = new Hashtable();

                return DB.DeleteRow("BoletosConsultadosAuditoria", w_params);
            } // End Delete

        } //End Class BoletosConsultadosAuditoria

        public class BoletosCortesiaAeropuerto
        {

            public BoletosCortesiaAeropuerto()
            {
            }

            public BoletosCortesiaAeropuerto(string codigo, int foliodiario, decimal monto, DateTime fecha, string usuario, int status)
            {
                this.Codigo = codigo;
                this.FolioDiario = foliodiario;
                this.Monto = monto;
                this.Fecha = fecha;
                this.Usuario = usuario;
                this.Status = status;
            }

            private string _Codigo;
            public string Codigo
            {
                get { return _Codigo; }
                set { _Codigo = value; }
            }

            private int _FolioDiario;
            public int FolioDiario
            {
                get { return _FolioDiario; }
                set { _FolioDiario = value; }
            }

            private decimal _Monto;
            public decimal Monto
            {
                get { return _Monto; }
                set { _Monto = value; }
            }

            private DateTime _Fecha;
            public DateTime Fecha
            {
                get { return _Fecha; }
                set { _Fecha = value; }
            }

            private string _Usuario;
            public string Usuario
            {
                get { return _Usuario; }
                set { _Usuario = value; }
            }

            private int _Status;
            public int Status
            {
                get { return _Status; }
                set { _Status = value; }
            }

            public int Create()
            {
                Hashtable m_params = new Hashtable();
                m_params.Add("Codigo", this.Codigo);
                m_params.Add("FolioDiario", this.FolioDiario);
                m_params.Add("Monto", this.Monto);
                m_params.Add("Fecha", this.Fecha);
                m_params.Add("Usuario", this.Usuario);
                m_params.Add("Status", this.Status);

                return DB.InsertRow("BoletosCortesiaAeropuerto", m_params);
            } // End Create

            public static List<BoletosCortesiaAeropuerto> Read()
            {
                List<BoletosCortesiaAeropuerto> list = new List<BoletosCortesiaAeropuerto>();
                DataTable dt = DB.Select("BoletosCortesiaAeropuerto");
                foreach (DataRow dr in dt.Rows)
                {
                    list.Add(new BoletosCortesiaAeropuerto(Convert.ToString(dr["Codigo"]), Convert.ToInt32(dr["FolioDiario"]), Convert.ToDecimal(dr["Monto"]), Convert.ToDateTime(dr["Fecha"]), Convert.ToString(dr["Usuario"]), Convert.ToInt32(dr["Status"])));
                }

                return list;
            } // End Read

            public static BoletosCortesiaAeropuerto Read(string codigo)
            {
                Hashtable w_params = new Hashtable();
                w_params.Add("Codigo", codigo);
                DataTable dt = DB.Select("BoletosCortesiaAeropuerto", w_params);
                if (dt.Rows.Count == 0)
                {
                    throw new Exception("No existe BoletosCortesiaAeropuerto con los criterios de búsqueda especificados.");
                }
                DataRow dr = dt.Rows[0];
                return new BoletosCortesiaAeropuerto(Convert.ToString(dr["Codigo"]), Convert.ToInt32(dr["FolioDiario"]), Convert.ToDecimal(dr["Monto"]), Convert.ToDateTime(dr["Fecha"]), Convert.ToString(dr["Usuario"]), Convert.ToInt32(dr["Status"]));
            } // End Read

            public int Update()
            {
                Hashtable m_params = new Hashtable();
                Hashtable w_params = new Hashtable();
                w_params.Add("Codigo", this.Codigo);
                m_params.Add("FolioDiario", this.FolioDiario);
                m_params.Add("Monto", this.Monto);
                m_params.Add("Fecha", this.Fecha);
                m_params.Add("Usuario", this.Usuario);
                m_params.Add("Status", this.Status);

                return DB.UpdateRow("BoletosCortesiaAeropuerto", m_params, w_params);
            } // End Update

            public int Delete()
            {
                Hashtable w_params = new Hashtable();
                w_params.Add("Codigo", this.Codigo);

                return DB.DeleteRow("BoletosCortesiaAeropuerto", w_params);
            } // End Delete

        } //End Class BoletosCortesiaAeropuerto

        public class BoletosEspecialesAeropuerto
        {

            public BoletosEspecialesAeropuerto()
            {
            }

            public BoletosEspecialesAeropuerto(string codigo, int? tipo, int? foliodiario, decimal? precio, DateTime? fecha, int? status, string usuario, int? tipopago)
            {
                this.Codigo = codigo;
                this.Tipo = tipo;
                this.FolioDiario = foliodiario;
                this.Precio = precio;
                this.Fecha = fecha;
                this.Status = status;
                this.Usuario = usuario;
                this.TipoPago = tipopago;

                this.LoadRelations();
            }

            private string _Codigo;
            public string Codigo
            {
                get { return _Codigo; }
                set { _Codigo = value; }
            }

            private int? _Tipo;
            public int? Tipo
            {
                get { return _Tipo; }
                set { _Tipo = value; }
            }

            private int? _FolioDiario;
            public int? FolioDiario
            {
                get { return _FolioDiario; }
                set { _FolioDiario = value; }
            }

            private decimal? _Precio;
            public decimal? Precio
            {
                get { return _Precio; }
                set { _Precio = value; }
            }

            private DateTime? _Fecha;
            public DateTime? Fecha
            {
                get { return _Fecha; }
                set { _Fecha = value; }
            }

            private int? _Status;
            public int? Status
            {
                get { return _Status; }
                set { _Status = value; }
            }

            private string _Usuario;
            public string Usuario
            {
                get { return _Usuario; }
                set { _Usuario = value; }
            }

            private int? _TipoPago;
            public int? TipoPago
            {
                get { return _TipoPago; }
                set { _TipoPago = value; }
            }

            private CarrerasAeropuerto _Carrera;
            public CarrerasAeropuerto Carrera
            {
                get { return _Carrera; }
            }

            private PagoBoletos _Pago;
            public PagoBoletos Pago
            {
                get { return _Pago; }
            }

            private ControlCajas _ControlCaja;
            public ControlCajas ControlCaja
            {
                get { return _ControlCaja; }
            }

            private void LoadRelations()
            {
                this._Carrera = CarrerasAeropuerto.Read(this.Codigo);
                this._Pago = PagoBoletos.Read(this.Codigo);
                this._ControlCaja =
                    ControlCajas.Read(
                        @" ( @Fecha BETWEEN FechaInicioCaja AND FechaCorteCaja ) AND
                            ( Usuario = @Usuario ) ", DB.Param("@Fecha", this.Fecha),
                                                    DB.Param("@Usuario", this.Usuario));
            }

            public int Create()
            {
                Hashtable m_params = new Hashtable();
                m_params.Add("Codigo", this.Codigo);
                if (!AppHelper.IsNullOrEmpty(this.Tipo)) m_params.Add("Tipo", this.Tipo);
                if (!AppHelper.IsNullOrEmpty(this.FolioDiario)) m_params.Add("FolioDiario", this.FolioDiario);
                if (!AppHelper.IsNullOrEmpty(this.Precio)) m_params.Add("Precio", this.Precio);
                if (!AppHelper.IsNullOrEmpty(this.Fecha)) m_params.Add("Fecha", this.Fecha);
                if (!AppHelper.IsNullOrEmpty(this.Status)) m_params.Add("Status", this.Status);
                if (!AppHelper.IsNullOrEmpty(this.Usuario)) m_params.Add("Usuario", this.Usuario);
                if (!AppHelper.IsNullOrEmpty(this.TipoPago)) m_params.Add("TipoPago", this.TipoPago);

                return DB.InsertRow("BoletosEspecialesAeropuerto", m_params);
            } // End Create

            public static List<BoletosEspecialesAeropuerto> Read()
            {
                List<BoletosEspecialesAeropuerto> list = new List<BoletosEspecialesAeropuerto>();
                DataTable dt = DB.Select("BoletosEspecialesAeropuerto");
                foreach (DataRow dr in dt.Rows)
                {
                    list.Add(new BoletosEspecialesAeropuerto(Convert.ToString(dr["Codigo"]), DB.GetNullableInt32(dr["Tipo"]), DB.GetNullableInt32(dr["FolioDiario"]), DB.GetNullableDecimal(dr["Precio"]), DB.GetNullableDateTime(dr["Fecha"]), DB.GetNullableInt32(dr["Status"]), Convert.ToString(dr["Usuario"]), DB.GetNullableInt32(dr["TipoPago"])));
                }

                return list;
            } // End Read

            public static BoletosEspecialesAeropuerto Read(string codigo)
            {
                Hashtable w_params = new Hashtable();
                w_params.Add("Codigo", codigo);
                DataTable dt = DB.Select("BoletosEspecialesAeropuerto", w_params);
                if (dt.Rows.Count == 0)
                {
                    throw new Exception("No existe BoletosEspecialesAeropuerto con los criterios de búsqueda especificados.");
                }
                DataRow dr = dt.Rows[0];
                return new BoletosEspecialesAeropuerto(Convert.ToString(dr["Codigo"]), DB.GetNullableInt32(dr["Tipo"]), DB.GetNullableInt32(dr["FolioDiario"]), DB.GetNullableDecimal(dr["Precio"]), DB.GetNullableDateTime(dr["Fecha"]), DB.GetNullableInt32(dr["Status"]), Convert.ToString(dr["Usuario"]), DB.GetNullableInt32(dr["TipoPago"]));
            } // End Read

            public static List<BoletosEspecialesAeropuerto> Read(params KeyValuePair<string, object>[] args)
            {
                DataTable dt = DB.Read("BoletosEspecialesAeropuerto", args);
                List<BoletosEspecialesAeropuerto> list = new List<BoletosEspecialesAeropuerto>();                
                foreach (DataRow dr in dt.Rows)
                {
                    list.Add(new BoletosEspecialesAeropuerto(Convert.ToString(dr["Codigo"]), DB.GetNullableInt32(dr["Tipo"]), DB.GetNullableInt32(dr["FolioDiario"]), DB.GetNullableDecimal(dr["Precio"]), DB.GetNullableDateTime(dr["Fecha"]), DB.GetNullableInt32(dr["Status"]), Convert.ToString(dr["Usuario"]), DB.GetNullableInt32(dr["TipoPago"])));
                }

                return list;
            } // End Read

            public static bool Read(out BoletosEspecialesAeropuerto boletosespecialesaeropuerto, int top, string filter, string sort, params KeyValuePair<string, object>[] args)
            {
                DataTable dt = DB.Read("BoletosEspecialesAeropuerto", top, filter, sort, args);
                if (dt.Rows.Count == 0)
                {
                    boletosespecialesaeropuerto = null;
                    return false;
                }
                DataRow dr = dt.Rows[0];
                boletosespecialesaeropuerto = new BoletosEspecialesAeropuerto(Convert.ToString(dr["Codigo"]), DB.GetNullableInt32(dr["Tipo"]), DB.GetNullableInt32(dr["FolioDiario"]), DB.GetNullableDecimal(dr["Precio"]), DB.GetNullableDateTime(dr["Fecha"]), DB.GetNullableInt32(dr["Status"]), 
                    Convert.ToString(dr["Usuario"]), DB.GetNullableInt32(dr["TipoPago"]));
                return true;
            } // End Read

            public static DataTable ReadDataTable()
            {
                return DB.Select("BoletosEspecialesAeropuerto");
            } // End Read

            public static DataTable ReadDataTable(string codigo)
            {
                Hashtable w_params = new Hashtable();
                w_params.Add("Codigo", codigo);
                return DB.Select("BoletosEspecialesAeropuerto", w_params);
            } // End Read

            public int Update()
            {
                Hashtable m_params = new Hashtable();
                Hashtable w_params = new Hashtable();
                w_params.Add("Codigo", this.Codigo);
                if (!AppHelper.IsNullOrEmpty(this.Tipo)) m_params.Add("Tipo", this.Tipo);
                if (!AppHelper.IsNullOrEmpty(this.FolioDiario)) m_params.Add("FolioDiario", this.FolioDiario);
                if (!AppHelper.IsNullOrEmpty(this.Precio)) m_params.Add("Precio", this.Precio);
                if (!AppHelper.IsNullOrEmpty(this.Fecha)) m_params.Add("Fecha", this.Fecha);
                if (!AppHelper.IsNullOrEmpty(this.Status)) m_params.Add("Status", this.Status);
                if (!AppHelper.IsNullOrEmpty(this.Usuario)) m_params.Add("Usuario", this.Usuario);
                if (!AppHelper.IsNullOrEmpty(this.TipoPago)) m_params.Add("TipoPago", this.TipoPago);

                return DB.UpdateRow("BoletosEspecialesAeropuerto", m_params, w_params);
            } // End Update

            public int Delete()
            {
                Hashtable w_params = new Hashtable();
                w_params.Add("Codigo", this.Codigo);

                return DB.DeleteRow("BoletosEspecialesAeropuerto", w_params);
            } // End Delete

        } //End Class BoletosEspecialesAeropuerto

        public class BoletosRegresos
        {

            public BoletosRegresos()
            {
            }

            public BoletosRegresos(string boleto, int conductor, int unidad, decimal precio, decimal porcentajeactual, decimal comision, string usuario, DateTime fecha)
            {
                this.Boleto = boleto;
                this.Conductor = conductor;
                this.Unidad = unidad;
                this.Precio = precio;
                this.PorcentajeActual = porcentajeactual;
                this.Comision = comision;
                this.Usuario = usuario;
                this.Fecha = fecha;
            }

            private string _Boleto;
            public string Boleto
            {
                get { return _Boleto; }
                set { _Boleto = value; }
            }

            private int _Conductor;
            public int Conductor
            {
                get { return _Conductor; }
                set { _Conductor = value; }
            }

            private int _Unidad;
            public int Unidad
            {
                get { return _Unidad; }
                set { _Unidad = value; }
            }

            private decimal _Precio;
            public decimal Precio
            {
                get { return _Precio; }
                set { _Precio = value; }
            }

            private decimal _PorcentajeActual;
            public decimal PorcentajeActual
            {
                get { return _PorcentajeActual; }
                set { _PorcentajeActual = value; }
            }

            private decimal _Comision;
            public decimal Comision
            {
                get { return _Comision; }
                set { _Comision = value; }
            }

            private string _Usuario;
            public string Usuario
            {
                get { return _Usuario; }
                set { _Usuario = value; }
            }

            private DateTime _Fecha;
            public DateTime Fecha
            {
                get { return _Fecha; }
                set { _Fecha = value; }
            }

            public int Create()
            {
                Hashtable m_params = new Hashtable();
                m_params.Add("Boleto", this.Boleto);
                m_params.Add("Conductor", this.Conductor);
                m_params.Add("Unidad", this.Unidad);
                m_params.Add("Precio", this.Precio);
                m_params.Add("PorcentajeActual", this.PorcentajeActual);
                m_params.Add("Comision", this.Comision);
                m_params.Add("Usuario", this.Usuario);
                m_params.Add("Fecha", this.Fecha);

                return DB.InsertRow("BoletosRegresos", m_params);
            } // End Create

            public static List<BoletosRegresos> Read()
            {
                List<BoletosRegresos> list = new List<BoletosRegresos>();
                DataTable dt = DB.Select("BoletosRegresos");
                foreach (DataRow dr in dt.Rows)
                {
                    list.Add(new BoletosRegresos(Convert.ToString(dr["Boleto"]), Convert.ToInt32(dr["Conductor"]), Convert.ToInt32(dr["Unidad"]), Convert.ToDecimal(dr["Precio"]), Convert.ToDecimal(dr["PorcentajeActual"]), Convert.ToDecimal(dr["Comision"]), Convert.ToString(dr["Usuario"]), Convert.ToDateTime(dr["Fecha"])));
                }

                return list;
            } // End Read

            public static BoletosRegresos Read(string boleto)
            {
                Hashtable w_params = new Hashtable();
                w_params.Add("Boleto", boleto);
                DataTable dt = DB.Select("BoletosRegresos", w_params);
                if (dt.Rows.Count == 0)
                {
                    return null;
                }
                DataRow dr = dt.Rows[0];
                return new BoletosRegresos(Convert.ToString(dr["Boleto"]), Convert.ToInt32(dr["Conductor"]), Convert.ToInt32(dr["Unidad"]), Convert.ToDecimal(dr["Precio"]), Convert.ToDecimal(dr["PorcentajeActual"]), Convert.ToDecimal(dr["Comision"]), Convert.ToString(dr["Usuario"]), Convert.ToDateTime(dr["Fecha"]));
            } // End Read

            public int Update()
            {
                Hashtable m_params = new Hashtable();
                Hashtable w_params = new Hashtable();
                w_params.Add("Boleto", this.Boleto);
                m_params.Add("Conductor", this.Conductor);
                m_params.Add("Unidad", this.Unidad);
                m_params.Add("Precio", this.Precio);
                m_params.Add("PorcentajeActual", this.PorcentajeActual);
                m_params.Add("Comision", this.Comision);
                m_params.Add("Usuario", this.Usuario);
                m_params.Add("Fecha", this.Fecha);

                return DB.UpdateRow("BoletosRegresos", m_params, w_params);
            } // End Update

            public int Delete()
            {
                Hashtable w_params = new Hashtable();
                w_params.Add("Boleto", this.Boleto);

                return DB.DeleteRow("BoletosRegresos", w_params);
            } // End Delete

        } //End Class BoletosRegresos

        public class CajaAhorro
        {

            public CajaAhorro()
            {
            }

            public CajaAhorro(int folio, int conductor, int unidad, decimal monto, DateTime fecha, int? recibo)
            {
                this.Folio = folio;
                this.Conductor = conductor;
                this.Unidad = unidad;
                this.Monto = monto;
                this.Fecha = fecha;
                this.Recibo = recibo;
            }

            private int _Folio;
            public int Folio
            {
                get { return _Folio; }
                set { _Folio = value; }
            }

            private int _Conductor;
            public int Conductor
            {
                get { return _Conductor; }
                set { _Conductor = value; }
            }

            private int _Unidad;
            public int Unidad
            {
                get { return _Unidad; }
                set { _Unidad = value; }
            }

            private decimal _Monto;
            public decimal Monto
            {
                get { return _Monto; }
                set { _Monto = value; }
            }

            private DateTime _Fecha;
            public DateTime Fecha
            {
                get { return _Fecha; }
                set { _Fecha = value; }
            }

            private int? _Recibo;
            public int? Recibo
            {
                get { return _Recibo; }
                set { _Recibo = value; }
            }

            public int Create()
            {
                Hashtable m_params = new Hashtable();
                m_params.Add("Folio", this.Folio);
                m_params.Add("Conductor", this.Conductor);
                m_params.Add("Unidad", this.Unidad);
                m_params.Add("Monto", this.Monto);
                m_params.Add("Fecha", this.Fecha);
                if (!AppHelper.IsNullOrEmpty(this.Recibo)) m_params.Add("Recibo", this.Recibo);

                return DB.InsertRow("CajaAhorro", m_params);
            } // End Create

            public static List<CajaAhorro> Read()
            {
                List<CajaAhorro> list = new List<CajaAhorro>();
                DataTable dt = DB.Select("CajaAhorro");
                foreach (DataRow dr in dt.Rows)
                {
                    list.Add(new CajaAhorro(Convert.ToInt32(dr["Folio"]), Convert.ToInt32(dr["Conductor"]), Convert.ToInt32(dr["Unidad"]), Convert.ToDecimal(dr["Monto"]), Convert.ToDateTime(dr["Fecha"]), DB.GetNullableInt32(dr["Recibo"])));
                }

                return list;
            } // End Read

            public int Update()
            {
                Hashtable m_params = new Hashtable();
                Hashtable w_params = new Hashtable();
                m_params.Add("Folio", this.Folio);
                m_params.Add("Conductor", this.Conductor);
                m_params.Add("Unidad", this.Unidad);
                m_params.Add("Monto", this.Monto);
                m_params.Add("Fecha", this.Fecha);
                if (!AppHelper.IsNullOrEmpty(this.Recibo)) m_params.Add("Recibo", this.Recibo);

                return DB.UpdateRow("CajaAhorro", m_params, w_params);
            } // End Update

            public int Delete()
            {
                Hashtable w_params = new Hashtable();

                return DB.DeleteRow("CajaAhorro", w_params);
            } // End Delete

        } //End Class CajaAhorro

        public class Cajas
        {

            public Cajas()
            {
            }

            public Cajas(int folio, string descripcion)
            {
                this.Folio = folio;
                this.Descripcion = descripcion;
            }

            private int _Folio;
            public int Folio
            {
                get { return _Folio; }
                set { _Folio = value; }
            }

            private string _Descripcion;
            public string Descripcion
            {
                get { return _Descripcion; }
                set { _Descripcion = value; }
            }

            public int Create()
            {
                Hashtable m_params = new Hashtable();
                if (!AppHelper.IsNullOrEmpty(this.Descripcion)) m_params.Add("Descripcion", this.Descripcion);

                return DB.InsertRow("Cajas", m_params);
            } // End Create

            public static List<Cajas> Read()
            {
                List<Cajas> list = new List<Cajas>();
                DataTable dt = DB.Select("Cajas");
                foreach (DataRow dr in dt.Rows)
                {
                    list.Add(new Cajas(Convert.ToInt32(dr["Folio"]), Convert.ToString(dr["Descripcion"])));
                }

                return list;
            } // End Read

            public static Cajas Read(int folio)
            {
                Hashtable w_params = new Hashtable();
                w_params.Add("Folio", folio);
                DataTable dt = DB.Select("Cajas", w_params);
                if (dt.Rows.Count == 0)
                {
                    throw new Exception("No existe Cajas con los criterios de búsqueda especificados.");
                }
                DataRow dr = dt.Rows[0];
                return new Cajas(Convert.ToInt32(dr["Folio"]), Convert.ToString(dr["Descripcion"]));
            } // End Read

            public int Update()
            {
                Hashtable m_params = new Hashtable();
                Hashtable w_params = new Hashtable();
                w_params.Add("Folio", this.Folio);
                if (!AppHelper.IsNullOrEmpty(this.Descripcion)) m_params.Add("Descripcion", this.Descripcion);

                return DB.UpdateRow("Cajas", m_params, w_params);
            } // End Update

            public int Delete()
            {
                Hashtable w_params = new Hashtable();
                w_params.Add("Folio", this.Folio);

                return DB.DeleteRow("Cajas", w_params);
            } // End Delete

        } //End Class Cajas

        public class CancelacionBoletosEpson
        {

            public CancelacionBoletosEpson()
            {
            }

            public CancelacionBoletosEpson(string boleto, string motivo, int? conductor, int? unidad, DateTime fecha, string usuario, bool carrera)
            {
                this.Boleto = boleto;
                this.Motivo = motivo;
                this.Conductor = conductor;
                this.Unidad = unidad;
                this.Fecha = fecha;
                this.Usuario = usuario;
                this.Carrera = carrera;
            }

            private string _Boleto;
            public string Boleto
            {
                get { return _Boleto; }
                set { _Boleto = value; }
            }

            private string _Motivo;
            public string Motivo
            {
                get { return _Motivo; }
                set { _Motivo = value; }
            }

            private int? _Conductor;
            public int? Conductor
            {
                get { return _Conductor; }
                set { _Conductor = value; }
            }

            private int? _Unidad;
            public int? Unidad
            {
                get { return _Unidad; }
                set { _Unidad = value; }
            }

            private DateTime _Fecha;
            public DateTime Fecha
            {
                get { return _Fecha; }
                set { _Fecha = value; }
            }

            private string _Usuario;
            public string Usuario
            {
                get { return _Usuario; }
                set { _Usuario = value; }
            }

            private bool _Carrera;
            public bool Carrera
            {
                get { return _Carrera; }
                set { _Carrera = value; }
            }

            public int Create()
            {
                Hashtable m_params = new Hashtable();
                m_params.Add("Boleto", this.Boleto);
                m_params.Add("Motivo", this.Motivo);
                if (!AppHelper.IsNullOrEmpty(this.Conductor)) m_params.Add("Conductor", this.Conductor);
                if (!AppHelper.IsNullOrEmpty(this.Unidad)) m_params.Add("Unidad", this.Unidad);
                m_params.Add("Fecha", this.Fecha);
                m_params.Add("Usuario", this.Usuario);
                m_params.Add("Carrera", this.Carrera);

                return DB.InsertRow("CancelacionBoletosEpson", m_params);
            } // End Create

            public static List<CancelacionBoletosEpson> Read()
            {
                List<CancelacionBoletosEpson> list = new List<CancelacionBoletosEpson>();
                DataTable dt = DB.Select("CancelacionBoletosEpson");
                foreach (DataRow dr in dt.Rows)
                {
                    list.Add(new CancelacionBoletosEpson(Convert.ToString(dr["Boleto"]), Convert.ToString(dr["Motivo"]), DB.GetNullableInt32(dr["Conductor"]), DB.GetNullableInt32(dr["Unidad"]), Convert.ToDateTime(dr["Fecha"]), Convert.ToString(dr["Usuario"]), Convert.ToBoolean(dr["Carrera"])));
                }

                return list;
            } // End Read

            public int Update()
            {
                Hashtable m_params = new Hashtable();
                Hashtable w_params = new Hashtable();
                m_params.Add("Boleto", this.Boleto);
                m_params.Add("Motivo", this.Motivo);
                if (!AppHelper.IsNullOrEmpty(this.Conductor)) m_params.Add("Conductor", this.Conductor);
                if (!AppHelper.IsNullOrEmpty(this.Unidad)) m_params.Add("Unidad", this.Unidad);
                m_params.Add("Fecha", this.Fecha);
                m_params.Add("Usuario", this.Usuario);
                m_params.Add("Carrera", this.Carrera);

                return DB.UpdateRow("CancelacionBoletosEpson", m_params, w_params);
            } // End Update

            public int Delete()
            {
                Hashtable w_params = new Hashtable();

                return DB.DeleteRow("CancelacionBoletosEpson", w_params);
            } // End Delete

        } //End Class CancelacionBoletosEpson

        public class CANCELBOL24SEP09
        {

            public CANCELBOL24SEP09()
            {
            }

            public CANCELBOL24SEP09(string codigo)
            {
                this.CODIGO = codigo;
            }

            private string _CODIGO;
            public string CODIGO
            {
                get { return _CODIGO; }
                set { _CODIGO = value; }
            }

            public int Create()
            {
                Hashtable m_params = new Hashtable();
                if (!AppHelper.IsNullOrEmpty(this.CODIGO)) m_params.Add("CODIGO", this.CODIGO);

                return DB.InsertRow("CANCELBOL24SEP09", m_params);
            } // End Create

            public static List<CANCELBOL24SEP09> Read()
            {
                List<CANCELBOL24SEP09> list = new List<CANCELBOL24SEP09>();
                DataTable dt = DB.Select("CANCELBOL24SEP09");
                foreach (DataRow dr in dt.Rows)
                {
                    list.Add(new CANCELBOL24SEP09(Convert.ToString(dr["CODIGO"])));
                }

                return list;
            } // End Read

            public int Update()
            {
                Hashtable m_params = new Hashtable();
                Hashtable w_params = new Hashtable();
                if (!AppHelper.IsNullOrEmpty(this.CODIGO)) m_params.Add("CODIGO", this.CODIGO);

                return DB.UpdateRow("CANCELBOL24SEP09", m_params, w_params);
            } // End Update

            public int Delete()
            {
                Hashtable w_params = new Hashtable();

                return DB.DeleteRow("CANCELBOL24SEP09", w_params);
            } // End Delete

        } //End Class CANCELBOL24SEP09

        public class CarrerasAeropuerto
        {

            public CarrerasAeropuerto()
            {
            }

            public CarrerasAeropuerto(string boleto, int conductor, int unidad, DateTime? fechacarreraebssa, DateTime? fechacarreralocal, bool compartida)
            {
                this.Boleto = boleto;
                this.Conductor = conductor;
                this.Unidad = unidad;
                this.FechaCarreraEbssa = fechacarreraebssa;
                this.FechaCarreraLocal = fechacarreralocal;
                this.Compartida = compartida;
            }

            private string _Boleto;
            public string Boleto
            {
                get { return _Boleto; }
                set { _Boleto = value; }
            }

            private int _Conductor;
            public int Conductor
            {
                get { return _Conductor; }
                set { _Conductor = value; }
            }

            private int _Unidad;
            public int Unidad
            {
                get { return _Unidad; }
                set { _Unidad = value; }
            }

            private DateTime? _FechaCarreraEbssa;
            public DateTime? FechaCarreraEbssa
            {
                get { return _FechaCarreraEbssa; }
                set { _FechaCarreraEbssa = value; }
            }

            private DateTime? _FechaCarreraLocal;
            public DateTime? FechaCarreraLocal
            {
                get { return _FechaCarreraLocal; }
                set { _FechaCarreraLocal = value; }
            }

            private bool _Compartida;
            public bool Compartida
            {
                get { return _Compartida; }
                set { _Compartida = value; }
            }

            public int Create()
            {
                Hashtable m_params = new Hashtable();
                m_params.Add("Boleto", this.Boleto);
                m_params.Add("Conductor", this.Conductor);
                m_params.Add("Unidad", this.Unidad);
                if (!AppHelper.IsNullOrEmpty(this.FechaCarreraEbssa)) m_params.Add("FechaCarreraEbssa", this.FechaCarreraEbssa);
                if (!AppHelper.IsNullOrEmpty(this.FechaCarreraLocal)) m_params.Add("FechaCarreraLocal", this.FechaCarreraLocal);
                m_params.Add("Compartida", this.Compartida);

                return DB.InsertRow("CarrerasAeropuerto", m_params);
            } // End Create

            public static List<CarrerasAeropuerto> Read()
            {
                List<CarrerasAeropuerto> list = new List<CarrerasAeropuerto>();
                DataTable dt = DB.Select("CarrerasAeropuerto");
                foreach (DataRow dr in dt.Rows)
                {
                    list.Add(new CarrerasAeropuerto(Convert.ToString(dr["Boleto"]), Convert.ToInt32(dr["Conductor"]), Convert.ToInt32(dr["Unidad"]), DB.GetNullableDateTime(dr["FechaCarreraEbssa"]), DB.GetNullableDateTime(dr["FechaCarreraLocal"]), Convert.ToBoolean(dr["Compartida"])));
                }

                return list;
            } // End Read

            public static List<CarrerasAeropuerto> Read(string filter, string sort, params KeyValuePair<string,object>[] args)
            {
                List<CarrerasAeropuerto> list = new List<CarrerasAeropuerto>();
                DataTable dt = DB.Read("CarrerasAeropuerto", filter, sort, args);
                foreach (DataRow dr in dt.Rows)
                {
                    list.Add(new CarrerasAeropuerto(Convert.ToString(dr["Boleto"]), Convert.ToInt32(dr["Conductor"]), Convert.ToInt32(dr["Unidad"]), DB.GetNullableDateTime(dr["FechaCarreraEbssa"]), DB.GetNullableDateTime(dr["FechaCarreraLocal"]), Convert.ToBoolean(dr["Compartida"])));
                }

                return list;
            } // End Read

            public static CarrerasAeropuerto Read(string boleto)
            {                
                DataTable dt = DB.Read("CarrerasAeropuerto", DB.Param("Boleto",boleto));

                if (dt.Rows.Count > 0)
                {
                    DataRow dr = dt.Rows[0];
                    return new CarrerasAeropuerto(Convert.ToString(dr["Boleto"]), Convert.ToInt32(dr["Conductor"]), Convert.ToInt32(dr["Unidad"]), 
                        DB.GetNullableDateTime(dr["FechaCarreraEbssa"]), DB.GetNullableDateTime(dr["FechaCarreraLocal"]), 
                            Convert.ToBoolean(dr["Compartida"]));
                }

                return null;
            } // End Read

            public int Update()
            {
                Hashtable m_params = new Hashtable();
                Hashtable w_params = new Hashtable();
                m_params.Add("Boleto", this.Boleto);
                m_params.Add("Conductor", this.Conductor);
                m_params.Add("Unidad", this.Unidad);
                if (!AppHelper.IsNullOrEmpty(this.FechaCarreraEbssa)) m_params.Add("FechaCarreraEbssa", this.FechaCarreraEbssa);
                if (!AppHelper.IsNullOrEmpty(this.FechaCarreraLocal)) m_params.Add("FechaCarreraLocal", this.FechaCarreraLocal);
                m_params.Add("Compartida", this.Compartida);

                return DB.UpdateRow("CarrerasAeropuerto", m_params, w_params);
            } // End Update

            public int Delete()
            {
                Hashtable w_params = new Hashtable();

                return DB.DeleteRow("CarrerasAeropuerto", w_params);
            } // End Delete

        } //End Class CarrerasAeropuerto

        public class CarrerasAeropuerto2007
        {

            public CarrerasAeropuerto2007()
            {
            }

            public CarrerasAeropuerto2007(string boleto, int conductor, int unidad, DateTime? fechacarreraebssa, DateTime? fechacarreralocal, bool compartida)
            {
                this.Boleto = boleto;
                this.Conductor = conductor;
                this.Unidad = unidad;
                this.FechaCarreraEbssa = fechacarreraebssa;
                this.FechaCarreraLocal = fechacarreralocal;
                this.Compartida = compartida;
            }

            private string _Boleto;
            public string Boleto
            {
                get { return _Boleto; }
                set { _Boleto = value; }
            }

            private int _Conductor;
            public int Conductor
            {
                get { return _Conductor; }
                set { _Conductor = value; }
            }

            private int _Unidad;
            public int Unidad
            {
                get { return _Unidad; }
                set { _Unidad = value; }
            }

            private DateTime? _FechaCarreraEbssa;
            public DateTime? FechaCarreraEbssa
            {
                get { return _FechaCarreraEbssa; }
                set { _FechaCarreraEbssa = value; }
            }

            private DateTime? _FechaCarreraLocal;
            public DateTime? FechaCarreraLocal
            {
                get { return _FechaCarreraLocal; }
                set { _FechaCarreraLocal = value; }
            }

            private bool _Compartida;
            public bool Compartida
            {
                get { return _Compartida; }
                set { _Compartida = value; }
            }

            public int Create()
            {
                Hashtable m_params = new Hashtable();
                m_params.Add("Boleto", this.Boleto);
                m_params.Add("Conductor", this.Conductor);
                m_params.Add("Unidad", this.Unidad);
                if (!AppHelper.IsNullOrEmpty(this.FechaCarreraEbssa)) m_params.Add("FechaCarreraEbssa", this.FechaCarreraEbssa);
                if (!AppHelper.IsNullOrEmpty(this.FechaCarreraLocal)) m_params.Add("FechaCarreraLocal", this.FechaCarreraLocal);
                m_params.Add("Compartida", this.Compartida);

                return DB.InsertRow("CarrerasAeropuerto2007", m_params);
            } // End Create

            public static List<CarrerasAeropuerto2007> Read()
            {
                List<CarrerasAeropuerto2007> list = new List<CarrerasAeropuerto2007>();
                DataTable dt = DB.Select("CarrerasAeropuerto2007");
                foreach (DataRow dr in dt.Rows)
                {
                    list.Add(new CarrerasAeropuerto2007(Convert.ToString(dr["Boleto"]), Convert.ToInt32(dr["Conductor"]), Convert.ToInt32(dr["Unidad"]), DB.GetNullableDateTime(dr["FechaCarreraEbssa"]), DB.GetNullableDateTime(dr["FechaCarreraLocal"]), Convert.ToBoolean(dr["Compartida"])));
                }

                return list;
            } // End Read

            public int Update()
            {
                Hashtable m_params = new Hashtable();
                Hashtable w_params = new Hashtable();
                m_params.Add("Boleto", this.Boleto);
                m_params.Add("Conductor", this.Conductor);
                m_params.Add("Unidad", this.Unidad);
                if (!AppHelper.IsNullOrEmpty(this.FechaCarreraEbssa)) m_params.Add("FechaCarreraEbssa", this.FechaCarreraEbssa);
                if (!AppHelper.IsNullOrEmpty(this.FechaCarreraLocal)) m_params.Add("FechaCarreraLocal", this.FechaCarreraLocal);
                m_params.Add("Compartida", this.Compartida);

                return DB.UpdateRow("CarrerasAeropuerto2007", m_params, w_params);
            } // End Update

            public int Delete()
            {
                Hashtable w_params = new Hashtable();

                return DB.DeleteRow("CarrerasAeropuerto2007", w_params);
            } // End Delete

        } //End Class CarrerasAeropuerto2007

        public class CategoriasProductividad
        {

            public CategoriasProductividad()
            {
            }

            public CategoriasProductividad(int folio, string descripcion)
            {
                this.Folio = folio;
                this.Descripcion = descripcion;
            }

            private int _Folio;
            public int Folio
            {
                get { return _Folio; }
                set { _Folio = value; }
            }

            private string _Descripcion;
            public string Descripcion
            {
                get { return _Descripcion; }
                set { _Descripcion = value; }
            }

            public int Create()
            {
                Hashtable m_params = new Hashtable();
                m_params.Add("Descripcion", this.Descripcion);

                return DB.InsertRow("CategoriasProductividad", m_params);
            } // End Create

            public static List<CategoriasProductividad> Read()
            {
                List<CategoriasProductividad> list = new List<CategoriasProductividad>();
                DataTable dt = DB.Select("CategoriasProductividad");
                foreach (DataRow dr in dt.Rows)
                {
                    list.Add(new CategoriasProductividad(Convert.ToInt32(dr["Folio"]), Convert.ToString(dr["Descripcion"])));
                }

                return list;
            } // End Read

            public static CategoriasProductividad Read(int folio)
            {
                Hashtable w_params = new Hashtable();
                w_params.Add("Folio", folio);
                DataTable dt = DB.Select("CategoriasProductividad", w_params);
                if (dt.Rows.Count == 0)
                {
                    throw new Exception("No existe CategoriasProductividad con los criterios de búsqueda especificados.");
                }
                DataRow dr = dt.Rows[0];
                return new CategoriasProductividad(Convert.ToInt32(dr["Folio"]), Convert.ToString(dr["Descripcion"]));
            } // End Read

            public int Update()
            {
                Hashtable m_params = new Hashtable();
                Hashtable w_params = new Hashtable();
                w_params.Add("Folio", this.Folio);
                m_params.Add("Descripcion", this.Descripcion);

                return DB.UpdateRow("CategoriasProductividad", m_params, w_params);
            } // End Update

            public int Delete()
            {
                Hashtable w_params = new Hashtable();
                w_params.Add("Folio", this.Folio);

                return DB.DeleteRow("CategoriasProductividad", w_params);
            } // End Delete

        } //End Class CategoriasProductividad

        public class CategoriasProductividadConductores
        {

            public CategoriasProductividadConductores()
            {
            }

            public CategoriasProductividadConductores(int categoria, int conductor)
            {
                this.Categoria = categoria;
                this.Categoria = categoria;
                this.Conductor = conductor;
                this.Conductor = conductor;
            }

            private int _Categoria;
            public int Categoria
            {
                get { return _Categoria; }
                set { _Categoria = value; }
            }

            private int _Conductor;
            public int Conductor
            {
                get { return _Conductor; }
                set { _Conductor = value; }
            }

            public int Create()
            {
                Hashtable m_params = new Hashtable();
                m_params.Add("Categoria", this.Categoria);
                m_params.Add("Categoria", this.Categoria);
                m_params.Add("Conductor", this.Conductor);
                m_params.Add("Conductor", this.Conductor);

                return DB.InsertRow("CategoriasProductividadConductores", m_params);
            } // End Create

            public static List<CategoriasProductividadConductores> Read()
            {
                List<CategoriasProductividadConductores> list = new List<CategoriasProductividadConductores>();
                DataTable dt = DB.Select("CategoriasProductividadConductores");
                foreach (DataRow dr in dt.Rows)
                {
                    list.Add(new CategoriasProductividadConductores(Convert.ToInt32(dr["Categoria"]), Convert.ToInt32(dr["Conductor"])));
                }

                return list;
            } // End Read

            public static CategoriasProductividadConductores Read(int categoria, int conductor)
            {
                Hashtable w_params = new Hashtable();
                w_params.Add("Categoria", categoria);
                w_params.Add("Conductor", conductor);
                DataTable dt = DB.Select("CategoriasProductividadConductores", w_params);
                if (dt.Rows.Count == 0)
                {
                    throw new Exception("No existe CategoriasProductividadConductores con los criterios de búsqueda especificados.");
                }
                DataRow dr = dt.Rows[0];
                return new CategoriasProductividadConductores(Convert.ToInt32(dr["Categoria"]), Convert.ToInt32(dr["Conductor"]));
            } // End Read

            public int Update()
            {
                Hashtable m_params = new Hashtable();
                Hashtable w_params = new Hashtable();
                m_params.Add("Categoria", this.Categoria);
                w_params.Add("Categoria", this.Categoria);
                m_params.Add("Conductor", this.Conductor);
                w_params.Add("Conductor", this.Conductor);

                return DB.UpdateRow("CategoriasProductividadConductores", m_params, w_params);
            } // End Update

            public int Delete()
            {
                Hashtable w_params = new Hashtable();
                w_params.Add("Categoria", this.Categoria);
                w_params.Add("Conductor", this.Conductor);

                return DB.DeleteRow("CategoriasProductividadConductores", w_params);
            } // End Delete

        } //End Class CategoriasProductividadConductores

        public class ClasesServicios
        {

            public ClasesServicios()
            {
            }

            public ClasesServicios(int folio, string descripcion)
            {
                this.Folio = folio;
                this.Descripcion = descripcion;
            }

            private int _Folio;
            public int Folio
            {
                get { return _Folio; }
                set { _Folio = value; }
            }

            private string _Descripcion;
            public string Descripcion
            {
                get { return _Descripcion; }
                set { _Descripcion = value; }
            }

            public int Create()
            {
                Hashtable m_params = new Hashtable();
                m_params.Add("Descripcion", this.Descripcion);

                return DB.InsertRow("ClasesServicios", m_params);
            } // End Create

            public static List<ClasesServicios> Read()
            {
                List<ClasesServicios> list = new List<ClasesServicios>();
                DataTable dt = DB.Select("ClasesServicios");
                foreach (DataRow dr in dt.Rows)
                {
                    list.Add(new ClasesServicios(Convert.ToInt32(dr["Folio"]), Convert.ToString(dr["Descripcion"])));
                }

                return list;
            } // End Read

            public static ClasesServicios Read(int folio)
            {
                Hashtable w_params = new Hashtable();
                w_params.Add("Folio", folio);
                DataTable dt = DB.Select("ClasesServicios", w_params);
                if (dt.Rows.Count == 0)
                {
                    throw new Exception("No existe ClasesServicios con los criterios de búsqueda especificados.");
                }
                DataRow dr = dt.Rows[0];
                return new ClasesServicios(Convert.ToInt32(dr["Folio"]), Convert.ToString(dr["Descripcion"]));
            } // End Read

            public int Update()
            {
                Hashtable m_params = new Hashtable();
                Hashtable w_params = new Hashtable();
                w_params.Add("Folio", this.Folio);
                m_params.Add("Descripcion", this.Descripcion);

                return DB.UpdateRow("ClasesServicios", m_params, w_params);
            } // End Update

            public int Delete()
            {
                Hashtable w_params = new Hashtable();
                w_params.Add("Folio", this.Folio);

                return DB.DeleteRow("ClasesServicios", w_params);
            } // End Delete

        } //End Class ClasesServicios

        public class ClaseVehiculo
        {

            public ClaseVehiculo()
            {
            }

            public ClaseVehiculo(int folio, string descripcion)
            {
                this.Folio = folio;
                this.Descripcion = descripcion;
            }

            private int _Folio;
            public int Folio
            {
                get { return _Folio; }
                set { _Folio = value; }
            }

            private string _Descripcion;
            public string Descripcion
            {
                get { return _Descripcion; }
                set { _Descripcion = value; }
            }

            public int Create()
            {
                Hashtable m_params = new Hashtable();
                m_params.Add("Descripcion", this.Descripcion);

                return DB.InsertRow("ClaseVehiculo", m_params);
            } // End Create

            public static List<ClaseVehiculo> Read()
            {
                List<ClaseVehiculo> list = new List<ClaseVehiculo>();
                DataTable dt = DB.Select("ClaseVehiculo");
                foreach (DataRow dr in dt.Rows)
                {
                    list.Add(new ClaseVehiculo(Convert.ToInt32(dr["Folio"]), Convert.ToString(dr["Descripcion"])));
                }

                return list;
            } // End Read

            public static ClaseVehiculo Read(int folio)
            {
                Hashtable w_params = new Hashtable();
                w_params.Add("Folio", folio);
                DataTable dt = DB.Select("ClaseVehiculo", w_params);
                if (dt.Rows.Count == 0)
                {
                    throw new Exception("No existe ClaseVehiculo con los criterios de búsqueda especificados.");
                }
                DataRow dr = dt.Rows[0];
                return new ClaseVehiculo(Convert.ToInt32(dr["Folio"]), Convert.ToString(dr["Descripcion"]));
            } // End Read

            public int Update()
            {
                Hashtable m_params = new Hashtable();
                Hashtable w_params = new Hashtable();
                w_params.Add("Folio", this.Folio);
                m_params.Add("Descripcion", this.Descripcion);

                return DB.UpdateRow("ClaseVehiculo", m_params, w_params);
            } // End Update

            public int Delete()
            {
                Hashtable w_params = new Hashtable();
                w_params.Add("Folio", this.Folio);

                return DB.DeleteRow("ClaseVehiculo", w_params);
            } // End Delete

        } //End Class ClaseVehiculo

        public class Claves_OXXOGas
        {

            public Claves_OXXOGas()
            {
            }

            public Claves_OXXOGas(string idcomercio, string usuario, string pwd, string codigocliente)
            {
                this.IDComercio = idcomercio;
                this.Usuario = usuario;
                this.Pwd = pwd;
                this.CodigoCliente = codigocliente;
            }

            private string _IDComercio;
            public string IDComercio
            {
                get { return _IDComercio; }
                set { _IDComercio = value; }
            }

            private string _Usuario;
            public string Usuario
            {
                get { return _Usuario; }
                set { _Usuario = value; }
            }

            private string _Pwd;
            public string Pwd
            {
                get { return _Pwd; }
                set { _Pwd = value; }
            }

            private string _CodigoCliente;
            public string CodigoCliente
            {
                get { return _CodigoCliente; }
                set { _CodigoCliente = value; }
            }

            public int Create()
            {
                Hashtable m_params = new Hashtable();
                m_params.Add("IDComercio", this.IDComercio);
                m_params.Add("Usuario", this.Usuario);
                m_params.Add("Pwd", this.Pwd);
                m_params.Add("CodigoCliente", this.CodigoCliente);

                return DB.InsertRow("Claves_OXXOGas", m_params);
            } // End Create

            public static List<Claves_OXXOGas> Read()
            {
                List<Claves_OXXOGas> list = new List<Claves_OXXOGas>();
                DataTable dt = DB.Select("Claves_OXXOGas");
                foreach (DataRow dr in dt.Rows)
                {
                    list.Add(new Claves_OXXOGas(Convert.ToString(dr["IDComercio"]), Convert.ToString(dr["Usuario"]), Convert.ToString(dr["Pwd"]), Convert.ToString(dr["CodigoCliente"])));
                }

                return list;
            } // End Read

            public int Update()
            {
                Hashtable m_params = new Hashtable();
                Hashtable w_params = new Hashtable();
                m_params.Add("IDComercio", this.IDComercio);
                m_params.Add("Usuario", this.Usuario);
                m_params.Add("Pwd", this.Pwd);
                m_params.Add("CodigoCliente", this.CodigoCliente);

                return DB.UpdateRow("Claves_OXXOGas", m_params, w_params);
            } // End Update

            public int Delete()
            {
                Hashtable w_params = new Hashtable();

                return DB.DeleteRow("Claves_OXXOGas", w_params);
            } // End Delete

        } //End Class Claves_OXXOGas

        public class ClavesControlConductores
        {

            public ClavesControlConductores()
            {
            }

            public ClavesControlConductores(int folio, string descripcion)
            {
                this.Folio = folio;
                this.Descripcion = descripcion;
            }

            private int _Folio;
            public int Folio
            {
                get { return _Folio; }
                set { _Folio = value; }
            }

            private string _Descripcion;
            public string Descripcion
            {
                get { return _Descripcion; }
                set { _Descripcion = value; }
            }

            public int Create()
            {
                Hashtable m_params = new Hashtable();
                m_params.Add("Descripcion", this.Descripcion);

                return DB.InsertRow("ClavesControlConductores", m_params);
            } // End Create

            public static List<ClavesControlConductores> Read()
            {
                List<ClavesControlConductores> list = new List<ClavesControlConductores>();
                DataTable dt = DB.Select("ClavesControlConductores");
                foreach (DataRow dr in dt.Rows)
                {
                    list.Add(new ClavesControlConductores(Convert.ToInt32(dr["Folio"]), Convert.ToString(dr["Descripcion"])));
                }

                return list;
            } // End Read

            public static ClavesControlConductores Read(int folio)
            {
                Hashtable w_params = new Hashtable();
                w_params.Add("Folio", folio);
                DataTable dt = DB.Select("ClavesControlConductores", w_params);
                if (dt.Rows.Count == 0)
                {
                    throw new Exception("No existe ClavesControlConductores con los criterios de búsqueda especificados.");
                }
                DataRow dr = dt.Rows[0];
                return new ClavesControlConductores(Convert.ToInt32(dr["Folio"]), Convert.ToString(dr["Descripcion"]));
            } // End Read

            public int Update()
            {
                Hashtable m_params = new Hashtable();
                Hashtable w_params = new Hashtable();
                w_params.Add("Folio", this.Folio);
                m_params.Add("Descripcion", this.Descripcion);

                return DB.UpdateRow("ClavesControlConductores", m_params, w_params);
            } // End Update

            public int Delete()
            {
                Hashtable w_params = new Hashtable();
                w_params.Add("Folio", this.Folio);

                return DB.DeleteRow("ClavesControlConductores", w_params);
            } // End Delete

        } //End Class ClavesControlConductores

        public class CobroMantenimientos
        {

            public CobroMantenimientos()
            {
            }

            public CobroMantenimientos(int? movimiento, int? unidad, int? conductor, decimal? productividad, decimal? mantenimiento, DateTime? fecha)
            {
                this.Movimiento = movimiento;
                this.Unidad = unidad;
                this.Conductor = conductor;
                this.Productividad = productividad;
                this.Mantenimiento = mantenimiento;
                this.Fecha = fecha;
            }

            private int? _Movimiento;
            public int? Movimiento
            {
                get { return _Movimiento; }
                set { _Movimiento = value; }
            }

            private int? _Unidad;
            public int? Unidad
            {
                get { return _Unidad; }
                set { _Unidad = value; }
            }

            private int? _Conductor;
            public int? Conductor
            {
                get { return _Conductor; }
                set { _Conductor = value; }
            }

            private decimal? _Productividad;
            public decimal? Productividad
            {
                get { return _Productividad; }
                set { _Productividad = value; }
            }

            private decimal? _Mantenimiento;
            public decimal? Mantenimiento
            {
                get { return _Mantenimiento; }
                set { _Mantenimiento = value; }
            }

            private DateTime? _Fecha;
            public DateTime? Fecha
            {
                get { return _Fecha; }
                set { _Fecha = value; }
            }

            public int Create()
            {
                Hashtable m_params = new Hashtable();
                if (!AppHelper.IsNullOrEmpty(this.Movimiento)) m_params.Add("Movimiento", this.Movimiento);
                if (!AppHelper.IsNullOrEmpty(this.Unidad)) m_params.Add("Unidad", this.Unidad);
                if (!AppHelper.IsNullOrEmpty(this.Conductor)) m_params.Add("Conductor", this.Conductor);
                if (!AppHelper.IsNullOrEmpty(this.Productividad)) m_params.Add("Productividad", this.Productividad);
                if (!AppHelper.IsNullOrEmpty(this.Mantenimiento)) m_params.Add("Mantenimiento", this.Mantenimiento);
                if (!AppHelper.IsNullOrEmpty(this.Fecha)) m_params.Add("Fecha", this.Fecha);

                return DB.InsertRow("CobroMantenimientos", m_params);
            } // End Create

            public static List<CobroMantenimientos> Read()
            {
                List<CobroMantenimientos> list = new List<CobroMantenimientos>();
                DataTable dt = DB.Select("CobroMantenimientos");
                foreach (DataRow dr in dt.Rows)
                {
                    list.Add(new CobroMantenimientos(DB.GetNullableInt32(dr["Movimiento"]), DB.GetNullableInt32(dr["Unidad"]), DB.GetNullableInt32(dr["Conductor"]), DB.GetNullableDecimal(dr["Productividad"]), DB.GetNullableDecimal(dr["Mantenimiento"]), DB.GetNullableDateTime(dr["Fecha"])));
                }

                return list;
            } // End Read

            public int Update()
            {
                Hashtable m_params = new Hashtable();
                Hashtable w_params = new Hashtable();
                if (!AppHelper.IsNullOrEmpty(this.Movimiento)) m_params.Add("Movimiento", this.Movimiento);
                if (!AppHelper.IsNullOrEmpty(this.Unidad)) m_params.Add("Unidad", this.Unidad);
                if (!AppHelper.IsNullOrEmpty(this.Conductor)) m_params.Add("Conductor", this.Conductor);
                if (!AppHelper.IsNullOrEmpty(this.Productividad)) m_params.Add("Productividad", this.Productividad);
                if (!AppHelper.IsNullOrEmpty(this.Mantenimiento)) m_params.Add("Mantenimiento", this.Mantenimiento);
                if (!AppHelper.IsNullOrEmpty(this.Fecha)) m_params.Add("Fecha", this.Fecha);

                return DB.UpdateRow("CobroMantenimientos", m_params, w_params);
            } // End Update

            public int Delete()
            {
                Hashtable w_params = new Hashtable();

                return DB.DeleteRow("CobroMantenimientos", w_params);
            } // End Delete

        } //End Class CobroMantenimientos

        public class ComentariosIncidencias
        {

            public ComentariosIncidencias()
            {
            }

            public ComentariosIncidencias(string boleto, int tipoincidencia, string comentario)
            {
                this.Boleto = boleto;
                this.TipoIncidencia = tipoincidencia;
                this.Comentario = comentario;
            }

            private string _Boleto;
            public string Boleto
            {
                get { return _Boleto; }
                set { _Boleto = value; }
            }

            private int _TipoIncidencia;
            public int TipoIncidencia
            {
                get { return _TipoIncidencia; }
                set { _TipoIncidencia = value; }
            }

            private string _Comentario;
            public string Comentario
            {
                get { return _Comentario; }
                set { _Comentario = value; }
            }

            public int Create()
            {
                Hashtable m_params = new Hashtable();
                m_params.Add("Boleto", this.Boleto);
                m_params.Add("TipoIncidencia", this.TipoIncidencia);
                m_params.Add("Comentario", this.Comentario);

                return DB.InsertRow("ComentariosIncidencias", m_params);
            } // End Create

            public static List<ComentariosIncidencias> Read()
            {
                List<ComentariosIncidencias> list = new List<ComentariosIncidencias>();
                DataTable dt = DB.Select("ComentariosIncidencias");
                foreach (DataRow dr in dt.Rows)
                {
                    list.Add(new ComentariosIncidencias(Convert.ToString(dr["Boleto"]), Convert.ToInt32(dr["TipoIncidencia"]), Convert.ToString(dr["Comentario"])));
                }

                return list;
            } // End Read

            public int Update()
            {
                Hashtable m_params = new Hashtable();
                Hashtable w_params = new Hashtable();
                m_params.Add("Boleto", this.Boleto);
                m_params.Add("TipoIncidencia", this.TipoIncidencia);
                m_params.Add("Comentario", this.Comentario);

                return DB.UpdateRow("ComentariosIncidencias", m_params, w_params);
            } // End Update

            public int Delete()
            {
                Hashtable w_params = new Hashtable();

                return DB.DeleteRow("ComentariosIncidencias", w_params);
            } // End Delete

        } //End Class ComentariosIncidencias

        public class Comisionistas
        {

            public Comisionistas()
            {
            }

            public Comisionistas(int folio, string descripcion, decimal? porcentajecomision, int? serviciosparaproductividad)
            {
                this.Folio = folio;
                this.Descripcion = descripcion;
                this.PorcentajeComision = porcentajecomision;
                this.ServiciosParaProductividad = serviciosparaproductividad;
            }

            private int _Folio;
            public int Folio
            {
                get { return _Folio; }
                set { _Folio = value; }
            }

            private string _Descripcion;
            public string Descripcion
            {
                get { return _Descripcion; }
                set { _Descripcion = value; }
            }

            private decimal? _PorcentajeComision;
            public decimal? PorcentajeComision
            {
                get { return _PorcentajeComision; }
                set { _PorcentajeComision = value; }
            }

            private int? _ServiciosParaProductividad;
            public int? ServiciosParaProductividad
            {
                get { return _ServiciosParaProductividad; }
                set { _ServiciosParaProductividad = value; }
            }

            public int Create()
            {
                Hashtable m_params = new Hashtable();
                if (!AppHelper.IsNullOrEmpty(this.Descripcion)) m_params.Add("Descripcion", this.Descripcion);
                if (!AppHelper.IsNullOrEmpty(this.PorcentajeComision)) m_params.Add("PorcentajeComision", this.PorcentajeComision);
                if (!AppHelper.IsNullOrEmpty(this.ServiciosParaProductividad)) m_params.Add("ServiciosParaProductividad", this.ServiciosParaProductividad);

                return DB.InsertRow("Comisionistas", m_params);
            } // End Create

            public static List<Comisionistas> Read()
            {
                List<Comisionistas> list = new List<Comisionistas>();
                DataTable dt = DB.Select("Comisionistas");
                foreach (DataRow dr in dt.Rows)
                {
                    list.Add(new Comisionistas(Convert.ToInt32(dr["Folio"]), Convert.ToString(dr["Descripcion"]), DB.GetNullableDecimal(dr["PorcentajeComision"]), DB.GetNullableInt32(dr["ServiciosParaProductividad"])));
                }

                return list;
            } // End Read

            public static Comisionistas Read(int folio)
            {
                Hashtable w_params = new Hashtable();
                w_params.Add("Folio", folio);
                DataTable dt = DB.Select("Comisionistas", w_params);
                if (dt.Rows.Count == 0)
                {
                    throw new Exception("No existe Comisionistas con los criterios de búsqueda especificados.");
                }
                DataRow dr = dt.Rows[0];
                return new Comisionistas(Convert.ToInt32(dr["Folio"]), Convert.ToString(dr["Descripcion"]), DB.GetNullableDecimal(dr["PorcentajeComision"]), DB.GetNullableInt32(dr["ServiciosParaProductividad"]));
            } // End Read

            public int Update()
            {
                Hashtable m_params = new Hashtable();
                Hashtable w_params = new Hashtable();
                w_params.Add("Folio", this.Folio);
                if (!AppHelper.IsNullOrEmpty(this.Descripcion)) m_params.Add("Descripcion", this.Descripcion);
                if (!AppHelper.IsNullOrEmpty(this.PorcentajeComision)) m_params.Add("PorcentajeComision", this.PorcentajeComision);
                if (!AppHelper.IsNullOrEmpty(this.ServiciosParaProductividad)) m_params.Add("ServiciosParaProductividad", this.ServiciosParaProductividad);

                return DB.UpdateRow("Comisionistas", m_params, w_params);
            } // End Update

            public int Delete()
            {
                Hashtable w_params = new Hashtable();
                w_params.Add("Folio", this.Folio);

                return DB.DeleteRow("Comisionistas", w_params);
            } // End Delete

        } //End Class Comisionistas

        public class Conceptos
        {

            public Conceptos()
            {
            }

            public Conceptos(int folio, int cuenta, int tipo, int? fondocaja, int? tipopago, string descripcion, decimal monto, bool incluidoenrecibo, bool visibleenrecibo)
            {
                this.Folio = folio;
                this.Cuenta = cuenta;
                this.Tipo = tipo;
                this.FondoCaja = fondocaja;
                this.TipoPago = tipopago;
                this.Descripcion = descripcion;
                this.Monto = monto;
                this.IncluidoEnRecibo = incluidoenrecibo;
                this.VisibleEnRecibo = visibleenrecibo;
            }

            private int _Folio;
            public int Folio
            {
                get { return _Folio; }
                set { _Folio = value; }
            }

            private int _Cuenta;
            public int Cuenta
            {
                get { return _Cuenta; }
                set { _Cuenta = value; }
            }

            private int _Tipo;
            public int Tipo
            {
                get { return _Tipo; }
                set { _Tipo = value; }
            }

            private int? _FondoCaja;
            public int? FondoCaja
            {
                get { return _FondoCaja; }
                set { _FondoCaja = value; }
            }

            private int? _TipoPago;
            public int? TipoPago
            {
                get { return _TipoPago; }
                set { _TipoPago = value; }
            }

            private string _Descripcion;
            public string Descripcion
            {
                get { return _Descripcion; }
                set { _Descripcion = value; }
            }

            private decimal _Monto;
            public decimal Monto
            {
                get { return _Monto; }
                set { _Monto = value; }
            }

            private bool _IncluidoEnRecibo;
            public bool IncluidoEnRecibo
            {
                get { return _IncluidoEnRecibo; }
                set { _IncluidoEnRecibo = value; }
            }

            private bool _VisibleEnRecibo;
            public bool VisibleEnRecibo
            {
                get { return _VisibleEnRecibo; }
                set { _VisibleEnRecibo = value; }
            }

            public int Create()
            {
                Hashtable m_params = new Hashtable();
                m_params.Add("Cuenta", this.Cuenta);
                m_params.Add("Tipo", this.Tipo);
                if (!AppHelper.IsNullOrEmpty(this.FondoCaja)) m_params.Add("FondoCaja", this.FondoCaja);
                if (!AppHelper.IsNullOrEmpty(this.TipoPago)) m_params.Add("TipoPago", this.TipoPago);
                m_params.Add("Descripcion", this.Descripcion);
                m_params.Add("Monto", this.Monto);
                m_params.Add("IncluidoEnRecibo", this.IncluidoEnRecibo);
                m_params.Add("VisibleEnRecibo", this.VisibleEnRecibo);

                return DB.InsertRow("Conceptos", m_params);
            } // End Create

            public static List<Conceptos> Read()
            {
                List<Conceptos> list = new List<Conceptos>();
                DataTable dt = DB.Select("Conceptos");
                foreach (DataRow dr in dt.Rows)
                {
                    list.Add(new Conceptos(Convert.ToInt32(dr["Folio"]), Convert.ToInt32(dr["Cuenta"]), Convert.ToInt32(dr["Tipo"]), DB.GetNullableInt32(dr["FondoCaja"]), DB.GetNullableInt32(dr["TipoPago"]), Convert.ToString(dr["Descripcion"]), Convert.ToDecimal(dr["Monto"]), Convert.ToBoolean(dr["IncluidoEnRecibo"]), Convert.ToBoolean(dr["VisibleEnRecibo"])));
                }

                return list;
            } // End Read

            public static Conceptos Read(int folio)
            {
                Hashtable w_params = new Hashtable();
                w_params.Add("Folio", folio);
                DataTable dt = DB.Select("Conceptos", w_params);
                if (dt.Rows.Count == 0)
                {
                    throw new Exception("No existe Conceptos con los criterios de búsqueda especificados.");
                }
                DataRow dr = dt.Rows[0];
                return new Conceptos(Convert.ToInt32(dr["Folio"]), Convert.ToInt32(dr["Cuenta"]), Convert.ToInt32(dr["Tipo"]), DB.GetNullableInt32(dr["FondoCaja"]), DB.GetNullableInt32(dr["TipoPago"]), Convert.ToString(dr["Descripcion"]), Convert.ToDecimal(dr["Monto"]), Convert.ToBoolean(dr["IncluidoEnRecibo"]), Convert.ToBoolean(dr["VisibleEnRecibo"]));
            } // End Read

            public int Update()
            {
                Hashtable m_params = new Hashtable();
                Hashtable w_params = new Hashtable();
                w_params.Add("Folio", this.Folio);
                m_params.Add("Cuenta", this.Cuenta);
                m_params.Add("Tipo", this.Tipo);
                if (!AppHelper.IsNullOrEmpty(this.FondoCaja)) m_params.Add("FondoCaja", this.FondoCaja);
                if (!AppHelper.IsNullOrEmpty(this.TipoPago)) m_params.Add("TipoPago", this.TipoPago);
                m_params.Add("Descripcion", this.Descripcion);
                m_params.Add("Monto", this.Monto);
                m_params.Add("IncluidoEnRecibo", this.IncluidoEnRecibo);
                m_params.Add("VisibleEnRecibo", this.VisibleEnRecibo);

                return DB.UpdateRow("Conceptos", m_params, w_params);
            } // End Update

            public int Delete()
            {
                Hashtable w_params = new Hashtable();
                w_params.Add("Folio", this.Folio);

                return DB.DeleteRow("Conceptos", w_params);
            } // End Delete

        } //End Class Conceptos

        public class conceptos_operaciones
        {

            public conceptos_operaciones()
            {
            }

            public conceptos_operaciones(int? concepto, int? operacion)
            {
                this.concepto = concepto;
                this.operacion = operacion;
            }

            private int? _concepto;
            public int? concepto
            {
                get { return _concepto; }
                set { _concepto = value; }
            }

            private int? _operacion;
            public int? operacion
            {
                get { return _operacion; }
                set { _operacion = value; }
            }

            public int Create()
            {
                Hashtable m_params = new Hashtable();
                if (!AppHelper.IsNullOrEmpty(this.concepto)) m_params.Add("concepto", this.concepto);
                if (!AppHelper.IsNullOrEmpty(this.operacion)) m_params.Add("operacion", this.operacion);

                return DB.InsertRow("conceptos_operaciones", m_params);
            } // End Create

            public static List<conceptos_operaciones> Read()
            {
                List<conceptos_operaciones> list = new List<conceptos_operaciones>();
                DataTable dt = DB.Select("conceptos_operaciones");
                foreach (DataRow dr in dt.Rows)
                {
                    list.Add(new conceptos_operaciones(DB.GetNullableInt32(dr["concepto"]), DB.GetNullableInt32(dr["operacion"])));
                }

                return list;
            } // End Read

            public int Update()
            {
                Hashtable m_params = new Hashtable();
                Hashtable w_params = new Hashtable();
                if (!AppHelper.IsNullOrEmpty(this.concepto)) m_params.Add("concepto", this.concepto);
                if (!AppHelper.IsNullOrEmpty(this.operacion)) m_params.Add("operacion", this.operacion);

                return DB.UpdateRow("conceptos_operaciones", m_params, w_params);
            } // End Update

            public int Delete()
            {
                Hashtable w_params = new Hashtable();

                return DB.DeleteRow("conceptos_operaciones", w_params);
            } // End Delete

        } //End Class conceptos_operaciones

        public class ConceptosCuentasCascoTransportes
        {

            public ConceptosCuentasCascoTransportes()
            {
            }

            public ConceptosCuentasCascoTransportes(int? folio, int? cuentacasco, int? tipo, string descripcion, decimal? monto)
            {
                this.Folio = folio;
                this.CuentaCasco = cuentacasco;
                this.Tipo = tipo;
                this.Descripcion = descripcion;
                this.Monto = monto;
            }

            private int? _Folio;
            public int? Folio
            {
                get { return _Folio; }
                set { _Folio = value; }
            }

            private int? _CuentaCasco;
            public int? CuentaCasco
            {
                get { return _CuentaCasco; }
                set { _CuentaCasco = value; }
            }

            private int? _Tipo;
            public int? Tipo
            {
                get { return _Tipo; }
                set { _Tipo = value; }
            }

            private string _Descripcion;
            public string Descripcion
            {
                get { return _Descripcion; }
                set { _Descripcion = value; }
            }

            private decimal? _Monto;
            public decimal? Monto
            {
                get { return _Monto; }
                set { _Monto = value; }
            }

            public int Create()
            {
                Hashtable m_params = new Hashtable();
                if (!AppHelper.IsNullOrEmpty(this.Folio)) m_params.Add("Folio", this.Folio);
                if (!AppHelper.IsNullOrEmpty(this.CuentaCasco)) m_params.Add("CuentaCasco", this.CuentaCasco);
                if (!AppHelper.IsNullOrEmpty(this.Tipo)) m_params.Add("Tipo", this.Tipo);
                if (!AppHelper.IsNullOrEmpty(this.Descripcion)) m_params.Add("Descripcion", this.Descripcion);
                if (!AppHelper.IsNullOrEmpty(this.Monto)) m_params.Add("Monto", this.Monto);

                return DB.InsertRow("ConceptosCuentasCascoTransportes", m_params);
            } // End Create

            public static List<ConceptosCuentasCascoTransportes> Read()
            {
                List<ConceptosCuentasCascoTransportes> list = new List<ConceptosCuentasCascoTransportes>();
                DataTable dt = DB.Select("ConceptosCuentasCascoTransportes");
                foreach (DataRow dr in dt.Rows)
                {
                    list.Add(new ConceptosCuentasCascoTransportes(DB.GetNullableInt32(dr["Folio"]), DB.GetNullableInt32(dr["CuentaCasco"]), DB.GetNullableInt32(dr["Tipo"]), Convert.ToString(dr["Descripcion"]), DB.GetNullableDecimal(dr["Monto"])));
                }

                return list;
            } // End Read

            public int Update()
            {
                Hashtable m_params = new Hashtable();
                Hashtable w_params = new Hashtable();
                if (!AppHelper.IsNullOrEmpty(this.Folio)) m_params.Add("Folio", this.Folio);
                if (!AppHelper.IsNullOrEmpty(this.CuentaCasco)) m_params.Add("CuentaCasco", this.CuentaCasco);
                if (!AppHelper.IsNullOrEmpty(this.Tipo)) m_params.Add("Tipo", this.Tipo);
                if (!AppHelper.IsNullOrEmpty(this.Descripcion)) m_params.Add("Descripcion", this.Descripcion);
                if (!AppHelper.IsNullOrEmpty(this.Monto)) m_params.Add("Monto", this.Monto);

                return DB.UpdateRow("ConceptosCuentasCascoTransportes", m_params, w_params);
            } // End Update

            public int Delete()
            {
                Hashtable w_params = new Hashtable();

                return DB.DeleteRow("ConceptosCuentasCascoTransportes", w_params);
            } // End Delete

        } //End Class ConceptosCuentasCascoTransportes

        public class ConceptosDeCaja
        {

            public ConceptosDeCaja()
            {
            }

            public ConceptosDeCaja(int folio, int? tipo, string descripcion)
            {
                this.Folio = folio;
                this.Tipo = tipo;
                this.Descripcion = descripcion;
            }

            private int _Folio;
            public int Folio
            {
                get { return _Folio; }
                set { _Folio = value; }
            }

            private int? _Tipo;
            public int? Tipo
            {
                get { return _Tipo; }
                set { _Tipo = value; }
            }

            private string _Descripcion;
            public string Descripcion
            {
                get { return _Descripcion; }
                set { _Descripcion = value; }
            }

            public int Create()
            {
                Hashtable m_params = new Hashtable();
                if (!AppHelper.IsNullOrEmpty(this.Tipo)) m_params.Add("Tipo", this.Tipo);
                if (!AppHelper.IsNullOrEmpty(this.Descripcion)) m_params.Add("Descripcion", this.Descripcion);

                return DB.InsertRow("ConceptosDeCaja", m_params);
            } // End Create

            public static List<ConceptosDeCaja> Read()
            {
                List<ConceptosDeCaja> list = new List<ConceptosDeCaja>();
                DataTable dt = DB.Select("ConceptosDeCaja");
                foreach (DataRow dr in dt.Rows)
                {
                    list.Add(new ConceptosDeCaja(Convert.ToInt32(dr["Folio"]), DB.GetNullableInt32(dr["Tipo"]), Convert.ToString(dr["Descripcion"])));
                }

                return list;
            } // End Read

            public static ConceptosDeCaja Read(int folio)
            {
                Hashtable w_params = new Hashtable();
                w_params.Add("Folio", folio);
                DataTable dt = DB.Select("ConceptosDeCaja", w_params);
                if (dt.Rows.Count == 0)
                {
                    throw new Exception("No existe ConceptosDeCaja con los criterios de búsqueda especificados.");
                }
                DataRow dr = dt.Rows[0];
                return new ConceptosDeCaja(Convert.ToInt32(dr["Folio"]), DB.GetNullableInt32(dr["Tipo"]), Convert.ToString(dr["Descripcion"]));
            } // End Read

            public int Update()
            {
                Hashtable m_params = new Hashtable();
                Hashtable w_params = new Hashtable();
                w_params.Add("Folio", this.Folio);
                if (!AppHelper.IsNullOrEmpty(this.Tipo)) m_params.Add("Tipo", this.Tipo);
                if (!AppHelper.IsNullOrEmpty(this.Descripcion)) m_params.Add("Descripcion", this.Descripcion);

                return DB.UpdateRow("ConceptosDeCaja", m_params, w_params);
            } // End Update

            public int Delete()
            {
                Hashtable w_params = new Hashtable();
                w_params.Add("Folio", this.Folio);

                return DB.DeleteRow("ConceptosDeCaja", w_params);
            } // End Delete

        } //End Class ConceptosDeCaja

        public class Concesiones
        {

            public Concesiones()
            {
            }

            public Concesiones(int folio, string placa, int tipo, int status, DateTime fechaalta, string usuarioalta)
            {
                this.Folio = folio;
                this.Placa = placa;
                this.Tipo = tipo;
                this.Status = status;
                this.FechaAlta = fechaalta;
                this.UsuarioAlta = usuarioalta;
            }

            private int _Folio;
            public int Folio
            {
                get { return _Folio; }
                set { _Folio = value; }
            }

            private string _Placa;
            public string Placa
            {
                get { return _Placa; }
                set { _Placa = value; }
            }

            private int _Tipo;
            public int Tipo
            {
                get { return _Tipo; }
                set { _Tipo = value; }
            }

            private int _Status;
            public int Status
            {
                get { return _Status; }
                set { _Status = value; }
            }

            private DateTime _FechaAlta;
            public DateTime FechaAlta
            {
                get { return _FechaAlta; }
                set { _FechaAlta = value; }
            }

            private string _UsuarioAlta;
            public string UsuarioAlta
            {
                get { return _UsuarioAlta; }
                set { _UsuarioAlta = value; }
            }

            public int Create()
            {
                Hashtable m_params = new Hashtable();
                m_params.Add("Placa", this.Placa);
                m_params.Add("Tipo", this.Tipo);
                m_params.Add("Status", this.Status);
                m_params.Add("FechaAlta", this.FechaAlta);
                m_params.Add("UsuarioAlta", this.UsuarioAlta);

                return DB.InsertRow("Concesiones", m_params);
            } // End Create

            public static List<Concesiones> Read()
            {
                List<Concesiones> list = new List<Concesiones>();
                DataTable dt = DB.Select("Concesiones");
                foreach (DataRow dr in dt.Rows)
                {
                    list.Add(new Concesiones(Convert.ToInt32(dr["Folio"]), Convert.ToString(dr["Placa"]), Convert.ToInt32(dr["Tipo"]), Convert.ToInt32(dr["Status"]), Convert.ToDateTime(dr["FechaAlta"]), Convert.ToString(dr["UsuarioAlta"])));
                }

                return list;
            } // End Read

            public static Concesiones Read(int folio)
            {
                Hashtable w_params = new Hashtable();
                w_params.Add("Folio", folio);
                DataTable dt = DB.Select("Concesiones", w_params);
                if (dt.Rows.Count == 0)
                {
                    throw new Exception("No existe Concesiones con los criterios de búsqueda especificados.");
                }
                DataRow dr = dt.Rows[0];
                return new Concesiones(Convert.ToInt32(dr["Folio"]), Convert.ToString(dr["Placa"]), Convert.ToInt32(dr["Tipo"]), Convert.ToInt32(dr["Status"]), Convert.ToDateTime(dr["FechaAlta"]), Convert.ToString(dr["UsuarioAlta"]));
            } // End Read

            public int Update()
            {
                Hashtable m_params = new Hashtable();
                Hashtable w_params = new Hashtable();
                w_params.Add("Folio", this.Folio);
                m_params.Add("Placa", this.Placa);
                m_params.Add("Tipo", this.Tipo);
                m_params.Add("Status", this.Status);
                m_params.Add("FechaAlta", this.FechaAlta);
                m_params.Add("UsuarioAlta", this.UsuarioAlta);

                return DB.UpdateRow("Concesiones", m_params, w_params);
            } // End Update

            public int Delete()
            {
                Hashtable w_params = new Hashtable();
                w_params.Add("Folio", this.Folio);

                return DB.DeleteRow("Concesiones", w_params);
            } // End Delete

        } //End Class Concesiones

        public class ConcesionesUnidades
        {

            public ConcesionesUnidades()
            {
            }

            public ConcesionesUnidades(int concesion, int unidad, DateTime fecha, string usuario, Guid claveconsecion)
            {
                this.Concesion = concesion;
                this.Unidad = unidad;
                this.Fecha = fecha;
                this.Usuario = usuario;
                this.ClaveConsecion = claveconsecion;
            }

            private int _Concesion;
            public int Concesion
            {
                get { return _Concesion; }
                set { _Concesion = value; }
            }

            private int _Unidad;
            public int Unidad
            {
                get { return _Unidad; }
                set { _Unidad = value; }
            }

            private DateTime _Fecha;
            public DateTime Fecha
            {
                get { return _Fecha; }
                set { _Fecha = value; }
            }

            private string _Usuario;
            public string Usuario
            {
                get { return _Usuario; }
                set { _Usuario = value; }
            }

            private Guid _ClaveConsecion;
            public Guid ClaveConsecion
            {
                get { return _ClaveConsecion; }
                set { _ClaveConsecion = value; }
            }

            public int Create()
            {
                Hashtable m_params = new Hashtable();
                m_params.Add("Concesion", this.Concesion);
                m_params.Add("Unidad", this.Unidad);
                m_params.Add("Fecha", this.Fecha);
                m_params.Add("Usuario", this.Usuario);
                m_params.Add("ClaveConsecion", this.ClaveConsecion);

                return DB.InsertRow("ConcesionesUnidades", m_params);
            } // End Create

            public static List<ConcesionesUnidades> Read()
            {
                List<ConcesionesUnidades> list = new List<ConcesionesUnidades>();
                DataTable dt = DB.Select("ConcesionesUnidades");
                foreach (DataRow dr in dt.Rows)
                {
                    list.Add(new ConcesionesUnidades(Convert.ToInt32(dr["Concesion"]), Convert.ToInt32(dr["Unidad"]), Convert.ToDateTime(dr["Fecha"]), Convert.ToString(dr["Usuario"]), new Guid(Convert.ToString(dr["ClaveConsecion"]))));
                }

                return list;
            } // End Read

            public static ConcesionesUnidades Read(int concesion, int unidad)
            {
                Hashtable w_params = new Hashtable();
                w_params.Add("Concesion", concesion);
                w_params.Add("Unidad", unidad);
                DataTable dt = DB.Select("ConcesionesUnidades", w_params);
                if (dt.Rows.Count == 0)
                {
                    throw new Exception("No existe ConcesionesUnidades con los criterios de búsqueda especificados.");
                }
                DataRow dr = dt.Rows[0];
                return new ConcesionesUnidades(Convert.ToInt32(dr["Concesion"]), Convert.ToInt32(dr["Unidad"]), Convert.ToDateTime(dr["Fecha"]), Convert.ToString(dr["Usuario"]), new Guid(Convert.ToString((dr["ClaveConsecion"]))));
            } // End Read

            public int Update()
            {
                Hashtable m_params = new Hashtable();
                Hashtable w_params = new Hashtable();
                w_params.Add("Concesion", this.Concesion);
                w_params.Add("Unidad", this.Unidad);
                m_params.Add("Fecha", this.Fecha);
                m_params.Add("Usuario", this.Usuario);
                m_params.Add("ClaveConsecion", this.ClaveConsecion);

                return DB.UpdateRow("ConcesionesUnidades", m_params, w_params);
            } // End Update

            public int Delete()
            {
                Hashtable w_params = new Hashtable();
                w_params.Add("Concesion", this.Concesion);
                w_params.Add("Unidad", this.Unidad);

                return DB.DeleteRow("ConcesionesUnidades", w_params);
            } // End Delete

        } //End Class ConcesionesUnidades

        public class Conductores
        {

            public Conductores()
            {
            }

            public Conductores(int folio, int tipo, string apellidopaterno, string apellidomaterno, string nombre, string calle, string numerocasa, string colonia, string municipio, string estado, string telefono, string celular, string otro, string correoelectronico, string fotografia, int? diadescanso)
            {
                this.Folio = folio;
                this.Tipo = tipo;
                this.ApellidoPaterno = apellidopaterno;
                this.ApellidoMaterno = apellidomaterno;
                this.Nombre = nombre;
                this.Calle = calle;
                this.NumeroCasa = numerocasa;
                this.Colonia = colonia;
                this.Municipio = municipio;
                this.Estado = estado;
                this.Telefono = telefono;
                this.Celular = celular;
                this.Otro = otro;
                this.CorreoElectronico = correoelectronico;
                this.Fotografia = fotografia;
                this.DiaDescanso = diadescanso;
            }

            private int _Folio;
            public int Folio
            {
                get { return _Folio; }
                set { _Folio = value; }
            }

            private int _Tipo;
            public int Tipo
            {
                get { return _Tipo; }
                set { _Tipo = value; }
            }

            private string _ApellidoPaterno;
            public string ApellidoPaterno
            {
                get { return _ApellidoPaterno; }
                set { _ApellidoPaterno = value; }
            }

            private string _ApellidoMaterno;
            public string ApellidoMaterno
            {
                get { return _ApellidoMaterno; }
                set { _ApellidoMaterno = value; }
            }

            private string _Nombre;
            public string Nombre
            {
                get { return _Nombre; }
                set { _Nombre = value; }
            }

            private string _Calle;
            public string Calle
            {
                get { return _Calle; }
                set { _Calle = value; }
            }

            private string _NumeroCasa;
            public string NumeroCasa
            {
                get { return _NumeroCasa; }
                set { _NumeroCasa = value; }
            }

            private string _Colonia;
            public string Colonia
            {
                get { return _Colonia; }
                set { _Colonia = value; }
            }

            private string _Municipio;
            public string Municipio
            {
                get { return _Municipio; }
                set { _Municipio = value; }
            }

            private string _Estado;
            public string Estado
            {
                get { return _Estado; }
                set { _Estado = value; }
            }

            private string _Telefono;
            public string Telefono
            {
                get { return _Telefono; }
                set { _Telefono = value; }
            }

            private string _Celular;
            public string Celular
            {
                get { return _Celular; }
                set { _Celular = value; }
            }

            private string _Otro;
            public string Otro
            {
                get { return _Otro; }
                set { _Otro = value; }
            }

            private string _CorreoElectronico;
            public string CorreoElectronico
            {
                get { return _CorreoElectronico; }
                set { _CorreoElectronico = value; }
            }

            private string _Fotografia;
            public string Fotografia
            {
                get { return _Fotografia; }
                set { _Fotografia = value; }
            }

            private int? _DiaDescanso;
            public int? DiaDescanso
            {
                get { return _DiaDescanso; }
                set { _DiaDescanso = value; }
            }

            public int Create()
            {
                Hashtable m_params = new Hashtable();
                m_params.Add("Tipo", this.Tipo);
                m_params.Add("ApellidoPaterno", this.ApellidoPaterno);
                m_params.Add("ApellidoMaterno", this.ApellidoMaterno);
                m_params.Add("Nombre", this.Nombre);
                m_params.Add("Calle", this.Calle);
                m_params.Add("NumeroCasa", this.NumeroCasa);
                m_params.Add("Colonia", this.Colonia);
                m_params.Add("Municipio", this.Municipio);
                m_params.Add("Estado", this.Estado);
                m_params.Add("Telefono", this.Telefono);
                if (!AppHelper.IsNullOrEmpty(this.Celular)) m_params.Add("Celular", this.Celular);
                if (!AppHelper.IsNullOrEmpty(this.Otro)) m_params.Add("Otro", this.Otro);
                if (!AppHelper.IsNullOrEmpty(this.CorreoElectronico)) m_params.Add("CorreoElectronico", this.CorreoElectronico);
                if (!AppHelper.IsNullOrEmpty(this.Fotografia)) m_params.Add("Fotografia", this.Fotografia);
                if (!AppHelper.IsNullOrEmpty(this.DiaDescanso)) m_params.Add("DiaDescanso", this.DiaDescanso);

                return DB.InsertRow("Conductores", m_params);
            } // End Create

            public static List<Conductores> Read()
            {
                List<Conductores> list = new List<Conductores>();
                DataTable dt = DB.Select("Conductores");
                foreach (DataRow dr in dt.Rows)
                {
                    list.Add(new Conductores(Convert.ToInt32(dr["Folio"]), Convert.ToInt32(dr["Tipo"]), Convert.ToString(dr["ApellidoPaterno"]), Convert.ToString(dr["ApellidoMaterno"]), Convert.ToString(dr["Nombre"]), Convert.ToString(dr["Calle"]), Convert.ToString(dr["NumeroCasa"]), Convert.ToString(dr["Colonia"]), Convert.ToString(dr["Municipio"]), Convert.ToString(dr["Estado"]), Convert.ToString(dr["Telefono"]), Convert.ToString(dr["Celular"]), Convert.ToString(dr["Otro"]), Convert.ToString(dr["CorreoElectronico"]), Convert.ToString(dr["Fotografia"]), DB.GetNullableInt32(dr["DiaDescanso"])));
                }

                return list;
            } // End Read

            public static Conductores Read(int folio)
            {
                Hashtable w_params = new Hashtable();
                w_params.Add("Folio", folio);
                DataTable dt = DB.Select("Conductores", w_params);
                if (dt.Rows.Count == 0)
                {
                    throw new Exception("No existe Conductores con los criterios de búsqueda especificados.");
                }
                DataRow dr = dt.Rows[0];
                return new Conductores(Convert.ToInt32(dr["Folio"]), Convert.ToInt32(dr["Tipo"]), Convert.ToString(dr["ApellidoPaterno"]), Convert.ToString(dr["ApellidoMaterno"]), Convert.ToString(dr["Nombre"]), Convert.ToString(dr["Calle"]), Convert.ToString(dr["NumeroCasa"]), Convert.ToString(dr["Colonia"]), Convert.ToString(dr["Municipio"]), Convert.ToString(dr["Estado"]), Convert.ToString(dr["Telefono"]), Convert.ToString(dr["Celular"]), Convert.ToString(dr["Otro"]), Convert.ToString(dr["CorreoElectronico"]), Convert.ToString(dr["Fotografia"]), DB.GetNullableInt32(dr["DiaDescanso"]));
            } // End Read

            public static Conductores Read(params KeyValuePair<string, object>[] args)
            {
                DataTable dt = DB.Read("Conductores", args);
                if (dt.Rows.Count == 0)
                {
                    return null;
                }
                DataRow dr = dt.Rows[0];
                return new Conductores(Convert.ToInt32(dr["Folio"]), Convert.ToInt32(dr["Tipo"]), Convert.ToString(dr["ApellidoPaterno"]), 
                    Convert.ToString(dr["ApellidoMaterno"]), Convert.ToString(dr["Nombre"]), Convert.ToString(dr["Calle"]), 
                    Convert.ToString(dr["NumeroCasa"]), Convert.ToString(dr["Colonia"]), Convert.ToString(dr["Municipio"]), 
                    Convert.ToString(dr["Estado"]), Convert.ToString(dr["Telefono"]), Convert.ToString(dr["Celular"]), Convert.ToString(dr["Otro"]), Convert.ToString(dr["CorreoElectronico"]), Convert.ToString(dr["Fotografia"]), DB.GetNullableInt32(dr["DiaDescanso"]));
            } // End Read

            public static bool Read(out Conductores conductores, int top, string filter, string sort, params KeyValuePair<string, object>[] args)
            {
                DataTable dt = DB.Read("Conductores", top, filter, sort, args);
                if (dt.Rows.Count == 0)
                {
                    conductores = null;
                    return false;
                }
                DataRow dr = dt.Rows[0];
                conductores = new Conductores(Convert.ToInt32(dr["Folio"]), Convert.ToInt32(dr["Tipo"]), Convert.ToString(dr["ApellidoPaterno"]), Convert.ToString(dr["ApellidoMaterno"]), Convert.ToString(dr["Nombre"]), Convert.ToString(dr["Calle"]), Convert.ToString(dr["NumeroCasa"]), Convert.ToString(dr["Colonia"]), Convert.ToString(dr["Municipio"]), Convert.ToString(dr["Estado"]), Convert.ToString(dr["Telefono"]), Convert.ToString(dr["Celular"]), Convert.ToString(dr["Otro"]), Convert.ToString(dr["CorreoElectronico"]), Convert.ToString(dr["Fotografia"]), DB.GetNullableInt32(dr["DiaDescanso"]));
                return true;
            } // End Read


            public int Update()
            {
                Hashtable m_params = new Hashtable();
                Hashtable w_params = new Hashtable();
                w_params.Add("Folio", this.Folio);
                m_params.Add("Tipo", this.Tipo);
                m_params.Add("ApellidoPaterno", this.ApellidoPaterno);
                m_params.Add("ApellidoMaterno", this.ApellidoMaterno);
                m_params.Add("Nombre", this.Nombre);
                m_params.Add("Calle", this.Calle);
                m_params.Add("NumeroCasa", this.NumeroCasa);
                m_params.Add("Colonia", this.Colonia);
                m_params.Add("Municipio", this.Municipio);
                m_params.Add("Estado", this.Estado);
                m_params.Add("Telefono", this.Telefono);
                if (!AppHelper.IsNullOrEmpty(this.Celular)) m_params.Add("Celular", this.Celular);
                if (!AppHelper.IsNullOrEmpty(this.Otro)) m_params.Add("Otro", this.Otro);
                if (!AppHelper.IsNullOrEmpty(this.CorreoElectronico)) m_params.Add("CorreoElectronico", this.CorreoElectronico);
                if (!AppHelper.IsNullOrEmpty(this.Fotografia)) m_params.Add("Fotografia", this.Fotografia);
                if (!AppHelper.IsNullOrEmpty(this.DiaDescanso)) m_params.Add("DiaDescanso", this.DiaDescanso);

                return DB.UpdateRow("Conductores", m_params, w_params);
            } // End Update

            public int Delete()
            {
                Hashtable w_params = new Hashtable();
                w_params.Add("Folio", this.Folio);

                return DB.DeleteRow("Conductores", w_params);
            } // End Delete

        } //End Class Conductores

        public class ConductoresEbssa
        {

            public ConductoresEbssa()
            {
            }

            public ConductoresEbssa(int conductor, int conductorebssa)
            {
                this.Conductor = conductor;
                this.ConductorEbssa = conductorebssa;
            }

            private int _Conductor;
            public int Conductor
            {
                get { return _Conductor; }
                set { _Conductor = value; }
            }

            private int _ConductorEbssa;
            public int ConductorEbssa
            {
                get { return _ConductorEbssa; }
                set { _ConductorEbssa = value; }
            }

            public int Create()
            {
                Hashtable m_params = new Hashtable();
                m_params.Add("Conductor", this.Conductor);
                m_params.Add("ConductorEbssa", this.ConductorEbssa);

                return DB.InsertRow("ConductoresEbssa", m_params);
            } // End Create

            public static List<ConductoresEbssa> Read()
            {
                List<ConductoresEbssa> list = new List<ConductoresEbssa>();
                DataTable dt = DB.Select("ConductoresEbssa");
                foreach (DataRow dr in dt.Rows)
                {
                    list.Add(new ConductoresEbssa(Convert.ToInt32(dr["Conductor"]), Convert.ToInt32(dr["ConductorEbssa"])));
                }

                return list;
            } // End Read

            public int Update()
            {
                Hashtable m_params = new Hashtable();
                Hashtable w_params = new Hashtable();
                m_params.Add("Conductor", this.Conductor);
                m_params.Add("ConductorEbssa", this.ConductorEbssa);

                return DB.UpdateRow("ConductoresEbssa", m_params, w_params);
            } // End Update

            public int Delete()
            {
                Hashtable w_params = new Hashtable();

                return DB.DeleteRow("ConductoresEbssa", w_params);
            } // End Delete

        } //End Class ConductoresEbssa

        public class ConductoresPlanesDeRenta
        {

            public ConductoresPlanesDeRenta()
            {
            }

            public ConductoresPlanesDeRenta(int conductor, int categoriaactual, int unidadactual, int planderenta, string usuario, DateTime fecha)
            {
                this.Conductor = conductor;
                this.CategoriaActual = categoriaactual;
                this.UnidadActual = unidadactual;
                this.PlanDeRenta = planderenta;
                this.Usuario = usuario;
                this.Fecha = fecha;
            }

            private int _Conductor;
            public int Conductor
            {
                get { return _Conductor; }
                set { _Conductor = value; }
            }

            private int _CategoriaActual;
            public int CategoriaActual
            {
                get { return _CategoriaActual; }
                set { _CategoriaActual = value; }
            }

            private int _UnidadActual;
            public int UnidadActual
            {
                get { return _UnidadActual; }
                set { _UnidadActual = value; }
            }

            private int _PlanDeRenta;
            public int PlanDeRenta
            {
                get { return _PlanDeRenta; }
                set { _PlanDeRenta = value; }
            }

            private string _Usuario;
            public string Usuario
            {
                get { return _Usuario; }
                set { _Usuario = value; }
            }

            private DateTime _Fecha;
            public DateTime Fecha
            {
                get { return _Fecha; }
                set { _Fecha = value; }
            }

            public int Create()
            {
                Hashtable m_params = new Hashtable();
                m_params.Add("Conductor", this.Conductor);
                m_params.Add("CategoriaActual", this.CategoriaActual);
                m_params.Add("UnidadActual", this.UnidadActual);
                m_params.Add("PlanDeRenta", this.PlanDeRenta);
                m_params.Add("Usuario", this.Usuario);
                m_params.Add("Fecha", this.Fecha);

                return DB.InsertRow("ConductoresPlanesDeRenta", m_params);
            } // End Create

            public static List<ConductoresPlanesDeRenta> Read()
            {
                List<ConductoresPlanesDeRenta> list = new List<ConductoresPlanesDeRenta>();
                DataTable dt = DB.Select("ConductoresPlanesDeRenta");
                foreach (DataRow dr in dt.Rows)
                {
                    list.Add(new ConductoresPlanesDeRenta(Convert.ToInt32(dr["Conductor"]), Convert.ToInt32(dr["CategoriaActual"]), Convert.ToInt32(dr["UnidadActual"]), Convert.ToInt32(dr["PlanDeRenta"]), Convert.ToString(dr["Usuario"]), Convert.ToDateTime(dr["Fecha"])));
                }

                return list;
            } // End Read

            public static ConductoresPlanesDeRenta Read(int conductor)
            {
                Hashtable w_params = new Hashtable();
                w_params.Add("Conductor", conductor);
                DataTable dt = DB.Select("ConductoresPlanesDeRenta", w_params);
                if (dt.Rows.Count == 0)
                {
                    return null;
                }
                DataRow dr = dt.Rows[0];
                return new ConductoresPlanesDeRenta(Convert.ToInt32(dr["Conductor"]), Convert.ToInt32(dr["CategoriaActual"]), Convert.ToInt32(dr["UnidadActual"]), Convert.ToInt32(dr["PlanDeRenta"]), Convert.ToString(dr["Usuario"]), Convert.ToDateTime(dr["Fecha"]));
            } // End Read

            public int Update()
            {
                Hashtable m_params = new Hashtable();
                Hashtable w_params = new Hashtable();
                w_params.Add("Conductor", this.Conductor);
                m_params.Add("CategoriaActual", this.CategoriaActual);
                m_params.Add("UnidadActual", this.UnidadActual);
                m_params.Add("PlanDeRenta", this.PlanDeRenta);
                m_params.Add("Usuario", this.Usuario);
                m_params.Add("Fecha", this.Fecha);

                return DB.UpdateRow("ConductoresPlanesDeRenta", m_params, w_params);
            } // End Update

            public int Delete()
            {
                Hashtable w_params = new Hashtable();
                w_params.Add("Conductor", this.Conductor);

                return DB.DeleteRow("ConductoresPlanesDeRenta", w_params);
            } // End Delete

        } //End Class ConductoresPlanesDeRenta

        public class ConductoresTurnoNocturno
        {

            public ConductoresTurnoNocturno()
            {
            }

            public ConductoresTurnoNocturno(int? unidad, int? conductor)
            {
                this.Unidad = unidad;
                this.Conductor = conductor;
            }

            private int? _Unidad;
            public int? Unidad
            {
                get { return _Unidad; }
                set { _Unidad = value; }
            }

            private int? _Conductor;
            public int? Conductor
            {
                get { return _Conductor; }
                set { _Conductor = value; }
            }

            public int Create()
            {
                Hashtable m_params = new Hashtable();
                if (!AppHelper.IsNullOrEmpty(this.Unidad)) m_params.Add("Unidad", this.Unidad);
                if (!AppHelper.IsNullOrEmpty(this.Conductor)) m_params.Add("Conductor", this.Conductor);

                return DB.InsertRow("ConductoresTurnoNocturno", m_params);
            } // End Create

            public static List<ConductoresTurnoNocturno> Read()
            {
                List<ConductoresTurnoNocturno> list = new List<ConductoresTurnoNocturno>();
                DataTable dt = DB.Select("ConductoresTurnoNocturno");
                foreach (DataRow dr in dt.Rows)
                {
                    list.Add(new ConductoresTurnoNocturno(DB.GetNullableInt32(dr["Unidad"]), DB.GetNullableInt32(dr["Conductor"])));
                }

                return list;
            } // End Read

            public int Update()
            {
                Hashtable m_params = new Hashtable();
                Hashtable w_params = new Hashtable();
                if (!AppHelper.IsNullOrEmpty(this.Unidad)) m_params.Add("Unidad", this.Unidad);
                if (!AppHelper.IsNullOrEmpty(this.Conductor)) m_params.Add("Conductor", this.Conductor);

                return DB.UpdateRow("ConductoresTurnoNocturno", m_params, w_params);
            } // End Update

            public int Delete()
            {
                Hashtable w_params = new Hashtable();

                return DB.DeleteRow("ConductoresTurnoNocturno", w_params);
            } // End Delete

        } //End Class ConductoresTurnoNocturno

        public class Contratos
        {

            public Contratos()
            {
            }

            public Contratos(int folio, int? conductor, int? unidad, DateTime? fechainicio, DateTime? fechaterminacion)
            {
                this.Folio = folio;
                this.Conductor = conductor;
                this.Unidad = unidad;
                this.FechaInicio = fechainicio;
                this.FechaTerminacion = fechaterminacion;
            }

            private int _Folio;
            public int Folio
            {
                get { return _Folio; }
                set { _Folio = value; }
            }

            private int? _Conductor;
            public int? Conductor
            {
                get { return _Conductor; }
                set { _Conductor = value; }
            }

            private int? _Unidad;
            public int? Unidad
            {
                get { return _Unidad; }
                set { _Unidad = value; }
            }

            private DateTime? _FechaInicio;
            public DateTime? FechaInicio
            {
                get { return _FechaInicio; }
                set { _FechaInicio = value; }
            }

            private DateTime? _FechaTerminacion;
            public DateTime? FechaTerminacion
            {
                get { return _FechaTerminacion; }
                set { _FechaTerminacion = value; }
            }

            public int Create()
            {
                Hashtable m_params = new Hashtable();
                if (!AppHelper.IsNullOrEmpty(this.Conductor)) m_params.Add("Conductor", this.Conductor);
                if (!AppHelper.IsNullOrEmpty(this.Unidad)) m_params.Add("Unidad", this.Unidad);
                if (!AppHelper.IsNullOrEmpty(this.FechaInicio)) m_params.Add("FechaInicio", this.FechaInicio);
                if (!AppHelper.IsNullOrEmpty(this.FechaTerminacion)) m_params.Add("FechaTerminacion", this.FechaTerminacion);

                return DB.InsertRow("Contratos", m_params);
            } // End Create

            public static List<Contratos> Read()
            {
                List<Contratos> list = new List<Contratos>();
                DataTable dt = DB.Select("Contratos");
                foreach (DataRow dr in dt.Rows)
                {
                    list.Add(new Contratos(Convert.ToInt32(dr["Folio"]), DB.GetNullableInt32(dr["Conductor"]), DB.GetNullableInt32(dr["Unidad"]), DB.GetNullableDateTime(dr["FechaInicio"]), DB.GetNullableDateTime(dr["FechaTerminacion"])));
                }

                return list;
            } // End Read

            public static Contratos Read(int folio)
            {
                Hashtable w_params = new Hashtable();
                w_params.Add("Folio", folio);
                DataTable dt = DB.Select("Contratos", w_params);
                if (dt.Rows.Count == 0)
                {
                    throw new Exception("No existe Contratos con los criterios de búsqueda especificados.");
                }
                DataRow dr = dt.Rows[0];
                return new Contratos(Convert.ToInt32(dr["Folio"]), DB.GetNullableInt32(dr["Conductor"]), DB.GetNullableInt32(dr["Unidad"]), DB.GetNullableDateTime(dr["FechaInicio"]), DB.GetNullableDateTime(dr["FechaTerminacion"]));
            } // End Read

            public static Contratos Read(params KeyValuePair<string, object>[] args)
            {
                DataTable dt = DB.Read("Contratos", args);
                if (dt.Rows.Count == 0)
                {
                    return null;
                }
                DataRow dr = dt.Rows[0];
                return new Contratos(Convert.ToInt32(dr["Folio"]), DB.GetNullableInt32(dr["Conductor"]), DB.GetNullableInt32(dr["Unidad"]), DB.GetNullableDateTime(dr["FechaInicio"]), DB.GetNullableDateTime(dr["FechaTerminacion"]));
            } // End Read

            public static bool Read(out Contratos contratos, int top, string filter, string sort, params KeyValuePair<string, object>[] args)
            {
                DataTable dt = DB.Read("Contratos", top, filter, sort, args);
                if (dt.Rows.Count == 0)
                {
                    contratos = null;
                    return false;
                }
                DataRow dr = dt.Rows[0];
                contratos = new Contratos(Convert.ToInt32(dr["Folio"]), DB.GetNullableInt32(dr["Conductor"]), DB.GetNullableInt32(dr["Unidad"]), DB.GetNullableDateTime(dr["FechaInicio"]), DB.GetNullableDateTime(dr["FechaTerminacion"]));
                return true;
            } // End Read

            public int Update()
            {
                Hashtable m_params = new Hashtable();
                Hashtable w_params = new Hashtable();
                w_params.Add("Folio", this.Folio);
                if (!AppHelper.IsNullOrEmpty(this.Conductor)) m_params.Add("Conductor", this.Conductor);
                if (!AppHelper.IsNullOrEmpty(this.Unidad)) m_params.Add("Unidad", this.Unidad);
                if (!AppHelper.IsNullOrEmpty(this.FechaInicio)) m_params.Add("FechaInicio", this.FechaInicio);
                if (!AppHelper.IsNullOrEmpty(this.FechaTerminacion)) m_params.Add("FechaTerminacion", this.FechaTerminacion);

                return DB.UpdateRow("Contratos", m_params, w_params);
            } // End Update

            public int Delete()
            {
                Hashtable w_params = new Hashtable();
                w_params.Add("Folio", this.Folio);

                return DB.DeleteRow("Contratos", w_params);
            } // End Delete

        } //End Class Contratos

        public class ControlCajas
        {

            public ControlCajas()
            {
            }

            public ControlCajas(int folio, int caja, string usuario, DateTime fechainiciocaja, DateTime? fechacortecaja)
            {
                this.Folio = folio;
                this.Caja = caja;
                this.Usuario = usuario;
                this.FechaInicioCaja = fechainiciocaja;
                this.FechaCorteCaja = fechacortecaja;
            }

            private int _Folio;
            public int Folio
            {
                get { return _Folio; }
                set { _Folio = value; }
            }

            private int _Caja;
            public int Caja
            {
                get { return _Caja; }
                set { _Caja = value; }
            }

            private string _Usuario;
            public string Usuario
            {
                get { return _Usuario; }
                set { _Usuario = value; }
            }

            private DateTime _FechaInicioCaja;
            public DateTime FechaInicioCaja
            {
                get { return _FechaInicioCaja; }
                set { _FechaInicioCaja = value; }
            }

            private DateTime? _FechaCorteCaja;
            public DateTime? FechaCorteCaja
            {
                get { return _FechaCorteCaja; }
                set { _FechaCorteCaja = value; }
            }

            public static ControlCajas GetBy(DateTime fecha, int? caja)
            {
                string filter = "(@Fecha BETWEEN FechaInicioCaja AND ISNULL(FechaCorteCaja,GETDATE())) AND (Caja = @Caja)";
                DataTable dt = DB.Read("ControlCajas", 1, filter, "", DB.Param("@Fecha", fecha), DB.Param("@Caja", caja));

                if (dt.Rows.Count == 0)
                {
                    return null;
                }

                DataRow dr = dt.Rows[0];
                return new ControlCajas(Convert.ToInt32(dr["Folio"]), Convert.ToInt32(dr["Caja"]), Convert.ToString(dr["Usuario"]), 
                    Convert.ToDateTime(dr["FechaInicioCaja"]), DB.GetNullableDateTime(dr["FechaCorteCaja"]));
            }

            public int Create()
            {
                Hashtable m_params = new Hashtable();
                m_params.Add("Caja", this.Caja);
                m_params.Add("Usuario", this.Usuario);
                m_params.Add("FechaInicioCaja", this.FechaInicioCaja);
                if (!AppHelper.IsNullOrEmpty(this.FechaCorteCaja)) m_params.Add("FechaCorteCaja", this.FechaCorteCaja);

                return DB.InsertRow("ControlCajas", m_params);
            } // End Create

            public static List<ControlCajas> Read()
            {
                List<ControlCajas> list = new List<ControlCajas>();
                DataTable dt = DB.Select("ControlCajas");
                foreach (DataRow dr in dt.Rows)
                {
                    list.Add(new ControlCajas(Convert.ToInt32(dr["Folio"]), Convert.ToInt32(dr["Caja"]), Convert.ToString(dr["Usuario"]), Convert.ToDateTime(dr["FechaInicioCaja"]), DB.GetNullableDateTime(dr["FechaCorteCaja"])));
                }

                return list;
            } // End Read

            public static ControlCajas Read(string filter, params KeyValuePair<string, object>[] args)
            {
                DataTable dt = DB.Read("ControlCajas", filter, "", args);
                if (dt.Rows.Count == 0)
                {
                    return null;
                }
                DataRow dr = dt.Rows[0];
                return new ControlCajas(Convert.ToInt32(dr["Folio"]), Convert.ToInt32(dr["Caja"]), Convert.ToString(dr["Usuario"]), Convert.ToDateTime(dr["FechaInicioCaja"]), DB.GetNullableDateTime(dr["FechaCorteCaja"]));
            } // End Read

            public static ControlCajas Read(int folio)
            {
                Hashtable w_params = new Hashtable();
                w_params.Add("Folio", folio);
                DataTable dt = DB.Select("ControlCajas", w_params);
                if (dt.Rows.Count == 0)
                {
                    throw new Exception("No existe ControlCajas con los criterios de búsqueda especificados.");
                }
                DataRow dr = dt.Rows[0];
                return new ControlCajas(Convert.ToInt32(dr["Folio"]), Convert.ToInt32(dr["Caja"]), Convert.ToString(dr["Usuario"]), Convert.ToDateTime(dr["FechaInicioCaja"]), DB.GetNullableDateTime(dr["FechaCorteCaja"]));
            } // End Read

            public static ControlCajas Read(params KeyValuePair<string, object>[] args)
            {
                DataTable dt = DB.Read("ControlCajas", args);
                if (dt.Rows.Count == 0)
                {
                    return null;
                }
                DataRow dr = dt.Rows[0];
                return new ControlCajas(Convert.ToInt32(dr["Folio"]), Convert.ToInt32(dr["Caja"]), Convert.ToString(dr["Usuario"]), Convert.ToDateTime(dr["FechaInicioCaja"]), DB.GetNullableDateTime(dr["FechaCorteCaja"]));
            } // End Read

            public static bool Read(out ControlCajas controlcajas, int top, string filter, string sort, params KeyValuePair<string, object>[] args)
            {
                DataTable dt = DB.Read("ControlCajas", top, filter, sort, args);
                if (dt.Rows.Count == 0)
                {
                    controlcajas = null;
                    return false;
                }
                DataRow dr = dt.Rows[0];
                controlcajas = new ControlCajas(Convert.ToInt32(dr["Folio"]), Convert.ToInt32(dr["Caja"]), Convert.ToString(dr["Usuario"]), Convert.ToDateTime(dr["FechaInicioCaja"]), DB.GetNullableDateTime(dr["FechaCorteCaja"]));
                return true;
            } // End Read

            public int Update()
            {
                Hashtable m_params = new Hashtable();
                Hashtable w_params = new Hashtable();
                w_params.Add("Folio", this.Folio);
                m_params.Add("Caja", this.Caja);
                m_params.Add("Usuario", this.Usuario);
                m_params.Add("FechaInicioCaja", this.FechaInicioCaja);
                if (!AppHelper.IsNullOrEmpty(this.FechaCorteCaja)) m_params.Add("FechaCorteCaja", this.FechaCorteCaja);

                return DB.UpdateRow("ControlCajas", m_params, w_params);
            } // End Update

            public int Delete()
            {
                Hashtable w_params = new Hashtable();
                w_params.Add("Folio", this.Folio);

                return DB.DeleteRow("ControlCajas", w_params);
            } // End Delete

        } //End Class ControlCajas

        public class ControlCarrerasSinCubrir
        {

            public ControlCarrerasSinCubrir()
            {
            }

            public ControlCarrerasSinCubrir(int folio, int unidad, int conductor, DateTime fecha, char horaasignada, int tipopenalizacion, string colonia, string cliente, string motivo, decimal? montopenalizacion, int? diassuspencion, string comentarios)
            {
                this.Folio = folio;
                this.Unidad = unidad;
                this.Conductor = conductor;
                this.Fecha = fecha;
                this.HoraAsignada = horaasignada;
                this.TipoPenalizacion = tipopenalizacion;
                this.Colonia = colonia;
                this.Cliente = cliente;
                this.Motivo = motivo;
                this.MontoPenalizacion = montopenalizacion;
                this.DiasSuspencion = diassuspencion;
                this.Comentarios = comentarios;
            }

            private int _Folio;
            public int Folio
            {
                get { return _Folio; }
                set { _Folio = value; }
            }

            private int _Unidad;
            public int Unidad
            {
                get { return _Unidad; }
                set { _Unidad = value; }
            }

            private int _Conductor;
            public int Conductor
            {
                get { return _Conductor; }
                set { _Conductor = value; }
            }

            private DateTime _Fecha;
            public DateTime Fecha
            {
                get { return _Fecha; }
                set { _Fecha = value; }
            }

            private char _HoraAsignada;
            public char HoraAsignada
            {
                get { return _HoraAsignada; }
                set { _HoraAsignada = value; }
            }

            private int _TipoPenalizacion;
            public int TipoPenalizacion
            {
                get { return _TipoPenalizacion; }
                set { _TipoPenalizacion = value; }
            }

            private string _Colonia;
            public string Colonia
            {
                get { return _Colonia; }
                set { _Colonia = value; }
            }

            private string _Cliente;
            public string Cliente
            {
                get { return _Cliente; }
                set { _Cliente = value; }
            }

            private string _Motivo;
            public string Motivo
            {
                get { return _Motivo; }
                set { _Motivo = value; }
            }

            private decimal? _MontoPenalizacion;
            public decimal? MontoPenalizacion
            {
                get { return _MontoPenalizacion; }
                set { _MontoPenalizacion = value; }
            }

            private int? _DiasSuspencion;
            public int? DiasSuspencion
            {
                get { return _DiasSuspencion; }
                set { _DiasSuspencion = value; }
            }

            private string _Comentarios;
            public string Comentarios
            {
                get { return _Comentarios; }
                set { _Comentarios = value; }
            }

            public int Create()
            {
                Hashtable m_params = new Hashtable();
                m_params.Add("Unidad", this.Unidad);
                m_params.Add("Conductor", this.Conductor);
                m_params.Add("Fecha", this.Fecha);
                m_params.Add("HoraAsignada", this.HoraAsignada);
                m_params.Add("TipoPenalizacion", this.TipoPenalizacion);
                m_params.Add("Colonia", this.Colonia);
                m_params.Add("Cliente", this.Cliente);
                m_params.Add("Motivo", this.Motivo);
                if (!AppHelper.IsNullOrEmpty(this.MontoPenalizacion)) m_params.Add("MontoPenalizacion", this.MontoPenalizacion);
                if (!AppHelper.IsNullOrEmpty(this.DiasSuspencion)) m_params.Add("DiasSuspencion", this.DiasSuspencion);
                if (!AppHelper.IsNullOrEmpty(this.Comentarios)) m_params.Add("Comentarios", this.Comentarios);

                return DB.InsertRow("ControlCarrerasSinCubrir", m_params);
            } // End Create

            public static List<ControlCarrerasSinCubrir> Read()
            {
                List<ControlCarrerasSinCubrir> list = new List<ControlCarrerasSinCubrir>();
                DataTable dt = DB.Select("ControlCarrerasSinCubrir");
                foreach (DataRow dr in dt.Rows)
                {
                    list.Add(new ControlCarrerasSinCubrir(Convert.ToInt32(dr["Folio"]), Convert.ToInt32(dr["Unidad"]), Convert.ToInt32(dr["Conductor"]), Convert.ToDateTime(dr["Fecha"]), Convert.ToChar(dr["HoraAsignada"]), Convert.ToInt32(dr["TipoPenalizacion"]), Convert.ToString(dr["Colonia"]), Convert.ToString(dr["Cliente"]), Convert.ToString(dr["Motivo"]), DB.GetNullableDecimal(dr["MontoPenalizacion"]), DB.GetNullableInt32(dr["DiasSuspencion"]), Convert.ToString(dr["Comentarios"])));
                }

                return list;
            } // End Read

            public static ControlCarrerasSinCubrir Read(int folio)
            {
                Hashtable w_params = new Hashtable();
                w_params.Add("Folio", folio);
                DataTable dt = DB.Select("ControlCarrerasSinCubrir", w_params);
                if (dt.Rows.Count == 0)
                {
                    throw new Exception("No existe ControlCarrerasSinCubrir con los criterios de búsqueda especificados.");
                }
                DataRow dr = dt.Rows[0];
                return new ControlCarrerasSinCubrir(Convert.ToInt32(dr["Folio"]), Convert.ToInt32(dr["Unidad"]), Convert.ToInt32(dr["Conductor"]), Convert.ToDateTime(dr["Fecha"]), Convert.ToChar(dr["HoraAsignada"]), Convert.ToInt32(dr["TipoPenalizacion"]), Convert.ToString(dr["Colonia"]), Convert.ToString(dr["Cliente"]), Convert.ToString(dr["Motivo"]), DB.GetNullableDecimal(dr["MontoPenalizacion"]), DB.GetNullableInt32(dr["DiasSuspencion"]), Convert.ToString(dr["Comentarios"]));
            } // End Read

            public int Update()
            {
                Hashtable m_params = new Hashtable();
                Hashtable w_params = new Hashtable();
                w_params.Add("Folio", this.Folio);
                m_params.Add("Unidad", this.Unidad);
                m_params.Add("Conductor", this.Conductor);
                m_params.Add("Fecha", this.Fecha);
                m_params.Add("HoraAsignada", this.HoraAsignada);
                m_params.Add("TipoPenalizacion", this.TipoPenalizacion);
                m_params.Add("Colonia", this.Colonia);
                m_params.Add("Cliente", this.Cliente);
                m_params.Add("Motivo", this.Motivo);
                if (!AppHelper.IsNullOrEmpty(this.MontoPenalizacion)) m_params.Add("MontoPenalizacion", this.MontoPenalizacion);
                if (!AppHelper.IsNullOrEmpty(this.DiasSuspencion)) m_params.Add("DiasSuspencion", this.DiasSuspencion);
                if (!AppHelper.IsNullOrEmpty(this.Comentarios)) m_params.Add("Comentarios", this.Comentarios);

                return DB.UpdateRow("ControlCarrerasSinCubrir", m_params, w_params);
            } // End Update

            public int Delete()
            {
                Hashtable w_params = new Hashtable();
                w_params.Add("Folio", this.Folio);

                return DB.DeleteRow("ControlCarrerasSinCubrir", w_params);
            } // End Delete

        } //End Class ControlCarrerasSinCubrir

        public class ControlCobroPrestamosCombutible
        {

            public ControlCobroPrestamosCombutible()
            {
            }

            public ControlCobroPrestamosCombutible(int conductor, int status, DateTime fecha, string usuario)
            {
                this.Conductor = conductor;
                this.Status = status;
                this.Fecha = fecha;
                this.Usuario = usuario;
            }

            private int _Conductor;
            public int Conductor
            {
                get { return _Conductor; }
                set { _Conductor = value; }
            }

            private int _Status;
            public int Status
            {
                get { return _Status; }
                set { _Status = value; }
            }

            private DateTime _Fecha;
            public DateTime Fecha
            {
                get { return _Fecha; }
                set { _Fecha = value; }
            }

            private string _Usuario;
            public string Usuario
            {
                get { return _Usuario; }
                set { _Usuario = value; }
            }

            public int Create()
            {
                Hashtable m_params = new Hashtable();
                m_params.Add("Conductor", this.Conductor);
                m_params.Add("Status", this.Status);
                m_params.Add("Fecha", this.Fecha);
                m_params.Add("Usuario", this.Usuario);

                return DB.InsertRow("ControlCobroPrestamosCombutible", m_params);
            } // End Create

            public static List<ControlCobroPrestamosCombutible> Read()
            {
                List<ControlCobroPrestamosCombutible> list = new List<ControlCobroPrestamosCombutible>();
                DataTable dt = DB.Select("ControlCobroPrestamosCombutible");
                foreach (DataRow dr in dt.Rows)
                {
                    list.Add(new ControlCobroPrestamosCombutible(Convert.ToInt32(dr["Conductor"]), Convert.ToInt32(dr["Status"]), Convert.ToDateTime(dr["Fecha"]), Convert.ToString(dr["Usuario"])));
                }

                return list;
            } // End Read

            public static ControlCobroPrestamosCombutible Read(int conductor)
            {
                Hashtable w_params = new Hashtable();
                w_params.Add("Conductor", conductor);
                DataTable dt = DB.Select("ControlCobroPrestamosCombutible", w_params);
                if (dt.Rows.Count == 0)
                {
                    throw new Exception("No existe ControlCobroPrestamosCombutible con los criterios de búsqueda especificados.");
                }
                DataRow dr = dt.Rows[0];
                return new ControlCobroPrestamosCombutible(Convert.ToInt32(dr["Conductor"]), Convert.ToInt32(dr["Status"]), Convert.ToDateTime(dr["Fecha"]), Convert.ToString(dr["Usuario"]));
            } // End Read

            public int Update()
            {
                Hashtable m_params = new Hashtable();
                Hashtable w_params = new Hashtable();
                w_params.Add("Conductor", this.Conductor);
                m_params.Add("Status", this.Status);
                m_params.Add("Fecha", this.Fecha);
                m_params.Add("Usuario", this.Usuario);

                return DB.UpdateRow("ControlCobroPrestamosCombutible", m_params, w_params);
            } // End Update

            public int Delete()
            {
                Hashtable w_params = new Hashtable();
                w_params.Add("Conductor", this.Conductor);

                return DB.DeleteRow("ControlCobroPrestamosCombutible", w_params);
            } // End Delete

        } //End Class ControlCobroPrestamosCombutible

        public class ControlConductores
        {

            public ControlConductores()
            {
            }

            public ControlConductores(int unidad, int conductor, int clave, string comentario, DateTime fecha, int tipopenalizacion, int? diassuspencion)
            {
                this.Unidad = unidad;
                this.Conductor = conductor;
                this.Clave = clave;
                this.Comentario = comentario;
                this.Fecha = fecha;
                this.TipoPenalizacion = tipopenalizacion;
                this.DiasSuspencion = diassuspencion;
            }

            private int _Unidad;
            public int Unidad
            {
                get { return _Unidad; }
                set { _Unidad = value; }
            }

            private int _Conductor;
            public int Conductor
            {
                get { return _Conductor; }
                set { _Conductor = value; }
            }

            private int _Clave;
            public int Clave
            {
                get { return _Clave; }
                set { _Clave = value; }
            }

            private string _Comentario;
            public string Comentario
            {
                get { return _Comentario; }
                set { _Comentario = value; }
            }

            private DateTime _Fecha;
            public DateTime Fecha
            {
                get { return _Fecha; }
                set { _Fecha = value; }
            }

            private int _TipoPenalizacion;
            public int TipoPenalizacion
            {
                get { return _TipoPenalizacion; }
                set { _TipoPenalizacion = value; }
            }

            private int? _DiasSuspencion;
            public int? DiasSuspencion
            {
                get { return _DiasSuspencion; }
                set { _DiasSuspencion = value; }
            }

            public int Create()
            {
                Hashtable m_params = new Hashtable();
                m_params.Add("Unidad", this.Unidad);
                m_params.Add("Conductor", this.Conductor);
                m_params.Add("Clave", this.Clave);
                m_params.Add("Comentario", this.Comentario);
                m_params.Add("Fecha", this.Fecha);
                m_params.Add("TipoPenalizacion", this.TipoPenalizacion);
                if (!AppHelper.IsNullOrEmpty(this.DiasSuspencion)) m_params.Add("DiasSuspencion", this.DiasSuspencion);

                return DB.InsertRow("ControlConductores", m_params);
            } // End Create

            public static List<ControlConductores> Read()
            {
                List<ControlConductores> list = new List<ControlConductores>();
                DataTable dt = DB.Select("ControlConductores");
                foreach (DataRow dr in dt.Rows)
                {
                    list.Add(new ControlConductores(Convert.ToInt32(dr["Unidad"]), Convert.ToInt32(dr["Conductor"]), Convert.ToInt32(dr["Clave"]), Convert.ToString(dr["Comentario"]), Convert.ToDateTime(dr["Fecha"]), Convert.ToInt32(dr["TipoPenalizacion"]), DB.GetNullableInt32(dr["DiasSuspencion"])));
                }

                return list;
            } // End Read

            public int Update()
            {
                Hashtable m_params = new Hashtable();
                Hashtable w_params = new Hashtable();
                m_params.Add("Unidad", this.Unidad);
                m_params.Add("Conductor", this.Conductor);
                m_params.Add("Clave", this.Clave);
                m_params.Add("Comentario", this.Comentario);
                m_params.Add("Fecha", this.Fecha);
                m_params.Add("TipoPenalizacion", this.TipoPenalizacion);
                if (!AppHelper.IsNullOrEmpty(this.DiasSuspencion)) m_params.Add("DiasSuspencion", this.DiasSuspencion);

                return DB.UpdateRow("ControlConductores", m_params, w_params);
            } // End Update

            public int Delete()
            {
                Hashtable w_params = new Hashtable();

                return DB.DeleteRow("ControlConductores", w_params);
            } // End Delete

        } //End Class ControlConductores

        public class COntrolTrasladosPersonal
        {

            public COntrolTrasladosPersonal()
            {
            }

            public COntrolTrasladosPersonal(int? conductor, int? unidad, DateTime? fecha, int? empleado, decimal? monto)
            {
                this.Conductor = conductor;
                this.Unidad = unidad;
                this.Fecha = fecha;
                this.Empleado = empleado;
                this.Monto = monto;
            }

            private int? _Conductor;
            public int? Conductor
            {
                get { return _Conductor; }
                set { _Conductor = value; }
            }

            private int? _Unidad;
            public int? Unidad
            {
                get { return _Unidad; }
                set { _Unidad = value; }
            }

            private DateTime? _Fecha;
            public DateTime? Fecha
            {
                get { return _Fecha; }
                set { _Fecha = value; }
            }

            private int? _Empleado;
            public int? Empleado
            {
                get { return _Empleado; }
                set { _Empleado = value; }
            }

            private decimal? _Monto;
            public decimal? Monto
            {
                get { return _Monto; }
                set { _Monto = value; }
            }

            public int Create()
            {
                Hashtable m_params = new Hashtable();
                if (!AppHelper.IsNullOrEmpty(this.Conductor)) m_params.Add("Conductor", this.Conductor);
                if (!AppHelper.IsNullOrEmpty(this.Unidad)) m_params.Add("Unidad", this.Unidad);
                if (!AppHelper.IsNullOrEmpty(this.Fecha)) m_params.Add("Fecha", this.Fecha);
                if (!AppHelper.IsNullOrEmpty(this.Empleado)) m_params.Add("Empleado", this.Empleado);
                if (!AppHelper.IsNullOrEmpty(this.Monto)) m_params.Add("Monto", this.Monto);

                return DB.InsertRow("COntrolTrasladosPersonal", m_params);
            } // End Create

            public static List<COntrolTrasladosPersonal> Read()
            {
                List<COntrolTrasladosPersonal> list = new List<COntrolTrasladosPersonal>();
                DataTable dt = DB.Select("COntrolTrasladosPersonal");
                foreach (DataRow dr in dt.Rows)
                {
                    list.Add(new COntrolTrasladosPersonal(DB.GetNullableInt32(dr["Conductor"]), DB.GetNullableInt32(dr["Unidad"]), DB.GetNullableDateTime(dr["Fecha"]), DB.GetNullableInt32(dr["Empleado"]), DB.GetNullableDecimal(dr["Monto"])));
                }

                return list;
            } // End Read

            public int Update()
            {
                Hashtable m_params = new Hashtable();
                Hashtable w_params = new Hashtable();
                if (!AppHelper.IsNullOrEmpty(this.Conductor)) m_params.Add("Conductor", this.Conductor);
                if (!AppHelper.IsNullOrEmpty(this.Unidad)) m_params.Add("Unidad", this.Unidad);
                if (!AppHelper.IsNullOrEmpty(this.Fecha)) m_params.Add("Fecha", this.Fecha);
                if (!AppHelper.IsNullOrEmpty(this.Empleado)) m_params.Add("Empleado", this.Empleado);
                if (!AppHelper.IsNullOrEmpty(this.Monto)) m_params.Add("Monto", this.Monto);

                return DB.UpdateRow("COntrolTrasladosPersonal", m_params, w_params);
            } // End Update

            public int Delete()
            {
                Hashtable w_params = new Hashtable();

                return DB.DeleteRow("COntrolTrasladosPersonal", w_params);
            } // End Delete

        } //End Class COntrolTrasladosPersonal

        public class CortesAeropuerto
        {

            public CortesAeropuerto()
            {
            }

            public CortesAeropuerto(int folio, int caja, string usuario, DateTime fecha, string comentarios, int? status)
            {
                this.Folio = folio;
                this.Folio = folio;
                this.Caja = caja;
                this.Usuario = usuario;
                this.Fecha = fecha;
                this.Comentarios = comentarios;
                this.Status = status;
            }

            private int _Folio;
            public int Folio
            {
                get { return _Folio; }
                set { _Folio = value; }
            }

            private int _Caja;
            public int Caja
            {
                get { return _Caja; }
                set { _Caja = value; }
            }

            private string _Usuario;
            public string Usuario
            {
                get { return _Usuario; }
                set { _Usuario = value; }
            }

            private DateTime _Fecha;
            public DateTime Fecha
            {
                get { return _Fecha; }
                set { _Fecha = value; }
            }

            private string _Comentarios;
            public string Comentarios
            {
                get { return _Comentarios; }
                set { _Comentarios = value; }
            }

            private int? _Status;
            public int? Status
            {
                get { return _Status; }
                set { _Status = value; }
            }

            public int Create()
            {
                Hashtable m_params = new Hashtable();
                m_params.Add("Caja", this.Caja);
                m_params.Add("Usuario", this.Usuario);
                m_params.Add("Fecha", this.Fecha);
                if (!AppHelper.IsNullOrEmpty(this.Comentarios)) m_params.Add("Comentarios", this.Comentarios);
                if (!AppHelper.IsNullOrEmpty(this.Status)) m_params.Add("Status", this.Status);

                return DB.InsertRow("CortesAeropuerto", m_params);
            } // End Create

            public static List<CortesAeropuerto> Read()
            {
                List<CortesAeropuerto> list = new List<CortesAeropuerto>();
                DataTable dt = DB.Select("CortesAeropuerto");
                foreach (DataRow dr in dt.Rows)
                {
                    list.Add(new CortesAeropuerto(Convert.ToInt32(dr["Folio"]), Convert.ToInt32(dr["Caja"]), Convert.ToString(dr["Usuario"]), Convert.ToDateTime(dr["Fecha"]), Convert.ToString(dr["Comentarios"]), DB.GetNullableInt32(dr["Status"])));
                }

                return list;
            } // End Read

            public static CortesAeropuerto Read(int folio)
            {
                Hashtable w_params = new Hashtable();
                w_params.Add("Folio", folio);
                DataTable dt = DB.Select("CortesAeropuerto", w_params);
                if (dt.Rows.Count == 0)
                {
                    throw new Exception("No existe CortesAeropuerto con los criterios de búsqueda especificados.");
                }
                DataRow dr = dt.Rows[0];
                return new CortesAeropuerto(Convert.ToInt32(dr["Folio"]), Convert.ToInt32(dr["Caja"]), Convert.ToString(dr["Usuario"]), Convert.ToDateTime(dr["Fecha"]), Convert.ToString(dr["Comentarios"]), DB.GetNullableInt32(dr["Status"]));
            } // End Read

            public int Update()
            {
                Hashtable m_params = new Hashtable();
                Hashtable w_params = new Hashtable();
                m_params.Add("Folio", this.Folio);
                w_params.Add("Folio", this.Folio);
                m_params.Add("Caja", this.Caja);
                m_params.Add("Usuario", this.Usuario);
                m_params.Add("Fecha", this.Fecha);
                if (!AppHelper.IsNullOrEmpty(this.Comentarios)) m_params.Add("Comentarios", this.Comentarios);
                if (!AppHelper.IsNullOrEmpty(this.Status)) m_params.Add("Status", this.Status);

                return DB.UpdateRow("CortesAeropuerto", m_params, w_params);
            } // End Update

            public int Delete()
            {
                Hashtable w_params = new Hashtable();
                w_params.Add("Folio", this.Folio);

                return DB.DeleteRow("CortesAeropuerto", w_params);
            } // End Delete

        } //End Class CortesAeropuerto

        public class CuentaConductor
        {

            public CuentaConductor()
            {
            }

            public CuentaConductor(int folio, int empresa, int? caja, int unidad, int conductor, int concepto, decimal monto, DateTime fecha, string usuario, string comentario)
            {
                this.Folio = folio;
                this.Empresa = empresa;
                this.Caja = caja;
                this.Unidad = unidad;
                this.Conductor = conductor;
                this.Concepto = concepto;
                this.Monto = monto;
                this.Fecha = fecha;
                this.Usuario = usuario;
                this.Comentario = comentario;
            }

            private int _Folio;
            public int Folio
            {
                get { return _Folio; }
                set { _Folio = value; }
            }

            private int _Empresa;
            public int Empresa
            {
                get { return _Empresa; }
                set { _Empresa = value; }
            }

            private int? _Caja;
            public int? Caja
            {
                get { return _Caja; }
                set { _Caja = value; }
            }

            private int _Unidad;
            public int Unidad
            {
                get { return _Unidad; }
                set { _Unidad = value; }
            }

            private int _Conductor;
            public int Conductor
            {
                get { return _Conductor; }
                set { _Conductor = value; }
            }

            private int _Concepto;
            public int Concepto
            {
                get { return _Concepto; }
                set { _Concepto = value; }
            }

            private decimal _Monto;
            public decimal Monto
            {
                get { return _Monto; }
                set { _Monto = value; }
            }

            private DateTime _Fecha;
            public DateTime Fecha
            {
                get { return _Fecha; }
                set { _Fecha = value; }
            }

            private string _Usuario;
            public string Usuario
            {
                get { return _Usuario; }
                set { _Usuario = value; }
            }

            private string _Comentario;
            public string Comentario
            {
                get { return _Comentario; }
                set { _Comentario = value; }
            }

            public int Create()
            {
                Hashtable m_params = new Hashtable();
                m_params.Add("Empresa", this.Empresa);
                if (!AppHelper.IsNullOrEmpty(this.Caja)) m_params.Add("Caja", this.Caja);
                m_params.Add("Unidad", this.Unidad);
                m_params.Add("Conductor", this.Conductor);
                m_params.Add("Concepto", this.Concepto);
                m_params.Add("Monto", this.Monto);
                m_params.Add("Fecha", this.Fecha);
                m_params.Add("Usuario", this.Usuario);
                if (!AppHelper.IsNullOrEmpty(this.Comentario)) m_params.Add("Comentario", this.Comentario);

                return DB.InsertRow("CuentaConductor", m_params);
            } // End Create

            public static List<CuentaConductor> Read()
            {
                List<CuentaConductor> list = new List<CuentaConductor>();
                DataTable dt = DB.Select("CuentaConductor");
                foreach (DataRow dr in dt.Rows)
                {
                    list.Add(new CuentaConductor(Convert.ToInt32(dr["Folio"]), Convert.ToInt32(dr["Empresa"]), DB.GetNullableInt32(dr["Caja"]), Convert.ToInt32(dr["Unidad"]), Convert.ToInt32(dr["Conductor"]), Convert.ToInt32(dr["Concepto"]), Convert.ToDecimal(dr["Monto"]), Convert.ToDateTime(dr["Fecha"]), Convert.ToString(dr["Usuario"]), Convert.ToString(dr["Comentario"])));
                }

                return list;
            } // End Read

            public static CuentaConductor Read(int folio)
            {
                Hashtable w_params = new Hashtable();
                w_params.Add("Folio", folio);
                DataTable dt = DB.Select("CuentaConductor", w_params);
                if (dt.Rows.Count == 0)
                {
                    throw new Exception("No existe CuentaConductor con los criterios de búsqueda especificados.");
                }
                DataRow dr = dt.Rows[0];
                return new CuentaConductor(Convert.ToInt32(dr["Folio"]), Convert.ToInt32(dr["Empresa"]), DB.GetNullableInt32(dr["Caja"]), Convert.ToInt32(dr["Unidad"]), Convert.ToInt32(dr["Conductor"]), Convert.ToInt32(dr["Concepto"]), Convert.ToDecimal(dr["Monto"]), Convert.ToDateTime(dr["Fecha"]), Convert.ToString(dr["Usuario"]), Convert.ToString(dr["Comentario"]));
            } // End Read

            public static CuentaConductor Read(params KeyValuePair<string, object>[] args)
            {
                DataTable dt = DB.Read("CuentaConductor", args);
                if (dt.Rows.Count == 0)
                {
                    return null;
                }
                DataRow dr = dt.Rows[0];
                return new CuentaConductor(Convert.ToInt32(dr["Folio"]), Convert.ToInt32(dr["Empresa"]), DB.GetNullableInt32(dr["Caja"]), Convert.ToInt32(dr["Unidad"]), Convert.ToInt32(dr["Conductor"]), Convert.ToInt32(dr["Concepto"]), Convert.ToDecimal(dr["Monto"]), Convert.ToDateTime(dr["Fecha"]), Convert.ToString(dr["Usuario"]), Convert.ToString(dr["Comentario"]));
            } // End Read

            public static bool Read(out CuentaConductor cuentaconductor, int top, string filter, string sort, params KeyValuePair<string, object>[] args)
            {
                DataTable dt = DB.Read("CuentaConductor", top, filter, sort, args);
                if (dt.Rows.Count == 0)
                {
                    cuentaconductor = null;
                    return false;
                }
                DataRow dr = dt.Rows[0];
                cuentaconductor = new CuentaConductor(Convert.ToInt32(dr["Folio"]), Convert.ToInt32(dr["Empresa"]), DB.GetNullableInt32(dr["Caja"]), Convert.ToInt32(dr["Unidad"]), Convert.ToInt32(dr["Conductor"]), Convert.ToInt32(dr["Concepto"]), Convert.ToDecimal(dr["Monto"]), Convert.ToDateTime(dr["Fecha"]), Convert.ToString(dr["Usuario"]), Convert.ToString(dr["Comentario"]));
                return true;
            } // End Read

            public int Update()
            {
                Hashtable m_params = new Hashtable();
                Hashtable w_params = new Hashtable();
                w_params.Add("Folio", this.Folio);
                m_params.Add("Empresa", this.Empresa);
                if (!AppHelper.IsNullOrEmpty(this.Caja)) m_params.Add("Caja", this.Caja);
                m_params.Add("Unidad", this.Unidad);
                m_params.Add("Conductor", this.Conductor);
                m_params.Add("Concepto", this.Concepto);
                m_params.Add("Monto", this.Monto);
                m_params.Add("Fecha", this.Fecha);
                m_params.Add("Usuario", this.Usuario);
                if (!AppHelper.IsNullOrEmpty(this.Comentario)) m_params.Add("Comentario", this.Comentario);

                return DB.UpdateRow("CuentaConductor", m_params, w_params);
            } // End Update

            public int Delete()
            {
                Hashtable w_params = new Hashtable();
                w_params.Add("Folio", this.Folio);

                return DB.DeleteRow("CuentaConductor", w_params);
            } // End Delete

        } //End Class CuentaConductor

        public class Cuentas
        {

            public Cuentas()
            {
            }

            public Cuentas(int folio, int subsistema, string descripcion)
            {
                this.Folio = folio;
                this.Subsistema = subsistema;
                this.Descripcion = descripcion;
            }

            private int _Folio;
            public int Folio
            {
                get { return _Folio; }
                set { _Folio = value; }
            }

            private int _Subsistema;
            public int Subsistema
            {
                get { return _Subsistema; }
                set { _Subsistema = value; }
            }

            private string _Descripcion;
            public string Descripcion
            {
                get { return _Descripcion; }
                set { _Descripcion = value; }
            }

            public int Create()
            {
                Hashtable m_params = new Hashtable();
                m_params.Add("Subsistema", this.Subsistema);
                m_params.Add("Descripcion", this.Descripcion);

                return DB.InsertRow("Cuentas", m_params);
            } // End Create

            public static List<Cuentas> Read()
            {
                List<Cuentas> list = new List<Cuentas>();
                DataTable dt = DB.Select("Cuentas");
                foreach (DataRow dr in dt.Rows)
                {
                    list.Add(new Cuentas(Convert.ToInt32(dr["Folio"]), Convert.ToInt32(dr["Subsistema"]), Convert.ToString(dr["Descripcion"])));
                }

                return list;
            } // End Read

            public static Cuentas Read(int folio)
            {
                Hashtable w_params = new Hashtable();
                w_params.Add("Folio", folio);
                DataTable dt = DB.Select("Cuentas", w_params);
                if (dt.Rows.Count == 0)
                {
                    throw new Exception("No existe Cuentas con los criterios de búsqueda especificados.");
                }
                DataRow dr = dt.Rows[0];
                return new Cuentas(Convert.ToInt32(dr["Folio"]), Convert.ToInt32(dr["Subsistema"]), Convert.ToString(dr["Descripcion"]));
            } // End Read

            public int Update()
            {
                Hashtable m_params = new Hashtable();
                Hashtable w_params = new Hashtable();
                w_params.Add("Folio", this.Folio);
                m_params.Add("Subsistema", this.Subsistema);
                m_params.Add("Descripcion", this.Descripcion);

                return DB.UpdateRow("Cuentas", m_params, w_params);
            } // End Update

            public int Delete()
            {
                Hashtable w_params = new Hashtable();
                w_params.Add("Folio", this.Folio);

                return DB.DeleteRow("Cuentas", w_params);
            } // End Delete

        } //End Class Cuentas

        public class CuentasCascoTransportes
        {

            public CuentasCascoTransportes()
            {
            }

            public CuentasCascoTransportes(int? folio, string descripcion)
            {
                this.Folio = folio;
                this.Descripcion = descripcion;
            }

            private int? _Folio;
            public int? Folio
            {
                get { return _Folio; }
                set { _Folio = value; }
            }

            private string _Descripcion;
            public string Descripcion
            {
                get { return _Descripcion; }
                set { _Descripcion = value; }
            }

            public int Create()
            {
                Hashtable m_params = new Hashtable();
                if (!AppHelper.IsNullOrEmpty(this.Folio)) m_params.Add("Folio", this.Folio);
                if (!AppHelper.IsNullOrEmpty(this.Descripcion)) m_params.Add("Descripcion", this.Descripcion);

                return DB.InsertRow("CuentasCascoTransportes", m_params);
            } // End Create

            public static List<CuentasCascoTransportes> Read()
            {
                List<CuentasCascoTransportes> list = new List<CuentasCascoTransportes>();
                DataTable dt = DB.Select("CuentasCascoTransportes");
                foreach (DataRow dr in dt.Rows)
                {
                    list.Add(new CuentasCascoTransportes(DB.GetNullableInt32(dr["Folio"]), Convert.ToString(dr["Descripcion"])));
                }

                return list;
            } // End Read

            public int Update()
            {
                Hashtable m_params = new Hashtable();
                Hashtable w_params = new Hashtable();
                if (!AppHelper.IsNullOrEmpty(this.Folio)) m_params.Add("Folio", this.Folio);
                if (!AppHelper.IsNullOrEmpty(this.Descripcion)) m_params.Add("Descripcion", this.Descripcion);

                return DB.UpdateRow("CuentasCascoTransportes", m_params, w_params);
            } // End Update

            public int Delete()
            {
                Hashtable w_params = new Hashtable();

                return DB.DeleteRow("CuentasCascoTransportes", w_params);
            } // End Delete

        } //End Class CuentasCascoTransportes

        public class CuotaEbssaConductor
        {

            public CuotaEbssaConductor()
            {
            }

            public CuotaEbssaConductor(decimal? monto)
            {
                this.Monto = monto;
            }

            private decimal? _Monto;
            public decimal? Monto
            {
                get { return _Monto; }
                set { _Monto = value; }
            }

            public int Create()
            {
                Hashtable m_params = new Hashtable();
                if (!AppHelper.IsNullOrEmpty(this.Monto)) m_params.Add("Monto", this.Monto);

                return DB.InsertRow("CuotaEbssaConductor", m_params);
            } // End Create

            public static List<CuotaEbssaConductor> Read()
            {
                List<CuotaEbssaConductor> list = new List<CuotaEbssaConductor>();
                DataTable dt = DB.Select("CuotaEbssaConductor");
                foreach (DataRow dr in dt.Rows)
                {
                    list.Add(new CuotaEbssaConductor(DB.GetNullableDecimal(dr["Monto"])));
                }

                return list;
            } // End Read

            public int Update()
            {
                Hashtable m_params = new Hashtable();
                Hashtable w_params = new Hashtable();
                if (!AppHelper.IsNullOrEmpty(this.Monto)) m_params.Add("Monto", this.Monto);

                return DB.UpdateRow("CuotaEbssaConductor", m_params, w_params);
            } // End Update

            public int Delete()
            {
                Hashtable w_params = new Hashtable();

                return DB.DeleteRow("CuotaEbssaConductor", w_params);
            } // End Delete

        } //End Class CuotaEbssaConductor

        public class DescripcionCategoriasProductividad
        {

            public DescripcionCategoriasProductividad()
            {
            }

            public DescripcionCategoriasProductividad(int? categoria, int? cantidadinicialservicios, int? cantidadfinalservicios, decimal? porcentajecasco, decimal? porcentajeconductor, decimal? porcentajepagounidad, decimal? cuotamantenimientonormal, decimal? cuotamantenimientodomingos, bool? bonoextra)
            {
                this.Categoria = categoria;
                this.CantidadInicialServicios = cantidadinicialservicios;
                this.CantidadFinalServicios = cantidadfinalservicios;
                this.PorcentajeCasco = porcentajecasco;
                this.PorcentajeConductor = porcentajeconductor;
                this.PorcentajePagoUnidad = porcentajepagounidad;
                this.CuotaMantenimientoNormal = cuotamantenimientonormal;
                this.CuotaMantenimientoDomingos = cuotamantenimientodomingos;
                this.BonoExtra = bonoextra;
            }

            private int? _Categoria;
            public int? Categoria
            {
                get { return _Categoria; }
                set { _Categoria = value; }
            }

            private int? _CantidadInicialServicios;
            public int? CantidadInicialServicios
            {
                get { return _CantidadInicialServicios; }
                set { _CantidadInicialServicios = value; }
            }

            private int? _CantidadFinalServicios;
            public int? CantidadFinalServicios
            {
                get { return _CantidadFinalServicios; }
                set { _CantidadFinalServicios = value; }
            }

            private decimal? _PorcentajeCasco;
            public decimal? PorcentajeCasco
            {
                get { return _PorcentajeCasco; }
                set { _PorcentajeCasco = value; }
            }

            private decimal? _PorcentajeConductor;
            public decimal? PorcentajeConductor
            {
                get { return _PorcentajeConductor; }
                set { _PorcentajeConductor = value; }
            }

            private decimal? _PorcentajePagoUnidad;
            public decimal? PorcentajePagoUnidad
            {
                get { return _PorcentajePagoUnidad; }
                set { _PorcentajePagoUnidad = value; }
            }

            private decimal? _CuotaMantenimientoNormal;
            public decimal? CuotaMantenimientoNormal
            {
                get { return _CuotaMantenimientoNormal; }
                set { _CuotaMantenimientoNormal = value; }
            }

            private decimal? _CuotaMantenimientoDomingos;
            public decimal? CuotaMantenimientoDomingos
            {
                get { return _CuotaMantenimientoDomingos; }
                set { _CuotaMantenimientoDomingos = value; }
            }

            private bool? _BonoExtra;
            public bool? BonoExtra
            {
                get { return _BonoExtra; }
                set { _BonoExtra = value; }
            }

            public int Create()
            {
                Hashtable m_params = new Hashtable();
                if (!AppHelper.IsNullOrEmpty(this.Categoria)) m_params.Add("Categoria", this.Categoria);
                if (!AppHelper.IsNullOrEmpty(this.CantidadInicialServicios)) m_params.Add("CantidadInicialServicios", this.CantidadInicialServicios);
                if (!AppHelper.IsNullOrEmpty(this.CantidadFinalServicios)) m_params.Add("CantidadFinalServicios", this.CantidadFinalServicios);
                if (!AppHelper.IsNullOrEmpty(this.PorcentajeCasco)) m_params.Add("PorcentajeCasco", this.PorcentajeCasco);
                if (!AppHelper.IsNullOrEmpty(this.PorcentajeConductor)) m_params.Add("PorcentajeConductor", this.PorcentajeConductor);
                if (!AppHelper.IsNullOrEmpty(this.PorcentajePagoUnidad)) m_params.Add("PorcentajePagoUnidad", this.PorcentajePagoUnidad);
                if (!AppHelper.IsNullOrEmpty(this.CuotaMantenimientoNormal)) m_params.Add("CuotaMantenimientoNormal", this.CuotaMantenimientoNormal);
                if (!AppHelper.IsNullOrEmpty(this.CuotaMantenimientoDomingos)) m_params.Add("CuotaMantenimientoDomingos", this.CuotaMantenimientoDomingos);
                if (!AppHelper.IsNullOrEmpty(this.BonoExtra)) m_params.Add("BonoExtra", this.BonoExtra);

                return DB.InsertRow("DescripcionCategoriasProductividad", m_params);
            } // End Create

            public static List<DescripcionCategoriasProductividad> Read()
            {
                List<DescripcionCategoriasProductividad> list = new List<DescripcionCategoriasProductividad>();
                DataTable dt = DB.Select("DescripcionCategoriasProductividad");
                foreach (DataRow dr in dt.Rows)
                {
                    list.Add(new DescripcionCategoriasProductividad(DB.GetNullableInt32(dr["Categoria"]), DB.GetNullableInt32(dr["CantidadInicialServicios"]), DB.GetNullableInt32(dr["CantidadFinalServicios"]), DB.GetNullableDecimal(dr["PorcentajeCasco"]), DB.GetNullableDecimal(dr["PorcentajeConductor"]), DB.GetNullableDecimal(dr["PorcentajePagoUnidad"]), DB.GetNullableDecimal(dr["CuotaMantenimientoNormal"]), DB.GetNullableDecimal(dr["CuotaMantenimientoDomingos"]), DB.GetNullableBoolean(dr["BonoExtra"])));
                }

                return list;
            } // End Read

            public int Update()
            {
                Hashtable m_params = new Hashtable();
                Hashtable w_params = new Hashtable();
                if (!AppHelper.IsNullOrEmpty(this.Categoria)) m_params.Add("Categoria", this.Categoria);
                if (!AppHelper.IsNullOrEmpty(this.CantidadInicialServicios)) m_params.Add("CantidadInicialServicios", this.CantidadInicialServicios);
                if (!AppHelper.IsNullOrEmpty(this.CantidadFinalServicios)) m_params.Add("CantidadFinalServicios", this.CantidadFinalServicios);
                if (!AppHelper.IsNullOrEmpty(this.PorcentajeCasco)) m_params.Add("PorcentajeCasco", this.PorcentajeCasco);
                if (!AppHelper.IsNullOrEmpty(this.PorcentajeConductor)) m_params.Add("PorcentajeConductor", this.PorcentajeConductor);
                if (!AppHelper.IsNullOrEmpty(this.PorcentajePagoUnidad)) m_params.Add("PorcentajePagoUnidad", this.PorcentajePagoUnidad);
                if (!AppHelper.IsNullOrEmpty(this.CuotaMantenimientoNormal)) m_params.Add("CuotaMantenimientoNormal", this.CuotaMantenimientoNormal);
                if (!AppHelper.IsNullOrEmpty(this.CuotaMantenimientoDomingos)) m_params.Add("CuotaMantenimientoDomingos", this.CuotaMantenimientoDomingos);
                if (!AppHelper.IsNullOrEmpty(this.BonoExtra)) m_params.Add("BonoExtra", this.BonoExtra);

                return DB.UpdateRow("DescripcionCategoriasProductividad", m_params, w_params);
            } // End Update

            public int Delete()
            {
                Hashtable w_params = new Hashtable();

                return DB.DeleteRow("DescripcionCategoriasProductividad", w_params);
            } // End Delete

        } //End Class DescripcionCategoriasProductividad

        public class DescripcionModeloNegocio
        {

            public DescripcionModeloNegocio()
            {
            }

            public DescripcionModeloNegocio(int? tipomodelonegocio, int? cantidadinicialservicios, int? cantidadfinalservicios, decimal? porcentajecasco, decimal? porcentajeconductor, decimal? porcentajepagounidad, decimal? cuotamantenimientonormal, decimal? cuotamantenimientodomingos)
            {
                this.TipoModeloNegocio = tipomodelonegocio;
                this.CantidadInicialServicios = cantidadinicialservicios;
                this.CantidadFinalServicios = cantidadfinalservicios;
                this.PorcentajeCasco = porcentajecasco;
                this.PorcentajeConductor = porcentajeconductor;
                this.PorcentajePagoUnidad = porcentajepagounidad;
                this.CuotaMantenimientoNormal = cuotamantenimientonormal;
                this.CuotaMantenimientoDomingos = cuotamantenimientodomingos;
            }

            private int? _TipoModeloNegocio;
            public int? TipoModeloNegocio
            {
                get { return _TipoModeloNegocio; }
                set { _TipoModeloNegocio = value; }
            }

            private int? _CantidadInicialServicios;
            public int? CantidadInicialServicios
            {
                get { return _CantidadInicialServicios; }
                set { _CantidadInicialServicios = value; }
            }

            private int? _CantidadFinalServicios;
            public int? CantidadFinalServicios
            {
                get { return _CantidadFinalServicios; }
                set { _CantidadFinalServicios = value; }
            }

            private decimal? _PorcentajeCasco;
            public decimal? PorcentajeCasco
            {
                get { return _PorcentajeCasco; }
                set { _PorcentajeCasco = value; }
            }

            private decimal? _PorcentajeConductor;
            public decimal? PorcentajeConductor
            {
                get { return _PorcentajeConductor; }
                set { _PorcentajeConductor = value; }
            }

            private decimal? _PorcentajePagoUnidad;
            public decimal? PorcentajePagoUnidad
            {
                get { return _PorcentajePagoUnidad; }
                set { _PorcentajePagoUnidad = value; }
            }

            private decimal? _CuotaMantenimientoNormal;
            public decimal? CuotaMantenimientoNormal
            {
                get { return _CuotaMantenimientoNormal; }
                set { _CuotaMantenimientoNormal = value; }
            }

            private decimal? _CuotaMantenimientoDomingos;
            public decimal? CuotaMantenimientoDomingos
            {
                get { return _CuotaMantenimientoDomingos; }
                set { _CuotaMantenimientoDomingos = value; }
            }

            public int Create()
            {
                Hashtable m_params = new Hashtable();
                if (!AppHelper.IsNullOrEmpty(this.TipoModeloNegocio)) m_params.Add("TipoModeloNegocio", this.TipoModeloNegocio);
                if (!AppHelper.IsNullOrEmpty(this.CantidadInicialServicios)) m_params.Add("CantidadInicialServicios", this.CantidadInicialServicios);
                if (!AppHelper.IsNullOrEmpty(this.CantidadFinalServicios)) m_params.Add("CantidadFinalServicios", this.CantidadFinalServicios);
                if (!AppHelper.IsNullOrEmpty(this.PorcentajeCasco)) m_params.Add("PorcentajeCasco", this.PorcentajeCasco);
                if (!AppHelper.IsNullOrEmpty(this.PorcentajeConductor)) m_params.Add("PorcentajeConductor", this.PorcentajeConductor);
                if (!AppHelper.IsNullOrEmpty(this.PorcentajePagoUnidad)) m_params.Add("PorcentajePagoUnidad", this.PorcentajePagoUnidad);
                if (!AppHelper.IsNullOrEmpty(this.CuotaMantenimientoNormal)) m_params.Add("CuotaMantenimientoNormal", this.CuotaMantenimientoNormal);
                if (!AppHelper.IsNullOrEmpty(this.CuotaMantenimientoDomingos)) m_params.Add("CuotaMantenimientoDomingos", this.CuotaMantenimientoDomingos);

                return DB.InsertRow("DescripcionModeloNegocio", m_params);
            } // End Create

            public static List<DescripcionModeloNegocio> Read()
            {
                List<DescripcionModeloNegocio> list = new List<DescripcionModeloNegocio>();
                DataTable dt = DB.Select("DescripcionModeloNegocio");
                foreach (DataRow dr in dt.Rows)
                {
                    list.Add(new DescripcionModeloNegocio(DB.GetNullableInt32(dr["TipoModeloNegocio"]), DB.GetNullableInt32(dr["CantidadInicialServicios"]), DB.GetNullableInt32(dr["CantidadFinalServicios"]), DB.GetNullableDecimal(dr["PorcentajeCasco"]), DB.GetNullableDecimal(dr["PorcentajeConductor"]), DB.GetNullableDecimal(dr["PorcentajePagoUnidad"]), DB.GetNullableDecimal(dr["CuotaMantenimientoNormal"]), DB.GetNullableDecimal(dr["CuotaMantenimientoDomingos"])));
                }

                return list;
            } // End Read

            public int Update()
            {
                Hashtable m_params = new Hashtable();
                Hashtable w_params = new Hashtable();
                if (!AppHelper.IsNullOrEmpty(this.TipoModeloNegocio)) m_params.Add("TipoModeloNegocio", this.TipoModeloNegocio);
                if (!AppHelper.IsNullOrEmpty(this.CantidadInicialServicios)) m_params.Add("CantidadInicialServicios", this.CantidadInicialServicios);
                if (!AppHelper.IsNullOrEmpty(this.CantidadFinalServicios)) m_params.Add("CantidadFinalServicios", this.CantidadFinalServicios);
                if (!AppHelper.IsNullOrEmpty(this.PorcentajeCasco)) m_params.Add("PorcentajeCasco", this.PorcentajeCasco);
                if (!AppHelper.IsNullOrEmpty(this.PorcentajeConductor)) m_params.Add("PorcentajeConductor", this.PorcentajeConductor);
                if (!AppHelper.IsNullOrEmpty(this.PorcentajePagoUnidad)) m_params.Add("PorcentajePagoUnidad", this.PorcentajePagoUnidad);
                if (!AppHelper.IsNullOrEmpty(this.CuotaMantenimientoNormal)) m_params.Add("CuotaMantenimientoNormal", this.CuotaMantenimientoNormal);
                if (!AppHelper.IsNullOrEmpty(this.CuotaMantenimientoDomingos)) m_params.Add("CuotaMantenimientoDomingos", this.CuotaMantenimientoDomingos);

                return DB.UpdateRow("DescripcionModeloNegocio", m_params, w_params);
            } // End Update

            public int Delete()
            {
                Hashtable w_params = new Hashtable();

                return DB.DeleteRow("DescripcionModeloNegocio", w_params);
            } // End Delete

        } //End Class DescripcionModeloNegocio

        public class DetalleAjusteKm
        {

            public DetalleAjusteKm()
            {
            }

            public DetalleAjusteKm(int ajuste, int unidad, int kilometreje, DateTime fecha)
            {
                this.Ajuste = ajuste;
                this.Unidad = unidad;
                this.Kilometreje = kilometreje;
                this.Fecha = fecha;
            }

            private int _Ajuste;
            public int Ajuste
            {
                get { return _Ajuste; }
                set { _Ajuste = value; }
            }

            private int _Unidad;
            public int Unidad
            {
                get { return _Unidad; }
                set { _Unidad = value; }
            }

            private int _Kilometreje;
            public int Kilometreje
            {
                get { return _Kilometreje; }
                set { _Kilometreje = value; }
            }

            private DateTime _Fecha;
            public DateTime Fecha
            {
                get { return _Fecha; }
                set { _Fecha = value; }
            }

            public int Create()
            {
                Hashtable m_params = new Hashtable();
                m_params.Add("Ajuste", this.Ajuste);
                m_params.Add("Unidad", this.Unidad);
                m_params.Add("Kilometreje", this.Kilometreje);
                m_params.Add("Fecha", this.Fecha);

                return DB.InsertRow("DetalleAjusteKm", m_params);
            } // End Create

            public static List<DetalleAjusteKm> Read()
            {
                List<DetalleAjusteKm> list = new List<DetalleAjusteKm>();
                DataTable dt = DB.Select("DetalleAjusteKm");
                foreach (DataRow dr in dt.Rows)
                {
                    list.Add(new DetalleAjusteKm(Convert.ToInt32(dr["Ajuste"]), Convert.ToInt32(dr["Unidad"]), Convert.ToInt32(dr["Kilometreje"]), Convert.ToDateTime(dr["Fecha"])));
                }

                return list;
            } // End Read

            public int Update()
            {
                Hashtable m_params = new Hashtable();
                Hashtable w_params = new Hashtable();
                m_params.Add("Ajuste", this.Ajuste);
                m_params.Add("Unidad", this.Unidad);
                m_params.Add("Kilometreje", this.Kilometreje);
                m_params.Add("Fecha", this.Fecha);

                return DB.UpdateRow("DetalleAjusteKm", m_params, w_params);
            } // End Update

            public int Delete()
            {
                Hashtable w_params = new Hashtable();

                return DB.DeleteRow("DetalleAjusteKm", w_params);
            } // End Delete

        } //End Class DetalleAjusteKm

        public class DetalleCobroPrestamoCombustible
        {

            public DetalleCobroPrestamoCombustible()
            {
            }

            public DetalleCobroPrestamoCombustible(int conductor, string diasemana, decimal monto, DateTime fecha, string usuario)
            {
                this.Conductor = conductor;
                this.DiaSemana = diasemana;
                this.Monto = monto;
                this.Fecha = fecha;
                this.Usuario = usuario;
            }

            private int _Conductor;
            public int Conductor
            {
                get { return _Conductor; }
                set { _Conductor = value; }
            }

            private string _DiaSemana;
            public string DiaSemana
            {
                get { return _DiaSemana; }
                set { _DiaSemana = value; }
            }

            private decimal _Monto;
            public decimal Monto
            {
                get { return _Monto; }
                set { _Monto = value; }
            }

            private DateTime _Fecha;
            public DateTime Fecha
            {
                get { return _Fecha; }
                set { _Fecha = value; }
            }

            private string _Usuario;
            public string Usuario
            {
                get { return _Usuario; }
                set { _Usuario = value; }
            }

            public int Create()
            {
                Hashtable m_params = new Hashtable();
                m_params.Add("Conductor", this.Conductor);
                m_params.Add("DiaSemana", this.DiaSemana);
                m_params.Add("Monto", this.Monto);
                m_params.Add("Fecha", this.Fecha);
                m_params.Add("Usuario", this.Usuario);

                return DB.InsertRow("DetalleCobroPrestamoCombustible", m_params);
            } // End Create

            public static List<DetalleCobroPrestamoCombustible> Read()
            {
                List<DetalleCobroPrestamoCombustible> list = new List<DetalleCobroPrestamoCombustible>();
                DataTable dt = DB.Select("DetalleCobroPrestamoCombustible");
                foreach (DataRow dr in dt.Rows)
                {
                    list.Add(new DetalleCobroPrestamoCombustible(Convert.ToInt32(dr["Conductor"]), Convert.ToString(dr["DiaSemana"]), Convert.ToDecimal(dr["Monto"]), Convert.ToDateTime(dr["Fecha"]), Convert.ToString(dr["Usuario"])));
                }

                return list;
            } // End Read

            public static DetalleCobroPrestamoCombustible Read(int conductor, string diasemana)
            {
                Hashtable w_params = new Hashtable();
                w_params.Add("Conductor", conductor);
                w_params.Add("DiaSemana", diasemana);
                DataTable dt = DB.Select("DetalleCobroPrestamoCombustible", w_params);
                if (dt.Rows.Count == 0)
                {
                    throw new Exception("No existe DetalleCobroPrestamoCombustible con los criterios de búsqueda especificados.");
                }
                DataRow dr = dt.Rows[0];
                return new DetalleCobroPrestamoCombustible(Convert.ToInt32(dr["Conductor"]), Convert.ToString(dr["DiaSemana"]), Convert.ToDecimal(dr["Monto"]), Convert.ToDateTime(dr["Fecha"]), Convert.ToString(dr["Usuario"]));
            } // End Read

            public int Update()
            {
                Hashtable m_params = new Hashtable();
                Hashtable w_params = new Hashtable();
                w_params.Add("Conductor", this.Conductor);
                w_params.Add("DiaSemana", this.DiaSemana);
                m_params.Add("Monto", this.Monto);
                m_params.Add("Fecha", this.Fecha);
                m_params.Add("Usuario", this.Usuario);

                return DB.UpdateRow("DetalleCobroPrestamoCombustible", m_params, w_params);
            } // End Update

            public int Delete()
            {
                Hashtable w_params = new Hashtable();
                w_params.Add("Conductor", this.Conductor);
                w_params.Add("DiaSemana", this.DiaSemana);

                return DB.DeleteRow("DetalleCobroPrestamoCombustible", w_params);
            } // End Delete

        } //End Class DetalleCobroPrestamoCombustible

        public class DetalleCortesAeropuerto
        {

            public DetalleCortesAeropuerto()
            {
            }

            public DetalleCortesAeropuerto(int corte, int tipopago, decimal monto)
            {
                this.Corte = corte;
                this.TipoPago = tipopago;
                this.Monto = monto;
            }

            private int _Corte;
            public int Corte
            {
                get { return _Corte; }
                set { _Corte = value; }
            }

            private int _TipoPago;
            public int TipoPago
            {
                get { return _TipoPago; }
                set { _TipoPago = value; }
            }

            private decimal _Monto;
            public decimal Monto
            {
                get { return _Monto; }
                set { _Monto = value; }
            }

            public int Create()
            {
                Hashtable m_params = new Hashtable();
                m_params.Add("Corte", this.Corte);
                m_params.Add("TipoPago", this.TipoPago);
                m_params.Add("Monto", this.Monto);

                return DB.InsertRow("DetalleCortesAeropuerto", m_params);
            } // End Create

            public static List<DetalleCortesAeropuerto> Read()
            {
                List<DetalleCortesAeropuerto> list = new List<DetalleCortesAeropuerto>();
                DataTable dt = DB.Select("DetalleCortesAeropuerto");
                foreach (DataRow dr in dt.Rows)
                {
                    list.Add(new DetalleCortesAeropuerto(Convert.ToInt32(dr["Corte"]), Convert.ToInt32(dr["TipoPago"]), Convert.ToDecimal(dr["Monto"])));
                }

                return list;
            } // End Read

            public int Update()
            {
                Hashtable m_params = new Hashtable();
                Hashtable w_params = new Hashtable();
                m_params.Add("Corte", this.Corte);
                m_params.Add("TipoPago", this.TipoPago);
                m_params.Add("Monto", this.Monto);

                return DB.UpdateRow("DetalleCortesAeropuerto", m_params, w_params);
            } // End Update

            public int Delete()
            {
                Hashtable w_params = new Hashtable();

                return DB.DeleteRow("DetalleCortesAeropuerto", w_params);
            } // End Delete

        } //End Class DetalleCortesAeropuerto

        public class DetalleZonasEbssa
        {

            public DetalleZonasEbssa()
            {
            }

            public DetalleZonasEbssa(int zonaaeropuertolocal, int zonaebssa)
            {
                this.ZonaAeropuertoLocal = zonaaeropuertolocal;
                this.ZonaEbssa = zonaebssa;
            }

            private int _ZonaAeropuertoLocal;
            public int ZonaAeropuertoLocal
            {
                get { return _ZonaAeropuertoLocal; }
                set { _ZonaAeropuertoLocal = value; }
            }

            private int _ZonaEbssa;
            public int ZonaEbssa
            {
                get { return _ZonaEbssa; }
                set { _ZonaEbssa = value; }
            }

            public int Create()
            {
                Hashtable m_params = new Hashtable();
                m_params.Add("ZonaAeropuertoLocal", this.ZonaAeropuertoLocal);
                m_params.Add("ZonaEbssa", this.ZonaEbssa);

                return DB.InsertRow("DetalleZonasEbssa", m_params);
            } // End Create

            public static List<DetalleZonasEbssa> Read()
            {
                List<DetalleZonasEbssa> list = new List<DetalleZonasEbssa>();
                DataTable dt = DB.Select("DetalleZonasEbssa");
                foreach (DataRow dr in dt.Rows)
                {
                    list.Add(new DetalleZonasEbssa(Convert.ToInt32(dr["ZonaAeropuertoLocal"]), Convert.ToInt32(dr["ZonaEbssa"])));
                }

                return list;
            } // End Read

            public static DetalleZonasEbssa Read(int zonaaeropuertolocal, int zonaebssa)
            {
                Hashtable w_params = new Hashtable();
                w_params.Add("ZonaAeropuertoLocal", zonaaeropuertolocal);
                w_params.Add("ZonaEbssa", zonaebssa);
                DataTable dt = DB.Select("DetalleZonasEbssa", w_params);
                if (dt.Rows.Count == 0)
                {
                    throw new Exception("No existe DetalleZonasEbssa con los criterios de búsqueda especificados.");
                }
                DataRow dr = dt.Rows[0];
                return new DetalleZonasEbssa(Convert.ToInt32(dr["ZonaAeropuertoLocal"]), Convert.ToInt32(dr["ZonaEbssa"]));
            } // End Read

            public int Update()
            {
                Hashtable m_params = new Hashtable();
                Hashtable w_params = new Hashtable();
                w_params.Add("ZonaAeropuertoLocal", this.ZonaAeropuertoLocal);
                w_params.Add("ZonaEbssa", this.ZonaEbssa);

                return DB.UpdateRow("DetalleZonasEbssa", m_params, w_params);
            } // End Update

            public int Delete()
            {
                Hashtable w_params = new Hashtable();
                w_params.Add("ZonaAeropuertoLocal", this.ZonaAeropuertoLocal);
                w_params.Add("ZonaEbssa", this.ZonaEbssa);

                return DB.DeleteRow("DetalleZonasEbssa", w_params);
            } // End Delete

        } //End Class DetalleZonasEbssa

        public class DiasDeSemana
        {

            public DiasDeSemana()
            {
            }

            public DiasDeSemana(int? numero, string diasemana)
            {
                this.Numero = numero;
                this.DiaSemana = diasemana;
            }

            private int? _Numero;
            public int? Numero
            {
                get { return _Numero; }
                set { _Numero = value; }
            }

            private string _DiaSemana;
            public string DiaSemana
            {
                get { return _DiaSemana; }
                set { _DiaSemana = value; }
            }

            public int Create()
            {
                Hashtable m_params = new Hashtable();
                if (!AppHelper.IsNullOrEmpty(this.Numero)) m_params.Add("Numero", this.Numero);
                if (!AppHelper.IsNullOrEmpty(this.DiaSemana)) m_params.Add("DiaSemana", this.DiaSemana);

                return DB.InsertRow("DiasDeSemana", m_params);
            } // End Create

            public static List<DiasDeSemana> Read()
            {
                List<DiasDeSemana> list = new List<DiasDeSemana>();
                DataTable dt = DB.Select("DiasDeSemana");
                foreach (DataRow dr in dt.Rows)
                {
                    list.Add(new DiasDeSemana(DB.GetNullableInt32(dr["Numero"]), Convert.ToString(dr["DiaSemana"])));
                }

                return list;
            } // End Read

            public int Update()
            {
                Hashtable m_params = new Hashtable();
                Hashtable w_params = new Hashtable();
                if (!AppHelper.IsNullOrEmpty(this.Numero)) m_params.Add("Numero", this.Numero);
                if (!AppHelper.IsNullOrEmpty(this.DiaSemana)) m_params.Add("DiaSemana", this.DiaSemana);

                return DB.UpdateRow("DiasDeSemana", m_params, w_params);
            } // End Update

            public int Delete()
            {
                Hashtable w_params = new Hashtable();

                return DB.DeleteRow("DiasDeSemana", w_params);
            } // End Delete

        } //End Class DiasDeSemana

        public class DireccionCajaGeneral
        {

            public DireccionCajaGeneral()
            {
            }

            public DireccionCajaGeneral(string dirmac)
            {
                this.DirMac = dirmac;
            }

            private string _DirMac;
            public string DirMac
            {
                get { return _DirMac; }
                set { _DirMac = value; }
            }

            public int Create()
            {
                Hashtable m_params = new Hashtable();
                if (!AppHelper.IsNullOrEmpty(this.DirMac)) m_params.Add("DirMac", this.DirMac);

                return DB.InsertRow("DireccionCajaGeneral", m_params);
            } // End Create

            public static List<DireccionCajaGeneral> Read()
            {
                List<DireccionCajaGeneral> list = new List<DireccionCajaGeneral>();
                DataTable dt = DB.Select("DireccionCajaGeneral");
                foreach (DataRow dr in dt.Rows)
                {
                    list.Add(new DireccionCajaGeneral(Convert.ToString(dr["DirMac"])));
                }

                return list;
            } // End Read

            public int Update()
            {
                Hashtable m_params = new Hashtable();
                Hashtable w_params = new Hashtable();
                if (!AppHelper.IsNullOrEmpty(this.DirMac)) m_params.Add("DirMac", this.DirMac);

                return DB.UpdateRow("DireccionCajaGeneral", m_params, w_params);
            } // End Update

            public int Delete()
            {
                Hashtable w_params = new Hashtable();

                return DB.DeleteRow("DireccionCajaGeneral", w_params);
            } // End Delete

        } //End Class DireccionCajaGeneral

        public class Empleados
        {

            public Empleados()
            {
            }

            public Empleados(int folio, string nombre, string apellidopaterno, string apellidomaterno, string calle, string numerocasa, string colonia, string municipio, string estado, string telefono, string celular, string otro, string correoelectronico)
            {
                this.Folio = folio;
                this.Nombre = nombre;
                this.ApellidoPaterno = apellidopaterno;
                this.ApellidoMaterno = apellidomaterno;
                this.Calle = calle;
                this.NumeroCasa = numerocasa;
                this.Colonia = colonia;
                this.Municipio = municipio;
                this.Estado = estado;
                this.Telefono = telefono;
                this.Celular = celular;
                this.Otro = otro;
                this.CorreoElectronico = correoelectronico;
            }

            private int _Folio;
            public int Folio
            {
                get { return _Folio; }
                set { _Folio = value; }
            }

            private string _Nombre;
            public string Nombre
            {
                get { return _Nombre; }
                set { _Nombre = value; }
            }

            private string _ApellidoPaterno;
            public string ApellidoPaterno
            {
                get { return _ApellidoPaterno; }
                set { _ApellidoPaterno = value; }
            }

            private string _ApellidoMaterno;
            public string ApellidoMaterno
            {
                get { return _ApellidoMaterno; }
                set { _ApellidoMaterno = value; }
            }

            private string _Calle;
            public string Calle
            {
                get { return _Calle; }
                set { _Calle = value; }
            }

            private string _NumeroCasa;
            public string NumeroCasa
            {
                get { return _NumeroCasa; }
                set { _NumeroCasa = value; }
            }

            private string _Colonia;
            public string Colonia
            {
                get { return _Colonia; }
                set { _Colonia = value; }
            }

            private string _Municipio;
            public string Municipio
            {
                get { return _Municipio; }
                set { _Municipio = value; }
            }

            private string _Estado;
            public string Estado
            {
                get { return _Estado; }
                set { _Estado = value; }
            }

            private string _Telefono;
            public string Telefono
            {
                get { return _Telefono; }
                set { _Telefono = value; }
            }

            private string _Celular;
            public string Celular
            {
                get { return _Celular; }
                set { _Celular = value; }
            }

            private string _Otro;
            public string Otro
            {
                get { return _Otro; }
                set { _Otro = value; }
            }

            private string _CorreoElectronico;
            public string CorreoElectronico
            {
                get { return _CorreoElectronico; }
                set { _CorreoElectronico = value; }
            }

            public int Create()
            {
                Hashtable m_params = new Hashtable();
                m_params.Add("Folio", this.Folio);
                m_params.Add("Nombre", this.Nombre);
                m_params.Add("ApellidoPaterno", this.ApellidoPaterno);
                m_params.Add("ApellidoMaterno", this.ApellidoMaterno);
                m_params.Add("Calle", this.Calle);
                m_params.Add("NumeroCasa", this.NumeroCasa);
                m_params.Add("Colonia", this.Colonia);
                m_params.Add("Municipio", this.Municipio);
                m_params.Add("Estado", this.Estado);
                if (!AppHelper.IsNullOrEmpty(this.Telefono)) m_params.Add("Telefono", this.Telefono);
                if (!AppHelper.IsNullOrEmpty(this.Celular)) m_params.Add("Celular", this.Celular);
                if (!AppHelper.IsNullOrEmpty(this.Otro)) m_params.Add("Otro", this.Otro);
                if (!AppHelper.IsNullOrEmpty(this.CorreoElectronico)) m_params.Add("CorreoElectronico", this.CorreoElectronico);

                return DB.InsertRow("Empleados", m_params);
            } // End Create

            public static List<Empleados> Read()
            {
                List<Empleados> list = new List<Empleados>();
                DataTable dt = DB.Select("Empleados");
                foreach (DataRow dr in dt.Rows)
                {
                    list.Add(new Empleados(Convert.ToInt32(dr["Folio"]), Convert.ToString(dr["Nombre"]), Convert.ToString(dr["ApellidoPaterno"]), Convert.ToString(dr["ApellidoMaterno"]), Convert.ToString(dr["Calle"]), Convert.ToString(dr["NumeroCasa"]), Convert.ToString(dr["Colonia"]), Convert.ToString(dr["Municipio"]), Convert.ToString(dr["Estado"]), Convert.ToString(dr["Telefono"]), Convert.ToString(dr["Celular"]), Convert.ToString(dr["Otro"]), Convert.ToString(dr["CorreoElectronico"])));
                }

                return list;
            } // End Read

            public int Update()
            {
                Hashtable m_params = new Hashtable();
                Hashtable w_params = new Hashtable();
                m_params.Add("Folio", this.Folio);
                m_params.Add("Nombre", this.Nombre);
                m_params.Add("ApellidoPaterno", this.ApellidoPaterno);
                m_params.Add("ApellidoMaterno", this.ApellidoMaterno);
                m_params.Add("Calle", this.Calle);
                m_params.Add("NumeroCasa", this.NumeroCasa);
                m_params.Add("Colonia", this.Colonia);
                m_params.Add("Municipio", this.Municipio);
                m_params.Add("Estado", this.Estado);
                if (!AppHelper.IsNullOrEmpty(this.Telefono)) m_params.Add("Telefono", this.Telefono);
                if (!AppHelper.IsNullOrEmpty(this.Celular)) m_params.Add("Celular", this.Celular);
                if (!AppHelper.IsNullOrEmpty(this.Otro)) m_params.Add("Otro", this.Otro);
                if (!AppHelper.IsNullOrEmpty(this.CorreoElectronico)) m_params.Add("CorreoElectronico", this.CorreoElectronico);

                return DB.UpdateRow("Empleados", m_params, w_params);
            } // End Update

            public int Delete()
            {
                Hashtable w_params = new Hashtable();

                return DB.DeleteRow("Empleados", w_params);
            } // End Delete

        } //End Class Empleados

        public class Empresas
        {

            public Empresas()
            {
            }

            public Empresas(int folio, int subsistema, string rfc, string razonsocial, string calle, string numero, string colonia, string municipio, string estado, string cp, string telefonoatencionaclientes, int status, string paginaweb, string correoelectronico)
            {
                this.Folio = folio;
                this.Subsistema = subsistema;
                this.Rfc = rfc;
                this.RazonSocial = razonsocial;
                this.Calle = calle;
                this.Numero = numero;
                this.Colonia = colonia;
                this.Municipio = municipio;
                this.Estado = estado;
                this.CP = cp;
                this.TelefonoAtencionAClientes = telefonoatencionaclientes;
                this.Status = status;
                this.PaginaWeb = paginaweb;
                this.CorreoElectronico = correoelectronico;
            }

            private int _Folio;
            public int Folio
            {
                get { return _Folio; }
                set { _Folio = value; }
            }

            private int _Subsistema;
            public int Subsistema
            {
                get { return _Subsistema; }
                set { _Subsistema = value; }
            }

            private string _Rfc;
            public string Rfc
            {
                get { return _Rfc; }
                set { _Rfc = value; }
            }

            private string _RazonSocial;
            public string RazonSocial
            {
                get { return _RazonSocial; }
                set { _RazonSocial = value; }
            }

            private string _Calle;
            public string Calle
            {
                get { return _Calle; }
                set { _Calle = value; }
            }

            private string _Numero;
            public string Numero
            {
                get { return _Numero; }
                set { _Numero = value; }
            }

            private string _Colonia;
            public string Colonia
            {
                get { return _Colonia; }
                set { _Colonia = value; }
            }

            private string _Municipio;
            public string Municipio
            {
                get { return _Municipio; }
                set { _Municipio = value; }
            }

            private string _Estado;
            public string Estado
            {
                get { return _Estado; }
                set { _Estado = value; }
            }

            private string _CP;
            public string CP
            {
                get { return _CP; }
                set { _CP = value; }
            }

            private string _TelefonoAtencionAClientes;
            public string TelefonoAtencionAClientes
            {
                get { return _TelefonoAtencionAClientes; }
                set { _TelefonoAtencionAClientes = value; }
            }

            private int _Status;
            public int Status
            {
                get { return _Status; }
                set { _Status = value; }
            }

            private string _PaginaWeb;
            public string PaginaWeb
            {
                get { return _PaginaWeb; }
                set { _PaginaWeb = value; }
            }

            private string _CorreoElectronico;
            public string CorreoElectronico
            {
                get { return _CorreoElectronico; }
                set { _CorreoElectronico = value; }
            }

            public int Create()
            {
                Hashtable m_params = new Hashtable();
                m_params.Add("Subsistema", this.Subsistema);
                m_params.Add("Rfc", this.Rfc);
                m_params.Add("RazonSocial", this.RazonSocial);
                if (!AppHelper.IsNullOrEmpty(this.Calle)) m_params.Add("Calle", this.Calle);
                if (!AppHelper.IsNullOrEmpty(this.Numero)) m_params.Add("Numero", this.Numero);
                if (!AppHelper.IsNullOrEmpty(this.Colonia)) m_params.Add("Colonia", this.Colonia);
                if (!AppHelper.IsNullOrEmpty(this.Municipio)) m_params.Add("Municipio", this.Municipio);
                if (!AppHelper.IsNullOrEmpty(this.Estado)) m_params.Add("Estado", this.Estado);
                if (!AppHelper.IsNullOrEmpty(this.CP)) m_params.Add("CP", this.CP);
                if (!AppHelper.IsNullOrEmpty(this.TelefonoAtencionAClientes)) m_params.Add("TelefonoAtencionAClientes", this.TelefonoAtencionAClientes);
                m_params.Add("Status", this.Status);
                if (!AppHelper.IsNullOrEmpty(this.PaginaWeb)) m_params.Add("PaginaWeb", this.PaginaWeb);
                if (!AppHelper.IsNullOrEmpty(this.CorreoElectronico)) m_params.Add("CorreoElectronico", this.CorreoElectronico);

                return DB.InsertRow("Empresas", m_params);
            } // End Create

            public static List<Empresas> Read()
            {
                List<Empresas> list = new List<Empresas>();
                DataTable dt = DB.Select("Empresas");
                foreach (DataRow dr in dt.Rows)
                {
                    list.Add(new Empresas(Convert.ToInt32(dr["Folio"]), Convert.ToInt32(dr["Subsistema"]), Convert.ToString(dr["Rfc"]), Convert.ToString(dr["RazonSocial"]), Convert.ToString(dr["Calle"]), Convert.ToString(dr["Numero"]), Convert.ToString(dr["Colonia"]), Convert.ToString(dr["Municipio"]), Convert.ToString(dr["Estado"]), Convert.ToString(dr["CP"]), Convert.ToString(dr["TelefonoAtencionAClientes"]), Convert.ToInt32(dr["Status"]), Convert.ToString(dr["PaginaWeb"]), Convert.ToString(dr["CorreoElectronico"])));
                }

                return list;
            } // End Read

            public static Empresas Read(int folio)
            {
                Hashtable w_params = new Hashtable();
                w_params.Add("Folio", folio);
                DataTable dt = DB.Select("Empresas", w_params);
                if (dt.Rows.Count == 0)
                {
                    throw new Exception("No existe Empresas con los criterios de búsqueda especificados.");
                }
                DataRow dr = dt.Rows[0];
                return new Empresas(Convert.ToInt32(dr["Folio"]), Convert.ToInt32(dr["Subsistema"]), Convert.ToString(dr["Rfc"]), Convert.ToString(dr["RazonSocial"]), Convert.ToString(dr["Calle"]), Convert.ToString(dr["Numero"]), Convert.ToString(dr["Colonia"]), Convert.ToString(dr["Municipio"]), Convert.ToString(dr["Estado"]), Convert.ToString(dr["CP"]), Convert.ToString(dr["TelefonoAtencionAClientes"]), Convert.ToInt32(dr["Status"]), Convert.ToString(dr["PaginaWeb"]), Convert.ToString(dr["CorreoElectronico"]));
            } // End Read

            public int Update()
            {
                Hashtable m_params = new Hashtable();
                Hashtable w_params = new Hashtable();
                w_params.Add("Folio", this.Folio);
                m_params.Add("Subsistema", this.Subsistema);
                m_params.Add("Rfc", this.Rfc);
                m_params.Add("RazonSocial", this.RazonSocial);
                if (!AppHelper.IsNullOrEmpty(this.Calle)) m_params.Add("Calle", this.Calle);
                if (!AppHelper.IsNullOrEmpty(this.Numero)) m_params.Add("Numero", this.Numero);
                if (!AppHelper.IsNullOrEmpty(this.Colonia)) m_params.Add("Colonia", this.Colonia);
                if (!AppHelper.IsNullOrEmpty(this.Municipio)) m_params.Add("Municipio", this.Municipio);
                if (!AppHelper.IsNullOrEmpty(this.Estado)) m_params.Add("Estado", this.Estado);
                if (!AppHelper.IsNullOrEmpty(this.CP)) m_params.Add("CP", this.CP);
                if (!AppHelper.IsNullOrEmpty(this.TelefonoAtencionAClientes)) m_params.Add("TelefonoAtencionAClientes", this.TelefonoAtencionAClientes);
                m_params.Add("Status", this.Status);
                if (!AppHelper.IsNullOrEmpty(this.PaginaWeb)) m_params.Add("PaginaWeb", this.PaginaWeb);
                if (!AppHelper.IsNullOrEmpty(this.CorreoElectronico)) m_params.Add("CorreoElectronico", this.CorreoElectronico);

                return DB.UpdateRow("Empresas", m_params, w_params);
            } // End Update

            public int Delete()
            {
                Hashtable w_params = new Hashtable();
                w_params.Add("Folio", this.Folio);

                return DB.DeleteRow("Empresas", w_params);
            } // End Delete

        } //End Class Empresas

        public class EmpresasStatusConductores
        {

            public EmpresasStatusConductores()
            {
            }

            public EmpresasStatusConductores(int empresa, int conductor, int status)
            {
                this.Empresa = empresa;
                this.Conductor = conductor;
                this.Status = status;
            }

            private int _Empresa;
            public int Empresa
            {
                get { return _Empresa; }
                set { _Empresa = value; }
            }

            private int _Conductor;
            public int Conductor
            {
                get { return _Conductor; }
                set { _Conductor = value; }
            }

            private int _Status;
            public int Status
            {
                get { return _Status; }
                set { _Status = value; }
            }

            public int Create()
            {
                Hashtable m_params = new Hashtable();
                m_params.Add("Empresa", this.Empresa);
                m_params.Add("Conductor", this.Conductor);
                m_params.Add("Status", this.Status);

                return DB.InsertRow("EmpresasStatusConductores", m_params);
            } // End Create

            public static List<EmpresasStatusConductores> Read()
            {
                List<EmpresasStatusConductores> list = new List<EmpresasStatusConductores>();
                DataTable dt = DB.Select("EmpresasStatusConductores");
                foreach (DataRow dr in dt.Rows)
                {
                    list.Add(new EmpresasStatusConductores(Convert.ToInt32(dr["Empresa"]), Convert.ToInt32(dr["Conductor"]), Convert.ToInt32(dr["Status"])));
                }

                return list;
            } // End Read

            public int Update()
            {
                Hashtable m_params = new Hashtable();
                Hashtable w_params = new Hashtable();
                m_params.Add("Empresa", this.Empresa);
                m_params.Add("Conductor", this.Conductor);
                m_params.Add("Status", this.Status);

                return DB.UpdateRow("EmpresasStatusConductores", m_params, w_params);
            } // End Update

            public int Delete()
            {
                Hashtable w_params = new Hashtable();

                return DB.DeleteRow("EmpresasStatusConductores", w_params);
            } // End Delete

        } //End Class EmpresasStatusConductores

        public class EmpresasStatusUnidades
        {

            public EmpresasStatusUnidades()
            {
            }

            public EmpresasStatusUnidades(int empresa, int unidad, int status)
            {
                this.Empresa = empresa;
                this.Unidad = unidad;
                this.Status = status;
            }

            private int _Empresa;
            public int Empresa
            {
                get { return _Empresa; }
                set { _Empresa = value; }
            }

            private int _Unidad;
            public int Unidad
            {
                get { return _Unidad; }
                set { _Unidad = value; }
            }

            private int _Status;
            public int Status
            {
                get { return _Status; }
                set { _Status = value; }
            }

            public int Create()
            {
                Hashtable m_params = new Hashtable();
                m_params.Add("Empresa", this.Empresa);
                m_params.Add("Unidad", this.Unidad);
                m_params.Add("Status", this.Status);

                return DB.InsertRow("EmpresasStatusUnidades", m_params);
            } // End Create

            public static List<EmpresasStatusUnidades> Read()
            {
                List<EmpresasStatusUnidades> list = new List<EmpresasStatusUnidades>();
                DataTable dt = DB.Select("EmpresasStatusUnidades");
                foreach (DataRow dr in dt.Rows)
                {
                    list.Add(new EmpresasStatusUnidades(Convert.ToInt32(dr["Empresa"]), Convert.ToInt32(dr["Unidad"]), Convert.ToInt32(dr["Status"])));
                }

                return list;
            } // End Read

            public int Update()
            {
                Hashtable m_params = new Hashtable();
                Hashtable w_params = new Hashtable();
                m_params.Add("Empresa", this.Empresa);
                m_params.Add("Unidad", this.Unidad);
                m_params.Add("Status", this.Status);

                return DB.UpdateRow("EmpresasStatusUnidades", m_params, w_params);
            } // End Update

            public int Delete()
            {
                Hashtable w_params = new Hashtable();

                return DB.DeleteRow("EmpresasStatusUnidades", w_params);
            } // End Delete

        } //End Class EmpresasStatusUnidades

        public class EntregaBoletos
        {

            public EntregaBoletos()
            {
            }

            public EntregaBoletos(string boleto, string usuario, DateTime? fecha)
            {
                this.Boleto = boleto;
                this.Usuario = usuario;
                this.Fecha = fecha;
            }

            private string _Boleto;
            public string Boleto
            {
                get { return _Boleto; }
                set { _Boleto = value; }
            }

            private string _Usuario;
            public string Usuario
            {
                get { return _Usuario; }
                set { _Usuario = value; }
            }

            private DateTime? _Fecha;
            public DateTime? Fecha
            {
                get { return _Fecha; }
                set { _Fecha = value; }
            }

            public int Create()
            {
                Hashtable m_params = new Hashtable();
                if (!AppHelper.IsNullOrEmpty(this.Boleto)) m_params.Add("Boleto", this.Boleto);
                if (!AppHelper.IsNullOrEmpty(this.Usuario)) m_params.Add("Usuario", this.Usuario);
                if (!AppHelper.IsNullOrEmpty(this.Fecha)) m_params.Add("Fecha", this.Fecha);

                return DB.InsertRow("EntregaBoletos", m_params);
            } // End Create

            public static List<EntregaBoletos> Read()
            {
                List<EntregaBoletos> list = new List<EntregaBoletos>();
                DataTable dt = DB.Select("EntregaBoletos");
                foreach (DataRow dr in dt.Rows)
                {
                    list.Add(new EntregaBoletos(Convert.ToString(dr["Boleto"]), Convert.ToString(dr["Usuario"]), DB.GetNullableDateTime(dr["Fecha"])));
                }

                return list;
            } // End Read

            public int Update()
            {
                Hashtable m_params = new Hashtable();
                Hashtable w_params = new Hashtable();
                if (!AppHelper.IsNullOrEmpty(this.Boleto)) m_params.Add("Boleto", this.Boleto);
                if (!AppHelper.IsNullOrEmpty(this.Usuario)) m_params.Add("Usuario", this.Usuario);
                if (!AppHelper.IsNullOrEmpty(this.Fecha)) m_params.Add("Fecha", this.Fecha);

                return DB.UpdateRow("EntregaBoletos", m_params, w_params);
            } // End Update

            public int Delete()
            {
                Hashtable w_params = new Hashtable();

                return DB.DeleteRow("EntregaBoletos", w_params);
            } // End Delete

        } //End Class EntregaBoletos

        public class Estados_PlanesDePagos
        {

            public Estados_PlanesDePagos()
            {
            }

            public Estados_PlanesDePagos(int estado_plandepagoid, string nombre)
            {
                this.Estado_PlanDePagoID = estado_plandepagoid;
                this.Nombre = nombre;
            }

            private int _Estado_PlanDePagoID;
            public int Estado_PlanDePagoID
            {
                get { return _Estado_PlanDePagoID; }
                set { _Estado_PlanDePagoID = value; }
            }

            private string _Nombre;
            public string Nombre
            {
                get { return _Nombre; }
                set { _Nombre = value; }
            }

            public int Create()
            {
                Hashtable m_params = new Hashtable();
                m_params.Add("Nombre", this.Nombre);

                return DB.InsertRow("Estados_PlanesDePagos", m_params);
            } // End Create

            public static List<Estados_PlanesDePagos> Read()
            {
                List<Estados_PlanesDePagos> list = new List<Estados_PlanesDePagos>();
                DataTable dt = DB.Select("Estados_PlanesDePagos");
                foreach (DataRow dr in dt.Rows)
                {
                    list.Add(new Estados_PlanesDePagos(Convert.ToInt32(dr["Estado_PlanDePagoID"]), Convert.ToString(dr["Nombre"])));
                }

                return list;
            } // End Read

            public static Estados_PlanesDePagos Read(int estado_plandepagoid)
            {
                Hashtable w_params = new Hashtable();
                w_params.Add("Estado_PlanDePagoID", estado_plandepagoid);
                DataTable dt = DB.Select("Estados_PlanesDePagos", w_params);
                if (dt.Rows.Count == 0)
                {
                    throw new Exception("No existe Estados_PlanesDePagos con los criterios de búsqueda especificados.");
                }
                DataRow dr = dt.Rows[0];
                return new Estados_PlanesDePagos(Convert.ToInt32(dr["Estado_PlanDePagoID"]), Convert.ToString(dr["Nombre"]));
            } // End Read

            public int Update()
            {
                Hashtable m_params = new Hashtable();
                Hashtable w_params = new Hashtable();
                w_params.Add("Estado_PlanDePagoID", this.Estado_PlanDePagoID);
                m_params.Add("Nombre", this.Nombre);

                return DB.UpdateRow("Estados_PlanesDePagos", m_params, w_params);
            } // End Update

            public int Delete()
            {
                Hashtable w_params = new Hashtable();
                w_params.Add("Estado_PlanDePagoID", this.Estado_PlanDePagoID);

                return DB.DeleteRow("Estados_PlanesDePagos", w_params);
            } // End Delete

        } //End Class Estados_PlanesDePagos

        public class FondosCajas
        {

            public FondosCajas()
            {
            }

            public FondosCajas(int folio, string descripcion, bool? saldorojo, bool? fondo, bool? retiro, bool? transferenciaorigen, bool? transferenciadestino)
            {
                this.Folio = folio;
                this.Descripcion = descripcion;
                this.SaldoRojo = saldorojo;
                this.Fondo = fondo;
                this.Retiro = retiro;
                this.TransferenciaOrigen = transferenciaorigen;
                this.TransferenciaDestino = transferenciadestino;
            }

            private int _Folio;
            public int Folio
            {
                get { return _Folio; }
                set { _Folio = value; }
            }

            private string _Descripcion;
            public string Descripcion
            {
                get { return _Descripcion; }
                set { _Descripcion = value; }
            }

            private bool? _SaldoRojo;
            public bool? SaldoRojo
            {
                get { return _SaldoRojo; }
                set { _SaldoRojo = value; }
            }

            private bool? _Fondo;
            public bool? Fondo
            {
                get { return _Fondo; }
                set { _Fondo = value; }
            }

            private bool? _Retiro;
            public bool? Retiro
            {
                get { return _Retiro; }
                set { _Retiro = value; }
            }

            private bool? _TransferenciaOrigen;
            public bool? TransferenciaOrigen
            {
                get { return _TransferenciaOrigen; }
                set { _TransferenciaOrigen = value; }
            }

            private bool? _TransferenciaDestino;
            public bool? TransferenciaDestino
            {
                get { return _TransferenciaDestino; }
                set { _TransferenciaDestino = value; }
            }

            public int Create()
            {
                Hashtable m_params = new Hashtable();
                if (!AppHelper.IsNullOrEmpty(this.Descripcion)) m_params.Add("Descripcion", this.Descripcion);
                if (!AppHelper.IsNullOrEmpty(this.SaldoRojo)) m_params.Add("SaldoRojo", this.SaldoRojo);
                if (!AppHelper.IsNullOrEmpty(this.Fondo)) m_params.Add("Fondo", this.Fondo);
                if (!AppHelper.IsNullOrEmpty(this.Retiro)) m_params.Add("Retiro", this.Retiro);
                if (!AppHelper.IsNullOrEmpty(this.TransferenciaOrigen)) m_params.Add("TransferenciaOrigen", this.TransferenciaOrigen);
                if (!AppHelper.IsNullOrEmpty(this.TransferenciaDestino)) m_params.Add("TransferenciaDestino", this.TransferenciaDestino);

                return DB.InsertRow("FondosCajas", m_params);
            } // End Create

            public static List<FondosCajas> Read()
            {
                List<FondosCajas> list = new List<FondosCajas>();
                DataTable dt = DB.Select("FondosCajas");
                foreach (DataRow dr in dt.Rows)
                {
                    list.Add(new FondosCajas(Convert.ToInt32(dr["Folio"]), Convert.ToString(dr["Descripcion"]), DB.GetNullableBoolean(dr["SaldoRojo"]), DB.GetNullableBoolean(dr["Fondo"]), DB.GetNullableBoolean(dr["Retiro"]), DB.GetNullableBoolean(dr["TransferenciaOrigen"]), DB.GetNullableBoolean(dr["TransferenciaDestino"])));
                }

                return list;
            } // End Read

            public static FondosCajas Read(int folio)
            {
                Hashtable w_params = new Hashtable();
                w_params.Add("Folio", folio);
                DataTable dt = DB.Select("FondosCajas", w_params);
                if (dt.Rows.Count == 0)
                {
                    throw new Exception("No existe FondosCajas con los criterios de búsqueda especificados.");
                }
                DataRow dr = dt.Rows[0];
                return new FondosCajas(Convert.ToInt32(dr["Folio"]), Convert.ToString(dr["Descripcion"]), DB.GetNullableBoolean(dr["SaldoRojo"]), DB.GetNullableBoolean(dr["Fondo"]), DB.GetNullableBoolean(dr["Retiro"]), DB.GetNullableBoolean(dr["TransferenciaOrigen"]), DB.GetNullableBoolean(dr["TransferenciaDestino"]));
            } // End Read

            public int Update()
            {
                Hashtable m_params = new Hashtable();
                Hashtable w_params = new Hashtable();
                w_params.Add("Folio", this.Folio);
                if (!AppHelper.IsNullOrEmpty(this.Descripcion)) m_params.Add("Descripcion", this.Descripcion);
                if (!AppHelper.IsNullOrEmpty(this.SaldoRojo)) m_params.Add("SaldoRojo", this.SaldoRojo);
                if (!AppHelper.IsNullOrEmpty(this.Fondo)) m_params.Add("Fondo", this.Fondo);
                if (!AppHelper.IsNullOrEmpty(this.Retiro)) m_params.Add("Retiro", this.Retiro);
                if (!AppHelper.IsNullOrEmpty(this.TransferenciaOrigen)) m_params.Add("TransferenciaOrigen", this.TransferenciaOrigen);
                if (!AppHelper.IsNullOrEmpty(this.TransferenciaDestino)) m_params.Add("TransferenciaDestino", this.TransferenciaDestino);

                return DB.UpdateRow("FondosCajas", m_params, w_params);
            } // End Update

            public int Delete()
            {
                Hashtable w_params = new Hashtable();
                w_params.Add("Folio", this.Folio);

                return DB.DeleteRow("FondosCajas", w_params);
            } // End Delete

        } //End Class FondosCajas

        public class Incidencias
        {

            public Incidencias()
            {
            }

            public Incidencias(int folio, int unidad, int conductor, DateTime fecha, string hora, string tomareporte, string cliente, string colonia, string situacion, string responsable, string empresasoluciona, string solucion, decimal? costo, bool pagada, string usuario)
            {
                this.Folio = folio;
                this.Unidad = unidad;
                this.Conductor = conductor;
                this.Fecha = fecha;
                this.Hora = hora;
                this.TomaReporte = tomareporte;
                this.Cliente = cliente;
                this.Colonia = colonia;
                this.Situacion = situacion;
                this.Responsable = responsable;
                this.EmpresaSoluciona = empresasoluciona;
                this.Solucion = solucion;
                this.Costo = costo;
                this.Pagada = pagada;
                this.Usuario = usuario;
            }

            private int _Folio;
            public int Folio
            {
                get { return _Folio; }
                set { _Folio = value; }
            }

            private int _Unidad;
            public int Unidad
            {
                get { return _Unidad; }
                set { _Unidad = value; }
            }

            private int _Conductor;
            public int Conductor
            {
                get { return _Conductor; }
                set { _Conductor = value; }
            }

            private DateTime _Fecha;
            public DateTime Fecha
            {
                get { return _Fecha; }
                set { _Fecha = value; }
            }

            private string _Hora;
            public string Hora
            {
                get { return _Hora; }
                set { _Hora = value; }
            }

            private string _TomaReporte;
            public string TomaReporte
            {
                get { return _TomaReporte; }
                set { _TomaReporte = value; }
            }

            private string _Cliente;
            public string Cliente
            {
                get { return _Cliente; }
                set { _Cliente = value; }
            }

            private string _Colonia;
            public string Colonia
            {
                get { return _Colonia; }
                set { _Colonia = value; }
            }

            private string _Situacion;
            public string Situacion
            {
                get { return _Situacion; }
                set { _Situacion = value; }
            }

            private string _Responsable;
            public string Responsable
            {
                get { return _Responsable; }
                set { _Responsable = value; }
            }

            private string _EmpresaSoluciona;
            public string EmpresaSoluciona
            {
                get { return _EmpresaSoluciona; }
                set { _EmpresaSoluciona = value; }
            }

            private string _Solucion;
            public string Solucion
            {
                get { return _Solucion; }
                set { _Solucion = value; }
            }

            private decimal? _Costo;
            public decimal? Costo
            {
                get { return _Costo; }
                set { _Costo = value; }
            }

            private bool _Pagada;
            public bool Pagada
            {
                get { return _Pagada; }
                set { _Pagada = value; }
            }

            private string _Usuario;
            public string Usuario
            {
                get { return _Usuario; }
                set { _Usuario = value; }
            }

            public int Create()
            {
                Hashtable m_params = new Hashtable();
                m_params.Add("Unidad", this.Unidad);
                m_params.Add("Conductor", this.Conductor);
                m_params.Add("Fecha", this.Fecha);
                if (!AppHelper.IsNullOrEmpty(this.Hora)) m_params.Add("Hora", this.Hora);
                if (!AppHelper.IsNullOrEmpty(this.TomaReporte)) m_params.Add("TomaReporte", this.TomaReporte);
                if (!AppHelper.IsNullOrEmpty(this.Cliente)) m_params.Add("Cliente", this.Cliente);
                if (!AppHelper.IsNullOrEmpty(this.Colonia)) m_params.Add("Colonia", this.Colonia);
                if (!AppHelper.IsNullOrEmpty(this.Situacion)) m_params.Add("Situacion", this.Situacion);
                m_params.Add("Responsable", this.Responsable);
                if (!AppHelper.IsNullOrEmpty(this.EmpresaSoluciona)) m_params.Add("EmpresaSoluciona", this.EmpresaSoluciona);
                m_params.Add("Solucion", this.Solucion);
                if (!AppHelper.IsNullOrEmpty(this.Costo)) m_params.Add("Costo", this.Costo);
                m_params.Add("Pagada", this.Pagada);
                if (!AppHelper.IsNullOrEmpty(this.Usuario)) m_params.Add("Usuario", this.Usuario);

                return DB.InsertRow("Incidencias", m_params);
            } // End Create

            public static List<Incidencias> Read()
            {
                List<Incidencias> list = new List<Incidencias>();
                DataTable dt = DB.Select("Incidencias");
                foreach (DataRow dr in dt.Rows)
                {
                    list.Add(new Incidencias(Convert.ToInt32(dr["Folio"]), Convert.ToInt32(dr["Unidad"]), Convert.ToInt32(dr["Conductor"]), Convert.ToDateTime(dr["Fecha"]), Convert.ToString(dr["Hora"]), Convert.ToString(dr["TomaReporte"]), Convert.ToString(dr["Cliente"]), Convert.ToString(dr["Colonia"]), Convert.ToString(dr["Situacion"]), Convert.ToString(dr["Responsable"]), Convert.ToString(dr["EmpresaSoluciona"]), Convert.ToString(dr["Solucion"]), DB.GetNullableDecimal(dr["Costo"]), Convert.ToBoolean(dr["Pagada"]), Convert.ToString(dr["Usuario"])));
                }

                return list;
            } // End Read

            public static Incidencias Read(int folio)
            {
                Hashtable w_params = new Hashtable();
                w_params.Add("Folio", folio);
                DataTable dt = DB.Select("Incidencias", w_params);
                if (dt.Rows.Count == 0)
                {
                    throw new Exception("No existe Incidencias con los criterios de búsqueda especificados.");
                }
                DataRow dr = dt.Rows[0];
                return new Incidencias(Convert.ToInt32(dr["Folio"]), Convert.ToInt32(dr["Unidad"]), Convert.ToInt32(dr["Conductor"]), Convert.ToDateTime(dr["Fecha"]), Convert.ToString(dr["Hora"]), Convert.ToString(dr["TomaReporte"]), Convert.ToString(dr["Cliente"]), Convert.ToString(dr["Colonia"]), Convert.ToString(dr["Situacion"]), Convert.ToString(dr["Responsable"]), Convert.ToString(dr["EmpresaSoluciona"]), Convert.ToString(dr["Solucion"]), DB.GetNullableDecimal(dr["Costo"]), Convert.ToBoolean(dr["Pagada"]), Convert.ToString(dr["Usuario"]));
            } // End Read

            public int Update()
            {
                Hashtable m_params = new Hashtable();
                Hashtable w_params = new Hashtable();
                w_params.Add("Folio", this.Folio);
                m_params.Add("Unidad", this.Unidad);
                m_params.Add("Conductor", this.Conductor);
                m_params.Add("Fecha", this.Fecha);
                if (!AppHelper.IsNullOrEmpty(this.Hora)) m_params.Add("Hora", this.Hora);
                if (!AppHelper.IsNullOrEmpty(this.TomaReporte)) m_params.Add("TomaReporte", this.TomaReporte);
                if (!AppHelper.IsNullOrEmpty(this.Cliente)) m_params.Add("Cliente", this.Cliente);
                if (!AppHelper.IsNullOrEmpty(this.Colonia)) m_params.Add("Colonia", this.Colonia);
                if (!AppHelper.IsNullOrEmpty(this.Situacion)) m_params.Add("Situacion", this.Situacion);
                m_params.Add("Responsable", this.Responsable);
                if (!AppHelper.IsNullOrEmpty(this.EmpresaSoluciona)) m_params.Add("EmpresaSoluciona", this.EmpresaSoluciona);
                m_params.Add("Solucion", this.Solucion);
                if (!AppHelper.IsNullOrEmpty(this.Costo)) m_params.Add("Costo", this.Costo);
                m_params.Add("Pagada", this.Pagada);
                if (!AppHelper.IsNullOrEmpty(this.Usuario)) m_params.Add("Usuario", this.Usuario);

                return DB.UpdateRow("Incidencias", m_params, w_params);
            } // End Update

            public int Delete()
            {
                Hashtable w_params = new Hashtable();
                w_params.Add("Folio", this.Folio);

                return DB.DeleteRow("Incidencias", w_params);
            } // End Delete

        } //End Class Incidencias

        public class KilometrajesUnidades
        {

            public KilometrajesUnidades()
            {
            }

            public KilometrajesUnidades(int unidad, int kilometraje, DateTime fecha)
            {
                this.Unidad = unidad;
                this.Kilometraje = kilometraje;
                this.Fecha = fecha;
            }

            private int _Unidad;
            public int Unidad
            {
                get { return _Unidad; }
                set { _Unidad = value; }
            }

            private int _Kilometraje;
            public int Kilometraje
            {
                get { return _Kilometraje; }
                set { _Kilometraje = value; }
            }

            private DateTime _Fecha;
            public DateTime Fecha
            {
                get { return _Fecha; }
                set { _Fecha = value; }
            }

            public int Create()
            {
                Hashtable m_params = new Hashtable();
                m_params.Add("Unidad", this.Unidad);
                m_params.Add("Kilometraje", this.Kilometraje);
                m_params.Add("Fecha", this.Fecha);

                return DB.InsertRow("KilometrajesUnidades", m_params);
            } // End Create

            public static List<KilometrajesUnidades> Read()
            {
                List<KilometrajesUnidades> list = new List<KilometrajesUnidades>();
                DataTable dt = DB.Select("KilometrajesUnidades");
                foreach (DataRow dr in dt.Rows)
                {
                    list.Add(new KilometrajesUnidades(Convert.ToInt32(dr["Unidad"]), Convert.ToInt32(dr["Kilometraje"]), Convert.ToDateTime(dr["Fecha"])));
                }

                return list;
            } // End Read

            public static KilometrajesUnidades Read(params KeyValuePair<string, object>[] args)
            {
                DataTable dt = DB.Read("KilometrajesUnidades", args);
                if (dt.Rows.Count == 0)
                {
                    return null;
                }
                DataRow dr = dt.Rows[0];
                return new KilometrajesUnidades(Convert.ToInt32(dr["Unidad"]), Convert.ToInt32(dr["Kilometraje"]), Convert.ToDateTime(dr["Fecha"]));
            } // End Read

            public static bool Read(out KilometrajesUnidades kilometrajesunidades, int top, string filter, string sort, params KeyValuePair<string, object>[] args)
            {
                DataTable dt = DB.Read("KilometrajesUnidades", top, filter, sort, args);
                if (dt.Rows.Count == 0)
                {
                    kilometrajesunidades = null;
                    return false;
                }
                DataRow dr = dt.Rows[0];
                kilometrajesunidades = new KilometrajesUnidades(Convert.ToInt32(dr["Unidad"]), Convert.ToInt32(dr["Kilometraje"]), Convert.ToDateTime(dr["Fecha"]));
                return true;
            } // End Read


            public int Update()
            {
                Hashtable m_params = new Hashtable();
                Hashtable w_params = new Hashtable();
                m_params.Add("Unidad", this.Unidad);
                m_params.Add("Kilometraje", this.Kilometraje);
                m_params.Add("Fecha", this.Fecha);

                return DB.UpdateRow("KilometrajesUnidades", m_params, w_params);
            } // End Update

            public int Delete()
            {
                Hashtable w_params = new Hashtable();

                return DB.DeleteRow("KilometrajesUnidades", w_params);
            } // End Delete

        } //End Class KilometrajesUnidades

        public class Km
        {

            public Km()
            {
            }

            public Km(int? unidad, int? kilometraje, string fecha, string hora)
            {
                this.Unidad = unidad;
                this.Kilometraje = kilometraje;
                this.Fecha = fecha;
                this.Hora = hora;
            }

            private int? _Unidad;
            public int? Unidad
            {
                get { return _Unidad; }
                set { _Unidad = value; }
            }

            private int? _Kilometraje;
            public int? Kilometraje
            {
                get { return _Kilometraje; }
                set { _Kilometraje = value; }
            }

            private string _Fecha;
            public string Fecha
            {
                get { return _Fecha; }
                set { _Fecha = value; }
            }

            private string _Hora;
            public string Hora
            {
                get { return _Hora; }
                set { _Hora = value; }
            }

            public int Create()
            {
                Hashtable m_params = new Hashtable();
                if (!AppHelper.IsNullOrEmpty(this.Unidad)) m_params.Add("Unidad", this.Unidad);
                if (!AppHelper.IsNullOrEmpty(this.Kilometraje)) m_params.Add("Kilometraje", this.Kilometraje);
                if (!AppHelper.IsNullOrEmpty(this.Fecha)) m_params.Add("Fecha", this.Fecha);
                if (!AppHelper.IsNullOrEmpty(this.Hora)) m_params.Add("Hora", this.Hora);

                return DB.InsertRow("Km", m_params);
            } // End Create

            public static List<Km> Read()
            {
                List<Km> list = new List<Km>();
                DataTable dt = DB.Select("Km");
                foreach (DataRow dr in dt.Rows)
                {
                    list.Add(new Km(DB.GetNullableInt32(dr["Unidad"]), DB.GetNullableInt32(dr["Kilometraje"]), Convert.ToString(dr["Fecha"]), Convert.ToString(dr["Hora"])));
                }

                return list;
            } // End Read

            public int Update()
            {
                Hashtable m_params = new Hashtable();
                Hashtable w_params = new Hashtable();
                if (!AppHelper.IsNullOrEmpty(this.Unidad)) m_params.Add("Unidad", this.Unidad);
                if (!AppHelper.IsNullOrEmpty(this.Kilometraje)) m_params.Add("Kilometraje", this.Kilometraje);
                if (!AppHelper.IsNullOrEmpty(this.Fecha)) m_params.Add("Fecha", this.Fecha);
                if (!AppHelper.IsNullOrEmpty(this.Hora)) m_params.Add("Hora", this.Hora);

                return DB.UpdateRow("Km", m_params, w_params);
            } // End Update

            public int Delete()
            {
                Hashtable w_params = new Hashtable();

                return DB.DeleteRow("Km", w_params);
            } // End Delete

        } //End Class Km

        public class KmBack200708242
        {

            public KmBack200708242()
            {
            }

            public KmBack200708242(int? unidad, int? kilometraje, DateTime? fecha)
            {
                this.Unidad = unidad;
                this.Kilometraje = kilometraje;
                this.Fecha = fecha;
            }

            private int? _Unidad;
            public int? Unidad
            {
                get { return _Unidad; }
                set { _Unidad = value; }
            }

            private int? _Kilometraje;
            public int? Kilometraje
            {
                get { return _Kilometraje; }
                set { _Kilometraje = value; }
            }

            private DateTime? _Fecha;
            public DateTime? Fecha
            {
                get { return _Fecha; }
                set { _Fecha = value; }
            }

            public int Create()
            {
                Hashtable m_params = new Hashtable();
                if (!AppHelper.IsNullOrEmpty(this.Unidad)) m_params.Add("Unidad", this.Unidad);
                if (!AppHelper.IsNullOrEmpty(this.Kilometraje)) m_params.Add("Kilometraje", this.Kilometraje);
                if (!AppHelper.IsNullOrEmpty(this.Fecha)) m_params.Add("Fecha", this.Fecha);

                return DB.InsertRow("KmBack200708242", m_params);
            } // End Create

            public static List<KmBack200708242> Read()
            {
                List<KmBack200708242> list = new List<KmBack200708242>();
                DataTable dt = DB.Select("KmBack200708242");
                foreach (DataRow dr in dt.Rows)
                {
                    list.Add(new KmBack200708242(DB.GetNullableInt32(dr["Unidad"]), DB.GetNullableInt32(dr["Kilometraje"]), DB.GetNullableDateTime(dr["Fecha"])));
                }

                return list;
            } // End Read

            public int Update()
            {
                Hashtable m_params = new Hashtable();
                Hashtable w_params = new Hashtable();
                if (!AppHelper.IsNullOrEmpty(this.Unidad)) m_params.Add("Unidad", this.Unidad);
                if (!AppHelper.IsNullOrEmpty(this.Kilometraje)) m_params.Add("Kilometraje", this.Kilometraje);
                if (!AppHelper.IsNullOrEmpty(this.Fecha)) m_params.Add("Fecha", this.Fecha);

                return DB.UpdateRow("KmBack200708242", m_params, w_params);
            } // End Update

            public int Delete()
            {
                Hashtable w_params = new Hashtable();

                return DB.DeleteRow("KmBack200708242", w_params);
            } // End Delete

        } //End Class KmBack200708242

        public class KmErroneos
        {

            public KmErroneos()
            {
            }

            public KmErroneos(int? unidad, int? kilometraje, DateTime? fecha)
            {
                this.Unidad = unidad;
                this.Kilometraje = kilometraje;
                this.Fecha = fecha;
            }

            private int? _Unidad;
            public int? Unidad
            {
                get { return _Unidad; }
                set { _Unidad = value; }
            }

            private int? _Kilometraje;
            public int? Kilometraje
            {
                get { return _Kilometraje; }
                set { _Kilometraje = value; }
            }

            private DateTime? _Fecha;
            public DateTime? Fecha
            {
                get { return _Fecha; }
                set { _Fecha = value; }
            }

            public int Create()
            {
                Hashtable m_params = new Hashtable();
                if (!AppHelper.IsNullOrEmpty(this.Unidad)) m_params.Add("Unidad", this.Unidad);
                if (!AppHelper.IsNullOrEmpty(this.Kilometraje)) m_params.Add("Kilometraje", this.Kilometraje);
                if (!AppHelper.IsNullOrEmpty(this.Fecha)) m_params.Add("Fecha", this.Fecha);

                return DB.InsertRow("KmErroneos", m_params);
            } // End Create

            public static List<KmErroneos> Read()
            {
                List<KmErroneos> list = new List<KmErroneos>();
                DataTable dt = DB.Select("KmErroneos");
                foreach (DataRow dr in dt.Rows)
                {
                    list.Add(new KmErroneos(DB.GetNullableInt32(dr["Unidad"]), DB.GetNullableInt32(dr["Kilometraje"]), DB.GetNullableDateTime(dr["Fecha"])));
                }

                return list;
            } // End Read

            public int Update()
            {
                Hashtable m_params = new Hashtable();
                Hashtable w_params = new Hashtable();
                if (!AppHelper.IsNullOrEmpty(this.Unidad)) m_params.Add("Unidad", this.Unidad);
                if (!AppHelper.IsNullOrEmpty(this.Kilometraje)) m_params.Add("Kilometraje", this.Kilometraje);
                if (!AppHelper.IsNullOrEmpty(this.Fecha)) m_params.Add("Fecha", this.Fecha);

                return DB.UpdateRow("KmErroneos", m_params, w_params);
            } // End Update

            public int Delete()
            {
                Hashtable w_params = new Hashtable();

                return DB.DeleteRow("KmErroneos", w_params);
            } // End Delete

        } //End Class KmErroneos

        //public class LeyendaFiscal
        //{

        //    public LeyendaFiscal()
        //    {
        //    }

        //    public LeyendaFiscal(string leyendafiscal)
        //    {
        //        this.LeyendaFiscal = leyendafiscal;
        //    }

        //    private string _LeyendaFiscal;
        //    public string LeyendaFiscal
        //    {
        //        get { return _LeyendaFiscal; }
        //        set { _LeyendaFiscal = value; }
        //    }

        //    public int Create()
        //    {
        //        Hashtable m_params = new Hashtable();
        //        if (!AppHelper.IsNullOrEmpty(this.LeyendaFiscal)) m_params.Add("LeyendaFiscal", this.LeyendaFiscal);

        //        return DB.InsertRow("LeyendaFiscal", m_params);
        //    } // End Create

        //    public static List<LeyendaFiscal> Read()
        //    {
        //        List<LeyendaFiscal> list = new List<LeyendaFiscal>();
        //        DataTable dt = DB.Select("LeyendaFiscal");
        //        foreach (DataRow dr in dt.Rows)
        //        {
        //            list.Add(new LeyendaFiscal(Convert.ToString(dr["LeyendaFiscal"])));
        //        }

        //        return list;
        //    } // End Read

        //    public int Update()
        //    {
        //        Hashtable m_params = new Hashtable();
        //        Hashtable w_params = new Hashtable();
        //        if (!AppHelper.IsNullOrEmpty(this.LeyendaFiscal)) m_params.Add("LeyendaFiscal", this.LeyendaFiscal);

        //        return DB.UpdateRow("LeyendaFiscal", m_params, w_params);
        //    } // End Update

        //    public int Delete()
        //    {
        //        Hashtable w_params = new Hashtable();

        //        return DB.DeleteRow("LeyendaFiscal", w_params);
        //    } // End Delete

        //} //End Class LeyendaFiscal

        public class LicenciasConductores
        {

            public LicenciasConductores()
            {
            }

            public LicenciasConductores(int conductor, int tipolicencia, string numerolicencia, DateTime fechavencimiento)
            {
                this.Conductor = conductor;
                this.Conductor = conductor;
                this.TipoLicencia = tipolicencia;
                this.NumeroLicencia = numerolicencia;
                this.FechaVencimiento = fechavencimiento;
            }

            private int _Conductor;
            public int Conductor
            {
                get { return _Conductor; }
                set { _Conductor = value; }
            }

            private int _TipoLicencia;
            public int TipoLicencia
            {
                get { return _TipoLicencia; }
                set { _TipoLicencia = value; }
            }

            private string _NumeroLicencia;
            public string NumeroLicencia
            {
                get { return _NumeroLicencia; }
                set { _NumeroLicencia = value; }
            }

            private DateTime _FechaVencimiento;
            public DateTime FechaVencimiento
            {
                get { return _FechaVencimiento; }
                set { _FechaVencimiento = value; }
            }

            public int Create()
            {
                Hashtable m_params = new Hashtable();
                m_params.Add("Conductor", this.Conductor);
                m_params.Add("Conductor", this.Conductor);
                m_params.Add("TipoLicencia", this.TipoLicencia);
                m_params.Add("NumeroLicencia", this.NumeroLicencia);
                m_params.Add("FechaVencimiento", this.FechaVencimiento);

                return DB.InsertRow("LicenciasConductores", m_params);
            } // End Create

            public static List<LicenciasConductores> Read()
            {
                List<LicenciasConductores> list = new List<LicenciasConductores>();
                DataTable dt = DB.Select("LicenciasConductores");
                foreach (DataRow dr in dt.Rows)
                {
                    list.Add(new LicenciasConductores(Convert.ToInt32(dr["Conductor"]), Convert.ToInt32(dr["TipoLicencia"]), Convert.ToString(dr["NumeroLicencia"]), Convert.ToDateTime(dr["FechaVencimiento"])));
                }

                return list;
            } // End Read

            public static LicenciasConductores Read(int conductor)
            {
                Hashtable w_params = new Hashtable();
                w_params.Add("Conductor", conductor);
                DataTable dt = DB.Select("LicenciasConductores", w_params);
                if (dt.Rows.Count == 0)
                {
                    throw new Exception("No existe LicenciasConductores con los criterios de búsqueda especificados.");
                }
                DataRow dr = dt.Rows[0];
                return new LicenciasConductores(Convert.ToInt32(dr["Conductor"]), Convert.ToInt32(dr["TipoLicencia"]), Convert.ToString(dr["NumeroLicencia"]), Convert.ToDateTime(dr["FechaVencimiento"]));
            } // End Read

            public int Update()
            {
                Hashtable m_params = new Hashtable();
                Hashtable w_params = new Hashtable();
                m_params.Add("Conductor", this.Conductor);
                w_params.Add("Conductor", this.Conductor);
                m_params.Add("TipoLicencia", this.TipoLicencia);
                m_params.Add("NumeroLicencia", this.NumeroLicencia);
                m_params.Add("FechaVencimiento", this.FechaVencimiento);

                return DB.UpdateRow("LicenciasConductores", m_params, w_params);
            } // End Update

            public int Delete()
            {
                Hashtable w_params = new Hashtable();
                w_params.Add("Conductor", this.Conductor);

                return DB.DeleteRow("LicenciasConductores", w_params);
            } // End Delete

        } //End Class LicenciasConductores

        public class LocacionesUnidades
        {

            public LocacionesUnidades()
            {
            }

            public LocacionesUnidades(int folio, string descripcion)
            {
                this.Folio = folio;
                this.Descripcion = descripcion;
            }

            private int _Folio;
            public int Folio
            {
                get { return _Folio; }
                set { _Folio = value; }
            }

            private string _Descripcion;
            public string Descripcion
            {
                get { return _Descripcion; }
                set { _Descripcion = value; }
            }

            public int Create()
            {
                Hashtable m_params = new Hashtable();
                m_params.Add("Descripcion", this.Descripcion);

                return DB.InsertRow("LocacionesUnidades", m_params);
            } // End Create

            public static List<LocacionesUnidades> Read()
            {
                List<LocacionesUnidades> list = new List<LocacionesUnidades>();
                DataTable dt = DB.Select("LocacionesUnidades");
                foreach (DataRow dr in dt.Rows)
                {
                    list.Add(new LocacionesUnidades(Convert.ToInt32(dr["Folio"]), Convert.ToString(dr["Descripcion"])));
                }

                return list;
            } // End Read

            public static LocacionesUnidades Read(int folio)
            {
                Hashtable w_params = new Hashtable();
                w_params.Add("Folio", folio);
                DataTable dt = DB.Select("LocacionesUnidades", w_params);
                if (dt.Rows.Count == 0)
                {
                    throw new Exception("No existe LocacionesUnidades con los criterios de búsqueda especificados.");
                }
                DataRow dr = dt.Rows[0];
                return new LocacionesUnidades(Convert.ToInt32(dr["Folio"]), Convert.ToString(dr["Descripcion"]));
            } // End Read

            public int Update()
            {
                Hashtable m_params = new Hashtable();
                Hashtable w_params = new Hashtable();
                w_params.Add("Folio", this.Folio);
                m_params.Add("Descripcion", this.Descripcion);

                return DB.UpdateRow("LocacionesUnidades", m_params, w_params);
            } // End Update

            public int Delete()
            {
                Hashtable w_params = new Hashtable();
                w_params.Add("Folio", this.Folio);

                return DB.DeleteRow("LocacionesUnidades", w_params);
            } // End Delete

        } //End Class LocacionesUnidades

        public class MantenimientosKilometrajes
        {

            public MantenimientosKilometrajes()
            {
            }

            public MantenimientosKilometrajes(int? unidad, int? kilometrosparamantenimiento, int? kilometrajeproximomantenimiento)
            {
                this.Unidad = unidad;
                this.KilometrosParaMantenimiento = kilometrosparamantenimiento;
                this.KilometrajeProximoMantenimiento = kilometrajeproximomantenimiento;
            }

            private int? _Unidad;
            public int? Unidad
            {
                get { return _Unidad; }
                set { _Unidad = value; }
            }

            private int? _KilometrosParaMantenimiento;
            public int? KilometrosParaMantenimiento
            {
                get { return _KilometrosParaMantenimiento; }
                set { _KilometrosParaMantenimiento = value; }
            }

            private int? _KilometrajeProximoMantenimiento;
            public int? KilometrajeProximoMantenimiento
            {
                get { return _KilometrajeProximoMantenimiento; }
                set { _KilometrajeProximoMantenimiento = value; }
            }

            public int Create()
            {
                Hashtable m_params = new Hashtable();
                if (!AppHelper.IsNullOrEmpty(this.Unidad)) m_params.Add("Unidad", this.Unidad);
                if (!AppHelper.IsNullOrEmpty(this.KilometrosParaMantenimiento)) m_params.Add("KilometrosParaMantenimiento", this.KilometrosParaMantenimiento);
                if (!AppHelper.IsNullOrEmpty(this.KilometrajeProximoMantenimiento)) m_params.Add("KilometrajeProximoMantenimiento", this.KilometrajeProximoMantenimiento);

                return DB.InsertRow("MantenimientosKilometrajes", m_params);
            } // End Create

            public static List<MantenimientosKilometrajes> Read()
            {
                List<MantenimientosKilometrajes> list = new List<MantenimientosKilometrajes>();
                DataTable dt = DB.Select("MantenimientosKilometrajes");
                foreach (DataRow dr in dt.Rows)
                {
                    list.Add(new MantenimientosKilometrajes(DB.GetNullableInt32(dr["Unidad"]), DB.GetNullableInt32(dr["KilometrosParaMantenimiento"]), DB.GetNullableInt32(dr["KilometrajeProximoMantenimiento"])));
                }

                return list;
            } // End Read

            public int Update()
            {
                Hashtable m_params = new Hashtable();
                Hashtable w_params = new Hashtable();
                if (!AppHelper.IsNullOrEmpty(this.Unidad)) m_params.Add("Unidad", this.Unidad);
                if (!AppHelper.IsNullOrEmpty(this.KilometrosParaMantenimiento)) m_params.Add("KilometrosParaMantenimiento", this.KilometrosParaMantenimiento);
                if (!AppHelper.IsNullOrEmpty(this.KilometrajeProximoMantenimiento)) m_params.Add("KilometrajeProximoMantenimiento", this.KilometrajeProximoMantenimiento);

                return DB.UpdateRow("MantenimientosKilometrajes", m_params, w_params);
            } // End Update

            public int Delete()
            {
                Hashtable w_params = new Hashtable();

                return DB.DeleteRow("MantenimientosKilometrajes", w_params);
            } // End Delete

        } //End Class MantenimientosKilometrajes

        public class MantenimientosUnidades
        {

            public MantenimientosUnidades()
            {
            }

            public MantenimientosUnidades(int folio, int unidad, int conductor, int kilometraje, string ordenservicio, decimal costomanoobra, decimal costorefacciones, string comentarios, DateTime fecha, int tipo)
            {
                this.Folio = folio;
                this.Unidad = unidad;
                this.Conductor = conductor;
                this.Kilometraje = kilometraje;
                this.OrdenServicio = ordenservicio;
                this.CostoManoObra = costomanoobra;
                this.CostoRefacciones = costorefacciones;
                this.Comentarios = comentarios;
                this.Fecha = fecha;
                this.Tipo = tipo;
            }

            private int _Folio;
            public int Folio
            {
                get { return _Folio; }
                set { _Folio = value; }
            }

            private int _Unidad;
            public int Unidad
            {
                get { return _Unidad; }
                set { _Unidad = value; }
            }

            private int _Conductor;
            public int Conductor
            {
                get { return _Conductor; }
                set { _Conductor = value; }
            }

            private int _Kilometraje;
            public int Kilometraje
            {
                get { return _Kilometraje; }
                set { _Kilometraje = value; }
            }

            private string _OrdenServicio;
            public string OrdenServicio
            {
                get { return _OrdenServicio; }
                set { _OrdenServicio = value; }
            }

            private decimal _CostoManoObra;
            public decimal CostoManoObra
            {
                get { return _CostoManoObra; }
                set { _CostoManoObra = value; }
            }

            private decimal _CostoRefacciones;
            public decimal CostoRefacciones
            {
                get { return _CostoRefacciones; }
                set { _CostoRefacciones = value; }
            }

            private string _Comentarios;
            public string Comentarios
            {
                get { return _Comentarios; }
                set { _Comentarios = value; }
            }

            private DateTime _Fecha;
            public DateTime Fecha
            {
                get { return _Fecha; }
                set { _Fecha = value; }
            }

            private int _Tipo;
            public int Tipo
            {
                get { return _Tipo; }
                set { _Tipo = value; }
            }

            public int Create()
            {
                Hashtable m_params = new Hashtable();
                m_params.Add("Unidad", this.Unidad);
                m_params.Add("Conductor", this.Conductor);
                m_params.Add("Kilometraje", this.Kilometraje);
                m_params.Add("OrdenServicio", this.OrdenServicio);
                m_params.Add("CostoManoObra", this.CostoManoObra);
                m_params.Add("CostoRefacciones", this.CostoRefacciones);
                if (!AppHelper.IsNullOrEmpty(this.Comentarios)) m_params.Add("Comentarios", this.Comentarios);
                m_params.Add("Fecha", this.Fecha);
                m_params.Add("Tipo", this.Tipo);

                return DB.InsertRow("MantenimientosUnidades", m_params);
            } // End Create

            public static List<MantenimientosUnidades> Read()
            {
                List<MantenimientosUnidades> list = new List<MantenimientosUnidades>();
                DataTable dt = DB.Select("MantenimientosUnidades");
                foreach (DataRow dr in dt.Rows)
                {
                    list.Add(new MantenimientosUnidades(Convert.ToInt32(dr["Folio"]), Convert.ToInt32(dr["Unidad"]), Convert.ToInt32(dr["Conductor"]), Convert.ToInt32(dr["Kilometraje"]), Convert.ToString(dr["OrdenServicio"]), Convert.ToDecimal(dr["CostoManoObra"]), Convert.ToDecimal(dr["CostoRefacciones"]), Convert.ToString(dr["Comentarios"]), Convert.ToDateTime(dr["Fecha"]), Convert.ToInt32(dr["Tipo"])));
                }

                return list;
            } // End Read

            public static MantenimientosUnidades Read(int folio)
            {
                Hashtable w_params = new Hashtable();
                w_params.Add("Folio", folio);
                DataTable dt = DB.Select("MantenimientosUnidades", w_params);
                if (dt.Rows.Count == 0)
                {
                    throw new Exception("No existe MantenimientosUnidades con los criterios de búsqueda especificados.");
                }
                DataRow dr = dt.Rows[0];
                return new MantenimientosUnidades(Convert.ToInt32(dr["Folio"]), Convert.ToInt32(dr["Unidad"]), Convert.ToInt32(dr["Conductor"]), Convert.ToInt32(dr["Kilometraje"]), Convert.ToString(dr["OrdenServicio"]), Convert.ToDecimal(dr["CostoManoObra"]), Convert.ToDecimal(dr["CostoRefacciones"]), Convert.ToString(dr["Comentarios"]), Convert.ToDateTime(dr["Fecha"]), Convert.ToInt32(dr["Tipo"]));
            } // End Read

            public int Update()
            {
                Hashtable m_params = new Hashtable();
                Hashtable w_params = new Hashtable();
                w_params.Add("Folio", this.Folio);
                m_params.Add("Unidad", this.Unidad);
                m_params.Add("Conductor", this.Conductor);
                m_params.Add("Kilometraje", this.Kilometraje);
                m_params.Add("OrdenServicio", this.OrdenServicio);
                m_params.Add("CostoManoObra", this.CostoManoObra);
                m_params.Add("CostoRefacciones", this.CostoRefacciones);
                if (!AppHelper.IsNullOrEmpty(this.Comentarios)) m_params.Add("Comentarios", this.Comentarios);
                m_params.Add("Fecha", this.Fecha);
                m_params.Add("Tipo", this.Tipo);

                return DB.UpdateRow("MantenimientosUnidades", m_params, w_params);
            } // End Update

            public int Delete()
            {
                Hashtable w_params = new Hashtable();
                w_params.Add("Folio", this.Folio);

                return DB.DeleteRow("MantenimientosUnidades", w_params);
            } // End Delete

        } //End Class MantenimientosUnidades

        public class MarcasUnidades
        {

            public MarcasUnidades()
            {
            }

            public MarcasUnidades(int folio, string descripcion)
            {
                this.Folio = folio;
                this.Descripcion = descripcion;
            }

            private int _Folio;
            public int Folio
            {
                get { return _Folio; }
                set { _Folio = value; }
            }

            private string _Descripcion;
            public string Descripcion
            {
                get { return _Descripcion; }
                set { _Descripcion = value; }
            }

            public int Create()
            {
                Hashtable m_params = new Hashtable();
                m_params.Add("Descripcion", this.Descripcion);

                return DB.InsertRow("MarcasUnidades", m_params);
            } // End Create

            public static List<MarcasUnidades> Read()
            {
                List<MarcasUnidades> list = new List<MarcasUnidades>();
                DataTable dt = DB.Select("MarcasUnidades");
                foreach (DataRow dr in dt.Rows)
                {
                    list.Add(new MarcasUnidades(Convert.ToInt32(dr["Folio"]), Convert.ToString(dr["Descripcion"])));
                }

                return list;
            } // End Read

            public static MarcasUnidades Read(int folio)
            {
                Hashtable w_params = new Hashtable();
                w_params.Add("Folio", folio);
                DataTable dt = DB.Select("MarcasUnidades", w_params);
                if (dt.Rows.Count == 0)
                {
                    throw new Exception("No existe MarcasUnidades con los criterios de búsqueda especificados.");
                }
                DataRow dr = dt.Rows[0];
                return new MarcasUnidades(Convert.ToInt32(dr["Folio"]), Convert.ToString(dr["Descripcion"]));
            } // End Read

            public int Update()
            {
                Hashtable m_params = new Hashtable();
                Hashtable w_params = new Hashtable();
                w_params.Add("Folio", this.Folio);
                m_params.Add("Descripcion", this.Descripcion);

                return DB.UpdateRow("MarcasUnidades", m_params, w_params);
            } // End Update

            public int Delete()
            {
                Hashtable w_params = new Hashtable();
                w_params.Add("Folio", this.Folio);

                return DB.DeleteRow("MarcasUnidades", w_params);
            } // End Delete

        } //End Class MarcasUnidades

        public class ModelosPrestamoCombustible
        {

            public ModelosPrestamoCombustible()
            {
            }

            public ModelosPrestamoCombustible(int modelo, decimal cuotadiaria, DateTime fecha, string usuario)
            {
                this.Modelo = modelo;
                this.CuotaDiaria = cuotadiaria;
                this.Fecha = fecha;
                this.Usuario = usuario;
            }

            private int _Modelo;
            public int Modelo
            {
                get { return _Modelo; }
                set { _Modelo = value; }
            }

            private decimal _CuotaDiaria;
            public decimal CuotaDiaria
            {
                get { return _CuotaDiaria; }
                set { _CuotaDiaria = value; }
            }

            private DateTime _Fecha;
            public DateTime Fecha
            {
                get { return _Fecha; }
                set { _Fecha = value; }
            }

            private string _Usuario;
            public string Usuario
            {
                get { return _Usuario; }
                set { _Usuario = value; }
            }

            public int Create()
            {
                Hashtable m_params = new Hashtable();
                m_params.Add("Modelo", this.Modelo);
                m_params.Add("CuotaDiaria", this.CuotaDiaria);
                m_params.Add("Fecha", this.Fecha);
                m_params.Add("Usuario", this.Usuario);

                return DB.InsertRow("ModelosPrestamoCombustible", m_params);
            } // End Create

            public static List<ModelosPrestamoCombustible> Read()
            {
                List<ModelosPrestamoCombustible> list = new List<ModelosPrestamoCombustible>();
                DataTable dt = DB.Select("ModelosPrestamoCombustible");
                foreach (DataRow dr in dt.Rows)
                {
                    list.Add(new ModelosPrestamoCombustible(Convert.ToInt32(dr["Modelo"]), Convert.ToDecimal(dr["CuotaDiaria"]), Convert.ToDateTime(dr["Fecha"]), Convert.ToString(dr["Usuario"])));
                }

                return list;
            } // End Read

            public static ModelosPrestamoCombustible Read(int modelo)
            {
                Hashtable w_params = new Hashtable();
                w_params.Add("Modelo", modelo);
                DataTable dt = DB.Select("ModelosPrestamoCombustible", w_params);
                if (dt.Rows.Count == 0)
                {
                    throw new Exception("No existe ModelosPrestamoCombustible con los criterios de búsqueda especificados.");
                }
                DataRow dr = dt.Rows[0];
                return new ModelosPrestamoCombustible(Convert.ToInt32(dr["Modelo"]), Convert.ToDecimal(dr["CuotaDiaria"]), Convert.ToDateTime(dr["Fecha"]), Convert.ToString(dr["Usuario"]));
            } // End Read

            public int Update()
            {
                Hashtable m_params = new Hashtable();
                Hashtable w_params = new Hashtable();
                w_params.Add("Modelo", this.Modelo);
                m_params.Add("CuotaDiaria", this.CuotaDiaria);
                m_params.Add("Fecha", this.Fecha);
                m_params.Add("Usuario", this.Usuario);

                return DB.UpdateRow("ModelosPrestamoCombustible", m_params, w_params);
            } // End Update

            public int Delete()
            {
                Hashtable w_params = new Hashtable();
                w_params.Add("Modelo", this.Modelo);

                return DB.DeleteRow("ModelosPrestamoCombustible", w_params);
            } // End Delete

        } //End Class ModelosPrestamoCombustible

        public class ModelosUnidades
        {

            public ModelosUnidades()
            {
            }

            public ModelosUnidades(int folio, int marca, int clase, string descripcion, int anyo, decimal preciolista)
            {
                this.Folio = folio;
                this.Marca = marca;
                this.Clase = clase;
                this.Descripcion = descripcion;
                this.Anyo = anyo;
                this.PrecioLista = preciolista;
            }

            private int _Folio;
            public int Folio
            {
                get { return _Folio; }
                set { _Folio = value; }
            }

            private int _Marca;
            public int Marca
            {
                get { return _Marca; }
                set { _Marca = value; }
            }

            private int _Clase;
            public int Clase
            {
                get { return _Clase; }
                set { _Clase = value; }
            }

            private string _Descripcion;
            public string Descripcion
            {
                get { return _Descripcion; }
                set { _Descripcion = value; }
            }

            private int _Anyo;
            public int Anyo
            {
                get { return _Anyo; }
                set { _Anyo = value; }
            }

            private decimal _PrecioLista;
            public decimal PrecioLista
            {
                get { return _PrecioLista; }
                set { _PrecioLista = value; }
            }

            public int Create()
            {
                Hashtable m_params = new Hashtable();
                m_params.Add("Marca", this.Marca);
                m_params.Add("Clase", this.Clase);
                m_params.Add("Descripcion", this.Descripcion);
                m_params.Add("Anyo", this.Anyo);
                m_params.Add("PrecioLista", this.PrecioLista);

                return DB.InsertRow("ModelosUnidades", m_params);
            } // End Create

            public static List<ModelosUnidades> Read()
            {
                List<ModelosUnidades> list = new List<ModelosUnidades>();
                DataTable dt = DB.Select("ModelosUnidades");
                foreach (DataRow dr in dt.Rows)
                {
                    list.Add(new ModelosUnidades(Convert.ToInt32(dr["Folio"]), Convert.ToInt32(dr["Marca"]), Convert.ToInt32(dr["Clase"]), Convert.ToString(dr["Descripcion"]), Convert.ToInt32(dr["Anyo"]), Convert.ToDecimal(dr["PrecioLista"])));
                }

                return list;
            } // End Read

            public static ModelosUnidades Read(int folio)
            {
                Hashtable w_params = new Hashtable();
                w_params.Add("Folio", folio);
                DataTable dt = DB.Select("ModelosUnidades", w_params);
                if (dt.Rows.Count == 0)
                {
                    throw new Exception("No existe ModelosUnidades con los criterios de búsqueda especificados.");
                }
                DataRow dr = dt.Rows[0];
                return new ModelosUnidades(Convert.ToInt32(dr["Folio"]), Convert.ToInt32(dr["Marca"]), Convert.ToInt32(dr["Clase"]), Convert.ToString(dr["Descripcion"]), Convert.ToInt32(dr["Anyo"]), Convert.ToDecimal(dr["PrecioLista"]));
            } // End Read

            public int Update()
            {
                Hashtable m_params = new Hashtable();
                Hashtable w_params = new Hashtable();
                w_params.Add("Folio", this.Folio);
                m_params.Add("Marca", this.Marca);
                m_params.Add("Clase", this.Clase);
                m_params.Add("Descripcion", this.Descripcion);
                m_params.Add("Anyo", this.Anyo);
                m_params.Add("PrecioLista", this.PrecioLista);

                return DB.UpdateRow("ModelosUnidades", m_params, w_params);
            } // End Update

            public int Delete()
            {
                Hashtable w_params = new Hashtable();
                w_params.Add("Folio", this.Folio);

                return DB.DeleteRow("ModelosUnidades", w_params);
            } // End Delete

        } //End Class ModelosUnidades

        public class MotivosBajas
        {

            public MotivosBajas()
            {
            }

            public MotivosBajas(int folio, string descripcion, bool? derechoreingreso)
            {
                this.Folio = folio;
                this.Descripcion = descripcion;
                this.DerechoReingreso = derechoreingreso;
            }

            private int _Folio;
            public int Folio
            {
                get { return _Folio; }
                set { _Folio = value; }
            }

            private string _Descripcion;
            public string Descripcion
            {
                get { return _Descripcion; }
                set { _Descripcion = value; }
            }

            private bool? _DerechoReingreso;
            public bool? DerechoReingreso
            {
                get { return _DerechoReingreso; }
                set { _DerechoReingreso = value; }
            }

            public int Create()
            {
                Hashtable m_params = new Hashtable();
                if (!AppHelper.IsNullOrEmpty(this.Descripcion)) m_params.Add("Descripcion", this.Descripcion);
                if (!AppHelper.IsNullOrEmpty(this.DerechoReingreso)) m_params.Add("DerechoReingreso", this.DerechoReingreso);

                return DB.InsertRow("MotivosBajas", m_params);
            } // End Create

            public static List<MotivosBajas> Read()
            {
                List<MotivosBajas> list = new List<MotivosBajas>();
                DataTable dt = DB.Select("MotivosBajas");
                foreach (DataRow dr in dt.Rows)
                {
                    list.Add(new MotivosBajas(Convert.ToInt32(dr["Folio"]), Convert.ToString(dr["Descripcion"]), DB.GetNullableBoolean(dr["DerechoReingreso"])));
                }

                return list;
            } // End Read

            public static MotivosBajas Read(int folio)
            {
                Hashtable w_params = new Hashtable();
                w_params.Add("Folio", folio);
                DataTable dt = DB.Select("MotivosBajas", w_params);
                if (dt.Rows.Count == 0)
                {
                    throw new Exception("No existe MotivosBajas con los criterios de búsqueda especificados.");
                }
                DataRow dr = dt.Rows[0];
                return new MotivosBajas(Convert.ToInt32(dr["Folio"]), Convert.ToString(dr["Descripcion"]), DB.GetNullableBoolean(dr["DerechoReingreso"]));
            } // End Read

            public int Update()
            {
                Hashtable m_params = new Hashtable();
                Hashtable w_params = new Hashtable();
                w_params.Add("Folio", this.Folio);
                if (!AppHelper.IsNullOrEmpty(this.Descripcion)) m_params.Add("Descripcion", this.Descripcion);
                if (!AppHelper.IsNullOrEmpty(this.DerechoReingreso)) m_params.Add("DerechoReingreso", this.DerechoReingreso);

                return DB.UpdateRow("MotivosBajas", m_params, w_params);
            } // End Update

            public int Delete()
            {
                Hashtable w_params = new Hashtable();
                w_params.Add("Folio", this.Folio);

                return DB.DeleteRow("MotivosBajas", w_params);
            } // End Delete

        } //End Class MotivosBajas

        public class MovimientosCaja
        {

            public MovimientosCaja()
            {
            }

            public MovimientosCaja(int folio, int caja, int operacion, int tipopago, int fondocaja, decimal monto, DateTime fecha, string usuario, string motivo)
            {
                this.Folio = folio;
                this.Caja = caja;
                this.Operacion = operacion;
                this.TipoPago = tipopago;
                this.FondoCaja = fondocaja;
                this.Monto = monto;
                this.Fecha = fecha;
                this.Usuario = usuario;
                this.Motivo = motivo;
            }

            private int _Folio;
            public int Folio
            {
                get { return _Folio; }
                set { _Folio = value; }
            }

            private int _Caja;
            public int Caja
            {
                get { return _Caja; }
                set { _Caja = value; }
            }

            private int _Operacion;
            public int Operacion
            {
                get { return _Operacion; }
                set { _Operacion = value; }
            }

            private int _TipoPago;
            public int TipoPago
            {
                get { return _TipoPago; }
                set { _TipoPago = value; }
            }

            private int _FondoCaja;
            public int FondoCaja
            {
                get { return _FondoCaja; }
                set { _FondoCaja = value; }
            }

            private decimal _Monto;
            public decimal Monto
            {
                get { return _Monto; }
                set { _Monto = value; }
            }

            private DateTime _Fecha;
            public DateTime Fecha
            {
                get { return _Fecha; }
                set { _Fecha = value; }
            }

            private string _Usuario;
            public string Usuario
            {
                get { return _Usuario; }
                set { _Usuario = value; }
            }

            private string _Motivo;
            public string Motivo
            {
                get { return _Motivo; }
                set { _Motivo = value; }
            }

            public int Create()
            {
                Hashtable m_params = new Hashtable();
                m_params.Add("Caja", this.Caja);
                m_params.Add("Operacion", this.Operacion);
                m_params.Add("TipoPago", this.TipoPago);
                m_params.Add("FondoCaja", this.FondoCaja);
                m_params.Add("Monto", this.Monto);
                m_params.Add("Fecha", this.Fecha);
                m_params.Add("Usuario", this.Usuario);
                m_params.Add("Motivo", this.Motivo);

                return DB.InsertRow("MovimientosCaja", m_params);
            } // End Create

            public static List<MovimientosCaja> Read()
            {
                List<MovimientosCaja> list = new List<MovimientosCaja>();
                DataTable dt = DB.Select("MovimientosCaja");
                foreach (DataRow dr in dt.Rows)
                {
                    list.Add(new MovimientosCaja(Convert.ToInt32(dr["Folio"]), Convert.ToInt32(dr["Caja"]), Convert.ToInt32(dr["Operacion"]), Convert.ToInt32(dr["TipoPago"]), Convert.ToInt32(dr["FondoCaja"]), Convert.ToDecimal(dr["Monto"]), Convert.ToDateTime(dr["Fecha"]), Convert.ToString(dr["Usuario"]), Convert.ToString(dr["Motivo"])));
                }

                return list;
            } // End Read

            public static MovimientosCaja Read(int folio)
            {
                Hashtable w_params = new Hashtable();
                w_params.Add("Folio", folio);
                DataTable dt = DB.Select("MovimientosCaja", w_params);
                if (dt.Rows.Count == 0)
                {
                    throw new Exception("No existe MovimientosCaja con los criterios de búsqueda especificados.");
                }
                DataRow dr = dt.Rows[0];
                return new MovimientosCaja(Convert.ToInt32(dr["Folio"]), Convert.ToInt32(dr["Caja"]), Convert.ToInt32(dr["Operacion"]), Convert.ToInt32(dr["TipoPago"]), Convert.ToInt32(dr["FondoCaja"]), Convert.ToDecimal(dr["Monto"]), Convert.ToDateTime(dr["Fecha"]), Convert.ToString(dr["Usuario"]), Convert.ToString(dr["Motivo"]));
            } // End Read

            public static MovimientosCaja Read(params KeyValuePair<string, object>[] args)
            {
                DataTable dt = DB.Read("MovimientosCaja", args);
                if (dt.Rows.Count == 0)
                {
                    return null;
                }
                DataRow dr = dt.Rows[0];
                return new MovimientosCaja(Convert.ToInt32(dr["Folio"]), Convert.ToInt32(dr["Caja"]), Convert.ToInt32(dr["Operacion"]), Convert.ToInt32(dr["TipoPago"]), Convert.ToInt32(dr["FondoCaja"]), Convert.ToDecimal(dr["Monto"]), Convert.ToDateTime(dr["Fecha"]), Convert.ToString(dr["Usuario"]), Convert.ToString(dr["Motivo"]));
            } // End Read

            public static bool Read(out MovimientosCaja movimientoscaja, int top, string filter, string sort, params KeyValuePair<string, object>[] args)
            {
                DataTable dt = DB.Read("MovimientosCaja", top, filter, sort, args);
                if (dt.Rows.Count == 0)
                {
                    movimientoscaja = null;
                    return false;
                }
                DataRow dr = dt.Rows[0];
                movimientoscaja = new MovimientosCaja(Convert.ToInt32(dr["Folio"]), Convert.ToInt32(dr["Caja"]), Convert.ToInt32(dr["Operacion"]), Convert.ToInt32(dr["TipoPago"]), Convert.ToInt32(dr["FondoCaja"]), Convert.ToDecimal(dr["Monto"]), Convert.ToDateTime(dr["Fecha"]), Convert.ToString(dr["Usuario"]), Convert.ToString(dr["Motivo"]));
                return true;
            } // End Read

            public int Update()
            {
                Hashtable m_params = new Hashtable();
                Hashtable w_params = new Hashtable();
                w_params.Add("Folio", this.Folio);
                m_params.Add("Caja", this.Caja);
                m_params.Add("Operacion", this.Operacion);
                m_params.Add("TipoPago", this.TipoPago);
                m_params.Add("FondoCaja", this.FondoCaja);
                m_params.Add("Monto", this.Monto);
                m_params.Add("Fecha", this.Fecha);
                m_params.Add("Usuario", this.Usuario);
                m_params.Add("Motivo", this.Motivo);

                return DB.UpdateRow("MovimientosCaja", m_params, w_params);
            } // End Update

            public int Delete()
            {
                Hashtable w_params = new Hashtable();
                w_params.Add("Folio", this.Folio);

                return DB.DeleteRow("MovimientosCaja", w_params);
            } // End Delete

        } //End Class MovimientosCaja

        public class MovimientosDeCaja
        {

            public MovimientosDeCaja()
            {
            }

            public MovimientosDeCaja(int folio, int controlcaja, int tipopago, int conceptocaja, decimal monto, DateTime fecha)
            {
                this.Folio = folio;
                this.ControlCaja = controlcaja;
                this.TipoPago = tipopago;
                this.ConceptoCaja = conceptocaja;
                this.Monto = monto;
                this.Fecha = fecha;
            }

            private int _Folio;
            public int Folio
            {
                get { return _Folio; }
                set { _Folio = value; }
            }

            private int _ControlCaja;
            public int ControlCaja
            {
                get { return _ControlCaja; }
                set { _ControlCaja = value; }
            }

            private int _TipoPago;
            public int TipoPago
            {
                get { return _TipoPago; }
                set { _TipoPago = value; }
            }

            private int _ConceptoCaja;
            public int ConceptoCaja
            {
                get { return _ConceptoCaja; }
                set { _ConceptoCaja = value; }
            }

            private decimal _Monto;
            public decimal Monto
            {
                get { return _Monto; }
                set { _Monto = value; }
            }

            private DateTime _Fecha;
            public DateTime Fecha
            {
                get { return _Fecha; }
                set { _Fecha = value; }
            }

            public int Create()
            {
                Hashtable m_params = new Hashtable();
                m_params.Add("ControlCaja", this.ControlCaja);
                m_params.Add("TipoPago", this.TipoPago);
                m_params.Add("ConceptoCaja", this.ConceptoCaja);
                m_params.Add("Monto", this.Monto);
                m_params.Add("Fecha", this.Fecha);

                return DB.InsertRow("MovimientosDeCaja", m_params);
            } // End Create

            public static List<MovimientosDeCaja> Read()
            {
                List<MovimientosDeCaja> list = new List<MovimientosDeCaja>();
                DataTable dt = DB.Select("MovimientosDeCaja");
                foreach (DataRow dr in dt.Rows)
                {
                    list.Add(new MovimientosDeCaja(Convert.ToInt32(dr["Folio"]), Convert.ToInt32(dr["ControlCaja"]), Convert.ToInt32(dr["TipoPago"]), Convert.ToInt32(dr["ConceptoCaja"]), Convert.ToDecimal(dr["Monto"]), Convert.ToDateTime(dr["Fecha"])));
                }

                return list;
            } // End Read

            public static MovimientosDeCaja Read(int folio)
            {
                Hashtable w_params = new Hashtable();
                w_params.Add("Folio", folio);
                DataTable dt = DB.Select("MovimientosDeCaja", w_params);
                if (dt.Rows.Count == 0)
                {
                    throw new Exception("No existe MovimientosDeCaja con los criterios de búsqueda especificados.");
                }
                DataRow dr = dt.Rows[0];
                return new MovimientosDeCaja(Convert.ToInt32(dr["Folio"]), Convert.ToInt32(dr["ControlCaja"]), Convert.ToInt32(dr["TipoPago"]), Convert.ToInt32(dr["ConceptoCaja"]), Convert.ToDecimal(dr["Monto"]), Convert.ToDateTime(dr["Fecha"]));
            } // End Read

            public int Update()
            {
                Hashtable m_params = new Hashtable();
                Hashtable w_params = new Hashtable();
                w_params.Add("Folio", this.Folio);
                m_params.Add("ControlCaja", this.ControlCaja);
                m_params.Add("TipoPago", this.TipoPago);
                m_params.Add("ConceptoCaja", this.ConceptoCaja);
                m_params.Add("Monto", this.Monto);
                m_params.Add("Fecha", this.Fecha);

                return DB.UpdateRow("MovimientosDeCaja", m_params, w_params);
            } // End Update

            public int Delete()
            {
                Hashtable w_params = new Hashtable();
                w_params.Add("Folio", this.Folio);

                return DB.DeleteRow("MovimientosDeCaja", w_params);
            } // End Delete

        } //End Class MovimientosDeCaja

        public class OperacionesCajas
        {

            public OperacionesCajas()
            {
            }

            public OperacionesCajas(int folio, string descripcion, int tipoconcepto)
            {
                this.Folio = folio;
                this.Descripcion = descripcion;
                this.TipoConcepto = tipoconcepto;
            }

            private int _Folio;
            public int Folio
            {
                get { return _Folio; }
                set { _Folio = value; }
            }

            private string _Descripcion;
            public string Descripcion
            {
                get { return _Descripcion; }
                set { _Descripcion = value; }
            }

            private int _TipoConcepto;
            public int TipoConcepto
            {
                get { return _TipoConcepto; }
                set { _TipoConcepto = value; }
            }

            public int Create()
            {
                Hashtable m_params = new Hashtable();
                m_params.Add("Descripcion", this.Descripcion);
                m_params.Add("TipoConcepto", this.TipoConcepto);

                return DB.InsertRow("OperacionesCajas", m_params);
            } // End Create

            public static List<OperacionesCajas> Read()
            {
                List<OperacionesCajas> list = new List<OperacionesCajas>();
                DataTable dt = DB.Select("OperacionesCajas");
                foreach (DataRow dr in dt.Rows)
                {
                    list.Add(new OperacionesCajas(Convert.ToInt32(dr["Folio"]), Convert.ToString(dr["Descripcion"]), Convert.ToInt32(dr["TipoConcepto"])));
                }

                return list;
            } // End Read

            public static OperacionesCajas Read(int folio)
            {
                Hashtable w_params = new Hashtable();
                w_params.Add("Folio", folio);
                DataTable dt = DB.Select("OperacionesCajas", w_params);
                if (dt.Rows.Count == 0)
                {
                    throw new Exception("No existe OperacionesCajas con los criterios de búsqueda especificados.");
                }
                DataRow dr = dt.Rows[0];
                return new OperacionesCajas(Convert.ToInt32(dr["Folio"]), Convert.ToString(dr["Descripcion"]), Convert.ToInt32(dr["TipoConcepto"]));
            } // End Read

            public int Update()
            {
                Hashtable m_params = new Hashtable();
                Hashtable w_params = new Hashtable();
                w_params.Add("Folio", this.Folio);
                m_params.Add("Descripcion", this.Descripcion);
                m_params.Add("TipoConcepto", this.TipoConcepto);

                return DB.UpdateRow("OperacionesCajas", m_params, w_params);
            } // End Update

            public int Delete()
            {
                Hashtable w_params = new Hashtable();
                w_params.Add("Folio", this.Folio);

                return DB.DeleteRow("OperacionesCajas", w_params);
            } // End Delete

        } //End Class OperacionesCajas

        public class PagoBoletos
        {

            public PagoBoletos()
            {
            }

            public PagoBoletos(string boleto, decimal? precio, decimal pagocasco, decimal pagoconductor, decimal pagounidad, DateTime fecha, int? tipo, decimal? tarifaebssa, decimal? totalcasco, decimal? porcentajecasco, decimal? porcentajeconductor, decimal? porcentajepagounidad, decimal? baseacreditacion, decimal? carrerasvalidas, int? totalcarrerasvalidas, int? recibo, int? fondocaja, decimal? porcentajecomisionista, decimal? pagocomisionista, DateTime? diapagado, decimal? tarifacascoregresos)
            {
                this.Boleto = boleto;
                this.Precio = precio;
                this.PagoCasco = pagocasco;
                this.PagoConductor = pagoconductor;
                this.PagoUnidad = pagounidad;
                this.Fecha = fecha;
                this.Tipo = tipo;
                this.TarifaEbssa = tarifaebssa;
                this.TotalCasco = totalcasco;
                this.PorcentajeCasco = porcentajecasco;
                this.PorcentajeConductor = porcentajeconductor;
                this.PorcentajePagoUnidad = porcentajepagounidad;
                this.BaseAcreditacion = baseacreditacion;
                this.CarrerasValidas = carrerasvalidas;
                this.TotalCarrerasValidas = totalcarrerasvalidas;
                this.Recibo = recibo;
                this.FondoCaja = fondocaja;
                this.PorcentajeComisionista = porcentajecomisionista;
                this.PagoComisionista = pagocomisionista;
                this.DiaPagado = diapagado;
                this.TarifaCascoRegresos = tarifacascoregresos;
            }

            private string _Boleto;
            public string Boleto
            {
                get { return _Boleto; }
                set { _Boleto = value; }
            }

            private decimal? _Precio;
            public decimal? Precio
            {
                get { return _Precio; }
                set { _Precio = value; }
            }

            private decimal _PagoCasco;
            public decimal PagoCasco
            {
                get { return _PagoCasco; }
                set { _PagoCasco = value; }
            }

            private decimal _PagoConductor;
            public decimal PagoConductor
            {
                get { return _PagoConductor; }
                set { _PagoConductor = value; }
            }

            private decimal _PagoUnidad;
            public decimal PagoUnidad
            {
                get { return _PagoUnidad; }
                set { _PagoUnidad = value; }
            }

            private DateTime _Fecha;
            public DateTime Fecha
            {
                get { return _Fecha; }
                set { _Fecha = value; }
            }

            private int? _Tipo;
            public int? Tipo
            {
                get { return _Tipo; }
                set { _Tipo = value; }
            }

            private decimal? _TarifaEbssa;
            public decimal? TarifaEbssa
            {
                get { return _TarifaEbssa; }
                set { _TarifaEbssa = value; }
            }

            private decimal? _TotalCasco;
            public decimal? TotalCasco
            {
                get { return _TotalCasco; }
                set { _TotalCasco = value; }
            }

            private decimal? _PorcentajeCasco;
            public decimal? PorcentajeCasco
            {
                get { return _PorcentajeCasco; }
                set { _PorcentajeCasco = value; }
            }

            private decimal? _PorcentajeConductor;
            public decimal? PorcentajeConductor
            {
                get { return _PorcentajeConductor; }
                set { _PorcentajeConductor = value; }
            }

            private decimal? _PorcentajePagoUnidad;
            public decimal? PorcentajePagoUnidad
            {
                get { return _PorcentajePagoUnidad; }
                set { _PorcentajePagoUnidad = value; }
            }

            private decimal? _BaseAcreditacion;
            public decimal? BaseAcreditacion
            {
                get { return _BaseAcreditacion; }
                set { _BaseAcreditacion = value; }
            }

            private decimal? _CarrerasValidas;
            public decimal? CarrerasValidas
            {
                get { return _CarrerasValidas; }
                set { _CarrerasValidas = value; }
            }

            private int? _TotalCarrerasValidas;
            public int? TotalCarrerasValidas
            {
                get { return _TotalCarrerasValidas; }
                set { _TotalCarrerasValidas = value; }
            }

            private int? _Recibo;
            public int? Recibo
            {
                get { return _Recibo; }
                set { _Recibo = value; }
            }

            private int? _FondoCaja;
            public int? FondoCaja
            {
                get { return _FondoCaja; }
                set { _FondoCaja = value; }
            }

            private decimal? _PorcentajeComisionista;
            public decimal? PorcentajeComisionista
            {
                get { return _PorcentajeComisionista; }
                set { _PorcentajeComisionista = value; }
            }

            private decimal? _PagoComisionista;
            public decimal? PagoComisionista
            {
                get { return _PagoComisionista; }
                set { _PagoComisionista = value; }
            }

            private DateTime? _DiaPagado;
            public DateTime? DiaPagado
            {
                get { return _DiaPagado; }
                set { _DiaPagado = value; }
            }

            private decimal? _TarifaCascoRegresos;
            public decimal? TarifaCascoRegresos
            {
                get { return _TarifaCascoRegresos; }
                set { _TarifaCascoRegresos = value; }
            }

            public int Create()
            {
                Hashtable m_params = new Hashtable();
                m_params.Add("Boleto", this.Boleto);
                if (!AppHelper.IsNullOrEmpty(this.Precio)) m_params.Add("Precio", this.Precio);
                m_params.Add("PagoCasco", this.PagoCasco);
                m_params.Add("PagoConductor", this.PagoConductor);
                m_params.Add("PagoUnidad", this.PagoUnidad);
                m_params.Add("Fecha", this.Fecha);
                if (!AppHelper.IsNullOrEmpty(this.Tipo)) m_params.Add("Tipo", this.Tipo);
                if (!AppHelper.IsNullOrEmpty(this.TarifaEbssa)) m_params.Add("TarifaEbssa", this.TarifaEbssa);
                if (!AppHelper.IsNullOrEmpty(this.TotalCasco)) m_params.Add("TotalCasco", this.TotalCasco);
                if (!AppHelper.IsNullOrEmpty(this.PorcentajeCasco)) m_params.Add("PorcentajeCasco", this.PorcentajeCasco);
                if (!AppHelper.IsNullOrEmpty(this.PorcentajeConductor)) m_params.Add("PorcentajeConductor", this.PorcentajeConductor);
                if (!AppHelper.IsNullOrEmpty(this.PorcentajePagoUnidad)) m_params.Add("PorcentajePagoUnidad", this.PorcentajePagoUnidad);
                if (!AppHelper.IsNullOrEmpty(this.BaseAcreditacion)) m_params.Add("BaseAcreditacion", this.BaseAcreditacion);
                if (!AppHelper.IsNullOrEmpty(this.CarrerasValidas)) m_params.Add("CarrerasValidas", this.CarrerasValidas);
                if (!AppHelper.IsNullOrEmpty(this.TotalCarrerasValidas)) m_params.Add("TotalCarrerasValidas", this.TotalCarrerasValidas);
                if (!AppHelper.IsNullOrEmpty(this.Recibo)) m_params.Add("Recibo", this.Recibo);
                if (!AppHelper.IsNullOrEmpty(this.FondoCaja)) m_params.Add("FondoCaja", this.FondoCaja);
                if (!AppHelper.IsNullOrEmpty(this.PorcentajeComisionista)) m_params.Add("PorcentajeComisionista", this.PorcentajeComisionista);
                if (!AppHelper.IsNullOrEmpty(this.PagoComisionista)) m_params.Add("PagoComisionista", this.PagoComisionista);
                if (!AppHelper.IsNullOrEmpty(this.DiaPagado)) m_params.Add("DiaPagado", this.DiaPagado);
                if (!AppHelper.IsNullOrEmpty(this.TarifaCascoRegresos)) m_params.Add("TarifaCascoRegresos", this.TarifaCascoRegresos);

                return DB.InsertRow("PagoBoletos", m_params);
            } // End Create

            public static List<PagoBoletos> Read(string filter, string sort, params KeyValuePair<string,object>[] args)
            {
                List<PagoBoletos> list = new List<PagoBoletos>();
                DataTable dt = DB.Read("PagoBoletos", filter, sort, args);
                foreach (DataRow dr in dt.Rows)
                {
                    list.Add(new PagoBoletos(Convert.ToString(dr["Boleto"]), DB.GetNullableDecimal(dr["Precio"]), Convert.ToDecimal(dr["PagoCasco"]), Convert.ToDecimal(dr["PagoConductor"]), Convert.ToDecimal(dr["PagoUnidad"]), Convert.ToDateTime(dr["Fecha"]), DB.GetNullableInt32(dr["Tipo"]), DB.GetNullableDecimal(dr["TarifaEbssa"]), DB.GetNullableDecimal(dr["TotalCasco"]), DB.GetNullableDecimal(dr["PorcentajeCasco"]), DB.GetNullableDecimal(dr["PorcentajeConductor"]), DB.GetNullableDecimal(dr["PorcentajePagoUnidad"]), DB.GetNullableDecimal(dr["BaseAcreditacion"]), DB.GetNullableDecimal(dr["CarrerasValidas"]), DB.GetNullableInt32(dr["TotalCarrerasValidas"]), DB.GetNullableInt32(dr["Recibo"]), DB.GetNullableInt32(dr["FondoCaja"]), DB.GetNullableDecimal(dr["PorcentajeComisionista"]), DB.GetNullableDecimal(dr["PagoComisionista"]), DB.GetNullableDateTime(dr["DiaPagado"]), DB.GetNullableDecimal(dr["TarifaCascoRegresos"])));
                }

                return list;
            } // End Read

            public static List<PagoBoletos> Read()
            {
                List<PagoBoletos> list = new List<PagoBoletos>();
                DataTable dt = DB.Select("PagoBoletos");
                foreach (DataRow dr in dt.Rows)
                {
                    list.Add(new PagoBoletos(Convert.ToString(dr["Boleto"]), DB.GetNullableDecimal(dr["Precio"]), Convert.ToDecimal(dr["PagoCasco"]), Convert.ToDecimal(dr["PagoConductor"]), Convert.ToDecimal(dr["PagoUnidad"]), Convert.ToDateTime(dr["Fecha"]), DB.GetNullableInt32(dr["Tipo"]), DB.GetNullableDecimal(dr["TarifaEbssa"]), DB.GetNullableDecimal(dr["TotalCasco"]), DB.GetNullableDecimal(dr["PorcentajeCasco"]), DB.GetNullableDecimal(dr["PorcentajeConductor"]), DB.GetNullableDecimal(dr["PorcentajePagoUnidad"]), DB.GetNullableDecimal(dr["BaseAcreditacion"]), DB.GetNullableDecimal(dr["CarrerasValidas"]), DB.GetNullableInt32(dr["TotalCarrerasValidas"]), DB.GetNullableInt32(dr["Recibo"]), DB.GetNullableInt32(dr["FondoCaja"]), DB.GetNullableDecimal(dr["PorcentajeComisionista"]), DB.GetNullableDecimal(dr["PagoComisionista"]), DB.GetNullableDateTime(dr["DiaPagado"]), DB.GetNullableDecimal(dr["TarifaCascoRegresos"])));
                }

                return list;
            } // End Read

            public static PagoBoletos Read(string boleto)
            {
                Hashtable w_params = new Hashtable();
                w_params.Add("Boleto", boleto);
                DataTable dt = DB.Select("PagoBoletos", w_params);
                if (dt.Rows.Count == 0)
                {
                    return null;
                }
                DataRow dr = dt.Rows[0];
                return new PagoBoletos(Convert.ToString(dr["Boleto"]), DB.GetNullableDecimal(dr["Precio"]), Convert.ToDecimal(dr["PagoCasco"]), Convert.ToDecimal(dr["PagoConductor"]), Convert.ToDecimal(dr["PagoUnidad"]), Convert.ToDateTime(dr["Fecha"]), DB.GetNullableInt32(dr["Tipo"]), DB.GetNullableDecimal(dr["TarifaEbssa"]), DB.GetNullableDecimal(dr["TotalCasco"]), DB.GetNullableDecimal(dr["PorcentajeCasco"]), DB.GetNullableDecimal(dr["PorcentajeConductor"]), DB.GetNullableDecimal(dr["PorcentajePagoUnidad"]), DB.GetNullableDecimal(dr["BaseAcreditacion"]), DB.GetNullableDecimal(dr["CarrerasValidas"]), DB.GetNullableInt32(dr["TotalCarrerasValidas"]), DB.GetNullableInt32(dr["Recibo"]), DB.GetNullableInt32(dr["FondoCaja"]), DB.GetNullableDecimal(dr["PorcentajeComisionista"]), DB.GetNullableDecimal(dr["PagoComisionista"]), DB.GetNullableDateTime(dr["DiaPagado"]), DB.GetNullableDecimal(dr["TarifaCascoRegresos"]));
            } // End Read

            public int Update()
            {
                Hashtable m_params = new Hashtable();
                Hashtable w_params = new Hashtable();
                w_params.Add("Boleto", this.Boleto);
                if (!AppHelper.IsNullOrEmpty(this.Precio)) m_params.Add("Precio", this.Precio);
                m_params.Add("PagoCasco", this.PagoCasco);
                m_params.Add("PagoConductor", this.PagoConductor);
                m_params.Add("PagoUnidad", this.PagoUnidad);
                m_params.Add("Fecha", this.Fecha);
                if (!AppHelper.IsNullOrEmpty(this.Tipo)) m_params.Add("Tipo", this.Tipo);
                if (!AppHelper.IsNullOrEmpty(this.TarifaEbssa)) m_params.Add("TarifaEbssa", this.TarifaEbssa);
                if (!AppHelper.IsNullOrEmpty(this.TotalCasco)) m_params.Add("TotalCasco", this.TotalCasco);
                if (!AppHelper.IsNullOrEmpty(this.PorcentajeCasco)) m_params.Add("PorcentajeCasco", this.PorcentajeCasco);
                if (!AppHelper.IsNullOrEmpty(this.PorcentajeConductor)) m_params.Add("PorcentajeConductor", this.PorcentajeConductor);
                if (!AppHelper.IsNullOrEmpty(this.PorcentajePagoUnidad)) m_params.Add("PorcentajePagoUnidad", this.PorcentajePagoUnidad);
                if (!AppHelper.IsNullOrEmpty(this.BaseAcreditacion)) m_params.Add("BaseAcreditacion", this.BaseAcreditacion);
                if (!AppHelper.IsNullOrEmpty(this.CarrerasValidas)) m_params.Add("CarrerasValidas", this.CarrerasValidas);
                if (!AppHelper.IsNullOrEmpty(this.TotalCarrerasValidas)) m_params.Add("TotalCarrerasValidas", this.TotalCarrerasValidas);
                if (!AppHelper.IsNullOrEmpty(this.Recibo)) m_params.Add("Recibo", this.Recibo);
                if (!AppHelper.IsNullOrEmpty(this.FondoCaja)) m_params.Add("FondoCaja", this.FondoCaja);
                if (!AppHelper.IsNullOrEmpty(this.PorcentajeComisionista)) m_params.Add("PorcentajeComisionista", this.PorcentajeComisionista);
                if (!AppHelper.IsNullOrEmpty(this.PagoComisionista)) m_params.Add("PagoComisionista", this.PagoComisionista);
                if (!AppHelper.IsNullOrEmpty(this.DiaPagado)) m_params.Add("DiaPagado", this.DiaPagado);
                if (!AppHelper.IsNullOrEmpty(this.TarifaCascoRegresos)) m_params.Add("TarifaCascoRegresos", this.TarifaCascoRegresos);

                return DB.UpdateRow("PagoBoletos", m_params, w_params);
            } // End Update

            public int Delete()
            {
                Hashtable w_params = new Hashtable();
                w_params.Add("Boleto", this.Boleto);

                return DB.DeleteRow("PagoBoletos", w_params);
            } // End Delete

        } //End Class PagoBoletos

        public class PercancesUnidades
        {

            public PercancesUnidades()
            {
            }

            public PercancesUnidades(int folio, int? tipopercance, int? conductor, int? unidad, DateTime? fechapercance, string comentarios, int? tipoparticipacion)
            {
                this.Folio = folio;
                this.TipoPercance = tipopercance;
                this.Conductor = conductor;
                this.Unidad = unidad;
                this.FechaPercance = fechapercance;
                this.Comentarios = comentarios;
                this.TipoParticipacion = tipoparticipacion;
            }

            private int _Folio;
            public int Folio
            {
                get { return _Folio; }
                set { _Folio = value; }
            }

            private int? _TipoPercance;
            public int? TipoPercance
            {
                get { return _TipoPercance; }
                set { _TipoPercance = value; }
            }

            private int? _Conductor;
            public int? Conductor
            {
                get { return _Conductor; }
                set { _Conductor = value; }
            }

            private int? _Unidad;
            public int? Unidad
            {
                get { return _Unidad; }
                set { _Unidad = value; }
            }

            private DateTime? _FechaPercance;
            public DateTime? FechaPercance
            {
                get { return _FechaPercance; }
                set { _FechaPercance = value; }
            }

            private string _Comentarios;
            public string Comentarios
            {
                get { return _Comentarios; }
                set { _Comentarios = value; }
            }

            private int? _TipoParticipacion;
            public int? TipoParticipacion
            {
                get { return _TipoParticipacion; }
                set { _TipoParticipacion = value; }
            }

            public int Create()
            {
                Hashtable m_params = new Hashtable();
                if (!AppHelper.IsNullOrEmpty(this.TipoPercance)) m_params.Add("TipoPercance", this.TipoPercance);
                if (!AppHelper.IsNullOrEmpty(this.Conductor)) m_params.Add("Conductor", this.Conductor);
                if (!AppHelper.IsNullOrEmpty(this.Unidad)) m_params.Add("Unidad", this.Unidad);
                if (!AppHelper.IsNullOrEmpty(this.FechaPercance)) m_params.Add("FechaPercance", this.FechaPercance);
                if (!AppHelper.IsNullOrEmpty(this.Comentarios)) m_params.Add("Comentarios", this.Comentarios);
                if (!AppHelper.IsNullOrEmpty(this.TipoParticipacion)) m_params.Add("TipoParticipacion", this.TipoParticipacion);

                return DB.InsertRow("PercancesUnidades", m_params);
            } // End Create

            public static List<PercancesUnidades> Read()
            {
                List<PercancesUnidades> list = new List<PercancesUnidades>();
                DataTable dt = DB.Select("PercancesUnidades");
                foreach (DataRow dr in dt.Rows)
                {
                    list.Add(new PercancesUnidades(Convert.ToInt32(dr["Folio"]), DB.GetNullableInt32(dr["TipoPercance"]), DB.GetNullableInt32(dr["Conductor"]), DB.GetNullableInt32(dr["Unidad"]), DB.GetNullableDateTime(dr["FechaPercance"]), Convert.ToString(dr["Comentarios"]), DB.GetNullableInt32(dr["TipoParticipacion"])));
                }

                return list;
            } // End Read

            public static PercancesUnidades Read(int folio)
            {
                Hashtable w_params = new Hashtable();
                w_params.Add("Folio", folio);
                DataTable dt = DB.Select("PercancesUnidades", w_params);
                if (dt.Rows.Count == 0)
                {
                    throw new Exception("No existe PercancesUnidades con los criterios de búsqueda especificados.");
                }
                DataRow dr = dt.Rows[0];
                return new PercancesUnidades(Convert.ToInt32(dr["Folio"]), DB.GetNullableInt32(dr["TipoPercance"]), DB.GetNullableInt32(dr["Conductor"]), DB.GetNullableInt32(dr["Unidad"]), DB.GetNullableDateTime(dr["FechaPercance"]), Convert.ToString(dr["Comentarios"]), DB.GetNullableInt32(dr["TipoParticipacion"]));
            } // End Read

            public int Update()
            {
                Hashtable m_params = new Hashtable();
                Hashtable w_params = new Hashtable();
                w_params.Add("Folio", this.Folio);
                if (!AppHelper.IsNullOrEmpty(this.TipoPercance)) m_params.Add("TipoPercance", this.TipoPercance);
                if (!AppHelper.IsNullOrEmpty(this.Conductor)) m_params.Add("Conductor", this.Conductor);
                if (!AppHelper.IsNullOrEmpty(this.Unidad)) m_params.Add("Unidad", this.Unidad);
                if (!AppHelper.IsNullOrEmpty(this.FechaPercance)) m_params.Add("FechaPercance", this.FechaPercance);
                if (!AppHelper.IsNullOrEmpty(this.Comentarios)) m_params.Add("Comentarios", this.Comentarios);
                if (!AppHelper.IsNullOrEmpty(this.TipoParticipacion)) m_params.Add("TipoParticipacion", this.TipoParticipacion);

                return DB.UpdateRow("PercancesUnidades", m_params, w_params);
            } // End Update

            public int Delete()
            {
                Hashtable w_params = new Hashtable();
                w_params.Add("Folio", this.Folio);

                return DB.DeleteRow("PercancesUnidades", w_params);
            } // End Delete

        } //End Class PercancesUnidades

        public class PlanesDePagos
        {

            public PlanesDePagos()
            {
            }

            public PlanesDePagos(int plandepagoid, int conductor, int unidad, int numeroeconomico, int conceptocobro, string comentarios, decimal montodiario, DateTime fechainicial, DateTime? fechafinal, int estado, string usuario, DateTime fecha)
            {
                this.PlanDePagoID = plandepagoid;
                this.Conductor = conductor;
                this.Unidad = unidad;
                this.NumeroEconomico = numeroeconomico;
                this.ConceptoCobro = conceptocobro;
                this.Comentarios = comentarios;
                this.MontoDiario = montodiario;
                this.FechaInicial = fechainicial;
                this.FechaFinal = fechafinal;
                this.Estado = estado;
                this.Usuario = usuario;
                this.Fecha = fecha;
            }

            private int _PlanDePagoID;
            public int PlanDePagoID
            {
                get { return _PlanDePagoID; }
                set { _PlanDePagoID = value; }
            }

            private int _Conductor;
            public int Conductor
            {
                get { return _Conductor; }
                set { _Conductor = value; }
            }

            private int _Unidad;
            public int Unidad
            {
                get { return _Unidad; }
                set { _Unidad = value; }
            }

            private int _NumeroEconomico;
            public int NumeroEconomico
            {
                get { return _NumeroEconomico; }
                set { _NumeroEconomico = value; }
            }

            private int _ConceptoCobro;
            public int ConceptoCobro
            {
                get { return _ConceptoCobro; }
                set { _ConceptoCobro = value; }
            }

            private string _Comentarios;
            public string Comentarios
            {
                get { return _Comentarios; }
                set { _Comentarios = value; }
            }

            private decimal _MontoDiario;
            public decimal MontoDiario
            {
                get { return _MontoDiario; }
                set { _MontoDiario = value; }
            }

            private DateTime _FechaInicial;
            public DateTime FechaInicial
            {
                get { return _FechaInicial; }
                set { _FechaInicial = value; }
            }

            private DateTime? _FechaFinal;
            public DateTime? FechaFinal
            {
                get { return _FechaFinal; }
                set { _FechaFinal = value; }
            }

            private int _Estado;
            public int Estado
            {
                get { return _Estado; }
                set { _Estado = value; }
            }

            private string _Usuario;
            public string Usuario
            {
                get { return _Usuario; }
                set { _Usuario = value; }
            }

            private DateTime _Fecha;
            public DateTime Fecha
            {
                get { return _Fecha; }
                set { _Fecha = value; }
            }

            public int Create()
            {
                Hashtable m_params = new Hashtable();
                m_params.Add("Conductor", this.Conductor);
                m_params.Add("Unidad", this.Unidad);
                m_params.Add("NumeroEconomico", this.NumeroEconomico);
                m_params.Add("ConceptoCobro", this.ConceptoCobro);
                m_params.Add("Comentarios", this.Comentarios);
                m_params.Add("MontoDiario", this.MontoDiario);
                m_params.Add("FechaInicial", this.FechaInicial);
                if (!AppHelper.IsNullOrEmpty(this.FechaFinal)) m_params.Add("FechaFinal", this.FechaFinal);
                m_params.Add("Estado", this.Estado);
                m_params.Add("Usuario", this.Usuario);
                m_params.Add("Fecha", this.Fecha);

                return DB.InsertRow("PlanesDePagos", m_params);
            } // End Create

            public static List<PlanesDePagos> Read()
            {
                List<PlanesDePagos> list = new List<PlanesDePagos>();
                DataTable dt = DB.Select("PlanesDePagos");
                foreach (DataRow dr in dt.Rows)
                {
                    list.Add(new PlanesDePagos(Convert.ToInt32(dr["PlanDePagoID"]), Convert.ToInt32(dr["Conductor"]), Convert.ToInt32(dr["Unidad"]), Convert.ToInt32(dr["NumeroEconomico"]), Convert.ToInt32(dr["ConceptoCobro"]), Convert.ToString(dr["Comentarios"]), Convert.ToDecimal(dr["MontoDiario"]), Convert.ToDateTime(dr["FechaInicial"]), DB.GetNullableDateTime(dr["FechaFinal"]), Convert.ToInt32(dr["Estado"]), Convert.ToString(dr["Usuario"]), Convert.ToDateTime(dr["Fecha"])));
                }

                return list;
            } // End Read

            public static PlanesDePagos Read(int plandepagoid)
            {
                Hashtable w_params = new Hashtable();
                w_params.Add("PlanDePagoID", plandepagoid);
                DataTable dt = DB.Select("PlanesDePagos", w_params);
                if (dt.Rows.Count == 0)
                {
                    throw new Exception("No existe PlanesDePagos con los criterios de búsqueda especificados.");
                }
                DataRow dr = dt.Rows[0];
                return new PlanesDePagos(Convert.ToInt32(dr["PlanDePagoID"]), Convert.ToInt32(dr["Conductor"]), Convert.ToInt32(dr["Unidad"]), Convert.ToInt32(dr["NumeroEconomico"]), Convert.ToInt32(dr["ConceptoCobro"]), Convert.ToString(dr["Comentarios"]), Convert.ToDecimal(dr["MontoDiario"]), Convert.ToDateTime(dr["FechaInicial"]), DB.GetNullableDateTime(dr["FechaFinal"]), Convert.ToInt32(dr["Estado"]), Convert.ToString(dr["Usuario"]), Convert.ToDateTime(dr["Fecha"]));
            } // End Read

            public int Update()
            {
                Hashtable m_params = new Hashtable();
                Hashtable w_params = new Hashtable();
                w_params.Add("PlanDePagoID", this.PlanDePagoID);
                m_params.Add("Conductor", this.Conductor);
                m_params.Add("Unidad", this.Unidad);
                m_params.Add("NumeroEconomico", this.NumeroEconomico);
                m_params.Add("ConceptoCobro", this.ConceptoCobro);
                m_params.Add("Comentarios", this.Comentarios);
                m_params.Add("MontoDiario", this.MontoDiario);
                m_params.Add("FechaInicial", this.FechaInicial);
                if (!AppHelper.IsNullOrEmpty(this.FechaFinal)) m_params.Add("FechaFinal", this.FechaFinal);
                m_params.Add("Estado", this.Estado);
                m_params.Add("Usuario", this.Usuario);
                m_params.Add("Fecha", this.Fecha);

                return DB.UpdateRow("PlanesDePagos", m_params, w_params);
            } // End Update

            public int Delete()
            {
                Hashtable w_params = new Hashtable();
                w_params.Add("PlanDePagoID", this.PlanDePagoID);

                return DB.DeleteRow("PlanesDePagos", w_params);
            } // End Delete

        } //End Class PlanesDePagos

        public class PlanesDeRenta
        {

            public PlanesDeRenta()
            {
            }

            public PlanesDeRenta(int folio, string nombre, int categoria, int modelo, bool lunes, bool martes, bool miercoles, bool jueves, bool viernes, bool sabado, bool domingo, decimal cuotarenta, string usuario, DateTime fecha, bool? activo)
            {
                this.Folio = folio;
                this.Nombre = nombre;
                this.Categoria = categoria;
                this.Modelo = modelo;
                this.Lunes = lunes;
                this.Martes = martes;
                this.Miercoles = miercoles;
                this.Jueves = jueves;
                this.Viernes = viernes;
                this.Sabado = sabado;
                this.Domingo = domingo;
                this.CuotaRenta = cuotarenta;
                this.Usuario = usuario;
                this.Fecha = fecha;
                this.Activo = activo;
            }

            private int _Folio;
            public int Folio
            {
                get { return _Folio; }
                set { _Folio = value; }
            }

            private string _Nombre;
            public string Nombre
            {
                get { return _Nombre; }
                set { _Nombre = value; }
            }

            private int _Categoria;
            public int Categoria
            {
                get { return _Categoria; }
                set { _Categoria = value; }
            }

            private int _Modelo;
            public int Modelo
            {
                get { return _Modelo; }
                set { _Modelo = value; }
            }

            private bool _Lunes;
            public bool Lunes
            {
                get { return _Lunes; }
                set { _Lunes = value; }
            }

            private bool _Martes;
            public bool Martes
            {
                get { return _Martes; }
                set { _Martes = value; }
            }

            private bool _Miercoles;
            public bool Miercoles
            {
                get { return _Miercoles; }
                set { _Miercoles = value; }
            }

            private bool _Jueves;
            public bool Jueves
            {
                get { return _Jueves; }
                set { _Jueves = value; }
            }

            private bool _Viernes;
            public bool Viernes
            {
                get { return _Viernes; }
                set { _Viernes = value; }
            }

            private bool _Sabado;
            public bool Sabado
            {
                get { return _Sabado; }
                set { _Sabado = value; }
            }

            private bool _Domingo;
            public bool Domingo
            {
                get { return _Domingo; }
                set { _Domingo = value; }
            }

            private decimal _CuotaRenta;
            public decimal CuotaRenta
            {
                get { return _CuotaRenta; }
                set { _CuotaRenta = value; }
            }

            private string _Usuario;
            public string Usuario
            {
                get { return _Usuario; }
                set { _Usuario = value; }
            }

            private DateTime _Fecha;
            public DateTime Fecha
            {
                get { return _Fecha; }
                set { _Fecha = value; }
            }

            private bool? _Activo;
            public bool? Activo
            {
                get { return _Activo; }
                set { _Activo = value; }
            }

            public int Create()
            {
                Hashtable m_params = new Hashtable();
                m_params.Add("Nombre", this.Nombre);
                m_params.Add("Categoria", this.Categoria);
                m_params.Add("Modelo", this.Modelo);
                m_params.Add("Lunes", this.Lunes);
                m_params.Add("Martes", this.Martes);
                m_params.Add("Miercoles", this.Miercoles);
                m_params.Add("Jueves", this.Jueves);
                m_params.Add("Viernes", this.Viernes);
                m_params.Add("Sabado", this.Sabado);
                m_params.Add("Domingo", this.Domingo);
                m_params.Add("CuotaRenta", this.CuotaRenta);
                m_params.Add("Usuario", this.Usuario);
                m_params.Add("Fecha", this.Fecha);
                if (!AppHelper.IsNullOrEmpty(this.Activo)) m_params.Add("Activo", this.Activo);

                return DB.InsertRow("PlanesDeRenta", m_params);
            } // End Create

            public static List<PlanesDeRenta> Read()
            {
                List<PlanesDeRenta> list = new List<PlanesDeRenta>();
                DataTable dt = DB.Select("PlanesDeRenta");
                foreach (DataRow dr in dt.Rows)
                {
                    list.Add(new PlanesDeRenta(Convert.ToInt32(dr["Folio"]), Convert.ToString(dr["Nombre"]), Convert.ToInt32(dr["Categoria"]), Convert.ToInt32(dr["Modelo"]), Convert.ToBoolean(dr["Lunes"]), Convert.ToBoolean(dr["Martes"]), Convert.ToBoolean(dr["Miercoles"]), Convert.ToBoolean(dr["Jueves"]), Convert.ToBoolean(dr["Viernes"]), Convert.ToBoolean(dr["Sabado"]), Convert.ToBoolean(dr["Domingo"]), Convert.ToDecimal(dr["CuotaRenta"]), Convert.ToString(dr["Usuario"]), Convert.ToDateTime(dr["Fecha"]), DB.GetNullableBoolean(dr["Activo"])));
                }

                return list;
            } // End Read

            public static PlanesDeRenta Read(int folio)
            {
                Hashtable w_params = new Hashtable();
                w_params.Add("Folio", folio);
                DataTable dt = DB.Select("PlanesDeRenta", w_params);
                if (dt.Rows.Count == 0)
                {
                    return null;
                }
                DataRow dr = dt.Rows[0];
                return new PlanesDeRenta(Convert.ToInt32(dr["Folio"]), Convert.ToString(dr["Nombre"]), Convert.ToInt32(dr["Categoria"]), Convert.ToInt32(dr["Modelo"]), Convert.ToBoolean(dr["Lunes"]), Convert.ToBoolean(dr["Martes"]), Convert.ToBoolean(dr["Miercoles"]), Convert.ToBoolean(dr["Jueves"]), Convert.ToBoolean(dr["Viernes"]), Convert.ToBoolean(dr["Sabado"]), Convert.ToBoolean(dr["Domingo"]), Convert.ToDecimal(dr["CuotaRenta"]), Convert.ToString(dr["Usuario"]), Convert.ToDateTime(dr["Fecha"]), DB.GetNullableBoolean(dr["Activo"]));
            } // End Read

            public int Update()
            {
                Hashtable m_params = new Hashtable();
                Hashtable w_params = new Hashtable();
                w_params.Add("Folio", this.Folio);
                m_params.Add("Nombre", this.Nombre);
                m_params.Add("Categoria", this.Categoria);
                m_params.Add("Modelo", this.Modelo);
                m_params.Add("Lunes", this.Lunes);
                m_params.Add("Martes", this.Martes);
                m_params.Add("Miercoles", this.Miercoles);
                m_params.Add("Jueves", this.Jueves);
                m_params.Add("Viernes", this.Viernes);
                m_params.Add("Sabado", this.Sabado);
                m_params.Add("Domingo", this.Domingo);
                m_params.Add("CuotaRenta", this.CuotaRenta);
                m_params.Add("Usuario", this.Usuario);
                m_params.Add("Fecha", this.Fecha);
                if (!AppHelper.IsNullOrEmpty(this.Activo)) m_params.Add("Activo", this.Activo);

                return DB.UpdateRow("PlanesDeRenta", m_params, w_params);
            } // End Update

            public int Delete()
            {
                Hashtable w_params = new Hashtable();
                w_params.Add("Folio", this.Folio);

                return DB.DeleteRow("PlanesDeRenta", w_params);
            } // End Delete

        } //End Class PlanesDeRenta

        public class Productos_OXXOGas
        {

            public Productos_OXXOGas()
            {
            }

            public Productos_OXXOGas(string producto_id, string descripcion, decimal precio)
            {
                this.Producto_ID = producto_id;
                this.Descripcion = descripcion;
                this.Precio = precio;
            }

            private string _Producto_ID;
            public string Producto_ID
            {
                get { return _Producto_ID; }
                set { _Producto_ID = value; }
            }

            private string _Descripcion;
            public string Descripcion
            {
                get { return _Descripcion; }
                set { _Descripcion = value; }
            }

            private decimal _Precio;
            public decimal Precio
            {
                get { return _Precio; }
                set { _Precio = value; }
            }

            public int Create()
            {
                Hashtable m_params = new Hashtable();
                m_params.Add("Producto_ID", this.Producto_ID);
                m_params.Add("Descripcion", this.Descripcion);
                m_params.Add("Precio", this.Precio);

                return DB.InsertRow("Productos_OXXOGas", m_params);
            } // End Create

            public static List<Productos_OXXOGas> Read()
            {
                List<Productos_OXXOGas> list = new List<Productos_OXXOGas>();
                DataTable dt = DB.Select("Productos_OXXOGas");
                foreach (DataRow dr in dt.Rows)
                {
                    list.Add(new Productos_OXXOGas(Convert.ToString(dr["Producto_ID"]), Convert.ToString(dr["Descripcion"]), Convert.ToDecimal(dr["Precio"])));
                }

                return list;
            } // End Read

            public static Productos_OXXOGas Read(string producto_id)
            {
                Hashtable w_params = new Hashtable();
                w_params.Add("Producto_ID", producto_id);
                DataTable dt = DB.Select("Productos_OXXOGas", w_params);
                if (dt.Rows.Count == 0)
                {
                    throw new Exception("No existe Productos_OXXOGas con los criterios de búsqueda especificados.");
                }
                DataRow dr = dt.Rows[0];
                return new Productos_OXXOGas(Convert.ToString(dr["Producto_ID"]), Convert.ToString(dr["Descripcion"]), Convert.ToDecimal(dr["Precio"]));
            } // End Read

            public int Update()
            {
                Hashtable m_params = new Hashtable();
                Hashtable w_params = new Hashtable();
                w_params.Add("Producto_ID", this.Producto_ID);
                m_params.Add("Descripcion", this.Descripcion);
                m_params.Add("Precio", this.Precio);

                return DB.UpdateRow("Productos_OXXOGas", m_params, w_params);
            } // End Update

            public int Delete()
            {
                Hashtable w_params = new Hashtable();
                w_params.Add("Producto_ID", this.Producto_ID);

                return DB.DeleteRow("Productos_OXXOGas", w_params);
            } // End Delete

        } //End Class Productos_OXXOGas

        public class ProgramaMantenimientos
        {

            public ProgramaMantenimientos()
            {
            }

            public ProgramaMantenimientos(int unidad, int kilometrajeproximomantenimiento, DateTime? fechaproximomantenimiento)
            {
                this.Unidad = unidad;
                this.KilometrajeProximoMantenimiento = kilometrajeproximomantenimiento;
                this.FechaProximoMantenimiento = fechaproximomantenimiento;
            }

            private int _Unidad;
            public int Unidad
            {
                get { return _Unidad; }
                set { _Unidad = value; }
            }

            private int _KilometrajeProximoMantenimiento;
            public int KilometrajeProximoMantenimiento
            {
                get { return _KilometrajeProximoMantenimiento; }
                set { _KilometrajeProximoMantenimiento = value; }
            }

            private DateTime? _FechaProximoMantenimiento;
            public DateTime? FechaProximoMantenimiento
            {
                get { return _FechaProximoMantenimiento; }
                set { _FechaProximoMantenimiento = value; }
            }

            public int Create()
            {
                Hashtable m_params = new Hashtable();
                m_params.Add("Unidad", this.Unidad);
                m_params.Add("KilometrajeProximoMantenimiento", this.KilometrajeProximoMantenimiento);
                if (!AppHelper.IsNullOrEmpty(this.FechaProximoMantenimiento)) m_params.Add("FechaProximoMantenimiento", this.FechaProximoMantenimiento);

                return DB.InsertRow("ProgramaMantenimientos", m_params);
            } // End Create

            public static List<ProgramaMantenimientos> Read()
            {
                List<ProgramaMantenimientos> list = new List<ProgramaMantenimientos>();
                DataTable dt = DB.Select("ProgramaMantenimientos");
                foreach (DataRow dr in dt.Rows)
                {
                    list.Add(new ProgramaMantenimientos(Convert.ToInt32(dr["Unidad"]), Convert.ToInt32(dr["KilometrajeProximoMantenimiento"]), DB.GetNullableDateTime(dr["FechaProximoMantenimiento"])));
                }

                return list;
            } // End Read

            public int Update()
            {
                Hashtable m_params = new Hashtable();
                Hashtable w_params = new Hashtable();
                m_params.Add("Unidad", this.Unidad);
                m_params.Add("KilometrajeProximoMantenimiento", this.KilometrajeProximoMantenimiento);
                if (!AppHelper.IsNullOrEmpty(this.FechaProximoMantenimiento)) m_params.Add("FechaProximoMantenimiento", this.FechaProximoMantenimiento);

                return DB.UpdateRow("ProgramaMantenimientos", m_params, w_params);
            } // End Update

            public int Delete()
            {
                Hashtable w_params = new Hashtable();

                return DB.DeleteRow("ProgramaMantenimientos", w_params);
            } // End Delete

        } //End Class ProgramaMantenimientos

        public class ProveedoresValesCombustible
        {

            public ProveedoresValesCombustible()
            {
            }

            public ProveedoresValesCombustible(int folio, string descripcion)
            {
                this.Folio = folio;
                this.Descripcion = descripcion;
            }

            private int _Folio;
            public int Folio
            {
                get { return _Folio; }
                set { _Folio = value; }
            }

            private string _Descripcion;
            public string Descripcion
            {
                get { return _Descripcion; }
                set { _Descripcion = value; }
            }

            public int Create()
            {
                Hashtable m_params = new Hashtable();
                if (!AppHelper.IsNullOrEmpty(this.Descripcion)) m_params.Add("Descripcion", this.Descripcion);

                return DB.InsertRow("ProveedoresValesCombustible", m_params);
            } // End Create

            public static List<ProveedoresValesCombustible> Read()
            {
                List<ProveedoresValesCombustible> list = new List<ProveedoresValesCombustible>();
                DataTable dt = DB.Select("ProveedoresValesCombustible");
                foreach (DataRow dr in dt.Rows)
                {
                    list.Add(new ProveedoresValesCombustible(Convert.ToInt32(dr["Folio"]), Convert.ToString(dr["Descripcion"])));
                }

                return list;
            } // End Read

            public static ProveedoresValesCombustible Read(int folio)
            {
                Hashtable w_params = new Hashtable();
                w_params.Add("Folio", folio);
                DataTable dt = DB.Select("ProveedoresValesCombustible", w_params);
                if (dt.Rows.Count == 0)
                {
                    throw new Exception("No existe ProveedoresValesCombustible con los criterios de búsqueda especificados.");
                }
                DataRow dr = dt.Rows[0];
                return new ProveedoresValesCombustible(Convert.ToInt32(dr["Folio"]), Convert.ToString(dr["Descripcion"]));
            } // End Read

            public int Update()
            {
                Hashtable m_params = new Hashtable();
                Hashtable w_params = new Hashtable();
                w_params.Add("Folio", this.Folio);
                if (!AppHelper.IsNullOrEmpty(this.Descripcion)) m_params.Add("Descripcion", this.Descripcion);

                return DB.UpdateRow("ProveedoresValesCombustible", m_params, w_params);
            } // End Update

            public int Delete()
            {
                Hashtable w_params = new Hashtable();
                w_params.Add("Folio", this.Folio);

                return DB.DeleteRow("ProveedoresValesCombustible", w_params);
            } // End Delete

        } //End Class ProveedoresValesCombustible

        public class RecibosAeropuerto
        {

            public RecibosAeropuerto()
            {
            }

            public RecibosAeropuerto(int folio, int conductor, int unidad, decimal? ingresoservicios, decimal? cargos, decimal? totalconductor, decimal? valescombustible, DateTime? fecha, int? categoriaconductor)
            {
                this.Folio = folio;
                this.Conductor = conductor;
                this.Unidad = unidad;
                this.IngresoServicios = ingresoservicios;
                this.Cargos = cargos;
                this.TotalConductor = totalconductor;
                this.ValesCombustible = valescombustible;
                this.Fecha = fecha;
                this.CategoriaConductor = categoriaconductor;
            }

            private int _Folio;
            public int Folio
            {
                get { return _Folio; }
                set { _Folio = value; }
            }

            private int _Conductor;
            public int Conductor
            {
                get { return _Conductor; }
                set { _Conductor = value; }
            }

            private int _Unidad;
            public int Unidad
            {
                get { return _Unidad; }
                set { _Unidad = value; }
            }

            private decimal? _IngresoServicios;
            public decimal? IngresoServicios
            {
                get { return _IngresoServicios; }
                set { _IngresoServicios = value; }
            }

            private decimal? _Cargos;
            public decimal? Cargos
            {
                get { return _Cargos; }
                set { _Cargos = value; }
            }

            private decimal? _TotalConductor;
            public decimal? TotalConductor
            {
                get { return _TotalConductor; }
                set { _TotalConductor = value; }
            }

            private decimal? _ValesCombustible;
            public decimal? ValesCombustible
            {
                get { return _ValesCombustible; }
                set { _ValesCombustible = value; }
            }

            private DateTime? _Fecha;
            public DateTime? Fecha
            {
                get { return _Fecha; }
                set { _Fecha = value; }
            }

            private int? _CategoriaConductor;
            public int? CategoriaConductor
            {
                get { return _CategoriaConductor; }
                set { _CategoriaConductor = value; }
            }

            public int Create()
            {
                Hashtable m_params = new Hashtable();
                m_params.Add("Conductor", this.Conductor);
                m_params.Add("Unidad", this.Unidad);
                if (!AppHelper.IsNullOrEmpty(this.IngresoServicios)) m_params.Add("IngresoServicios", this.IngresoServicios);
                if (!AppHelper.IsNullOrEmpty(this.Cargos)) m_params.Add("Cargos", this.Cargos);
                if (!AppHelper.IsNullOrEmpty(this.TotalConductor)) m_params.Add("TotalConductor", this.TotalConductor);
                if (!AppHelper.IsNullOrEmpty(this.ValesCombustible)) m_params.Add("ValesCombustible", this.ValesCombustible);
                if (!AppHelper.IsNullOrEmpty(this.Fecha)) m_params.Add("Fecha", this.Fecha);
                if (!AppHelper.IsNullOrEmpty(this.CategoriaConductor)) m_params.Add("CategoriaConductor", this.CategoriaConductor);

                return DB.InsertRow("RecibosAeropuerto", m_params);
            } // End Create

            public static List<RecibosAeropuerto> Read()
            {
                List<RecibosAeropuerto> list = new List<RecibosAeropuerto>();
                DataTable dt = DB.Select("RecibosAeropuerto");
                foreach (DataRow dr in dt.Rows)
                {
                    list.Add(new RecibosAeropuerto(Convert.ToInt32(dr["Folio"]), Convert.ToInt32(dr["Conductor"]), Convert.ToInt32(dr["Unidad"]), DB.GetNullableDecimal(dr["IngresoServicios"]), DB.GetNullableDecimal(dr["Cargos"]), DB.GetNullableDecimal(dr["TotalConductor"]), DB.GetNullableDecimal(dr["ValesCombustible"]), DB.GetNullableDateTime(dr["Fecha"]), DB.GetNullableInt32(dr["CategoriaConductor"])));
                }

                return list;
            } // End Read

            public static RecibosAeropuerto Read(int folio)
            {
                Hashtable w_params = new Hashtable();
                w_params.Add("Folio", folio);
                DataTable dt = DB.Select("RecibosAeropuerto", w_params);
                if (dt.Rows.Count == 0)
                {
                    throw new Exception("No existe RecibosAeropuerto con los criterios de búsqueda especificados.");
                }
                DataRow dr = dt.Rows[0];
                return new RecibosAeropuerto(Convert.ToInt32(dr["Folio"]), Convert.ToInt32(dr["Conductor"]), Convert.ToInt32(dr["Unidad"]), DB.GetNullableDecimal(dr["IngresoServicios"]), DB.GetNullableDecimal(dr["Cargos"]), DB.GetNullableDecimal(dr["TotalConductor"]), DB.GetNullableDecimal(dr["ValesCombustible"]), DB.GetNullableDateTime(dr["Fecha"]), DB.GetNullableInt32(dr["CategoriaConductor"]));
            } // End Read

            public static RecibosAeropuerto Read(params KeyValuePair<string, object>[] args)
            {
                DataTable dt = DB.Read("RecibosAeropuerto", args);
                if (dt.Rows.Count == 0)
                {
                    return null;
                }
                DataRow dr = dt.Rows[0];
                return new RecibosAeropuerto(Convert.ToInt32(dr["Folio"]), Convert.ToInt32(dr["Conductor"]), Convert.ToInt32(dr["Unidad"]), DB.GetNullableDecimal(dr["IngresoServicios"]), DB.GetNullableDecimal(dr["Cargos"]), DB.GetNullableDecimal(dr["TotalConductor"]), DB.GetNullableDecimal(dr["ValesCombustible"]), DB.GetNullableDateTime(dr["Fecha"]), DB.GetNullableInt32(dr["CategoriaConductor"]));
            } // End Read

            public static bool Read(out RecibosAeropuerto recibosaeropuerto, int top, string filter, string sort, params KeyValuePair<string, object>[] args)
            {
                DataTable dt = DB.Read("RecibosAeropuerto", top, filter, sort, args);
                if (dt.Rows.Count == 0)
                {
                    recibosaeropuerto = null;
                    return false;
                }
                DataRow dr = dt.Rows[0];
                recibosaeropuerto = new RecibosAeropuerto(Convert.ToInt32(dr["Folio"]), Convert.ToInt32(dr["Conductor"]), Convert.ToInt32(dr["Unidad"]), DB.GetNullableDecimal(dr["IngresoServicios"]), DB.GetNullableDecimal(dr["Cargos"]), DB.GetNullableDecimal(dr["TotalConductor"]), DB.GetNullableDecimal(dr["ValesCombustible"]), DB.GetNullableDateTime(dr["Fecha"]), DB.GetNullableInt32(dr["CategoriaConductor"]));
                return true;
            } // End Read

            public static DataTable ReadDataTable()
            {
                return DB.Select("RecibosAeropuerto");
            } // End Read

            public static DataTable ReadDataTable(int folio)
            {
                Hashtable w_params = new Hashtable();
                w_params.Add("Folio", folio);
                return DB.Select("RecibosAeropuerto", w_params);
            } // End Read

            public int Update()
            {
                Hashtable m_params = new Hashtable();
                Hashtable w_params = new Hashtable();
                w_params.Add("Folio", this.Folio);
                m_params.Add("Conductor", this.Conductor);
                m_params.Add("Unidad", this.Unidad);
                if (!AppHelper.IsNullOrEmpty(this.IngresoServicios)) m_params.Add("IngresoServicios", this.IngresoServicios);
                if (!AppHelper.IsNullOrEmpty(this.Cargos)) m_params.Add("Cargos", this.Cargos);
                if (!AppHelper.IsNullOrEmpty(this.TotalConductor)) m_params.Add("TotalConductor", this.TotalConductor);
                if (!AppHelper.IsNullOrEmpty(this.ValesCombustible)) m_params.Add("ValesCombustible", this.ValesCombustible);
                if (!AppHelper.IsNullOrEmpty(this.Fecha)) m_params.Add("Fecha", this.Fecha);
                if (!AppHelper.IsNullOrEmpty(this.CategoriaConductor)) m_params.Add("CategoriaConductor", this.CategoriaConductor);

                return DB.UpdateRow("RecibosAeropuerto", m_params, w_params);
            } // End Update

            public int Delete()
            {
                Hashtable w_params = new Hashtable();
                w_params.Add("Folio", this.Folio);

                return DB.DeleteRow("RecibosAeropuerto", w_params);
            } // End Delete

        } //End Class RecibosAeropuerto

        public class RecibosBoletos
        {

            public RecibosBoletos()
            {
            }

            public RecibosBoletos(int? recibo, string boleto)
            {
                this.Recibo = recibo;
                this.Boleto = boleto;
            }

            private int? _Recibo;
            public int? Recibo
            {
                get { return _Recibo; }
                set { _Recibo = value; }
            }

            private string _Boleto;
            public string Boleto
            {
                get { return _Boleto; }
                set { _Boleto = value; }
            }

            public int Create()
            {
                Hashtable m_params = new Hashtable();
                if (!AppHelper.IsNullOrEmpty(this.Recibo)) m_params.Add("Recibo", this.Recibo);
                if (!AppHelper.IsNullOrEmpty(this.Boleto)) m_params.Add("Boleto", this.Boleto);

                return DB.InsertRow("RecibosBoletos", m_params);
            } // End Create

            public static List<RecibosBoletos> Read()
            {
                List<RecibosBoletos> list = new List<RecibosBoletos>();
                DataTable dt = DB.Select("RecibosBoletos");
                foreach (DataRow dr in dt.Rows)
                {
                    list.Add(new RecibosBoletos(DB.GetNullableInt32(dr["Recibo"]), Convert.ToString(dr["Boleto"])));
                }

                return list;
            } // End Read

            public int Update()
            {
                Hashtable m_params = new Hashtable();
                Hashtable w_params = new Hashtable();
                if (!AppHelper.IsNullOrEmpty(this.Recibo)) m_params.Add("Recibo", this.Recibo);
                if (!AppHelper.IsNullOrEmpty(this.Boleto)) m_params.Add("Boleto", this.Boleto);

                return DB.UpdateRow("RecibosBoletos", m_params, w_params);
            } // End Update

            public int Delete()
            {
                Hashtable w_params = new Hashtable();

                return DB.DeleteRow("RecibosBoletos", w_params);
            } // End Delete

        } //End Class RecibosBoletos

        public class RecibosIncidencias
        {

            public RecibosIncidencias()
            {
            }

            public RecibosIncidencias(int recibo, int incidencia)
            {
                this.Recibo = recibo;
                this.Incidencia = incidencia;
            }

            private int _Recibo;
            public int Recibo
            {
                get { return _Recibo; }
                set { _Recibo = value; }
            }

            private int _Incidencia;
            public int Incidencia
            {
                get { return _Incidencia; }
                set { _Incidencia = value; }
            }

            public int Create()
            {
                Hashtable m_params = new Hashtable();
                m_params.Add("Recibo", this.Recibo);
                m_params.Add("Incidencia", this.Incidencia);

                return DB.InsertRow("RecibosIncidencias", m_params);
            } // End Create

            public static List<RecibosIncidencias> Read()
            {
                List<RecibosIncidencias> list = new List<RecibosIncidencias>();
                DataTable dt = DB.Select("RecibosIncidencias");
                foreach (DataRow dr in dt.Rows)
                {
                    list.Add(new RecibosIncidencias(Convert.ToInt32(dr["Recibo"]), Convert.ToInt32(dr["Incidencia"])));
                }

                return list;
            } // End Read

            public int Update()
            {
                Hashtable m_params = new Hashtable();
                Hashtable w_params = new Hashtable();
                m_params.Add("Recibo", this.Recibo);
                m_params.Add("Incidencia", this.Incidencia);

                return DB.UpdateRow("RecibosIncidencias", m_params, w_params);
            } // End Update

            public int Delete()
            {
                Hashtable w_params = new Hashtable();

                return DB.DeleteRow("RecibosIncidencias", w_params);
            } // End Delete

        } //End Class RecibosIncidencias

        public class RecibosMovimientos
        {

            public RecibosMovimientos()
            {
            }

            public RecibosMovimientos(int? recibo, int? movimiento)
            {
                this.Recibo = recibo;
                this.Movimiento = movimiento;
            }

            private int? _Recibo;
            public int? Recibo
            {
                get { return _Recibo; }
                set { _Recibo = value; }
            }

            private int? _Movimiento;
            public int? Movimiento
            {
                get { return _Movimiento; }
                set { _Movimiento = value; }
            }

            public int Create()
            {
                Hashtable m_params = new Hashtable();
                if (!AppHelper.IsNullOrEmpty(this.Recibo)) m_params.Add("Recibo", this.Recibo);
                if (!AppHelper.IsNullOrEmpty(this.Movimiento)) m_params.Add("Movimiento", this.Movimiento);

                return DB.InsertRow("RecibosMovimientos", m_params);
            } // End Create

            public static List<RecibosMovimientos> Read()
            {
                List<RecibosMovimientos> list = new List<RecibosMovimientos>();
                DataTable dt = DB.Select("RecibosMovimientos");
                foreach (DataRow dr in dt.Rows)
                {
                    list.Add(new RecibosMovimientos(DB.GetNullableInt32(dr["Recibo"]), DB.GetNullableInt32(dr["Movimiento"])));
                }

                return list;
            } // End Read

            public int Update()
            {
                Hashtable m_params = new Hashtable();
                Hashtable w_params = new Hashtable();
                if (!AppHelper.IsNullOrEmpty(this.Recibo)) m_params.Add("Recibo", this.Recibo);
                if (!AppHelper.IsNullOrEmpty(this.Movimiento)) m_params.Add("Movimiento", this.Movimiento);

                return DB.UpdateRow("RecibosMovimientos", m_params, w_params);
            } // End Update

            public int Delete()
            {
                Hashtable w_params = new Hashtable();

                return DB.DeleteRow("RecibosMovimientos", w_params);
            } // End Delete

        } //End Class RecibosMovimientos

        public class ReferenciasZonas
        {

            public ReferenciasZonas()
            {
            }

            public ReferenciasZonas(int folio, int tipo, int zona, string descripcion)
            {
                this.Folio = folio;
                this.Tipo = tipo;
                this.Zona = zona;
                this.Descripcion = descripcion;
            }

            private int _Folio;
            public int Folio
            {
                get { return _Folio; }
                set { _Folio = value; }
            }

            private int _Tipo;
            public int Tipo
            {
                get { return _Tipo; }
                set { _Tipo = value; }
            }

            private int _Zona;
            public int Zona
            {
                get { return _Zona; }
                set { _Zona = value; }
            }

            private string _Descripcion;
            public string Descripcion
            {
                get { return _Descripcion; }
                set { _Descripcion = value; }
            }

            public int Create()
            {
                Hashtable m_params = new Hashtable();
                m_params.Add("Tipo", this.Tipo);
                m_params.Add("Zona", this.Zona);
                m_params.Add("Descripcion", this.Descripcion);

                return DB.InsertRow("ReferenciasZonas", m_params);
            } // End Create

            public static List<ReferenciasZonas> Read()
            {
                List<ReferenciasZonas> list = new List<ReferenciasZonas>();
                DataTable dt = DB.Select("ReferenciasZonas");
                foreach (DataRow dr in dt.Rows)
                {
                    list.Add(new ReferenciasZonas(Convert.ToInt32(dr["Folio"]), Convert.ToInt32(dr["Tipo"]), Convert.ToInt32(dr["Zona"]), Convert.ToString(dr["Descripcion"])));
                }

                return list;
            } // End Read

            public static ReferenciasZonas Read(int folio)
            {
                Hashtable w_params = new Hashtable();
                w_params.Add("Folio", folio);
                DataTable dt = DB.Select("ReferenciasZonas", w_params);
                if (dt.Rows.Count == 0)
                {
                    throw new Exception("No existe ReferenciasZonas con los criterios de búsqueda especificados.");
                }
                DataRow dr = dt.Rows[0];
                return new ReferenciasZonas(Convert.ToInt32(dr["Folio"]), Convert.ToInt32(dr["Tipo"]), Convert.ToInt32(dr["Zona"]), Convert.ToString(dr["Descripcion"]));
            } // End Read

            public int Update()
            {
                Hashtable m_params = new Hashtable();
                Hashtable w_params = new Hashtable();
                w_params.Add("Folio", this.Folio);
                m_params.Add("Tipo", this.Tipo);
                m_params.Add("Zona", this.Zona);
                m_params.Add("Descripcion", this.Descripcion);

                return DB.UpdateRow("ReferenciasZonas", m_params, w_params);
            } // End Update

            public int Delete()
            {
                Hashtable w_params = new Hashtable();
                w_params.Add("Folio", this.Folio);

                return DB.DeleteRow("ReferenciasZonas", w_params);
            } // End Delete

        } //End Class ReferenciasZonas

        public class RegistroLocacionesUnidades
        {

            public RegistroLocacionesUnidades()
            {
            }

            public RegistroLocacionesUnidades(int unidad, int locacion, DateTime fecha, string motivo)
            {
                this.Unidad = unidad;
                this.Locacion = locacion;
                this.Fecha = fecha;
                this.Motivo = motivo;
            }

            private int _Unidad;
            public int Unidad
            {
                get { return _Unidad; }
                set { _Unidad = value; }
            }

            private int _Locacion;
            public int Locacion
            {
                get { return _Locacion; }
                set { _Locacion = value; }
            }

            private DateTime _Fecha;
            public DateTime Fecha
            {
                get { return _Fecha; }
                set { _Fecha = value; }
            }

            private string _Motivo;
            public string Motivo
            {
                get { return _Motivo; }
                set { _Motivo = value; }
            }

            public int Create()
            {
                Hashtable m_params = new Hashtable();
                m_params.Add("Unidad", this.Unidad);
                m_params.Add("Locacion", this.Locacion);
                m_params.Add("Fecha", this.Fecha);
                m_params.Add("Motivo", this.Motivo);

                return DB.InsertRow("RegistroLocacionesUnidades", m_params);
            } // End Create

            public static List<RegistroLocacionesUnidades> Read()
            {
                List<RegistroLocacionesUnidades> list = new List<RegistroLocacionesUnidades>();
                DataTable dt = DB.Select("RegistroLocacionesUnidades");
                foreach (DataRow dr in dt.Rows)
                {
                    list.Add(new RegistroLocacionesUnidades(Convert.ToInt32(dr["Unidad"]), Convert.ToInt32(dr["Locacion"]), Convert.ToDateTime(dr["Fecha"]), Convert.ToString(dr["Motivo"])));
                }

                return list;
            } // End Read

            public int Update()
            {
                Hashtable m_params = new Hashtable();
                Hashtable w_params = new Hashtable();
                m_params.Add("Unidad", this.Unidad);
                m_params.Add("Locacion", this.Locacion);
                m_params.Add("Fecha", this.Fecha);
                m_params.Add("Motivo", this.Motivo);

                return DB.UpdateRow("RegistroLocacionesUnidades", m_params, w_params);
            } // End Update

            public int Delete()
            {
                Hashtable w_params = new Hashtable();

                return DB.DeleteRow("RegistroLocacionesUnidades", w_params);
            } // End Delete

        } //End Class RegistroLocacionesUnidades

        public class RegistroUnidadesConductores
        {

            public RegistroUnidadesConductores()
            {
            }

            public RegistroUnidadesConductores(int conductor, int unidad, DateTime fecha, string motivo)
            {
                this.Conductor = conductor;
                this.Unidad = unidad;
                this.Fecha = fecha;
                this.Motivo = motivo;
            }

            private int _Conductor;
            public int Conductor
            {
                get { return _Conductor; }
                set { _Conductor = value; }
            }

            private int _Unidad;
            public int Unidad
            {
                get { return _Unidad; }
                set { _Unidad = value; }
            }

            private DateTime _Fecha;
            public DateTime Fecha
            {
                get { return _Fecha; }
                set { _Fecha = value; }
            }

            private string _Motivo;
            public string Motivo
            {
                get { return _Motivo; }
                set { _Motivo = value; }
            }

            public int Create()
            {
                Hashtable m_params = new Hashtable();
                m_params.Add("Conductor", this.Conductor);
                m_params.Add("Unidad", this.Unidad);
                m_params.Add("Fecha", this.Fecha);
                m_params.Add("Motivo", this.Motivo);

                return DB.InsertRow("RegistroUnidadesConductores", m_params);
            } // End Create

            public static List<RegistroUnidadesConductores> Read()
            {
                List<RegistroUnidadesConductores> list = new List<RegistroUnidadesConductores>();
                DataTable dt = DB.Select("RegistroUnidadesConductores");
                foreach (DataRow dr in dt.Rows)
                {
                    list.Add(new RegistroUnidadesConductores(Convert.ToInt32(dr["Conductor"]), Convert.ToInt32(dr["Unidad"]), Convert.ToDateTime(dr["Fecha"]), Convert.ToString(dr["Motivo"])));
                }

                return list;
            } // End Read

            public int Update()
            {
                Hashtable m_params = new Hashtable();
                Hashtable w_params = new Hashtable();
                m_params.Add("Conductor", this.Conductor);
                m_params.Add("Unidad", this.Unidad);
                m_params.Add("Fecha", this.Fecha);
                m_params.Add("Motivo", this.Motivo);

                return DB.UpdateRow("RegistroUnidadesConductores", m_params, w_params);
            } // End Update

            public int Delete()
            {
                Hashtable w_params = new Hashtable();

                return DB.DeleteRow("RegistroUnidadesConductores", w_params);
            } // End Delete

        } //End Class RegistroUnidadesConductores

        public class ResponsablesIncidencias
        {

            public ResponsablesIncidencias()
            {
            }

            public ResponsablesIncidencias(int folio, string descripcion)
            {
                this.Folio = folio;
                this.Descripcion = descripcion;
            }

            private int _Folio;
            public int Folio
            {
                get { return _Folio; }
                set { _Folio = value; }
            }

            private string _Descripcion;
            public string Descripcion
            {
                get { return _Descripcion; }
                set { _Descripcion = value; }
            }

            public int Create()
            {
                Hashtable m_params = new Hashtable();
                m_params.Add("Folio", this.Folio);
                m_params.Add("Descripcion", this.Descripcion);

                return DB.InsertRow("ResponsablesIncidencias", m_params);
            } // End Create

            public static List<ResponsablesIncidencias> Read()
            {
                List<ResponsablesIncidencias> list = new List<ResponsablesIncidencias>();
                DataTable dt = DB.Select("ResponsablesIncidencias");
                foreach (DataRow dr in dt.Rows)
                {
                    list.Add(new ResponsablesIncidencias(Convert.ToInt32(dr["Folio"]), Convert.ToString(dr["Descripcion"])));
                }

                return list;
            } // End Read

            public static ResponsablesIncidencias Read(int folio)
            {
                Hashtable w_params = new Hashtable();
                w_params.Add("Folio", folio);
                DataTable dt = DB.Select("ResponsablesIncidencias", w_params);
                if (dt.Rows.Count == 0)
                {
                    throw new Exception("No existe ResponsablesIncidencias con los criterios de búsqueda especificados.");
                }
                DataRow dr = dt.Rows[0];
                return new ResponsablesIncidencias(Convert.ToInt32(dr["Folio"]), Convert.ToString(dr["Descripcion"]));
            } // End Read

            public int Update()
            {
                Hashtable m_params = new Hashtable();
                Hashtable w_params = new Hashtable();
                w_params.Add("Folio", this.Folio);
                m_params.Add("Descripcion", this.Descripcion);

                return DB.UpdateRow("ResponsablesIncidencias", m_params, w_params);
            } // End Update

            public int Delete()
            {
                Hashtable w_params = new Hashtable();
                w_params.Add("Folio", this.Folio);

                return DB.DeleteRow("ResponsablesIncidencias", w_params);
            } // End Delete

        } //End Class ResponsablesIncidencias

        public class Roles
        {

            public Roles()
            {
            }

            public Roles(int folio, string descripcion)
            {
                this.Folio = folio;
                this.Descripcion = descripcion;
            }

            private int _Folio;
            public int Folio
            {
                get { return _Folio; }
                set { _Folio = value; }
            }

            private string _Descripcion;
            public string Descripcion
            {
                get { return _Descripcion; }
                set { _Descripcion = value; }
            }

            public int Create()
            {
                Hashtable m_params = new Hashtable();
                m_params.Add("Descripcion", this.Descripcion);

                return DB.InsertRow("Roles", m_params);
            } // End Create

            public static List<Roles> Read()
            {
                List<Roles> list = new List<Roles>();
                DataTable dt = DB.Select("Roles");
                foreach (DataRow dr in dt.Rows)
                {
                    list.Add(new Roles(Convert.ToInt32(dr["Folio"]), Convert.ToString(dr["Descripcion"])));
                }

                return list;
            } // End Read

            public static Roles Read(int folio)
            {
                Hashtable w_params = new Hashtable();
                w_params.Add("Folio", folio);
                DataTable dt = DB.Select("Roles", w_params);
                if (dt.Rows.Count == 0)
                {
                    throw new Exception("No existe Roles con los criterios de búsqueda especificados.");
                }
                DataRow dr = dt.Rows[0];
                return new Roles(Convert.ToInt32(dr["Folio"]), Convert.ToString(dr["Descripcion"]));
            } // End Read

            public int Update()
            {
                Hashtable m_params = new Hashtable();
                Hashtable w_params = new Hashtable();
                w_params.Add("Folio", this.Folio);
                m_params.Add("Descripcion", this.Descripcion);

                return DB.UpdateRow("Roles", m_params, w_params);
            } // End Update

            public int Delete()
            {
                Hashtable w_params = new Hashtable();
                w_params.Add("Folio", this.Folio);

                return DB.DeleteRow("Roles", w_params);
            } // End Delete

        } //End Class Roles

        public class SaldosCajas
        {

            public SaldosCajas()
            {
            }

            public SaldosCajas(int caja, int fondocaja, int tipopago, decimal monto, DateTime fecha)
            {
                this.Caja = caja;
                this.FondoCaja = fondocaja;
                this.TipoPago = tipopago;
                this.Monto = monto;
                this.Fecha = fecha;
            }

            private int _Caja;
            public int Caja
            {
                get { return _Caja; }
                set { _Caja = value; }
            }

            private int _FondoCaja;
            public int FondoCaja
            {
                get { return _FondoCaja; }
                set { _FondoCaja = value; }
            }

            private int _TipoPago;
            public int TipoPago
            {
                get { return _TipoPago; }
                set { _TipoPago = value; }
            }

            private decimal _Monto;
            public decimal Monto
            {
                get { return _Monto; }
                set { _Monto = value; }
            }

            private DateTime _Fecha;
            public DateTime Fecha
            {
                get { return _Fecha; }
                set { _Fecha = value; }
            }

            public int Create()
            {
                Hashtable m_params = new Hashtable();
                m_params.Add("Caja", this.Caja);
                m_params.Add("FondoCaja", this.FondoCaja);
                m_params.Add("TipoPago", this.TipoPago);
                m_params.Add("Monto", this.Monto);
                m_params.Add("Fecha", this.Fecha);

                return DB.InsertRow("SaldosCajas", m_params);
            } // End Create

            public static List<SaldosCajas> Read()
            {
                List<SaldosCajas> list = new List<SaldosCajas>();
                DataTable dt = DB.Select("SaldosCajas");
                foreach (DataRow dr in dt.Rows)
                {
                    list.Add(new SaldosCajas(Convert.ToInt32(dr["Caja"]), Convert.ToInt32(dr["FondoCaja"]), Convert.ToInt32(dr["TipoPago"]), Convert.ToDecimal(dr["Monto"]), Convert.ToDateTime(dr["Fecha"])));
                }

                return list;
            } // End Read

            public int Update()
            {
                Hashtable m_params = new Hashtable();
                Hashtable w_params = new Hashtable();
                m_params.Add("Caja", this.Caja);
                m_params.Add("FondoCaja", this.FondoCaja);
                m_params.Add("TipoPago", this.TipoPago);
                m_params.Add("Monto", this.Monto);
                m_params.Add("Fecha", this.Fecha);

                return DB.UpdateRow("SaldosCajas", m_params, w_params);
            } // End Update

            public int Delete()
            {
                Hashtable w_params = new Hashtable();

                return DB.DeleteRow("SaldosCajas", w_params);
            } // End Delete

        } //End Class SaldosCajas

        public class StatusBoletos
        {

            public StatusBoletos()
            {
            }

            public StatusBoletos(int folio, string descripcion)
            {
                this.Folio = folio;
                this.Descripcion = descripcion;
            }

            private int _Folio;
            public int Folio
            {
                get { return _Folio; }
                set { _Folio = value; }
            }

            private string _Descripcion;
            public string Descripcion
            {
                get { return _Descripcion; }
                set { _Descripcion = value; }
            }

            public int Create()
            {
                Hashtable m_params = new Hashtable();
                m_params.Add("Descripcion", this.Descripcion);

                return DB.InsertRow("StatusBoletos", m_params);
            } // End Create

            public static List<StatusBoletos> Read()
            {
                List<StatusBoletos> list = new List<StatusBoletos>();
                DataTable dt = DB.Select("StatusBoletos");
                foreach (DataRow dr in dt.Rows)
                {
                    list.Add(new StatusBoletos(Convert.ToInt32(dr["Folio"]), Convert.ToString(dr["Descripcion"])));
                }

                return list;
            } // End Read

            public static StatusBoletos Read(int folio)
            {
                Hashtable w_params = new Hashtable();
                w_params.Add("Folio", folio);
                DataTable dt = DB.Select("StatusBoletos", w_params);
                if (dt.Rows.Count == 0)
                {
                    throw new Exception("No existe StatusBoletos con los criterios de búsqueda especificados.");
                }
                DataRow dr = dt.Rows[0];
                return new StatusBoletos(Convert.ToInt32(dr["Folio"]), Convert.ToString(dr["Descripcion"]));
            } // End Read

            public int Update()
            {
                Hashtable m_params = new Hashtable();
                Hashtable w_params = new Hashtable();
                w_params.Add("Folio", this.Folio);
                m_params.Add("Descripcion", this.Descripcion);

                return DB.UpdateRow("StatusBoletos", m_params, w_params);
            } // End Update

            public int Delete()
            {
                Hashtable w_params = new Hashtable();
                w_params.Add("Folio", this.Folio);

                return DB.DeleteRow("StatusBoletos", w_params);
            } // End Delete

        } //End Class StatusBoletos

        public class StatusBoletosCortesia
        {

            public StatusBoletosCortesia()
            {
            }

            public StatusBoletosCortesia(int folio, string descripcion)
            {
                this.Folio = folio;
                this.Descripcion = descripcion;
            }

            private int _Folio;
            public int Folio
            {
                get { return _Folio; }
                set { _Folio = value; }
            }

            private string _Descripcion;
            public string Descripcion
            {
                get { return _Descripcion; }
                set { _Descripcion = value; }
            }

            public int Create()
            {
                Hashtable m_params = new Hashtable();
                if (!AppHelper.IsNullOrEmpty(this.Descripcion)) m_params.Add("Descripcion", this.Descripcion);

                return DB.InsertRow("StatusBoletosCortesia", m_params);
            } // End Create

            public static List<StatusBoletosCortesia> Read()
            {
                List<StatusBoletosCortesia> list = new List<StatusBoletosCortesia>();
                DataTable dt = DB.Select("StatusBoletosCortesia");
                foreach (DataRow dr in dt.Rows)
                {
                    list.Add(new StatusBoletosCortesia(Convert.ToInt32(dr["Folio"]), Convert.ToString(dr["Descripcion"])));
                }

                return list;
            } // End Read

            public static StatusBoletosCortesia Read(int folio)
            {
                Hashtable w_params = new Hashtable();
                w_params.Add("Folio", folio);
                DataTable dt = DB.Select("StatusBoletosCortesia", w_params);
                if (dt.Rows.Count == 0)
                {
                    throw new Exception("No existe StatusBoletosCortesia con los criterios de búsqueda especificados.");
                }
                DataRow dr = dt.Rows[0];
                return new StatusBoletosCortesia(Convert.ToInt32(dr["Folio"]), Convert.ToString(dr["Descripcion"]));
            } // End Read

            public int Update()
            {
                Hashtable m_params = new Hashtable();
                Hashtable w_params = new Hashtable();
                w_params.Add("Folio", this.Folio);
                if (!AppHelper.IsNullOrEmpty(this.Descripcion)) m_params.Add("Descripcion", this.Descripcion);

                return DB.UpdateRow("StatusBoletosCortesia", m_params, w_params);
            } // End Update

            public int Delete()
            {
                Hashtable w_params = new Hashtable();
                w_params.Add("Folio", this.Folio);

                return DB.DeleteRow("StatusBoletosCortesia", w_params);
            } // End Delete

        } //End Class StatusBoletosCortesia

        public class StatusCobroPrestamosCombustible
        {

            public StatusCobroPrestamosCombustible()
            {
            }

            public StatusCobroPrestamosCombustible(int folio, string descripcion)
            {
                this.Folio = folio;
                this.Descripcion = descripcion;
            }

            private int _Folio;
            public int Folio
            {
                get { return _Folio; }
                set { _Folio = value; }
            }

            private string _Descripcion;
            public string Descripcion
            {
                get { return _Descripcion; }
                set { _Descripcion = value; }
            }

            public int Create()
            {
                Hashtable m_params = new Hashtable();
                m_params.Add("Descripcion", this.Descripcion);

                return DB.InsertRow("StatusCobroPrestamosCombustible", m_params);
            } // End Create

            public static List<StatusCobroPrestamosCombustible> Read()
            {
                List<StatusCobroPrestamosCombustible> list = new List<StatusCobroPrestamosCombustible>();
                DataTable dt = DB.Select("StatusCobroPrestamosCombustible");
                foreach (DataRow dr in dt.Rows)
                {
                    list.Add(new StatusCobroPrestamosCombustible(Convert.ToInt32(dr["Folio"]), Convert.ToString(dr["Descripcion"])));
                }

                return list;
            } // End Read

            public static StatusCobroPrestamosCombustible Read(int folio)
            {
                Hashtable w_params = new Hashtable();
                w_params.Add("Folio", folio);
                DataTable dt = DB.Select("StatusCobroPrestamosCombustible", w_params);
                if (dt.Rows.Count == 0)
                {
                    throw new Exception("No existe StatusCobroPrestamosCombustible con los criterios de búsqueda especificados.");
                }
                DataRow dr = dt.Rows[0];
                return new StatusCobroPrestamosCombustible(Convert.ToInt32(dr["Folio"]), Convert.ToString(dr["Descripcion"]));
            } // End Read

            public int Update()
            {
                Hashtable m_params = new Hashtable();
                Hashtable w_params = new Hashtable();
                w_params.Add("Folio", this.Folio);
                m_params.Add("Descripcion", this.Descripcion);

                return DB.UpdateRow("StatusCobroPrestamosCombustible", m_params, w_params);
            } // End Update

            public int Delete()
            {
                Hashtable w_params = new Hashtable();
                w_params.Add("Folio", this.Folio);

                return DB.DeleteRow("StatusCobroPrestamosCombustible", w_params);
            } // End Delete

        } //End Class StatusCobroPrestamosCombustible

        public class StatusConcesiones
        {

            public StatusConcesiones()
            {
            }

            public StatusConcesiones(int folio, string descripcion)
            {
                this.Folio = folio;
                this.Descripcion = descripcion;
            }

            private int _Folio;
            public int Folio
            {
                get { return _Folio; }
                set { _Folio = value; }
            }

            private string _Descripcion;
            public string Descripcion
            {
                get { return _Descripcion; }
                set { _Descripcion = value; }
            }

            public int Create()
            {
                Hashtable m_params = new Hashtable();
                m_params.Add("Descripcion", this.Descripcion);

                return DB.InsertRow("StatusConcesiones", m_params);
            } // End Create

            public static List<StatusConcesiones> Read()
            {
                List<StatusConcesiones> list = new List<StatusConcesiones>();
                DataTable dt = DB.Select("StatusConcesiones");
                foreach (DataRow dr in dt.Rows)
                {
                    list.Add(new StatusConcesiones(Convert.ToInt32(dr["Folio"]), Convert.ToString(dr["Descripcion"])));
                }

                return list;
            } // End Read

            public static StatusConcesiones Read(int folio)
            {
                Hashtable w_params = new Hashtable();
                w_params.Add("Folio", folio);
                DataTable dt = DB.Select("StatusConcesiones", w_params);
                if (dt.Rows.Count == 0)
                {
                    throw new Exception("No existe StatusConcesiones con los criterios de búsqueda especificados.");
                }
                DataRow dr = dt.Rows[0];
                return new StatusConcesiones(Convert.ToInt32(dr["Folio"]), Convert.ToString(dr["Descripcion"]));
            } // End Read

            public int Update()
            {
                Hashtable m_params = new Hashtable();
                Hashtable w_params = new Hashtable();
                w_params.Add("Folio", this.Folio);
                m_params.Add("Descripcion", this.Descripcion);

                return DB.UpdateRow("StatusConcesiones", m_params, w_params);
            } // End Update

            public int Delete()
            {
                Hashtable w_params = new Hashtable();
                w_params.Add("Folio", this.Folio);

                return DB.DeleteRow("StatusConcesiones", w_params);
            } // End Delete

        } //End Class StatusConcesiones

        public class StatusConductores
        {

            public StatusConductores()
            {
            }

            public StatusConductores(int folio, string descripcion)
            {
                this.Folio = folio;
                this.Descripcion = descripcion;
            }

            private int _Folio;
            public int Folio
            {
                get { return _Folio; }
                set { _Folio = value; }
            }

            private string _Descripcion;
            public string Descripcion
            {
                get { return _Descripcion; }
                set { _Descripcion = value; }
            }

            public int Create()
            {
                Hashtable m_params = new Hashtable();
                m_params.Add("Descripcion", this.Descripcion);

                return DB.InsertRow("StatusConductores", m_params);
            } // End Create

            public static List<StatusConductores> Read()
            {
                List<StatusConductores> list = new List<StatusConductores>();
                DataTable dt = DB.Select("StatusConductores");
                foreach (DataRow dr in dt.Rows)
                {
                    list.Add(new StatusConductores(Convert.ToInt32(dr["Folio"]), Convert.ToString(dr["Descripcion"])));
                }

                return list;
            } // End Read

            public static StatusConductores Read(int folio)
            {
                Hashtable w_params = new Hashtable();
                w_params.Add("Folio", folio);
                DataTable dt = DB.Select("StatusConductores", w_params);
                if (dt.Rows.Count == 0)
                {
                    throw new Exception("No existe StatusConductores con los criterios de búsqueda especificados.");
                }
                DataRow dr = dt.Rows[0];
                return new StatusConductores(Convert.ToInt32(dr["Folio"]), Convert.ToString(dr["Descripcion"]));
            } // End Read

            public int Update()
            {
                Hashtable m_params = new Hashtable();
                Hashtable w_params = new Hashtable();
                w_params.Add("Folio", this.Folio);
                m_params.Add("Descripcion", this.Descripcion);

                return DB.UpdateRow("StatusConductores", m_params, w_params);
            } // End Update

            public int Delete()
            {
                Hashtable w_params = new Hashtable();
                w_params.Add("Folio", this.Folio);

                return DB.DeleteRow("StatusConductores", w_params);
            } // End Delete

        } //End Class StatusConductores

        public class StatusEmpresas
        {

            public StatusEmpresas()
            {
            }

            public StatusEmpresas(int folio, string descripcion)
            {
                this.Folio = folio;
                this.Descripcion = descripcion;
            }

            private int _Folio;
            public int Folio
            {
                get { return _Folio; }
                set { _Folio = value; }
            }

            private string _Descripcion;
            public string Descripcion
            {
                get { return _Descripcion; }
                set { _Descripcion = value; }
            }

            public int Create()
            {
                Hashtable m_params = new Hashtable();
                m_params.Add("Descripcion", this.Descripcion);

                return DB.InsertRow("StatusEmpresas", m_params);
            } // End Create

            public static List<StatusEmpresas> Read()
            {
                List<StatusEmpresas> list = new List<StatusEmpresas>();
                DataTable dt = DB.Select("StatusEmpresas");
                foreach (DataRow dr in dt.Rows)
                {
                    list.Add(new StatusEmpresas(Convert.ToInt32(dr["Folio"]), Convert.ToString(dr["Descripcion"])));
                }

                return list;
            } // End Read

            public static StatusEmpresas Read(int folio)
            {
                Hashtable w_params = new Hashtable();
                w_params.Add("Folio", folio);
                DataTable dt = DB.Select("StatusEmpresas", w_params);
                if (dt.Rows.Count == 0)
                {
                    throw new Exception("No existe StatusEmpresas con los criterios de búsqueda especificados.");
                }
                DataRow dr = dt.Rows[0];
                return new StatusEmpresas(Convert.ToInt32(dr["Folio"]), Convert.ToString(dr["Descripcion"]));
            } // End Read

            public int Update()
            {
                Hashtable m_params = new Hashtable();
                Hashtable w_params = new Hashtable();
                w_params.Add("Folio", this.Folio);
                m_params.Add("Descripcion", this.Descripcion);

                return DB.UpdateRow("StatusEmpresas", m_params, w_params);
            } // End Update

            public int Delete()
            {
                Hashtable w_params = new Hashtable();
                w_params.Add("Folio", this.Folio);

                return DB.DeleteRow("StatusEmpresas", w_params);
            } // End Delete

        } //End Class StatusEmpresas

        public class StatusUnidades
        {

            public StatusUnidades()
            {
            }

            public StatusUnidades(int folio, string descripcion)
            {
                this.Folio = folio;
                this.Descripcion = descripcion;
            }

            private int _Folio;
            public int Folio
            {
                get { return _Folio; }
                set { _Folio = value; }
            }

            private string _Descripcion;
            public string Descripcion
            {
                get { return _Descripcion; }
                set { _Descripcion = value; }
            }

            public int Create()
            {
                Hashtable m_params = new Hashtable();
                m_params.Add("Descripcion", this.Descripcion);

                return DB.InsertRow("StatusUnidades", m_params);
            } // End Create

            public static List<StatusUnidades> Read()
            {
                List<StatusUnidades> list = new List<StatusUnidades>();
                DataTable dt = DB.Select("StatusUnidades");
                foreach (DataRow dr in dt.Rows)
                {
                    list.Add(new StatusUnidades(Convert.ToInt32(dr["Folio"]), Convert.ToString(dr["Descripcion"])));
                }

                return list;
            } // End Read

            public static StatusUnidades Read(int folio)
            {
                Hashtable w_params = new Hashtable();
                w_params.Add("Folio", folio);
                DataTable dt = DB.Select("StatusUnidades", w_params);
                if (dt.Rows.Count == 0)
                {
                    throw new Exception("No existe StatusUnidades con los criterios de búsqueda especificados.");
                }
                DataRow dr = dt.Rows[0];
                return new StatusUnidades(Convert.ToInt32(dr["Folio"]), Convert.ToString(dr["Descripcion"]));
            } // End Read

            public int Update()
            {
                Hashtable m_params = new Hashtable();
                Hashtable w_params = new Hashtable();
                w_params.Add("Folio", this.Folio);
                m_params.Add("Descripcion", this.Descripcion);

                return DB.UpdateRow("StatusUnidades", m_params, w_params);
            } // End Update

            public int Delete()
            {
                Hashtable w_params = new Hashtable();
                w_params.Add("Folio", this.Folio);

                return DB.DeleteRow("StatusUnidades", w_params);
            } // End Delete

        } //End Class StatusUnidades

        public class Subsistemas
        {

            public Subsistemas()
            {
            }

            public Subsistemas(int folio, string descripcion)
            {
                this.Folio = folio;
                this.Descripcion = descripcion;
            }

            private int _Folio;
            public int Folio
            {
                get { return _Folio; }
                set { _Folio = value; }
            }

            private string _Descripcion;
            public string Descripcion
            {
                get { return _Descripcion; }
                set { _Descripcion = value; }
            }

            public int Create()
            {
                Hashtable m_params = new Hashtable();
                m_params.Add("Descripcion", this.Descripcion);

                return DB.InsertRow("Subsistemas", m_params);
            } // End Create

            public static List<Subsistemas> Read()
            {
                List<Subsistemas> list = new List<Subsistemas>();
                DataTable dt = DB.Select("Subsistemas");
                foreach (DataRow dr in dt.Rows)
                {
                    list.Add(new Subsistemas(Convert.ToInt32(dr["Folio"]), Convert.ToString(dr["Descripcion"])));
                }

                return list;
            } // End Read

            public static Subsistemas Read(int folio)
            {
                Hashtable w_params = new Hashtable();
                w_params.Add("Folio", folio);
                DataTable dt = DB.Select("Subsistemas", w_params);
                if (dt.Rows.Count == 0)
                {
                    throw new Exception("No existe Subsistemas con los criterios de búsqueda especificados.");
                }
                DataRow dr = dt.Rows[0];
                return new Subsistemas(Convert.ToInt32(dr["Folio"]), Convert.ToString(dr["Descripcion"]));
            } // End Read

            public int Update()
            {
                Hashtable m_params = new Hashtable();
                Hashtable w_params = new Hashtable();
                w_params.Add("Folio", this.Folio);
                m_params.Add("Descripcion", this.Descripcion);

                return DB.UpdateRow("Subsistemas", m_params, w_params);
            } // End Update

            public int Delete()
            {
                Hashtable w_params = new Hashtable();
                w_params.Add("Folio", this.Folio);

                return DB.DeleteRow("Subsistemas", w_params);
            } // End Delete

        } //End Class Subsistemas

        public class Tarifas
        {

            public Tarifas()
            {
            }

            public Tarifas(int zona, int tiposervicio, decimal tarifa)
            {
                this.Zona = zona;
                this.TipoServicio = tiposervicio;
                this.Tarifa = tarifa;
            }

            private int _Zona;
            public int Zona
            {
                get { return _Zona; }
                set { _Zona = value; }
            }

            private int _TipoServicio;
            public int TipoServicio
            {
                get { return _TipoServicio; }
                set { _TipoServicio = value; }
            }

            private decimal _Tarifa;
            public decimal Tarifa
            {
                get { return _Tarifa; }
                set { _Tarifa = value; }
            }

            public int Create()
            {
                Hashtable m_params = new Hashtable();
                m_params.Add("Zona", this.Zona);
                m_params.Add("TipoServicio", this.TipoServicio);
                m_params.Add("Tarifa", this.Tarifa);

                return DB.InsertRow("Tarifas", m_params);
            } // End Create

            public static List<Tarifas> Read()
            {
                List<Tarifas> list = new List<Tarifas>();
                DataTable dt = DB.Select("Tarifas");
                foreach (DataRow dr in dt.Rows)
                {
                    list.Add(new Tarifas(Convert.ToInt32(dr["Zona"]), Convert.ToInt32(dr["TipoServicio"]), Convert.ToDecimal(dr["Tarifa"])));
                }

                return list;
            } // End Read

            public int Update()
            {
                Hashtable m_params = new Hashtable();
                Hashtable w_params = new Hashtable();
                m_params.Add("Zona", this.Zona);
                m_params.Add("TipoServicio", this.TipoServicio);
                m_params.Add("Tarifa", this.Tarifa);

                return DB.UpdateRow("Tarifas", m_params, w_params);
            } // End Update

            public int Delete()
            {
                Hashtable w_params = new Hashtable();

                return DB.DeleteRow("Tarifas", w_params);
            } // End Delete

        } //End Class Tarifas

        public class TarifasPredefinidas
        {

            public TarifasPredefinidas()
            {
            }

            public TarifasPredefinidas(decimal? tarifaebssa, decimal? baseacreditacion, decimal? tipocambiomndls, decimal? porcentajeboletosregresos, decimal? preciobono, decimal? tarifaebssa_categoriac, decimal? tarifacascoregresos, decimal? tarifadescanso, decimal? limitecreditooxxogas, decimal? tarifacompartida)
            {
                this.TarifaEbssa = tarifaebssa;
                this.BaseAcreditacion = baseacreditacion;
                this.TipoCambioMNDLS = tipocambiomndls;
                this.PorcentajeBoletosRegresos = porcentajeboletosregresos;
                this.PrecioBono = preciobono;
                this.TarifaEBSSA_CategoriaC = tarifaebssa_categoriac;
                this.TarifaCascoRegresos = tarifacascoregresos;
                this.TarifaDescanso = tarifadescanso;
                this.LimiteCreditoOXXOGas = limitecreditooxxogas;
                this.TarifaCompartida = tarifacompartida;
            }

            private decimal? _TarifaEbssa;
            public decimal? TarifaEbssa
            {
                get { return _TarifaEbssa; }
                set { _TarifaEbssa = value; }
            }

            private decimal? _BaseAcreditacion;
            public decimal? BaseAcreditacion
            {
                get { return _BaseAcreditacion; }
                set { _BaseAcreditacion = value; }
            }

            private decimal? _TipoCambioMNDLS;
            public decimal? TipoCambioMNDLS
            {
                get { return _TipoCambioMNDLS; }
                set { _TipoCambioMNDLS = value; }
            }

            private decimal? _PorcentajeBoletosRegresos;
            public decimal? PorcentajeBoletosRegresos
            {
                get { return _PorcentajeBoletosRegresos; }
                set { _PorcentajeBoletosRegresos = value; }
            }

            private decimal? _PrecioBono;
            public decimal? PrecioBono
            {
                get { return _PrecioBono; }
                set { _PrecioBono = value; }
            }

            private decimal? _TarifaEBSSA_CategoriaC;
            public decimal? TarifaEBSSA_CategoriaC
            {
                get { return _TarifaEBSSA_CategoriaC; }
                set { _TarifaEBSSA_CategoriaC = value; }
            }

            private decimal? _TarifaCascoRegresos;
            public decimal? TarifaCascoRegresos
            {
                get { return _TarifaCascoRegresos; }
                set { _TarifaCascoRegresos = value; }
            }

            private decimal? _TarifaDescanso;
            public decimal? TarifaDescanso
            {
                get { return _TarifaDescanso; }
                set { _TarifaDescanso = value; }
            }

            private decimal? _LimiteCreditoOXXOGas;
            public decimal? LimiteCreditoOXXOGas
            {
                get { return _LimiteCreditoOXXOGas; }
                set { _LimiteCreditoOXXOGas = value; }
            }

            private decimal? _TarifaCompartida;
            public decimal? TarifaCompartida
            {
                get { return _TarifaCompartida; }
                set { _TarifaCompartida = value; }
            }

            public int Create()
            {
                Hashtable m_params = new Hashtable();
                if (!AppHelper.IsNullOrEmpty(this.TarifaEbssa)) m_params.Add("TarifaEbssa", this.TarifaEbssa);
                if (!AppHelper.IsNullOrEmpty(this.BaseAcreditacion)) m_params.Add("BaseAcreditacion", this.BaseAcreditacion);
                if (!AppHelper.IsNullOrEmpty(this.TipoCambioMNDLS)) m_params.Add("TipoCambioMNDLS", this.TipoCambioMNDLS);
                if (!AppHelper.IsNullOrEmpty(this.PorcentajeBoletosRegresos)) m_params.Add("PorcentajeBoletosRegresos", this.PorcentajeBoletosRegresos);
                if (!AppHelper.IsNullOrEmpty(this.PrecioBono)) m_params.Add("PrecioBono", this.PrecioBono);
                if (!AppHelper.IsNullOrEmpty(this.TarifaEBSSA_CategoriaC)) m_params.Add("TarifaEBSSA_CategoriaC", this.TarifaEBSSA_CategoriaC);
                if (!AppHelper.IsNullOrEmpty(this.TarifaCascoRegresos)) m_params.Add("TarifaCascoRegresos", this.TarifaCascoRegresos);
                if (!AppHelper.IsNullOrEmpty(this.TarifaDescanso)) m_params.Add("TarifaDescanso", this.TarifaDescanso);
                if (!AppHelper.IsNullOrEmpty(this.LimiteCreditoOXXOGas)) m_params.Add("LimiteCreditoOXXOGas", this.LimiteCreditoOXXOGas);
                if (!AppHelper.IsNullOrEmpty(this.TarifaCompartida)) m_params.Add("TarifaCompartida", this.TarifaCompartida);

                return DB.InsertRow("TarifasPredefinidas", m_params);
            } // End Create

            public static List<TarifasPredefinidas> Read()
            {
                List<TarifasPredefinidas> list = new List<TarifasPredefinidas>();
                DataTable dt = DB.Select("TarifasPredefinidas");
                foreach (DataRow dr in dt.Rows)
                {
                    list.Add(new TarifasPredefinidas(DB.GetNullableDecimal(dr["TarifaEbssa"]), DB.GetNullableDecimal(dr["BaseAcreditacion"]), DB.GetNullableDecimal(dr["TipoCambioMNDLS"]), DB.GetNullableDecimal(dr["PorcentajeBoletosRegresos"]), DB.GetNullableDecimal(dr["PrecioBono"]), DB.GetNullableDecimal(dr["TarifaEBSSA_CategoriaC"]), DB.GetNullableDecimal(dr["TarifaCascoRegresos"]), DB.GetNullableDecimal(dr["TarifaDescanso"]), DB.GetNullableDecimal(dr["LimiteCreditoOXXOGas"]), DB.GetNullableDecimal(dr["TarifaCompartida"])));
                }

                return list;
            } // End Read

            public int Update()
            {
                Hashtable m_params = new Hashtable();
                Hashtable w_params = new Hashtable();
                if (!AppHelper.IsNullOrEmpty(this.TarifaEbssa)) m_params.Add("TarifaEbssa", this.TarifaEbssa);
                if (!AppHelper.IsNullOrEmpty(this.BaseAcreditacion)) m_params.Add("BaseAcreditacion", this.BaseAcreditacion);
                if (!AppHelper.IsNullOrEmpty(this.TipoCambioMNDLS)) m_params.Add("TipoCambioMNDLS", this.TipoCambioMNDLS);
                if (!AppHelper.IsNullOrEmpty(this.PorcentajeBoletosRegresos)) m_params.Add("PorcentajeBoletosRegresos", this.PorcentajeBoletosRegresos);
                if (!AppHelper.IsNullOrEmpty(this.PrecioBono)) m_params.Add("PrecioBono", this.PrecioBono);
                if (!AppHelper.IsNullOrEmpty(this.TarifaEBSSA_CategoriaC)) m_params.Add("TarifaEBSSA_CategoriaC", this.TarifaEBSSA_CategoriaC);
                if (!AppHelper.IsNullOrEmpty(this.TarifaCascoRegresos)) m_params.Add("TarifaCascoRegresos", this.TarifaCascoRegresos);
                if (!AppHelper.IsNullOrEmpty(this.TarifaDescanso)) m_params.Add("TarifaDescanso", this.TarifaDescanso);
                if (!AppHelper.IsNullOrEmpty(this.LimiteCreditoOXXOGas)) m_params.Add("LimiteCreditoOXXOGas", this.LimiteCreditoOXXOGas);
                if (!AppHelper.IsNullOrEmpty(this.TarifaCompartida)) m_params.Add("TarifaCompartida", this.TarifaCompartida);

                return DB.UpdateRow("TarifasPredefinidas", m_params, w_params);
            } // End Update

            public int Delete()
            {
                Hashtable w_params = new Hashtable();

                return DB.DeleteRow("TarifasPredefinidas", w_params);
            } // End Delete

        } //End Class TarifasPredefinidas

        public class TarifasSuperProductividad
        {

            public TarifasSuperProductividad()
            {
            }

            public TarifasSuperProductividad(decimal productividad, decimal? tarifa)
            {
                this.Productividad = productividad;
                this.Tarifa = tarifa;
            }

            private decimal _Productividad;
            public decimal Productividad
            {
                get { return _Productividad; }
                set { _Productividad = value; }
            }

            private decimal? _Tarifa;
            public decimal? Tarifa
            {
                get { return _Tarifa; }
                set { _Tarifa = value; }
            }

            public int Create()
            {
                Hashtable m_params = new Hashtable();
                m_params.Add("Productividad", this.Productividad);
                if (!AppHelper.IsNullOrEmpty(this.Tarifa)) m_params.Add("Tarifa", this.Tarifa);

                return DB.InsertRow("TarifasSuperProductividad", m_params);
            } // End Create

            public static List<TarifasSuperProductividad> Read()
            {
                List<TarifasSuperProductividad> list = new List<TarifasSuperProductividad>();
                DataTable dt = DB.Select("TarifasSuperProductividad");
                foreach (DataRow dr in dt.Rows)
                {
                    list.Add(new TarifasSuperProductividad(Convert.ToDecimal(dr["Productividad"]), DB.GetNullableDecimal(dr["Tarifa"])));
                }

                return list;
            } // End Read

            public static TarifasSuperProductividad Read(decimal productividad)
            {
                Hashtable w_params = new Hashtable();
                w_params.Add("Productividad", productividad);
                DataTable dt = DB.Select("TarifasSuperProductividad", w_params);
                if (dt.Rows.Count == 0)
                {
                    throw new Exception("No existe TarifasSuperProductividad con los criterios de búsqueda especificados.");
                }
                DataRow dr = dt.Rows[0];
                return new TarifasSuperProductividad(Convert.ToDecimal(dr["Productividad"]), DB.GetNullableDecimal(dr["Tarifa"]));
            } // End Read

            public int Update()
            {
                Hashtable m_params = new Hashtable();
                Hashtable w_params = new Hashtable();
                w_params.Add("Productividad", this.Productividad);
                if (!AppHelper.IsNullOrEmpty(this.Tarifa)) m_params.Add("Tarifa", this.Tarifa);

                return DB.UpdateRow("TarifasSuperProductividad", m_params, w_params);
            } // End Update

            public int Delete()
            {
                Hashtable w_params = new Hashtable();
                w_params.Add("Productividad", this.Productividad);

                return DB.DeleteRow("TarifasSuperProductividad", w_params);
            } // End Delete

        } //End Class TarifasSuperProductividad

        public class TiposBoletosEspeciales
        {

            public TiposBoletosEspeciales()
            {
            }

            public TiposBoletosEspeciales(int folio, string descripcion, bool esquemaporcentajes, decimal precio, int fondocaja, bool validocarrera, int? status, bool? exclusivoconductor)
            {
                this.Folio = folio;
                this.Descripcion = descripcion;
                this.EsquemaPorcentajes = esquemaporcentajes;
                this.Precio = precio;
                this.FondoCaja = fondocaja;
                this.ValidoCarrera = validocarrera;
                this.Status = status;
                this.ExclusivoConductor = exclusivoconductor;
            }

            private int _Folio;
            public int Folio
            {
                get { return _Folio; }
                set { _Folio = value; }
            }

            private string _Descripcion;
            public string Descripcion
            {
                get { return _Descripcion; }
                set { _Descripcion = value; }
            }

            private bool _EsquemaPorcentajes;
            public bool EsquemaPorcentajes
            {
                get { return _EsquemaPorcentajes; }
                set { _EsquemaPorcentajes = value; }
            }

            private decimal _Precio;
            public decimal Precio
            {
                get { return _Precio; }
                set { _Precio = value; }
            }

            private int _FondoCaja;
            public int FondoCaja
            {
                get { return _FondoCaja; }
                set { _FondoCaja = value; }
            }

            private bool _ValidoCarrera;
            public bool ValidoCarrera
            {
                get { return _ValidoCarrera; }
                set { _ValidoCarrera = value; }
            }

            private int? _Status;
            public int? Status
            {
                get { return _Status; }
                set { _Status = value; }
            }

            private bool? _ExclusivoConductor;
            public bool? ExclusivoConductor
            {
                get { return _ExclusivoConductor; }
                set { _ExclusivoConductor = value; }
            }

            public int Create()
            {
                Hashtable m_params = new Hashtable();
                m_params.Add("Descripcion", this.Descripcion);
                m_params.Add("EsquemaPorcentajes", this.EsquemaPorcentajes);
                m_params.Add("Precio", this.Precio);
                m_params.Add("FondoCaja", this.FondoCaja);
                m_params.Add("ValidoCarrera", this.ValidoCarrera);
                if (!AppHelper.IsNullOrEmpty(this.Status)) m_params.Add("Status", this.Status);
                if (!AppHelper.IsNullOrEmpty(this.ExclusivoConductor)) m_params.Add("ExclusivoConductor", this.ExclusivoConductor);

                return DB.InsertRow("TiposBoletosEspeciales", m_params);
            } // End Create

            public static List<TiposBoletosEspeciales> Read()
            {
                List<TiposBoletosEspeciales> list = new List<TiposBoletosEspeciales>();
                DataTable dt = DB.Select("TiposBoletosEspeciales");
                foreach (DataRow dr in dt.Rows)
                {
                    list.Add(new TiposBoletosEspeciales(Convert.ToInt32(dr["Folio"]), Convert.ToString(dr["Descripcion"]), Convert.ToBoolean(dr["EsquemaPorcentajes"]), Convert.ToDecimal(dr["Precio"]), Convert.ToInt32(dr["FondoCaja"]), Convert.ToBoolean(dr["ValidoCarrera"]), DB.GetNullableInt32(dr["Status"]), DB.GetNullableBoolean(dr["ExclusivoConductor"])));
                }

                return list;
            } // End Read

            public static TiposBoletosEspeciales Read(int folio)
            {
                Hashtable w_params = new Hashtable();
                w_params.Add("Folio", folio);
                DataTable dt = DB.Select("TiposBoletosEspeciales", w_params);
                if (dt.Rows.Count == 0)
                {
                    throw new Exception("No existe TiposBoletosEspeciales con los criterios de búsqueda especificados.");
                }
                DataRow dr = dt.Rows[0];
                return new TiposBoletosEspeciales(Convert.ToInt32(dr["Folio"]), Convert.ToString(dr["Descripcion"]), Convert.ToBoolean(dr["EsquemaPorcentajes"]), Convert.ToDecimal(dr["Precio"]), Convert.ToInt32(dr["FondoCaja"]), Convert.ToBoolean(dr["ValidoCarrera"]), DB.GetNullableInt32(dr["Status"]), DB.GetNullableBoolean(dr["ExclusivoConductor"]));
            } // End Read

            public int Update()
            {
                Hashtable m_params = new Hashtable();
                Hashtable w_params = new Hashtable();
                w_params.Add("Folio", this.Folio);
                m_params.Add("Descripcion", this.Descripcion);
                m_params.Add("EsquemaPorcentajes", this.EsquemaPorcentajes);
                m_params.Add("Precio", this.Precio);
                m_params.Add("FondoCaja", this.FondoCaja);
                m_params.Add("ValidoCarrera", this.ValidoCarrera);
                if (!AppHelper.IsNullOrEmpty(this.Status)) m_params.Add("Status", this.Status);
                if (!AppHelper.IsNullOrEmpty(this.ExclusivoConductor)) m_params.Add("ExclusivoConductor", this.ExclusivoConductor);

                return DB.UpdateRow("TiposBoletosEspeciales", m_params, w_params);
            } // End Update

            public int Delete()
            {
                Hashtable w_params = new Hashtable();
                w_params.Add("Folio", this.Folio);

                return DB.DeleteRow("TiposBoletosEspeciales", w_params);
            } // End Delete

        } //End Class TiposBoletosEspeciales

        public class TiposConceptos
        {

            public TiposConceptos()
            {
            }

            public TiposConceptos(int folio, string descripcion)
            {
                this.Folio = folio;
                this.Descripcion = descripcion;
            }

            private int _Folio;
            public int Folio
            {
                get { return _Folio; }
                set { _Folio = value; }
            }

            private string _Descripcion;
            public string Descripcion
            {
                get { return _Descripcion; }
                set { _Descripcion = value; }
            }

            public int Create()
            {
                Hashtable m_params = new Hashtable();
                m_params.Add("Descripcion", this.Descripcion);

                return DB.InsertRow("TiposConceptos", m_params);
            } // End Create

            public static List<TiposConceptos> Read()
            {
                List<TiposConceptos> list = new List<TiposConceptos>();
                DataTable dt = DB.Select("TiposConceptos");
                foreach (DataRow dr in dt.Rows)
                {
                    list.Add(new TiposConceptos(Convert.ToInt32(dr["Folio"]), Convert.ToString(dr["Descripcion"])));
                }

                return list;
            } // End Read

            public static TiposConceptos Read(int folio)
            {
                Hashtable w_params = new Hashtable();
                w_params.Add("Folio", folio);
                DataTable dt = DB.Select("TiposConceptos", w_params);
                if (dt.Rows.Count == 0)
                {
                    throw new Exception("No existe TiposConceptos con los criterios de búsqueda especificados.");
                }
                DataRow dr = dt.Rows[0];
                return new TiposConceptos(Convert.ToInt32(dr["Folio"]), Convert.ToString(dr["Descripcion"]));
            } // End Read

            public int Update()
            {
                Hashtable m_params = new Hashtable();
                Hashtable w_params = new Hashtable();
                w_params.Add("Folio", this.Folio);
                m_params.Add("Descripcion", this.Descripcion);

                return DB.UpdateRow("TiposConceptos", m_params, w_params);
            } // End Update

            public int Delete()
            {
                Hashtable w_params = new Hashtable();
                w_params.Add("Folio", this.Folio);

                return DB.DeleteRow("TiposConceptos", w_params);
            } // End Delete

        } //End Class TiposConceptos

        public class TiposConcesiones
        {

            public TiposConcesiones()
            {
            }

            public TiposConcesiones(int folio, string descripcion)
            {
                this.Folio = folio;
                this.Descripcion = descripcion;
            }

            private int _Folio;
            public int Folio
            {
                get { return _Folio; }
                set { _Folio = value; }
            }

            private string _Descripcion;
            public string Descripcion
            {
                get { return _Descripcion; }
                set { _Descripcion = value; }
            }

            public int Create()
            {
                Hashtable m_params = new Hashtable();
                m_params.Add("Descripcion", this.Descripcion);

                return DB.InsertRow("TiposConcesiones", m_params);
            } // End Create

            public static List<TiposConcesiones> Read()
            {
                List<TiposConcesiones> list = new List<TiposConcesiones>();
                DataTable dt = DB.Select("TiposConcesiones");
                foreach (DataRow dr in dt.Rows)
                {
                    list.Add(new TiposConcesiones(Convert.ToInt32(dr["Folio"]), Convert.ToString(dr["Descripcion"])));
                }

                return list;
            } // End Read

            public static TiposConcesiones Read(int folio)
            {
                Hashtable w_params = new Hashtable();
                w_params.Add("Folio", folio);
                DataTable dt = DB.Select("TiposConcesiones", w_params);
                if (dt.Rows.Count == 0)
                {
                    throw new Exception("No existe TiposConcesiones con los criterios de búsqueda especificados.");
                }
                DataRow dr = dt.Rows[0];
                return new TiposConcesiones(Convert.ToInt32(dr["Folio"]), Convert.ToString(dr["Descripcion"]));
            } // End Read

            public int Update()
            {
                Hashtable m_params = new Hashtable();
                Hashtable w_params = new Hashtable();
                w_params.Add("Folio", this.Folio);
                m_params.Add("Descripcion", this.Descripcion);

                return DB.UpdateRow("TiposConcesiones", m_params, w_params);
            } // End Update

            public int Delete()
            {
                Hashtable w_params = new Hashtable();
                w_params.Add("Folio", this.Folio);

                return DB.DeleteRow("TiposConcesiones", w_params);
            } // End Delete

        } //End Class TiposConcesiones

        public class TiposConductores
        {

            public TiposConductores()
            {
            }

            public TiposConductores(int folio, string descripcion)
            {
                this.Folio = folio;
                this.Descripcion = descripcion;
            }

            private int _Folio;
            public int Folio
            {
                get { return _Folio; }
                set { _Folio = value; }
            }

            private string _Descripcion;
            public string Descripcion
            {
                get { return _Descripcion; }
                set { _Descripcion = value; }
            }

            public int Create()
            {
                Hashtable m_params = new Hashtable();
                m_params.Add("Descripcion", this.Descripcion);

                return DB.InsertRow("TiposConductores", m_params);
            } // End Create

            public static List<TiposConductores> Read()
            {
                List<TiposConductores> list = new List<TiposConductores>();
                DataTable dt = DB.Select("TiposConductores");
                foreach (DataRow dr in dt.Rows)
                {
                    list.Add(new TiposConductores(Convert.ToInt32(dr["Folio"]), Convert.ToString(dr["Descripcion"])));
                }

                return list;
            } // End Read

            public static TiposConductores Read(int folio)
            {
                Hashtable w_params = new Hashtable();
                w_params.Add("Folio", folio);
                DataTable dt = DB.Select("TiposConductores", w_params);
                if (dt.Rows.Count == 0)
                {
                    throw new Exception("No existe TiposConductores con los criterios de búsqueda especificados.");
                }
                DataRow dr = dt.Rows[0];
                return new TiposConductores(Convert.ToInt32(dr["Folio"]), Convert.ToString(dr["Descripcion"]));
            } // End Read

            public int Update()
            {
                Hashtable m_params = new Hashtable();
                Hashtable w_params = new Hashtable();
                w_params.Add("Folio", this.Folio);
                m_params.Add("Descripcion", this.Descripcion);

                return DB.UpdateRow("TiposConductores", m_params, w_params);
            } // End Update

            public int Delete()
            {
                Hashtable w_params = new Hashtable();
                w_params.Add("Folio", this.Folio);

                return DB.DeleteRow("TiposConductores", w_params);
            } // End Delete

        } //End Class TiposConductores

        public class TiposDeCaja
        {

            public TiposDeCaja()
            {
            }

            public TiposDeCaja(int folio, string descripcion)
            {
                this.Folio = folio;
                this.Descripcion = descripcion;
            }

            private int _Folio;
            public int Folio
            {
                get { return _Folio; }
                set { _Folio = value; }
            }

            private string _Descripcion;
            public string Descripcion
            {
                get { return _Descripcion; }
                set { _Descripcion = value; }
            }

            public int Create()
            {
                Hashtable m_params = new Hashtable();
                if (!AppHelper.IsNullOrEmpty(this.Descripcion)) m_params.Add("Descripcion", this.Descripcion);

                return DB.InsertRow("TiposDeCaja", m_params);
            } // End Create

            public static List<TiposDeCaja> Read()
            {
                List<TiposDeCaja> list = new List<TiposDeCaja>();
                DataTable dt = DB.Select("TiposDeCaja");
                foreach (DataRow dr in dt.Rows)
                {
                    list.Add(new TiposDeCaja(Convert.ToInt32(dr["Folio"]), Convert.ToString(dr["Descripcion"])));
                }

                return list;
            } // End Read

            public static TiposDeCaja Read(int folio)
            {
                Hashtable w_params = new Hashtable();
                w_params.Add("Folio", folio);
                DataTable dt = DB.Select("TiposDeCaja", w_params);
                if (dt.Rows.Count == 0)
                {
                    throw new Exception("No existe TiposDeCaja con los criterios de búsqueda especificados.");
                }
                DataRow dr = dt.Rows[0];
                return new TiposDeCaja(Convert.ToInt32(dr["Folio"]), Convert.ToString(dr["Descripcion"]));
            } // End Read

            public int Update()
            {
                Hashtable m_params = new Hashtable();
                Hashtable w_params = new Hashtable();
                w_params.Add("Folio", this.Folio);
                if (!AppHelper.IsNullOrEmpty(this.Descripcion)) m_params.Add("Descripcion", this.Descripcion);

                return DB.UpdateRow("TiposDeCaja", m_params, w_params);
            } // End Update

            public int Delete()
            {
                Hashtable w_params = new Hashtable();
                w_params.Add("Folio", this.Folio);

                return DB.DeleteRow("TiposDeCaja", w_params);
            } // End Delete

        } //End Class TiposDeCaja

        public class TiposIncidencias
        {

            public TiposIncidencias()
            {
            }

            public TiposIncidencias(int folio, string descripcion)
            {
                this.Folio = folio;
                this.Descripcion = descripcion;
            }

            private int _Folio;
            public int Folio
            {
                get { return _Folio; }
                set { _Folio = value; }
            }

            private string _Descripcion;
            public string Descripcion
            {
                get { return _Descripcion; }
                set { _Descripcion = value; }
            }

            public int Create()
            {
                Hashtable m_params = new Hashtable();
                m_params.Add("Folio", this.Folio);
                m_params.Add("Descripcion", this.Descripcion);

                return DB.InsertRow("TiposIncidencias", m_params);
            } // End Create

            public static List<TiposIncidencias> Read()
            {
                List<TiposIncidencias> list = new List<TiposIncidencias>();
                DataTable dt = DB.Select("TiposIncidencias");
                foreach (DataRow dr in dt.Rows)
                {
                    list.Add(new TiposIncidencias(Convert.ToInt32(dr["Folio"]), Convert.ToString(dr["Descripcion"])));
                }

                return list;
            } // End Read

            public int Update()
            {
                Hashtable m_params = new Hashtable();
                Hashtable w_params = new Hashtable();
                m_params.Add("Folio", this.Folio);
                m_params.Add("Descripcion", this.Descripcion);

                return DB.UpdateRow("TiposIncidencias", m_params, w_params);
            } // End Update

            public int Delete()
            {
                Hashtable w_params = new Hashtable();

                return DB.DeleteRow("TiposIncidencias", w_params);
            } // End Delete

        } //End Class TiposIncidencias

        public class TiposLicencias
        {

            public TiposLicencias()
            {
            }

            public TiposLicencias(int folio, string descripcion)
            {
                this.Folio = folio;
                this.Descripcion = descripcion;
            }

            private int _Folio;
            public int Folio
            {
                get { return _Folio; }
                set { _Folio = value; }
            }

            private string _Descripcion;
            public string Descripcion
            {
                get { return _Descripcion; }
                set { _Descripcion = value; }
            }

            public int Create()
            {
                Hashtable m_params = new Hashtable();
                if (!AppHelper.IsNullOrEmpty(this.Descripcion)) m_params.Add("Descripcion", this.Descripcion);

                return DB.InsertRow("TiposLicencias", m_params);
            } // End Create

            public static List<TiposLicencias> Read()
            {
                List<TiposLicencias> list = new List<TiposLicencias>();
                DataTable dt = DB.Select("TiposLicencias");
                foreach (DataRow dr in dt.Rows)
                {
                    list.Add(new TiposLicencias(Convert.ToInt32(dr["Folio"]), Convert.ToString(dr["Descripcion"])));
                }

                return list;
            } // End Read

            public static TiposLicencias Read(int folio)
            {
                Hashtable w_params = new Hashtable();
                w_params.Add("Folio", folio);
                DataTable dt = DB.Select("TiposLicencias", w_params);
                if (dt.Rows.Count == 0)
                {
                    throw new Exception("No existe TiposLicencias con los criterios de búsqueda especificados.");
                }
                DataRow dr = dt.Rows[0];
                return new TiposLicencias(Convert.ToInt32(dr["Folio"]), Convert.ToString(dr["Descripcion"]));
            } // End Read

            public int Update()
            {
                Hashtable m_params = new Hashtable();
                Hashtable w_params = new Hashtable();
                w_params.Add("Folio", this.Folio);
                if (!AppHelper.IsNullOrEmpty(this.Descripcion)) m_params.Add("Descripcion", this.Descripcion);

                return DB.UpdateRow("TiposLicencias", m_params, w_params);
            } // End Update

            public int Delete()
            {
                Hashtable w_params = new Hashtable();
                w_params.Add("Folio", this.Folio);

                return DB.DeleteRow("TiposLicencias", w_params);
            } // End Delete

        } //End Class TiposLicencias

        public class TiposMantenimientos
        {

            public TiposMantenimientos()
            {
            }

            public TiposMantenimientos(int folio, string descripcion)
            {
                this.Folio = folio;
                this.Descripcion = descripcion;
            }

            private int _Folio;
            public int Folio
            {
                get { return _Folio; }
                set { _Folio = value; }
            }

            private string _Descripcion;
            public string Descripcion
            {
                get { return _Descripcion; }
                set { _Descripcion = value; }
            }

            public int Create()
            {
                Hashtable m_params = new Hashtable();
                if (!AppHelper.IsNullOrEmpty(this.Descripcion)) m_params.Add("Descripcion", this.Descripcion);

                return DB.InsertRow("TiposMantenimientos", m_params);
            } // End Create

            public static List<TiposMantenimientos> Read()
            {
                List<TiposMantenimientos> list = new List<TiposMantenimientos>();
                DataTable dt = DB.Select("TiposMantenimientos");
                foreach (DataRow dr in dt.Rows)
                {
                    list.Add(new TiposMantenimientos(Convert.ToInt32(dr["Folio"]), Convert.ToString(dr["Descripcion"])));
                }

                return list;
            } // End Read

            public static TiposMantenimientos Read(int folio)
            {
                Hashtable w_params = new Hashtable();
                w_params.Add("Folio", folio);
                DataTable dt = DB.Select("TiposMantenimientos", w_params);
                if (dt.Rows.Count == 0)
                {
                    throw new Exception("No existe TiposMantenimientos con los criterios de búsqueda especificados.");
                }
                DataRow dr = dt.Rows[0];
                return new TiposMantenimientos(Convert.ToInt32(dr["Folio"]), Convert.ToString(dr["Descripcion"]));
            } // End Read

            public int Update()
            {
                Hashtable m_params = new Hashtable();
                Hashtable w_params = new Hashtable();
                w_params.Add("Folio", this.Folio);
                if (!AppHelper.IsNullOrEmpty(this.Descripcion)) m_params.Add("Descripcion", this.Descripcion);

                return DB.UpdateRow("TiposMantenimientos", m_params, w_params);
            } // End Update

            public int Delete()
            {
                Hashtable w_params = new Hashtable();
                w_params.Add("Folio", this.Folio);

                return DB.DeleteRow("TiposMantenimientos", w_params);
            } // End Delete

        } //End Class TiposMantenimientos

        public class TiposModeloNegocio
        {

            public TiposModeloNegocio()
            {
            }

            public TiposModeloNegocio(int folio, string descripcion, decimal maximoprestamocombustible)
            {
                this.Folio = folio;
                this.Descripcion = descripcion;
                this.MaximoPrestamoCombustible = maximoprestamocombustible;
            }

            private int _Folio;
            public int Folio
            {
                get { return _Folio; }
                set { _Folio = value; }
            }

            private string _Descripcion;
            public string Descripcion
            {
                get { return _Descripcion; }
                set { _Descripcion = value; }
            }

            private decimal _MaximoPrestamoCombustible;
            public decimal MaximoPrestamoCombustible
            {
                get { return _MaximoPrestamoCombustible; }
                set { _MaximoPrestamoCombustible = value; }
            }

            public int Create()
            {
                Hashtable m_params = new Hashtable();
                m_params.Add("Descripcion", this.Descripcion);
                m_params.Add("MaximoPrestamoCombustible", this.MaximoPrestamoCombustible);

                return DB.InsertRow("TiposModeloNegocio", m_params);
            } // End Create

            public static List<TiposModeloNegocio> Read()
            {
                List<TiposModeloNegocio> list = new List<TiposModeloNegocio>();
                DataTable dt = DB.Select("TiposModeloNegocio");
                foreach (DataRow dr in dt.Rows)
                {
                    list.Add(new TiposModeloNegocio(Convert.ToInt32(dr["Folio"]), Convert.ToString(dr["Descripcion"]), Convert.ToDecimal(dr["MaximoPrestamoCombustible"])));
                }

                return list;
            } // End Read

            public static TiposModeloNegocio Read(int folio)
            {
                Hashtable w_params = new Hashtable();
                w_params.Add("Folio", folio);
                DataTable dt = DB.Select("TiposModeloNegocio", w_params);
                if (dt.Rows.Count == 0)
                {
                    throw new Exception("No existe TiposModeloNegocio con los criterios de búsqueda especificados.");
                }
                DataRow dr = dt.Rows[0];
                return new TiposModeloNegocio(Convert.ToInt32(dr["Folio"]), Convert.ToString(dr["Descripcion"]), Convert.ToDecimal(dr["MaximoPrestamoCombustible"]));
            } // End Read

            public int Update()
            {
                Hashtable m_params = new Hashtable();
                Hashtable w_params = new Hashtable();
                w_params.Add("Folio", this.Folio);
                m_params.Add("Descripcion", this.Descripcion);
                m_params.Add("MaximoPrestamoCombustible", this.MaximoPrestamoCombustible);

                return DB.UpdateRow("TiposModeloNegocio", m_params, w_params);
            } // End Update

            public int Delete()
            {
                Hashtable w_params = new Hashtable();
                w_params.Add("Folio", this.Folio);

                return DB.DeleteRow("TiposModeloNegocio", w_params);
            } // End Delete

        } //End Class TiposModeloNegocio

        public class TiposPagos
        {

            public TiposPagos()
            {
            }

            public TiposPagos(int folio, string descripcion)
            {
                this.Folio = folio;
                this.Descripcion = descripcion;
            }

            private int _Folio;
            public int Folio
            {
                get { return _Folio; }
                set { _Folio = value; }
            }

            private string _Descripcion;
            public string Descripcion
            {
                get { return _Descripcion; }
                set { _Descripcion = value; }
            }

            public int Create()
            {
                Hashtable m_params = new Hashtable();
                m_params.Add("Descripcion", this.Descripcion);

                return DB.InsertRow("TiposPagos", m_params);
            } // End Create

            public static List<TiposPagos> Read()
            {
                List<TiposPagos> list = new List<TiposPagos>();
                DataTable dt = DB.Select("TiposPagos");
                foreach (DataRow dr in dt.Rows)
                {
                    list.Add(new TiposPagos(Convert.ToInt32(dr["Folio"]), Convert.ToString(dr["Descripcion"])));
                }

                return list;
            } // End Read

            public static TiposPagos Read(int folio)
            {
                Hashtable w_params = new Hashtable();
                w_params.Add("Folio", folio);
                DataTable dt = DB.Select("TiposPagos", w_params);
                if (dt.Rows.Count == 0)
                {
                    throw new Exception("No existe TiposPagos con los criterios de búsqueda especificados.");
                }
                DataRow dr = dt.Rows[0];
                return new TiposPagos(Convert.ToInt32(dr["Folio"]), Convert.ToString(dr["Descripcion"]));
            } // End Read

            public int Update()
            {
                Hashtable m_params = new Hashtable();
                Hashtable w_params = new Hashtable();
                w_params.Add("Folio", this.Folio);
                m_params.Add("Descripcion", this.Descripcion);

                return DB.UpdateRow("TiposPagos", m_params, w_params);
            } // End Update

            public int Delete()
            {
                Hashtable w_params = new Hashtable();
                w_params.Add("Folio", this.Folio);

                return DB.DeleteRow("TiposPagos", w_params);
            } // End Delete

        } //End Class TiposPagos

        public class TiposParticipacionPercances
        {

            public TiposParticipacionPercances()
            {
            }

            public TiposParticipacionPercances(int folio, string descripcion)
            {
                this.Folio = folio;
                this.Descripcion = descripcion;
            }

            private int _Folio;
            public int Folio
            {
                get { return _Folio; }
                set { _Folio = value; }
            }

            private string _Descripcion;
            public string Descripcion
            {
                get { return _Descripcion; }
                set { _Descripcion = value; }
            }

            public int Create()
            {
                Hashtable m_params = new Hashtable();
                if (!AppHelper.IsNullOrEmpty(this.Descripcion)) m_params.Add("Descripcion", this.Descripcion);

                return DB.InsertRow("TiposParticipacionPercances", m_params);
            } // End Create

            public static List<TiposParticipacionPercances> Read()
            {
                List<TiposParticipacionPercances> list = new List<TiposParticipacionPercances>();
                DataTable dt = DB.Select("TiposParticipacionPercances");
                foreach (DataRow dr in dt.Rows)
                {
                    list.Add(new TiposParticipacionPercances(Convert.ToInt32(dr["Folio"]), Convert.ToString(dr["Descripcion"])));
                }

                return list;
            } // End Read

            public static TiposParticipacionPercances Read(int folio)
            {
                Hashtable w_params = new Hashtable();
                w_params.Add("Folio", folio);
                DataTable dt = DB.Select("TiposParticipacionPercances", w_params);
                if (dt.Rows.Count == 0)
                {
                    throw new Exception("No existe TiposParticipacionPercances con los criterios de búsqueda especificados.");
                }
                DataRow dr = dt.Rows[0];
                return new TiposParticipacionPercances(Convert.ToInt32(dr["Folio"]), Convert.ToString(dr["Descripcion"]));
            } // End Read

            public int Update()
            {
                Hashtable m_params = new Hashtable();
                Hashtable w_params = new Hashtable();
                w_params.Add("Folio", this.Folio);
                if (!AppHelper.IsNullOrEmpty(this.Descripcion)) m_params.Add("Descripcion", this.Descripcion);

                return DB.UpdateRow("TiposParticipacionPercances", m_params, w_params);
            } // End Update

            public int Delete()
            {
                Hashtable w_params = new Hashtable();
                w_params.Add("Folio", this.Folio);

                return DB.DeleteRow("TiposParticipacionPercances", w_params);
            } // End Delete

        } //End Class TiposParticipacionPercances

        public class TiposPenalizacion
        {

            public TiposPenalizacion()
            {
            }

            public TiposPenalizacion(int folio, string descripcion)
            {
                this.Folio = folio;
                this.Descripcion = descripcion;
            }

            private int _Folio;
            public int Folio
            {
                get { return _Folio; }
                set { _Folio = value; }
            }

            private string _Descripcion;
            public string Descripcion
            {
                get { return _Descripcion; }
                set { _Descripcion = value; }
            }

            public int Create()
            {
                Hashtable m_params = new Hashtable();
                if (!AppHelper.IsNullOrEmpty(this.Descripcion)) m_params.Add("Descripcion", this.Descripcion);

                return DB.InsertRow("TiposPenalizacion", m_params);
            } // End Create

            public static List<TiposPenalizacion> Read()
            {
                List<TiposPenalizacion> list = new List<TiposPenalizacion>();
                DataTable dt = DB.Select("TiposPenalizacion");
                foreach (DataRow dr in dt.Rows)
                {
                    list.Add(new TiposPenalizacion(Convert.ToInt32(dr["Folio"]), Convert.ToString(dr["Descripcion"])));
                }

                return list;
            } // End Read

            public static TiposPenalizacion Read(int folio)
            {
                Hashtable w_params = new Hashtable();
                w_params.Add("Folio", folio);
                DataTable dt = DB.Select("TiposPenalizacion", w_params);
                if (dt.Rows.Count == 0)
                {
                    throw new Exception("No existe TiposPenalizacion con los criterios de búsqueda especificados.");
                }
                DataRow dr = dt.Rows[0];
                return new TiposPenalizacion(Convert.ToInt32(dr["Folio"]), Convert.ToString(dr["Descripcion"]));
            } // End Read

            public int Update()
            {
                Hashtable m_params = new Hashtable();
                Hashtable w_params = new Hashtable();
                w_params.Add("Folio", this.Folio);
                if (!AppHelper.IsNullOrEmpty(this.Descripcion)) m_params.Add("Descripcion", this.Descripcion);

                return DB.UpdateRow("TiposPenalizacion", m_params, w_params);
            } // End Update

            public int Delete()
            {
                Hashtable w_params = new Hashtable();
                w_params.Add("Folio", this.Folio);

                return DB.DeleteRow("TiposPenalizacion", w_params);
            } // End Delete

        } //End Class TiposPenalizacion

        public class TiposPercances
        {

            public TiposPercances()
            {
            }

            public TiposPercances(int folio, string descripcion)
            {
                this.Folio = folio;
                this.Descripcion = descripcion;
            }

            private int _Folio;
            public int Folio
            {
                get { return _Folio; }
                set { _Folio = value; }
            }

            private string _Descripcion;
            public string Descripcion
            {
                get { return _Descripcion; }
                set { _Descripcion = value; }
            }

            public int Create()
            {
                Hashtable m_params = new Hashtable();
                if (!AppHelper.IsNullOrEmpty(this.Descripcion)) m_params.Add("Descripcion", this.Descripcion);

                return DB.InsertRow("TiposPercances", m_params);
            } // End Create

            public static List<TiposPercances> Read()
            {
                List<TiposPercances> list = new List<TiposPercances>();
                DataTable dt = DB.Select("TiposPercances");
                foreach (DataRow dr in dt.Rows)
                {
                    list.Add(new TiposPercances(Convert.ToInt32(dr["Folio"]), Convert.ToString(dr["Descripcion"])));
                }

                return list;
            } // End Read

            public static TiposPercances Read(int folio)
            {
                Hashtable w_params = new Hashtable();
                w_params.Add("Folio", folio);
                DataTable dt = DB.Select("TiposPercances", w_params);
                if (dt.Rows.Count == 0)
                {
                    throw new Exception("No existe TiposPercances con los criterios de búsqueda especificados.");
                }
                DataRow dr = dt.Rows[0];
                return new TiposPercances(Convert.ToInt32(dr["Folio"]), Convert.ToString(dr["Descripcion"]));
            } // End Read

            public int Update()
            {
                Hashtable m_params = new Hashtable();
                Hashtable w_params = new Hashtable();
                w_params.Add("Folio", this.Folio);
                if (!AppHelper.IsNullOrEmpty(this.Descripcion)) m_params.Add("Descripcion", this.Descripcion);

                return DB.UpdateRow("TiposPercances", m_params, w_params);
            } // End Update

            public int Delete()
            {
                Hashtable w_params = new Hashtable();
                w_params.Add("Folio", this.Folio);

                return DB.DeleteRow("TiposPercances", w_params);
            } // End Delete

        } //End Class TiposPercances

        public class TiposReferencias
        {

            public TiposReferencias()
            {
            }

            public TiposReferencias(int folio, string descripcion)
            {
                this.Folio = folio;
                this.Descripcion = descripcion;
            }

            private int _Folio;
            public int Folio
            {
                get { return _Folio; }
                set { _Folio = value; }
            }

            private string _Descripcion;
            public string Descripcion
            {
                get { return _Descripcion; }
                set { _Descripcion = value; }
            }

            public int Create()
            {
                Hashtable m_params = new Hashtable();
                m_params.Add("Descripcion", this.Descripcion);

                return DB.InsertRow("TiposReferencias", m_params);
            } // End Create

            public static List<TiposReferencias> Read()
            {
                List<TiposReferencias> list = new List<TiposReferencias>();
                DataTable dt = DB.Select("TiposReferencias");
                foreach (DataRow dr in dt.Rows)
                {
                    list.Add(new TiposReferencias(Convert.ToInt32(dr["Folio"]), Convert.ToString(dr["Descripcion"])));
                }

                return list;
            } // End Read

            public static TiposReferencias Read(int folio)
            {
                Hashtable w_params = new Hashtable();
                w_params.Add("Folio", folio);
                DataTable dt = DB.Select("TiposReferencias", w_params);
                if (dt.Rows.Count == 0)
                {
                    throw new Exception("No existe TiposReferencias con los criterios de búsqueda especificados.");
                }
                DataRow dr = dt.Rows[0];
                return new TiposReferencias(Convert.ToInt32(dr["Folio"]), Convert.ToString(dr["Descripcion"]));
            } // End Read

            public int Update()
            {
                Hashtable m_params = new Hashtable();
                Hashtable w_params = new Hashtable();
                w_params.Add("Folio", this.Folio);
                m_params.Add("Descripcion", this.Descripcion);

                return DB.UpdateRow("TiposReferencias", m_params, w_params);
            } // End Update

            public int Delete()
            {
                Hashtable w_params = new Hashtable();
                w_params.Add("Folio", this.Folio);

                return DB.DeleteRow("TiposReferencias", w_params);
            } // End Delete

        } //End Class TiposReferencias

        public class TiposSaldosCaja
        {

            public TiposSaldosCaja()
            {
            }

            public TiposSaldosCaja(int folio, string descripcion)
            {
                this.Folio = folio;
                this.Descripcion = descripcion;
            }

            private int _Folio;
            public int Folio
            {
                get { return _Folio; }
                set { _Folio = value; }
            }

            private string _Descripcion;
            public string Descripcion
            {
                get { return _Descripcion; }
                set { _Descripcion = value; }
            }

            public int Create()
            {
                Hashtable m_params = new Hashtable();
                if (!AppHelper.IsNullOrEmpty(this.Descripcion)) m_params.Add("Descripcion", this.Descripcion);

                return DB.InsertRow("TiposSaldosCaja", m_params);
            } // End Create

            public static List<TiposSaldosCaja> Read()
            {
                List<TiposSaldosCaja> list = new List<TiposSaldosCaja>();
                DataTable dt = DB.Select("TiposSaldosCaja");
                foreach (DataRow dr in dt.Rows)
                {
                    list.Add(new TiposSaldosCaja(Convert.ToInt32(dr["Folio"]), Convert.ToString(dr["Descripcion"])));
                }

                return list;
            } // End Read

            public static TiposSaldosCaja Read(int folio)
            {
                Hashtable w_params = new Hashtable();
                w_params.Add("Folio", folio);
                DataTable dt = DB.Select("TiposSaldosCaja", w_params);
                if (dt.Rows.Count == 0)
                {
                    throw new Exception("No existe TiposSaldosCaja con los criterios de búsqueda especificados.");
                }
                DataRow dr = dt.Rows[0];
                return new TiposSaldosCaja(Convert.ToInt32(dr["Folio"]), Convert.ToString(dr["Descripcion"]));
            } // End Read

            public int Update()
            {
                Hashtable m_params = new Hashtable();
                Hashtable w_params = new Hashtable();
                w_params.Add("Folio", this.Folio);
                if (!AppHelper.IsNullOrEmpty(this.Descripcion)) m_params.Add("Descripcion", this.Descripcion);

                return DB.UpdateRow("TiposSaldosCaja", m_params, w_params);
            } // End Update

            public int Delete()
            {
                Hashtable w_params = new Hashtable();
                w_params.Add("Folio", this.Folio);

                return DB.DeleteRow("TiposSaldosCaja", w_params);
            } // End Delete

        } //End Class TiposSaldosCaja

        public class TiposServicios
        {

            public TiposServicios()
            {
            }

            public TiposServicios(int folio, string descripcion)
            {
                this.Folio = folio;
                this.Descripcion = descripcion;
            }

            private int _Folio;
            public int Folio
            {
                get { return _Folio; }
                set { _Folio = value; }
            }

            private string _Descripcion;
            public string Descripcion
            {
                get { return _Descripcion; }
                set { _Descripcion = value; }
            }

            public int Create()
            {
                Hashtable m_params = new Hashtable();
                m_params.Add("Descripcion", this.Descripcion);

                return DB.InsertRow("TiposServicios", m_params);
            } // End Create

            public static List<TiposServicios> Read()
            {
                List<TiposServicios> list = new List<TiposServicios>();
                DataTable dt = DB.Select("TiposServicios");
                foreach (DataRow dr in dt.Rows)
                {
                    list.Add(new TiposServicios(Convert.ToInt32(dr["Folio"]), Convert.ToString(dr["Descripcion"])));
                }

                return list;
            } // End Read

            public static TiposServicios Read(int folio)
            {
                Hashtable w_params = new Hashtable();
                w_params.Add("Folio", folio);
                DataTable dt = DB.Select("TiposServicios", w_params);
                if (dt.Rows.Count == 0)
                {
                    throw new Exception("No existe TiposServicios con los criterios de búsqueda especificados.");
                }
                DataRow dr = dt.Rows[0];
                return new TiposServicios(Convert.ToInt32(dr["Folio"]), Convert.ToString(dr["Descripcion"]));
            } // End Read

            public int Update()
            {
                Hashtable m_params = new Hashtable();
                Hashtable w_params = new Hashtable();
                w_params.Add("Folio", this.Folio);
                m_params.Add("Descripcion", this.Descripcion);

                return DB.UpdateRow("TiposServicios", m_params, w_params);
            } // End Update

            public int Delete()
            {
                Hashtable w_params = new Hashtable();
                w_params.Add("Folio", this.Folio);

                return DB.DeleteRow("TiposServicios", w_params);
            } // End Delete

        } //End Class TiposServicios

        public class TiposUnidades
        {

            public TiposUnidades()
            {
            }

            public TiposUnidades(int folio, string descripcion)
            {
                this.Folio = folio;
                this.Descripcion = descripcion;
            }

            private int _Folio;
            public int Folio
            {
                get { return _Folio; }
                set { _Folio = value; }
            }

            private string _Descripcion;
            public string Descripcion
            {
                get { return _Descripcion; }
                set { _Descripcion = value; }
            }

            public int Create()
            {
                Hashtable m_params = new Hashtable();
                m_params.Add("Descripcion", this.Descripcion);

                return DB.InsertRow("TiposUnidades", m_params);
            } // End Create

            public static List<TiposUnidades> Read()
            {
                List<TiposUnidades> list = new List<TiposUnidades>();
                DataTable dt = DB.Select("TiposUnidades");
                foreach (DataRow dr in dt.Rows)
                {
                    list.Add(new TiposUnidades(Convert.ToInt32(dr["Folio"]), Convert.ToString(dr["Descripcion"])));
                }

                return list;
            } // End Read

            public static TiposUnidades Read(int folio)
            {
                Hashtable w_params = new Hashtable();
                w_params.Add("Folio", folio);
                DataTable dt = DB.Select("TiposUnidades", w_params);
                if (dt.Rows.Count == 0)
                {
                    throw new Exception("No existe TiposUnidades con los criterios de búsqueda especificados.");
                }
                DataRow dr = dt.Rows[0];
                return new TiposUnidades(Convert.ToInt32(dr["Folio"]), Convert.ToString(dr["Descripcion"]));
            } // End Read

            public int Update()
            {
                Hashtable m_params = new Hashtable();
                Hashtable w_params = new Hashtable();
                w_params.Add("Folio", this.Folio);
                m_params.Add("Descripcion", this.Descripcion);

                return DB.UpdateRow("TiposUnidades", m_params, w_params);
            } // End Update

            public int Delete()
            {
                Hashtable w_params = new Hashtable();
                w_params.Add("Folio", this.Folio);

                return DB.DeleteRow("TiposUnidades", w_params);
            } // End Delete

        } //End Class TiposUnidades

        public class TiposZonas
        {

            public TiposZonas()
            {
            }

            public TiposZonas(int folio, string descripcion, bool acredita)
            {
                this.Folio = folio;
                this.Descripcion = descripcion;
                this.Acredita = acredita;
            }

            private int _Folio;
            public int Folio
            {
                get { return _Folio; }
                set { _Folio = value; }
            }

            private string _Descripcion;
            public string Descripcion
            {
                get { return _Descripcion; }
                set { _Descripcion = value; }
            }

            private bool _Acredita;
            public bool Acredita
            {
                get { return _Acredita; }
                set { _Acredita = value; }
            }

            public int Create()
            {
                Hashtable m_params = new Hashtable();
                m_params.Add("Descripcion", this.Descripcion);
                m_params.Add("Acredita", this.Acredita);

                return DB.InsertRow("TiposZonas", m_params);
            } // End Create

            public static List<TiposZonas> Read()
            {
                List<TiposZonas> list = new List<TiposZonas>();
                DataTable dt = DB.Select("TiposZonas");
                foreach (DataRow dr in dt.Rows)
                {
                    list.Add(new TiposZonas(Convert.ToInt32(dr["Folio"]), Convert.ToString(dr["Descripcion"]), Convert.ToBoolean(dr["Acredita"])));
                }

                return list;
            } // End Read

            public static TiposZonas Read(int folio)
            {
                Hashtable w_params = new Hashtable();
                w_params.Add("Folio", folio);
                DataTable dt = DB.Select("TiposZonas", w_params);
                if (dt.Rows.Count == 0)
                {
                    throw new Exception("No existe TiposZonas con los criterios de búsqueda especificados.");
                }
                DataRow dr = dt.Rows[0];
                return new TiposZonas(Convert.ToInt32(dr["Folio"]), Convert.ToString(dr["Descripcion"]), Convert.ToBoolean(dr["Acredita"]));
            } // End Read

            public int Update()
            {
                Hashtable m_params = new Hashtable();
                Hashtable w_params = new Hashtable();
                w_params.Add("Folio", this.Folio);
                m_params.Add("Descripcion", this.Descripcion);
                m_params.Add("Acredita", this.Acredita);

                return DB.UpdateRow("TiposZonas", m_params, w_params);
            } // End Update

            public int Delete()
            {
                Hashtable w_params = new Hashtable();
                w_params.Add("Folio", this.Folio);

                return DB.DeleteRow("TiposZonas", w_params);
            } // End Delete

        } //End Class TiposZonas

        public class Transacciones_OXXOGas
        {

            public Transacciones_OXXOGas()
            {
            }

            public Transacciones_OXXOGas(int transaccion_id, int unidad, string empresa, DateTime fecha, string id_tran_oxxogas, string codigocliente, string tarjeta, string tag_id, string producto, decimal cantidad, decimal monto, bool exito, string usuario_oxxogas, string usuario, string tipoventa)
            {
                this.Transaccion_ID = transaccion_id;
                this.Unidad = unidad;
                this.Empresa = empresa;
                this.Fecha = fecha;
                this.ID_Tran_OXXOGas = id_tran_oxxogas;
                this.CodigoCliente = codigocliente;
                this.Tarjeta = tarjeta;
                this.Tag_ID = tag_id;
                this.Producto = producto;
                this.Cantidad = cantidad;
                this.Monto = monto;
                this.Exito = exito;
                this.Usuario_OXXOGas = usuario_oxxogas;
                this.Usuario = usuario;
                this.TipoVenta = tipoventa;
            }

            private int _Transaccion_ID;
            public int Transaccion_ID
            {
                get { return _Transaccion_ID; }
                set { _Transaccion_ID = value; }
            }

            private int _Unidad;
            public int Unidad
            {
                get { return _Unidad; }
                set { _Unidad = value; }
            }

            private string _Empresa;
            public string Empresa
            {
                get { return _Empresa; }
                set { _Empresa = value; }
            }

            private DateTime _Fecha;
            public DateTime Fecha
            {
                get { return _Fecha; }
                set { _Fecha = value; }
            }

            private string _ID_Tran_OXXOGas;
            public string ID_Tran_OXXOGas
            {
                get { return _ID_Tran_OXXOGas; }
                set { _ID_Tran_OXXOGas = value; }
            }

            private string _CodigoCliente;
            public string CodigoCliente
            {
                get { return _CodigoCliente; }
                set { _CodigoCliente = value; }
            }

            private string _Tarjeta;
            public string Tarjeta
            {
                get { return _Tarjeta; }
                set { _Tarjeta = value; }
            }

            private string _Tag_ID;
            public string Tag_ID
            {
                get { return _Tag_ID; }
                set { _Tag_ID = value; }
            }

            private string _Producto;
            public string Producto
            {
                get { return _Producto; }
                set { _Producto = value; }
            }

            private decimal _Cantidad;
            public decimal Cantidad
            {
                get { return _Cantidad; }
                set { _Cantidad = value; }
            }

            private decimal _Monto;
            public decimal Monto
            {
                get { return _Monto; }
                set { _Monto = value; }
            }

            private bool _Exito;
            public bool Exito
            {
                get { return _Exito; }
                set { _Exito = value; }
            }

            private string _Usuario_OXXOGas;
            public string Usuario_OXXOGas
            {
                get { return _Usuario_OXXOGas; }
                set { _Usuario_OXXOGas = value; }
            }

            private string _Usuario;
            public string Usuario
            {
                get { return _Usuario; }
                set { _Usuario = value; }
            }

            private string _TipoVenta;
            public string TipoVenta
            {
                get { return _TipoVenta; }
                set { _TipoVenta = value; }
            }

            public int Create()
            {
                Hashtable m_params = new Hashtable();
                m_params.Add("Unidad", this.Unidad);
                m_params.Add("Empresa", this.Empresa);
                m_params.Add("Fecha", this.Fecha);
                m_params.Add("ID_Tran_OXXOGas", this.ID_Tran_OXXOGas);
                m_params.Add("CodigoCliente", this.CodigoCliente);
                if (!AppHelper.IsNullOrEmpty(this.Tarjeta)) m_params.Add("Tarjeta", this.Tarjeta);
                if (!AppHelper.IsNullOrEmpty(this.Tag_ID)) m_params.Add("Tag_ID", this.Tag_ID);
                m_params.Add("Producto", this.Producto);
                m_params.Add("Cantidad", this.Cantidad);
                m_params.Add("Monto", this.Monto);
                m_params.Add("Exito", this.Exito);
                m_params.Add("Usuario_OXXOGas", this.Usuario_OXXOGas);
                m_params.Add("Usuario", this.Usuario);
                if (!AppHelper.IsNullOrEmpty(this.TipoVenta)) m_params.Add("TipoVenta", this.TipoVenta);

                return DB.InsertRow("Transacciones_OXXOGas", m_params);
            } // End Create

            public static List<Transacciones_OXXOGas> Read()
            {
                List<Transacciones_OXXOGas> list = new List<Transacciones_OXXOGas>();
                DataTable dt = DB.Select("Transacciones_OXXOGas");
                foreach (DataRow dr in dt.Rows)
                {
                    list.Add(new Transacciones_OXXOGas(Convert.ToInt32(dr["Transaccion_ID"]), Convert.ToInt32(dr["Unidad"]), Convert.ToString(dr["Empresa"]), Convert.ToDateTime(dr["Fecha"]), Convert.ToString(dr["ID_Tran_OXXOGas"]), Convert.ToString(dr["CodigoCliente"]), Convert.ToString(dr["Tarjeta"]), Convert.ToString(dr["Tag_ID"]), Convert.ToString(dr["Producto"]), Convert.ToDecimal(dr["Cantidad"]), Convert.ToDecimal(dr["Monto"]), Convert.ToBoolean(dr["Exito"]), Convert.ToString(dr["Usuario_OXXOGas"]), Convert.ToString(dr["Usuario"]), Convert.ToString(dr["TipoVenta"])));
                }

                return list;
            } // End Read

            public static Transacciones_OXXOGas Read(int transaccion_id)
            {
                Hashtable w_params = new Hashtable();
                w_params.Add("Transaccion_ID", transaccion_id);
                DataTable dt = DB.Select("Transacciones_OXXOGas", w_params);
                if (dt.Rows.Count == 0)
                {
                    throw new Exception("No existe Transacciones_OXXOGas con los criterios de búsqueda especificados.");
                }
                DataRow dr = dt.Rows[0];
                return new Transacciones_OXXOGas(Convert.ToInt32(dr["Transaccion_ID"]), Convert.ToInt32(dr["Unidad"]), Convert.ToString(dr["Empresa"]), Convert.ToDateTime(dr["Fecha"]), Convert.ToString(dr["ID_Tran_OXXOGas"]), Convert.ToString(dr["CodigoCliente"]), Convert.ToString(dr["Tarjeta"]), Convert.ToString(dr["Tag_ID"]), Convert.ToString(dr["Producto"]), Convert.ToDecimal(dr["Cantidad"]), Convert.ToDecimal(dr["Monto"]), Convert.ToBoolean(dr["Exito"]), Convert.ToString(dr["Usuario_OXXOGas"]), Convert.ToString(dr["Usuario"]), Convert.ToString(dr["TipoVenta"]));
            } // End Read

            public int Update()
            {
                Hashtable m_params = new Hashtable();
                Hashtable w_params = new Hashtable();
                w_params.Add("Transaccion_ID", this.Transaccion_ID);
                m_params.Add("Unidad", this.Unidad);
                m_params.Add("Empresa", this.Empresa);
                m_params.Add("Fecha", this.Fecha);
                m_params.Add("ID_Tran_OXXOGas", this.ID_Tran_OXXOGas);
                m_params.Add("CodigoCliente", this.CodigoCliente);
                if (!AppHelper.IsNullOrEmpty(this.Tarjeta)) m_params.Add("Tarjeta", this.Tarjeta);
                if (!AppHelper.IsNullOrEmpty(this.Tag_ID)) m_params.Add("Tag_ID", this.Tag_ID);
                m_params.Add("Producto", this.Producto);
                m_params.Add("Cantidad", this.Cantidad);
                m_params.Add("Monto", this.Monto);
                m_params.Add("Exito", this.Exito);
                m_params.Add("Usuario_OXXOGas", this.Usuario_OXXOGas);
                m_params.Add("Usuario", this.Usuario);
                if (!AppHelper.IsNullOrEmpty(this.TipoVenta)) m_params.Add("TipoVenta", this.TipoVenta);

                return DB.UpdateRow("Transacciones_OXXOGas", m_params, w_params);
            } // End Update

            public int Delete()
            {
                Hashtable w_params = new Hashtable();
                w_params.Add("Transaccion_ID", this.Transaccion_ID);

                return DB.DeleteRow("Transacciones_OXXOGas", w_params);
            } // End Delete

        } //End Class Transacciones_OXXOGas

        public class TrasladosDePersonal
        {

            public TrasladosDePersonal()
            {
            }

            public TrasladosDePersonal(int folio, int conductor, int unidad, decimal monto, string comentarios, DateTime fecha, string usuario, bool pagado)
            {
                this.Folio = folio;
                this.Conductor = conductor;
                this.Unidad = unidad;
                this.Monto = monto;
                this.Comentarios = comentarios;
                this.Fecha = fecha;
                this.Usuario = usuario;
                this.Pagado = pagado;
            }

            private int _Folio;
            public int Folio
            {
                get { return _Folio; }
                set { _Folio = value; }
            }

            private int _Conductor;
            public int Conductor
            {
                get { return _Conductor; }
                set { _Conductor = value; }
            }

            private int _Unidad;
            public int Unidad
            {
                get { return _Unidad; }
                set { _Unidad = value; }
            }

            private decimal _Monto;
            public decimal Monto
            {
                get { return _Monto; }
                set { _Monto = value; }
            }

            private string _Comentarios;
            public string Comentarios
            {
                get { return _Comentarios; }
                set { _Comentarios = value; }
            }

            private DateTime _Fecha;
            public DateTime Fecha
            {
                get { return _Fecha; }
                set { _Fecha = value; }
            }

            private string _Usuario;
            public string Usuario
            {
                get { return _Usuario; }
                set { _Usuario = value; }
            }

            private bool _Pagado;
            public bool Pagado
            {
                get { return _Pagado; }
                set { _Pagado = value; }
            }

            public int Create()
            {
                Hashtable m_params = new Hashtable();
                m_params.Add("Folio", this.Folio);
                m_params.Add("Conductor", this.Conductor);
                m_params.Add("Unidad", this.Unidad);
                m_params.Add("Monto", this.Monto);
                if (!AppHelper.IsNullOrEmpty(this.Comentarios)) m_params.Add("Comentarios", this.Comentarios);
                m_params.Add("Fecha", this.Fecha);
                m_params.Add("Usuario", this.Usuario);
                m_params.Add("Pagado", this.Pagado);

                return DB.InsertRow("TrasladosDePersonal", m_params);
            } // End Create

            public static List<TrasladosDePersonal> Read()
            {
                List<TrasladosDePersonal> list = new List<TrasladosDePersonal>();
                DataTable dt = DB.Select("TrasladosDePersonal");
                foreach (DataRow dr in dt.Rows)
                {
                    list.Add(new TrasladosDePersonal(Convert.ToInt32(dr["Folio"]), Convert.ToInt32(dr["Conductor"]), Convert.ToInt32(dr["Unidad"]), Convert.ToDecimal(dr["Monto"]), Convert.ToString(dr["Comentarios"]), Convert.ToDateTime(dr["Fecha"]), Convert.ToString(dr["Usuario"]), Convert.ToBoolean(dr["Pagado"])));
                }

                return list;
            } // End Read

            public int Update()
            {
                Hashtable m_params = new Hashtable();
                Hashtable w_params = new Hashtable();
                m_params.Add("Folio", this.Folio);
                m_params.Add("Conductor", this.Conductor);
                m_params.Add("Unidad", this.Unidad);
                m_params.Add("Monto", this.Monto);
                if (!AppHelper.IsNullOrEmpty(this.Comentarios)) m_params.Add("Comentarios", this.Comentarios);
                m_params.Add("Fecha", this.Fecha);
                m_params.Add("Usuario", this.Usuario);
                m_params.Add("Pagado", this.Pagado);

                return DB.UpdateRow("TrasladosDePersonal", m_params, w_params);
            } // End Update

            public int Delete()
            {
                Hashtable w_params = new Hashtable();

                return DB.DeleteRow("TrasladosDePersonal", w_params);
            } // End Delete

        } //End Class TrasladosDePersonal

        public class Turnos
        {

            public Turnos()
            {
            }

            public Turnos(int folio, string descripcion, int? horainicial, int? horafinal)
            {
                this.Folio = folio;
                this.Descripcion = descripcion;
                this.HoraInicial = horainicial;
                this.HoraFinal = horafinal;
            }

            private int _Folio;
            public int Folio
            {
                get { return _Folio; }
                set { _Folio = value; }
            }

            private string _Descripcion;
            public string Descripcion
            {
                get { return _Descripcion; }
                set { _Descripcion = value; }
            }

            private int? _HoraInicial;
            public int? HoraInicial
            {
                get { return _HoraInicial; }
                set { _HoraInicial = value; }
            }

            private int? _HoraFinal;
            public int? HoraFinal
            {
                get { return _HoraFinal; }
                set { _HoraFinal = value; }
            }

            public int Create()
            {
                Hashtable m_params = new Hashtable();
                if (!AppHelper.IsNullOrEmpty(this.Descripcion)) m_params.Add("Descripcion", this.Descripcion);
                if (!AppHelper.IsNullOrEmpty(this.HoraInicial)) m_params.Add("HoraInicial", this.HoraInicial);
                if (!AppHelper.IsNullOrEmpty(this.HoraFinal)) m_params.Add("HoraFinal", this.HoraFinal);

                return DB.InsertRow("Turnos", m_params);
            } // End Create

            public static List<Turnos> Read()
            {
                List<Turnos> list = new List<Turnos>();
                DataTable dt = DB.Select("Turnos");
                foreach (DataRow dr in dt.Rows)
                {
                    list.Add(new Turnos(Convert.ToInt32(dr["Folio"]), Convert.ToString(dr["Descripcion"]), DB.GetNullableInt32(dr["HoraInicial"]), DB.GetNullableInt32(dr["HoraFinal"])));
                }

                return list;
            } // End Read

            public static Turnos Read(int folio)
            {
                Hashtable w_params = new Hashtable();
                w_params.Add("Folio", folio);
                DataTable dt = DB.Select("Turnos", w_params);
                if (dt.Rows.Count == 0)
                {
                    throw new Exception("No existe Turnos con los criterios de búsqueda especificados.");
                }
                DataRow dr = dt.Rows[0];
                return new Turnos(Convert.ToInt32(dr["Folio"]), Convert.ToString(dr["Descripcion"]), DB.GetNullableInt32(dr["HoraInicial"]), DB.GetNullableInt32(dr["HoraFinal"]));
            } // End Read

            public int Update()
            {
                Hashtable m_params = new Hashtable();
                Hashtable w_params = new Hashtable();
                w_params.Add("Folio", this.Folio);
                if (!AppHelper.IsNullOrEmpty(this.Descripcion)) m_params.Add("Descripcion", this.Descripcion);
                if (!AppHelper.IsNullOrEmpty(this.HoraInicial)) m_params.Add("HoraInicial", this.HoraInicial);
                if (!AppHelper.IsNullOrEmpty(this.HoraFinal)) m_params.Add("HoraFinal", this.HoraFinal);

                return DB.UpdateRow("Turnos", m_params, w_params);
            } // End Update

            public int Delete()
            {
                Hashtable w_params = new Hashtable();
                w_params.Add("Folio", this.Folio);

                return DB.DeleteRow("Turnos", w_params);
            } // End Delete

        } //End Class Turnos

        public class Unidades
        {

            public Unidades()
            {
            }

            public Unidades(int folio, int empresa, int tipo, int modelo, int numeroeconomico, string placas, string numeroserie, string numeroseriemotor, string tarjetacirculacion, DateTime fechaalta, int tipomodelonegocio, int? status, string usuarioalta, DateTime? fechabaja, string usuariobaja, string comentariosbaja)
            {
                this.Folio = folio;
                this.Empresa = empresa;
                this.Tipo = tipo;
                this.Modelo = modelo;
                this.NumeroEconomico = numeroeconomico;
                this.Placas = placas;
                this.NumeroSerie = numeroserie;
                this.NumeroSerieMotor = numeroseriemotor;
                this.TarjetaCirculacion = tarjetacirculacion;
                this.FechaAlta = fechaalta;
                this.TipoModeloNegocio = tipomodelonegocio;
                this.Status = status;
                this.UsuarioAlta = usuarioalta;
                this.FechaBaja = fechabaja;
                this.UsuarioBaja = usuariobaja;
                this.ComentariosBaja = comentariosbaja;
            }

            private int _Folio;
            public int Folio
            {
                get { return _Folio; }
                set { _Folio = value; }
            }

            private int _Empresa;
            public int Empresa
            {
                get { return _Empresa; }
                set { _Empresa = value; }
            }

            private int _Tipo;
            public int Tipo
            {
                get { return _Tipo; }
                set { _Tipo = value; }
            }

            private int _Modelo;
            public int Modelo
            {
                get { return _Modelo; }
                set { _Modelo = value; }
            }

            private int _NumeroEconomico;
            public int NumeroEconomico
            {
                get { return _NumeroEconomico; }
                set { _NumeroEconomico = value; }
            }

            private string _Placas;
            public string Placas
            {
                get { return _Placas; }
                set { _Placas = value; }
            }

            private string _NumeroSerie;
            public string NumeroSerie
            {
                get { return _NumeroSerie; }
                set { _NumeroSerie = value; }
            }

            private string _NumeroSerieMotor;
            public string NumeroSerieMotor
            {
                get { return _NumeroSerieMotor; }
                set { _NumeroSerieMotor = value; }
            }

            private string _TarjetaCirculacion;
            public string TarjetaCirculacion
            {
                get { return _TarjetaCirculacion; }
                set { _TarjetaCirculacion = value; }
            }

            private DateTime _FechaAlta;
            public DateTime FechaAlta
            {
                get { return _FechaAlta; }
                set { _FechaAlta = value; }
            }

            private int _TipoModeloNegocio;
            public int TipoModeloNegocio
            {
                get { return _TipoModeloNegocio; }
                set { _TipoModeloNegocio = value; }
            }

            private int? _Status;
            public int? Status
            {
                get { return _Status; }
                set { _Status = value; }
            }

            private string _UsuarioAlta;
            public string UsuarioAlta
            {
                get { return _UsuarioAlta; }
                set { _UsuarioAlta = value; }
            }

            private DateTime? _FechaBaja;
            public DateTime? FechaBaja
            {
                get { return _FechaBaja; }
                set { _FechaBaja = value; }
            }

            private string _UsuarioBaja;
            public string UsuarioBaja
            {
                get { return _UsuarioBaja; }
                set { _UsuarioBaja = value; }
            }

            private string _ComentariosBaja;
            public string ComentariosBaja
            {
                get { return _ComentariosBaja; }
                set { _ComentariosBaja = value; }
            }

            public int Create()
            {
                Hashtable m_params = new Hashtable();
                m_params.Add("Empresa", this.Empresa);
                m_params.Add("Tipo", this.Tipo);
                m_params.Add("Modelo", this.Modelo);
                m_params.Add("NumeroEconomico", this.NumeroEconomico);
                m_params.Add("Placas", this.Placas);
                m_params.Add("NumeroSerie", this.NumeroSerie);
                m_params.Add("NumeroSerieMotor", this.NumeroSerieMotor);
                m_params.Add("TarjetaCirculacion", this.TarjetaCirculacion);
                m_params.Add("FechaAlta", this.FechaAlta);
                m_params.Add("TipoModeloNegocio", this.TipoModeloNegocio);
                if (!AppHelper.IsNullOrEmpty(this.Status)) m_params.Add("Status", this.Status);
                if (!AppHelper.IsNullOrEmpty(this.UsuarioAlta)) m_params.Add("UsuarioAlta", this.UsuarioAlta);
                if (!AppHelper.IsNullOrEmpty(this.FechaBaja)) m_params.Add("FechaBaja", this.FechaBaja);
                if (!AppHelper.IsNullOrEmpty(this.UsuarioBaja)) m_params.Add("UsuarioBaja", this.UsuarioBaja);
                if (!AppHelper.IsNullOrEmpty(this.ComentariosBaja)) m_params.Add("ComentariosBaja", this.ComentariosBaja);

                return DB.InsertRow("Unidades", m_params);
            } // End Create

            public static List<Unidades> Read()
            {
                List<Unidades> list = new List<Unidades>();
                DataTable dt = DB.Select("Unidades");
                foreach (DataRow dr in dt.Rows)
                {
                    list.Add(new Unidades(Convert.ToInt32(dr["Folio"]), Convert.ToInt32(dr["Empresa"]), Convert.ToInt32(dr["Tipo"]), Convert.ToInt32(dr["Modelo"]), Convert.ToInt32(dr["NumeroEconomico"]), Convert.ToString(dr["Placas"]), Convert.ToString(dr["NumeroSerie"]), Convert.ToString(dr["NumeroSerieMotor"]), Convert.ToString(dr["TarjetaCirculacion"]), Convert.ToDateTime(dr["FechaAlta"]), Convert.ToInt32(dr["TipoModeloNegocio"]), DB.GetNullableInt32(dr["Status"]), Convert.ToString(dr["UsuarioAlta"]), DB.GetNullableDateTime(dr["FechaBaja"]), Convert.ToString(dr["UsuarioBaja"]), Convert.ToString(dr["ComentariosBaja"])));
                }

                return list;
            } // End Read

            public static Unidades Read(int folio)
            {
                Hashtable w_params = new Hashtable();
                w_params.Add("Folio", folio);
                DataTable dt = DB.Select("Unidades", w_params);
                if (dt.Rows.Count == 0)
                {
                    throw new Exception("No existe Unidades con los criterios de búsqueda especificados.");
                }
                DataRow dr = dt.Rows[0];
                return new Unidades(Convert.ToInt32(dr["Folio"]), Convert.ToInt32(dr["Empresa"]), Convert.ToInt32(dr["Tipo"]), Convert.ToInt32(dr["Modelo"]), Convert.ToInt32(dr["NumeroEconomico"]), Convert.ToString(dr["Placas"]), Convert.ToString(dr["NumeroSerie"]), Convert.ToString(dr["NumeroSerieMotor"]), Convert.ToString(dr["TarjetaCirculacion"]), Convert.ToDateTime(dr["FechaAlta"]), Convert.ToInt32(dr["TipoModeloNegocio"]), DB.GetNullableInt32(dr["Status"]), Convert.ToString(dr["UsuarioAlta"]), DB.GetNullableDateTime(dr["FechaBaja"]), Convert.ToString(dr["UsuarioBaja"]), Convert.ToString(dr["ComentariosBaja"]));
            } // End Read

            public static Unidades Read(params KeyValuePair<string, object>[] args)
            {
                DataTable dt = DB.Read("Unidades", args);
                if (dt.Rows.Count == 0)
                {
                    return null;
                }
                DataRow dr = dt.Rows[0];
                return new Unidades(Convert.ToInt32(dr["Folio"]), Convert.ToInt32(dr["Empresa"]), Convert.ToInt32(dr["Tipo"]), Convert.ToInt32(dr["Modelo"]), Convert.ToInt32(dr["NumeroEconomico"]), Convert.ToString(dr["Placas"]), Convert.ToString(dr["NumeroSerie"]), Convert.ToString(dr["NumeroSerieMotor"]), Convert.ToString(dr["TarjetaCirculacion"]), Convert.ToDateTime(dr["FechaAlta"]), Convert.ToInt32(dr["TipoModeloNegocio"]), DB.GetNullableInt32(dr["Status"]), Convert.ToString(dr["UsuarioAlta"]), DB.GetNullableDateTime(dr["FechaBaja"]), Convert.ToString(dr["UsuarioBaja"]), Convert.ToString(dr["ComentariosBaja"]));
            } // End Read

            public static bool Read(out Unidades unidades, int top, string filter, string sort, params KeyValuePair<string, object>[] args)
            {
                DataTable dt = DB.Read("Unidades", top, filter, sort, args);
                if (dt.Rows.Count == 0)
                {
                    unidades = null;
                    return false;
                }
                DataRow dr = dt.Rows[0];
                unidades = new Unidades(Convert.ToInt32(dr["Folio"]), Convert.ToInt32(dr["Empresa"]), Convert.ToInt32(dr["Tipo"]), Convert.ToInt32(dr["Modelo"]), Convert.ToInt32(dr["NumeroEconomico"]), Convert.ToString(dr["Placas"]), Convert.ToString(dr["NumeroSerie"]), Convert.ToString(dr["NumeroSerieMotor"]), Convert.ToString(dr["TarjetaCirculacion"]), Convert.ToDateTime(dr["FechaAlta"]), Convert.ToInt32(dr["TipoModeloNegocio"]), DB.GetNullableInt32(dr["Status"]), Convert.ToString(dr["UsuarioAlta"]), DB.GetNullableDateTime(dr["FechaBaja"]), Convert.ToString(dr["UsuarioBaja"]), Convert.ToString(dr["ComentariosBaja"]));
                return true;
            } // End Read

            public int Update()
            {
                Hashtable m_params = new Hashtable();
                Hashtable w_params = new Hashtable();
                w_params.Add("Folio", this.Folio);
                m_params.Add("Empresa", this.Empresa);
                m_params.Add("Tipo", this.Tipo);
                m_params.Add("Modelo", this.Modelo);
                m_params.Add("NumeroEconomico", this.NumeroEconomico);
                m_params.Add("Placas", this.Placas);
                m_params.Add("NumeroSerie", this.NumeroSerie);
                m_params.Add("NumeroSerieMotor", this.NumeroSerieMotor);
                m_params.Add("TarjetaCirculacion", this.TarjetaCirculacion);
                m_params.Add("FechaAlta", this.FechaAlta);
                m_params.Add("TipoModeloNegocio", this.TipoModeloNegocio);
                if (!AppHelper.IsNullOrEmpty(this.Status)) m_params.Add("Status", this.Status);
                if (!AppHelper.IsNullOrEmpty(this.UsuarioAlta)) m_params.Add("UsuarioAlta", this.UsuarioAlta);
                if (!AppHelper.IsNullOrEmpty(this.FechaBaja)) m_params.Add("FechaBaja", this.FechaBaja);
                if (!AppHelper.IsNullOrEmpty(this.UsuarioBaja)) m_params.Add("UsuarioBaja", this.UsuarioBaja);
                if (!AppHelper.IsNullOrEmpty(this.ComentariosBaja)) m_params.Add("ComentariosBaja", this.ComentariosBaja);

                return DB.UpdateRow("Unidades", m_params, w_params);
            } // End Update

            public int Delete()
            {
                Hashtable w_params = new Hashtable();
                w_params.Add("Folio", this.Folio);

                return DB.DeleteRow("Unidades", w_params);
            } // End Delete

        } //End Class Unidades

        public class Unidades_OXXOGas
        {

            public Unidades_OXXOGas()
            {
            }

            public Unidades_OXXOGas(int unidad, string tarjeta, string tag_id)
            {
                this.Unidad = unidad;
                this.Tarjeta = tarjeta;
                this.Tag_ID = tag_id;
            }

            private int _Unidad;
            public int Unidad
            {
                get { return _Unidad; }
                set { _Unidad = value; }
            }

            private string _Tarjeta;
            public string Tarjeta
            {
                get { return _Tarjeta; }
                set { _Tarjeta = value; }
            }

            private string _Tag_ID;
            public string Tag_ID
            {
                get { return _Tag_ID; }
                set { _Tag_ID = value; }
            }

            public int Create()
            {
                Hashtable m_params = new Hashtable();
                m_params.Add("Unidad", this.Unidad);
                m_params.Add("Tarjeta", this.Tarjeta);
                m_params.Add("Tag_ID", this.Tag_ID);

                return DB.InsertRow("Unidades_OXXOGas", m_params);
            } // End Create

            public static List<Unidades_OXXOGas> Read()
            {
                List<Unidades_OXXOGas> list = new List<Unidades_OXXOGas>();
                DataTable dt = DB.Select("Unidades_OXXOGas");
                foreach (DataRow dr in dt.Rows)
                {
                    list.Add(new Unidades_OXXOGas(Convert.ToInt32(dr["Unidad"]), Convert.ToString(dr["Tarjeta"]), Convert.ToString(dr["Tag_ID"])));
                }

                return list;
            } // End Read

            public static Unidades_OXXOGas Read(int unidad)
            {
                Hashtable w_params = new Hashtable();
                w_params.Add("Unidad", unidad);
                DataTable dt = DB.Select("Unidades_OXXOGas", w_params);
                if (dt.Rows.Count == 0)
                {
                    throw new Exception("No existe Unidades_OXXOGas con los criterios de búsqueda especificados.");
                }
                DataRow dr = dt.Rows[0];
                return new Unidades_OXXOGas(Convert.ToInt32(dr["Unidad"]), Convert.ToString(dr["Tarjeta"]), Convert.ToString(dr["Tag_ID"]));
            } // End Read

            public int Update()
            {
                Hashtable m_params = new Hashtable();
                Hashtable w_params = new Hashtable();
                w_params.Add("Unidad", this.Unidad);
                m_params.Add("Tarjeta", this.Tarjeta);
                m_params.Add("Tag_ID", this.Tag_ID);

                return DB.UpdateRow("Unidades_OXXOGas", m_params, w_params);
            } // End Update

            public int Delete()
            {
                Hashtable w_params = new Hashtable();
                w_params.Add("Unidad", this.Unidad);

                return DB.DeleteRow("Unidades_OXXOGas", w_params);
            } // End Delete

        } //End Class Unidades_OXXOGas

        public class UnidadesConductores
        {

            public UnidadesConductores()
            {
            }

            public UnidadesConductores(int unidad, int conductor)
            {
                this.Unidad = unidad;
                this.Conductor = conductor;
            }

            private int _Unidad;
            public int Unidad
            {
                get { return _Unidad; }
                set { _Unidad = value; }
            }

            private int _Conductor;
            public int Conductor
            {
                get { return _Conductor; }
                set { _Conductor = value; }
            }

            public int Create()
            {
                Hashtable m_params = new Hashtable();
                m_params.Add("Unidad", this.Unidad);
                m_params.Add("Conductor", this.Conductor);

                return DB.InsertRow("UnidadesConductores", m_params);
            } // End Create

            public static List<UnidadesConductores> Read()
            {
                List<UnidadesConductores> list = new List<UnidadesConductores>();
                DataTable dt = DB.Select("UnidadesConductores");
                foreach (DataRow dr in dt.Rows)
                {
                    list.Add(new UnidadesConductores(Convert.ToInt32(dr["Unidad"]), Convert.ToInt32(dr["Conductor"])));
                }

                return list;
            } // End Read

            public int Update()
            {
                Hashtable m_params = new Hashtable();
                Hashtable w_params = new Hashtable();
                m_params.Add("Unidad", this.Unidad);
                m_params.Add("Conductor", this.Conductor);

                return DB.UpdateRow("UnidadesConductores", m_params, w_params);
            } // End Update

            public int Delete()
            {
                Hashtable w_params = new Hashtable();

                return DB.DeleteRow("UnidadesConductores", w_params);
            } // End Delete

        } //End Class UnidadesConductores

        public class UnidadesEbssa
        {

            public UnidadesEbssa()
            {
            }

            public UnidadesEbssa(int unidad, int unidadebssa)
            {
                this.Unidad = unidad;
                this.UnidadEbssa = unidadebssa;
            }

            private int _Unidad;
            public int Unidad
            {
                get { return _Unidad; }
                set { _Unidad = value; }
            }

            private int _UnidadEbssa;
            public int UnidadEbssa
            {
                get { return _UnidadEbssa; }
                set { _UnidadEbssa = value; }
            }

            public int Create()
            {
                Hashtable m_params = new Hashtable();
                m_params.Add("Unidad", this.Unidad);
                m_params.Add("UnidadEbssa", this.UnidadEbssa);

                return DB.InsertRow("UnidadesEbssa", m_params);
            } // End Create

            public static List<UnidadesEbssa> Read()
            {
                List<UnidadesEbssa> list = new List<UnidadesEbssa>();
                DataTable dt = DB.Select("UnidadesEbssa");
                foreach (DataRow dr in dt.Rows)
                {
                    list.Add(new UnidadesEbssa(Convert.ToInt32(dr["Unidad"]), Convert.ToInt32(dr["UnidadEbssa"])));
                }

                return list;
            } // End Read

            public int Update()
            {
                Hashtable m_params = new Hashtable();
                Hashtable w_params = new Hashtable();
                m_params.Add("Unidad", this.Unidad);
                m_params.Add("UnidadEbssa", this.UnidadEbssa);

                return DB.UpdateRow("UnidadesEbssa", m_params, w_params);
            } // End Update

            public int Delete()
            {
                Hashtable w_params = new Hashtable();

                return DB.DeleteRow("UnidadesEbssa", w_params);
            } // End Delete

        } //End Class UnidadesEbssa

        public class UnidadesLocaciones
        {

            public UnidadesLocaciones()
            {
            }

            public UnidadesLocaciones(int unidad, int locacion, DateTime? fecha)
            {
                this.Unidad = unidad;
                this.Locacion = locacion;
                this.Fecha = fecha;
            }

            private int _Unidad;
            public int Unidad
            {
                get { return _Unidad; }
                set { _Unidad = value; }
            }

            private int _Locacion;
            public int Locacion
            {
                get { return _Locacion; }
                set { _Locacion = value; }
            }

            private DateTime? _Fecha;
            public DateTime? Fecha
            {
                get { return _Fecha; }
                set { _Fecha = value; }
            }

            public int Create()
            {
                Hashtable m_params = new Hashtable();
                m_params.Add("Unidad", this.Unidad);
                m_params.Add("Unidad", this.Unidad);
                m_params.Add("Locacion", this.Locacion);
                if (!AppHelper.IsNullOrEmpty(this.Fecha)) m_params.Add("Fecha", this.Fecha);

                return DB.InsertRow("UnidadesLocaciones", m_params);
            } // End Create

            public static List<UnidadesLocaciones> Read()
            {
                List<UnidadesLocaciones> list = new List<UnidadesLocaciones>();
                DataTable dt = DB.Select("UnidadesLocaciones");
                foreach (DataRow dr in dt.Rows)
                {
                    list.Add(new UnidadesLocaciones(Convert.ToInt32(dr["Unidad"]), Convert.ToInt32(dr["Locacion"]), DB.GetNullableDateTime(dr["Fecha"])));
                }

                return list;
            } // End Read

            public static UnidadesLocaciones Read(int unidad)
            {
                Hashtable w_params = new Hashtable();
                w_params.Add("Unidad", unidad);
                DataTable dt = DB.Select("UnidadesLocaciones", w_params);
                if (dt.Rows.Count == 0)
                {
                    throw new Exception("No existe UnidadesLocaciones con los criterios de búsqueda especificados.");
                }
                DataRow dr = dt.Rows[0];
                return new UnidadesLocaciones(Convert.ToInt32(dr["Unidad"]), Convert.ToInt32(dr["Locacion"]), DB.GetNullableDateTime(dr["Fecha"]));
            } // End Read

            public static UnidadesLocaciones Read(params KeyValuePair<string, object>[] args)
            {
                DataTable dt = DB.Read("UnidadesLocaciones", args);
                if (dt.Rows.Count == 0)
                {
                    return null;
                }
                DataRow dr = dt.Rows[0];
                return new UnidadesLocaciones(Convert.ToInt32(dr["Unidad"]), Convert.ToInt32(dr["Locacion"]), DB.GetNullableDateTime(dr["Fecha"]));
            } // End Read

            public static bool Read(out UnidadesLocaciones unidadeslocaciones, int top, string filter, string sort, params KeyValuePair<string, object>[] args)
            {
                DataTable dt = DB.Read("UnidadesLocaciones", top, filter, sort, args);
                if (dt.Rows.Count == 0)
                {
                    unidadeslocaciones = null;
                    return false;
                }
                DataRow dr = dt.Rows[0];
                unidadeslocaciones = new UnidadesLocaciones(Convert.ToInt32(dr["Unidad"]), Convert.ToInt32(dr["Locacion"]), DB.GetNullableDateTime(dr["Fecha"]));
                return true;
            } // End Read


            public int Update()
            {
                Hashtable m_params = new Hashtable();
                Hashtable w_params = new Hashtable();
                m_params.Add("Unidad", this.Unidad);
                w_params.Add("Unidad", this.Unidad);
                m_params.Add("Locacion", this.Locacion);
                if (!AppHelper.IsNullOrEmpty(this.Fecha)) m_params.Add("Fecha", this.Fecha);

                return DB.UpdateRow("UnidadesLocaciones", m_params, w_params);
            } // End Update

            public int Delete()
            {
                Hashtable w_params = new Hashtable();
                w_params.Add("Unidad", this.Unidad);

                return DB.DeleteRow("UnidadesLocaciones", w_params);
            } // End Delete

        } //End Class UnidadesLocaciones

        public class Usuarios
        {

            public Usuarios()
            {
            }

            public Usuarios(string clave, string pwd, int? empresa, Guid? sessionid, int? rol, int? empleado, string contraseñagerencial, string apellidopaterno, string apellidomaterno, string nombre, DateTime? fechaalta, string usuarioalta, int? status)
            {
                this.Clave = clave;
                this.Pwd = pwd;
                this.Empresa = empresa;
                this.SessionID = sessionid;
                this.Rol = rol;
                this.Empleado = empleado;
                this.ContraseñaGerencial = contraseñagerencial;
                this.ApellidoPaterno = apellidopaterno;
                this.ApellidoMaterno = apellidomaterno;
                this.Nombre = nombre;
                this.FechaAlta = fechaalta;
                this.UsuarioAlta = usuarioalta;
                this.Status = status;
            }

            private string _Clave;
            public string Clave
            {
                get { return _Clave; }
                set { _Clave = value; }
            }

            private string _Pwd;
            public string Pwd
            {
                get { return _Pwd; }
                set { _Pwd = value; }
            }

            private int? _Empresa;
            public int? Empresa
            {
                get { return _Empresa; }
                set { _Empresa = value; }
            }

            private Guid? _SessionID;
            public Guid? SessionID
            {
                get { return _SessionID; }
                set { _SessionID = value; }
            }

            private int? _Rol;
            public int? Rol
            {
                get { return _Rol; }
                set { _Rol = value; }
            }

            private int? _Empleado;
            public int? Empleado
            {
                get { return _Empleado; }
                set { _Empleado = value; }
            }

            private string _ContraseñaGerencial;
            public string ContraseñaGerencial
            {
                get { return _ContraseñaGerencial; }
                set { _ContraseñaGerencial = value; }
            }

            private string _ApellidoPaterno;
            public string ApellidoPaterno
            {
                get { return _ApellidoPaterno; }
                set { _ApellidoPaterno = value; }
            }

            private string _ApellidoMaterno;
            public string ApellidoMaterno
            {
                get { return _ApellidoMaterno; }
                set { _ApellidoMaterno = value; }
            }

            private string _Nombre;
            public string Nombre
            {
                get { return _Nombre; }
                set { _Nombre = value; }
            }

            private DateTime? _FechaAlta;
            public DateTime? FechaAlta
            {
                get { return _FechaAlta; }
                set { _FechaAlta = value; }
            }

            private string _UsuarioAlta;
            public string UsuarioAlta
            {
                get { return _UsuarioAlta; }
                set { _UsuarioAlta = value; }
            }

            private int? _Status;
            public int? Status
            {
                get { return _Status; }
                set { _Status = value; }
            }

            public int Create()
            {
                Hashtable m_params = new Hashtable();
                m_params.Add("Clave", this.Clave);
                if (!AppHelper.IsNullOrEmpty(this.Pwd)) m_params.Add("Pwd", this.Pwd);
                if (!AppHelper.IsNullOrEmpty(this.Empresa)) m_params.Add("Empresa", this.Empresa);
                if (!AppHelper.IsNullOrEmpty(this.SessionID)) m_params.Add("SessionID", this.SessionID);
                if (!AppHelper.IsNullOrEmpty(this.Rol)) m_params.Add("Rol", this.Rol);
                if (!AppHelper.IsNullOrEmpty(this.Empleado)) m_params.Add("Empleado", this.Empleado);
                if (!AppHelper.IsNullOrEmpty(this.ContraseñaGerencial)) m_params.Add("ContraseñaGerencial", this.ContraseñaGerencial);
                if (!AppHelper.IsNullOrEmpty(this.ApellidoPaterno)) m_params.Add("ApellidoPaterno", this.ApellidoPaterno);
                if (!AppHelper.IsNullOrEmpty(this.ApellidoMaterno)) m_params.Add("ApellidoMaterno", this.ApellidoMaterno);
                if (!AppHelper.IsNullOrEmpty(this.Nombre)) m_params.Add("Nombre", this.Nombre);
                if (!AppHelper.IsNullOrEmpty(this.FechaAlta)) m_params.Add("FechaAlta", this.FechaAlta);
                if (!AppHelper.IsNullOrEmpty(this.UsuarioAlta)) m_params.Add("UsuarioAlta", this.UsuarioAlta);
                if (!AppHelper.IsNullOrEmpty(this.Status)) m_params.Add("Status", this.Status);

                return DB.InsertRow("Usuarios", m_params);
            } // End Create

            public static List<Usuarios> Read()
            {
                List<Usuarios> list = new List<Usuarios>();
                DataTable dt = DB.Select("Usuarios");
                foreach (DataRow dr in dt.Rows)
                {
                    list.Add(new Usuarios(Convert.ToString(dr["Clave"]), Convert.ToString(dr["Pwd"]), DB.GetNullableInt32(dr["Empresa"]), DB.GetNullableGuid(dr["SessionID"]), DB.GetNullableInt32(dr["Rol"]), DB.GetNullableInt32(dr["Empleado"]), Convert.ToString(dr["ContraseñaGerencial"]), Convert.ToString(dr["ApellidoPaterno"]), Convert.ToString(dr["ApellidoMaterno"]), Convert.ToString(dr["Nombre"]), DB.GetNullableDateTime(dr["FechaAlta"]), Convert.ToString(dr["UsuarioAlta"]), DB.GetNullableInt32(dr["Status"])));
                }

                return list;
            } // End Read

            public static Usuarios Read(string clave)
            {
                Hashtable w_params = new Hashtable();
                w_params.Add("Clave", clave);
                DataTable dt = DB.Select("Usuarios", w_params);
                if (dt.Rows.Count == 0)
                {
                    throw new Exception("No existe Usuarios con los criterios de búsqueda especificados.");
                }
                DataRow dr = dt.Rows[0];
                return new Usuarios(Convert.ToString(dr["Clave"]), Convert.ToString(dr["Pwd"]), DB.GetNullableInt32(dr["Empresa"]), DB.GetNullableGuid(dr["SessionID"]), DB.GetNullableInt32(dr["Rol"]), DB.GetNullableInt32(dr["Empleado"]), Convert.ToString(dr["ContraseñaGerencial"]), Convert.ToString(dr["ApellidoPaterno"]), Convert.ToString(dr["ApellidoMaterno"]), Convert.ToString(dr["Nombre"]), DB.GetNullableDateTime(dr["FechaAlta"]), Convert.ToString(dr["UsuarioAlta"]), DB.GetNullableInt32(dr["Status"]));
            } // End Read

            public int Update()
            {
                Hashtable m_params = new Hashtable();
                Hashtable w_params = new Hashtable();
                w_params.Add("Clave", this.Clave);
                if (!AppHelper.IsNullOrEmpty(this.Pwd)) m_params.Add("Pwd", this.Pwd);
                if (!AppHelper.IsNullOrEmpty(this.Empresa)) m_params.Add("Empresa", this.Empresa);
                if (!AppHelper.IsNullOrEmpty(this.SessionID)) m_params.Add("SessionID", this.SessionID);
                if (!AppHelper.IsNullOrEmpty(this.Rol)) m_params.Add("Rol", this.Rol);
                if (!AppHelper.IsNullOrEmpty(this.Empleado)) m_params.Add("Empleado", this.Empleado);
                if (!AppHelper.IsNullOrEmpty(this.ContraseñaGerencial)) m_params.Add("ContraseñaGerencial", this.ContraseñaGerencial);
                if (!AppHelper.IsNullOrEmpty(this.ApellidoPaterno)) m_params.Add("ApellidoPaterno", this.ApellidoPaterno);
                if (!AppHelper.IsNullOrEmpty(this.ApellidoMaterno)) m_params.Add("ApellidoMaterno", this.ApellidoMaterno);
                if (!AppHelper.IsNullOrEmpty(this.Nombre)) m_params.Add("Nombre", this.Nombre);
                if (!AppHelper.IsNullOrEmpty(this.FechaAlta)) m_params.Add("FechaAlta", this.FechaAlta);
                if (!AppHelper.IsNullOrEmpty(this.UsuarioAlta)) m_params.Add("UsuarioAlta", this.UsuarioAlta);
                if (!AppHelper.IsNullOrEmpty(this.Status)) m_params.Add("Status", this.Status);

                return DB.UpdateRow("Usuarios", m_params, w_params);
            } // End Update

            public int Delete()
            {
                Hashtable w_params = new Hashtable();
                w_params.Add("Clave", this.Clave);

                return DB.DeleteRow("Usuarios", w_params);
            } // End Delete

        } //End Class Usuarios

        public class VentaBoletos
        {

            public VentaBoletos()
            {
            }

            public VentaBoletos(string boleto, DateTime? fecha, string usuario)
            {
                this.Boleto = boleto;
                this.Fecha = fecha;
                this.Usuario = usuario;
            }

            private string _Boleto;
            public string Boleto
            {
                get { return _Boleto; }
                set { _Boleto = value; }
            }

            private DateTime? _Fecha;
            public DateTime? Fecha
            {
                get { return _Fecha; }
                set { _Fecha = value; }
            }

            private string _Usuario;
            public string Usuario
            {
                get { return _Usuario; }
                set { _Usuario = value; }
            }

            public int Create()
            {
                Hashtable m_params = new Hashtable();
                if (!AppHelper.IsNullOrEmpty(this.Boleto)) m_params.Add("Boleto", this.Boleto);
                if (!AppHelper.IsNullOrEmpty(this.Fecha)) m_params.Add("Fecha", this.Fecha);
                if (!AppHelper.IsNullOrEmpty(this.Usuario)) m_params.Add("Usuario", this.Usuario);

                return DB.InsertRow("VentaBoletos", m_params);
            } // End Create

            public static List<VentaBoletos> Read()
            {
                List<VentaBoletos> list = new List<VentaBoletos>();
                DataTable dt = DB.Select("VentaBoletos");
                foreach (DataRow dr in dt.Rows)
                {
                    list.Add(new VentaBoletos(Convert.ToString(dr["Boleto"]), DB.GetNullableDateTime(dr["Fecha"]), Convert.ToString(dr["Usuario"])));
                }

                return list;
            } // End Read

            public int Update()
            {
                Hashtable m_params = new Hashtable();
                Hashtable w_params = new Hashtable();
                if (!AppHelper.IsNullOrEmpty(this.Boleto)) m_params.Add("Boleto", this.Boleto);
                if (!AppHelper.IsNullOrEmpty(this.Fecha)) m_params.Add("Fecha", this.Fecha);
                if (!AppHelper.IsNullOrEmpty(this.Usuario)) m_params.Add("Usuario", this.Usuario);

                return DB.UpdateRow("VentaBoletos", m_params, w_params);
            } // End Update

            public int Delete()
            {
                Hashtable w_params = new Hashtable();

                return DB.DeleteRow("VentaBoletos", w_params);
            } // End Delete

        } //End Class VentaBoletos

        public class Zonas
        {

            public Zonas()
            {
            }

            public Zonas(int folio, int tipo, string descripcion, int? comisionista)
            {
                this.Folio = folio;
                this.Tipo = tipo;
                this.Descripcion = descripcion;
                this.Comisionista = comisionista;
            }

            private int _Folio;
            public int Folio
            {
                get { return _Folio; }
                set { _Folio = value; }
            }

            private int _Tipo;
            public int Tipo
            {
                get { return _Tipo; }
                set { _Tipo = value; }
            }

            private string _Descripcion;
            public string Descripcion
            {
                get { return _Descripcion; }
                set { _Descripcion = value; }
            }

            private int? _Comisionista;
            public int? Comisionista
            {
                get { return _Comisionista; }
                set { _Comisionista = value; }
            }

            public int Create()
            {
                Hashtable m_params = new Hashtable();
                m_params.Add("Tipo", this.Tipo);
                m_params.Add("Descripcion", this.Descripcion);
                if (!AppHelper.IsNullOrEmpty(this.Comisionista)) m_params.Add("Comisionista", this.Comisionista);

                return DB.InsertRow("Zonas", m_params);
            } // End Create

            public static List<Zonas> Read()
            {
                List<Zonas> list = new List<Zonas>();
                DataTable dt = DB.Select("Zonas");
                foreach (DataRow dr in dt.Rows)
                {
                    list.Add(new Zonas(Convert.ToInt32(dr["Folio"]), Convert.ToInt32(dr["Tipo"]), Convert.ToString(dr["Descripcion"]), DB.GetNullableInt32(dr["Comisionista"])));
                }

                return list;
            } // End Read

            public static Zonas Read(int folio)
            {
                Hashtable w_params = new Hashtable();
                w_params.Add("Folio", folio);
                DataTable dt = DB.Select("Zonas", w_params);
                if (dt.Rows.Count == 0)
                {
                    return null;
                }
                DataRow dr = dt.Rows[0];
                return new Zonas(Convert.ToInt32(dr["Folio"]), Convert.ToInt32(dr["Tipo"]), Convert.ToString(dr["Descripcion"]), DB.GetNullableInt32(dr["Comisionista"]));
            } // End Read

            public int Update()
            {
                Hashtable m_params = new Hashtable();
                Hashtable w_params = new Hashtable();
                w_params.Add("Folio", this.Folio);
                m_params.Add("Tipo", this.Tipo);
                m_params.Add("Descripcion", this.Descripcion);
                if (!AppHelper.IsNullOrEmpty(this.Comisionista)) m_params.Add("Comisionista", this.Comisionista);

                return DB.UpdateRow("Zonas", m_params, w_params);
            } // End Update

            public int Delete()
            {
                Hashtable w_params = new Hashtable();
                w_params.Add("Folio", this.Folio);

                return DB.DeleteRow("Zonas", w_params);
            } // End Delete

        } //End Class Zonas

    } // End namespace

} // End Namespace