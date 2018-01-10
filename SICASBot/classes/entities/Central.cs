using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Microsoft.SqlServer.Management.Common;
using Microsoft.SqlServer.Management.Smo;

namespace SICASBot.Central
{
    public class DB
    {
        //public static string connStr = "Data Source=(local)\\SQLEXPRESS;Initial Catalog=SICASCentral;Persist Security Info=True;User ID=SICASusr;Password=nhtccuag";
        //public static string connStr = "Data Source=(local)\\SQLEXPRESS;Initial Catalog=SICASSync;Persist Security Info=True;User ID=SICASusr;Password=nhtccuag";
        //public static string connStr = "Data Source=(local)\\SQLEXPRESS;Initial Catalog=SICASTest;Persist Security Info=True;User ID=SICASusr;Password=nhtccuag";
        //public static string connStr = "Data Source=sicas.casco.com.mx;Initial Catalog=SICASSync;Persist Security Info=True;User ID=SICASusr;Password=nhtccuag";
        //public static string connStr = "Data Source=192.168.0.251,1433;Network Library=DBMSSOCN;Initial Catalog=SICASSync;Persist Security Info=True;User ID=SICASusr;Password=oiuddvbh;Connection Timeout=30;";
	    private static string ConProd { get { return "Data Source=sicas.casco.com.mx,54903;Network Library=DBMSSOCN;Initial Catalog=SICASSync;Persist Security Info=True;User ID=SICASusr;Password=oiuddvbh;Connection Timeout=30;"; } }
	    private static string ConTest { get { return "Data Source=sicas.casco.com.mx,54903;Network Library=DBMSSOCN;Initial Catalog=SICASTest;Persist Security Info=True;User ID=SICASusr;Password=oiuddvbh;Connection Timeout=60;"; } }
	    public static string connStr
	    {
		    get
		    {
			    bool bProd = false;
			    if (System.Configuration.ConfigurationManager.AppSettings["AmbienteProd"] != null &&
				    System.Configuration.ConfigurationManager.AppSettings["AmbienteProd"].Length > 0)
				    bProd = Convert.ToBoolean(System.Configuration.ConfigurationManager.AppSettings["AmbienteProd"]);
			    return bProd ? ConProd : ConTest;
		    }
	    }

        private static SqlConnection conn;

        public static int ExecuteBatch(string batchsql)
        {
            SqlConnection conn = new SqlConnection(Central.DB.connStr);
            Server server = new Server(new ServerConnection(conn));
            return server.ConnectionContext.ExecuteNonQuery(batchsql);
        }

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

        public static bool IsNullOrEmpty(object expression)
        {
            if (expression == null || Convert.IsDBNull(expression))
            {
                return true;
            }
            else
            {
                if (expression.GetType() == typeof(string))
                {
                    if ((string)expression == "" || (string)expression == string.Empty)
                    {
                        return true;
                    }
                }
                return false;
            }
        }

        public static KeyValuePair<string, object> Param(string key, object value)
        {
            return new KeyValuePair<string, object>(key, value);
        }
        
        public static DataTable Read(string tableName, string filter, string sort, params KeyValuePair<string, object>[] args)
        {
            return QueryCommand(SelectStatement("Refacciones", filter, sort), GetParams(args));
        }

        public static DataTable Read(string tableName, int top, string filter, string sort, params KeyValuePair<string, object>[] args)
        {
            return QueryCommand(SelectStatement("Refacciones", top, filter, sort), GetParams(args));
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

        public static object ReadScalar(string sqlQry, params KeyValuePair<string, object>[] args)
        {
            Hashtable data = new Hashtable();
            foreach (KeyValuePair<string, object> kp in args)
            {
                data.Add(kp.Key, kp.Value);
            }

            return QueryScalar(sqlQry, data);
        }

        public static object ReadScalar(string tableName, string fieldName, params KeyValuePair<string, object>[] args)
        {
            Hashtable data = new Hashtable();
            foreach (KeyValuePair<string, object> kp in args)
            {
                data.Add(kp.Key, kp.Value);
            }

            return QueryScalar(SelectScalarStatement(tableName, fieldName, data), data);
        }

        public static int Ident_Current(string tableName)
        {          
            string sqlstr = String.Format("SELECT IDENT_CURRENT('{0}');", tableName);
            return Convert.ToInt32(QueryScalar(sqlstr));
        }

        public static DateTime GetDate()
        {
            string sqlstr = "SELECT GETDATE()";
            return (DateTime)QueryScalar(sqlstr);
        }

        public static T QueryScalar<T>(string sqlQry, params KeyValuePair<string, object>[] @params)
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
                return (T)result;
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

        #region ActiveRecord

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
    } //    DB Class

    namespace Entities
    {
        public class AjustesInventario
        {

            #region Constructors

            public AjustesInventario()
            {
            }

            public AjustesInventario(
                int ajusteinventario_id,
                int tipomovimientoinventario_id,
                int refaccion_id,
                string usuario_id,
                int cantidad,
                decimal costounitario,
                decimal total,
                DateTime fecha,
                string comentarios,
                int empresa_id,
                int estacion_id)
            {
                this.AjusteInventario_ID = ajusteinventario_id;
                this.TipoMovimientoInventario_ID = tipomovimientoinventario_id;
                this.Refaccion_ID = refaccion_id;
                this.Usuario_ID = usuario_id;
                this.Cantidad = cantidad;
                this.CostoUnitario = costounitario;
                this.Total = total;
                this.Fecha = fecha;
                this.Comentarios = comentarios;
                this.Empresa_ID = empresa_id;
                this.Estacion_ID = estacion_id;
            }

            #endregion

            #region Properties

            private int _AjusteInventario_ID;
            public int AjusteInventario_ID
            {
                get { return _AjusteInventario_ID; }
                set { _AjusteInventario_ID = value; }
            }

            private int _TipoMovimientoInventario_ID;
            public int TipoMovimientoInventario_ID
            {
                get { return _TipoMovimientoInventario_ID; }
                set { _TipoMovimientoInventario_ID = value; }
            }

            private int _Refaccion_ID;
            public int Refaccion_ID
            {
                get { return _Refaccion_ID; }
                set { _Refaccion_ID = value; }
            }

            private string _Usuario_ID;
            public string Usuario_ID
            {
                get { return _Usuario_ID; }
                set { _Usuario_ID = value; }
            }

            private int _Cantidad;
            public int Cantidad
            {
                get { return _Cantidad; }
                set { _Cantidad = value; }
            }

            private decimal _CostoUnitario;
            public decimal CostoUnitario
            {
                get { return _CostoUnitario; }
                set { _CostoUnitario = value; }
            }

            private decimal _Total;
            public decimal Total
            {
                get { return _Total; }
                set { _Total = value; }
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

            private int _Empresa_ID;
            public int Empresa_ID
            {
                get { return _Empresa_ID; }
                set { _Empresa_ID = value; }
            }

            private int _Estacion_ID;
            public int Estacion_ID
            {
                get { return _Estacion_ID; }
                set { _Estacion_ID = value; }
            }

            #endregion

            #region Methods
            public void Validate()
            {
                if (this.AjusteInventario_ID == null) throw new Exception("AjusteInventario_ID no puede ser nulo.");

                if (this.TipoMovimientoInventario_ID == null) throw new Exception("TipoMovimientoInventario_ID no puede ser nulo.");

                if (this.Refaccion_ID == null) throw new Exception("Refaccion_ID no puede ser nulo.");

                if (this.Usuario_ID == null) throw new Exception("Usuario_ID no puede ser nulo.");

                if (this.Usuario_ID.Length > 30)
                {
                    throw new Exception("Usuario_ID debe tener máximo 30 carateres.");
                }

                if (this.Cantidad == null) throw new Exception("Cantidad no puede ser nulo.");

                if (this.CostoUnitario == null) throw new Exception("CostoUnitario no puede ser nulo.");

                if (this.Total == null) throw new Exception("Total no puede ser nulo.");

                if (this.Fecha == null) throw new Exception("Fecha no puede ser nulo.");

                if (this.Comentarios == null) throw new Exception("Comentarios no puede ser nulo.");

                if (this.Comentarios.Length > 255)
                {
                    throw new Exception("Comentarios debe tener máximo 255 carateres.");
                }

                if (this.Empresa_ID == null) throw new Exception("Empresa_ID no puede ser nulo.");

                if (this.Estacion_ID == null) throw new Exception("Estacion_ID no puede ser nulo.");


            } // End Validate

            public int Create()
            {
                Hashtable m_params = new Hashtable();
                m_params.Add("TipoMovimientoInventario_ID", this.TipoMovimientoInventario_ID);
                m_params.Add("Refaccion_ID", this.Refaccion_ID);
                m_params.Add("Usuario_ID", this.Usuario_ID);
                m_params.Add("Cantidad", this.Cantidad);
                m_params.Add("CostoUnitario", this.CostoUnitario);
                m_params.Add("Total", this.Total);
                m_params.Add("Fecha", this.Fecha);
                m_params.Add("Comentarios", this.Comentarios);
                m_params.Add("Empresa_ID", this.Empresa_ID);
                m_params.Add("Estacion_ID", this.Estacion_ID);

                return DB.InsertRow("AjustesInventario", m_params);
            } // End Create

            public int Create(bool IsIdentityInsert)
            {
                if (!IsIdentityInsert) return Create();
                Hashtable m_params = new Hashtable();
                m_params.Add("AjusteInventario_ID", this.AjusteInventario_ID);
                m_params.Add("TipoMovimientoInventario_ID", this.TipoMovimientoInventario_ID);
                m_params.Add("Refaccion_ID", this.Refaccion_ID);
                m_params.Add("Usuario_ID", this.Usuario_ID);
                m_params.Add("Cantidad", this.Cantidad);
                m_params.Add("CostoUnitario", this.CostoUnitario);
                m_params.Add("Total", this.Total);
                m_params.Add("Fecha", this.Fecha);
                m_params.Add("Comentarios", this.Comentarios);
                m_params.Add("Empresa_ID", this.Empresa_ID);
                m_params.Add("Estacion_ID", this.Estacion_ID);

                return DB.IdentityInsertRow("AjustesInventario", m_params);
            } // End Create

            public static List<AjustesInventario> Read()
            {
                List<AjustesInventario> list = new List<AjustesInventario>();
                DataTable dt = DB.Select("AjustesInventario");
                foreach (DataRow dr in dt.Rows)
                {
                    list.Add(
                        new AjustesInventario(
                            Convert.ToInt32(dr["AjusteInventario_ID"]),
                            Convert.ToInt32(dr["TipoMovimientoInventario_ID"]),
                            Convert.ToInt32(dr["Refaccion_ID"]),
                            Convert.ToString(dr["Usuario_ID"]),
                            Convert.ToInt32(dr["Cantidad"]),
                            Convert.ToDecimal(dr["CostoUnitario"]),
                            Convert.ToDecimal(dr["Total"]),
                            Convert.ToDateTime(dr["Fecha"]),
                            Convert.ToString(dr["Comentarios"]),
                            Convert.ToInt32(dr["Empresa_ID"]),
                            Convert.ToInt32(dr["Estacion_ID"])
                        )
                    );
                }

                return list;
            } // End Read

            public static AjustesInventario Read(int ajusteinventario_id)
            {
                Hashtable w_params = new Hashtable();
                w_params.Add("AjusteInventario_ID", ajusteinventario_id);
                DataTable dt = DB.Select("AjustesInventario", w_params);
                if (dt.Rows.Count == 0)
                {
                    throw new Exception("No existe AjustesInventario con los criterios de búsqueda especificados.");
                }
                DataRow dr = dt.Rows[0];
                return new AjustesInventario(
                    Convert.ToInt32(dr["AjusteInventario_ID"]),
                            Convert.ToInt32(dr["TipoMovimientoInventario_ID"]),
                            Convert.ToInt32(dr["Refaccion_ID"]),
                            Convert.ToString(dr["Usuario_ID"]),
                            Convert.ToInt32(dr["Cantidad"]),
                            Convert.ToDecimal(dr["CostoUnitario"]),
                            Convert.ToDecimal(dr["Total"]),
                            Convert.ToDateTime(dr["Fecha"]),
                            Convert.ToString(dr["Comentarios"]),
                            Convert.ToInt32(dr["Empresa_ID"]),
                            Convert.ToInt32(dr["Estacion_ID"])
                        );
            } // End Read

            public static AjustesInventario Read(params KeyValuePair<string, object>[] args)
            {
                DataTable dt = DB.Read("AjustesInventario", args);
                if (dt.Rows.Count == 0)
                {
                    return null;
                }
                DataRow dr = dt.Rows[0];
                return new AjustesInventario(
                    Convert.ToInt32(dr["AjusteInventario_ID"]),
                            Convert.ToInt32(dr["TipoMovimientoInventario_ID"]),
                            Convert.ToInt32(dr["Refaccion_ID"]),
                            Convert.ToString(dr["Usuario_ID"]),
                            Convert.ToInt32(dr["Cantidad"]),
                            Convert.ToDecimal(dr["CostoUnitario"]),
                            Convert.ToDecimal(dr["Total"]),
                            Convert.ToDateTime(dr["Fecha"]),
                            Convert.ToString(dr["Comentarios"]),
                            Convert.ToInt32(dr["Empresa_ID"]),
                            Convert.ToInt32(dr["Estacion_ID"])
                        );
            } // End Read

            public static bool Read(
                out AjustesInventario ajustesinventario,
                int top,
                string filter,
                string sort,
                params KeyValuePair<string, object>[] args)
            {
                DataTable dt = DB.Read("AjustesInventario", top, filter, sort, args);
                if (dt.Rows.Count == 0)
                {
                    ajustesinventario = null;
                    return false;
                }
                DataRow dr = dt.Rows[0];
                ajustesinventario = new AjustesInventario(
                    Convert.ToInt32(dr["AjusteInventario_ID"]),
                            Convert.ToInt32(dr["TipoMovimientoInventario_ID"]),
                            Convert.ToInt32(dr["Refaccion_ID"]),
                            Convert.ToString(dr["Usuario_ID"]),
                            Convert.ToInt32(dr["Cantidad"]),
                            Convert.ToDecimal(dr["CostoUnitario"]),
                            Convert.ToDecimal(dr["Total"]),
                            Convert.ToDateTime(dr["Fecha"]),
                            Convert.ToString(dr["Comentarios"]),
                            Convert.ToInt32(dr["Empresa_ID"]),
                            Convert.ToInt32(dr["Estacion_ID"])
                        );
                return true;
            } // End Read

            public static DataTable ReadDataTable()
            {
                return DB.Select("AjustesInventario");
            } // End Read

            public static DataTable ReadDataTable(int ajusteinventario_id)
            {
                Hashtable w_params = new Hashtable();
                w_params.Add("AjusteInventario_ID", ajusteinventario_id);
                return DB.Select("AjustesInventario", w_params);
            } // End Read

            public int Update()
            {
                Hashtable m_params = new Hashtable();
                Hashtable w_params = new Hashtable();
                w_params.Add("AjusteInventario_ID", this.AjusteInventario_ID);
                m_params.Add("TipoMovimientoInventario_ID", this.TipoMovimientoInventario_ID);
                m_params.Add("Refaccion_ID", this.Refaccion_ID);
                m_params.Add("Usuario_ID", this.Usuario_ID);
                m_params.Add("Cantidad", this.Cantidad);
                m_params.Add("CostoUnitario", this.CostoUnitario);
                m_params.Add("Total", this.Total);
                m_params.Add("Fecha", this.Fecha);
                m_params.Add("Comentarios", this.Comentarios);
                m_params.Add("Empresa_ID", this.Empresa_ID);
                m_params.Add("Estacion_ID", this.Estacion_ID);

                return DB.UpdateRow("AjustesInventario", m_params, w_params);
            } // End Update

            public int Delete()
            {
                Hashtable w_params = new Hashtable();
                w_params.Add("AjusteInventario_ID", this.AjusteInventario_ID);

                return DB.DeleteRow("AjustesInventario", w_params);
            } // End Delete


            #endregion
        } //End Class AjustesInventario

        public class Arrendamientos
        {
            public Arrendamientos()
            {

            }

            public Arrendamientos(int arrendamiento_id, string descripcion, int referencia, string catalogoreferencia, int arrendador_id, int arrendatario_id, decimal montoafinanciar, decimal valorfactura, int plazos, decimal mensualidad, decimal residual, decimal tasa, decimal amortizacionresidual, int estatusfinanciero_id, decimal montopagado, decimal saldo, int plazosrestantes, DateTime fechainicial, DateTime fechafinal, DateTime ultimafecha, DateTime proximafecha, bool activo, string comentarios)
            {
                this.Arrendamiento_ID = arrendamiento_id;
                this.Descripcion = descripcion;
                this.Referencia = referencia;
                this.CatalogoReferencia = catalogoreferencia;
                this.Arrendador_ID = arrendador_id;
                this.Arrendatario_ID = arrendatario_id;
                this.MontoAFinanciar = montoafinanciar;
                this.ValorFactura = valorfactura;
                this.Plazos = plazos;
                this.Mensualidad = mensualidad;
                this.Residual = residual;
                this.Tasa = tasa;
                this.AmortizacionResidual = amortizacionresidual;
                this.EstatusFinanciero_ID = estatusfinanciero_id;
                this.MontoPagado = montopagado;
                this.Saldo = saldo;
                this.PlazosRestantes = plazosrestantes;
                this.FechaInicial = fechainicial;
                this.FechaFinal = fechafinal;
                this.UltimaFecha = ultimafecha;
                this.ProximaFecha = proximafecha;
                this.Activo = activo;
                this.Comentarios = comentarios;
            }

            private int _Arrendamiento_ID;
            public int Arrendamiento_ID
            {
                get { return _Arrendamiento_ID; }
                set { _Arrendamiento_ID = value; }
            }

            private string _Descripcion;
            public string Descripcion
            {
                get { return _Descripcion; }
                set { _Descripcion = value; }
            }

            private int _Referencia;
            public int Referencia
            {
                get { return _Referencia; }
                set { _Referencia = value; }
            }

            private string _CatalogoReferencia;
            public string CatalogoReferencia
            {
                get { return _CatalogoReferencia; }
                set { _CatalogoReferencia = value; }
            }

            private int _Arrendador_ID;
            public int Arrendador_ID
            {
                get { return _Arrendador_ID; }
                set { _Arrendador_ID = value; }
            }

            private int _Arrendatario_ID;
            public int Arrendatario_ID
            {
                get { return _Arrendatario_ID; }
                set { _Arrendatario_ID = value; }
            }

            private decimal _MontoAFinanciar;
            public decimal MontoAFinanciar
            {
                get { return _MontoAFinanciar; }
                set { _MontoAFinanciar = value; }
            }

            private decimal _ValorFactura;
            public decimal ValorFactura
            {
                get { return _ValorFactura; }
                set { _ValorFactura = value; }
            }

            private int _Plazos;
            public int Plazos
            {
                get { return _Plazos; }
                set { _Plazos = value; }
            }

            private decimal _Mensualidad;
            public decimal Mensualidad
            {
                get { return _Mensualidad; }
                set { _Mensualidad = value; }
            }

            private decimal _Residual;
            public decimal Residual
            {
                get { return _Residual; }
                set { _Residual = value; }
            }

            private decimal _Tasa;
            public decimal Tasa
            {
                get { return _Tasa; }
                set { _Tasa = value; }
            }

            private decimal _AmortizacionResidual;
            public decimal AmortizacionResidual
            {
                get { return _AmortizacionResidual; }
                set { _AmortizacionResidual = value; }
            }

            private int _EstatusFinanciero_ID;
            public int EstatusFinanciero_ID
            {
                get { return _EstatusFinanciero_ID; }
                set { _EstatusFinanciero_ID = value; }
            }

            private decimal _MontoPagado;
            public decimal MontoPagado
            {
                get { return _MontoPagado; }
                set { _MontoPagado = value; }
            }

            private decimal _Saldo;
            public decimal Saldo
            {
                get { return _Saldo; }
                set { _Saldo = value; }
            }

            private int _PlazosRestantes;
            public int PlazosRestantes
            {
                get { return _PlazosRestantes; }
                set { _PlazosRestantes = value; }
            }

            private DateTime _FechaInicial;
            public DateTime FechaInicial
            {
                get { return _FechaInicial; }
                set { _FechaInicial = value; }
            }

            private DateTime _FechaFinal;
            public DateTime FechaFinal
            {
                get { return _FechaFinal; }
                set { _FechaFinal = value; }
            }

            private DateTime _UltimaFecha;
            public DateTime UltimaFecha
            {
                get { return _UltimaFecha; }
                set { _UltimaFecha = value; }
            }

            private DateTime _ProximaFecha;
            public DateTime ProximaFecha
            {
                get { return _ProximaFecha; }
                set { _ProximaFecha = value; }
            }

            private bool _Activo;
            public bool Activo
            {
                get { return _Activo; }
                set { _Activo = value; }
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
                m_params.Add("Descripcion", this.Descripcion);
                m_params.Add("Referencia", this.Referencia);
                m_params.Add("CatalogoReferencia", this.CatalogoReferencia);
                m_params.Add("Arrendador_ID", this.Arrendador_ID);
                m_params.Add("Arrendatario_ID", this.Arrendatario_ID);
                m_params.Add("MontoAFinanciar", this.MontoAFinanciar);
                m_params.Add("ValorFactura", this.ValorFactura);
                m_params.Add("Plazos", this.Plazos);
                m_params.Add("Mensualidad", this.Mensualidad);
                m_params.Add("Residual", this.Residual);
                m_params.Add("Tasa", this.Tasa);
                m_params.Add("AmortizacionResidual", this.AmortizacionResidual);
                m_params.Add("EstatusFinanciero_ID", this.EstatusFinanciero_ID);
                m_params.Add("MontoPagado", this.MontoPagado);
                m_params.Add("Saldo", this.Saldo);
                m_params.Add("PlazosRestantes", this.PlazosRestantes);
                m_params.Add("FechaInicial", this.FechaInicial);
                m_params.Add("FechaFinal", this.FechaFinal);
                m_params.Add("UltimaFecha", this.UltimaFecha);
                m_params.Add("ProximaFecha", this.ProximaFecha);
                m_params.Add("Activo", this.Activo);
                m_params.Add("Comentarios", this.Comentarios);

                return DB.InsertRow("Arrendamientos", m_params);
            } // End Create

            public static List<Arrendamientos> Read()
            {
                List<Arrendamientos> list = new List<Arrendamientos>();
                DataTable dt = DB.Select("Arrendamientos");
                foreach (DataRow dr in dt.Rows)
                {
                    list.Add(new Arrendamientos(Convert.ToInt32(dr["Arrendamiento_ID"]), Convert.ToString(dr["Descripcion"]), Convert.ToInt32(dr["Referencia"]), Convert.ToString(dr["CatalogoReferencia"]), Convert.ToInt32(dr["Arrendador_ID"]), Convert.ToInt32(dr["Arrendatario_ID"]), Convert.ToDecimal(dr["MontoAFinanciar"]), Convert.ToDecimal(dr["ValorFactura"]), Convert.ToInt32(dr["Plazos"]), Convert.ToDecimal(dr["Mensualidad"]), Convert.ToDecimal(dr["Residual"]), Convert.ToDecimal(dr["Tasa"]), Convert.ToDecimal(dr["AmortizacionResidual"]), Convert.ToInt32(dr["EstatusFinanciero_ID"]), Convert.ToDecimal(dr["MontoPagado"]), Convert.ToDecimal(dr["Saldo"]), Convert.ToInt32(dr["PlazosRestantes"]), Convert.ToDateTime(dr["FechaInicial"]), Convert.ToDateTime(dr["FechaFinal"]), Convert.ToDateTime(dr["UltimaFecha"]), Convert.ToDateTime(dr["ProximaFecha"]), Convert.ToBoolean(dr["Activo"]), Convert.ToString(dr["Comentarios"])));
                }

                return list;
            } // End Read

            public static List<Arrendamientos> Read(int arrendamiento_id)
            {
                List<Arrendamientos> list = new List<Arrendamientos>();
                Hashtable w_params = new Hashtable();
                w_params.Add("Arrendamiento_ID", arrendamiento_id);
                DataTable dt = DB.Select("Arrendamientos", w_params);
                foreach (DataRow dr in dt.Rows)
                {
                    list.Add(new Arrendamientos(Convert.ToInt32(dr["Arrendamiento_ID"]), Convert.ToString(dr["Descripcion"]), Convert.ToInt32(dr["Referencia"]), Convert.ToString(dr["CatalogoReferencia"]), Convert.ToInt32(dr["Arrendador_ID"]), Convert.ToInt32(dr["Arrendatario_ID"]), Convert.ToDecimal(dr["MontoAFinanciar"]), Convert.ToDecimal(dr["ValorFactura"]), Convert.ToInt32(dr["Plazos"]), Convert.ToDecimal(dr["Mensualidad"]), Convert.ToDecimal(dr["Residual"]), Convert.ToDecimal(dr["Tasa"]), Convert.ToDecimal(dr["AmortizacionResidual"]), Convert.ToInt32(dr["EstatusFinanciero_ID"]), Convert.ToDecimal(dr["MontoPagado"]), Convert.ToDecimal(dr["Saldo"]), Convert.ToInt32(dr["PlazosRestantes"]), Convert.ToDateTime(dr["FechaInicial"]), Convert.ToDateTime(dr["FechaFinal"]), Convert.ToDateTime(dr["UltimaFecha"]), Convert.ToDateTime(dr["ProximaFecha"]), Convert.ToBoolean(dr["Activo"]), Convert.ToString(dr["Comentarios"])));
                }

                return list;
            } // End Read

            public int Update()
            {
                Hashtable m_params = new Hashtable();
                Hashtable w_params = new Hashtable();
                w_params.Add("Arrendamiento_ID", this.Arrendamiento_ID);
                m_params.Add("Descripcion", this.Descripcion);
                m_params.Add("Referencia", this.Referencia);
                m_params.Add("CatalogoReferencia", this.CatalogoReferencia);
                m_params.Add("Arrendador_ID", this.Arrendador_ID);
                m_params.Add("Arrendatario_ID", this.Arrendatario_ID);
                m_params.Add("MontoAFinanciar", this.MontoAFinanciar);
                m_params.Add("ValorFactura", this.ValorFactura);
                m_params.Add("Plazos", this.Plazos);
                m_params.Add("Mensualidad", this.Mensualidad);
                m_params.Add("Residual", this.Residual);
                m_params.Add("Tasa", this.Tasa);
                m_params.Add("AmortizacionResidual", this.AmortizacionResidual);
                m_params.Add("EstatusFinanciero_ID", this.EstatusFinanciero_ID);
                m_params.Add("MontoPagado", this.MontoPagado);
                m_params.Add("Saldo", this.Saldo);
                m_params.Add("PlazosRestantes", this.PlazosRestantes);
                m_params.Add("FechaInicial", this.FechaInicial);
                m_params.Add("FechaFinal", this.FechaFinal);
                m_params.Add("UltimaFecha", this.UltimaFecha);
                m_params.Add("ProximaFecha", this.ProximaFecha);
                m_params.Add("Activo", this.Activo);
                m_params.Add("Comentarios", this.Comentarios);

                return DB.UpdateRow("Arrendamientos", m_params, w_params);
            } // End Update

            public int Delete()
            {
                Hashtable w_params = new Hashtable();
                w_params.Add("Arrendamiento_ID", this.Arrendamiento_ID);

                return DB.DeleteRow("Arrendamientos", w_params);
            }

        } //End Class Arrendamientos

        public class AyudasOpciones
        {

            public AyudasOpciones()
            {
            }

            public AyudasOpciones(int ayudaopcion_id, string opcion, string url)
            {
                this.AyudaOpcion_ID = ayudaopcion_id;
                this.Opcion = opcion;
                this.Url = url;
            }

            private int _AyudaOpcion_ID;
            public int AyudaOpcion_ID
            {
                get { return _AyudaOpcion_ID; }
                set { _AyudaOpcion_ID = value; }
            }

            private string _Opcion;
            public string Opcion
            {
                get { return _Opcion; }
                set { _Opcion = value; }
            }

            private string _Url;
            public string Url
            {
                get { return _Url; }
                set { _Url = value; }
            }

            public int Create()
            {
                Hashtable m_params = new Hashtable();
                m_params.Add("Opcion", this.Opcion);
                m_params.Add("Url", this.Url);

                return DB.InsertRow("AyudasOpciones", m_params);
            } // End Create

            public static List<AyudasOpciones> Read()
            {
                List<AyudasOpciones> list = new List<AyudasOpciones>();
                DataTable dt = DB.Select("AyudasOpciones");
                foreach (DataRow dr in dt.Rows)
                {
                    list.Add(new AyudasOpciones(Convert.ToInt32(dr["AyudaOpcion_ID"]), Convert.ToString(dr["Opcion"]), Convert.ToString(dr["Url"])));
                }

                return list;
            } // End Read

            public static List<AyudasOpciones> Read(int ayudaopcion_id)
            {
                List<AyudasOpciones> list = new List<AyudasOpciones>();
                Hashtable w_params = new Hashtable();
                w_params.Add("AyudaOpcion_ID", ayudaopcion_id);
                DataTable dt = DB.Select("AyudasOpciones", w_params);
                foreach (DataRow dr in dt.Rows)
                {
                    list.Add(new AyudasOpciones(Convert.ToInt32(dr["AyudaOpcion_ID"]), Convert.ToString(dr["Opcion"]), Convert.ToString(dr["Url"])));
                }

                return list;
            } // End Read

            public int Update()
            {
                Hashtable m_params = new Hashtable();
                Hashtable w_params = new Hashtable();
                w_params.Add("AyudaOpcion_ID", this.AyudaOpcion_ID);
                m_params.Add("Opcion", this.Opcion);
                m_params.Add("Url", this.Url);

                return DB.UpdateRow("AyudasOpciones", m_params, w_params);
            } // End Update

            public int Delete()
            {
                Hashtable w_params = new Hashtable();
                w_params.Add("AyudaOpcion_ID", this.AyudaOpcion_ID);

                return DB.DeleteRow("AyudasOpciones", w_params);
            }

            public static string GetUrlByOpcion(string opcion)
            {
                string sqlstr = "SELECT Url FROM AyudasOpciones WHERE Opcion = @Opcion";
                return DB.QueryScalar(sqlstr,
                    new KeyValuePair<string, object>("@Opcion", opcion)).ToString();
            }

        } //End Class AyudasOpciones

        public class Cajas
        {

            public Cajas()
            {
            }

            public Cajas(int caja_id, int empresa_id, int estacion_id, string nombre, bool activa, int referencia_id)
            {
                this.Caja_ID = caja_id;
                this.Empresa_ID = empresa_id;
                this.Estacion_ID = estacion_id;
                this.Nombre = nombre;
                this.Activa = activa;
                this.Referencia_ID = referencia_id;
            }

            private int _Caja_ID;
            public int Caja_ID
            {
                get { return _Caja_ID; }
                set { _Caja_ID = value; }
            }

            private int _Empresa_ID;
            public int Empresa_ID
            {
                get { return _Empresa_ID; }
                set { _Empresa_ID = value; }
            }

            private int _Estacion_ID;
            public int Estacion_ID
            {
                get { return _Estacion_ID; }
                set { _Estacion_ID = value; }
            }

            private string _Nombre;
            public string Nombre
            {
                get { return _Nombre; }
                set { _Nombre = value; }
            }

            private bool _Activa;
            public bool Activa
            {
                get { return _Activa; }
                set { _Activa = value; }
            }

            private int _Referencia_ID;
            public int Referencia_ID
            {
                get { return _Referencia_ID; }
                set { _Referencia_ID = value; }
            }

            public int Create()
            {
                Hashtable m_params = new Hashtable();
                m_params.Add("Empresa_ID", this.Empresa_ID);
                m_params.Add("Estacion_ID", this.Estacion_ID);
                m_params.Add("Nombre", this.Nombre);
                m_params.Add("Activa", this.Activa);
                m_params.Add("Referencia_ID", this.Referencia_ID);

                return DB.InsertRow("Cajas", m_params);
            } // End Create

            public static List<Cajas> Read()
            {
                List<Cajas> list = new List<Cajas>();
                DataTable dt = DB.Select("Cajas");
                foreach (DataRow dr in dt.Rows)
                {
                    list.Add(new Cajas(Convert.ToInt32(dr["Caja_ID"]), Convert.ToInt32(dr["Empresa_ID"]), Convert.ToInt32(dr["Estacion_ID"]), Convert.ToString(dr["Nombre"]), Convert.ToBoolean(dr["Activa"]), Convert.ToInt32(dr["Referencia_ID"])));
                }

                return list;
            } // End Read

            public static Cajas Read(int caja_id)
            {                
                Hashtable w_params = new Hashtable();
                w_params.Add("Caja_ID", caja_id);
                DataTable dt = DB.Select("Cajas", w_params);
                
                if(dt.Rows.Count==0)
                {
                    return null;
                }

                DataRow dr = dt.Rows[0];

                return new Cajas(Convert.ToInt32(dr["Caja_ID"]), Convert.ToInt32(dr["Empresa_ID"]), Convert.ToInt32(dr["Estacion_ID"]), 
                        Convert.ToString(dr["Nombre"]), Convert.ToBoolean(dr["Activa"]), Convert.ToInt32(dr["Referencia_ID"]));
            } // End Read

            public static Cajas Read(params KeyValuePair<string,object>[] args)
            {                
                DataTable dt = DB.Read("Cajas", args);

                if (dt.Rows.Count == 0)
                {
                    return null;
                }

                DataRow dr = dt.Rows[0];

                return new Cajas(Convert.ToInt32(dr["Caja_ID"]), Convert.ToInt32(dr["Empresa_ID"]), Convert.ToInt32(dr["Estacion_ID"]),
                        Convert.ToString(dr["Nombre"]), Convert.ToBoolean(dr["Activa"]), Convert.ToInt32(dr["Referencia_ID"]));
            } // End Read

            public int Update()
            {
                Hashtable m_params = new Hashtable();
                Hashtable w_params = new Hashtable();
                w_params.Add("Caja_ID", this.Caja_ID);
                m_params.Add("Empresa_ID", this.Empresa_ID);
                m_params.Add("Estacion_ID", this.Estacion_ID);
                m_params.Add("Nombre", this.Nombre);
                m_params.Add("Activa", this.Activa);
                m_params.Add("Referencia_ID", this.Referencia_ID);

                return DB.UpdateRow("Cajas", m_params, w_params);
            } // End Update

            public int Delete()
            {
                Hashtable w_params = new Hashtable();
                w_params.Add("Caja_ID", this.Caja_ID);

                return DB.DeleteRow("Cajas", w_params);
            }

        } //End Class Cajas

        public class CancelacionesOrdenesTrabajos
        {

            public CancelacionesOrdenesTrabajos()
            {
            }

            public CancelacionesOrdenesTrabajos(int ordentrabajo_id, string usuario_id, DateTime fecha, string comentarios)
            {
                this.OrdenTrabajo_ID = ordentrabajo_id;
                this.Usuario_ID = usuario_id;
                this.Fecha = fecha;
                this.Comentarios = comentarios;
            }

            private int _OrdenTrabajo_ID;
            public int OrdenTrabajo_ID
            {
                get { return _OrdenTrabajo_ID; }
                set { _OrdenTrabajo_ID = value; }
            }

            private string _Usuario_ID;
            public string Usuario_ID
            {
                get { return _Usuario_ID; }
                set { _Usuario_ID = value; }
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
                m_params.Add("OrdenTrabajo_ID", this.OrdenTrabajo_ID);
                m_params.Add("Usuario_ID", this.Usuario_ID);
                m_params.Add("Fecha", this.Fecha);
                m_params.Add("Comentarios", this.Comentarios);

                return DB.InsertRow("CancelacionesOrdenesTrabajos", m_params);
            } // End Create

            public static List<CancelacionesOrdenesTrabajos> Read()
            {
                List<CancelacionesOrdenesTrabajos> list = new List<CancelacionesOrdenesTrabajos>();
                DataTable dt = DB.Select("CancelacionesOrdenesTrabajos");
                foreach (DataRow dr in dt.Rows)
                {
                    list.Add(new CancelacionesOrdenesTrabajos(Convert.ToInt32(dr["OrdenTrabajo_ID"]), Convert.ToString(dr["Usuario_ID"]), Convert.ToDateTime(dr["Fecha"]), Convert.ToString(dr["Comentarios"])));
                }

                return list;
            } // End Read

            public static CancelacionesOrdenesTrabajos Read(int ordentrabajo_id)
            {
                Hashtable w_params = new Hashtable();
                w_params.Add("OrdenTrabajo_ID", ordentrabajo_id);
                DataTable dt = DB.Select("CancelacionesOrdenesTrabajos", w_params);
                if (dt.Rows.Count == 0)
                {
                    throw new Exception("No existe CancelacionesOrdenesTrabajos con los criterios de búsqueda especificados.");
                }
                DataRow dr = dt.Rows[0];
                return new CancelacionesOrdenesTrabajos(Convert.ToInt32(dr["OrdenTrabajo_ID"]), Convert.ToString(dr["Usuario_ID"]), Convert.ToDateTime(dr["Fecha"]), Convert.ToString(dr["Comentarios"]));
            } // End Read

            public int Update()
            {
                Hashtable m_params = new Hashtable();
                Hashtable w_params = new Hashtable();
                w_params.Add("OrdenTrabajo_ID", this.OrdenTrabajo_ID);                
                m_params.Add("Usuario_ID", this.Usuario_ID);
                m_params.Add("Fecha", this.Fecha);
                m_params.Add("Comentarios", this.Comentarios);

                return DB.UpdateRow("CancelacionesOrdenesTrabajos", m_params, w_params);
            } // End Update

            public int Delete()
            {
                Hashtable w_params = new Hashtable();
                w_params.Add("OrdenTrabajo_ID", this.OrdenTrabajo_ID);

                return DB.DeleteRow("CancelacionesOrdenesTrabajos", w_params);
            } // End Delete

        } //End Class CancelacionesOrdenesTrabajos

        public class CategoriasMecanicos
        {

            public CategoriasMecanicos()
            {
            }

            public CategoriasMecanicos(int categoriamecanico_id, int familia_id, string nombre)
            {
                this.CategoriaMecanico_ID = categoriamecanico_id;
                this.Familia_ID = familia_id;
                this.Nombre = nombre;
            }

            private int _CategoriaMecanico_ID;
            public int CategoriaMecanico_ID
            {
                get { return _CategoriaMecanico_ID; }
                set { _CategoriaMecanico_ID = value; }
            }

            private int _Familia_ID;
            public int Familia_ID
            {
                get { return _Familia_ID; }
                set { _Familia_ID = value; }
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
                m_params.Add("Familia_ID", this.Familia_ID);
                m_params.Add("Nombre", this.Nombre);

                return DB.InsertRow("CategoriasMecanicos", m_params);
            } // End Create  

            public int Create(bool IsIdentityInsert)
            {
                if (!IsIdentityInsert) { return Create(); }

                Hashtable m_params = new Hashtable();
                m_params.Add("CategoriaMecanico_ID", this.CategoriaMecanico_ID);
                m_params.Add("Familia_ID", this.Familia_ID);
                m_params.Add("Nombre", this.Nombre);

                return DB.IdentityInsertRow("CategoriasMecanicos", m_params);

            } // End Create

            public static List<CategoriasMecanicos> Read()
            {
                List<CategoriasMecanicos> list = new List<CategoriasMecanicos>();
                DataTable dt = DB.Select("CategoriasMecanicos");
                foreach (DataRow dr in dt.Rows)
                {
                    list.Add(new CategoriasMecanicos(Convert.ToInt32(dr["CategoriaMecanico_ID"]), Convert.ToInt32(dr["Familia_ID"]), Convert.ToString(dr["Nombre"])));
                }

                return list;
            } // End Read

            public static CategoriasMecanicos Read(int categoriamecanico_id)
            {
                Hashtable w_params = new Hashtable();
                w_params.Add("CategoriaMecanico_ID", categoriamecanico_id);
                DataTable dt = DB.Select("CategoriasMecanicos", w_params);
                if (dt.Rows.Count == 0)
                {
                    throw new Exception("No existe CategoriasMecanicos con los criterios de búsqueda especificados.");
                }
                DataRow dr = dt.Rows[0];
                return new CategoriasMecanicos(Convert.ToInt32(dr["CategoriaMecanico_ID"]), Convert.ToInt32(dr["Familia_ID"]), Convert.ToString(dr["Nombre"]));
            } // End Read

            public int Update()
            {
                Hashtable m_params = new Hashtable();
                Hashtable w_params = new Hashtable();
                w_params.Add("CategoriaMecanico_ID", this.CategoriaMecanico_ID);
                m_params.Add("Familia_ID", this.Familia_ID);
                m_params.Add("Nombre", this.Nombre);

                return DB.UpdateRow("CategoriasMecanicos", m_params, w_params);
            } // End Update

            public int Delete()
            {
                Hashtable w_params = new Hashtable();
                w_params.Add("CategoriaMecanico_ID", this.CategoriaMecanico_ID);

                return DB.DeleteRow("CategoriasMecanicos", w_params);
            } // End Delete

        } //End Class CategoriasMecanicos

        public class ClasesPublicidad
        {

            public ClasesPublicidad()
            {
            }

            public ClasesPublicidad(int clasepublicidad_id, string nombre)
            {
                this.ClasePublicidad_ID = clasepublicidad_id;
                this.Nombre = nombre;
            }

            private int _ClasePublicidad_ID;
            public int ClasePublicidad_ID
            {
                get { return _ClasePublicidad_ID; }
                set { _ClasePublicidad_ID = value; }
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

                return DB.InsertRow("ClasesPublicidad", m_params);
            } // End Create

            public static List<ClasesPublicidad> Read()
            {
                List<ClasesPublicidad> list = new List<ClasesPublicidad>();
                DataTable dt = DB.Select("ClasesPublicidad");
                foreach (DataRow dr in dt.Rows)
                {
                    list.Add(new ClasesPublicidad(Convert.ToInt32(dr["ClasePublicidad_ID"]), Convert.ToString(dr["Nombre"])));
                }

                return list;
            } // End Read

            public static List<ClasesPublicidad> Read(int clasepublicidad_id)
            {
                List<ClasesPublicidad> list = new List<ClasesPublicidad>();
                Hashtable w_params = new Hashtable();
                w_params.Add("ClasePublicidad_ID", clasepublicidad_id);
                DataTable dt = DB.Select("ClasesPublicidad", w_params);
                foreach (DataRow dr in dt.Rows)
                {
                    list.Add(new ClasesPublicidad(Convert.ToInt32(dr["ClasePublicidad_ID"]), Convert.ToString(dr["Nombre"])));
                }

                return list;
            } // End Read

            public int Update()
            {
                Hashtable m_params = new Hashtable();
                Hashtable w_params = new Hashtable();
                w_params.Add("ClasePublicidad_ID", this.ClasePublicidad_ID);
                m_params.Add("Nombre", this.Nombre);

                return DB.UpdateRow("ClasesPublicidad", m_params, w_params);
            } // End Update

            public int Delete()
            {
                Hashtable w_params = new Hashtable();
                w_params.Add("ClasePublicidad_ID", this.ClasePublicidad_ID);

                return DB.DeleteRow("ClasesPublicidad", w_params);
            }

        } //End Class ClasesPublicidad

        public class ClasesServicios
        {

            public ClasesServicios()
            {
            }

            public ClasesServicios(int claseservicio_id, string nombre)
            {
                this.ClaseServicio_ID = claseservicio_id;
                this.Nombre = nombre;
            }

            private int _ClaseServicio_ID;
            public int ClaseServicio_ID
            {
                get { return _ClaseServicio_ID; }
                set { _ClaseServicio_ID = value; }
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

                return DB.InsertRow("ClasesServicios", m_params);
            } // End Create

            public static List<ClasesServicios> Read()
            {
                List<ClasesServicios> list = new List<ClasesServicios>();
                DataTable dt = DB.Select("ClasesServicios");
                foreach (DataRow dr in dt.Rows)
                {
                    list.Add(new ClasesServicios(Convert.ToInt32(dr["ClaseServicio_ID"]), Convert.ToString(dr["Nombre"])));
                }

                return list;
            } // End Read

            public static List<ClasesServicios> Read(int claseservicio_id)
            {
                List<ClasesServicios> list = new List<ClasesServicios>();
                Hashtable w_params = new Hashtable();
                w_params.Add("ClaseServicio_ID", claseservicio_id);
                DataTable dt = DB.Select("ClasesServicios", w_params);
                foreach (DataRow dr in dt.Rows)
                {
                    list.Add(new ClasesServicios(Convert.ToInt32(dr["ClaseServicio_ID"]), Convert.ToString(dr["Nombre"])));
                }

                return list;
            } // End Read

            public int Update()
            {
                Hashtable m_params = new Hashtable();
                Hashtable w_params = new Hashtable();
                w_params.Add("ClaseServicio_ID", this.ClaseServicio_ID);
                m_params.Add("Nombre", this.Nombre);

                return DB.UpdateRow("ClasesServicios", m_params, w_params);
            } // End Update

            public int Delete()
            {
                Hashtable w_params = new Hashtable();
                w_params.Add("ClaseServicio_ID", this.ClaseServicio_ID);

                return DB.DeleteRow("ClasesServicios", w_params);
            }

        } //End Class ClasesServicios

        public class ComisionesServicios
        {

            public ComisionesServicios()
            {
            }

            public ComisionesServicios(int comisionservicio_id, int comisionista_id, int tipocomision_id, decimal monto, string nombre)
            {
                this.ComisionServicio_ID = comisionservicio_id;
                this.Comisionista_ID = comisionista_id;
                this.TipoComision_ID = tipocomision_id;
                this.Monto = monto;
                this.Nombre = nombre;
            }

            private int _ComisionServicio_ID;
            public int ComisionServicio_ID
            {
                get { return _ComisionServicio_ID; }
                set { _ComisionServicio_ID = value; }
            }

            private int _Comisionista_ID;
            public int Comisionista_ID
            {
                get { return _Comisionista_ID; }
                set { _Comisionista_ID = value; }
            }

            private int _TipoComision_ID;
            public int TipoComision_ID
            {
                get { return _TipoComision_ID; }
                set { _TipoComision_ID = value; }
            }

            private decimal _Monto;
            public decimal Monto
            {
                get { return _Monto; }
                set { _Monto = value; }
            }

            private string _Nombre;
            public string Nombre
            {
                get { return _Nombre; }
                set { _Nombre = value; }
            }

            public List<Zonas> Zonas
            {
                get
                {
                    List<Zonas> list = new List<Zonas>();
                    Hashtable w_params = new Hashtable();
                    w_params.Add("ComisionServicio_ID", this.ComisionServicio_ID);
                    DataTable dt = DB.Select("Zonas", w_params);
                    foreach (DataRow dr in dt.Rows)
                    {
                        list.Add(new Zonas(Convert.ToInt32(dr["Zona_ID"]), Convert.ToInt32(dr["TipoZona_ID"]), DB.GetNullableInt32(dr["ComisionServicio_ID"]),
                            Convert.ToString(dr["Nombre"])));
                    }

                    return list;
                }
            }

            public List<TiposVenta> TiposVenta
            {
                get
                {
                    List<TiposVenta> list = new List<TiposVenta>();
                    Hashtable w_params = new Hashtable();
                    w_params.Add("ComisionServicio_ID", this.ComisionServicio_ID);
                    DataTable dt = DB.Select("TiposVenta", w_params);
                    foreach (DataRow dr in dt.Rows)
                    {
                        list.Add(new TiposVenta(Convert.ToInt32(dr["TipoVenta_ID"]), DB.GetNullableInt32(dr["ComisionServicio_ID"]), Convert.ToString(dr["Nombre"])));
                    }

                    return list;
                }
            }

            public int Create()
            {
                Hashtable m_params = new Hashtable();
                m_params.Add("Comisionista_ID", this.Comisionista_ID);
                m_params.Add("TipoComision_ID", this.TipoComision_ID);
                m_params.Add("Monto", this.Monto);
                m_params.Add("Nombre", this.Nombre);

                return DB.InsertRow("ComisionesServicios", m_params);
            } // End Create

            public static List<ComisionesServicios> Read()
            {
                List<ComisionesServicios> list = new List<ComisionesServicios>();
                DataTable dt = DB.Select("ComisionesServicios");
                foreach (DataRow dr in dt.Rows)
                {
                    list.Add(new ComisionesServicios(Convert.ToInt32(dr["ComisionServicio_ID"]), Convert.ToInt32(dr["Comisionista_ID"]), Convert.ToInt32(dr["TipoComision_ID"]), Convert.ToDecimal(dr["Monto"]), Convert.ToString(dr["Nombre"])));
                }

                return list;
            } // End Read

            public static ComisionesServicios Read(int comisionservicio_id)
            {
                Hashtable w_params = new Hashtable();
                w_params.Add("ComisionServicio_ID", comisionservicio_id);
                DataTable dt = DB.Select("ComisionesServicios", w_params);
                if (dt.Rows.Count == 0)
                {
                    throw new Exception("No existe ComisionesServicios con los criterios de búsqueda especificados.");
                }
                DataRow dr = dt.Rows[0];
                return new ComisionesServicios(Convert.ToInt32(dr["ComisionServicio_ID"]), Convert.ToInt32(dr["Comisionista_ID"]), Convert.ToInt32(dr["TipoComision_ID"]), Convert.ToDecimal(dr["Monto"]), Convert.ToString(dr["Nombre"]));
            } // End Read

            public int Update()
            {
                Hashtable m_params = new Hashtable();
                Hashtable w_params = new Hashtable();
                w_params.Add("ComisionServicio_ID", this.ComisionServicio_ID);
                m_params.Add("Comisionista_ID", this.Comisionista_ID);
                m_params.Add("TipoComision_ID", this.TipoComision_ID);
                m_params.Add("Monto", this.Monto);
                m_params.Add("Nombre", this.Nombre);

                return DB.UpdateRow("ComisionesServicios", m_params, w_params);
            } // End Update

            public int Delete()
            {
                Hashtable w_params = new Hashtable();
                w_params.Add("ComisionServicio_ID", this.ComisionServicio_ID);

                return DB.DeleteRow("ComisionesServicios", w_params);
            } // End Delete

        } //End Class ComisionesServicios

        public class Compras
        {

            #region Constructors

            public Compras()
            {
            }

            public Compras(
                int compra_id,
                int ordencompra_id,
                int refaccion_id,
                int marcarefaccion_id,
                string usuario_id,
                decimal costounitario,
                int cantidad,
                DateTime fecha,
                int refaccionessurtidas,
                int empresa_id,
                int estacion_id)
            {
                this.Compra_ID = compra_id;
                this.OrdenCompra_ID = ordencompra_id;
                this.Refaccion_ID = refaccion_id;
                this.MarcaRefaccion_ID = marcarefaccion_id;
                this.Usuario_ID = usuario_id;
                this.CostoUnitario = costounitario;
                this.Cantidad = cantidad;
                this.Fecha = fecha;
                this.RefaccionesSurtidas = refaccionessurtidas;
                this.Empresa_ID = empresa_id;
                this.Estacion_ID = estacion_id;
            }

            #endregion

            #region Properties

            private int _Compra_ID;
            public int Compra_ID
            {
                get { return _Compra_ID; }
                set { _Compra_ID = value; }
            }

            private int _OrdenCompra_ID;
            public int OrdenCompra_ID
            {
                get { return _OrdenCompra_ID; }
                set { _OrdenCompra_ID = value; }
            }

            private int _Refaccion_ID;
            public int Refaccion_ID
            {
                get { return _Refaccion_ID; }
                set { _Refaccion_ID = value; }
            }

            private int _MarcaRefaccion_ID;
            public int MarcaRefaccion_ID
            {
                get { return _MarcaRefaccion_ID; }
                set { _MarcaRefaccion_ID = value; }
            }

            private string _Usuario_ID;
            public string Usuario_ID
            {
                get { return _Usuario_ID; }
                set { _Usuario_ID = value; }
            }

            private decimal _CostoUnitario;
            public decimal CostoUnitario
            {
                get { return _CostoUnitario; }
                set { _CostoUnitario = value; }
            }

            private int _Cantidad;
            public int Cantidad
            {
                get { return _Cantidad; }
                set { _Cantidad = value; }
            }

            private DateTime _Fecha;
            public DateTime Fecha
            {
                get { return _Fecha; }
                set { _Fecha = value; }
            }

            private int _RefaccionesSurtidas;
            public int RefaccionesSurtidas
            {
                get { return _RefaccionesSurtidas; }
                set { _RefaccionesSurtidas = value; }
            }

            private int _Empresa_ID;
            public int Empresa_ID
            {
                get { return _Empresa_ID; }
                set { _Empresa_ID = value; }
            }

            private int _Estacion_ID;
            public int Estacion_ID
            {
                get { return _Estacion_ID; }
                set { _Estacion_ID = value; }
            }

            #endregion

            #region Methods
            public void Validate()
            {
                if (this.Compra_ID == null) throw new Exception("Compra_ID no puede ser nulo.");

                if (this.OrdenCompra_ID == null) throw new Exception("OrdenCompra_ID no puede ser nulo.");

                if (this.Refaccion_ID == null) throw new Exception("Refaccion_ID no puede ser nulo.");

                if (this.MarcaRefaccion_ID == null) throw new Exception("MarcaRefaccion_ID no puede ser nulo.");

                if (this.Usuario_ID == null) throw new Exception("Usuario_ID no puede ser nulo.");

                if (this.Usuario_ID.Length > 30)
                {
                    throw new Exception("Usuario_ID debe tener máximo 30 carateres.");
                }

                if (this.CostoUnitario == null) throw new Exception("CostoUnitario no puede ser nulo.");

                if (this.Cantidad == null) throw new Exception("Cantidad no puede ser nulo.");

                if (this.Fecha == null) throw new Exception("Fecha no puede ser nulo.");

                if (this.RefaccionesSurtidas == null) throw new Exception("RefaccionesSurtidas no puede ser nulo.");

                if (this.Empresa_ID == null) throw new Exception("Empresa_ID no puede ser nulo.");

                if (this.Estacion_ID == null) throw new Exception("Estacion_ID no puede ser nulo.");


            } // End Validate

            public int Create()
            {
                Hashtable m_params = new Hashtable();
                m_params.Add("OrdenCompra_ID", this.OrdenCompra_ID);
                m_params.Add("Refaccion_ID", this.Refaccion_ID);
                m_params.Add("MarcaRefaccion_ID", this.MarcaRefaccion_ID);
                m_params.Add("Usuario_ID", this.Usuario_ID);
                m_params.Add("CostoUnitario", this.CostoUnitario);
                m_params.Add("Cantidad", this.Cantidad);
                m_params.Add("Fecha", this.Fecha);
                m_params.Add("RefaccionesSurtidas", this.RefaccionesSurtidas);
                m_params.Add("Empresa_ID", this.Empresa_ID);
                m_params.Add("Estacion_ID", this.Estacion_ID);

                return DB.InsertRow("Compras", m_params);
            } // End Create

            public int Create(bool IsIdentityInsert)
            {
                if (!IsIdentityInsert) return Create();
                Hashtable m_params = new Hashtable();
                m_params.Add("Compra_ID", this.Compra_ID);
                m_params.Add("OrdenCompra_ID", this.OrdenCompra_ID);
                m_params.Add("Refaccion_ID", this.Refaccion_ID);
                m_params.Add("MarcaRefaccion_ID", this.MarcaRefaccion_ID);
                m_params.Add("Usuario_ID", this.Usuario_ID);
                m_params.Add("CostoUnitario", this.CostoUnitario);
                m_params.Add("Cantidad", this.Cantidad);
                m_params.Add("Fecha", this.Fecha);
                m_params.Add("RefaccionesSurtidas", this.RefaccionesSurtidas);
                m_params.Add("Empresa_ID", this.Empresa_ID);
                m_params.Add("Estacion_ID", this.Estacion_ID);

                return DB.IdentityInsertRow("Compras", m_params);
            } // End Create

            public static List<Compras> Read()
            {
                List<Compras> list = new List<Compras>();
                DataTable dt = DB.Select("Compras");
                foreach (DataRow dr in dt.Rows)
                {
                    list.Add(
                        new Compras(
                            Convert.ToInt32(dr["Compra_ID"]),
                            Convert.ToInt32(dr["OrdenCompra_ID"]),
                            Convert.ToInt32(dr["Refaccion_ID"]),
                            Convert.ToInt32(dr["MarcaRefaccion_ID"]),
                            Convert.ToString(dr["Usuario_ID"]),
                            Convert.ToDecimal(dr["CostoUnitario"]),
                            Convert.ToInt32(dr["Cantidad"]),
                            Convert.ToDateTime(dr["Fecha"]),
                            Convert.ToInt32(dr["RefaccionesSurtidas"]),
                            Convert.ToInt32(dr["Empresa_ID"]),
                            Convert.ToInt32(dr["Estacion_ID"])
                        )
                    );
                }

                return list;
            } // End Read

            public static Compras Read(int compra_id)
            {
                Hashtable w_params = new Hashtable();
                w_params.Add("Compra_ID", compra_id);
                DataTable dt = DB.Select("Compras", w_params);
                if (dt.Rows.Count == 0)
                {
                    throw new Exception("No existe Compras con los criterios de búsqueda especificados.");
                }
                DataRow dr = dt.Rows[0];
                return new Compras(
                    Convert.ToInt32(dr["Compra_ID"]),
                            Convert.ToInt32(dr["OrdenCompra_ID"]),
                            Convert.ToInt32(dr["Refaccion_ID"]),
                            Convert.ToInt32(dr["MarcaRefaccion_ID"]),
                            Convert.ToString(dr["Usuario_ID"]),
                            Convert.ToDecimal(dr["CostoUnitario"]),
                            Convert.ToInt32(dr["Cantidad"]),
                            Convert.ToDateTime(dr["Fecha"]),
                            Convert.ToInt32(dr["RefaccionesSurtidas"]),
                            Convert.ToInt32(dr["Empresa_ID"]),
                            Convert.ToInt32(dr["Estacion_ID"])
                        );
            } // End Read

            public static Compras Read(params KeyValuePair<string, object>[] args)
            {
                DataTable dt = DB.Read("Compras", args);
                if (dt.Rows.Count == 0)
                {
                    return null;
                }
                DataRow dr = dt.Rows[0];
                return new Compras(
                    Convert.ToInt32(dr["Compra_ID"]),
                            Convert.ToInt32(dr["OrdenCompra_ID"]),
                            Convert.ToInt32(dr["Refaccion_ID"]),
                            Convert.ToInt32(dr["MarcaRefaccion_ID"]),
                            Convert.ToString(dr["Usuario_ID"]),
                            Convert.ToDecimal(dr["CostoUnitario"]),
                            Convert.ToInt32(dr["Cantidad"]),
                            Convert.ToDateTime(dr["Fecha"]),
                            Convert.ToInt32(dr["RefaccionesSurtidas"]),
                            Convert.ToInt32(dr["Empresa_ID"]),
                            Convert.ToInt32(dr["Estacion_ID"])
                        );
            } // End Read

            public static bool Read(
                out Compras compras,
                int top,
                string filter,
                string sort,
                params KeyValuePair<string, object>[] args)
            {
                DataTable dt = DB.Read("Compras", top, filter, sort, args);
                if (dt.Rows.Count == 0)
                {
                    compras = null;
                    return false;
                }
                DataRow dr = dt.Rows[0];
                compras = new Compras(
                    Convert.ToInt32(dr["Compra_ID"]),
                            Convert.ToInt32(dr["OrdenCompra_ID"]),
                            Convert.ToInt32(dr["Refaccion_ID"]),
                            Convert.ToInt32(dr["MarcaRefaccion_ID"]),
                            Convert.ToString(dr["Usuario_ID"]),
                            Convert.ToDecimal(dr["CostoUnitario"]),
                            Convert.ToInt32(dr["Cantidad"]),
                            Convert.ToDateTime(dr["Fecha"]),
                            Convert.ToInt32(dr["RefaccionesSurtidas"]),
                            Convert.ToInt32(dr["Empresa_ID"]),
                            Convert.ToInt32(dr["Estacion_ID"])
                        );
                return true;
            } // End Read

            public static DataTable ReadDataTable()
            {
                return DB.Select("Compras");
            } // End Read

            public static DataTable ReadDataTable(int compra_id)
            {
                Hashtable w_params = new Hashtable();
                w_params.Add("Compra_ID", compra_id);
                return DB.Select("Compras", w_params);
            } // End Read

            public int Update()
            {
                Hashtable m_params = new Hashtable();
                Hashtable w_params = new Hashtable();
                w_params.Add("Compra_ID", this.Compra_ID);
                m_params.Add("OrdenCompra_ID", this.OrdenCompra_ID);
                m_params.Add("Refaccion_ID", this.Refaccion_ID);
                m_params.Add("MarcaRefaccion_ID", this.MarcaRefaccion_ID);
                m_params.Add("Usuario_ID", this.Usuario_ID);
                m_params.Add("CostoUnitario", this.CostoUnitario);
                m_params.Add("Cantidad", this.Cantidad);
                m_params.Add("Fecha", this.Fecha);
                m_params.Add("RefaccionesSurtidas", this.RefaccionesSurtidas);
                m_params.Add("Empresa_ID", this.Empresa_ID);
                m_params.Add("Estacion_ID", this.Estacion_ID);

                return DB.UpdateRow("Compras", m_params, w_params);
            } // End Update

            public int Delete()
            {
                Hashtable w_params = new Hashtable();
                w_params.Add("Compra_ID", this.Compra_ID);

                return DB.DeleteRow("Compras", w_params);
            } // End Delete


            #endregion
        } //End Class Compras

        public class Conceptos
        {

            public Conceptos()
            {
            }

            public Conceptos(int concepto_id, int cuenta_id, string nombre, bool enrecibo, bool visiblerecibo, bool activo)
            {
                this.Concepto_ID = concepto_id;
                this.Cuenta_ID = cuenta_id;
                this.Nombre = nombre;
                this.EnRecibo = enrecibo;
                this.VisibleRecibo = visiblerecibo;
                this.Activo = activo;
            }

            private int _Concepto_ID;
            public int Concepto_ID
            {
                get { return _Concepto_ID; }
                set { _Concepto_ID = value; }
            }

            private int _Cuenta_ID;
            public int Cuenta_ID
            {
                get { return _Cuenta_ID; }
                set { _Cuenta_ID = value; }
            }

            private string _Nombre;
            public string Nombre
            {
                get { return _Nombre; }
                set { _Nombre = value; }
            }

            private bool _EnRecibo;
            public bool EnRecibo
            {
                get { return _EnRecibo; }
                set { _EnRecibo = value; }
            }

            private bool _VisibleRecibo;
            public bool VisibleRecibo
            {
                get { return _VisibleRecibo; }
                set { _VisibleRecibo = value; }
            }

            private bool _Activo;
            public bool Activo
            {
                get { return _Activo; }
                set { _Activo = value; }
            }

            public int Create()
            {
                Hashtable m_params = new Hashtable();
                m_params.Add("Cuenta_ID", this.Cuenta_ID);
                m_params.Add("Nombre", this.Nombre);
                m_params.Add("EnRecibo", this.EnRecibo);
                m_params.Add("VisibleRecibo", this.VisibleRecibo);
                m_params.Add("Activo", this.Activo);

                return DB.InsertRow("Conceptos", m_params);
            } // End Create

            public static List<Conceptos> Read()
            {
                List<Conceptos> list = new List<Conceptos>();
                DataTable dt = DB.Select("Conceptos");
                foreach (DataRow dr in dt.Rows)
                {
                    list.Add(new Conceptos(Convert.ToInt32(dr["Concepto_ID"]), Convert.ToInt32(dr["Cuenta_ID"]), Convert.ToString(dr["Nombre"]), Convert.ToBoolean(dr["EnRecibo"]), Convert.ToBoolean(dr["VisibleRecibo"]), Convert.ToBoolean(dr["Activo"])));
                }

                return list;
            } // End Read

            public static List<Conceptos> Read(int concepto_id)
            {
                List<Conceptos> list = new List<Conceptos>();
                Hashtable w_params = new Hashtable();
                w_params.Add("Concepto_ID", concepto_id);
                DataTable dt = DB.Select("Conceptos", w_params);
                foreach (DataRow dr in dt.Rows)
                {
                    list.Add(new Conceptos(Convert.ToInt32(dr["Concepto_ID"]), Convert.ToInt32(dr["Cuenta_ID"]), Convert.ToString(dr["Nombre"]), Convert.ToBoolean(dr["EnRecibo"]), Convert.ToBoolean(dr["VisibleRecibo"]), Convert.ToBoolean(dr["Activo"])));
                }

                return list;
            } // End Read

            public int Update()
            {
                Hashtable m_params = new Hashtable();
                Hashtable w_params = new Hashtable();
                w_params.Add("Concepto_ID", this.Concepto_ID);
                m_params.Add("Cuenta_ID", this.Cuenta_ID);
                m_params.Add("Nombre", this.Nombre);
                m_params.Add("EnRecibo", this.EnRecibo);
                m_params.Add("VisibleRecibo", this.VisibleRecibo);
                m_params.Add("Activo", this.Activo);

                return DB.UpdateRow("Conceptos", m_params, w_params);
            } // End Update

            public int Delete()
            {
                Hashtable w_params = new Hashtable();
                w_params.Add("Concepto_ID", this.Concepto_ID);

                return DB.DeleteRow("Conceptos", w_params);
            }

        } //End Class Conceptos

        public class Concesiones
        {

            public Concesiones()
            {
            }

            public Concesiones(int concesion_id, int empresa_id, int tipoconcesion_id, string placa, string numeroconcesion, bool? activo, int? referencia_id, int? estacionreferencia_id)
            {
                this.Concesion_ID = concesion_id;
                this.Empresa_ID = empresa_id;
                this.TipoConcesion_ID = tipoconcesion_id;
                this.Placa = placa;
                this.NumeroConcesion = numeroconcesion;
                this.Activo = activo;
                this.Referencia_ID = referencia_id;
                this.EstacionReferencia_ID = estacionreferencia_id;
            }

            private int _Concesion_ID;
            public int Concesion_ID
            {
                get { return _Concesion_ID; }
                set { _Concesion_ID = value; }
            }

            private int _Empresa_ID;
            public int Empresa_ID
            {
                get { return _Empresa_ID; }
                set { _Empresa_ID = value; }
            }

            private int _TipoConcesion_ID;
            public int TipoConcesion_ID
            {
                get { return _TipoConcesion_ID; }
                set { _TipoConcesion_ID = value; }
            }

            private string _Placa;
            public string Placa
            {
                get { return _Placa; }
                set { _Placa = value; }
            }

            private string _NumeroConcesion;
            public string NumeroConcesion
            {
                get { return _NumeroConcesion; }
                set { _NumeroConcesion = value; }
            }

            private bool? _Activo;
            public bool? Activo
            {
                get { return _Activo; }
                set { _Activo = value; }
            }

            private int? _Referencia_ID;
            public int? Referencia_ID
            {
                get { return _Referencia_ID; }
                set { _Referencia_ID = value; }
            }

            private int? _EstacionReferencia_ID;
            public int? EstacionReferencia_ID
            {
                get { return _EstacionReferencia_ID; }
                set { _EstacionReferencia_ID = value; }
            }

            public int Create()
            {
                Hashtable m_params = new Hashtable();
                m_params.Add("Empresa_ID", this.Empresa_ID);
                m_params.Add("TipoConcesion_ID", this.TipoConcesion_ID);
                m_params.Add("Placa", this.Placa);
                m_params.Add("NumeroConcesion", this.NumeroConcesion);
                if (!AppHelper.IsNullOrEmpty(this.Activo)) m_params.Add("Activo", this.Activo);
                if (!AppHelper.IsNullOrEmpty(this.Referencia_ID)) m_params.Add("Referencia_ID", this.Referencia_ID);
                if (!AppHelper.IsNullOrEmpty(this.EstacionReferencia_ID)) m_params.Add("EstacionReferencia_ID", this.EstacionReferencia_ID);

                return DB.InsertRow("Concesiones", m_params);
            } // End Create

            public int Create(bool IsIdentityInsert)
            {
                if (!IsIdentityInsert) return Create();
                Hashtable m_params = new Hashtable();
                m_params.Add("Concesion_ID", this.Concesion_ID);
                m_params.Add("Empresa_ID", this.Empresa_ID);
                m_params.Add("TipoConcesion_ID", this.TipoConcesion_ID);
                m_params.Add("Placa", this.Placa);
                m_params.Add("NumeroConcesion", this.NumeroConcesion);
                if (!AppHelper.IsNullOrEmpty(this.Activo)) m_params.Add("Activo", this.Activo);
                if (!AppHelper.IsNullOrEmpty(this.Referencia_ID)) m_params.Add("Referencia_ID", this.Referencia_ID);
                if (!AppHelper.IsNullOrEmpty(this.EstacionReferencia_ID)) m_params.Add("EstacionReferencia_ID", this.EstacionReferencia_ID);

                return DB.IdentityInsertRow("Concesiones", m_params);
            } // End Create

            public static List<Concesiones> Read()
            {
                List<Concesiones> list = new List<Concesiones>();
                DataTable dt = DB.Select("Concesiones");
                foreach (DataRow dr in dt.Rows)
                {
                    list.Add(new Concesiones(Convert.ToInt32(dr["Concesion_ID"]), Convert.ToInt32(dr["Empresa_ID"]), Convert.ToInt32(dr["TipoConcesion_ID"]), Convert.ToString(dr["Placa"]), Convert.ToString(dr["NumeroConcesion"]), DB.GetNullableBoolean(dr["Activo"]), DB.GetNullableInt32(dr["Referencia_ID"]), DB.GetNullableInt32(dr["EstacionReferencia_ID"])));
                }

                return list;
            } // End Read

            public static Concesiones Read(int concesion_id)
            {
                Hashtable w_params = new Hashtable();
                w_params.Add("Concesion_ID", concesion_id);
                DataTable dt = DB.Select("Concesiones", w_params);
                if (dt.Rows.Count == 0)
                {
                    throw new Exception("No existe Concesiones con los criterios de búsqueda especificados.");
                }
                DataRow dr = dt.Rows[0];
                return new Concesiones(Convert.ToInt32(dr["Concesion_ID"]), Convert.ToInt32(dr["Empresa_ID"]), Convert.ToInt32(dr["TipoConcesion_ID"]), Convert.ToString(dr["Placa"]), Convert.ToString(dr["NumeroConcesion"]), DB.GetNullableBoolean(dr["Activo"]), DB.GetNullableInt32(dr["Referencia_ID"]), DB.GetNullableInt32(dr["EstacionReferencia_ID"]));
            } // End Read

            public static Concesiones Read(params KeyValuePair<string, object>[] args)
            {
                DataTable dt = DB.Read("Concesiones", args);
                if (dt.Rows.Count == 0)
                {
                    return null;
                }
                DataRow dr = dt.Rows[0];
                return new Concesiones(Convert.ToInt32(dr["Concesion_ID"]), Convert.ToInt32(dr["Empresa_ID"]), Convert.ToInt32(dr["TipoConcesion_ID"]), Convert.ToString(dr["Placa"]), Convert.ToString(dr["NumeroConcesion"]), DB.GetNullableBoolean(dr["Activo"]), DB.GetNullableInt32(dr["Referencia_ID"]), DB.GetNullableInt32(dr["EstacionReferencia_ID"]));
            } // End Read

            public static bool Read(out Concesiones concesiones, int top, string filter, string sort, params KeyValuePair<string, object>[] args)
            {
                DataTable dt = DB.Read("Concesiones", top, filter, sort, args);
                if (dt.Rows.Count == 0)
                {
                    concesiones = null;
                    return false;
                }
                DataRow dr = dt.Rows[0];
                concesiones = new Concesiones(Convert.ToInt32(dr["Concesion_ID"]), Convert.ToInt32(dr["Empresa_ID"]), Convert.ToInt32(dr["TipoConcesion_ID"]), Convert.ToString(dr["Placa"]), Convert.ToString(dr["NumeroConcesion"]), DB.GetNullableBoolean(dr["Activo"]), DB.GetNullableInt32(dr["Referencia_ID"]), DB.GetNullableInt32(dr["EstacionReferencia_ID"]));
                return true;
            } // End Read

            public int Update()
            {
                Hashtable m_params = new Hashtable();
                Hashtable w_params = new Hashtable();
                w_params.Add("Concesion_ID", this.Concesion_ID);
                m_params.Add("Empresa_ID", this.Empresa_ID);
                m_params.Add("TipoConcesion_ID", this.TipoConcesion_ID);
                m_params.Add("Placa", this.Placa);
                m_params.Add("NumeroConcesion", this.NumeroConcesion);
                if (!AppHelper.IsNullOrEmpty(this.Activo)) m_params.Add("Activo", this.Activo);
                if (!AppHelper.IsNullOrEmpty(this.Referencia_ID)) m_params.Add("Referencia_ID", this.Referencia_ID);
                if (!AppHelper.IsNullOrEmpty(this.EstacionReferencia_ID)) m_params.Add("EstacionReferencia_ID", this.EstacionReferencia_ID);

                return DB.UpdateRow("Concesiones", m_params, w_params);
            } // End Update

            public int Delete()
            {
                Hashtable w_params = new Hashtable();
                w_params.Add("Concesion_ID", this.Concesion_ID);

                return DB.DeleteRow("Concesiones", w_params);
            } // End Delete

        } //End Class Concesiones

        public class Conductores
        {

            public Conductores()
            {
            }

            public Conductores(int conductor_id, string nombre, string apellidos, string domicilio, string ciudad, string entidad, string telefono, 
                string telefono2, string movil, string email, string rfc, int estacion_id, string curp, string codigopostal, string fotografia, 
                int estatusconductor_id, int? mediopublicitario_id, bool? cumplioperfil, bool? interesado, int? mercado_id, string comentarios, 
                int? edad, string estadocivil, int? añosexperiencia, string genero, int? tipolicencia_id, string foliolicencia, DateTime? vencelicencia, 
                string rfc_aval, string apellidos_aval, string nombre_aval, string curp_aval, string domicilio_aval, string ciudad_aval, 
                string estado_aval, string codigopostal_aval, string telefono_aval, string email_aval, string solicitud, string actanacimiento, 
                string credencialelector, string cartanoantecedentes, string comprobantedomicilio, string credencialelector_aval, 
                string comprobantedomicilio_aval, decimal? saldoatratar, bool? cronocasco, bool? terminaldatos, bool? bloquearconductor, 
                string mensajeacaja, DateTime? fecha, string usuario_id, int? referencia_id)
            {
                this.Conductor_ID = conductor_id;
                this.Nombre = nombre;
                this.Apellidos = apellidos;
                this.Domicilio = domicilio;
                this.Ciudad = ciudad;
                this.Entidad = entidad;
                this.Telefono = telefono;
                this.Telefono2 = telefono2;
                this.Movil = movil;
                this.Email = email;
                this.RFC = rfc;
                this.Estacion_ID = estacion_id;
                this.CURP = curp;
                this.CodigoPostal = codigopostal;
                this.Fotografia = fotografia;
                this.EstatusConductor_ID = estatusconductor_id;
                this.MedioPublicitario_ID = mediopublicitario_id;
                this.CumplioPerfil = cumplioperfil;
                this.Interesado = interesado;
                this.Mercado_ID = mercado_id;
                this.Comentarios = comentarios;
                this.Edad = edad;
                this.EstadoCivil = estadocivil;
                this.AñosExperiencia = añosexperiencia;
                this.Genero = genero;
                this.TipoLicencia_ID = tipolicencia_id;
                this.FolioLicencia = foliolicencia;
                this.VenceLicencia = vencelicencia;
                this.Rfc_Aval = rfc_aval;
                this.Apellidos_Aval = apellidos_aval;
                this.Nombre_Aval = nombre_aval;
                this.Curp_Aval = curp_aval;
                this.Domicilio_Aval = domicilio_aval;
                this.Ciudad_Aval = ciudad_aval;
                this.Estado_Aval = estado_aval;
                this.CodigoPostal_Aval = codigopostal_aval;
                this.Telefono_Aval = telefono_aval;
                this.Email_Aval = email_aval;
                this.Solicitud = solicitud;
                this.ActaNacimiento = actanacimiento;
                this.CredencialElector = credencialelector;
                this.CartaNoAntecedentes = cartanoantecedentes;
                this.ComprobanteDomicilio = comprobantedomicilio;
                this.CredencialElector_Aval = credencialelector_aval;
                this.ComprobanteDomicilio_Aval = comprobantedomicilio_aval;
                this.SaldoATratar = saldoatratar;
                this.Cronocasco = cronocasco;
                this.TerminalDatos = terminaldatos;
                this.BloquearConductor = bloquearconductor;
                this.MensajeACaja = mensajeacaja;
                this.Fecha = fecha;
                this.Usuario_ID = usuario_id;
                this.Referencia_ID = referencia_id;
            }

            private int _Conductor_ID;
            public int Conductor_ID
            {
                get { return _Conductor_ID; }
                set { _Conductor_ID = value; }
            }

            private string _Nombre;
            public string Nombre
            {
                get { return _Nombre; }
                set { _Nombre = value; }
            }

            private string _Apellidos;
            public string Apellidos
            {
                get { return _Apellidos; }
                set { _Apellidos = value; }
            }

            private string _Domicilio;
            public string Domicilio
            {
                get { return _Domicilio; }
                set { _Domicilio = value; }
            }

            private string _Ciudad;
            public string Ciudad
            {
                get { return _Ciudad; }
                set { _Ciudad = value; }
            }

            private string _Entidad;
            public string Entidad
            {
                get { return _Entidad; }
                set { _Entidad = value; }
            }

            private string _Telefono;
            public string Telefono
            {
                get { return _Telefono; }
                set { _Telefono = value; }
            }

            private string _Telefono2;
            public string Telefono2
            {
                get { return _Telefono2; }
                set { _Telefono2 = value; }
            }

            private string _Movil;
            public string Movil
            {
                get { return _Movil; }
                set { _Movil = value; }
            }

            private string _Email;
            public string Email
            {
                get { return _Email; }
                set { _Email = value; }
            }

            private string _RFC;
            public string RFC
            {
                get { return _RFC; }
                set { _RFC = value; }
            }

            private int _Estacion_ID;
            public int Estacion_ID
            {
                get { return _Estacion_ID; }
                set { _Estacion_ID = value; }
            }

            private string _CURP;
            public string CURP
            {
                get { return _CURP; }
                set { _CURP = value; }
            }

            private string _CodigoPostal;
            public string CodigoPostal
            {
                get { return _CodigoPostal; }
                set { _CodigoPostal = value; }
            }

            private string _Fotografia;
            public string Fotografia
            {
                get { return _Fotografia; }
                set { _Fotografia = value; }
            }

            private int _EstatusConductor_ID;
            public int EstatusConductor_ID
            {
                get { return _EstatusConductor_ID; }
                set { _EstatusConductor_ID = value; }
            }

            private int? _MedioPublicitario_ID;
            public int? MedioPublicitario_ID
            {
                get { return _MedioPublicitario_ID; }
                set { _MedioPublicitario_ID = value; }
            }

            private bool? _CumplioPerfil;
            public bool? CumplioPerfil
            {
                get { return _CumplioPerfil; }
                set { _CumplioPerfil = value; }
            }

            private bool? _Interesado;
            public bool? Interesado
            {
                get { return _Interesado; }
                set { _Interesado = value; }
            }

            private int? _Mercado_ID;
            public int? Mercado_ID
            {
                get { return _Mercado_ID; }
                set { _Mercado_ID = value; }
            }

            private string _Comentarios;
            public string Comentarios
            {
                get { return _Comentarios; }
                set { _Comentarios = value; }
            }

            private int? _Edad;
            public int? Edad
            {
                get { return _Edad; }
                set { _Edad = value; }
            }

            private string _EstadoCivil;
            public string EstadoCivil
            {
                get { return _EstadoCivil; }
                set { _EstadoCivil = value; }
            }

            private int? _AñosExperiencia;
            public int? AñosExperiencia
            {
                get { return _AñosExperiencia; }
                set { _AñosExperiencia = value; }
            }

            private string _Genero;
            public string Genero
            {
                get { return _Genero; }
                set { _Genero = value; }
            }

            private int? _TipoLicencia_ID;
            public int? TipoLicencia_ID
            {
                get { return _TipoLicencia_ID; }
                set { _TipoLicencia_ID = value; }
            }

            private string _FolioLicencia;
            public string FolioLicencia
            {
                get { return _FolioLicencia; }
                set { _FolioLicencia = value; }
            }

            private DateTime? _VenceLicencia;
            public DateTime? VenceLicencia
            {
                get { return _VenceLicencia; }
                set { _VenceLicencia = value; }
            }

            private string _Rfc_Aval;
            public string Rfc_Aval
            {
                get { return _Rfc_Aval; }
                set { _Rfc_Aval = value; }
            }

            private string _Apellidos_Aval;
            public string Apellidos_Aval
            {
                get { return _Apellidos_Aval; }
                set { _Apellidos_Aval = value; }
            }

            private string _Nombre_Aval;
            public string Nombre_Aval
            {
                get { return _Nombre_Aval; }
                set { _Nombre_Aval = value; }
            }

            private string _Curp_Aval;
            public string Curp_Aval
            {
                get { return _Curp_Aval; }
                set { _Curp_Aval = value; }
            }

            private string _Domicilio_Aval;
            public string Domicilio_Aval
            {
                get { return _Domicilio_Aval; }
                set { _Domicilio_Aval = value; }
            }

            private string _Ciudad_Aval;
            public string Ciudad_Aval
            {
                get { return _Ciudad_Aval; }
                set { _Ciudad_Aval = value; }
            }

            private string _Estado_Aval;
            public string Estado_Aval
            {
                get { return _Estado_Aval; }
                set { _Estado_Aval = value; }
            }

            private string _CodigoPostal_Aval;
            public string CodigoPostal_Aval
            {
                get { return _CodigoPostal_Aval; }
                set { _CodigoPostal_Aval = value; }
            }

            private string _Telefono_Aval;
            public string Telefono_Aval
            {
                get { return _Telefono_Aval; }
                set { _Telefono_Aval = value; }
            }

            private string _Email_Aval;
            public string Email_Aval
            {
                get { return _Email_Aval; }
                set { _Email_Aval = value; }
            }

            private string _Solicitud;
            public string Solicitud
            {
                get { return _Solicitud; }
                set { _Solicitud = value; }
            }

            private string _ActaNacimiento;
            public string ActaNacimiento
            {
                get { return _ActaNacimiento; }
                set { _ActaNacimiento = value; }
            }

            private string _CredencialElector;
            public string CredencialElector
            {
                get { return _CredencialElector; }
                set { _CredencialElector = value; }
            }

            private string _CartaNoAntecedentes;
            public string CartaNoAntecedentes
            {
                get { return _CartaNoAntecedentes; }
                set { _CartaNoAntecedentes = value; }
            }

            private string _ComprobanteDomicilio;
            public string ComprobanteDomicilio
            {
                get { return _ComprobanteDomicilio; }
                set { _ComprobanteDomicilio = value; }
            }

            private string _CredencialElector_Aval;
            public string CredencialElector_Aval
            {
                get { return _CredencialElector_Aval; }
                set { _CredencialElector_Aval = value; }
            }

            private string _ComprobanteDomicilio_Aval;
            public string ComprobanteDomicilio_Aval
            {
                get { return _ComprobanteDomicilio_Aval; }
                set { _ComprobanteDomicilio_Aval = value; }
            }

            private decimal? _SaldoATratar;
            public decimal? SaldoATratar
            {
                get { return _SaldoATratar; }
                set { _SaldoATratar = value; }
            }

            private bool? _Cronocasco;
            public bool? Cronocasco
            {
                get { return _Cronocasco; }
                set { _Cronocasco = value; }
            }

            private bool? _TerminalDatos;
            public bool? TerminalDatos
            {
                get { return _TerminalDatos; }
                set { _TerminalDatos = value; }
            }

            private bool? _BloquearConductor;
            public bool? BloquearConductor
            {
                get { return _BloquearConductor; }
                set { _BloquearConductor = value; }
            }

            private string _MensajeACaja;
            public string MensajeACaja
            {
                get { return _MensajeACaja; }
                set { _MensajeACaja = value; }
            }

            private DateTime? _Fecha;
            public DateTime? Fecha
            {
                get { return _Fecha; }
                set { _Fecha = value; }
            }

            private string _Usuario_ID;
            public string Usuario_ID
            {
                get { return _Usuario_ID; }
                set { _Usuario_ID = value; }
            }

            private int? _Referencia_ID;
            public int? Referencia_ID
            {
                get { return _Referencia_ID; }
                set { _Referencia_ID = value; }
            }

            public int Create()
            {
                Hashtable m_params = new Hashtable();
                if (!AppHelper.IsNullOrEmpty(this.Nombre)) m_params.Add("Nombre", this.Nombre);
                if (!AppHelper.IsNullOrEmpty(this.Apellidos)) m_params.Add("Apellidos", this.Apellidos);
                m_params.Add("Domicilio", this.Domicilio);
                m_params.Add("Ciudad", this.Ciudad);
                m_params.Add("Entidad", this.Entidad);
                if (!AppHelper.IsNullOrEmpty(this.Telefono)) m_params.Add("Telefono", this.Telefono);
                if (!AppHelper.IsNullOrEmpty(this.Telefono2)) m_params.Add("Telefono2", this.Telefono2);
                if (!AppHelper.IsNullOrEmpty(this.Movil)) m_params.Add("Movil", this.Movil);
                if (!AppHelper.IsNullOrEmpty(this.Email)) m_params.Add("Email", this.Email);
                m_params.Add("RFC", this.RFC);
                m_params.Add("Estacion_ID", this.Estacion_ID);
                m_params.Add("CURP", this.CURP);
                m_params.Add("CodigoPostal", this.CodigoPostal);
                if (!AppHelper.IsNullOrEmpty(this.Fotografia)) m_params.Add("Fotografia", this.Fotografia);
                m_params.Add("EstatusConductor_ID", this.EstatusConductor_ID);
                if (!AppHelper.IsNullOrEmpty(this.MedioPublicitario_ID)) m_params.Add("MedioPublicitario_ID", this.MedioPublicitario_ID);
                if (!AppHelper.IsNullOrEmpty(this.CumplioPerfil)) m_params.Add("CumplioPerfil", this.CumplioPerfil);
                if (!AppHelper.IsNullOrEmpty(this.Interesado)) m_params.Add("Interesado", this.Interesado);
                if (!AppHelper.IsNullOrEmpty(this.Mercado_ID)) m_params.Add("Mercado_ID", this.Mercado_ID);
                if (!AppHelper.IsNullOrEmpty(this.Comentarios)) m_params.Add("Comentarios", this.Comentarios);
                if (!AppHelper.IsNullOrEmpty(this.Edad)) m_params.Add("Edad", this.Edad);
                if (!AppHelper.IsNullOrEmpty(this.EstadoCivil)) m_params.Add("EstadoCivil", this.EstadoCivil);
                if (!AppHelper.IsNullOrEmpty(this.AñosExperiencia)) m_params.Add("AñosExperiencia", this.AñosExperiencia);
                if (!AppHelper.IsNullOrEmpty(this.Genero)) m_params.Add("Genero", this.Genero);
                if (!AppHelper.IsNullOrEmpty(this.TipoLicencia_ID)) m_params.Add("TipoLicencia_ID", this.TipoLicencia_ID);
                if (!AppHelper.IsNullOrEmpty(this.FolioLicencia)) m_params.Add("FolioLicencia", this.FolioLicencia);
                if (!AppHelper.IsNullOrEmpty(this.VenceLicencia)) m_params.Add("VenceLicencia", this.VenceLicencia);
                if (!AppHelper.IsNullOrEmpty(this.Rfc_Aval)) m_params.Add("Rfc_Aval", this.Rfc_Aval);
                if (!AppHelper.IsNullOrEmpty(this.Apellidos_Aval)) m_params.Add("Apellidos_Aval", this.Apellidos_Aval);
                if (!AppHelper.IsNullOrEmpty(this.Nombre_Aval)) m_params.Add("Nombre_Aval", this.Nombre_Aval);
                if (!AppHelper.IsNullOrEmpty(this.Curp_Aval)) m_params.Add("Curp_Aval", this.Curp_Aval);
                if (!AppHelper.IsNullOrEmpty(this.Domicilio_Aval)) m_params.Add("Domicilio_Aval", this.Domicilio_Aval);
                if (!AppHelper.IsNullOrEmpty(this.Ciudad_Aval)) m_params.Add("Ciudad_Aval", this.Ciudad_Aval);
                if (!AppHelper.IsNullOrEmpty(this.Estado_Aval)) m_params.Add("Estado_Aval", this.Estado_Aval);
                if (!AppHelper.IsNullOrEmpty(this.CodigoPostal_Aval)) m_params.Add("CodigoPostal_Aval", this.CodigoPostal_Aval);
                if (!AppHelper.IsNullOrEmpty(this.Telefono_Aval)) m_params.Add("Telefono_Aval", this.Telefono_Aval);
                if (!AppHelper.IsNullOrEmpty(this.Email_Aval)) m_params.Add("Email_Aval", this.Email_Aval);
                if (!AppHelper.IsNullOrEmpty(this.Solicitud)) m_params.Add("Solicitud", this.Solicitud);
                if (!AppHelper.IsNullOrEmpty(this.ActaNacimiento)) m_params.Add("ActaNacimiento", this.ActaNacimiento);
                if (!AppHelper.IsNullOrEmpty(this.CredencialElector)) m_params.Add("CredencialElector", this.CredencialElector);
                if (!AppHelper.IsNullOrEmpty(this.CartaNoAntecedentes)) m_params.Add("CartaNoAntecedentes", this.CartaNoAntecedentes);
                if (!AppHelper.IsNullOrEmpty(this.ComprobanteDomicilio)) m_params.Add("ComprobanteDomicilio", this.ComprobanteDomicilio);
                if (!AppHelper.IsNullOrEmpty(this.CredencialElector_Aval)) m_params.Add("CredencialElector_Aval", this.CredencialElector_Aval);
                if (!AppHelper.IsNullOrEmpty(this.ComprobanteDomicilio_Aval)) m_params.Add("ComprobanteDomicilio_Aval", this.ComprobanteDomicilio_Aval);
                if (!AppHelper.IsNullOrEmpty(this.SaldoATratar)) m_params.Add("SaldoATratar", this.SaldoATratar);
                if (!AppHelper.IsNullOrEmpty(this.Cronocasco)) m_params.Add("Cronocasco", this.Cronocasco);
                if (!AppHelper.IsNullOrEmpty(this.TerminalDatos)) m_params.Add("TerminalDatos", this.TerminalDatos);
                if (!AppHelper.IsNullOrEmpty(this.BloquearConductor)) m_params.Add("BloquearConductor", this.BloquearConductor);
                if (!AppHelper.IsNullOrEmpty(this.MensajeACaja)) m_params.Add("MensajeACaja", this.MensajeACaja);
                if (!AppHelper.IsNullOrEmpty(this.Fecha)) m_params.Add("Fecha", this.Fecha);
                if (!AppHelper.IsNullOrEmpty(this.Usuario_ID)) m_params.Add("Usuario_ID", this.Usuario_ID);
                if (!AppHelper.IsNullOrEmpty(this.Referencia_ID)) m_params.Add("Referencia_ID", this.Referencia_ID);

                int result = DB.InsertRow("Conductores", m_params);
                this.Conductor_ID = Convert.ToInt32(DB.Ident_Current("Conductores"));
                return result;
            } // End Create

            public static List<Conductores> Read()
            {
                List<Conductores> list = new List<Conductores>();
                DataTable dt = DB.Select("Conductores");
                foreach (DataRow dr in dt.Rows)
                {
                    list.Add(new Conductores(Convert.ToInt32(dr["Conductor_ID"]), Convert.ToString(dr["Nombre"]), Convert.ToString(dr["Apellidos"]), 
                        Convert.ToString(dr["Domicilio"]), Convert.ToString(dr["Ciudad"]), Convert.ToString(dr["Entidad"]), Convert.ToString(dr["Telefono"]), 
                            Convert.ToString(dr["Telefono2"]), Convert.ToString(dr["Movil"]), Convert.ToString(dr["Email"]), Convert.ToString(dr["RFC"]), 
                                Convert.ToInt32(dr["Estacion_ID"]), Convert.ToString(dr["CURP"]), Convert.ToString(dr["CodigoPostal"]), 
                                    Convert.ToString(dr["Fotografia"]), Convert.ToInt32(dr["EstatusConductor_ID"]), DB.GetNullableInt32(dr["MedioPublicitario_ID"]), 
                                        DB.GetNullableBoolean(dr["CumplioPerfil"]), DB.GetNullableBoolean(dr["Interesado"]), DB.GetNullableInt32(dr["Mercado_ID"]), 
                                            Convert.ToString(dr["Comentarios"]), DB.GetNullableInt32(dr["Edad"]), Convert.ToString(dr["EstadoCivil"]), 
                                                DB.GetNullableInt32(dr["AñosExperiencia"]), Convert.ToString(dr["Genero"]), DB.GetNullableInt32(dr["TipoLicencia_ID"]), 
                                                    Convert.ToString(dr["FolioLicencia"]), DB.GetNullableDateTime(dr["VenceLicencia"]), Convert.ToString(dr["Rfc_Aval"]), 
                                                        Convert.ToString(dr["Apellidos_Aval"]), Convert.ToString(dr["Nombre_Aval"]), Convert.ToString(dr["Curp_Aval"]), 
                                                            Convert.ToString(dr["Domicilio_Aval"]), Convert.ToString(dr["Ciudad_Aval"]), Convert.ToString(dr["Estado_Aval"]), 
                                                                Convert.ToString(dr["CodigoPostal_Aval"]), Convert.ToString(dr["Telefono_Aval"]), Convert.ToString(dr["Email_Aval"]), 
                                                                    Convert.ToString(dr["Solicitud"]), Convert.ToString(dr["ActaNacimiento"]), Convert.ToString(dr["CredencialElector"]), 
                                                                        Convert.ToString(dr["CartaNoAntecedentes"]), Convert.ToString(dr["ComprobanteDomicilio"]), 
                                                                            Convert.ToString(dr["CredencialElector_Aval"]), Convert.ToString(dr["ComprobanteDomicilio_Aval"]), 
                                                                                DB.GetNullableDecimal(dr["SaldoATratar"]), DB.GetNullableBoolean(dr["Cronocasco"]), DB.GetNullableBoolean(dr["TerminalDatos"]), 
                                                                                    DB.GetNullableBoolean(dr["BloquearConductor"]), Convert.ToString(dr["MensajeACaja"]), DB.GetNullableDateTime(dr["Fecha"]), 
                                                                                        Convert.ToString(dr["Usuario_ID"]), DB.GetNullableInt32(dr["Referencia_ID"])));
                }

                return list;
            } // End Read

            public static Conductores Read(int conductor_id)
            {
                Hashtable w_params = new Hashtable();
                w_params.Add("Conductor_ID", conductor_id);
                DataTable dt = DB.Select("Conductores", w_params);
                if (dt.Rows.Count == 0)
                {
                    throw new Exception("No existe Conductores con los criterios de búsqueda especificados.");
                }
                DataRow dr = dt.Rows[0];
                return new Conductores(Convert.ToInt32(dr["Conductor_ID"]), Convert.ToString(dr["Nombre"]), Convert.ToString(dr["Apellidos"]), Convert.ToString(dr["Domicilio"]), Convert.ToString(dr["Ciudad"]), Convert.ToString(dr["Entidad"]), Convert.ToString(dr["Telefono"]), Convert.ToString(dr["Telefono2"]), Convert.ToString(dr["Movil"]), Convert.ToString(dr["Email"]), Convert.ToString(dr["RFC"]), Convert.ToInt32(dr["Estacion_ID"]), Convert.ToString(dr["CURP"]), Convert.ToString(dr["CodigoPostal"]), Convert.ToString(dr["Fotografia"]), Convert.ToInt32(dr["EstatusConductor_ID"]), DB.GetNullableInt32(dr["MedioPublicitario_ID"]), DB.GetNullableBoolean(dr["CumplioPerfil"]), DB.GetNullableBoolean(dr["Interesado"]), DB.GetNullableInt32(dr["Mercado_ID"]), Convert.ToString(dr["Comentarios"]), DB.GetNullableInt32(dr["Edad"]), Convert.ToString(dr["EstadoCivil"]), DB.GetNullableInt32(dr["AñosExperiencia"]), Convert.ToString(dr["Genero"]), DB.GetNullableInt32(dr["TipoLicencia_ID"]), Convert.ToString(dr["FolioLicencia"]), DB.GetNullableDateTime(dr["VenceLicencia"]), Convert.ToString(dr["Rfc_Aval"]), Convert.ToString(dr["Apellidos_Aval"]), Convert.ToString(dr["Nombre_Aval"]), Convert.ToString(dr["Curp_Aval"]), Convert.ToString(dr["Domicilio_Aval"]), Convert.ToString(dr["Ciudad_Aval"]), Convert.ToString(dr["Estado_Aval"]), Convert.ToString(dr["CodigoPostal_Aval"]), Convert.ToString(dr["Telefono_Aval"]), Convert.ToString(dr["Email_Aval"]), Convert.ToString(dr["Solicitud"]), Convert.ToString(dr["ActaNacimiento"]), Convert.ToString(dr["CredencialElector"]), Convert.ToString(dr["CartaNoAntecedentes"]), Convert.ToString(dr["ComprobanteDomicilio"]), Convert.ToString(dr["CredencialElector_Aval"]), Convert.ToString(dr["ComprobanteDomicilio_Aval"]), DB.GetNullableDecimal(dr["SaldoATratar"]), DB.GetNullableBoolean(dr["Cronocasco"]), DB.GetNullableBoolean(dr["TerminalDatos"]), DB.GetNullableBoolean(dr["BloquearConductor"]), Convert.ToString(dr["MensajeACaja"]), DB.GetNullableDateTime(dr["Fecha"]), Convert.ToString(dr["Usuario_ID"]), DB.GetNullableInt32(dr["Referencia_ID"]));
            } // End Read

            public static Conductores Read(params KeyValuePair<string, object>[] args)
            {
                DataTable dt = DB.Read("Conductores", args);
                if (dt.Rows.Count == 0)
                {
                    return null;
                }
                DataRow dr = dt.Rows[0];
                return new Conductores(Convert.ToInt32(dr["Conductor_ID"]), Convert.ToString(dr["Nombre"]), Convert.ToString(dr["Apellidos"]), Convert.ToString(dr["Domicilio"]), Convert.ToString(dr["Ciudad"]), Convert.ToString(dr["Entidad"]), Convert.ToString(dr["Telefono"]), Convert.ToString(dr["Telefono2"]), Convert.ToString(dr["Movil"]), Convert.ToString(dr["Email"]), Convert.ToString(dr["RFC"]), Convert.ToInt32(dr["Estacion_ID"]), Convert.ToString(dr["CURP"]), Convert.ToString(dr["CodigoPostal"]), Convert.ToString(dr["Fotografia"]), Convert.ToInt32(dr["EstatusConductor_ID"]), DB.GetNullableInt32(dr["MedioPublicitario_ID"]), DB.GetNullableBoolean(dr["CumplioPerfil"]), DB.GetNullableBoolean(dr["Interesado"]), DB.GetNullableInt32(dr["Mercado_ID"]), Convert.ToString(dr["Comentarios"]), DB.GetNullableInt32(dr["Edad"]), Convert.ToString(dr["EstadoCivil"]), DB.GetNullableInt32(dr["AñosExperiencia"]), Convert.ToString(dr["Genero"]), DB.GetNullableInt32(dr["TipoLicencia_ID"]), Convert.ToString(dr["FolioLicencia"]), DB.GetNullableDateTime(dr["VenceLicencia"]), Convert.ToString(dr["Rfc_Aval"]), Convert.ToString(dr["Apellidos_Aval"]), Convert.ToString(dr["Nombre_Aval"]), Convert.ToString(dr["Curp_Aval"]), Convert.ToString(dr["Domicilio_Aval"]), Convert.ToString(dr["Ciudad_Aval"]), Convert.ToString(dr["Estado_Aval"]), Convert.ToString(dr["CodigoPostal_Aval"]), Convert.ToString(dr["Telefono_Aval"]), Convert.ToString(dr["Email_Aval"]), Convert.ToString(dr["Solicitud"]), Convert.ToString(dr["ActaNacimiento"]), Convert.ToString(dr["CredencialElector"]), Convert.ToString(dr["CartaNoAntecedentes"]), Convert.ToString(dr["ComprobanteDomicilio"]), Convert.ToString(dr["CredencialElector_Aval"]), Convert.ToString(dr["ComprobanteDomicilio_Aval"]), DB.GetNullableDecimal(dr["SaldoATratar"]), DB.GetNullableBoolean(dr["Cronocasco"]), DB.GetNullableBoolean(dr["TerminalDatos"]), DB.GetNullableBoolean(dr["BloquearConductor"]), Convert.ToString(dr["MensajeACaja"]), DB.GetNullableDateTime(dr["Fecha"]), Convert.ToString(dr["Usuario_ID"]), DB.GetNullableInt32(dr["Referencia_ID"]));
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
                conductores = new Conductores(Convert.ToInt32(dr["Conductor_ID"]), Convert.ToString(dr["Nombre"]), Convert.ToString(dr["Apellidos"]), Convert.ToString(dr["Domicilio"]), Convert.ToString(dr["Ciudad"]), Convert.ToString(dr["Entidad"]), Convert.ToString(dr["Telefono"]), Convert.ToString(dr["Telefono2"]), Convert.ToString(dr["Movil"]), Convert.ToString(dr["Email"]), Convert.ToString(dr["RFC"]), Convert.ToInt32(dr["Estacion_ID"]), Convert.ToString(dr["CURP"]), Convert.ToString(dr["CodigoPostal"]), Convert.ToString(dr["Fotografia"]), Convert.ToInt32(dr["EstatusConductor_ID"]), DB.GetNullableInt32(dr["MedioPublicitario_ID"]), DB.GetNullableBoolean(dr["CumplioPerfil"]), DB.GetNullableBoolean(dr["Interesado"]), DB.GetNullableInt32(dr["Mercado_ID"]), Convert.ToString(dr["Comentarios"]), DB.GetNullableInt32(dr["Edad"]), Convert.ToString(dr["EstadoCivil"]), DB.GetNullableInt32(dr["AñosExperiencia"]), Convert.ToString(dr["Genero"]), DB.GetNullableInt32(dr["TipoLicencia_ID"]), Convert.ToString(dr["FolioLicencia"]), DB.GetNullableDateTime(dr["VenceLicencia"]), Convert.ToString(dr["Rfc_Aval"]), Convert.ToString(dr["Apellidos_Aval"]), Convert.ToString(dr["Nombre_Aval"]), Convert.ToString(dr["Curp_Aval"]), Convert.ToString(dr["Domicilio_Aval"]), Convert.ToString(dr["Ciudad_Aval"]), Convert.ToString(dr["Estado_Aval"]), Convert.ToString(dr["CodigoPostal_Aval"]), Convert.ToString(dr["Telefono_Aval"]), Convert.ToString(dr["Email_Aval"]), Convert.ToString(dr["Solicitud"]), Convert.ToString(dr["ActaNacimiento"]), Convert.ToString(dr["CredencialElector"]), Convert.ToString(dr["CartaNoAntecedentes"]), Convert.ToString(dr["ComprobanteDomicilio"]), Convert.ToString(dr["CredencialElector_Aval"]), Convert.ToString(dr["ComprobanteDomicilio_Aval"]), DB.GetNullableDecimal(dr["SaldoATratar"]), DB.GetNullableBoolean(dr["Cronocasco"]), DB.GetNullableBoolean(dr["TerminalDatos"]), DB.GetNullableBoolean(dr["BloquearConductor"]), Convert.ToString(dr["MensajeACaja"]), DB.GetNullableDateTime(dr["Fecha"]), Convert.ToString(dr["Usuario_ID"]), DB.GetNullableInt32(dr["Referencia_ID"]));
                return true;
            } // End Read

            public int Update()
            {
                Hashtable m_params = new Hashtable();
                Hashtable w_params = new Hashtable();
                w_params.Add("Conductor_ID", this.Conductor_ID);
                if (!AppHelper.IsNullOrEmpty(this.Nombre)) m_params.Add("Nombre", this.Nombre);
                if (!AppHelper.IsNullOrEmpty(this.Apellidos)) m_params.Add("Apellidos", this.Apellidos);
                m_params.Add("Domicilio", this.Domicilio);
                m_params.Add("Ciudad", this.Ciudad);
                m_params.Add("Entidad", this.Entidad);
                if (!AppHelper.IsNullOrEmpty(this.Telefono)) m_params.Add("Telefono", this.Telefono);
                if (!AppHelper.IsNullOrEmpty(this.Telefono2)) m_params.Add("Telefono2", this.Telefono2);
                if (!AppHelper.IsNullOrEmpty(this.Movil)) m_params.Add("Movil", this.Movil);
                if (!AppHelper.IsNullOrEmpty(this.Email)) m_params.Add("Email", this.Email);
                m_params.Add("RFC", this.RFC);
                m_params.Add("Estacion_ID", this.Estacion_ID);
                m_params.Add("CURP", this.CURP);
                m_params.Add("CodigoPostal", this.CodigoPostal);
                if (!AppHelper.IsNullOrEmpty(this.Fotografia)) m_params.Add("Fotografia", this.Fotografia);
                m_params.Add("EstatusConductor_ID", this.EstatusConductor_ID);
                if (!AppHelper.IsNullOrEmpty(this.MedioPublicitario_ID)) m_params.Add("MedioPublicitario_ID", this.MedioPublicitario_ID);
                if (!AppHelper.IsNullOrEmpty(this.CumplioPerfil)) m_params.Add("CumplioPerfil", this.CumplioPerfil);
                if (!AppHelper.IsNullOrEmpty(this.Interesado)) m_params.Add("Interesado", this.Interesado);
                if (!AppHelper.IsNullOrEmpty(this.Mercado_ID)) m_params.Add("Mercado_ID", this.Mercado_ID);
                if (!AppHelper.IsNullOrEmpty(this.Comentarios)) m_params.Add("Comentarios", this.Comentarios);
                if (!AppHelper.IsNullOrEmpty(this.Edad)) m_params.Add("Edad", this.Edad);
                if (!AppHelper.IsNullOrEmpty(this.EstadoCivil)) m_params.Add("EstadoCivil", this.EstadoCivil);
                if (!AppHelper.IsNullOrEmpty(this.AñosExperiencia)) m_params.Add("AñosExperiencia", this.AñosExperiencia);
                if (!AppHelper.IsNullOrEmpty(this.Genero)) m_params.Add("Genero", this.Genero);
                if (!AppHelper.IsNullOrEmpty(this.TipoLicencia_ID)) m_params.Add("TipoLicencia_ID", this.TipoLicencia_ID);
                if (!AppHelper.IsNullOrEmpty(this.FolioLicencia)) m_params.Add("FolioLicencia", this.FolioLicencia);
                if (!AppHelper.IsNullOrEmpty(this.VenceLicencia)) m_params.Add("VenceLicencia", this.VenceLicencia);
                if (!AppHelper.IsNullOrEmpty(this.Rfc_Aval)) m_params.Add("Rfc_Aval", this.Rfc_Aval);
                if (!AppHelper.IsNullOrEmpty(this.Apellidos_Aval)) m_params.Add("Apellidos_Aval", this.Apellidos_Aval);
                if (!AppHelper.IsNullOrEmpty(this.Nombre_Aval)) m_params.Add("Nombre_Aval", this.Nombre_Aval);
                if (!AppHelper.IsNullOrEmpty(this.Curp_Aval)) m_params.Add("Curp_Aval", this.Curp_Aval);
                if (!AppHelper.IsNullOrEmpty(this.Domicilio_Aval)) m_params.Add("Domicilio_Aval", this.Domicilio_Aval);
                if (!AppHelper.IsNullOrEmpty(this.Ciudad_Aval)) m_params.Add("Ciudad_Aval", this.Ciudad_Aval);
                if (!AppHelper.IsNullOrEmpty(this.Estado_Aval)) m_params.Add("Estado_Aval", this.Estado_Aval);
                if (!AppHelper.IsNullOrEmpty(this.CodigoPostal_Aval)) m_params.Add("CodigoPostal_Aval", this.CodigoPostal_Aval);
                if (!AppHelper.IsNullOrEmpty(this.Telefono_Aval)) m_params.Add("Telefono_Aval", this.Telefono_Aval);
                if (!AppHelper.IsNullOrEmpty(this.Email_Aval)) m_params.Add("Email_Aval", this.Email_Aval);
                if (!AppHelper.IsNullOrEmpty(this.Solicitud)) m_params.Add("Solicitud", this.Solicitud);
                if (!AppHelper.IsNullOrEmpty(this.ActaNacimiento)) m_params.Add("ActaNacimiento", this.ActaNacimiento);
                if (!AppHelper.IsNullOrEmpty(this.CredencialElector)) m_params.Add("CredencialElector", this.CredencialElector);
                if (!AppHelper.IsNullOrEmpty(this.CartaNoAntecedentes)) m_params.Add("CartaNoAntecedentes", this.CartaNoAntecedentes);
                if (!AppHelper.IsNullOrEmpty(this.ComprobanteDomicilio)) m_params.Add("ComprobanteDomicilio", this.ComprobanteDomicilio);
                if (!AppHelper.IsNullOrEmpty(this.CredencialElector_Aval)) m_params.Add("CredencialElector_Aval", this.CredencialElector_Aval);
                if (!AppHelper.IsNullOrEmpty(this.ComprobanteDomicilio_Aval)) m_params.Add("ComprobanteDomicilio_Aval", this.ComprobanteDomicilio_Aval);
                if (!AppHelper.IsNullOrEmpty(this.SaldoATratar)) m_params.Add("SaldoATratar", this.SaldoATratar);
                if (!AppHelper.IsNullOrEmpty(this.Cronocasco)) m_params.Add("Cronocasco", this.Cronocasco);
                if (!AppHelper.IsNullOrEmpty(this.TerminalDatos)) m_params.Add("TerminalDatos", this.TerminalDatos);
                if (!AppHelper.IsNullOrEmpty(this.BloquearConductor)) m_params.Add("BloquearConductor", this.BloquearConductor);
                if (!AppHelper.IsNullOrEmpty(this.MensajeACaja)) m_params.Add("MensajeACaja", this.MensajeACaja);
                if (!AppHelper.IsNullOrEmpty(this.Fecha)) m_params.Add("Fecha", this.Fecha);
                if (!AppHelper.IsNullOrEmpty(this.Usuario_ID)) m_params.Add("Usuario_ID", this.Usuario_ID);
                if (!AppHelper.IsNullOrEmpty(this.Referencia_ID)) m_params.Add("Referencia_ID", this.Referencia_ID);

                return DB.UpdateRow("Conductores", m_params, w_params);
            } // End Update

            public int Delete()
            {
                Hashtable w_params = new Hashtable();
                w_params.Add("Conductor_ID", this.Conductor_ID);

                return DB.DeleteRow("Conductores", w_params);
            } // End Delete

        } //End Class Conductores

	    public class Contratos
	    {

		    public Contratos()
		    {
		    }

		    public Contratos(int contrato_id, int empresa_id, int estacion_id, int tipocontrato_id, string descripcion, int? modelounidad_id, decimal montodiario, int diasdecobro_id, decimal fondoresidual, int conductor_id, int? unidad_id, int? numeroeconomico, int cuenta_id, int concepto_id, DateTime fechainicial, DateTime? fechafinal, int estatuscontrato_id, string comentarios, int? conductorcopia_id, bool cobropermanente, int? referencia_id)
		    {
			    this.Contrato_ID = contrato_id;
			    this.Empresa_ID = empresa_id;
			    this.Estacion_ID = estacion_id;
			    this.TipoContrato_ID = tipocontrato_id;
			    this.Descripcion = descripcion;
			    this.ModeloUnidad_ID = modelounidad_id;
			    this.MontoDiario = montodiario;
			    this.DiasDeCobro_ID = diasdecobro_id;
			    this.FondoResidual = fondoresidual;
			    this.Conductor_ID = conductor_id;
			    this.Unidad_ID = unidad_id;
			    this.NumeroEconomico = numeroeconomico;
			    this.Cuenta_ID = cuenta_id;
			    this.Concepto_ID = concepto_id;
			    this.FechaInicial = fechainicial;
			    this.FechaFinal = fechafinal;
			    this.EstatusContrato_ID = estatuscontrato_id;
			    this.Comentarios = comentarios;
			    this.ConductorCopia_ID = conductorcopia_id;
			    this.CobroPermanente = cobropermanente;
			    this.Referencia_ID = referencia_id;
		    }

		    private int _Contrato_ID;
		    public int Contrato_ID
		    {
			    get { return _Contrato_ID; }
			    set { _Contrato_ID = value; }
		    }

		    private int _Empresa_ID;
		    public int Empresa_ID
		    {
			    get { return _Empresa_ID; }
			    set { _Empresa_ID = value; }
		    }

		    private int _Estacion_ID;
		    public int Estacion_ID
		    {
			    get { return _Estacion_ID; }
			    set { _Estacion_ID = value; }
		    }

		    private int _TipoContrato_ID;
		    public int TipoContrato_ID
		    {
			    get { return _TipoContrato_ID; }
			    set { _TipoContrato_ID = value; }
		    }

		    private string _Descripcion;
		    public string Descripcion
		    {
			    get { return _Descripcion; }
			    set { _Descripcion = value; }
		    }

		    private int? _ModeloUnidad_ID;
		    public int? ModeloUnidad_ID
		    {
			    get { return _ModeloUnidad_ID; }
			    set { _ModeloUnidad_ID = value; }
		    }

		    private decimal _MontoDiario;
		    public decimal MontoDiario
		    {
			    get { return _MontoDiario; }
			    set { _MontoDiario = value; }
		    }

		    private int _DiasDeCobro_ID;
		    public int DiasDeCobro_ID
		    {
			    get { return _DiasDeCobro_ID; }
			    set { _DiasDeCobro_ID = value; }
		    }

		    private decimal _FondoResidual;
		    public decimal FondoResidual
		    {
			    get { return _FondoResidual; }
			    set { _FondoResidual = value; }
		    }

		    private int _Conductor_ID;
		    public int Conductor_ID
		    {
			    get { return _Conductor_ID; }
			    set { _Conductor_ID = value; }
		    }

		    private int? _Unidad_ID;
		    public int? Unidad_ID
		    {
			    get { return _Unidad_ID; }
			    set { _Unidad_ID = value; }
		    }

		    private int? _NumeroEconomico;
		    public int? NumeroEconomico
		    {
			    get { return _NumeroEconomico; }
			    set { _NumeroEconomico = value; }
		    }

		    private int _Cuenta_ID;
		    public int Cuenta_ID
		    {
			    get { return _Cuenta_ID; }
			    set { _Cuenta_ID = value; }
		    }

		    private int _Concepto_ID;
		    public int Concepto_ID
		    {
			    get { return _Concepto_ID; }
			    set { _Concepto_ID = value; }
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

		    private int _EstatusContrato_ID;
		    public int EstatusContrato_ID
		    {
			    get { return _EstatusContrato_ID; }
			    set { _EstatusContrato_ID = value; }
		    }

		    private string _Comentarios;
		    public string Comentarios
		    {
			    get { return _Comentarios; }
			    set { _Comentarios = value; }
		    }

		    private int? _ConductorCopia_ID;
		    public int? ConductorCopia_ID
		    {
			    get { return _ConductorCopia_ID; }
			    set { _ConductorCopia_ID = value; }
		    }

		    private bool _CobroPermanente;
		    public bool CobroPermanente
		    {
			    get { return _CobroPermanente; }
			    set { _CobroPermanente = value; }
		    }

		    private int? _Referencia_ID;
		    public int? Referencia_ID
		    {
			    get { return _Referencia_ID; }
			    set { _Referencia_ID = value; }
		    }

		    public int Create()
		    {
			    Hashtable m_params = new Hashtable();
			    m_params.Add("Empresa_ID", this.Empresa_ID);
			    m_params.Add("Estacion_ID", this.Estacion_ID);
			    m_params.Add("TipoContrato_ID", this.TipoContrato_ID);
			    m_params.Add("Descripcion", this.Descripcion);
			    if (!AppHelper.IsNullOrEmpty(this.ModeloUnidad_ID)) m_params.Add("ModeloUnidad_ID", this.ModeloUnidad_ID);
			    m_params.Add("MontoDiario", this.MontoDiario);
			    m_params.Add("DiasDeCobro_ID", this.DiasDeCobro_ID);
			    m_params.Add("FondoResidual", this.FondoResidual);
			    m_params.Add("Conductor_ID", this.Conductor_ID);
			    if (!AppHelper.IsNullOrEmpty(this.Unidad_ID)) m_params.Add("Unidad_ID", this.Unidad_ID);
			    if (!AppHelper.IsNullOrEmpty(this.NumeroEconomico)) m_params.Add("NumeroEconomico", this.NumeroEconomico);
			    m_params.Add("Cuenta_ID", this.Cuenta_ID);
			    m_params.Add("Concepto_ID", this.Concepto_ID);
			    m_params.Add("FechaInicial", this.FechaInicial);
			    if (!AppHelper.IsNullOrEmpty(this.FechaFinal)) m_params.Add("FechaFinal", this.FechaFinal);
			    m_params.Add("EstatusContrato_ID", this.EstatusContrato_ID);
			    if (!AppHelper.IsNullOrEmpty(this.Comentarios)) m_params.Add("Comentarios", this.Comentarios);
			    if (!AppHelper.IsNullOrEmpty(this.ConductorCopia_ID)) m_params.Add("ConductorCopia_ID", this.ConductorCopia_ID);
			    m_params.Add("CobroPermanente", this.CobroPermanente);
			    if (!AppHelper.IsNullOrEmpty(this.Referencia_ID)) m_params.Add("Referencia_ID", this.Referencia_ID);

			    return DB.InsertRow("Contratos", m_params);
		    } // End Create

		    public int Create(bool IsIdentityInsert)
		    {
			    if (!IsIdentityInsert) return Create();
			    Hashtable m_params = new Hashtable();
			    m_params.Add("Contrato_ID", this.Contrato_ID);
			    m_params.Add("Empresa_ID", this.Empresa_ID);
			    m_params.Add("Estacion_ID", this.Estacion_ID);
			    m_params.Add("TipoContrato_ID", this.TipoContrato_ID);
			    m_params.Add("Descripcion", this.Descripcion);
			    if (!AppHelper.IsNullOrEmpty(this.ModeloUnidad_ID)) m_params.Add("ModeloUnidad_ID", this.ModeloUnidad_ID);
			    m_params.Add("MontoDiario", this.MontoDiario);
			    m_params.Add("DiasDeCobro_ID", this.DiasDeCobro_ID);
			    m_params.Add("FondoResidual", this.FondoResidual);
			    m_params.Add("Conductor_ID", this.Conductor_ID);
			    if (!AppHelper.IsNullOrEmpty(this.Unidad_ID)) m_params.Add("Unidad_ID", this.Unidad_ID);
			    if (!AppHelper.IsNullOrEmpty(this.NumeroEconomico)) m_params.Add("NumeroEconomico", this.NumeroEconomico);
			    m_params.Add("Cuenta_ID", this.Cuenta_ID);
			    m_params.Add("Concepto_ID", this.Concepto_ID);
			    m_params.Add("FechaInicial", this.FechaInicial);
			    if (!AppHelper.IsNullOrEmpty(this.FechaFinal)) m_params.Add("FechaFinal", this.FechaFinal);
			    m_params.Add("EstatusContrato_ID", this.EstatusContrato_ID);
			    if (!AppHelper.IsNullOrEmpty(this.Comentarios)) m_params.Add("Comentarios", this.Comentarios);
			    if (!AppHelper.IsNullOrEmpty(this.ConductorCopia_ID)) m_params.Add("ConductorCopia_ID", this.ConductorCopia_ID);
			    m_params.Add("CobroPermanente", this.CobroPermanente);
			    if (!AppHelper.IsNullOrEmpty(this.Referencia_ID)) m_params.Add("Referencia_ID", this.Referencia_ID);

			    return DB.IdentityInsertRow("Contratos", m_params);
		    } // End Create

		    public static List<Contratos> Read()
		    {
			    List<Contratos> list = new List<Contratos>();
			    DataTable dt = DB.Select("Contratos");
			    foreach (DataRow dr in dt.Rows)
			    {
				    list.Add(new Contratos(Convert.ToInt32(dr["Contrato_ID"]), Convert.ToInt32(dr["Empresa_ID"]), Convert.ToInt32(dr["Estacion_ID"]), Convert.ToInt32(dr["TipoContrato_ID"]), Convert.ToString(dr["Descripcion"]), DB.GetNullableInt32(dr["ModeloUnidad_ID"]), Convert.ToDecimal(dr["MontoDiario"]), Convert.ToInt32(dr["DiasDeCobro_ID"]), Convert.ToDecimal(dr["FondoResidual"]), Convert.ToInt32(dr["Conductor_ID"]), DB.GetNullableInt32(dr["Unidad_ID"]), DB.GetNullableInt32(dr["NumeroEconomico"]), Convert.ToInt32(dr["Cuenta_ID"]), Convert.ToInt32(dr["Concepto_ID"]), Convert.ToDateTime(dr["FechaInicial"]), DB.GetNullableDateTime(dr["FechaFinal"]), Convert.ToInt32(dr["EstatusContrato_ID"]), Convert.ToString(dr["Comentarios"]), DB.GetNullableInt32(dr["ConductorCopia_ID"]), Convert.ToBoolean(dr["CobroPermanente"]), DB.GetNullableInt32(dr["Referencia_ID"])));
			    }

			    return list;
		    } // End Read

		    public static Contratos Read(int contrato_id)
		    {
			    Hashtable w_params = new Hashtable();
			    w_params.Add("Contrato_ID", contrato_id);
			    DataTable dt = DB.Select("Contratos", w_params);
			    if ( dt.Rows.Count == 0 )
			    {
				    throw new Exception("No existe Contratos con los criterios de búsqueda especificados.");
			    }
			    DataRow dr = dt.Rows[0];
			    return new Contratos(Convert.ToInt32(dr["Contrato_ID"]), Convert.ToInt32(dr["Empresa_ID"]), Convert.ToInt32(dr["Estacion_ID"]), Convert.ToInt32(dr["TipoContrato_ID"]), Convert.ToString(dr["Descripcion"]), DB.GetNullableInt32(dr["ModeloUnidad_ID"]), Convert.ToDecimal(dr["MontoDiario"]), Convert.ToInt32(dr["DiasDeCobro_ID"]), Convert.ToDecimal(dr["FondoResidual"]), Convert.ToInt32(dr["Conductor_ID"]), DB.GetNullableInt32(dr["Unidad_ID"]), DB.GetNullableInt32(dr["NumeroEconomico"]), Convert.ToInt32(dr["Cuenta_ID"]), Convert.ToInt32(dr["Concepto_ID"]), Convert.ToDateTime(dr["FechaInicial"]), DB.GetNullableDateTime(dr["FechaFinal"]), Convert.ToInt32(dr["EstatusContrato_ID"]), Convert.ToString(dr["Comentarios"]), DB.GetNullableInt32(dr["ConductorCopia_ID"]), Convert.ToBoolean(dr["CobroPermanente"]), DB.GetNullableInt32(dr["Referencia_ID"]));
		    } // End Read

		    public static Contratos Read(params KeyValuePair<string,object>[] args)		{
			    DataTable dt = DB.Read("Contratos", args);
			    if ( dt.Rows.Count == 0 )
			    {
				    return null;
			    }
			    DataRow dr = dt.Rows[0];
			    return new Contratos(Convert.ToInt32(dr["Contrato_ID"]), Convert.ToInt32(dr["Empresa_ID"]), Convert.ToInt32(dr["Estacion_ID"]), Convert.ToInt32(dr["TipoContrato_ID"]), Convert.ToString(dr["Descripcion"]), DB.GetNullableInt32(dr["ModeloUnidad_ID"]), Convert.ToDecimal(dr["MontoDiario"]), Convert.ToInt32(dr["DiasDeCobro_ID"]), Convert.ToDecimal(dr["FondoResidual"]), Convert.ToInt32(dr["Conductor_ID"]), DB.GetNullableInt32(dr["Unidad_ID"]), DB.GetNullableInt32(dr["NumeroEconomico"]), Convert.ToInt32(dr["Cuenta_ID"]), Convert.ToInt32(dr["Concepto_ID"]), Convert.ToDateTime(dr["FechaInicial"]), DB.GetNullableDateTime(dr["FechaFinal"]), Convert.ToInt32(dr["EstatusContrato_ID"]), Convert.ToString(dr["Comentarios"]), DB.GetNullableInt32(dr["ConductorCopia_ID"]), Convert.ToBoolean(dr["CobroPermanente"]), DB.GetNullableInt32(dr["Referencia_ID"]));
		    } // End Read

            public static List<Contratos> ReadList(params KeyValuePair<string, object>[] args)
            {
                DataTable dt = DB.Read("Contratos", args);
                List<Contratos> list = new List<Contratos>();
                if (dt.Rows.Count == 0)
                {
                    return null;
                }

                foreach (DataRow dr in dt.Rows)
                { 
                    list.Add(
                        new Contratos(
                            Convert.ToInt32(dr["Contrato_ID"]), 
                            Convert.ToInt32(dr["Empresa_ID"]), 
                            Convert.ToInt32(dr["Estacion_ID"]), 
                            Convert.ToInt32(dr["TipoContrato_ID"]),
                            Convert.ToString(dr["Descripcion"]), 
                            DB.GetNullableInt32(dr["ModeloUnidad_ID"]), 
                            Convert.ToDecimal(dr["MontoDiario"]), 
                            Convert.ToInt32(dr["DiasDeCobro_ID"]),
                            Convert.ToDecimal(dr["FondoResidual"]), 
                            Convert.ToInt32(dr["Conductor_ID"]), 
                            DB.GetNullableInt32(dr["Unidad_ID"]), 
                            DB.GetNullableInt32(dr["NumeroEconomico"]), 
                            Convert.ToInt32(dr["Cuenta_ID"]), 
                            Convert.ToInt32(dr["Concepto_ID"]), 
                            Convert.ToDateTime(dr["FechaInicial"]), 
                            DB.GetNullableDateTime(dr["FechaFinal"]), 
                            Convert.ToInt32(dr["EstatusContrato_ID"]), 
                            Convert.ToString(dr["Comentarios"]), 
                            DB.GetNullableInt32(dr["ConductorCopia_ID"]), 
                            Convert.ToBoolean(dr["CobroPermanente"]),
                            DB.GetNullableInt32(dr["Referencia_ID"]))
                            );
                }

                return list;
            } // End Read

		    public static bool Read(out Contratos contratos, int top, string filter, string sort, params KeyValuePair<string, object>[] args)		{
			    DataTable dt = DB.Read("Contratos", top, filter, sort, args);
			    if ( dt.Rows.Count == 0 )
			    {
				    contratos = null; 
				    return false;
			    }
			    DataRow dr = dt.Rows[0];
			    contratos = new Contratos(Convert.ToInt32(dr["Contrato_ID"]), Convert.ToInt32(dr["Empresa_ID"]), Convert.ToInt32(dr["Estacion_ID"]), Convert.ToInt32(dr["TipoContrato_ID"]), Convert.ToString(dr["Descripcion"]), DB.GetNullableInt32(dr["ModeloUnidad_ID"]), Convert.ToDecimal(dr["MontoDiario"]), Convert.ToInt32(dr["DiasDeCobro_ID"]), Convert.ToDecimal(dr["FondoResidual"]), Convert.ToInt32(dr["Conductor_ID"]), DB.GetNullableInt32(dr["Unidad_ID"]), DB.GetNullableInt32(dr["NumeroEconomico"]), Convert.ToInt32(dr["Cuenta_ID"]), Convert.ToInt32(dr["Concepto_ID"]), Convert.ToDateTime(dr["FechaInicial"]), DB.GetNullableDateTime(dr["FechaFinal"]), Convert.ToInt32(dr["EstatusContrato_ID"]), Convert.ToString(dr["Comentarios"]), DB.GetNullableInt32(dr["ConductorCopia_ID"]), Convert.ToBoolean(dr["CobroPermanente"]), DB.GetNullableInt32(dr["Referencia_ID"]));
			    return true;
		    } // End Read

		    public static DataTable ReadDataTable()
		    {
			    return DB.Select("Contratos");
		    } // End Read

		    public static DataTable ReadDataTable(int contrato_id)
		    {
			    Hashtable w_params = new Hashtable();
			    w_params.Add("Contrato_ID", contrato_id);
			    return DB.Select("Contratos", w_params);
		    } // End Read

            public int Update(params string[] fields)
            {
                if (fields.Length == 0)
                {
                    throw new Exception("Debe especificar los campos");
                }

                Hashtable m_params = new Hashtable();
                Hashtable w_params = new Hashtable();
                w_params.Add("Contrato_ID", this.Contrato_ID);

                foreach (string field in fields)
                {
                    m_params.Add(field, this.GetType().GetProperty(field).GetValue(this, null));
                }

                return DB.UpdateRow("Contratos", m_params, w_params);
            }

		    public int Update()
		    {
			    Hashtable m_params = new Hashtable();
			    Hashtable w_params = new Hashtable();
			    w_params.Add("Contrato_ID", this.Contrato_ID);
			    m_params.Add("Empresa_ID", this.Empresa_ID);
			    m_params.Add("Estacion_ID", this.Estacion_ID);
			    m_params.Add("TipoContrato_ID", this.TipoContrato_ID);
			    m_params.Add("Descripcion", this.Descripcion);
			    if (!AppHelper.IsNullOrEmpty(this.ModeloUnidad_ID)) m_params.Add("ModeloUnidad_ID", this.ModeloUnidad_ID);
			    m_params.Add("MontoDiario", this.MontoDiario);
			    m_params.Add("DiasDeCobro_ID", this.DiasDeCobro_ID);
			    m_params.Add("FondoResidual", this.FondoResidual);
			    m_params.Add("Conductor_ID", this.Conductor_ID);
			    if (!AppHelper.IsNullOrEmpty(this.Unidad_ID)) m_params.Add("Unidad_ID", this.Unidad_ID);
			    if (!AppHelper.IsNullOrEmpty(this.NumeroEconomico)) m_params.Add("NumeroEconomico", this.NumeroEconomico);
			    m_params.Add("Cuenta_ID", this.Cuenta_ID);
			    m_params.Add("Concepto_ID", this.Concepto_ID);
			    m_params.Add("FechaInicial", this.FechaInicial);
			    if (!AppHelper.IsNullOrEmpty(this.FechaFinal)) m_params.Add("FechaFinal", this.FechaFinal);
			    m_params.Add("EstatusContrato_ID", this.EstatusContrato_ID);
			    if (!AppHelper.IsNullOrEmpty(this.Comentarios)) m_params.Add("Comentarios", this.Comentarios);
			    if (!AppHelper.IsNullOrEmpty(this.ConductorCopia_ID)) m_params.Add("ConductorCopia_ID", this.ConductorCopia_ID);
			    m_params.Add("CobroPermanente", this.CobroPermanente);
			    if (!AppHelper.IsNullOrEmpty(this.Referencia_ID)) m_params.Add("Referencia_ID", this.Referencia_ID);

			    return DB.UpdateRow("Contratos", m_params, w_params);
		    } // End Update

		    public int Delete()
		    {
			    Hashtable w_params = new Hashtable();
			    w_params.Add("Contrato_ID", this.Contrato_ID);

			    return DB.DeleteRow("Contratos", w_params);
		    } // End Delete

	    } //End Class Contratos

        public class ContratosLiquidados
        {

            public ContratosLiquidados()
            {
            }

            public ContratosLiquidados(int contratoliquidado_id, int contrato_id, int conductor_id, int unidad_id, int locacionunidad_id, int estatusconductor_id, int estatuscontrato_id, string comentarios, DateTime fecha, string usuario_id)
            {
                this.ContratoLiquidado_ID = contratoliquidado_id;
                this.Contrato_ID = contrato_id;
                this.Conductor_ID = conductor_id;
                this.Unidad_ID = unidad_id;
                this.LocacionUnidad_ID = locacionunidad_id;
                this.EstatusConductor_ID = estatusconductor_id;
                this.EstatusContrato_ID = estatuscontrato_id;
                this.Comentarios = comentarios;
                this.Fecha = fecha;
                this.Usuario_ID = usuario_id;
            }

            private int _ContratoLiquidado_ID;
            public int ContratoLiquidado_ID
            {
                get { return _ContratoLiquidado_ID; }
                set { _ContratoLiquidado_ID = value; }
            }

            private int _Contrato_ID;
            public int Contrato_ID
            {
                get { return _Contrato_ID; }
                set { _Contrato_ID = value; }
            }

            private int _Conductor_ID;
            public int Conductor_ID
            {
                get { return _Conductor_ID; }
                set { _Conductor_ID = value; }
            }

            private int _Unidad_ID;
            public int Unidad_ID
            {
                get { return _Unidad_ID; }
                set { _Unidad_ID = value; }
            }

            private int _LocacionUnidad_ID;
            public int LocacionUnidad_ID
            {
                get { return _LocacionUnidad_ID; }
                set { _LocacionUnidad_ID = value; }
            }

            private int _EstatusConductor_ID;
            public int EstatusConductor_ID
            {
                get { return _EstatusConductor_ID; }
                set { _EstatusConductor_ID = value; }
            }

            private int _EstatusContrato_ID;
            public int EstatusContrato_ID
            {
                get { return _EstatusContrato_ID; }
                set { _EstatusContrato_ID = value; }
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

            private string _Usuario_ID;
            public string Usuario_ID
            {
                get { return _Usuario_ID; }
                set { _Usuario_ID = value; }
            }

            public int Create()
            {
                Hashtable m_params = new Hashtable();
                m_params.Add("Contrato_ID", this.Contrato_ID);
                m_params.Add("Conductor_ID", this.Conductor_ID);
                m_params.Add("Unidad_ID", this.Unidad_ID);
                m_params.Add("LocacionUnidad_ID", this.LocacionUnidad_ID);
                m_params.Add("EstatusConductor_ID", this.EstatusConductor_ID);
                m_params.Add("EstatusContrato_ID", this.EstatusContrato_ID);
                m_params.Add("Comentarios", this.Comentarios);
                m_params.Add("Fecha", this.Fecha);
                m_params.Add("Usuario_ID", this.Usuario_ID);

                return DB.InsertRow("ContratosLiquidados", m_params);
            } // End Create

            public int Create(bool IsIdentityInsert)
            {
                if (!IsIdentityInsert) return Create();
                Hashtable m_params = new Hashtable();
                m_params.Add("ContratoLiquidado_ID", this.ContratoLiquidado_ID);
                m_params.Add("Contrato_ID", this.Contrato_ID);
                m_params.Add("Conductor_ID", this.Conductor_ID);
                m_params.Add("Unidad_ID", this.Unidad_ID);
                m_params.Add("LocacionUnidad_ID", this.LocacionUnidad_ID);
                m_params.Add("EstatusConductor_ID", this.EstatusConductor_ID);
                m_params.Add("EstatusContrato_ID", this.EstatusContrato_ID);
                m_params.Add("Comentarios", this.Comentarios);
                m_params.Add("Fecha", this.Fecha);
                m_params.Add("Usuario_ID", this.Usuario_ID);

                return DB.IdentityInsertRow("ContratosLiquidados", m_params);
            } // End Create

            public static List<ContratosLiquidados> Read()
            {
                List<ContratosLiquidados> list = new List<ContratosLiquidados>();
                DataTable dt = DB.Select("ContratosLiquidados");
                foreach (DataRow dr in dt.Rows)
                {
                    list.Add(new ContratosLiquidados(Convert.ToInt32(dr["ContratoLiquidado_ID"]), Convert.ToInt32(dr["Contrato_ID"]), Convert.ToInt32(dr["Conductor_ID"]), Convert.ToInt32(dr["Unidad_ID"]), Convert.ToInt32(dr["LocacionUnidad_ID"]), Convert.ToInt32(dr["EstatusConductor_ID"]), Convert.ToInt32(dr["EstatusContrato_ID"]), Convert.ToString(dr["Comentarios"]), Convert.ToDateTime(dr["Fecha"]), Convert.ToString(dr["Usuario_ID"])));
                }

                return list;
            } // End Read

            public static ContratosLiquidados Read(int contratoliquidado_id)
            {
                Hashtable w_params = new Hashtable();
                w_params.Add("ContratoLiquidado_ID", contratoliquidado_id);
                DataTable dt = DB.Select("ContratosLiquidados", w_params);
                if (dt.Rows.Count == 0)
                {
                    throw new Exception("No existe ContratosLiquidados con los criterios de búsqueda especificados.");
                }
                DataRow dr = dt.Rows[0];
                return new ContratosLiquidados(Convert.ToInt32(dr["ContratoLiquidado_ID"]), Convert.ToInt32(dr["Contrato_ID"]), Convert.ToInt32(dr["Conductor_ID"]), Convert.ToInt32(dr["Unidad_ID"]), Convert.ToInt32(dr["LocacionUnidad_ID"]), Convert.ToInt32(dr["EstatusConductor_ID"]), Convert.ToInt32(dr["EstatusContrato_ID"]), Convert.ToString(dr["Comentarios"]), Convert.ToDateTime(dr["Fecha"]), Convert.ToString(dr["Usuario_ID"]));
            } // End Read

            public static ContratosLiquidados Read(params KeyValuePair<string, object>[] args)
            {
                DataTable dt = DB.Read("ContratosLiquidados", args);
                if (dt.Rows.Count == 0)
                {
                    return null;
                }
                DataRow dr = dt.Rows[0];
                return new ContratosLiquidados(Convert.ToInt32(dr["ContratoLiquidado_ID"]), Convert.ToInt32(dr["Contrato_ID"]), Convert.ToInt32(dr["Conductor_ID"]), Convert.ToInt32(dr["Unidad_ID"]), Convert.ToInt32(dr["LocacionUnidad_ID"]), Convert.ToInt32(dr["EstatusConductor_ID"]), Convert.ToInt32(dr["EstatusContrato_ID"]), Convert.ToString(dr["Comentarios"]), Convert.ToDateTime(dr["Fecha"]), Convert.ToString(dr["Usuario_ID"]));
            } // End Read

            public static bool Read(out ContratosLiquidados contratosliquidados, int top, string filter, string sort, params KeyValuePair<string, object>[] args)
            {
                DataTable dt = DB.Read("ContratosLiquidados", top, filter, sort, args);
                if (dt.Rows.Count == 0)
                {
                    contratosliquidados = null;
                    return false;
                }
                DataRow dr = dt.Rows[0];
                contratosliquidados = new ContratosLiquidados(Convert.ToInt32(dr["ContratoLiquidado_ID"]), Convert.ToInt32(dr["Contrato_ID"]), Convert.ToInt32(dr["Conductor_ID"]), Convert.ToInt32(dr["Unidad_ID"]), Convert.ToInt32(dr["LocacionUnidad_ID"]), Convert.ToInt32(dr["EstatusConductor_ID"]), Convert.ToInt32(dr["EstatusContrato_ID"]), Convert.ToString(dr["Comentarios"]), Convert.ToDateTime(dr["Fecha"]), Convert.ToString(dr["Usuario_ID"]));
                return true;
            } // End Read

            public static DataTable ReadDataTable()
            {
                return DB.Select("ContratosLiquidados");
            } // End Read

            public static DataTable ReadDataTable(int contratoliquidado_id)
            {
                Hashtable w_params = new Hashtable();
                w_params.Add("ContratoLiquidado_ID", contratoliquidado_id);
                return DB.Select("ContratosLiquidados", w_params);
            } // End Read

            public int Update()
            {
                Hashtable m_params = new Hashtable();
                Hashtable w_params = new Hashtable();
                w_params.Add("ContratoLiquidado_ID", this.ContratoLiquidado_ID);
                m_params.Add("Contrato_ID", this.Contrato_ID);
                m_params.Add("Conductor_ID", this.Conductor_ID);
                m_params.Add("Unidad_ID", this.Unidad_ID);
                m_params.Add("LocacionUnidad_ID", this.LocacionUnidad_ID);
                m_params.Add("EstatusConductor_ID", this.EstatusConductor_ID);
                m_params.Add("EstatusContrato_ID", this.EstatusContrato_ID);
                m_params.Add("Comentarios", this.Comentarios);
                m_params.Add("Fecha", this.Fecha);
                m_params.Add("Usuario_ID", this.Usuario_ID);

                return DB.UpdateRow("ContratosLiquidados", m_params, w_params);
            } // End Update

            public int Delete()
            {
                Hashtable w_params = new Hashtable();
                w_params.Add("ContratoLiquidado_ID", this.ContratoLiquidado_ID);

                return DB.DeleteRow("ContratosLiquidados", w_params);
            } // End Delete

        } //End Class ContratosLiquidados

        public class CuentaCajas
        {

            public CuentaCajas()
            {
            }

            public CuentaCajas(int cuentacaja_id, int? sesion_id, int empresa_id, int estacion_id, int caja_id, int? ticket_id, int cuenta_id, int? concepto_id, decimal cargo, decimal abono, decimal saldo, string comentarios, DateTime fecha, string usuario_id, int? referencia_id)
            {
                this.CuentaCaja_ID = cuentacaja_id;
                this.Sesion_ID = sesion_id;
                this.Empresa_ID = empresa_id;
                this.Estacion_ID = estacion_id;
                this.Caja_ID = caja_id;
                this.Ticket_ID = ticket_id;
                this.Cuenta_ID = cuenta_id;
                this.Concepto_ID = concepto_id;
                this.Cargo = cargo;
                this.Abono = abono;
                this.Saldo = saldo;
                this.Comentarios = comentarios;
                this.Fecha = fecha;
                this.Usuario_ID = usuario_id;
                this.Referencia_ID = referencia_id;
            }

            private int _CuentaCaja_ID;
            public int CuentaCaja_ID
            {
                get { return _CuentaCaja_ID; }
                set { _CuentaCaja_ID = value; }
            }

            private int? _Sesion_ID;
            public int? Sesion_ID
            {
                get { return _Sesion_ID; }
                set { _Sesion_ID = value; }
            }

            private int _Empresa_ID;
            public int Empresa_ID
            {
                get { return _Empresa_ID; }
                set { _Empresa_ID = value; }
            }

            private int _Estacion_ID;
            public int Estacion_ID
            {
                get { return _Estacion_ID; }
                set { _Estacion_ID = value; }
            }

            private int _Caja_ID;
            public int Caja_ID
            {
                get { return _Caja_ID; }
                set { _Caja_ID = value; }
            }

            private int? _Ticket_ID;
            public int? Ticket_ID
            {
                get { return _Ticket_ID; }
                set { _Ticket_ID = value; }
            }

            private int _Cuenta_ID;
            public int Cuenta_ID
            {
                get { return _Cuenta_ID; }
                set { _Cuenta_ID = value; }
            }

            private int? _Concepto_ID;
            public int? Concepto_ID
            {
                get { return _Concepto_ID; }
                set { _Concepto_ID = value; }
            }

            private decimal _Cargo;
            public decimal Cargo
            {
                get { return _Cargo; }
                set { _Cargo = value; }
            }

            private decimal _Abono;
            public decimal Abono
            {
                get { return _Abono; }
                set { _Abono = value; }
            }

            private decimal _Saldo;
            public decimal Saldo
            {
                get { return _Saldo; }
                set { _Saldo = value; }
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

            private string _Usuario_ID;
            public string Usuario_ID
            {
                get { return _Usuario_ID; }
                set { _Usuario_ID = value; }
            }

            private int? _Referencia_ID;
            public int? Referencia_ID
            {
                get { return _Referencia_ID; }
                set { _Referencia_ID = value; }
            }

            private void CalcularSaldo()
            {
                this.Saldo = 0;
                if (this.Sesion_ID != null)
                {
                    string sqlQry = "SELECT ISNULL(SUM(Abono - Cargo),0) Saldo FROM CuentaCajas WHERE Sesion_ID = @Sesion_ID AND Empresa_ID = @Empresa_ID";

                    this.Saldo =
                        Convert.ToDecimal(
                            DB.ReadScalar(sqlQry, DB.Param("@Sesion_ID", this.Sesion_ID),
                                DB.Param("@Empresa_ID", Empresa_ID))) +
                                    this.Abono - this.Cargo;
                }
            }

            public int Create()
            {

                CalcularSaldo();

                Hashtable m_params = new Hashtable();
                if (!AppHelper.IsNullOrEmpty(this.Sesion_ID)) m_params.Add("Sesion_ID", this.Sesion_ID);
                m_params.Add("Empresa_ID", this.Empresa_ID);
                m_params.Add("Estacion_ID", this.Estacion_ID);
                m_params.Add("Caja_ID", this.Caja_ID);
                if (!AppHelper.IsNullOrEmpty(this.Ticket_ID)) m_params.Add("Ticket_ID", this.Ticket_ID);
                m_params.Add("Cuenta_ID", this.Cuenta_ID);
                if (!AppHelper.IsNullOrEmpty(this.Concepto_ID)) m_params.Add("Concepto_ID", this.Concepto_ID);
                m_params.Add("Cargo", this.Cargo);
                m_params.Add("Abono", this.Abono);
                m_params.Add("Saldo", this.Saldo);
                if (!AppHelper.IsNullOrEmpty(this.Comentarios)) m_params.Add("Comentarios", this.Comentarios);
                m_params.Add("Fecha", this.Fecha);
                m_params.Add("Usuario_ID", this.Usuario_ID);
                if (!AppHelper.IsNullOrEmpty(this.Referencia_ID)) m_params.Add("Referencia_ID", this.Referencia_ID);

                return DB.InsertRow("CuentaCajas", m_params);
            } // End Create

            public int Create(bool IsIdentityInsert)
            {
                if (!IsIdentityInsert) return Create();
                Hashtable m_params = new Hashtable();
                m_params.Add("CuentaCaja_ID", this.CuentaCaja_ID);
                if (!AppHelper.IsNullOrEmpty(this.Sesion_ID)) m_params.Add("Sesion_ID", this.Sesion_ID);
                m_params.Add("Empresa_ID", this.Empresa_ID);
                m_params.Add("Estacion_ID", this.Estacion_ID);
                m_params.Add("Caja_ID", this.Caja_ID);
                if (!AppHelper.IsNullOrEmpty(this.Ticket_ID)) m_params.Add("Ticket_ID", this.Ticket_ID);
                m_params.Add("Cuenta_ID", this.Cuenta_ID);
                if (!AppHelper.IsNullOrEmpty(this.Concepto_ID)) m_params.Add("Concepto_ID", this.Concepto_ID);
                m_params.Add("Cargo", this.Cargo);
                m_params.Add("Abono", this.Abono);
                m_params.Add("Saldo", this.Saldo);
                if (!AppHelper.IsNullOrEmpty(this.Comentarios)) m_params.Add("Comentarios", this.Comentarios);
                m_params.Add("Fecha", this.Fecha);
                m_params.Add("Usuario_ID", this.Usuario_ID);
                if (!AppHelper.IsNullOrEmpty(this.Referencia_ID)) m_params.Add("Referencia_ID", this.Referencia_ID);

                return DB.IdentityInsertRow("CuentaCajas", m_params);
            } // End Create

            public static List<CuentaCajas> Read()
            {
                List<CuentaCajas> list = new List<CuentaCajas>();
                DataTable dt = DB.Select("CuentaCajas");
                foreach (DataRow dr in dt.Rows)
                {
                    list.Add(new CuentaCajas(Convert.ToInt32(dr["CuentaCaja_ID"]), DB.GetNullableInt32(dr["Sesion_ID"]), Convert.ToInt32(dr["Empresa_ID"]), Convert.ToInt32(dr["Estacion_ID"]), Convert.ToInt32(dr["Caja_ID"]), DB.GetNullableInt32(dr["Ticket_ID"]), Convert.ToInt32(dr["Cuenta_ID"]), DB.GetNullableInt32(dr["Concepto_ID"]), Convert.ToDecimal(dr["Cargo"]), Convert.ToDecimal(dr["Abono"]), Convert.ToDecimal(dr["Saldo"]), Convert.ToString(dr["Comentarios"]), Convert.ToDateTime(dr["Fecha"]), Convert.ToString(dr["Usuario_ID"]), DB.GetNullableInt32(dr["Referencia_ID"])));
                }

                return list;
            } // End Read

            public static CuentaCajas Read(int cuentacaja_id)
            {
                Hashtable w_params = new Hashtable();
                w_params.Add("CuentaCaja_ID", cuentacaja_id);
                DataTable dt = DB.Select("CuentaCajas", w_params);
                if (dt.Rows.Count == 0)
                {
                    throw new Exception("No existe CuentaCajas con los criterios de búsqueda especificados.");
                }
                DataRow dr = dt.Rows[0];
                return new CuentaCajas(Convert.ToInt32(dr["CuentaCaja_ID"]), DB.GetNullableInt32(dr["Sesion_ID"]), Convert.ToInt32(dr["Empresa_ID"]), Convert.ToInt32(dr["Estacion_ID"]), Convert.ToInt32(dr["Caja_ID"]), DB.GetNullableInt32(dr["Ticket_ID"]), Convert.ToInt32(dr["Cuenta_ID"]), DB.GetNullableInt32(dr["Concepto_ID"]), Convert.ToDecimal(dr["Cargo"]), Convert.ToDecimal(dr["Abono"]), Convert.ToDecimal(dr["Saldo"]), Convert.ToString(dr["Comentarios"]), Convert.ToDateTime(dr["Fecha"]), Convert.ToString(dr["Usuario_ID"]), DB.GetNullableInt32(dr["Referencia_ID"]));
            } // End Read

            public static CuentaCajas Read(params KeyValuePair<string, object>[] args)
            {
                DataTable dt = DB.Read("CuentaCajas", args);
                if (dt.Rows.Count == 0)
                {
                    return null;
                }
                DataRow dr = dt.Rows[0];
                return new CuentaCajas(Convert.ToInt32(dr["CuentaCaja_ID"]), DB.GetNullableInt32(dr["Sesion_ID"]), Convert.ToInt32(dr["Empresa_ID"]), Convert.ToInt32(dr["Estacion_ID"]), Convert.ToInt32(dr["Caja_ID"]), DB.GetNullableInt32(dr["Ticket_ID"]), Convert.ToInt32(dr["Cuenta_ID"]), DB.GetNullableInt32(dr["Concepto_ID"]), Convert.ToDecimal(dr["Cargo"]), Convert.ToDecimal(dr["Abono"]), Convert.ToDecimal(dr["Saldo"]), Convert.ToString(dr["Comentarios"]), Convert.ToDateTime(dr["Fecha"]), Convert.ToString(dr["Usuario_ID"]), DB.GetNullableInt32(dr["Referencia_ID"]));
            } // End Read

            public static bool Read(out CuentaCajas cuentacajas, int top, string filter, string sort, params KeyValuePair<string, object>[] args)
            {
                DataTable dt = DB.Read("CuentaCajas", top, filter, sort, args);
                if (dt.Rows.Count == 0)
                {
                    cuentacajas = null;
                    return false;
                }
                DataRow dr = dt.Rows[0];
                cuentacajas = new CuentaCajas(Convert.ToInt32(dr["CuentaCaja_ID"]), DB.GetNullableInt32(dr["Sesion_ID"]), Convert.ToInt32(dr["Empresa_ID"]), Convert.ToInt32(dr["Estacion_ID"]), Convert.ToInt32(dr["Caja_ID"]), DB.GetNullableInt32(dr["Ticket_ID"]), Convert.ToInt32(dr["Cuenta_ID"]), DB.GetNullableInt32(dr["Concepto_ID"]), Convert.ToDecimal(dr["Cargo"]), Convert.ToDecimal(dr["Abono"]), Convert.ToDecimal(dr["Saldo"]), Convert.ToString(dr["Comentarios"]), Convert.ToDateTime(dr["Fecha"]), Convert.ToString(dr["Usuario_ID"]), DB.GetNullableInt32(dr["Referencia_ID"]));
                return true;
            } // End Read

            public int Update()
            {
                CalcularSaldo();

                Hashtable m_params = new Hashtable();
                Hashtable w_params = new Hashtable();
                w_params.Add("CuentaCaja_ID", this.CuentaCaja_ID);
                if (!AppHelper.IsNullOrEmpty(this.Sesion_ID)) m_params.Add("Sesion_ID", this.Sesion_ID);
                m_params.Add("Empresa_ID", this.Empresa_ID);
                m_params.Add("Estacion_ID", this.Estacion_ID);
                m_params.Add("Caja_ID", this.Caja_ID);
                if (!AppHelper.IsNullOrEmpty(this.Ticket_ID)) m_params.Add("Ticket_ID", this.Ticket_ID);
                m_params.Add("Cuenta_ID", this.Cuenta_ID);
                if (!AppHelper.IsNullOrEmpty(this.Concepto_ID)) m_params.Add("Concepto_ID", this.Concepto_ID);
                m_params.Add("Cargo", this.Cargo);
                m_params.Add("Abono", this.Abono);
                m_params.Add("Saldo", this.Saldo);
                if (!AppHelper.IsNullOrEmpty(this.Comentarios)) m_params.Add("Comentarios", this.Comentarios);
                m_params.Add("Fecha", this.Fecha);
                m_params.Add("Usuario_ID", this.Usuario_ID);
                if (!AppHelper.IsNullOrEmpty(this.Referencia_ID)) m_params.Add("Referencia_ID", this.Referencia_ID);

                return DB.UpdateRow("CuentaCajas", m_params, w_params);
            } // End Update

            public int Delete()
            {
                Hashtable w_params = new Hashtable();
                w_params.Add("CuentaCaja_ID", this.CuentaCaja_ID);

                return DB.DeleteRow("CuentaCajas", w_params);
            } // End Delete

        } //End Class CuentaCajas

        public class CuentaConductores
        {

            public CuentaConductores()
            {
            }

            public CuentaConductores(int cuentaconductor_id, int empresa_id, int? estacion_id, int conductor_id, int? unidad_id, int? caja_id, int? ticket_id, int cuenta_id, int? concepto_id, decimal cargo, decimal abono, decimal saldo, string comentarios, DateTime fecha, string usuario_id, int? referencia_id)
            {
                this.CuentaConductor_ID = cuentaconductor_id;
                this.Empresa_ID = empresa_id;
                this.Estacion_ID = estacion_id;
                this.Conductor_ID = conductor_id;
                this.Unidad_ID = unidad_id;
                this.Caja_ID = caja_id;
                this.Ticket_ID = ticket_id;
                this.Cuenta_ID = cuenta_id;
                this.Concepto_ID = concepto_id;
                this.Cargo = cargo;
                this.Abono = abono;
                this.Saldo = saldo;
                this.Comentarios = comentarios;
                this.Fecha = fecha;
                this.Usuario_ID = usuario_id;
                this.Referencia_ID = referencia_id;
            }

            private int _CuentaConductor_ID;
            public int CuentaConductor_ID
            {
                get { return _CuentaConductor_ID; }
                set { _CuentaConductor_ID = value; }
            }

            private int _Empresa_ID;
            public int Empresa_ID
            {
                get { return _Empresa_ID; }
                set { _Empresa_ID = value; }
            }

            private int? _Estacion_ID;
            public int? Estacion_ID
            {
                get { return _Estacion_ID; }
                set { _Estacion_ID = value; }
            }

            private int _Conductor_ID;
            public int Conductor_ID
            {
                get { return _Conductor_ID; }
                set { _Conductor_ID = value; }
            }

            private int? _Unidad_ID;
            public int? Unidad_ID
            {
                get { return _Unidad_ID; }
                set { _Unidad_ID = value; }
            }

            private int? _Caja_ID;
            public int? Caja_ID
            {
                get { return _Caja_ID; }
                set { _Caja_ID = value; }
            }

            private int? _Ticket_ID;
            public int? Ticket_ID
            {
                get { return _Ticket_ID; }
                set { _Ticket_ID = value; }
            }

            private int _Cuenta_ID;
            public int Cuenta_ID
            {
                get { return _Cuenta_ID; }
                set { _Cuenta_ID = value; }
            }

            private int? _Concepto_ID;
            public int? Concepto_ID
            {
                get { return _Concepto_ID; }
                set { _Concepto_ID = value; }
            }

            private decimal _Cargo;
            public decimal Cargo
            {
                get { return _Cargo; }
                set { _Cargo = value; }
            }

            private decimal _Abono;
            public decimal Abono
            {
                get { return _Abono; }
                set { _Abono = value; }
            }

            private decimal _Saldo;
            public decimal Saldo
            {
                get { return _Saldo; }
                set { _Saldo = value; }
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

            private string _Usuario_ID;
            public string Usuario_ID
            {
                get { return _Usuario_ID; }
                set { _Usuario_ID = value; }
            }

            private int? _Referencia_ID;
            public int? Referencia_ID
            {
                get { return _Referencia_ID; }
                set { _Referencia_ID = value; }
            }

            private void CalcularSaldo()
            {
                string sqlQry = @"SELECT ISNULL(SUM(Abono - Cargo),0) Saldo FROM CuentaConductores WHERE Conductor_ID = @Conductor_ID
AND Empresa_ID = @Empresa_ID AND Cuenta_ID = @Cuenta_ID
AND Fecha <= @Fecha";

                this.Saldo =
                    Convert.ToDecimal(
                        DB.ReadScalar(
                            sqlQry, 
                            DB.Param("@Conductor_ID", this.Conductor_ID),
                            DB.Param("@Empresa_ID", this.Empresa_ID), 
                            DB.Param("@Cuenta_ID", this.Cuenta_ID),
                            DB.Param("@Fecha", this.Fecha)
                        )
                    ) + this.Abono - this.Cargo;
            }

            public int Create()
            {
                CalcularSaldo();

                Hashtable m_params = new Hashtable();
                m_params.Add("Empresa_ID", this.Empresa_ID);
                if (!AppHelper.IsNullOrEmpty(this.Estacion_ID)) m_params.Add("Estacion_ID", this.Estacion_ID);
                m_params.Add("Conductor_ID", this.Conductor_ID);
                if (!AppHelper.IsNullOrEmpty(this.Unidad_ID)) m_params.Add("Unidad_ID", this.Unidad_ID);
                if (!AppHelper.IsNullOrEmpty(this.Caja_ID)) m_params.Add("Caja_ID", this.Caja_ID);
                if (!AppHelper.IsNullOrEmpty(this.Ticket_ID)) m_params.Add("Ticket_ID", this.Ticket_ID);
                m_params.Add("Cuenta_ID", this.Cuenta_ID);
                if (!AppHelper.IsNullOrEmpty(this.Concepto_ID)) m_params.Add("Concepto_ID", this.Concepto_ID);
                m_params.Add("Cargo", this.Cargo);
                m_params.Add("Abono", this.Abono);
                m_params.Add("Saldo", this.Saldo);
                m_params.Add("Comentarios", SICASBot.Strings.Left(this.Comentarios,250));
                m_params.Add("Fecha", this.Fecha);
                m_params.Add("Usuario_ID", this.Usuario_ID);
                if (!AppHelper.IsNullOrEmpty(this.Referencia_ID)) m_params.Add("Referencia_ID", this.Referencia_ID);

                return DB.InsertRow("CuentaConductores", m_params);
            } // End Create

            public int Create(bool IsIdentityInsert)
            {
                CalcularSaldo();

                if (!IsIdentityInsert) return Create();
                Hashtable m_params = new Hashtable();
                m_params.Add("CuentaConductor_ID", this.CuentaConductor_ID);
                m_params.Add("Empresa_ID", this.Empresa_ID);
                if (!AppHelper.IsNullOrEmpty(this.Estacion_ID)) m_params.Add("Estacion_ID", this.Estacion_ID);
                m_params.Add("Conductor_ID", this.Conductor_ID);
                if (!AppHelper.IsNullOrEmpty(this.Unidad_ID)) m_params.Add("Unidad_ID", this.Unidad_ID);
                if (!AppHelper.IsNullOrEmpty(this.Caja_ID)) m_params.Add("Caja_ID", this.Caja_ID);
                if (!AppHelper.IsNullOrEmpty(this.Ticket_ID)) m_params.Add("Ticket_ID", this.Ticket_ID);
                m_params.Add("Cuenta_ID", this.Cuenta_ID);
                if (!AppHelper.IsNullOrEmpty(this.Concepto_ID)) m_params.Add("Concepto_ID", this.Concepto_ID);
                m_params.Add("Cargo", this.Cargo);
                m_params.Add("Abono", this.Abono);
                m_params.Add("Saldo", this.Saldo);
                m_params.Add("Comentarios", this.Comentarios);
                m_params.Add("Fecha", this.Fecha);
                m_params.Add("Usuario_ID", this.Usuario_ID);
                if (!AppHelper.IsNullOrEmpty(this.Referencia_ID)) m_params.Add("Referencia_ID", this.Referencia_ID);

                return DB.IdentityInsertRow("CuentaConductores", m_params);
            } // End Create

            public static List<CuentaConductores> Read()
            {
                List<CuentaConductores> list = new List<CuentaConductores>();
                DataTable dt = DB.Select("CuentaConductores");
                foreach (DataRow dr in dt.Rows)
                {
                    list.Add(new CuentaConductores(Convert.ToInt32(dr["CuentaConductor_ID"]), Convert.ToInt32(dr["Empresa_ID"]), DB.GetNullableInt32(dr["Estacion_ID"]), Convert.ToInt32(dr["Conductor_ID"]), DB.GetNullableInt32(dr["Unidad_ID"]), DB.GetNullableInt32(dr["Caja_ID"]), DB.GetNullableInt32(dr["Ticket_ID"]), Convert.ToInt32(dr["Cuenta_ID"]), DB.GetNullableInt32(dr["Concepto_ID"]), Convert.ToDecimal(dr["Cargo"]), Convert.ToDecimal(dr["Abono"]), Convert.ToDecimal(dr["Saldo"]), Convert.ToString(dr["Comentarios"]), Convert.ToDateTime(dr["Fecha"]), Convert.ToString(dr["Usuario_ID"]), DB.GetNullableInt32(dr["Referencia_ID"])));
                }

                return list;
            } // End Read

            public static CuentaConductores Read(int cuentaconductor_id)
            {
                Hashtable w_params = new Hashtable();
                w_params.Add("CuentaConductor_ID", cuentaconductor_id);
                DataTable dt = DB.Select("CuentaConductores", w_params);
                if (dt.Rows.Count == 0)
                {
                    throw new Exception("No existe CuentaConductores con los criterios de búsqueda especificados.");
                }
                DataRow dr = dt.Rows[0];
                return new CuentaConductores(Convert.ToInt32(dr["CuentaConductor_ID"]), Convert.ToInt32(dr["Empresa_ID"]), DB.GetNullableInt32(dr["Estacion_ID"]), Convert.ToInt32(dr["Conductor_ID"]), DB.GetNullableInt32(dr["Unidad_ID"]), DB.GetNullableInt32(dr["Caja_ID"]), DB.GetNullableInt32(dr["Ticket_ID"]), Convert.ToInt32(dr["Cuenta_ID"]), DB.GetNullableInt32(dr["Concepto_ID"]), Convert.ToDecimal(dr["Cargo"]), Convert.ToDecimal(dr["Abono"]), Convert.ToDecimal(dr["Saldo"]), Convert.ToString(dr["Comentarios"]), Convert.ToDateTime(dr["Fecha"]), Convert.ToString(dr["Usuario_ID"]), DB.GetNullableInt32(dr["Referencia_ID"]));
            } // End Read

            public static CuentaConductores Read(params KeyValuePair<string, object>[] args)
            {
                DataTable dt = DB.Read("CuentaConductores", args);
                if (dt.Rows.Count == 0)
                {
                    return null;
                }
                DataRow dr = dt.Rows[0];
                return new CuentaConductores(Convert.ToInt32(dr["CuentaConductor_ID"]), Convert.ToInt32(dr["Empresa_ID"]), DB.GetNullableInt32(dr["Estacion_ID"]), Convert.ToInt32(dr["Conductor_ID"]), DB.GetNullableInt32(dr["Unidad_ID"]), DB.GetNullableInt32(dr["Caja_ID"]), DB.GetNullableInt32(dr["Ticket_ID"]), Convert.ToInt32(dr["Cuenta_ID"]), DB.GetNullableInt32(dr["Concepto_ID"]), Convert.ToDecimal(dr["Cargo"]), Convert.ToDecimal(dr["Abono"]), Convert.ToDecimal(dr["Saldo"]), Convert.ToString(dr["Comentarios"]), Convert.ToDateTime(dr["Fecha"]), Convert.ToString(dr["Usuario_ID"]), DB.GetNullableInt32(dr["Referencia_ID"]));
            } // End Read

            public static bool Read(out CuentaConductores cuentaconductores, int top, string filter, string sort, params KeyValuePair<string, object>[] args)
            {
                DataTable dt = DB.Read("CuentaConductores", top, filter, sort, args);
                if (dt.Rows.Count == 0)
                {
                    cuentaconductores = null;
                    return false;
                }
                DataRow dr = dt.Rows[0];
                cuentaconductores = new CuentaConductores(Convert.ToInt32(dr["CuentaConductor_ID"]), Convert.ToInt32(dr["Empresa_ID"]), DB.GetNullableInt32(dr["Estacion_ID"]), Convert.ToInt32(dr["Conductor_ID"]), DB.GetNullableInt32(dr["Unidad_ID"]), DB.GetNullableInt32(dr["Caja_ID"]), DB.GetNullableInt32(dr["Ticket_ID"]), Convert.ToInt32(dr["Cuenta_ID"]), DB.GetNullableInt32(dr["Concepto_ID"]), Convert.ToDecimal(dr["Cargo"]), Convert.ToDecimal(dr["Abono"]), Convert.ToDecimal(dr["Saldo"]), Convert.ToString(dr["Comentarios"]), Convert.ToDateTime(dr["Fecha"]), Convert.ToString(dr["Usuario_ID"]), DB.GetNullableInt32(dr["Referencia_ID"]));
                return true;
            } // End Read

            public int Update()
            {
                CalcularSaldo();

                Hashtable m_params = new Hashtable();
                Hashtable w_params = new Hashtable();
                w_params.Add("CuentaConductor_ID", this.CuentaConductor_ID);
                m_params.Add("Empresa_ID", this.Empresa_ID);
                if (!AppHelper.IsNullOrEmpty(this.Estacion_ID)) m_params.Add("Estacion_ID", this.Estacion_ID);
                m_params.Add("Conductor_ID", this.Conductor_ID);
                if (!AppHelper.IsNullOrEmpty(this.Unidad_ID)) m_params.Add("Unidad_ID", this.Unidad_ID);
                if (!AppHelper.IsNullOrEmpty(this.Caja_ID)) m_params.Add("Caja_ID", this.Caja_ID);
                if (!AppHelper.IsNullOrEmpty(this.Ticket_ID)) m_params.Add("Ticket_ID", this.Ticket_ID);
                m_params.Add("Cuenta_ID", this.Cuenta_ID);
                if (!AppHelper.IsNullOrEmpty(this.Concepto_ID)) m_params.Add("Concepto_ID", this.Concepto_ID);
                m_params.Add("Cargo", this.Cargo);
                m_params.Add("Abono", this.Abono);
                m_params.Add("Saldo", this.Saldo);
                m_params.Add("Comentarios", this.Comentarios);
                m_params.Add("Fecha", this.Fecha);
                m_params.Add("Usuario_ID", this.Usuario_ID);
                if (!AppHelper.IsNullOrEmpty(this.Referencia_ID)) m_params.Add("Referencia_ID", this.Referencia_ID);

                return DB.UpdateRow("CuentaConductores", m_params, w_params);
            } // End Update

            public int Delete()
            {
                Hashtable w_params = new Hashtable();
                w_params.Add("CuentaConductor_ID", this.CuentaConductor_ID);

                return DB.DeleteRow("CuentaConductores", w_params);
            } // End Delete

        } //End Class CuentaConductores

        public class CuentaEmpresas
        {

            public CuentaEmpresas()
            {
            }

            public CuentaEmpresas(int cuentaempresa_id, int empresa_id, int cuenta_id, int concepto_id, decimal cargo, decimal abono, decimal saldo, string comentarios, DateTime fecha, string usuario_id)
            {
                this.CuentaEmpresa_ID = cuentaempresa_id;
                this.Empresa_ID = empresa_id;
                this.Cuenta_ID = cuenta_id;
                this.Concepto_ID = concepto_id;
                this.Cargo = cargo;
                this.Abono = abono;
                this.Saldo = saldo;
                this.Comentarios = comentarios;
                this.Fecha = fecha;
                this.Usuario_ID = usuario_id;
            }

            private int _CuentaEmpresa_ID;
            public int CuentaEmpresa_ID
            {
                get { return _CuentaEmpresa_ID; }
                set { _CuentaEmpresa_ID = value; }
            }

            private int _Empresa_ID;
            public int Empresa_ID
            {
                get { return _Empresa_ID; }
                set { _Empresa_ID = value; }
            }

            private int _Cuenta_ID;
            public int Cuenta_ID
            {
                get { return _Cuenta_ID; }
                set { _Cuenta_ID = value; }
            }

            private int _Concepto_ID;
            public int Concepto_ID
            {
                get { return _Concepto_ID; }
                set { _Concepto_ID = value; }
            }

            private decimal _Cargo;
            public decimal Cargo
            {
                get { return _Cargo; }
                set { _Cargo = value; }
            }

            private decimal _Abono;
            public decimal Abono
            {
                get { return _Abono; }
                set { _Abono = value; }
            }

            private decimal _Saldo;
            public decimal Saldo
            {
                get { return _Saldo; }
                set { _Saldo = value; }
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

            private string _Usuario_ID;
            public string Usuario_ID
            {
                get { return _Usuario_ID; }
                set { _Usuario_ID = value; }
            }

            public int Create()
            {
                Hashtable m_params = new Hashtable();
                m_params.Add("Empresa_ID", this.Empresa_ID);
                m_params.Add("Cuenta_ID", this.Cuenta_ID);
                m_params.Add("Concepto_ID", this.Concepto_ID);
                m_params.Add("Cargo", this.Cargo);
                m_params.Add("Abono", this.Abono);
                m_params.Add("Saldo", this.Saldo);
                m_params.Add("Comentarios", this.Comentarios);
                m_params.Add("Fecha", this.Fecha);
                m_params.Add("Usuario_ID", this.Usuario_ID);

                return DB.InsertRow("CuentaEmpresas", m_params);
            } // End Create

            public static List<CuentaEmpresas> Read()
            {
                List<CuentaEmpresas> list = new List<CuentaEmpresas>();
                DataTable dt = DB.Select("CuentaEmpresas");
                foreach (DataRow dr in dt.Rows)
                {
                    list.Add(new CuentaEmpresas(Convert.ToInt32(dr["CuentaEmpresa_ID"]), Convert.ToInt32(dr["Empresa_ID"]), Convert.ToInt32(dr["Cuenta_ID"]), Convert.ToInt32(dr["Concepto_ID"]), Convert.ToDecimal(dr["Cargo"]), Convert.ToDecimal(dr["Abono"]), Convert.ToDecimal(dr["Saldo"]), Convert.ToString(dr["Comentarios"]), Convert.ToDateTime(dr["Fecha"]), Convert.ToString(dr["Usuario_ID"])));
                }

                return list;
            } // End Read

            public static List<CuentaEmpresas> Read(int cuentaempresa_id)
            {
                List<CuentaEmpresas> list = new List<CuentaEmpresas>();
                Hashtable w_params = new Hashtable();
                w_params.Add("CuentaEmpresa_ID", cuentaempresa_id);
                DataTable dt = DB.Select("CuentaEmpresas", w_params);
                foreach (DataRow dr in dt.Rows)
                {
                    list.Add(new CuentaEmpresas(Convert.ToInt32(dr["CuentaEmpresa_ID"]), Convert.ToInt32(dr["Empresa_ID"]), Convert.ToInt32(dr["Cuenta_ID"]), Convert.ToInt32(dr["Concepto_ID"]), Convert.ToDecimal(dr["Cargo"]), Convert.ToDecimal(dr["Abono"]), Convert.ToDecimal(dr["Saldo"]), Convert.ToString(dr["Comentarios"]), Convert.ToDateTime(dr["Fecha"]), Convert.ToString(dr["Usuario_ID"])));
                }

                return list;
            } // End Read

            public int Update()
            {
                Hashtable m_params = new Hashtable();
                Hashtable w_params = new Hashtable();
                w_params.Add("CuentaEmpresa_ID", this.CuentaEmpresa_ID);
                m_params.Add("Empresa_ID", this.Empresa_ID);
                m_params.Add("Cuenta_ID", this.Cuenta_ID);
                m_params.Add("Concepto_ID", this.Concepto_ID);
                m_params.Add("Cargo", this.Cargo);
                m_params.Add("Abono", this.Abono);
                m_params.Add("Saldo", this.Saldo);
                m_params.Add("Comentarios", this.Comentarios);
                m_params.Add("Fecha", this.Fecha);
                m_params.Add("Usuario_ID", this.Usuario_ID);

                return DB.UpdateRow("CuentaEmpresas", m_params, w_params);
            } // End Update

            public int Delete()
            {
                Hashtable w_params = new Hashtable();
                w_params.Add("CuentaEmpresa_ID", this.CuentaEmpresa_ID);

                return DB.DeleteRow("CuentaEmpresas", w_params);
            }

        } //End Class CuentaEmpresas

        public class CuentaFlujoCajas
        {

            public CuentaFlujoCajas()
            {
            }

            public CuentaFlujoCajas(int cuentaflujocaja_id, int sesion_id, int caja_id, int moneda_id, int ticket_id, string concepto, decimal cargo, decimal abono, decimal saldo, DateTime fecha, string usuario_id)
            {
                this.CuentaFlujoCaja_ID = cuentaflujocaja_id;
                this.Sesion_ID = sesion_id;
                this.Caja_ID = caja_id;
                this.Moneda_ID = moneda_id;
                this.Ticket_ID = ticket_id;
                this.Concepto = concepto;
                this.Cargo = cargo;
                this.Abono = abono;
                this.Saldo = saldo;
                this.Fecha = fecha;
                this.Usuario_ID = usuario_id;
            }

            private int _CuentaFlujoCaja_ID;
            public int CuentaFlujoCaja_ID
            {
                get { return _CuentaFlujoCaja_ID; }
                set { _CuentaFlujoCaja_ID = value; }
            }

            private int _Sesion_ID;
            public int Sesion_ID
            {
                get { return _Sesion_ID; }
                set { _Sesion_ID = value; }
            }

            private int _Caja_ID;
            public int Caja_ID
            {
                get { return _Caja_ID; }
                set { _Caja_ID = value; }
            }

            private int _Moneda_ID;
            public int Moneda_ID
            {
                get { return _Moneda_ID; }
                set { _Moneda_ID = value; }
            }

            private int _Ticket_ID;
            public int Ticket_ID
            {
                get { return _Ticket_ID; }
                set { _Ticket_ID = value; }
            }

            private string _Concepto;
            public string Concepto
            {
                get { return _Concepto; }
                set { _Concepto = value; }
            }

            private decimal _Cargo;
            public decimal Cargo
            {
                get { return _Cargo; }
                set { _Cargo = value; }
            }

            private decimal _Abono;
            public decimal Abono
            {
                get { return _Abono; }
                set { _Abono = value; }
            }

            private decimal _Saldo;
            public decimal Saldo
            {
                get { return _Saldo; }
                set { _Saldo = value; }
            }

            private DateTime _Fecha;
            public DateTime Fecha
            {
                get { return _Fecha; }
                set { _Fecha = value; }
            }

            private string _Usuario_ID;
            public string Usuario_ID
            {
                get { return _Usuario_ID; }
                set { _Usuario_ID = value; }
            }

            public int Create()
            {
                Hashtable m_params = new Hashtable();
                m_params.Add("Sesion_ID", this.Sesion_ID);
                m_params.Add("Caja_ID", this.Caja_ID);
                m_params.Add("Moneda_ID", this.Moneda_ID);
                m_params.Add("Ticket_ID", this.Ticket_ID);
                m_params.Add("Concepto", this.Concepto);
                m_params.Add("Cargo", this.Cargo);
                m_params.Add("Abono", this.Abono);
                m_params.Add("Saldo", this.Saldo);
                m_params.Add("Fecha", this.Fecha);
                m_params.Add("Usuario_ID", this.Usuario_ID);

                return DB.InsertRow("CuentaFlujoCajas", m_params);
            } // End Create

            public static List<CuentaFlujoCajas> Read()
            {
                List<CuentaFlujoCajas> list = new List<CuentaFlujoCajas>();
                DataTable dt = DB.Select("CuentaFlujoCajas");
                foreach (DataRow dr in dt.Rows)
                {
                    list.Add(new CuentaFlujoCajas(Convert.ToInt32(dr["CuentaFlujoCaja_ID"]), Convert.ToInt32(dr["Sesion_ID"]), Convert.ToInt32(dr["Caja_ID"]), Convert.ToInt32(dr["Moneda_ID"]), Convert.ToInt32(dr["Ticket_ID"]), Convert.ToString(dr["Concepto"]), Convert.ToDecimal(dr["Cargo"]), Convert.ToDecimal(dr["Abono"]), Convert.ToDecimal(dr["Saldo"]), Convert.ToDateTime(dr["Fecha"]), Convert.ToString(dr["Usuario_ID"])));
                }

                return list;
            } // End Read

            public static List<CuentaFlujoCajas> Read(int cuentaflujocaja_id)
            {
                List<CuentaFlujoCajas> list = new List<CuentaFlujoCajas>();
                Hashtable w_params = new Hashtable();
                w_params.Add("CuentaFlujoCaja_ID", cuentaflujocaja_id);
                DataTable dt = DB.Select("CuentaFlujoCajas", w_params);
                foreach (DataRow dr in dt.Rows)
                {
                    list.Add(new CuentaFlujoCajas(Convert.ToInt32(dr["CuentaFlujoCaja_ID"]), Convert.ToInt32(dr["Sesion_ID"]), Convert.ToInt32(dr["Caja_ID"]), Convert.ToInt32(dr["Moneda_ID"]), Convert.ToInt32(dr["Ticket_ID"]), Convert.ToString(dr["Concepto"]), Convert.ToDecimal(dr["Cargo"]), Convert.ToDecimal(dr["Abono"]), Convert.ToDecimal(dr["Saldo"]), Convert.ToDateTime(dr["Fecha"]), Convert.ToString(dr["Usuario_ID"])));
                }

                return list;
            } // End Read

            public int Update()
            {
                Hashtable m_params = new Hashtable();
                Hashtable w_params = new Hashtable();
                w_params.Add("CuentaFlujoCaja_ID", this.CuentaFlujoCaja_ID);
                m_params.Add("Sesion_ID", this.Sesion_ID);
                m_params.Add("Caja_ID", this.Caja_ID);
                m_params.Add("Moneda_ID", this.Moneda_ID);
                m_params.Add("Ticket_ID", this.Ticket_ID);
                m_params.Add("Concepto", this.Concepto);
                m_params.Add("Cargo", this.Cargo);
                m_params.Add("Abono", this.Abono);
                m_params.Add("Saldo", this.Saldo);
                m_params.Add("Fecha", this.Fecha);
                m_params.Add("Usuario_ID", this.Usuario_ID);

                return DB.UpdateRow("CuentaFlujoCajas", m_params, w_params);
            } // End Update

            public int Delete()
            {
                Hashtable w_params = new Hashtable();
                w_params.Add("CuentaFlujoCaja_ID", this.CuentaFlujoCaja_ID);

                return DB.DeleteRow("CuentaFlujoCajas", w_params);
            }

        } //End Class CuentaFlujoCajas

        public class Cuentas
        {

            public Cuentas()
            {
            }

            public Cuentas(int cuenta_id, string nombre)
            {
                this.Cuenta_ID = cuenta_id;
                this.Nombre = nombre;
            }

            private int _Cuenta_ID;
            public int Cuenta_ID
            {
                get { return _Cuenta_ID; }
                set { _Cuenta_ID = value; }
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

                return DB.InsertRow("Cuentas", m_params);
            } // End Create

            public static List<Cuentas> Read()
            {
                List<Cuentas> list = new List<Cuentas>();
                DataTable dt = DB.Select("Cuentas");
                foreach (DataRow dr in dt.Rows)
                {
                    list.Add(new Cuentas(Convert.ToInt32(dr["Cuenta_ID"]), Convert.ToString(dr["Nombre"])));
                }

                return list;
            } // End Read

            public static List<Cuentas> Read(int cuenta_id)
            {
                List<Cuentas> list = new List<Cuentas>();
                Hashtable w_params = new Hashtable();
                w_params.Add("Cuenta_ID", cuenta_id);
                DataTable dt = DB.Select("Cuentas", w_params);
                foreach (DataRow dr in dt.Rows)
                {
                    list.Add(new Cuentas(Convert.ToInt32(dr["Cuenta_ID"]), Convert.ToString(dr["Nombre"])));
                }

                return list;
            } // End Read

            public int Update()
            {
                Hashtable m_params = new Hashtable();
                Hashtable w_params = new Hashtable();
                w_params.Add("Cuenta_ID", this.Cuenta_ID);
                m_params.Add("Nombre", this.Nombre);

                return DB.UpdateRow("Cuentas", m_params, w_params);
            } // End Update

            public int Delete()
            {
                Hashtable w_params = new Hashtable();
                w_params.Add("Cuenta_ID", this.Cuenta_ID);

                return DB.DeleteRow("Cuentas", w_params);
            }

        } //End Class Cuentas

        public class CuentaUnidades
        {

            public CuentaUnidades()
            {
            }

            public CuentaUnidades(int cuentaunidad_id, int empresa_id, int estacion_id, int unidad_id, int conductor_id, int caja_id, int ticket_id, int cuenta_id, int concepto_id, decimal cargo, decimal abono, decimal saldo, string comentarios, DateTime fecha, string usuario_id)
            {
                this.CuentaUnidad_ID = cuentaunidad_id;
                this.Empresa_ID = empresa_id;
                this.Estacion_ID = estacion_id;
                this.Unidad_ID = unidad_id;
                this.Conductor_ID = conductor_id;
                this.Caja_ID = caja_id;
                this.Ticket_ID = ticket_id;
                this.Cuenta_ID = cuenta_id;
                this.Concepto_ID = concepto_id;
                this.Cargo = cargo;
                this.Abono = abono;
                this.Saldo = saldo;
                this.Comentarios = comentarios;
                this.Fecha = fecha;
                this.Usuario_ID = usuario_id;
            }

            private int _CuentaUnidad_ID;
            public int CuentaUnidad_ID
            {
                get { return _CuentaUnidad_ID; }
                set { _CuentaUnidad_ID = value; }
            }

            private int _Empresa_ID;
            public int Empresa_ID
            {
                get { return _Empresa_ID; }
                set { _Empresa_ID = value; }
            }

            private int _Estacion_ID;
            public int Estacion_ID
            {
                get { return _Estacion_ID; }
                set { _Estacion_ID = value; }
            }

            private int _Unidad_ID;
            public int Unidad_ID
            {
                get { return _Unidad_ID; }
                set { _Unidad_ID = value; }
            }

            private int _Conductor_ID;
            public int Conductor_ID
            {
                get { return _Conductor_ID; }
                set { _Conductor_ID = value; }
            }

            private int _Caja_ID;
            public int Caja_ID
            {
                get { return _Caja_ID; }
                set { _Caja_ID = value; }
            }

            private int _Ticket_ID;
            public int Ticket_ID
            {
                get { return _Ticket_ID; }
                set { _Ticket_ID = value; }
            }

            private int _Cuenta_ID;
            public int Cuenta_ID
            {
                get { return _Cuenta_ID; }
                set { _Cuenta_ID = value; }
            }

            private int _Concepto_ID;
            public int Concepto_ID
            {
                get { return _Concepto_ID; }
                set { _Concepto_ID = value; }
            }

            private decimal _Cargo;
            public decimal Cargo
            {
                get { return _Cargo; }
                set { _Cargo = value; }
            }

            private decimal _Abono;
            public decimal Abono
            {
                get { return _Abono; }
                set { _Abono = value; }
            }

            private decimal _Saldo;
            public decimal Saldo
            {
                get { return _Saldo; }
                set { _Saldo = value; }
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

            private string _Usuario_ID;
            public string Usuario_ID
            {
                get { return _Usuario_ID; }
                set { _Usuario_ID = value; }
            }

            public int Create()
            {
                Hashtable m_params = new Hashtable();
                m_params.Add("Empresa_ID", this.Empresa_ID);
                m_params.Add("Estacion_ID", this.Estacion_ID);
                m_params.Add("Unidad_ID", this.Unidad_ID);
                m_params.Add("Conductor_ID", this.Conductor_ID);
                m_params.Add("Caja_ID", this.Caja_ID);
                m_params.Add("Ticket_ID", this.Ticket_ID);
                m_params.Add("Cuenta_ID", this.Cuenta_ID);
                m_params.Add("Concepto_ID", this.Concepto_ID);
                m_params.Add("Cargo", this.Cargo);
                m_params.Add("Abono", this.Abono);
                m_params.Add("Saldo", this.Saldo);
                m_params.Add("Comentarios", this.Comentarios);
                m_params.Add("Fecha", this.Fecha);
                m_params.Add("Usuario_ID", this.Usuario_ID);

                return DB.InsertRow("CuentaUnidades", m_params);
            } // End Create

            public static List<CuentaUnidades> Read()
            {
                List<CuentaUnidades> list = new List<CuentaUnidades>();
                DataTable dt = DB.Select("CuentaUnidades");
                foreach (DataRow dr in dt.Rows)
                {
                    list.Add(new CuentaUnidades(Convert.ToInt32(dr["CuentaUnidad_ID"]), Convert.ToInt32(dr["Empresa_ID"]), Convert.ToInt32(dr["Estacion_ID"]), Convert.ToInt32(dr["Unidad_ID"]), Convert.ToInt32(dr["Conductor_ID"]), Convert.ToInt32(dr["Caja_ID"]), Convert.ToInt32(dr["Ticket_ID"]), Convert.ToInt32(dr["Cuenta_ID"]), Convert.ToInt32(dr["Concepto_ID"]), Convert.ToDecimal(dr["Cargo"]), Convert.ToDecimal(dr["Abono"]), Convert.ToDecimal(dr["Saldo"]), Convert.ToString(dr["Comentarios"]), Convert.ToDateTime(dr["Fecha"]), Convert.ToString(dr["Usuario_ID"])));
                }

                return list;
            } // End Read

            public static List<CuentaUnidades> Read(int cuentaunidad_id)
            {
                List<CuentaUnidades> list = new List<CuentaUnidades>();
                Hashtable w_params = new Hashtable();
                w_params.Add("CuentaUnidad_ID", cuentaunidad_id);
                DataTable dt = DB.Select("CuentaUnidades", w_params);
                foreach (DataRow dr in dt.Rows)
                {
                    list.Add(new CuentaUnidades(Convert.ToInt32(dr["CuentaUnidad_ID"]), Convert.ToInt32(dr["Empresa_ID"]), Convert.ToInt32(dr["Estacion_ID"]), Convert.ToInt32(dr["Unidad_ID"]), Convert.ToInt32(dr["Conductor_ID"]), Convert.ToInt32(dr["Caja_ID"]), Convert.ToInt32(dr["Ticket_ID"]), Convert.ToInt32(dr["Cuenta_ID"]), Convert.ToInt32(dr["Concepto_ID"]), Convert.ToDecimal(dr["Cargo"]), Convert.ToDecimal(dr["Abono"]), Convert.ToDecimal(dr["Saldo"]), Convert.ToString(dr["Comentarios"]), Convert.ToDateTime(dr["Fecha"]), Convert.ToString(dr["Usuario_ID"])));
                }

                return list;
            } // End Read

            public int Update()
            {
                Hashtable m_params = new Hashtable();
                Hashtable w_params = new Hashtable();
                w_params.Add("CuentaUnidad_ID", this.CuentaUnidad_ID);
                m_params.Add("Empresa_ID", this.Empresa_ID);
                m_params.Add("Estacion_ID", this.Estacion_ID);
                m_params.Add("Unidad_ID", this.Unidad_ID);
                m_params.Add("Conductor_ID", this.Conductor_ID);
                m_params.Add("Caja_ID", this.Caja_ID);
                m_params.Add("Ticket_ID", this.Ticket_ID);
                m_params.Add("Cuenta_ID", this.Cuenta_ID);
                m_params.Add("Concepto_ID", this.Concepto_ID);
                m_params.Add("Cargo", this.Cargo);
                m_params.Add("Abono", this.Abono);
                m_params.Add("Saldo", this.Saldo);
                m_params.Add("Comentarios", this.Comentarios);
                m_params.Add("Fecha", this.Fecha);
                m_params.Add("Usuario_ID", this.Usuario_ID);

                return DB.UpdateRow("CuentaUnidades", m_params, w_params);
            } // End Update

            public int Delete()
            {
                Hashtable w_params = new Hashtable();
                w_params.Add("CuentaUnidad_ID", this.CuentaUnidad_ID);

                return DB.DeleteRow("CuentaUnidades", w_params);
            }

        } //End Class CuentaUnidades

        public class DiasDeCobros
        {

            public DiasDeCobros()
            {
            }

            public DiasDeCobros(int diasdecobro_id, string nombre)
            {
                this.DiasDeCobro_ID = diasdecobro_id;
                this.Nombre = nombre;
            }

            private int _DiasDeCobro_ID;
            public int DiasDeCobro_ID
            {
                get { return _DiasDeCobro_ID; }
                set { _DiasDeCobro_ID = value; }
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

                return DB.InsertRow("DiasDeCobros", m_params);
            } // End Create

            public static List<DiasDeCobros> Read()
            {
                List<DiasDeCobros> list = new List<DiasDeCobros>();
                DataTable dt = DB.Select("DiasDeCobros");
                foreach (DataRow dr in dt.Rows)
                {
                    list.Add(new DiasDeCobros(Convert.ToInt32(dr["DiasDeCobro_ID"]), Convert.ToString(dr["Nombre"])));
                }

                return list;
            } // End Read

            public static List<DiasDeCobros> Read(int diasdecobro_id)
            {
                List<DiasDeCobros> list = new List<DiasDeCobros>();
                Hashtable w_params = new Hashtable();
                w_params.Add("DiasDeCobro_ID", diasdecobro_id);
                DataTable dt = DB.Select("DiasDeCobros", w_params);
                foreach (DataRow dr in dt.Rows)
                {
                    list.Add(new DiasDeCobros(Convert.ToInt32(dr["DiasDeCobro_ID"]), Convert.ToString(dr["Nombre"])));
                }

                return list;
            } // End Read

            public int Update()
            {
                Hashtable m_params = new Hashtable();
                Hashtable w_params = new Hashtable();
                w_params.Add("DiasDeCobro_ID", this.DiasDeCobro_ID);
                m_params.Add("Nombre", this.Nombre);

                return DB.UpdateRow("DiasDeCobros", m_params, w_params);
            } // End Update

            public int Delete()
            {
                Hashtable w_params = new Hashtable();
                w_params.Add("DiasDeCobro_ID", this.DiasDeCobro_ID);

                return DB.DeleteRow("DiasDeCobros", w_params);
            }

        } //End Class DiasDeCobros

        public class Empresas
        {

            public Empresas()
            {
            }

            public Empresas(int empresa_id, int tipoempresa_id, int? mercado_id, string rfc, string razonsocial, string nombre, string domicilio, string codigopostal, string ciudad, string estado, string telefono1, string telefono2, string movil, string email, string representantelegal, bool activo)
            {
                this.Empresa_ID = empresa_id;
                this.TipoEmpresa_ID = tipoempresa_id;
                this.Mercado_ID = mercado_id;
                this.RFC = rfc;
                this.RazonSocial = razonsocial;
                this.Nombre = nombre;
                this.Domicilio = domicilio;
                this.CodigoPostal = codigopostal;
                this.Ciudad = ciudad;
                this.Estado = estado;
                this.Telefono1 = telefono1;
                this.Telefono2 = telefono2;
                this.Movil = movil;
                this.Email = email;
                this.RepresentanteLegal = representantelegal;
                this.Activo = activo;
            }

            private int _Empresa_ID;
            public int Empresa_ID
            {
                get { return _Empresa_ID; }
                set { _Empresa_ID = value; }
            }

            private int _TipoEmpresa_ID;
            public int TipoEmpresa_ID
            {
                get { return _TipoEmpresa_ID; }
                set { _TipoEmpresa_ID = value; }
            }

            private int? _Mercado_ID;
            public int? Mercado_ID
            {
                get { return _Mercado_ID; }
                set { _Mercado_ID = value; }
            }

            private string _RFC;
            public string RFC
            {
                get { return _RFC; }
                set { _RFC = value; }
            }

            private string _RazonSocial;
            public string RazonSocial
            {
                get { return _RazonSocial; }
                set { _RazonSocial = value; }
            }

            private string _Nombre;
            public string Nombre
            {
                get { return _Nombre; }
                set { _Nombre = value; }
            }

            private string _Domicilio;
            public string Domicilio
            {
                get { return _Domicilio; }
                set { _Domicilio = value; }
            }

            private string _CodigoPostal;
            public string CodigoPostal
            {
                get { return _CodigoPostal; }
                set { _CodigoPostal = value; }
            }

            private string _Ciudad;
            public string Ciudad
            {
                get { return _Ciudad; }
                set { _Ciudad = value; }
            }

            private string _Estado;
            public string Estado
            {
                get { return _Estado; }
                set { _Estado = value; }
            }

            private string _Telefono1;
            public string Telefono1
            {
                get { return _Telefono1; }
                set { _Telefono1 = value; }
            }

            private string _Telefono2;
            public string Telefono2
            {
                get { return _Telefono2; }
                set { _Telefono2 = value; }
            }

            private string _Movil;
            public string Movil
            {
                get { return _Movil; }
                set { _Movil = value; }
            }

            private string _Email;
            public string Email
            {
                get { return _Email; }
                set { _Email = value; }
            }

            private string _RepresentanteLegal;
            public string RepresentanteLegal
            {
                get { return _RepresentanteLegal; }
                set { _RepresentanteLegal = value; }
            }

            private bool _Activo;
            public bool Activo
            {
                get { return _Activo; }
                set { _Activo = value; }
            }

            public int Create()
            {
                Hashtable m_params = new Hashtable();
                m_params.Add("TipoEmpresa_ID", this.TipoEmpresa_ID);
                m_params.Add("Mercado_ID", this.Mercado_ID);
                m_params.Add("RFC", this.RFC);
                m_params.Add("RazonSocial", this.RazonSocial);
                m_params.Add("Nombre", this.Nombre);
                m_params.Add("Domicilio", this.Domicilio);
                m_params.Add("CodigoPostal", this.CodigoPostal);
                m_params.Add("Ciudad", this.Ciudad);
                m_params.Add("Estado", this.Estado);
                m_params.Add("Telefono1", this.Telefono1);
                m_params.Add("Telefono2", this.Telefono2);
                m_params.Add("Movil", this.Movil);
                m_params.Add("Email", this.Email);
                m_params.Add("RepresentanteLegal", this.RepresentanteLegal);
                m_params.Add("Activo", this.Activo);

                return DB.InsertRow("Empresas", m_params);
            } // End Create

            public int Create(bool IsIdentityInsert)
            {
                if (!IsIdentityInsert) return Create();
                Hashtable m_params = new Hashtable();
                m_params.Add("Empresa_ID", this.Empresa_ID);
                m_params.Add("TipoEmpresa_ID", this.TipoEmpresa_ID);
                if (!AppHelper.IsNullOrEmpty(this.Mercado_ID)) m_params.Add("Mercado_ID", this.Mercado_ID);
                m_params.Add("RFC", this.RFC);
                m_params.Add("RazonSocial", this.RazonSocial);
                if (!AppHelper.IsNullOrEmpty(this.Nombre)) m_params.Add("Nombre", this.Nombre);
                m_params.Add("Domicilio", this.Domicilio);
                m_params.Add("CodigoPostal", this.CodigoPostal);
                m_params.Add("Ciudad", this.Ciudad);
                m_params.Add("Estado", this.Estado);
                m_params.Add("Telefono1", this.Telefono1);
                if (!AppHelper.IsNullOrEmpty(this.Telefono2)) m_params.Add("Telefono2", this.Telefono2);
                if (!AppHelper.IsNullOrEmpty(this.Movil)) m_params.Add("Movil", this.Movil);
                if (!AppHelper.IsNullOrEmpty(this.Email)) m_params.Add("Email", this.Email);
                if (!AppHelper.IsNullOrEmpty(this.RepresentanteLegal)) m_params.Add("RepresentanteLegal", this.RepresentanteLegal);
                m_params.Add("Activo", this.Activo);

                return DB.IdentityInsertRow("Empresas", m_params);
            } // End Create

            public static List<Empresas> Read(params KeyValuePair<string,object>[] args)
            {
                List<Empresas> list = new List<Empresas>();
                DataTable dt = DB.Read("Empresas", args);
                foreach (DataRow dr in dt.Rows)
                {
                    list.Add(new Empresas(Convert.ToInt32(dr["Empresa_ID"]), Convert.ToInt32(dr["TipoEmpresa_ID"]), DB.GetNullableInt32(dr["Mercado_ID"]), Convert.ToString(dr["RFC"]), Convert.ToString(dr["RazonSocial"]), Convert.ToString(dr["Nombre"]), Convert.ToString(dr["Domicilio"]), Convert.ToString(dr["CodigoPostal"]), Convert.ToString(dr["Ciudad"]), Convert.ToString(dr["Estado"]), Convert.ToString(dr["Telefono1"]), Convert.ToString(dr["Telefono2"]), Convert.ToString(dr["Movil"]), Convert.ToString(dr["Email"]), Convert.ToString(dr["RepresentanteLegal"]), Convert.ToBoolean(dr["Activo"])));
                }

                return list;
            } // End Read

            public static List<Empresas> Read()
            {
                List<Empresas> list = new List<Empresas>();
                DataTable dt = DB.Select("Empresas");
                foreach (DataRow dr in dt.Rows)
                {
                    list.Add(new Empresas(Convert.ToInt32(dr["Empresa_ID"]), Convert.ToInt32(dr["TipoEmpresa_ID"]), DB.GetNullableInt32(dr["Mercado_ID"]), Convert.ToString(dr["RFC"]), Convert.ToString(dr["RazonSocial"]), Convert.ToString(dr["Nombre"]), Convert.ToString(dr["Domicilio"]), Convert.ToString(dr["CodigoPostal"]), Convert.ToString(dr["Ciudad"]), Convert.ToString(dr["Estado"]), Convert.ToString(dr["Telefono1"]), Convert.ToString(dr["Telefono2"]), Convert.ToString(dr["Movil"]), Convert.ToString(dr["Email"]), Convert.ToString(dr["RepresentanteLegal"]), Convert.ToBoolean(dr["Activo"])));
                }

                return list;
            } // End Read

            public static List<Empresas> Read(int empresa_id)
            {
                List<Empresas> list = new List<Empresas>();
                Hashtable w_params = new Hashtable();
                w_params.Add("Empresa_ID", empresa_id);
                DataTable dt = DB.Select("Empresas", w_params);
                foreach (DataRow dr in dt.Rows)
                {
                    list.Add(new Empresas(Convert.ToInt32(dr["Empresa_ID"]), Convert.ToInt32(dr["TipoEmpresa_ID"]), Convert.ToInt32(dr["Mercado_ID"]), Convert.ToString(dr["RFC"]), Convert.ToString(dr["RazonSocial"]), Convert.ToString(dr["Nombre"]), Convert.ToString(dr["Domicilio"]), Convert.ToString(dr["CodigoPostal"]), Convert.ToString(dr["Ciudad"]), Convert.ToString(dr["Estado"]), Convert.ToString(dr["Telefono1"]), Convert.ToString(dr["Telefono2"]), Convert.ToString(dr["Movil"]), Convert.ToString(dr["Email"]), Convert.ToString(dr["RepresentanteLegal"]), Convert.ToBoolean(dr["Activo"])));
                }

                return list;
            } // End Read

            public int Update()
            {
                Hashtable m_params = new Hashtable();
                Hashtable w_params = new Hashtable();
                w_params.Add("Empresa_ID", this.Empresa_ID);
                m_params.Add("TipoEmpresa_ID", this.TipoEmpresa_ID);
                m_params.Add("Mercado_ID", this.Mercado_ID);
                m_params.Add("RFC", this.RFC);
                m_params.Add("RazonSocial", this.RazonSocial);
                m_params.Add("Nombre", this.Nombre);
                m_params.Add("Domicilio", this.Domicilio);
                m_params.Add("CodigoPostal", this.CodigoPostal);
                m_params.Add("Ciudad", this.Ciudad);
                m_params.Add("Estado", this.Estado);
                m_params.Add("Telefono1", this.Telefono1);
                m_params.Add("Telefono2", this.Telefono2);
                m_params.Add("Movil", this.Movil);
                m_params.Add("Email", this.Email);
                m_params.Add("RepresentanteLegal", this.RepresentanteLegal);
                m_params.Add("Activo", this.Activo);

                return DB.UpdateRow("Empresas", m_params, w_params);
            } // End Update

            public int Delete()
            {
                Hashtable w_params = new Hashtable();
                w_params.Add("Empresa_ID", this.Empresa_ID);

                return DB.DeleteRow("Empresas", w_params);
            }

        } //End Class Empresas

        public class Empresas_Cuentas
        {

            public Empresas_Cuentas()
            {
            }

            public Empresas_Cuentas(int empresa_id, int cuenta_id, string banco, string cuentabancaria, string referencia, string comentarios)
            {
                this.Empresa_ID = empresa_id;
                this.Cuenta_ID = cuenta_id;
                this.Banco = banco;
                this.CuentaBancaria = cuentabancaria;
                this.Referencia = referencia;
                this.Comentarios = comentarios;
            }

            private int _Empresa_ID;
            public int Empresa_ID
            {
                get { return _Empresa_ID; }
                set { _Empresa_ID = value; }
            }

            private int _Cuenta_ID;
            public int Cuenta_ID
            {
                get { return _Cuenta_ID; }
                set { _Cuenta_ID = value; }
            }

            private string _Banco;
            public string Banco
            {
                get { return _Banco; }
                set { _Banco = value; }
            }

            private string _CuentaBancaria;
            public string CuentaBancaria
            {
                get { return _CuentaBancaria; }
                set { _CuentaBancaria = value; }
            }

            private string _Referencia;
            public string Referencia
            {
                get { return _Referencia; }
                set { _Referencia = value; }
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
                m_params.Add("Empresa_ID", this.Empresa_ID);
                m_params.Add("Cuenta_ID", this.Cuenta_ID);
                m_params.Add("Banco", this.Banco);
                m_params.Add("CuentaBancaria", this.CuentaBancaria);
                m_params.Add("Referencia", this.Referencia);
                m_params.Add("Comentarios", this.Comentarios);

                return DB.InsertRow("Empresas_Cuentas", m_params);
            } // End Create

            public static List<Empresas_Cuentas> Read()
            {
                List<Empresas_Cuentas> list = new List<Empresas_Cuentas>();
                DataTable dt = DB.Select("Empresas_Cuentas");
                foreach (DataRow dr in dt.Rows)
                {
                    list.Add(new Empresas_Cuentas(Convert.ToInt32(dr["Empresa_ID"]), Convert.ToInt32(dr["Cuenta_ID"]), Convert.ToString(dr["Banco"]), Convert.ToString(dr["CuentaBancaria"]), Convert.ToString(dr["Referencia"]), Convert.ToString(dr["Comentarios"])));
                }

                return list;
            } // End Read

            public static List<Empresas_Cuentas> Read(int empresa_id, int cuenta_id)
            {
                List<Empresas_Cuentas> list = new List<Empresas_Cuentas>();
                Hashtable w_params = new Hashtable();
                w_params.Add("Empresa_ID", empresa_id);
                w_params.Add("Cuenta_ID", cuenta_id);
                DataTable dt = DB.Select("Empresas_Cuentas", w_params);
                foreach (DataRow dr in dt.Rows)
                {
                    list.Add(new Empresas_Cuentas(Convert.ToInt32(dr["Empresa_ID"]), Convert.ToInt32(dr["Cuenta_ID"]), Convert.ToString(dr["Banco"]), Convert.ToString(dr["CuentaBancaria"]), Convert.ToString(dr["Referencia"]), Convert.ToString(dr["Comentarios"])));
                }

                return list;
            } // End Read

            public int Update()
            {
                Hashtable m_params = new Hashtable();
                Hashtable w_params = new Hashtable();
                m_params.Add("Empresa_ID", this.Empresa_ID);
                w_params.Add("Cuenta_ID", this.Cuenta_ID);
                m_params.Add("Banco", this.Banco);
                m_params.Add("CuentaBancaria", this.CuentaBancaria);
                m_params.Add("Referencia", this.Referencia);
                m_params.Add("Comentarios", this.Comentarios);

                return DB.UpdateRow("Empresas_Cuentas", m_params, w_params);
            } // End Update

            public int Delete()
            {
                Hashtable w_params = new Hashtable();
                w_params.Add("Empresa_ID", this.Empresa_ID);
                w_params.Add("Cuenta_ID", this.Cuenta_ID);

                return DB.DeleteRow("Empresas_Cuentas", w_params);
            }

        } //End Class Empresas_Cuentas

        public class Estaciones
        {

            public Estaciones()
            {
            }

            public Estaciones(int estacion_id, int empresa_id, string nombre, string descripcion, string domicilio, string municipio, string estado, string telefono1, string telefono2, bool activo)
            {
                this.Estacion_ID = estacion_id;
                this.Empresa_ID = empresa_id;
                this.Nombre = nombre;
                this.Descripcion = descripcion;
                this.Domicilio = domicilio;
                this.Municipio = municipio;
                this.Estado = estado;
                this.Telefono1 = telefono1;
                this.Telefono2 = telefono2;
                this.Activo = activo;
            }

            private int _Estacion_ID;
            public int Estacion_ID
            {
                get { return _Estacion_ID; }
                set { _Estacion_ID = value; }
            }

            private int _Empresa_ID;
            public int Empresa_ID
            {
                get { return _Empresa_ID; }
                set { _Empresa_ID = value; }
            }

            private string _Nombre;
            public string Nombre
            {
                get { return _Nombre; }
                set { _Nombre = value; }
            }

            private string _Descripcion;
            public string Descripcion
            {
                get { return _Descripcion; }
                set { _Descripcion = value; }
            }

            private string _Domicilio;
            public string Domicilio
            {
                get { return _Domicilio; }
                set { _Domicilio = value; }
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

            private string _Telefono1;
            public string Telefono1
            {
                get { return _Telefono1; }
                set { _Telefono1 = value; }
            }

            private string _Telefono2;
            public string Telefono2
            {
                get { return _Telefono2; }
                set { _Telefono2 = value; }
            }

            private bool _Activo;
            public bool Activo
            {
                get { return _Activo; }
                set { _Activo = value; }
            }

            public int Create()
            {
                Hashtable m_params = new Hashtable();
                m_params.Add("Empresa_ID", this.Empresa_ID);
                m_params.Add("Nombre", this.Nombre);
                m_params.Add("Descripcion", this.Descripcion);
                m_params.Add("Domicilio", this.Domicilio);
                m_params.Add("Municipio", this.Municipio);
                m_params.Add("Estado", this.Estado);
                m_params.Add("Telefono1", this.Telefono1);
                m_params.Add("Telefono2", this.Telefono2);
                m_params.Add("Activo", this.Activo);

                return DB.InsertRow("Estaciones", m_params);
            } // End Create

            public static List<Estaciones> Read()
            {
                List<Estaciones> list = new List<Estaciones>();
                DataTable dt = DB.Select("Estaciones");
                foreach (DataRow dr in dt.Rows)
                {
                    list.Add(new Estaciones(Convert.ToInt32(dr["Estacion_ID"]), Convert.ToInt32(dr["Empresa_ID"]), Convert.ToString(dr["Nombre"]), Convert.ToString(dr["Descripcion"]), Convert.ToString(dr["Domicilio"]), Convert.ToString(dr["Municipio"]), Convert.ToString(dr["Estado"]), Convert.ToString(dr["Telefono1"]), Convert.ToString(dr["Telefono2"]), Convert.ToBoolean(dr["Activo"])));
                }

                return list;
            } // End Read

            public static List<Estaciones> Read(int estacion_id)
            {
                List<Estaciones> list = new List<Estaciones>();
                Hashtable w_params = new Hashtable();
                w_params.Add("Estacion_ID", estacion_id);
                DataTable dt = DB.Select("Estaciones", w_params);
                foreach (DataRow dr in dt.Rows)
                {
                    list.Add(new Estaciones(Convert.ToInt32(dr["Estacion_ID"]), Convert.ToInt32(dr["Empresa_ID"]), Convert.ToString(dr["Nombre"]), Convert.ToString(dr["Descripcion"]), Convert.ToString(dr["Domicilio"]), Convert.ToString(dr["Municipio"]), Convert.ToString(dr["Estado"]), Convert.ToString(dr["Telefono1"]), Convert.ToString(dr["Telefono2"]), Convert.ToBoolean(dr["Activo"])));
                }

                return list;
            } // End Read

            public int Update()
            {
                Hashtable m_params = new Hashtable();
                Hashtable w_params = new Hashtable();
                w_params.Add("Estacion_ID", this.Estacion_ID);
                m_params.Add("Empresa_ID", this.Empresa_ID);
                m_params.Add("Nombre", this.Nombre);
                m_params.Add("Descripcion", this.Descripcion);
                m_params.Add("Domicilio", this.Domicilio);
                m_params.Add("Municipio", this.Municipio);
                m_params.Add("Estado", this.Estado);
                m_params.Add("Telefono1", this.Telefono1);
                m_params.Add("Telefono2", this.Telefono2);
                m_params.Add("Activo", this.Activo);

                return DB.UpdateRow("Estaciones", m_params, w_params);
            } // End Update

            public int Delete()
            {
                Hashtable w_params = new Hashtable();
                w_params.Add("Estacion_ID", this.Estacion_ID);

                return DB.DeleteRow("Estaciones", w_params);
            }

        } //End Class Estaciones

        public class EstatusConductores
        {

            public EstatusConductores()
            {
            }

            public EstatusConductores(int estatusconductor_id, string nombre)
            {
                this.EstatusConductor_ID = estatusconductor_id;
                this.Nombre = nombre;
            }

            private int _EstatusConductor_ID;
            public int EstatusConductor_ID
            {
                get { return _EstatusConductor_ID; }
                set { _EstatusConductor_ID = value; }
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

                return DB.InsertRow("EstatusConductores", m_params);
            } // End Create

            public static List<EstatusConductores> Read()
            {
                List<EstatusConductores> list = new List<EstatusConductores>();
                DataTable dt = DB.Select("EstatusConductores");
                foreach (DataRow dr in dt.Rows)
                {
                    list.Add(new EstatusConductores(Convert.ToInt32(dr["EstatusConductor_ID"]), Convert.ToString(dr["Nombre"])));
                }

                return list;
            } // End Read

            public static List<EstatusConductores> Read(int estatusconductor_id)
            {
                List<EstatusConductores> list = new List<EstatusConductores>();
                Hashtable w_params = new Hashtable();
                w_params.Add("EstatusConductor_ID", estatusconductor_id);
                DataTable dt = DB.Select("EstatusConductores", w_params);
                foreach (DataRow dr in dt.Rows)
                {
                    list.Add(new EstatusConductores(Convert.ToInt32(dr["EstatusConductor_ID"]), Convert.ToString(dr["Nombre"])));
                }

                return list;
            } // End Read

            public int Update()
            {
                Hashtable m_params = new Hashtable();
                Hashtable w_params = new Hashtable();
                w_params.Add("EstatusConductor_ID", this.EstatusConductor_ID);
                m_params.Add("Nombre", this.Nombre);

                return DB.UpdateRow("EstatusConductores", m_params, w_params);
            } // End Update

            public int Delete()
            {
                Hashtable w_params = new Hashtable();
                w_params.Add("EstatusConductor_ID", this.EstatusConductor_ID);

                return DB.DeleteRow("EstatusConductores", w_params);
            }

        } //End Class EstatusConductores

        public class EstatusContratos
        {

            public EstatusContratos()
            {
            }

            public EstatusContratos(int estatuscontrato_id, string nombre)
            {
                this.EstatusContrato_ID = estatuscontrato_id;
                this.Nombre = nombre;
            }

            private int _EstatusContrato_ID;
            public int EstatusContrato_ID
            {
                get { return _EstatusContrato_ID; }
                set { _EstatusContrato_ID = value; }
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

                return DB.InsertRow("EstatusContratos", m_params);
            } // End Create

            public static List<EstatusContratos> Read()
            {
                List<EstatusContratos> list = new List<EstatusContratos>();
                DataTable dt = DB.Select("EstatusContratos");
                foreach (DataRow dr in dt.Rows)
                {
                    list.Add(new EstatusContratos(Convert.ToInt32(dr["EstatusContrato_ID"]), Convert.ToString(dr["Nombre"])));
                }

                return list;
            } // End Read

            public static List<EstatusContratos> Read(int estatuscontrato_id)
            {
                List<EstatusContratos> list = new List<EstatusContratos>();
                Hashtable w_params = new Hashtable();
                w_params.Add("EstatusContrato_ID", estatuscontrato_id);
                DataTable dt = DB.Select("EstatusContratos", w_params);
                foreach (DataRow dr in dt.Rows)
                {
                    list.Add(new EstatusContratos(Convert.ToInt32(dr["EstatusContrato_ID"]), Convert.ToString(dr["Nombre"])));
                }

                return list;
            } // End Read

            public int Update()
            {
                Hashtable m_params = new Hashtable();
                Hashtable w_params = new Hashtable();
                w_params.Add("EstatusContrato_ID", this.EstatusContrato_ID);
                m_params.Add("Nombre", this.Nombre);

                return DB.UpdateRow("EstatusContratos", m_params, w_params);
            } // End Update

            public int Delete()
            {
                Hashtable w_params = new Hashtable();
                w_params.Add("EstatusContrato_ID", this.EstatusContrato_ID);

                return DB.DeleteRow("EstatusContratos", w_params);
            }

        } //End Class EstatusContratos

        public class EstatusFacturas
        {

            public EstatusFacturas()
            {
            }

            public EstatusFacturas(int estatusfactura_id, string nombre)
            {
                this.EstatusFactura_ID = estatusfactura_id;
                this.Nombre = nombre;
            }

            private int _EstatusFactura_ID;
            public int EstatusFactura_ID
            {
                get { return _EstatusFactura_ID; }
                set { _EstatusFactura_ID = value; }
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

                return DB.InsertRow("EstatusFacturas", m_params);
            } // End Create

            public static List<EstatusFacturas> Read()
            {
                List<EstatusFacturas> list = new List<EstatusFacturas>();
                DataTable dt = DB.Select("EstatusFacturas");
                foreach (DataRow dr in dt.Rows)
                {
                    list.Add(new EstatusFacturas(Convert.ToInt32(dr["EstatusFactura_ID"]), Convert.ToString(dr["Nombre"])));
                }

                return list;
            } // End Read

            public static EstatusFacturas Read(int estatusfactura_id)
            {
                Hashtable w_params = new Hashtable();
                w_params.Add("EstatusFactura_ID", estatusfactura_id);
                DataTable dt = DB.Select("EstatusFacturas", w_params);
                if (dt.Rows.Count == 0)
                {
                    throw new Exception("No existe EstatusFacturas con los criterios de búsqueda especificados.");
                }
                DataRow dr = dt.Rows[0];
                return new EstatusFacturas(Convert.ToInt32(dr["EstatusFactura_ID"]), Convert.ToString(dr["Nombre"]));
            } // End Read

            public int Update()
            {
                Hashtable m_params = new Hashtable();
                Hashtable w_params = new Hashtable();
                w_params.Add("EstatusFactura_ID", this.EstatusFactura_ID);
                m_params.Add("Nombre", this.Nombre);

                return DB.UpdateRow("EstatusFacturas", m_params, w_params);
            } // End Update

            public int Delete()
            {
                Hashtable w_params = new Hashtable();
                w_params.Add("EstatusFactura_ID", this.EstatusFactura_ID);

                return DB.DeleteRow("EstatusFacturas", w_params);
            } // End Delete

        } //End Class EstatusFacturas

        public class EstatusFinancieros
        {

            public EstatusFinancieros()
            {
            }

            public EstatusFinancieros(int estatusfinanciero_id, string nombre)
            {
                this.EstatusFinanciero_ID = estatusfinanciero_id;
                this.Nombre = nombre;
            }

            private int _EstatusFinanciero_ID;
            public int EstatusFinanciero_ID
            {
                get { return _EstatusFinanciero_ID; }
                set { _EstatusFinanciero_ID = value; }
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

                return DB.InsertRow("EstatusFinancieros", m_params);
            } // End Create

            public static List<EstatusFinancieros> Read()
            {
                List<EstatusFinancieros> list = new List<EstatusFinancieros>();
                DataTable dt = DB.Select("EstatusFinancieros");
                foreach (DataRow dr in dt.Rows)
                {
                    list.Add(new EstatusFinancieros(Convert.ToInt32(dr["EstatusFinanciero_ID"]), Convert.ToString(dr["Nombre"])));
                }

                return list;
            } // End Read

            public static List<EstatusFinancieros> Read(int estatusfinanciero_id)
            {
                List<EstatusFinancieros> list = new List<EstatusFinancieros>();
                Hashtable w_params = new Hashtable();
                w_params.Add("EstatusFinanciero_ID", estatusfinanciero_id);
                DataTable dt = DB.Select("EstatusFinancieros", w_params);
                foreach (DataRow dr in dt.Rows)
                {
                    list.Add(new EstatusFinancieros(Convert.ToInt32(dr["EstatusFinanciero_ID"]), Convert.ToString(dr["Nombre"])));
                }

                return list;
            } // End Read

            public int Update()
            {
                Hashtable m_params = new Hashtable();
                Hashtable w_params = new Hashtable();
                w_params.Add("EstatusFinanciero_ID", this.EstatusFinanciero_ID);
                m_params.Add("Nombre", this.Nombre);

                return DB.UpdateRow("EstatusFinancieros", m_params, w_params);
            } // End Update

            public int Delete()
            {
                Hashtable w_params = new Hashtable();
                w_params.Add("EstatusFinanciero_ID", this.EstatusFinanciero_ID);

                return DB.DeleteRow("EstatusFinancieros", w_params);
            }

        } //End Class EstatusFinancieros

        public class EstatusMecanicos
        {

            public EstatusMecanicos()
            {
            }

            public EstatusMecanicos(int estatusmecanico_id, string nombre)
            {
                this.EstatusMecanico_ID = estatusmecanico_id;
                this.Nombre = nombre;
            }

            private int _EstatusMecanico_ID;
            public int EstatusMecanico_ID
            {
                get { return _EstatusMecanico_ID; }
                set { _EstatusMecanico_ID = value; }
            }

            private string _Nombre;
            public string Nombre
            {
                get { return _Nombre; }
                set { _Nombre = value; }
            }

            public int Create(bool IsIdentityInsert)
            {
                if (!IsIdentityInsert) return Create();

                Hashtable m_params = new Hashtable();
                m_params.Add("EstatusMecanico_ID", this.EstatusMecanico_ID);
                m_params.Add("Nombre", this.Nombre);

                return DB.IdentityInsertRow("EstatusMecanicos", m_params);
            } // End Create

            public int Create()
            {
                Hashtable m_params = new Hashtable();
                m_params.Add("Nombre", this.Nombre);

                return DB.InsertRow("EstatusMecanicos", m_params);
            } // End Create

            public static List<EstatusMecanicos> Read()
            {
                List<EstatusMecanicos> list = new List<EstatusMecanicos>();
                DataTable dt = DB.Select("EstatusMecanicos");
                foreach (DataRow dr in dt.Rows)
                {
                    list.Add(new EstatusMecanicos(Convert.ToInt32(dr["EstatusMecanico_ID"]), Convert.ToString(dr["Nombre"])));
                }

                return list;
            } // End Read

            public static EstatusMecanicos Read(int estatusmecanico_id)
            {
                Hashtable w_params = new Hashtable();
                w_params.Add("EstatusMecanico_ID", estatusmecanico_id);
                DataTable dt = DB.Select("EstatusMecanicos", w_params);
                if (dt.Rows.Count == 0)
                {
                    throw new Exception("No existe EstatusMecanicos con los criterios de búsqueda especificados.");
                }
                DataRow dr = dt.Rows[0];
                return new EstatusMecanicos(Convert.ToInt32(dr["EstatusMecanico_ID"]), Convert.ToString(dr["Nombre"]));
            } // End Read

            public int Update()
            {
                Hashtable m_params = new Hashtable();
                Hashtable w_params = new Hashtable();
                w_params.Add("EstatusMecanico_ID", this.EstatusMecanico_ID);
                m_params.Add("Nombre", this.Nombre);

                return DB.UpdateRow("EstatusMecanicos", m_params, w_params);
            } // End Update

            public int Delete()
            {
                Hashtable w_params = new Hashtable();
                w_params.Add("EstatusMecanico_ID", this.EstatusMecanico_ID);

                return DB.DeleteRow("EstatusMecanicos", w_params);
            } // End Delete

        } //End Class EstatusMecanicos

        public class EstatusOrdenesCompras
        {

            public EstatusOrdenesCompras()
            {
            }

            public EstatusOrdenesCompras(int estatusordencompra_id, string nombre)
            {
                this.EstatusOrdenCompra_ID = estatusordencompra_id;
                this.Nombre = nombre;
            }

            private int _EstatusOrdenCompra_ID;
            public int EstatusOrdenCompra_ID
            {
                get { return _EstatusOrdenCompra_ID; }
                set { _EstatusOrdenCompra_ID = value; }
            }

            private string _Nombre;
            public string Nombre
            {
                get { return _Nombre; }
                set { _Nombre = value; }
            }

            public int Create(bool IsIdentityInsert)
            {
                if (!IsIdentityInsert) return Create();

                Hashtable m_params = new Hashtable();
                m_params.Add("EstatusOrdenCompra_ID", this.EstatusOrdenCompra_ID);
                m_params.Add("Nombre", this.Nombre);

                return DB.IdentityInsertRow("EstatusOrdenesCompras", m_params);
            } // End Create

            public int Create()
            {
                Hashtable m_params = new Hashtable();
                m_params.Add("Nombre", this.Nombre);

                return DB.InsertRow("EstatusOrdenesCompras", m_params);
            } // End Create

            public static List<EstatusOrdenesCompras> Read()
            {
                List<EstatusOrdenesCompras> list = new List<EstatusOrdenesCompras>();
                DataTable dt = DB.Select("EstatusOrdenesCompras");
                foreach (DataRow dr in dt.Rows)
                {
                    list.Add(new EstatusOrdenesCompras(Convert.ToInt32(dr["EstatusOrdenCompra_ID"]), Convert.ToString(dr["Nombre"])));
                }

                return list;
            } // End Read

            public static EstatusOrdenesCompras Read(int estatusordencompra_id)
            {
                Hashtable w_params = new Hashtable();
                w_params.Add("EstatusOrdenCompra_ID", estatusordencompra_id);
                DataTable dt = DB.Select("EstatusOrdenesCompras", w_params);
                if (dt.Rows.Count == 0)
                {
                    throw new Exception("No existe EstatusOrdenesCompras con los criterios de búsqueda especificados.");
                }
                DataRow dr = dt.Rows[0];
                return new EstatusOrdenesCompras(Convert.ToInt32(dr["EstatusOrdenCompra_ID"]), Convert.ToString(dr["Nombre"]));
            } // End Read

            public int Update()
            {
                Hashtable m_params = new Hashtable();
                Hashtable w_params = new Hashtable();
                w_params.Add("EstatusOrdenCompra_ID", this.EstatusOrdenCompra_ID);
                m_params.Add("Nombre", this.Nombre);

                return DB.UpdateRow("EstatusOrdenesCompras", m_params, w_params);
            } // End Update

            public int Delete()
            {
                Hashtable w_params = new Hashtable();
                w_params.Add("EstatusOrdenCompra_ID", this.EstatusOrdenCompra_ID);

                return DB.DeleteRow("EstatusOrdenesCompras", w_params);
            } // End Delete

        } //End Class EstatusOrdenesCompras

        public class EstatusOrdenesServicios
        {

            public EstatusOrdenesServicios()
            {
            }

            public EstatusOrdenesServicios(int estatusordenservicio_id, string nombre)
            {
                this.EstatusOrdenServicio_ID = estatusordenservicio_id;
                this.Nombre = nombre;
            }

            private int _EstatusOrdenServicio_ID;
            public int EstatusOrdenServicio_ID
            {
                get { return _EstatusOrdenServicio_ID; }
                set { _EstatusOrdenServicio_ID = value; }
            }

            private string _Nombre;
            public string Nombre
            {
                get { return _Nombre; }
                set { _Nombre = value; }
            }

            public int Create(bool IsIdentityInsert)
            {
                if (!IsIdentityInsert) return Create();

                Hashtable m_params = new Hashtable();
                m_params.Add("EstatusOrdenServicio_ID", this.EstatusOrdenServicio_ID);
                m_params.Add("Nombre", this.Nombre);

                return DB.IdentityInsertRow("EstatusOrdenesServicios", m_params);
            } // End Create

            public int Create()
            {
                Hashtable m_params = new Hashtable();
                m_params.Add("Nombre", this.Nombre);

                return DB.InsertRow("EstatusOrdenesServicios", m_params);
            } // End Create

            public static List<EstatusOrdenesServicios> Read()
            {
                List<EstatusOrdenesServicios> list = new List<EstatusOrdenesServicios>();
                DataTable dt = DB.Select("EstatusOrdenesServicios");
                foreach (DataRow dr in dt.Rows)
                {
                    list.Add(new EstatusOrdenesServicios(Convert.ToInt32(dr["EstatusOrdenServicio_ID"]), Convert.ToString(dr["Nombre"])));
                }

                return list;
            } // End Read

            public static EstatusOrdenesServicios Read(int estatusordenservicio_id)
            {
                Hashtable w_params = new Hashtable();
                w_params.Add("EstatusOrdenServicio_ID", estatusordenservicio_id);
                DataTable dt = DB.Select("EstatusOrdenesServicios", w_params);
                if (dt.Rows.Count == 0)
                {
                    throw new Exception("No existe EstatusOrdenesServicios con los criterios de búsqueda especificados.");
                }
                DataRow dr = dt.Rows[0];
                return new EstatusOrdenesServicios(Convert.ToInt32(dr["EstatusOrdenServicio_ID"]), Convert.ToString(dr["Nombre"]));
            } // End Read

            public int Update()
            {
                Hashtable m_params = new Hashtable();
                Hashtable w_params = new Hashtable();
                w_params.Add("EstatusOrdenServicio_ID", this.EstatusOrdenServicio_ID);
                m_params.Add("Nombre", this.Nombre);

                return DB.UpdateRow("EstatusOrdenesServicios", m_params, w_params);
            } // End Update

            public int Delete()
            {
                Hashtable w_params = new Hashtable();
                w_params.Add("EstatusOrdenServicio_ID", this.EstatusOrdenServicio_ID);

                return DB.DeleteRow("EstatusOrdenesServicios", w_params);
            } // End Delete

        } //End Class EstatusOrdenesServicios

        public class EstatusOrdenesTrabajos
        {

            public EstatusOrdenesTrabajos()
            {
            }

            public EstatusOrdenesTrabajos(int estatusordentrabajo_id, string nombre)
            {
                this.EstatusOrdenTrabajo_ID = estatusordentrabajo_id;
                this.Nombre = nombre;
            }

            private int _EstatusOrdenTrabajo_ID;
            public int EstatusOrdenTrabajo_ID
            {
                get { return _EstatusOrdenTrabajo_ID; }
                set { _EstatusOrdenTrabajo_ID = value; }
            }

            private string _Nombre;
            public string Nombre
            {
                get { return _Nombre; }
                set { _Nombre = value; }
            }

            public int Create(bool IsIdentityInsert)
            {
                if (!IsIdentityInsert) return Create();

                Hashtable m_params = new Hashtable();
                m_params.Add("EstatusOrdenTrabajo_ID", this.EstatusOrdenTrabajo_ID);
                m_params.Add("Nombre", this.Nombre);

                return DB.IdentityInsertRow("EstatusOrdenesTrabajos", m_params);
            } // End Create

            public int Create()
            {
                Hashtable m_params = new Hashtable();
                m_params.Add("Nombre", this.Nombre);

                return DB.InsertRow("EstatusOrdenesTrabajos", m_params);
            } // End Create

            public static List<EstatusOrdenesTrabajos> Read()
            {
                List<EstatusOrdenesTrabajos> list = new List<EstatusOrdenesTrabajos>();
                DataTable dt = DB.Select("EstatusOrdenesTrabajos");
                foreach (DataRow dr in dt.Rows)
                {
                    list.Add(new EstatusOrdenesTrabajos(Convert.ToInt32(dr["EstatusOrdenTrabajo_ID"]), Convert.ToString(dr["Nombre"])));
                }

                return list;
            } // End Read

            public static EstatusOrdenesTrabajos Read(int estatusordentrabajo_id)
            {
                Hashtable w_params = new Hashtable();
                w_params.Add("EstatusOrdenTrabajo_ID", estatusordentrabajo_id);
                DataTable dt = DB.Select("EstatusOrdenesTrabajos", w_params);
                if (dt.Rows.Count == 0)
                {
                    throw new Exception("No existe EstatusOrdenesTrabajos con los criterios de búsqueda especificados.");
                }
                DataRow dr = dt.Rows[0];
                return new EstatusOrdenesTrabajos(Convert.ToInt32(dr["EstatusOrdenTrabajo_ID"]), Convert.ToString(dr["Nombre"]));
            } // End Read

            public int Update()
            {
                Hashtable m_params = new Hashtable();
                Hashtable w_params = new Hashtable();
                w_params.Add("EstatusOrdenTrabajo_ID", this.EstatusOrdenTrabajo_ID);
                m_params.Add("Nombre", this.Nombre);

                return DB.UpdateRow("EstatusOrdenesTrabajos", m_params, w_params);
            } // End Update

            public int Delete()
            {
                Hashtable w_params = new Hashtable();
                w_params.Add("EstatusOrdenTrabajo_ID", this.EstatusOrdenTrabajo_ID);

                return DB.DeleteRow("EstatusOrdenesTrabajos", w_params);
            } // End Delete

        } //End Class EstatusOrdenesTrabajos

        public class EstatusServicios
        {

            public EstatusServicios()
            {
            }

            public EstatusServicios(int estatusservicio_id, string nombre)
            {
                this.EstatusServicio_ID = estatusservicio_id;
                this.Nombre = nombre;
            }

            private int _EstatusServicio_ID;
            public int EstatusServicio_ID
            {
                get { return _EstatusServicio_ID; }
                set { _EstatusServicio_ID = value; }
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

                return DB.InsertRow("EstatusServicios", m_params);
            } // End Create

            public static List<EstatusServicios> Read()
            {
                List<EstatusServicios> list = new List<EstatusServicios>();
                DataTable dt = DB.Select("EstatusServicios");
                foreach (DataRow dr in dt.Rows)
                {
                    list.Add(new EstatusServicios(Convert.ToInt32(dr["EstatusServicio_ID"]), Convert.ToString(dr["Nombre"])));
                }

                return list;
            } // End Read

            public static List<EstatusServicios> Read(int estatusservicio_id)
            {
                List<EstatusServicios> list = new List<EstatusServicios>();
                Hashtable w_params = new Hashtable();
                w_params.Add("EstatusServicio_ID", estatusservicio_id);
                DataTable dt = DB.Select("EstatusServicios", w_params);
                foreach (DataRow dr in dt.Rows)
                {
                    list.Add(new EstatusServicios(Convert.ToInt32(dr["EstatusServicio_ID"]), Convert.ToString(dr["Nombre"])));
                }

                return list;
            } // End Read

            public int Update()
            {
                Hashtable m_params = new Hashtable();
                Hashtable w_params = new Hashtable();
                w_params.Add("EstatusServicio_ID", this.EstatusServicio_ID);
                m_params.Add("Nombre", this.Nombre);

                return DB.UpdateRow("EstatusServicios", m_params, w_params);
            } // End Update

            public int Delete()
            {
                Hashtable w_params = new Hashtable();
                w_params.Add("EstatusServicio_ID", this.EstatusServicio_ID);

                return DB.DeleteRow("EstatusServicios", w_params);
            }

        } //End Class EstatusServicios

        public class EstatusTickets
        {

            public EstatusTickets()
            {
            }

            public EstatusTickets(int estatusticket_id, string nombre)
            {
                this.EstatusTicket_ID = estatusticket_id;
                this.Nombre = nombre;
            }

            private int _EstatusTicket_ID;
            public int EstatusTicket_ID
            {
                get { return _EstatusTicket_ID; }
                set { _EstatusTicket_ID = value; }
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

                return DB.InsertRow("EstatusTickets", m_params);
            } // End Create

            public static List<EstatusTickets> Read()
            {
                List<EstatusTickets> list = new List<EstatusTickets>();
                DataTable dt = DB.Select("EstatusTickets");
                foreach (DataRow dr in dt.Rows)
                {
                    list.Add(new EstatusTickets(Convert.ToInt32(dr["EstatusTicket_ID"]), Convert.ToString(dr["Nombre"])));
                }

                return list;
            } // End Read

            public static List<EstatusTickets> Read(int estatusticket_id)
            {
                List<EstatusTickets> list = new List<EstatusTickets>();
                Hashtable w_params = new Hashtable();
                w_params.Add("EstatusTicket_ID", estatusticket_id);
                DataTable dt = DB.Select("EstatusTickets", w_params);
                foreach (DataRow dr in dt.Rows)
                {
                    list.Add(new EstatusTickets(Convert.ToInt32(dr["EstatusTicket_ID"]), Convert.ToString(dr["Nombre"])));
                }

                return list;
            } // End Read

            public int Update()
            {
                Hashtable m_params = new Hashtable();
                Hashtable w_params = new Hashtable();
                w_params.Add("EstatusTicket_ID", this.EstatusTicket_ID);
                m_params.Add("Nombre", this.Nombre);

                return DB.UpdateRow("EstatusTickets", m_params, w_params);
            } // End Update

            public int Delete()
            {
                Hashtable w_params = new Hashtable();
                w_params.Add("EstatusTicket_ID", this.EstatusTicket_ID);

                return DB.DeleteRow("EstatusTickets", w_params);
            }

        } //End Class EstatusTickets

        public class EstatusUnidades
        {

            public EstatusUnidades()
            {
            }

            public EstatusUnidades(int estatusunidad_id, string nombre)
            {
                this.EstatusUnidad_ID = estatusunidad_id;
                this.Nombre = nombre;
            }

            private int _EstatusUnidad_ID;
            public int EstatusUnidad_ID
            {
                get { return _EstatusUnidad_ID; }
                set { _EstatusUnidad_ID = value; }
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

                return DB.InsertRow("EstatusUnidades", m_params);
            } // End Create

            public static List<EstatusUnidades> Read()
            {
                List<EstatusUnidades> list = new List<EstatusUnidades>();
                DataTable dt = DB.Select("EstatusUnidades");
                foreach (DataRow dr in dt.Rows)
                {
                    list.Add(new EstatusUnidades(Convert.ToInt32(dr["EstatusUnidad_ID"]), Convert.ToString(dr["Nombre"])));
                }

                return list;
            } // End Read

            public static List<EstatusUnidades> Read(int estatusunidad_id)
            {
                List<EstatusUnidades> list = new List<EstatusUnidades>();
                Hashtable w_params = new Hashtable();
                w_params.Add("EstatusUnidad_ID", estatusunidad_id);
                DataTable dt = DB.Select("EstatusUnidades", w_params);
                foreach (DataRow dr in dt.Rows)
                {
                    list.Add(new EstatusUnidades(Convert.ToInt32(dr["EstatusUnidad_ID"]), Convert.ToString(dr["Nombre"])));
                }

                return list;
            } // End Read

            public int Update()
            {
                Hashtable m_params = new Hashtable();
                Hashtable w_params = new Hashtable();
                w_params.Add("EstatusUnidad_ID", this.EstatusUnidad_ID);
                m_params.Add("Nombre", this.Nombre);

                return DB.UpdateRow("EstatusUnidades", m_params, w_params);
            } // End Update

            public int Delete()
            {
                Hashtable w_params = new Hashtable();
                w_params.Add("EstatusUnidad_ID", this.EstatusUnidad_ID);

                return DB.DeleteRow("EstatusUnidades", w_params);
            }

        } //End Class EstatusUnidades

        public class Facturas
        {

            public Facturas()
            {
            }

            public Facturas(int factura_id, string foliofiscal, int empresaemisora_id, int empresareceptora_id, int estatusfactura_id, decimal subtotal, decimal impuestos, decimal total, DateTime fechaemision)
            {
                this.Factura_ID = factura_id;
                this.FolioFiscal = foliofiscal;
                this.EmpresaEmisora_ID = empresaemisora_id;
                this.EmpresaReceptora_ID = empresareceptora_id;
                this.EstatusFactura_ID = estatusfactura_id;
                this.Subtotal = subtotal;
                this.Impuestos = impuestos;
                this.Total = total;
                this.FechaEmision = fechaemision;
            }

            private int _Factura_ID;
            public int Factura_ID
            {
                get { return _Factura_ID; }
                set { _Factura_ID = value; }
            }

            private string _FolioFiscal;
            public string FolioFiscal
            {
                get { return _FolioFiscal; }
                set { _FolioFiscal = value; }
            }

            private int _EmpresaEmisora_ID;
            public int EmpresaEmisora_ID
            {
                get { return _EmpresaEmisora_ID; }
                set { _EmpresaEmisora_ID = value; }
            }

            private int _EmpresaReceptora_ID;
            public int EmpresaReceptora_ID
            {
                get { return _EmpresaReceptora_ID; }
                set { _EmpresaReceptora_ID = value; }
            }

            private int _EstatusFactura_ID;
            public int EstatusFactura_ID
            {
                get { return _EstatusFactura_ID; }
                set { _EstatusFactura_ID = value; }
            }

            private decimal _Subtotal;
            public decimal Subtotal
            {
                get { return _Subtotal; }
                set { _Subtotal = value; }
            }

            private decimal _Impuestos;
            public decimal Impuestos
            {
                get { return _Impuestos; }
                set { _Impuestos = value; }
            }

            private decimal _Total;
            public decimal Total
            {
                get { return _Total; }
                set { _Total = value; }
            }

            private DateTime _FechaEmision;
            public DateTime FechaEmision
            {
                get { return _FechaEmision; }
                set { _FechaEmision = value; }
            }

            public int Create()
            {
                Hashtable m_params = new Hashtable();
                m_params.Add("FolioFiscal", this.FolioFiscal);
                m_params.Add("EmpresaEmisora_ID", this.EmpresaEmisora_ID);
                m_params.Add("EmpresaReceptora_ID", this.EmpresaReceptora_ID);
                m_params.Add("EstatusFactura_ID", this.EstatusFactura_ID);
                m_params.Add("Subtotal", this.Subtotal);
                m_params.Add("Impuestos", this.Impuestos);
                m_params.Add("Total", this.Total);
                m_params.Add("FechaEmision", this.FechaEmision);

                return DB.InsertRow("Facturas", m_params);
            } // End Create

            public static List<Facturas> Read()
            {
                List<Facturas> list = new List<Facturas>();
                DataTable dt = DB.Select("Facturas");
                foreach (DataRow dr in dt.Rows)
                {
                    list.Add(new Facturas(Convert.ToInt32(dr["Factura_ID"]), Convert.ToString(dr["FolioFiscal"]), Convert.ToInt32(dr["EmpresaEmisora_ID"]), Convert.ToInt32(dr["EmpresaReceptora_ID"]), Convert.ToInt32(dr["EstatusFactura_ID"]), Convert.ToDecimal(dr["Subtotal"]), Convert.ToDecimal(dr["Impuestos"]), Convert.ToDecimal(dr["Total"]), Convert.ToDateTime(dr["FechaEmision"])));
                }

                return list;
            } // End Read

            public static Facturas Read(int factura_id)
            {
                Hashtable w_params = new Hashtable();
                w_params.Add("Factura_ID", factura_id);
                DataTable dt = DB.Select("Facturas", w_params);
                if (dt.Rows.Count == 0)
                {
                    throw new Exception("No existe Facturas con los criterios de búsqueda especificados.");
                }
                DataRow dr = dt.Rows[0];
                return new Facturas(Convert.ToInt32(dr["Factura_ID"]), Convert.ToString(dr["FolioFiscal"]), Convert.ToInt32(dr["EmpresaEmisora_ID"]), Convert.ToInt32(dr["EmpresaReceptora_ID"]), Convert.ToInt32(dr["EstatusFactura_ID"]), Convert.ToDecimal(dr["Subtotal"]), Convert.ToDecimal(dr["Impuestos"]), Convert.ToDecimal(dr["Total"]), Convert.ToDateTime(dr["FechaEmision"]));
            } // End Read

            public int Update()
            {
                Hashtable m_params = new Hashtable();
                Hashtable w_params = new Hashtable();
                w_params.Add("Factura_ID", this.Factura_ID);
                m_params.Add("FolioFiscal", this.FolioFiscal);
                m_params.Add("EmpresaEmisora_ID", this.EmpresaEmisora_ID);
                m_params.Add("EmpresaReceptora_ID", this.EmpresaReceptora_ID);
                m_params.Add("EstatusFactura_ID", this.EstatusFactura_ID);
                m_params.Add("Subtotal", this.Subtotal);
                m_params.Add("Impuestos", this.Impuestos);
                m_params.Add("Total", this.Total);
                m_params.Add("FechaEmision", this.FechaEmision);

                return DB.UpdateRow("Facturas", m_params, w_params);
            } // End Update

            public int Delete()
            {
                Hashtable w_params = new Hashtable();
                w_params.Add("Factura_ID", this.Factura_ID);

                return DB.DeleteRow("Facturas", w_params);
            } // End Delete

        } //End Class Facturas

        public class Familias
        {

            public Familias()
            {
            }

            public Familias(int familia_id, string nombre)
            {
                this.Familia_ID = familia_id;
                this.Nombre = nombre;
            }

            private int _Familia_ID;
            public int Familia_ID
            {
                get { return _Familia_ID; }
                set { _Familia_ID = value; }
            }

            private string _Nombre;
            public string Nombre
            {
                get { return _Nombre; }
                set { _Nombre = value; }
            }

            public int Create(bool IsIdentityInsert)
            {
                if (!IsIdentityInsert) return Create();

                Hashtable m_params = new Hashtable();
                m_params.Add("Familia_ID", this.Familia_ID);
                m_params.Add("Nombre", this.Nombre);

                return DB.IdentityInsertRow("Familias", m_params);
            } // End Create

            public int Create()
            {
                Hashtable m_params = new Hashtable();
                m_params.Add("Nombre", this.Nombre);

                return DB.InsertRow("Familias", m_params);
            } // End Create

            public static List<Familias> Read()
            {
                List<Familias> list = new List<Familias>();
                DataTable dt = DB.Select("Familias");
                foreach (DataRow dr in dt.Rows)
                {
                    list.Add(new Familias(Convert.ToInt32(dr["Familia_ID"]), Convert.ToString(dr["Nombre"])));
                }

                return list;
            } // End Read

            public static Familias Read(int familia_id)
            {
                Hashtable w_params = new Hashtable();
                w_params.Add("Familia_ID", familia_id);
                DataTable dt = DB.Select("Familias", w_params);
                if (dt.Rows.Count == 0)
                {
                    throw new Exception("No existe Familias con los criterios de búsqueda especificados.");
                }
                DataRow dr = dt.Rows[0];
                return new Familias(Convert.ToInt32(dr["Familia_ID"]), Convert.ToString(dr["Nombre"]));
            } // End Read

            public int Update()
            {
                Hashtable m_params = new Hashtable();
                Hashtable w_params = new Hashtable();
                w_params.Add("Familia_ID", this.Familia_ID);
                m_params.Add("Nombre", this.Nombre);

                return DB.UpdateRow("Familias", m_params, w_params);
            } // End Update

            public int Delete()
            {
                Hashtable w_params = new Hashtable();
                w_params.Add("Familia_ID", this.Familia_ID);

                return DB.DeleteRow("Familias", w_params);
            } // End Delete

        } //End Class Familias

	    public class HistorialCobranzaConductores
	    {

		    public HistorialCobranzaConductores()
		    {
		    }

		    public HistorialCobranzaConductores(int historialcobranzaconductor_id, int conductor_id, string usuario_id, int estacion_id, string accion, string comentario, int? referencia_id, DateTime? fecha)
		    {
			    this.HistorialCobranzaConductor_ID = historialcobranzaconductor_id;
			    this.Conductor_ID = conductor_id;
			    this.Usuario_ID = usuario_id;
			    this.Estacion_ID = estacion_id;
			    this.Accion = accion;
			    this.Comentario = comentario;
			    this.Referencia_ID = referencia_id;
			    this.Fecha = fecha;
		    }

		    private int _HistorialCobranzaConductor_ID;
		    public int HistorialCobranzaConductor_ID
		    {
			    get { return _HistorialCobranzaConductor_ID; }
			    set { _HistorialCobranzaConductor_ID = value; }
		    }

		    private int _Conductor_ID;
		    public int Conductor_ID
		    {
			    get { return _Conductor_ID; }
			    set { _Conductor_ID = value; }
		    }

		    private string _Usuario_ID;
		    public string Usuario_ID
		    {
			    get { return _Usuario_ID; }
			    set { _Usuario_ID = value; }
		    }

		    private int _Estacion_ID;
		    public int Estacion_ID
		    {
			    get { return _Estacion_ID; }
			    set { _Estacion_ID = value; }
		    }

		    private string _Accion;
		    public string Accion
		    {
			    get { return _Accion; }
			    set { _Accion = value; }
		    }

		    private string _Comentario;
		    public string Comentario
		    {
			    get { return _Comentario; }
			    set { _Comentario = value; }
		    }

		    private int? _Referencia_ID;
		    public int? Referencia_ID
		    {
			    get { return _Referencia_ID; }
			    set { _Referencia_ID = value; }
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
			    m_params.Add("Conductor_ID", this.Conductor_ID);
			    m_params.Add("Usuario_ID", this.Usuario_ID);
			    m_params.Add("Estacion_ID", this.Estacion_ID);
			    m_params.Add("Accion", this.Accion);
			    m_params.Add("Comentario", this.Comentario);
			    if (!AppHelper.IsNullOrEmpty(this.Referencia_ID)) m_params.Add("Referencia_ID", this.Referencia_ID);
			    if (!AppHelper.IsNullOrEmpty(this.Fecha)) m_params.Add("Fecha", this.Fecha);

			    return DB.InsertRow("HistorialCobranzaConductores", m_params);
		    } // End Create

		    public int Create(bool IsIdentityInsert)
		    {
			    if (!IsIdentityInsert) return Create();
			    Hashtable m_params = new Hashtable();
			    m_params.Add("HistorialCobranzaConductor_ID", this.HistorialCobranzaConductor_ID);
			    m_params.Add("Conductor_ID", this.Conductor_ID);
			    m_params.Add("Usuario_ID", this.Usuario_ID);
			    m_params.Add("Estacion_ID", this.Estacion_ID);
			    m_params.Add("Accion", this.Accion);
			    m_params.Add("Comentario", this.Comentario);
			    if (!AppHelper.IsNullOrEmpty(this.Referencia_ID)) m_params.Add("Referencia_ID", this.Referencia_ID);
			    if (!AppHelper.IsNullOrEmpty(this.Fecha)) m_params.Add("Fecha", this.Fecha);

			    return DB.IdentityInsertRow("HistorialCobranzaConductores", m_params);
		    } // End Create

		    public static List<HistorialCobranzaConductores> Read()
		    {
			    List<HistorialCobranzaConductores> list = new List<HistorialCobranzaConductores>();
			    DataTable dt = DB.Select("HistorialCobranzaConductores");
			    foreach (DataRow dr in dt.Rows)
			    {
				    list.Add(new HistorialCobranzaConductores(Convert.ToInt32(dr["HistorialCobranzaConductor_ID"]), Convert.ToInt32(dr["Conductor_ID"]), Convert.ToString(dr["Usuario_ID"]), Convert.ToInt32(dr["Estacion_ID"]), Convert.ToString(dr["Accion"]), Convert.ToString(dr["Comentario"]), DB.GetNullableInt32(dr["Referencia_ID"]), DB.GetNullableDateTime(dr["Fecha"])));
			    }

			    return list;
		    } // End Read

		    public static HistorialCobranzaConductores Read(int historialcobranzaconductor_id)
		    {
			    Hashtable w_params = new Hashtable();
			    w_params.Add("HistorialCobranzaConductor_ID", historialcobranzaconductor_id);
			    DataTable dt = DB.Select("HistorialCobranzaConductores", w_params);
			    if ( dt.Rows.Count == 0 )
			    {
				    throw new Exception("No existe HistorialCobranzaConductores con los criterios de búsqueda especificados.");
			    }
			    DataRow dr = dt.Rows[0];
			    return new HistorialCobranzaConductores(Convert.ToInt32(dr["HistorialCobranzaConductor_ID"]), Convert.ToInt32(dr["Conductor_ID"]), Convert.ToString(dr["Usuario_ID"]), Convert.ToInt32(dr["Estacion_ID"]), Convert.ToString(dr["Accion"]), Convert.ToString(dr["Comentario"]), DB.GetNullableInt32(dr["Referencia_ID"]), DB.GetNullableDateTime(dr["Fecha"]));
		    } // End Read

		    public static HistorialCobranzaConductores Read(params KeyValuePair<string,object>[] args)		{
			    DataTable dt = DB.Read("HistorialCobranzaConductores", args);
			    if ( dt.Rows.Count == 0 )
			    {
				    return null;
			    }
			    DataRow dr = dt.Rows[0];
			    return new HistorialCobranzaConductores(Convert.ToInt32(dr["HistorialCobranzaConductor_ID"]), Convert.ToInt32(dr["Conductor_ID"]), Convert.ToString(dr["Usuario_ID"]), Convert.ToInt32(dr["Estacion_ID"]), Convert.ToString(dr["Accion"]), Convert.ToString(dr["Comentario"]), DB.GetNullableInt32(dr["Referencia_ID"]), DB.GetNullableDateTime(dr["Fecha"]));
		    } // End Read

		    public static bool Read(out HistorialCobranzaConductores historialcobranzaconductores, int top, string filter, string sort, params KeyValuePair<string, object>[] args)		{
			    DataTable dt = DB.Read("HistorialCobranzaConductores", top, filter, sort, args);
			    if ( dt.Rows.Count == 0 )
			    {
				    historialcobranzaconductores = null; 
				    return false;
			    }
			    DataRow dr = dt.Rows[0];
			    historialcobranzaconductores = new HistorialCobranzaConductores(Convert.ToInt32(dr["HistorialCobranzaConductor_ID"]), Convert.ToInt32(dr["Conductor_ID"]), Convert.ToString(dr["Usuario_ID"]), Convert.ToInt32(dr["Estacion_ID"]), Convert.ToString(dr["Accion"]), Convert.ToString(dr["Comentario"]), DB.GetNullableInt32(dr["Referencia_ID"]), DB.GetNullableDateTime(dr["Fecha"]));
			    return true;
		    } // End Read

		    public static DataTable ReadDataTable()
		    {
			    return DB.Select("HistorialCobranzaConductores");
		    } // End Read

		    public static DataTable ReadDataTable(int historialcobranzaconductor_id)
		    {
			    Hashtable w_params = new Hashtable();
			    w_params.Add("HistorialCobranzaConductor_ID", historialcobranzaconductor_id);
			    return DB.Select("HistorialCobranzaConductores", w_params);
		    } // End Read

		    public int Update()
		    {
			    Hashtable m_params = new Hashtable();
			    Hashtable w_params = new Hashtable();
			    w_params.Add("HistorialCobranzaConductor_ID", this.HistorialCobranzaConductor_ID);
			    m_params.Add("Conductor_ID", this.Conductor_ID);
			    m_params.Add("Usuario_ID", this.Usuario_ID);
			    m_params.Add("Estacion_ID", this.Estacion_ID);
			    m_params.Add("Accion", this.Accion);
			    m_params.Add("Comentario", this.Comentario);
			    if (!AppHelper.IsNullOrEmpty(this.Referencia_ID)) m_params.Add("Referencia_ID", this.Referencia_ID);
			    if (!AppHelper.IsNullOrEmpty(this.Fecha)) m_params.Add("Fecha", this.Fecha);

			    return DB.UpdateRow("HistorialCobranzaConductores", m_params, w_params);
		    } // End Update

		    public int Delete()
		    {
			    Hashtable w_params = new Hashtable();
			    w_params.Add("HistorialCobranzaConductor_ID", this.HistorialCobranzaConductor_ID);

			    return DB.DeleteRow("HistorialCobranzaConductores", w_params);
		    } // End Delete

	    } //End Class HistorialCobranzaConductores

        public class Indicadores
        {

            public Indicadores()
            {
            }

            public Indicadores(int indicador_id, string nombre)
            {
                this.Indicador_ID = indicador_id;
                this.Nombre = nombre;
            }

            private int _Indicador_ID;
            public int Indicador_ID
            {
                get { return _Indicador_ID; }
                set { _Indicador_ID = value; }
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

                return DB.InsertRow("Indicadores", m_params);
            } // End Create

            public static List<Indicadores> Read()
            {
                List<Indicadores> list = new List<Indicadores>();
                DataTable dt = DB.Select("Indicadores");
                foreach (DataRow dr in dt.Rows)
                {
                    list.Add(new Indicadores(Convert.ToInt32(dr["Indicador_ID"]), Convert.ToString(dr["Nombre"])));
                }

                return list;
            } // End Read

            public static List<Indicadores> Read(int indicador_id)
            {
                List<Indicadores> list = new List<Indicadores>();
                Hashtable w_params = new Hashtable();
                w_params.Add("Indicador_ID", indicador_id);
                DataTable dt = DB.Select("Indicadores", w_params);
                foreach (DataRow dr in dt.Rows)
                {
                    list.Add(new Indicadores(Convert.ToInt32(dr["Indicador_ID"]), Convert.ToString(dr["Nombre"])));
                }

                return list;
            } // End Read

            public int Update()
            {
                Hashtable m_params = new Hashtable();
                Hashtable w_params = new Hashtable();
                w_params.Add("Indicador_ID", this.Indicador_ID);
                m_params.Add("Nombre", this.Nombre);

                return DB.UpdateRow("Indicadores", m_params, w_params);
            } // End Update

            public int Delete()
            {
                Hashtable w_params = new Hashtable();
                w_params.Add("Indicador_ID", this.Indicador_ID);

                return DB.DeleteRow("Indicadores", w_params);
            }

        } //End Class Indicadores

        public class Inventario
        {

            #region Constructors

            public Inventario()
            {
            }

            public Inventario(
                int empresa_id,
                int estacion_id,
                int refaccion_id,
                string pasillo,
                string estante,
                string nivel,
                string seccion,
                decimal costounitario,
                decimal preciointerno,
                decimal precioexterno,
                decimal margeninterno,
                decimal margenexterno,
                int cantidadinventario,
                decimal valorinventario,
                int puntodereorden)
            {
                this.Empresa_ID = empresa_id;
                this.Estacion_ID = estacion_id;
                this.Refaccion_ID = refaccion_id;
                this.Pasillo = pasillo;
                this.Estante = estante;
                this.Nivel = nivel;
                this.Seccion = seccion;
                this.CostoUnitario = costounitario;
                this.PrecioInterno = preciointerno;
                this.PrecioExterno = precioexterno;
                this.MargenInterno = margeninterno;
                this.MargenExterno = margenexterno;
                this.CantidadInventario = cantidadinventario;
                this.ValorInventario = valorinventario;
                this.PuntoDeReOrden = puntodereorden;
            }

            #endregion

            #region Properties

            private int _Empresa_ID;
            public int Empresa_ID
            {
                get { return _Empresa_ID; }
                set { _Empresa_ID = value; }
            }

            private int _Estacion_ID;
            public int Estacion_ID
            {
                get { return _Estacion_ID; }
                set { _Estacion_ID = value; }
            }

            private int _Refaccion_ID;
            public int Refaccion_ID
            {
                get { return _Refaccion_ID; }
                set { _Refaccion_ID = value; }
            }

            private string _Pasillo;
            public string Pasillo
            {
                get { return _Pasillo; }
                set { _Pasillo = value; }
            }

            private string _Estante;
            public string Estante
            {
                get { return _Estante; }
                set { _Estante = value; }
            }

            private string _Nivel;
            public string Nivel
            {
                get { return _Nivel; }
                set { _Nivel = value; }
            }

            private string _Seccion;
            public string Seccion
            {
                get { return _Seccion; }
                set { _Seccion = value; }
            }

            private decimal _CostoUnitario;
            public decimal CostoUnitario
            {
                get { return _CostoUnitario; }
                set { _CostoUnitario = value; }
            }

            private decimal _PrecioInterno;
            public decimal PrecioInterno
            {
                get { return _PrecioInterno; }
                set { _PrecioInterno = value; }
            }

            private decimal _PrecioExterno;
            public decimal PrecioExterno
            {
                get { return _PrecioExterno; }
                set { _PrecioExterno = value; }
            }

            private decimal _MargenInterno;
            public decimal MargenInterno
            {
                get { return _MargenInterno; }
                set { _MargenInterno = value; }
            }

            private decimal _MargenExterno;
            public decimal MargenExterno
            {
                get { return _MargenExterno; }
                set { _MargenExterno = value; }
            }

            private int _CantidadInventario;
            public int CantidadInventario
            {
                get { return _CantidadInventario; }
                set { _CantidadInventario = value; }
            }

            private decimal _ValorInventario;
            public decimal ValorInventario
            {
                get { return _ValorInventario; }
                set { _ValorInventario = value; }
            }

            private int _PuntoDeReOrden;
            public int PuntoDeReOrden
            {
                get { return _PuntoDeReOrden; }
                set { _PuntoDeReOrden = value; }
            }

            #endregion

            #region Methods
            public void Validate()
            {
                if (this.Empresa_ID == null) throw new Exception("Empresa_ID no puede ser nulo.");

                if (this.Estacion_ID == null) throw new Exception("Estacion_ID no puede ser nulo.");

                if (this.Refaccion_ID == null) throw new Exception("Refaccion_ID no puede ser nulo.");

                if (this.Pasillo.Length > 30)
                {
                    throw new Exception("Pasillo debe tener máximo 30 carateres.");
                }

                if (this.Estante.Length > 30)
                {
                    throw new Exception("Estante debe tener máximo 30 carateres.");
                }

                if (this.Nivel.Length > 30)
                {
                    throw new Exception("Nivel debe tener máximo 30 carateres.");
                }

                if (this.Seccion.Length > 30)
                {
                    throw new Exception("Seccion debe tener máximo 30 carateres.");
                }

                if (this.CostoUnitario == null) throw new Exception("CostoUnitario no puede ser nulo.");

                if (this.PrecioInterno == null) throw new Exception("PrecioInterno no puede ser nulo.");

                if (this.PrecioExterno == null) throw new Exception("PrecioExterno no puede ser nulo.");

                if (this.MargenInterno == null) throw new Exception("MargenInterno no puede ser nulo.");

                if (this.MargenExterno == null) throw new Exception("MargenExterno no puede ser nulo.");

                if (this.CantidadInventario == null) throw new Exception("CantidadInventario no puede ser nulo.");

                if (this.ValorInventario == null) throw new Exception("ValorInventario no puede ser nulo.");

                if (this.PuntoDeReOrden == null) throw new Exception("PuntoDeReOrden no puede ser nulo.");


            } // End Validate

            public int Create()
            {
                Hashtable m_params = new Hashtable();
                m_params.Add("Empresa_ID", this.Empresa_ID);
                m_params.Add("Estacion_ID", this.Estacion_ID);
                m_params.Add("Refaccion_ID", this.Refaccion_ID);
                if (!DB.IsNullOrEmpty(this.Pasillo)) m_params.Add("Pasillo", this.Pasillo);
                if (!DB.IsNullOrEmpty(this.Estante)) m_params.Add("Estante", this.Estante);
                if (!DB.IsNullOrEmpty(this.Nivel)) m_params.Add("Nivel", this.Nivel);
                if (!DB.IsNullOrEmpty(this.Seccion)) m_params.Add("Seccion", this.Seccion);
                m_params.Add("CostoUnitario", this.CostoUnitario);
                m_params.Add("PrecioInterno", this.PrecioInterno);
                m_params.Add("PrecioExterno", this.PrecioExterno);
                m_params.Add("MargenInterno", this.MargenInterno);
                m_params.Add("MargenExterno", this.MargenExterno);
                m_params.Add("CantidadInventario", this.CantidadInventario);
                m_params.Add("ValorInventario", this.ValorInventario);
                m_params.Add("PuntoDeReOrden", this.PuntoDeReOrden);

                return DB.InsertRow("Inventario", m_params);
            } // End Create
            
            public static List<Inventario> Read()
            {
                List<Inventario> list = new List<Inventario>();
                DataTable dt = DB.Select("Inventario");
                foreach (DataRow dr in dt.Rows)
                {
                    list.Add(
                        new Inventario(
                            Convert.ToInt32(dr["Empresa_ID"]),
                            Convert.ToInt32(dr["Estacion_ID"]),
                            Convert.ToInt32(dr["Refaccion_ID"]),
                            Convert.ToString(dr["Pasillo"]),
                            Convert.ToString(dr["Estante"]),
                            Convert.ToString(dr["Nivel"]),
                            Convert.ToString(dr["Seccion"]),
                            Convert.ToDecimal(dr["CostoUnitario"]),
                            Convert.ToDecimal(dr["PrecioInterno"]),
                            Convert.ToDecimal(dr["PrecioExterno"]),
                            Convert.ToDecimal(dr["MargenInterno"]),
                            Convert.ToDecimal(dr["MargenExterno"]),
                            Convert.ToInt32(dr["CantidadInventario"]),
                            Convert.ToDecimal(dr["ValorInventario"]),
                            Convert.ToInt32(dr["PuntoDeReOrden"])
                        )
                    );
                }

                return list;
            } // End Read

            
            public static Inventario Read(params KeyValuePair<string, object>[] args)
            {
                DataTable dt = DB.Read("Inventario", args);
                if (dt.Rows.Count == 0)
                {
                    return null;
                }
                DataRow dr = dt.Rows[0];
                return new Inventario(
                    Convert.ToInt32(dr["Empresa_ID"]),
                            Convert.ToInt32(dr["Estacion_ID"]),
                            Convert.ToInt32(dr["Refaccion_ID"]),
                            Convert.ToString(dr["Pasillo"]),
                            Convert.ToString(dr["Estante"]),
                            Convert.ToString(dr["Nivel"]),
                            Convert.ToString(dr["Seccion"]),
                            Convert.ToDecimal(dr["CostoUnitario"]),
                            Convert.ToDecimal(dr["PrecioInterno"]),
                            Convert.ToDecimal(dr["PrecioExterno"]),
                            Convert.ToDecimal(dr["MargenInterno"]),
                            Convert.ToDecimal(dr["MargenExterno"]),
                            Convert.ToInt32(dr["CantidadInventario"]),
                            Convert.ToDecimal(dr["ValorInventario"]),
                            Convert.ToInt32(dr["PuntoDeReOrden"])
                        );
            } // End Read

            public static bool Read(
                out Inventario inventario,
                int top,
                string filter,
                string sort,
                params KeyValuePair<string, object>[] args)
            {
                DataTable dt = DB.Read("Inventario", top, filter, sort, args);
                if (dt.Rows.Count == 0)
                {
                    inventario = null;
                    return false;
                }
                DataRow dr = dt.Rows[0];
                inventario = new Inventario(
                    Convert.ToInt32(dr["Empresa_ID"]),
                            Convert.ToInt32(dr["Estacion_ID"]),
                            Convert.ToInt32(dr["Refaccion_ID"]),
                            Convert.ToString(dr["Pasillo"]),
                            Convert.ToString(dr["Estante"]),
                            Convert.ToString(dr["Nivel"]),
                            Convert.ToString(dr["Seccion"]),
                            Convert.ToDecimal(dr["CostoUnitario"]),
                            Convert.ToDecimal(dr["PrecioInterno"]),
                            Convert.ToDecimal(dr["PrecioExterno"]),
                            Convert.ToDecimal(dr["MargenInterno"]),
                            Convert.ToDecimal(dr["MargenExterno"]),
                            Convert.ToInt32(dr["CantidadInventario"]),
                            Convert.ToDecimal(dr["ValorInventario"]),
                            Convert.ToInt32(dr["PuntoDeReOrden"])
                        );
                return true;
            } // End Read

            public static DataTable ReadDataTable()
            {
                return DB.Select("Inventario");
            } // End Read


            public int Update()
            {
                Hashtable m_params = new Hashtable();
                Hashtable w_params = new Hashtable();
                w_params.Add("Empresa_ID", this.Empresa_ID);
                w_params.Add("Estacion_ID", this.Estacion_ID);
                w_params.Add("Refaccion_ID", this.Refaccion_ID);
                if (!DB.IsNullOrEmpty(this.Pasillo)) m_params.Add("Pasillo", this.Pasillo);
                if (!DB.IsNullOrEmpty(this.Estante)) m_params.Add("Estante", this.Estante);
                if (!DB.IsNullOrEmpty(this.Nivel)) m_params.Add("Nivel", this.Nivel);
                if (!DB.IsNullOrEmpty(this.Seccion)) m_params.Add("Seccion", this.Seccion);
                m_params.Add("CostoUnitario", this.CostoUnitario);
                m_params.Add("PrecioInterno", this.PrecioInterno);
                m_params.Add("PrecioExterno", this.PrecioExterno);
                m_params.Add("MargenInterno", this.MargenInterno);
                m_params.Add("MargenExterno", this.MargenExterno);
                m_params.Add("CantidadInventario", this.CantidadInventario);
                m_params.Add("ValorInventario", this.ValorInventario);
                m_params.Add("PuntoDeReOrden", this.PuntoDeReOrden);

                return DB.UpdateRow("Inventario", m_params, w_params);
            } // End Update

            public int Delete()
            {
                Hashtable w_params = new Hashtable();
                w_params.Add("Empresa_ID", this.Empresa_ID);
                w_params.Add("Estacion_ID", this.Estacion_ID);
                w_params.Add("Refaccion_ID", this.Refaccion_ID);

                return DB.DeleteRow("Inventario", w_params);
            } // End Delete


            #endregion
        } //End Class Inventario

        public class LocacionesUnidades
        {

            public LocacionesUnidades()
            {
            }

            public LocacionesUnidades(int locacionunidad_id, string nombre)
            {
                this.LocacionUnidad_ID = locacionunidad_id;
                this.Nombre = nombre;
            }

            private int _LocacionUnidad_ID;
            public int LocacionUnidad_ID
            {
                get { return _LocacionUnidad_ID; }
                set { _LocacionUnidad_ID = value; }
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

                return DB.InsertRow("LocacionesUnidades", m_params);
            } // End Create

            public static List<LocacionesUnidades> Read()
            {
                List<LocacionesUnidades> list = new List<LocacionesUnidades>();
                DataTable dt = DB.Select("LocacionesUnidades");
                foreach (DataRow dr in dt.Rows)
                {
                    list.Add(new LocacionesUnidades(Convert.ToInt32(dr["LocacionUnidad_ID"]), Convert.ToString(dr["Nombre"])));
                }

                return list;
            } // End Read

            public static List<LocacionesUnidades> Read(int locacionunidad_id)
            {
                List<LocacionesUnidades> list = new List<LocacionesUnidades>();
                Hashtable w_params = new Hashtable();
                w_params.Add("LocacionUnidad_ID", locacionunidad_id);
                DataTable dt = DB.Select("LocacionesUnidades", w_params);
                foreach (DataRow dr in dt.Rows)
                {
                    list.Add(new LocacionesUnidades(Convert.ToInt32(dr["LocacionUnidad_ID"]), Convert.ToString(dr["Nombre"])));
                }

                return list;
            } // End Read

            public int Update()
            {
                Hashtable m_params = new Hashtable();
                Hashtable w_params = new Hashtable();
                w_params.Add("LocacionUnidad_ID", this.LocacionUnidad_ID);
                m_params.Add("Nombre", this.Nombre);

                return DB.UpdateRow("LocacionesUnidades", m_params, w_params);
            } // End Update

            public int Delete()
            {
                Hashtable w_params = new Hashtable();
                w_params.Add("LocacionUnidad_ID", this.LocacionUnidad_ID);

                return DB.DeleteRow("LocacionesUnidades", w_params);
            }

        } //End Class LocacionesUnidades

        public class MarcasRefacciones
        {

            public MarcasRefacciones()
            {
            }

            public MarcasRefacciones(int marcarefaccion_id, string nombre)
            {
                this.MarcaRefaccion_ID = marcarefaccion_id;
                this.Nombre = nombre;
            }

            private int _MarcaRefaccion_ID;
            public int MarcaRefaccion_ID
            {
                get { return _MarcaRefaccion_ID; }
                set { _MarcaRefaccion_ID = value; }
            }

            private string _Nombre;
            public string Nombre
            {
                get { return _Nombre; }
                set { _Nombre = value; }
            }

            public int Create(bool IsIdentityInsert)
            {
                if (!IsIdentityInsert) return Create();

                Hashtable m_params = new Hashtable();
                m_params.Add("MarcaRefaccion_ID", this.MarcaRefaccion_ID);
                m_params.Add("Nombre", this.Nombre);

                return DB.IdentityInsertRow("MarcasRefacciones", m_params);
            } // End Create

            public int Create()
            {
                Hashtable m_params = new Hashtable();
                m_params.Add("Nombre", this.Nombre);

                return DB.InsertRow("MarcasRefacciones", m_params);
            } // End Create

            public static List<MarcasRefacciones> Read()
            {
                List<MarcasRefacciones> list = new List<MarcasRefacciones>();
                DataTable dt = DB.Select("MarcasRefacciones");
                foreach (DataRow dr in dt.Rows)
                {
                    list.Add(new MarcasRefacciones(Convert.ToInt32(dr["MarcaRefaccion_ID"]), Convert.ToString(dr["Nombre"])));
                }

                return list;
            } // End Read

            public static MarcasRefacciones Read(int marcarefaccion_id)
            {
                Hashtable w_params = new Hashtable();
                w_params.Add("MarcaRefaccion_ID", marcarefaccion_id);
                DataTable dt = DB.Select("MarcasRefacciones", w_params);
                if (dt.Rows.Count == 0)
                {
                    throw new Exception("No existe MarcasRefacciones con los criterios de búsqueda especificados.");
                }
                DataRow dr = dt.Rows[0];
                return new MarcasRefacciones(Convert.ToInt32(dr["MarcaRefaccion_ID"]), Convert.ToString(dr["Nombre"]));
            } // End Read

            public int Update()
            {
                Hashtable m_params = new Hashtable();
                Hashtable w_params = new Hashtable();
                w_params.Add("MarcaRefaccion_ID", this.MarcaRefaccion_ID);
                m_params.Add("Nombre", this.Nombre);

                return DB.UpdateRow("MarcasRefacciones", m_params, w_params);
            } // End Update

            public int Delete()
            {
                Hashtable w_params = new Hashtable();
                w_params.Add("MarcaRefaccion_ID", this.MarcaRefaccion_ID);

                return DB.DeleteRow("MarcasRefacciones", w_params);
            } // End Delete

        } //End Class MarcasRefacciones

        public class MarcasUnidades
        {

            public MarcasUnidades()
            {
            }

            public MarcasUnidades(int marcaunidad_id, string descripcion)
            {
                this.MarcaUnidad_ID = marcaunidad_id;
                this.Descripcion = descripcion;
            }

            private int _MarcaUnidad_ID;
            public int MarcaUnidad_ID
            {
                get { return _MarcaUnidad_ID; }
                set { _MarcaUnidad_ID = value; }
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
                    list.Add(new MarcasUnidades(Convert.ToInt32(dr["MarcaUnidad_ID"]), Convert.ToString(dr["Descripcion"])));
                }

                return list;
            } // End Read

            public static List<MarcasUnidades> Read(int marcaunidad_id)
            {
                List<MarcasUnidades> list = new List<MarcasUnidades>();
                Hashtable w_params = new Hashtable();
                w_params.Add("MarcaUnidad_ID", marcaunidad_id);
                DataTable dt = DB.Select("MarcasUnidades", w_params);
                foreach (DataRow dr in dt.Rows)
                {
                    list.Add(new MarcasUnidades(Convert.ToInt32(dr["MarcaUnidad_ID"]), Convert.ToString(dr["Descripcion"])));
                }

                return list;
            } // End Read

            public static MarcasUnidades Read(params KeyValuePair<string, object>[] args)
            {
                DataTable dt = DB.Read("MarcasUnidades", args);
                if (dt.Rows.Count == 0)
                {
                    return null;
                }
                DataRow dr = dt.Rows[0];
                return new MarcasUnidades(Convert.ToInt32(dr["MarcaUnidad_ID"]), Convert.ToString(dr["Descripcion"]));
            } // End Read

            public static bool Read(out MarcasUnidades marcasunidades, int top, string filter, string sort, params KeyValuePair<string, object>[] args)
            {
                DataTable dt = DB.Read("MarcasUnidades", top, filter, sort, args);
                if (dt.Rows.Count == 0)
                {
                    marcasunidades = null;
                    return false;
                }
                DataRow dr = dt.Rows[0];
                marcasunidades = new MarcasUnidades(Convert.ToInt32(dr["MarcaUnidad_ID"]), Convert.ToString(dr["Descripcion"]));
                return true;
            } // End Read

            public int Update()
            {
                Hashtable m_params = new Hashtable();
                Hashtable w_params = new Hashtable();
                w_params.Add("MarcaUnidad_ID", this.MarcaUnidad_ID);
                m_params.Add("Descripcion", this.Descripcion);

                return DB.UpdateRow("MarcasUnidades", m_params, w_params);
            } // End Update

            public int Delete()
            {
                Hashtable w_params = new Hashtable();
                w_params.Add("MarcaUnidad_ID", this.MarcaUnidad_ID);

                return DB.DeleteRow("MarcasUnidades", w_params);
            }

        } //End Class MarcasUnidades

        public class Mecanicos
        {

            #region Constructors

            public Mecanicos()
            {
            }

            public Mecanicos(
                int mecanico_id,
                int categoriamecanico_id,
                int estatusmecanico_id,
                string usuario_id,
                DateTime fecha,
                string codigobarras,
                string nombres,
                string apellidos,
                string rfc,
                string curp,
                string nss,
                string domicilio,
                string ciudad,
                string entidad,
                string codigopostal,
                string telefono,
                string correoelectronico,
                decimal salariodiario,
                string horarioentrada,
                string horariosalida,
                int empresa_id,
                int estacion_id)
            {
                this.Mecanico_ID = mecanico_id;
                this.CategoriaMecanico_ID = categoriamecanico_id;
                this.EstatusMecanico_ID = estatusmecanico_id;
                this.Usuario_ID = usuario_id;
                this.Fecha = fecha;
                this.CodigoBarras = codigobarras;
                this.Nombres = nombres;
                this.Apellidos = apellidos;
                this.Rfc = rfc;
                this.Curp = curp;
                this.NSS = nss;
                this.Domicilio = domicilio;
                this.Ciudad = ciudad;
                this.Entidad = entidad;
                this.CodigoPostal = codigopostal;
                this.Telefono = telefono;
                this.CorreoElectronico = correoelectronico;
                this.SalarioDiario = salariodiario;
                this.HorarioEntrada = horarioentrada;
                this.HorarioSalida = horariosalida;
                this.Empresa_ID = empresa_id;
                this.Estacion_ID = estacion_id;
            }

            #endregion

            #region Properties

            private int _Mecanico_ID;
            public int Mecanico_ID
            {
                get { return _Mecanico_ID; }
                set { _Mecanico_ID = value; }
            }

            private int _CategoriaMecanico_ID;
            public int CategoriaMecanico_ID
            {
                get { return _CategoriaMecanico_ID; }
                set { _CategoriaMecanico_ID = value; }
            }

            private int _EstatusMecanico_ID;
            public int EstatusMecanico_ID
            {
                get { return _EstatusMecanico_ID; }
                set { _EstatusMecanico_ID = value; }
            }

            private string _Usuario_ID;
            public string Usuario_ID
            {
                get { return _Usuario_ID; }
                set { _Usuario_ID = value; }
            }

            private DateTime _Fecha;
            public DateTime Fecha
            {
                get { return _Fecha; }
                set { _Fecha = value; }
            }

            private string _CodigoBarras;
            public string CodigoBarras
            {
                get { return _CodigoBarras; }
                set { _CodigoBarras = value; }
            }

            private string _Nombres;
            public string Nombres
            {
                get { return _Nombres; }
                set { _Nombres = value; }
            }

            private string _Apellidos;
            public string Apellidos
            {
                get { return _Apellidos; }
                set { _Apellidos = value; }
            }

            private string _Rfc;
            public string Rfc
            {
                get { return _Rfc; }
                set { _Rfc = value; }
            }

            private string _Curp;
            public string Curp
            {
                get { return _Curp; }
                set { _Curp = value; }
            }

            private string _NSS;
            public string NSS
            {
                get { return _NSS; }
                set { _NSS = value; }
            }

            private string _Domicilio;
            public string Domicilio
            {
                get { return _Domicilio; }
                set { _Domicilio = value; }
            }

            private string _Ciudad;
            public string Ciudad
            {
                get { return _Ciudad; }
                set { _Ciudad = value; }
            }

            private string _Entidad;
            public string Entidad
            {
                get { return _Entidad; }
                set { _Entidad = value; }
            }

            private string _CodigoPostal;
            public string CodigoPostal
            {
                get { return _CodigoPostal; }
                set { _CodigoPostal = value; }
            }

            private string _Telefono;
            public string Telefono
            {
                get { return _Telefono; }
                set { _Telefono = value; }
            }

            private string _CorreoElectronico;
            public string CorreoElectronico
            {
                get { return _CorreoElectronico; }
                set { _CorreoElectronico = value; }
            }

            private decimal _SalarioDiario;
            public decimal SalarioDiario
            {
                get { return _SalarioDiario; }
                set { _SalarioDiario = value; }
            }

            private string _HorarioEntrada;
            public string HorarioEntrada
            {
                get { return _HorarioEntrada; }
                set { _HorarioEntrada = value; }
            }

            private string _HorarioSalida;
            public string HorarioSalida
            {
                get { return _HorarioSalida; }
                set { _HorarioSalida = value; }
            }

            private int _Empresa_ID;
            public int Empresa_ID
            {
                get { return _Empresa_ID; }
                set { _Empresa_ID = value; }
            }

            private int _Estacion_ID;
            public int Estacion_ID
            {
                get { return _Estacion_ID; }
                set { _Estacion_ID = value; }
            }

            #endregion

            #region Methods
            public void Validate()
            {
                if (this.Mecanico_ID == null) throw new Exception("Mecanico_ID no puede ser nulo.");

                if (this.CategoriaMecanico_ID == null) throw new Exception("CategoriaMecanico_ID no puede ser nulo.");

                if (this.EstatusMecanico_ID == null) throw new Exception("EstatusMecanico_ID no puede ser nulo.");

                if (this.Usuario_ID == null) throw new Exception("Usuario_ID no puede ser nulo.");

                if (this.Usuario_ID.Length > 30)
                {
                    throw new Exception("Usuario_ID debe tener máximo 30 carateres.");
                }

                if (this.Fecha == null) throw new Exception("Fecha no puede ser nulo.");

                if (this.CodigoBarras == null) throw new Exception("CodigoBarras no puede ser nulo.");

                if (this.CodigoBarras.Length > 50)
                {
                    throw new Exception("CodigoBarras debe tener máximo 50 carateres.");
                }

                if (this.Nombres == null) throw new Exception("Nombres no puede ser nulo.");

                if (this.Nombres.Length > 50)
                {
                    throw new Exception("Nombres debe tener máximo 50 carateres.");
                }

                if (this.Apellidos == null) throw new Exception("Apellidos no puede ser nulo.");

                if (this.Apellidos.Length > 100)
                {
                    throw new Exception("Apellidos debe tener máximo 100 carateres.");
                }

                if (this.Rfc == null) throw new Exception("Rfc no puede ser nulo.");

                if (this.Rfc.Length > 20)
                {
                    throw new Exception("Rfc debe tener máximo 20 carateres.");
                }

                if (this.Curp == null) throw new Exception("Curp no puede ser nulo.");

                if (this.Curp.Length > 50)
                {
                    throw new Exception("Curp debe tener máximo 50 carateres.");
                }

                if (this.NSS == null) throw new Exception("NSS no puede ser nulo.");

                if (this.NSS.Length > 50)
                {
                    throw new Exception("NSS debe tener máximo 50 carateres.");
                }

                if (this.Domicilio == null) throw new Exception("Domicilio no puede ser nulo.");

                if (this.Domicilio.Length > 150)
                {
                    throw new Exception("Domicilio debe tener máximo 150 carateres.");
                }

                if (this.Ciudad == null) throw new Exception("Ciudad no puede ser nulo.");

                if (this.Ciudad.Length > 50)
                {
                    throw new Exception("Ciudad debe tener máximo 50 carateres.");
                }

                if (this.Entidad == null) throw new Exception("Entidad no puede ser nulo.");

                if (this.Entidad.Length > 50)
                {
                    throw new Exception("Entidad debe tener máximo 50 carateres.");
                }

                if (this.CodigoPostal == null) throw new Exception("CodigoPostal no puede ser nulo.");

                if (this.CodigoPostal.Length > 10)
                {
                    throw new Exception("CodigoPostal debe tener máximo 10 carateres.");
                }

                if (this.Telefono == null) throw new Exception("Telefono no puede ser nulo.");

                if (this.Telefono.Length > 100)
                {
                    throw new Exception("Telefono debe tener máximo 100 carateres.");
                }

                if (this.CorreoElectronico == null) throw new Exception("CorreoElectronico no puede ser nulo.");

                if (this.CorreoElectronico.Length > 100)
                {
                    throw new Exception("CorreoElectronico debe tener máximo 100 carateres.");
                }

                if (this.SalarioDiario == null) throw new Exception("SalarioDiario no puede ser nulo.");

                if (this.HorarioEntrada == null) throw new Exception("HorarioEntrada no puede ser nulo.");

                if (this.HorarioEntrada.Length > 8)
                {
                    throw new Exception("HorarioEntrada debe tener máximo 8 carateres.");
                }

                if (this.HorarioSalida == null) throw new Exception("HorarioSalida no puede ser nulo.");

                if (this.HorarioSalida.Length > 8)
                {
                    throw new Exception("HorarioSalida debe tener máximo 8 carateres.");
                }

                if (this.Empresa_ID == null) throw new Exception("Empresa_ID no puede ser nulo.");

                if (this.Estacion_ID == null) throw new Exception("Estacion_ID no puede ser nulo.");


            } // End Validate

            public int Create()
            {
                Hashtable m_params = new Hashtable();
                m_params.Add("CategoriaMecanico_ID", this.CategoriaMecanico_ID);
                m_params.Add("EstatusMecanico_ID", this.EstatusMecanico_ID);
                m_params.Add("Usuario_ID", this.Usuario_ID);
                m_params.Add("Fecha", this.Fecha);
                m_params.Add("CodigoBarras", this.CodigoBarras);
                m_params.Add("Nombres", this.Nombres);
                m_params.Add("Apellidos", this.Apellidos);
                m_params.Add("Rfc", this.Rfc);
                m_params.Add("Curp", this.Curp);
                m_params.Add("NSS", this.NSS);
                m_params.Add("Domicilio", this.Domicilio);
                m_params.Add("Ciudad", this.Ciudad);
                m_params.Add("Entidad", this.Entidad);
                m_params.Add("CodigoPostal", this.CodigoPostal);
                m_params.Add("Telefono", this.Telefono);
                m_params.Add("CorreoElectronico", this.CorreoElectronico);
                m_params.Add("SalarioDiario", this.SalarioDiario);
                m_params.Add("HorarioEntrada", this.HorarioEntrada);
                m_params.Add("HorarioSalida", this.HorarioSalida);
                m_params.Add("Empresa_ID", this.Empresa_ID);
                m_params.Add("Estacion_ID", this.Estacion_ID);

                return DB.InsertRow("Mecanicos", m_params);
            } // End Create

            public int Create(bool IsIdentityInsert)
            {
                if (!IsIdentityInsert) return Create();
                Hashtable m_params = new Hashtable();
                m_params.Add("Mecanico_ID", this.Mecanico_ID);
                m_params.Add("CategoriaMecanico_ID", this.CategoriaMecanico_ID);
                m_params.Add("EstatusMecanico_ID", this.EstatusMecanico_ID);
                m_params.Add("Usuario_ID", this.Usuario_ID);
                m_params.Add("Fecha", this.Fecha);
                m_params.Add("CodigoBarras", this.CodigoBarras);
                m_params.Add("Nombres", this.Nombres);
                m_params.Add("Apellidos", this.Apellidos);
                m_params.Add("Rfc", this.Rfc);
                m_params.Add("Curp", this.Curp);
                m_params.Add("NSS", this.NSS);
                m_params.Add("Domicilio", this.Domicilio);
                m_params.Add("Ciudad", this.Ciudad);
                m_params.Add("Entidad", this.Entidad);
                m_params.Add("CodigoPostal", this.CodigoPostal);
                m_params.Add("Telefono", this.Telefono);
                m_params.Add("CorreoElectronico", this.CorreoElectronico);
                m_params.Add("SalarioDiario", this.SalarioDiario);
                m_params.Add("HorarioEntrada", this.HorarioEntrada);
                m_params.Add("HorarioSalida", this.HorarioSalida);
                m_params.Add("Empresa_ID", this.Empresa_ID);
                m_params.Add("Estacion_ID", this.Estacion_ID);

                return DB.IdentityInsertRow("Mecanicos", m_params);
            } // End Create

            public static List<Mecanicos> Read()
            {
                List<Mecanicos> list = new List<Mecanicos>();
                DataTable dt = DB.Select("Mecanicos");
                foreach (DataRow dr in dt.Rows)
                {
                    list.Add(
                        new Mecanicos(
                            Convert.ToInt32(dr["Mecanico_ID"]),
                            Convert.ToInt32(dr["CategoriaMecanico_ID"]),
                            Convert.ToInt32(dr["EstatusMecanico_ID"]),
                            Convert.ToString(dr["Usuario_ID"]),
                            Convert.ToDateTime(dr["Fecha"]),
                            Convert.ToString(dr["CodigoBarras"]),
                            Convert.ToString(dr["Nombres"]),
                            Convert.ToString(dr["Apellidos"]),
                            Convert.ToString(dr["Rfc"]),
                            Convert.ToString(dr["Curp"]),
                            Convert.ToString(dr["NSS"]),
                            Convert.ToString(dr["Domicilio"]),
                            Convert.ToString(dr["Ciudad"]),
                            Convert.ToString(dr["Entidad"]),
                            Convert.ToString(dr["CodigoPostal"]),
                            Convert.ToString(dr["Telefono"]),
                            Convert.ToString(dr["CorreoElectronico"]),
                            Convert.ToDecimal(dr["SalarioDiario"]),
                            Convert.ToString(dr["HorarioEntrada"]),
                            Convert.ToString(dr["HorarioSalida"]),
                            Convert.ToInt32(dr["Empresa_ID"]),
                            Convert.ToInt32(dr["Estacion_ID"])
                        )
                    );
                }

                return list;
            } // End Read

            public static Mecanicos Read(int mecanico_id)
            {
                Hashtable w_params = new Hashtable();
                w_params.Add("Mecanico_ID", mecanico_id);
                DataTable dt = DB.Select("Mecanicos", w_params);
                if (dt.Rows.Count == 0)
                {
                    throw new Exception("No existe Mecanicos con los criterios de búsqueda especificados.");
                }
                DataRow dr = dt.Rows[0];
                return new Mecanicos(
                    Convert.ToInt32(dr["Mecanico_ID"]),
                            Convert.ToInt32(dr["CategoriaMecanico_ID"]),
                            Convert.ToInt32(dr["EstatusMecanico_ID"]),
                            Convert.ToString(dr["Usuario_ID"]),
                            Convert.ToDateTime(dr["Fecha"]),
                            Convert.ToString(dr["CodigoBarras"]),
                            Convert.ToString(dr["Nombres"]),
                            Convert.ToString(dr["Apellidos"]),
                            Convert.ToString(dr["Rfc"]),
                            Convert.ToString(dr["Curp"]),
                            Convert.ToString(dr["NSS"]),
                            Convert.ToString(dr["Domicilio"]),
                            Convert.ToString(dr["Ciudad"]),
                            Convert.ToString(dr["Entidad"]),
                            Convert.ToString(dr["CodigoPostal"]),
                            Convert.ToString(dr["Telefono"]),
                            Convert.ToString(dr["CorreoElectronico"]),
                            Convert.ToDecimal(dr["SalarioDiario"]),
                            Convert.ToString(dr["HorarioEntrada"]),
                            Convert.ToString(dr["HorarioSalida"]),
                            Convert.ToInt32(dr["Empresa_ID"]),
                            Convert.ToInt32(dr["Estacion_ID"])
                        );
            } // End Read

            public static Mecanicos Read(params KeyValuePair<string, object>[] args)
            {
                DataTable dt = DB.Read("Mecanicos", args);
                if (dt.Rows.Count == 0)
                {
                    return null;
                }
                DataRow dr = dt.Rows[0];
                return new Mecanicos(
                    Convert.ToInt32(dr["Mecanico_ID"]),
                            Convert.ToInt32(dr["CategoriaMecanico_ID"]),
                            Convert.ToInt32(dr["EstatusMecanico_ID"]),
                            Convert.ToString(dr["Usuario_ID"]),
                            Convert.ToDateTime(dr["Fecha"]),
                            Convert.ToString(dr["CodigoBarras"]),
                            Convert.ToString(dr["Nombres"]),
                            Convert.ToString(dr["Apellidos"]),
                            Convert.ToString(dr["Rfc"]),
                            Convert.ToString(dr["Curp"]),
                            Convert.ToString(dr["NSS"]),
                            Convert.ToString(dr["Domicilio"]),
                            Convert.ToString(dr["Ciudad"]),
                            Convert.ToString(dr["Entidad"]),
                            Convert.ToString(dr["CodigoPostal"]),
                            Convert.ToString(dr["Telefono"]),
                            Convert.ToString(dr["CorreoElectronico"]),
                            Convert.ToDecimal(dr["SalarioDiario"]),
                            Convert.ToString(dr["HorarioEntrada"]),
                            Convert.ToString(dr["HorarioSalida"]),
                            Convert.ToInt32(dr["Empresa_ID"]),
                            Convert.ToInt32(dr["Estacion_ID"])
                        );
            } // End Read

            public static bool Read(
                out Mecanicos mecanicos,
                int top,
                string filter,
                string sort,
                params KeyValuePair<string, object>[] args)
            {
                DataTable dt = DB.Read("Mecanicos", top, filter, sort, args);
                if (dt.Rows.Count == 0)
                {
                    mecanicos = null;
                    return false;
                }
                DataRow dr = dt.Rows[0];
                mecanicos = new Mecanicos(
                    Convert.ToInt32(dr["Mecanico_ID"]),
                            Convert.ToInt32(dr["CategoriaMecanico_ID"]),
                            Convert.ToInt32(dr["EstatusMecanico_ID"]),
                            Convert.ToString(dr["Usuario_ID"]),
                            Convert.ToDateTime(dr["Fecha"]),
                            Convert.ToString(dr["CodigoBarras"]),
                            Convert.ToString(dr["Nombres"]),
                            Convert.ToString(dr["Apellidos"]),
                            Convert.ToString(dr["Rfc"]),
                            Convert.ToString(dr["Curp"]),
                            Convert.ToString(dr["NSS"]),
                            Convert.ToString(dr["Domicilio"]),
                            Convert.ToString(dr["Ciudad"]),
                            Convert.ToString(dr["Entidad"]),
                            Convert.ToString(dr["CodigoPostal"]),
                            Convert.ToString(dr["Telefono"]),
                            Convert.ToString(dr["CorreoElectronico"]),
                            Convert.ToDecimal(dr["SalarioDiario"]),
                            Convert.ToString(dr["HorarioEntrada"]),
                            Convert.ToString(dr["HorarioSalida"]),
                            Convert.ToInt32(dr["Empresa_ID"]),
                            Convert.ToInt32(dr["Estacion_ID"])
                        );
                return true;
            } // End Read

            public static DataTable ReadDataTable()
            {
                return DB.Select("Mecanicos");
            } // End Read

            public static DataTable ReadDataTable(int mecanico_id)
            {
                Hashtable w_params = new Hashtable();
                w_params.Add("Mecanico_ID", mecanico_id);
                return DB.Select("Mecanicos", w_params);
            } // End Read

            public int Update()
            {
                Hashtable m_params = new Hashtable();
                Hashtable w_params = new Hashtable();
                w_params.Add("Mecanico_ID", this.Mecanico_ID);
                m_params.Add("CategoriaMecanico_ID", this.CategoriaMecanico_ID);
                m_params.Add("EstatusMecanico_ID", this.EstatusMecanico_ID);
                m_params.Add("Usuario_ID", this.Usuario_ID);
                m_params.Add("Fecha", this.Fecha);
                m_params.Add("CodigoBarras", this.CodigoBarras);
                m_params.Add("Nombres", this.Nombres);
                m_params.Add("Apellidos", this.Apellidos);
                m_params.Add("Rfc", this.Rfc);
                m_params.Add("Curp", this.Curp);
                m_params.Add("NSS", this.NSS);
                m_params.Add("Domicilio", this.Domicilio);
                m_params.Add("Ciudad", this.Ciudad);
                m_params.Add("Entidad", this.Entidad);
                m_params.Add("CodigoPostal", this.CodigoPostal);
                m_params.Add("Telefono", this.Telefono);
                m_params.Add("CorreoElectronico", this.CorreoElectronico);
                m_params.Add("SalarioDiario", this.SalarioDiario);
                m_params.Add("HorarioEntrada", this.HorarioEntrada);
                m_params.Add("HorarioSalida", this.HorarioSalida);
                m_params.Add("Empresa_ID", this.Empresa_ID);
                m_params.Add("Estacion_ID", this.Estacion_ID);

                return DB.UpdateRow("Mecanicos", m_params, w_params);
            } // End Update

            public int Delete()
            {
                Hashtable w_params = new Hashtable();
                w_params.Add("Mecanico_ID", this.Mecanico_ID);

                return DB.DeleteRow("Mecanicos", w_params);
            } // End Delete


            #endregion
        } //End Class Mecanicos

        
        public class MediosPublicitarios
        {

            public MediosPublicitarios()
            {
            }

            public MediosPublicitarios(int mediopublicitario_id, int clasepublicidad_id, string nombre)
            {
                this.MedioPublicitario_ID = mediopublicitario_id;
                this.ClasePublicidad_ID = clasepublicidad_id;
                this.Nombre = nombre;
            }

            private int _MedioPublicitario_ID;
            public int MedioPublicitario_ID
            {
                get { return _MedioPublicitario_ID; }
                set { _MedioPublicitario_ID = value; }
            }

            private int _ClasePublicidad_ID;
            public int ClasePublicidad_ID
            {
                get { return _ClasePublicidad_ID; }
                set { _ClasePublicidad_ID = value; }
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
                m_params.Add("ClasePublicidad_ID", this.ClasePublicidad_ID);
                m_params.Add("Nombre", this.Nombre);

                return DB.InsertRow("MediosPublicitarios", m_params);
            } // End Create

            public static List<MediosPublicitarios> Read()
            {
                List<MediosPublicitarios> list = new List<MediosPublicitarios>();
                DataTable dt = DB.Select("MediosPublicitarios");
                foreach (DataRow dr in dt.Rows)
                {
                    list.Add(new MediosPublicitarios(Convert.ToInt32(dr["MedioPublicitario_ID"]), Convert.ToInt32(dr["ClasePublicidad_ID"]), Convert.ToString(dr["Nombre"])));
                }

                return list;
            } // End Read

            public static List<MediosPublicitarios> Read(int mediopublicitario_id)
            {
                List<MediosPublicitarios> list = new List<MediosPublicitarios>();
                Hashtable w_params = new Hashtable();
                w_params.Add("MedioPublicitario_ID", mediopublicitario_id);
                DataTable dt = DB.Select("MediosPublicitarios", w_params);
                foreach (DataRow dr in dt.Rows)
                {
                    list.Add(new MediosPublicitarios(Convert.ToInt32(dr["MedioPublicitario_ID"]), Convert.ToInt32(dr["ClasePublicidad_ID"]), Convert.ToString(dr["Nombre"])));
                }

                return list;
            } // End Read

            public int Update()
            {
                Hashtable m_params = new Hashtable();
                Hashtable w_params = new Hashtable();
                w_params.Add("MedioPublicitario_ID", this.MedioPublicitario_ID);
                m_params.Add("ClasePublicidad_ID", this.ClasePublicidad_ID);
                m_params.Add("Nombre", this.Nombre);

                return DB.UpdateRow("MediosPublicitarios", m_params, w_params);
            } // End Update

            public int Delete()
            {
                Hashtable w_params = new Hashtable();
                w_params.Add("MedioPublicitario_ID", this.MedioPublicitario_ID);

                return DB.DeleteRow("MediosPublicitarios", w_params);
            }

        } //End Class MediosPublicitarios

        public class Menues
        {

            public Menues()
            {
            }

            public Menues(int menu_id, int modulo_id, string nombre, string imagen)
            {
                this.Menu_ID = menu_id;
                this.Modulo_ID = modulo_id;
                this.Nombre = nombre;
                this.Imagen = imagen;
            }

            private int _Menu_ID;
            public int Menu_ID
            {
                get { return _Menu_ID; }
                set { _Menu_ID = value; }
            }

            private int _Modulo_ID;
            public int Modulo_ID
            {
                get { return _Modulo_ID; }
                set { _Modulo_ID = value; }
            }

            private string _Nombre;
            public string Nombre
            {
                get { return _Nombre; }
                set { _Nombre = value; }
            }

            private string _Imagen;
            public string Imagen
            {
                get { return _Imagen; }
                set { _Imagen = value; }
            }

            public int Create()
            {
                Hashtable m_params = new Hashtable();
                m_params.Add("Modulo_ID", this.Modulo_ID);
                m_params.Add("Nombre", this.Nombre);
                m_params.Add("Imagen", this.Imagen);

                return DB.InsertRow("Menues", m_params);
            } // End Create

            public static List<Menues> Read()
            {
                List<Menues> list = new List<Menues>();
                DataTable dt = DB.Select("Menues");
                foreach (DataRow dr in dt.Rows)
                {
                    list.Add(new Menues(Convert.ToInt32(dr["Menu_ID"]), Convert.ToInt32(dr["Modulo_ID"]), Convert.ToString(dr["Nombre"]), Convert.ToString(dr["Imagen"])));
                }

                return list;
            } // End Read

            public static List<Menues> Read(int menu_id)
            {
                List<Menues> list = new List<Menues>();
                Hashtable w_params = new Hashtable();
                w_params.Add("Menu_ID", menu_id);
                DataTable dt = DB.Select("Menues", w_params);
                foreach (DataRow dr in dt.Rows)
                {
                    list.Add(new Menues(Convert.ToInt32(dr["Menu_ID"]), Convert.ToInt32(dr["Modulo_ID"]), Convert.ToString(dr["Nombre"]), Convert.ToString(dr["Imagen"])));
                }

                return list;
            } // End Read

            public int Update()
            {
                Hashtable m_params = new Hashtable();
                Hashtable w_params = new Hashtable();
                w_params.Add("Menu_ID", this.Menu_ID);
                m_params.Add("Modulo_ID", this.Modulo_ID);
                m_params.Add("Nombre", this.Nombre);
                m_params.Add("Imagen", this.Imagen);

                return DB.UpdateRow("Menues", m_params, w_params);
            } // End Update

            public int Delete()
            {
                Hashtable w_params = new Hashtable();
                w_params.Add("Menu_ID", this.Menu_ID);

                return DB.DeleteRow("Menues", w_params);
            }

        } //End Class Menues

        public class Mercados
        {

            public Mercados()
            {
            }

            public Mercados(int mercado_id, string nombre)
            {
                this.Mercado_ID = mercado_id;
                this.Nombre = nombre;
            }

            private int _Mercado_ID;
            public int Mercado_ID
            {
                get { return _Mercado_ID; }
                set { _Mercado_ID = value; }
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

                return DB.InsertRow("Mercados", m_params);
            } // End Create

            public static List<Mercados> Read()
            {
                List<Mercados> list = new List<Mercados>();
                DataTable dt = DB.Select("Mercados");
                foreach (DataRow dr in dt.Rows)
                {
                    list.Add(new Mercados(Convert.ToInt32(dr["Mercado_ID"]), Convert.ToString(dr["Nombre"])));
                }

                return list;
            } // End Read

            public static List<Mercados> Read(int mercado_id)
            {
                List<Mercados> list = new List<Mercados>();
                Hashtable w_params = new Hashtable();
                w_params.Add("Mercado_ID", mercado_id);
                DataTable dt = DB.Select("Mercados", w_params);
                foreach (DataRow dr in dt.Rows)
                {
                    list.Add(new Mercados(Convert.ToInt32(dr["Mercado_ID"]), Convert.ToString(dr["Nombre"])));
                }

                return list;
            } // End Read

            public int Update()
            {
                Hashtable m_params = new Hashtable();
                Hashtable w_params = new Hashtable();
                w_params.Add("Mercado_ID", this.Mercado_ID);
                m_params.Add("Nombre", this.Nombre);

                return DB.UpdateRow("Mercados", m_params, w_params);
            } // End Update

            public int Delete()
            {
                Hashtable w_params = new Hashtable();
                w_params.Add("Mercado_ID", this.Mercado_ID);

                return DB.DeleteRow("Mercados", w_params);
            }

        } //End Class Mercados

        public class Modelos
        {

            public Modelos()
            {
            }

            public Modelos(int modelo_id, string nombre)
            {
                this.Modelo_ID = modelo_id;
                this.Nombre = nombre;
            }

            private int _Modelo_ID;
            public int Modelo_ID
            {
                get { return _Modelo_ID; }
                set { _Modelo_ID = value; }
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

                return DB.InsertRow("Modelos", m_params);
            } // End Create

            public static List<Modelos> Read()
            {
                List<Modelos> list = new List<Modelos>();
                DataTable dt = DB.Select("Modelos");
                foreach (DataRow dr in dt.Rows)
                {
                    list.Add(new Modelos(Convert.ToInt32(dr["Modelo_ID"]), Convert.ToString(dr["Nombre"])));
                }

                return list;
            } // End Read

            public static Modelos Read(int modelo_id)
            {
                Hashtable w_params = new Hashtable();
                w_params.Add("Modelo_ID", modelo_id);
                DataTable dt = DB.Select("Modelos", w_params);
                if (dt.Rows.Count == 0)
                {
                    throw new Exception("No existe Modelos con los criterios de búsqueda especificados.");
                }
                DataRow dr = dt.Rows[0];
                return new Modelos(Convert.ToInt32(dr["Modelo_ID"]), Convert.ToString(dr["Nombre"]));
            } // End Read

            public int Update()
            {
                Hashtable m_params = new Hashtable();
                Hashtable w_params = new Hashtable();
                w_params.Add("Modelo_ID", this.Modelo_ID);
                m_params.Add("Nombre", this.Nombre);

                return DB.UpdateRow("Modelos", m_params, w_params);
            } // End Update

            public int Delete()
            {
                Hashtable w_params = new Hashtable();
                w_params.Add("Modelo_ID", this.Modelo_ID);

                return DB.DeleteRow("Modelos", w_params);
            } // End Delete

        } //End Class Modelos

        public class ModelosUnidades
        {

            public ModelosUnidades()
            {
            }

            public ModelosUnidades(int modelounidad_id, int marcaunidad_id, string descripcion, decimal preciolista, int anio, decimal deposito, bool activo, int referencia_id, int empresareferencia)
            {
                this.ModeloUnidad_ID = modelounidad_id;
                this.MarcaUnidad_ID = marcaunidad_id;
                this.Descripcion = descripcion;
                this.PrecioLista = preciolista;
                this.Anio = anio;
                this.Deposito = deposito;
                this.Activo = activo;
                this.referencia_id = referencia_id;
                this.EmpresaReferencia = empresareferencia;
            }

            private int _ModeloUnidad_ID;
            public int ModeloUnidad_ID
            {
                get { return _ModeloUnidad_ID; }
                set { _ModeloUnidad_ID = value; }
            }

            private int _MarcaUnidad_ID;
            public int MarcaUnidad_ID
            {
                get { return _MarcaUnidad_ID; }
                set { _MarcaUnidad_ID = value; }
            }

            private string _Descripcion;
            public string Descripcion
            {
                get { return _Descripcion; }
                set { _Descripcion = value; }
            }

            private decimal _PrecioLista;
            public decimal PrecioLista
            {
                get { return _PrecioLista; }
                set { _PrecioLista = value; }
            }

            private int _Anio;
            public int Anio
            {
                get { return _Anio; }
                set { _Anio = value; }
            }

            private decimal _Deposito;
            public decimal Deposito
            {
                get { return _Deposito; }
                set { _Deposito = value; }
            }

            private bool _Activo;
            public bool Activo
            {
                get { return _Activo; }
                set { _Activo = value; }
            }

            private int _referencia_id;
            public int referencia_id
            {
                get { return _referencia_id; }
                set { _referencia_id = value; }
            }

            private int _EmpresaReferencia;
            public int EmpresaReferencia
            {
                get { return _EmpresaReferencia; }
                set { _EmpresaReferencia = value; }
            }

            public int Create()
            {
                Hashtable m_params = new Hashtable();
                m_params.Add("MarcaUnidad_ID", this.MarcaUnidad_ID);
                m_params.Add("Descripcion", this.Descripcion);
                m_params.Add("PrecioLista", this.PrecioLista);
                m_params.Add("Anio", this.Anio);
                m_params.Add("Deposito", this.Deposito);
                m_params.Add("Activo", this.Activo);
                m_params.Add("referencia_id", this.referencia_id);
                m_params.Add("EmpresaReferencia", this.EmpresaReferencia);

                return DB.InsertRow("ModelosUnidades", m_params);
            } // End Create

            public static List<ModelosUnidades> Read()
            {
                List<ModelosUnidades> list = new List<ModelosUnidades>();
                DataTable dt = DB.Select("ModelosUnidades");
                foreach (DataRow dr in dt.Rows)
                {
                    list.Add(new ModelosUnidades(Convert.ToInt32(dr["ModeloUnidad_ID"]), Convert.ToInt32(dr["MarcaUnidad_ID"]), Convert.ToString(dr["Descripcion"]), Convert.ToDecimal(dr["PrecioLista"]), Convert.ToInt32(dr["Anio"]), Convert.ToDecimal(dr["Deposito"]), Convert.ToBoolean(dr["Activo"]), Convert.ToInt32(dr["referencia_id"]), Convert.ToInt32(dr["EmpresaReferencia"])));
                }

                return list;
            } // End Read

            public static List<ModelosUnidades> Read(int modelounidad_id)
            {
                List<ModelosUnidades> list = new List<ModelosUnidades>();
                Hashtable w_params = new Hashtable();
                w_params.Add("ModeloUnidad_ID", modelounidad_id);
                DataTable dt = DB.Select("ModelosUnidades", w_params);
                foreach (DataRow dr in dt.Rows)
                {
                    list.Add(new ModelosUnidades(Convert.ToInt32(dr["ModeloUnidad_ID"]), Convert.ToInt32(dr["MarcaUnidad_ID"]), Convert.ToString(dr["Descripcion"]), Convert.ToDecimal(dr["PrecioLista"]), Convert.ToInt32(dr["Anio"]), Convert.ToDecimal(dr["Deposito"]), Convert.ToBoolean(dr["Activo"]), Convert.ToInt32(dr["referencia_id"]), Convert.ToInt32(dr["EmpresaReferencia"])));
                }

                return list;
            } // End Read

            public static ModelosUnidades Read(params KeyValuePair<string,object>[] args)
            {
                List<ModelosUnidades> list = new List<ModelosUnidades>();                
                DataTable dt = DB.Read("ModelosUnidades", args);

                if (dt.Rows.Count == 0)
                {
                    return null;
                }

                DataRow dr = dt.Rows[0];

                return new ModelosUnidades(Convert.ToInt32(dr["ModeloUnidad_ID"]), Convert.ToInt32(dr["MarcaUnidad_ID"]), 
                    Convert.ToString(dr["Descripcion"]), Convert.ToDecimal(dr["PrecioLista"]), Convert.ToInt32(dr["Anio"]), 
                        Convert.ToDecimal(dr["Deposito"]), Convert.ToBoolean(dr["Activo"]), Convert.ToInt32(dr["referencia_id"]), 
                            Convert.ToInt32(dr["EmpresaReferencia"]));
            } // End Read

            public int Update()
            {
                Hashtable m_params = new Hashtable();
                Hashtable w_params = new Hashtable();
                w_params.Add("ModeloUnidad_ID", this.ModeloUnidad_ID);
                m_params.Add("MarcaUnidad_ID", this.MarcaUnidad_ID);
                m_params.Add("Descripcion", this.Descripcion);
                m_params.Add("PrecioLista", this.PrecioLista);
                m_params.Add("Anio", this.Anio);
                m_params.Add("Deposito", this.Deposito);
                m_params.Add("Activo", this.Activo);
                m_params.Add("referencia_id", this.referencia_id);
                m_params.Add("EmpresaReferencia", this.EmpresaReferencia);

                return DB.UpdateRow("ModelosUnidades", m_params, w_params);
            } // End Update

            public int Delete()
            {
                Hashtable w_params = new Hashtable();
                w_params.Add("ModeloUnidad_ID", this.ModeloUnidad_ID);

                return DB.DeleteRow("ModelosUnidades", w_params);
            }

        } //End Class ModelosUnidades

        public class Modulos
        {

            public Modulos()
            {
            }

            public Modulos(int modulo_id, string nombre)
            {
                this.Modulo_ID = modulo_id;
                this.Nombre = nombre;
            }

            private int _Modulo_ID;
            public int Modulo_ID
            {
                get { return _Modulo_ID; }
                set { _Modulo_ID = value; }
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

                return DB.InsertRow("Modulos", m_params);
            } // End Create

            public static List<Modulos> Read()
            {
                List<Modulos> list = new List<Modulos>();
                DataTable dt = DB.Select("Modulos");
                foreach (DataRow dr in dt.Rows)
                {
                    list.Add(new Modulos(Convert.ToInt32(dr["Modulo_ID"]), Convert.ToString(dr["Nombre"])));
                }

                return list;
            } // End Read

            public static List<Modulos> Read(int modulo_id)
            {
                List<Modulos> list = new List<Modulos>();
                Hashtable w_params = new Hashtable();
                w_params.Add("Modulo_ID", modulo_id);
                DataTable dt = DB.Select("Modulos", w_params);
                foreach (DataRow dr in dt.Rows)
                {
                    list.Add(new Modulos(Convert.ToInt32(dr["Modulo_ID"]), Convert.ToString(dr["Nombre"])));
                }

                return list;
            } // End Read

            public int Update()
            {
                Hashtable m_params = new Hashtable();
                Hashtable w_params = new Hashtable();
                w_params.Add("Modulo_ID", this.Modulo_ID);
                m_params.Add("Nombre", this.Nombre);

                return DB.UpdateRow("Modulos", m_params, w_params);
            } // End Update

            public int Delete()
            {
                Hashtable w_params = new Hashtable();
                w_params.Add("Modulo_ID", this.Modulo_ID);

                return DB.DeleteRow("Modulos", w_params);
            }

        } //End Class Modulos

        public class Monedas
        {

            public Monedas()
            {
            }

            public Monedas(int moneda_id, string nombre, decimal tipocambio)
            {
                this.Moneda_ID = moneda_id;
                this.Nombre = nombre;
                this.TipoCambio = tipocambio;
            }

            private int _Moneda_ID;
            public int Moneda_ID
            {
                get { return _Moneda_ID; }
                set { _Moneda_ID = value; }
            }

            private string _Nombre;
            public string Nombre
            {
                get { return _Nombre; }
                set { _Nombre = value; }
            }

            private decimal _TipoCambio;
            public decimal TipoCambio
            {
                get { return _TipoCambio; }
                set { _TipoCambio = value; }
            }

            public int Create()
            {
                Hashtable m_params = new Hashtable();
                m_params.Add("Nombre", this.Nombre);
                m_params.Add("TipoCambio", this.TipoCambio);

                return DB.InsertRow("Monedas", m_params);
            } // End Create

            public static List<Monedas> Read()
            {
                List<Monedas> list = new List<Monedas>();
                DataTable dt = DB.Select("Monedas");
                foreach (DataRow dr in dt.Rows)
                {
                    list.Add(new Monedas(Convert.ToInt32(dr["Moneda_ID"]), Convert.ToString(dr["Nombre"]), Convert.ToDecimal(dr["TipoCambio"])));
                }

                return list;
            } // End Read

            public static List<Monedas> Read(int moneda_id)
            {
                List<Monedas> list = new List<Monedas>();
                Hashtable w_params = new Hashtable();
                w_params.Add("Moneda_ID", moneda_id);
                DataTable dt = DB.Select("Monedas", w_params);
                foreach (DataRow dr in dt.Rows)
                {
                    list.Add(new Monedas(Convert.ToInt32(dr["Moneda_ID"]), Convert.ToString(dr["Nombre"]), Convert.ToDecimal(dr["TipoCambio"])));
                }

                return list;
            } // End Read

            public int Update()
            {
                Hashtable m_params = new Hashtable();
                Hashtable w_params = new Hashtable();
                w_params.Add("Moneda_ID", this.Moneda_ID);
                m_params.Add("Nombre", this.Nombre);
                m_params.Add("TipoCambio", this.TipoCambio);

                return DB.UpdateRow("Monedas", m_params, w_params);
            } // End Update

            public int Delete()
            {
                Hashtable w_params = new Hashtable();
                w_params.Add("Moneda_ID", this.Moneda_ID);

                return DB.DeleteRow("Monedas", w_params);
            }

        } //End Class Monedas

        public class MovimientosInventario
        {

            #region Constructors

            public MovimientosInventario()
            {
            }

            public MovimientosInventario(
                int movimientoinventario_id,
                int tipomovimientoinventario_id,
                int? ordencompra_id,
                int? ordentrabajo_id,
                int? notaalmacen_id,
                int? ajusteinventario_id,
                string usuario_id,
                int refaccion_id,
                DateTime fecha,
                int cantidad,
                decimal costounitario,
                decimal valor,
                int cantidadprev,
                decimal valorprev,
                int cantidadpost,
                decimal valorpost,
                int cantidadprevprom,
                decimal valorprevprom,
                int cantidadpostprom,
                decimal valorpostprom,
                string referencia,
                decimal costounitarioprom,
                int empresa_id,
                int estacion_id)
            {
                this.MovimientoInventario_ID = movimientoinventario_id;
                this.TipoMovimientoInventario_ID = tipomovimientoinventario_id;
                this.OrdenCompra_ID = ordencompra_id;
                this.OrdenTrabajo_ID = ordentrabajo_id;
                this.NotaAlmacen_ID = notaalmacen_id;
                this.AjusteInventario_ID = ajusteinventario_id;
                this.Usuario_ID = usuario_id;
                this.Refaccion_ID = refaccion_id;
                this.Fecha = fecha;
                this.Cantidad = cantidad;
                this.CostoUnitario = costounitario;
                this.Valor = valor;
                this.CantidadPrev = cantidadprev;
                this.ValorPrev = valorprev;
                this.CantidadPost = cantidadpost;
                this.ValorPost = valorpost;
                this.CantidadPrevProm = cantidadprevprom;
                this.ValorPrevProm = valorprevprom;
                this.CantidadPostProm = cantidadpostprom;
                this.ValorPostProm = valorpostprom;
                this.Referencia = referencia;
                this.CostoUnitarioProm = costounitarioprom;
                this.Empresa_ID = empresa_id;
                this.Estacion_ID = estacion_id;
            }

            #endregion

            #region Properties

            private int _MovimientoInventario_ID;
            public int MovimientoInventario_ID
            {
                get { return _MovimientoInventario_ID; }
                set { _MovimientoInventario_ID = value; }
            }

            private int _TipoMovimientoInventario_ID;
            public int TipoMovimientoInventario_ID
            {
                get { return _TipoMovimientoInventario_ID; }
                set { _TipoMovimientoInventario_ID = value; }
            }

            private int? _OrdenCompra_ID;
            public int? OrdenCompra_ID
            {
                get { return _OrdenCompra_ID; }
                set { _OrdenCompra_ID = value; }
            }

            private int? _OrdenTrabajo_ID;
            public int? OrdenTrabajo_ID
            {
                get { return _OrdenTrabajo_ID; }
                set { _OrdenTrabajo_ID = value; }
            }

            private int? _NotaAlmacen_ID;
            public int? NotaAlmacen_ID
            {
                get { return _NotaAlmacen_ID; }
                set { _NotaAlmacen_ID = value; }
            }

            private int? _AjusteInventario_ID;
            public int? AjusteInventario_ID
            {
                get { return _AjusteInventario_ID; }
                set { _AjusteInventario_ID = value; }
            }

            private string _Usuario_ID;
            public string Usuario_ID
            {
                get { return _Usuario_ID; }
                set { _Usuario_ID = value; }
            }

            private int _Refaccion_ID;
            public int Refaccion_ID
            {
                get { return _Refaccion_ID; }
                set { _Refaccion_ID = value; }
            }

            private DateTime _Fecha;
            public DateTime Fecha
            {
                get { return _Fecha; }
                set { _Fecha = value; }
            }

            private int _Cantidad;
            public int Cantidad
            {
                get { return _Cantidad; }
                set { _Cantidad = value; }
            }

            private decimal _CostoUnitario;
            public decimal CostoUnitario
            {
                get { return _CostoUnitario; }
                set { _CostoUnitario = value; }
            }

            private decimal _Valor;
            public decimal Valor
            {
                get { return _Valor; }
                set { _Valor = value; }
            }

            private int _CantidadPrev;
            public int CantidadPrev
            {
                get { return _CantidadPrev; }
                set { _CantidadPrev = value; }
            }

            private decimal _ValorPrev;
            public decimal ValorPrev
            {
                get { return _ValorPrev; }
                set { _ValorPrev = value; }
            }

            private int _CantidadPost;
            public int CantidadPost
            {
                get { return _CantidadPost; }
                set { _CantidadPost = value; }
            }

            private decimal _ValorPost;
            public decimal ValorPost
            {
                get { return _ValorPost; }
                set { _ValorPost = value; }
            }

            private int _CantidadPrevProm;
            public int CantidadPrevProm
            {
                get { return _CantidadPrevProm; }
                set { _CantidadPrevProm = value; }
            }

            private decimal _ValorPrevProm;
            public decimal ValorPrevProm
            {
                get { return _ValorPrevProm; }
                set { _ValorPrevProm = value; }
            }

            private int _CantidadPostProm;
            public int CantidadPostProm
            {
                get { return _CantidadPostProm; }
                set { _CantidadPostProm = value; }
            }

            private decimal _ValorPostProm;
            public decimal ValorPostProm
            {
                get { return _ValorPostProm; }
                set { _ValorPostProm = value; }
            }

            private string _Referencia;
            public string Referencia
            {
                get { return _Referencia; }
                set { _Referencia = value; }
            }

            private decimal _CostoUnitarioProm;
            public decimal CostoUnitarioProm
            {
                get { return _CostoUnitarioProm; }
                set { _CostoUnitarioProm = value; }
            }

            private int _Empresa_ID;
            public int Empresa_ID
            {
                get { return _Empresa_ID; }
                set { _Empresa_ID = value; }
            }

            private int _Estacion_ID;
            public int Estacion_ID
            {
                get { return _Estacion_ID; }
                set { _Estacion_ID = value; }
            }

            #endregion

            #region Methods
            public void Validate()
            {
                if (this.MovimientoInventario_ID == null) throw new Exception("MovimientoInventario_ID no puede ser nulo.");

                if (this.TipoMovimientoInventario_ID == null) throw new Exception("TipoMovimientoInventario_ID no puede ser nulo.");

                if (this.Usuario_ID == null) throw new Exception("Usuario_ID no puede ser nulo.");

                if (this.Usuario_ID.Length > 30)
                {
                    throw new Exception("Usuario_ID debe tener máximo 30 carateres.");
                }

                if (this.Refaccion_ID == null) throw new Exception("Refaccion_ID no puede ser nulo.");

                if (this.Fecha == null) throw new Exception("Fecha no puede ser nulo.");

                if (this.Cantidad == null) throw new Exception("Cantidad no puede ser nulo.");

                if (this.CostoUnitario == null) throw new Exception("CostoUnitario no puede ser nulo.");

                if (this.Valor == null) throw new Exception("Valor no puede ser nulo.");

                if (this.CantidadPrev == null) throw new Exception("CantidadPrev no puede ser nulo.");

                if (this.ValorPrev == null) throw new Exception("ValorPrev no puede ser nulo.");

                if (this.CantidadPost == null) throw new Exception("CantidadPost no puede ser nulo.");

                if (this.ValorPost == null) throw new Exception("ValorPost no puede ser nulo.");

                if (this.CantidadPrevProm == null) throw new Exception("CantidadPrevProm no puede ser nulo.");

                if (this.ValorPrevProm == null) throw new Exception("ValorPrevProm no puede ser nulo.");

                if (this.CantidadPostProm == null) throw new Exception("CantidadPostProm no puede ser nulo.");

                if (this.ValorPostProm == null) throw new Exception("ValorPostProm no puede ser nulo.");

                if (this.Referencia.Length > 8)
                {
                    throw new Exception("Referencia debe tener máximo 8 carateres.");
                }

                if (this.CostoUnitarioProm == null) throw new Exception("CostoUnitarioProm no puede ser nulo.");

                if (this.Empresa_ID == null) throw new Exception("Empresa_ID no puede ser nulo.");

                if (this.Estacion_ID == null) throw new Exception("Estacion_ID no puede ser nulo.");


            } // End Validate

            public int Create()
            {
                Hashtable m_params = new Hashtable();
                m_params.Add("TipoMovimientoInventario_ID", this.TipoMovimientoInventario_ID);
                if (!DB.IsNullOrEmpty(this.OrdenCompra_ID)) m_params.Add("OrdenCompra_ID", this.OrdenCompra_ID);
                if (!DB.IsNullOrEmpty(this.OrdenTrabajo_ID)) m_params.Add("OrdenTrabajo_ID", this.OrdenTrabajo_ID);
                if (!DB.IsNullOrEmpty(this.NotaAlmacen_ID)) m_params.Add("NotaAlmacen_ID", this.NotaAlmacen_ID);
                if (!DB.IsNullOrEmpty(this.AjusteInventario_ID)) m_params.Add("AjusteInventario_ID", this.AjusteInventario_ID);
                m_params.Add("Usuario_ID", this.Usuario_ID);
                m_params.Add("Refaccion_ID", this.Refaccion_ID);
                m_params.Add("Fecha", this.Fecha);
                m_params.Add("Cantidad", this.Cantidad);
                m_params.Add("CostoUnitario", this.CostoUnitario);
                m_params.Add("Valor", this.Valor);
                m_params.Add("CantidadPrev", this.CantidadPrev);
                m_params.Add("ValorPrev", this.ValorPrev);
                m_params.Add("CantidadPost", this.CantidadPost);
                m_params.Add("ValorPost", this.ValorPost);
                m_params.Add("CantidadPrevProm", this.CantidadPrevProm);
                m_params.Add("ValorPrevProm", this.ValorPrevProm);
                m_params.Add("CantidadPostProm", this.CantidadPostProm);
                m_params.Add("ValorPostProm", this.ValorPostProm);
                if (!DB.IsNullOrEmpty(this.Referencia)) m_params.Add("Referencia", this.Referencia);
                m_params.Add("CostoUnitarioProm", this.CostoUnitarioProm);
                m_params.Add("Empresa_ID", this.Empresa_ID);
                m_params.Add("Estacion_ID", this.Estacion_ID);

                return DB.InsertRow("MovimientosInventario", m_params);
            } // End Create

            public int Create(bool IsIdentityInsert)
            {
                if (!IsIdentityInsert) return Create();
                Hashtable m_params = new Hashtable();
                m_params.Add("MovimientoInventario_ID", this.MovimientoInventario_ID);
                m_params.Add("TipoMovimientoInventario_ID", this.TipoMovimientoInventario_ID);
                if (!DB.IsNullOrEmpty(this.OrdenCompra_ID)) m_params.Add("OrdenCompra_ID", this.OrdenCompra_ID);
                if (!DB.IsNullOrEmpty(this.OrdenTrabajo_ID)) m_params.Add("OrdenTrabajo_ID", this.OrdenTrabajo_ID);
                if (!DB.IsNullOrEmpty(this.NotaAlmacen_ID)) m_params.Add("NotaAlmacen_ID", this.NotaAlmacen_ID);
                if (!DB.IsNullOrEmpty(this.AjusteInventario_ID)) m_params.Add("AjusteInventario_ID", this.AjusteInventario_ID);
                m_params.Add("Usuario_ID", this.Usuario_ID);
                m_params.Add("Refaccion_ID", this.Refaccion_ID);
                m_params.Add("Fecha", this.Fecha);
                m_params.Add("Cantidad", this.Cantidad);
                m_params.Add("CostoUnitario", this.CostoUnitario);
                m_params.Add("Valor", this.Valor);
                m_params.Add("CantidadPrev", this.CantidadPrev);
                m_params.Add("ValorPrev", this.ValorPrev);
                m_params.Add("CantidadPost", this.CantidadPost);
                m_params.Add("ValorPost", this.ValorPost);
                m_params.Add("CantidadPrevProm", this.CantidadPrevProm);
                m_params.Add("ValorPrevProm", this.ValorPrevProm);
                m_params.Add("CantidadPostProm", this.CantidadPostProm);
                m_params.Add("ValorPostProm", this.ValorPostProm);
                if (!DB.IsNullOrEmpty(this.Referencia)) m_params.Add("Referencia", this.Referencia);
                m_params.Add("CostoUnitarioProm", this.CostoUnitarioProm);
                m_params.Add("Empresa_ID", this.Empresa_ID);
                m_params.Add("Estacion_ID", this.Estacion_ID);

                return DB.IdentityInsertRow("MovimientosInventario", m_params);
            } // End Create

            public static List<MovimientosInventario> Read()
            {
                List<MovimientosInventario> list = new List<MovimientosInventario>();
                DataTable dt = DB.Select("MovimientosInventario");
                foreach (DataRow dr in dt.Rows)
                {
                    list.Add(
                        new MovimientosInventario(
                            Convert.ToInt32(dr["MovimientoInventario_ID"]),
                            Convert.ToInt32(dr["TipoMovimientoInventario_ID"]),
                            DB.GetNullableInt32(dr["OrdenCompra_ID"]),
                            DB.GetNullableInt32(dr["OrdenTrabajo_ID"]),
                            DB.GetNullableInt32(dr["NotaAlmacen_ID"]),
                            DB.GetNullableInt32(dr["AjusteInventario_ID"]),
                            Convert.ToString(dr["Usuario_ID"]),
                            Convert.ToInt32(dr["Refaccion_ID"]),
                            Convert.ToDateTime(dr["Fecha"]),
                            Convert.ToInt32(dr["Cantidad"]),
                            Convert.ToDecimal(dr["CostoUnitario"]),
                            Convert.ToDecimal(dr["Valor"]),
                            Convert.ToInt32(dr["CantidadPrev"]),
                            Convert.ToDecimal(dr["ValorPrev"]),
                            Convert.ToInt32(dr["CantidadPost"]),
                            Convert.ToDecimal(dr["ValorPost"]),
                            Convert.ToInt32(dr["CantidadPrevProm"]),
                            Convert.ToDecimal(dr["ValorPrevProm"]),
                            Convert.ToInt32(dr["CantidadPostProm"]),
                            Convert.ToDecimal(dr["ValorPostProm"]),
                            Convert.ToString(dr["Referencia"]),
                            Convert.ToDecimal(dr["CostoUnitarioProm"]),
                            Convert.ToInt32(dr["Empresa_ID"]),
                            Convert.ToInt32(dr["Estacion_ID"])
                        )
                    );
                }

                return list;
            } // End Read

            public static MovimientosInventario Read(int movimientoinventario_id)
            {
                Hashtable w_params = new Hashtable();
                w_params.Add("MovimientoInventario_ID", movimientoinventario_id);
                DataTable dt = DB.Select("MovimientosInventario", w_params);
                if (dt.Rows.Count == 0)
                {
                    throw new Exception("No existe MovimientosInventario con los criterios de búsqueda especificados.");
                }
                DataRow dr = dt.Rows[0];
                return new MovimientosInventario(
                    Convert.ToInt32(dr["MovimientoInventario_ID"]),
                            Convert.ToInt32(dr["TipoMovimientoInventario_ID"]),
                            DB.GetNullableInt32(dr["OrdenCompra_ID"]),
                            DB.GetNullableInt32(dr["OrdenTrabajo_ID"]),
                            DB.GetNullableInt32(dr["NotaAlmacen_ID"]),
                            DB.GetNullableInt32(dr["AjusteInventario_ID"]),
                            Convert.ToString(dr["Usuario_ID"]),
                            Convert.ToInt32(dr["Refaccion_ID"]),
                            Convert.ToDateTime(dr["Fecha"]),
                            Convert.ToInt32(dr["Cantidad"]),
                            Convert.ToDecimal(dr["CostoUnitario"]),
                            Convert.ToDecimal(dr["Valor"]),
                            Convert.ToInt32(dr["CantidadPrev"]),
                            Convert.ToDecimal(dr["ValorPrev"]),
                            Convert.ToInt32(dr["CantidadPost"]),
                            Convert.ToDecimal(dr["ValorPost"]),
                            Convert.ToInt32(dr["CantidadPrevProm"]),
                            Convert.ToDecimal(dr["ValorPrevProm"]),
                            Convert.ToInt32(dr["CantidadPostProm"]),
                            Convert.ToDecimal(dr["ValorPostProm"]),
                            Convert.ToString(dr["Referencia"]),
                            Convert.ToDecimal(dr["CostoUnitarioProm"]),
                            Convert.ToInt32(dr["Empresa_ID"]),
                            Convert.ToInt32(dr["Estacion_ID"])
                        );
            } // End Read

            public static MovimientosInventario Read(params KeyValuePair<string, object>[] args)
            {
                DataTable dt = DB.Read("MovimientosInventario", args);
                if (dt.Rows.Count == 0)
                {
                    return null;
                }
                DataRow dr = dt.Rows[0];
                return new MovimientosInventario(
                    Convert.ToInt32(dr["MovimientoInventario_ID"]),
                            Convert.ToInt32(dr["TipoMovimientoInventario_ID"]),
                            DB.GetNullableInt32(dr["OrdenCompra_ID"]),
                            DB.GetNullableInt32(dr["OrdenTrabajo_ID"]),
                            DB.GetNullableInt32(dr["NotaAlmacen_ID"]),
                            DB.GetNullableInt32(dr["AjusteInventario_ID"]),
                            Convert.ToString(dr["Usuario_ID"]),
                            Convert.ToInt32(dr["Refaccion_ID"]),
                            Convert.ToDateTime(dr["Fecha"]),
                            Convert.ToInt32(dr["Cantidad"]),
                            Convert.ToDecimal(dr["CostoUnitario"]),
                            Convert.ToDecimal(dr["Valor"]),
                            Convert.ToInt32(dr["CantidadPrev"]),
                            Convert.ToDecimal(dr["ValorPrev"]),
                            Convert.ToInt32(dr["CantidadPost"]),
                            Convert.ToDecimal(dr["ValorPost"]),
                            Convert.ToInt32(dr["CantidadPrevProm"]),
                            Convert.ToDecimal(dr["ValorPrevProm"]),
                            Convert.ToInt32(dr["CantidadPostProm"]),
                            Convert.ToDecimal(dr["ValorPostProm"]),
                            Convert.ToString(dr["Referencia"]),
                            Convert.ToDecimal(dr["CostoUnitarioProm"]),
                            Convert.ToInt32(dr["Empresa_ID"]),
                            Convert.ToInt32(dr["Estacion_ID"])
                        );
            } // End Read

            public static bool Read(
                out MovimientosInventario movimientosinventario,
                int top,
                string filter,
                string sort,
                params KeyValuePair<string, object>[] args)
            {
                DataTable dt = DB.Read("MovimientosInventario", top, filter, sort, args);
                if (dt.Rows.Count == 0)
                {
                    movimientosinventario = null;
                    return false;
                }
                DataRow dr = dt.Rows[0];
                movimientosinventario = new MovimientosInventario(
                    Convert.ToInt32(dr["MovimientoInventario_ID"]),
                            Convert.ToInt32(dr["TipoMovimientoInventario_ID"]),
                            DB.GetNullableInt32(dr["OrdenCompra_ID"]),
                            DB.GetNullableInt32(dr["OrdenTrabajo_ID"]),
                            DB.GetNullableInt32(dr["NotaAlmacen_ID"]),
                            DB.GetNullableInt32(dr["AjusteInventario_ID"]),
                            Convert.ToString(dr["Usuario_ID"]),
                            Convert.ToInt32(dr["Refaccion_ID"]),
                            Convert.ToDateTime(dr["Fecha"]),
                            Convert.ToInt32(dr["Cantidad"]),
                            Convert.ToDecimal(dr["CostoUnitario"]),
                            Convert.ToDecimal(dr["Valor"]),
                            Convert.ToInt32(dr["CantidadPrev"]),
                            Convert.ToDecimal(dr["ValorPrev"]),
                            Convert.ToInt32(dr["CantidadPost"]),
                            Convert.ToDecimal(dr["ValorPost"]),
                            Convert.ToInt32(dr["CantidadPrevProm"]),
                            Convert.ToDecimal(dr["ValorPrevProm"]),
                            Convert.ToInt32(dr["CantidadPostProm"]),
                            Convert.ToDecimal(dr["ValorPostProm"]),
                            Convert.ToString(dr["Referencia"]),
                            Convert.ToDecimal(dr["CostoUnitarioProm"]),
                            Convert.ToInt32(dr["Empresa_ID"]),
                            Convert.ToInt32(dr["Estacion_ID"])
                        );
                return true;
            } // End Read

            public static DataTable ReadDataTable()
            {
                return DB.Select("MovimientosInventario");
            } // End Read

            public static DataTable ReadDataTable(int movimientoinventario_id)
            {
                Hashtable w_params = new Hashtable();
                w_params.Add("MovimientoInventario_ID", movimientoinventario_id);
                return DB.Select("MovimientosInventario", w_params);
            } // End Read

            public int Update()
            {
                Hashtable m_params = new Hashtable();
                Hashtable w_params = new Hashtable();
                w_params.Add("MovimientoInventario_ID", this.MovimientoInventario_ID);
                m_params.Add("TipoMovimientoInventario_ID", this.TipoMovimientoInventario_ID);
                if (!DB.IsNullOrEmpty(this.OrdenCompra_ID)) m_params.Add("OrdenCompra_ID", this.OrdenCompra_ID);
                if (!DB.IsNullOrEmpty(this.OrdenTrabajo_ID)) m_params.Add("OrdenTrabajo_ID", this.OrdenTrabajo_ID);
                if (!DB.IsNullOrEmpty(this.NotaAlmacen_ID)) m_params.Add("NotaAlmacen_ID", this.NotaAlmacen_ID);
                if (!DB.IsNullOrEmpty(this.AjusteInventario_ID)) m_params.Add("AjusteInventario_ID", this.AjusteInventario_ID);
                m_params.Add("Usuario_ID", this.Usuario_ID);
                m_params.Add("Refaccion_ID", this.Refaccion_ID);
                m_params.Add("Fecha", this.Fecha);
                m_params.Add("Cantidad", this.Cantidad);
                m_params.Add("CostoUnitario", this.CostoUnitario);
                m_params.Add("Valor", this.Valor);
                m_params.Add("CantidadPrev", this.CantidadPrev);
                m_params.Add("ValorPrev", this.ValorPrev);
                m_params.Add("CantidadPost", this.CantidadPost);
                m_params.Add("ValorPost", this.ValorPost);
                m_params.Add("CantidadPrevProm", this.CantidadPrevProm);
                m_params.Add("ValorPrevProm", this.ValorPrevProm);
                m_params.Add("CantidadPostProm", this.CantidadPostProm);
                m_params.Add("ValorPostProm", this.ValorPostProm);
                if (!DB.IsNullOrEmpty(this.Referencia)) m_params.Add("Referencia", this.Referencia);
                m_params.Add("CostoUnitarioProm", this.CostoUnitarioProm);
                m_params.Add("Empresa_ID", this.Empresa_ID);
                m_params.Add("Estacion_ID", this.Estacion_ID);

                return DB.UpdateRow("MovimientosInventario", m_params, w_params);
            } // End Update

            public int Delete()
            {
                Hashtable w_params = new Hashtable();
                w_params.Add("MovimientoInventario_ID", this.MovimientoInventario_ID);

                return DB.DeleteRow("MovimientosInventario", w_params);
            } // End Delete


            #endregion
        } //End Class MovimientosInventario

        public class NotasAlmacen
        {

            #region Constructors

            public NotasAlmacen()
            {
            }

            public NotasAlmacen(
                int notaalmacen_id,
                string usuario_id,
                int tipomovimientoinventario_id,
                int? ordencompra_id,
                int? ordentrabajo_id,
                DateTime fecha,
                int empresa_id,
                int estacion_id)
            {
                this.NotaAlmacen_ID = notaalmacen_id;
                this.Usuario_ID = usuario_id;
                this.TipoMovimientoInventario_ID = tipomovimientoinventario_id;
                this.OrdenCompra_ID = ordencompra_id;
                this.OrdenTrabajo_ID = ordentrabajo_id;
                this.Fecha = fecha;
                this.Empresa_ID = empresa_id;
                this.Estacion_ID = estacion_id;
            }

            #endregion

            #region Properties

            private int _NotaAlmacen_ID;
            public int NotaAlmacen_ID
            {
                get { return _NotaAlmacen_ID; }
                set { _NotaAlmacen_ID = value; }
            }

            private string _Usuario_ID;
            public string Usuario_ID
            {
                get { return _Usuario_ID; }
                set { _Usuario_ID = value; }
            }

            private int _TipoMovimientoInventario_ID;
            public int TipoMovimientoInventario_ID
            {
                get { return _TipoMovimientoInventario_ID; }
                set { _TipoMovimientoInventario_ID = value; }
            }

            private int? _OrdenCompra_ID;
            public int? OrdenCompra_ID
            {
                get { return _OrdenCompra_ID; }
                set { _OrdenCompra_ID = value; }
            }

            private int? _OrdenTrabajo_ID;
            public int? OrdenTrabajo_ID
            {
                get { return _OrdenTrabajo_ID; }
                set { _OrdenTrabajo_ID = value; }
            }

            private DateTime _Fecha;
            public DateTime Fecha
            {
                get { return _Fecha; }
                set { _Fecha = value; }
            }

            private int _Empresa_ID;
            public int Empresa_ID
            {
                get { return _Empresa_ID; }
                set { _Empresa_ID = value; }
            }

            private int _Estacion_ID;
            public int Estacion_ID
            {
                get { return _Estacion_ID; }
                set { _Estacion_ID = value; }
            }

            #endregion

            #region Methods
            public void Validate()
            {
                if (this.NotaAlmacen_ID == null) throw new Exception("NotaAlmacen_ID no puede ser nulo.");

                if (this.Usuario_ID == null) throw new Exception("Usuario_ID no puede ser nulo.");

                if (this.Usuario_ID.Length > 30)
                {
                    throw new Exception("Usuario_ID debe tener máximo 30 carateres.");
                }

                if (this.TipoMovimientoInventario_ID == null) throw new Exception("TipoMovimientoInventario_ID no puede ser nulo.");

                if (this.Fecha == null) throw new Exception("Fecha no puede ser nulo.");

                if (this.Empresa_ID == null) throw new Exception("Empresa_ID no puede ser nulo.");

                if (this.Estacion_ID == null) throw new Exception("Estacion_ID no puede ser nulo.");


            } // End Validate

            public int Create()
            {
                Hashtable m_params = new Hashtable();
                m_params.Add("Usuario_ID", this.Usuario_ID);
                m_params.Add("TipoMovimientoInventario_ID", this.TipoMovimientoInventario_ID);
                if (!DB.IsNullOrEmpty(this.OrdenCompra_ID)) m_params.Add("OrdenCompra_ID", this.OrdenCompra_ID);
                if (!DB.IsNullOrEmpty(this.OrdenTrabajo_ID)) m_params.Add("OrdenTrabajo_ID", this.OrdenTrabajo_ID);
                m_params.Add("Fecha", this.Fecha);
                m_params.Add("Empresa_ID", this.Empresa_ID);
                m_params.Add("Estacion_ID", this.Estacion_ID);

                return DB.InsertRow("NotasAlmacen", m_params);
            } // End Create

            public int Create(bool IsIdentityInsert)
            {
                if (!IsIdentityInsert) return Create();
                Hashtable m_params = new Hashtable();
                m_params.Add("NotaAlmacen_ID", this.NotaAlmacen_ID);
                m_params.Add("Usuario_ID", this.Usuario_ID);
                m_params.Add("TipoMovimientoInventario_ID", this.TipoMovimientoInventario_ID);
                if (!DB.IsNullOrEmpty(this.OrdenCompra_ID)) m_params.Add("OrdenCompra_ID", this.OrdenCompra_ID);
                if (!DB.IsNullOrEmpty(this.OrdenTrabajo_ID)) m_params.Add("OrdenTrabajo_ID", this.OrdenTrabajo_ID);
                m_params.Add("Fecha", this.Fecha);
                m_params.Add("Empresa_ID", this.Empresa_ID);
                m_params.Add("Estacion_ID", this.Estacion_ID);

                return DB.IdentityInsertRow("NotasAlmacen", m_params);
            } // End Create

            public static List<NotasAlmacen> Read()
            {
                List<NotasAlmacen> list = new List<NotasAlmacen>();
                DataTable dt = DB.Select("NotasAlmacen");
                foreach (DataRow dr in dt.Rows)
                {
                    list.Add(
                        new NotasAlmacen(
                            Convert.ToInt32(dr["NotaAlmacen_ID"]),
                            Convert.ToString(dr["Usuario_ID"]),
                            Convert.ToInt32(dr["TipoMovimientoInventario_ID"]),
                            DB.GetNullableInt32(dr["OrdenCompra_ID"]),
                            DB.GetNullableInt32(dr["OrdenTrabajo_ID"]),
                            Convert.ToDateTime(dr["Fecha"]),
                            Convert.ToInt32(dr["Empresa_ID"]),
                            Convert.ToInt32(dr["Estacion_ID"])
                        )
                    );
                }

                return list;
            } // End Read

            public static NotasAlmacen Read(int notaalmacen_id)
            {
                Hashtable w_params = new Hashtable();
                w_params.Add("NotaAlmacen_ID", notaalmacen_id);
                DataTable dt = DB.Select("NotasAlmacen", w_params);
                if (dt.Rows.Count == 0)
                {
                    throw new Exception("No existe NotasAlmacen con los criterios de búsqueda especificados.");
                }
                DataRow dr = dt.Rows[0];
                return new NotasAlmacen(
                    Convert.ToInt32(dr["NotaAlmacen_ID"]),
                            Convert.ToString(dr["Usuario_ID"]),
                            Convert.ToInt32(dr["TipoMovimientoInventario_ID"]),
                            DB.GetNullableInt32(dr["OrdenCompra_ID"]),
                            DB.GetNullableInt32(dr["OrdenTrabajo_ID"]),
                            Convert.ToDateTime(dr["Fecha"]),
                            Convert.ToInt32(dr["Empresa_ID"]),
                            Convert.ToInt32(dr["Estacion_ID"])
                        );
            } // End Read

            public static NotasAlmacen Read(params KeyValuePair<string, object>[] args)
            {
                DataTable dt = DB.Read("NotasAlmacen", args);
                if (dt.Rows.Count == 0)
                {
                    return null;
                }
                DataRow dr = dt.Rows[0];
                return new NotasAlmacen(
                    Convert.ToInt32(dr["NotaAlmacen_ID"]),
                            Convert.ToString(dr["Usuario_ID"]),
                            Convert.ToInt32(dr["TipoMovimientoInventario_ID"]),
                            DB.GetNullableInt32(dr["OrdenCompra_ID"]),
                            DB.GetNullableInt32(dr["OrdenTrabajo_ID"]),
                            Convert.ToDateTime(dr["Fecha"]),
                            Convert.ToInt32(dr["Empresa_ID"]),
                            Convert.ToInt32(dr["Estacion_ID"])
                        );
            } // End Read

            public static bool Read(
                out NotasAlmacen notasalmacen,
                int top,
                string filter,
                string sort,
                params KeyValuePair<string, object>[] args)
            {
                DataTable dt = DB.Read("NotasAlmacen", top, filter, sort, args);
                if (dt.Rows.Count == 0)
                {
                    notasalmacen = null;
                    return false;
                }
                DataRow dr = dt.Rows[0];
                notasalmacen = new NotasAlmacen(
                    Convert.ToInt32(dr["NotaAlmacen_ID"]),
                            Convert.ToString(dr["Usuario_ID"]),
                            Convert.ToInt32(dr["TipoMovimientoInventario_ID"]),
                            DB.GetNullableInt32(dr["OrdenCompra_ID"]),
                            DB.GetNullableInt32(dr["OrdenTrabajo_ID"]),
                            Convert.ToDateTime(dr["Fecha"]),
                            Convert.ToInt32(dr["Empresa_ID"]),
                            Convert.ToInt32(dr["Estacion_ID"])
                        );
                return true;
            } // End Read

            public static DataTable ReadDataTable()
            {
                return DB.Select("NotasAlmacen");
            } // End Read

            public static DataTable ReadDataTable(int notaalmacen_id)
            {
                Hashtable w_params = new Hashtable();
                w_params.Add("NotaAlmacen_ID", notaalmacen_id);
                return DB.Select("NotasAlmacen", w_params);
            } // End Read

            public int Update()
            {
                Hashtable m_params = new Hashtable();
                Hashtable w_params = new Hashtable();
                w_params.Add("NotaAlmacen_ID", this.NotaAlmacen_ID);
                m_params.Add("Usuario_ID", this.Usuario_ID);
                m_params.Add("TipoMovimientoInventario_ID", this.TipoMovimientoInventario_ID);
                if (!DB.IsNullOrEmpty(this.OrdenCompra_ID)) m_params.Add("OrdenCompra_ID", this.OrdenCompra_ID);
                if (!DB.IsNullOrEmpty(this.OrdenTrabajo_ID)) m_params.Add("OrdenTrabajo_ID", this.OrdenTrabajo_ID);
                m_params.Add("Fecha", this.Fecha);
                m_params.Add("Empresa_ID", this.Empresa_ID);
                m_params.Add("Estacion_ID", this.Estacion_ID);

                return DB.UpdateRow("NotasAlmacen", m_params, w_params);
            } // End Update

            public int Delete()
            {
                Hashtable w_params = new Hashtable();
                w_params.Add("NotaAlmacen_ID", this.NotaAlmacen_ID);

                return DB.DeleteRow("NotasAlmacen", w_params);
            } // End Delete


            #endregion
        } //End Class NotasAlmacen

        public class Opciones
        {

            public Opciones()
            {
            }

            public Opciones(int opcion_id, int menu_id, string nombre, string texto, string imagen, bool esherramienta)
            {
                this.Opcion_ID = opcion_id;
                this.Menu_ID = menu_id;
                this.Nombre = nombre;
                this.Texto = texto;
                this.Imagen = imagen;
                this.EsHerramienta = esherramienta;
            }

            private int _Opcion_ID;
            public int Opcion_ID
            {
                get { return _Opcion_ID; }
                set { _Opcion_ID = value; }
            }

            private int _Menu_ID;
            public int Menu_ID
            {
                get { return _Menu_ID; }
                set { _Menu_ID = value; }
            }

            private string _Nombre;
            public string Nombre
            {
                get { return _Nombre; }
                set { _Nombre = value; }
            }

            private string _Texto;
            public string Texto
            {
                get { return _Texto; }
                set { _Texto = value; }
            }

            private string _Imagen;
            public string Imagen
            {
                get { return _Imagen; }
                set { _Imagen = value; }
            }

            private bool _EsHerramienta;
            public bool EsHerramienta
            {
                get { return _EsHerramienta; }
                set { _EsHerramienta = value; }
            }

            public int Create()
            {
                Hashtable m_params = new Hashtable();
                m_params.Add("Menu_ID", this.Menu_ID);
                m_params.Add("Nombre", this.Nombre);
                m_params.Add("Texto", this.Texto);
                m_params.Add("Imagen", this.Imagen);
                m_params.Add("EsHerramienta", this.EsHerramienta);

                return DB.InsertRow("Opciones", m_params);
            } // End Create

            public static List<Opciones> Read()
            {
                List<Opciones> list = new List<Opciones>();
                DataTable dt = DB.Select("Opciones");
                foreach (DataRow dr in dt.Rows)
                {
                    list.Add(new Opciones(Convert.ToInt32(dr["Opcion_ID"]), Convert.ToInt32(dr["Menu_ID"]), Convert.ToString(dr["Nombre"]), Convert.ToString(dr["Texto"]), Convert.ToString(dr["Imagen"]), Convert.ToBoolean(dr["EsHerramienta"])));
                }

                return list;
            } // End Read

            public static List<Opciones> Read(int opcion_id)
            {
                List<Opciones> list = new List<Opciones>();
                Hashtable w_params = new Hashtable();
                w_params.Add("Opcion_ID", opcion_id);
                DataTable dt = DB.Select("Opciones", w_params);
                foreach (DataRow dr in dt.Rows)
                {
                    list.Add(new Opciones(Convert.ToInt32(dr["Opcion_ID"]), Convert.ToInt32(dr["Menu_ID"]), Convert.ToString(dr["Nombre"]), Convert.ToString(dr["Texto"]), Convert.ToString(dr["Imagen"]), Convert.ToBoolean(dr["EsHerramienta"])));
                }

                return list;
            } // End Read

            public int Update()
            {
                Hashtable m_params = new Hashtable();
                Hashtable w_params = new Hashtable();
                w_params.Add("Opcion_ID", this.Opcion_ID);
                m_params.Add("Menu_ID", this.Menu_ID);
                m_params.Add("Nombre", this.Nombre);
                m_params.Add("Texto", this.Texto);
                m_params.Add("Imagen", this.Imagen);
                m_params.Add("EsHerramienta", this.EsHerramienta);

                return DB.UpdateRow("Opciones", m_params, w_params);
            } // End Update

            public int Delete()
            {
                Hashtable w_params = new Hashtable();
                w_params.Add("Opcion_ID", this.Opcion_ID);

                return DB.DeleteRow("Opciones", w_params);
            }

        } //End Class Opciones

        public class OrdenesCompras
        {

            #region Constructors

            public OrdenesCompras()
            {
            }

            public OrdenesCompras(
                int ordencompra_id,
                int proveedor_id,
                int estatusordencompra_id,
                string usuario_id,
                DateTime fecha,
                string factura,
                decimal subtotal,
                decimal iva,
                decimal total,
                int empresa_id,
                int estacion_id)
            {
                this.OrdenCompra_ID = ordencompra_id;
                this.Proveedor_ID = proveedor_id;
                this.EstatusOrdenCompra_ID = estatusordencompra_id;
                this.Usuario_ID = usuario_id;
                this.Fecha = fecha;
                this.Factura = factura;
                this.Subtotal = subtotal;
                this.IVA = iva;
                this.Total = total;
                this.Empresa_ID = empresa_id;
                this.Estacion_ID = estacion_id;
            }

            #endregion

            #region Properties

            private int _OrdenCompra_ID;
            public int OrdenCompra_ID
            {
                get { return _OrdenCompra_ID; }
                set { _OrdenCompra_ID = value; }
            }

            private int _Proveedor_ID;
            public int Proveedor_ID
            {
                get { return _Proveedor_ID; }
                set { _Proveedor_ID = value; }
            }

            private int _EstatusOrdenCompra_ID;
            public int EstatusOrdenCompra_ID
            {
                get { return _EstatusOrdenCompra_ID; }
                set { _EstatusOrdenCompra_ID = value; }
            }

            private string _Usuario_ID;
            public string Usuario_ID
            {
                get { return _Usuario_ID; }
                set { _Usuario_ID = value; }
            }

            private DateTime _Fecha;
            public DateTime Fecha
            {
                get { return _Fecha; }
                set { _Fecha = value; }
            }

            private string _Factura;
            public string Factura
            {
                get { return _Factura; }
                set { _Factura = value; }
            }

            private decimal _Subtotal;
            public decimal Subtotal
            {
                get { return _Subtotal; }
                set { _Subtotal = value; }
            }

            private decimal _IVA;
            public decimal IVA
            {
                get { return _IVA; }
                set { _IVA = value; }
            }

            private decimal _Total;
            public decimal Total
            {
                get { return _Total; }
                set { _Total = value; }
            }

            private int _Empresa_ID;
            public int Empresa_ID
            {
                get { return _Empresa_ID; }
                set { _Empresa_ID = value; }
            }

            private int _Estacion_ID;
            public int Estacion_ID
            {
                get { return _Estacion_ID; }
                set { _Estacion_ID = value; }
            }

            #endregion

            #region Methods
            public void Validate()
            {
                if (this.OrdenCompra_ID == null) throw new Exception("OrdenCompra_ID no puede ser nulo.");

                if (this.Proveedor_ID == null) throw new Exception("Proveedor_ID no puede ser nulo.");

                if (this.EstatusOrdenCompra_ID == null) throw new Exception("EstatusOrdenCompra_ID no puede ser nulo.");

                if (this.Usuario_ID == null) throw new Exception("Usuario_ID no puede ser nulo.");

                if (this.Usuario_ID.Length > 30)
                {
                    throw new Exception("Usuario_ID debe tener máximo 30 carateres.");
                }

                if (this.Fecha == null) throw new Exception("Fecha no puede ser nulo.");

                if (this.Factura == null) throw new Exception("Factura no puede ser nulo.");

                if (this.Factura.Length > 50)
                {
                    throw new Exception("Factura debe tener máximo 50 carateres.");
                }

                if (this.Subtotal == null) throw new Exception("Subtotal no puede ser nulo.");

                if (this.IVA == null) throw new Exception("IVA no puede ser nulo.");

                if (this.Total == null) throw new Exception("Total no puede ser nulo.");

                if (this.Empresa_ID == null) throw new Exception("Empresa_ID no puede ser nulo.");

                if (this.Estacion_ID == null) throw new Exception("Estacion_ID no puede ser nulo.");


            } // End Validate

            public int Create()
            {
                Hashtable m_params = new Hashtable();
                m_params.Add("Proveedor_ID", this.Proveedor_ID);
                m_params.Add("EstatusOrdenCompra_ID", this.EstatusOrdenCompra_ID);
                m_params.Add("Usuario_ID", this.Usuario_ID);
                m_params.Add("Fecha", this.Fecha);
                m_params.Add("Factura", this.Factura);
                m_params.Add("Subtotal", this.Subtotal);
                m_params.Add("IVA", this.IVA);
                m_params.Add("Total", this.Total);
                m_params.Add("Empresa_ID", this.Empresa_ID);
                m_params.Add("Estacion_ID", this.Estacion_ID);

                return DB.InsertRow("OrdenesCompras", m_params);
            } // End Create

            public int Create(bool IsIdentityInsert)
            {
                if (!IsIdentityInsert) return Create();
                Hashtable m_params = new Hashtable();
                m_params.Add("OrdenCompra_ID", this.OrdenCompra_ID);
                m_params.Add("Proveedor_ID", this.Proveedor_ID);
                m_params.Add("EstatusOrdenCompra_ID", this.EstatusOrdenCompra_ID);
                m_params.Add("Usuario_ID", this.Usuario_ID);
                m_params.Add("Fecha", this.Fecha);
                m_params.Add("Factura", this.Factura);
                m_params.Add("Subtotal", this.Subtotal);
                m_params.Add("IVA", this.IVA);
                m_params.Add("Total", this.Total);
                m_params.Add("Empresa_ID", this.Empresa_ID);
                m_params.Add("Estacion_ID", this.Estacion_ID);

                return DB.IdentityInsertRow("OrdenesCompras", m_params);
            } // End Create

            public static List<OrdenesCompras> Read()
            {
                List<OrdenesCompras> list = new List<OrdenesCompras>();
                DataTable dt = DB.Select("OrdenesCompras");
                foreach (DataRow dr in dt.Rows)
                {
                    list.Add(
                        new OrdenesCompras(
                            Convert.ToInt32(dr["OrdenCompra_ID"]),
                            Convert.ToInt32(dr["Proveedor_ID"]),
                            Convert.ToInt32(dr["EstatusOrdenCompra_ID"]),
                            Convert.ToString(dr["Usuario_ID"]),
                            Convert.ToDateTime(dr["Fecha"]),
                            Convert.ToString(dr["Factura"]),
                            Convert.ToDecimal(dr["Subtotal"]),
                            Convert.ToDecimal(dr["IVA"]),
                            Convert.ToDecimal(dr["Total"]),
                            Convert.ToInt32(dr["Empresa_ID"]),
                            Convert.ToInt32(dr["Estacion_ID"])
                        )
                    );
                }

                return list;
            } // End Read

            public static OrdenesCompras Read(int ordencompra_id)
            {
                Hashtable w_params = new Hashtable();
                w_params.Add("OrdenCompra_ID", ordencompra_id);
                DataTable dt = DB.Select("OrdenesCompras", w_params);
                if (dt.Rows.Count == 0)
                {
                    throw new Exception("No existe OrdenesCompras con los criterios de búsqueda especificados.");
                }
                DataRow dr = dt.Rows[0];
                return new OrdenesCompras(
                    Convert.ToInt32(dr["OrdenCompra_ID"]),
                            Convert.ToInt32(dr["Proveedor_ID"]),
                            Convert.ToInt32(dr["EstatusOrdenCompra_ID"]),
                            Convert.ToString(dr["Usuario_ID"]),
                            Convert.ToDateTime(dr["Fecha"]),
                            Convert.ToString(dr["Factura"]),
                            Convert.ToDecimal(dr["Subtotal"]),
                            Convert.ToDecimal(dr["IVA"]),
                            Convert.ToDecimal(dr["Total"]),
                            Convert.ToInt32(dr["Empresa_ID"]),
                            Convert.ToInt32(dr["Estacion_ID"])
                        );
            } // End Read

            public static OrdenesCompras Read(params KeyValuePair<string, object>[] args)
            {
                DataTable dt = DB.Read("OrdenesCompras", args);
                if (dt.Rows.Count == 0)
                {
                    return null;
                }
                DataRow dr = dt.Rows[0];
                return new OrdenesCompras(
                    Convert.ToInt32(dr["OrdenCompra_ID"]),
                            Convert.ToInt32(dr["Proveedor_ID"]),
                            Convert.ToInt32(dr["EstatusOrdenCompra_ID"]),
                            Convert.ToString(dr["Usuario_ID"]),
                            Convert.ToDateTime(dr["Fecha"]),
                            Convert.ToString(dr["Factura"]),
                            Convert.ToDecimal(dr["Subtotal"]),
                            Convert.ToDecimal(dr["IVA"]),
                            Convert.ToDecimal(dr["Total"]),
                            Convert.ToInt32(dr["Empresa_ID"]),
                            Convert.ToInt32(dr["Estacion_ID"])
                        );
            } // End Read

            public static bool Read(
                out OrdenesCompras ordenescompras,
                int top,
                string filter,
                string sort,
                params KeyValuePair<string, object>[] args)
            {
                DataTable dt = DB.Read("OrdenesCompras", top, filter, sort, args);
                if (dt.Rows.Count == 0)
                {
                    ordenescompras = null;
                    return false;
                }
                DataRow dr = dt.Rows[0];
                ordenescompras = new OrdenesCompras(
                    Convert.ToInt32(dr["OrdenCompra_ID"]),
                            Convert.ToInt32(dr["Proveedor_ID"]),
                            Convert.ToInt32(dr["EstatusOrdenCompra_ID"]),
                            Convert.ToString(dr["Usuario_ID"]),
                            Convert.ToDateTime(dr["Fecha"]),
                            Convert.ToString(dr["Factura"]),
                            Convert.ToDecimal(dr["Subtotal"]),
                            Convert.ToDecimal(dr["IVA"]),
                            Convert.ToDecimal(dr["Total"]),
                            Convert.ToInt32(dr["Empresa_ID"]),
                            Convert.ToInt32(dr["Estacion_ID"])
                        );
                return true;
            } // End Read

            public static DataTable ReadDataTable()
            {
                return DB.Select("OrdenesCompras");
            } // End Read

            public static DataTable ReadDataTable(int ordencompra_id)
            {
                Hashtable w_params = new Hashtable();
                w_params.Add("OrdenCompra_ID", ordencompra_id);
                return DB.Select("OrdenesCompras", w_params);
            } // End Read

            public int Update()
            {
                Hashtable m_params = new Hashtable();
                Hashtable w_params = new Hashtable();
                w_params.Add("OrdenCompra_ID", this.OrdenCompra_ID);
                m_params.Add("Proveedor_ID", this.Proveedor_ID);
                m_params.Add("EstatusOrdenCompra_ID", this.EstatusOrdenCompra_ID);
                m_params.Add("Usuario_ID", this.Usuario_ID);
                m_params.Add("Fecha", this.Fecha);
                m_params.Add("Factura", this.Factura);
                m_params.Add("Subtotal", this.Subtotal);
                m_params.Add("IVA", this.IVA);
                m_params.Add("Total", this.Total);
                m_params.Add("Empresa_ID", this.Empresa_ID);
                m_params.Add("Estacion_ID", this.Estacion_ID);

                return DB.UpdateRow("OrdenesCompras", m_params, w_params);
            } // End Update

            public int Delete()
            {
                Hashtable w_params = new Hashtable();
                w_params.Add("OrdenCompra_ID", this.OrdenCompra_ID);

                return DB.DeleteRow("OrdenesCompras", w_params);
            } // End Delete


            #endregion
        } //End Class OrdenesCompras

        public class OrdenesComprasCanceladas
        {

            public OrdenesComprasCanceladas()
            {
            }

            public OrdenesComprasCanceladas(int ordencompra_id, string usuario_id, DateTime fecha, string comentarios)
            {
                this.OrdenCompra_ID = ordencompra_id;
                this.Usuario_ID = usuario_id;
                this.Fecha = fecha;
                this.Comentarios = comentarios;
            }

            private int _OrdenCompra_ID;
            public int OrdenCompra_ID
            {
                get { return _OrdenCompra_ID; }
                set { _OrdenCompra_ID = value; }
            }

            private string _Usuario_ID;
            public string Usuario_ID
            {
                get { return _Usuario_ID; }
                set { _Usuario_ID = value; }
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
                m_params.Add("OrdenCompra_ID", this.OrdenCompra_ID);
                m_params.Add("Usuario_ID", this.Usuario_ID);
                m_params.Add("Fecha", this.Fecha);
                m_params.Add("Comentarios", this.Comentarios);

                return DB.InsertRow("OrdenesComprasCanceladas", m_params);
            } // End Create

            public static List<OrdenesComprasCanceladas> Read()
            {
                List<OrdenesComprasCanceladas> list = new List<OrdenesComprasCanceladas>();
                DataTable dt = DB.Select("OrdenesComprasCanceladas");
                foreach (DataRow dr in dt.Rows)
                {
                    list.Add(new OrdenesComprasCanceladas(Convert.ToInt32(dr["OrdenCompra_ID"]), Convert.ToString(dr["Usuario_ID"]), Convert.ToDateTime(dr["Fecha"]), Convert.ToString(dr["Comentarios"])));
                }

                return list;
            } // End Read

            public static OrdenesComprasCanceladas Read(int ordencompra_id)
            {
                Hashtable w_params = new Hashtable();
                w_params.Add("OrdenCompra_ID", ordencompra_id);
                DataTable dt = DB.Select("OrdenesComprasCanceladas", w_params);
                if (dt.Rows.Count == 0)
                {
                    throw new Exception("No existe OrdenesComprasCanceladas con los criterios de búsqueda especificados.");
                }
                DataRow dr = dt.Rows[0];
                return new OrdenesComprasCanceladas(Convert.ToInt32(dr["OrdenCompra_ID"]), Convert.ToString(dr["Usuario_ID"]), Convert.ToDateTime(dr["Fecha"]), Convert.ToString(dr["Comentarios"]));
            } // End Read

            public int Update()
            {
                Hashtable m_params = new Hashtable();
                Hashtable w_params = new Hashtable();
                w_params.Add("OrdenCompra_ID", this.OrdenCompra_ID);
                m_params.Add("Usuario_ID", this.Usuario_ID);
                m_params.Add("Fecha", this.Fecha);
                m_params.Add("Comentarios", this.Comentarios);

                return DB.UpdateRow("OrdenesComprasCanceladas", m_params, w_params);
            } // End Update

            public int Delete()
            {
                Hashtable w_params = new Hashtable();
                w_params.Add("OrdenCompra_ID", this.OrdenCompra_ID);

                return DB.DeleteRow("OrdenesComprasCanceladas", w_params);
            } // End Delete

        } //End Class OrdenesComprasCanceladas

        public class OrdenesServicios
        {

            public OrdenesServicios()
            {
            }

            public OrdenesServicios(int ordenservicio_id, int ordentrabajo_id, int serviciomantenimiento_id, int mecanico_id, 
                int estatusordenservicio_id, DateTime? fecha, int cantidad, decimal precio, decimal total)
            {
                this.OrdenServicio_ID = ordenservicio_id;
                this.OrdenTrabajo_ID = ordentrabajo_id;
                this.ServicioMantenimiento_ID = serviciomantenimiento_id;
                this.Mecanico_ID = mecanico_id;
                this.EstatusOrdenServicio_ID = estatusordenservicio_id;
                this.Fecha = fecha;
                this.Cantidad = cantidad;
                this.Precio = precio;
                this.Total = total;
            }

            private int _OrdenServicio_ID;
            public int OrdenServicio_ID
            {
                get { return _OrdenServicio_ID; }
                set { _OrdenServicio_ID = value; }
            }

            private int _OrdenTrabajo_ID;
            public int OrdenTrabajo_ID
            {
                get { return _OrdenTrabajo_ID; }
                set { _OrdenTrabajo_ID = value; }
            }

            private int _ServicioMantenimiento_ID;
            public int ServicioMantenimiento_ID
            {
                get { return _ServicioMantenimiento_ID; }
                set { _ServicioMantenimiento_ID = value; }
            }

            private int _Mecanico_ID;
            public int Mecanico_ID
            {
                get { return _Mecanico_ID; }
                set { _Mecanico_ID = value; }
            }

            private int _EstatusOrdenServicio_ID;
            public int EstatusOrdenServicio_ID
            {
                get { return _EstatusOrdenServicio_ID; }
                set { _EstatusOrdenServicio_ID = value; }
            }

            private DateTime? _Fecha;
            public DateTime? Fecha
            {
                get { return _Fecha; }
                set { _Fecha = value; }
            }

            private int _Cantidad;
            public int Cantidad
            {
                get { return _Cantidad; }
                set { _Cantidad = value; }
            }

            private decimal _Precio;
            public decimal Precio
            {
                get { return _Precio; }
                set { _Precio = value; }
            }

            private decimal _Total;
            public decimal Total
            {
                get { return _Total; }
                set { _Total = value; }
            }            

            public int Create(bool IsIdentityInsert)
            {
                if (!IsIdentityInsert) return Create();

                Hashtable m_params = new Hashtable();
                m_params.Add("OrdenServicio_ID", this.OrdenServicio_ID);
                m_params.Add("OrdenTrabajo_ID", this.OrdenTrabajo_ID);
                m_params.Add("ServicioMantenimiento_ID", this.ServicioMantenimiento_ID);
                m_params.Add("Mecanico_ID", this.Mecanico_ID);
                m_params.Add("EstatusOrdenServicio_ID", this.EstatusOrdenServicio_ID);
                m_params.Add("Fecha", this.Fecha);
                m_params.Add("Cantidad", this.Cantidad);
                m_params.Add("Precio", this.Precio);
                m_params.Add("Total", this.Total);

                return DB.IdentityInsertRow("OrdenesServicios", m_params);
            } // End Create

            public int Create()
            {
                Hashtable m_params = new Hashtable();
                m_params.Add("OrdenTrabajo_ID", this.OrdenTrabajo_ID);
                m_params.Add("ServicioMantenimiento_ID", this.ServicioMantenimiento_ID);
                m_params.Add("Mecanico_ID", this.Mecanico_ID);
                m_params.Add("EstatusOrdenServicio_ID", this.EstatusOrdenServicio_ID);
                m_params.Add("Fecha", this.Fecha);
                m_params.Add("Cantidad", this.Cantidad);
                m_params.Add("Precio", this.Precio);
                m_params.Add("Total", this.Total);

                return DB.InsertRow("OrdenesServicios", m_params);
            } // End Create

            public static List<OrdenesServicios> Read()
            {
                List<OrdenesServicios> list = new List<OrdenesServicios>();
                DataTable dt = DB.Select("OrdenesServicios");
                foreach (DataRow dr in dt.Rows)
                {
                    list.Add(new OrdenesServicios(Convert.ToInt32(dr["OrdenServicio_ID"]), Convert.ToInt32(dr["OrdenTrabajo_ID"]), 
                        Convert.ToInt32(dr["ServicioMantenimiento_ID"]), Convert.ToInt32(dr["Mecanico_ID"]), Convert.ToInt32(dr["EstatusOrdenServicio_ID"]),
                            DB.GetNullableDateTime(dr["Fecha"]), Convert.ToInt32(dr["Cantidad"]), Convert.ToDecimal(dr["Precio"]), 
                                Convert.ToDecimal(dr["Total"])));
                }

                return list;
            } // End Read

            public static OrdenesServicios Read(int ordenservicio_id)
            {
                Hashtable w_params = new Hashtable();
                w_params.Add("OrdenServicio_ID", ordenservicio_id);
                DataTable dt = DB.Select("OrdenesServicios", w_params);
                if (dt.Rows.Count == 0)
                {
                    throw new Exception("No existe OrdenesServicios con los criterios de búsqueda especificados.");
                }
                DataRow dr = dt.Rows[0];
                return new OrdenesServicios(Convert.ToInt32(dr["OrdenServicio_ID"]), Convert.ToInt32(dr["OrdenTrabajo_ID"]),
                        Convert.ToInt32(dr["ServicioMantenimiento_ID"]), Convert.ToInt32(dr["Mecanico_ID"]), Convert.ToInt32(dr["EstatusOrdenServicio_ID"]),
                            DB.GetNullableDateTime(dr["Fecha"]), Convert.ToInt32(dr["Cantidad"]), Convert.ToDecimal(dr["Precio"]),
                                Convert.ToDecimal(dr["Total"]));
            } // End Read

            public int Update()
            {
                Hashtable m_params = new Hashtable();
                Hashtable w_params = new Hashtable();
                w_params.Add("OrdenServicio_ID", this.OrdenServicio_ID);
                m_params.Add("OrdenTrabajo_ID", this.OrdenTrabajo_ID);
                m_params.Add("ServicioMantenimiento_ID", this.ServicioMantenimiento_ID);
                m_params.Add("Mecanico_ID", this.Mecanico_ID);
                m_params.Add("EstatusOrdenServicio_ID", this.EstatusOrdenServicio_ID);
                m_params.Add("Fecha", this.Fecha);
                m_params.Add("Cantidad", this.Cantidad);
                m_params.Add("Precio", this.Precio);
                m_params.Add("Total", this.Total);

                return DB.UpdateRow("OrdenesServicios", m_params, w_params);
            } // End Update

            public int Delete()
            {
                Hashtable w_params = new Hashtable();
                w_params.Add("OrdenServicio_ID", this.OrdenServicio_ID);

                return DB.DeleteRow("OrdenesServicios", w_params);
            } // End Delete

        } //End Class OrdenesServicios

        public class OrdenesServiciosRefacciones
        {

            public OrdenesServiciosRefacciones()
            {
            }

            public OrdenesServiciosRefacciones(int ordenserviciorefaccion_id, int ordenservicio_id, int refaccion_id, int cantidad, decimal preciounitario, decimal total, decimal costounitario, int? refsurtidas)
            {
                this.OrdenServicioRefaccion_ID = ordenserviciorefaccion_id;
                this.OrdenServicio_ID = ordenservicio_id;
                this.Refaccion_ID = refaccion_id;
                this.Cantidad = cantidad;
                this.PrecioUnitario = preciounitario;
                this.Total = total;
                this.CostoUnitario = costounitario;
                this.RefSurtidas = refsurtidas;
            }

            private int _OrdenServicioRefaccion_ID;
            public int OrdenServicioRefaccion_ID
            {
                get { return _OrdenServicioRefaccion_ID; }
                set { _OrdenServicioRefaccion_ID = value; }
            }

            private int _OrdenServicio_ID;
            public int OrdenServicio_ID
            {
                get { return _OrdenServicio_ID; }
                set { _OrdenServicio_ID = value; }
            }

            private int _Refaccion_ID;
            public int Refaccion_ID
            {
                get { return _Refaccion_ID; }
                set { _Refaccion_ID = value; }
            }

            private int _Cantidad;
            public int Cantidad
            {
                get { return _Cantidad; }
                set { _Cantidad = value; }
            }

            private decimal _PrecioUnitario;
            public decimal PrecioUnitario
            {
                get { return _PrecioUnitario; }
                set { _PrecioUnitario = value; }
            }

            private decimal _Total;
            public decimal Total
            {
                get { return _Total; }
                set { _Total = value; }
            }

            private decimal _CostoUnitario;
            public decimal CostoUnitario
            {
                get { return _CostoUnitario; }
                set { _CostoUnitario = value; }
            }

            private int? _RefSurtidas;
            public int? RefSurtidas
            {
                get { return _RefSurtidas; }
                set { _RefSurtidas = value; }
            }

            public int Create()
            {
                Hashtable m_params = new Hashtable();
                m_params.Add("OrdenServicio_ID", this.OrdenServicio_ID);
                m_params.Add("Refaccion_ID", this.Refaccion_ID);
                m_params.Add("Cantidad", this.Cantidad);
                m_params.Add("PrecioUnitario", this.PrecioUnitario);
                m_params.Add("Total", this.Total);
                m_params.Add("CostoUnitario", this.CostoUnitario);
                if (!AppHelper.IsNullOrEmpty(this.RefSurtidas)) m_params.Add("RefSurtidas", this.RefSurtidas);

                return DB.InsertRow("OrdenesServiciosRefacciones", m_params);
            } // End Create

            public static List<OrdenesServiciosRefacciones> Read()
            {
                List<OrdenesServiciosRefacciones> list = new List<OrdenesServiciosRefacciones>();
                DataTable dt = DB.Select("OrdenesServiciosRefacciones");
                foreach (DataRow dr in dt.Rows)
                {
                    list.Add(new OrdenesServiciosRefacciones(Convert.ToInt32(dr["OrdenServicioRefaccion_ID"]), Convert.ToInt32(dr["OrdenServicio_ID"]), Convert.ToInt32(dr["Refaccion_ID"]), Convert.ToInt32(dr["Cantidad"]), Convert.ToDecimal(dr["PrecioUnitario"]), Convert.ToDecimal(dr["Total"]), Convert.ToDecimal(dr["CostoUnitario"]), DB.GetNullableInt32(dr["RefSurtidas"])));
                }

                return list;
            } // End Read

            public static OrdenesServiciosRefacciones Read(int ordenserviciorefaccion_id)
            {
                Hashtable w_params = new Hashtable();
                w_params.Add("OrdenServicioRefaccion_ID", ordenserviciorefaccion_id);
                DataTable dt = DB.Select("OrdenesServiciosRefacciones", w_params);
                if (dt.Rows.Count == 0)
                {
                    throw new Exception("No existe OrdenesServiciosRefacciones con los criterios de búsqueda especificados.");
                }
                DataRow dr = dt.Rows[0];
                return new OrdenesServiciosRefacciones(Convert.ToInt32(dr["OrdenServicioRefaccion_ID"]), Convert.ToInt32(dr["OrdenServicio_ID"]), Convert.ToInt32(dr["Refaccion_ID"]), Convert.ToInt32(dr["Cantidad"]), Convert.ToDecimal(dr["PrecioUnitario"]), Convert.ToDecimal(dr["Total"]), Convert.ToDecimal(dr["CostoUnitario"]), DB.GetNullableInt32(dr["RefSurtidas"]));
            } // End Read

            public int Update()
            {
                Hashtable m_params = new Hashtable();
                Hashtable w_params = new Hashtable();
                w_params.Add("OrdenServicioRefaccion_ID", this.OrdenServicioRefaccion_ID);
                m_params.Add("OrdenServicio_ID", this.OrdenServicio_ID);
                m_params.Add("Refaccion_ID", this.Refaccion_ID);
                m_params.Add("Cantidad", this.Cantidad);
                m_params.Add("PrecioUnitario", this.PrecioUnitario);
                m_params.Add("Total", this.Total);
                m_params.Add("CostoUnitario", this.CostoUnitario);
                if (!AppHelper.IsNullOrEmpty(this.RefSurtidas)) m_params.Add("RefSurtidas", this.RefSurtidas);

                return DB.UpdateRow("OrdenesServiciosRefacciones", m_params, w_params);
            } // End Update

            public int Delete()
            {
                Hashtable w_params = new Hashtable();
                w_params.Add("OrdenServicioRefaccion_ID", this.OrdenServicioRefaccion_ID);

                return DB.DeleteRow("OrdenesServiciosRefacciones", w_params);
            } // End Delete

        } //End Class OrdenesServiciosRefacciones

        public class OrdenesTrabajos
        {

            #region Constructors

            public OrdenesTrabajos()
            {
            }

            public OrdenesTrabajos(
                int ordentrabajo_id,
                int empresa_id,
                int tipomantenimiento_id,
                int clientefacturar_id,
                int unidad_id,
                int estatusordentrabajo_id,
                int? caja_id,
                string usuario_id,
                int? factura_id,
                string usuariofacturacion_id,
                string codigobarras,
                decimal subtotal,
                decimal iva,
                decimal total,
                DateTime fechaalta,
                DateTime? fechaterminacion,
                DateTime? fechapago,
                int numeroeconomico,
                DateTime? fechainicioreparacion,
                decimal manoobra,
                decimal ivamanoobra,
                decimal refacciones,
                decimal ivarefacciones,
                DateTime? fechafacturacion,
                int? kilometraje,
                string comentarios,
                decimal costorefacciones,
                decimal costomanoobra,
                bool cargoaconductor,
                string cb,
                bool cb_activo,
                int estacion_id)
            {
                this.OrdenTrabajo_ID = ordentrabajo_id;
                this.Empresa_ID = empresa_id;
                this.TipoMantenimiento_ID = tipomantenimiento_id;
                this.ClienteFacturar_ID = clientefacturar_id;
                this.Unidad_ID = unidad_id;
                this.EstatusOrdenTrabajo_ID = estatusordentrabajo_id;
                this.Caja_ID = caja_id;
                this.Usuario_ID = usuario_id;
                this.Factura_ID = factura_id;
                this.UsuarioFacturacion_ID = usuariofacturacion_id;
                this.CodigoBarras = codigobarras;
                this.Subtotal = subtotal;
                this.IVA = iva;
                this.Total = total;
                this.FechaAlta = fechaalta;
                this.FechaTerminacion = fechaterminacion;
                this.FechaPago = fechapago;
                this.NumeroEconomico = numeroeconomico;
                this.FechaInicioReparacion = fechainicioreparacion;
                this.ManoObra = manoobra;
                this.IVAManoObra = ivamanoobra;
                this.Refacciones = refacciones;
                this.IVARefacciones = ivarefacciones;
                this.FechaFacturacion = fechafacturacion;
                this.Kilometraje = kilometraje;
                this.Comentarios = comentarios;
                this.CostoRefacciones = costorefacciones;
                this.CostoManoObra = costomanoobra;
                this.CargoAConductor = cargoaconductor;
                this.CB = cb;
                this.CB_Activo = cb_activo;
                this.Estacion_ID = estacion_id;
            }

            #endregion

            #region Properties

            private int _OrdenTrabajo_ID;
            public int OrdenTrabajo_ID
            {
                get { return _OrdenTrabajo_ID; }
                set { _OrdenTrabajo_ID = value; }
            }

            private int _Empresa_ID;
            public int Empresa_ID
            {
                get { return _Empresa_ID; }
                set { _Empresa_ID = value; }
            }

            private int _TipoMantenimiento_ID;
            public int TipoMantenimiento_ID
            {
                get { return _TipoMantenimiento_ID; }
                set { _TipoMantenimiento_ID = value; }
            }

            private int _ClienteFacturar_ID;
            public int ClienteFacturar_ID
            {
                get { return _ClienteFacturar_ID; }
                set { _ClienteFacturar_ID = value; }
            }

            private int _Unidad_ID;
            public int Unidad_ID
            {
                get { return _Unidad_ID; }
                set { _Unidad_ID = value; }
            }

            private int _EstatusOrdenTrabajo_ID;
            public int EstatusOrdenTrabajo_ID
            {
                get { return _EstatusOrdenTrabajo_ID; }
                set { _EstatusOrdenTrabajo_ID = value; }
            }

            private int? _Caja_ID;
            public int? Caja_ID
            {
                get { return _Caja_ID; }
                set { _Caja_ID = value; }
            }

            private string _Usuario_ID;
            public string Usuario_ID
            {
                get { return _Usuario_ID; }
                set { _Usuario_ID = value; }
            }

            private int? _Factura_ID;
            public int? Factura_ID
            {
                get { return _Factura_ID; }
                set { _Factura_ID = value; }
            }

            private string _UsuarioFacturacion_ID;
            public string UsuarioFacturacion_ID
            {
                get { return _UsuarioFacturacion_ID; }
                set { _UsuarioFacturacion_ID = value; }
            }

            private string _CodigoBarras;
            public string CodigoBarras
            {
                get { return _CodigoBarras; }
                set { _CodigoBarras = value; }
            }

            private decimal _Subtotal;
            public decimal Subtotal
            {
                get { return _Subtotal; }
                set { _Subtotal = value; }
            }

            private decimal _IVA;
            public decimal IVA
            {
                get { return _IVA; }
                set { _IVA = value; }
            }

            private decimal _Total;
            public decimal Total
            {
                get { return _Total; }
                set { _Total = value; }
            }

            private DateTime _FechaAlta;
            public DateTime FechaAlta
            {
                get { return _FechaAlta; }
                set { _FechaAlta = value; }
            }

            private DateTime? _FechaTerminacion;
            public DateTime? FechaTerminacion
            {
                get { return _FechaTerminacion; }
                set { _FechaTerminacion = value; }
            }

            private DateTime? _FechaPago;
            public DateTime? FechaPago
            {
                get { return _FechaPago; }
                set { _FechaPago = value; }
            }

            private int _NumeroEconomico;
            public int NumeroEconomico
            {
                get { return _NumeroEconomico; }
                set { _NumeroEconomico = value; }
            }

            private DateTime? _FechaInicioReparacion;
            public DateTime? FechaInicioReparacion
            {
                get { return _FechaInicioReparacion; }
                set { _FechaInicioReparacion = value; }
            }

            private decimal _ManoObra;
            public decimal ManoObra
            {
                get { return _ManoObra; }
                set { _ManoObra = value; }
            }

            private decimal _IVAManoObra;
            public decimal IVAManoObra
            {
                get { return _IVAManoObra; }
                set { _IVAManoObra = value; }
            }

            private decimal _Refacciones;
            public decimal Refacciones
            {
                get { return _Refacciones; }
                set { _Refacciones = value; }
            }

            private decimal _IVARefacciones;
            public decimal IVARefacciones
            {
                get { return _IVARefacciones; }
                set { _IVARefacciones = value; }
            }

            private DateTime? _FechaFacturacion;
            public DateTime? FechaFacturacion
            {
                get { return _FechaFacturacion; }
                set { _FechaFacturacion = value; }
            }

            private int? _Kilometraje;
            public int? Kilometraje
            {
                get { return _Kilometraje; }
                set { _Kilometraje = value; }
            }

            private string _Comentarios;
            public string Comentarios
            {
                get { return _Comentarios; }
                set { _Comentarios = value; }
            }

            private decimal _CostoRefacciones;
            public decimal CostoRefacciones
            {
                get { return _CostoRefacciones; }
                set { _CostoRefacciones = value; }
            }

            private decimal _CostoManoObra;
            public decimal CostoManoObra
            {
                get { return _CostoManoObra; }
                set { _CostoManoObra = value; }
            }

            private bool _CargoAConductor;
            public bool CargoAConductor
            {
                get { return _CargoAConductor; }
                set { _CargoAConductor = value; }
            }

            private string _CB;
            public string CB
            {
                get { return _CB; }
                set { _CB = value; }
            }

            private bool _CB_Activo;
            public bool CB_Activo
            {
                get { return _CB_Activo; }
                set { _CB_Activo = value; }
            }

            private int _Estacion_ID;
            public int Estacion_ID
            {
                get { return _Estacion_ID; }
                set { _Estacion_ID = value; }
            }

            #endregion

            #region Methods
            public void Validate()
            {
                if (this.OrdenTrabajo_ID == null) throw new Exception("OrdenTrabajo_ID no puede ser nulo.");

                if (this.Empresa_ID == null) throw new Exception("Empresa_ID no puede ser nulo.");

                if (this.TipoMantenimiento_ID == null) throw new Exception("TipoMantenimiento_ID no puede ser nulo.");

                if (this.ClienteFacturar_ID == null) throw new Exception("ClienteFacturar_ID no puede ser nulo.");

                if (this.Unidad_ID == null) throw new Exception("Unidad_ID no puede ser nulo.");

                if (this.EstatusOrdenTrabajo_ID == null) throw new Exception("EstatusOrdenTrabajo_ID no puede ser nulo.");

                if (this.Usuario_ID == null) throw new Exception("Usuario_ID no puede ser nulo.");

                if (this.Usuario_ID.Length > 30)
                {
                    throw new Exception("Usuario_ID debe tener máximo 30 carateres.");
                }

                if (this.UsuarioFacturacion_ID.Length > 30)
                {
                    throw new Exception("UsuarioFacturacion_ID debe tener máximo 30 carateres.");
                }

                if (this.CodigoBarras == null) throw new Exception("CodigoBarras no puede ser nulo.");

                if (this.CodigoBarras.Length > 50)
                {
                    throw new Exception("CodigoBarras debe tener máximo 50 carateres.");
                }

                if (this.Subtotal == null) throw new Exception("Subtotal no puede ser nulo.");

                if (this.IVA == null) throw new Exception("IVA no puede ser nulo.");

                if (this.Total == null) throw new Exception("Total no puede ser nulo.");

                if (this.FechaAlta == null) throw new Exception("FechaAlta no puede ser nulo.");

                if (this.NumeroEconomico == null) throw new Exception("NumeroEconomico no puede ser nulo.");

                if (this.ManoObra == null) throw new Exception("ManoObra no puede ser nulo.");

                if (this.IVAManoObra == null) throw new Exception("IVAManoObra no puede ser nulo.");

                if (this.Refacciones == null) throw new Exception("Refacciones no puede ser nulo.");

                if (this.IVARefacciones == null) throw new Exception("IVARefacciones no puede ser nulo.");

                if (this.Comentarios.Length > 250)
                {
                    throw new Exception("Comentarios debe tener máximo 250 carateres.");
                }

                if (this.CostoRefacciones == null) throw new Exception("CostoRefacciones no puede ser nulo.");

                if (this.CostoManoObra == null) throw new Exception("CostoManoObra no puede ser nulo.");

                if (this.CargoAConductor == null) throw new Exception("CargoAConductor no puede ser nulo.");

                if (this.CB == null) throw new Exception("CB no puede ser nulo.");

                if (this.CB.Length > 20)
                {
                    throw new Exception("CB debe tener máximo 20 carateres.");
                }

                if (this.CB_Activo == null) throw new Exception("CB_Activo no puede ser nulo.");

                if (this.Estacion_ID == null) throw new Exception("Estacion_ID no puede ser nulo.");


            } // End Validate

            public int Create()
            {
                Hashtable m_params = new Hashtable();
                m_params.Add("Empresa_ID", this.Empresa_ID);
                m_params.Add("TipoMantenimiento_ID", this.TipoMantenimiento_ID);
                m_params.Add("ClienteFacturar_ID", this.ClienteFacturar_ID);
                m_params.Add("Unidad_ID", this.Unidad_ID);
                m_params.Add("EstatusOrdenTrabajo_ID", this.EstatusOrdenTrabajo_ID);
                if (!DB.IsNullOrEmpty(this.Caja_ID)) m_params.Add("Caja_ID", this.Caja_ID);
                m_params.Add("Usuario_ID", this.Usuario_ID);
                if (!DB.IsNullOrEmpty(this.Factura_ID)) m_params.Add("Factura_ID", this.Factura_ID);
                if (!DB.IsNullOrEmpty(this.UsuarioFacturacion_ID)) m_params.Add("UsuarioFacturacion_ID", this.UsuarioFacturacion_ID);
                m_params.Add("CodigoBarras", this.CodigoBarras);
                m_params.Add("Subtotal", this.Subtotal);
                m_params.Add("IVA", this.IVA);
                m_params.Add("Total", this.Total);
                m_params.Add("FechaAlta", this.FechaAlta);
                if (!DB.IsNullOrEmpty(this.FechaTerminacion)) m_params.Add("FechaTerminacion", this.FechaTerminacion);
                if (!DB.IsNullOrEmpty(this.FechaPago)) m_params.Add("FechaPago", this.FechaPago);
                m_params.Add("NumeroEconomico", this.NumeroEconomico);
                if (!DB.IsNullOrEmpty(this.FechaInicioReparacion)) m_params.Add("FechaInicioReparacion", this.FechaInicioReparacion);
                m_params.Add("ManoObra", this.ManoObra);
                m_params.Add("IVAManoObra", this.IVAManoObra);
                m_params.Add("Refacciones", this.Refacciones);
                m_params.Add("IVARefacciones", this.IVARefacciones);
                if (!DB.IsNullOrEmpty(this.FechaFacturacion)) m_params.Add("FechaFacturacion", this.FechaFacturacion);
                if (!DB.IsNullOrEmpty(this.Kilometraje)) m_params.Add("Kilometraje", this.Kilometraje);
                if (!DB.IsNullOrEmpty(this.Comentarios)) m_params.Add("Comentarios", this.Comentarios);
                m_params.Add("CostoRefacciones", this.CostoRefacciones);
                m_params.Add("CostoManoObra", this.CostoManoObra);
                m_params.Add("CargoAConductor", this.CargoAConductor);
                m_params.Add("CB", this.CB);
                m_params.Add("CB_Activo", this.CB_Activo);
                m_params.Add("Estacion_ID", this.Estacion_ID);

                return DB.InsertRow("OrdenesTrabajos", m_params);
            } // End Create

            public int Create(bool IsIdentityInsert)
            {
                if (!IsIdentityInsert) return Create();
                Hashtable m_params = new Hashtable();
                m_params.Add("OrdenTrabajo_ID", this.OrdenTrabajo_ID);
                m_params.Add("Empresa_ID", this.Empresa_ID);
                m_params.Add("TipoMantenimiento_ID", this.TipoMantenimiento_ID);
                m_params.Add("ClienteFacturar_ID", this.ClienteFacturar_ID);
                m_params.Add("Unidad_ID", this.Unidad_ID);
                m_params.Add("EstatusOrdenTrabajo_ID", this.EstatusOrdenTrabajo_ID);
                if (!DB.IsNullOrEmpty(this.Caja_ID)) m_params.Add("Caja_ID", this.Caja_ID);
                m_params.Add("Usuario_ID", this.Usuario_ID);
                if (!DB.IsNullOrEmpty(this.Factura_ID)) m_params.Add("Factura_ID", this.Factura_ID);
                if (!DB.IsNullOrEmpty(this.UsuarioFacturacion_ID)) m_params.Add("UsuarioFacturacion_ID", this.UsuarioFacturacion_ID);
                m_params.Add("CodigoBarras", this.CodigoBarras);
                m_params.Add("Subtotal", this.Subtotal);
                m_params.Add("IVA", this.IVA);
                m_params.Add("Total", this.Total);
                m_params.Add("FechaAlta", this.FechaAlta);
                if (!DB.IsNullOrEmpty(this.FechaTerminacion)) m_params.Add("FechaTerminacion", this.FechaTerminacion);
                if (!DB.IsNullOrEmpty(this.FechaPago)) m_params.Add("FechaPago", this.FechaPago);
                m_params.Add("NumeroEconomico", this.NumeroEconomico);
                if (!DB.IsNullOrEmpty(this.FechaInicioReparacion)) m_params.Add("FechaInicioReparacion", this.FechaInicioReparacion);
                m_params.Add("ManoObra", this.ManoObra);
                m_params.Add("IVAManoObra", this.IVAManoObra);
                m_params.Add("Refacciones", this.Refacciones);
                m_params.Add("IVARefacciones", this.IVARefacciones);
                if (!DB.IsNullOrEmpty(this.FechaFacturacion)) m_params.Add("FechaFacturacion", this.FechaFacturacion);
                if (!DB.IsNullOrEmpty(this.Kilometraje)) m_params.Add("Kilometraje", this.Kilometraje);
                if (!DB.IsNullOrEmpty(this.Comentarios)) m_params.Add("Comentarios", this.Comentarios);
                m_params.Add("CostoRefacciones", this.CostoRefacciones);
                m_params.Add("CostoManoObra", this.CostoManoObra);
                m_params.Add("CargoAConductor", this.CargoAConductor);
                m_params.Add("CB", this.CB);
                m_params.Add("CB_Activo", this.CB_Activo);
                m_params.Add("Estacion_ID", this.Estacion_ID);

                return DB.IdentityInsertRow("OrdenesTrabajos", m_params);
            } // End Create

            public static List<OrdenesTrabajos> Read()
            {
                List<OrdenesTrabajos> list = new List<OrdenesTrabajos>();
                DataTable dt = DB.Select("OrdenesTrabajos");
                foreach (DataRow dr in dt.Rows)
                {
                    list.Add(
                        new OrdenesTrabajos(
                            Convert.ToInt32(dr["OrdenTrabajo_ID"]),
                            Convert.ToInt32(dr["Empresa_ID"]),
                            Convert.ToInt32(dr["TipoMantenimiento_ID"]),
                            Convert.ToInt32(dr["ClienteFacturar_ID"]),
                            Convert.ToInt32(dr["Unidad_ID"]),
                            Convert.ToInt32(dr["EstatusOrdenTrabajo_ID"]),
                            DB.GetNullableInt32(dr["Caja_ID"]),
                            Convert.ToString(dr["Usuario_ID"]),
                            DB.GetNullableInt32(dr["Factura_ID"]),
                            Convert.ToString(dr["UsuarioFacturacion_ID"]),
                            Convert.ToString(dr["CodigoBarras"]),
                            Convert.ToDecimal(dr["Subtotal"]),
                            Convert.ToDecimal(dr["IVA"]),
                            Convert.ToDecimal(dr["Total"]),
                            Convert.ToDateTime(dr["FechaAlta"]),
                            DB.GetNullableDateTime(dr["FechaTerminacion"]),
                            DB.GetNullableDateTime(dr["FechaPago"]),
                            Convert.ToInt32(dr["NumeroEconomico"]),
                            DB.GetNullableDateTime(dr["FechaInicioReparacion"]),
                            Convert.ToDecimal(dr["ManoObra"]),
                            Convert.ToDecimal(dr["IVAManoObra"]),
                            Convert.ToDecimal(dr["Refacciones"]),
                            Convert.ToDecimal(dr["IVARefacciones"]),
                            DB.GetNullableDateTime(dr["FechaFacturacion"]),
                            DB.GetNullableInt32(dr["Kilometraje"]),
                            Convert.ToString(dr["Comentarios"]),
                            Convert.ToDecimal(dr["CostoRefacciones"]),
                            Convert.ToDecimal(dr["CostoManoObra"]),
                            Convert.ToBoolean(dr["CargoAConductor"]),
                            Convert.ToString(dr["CB"]),
                            Convert.ToBoolean(dr["CB_Activo"]),
                            Convert.ToInt32(dr["Estacion_ID"])
                        )
                    );
                }

                return list;
            } // End Read

            public static OrdenesTrabajos Read(int ordentrabajo_id)
            {
                Hashtable w_params = new Hashtable();
                w_params.Add("OrdenTrabajo_ID", ordentrabajo_id);
                DataTable dt = DB.Select("OrdenesTrabajos", w_params);
                if (dt.Rows.Count == 0)
                {
                    throw new Exception("No existe OrdenesTrabajos con los criterios de búsqueda especificados.");
                }
                DataRow dr = dt.Rows[0];
                return new OrdenesTrabajos(
                    Convert.ToInt32(dr["OrdenTrabajo_ID"]),
                            Convert.ToInt32(dr["Empresa_ID"]),
                            Convert.ToInt32(dr["TipoMantenimiento_ID"]),
                            Convert.ToInt32(dr["ClienteFacturar_ID"]),
                            Convert.ToInt32(dr["Unidad_ID"]),
                            Convert.ToInt32(dr["EstatusOrdenTrabajo_ID"]),
                            DB.GetNullableInt32(dr["Caja_ID"]),
                            Convert.ToString(dr["Usuario_ID"]),
                            DB.GetNullableInt32(dr["Factura_ID"]),
                            Convert.ToString(dr["UsuarioFacturacion_ID"]),
                            Convert.ToString(dr["CodigoBarras"]),
                            Convert.ToDecimal(dr["Subtotal"]),
                            Convert.ToDecimal(dr["IVA"]),
                            Convert.ToDecimal(dr["Total"]),
                            Convert.ToDateTime(dr["FechaAlta"]),
                            DB.GetNullableDateTime(dr["FechaTerminacion"]),
                            DB.GetNullableDateTime(dr["FechaPago"]),
                            Convert.ToInt32(dr["NumeroEconomico"]),
                            DB.GetNullableDateTime(dr["FechaInicioReparacion"]),
                            Convert.ToDecimal(dr["ManoObra"]),
                            Convert.ToDecimal(dr["IVAManoObra"]),
                            Convert.ToDecimal(dr["Refacciones"]),
                            Convert.ToDecimal(dr["IVARefacciones"]),
                            DB.GetNullableDateTime(dr["FechaFacturacion"]),
                            DB.GetNullableInt32(dr["Kilometraje"]),
                            Convert.ToString(dr["Comentarios"]),
                            Convert.ToDecimal(dr["CostoRefacciones"]),
                            Convert.ToDecimal(dr["CostoManoObra"]),
                            Convert.ToBoolean(dr["CargoAConductor"]),
                            Convert.ToString(dr["CB"]),
                            Convert.ToBoolean(dr["CB_Activo"]),
                            Convert.ToInt32(dr["Estacion_ID"])
                        );
            } // End Read

            public static OrdenesTrabajos Read(params KeyValuePair<string, object>[] args)
            {
                DataTable dt = DB.Read("OrdenesTrabajos", args);
                if (dt.Rows.Count == 0)
                {
                    return null;
                }
                DataRow dr = dt.Rows[0];
                return new OrdenesTrabajos(
                    Convert.ToInt32(dr["OrdenTrabajo_ID"]),
                            Convert.ToInt32(dr["Empresa_ID"]),
                            Convert.ToInt32(dr["TipoMantenimiento_ID"]),
                            Convert.ToInt32(dr["ClienteFacturar_ID"]),
                            Convert.ToInt32(dr["Unidad_ID"]),
                            Convert.ToInt32(dr["EstatusOrdenTrabajo_ID"]),
                            DB.GetNullableInt32(dr["Caja_ID"]),
                            Convert.ToString(dr["Usuario_ID"]),
                            DB.GetNullableInt32(dr["Factura_ID"]),
                            Convert.ToString(dr["UsuarioFacturacion_ID"]),
                            Convert.ToString(dr["CodigoBarras"]),
                            Convert.ToDecimal(dr["Subtotal"]),
                            Convert.ToDecimal(dr["IVA"]),
                            Convert.ToDecimal(dr["Total"]),
                            Convert.ToDateTime(dr["FechaAlta"]),
                            DB.GetNullableDateTime(dr["FechaTerminacion"]),
                            DB.GetNullableDateTime(dr["FechaPago"]),
                            Convert.ToInt32(dr["NumeroEconomico"]),
                            DB.GetNullableDateTime(dr["FechaInicioReparacion"]),
                            Convert.ToDecimal(dr["ManoObra"]),
                            Convert.ToDecimal(dr["IVAManoObra"]),
                            Convert.ToDecimal(dr["Refacciones"]),
                            Convert.ToDecimal(dr["IVARefacciones"]),
                            DB.GetNullableDateTime(dr["FechaFacturacion"]),
                            DB.GetNullableInt32(dr["Kilometraje"]),
                            Convert.ToString(dr["Comentarios"]),
                            Convert.ToDecimal(dr["CostoRefacciones"]),
                            Convert.ToDecimal(dr["CostoManoObra"]),
                            Convert.ToBoolean(dr["CargoAConductor"]),
                            Convert.ToString(dr["CB"]),
                            Convert.ToBoolean(dr["CB_Activo"]),
                            Convert.ToInt32(dr["Estacion_ID"])
                        );
            } // End Read

            public static bool Read(
                out OrdenesTrabajos ordenestrabajos,
                int top,
                string filter,
                string sort,
                params KeyValuePair<string, object>[] args)
            {
                DataTable dt = DB.Read("OrdenesTrabajos", top, filter, sort, args);
                if (dt.Rows.Count == 0)
                {
                    ordenestrabajos = null;
                    return false;
                }
                DataRow dr = dt.Rows[0];
                ordenestrabajos = new OrdenesTrabajos(
                    Convert.ToInt32(dr["OrdenTrabajo_ID"]),
                            Convert.ToInt32(dr["Empresa_ID"]),
                            Convert.ToInt32(dr["TipoMantenimiento_ID"]),
                            Convert.ToInt32(dr["ClienteFacturar_ID"]),
                            Convert.ToInt32(dr["Unidad_ID"]),
                            Convert.ToInt32(dr["EstatusOrdenTrabajo_ID"]),
                            DB.GetNullableInt32(dr["Caja_ID"]),
                            Convert.ToString(dr["Usuario_ID"]),
                            DB.GetNullableInt32(dr["Factura_ID"]),
                            Convert.ToString(dr["UsuarioFacturacion_ID"]),
                            Convert.ToString(dr["CodigoBarras"]),
                            Convert.ToDecimal(dr["Subtotal"]),
                            Convert.ToDecimal(dr["IVA"]),
                            Convert.ToDecimal(dr["Total"]),
                            Convert.ToDateTime(dr["FechaAlta"]),
                            DB.GetNullableDateTime(dr["FechaTerminacion"]),
                            DB.GetNullableDateTime(dr["FechaPago"]),
                            Convert.ToInt32(dr["NumeroEconomico"]),
                            DB.GetNullableDateTime(dr["FechaInicioReparacion"]),
                            Convert.ToDecimal(dr["ManoObra"]),
                            Convert.ToDecimal(dr["IVAManoObra"]),
                            Convert.ToDecimal(dr["Refacciones"]),
                            Convert.ToDecimal(dr["IVARefacciones"]),
                            DB.GetNullableDateTime(dr["FechaFacturacion"]),
                            DB.GetNullableInt32(dr["Kilometraje"]),
                            Convert.ToString(dr["Comentarios"]),
                            Convert.ToDecimal(dr["CostoRefacciones"]),
                            Convert.ToDecimal(dr["CostoManoObra"]),
                            Convert.ToBoolean(dr["CargoAConductor"]),
                            Convert.ToString(dr["CB"]),
                            Convert.ToBoolean(dr["CB_Activo"]),
                            Convert.ToInt32(dr["Estacion_ID"])
                        );
                return true;
            } // End Read

            public static DataTable ReadDataTable()
            {
                return DB.Select("OrdenesTrabajos");
            } // End Read

            public static DataTable ReadDataTable(int ordentrabajo_id)
            {
                Hashtable w_params = new Hashtable();
                w_params.Add("OrdenTrabajo_ID", ordentrabajo_id);
                return DB.Select("OrdenesTrabajos", w_params);
            } // End Read

            public int Update()
            {
                Hashtable m_params = new Hashtable();
                Hashtable w_params = new Hashtable();
                w_params.Add("OrdenTrabajo_ID", this.OrdenTrabajo_ID);
                m_params.Add("Empresa_ID", this.Empresa_ID);
                m_params.Add("TipoMantenimiento_ID", this.TipoMantenimiento_ID);
                m_params.Add("ClienteFacturar_ID", this.ClienteFacturar_ID);
                m_params.Add("Unidad_ID", this.Unidad_ID);
                m_params.Add("EstatusOrdenTrabajo_ID", this.EstatusOrdenTrabajo_ID);
                if (!DB.IsNullOrEmpty(this.Caja_ID)) m_params.Add("Caja_ID", this.Caja_ID);
                m_params.Add("Usuario_ID", this.Usuario_ID);
                if (!DB.IsNullOrEmpty(this.Factura_ID)) m_params.Add("Factura_ID", this.Factura_ID);
                if (!DB.IsNullOrEmpty(this.UsuarioFacturacion_ID)) m_params.Add("UsuarioFacturacion_ID", this.UsuarioFacturacion_ID);
                m_params.Add("CodigoBarras", this.CodigoBarras);
                m_params.Add("Subtotal", this.Subtotal);
                m_params.Add("IVA", this.IVA);
                m_params.Add("Total", this.Total);
                m_params.Add("FechaAlta", this.FechaAlta);
                if (!DB.IsNullOrEmpty(this.FechaTerminacion)) m_params.Add("FechaTerminacion", this.FechaTerminacion);
                if (!DB.IsNullOrEmpty(this.FechaPago)) m_params.Add("FechaPago", this.FechaPago);
                m_params.Add("NumeroEconomico", this.NumeroEconomico);
                if (!DB.IsNullOrEmpty(this.FechaInicioReparacion)) m_params.Add("FechaInicioReparacion", this.FechaInicioReparacion);
                m_params.Add("ManoObra", this.ManoObra);
                m_params.Add("IVAManoObra", this.IVAManoObra);
                m_params.Add("Refacciones", this.Refacciones);
                m_params.Add("IVARefacciones", this.IVARefacciones);
                if (!DB.IsNullOrEmpty(this.FechaFacturacion)) m_params.Add("FechaFacturacion", this.FechaFacturacion);
                if (!DB.IsNullOrEmpty(this.Kilometraje)) m_params.Add("Kilometraje", this.Kilometraje);
                if (!DB.IsNullOrEmpty(this.Comentarios)) m_params.Add("Comentarios", this.Comentarios);
                m_params.Add("CostoRefacciones", this.CostoRefacciones);
                m_params.Add("CostoManoObra", this.CostoManoObra);
                m_params.Add("CargoAConductor", this.CargoAConductor);
                m_params.Add("CB", this.CB);
                m_params.Add("CB_Activo", this.CB_Activo);
                m_params.Add("Estacion_ID", this.Estacion_ID);

                return DB.UpdateRow("OrdenesTrabajos", m_params, w_params);
            } // End Update

            public int Delete()
            {
                Hashtable w_params = new Hashtable();
                w_params.Add("OrdenTrabajo_ID", this.OrdenTrabajo_ID);

                return DB.DeleteRow("OrdenesTrabajos", w_params);
            } // End Delete


            #endregion
        } //End Class OrdenesTrabajos


        public class PermisosUsuarios
        {

            public PermisosUsuarios()
            {
            }

            public PermisosUsuarios(string usuario_id, int opcion_id, bool espermitido)
            {
                this.Usuario_ID = usuario_id;
                this.Opcion_ID = opcion_id;
                this.EsPermitido = espermitido;
            }

            private string _Usuario_ID;
            public string Usuario_ID
            {
                get { return _Usuario_ID; }
                set { _Usuario_ID = value; }
            }

            private int _Opcion_ID;
            public int Opcion_ID
            {
                get { return _Opcion_ID; }
                set { _Opcion_ID = value; }
            }

            private bool _EsPermitido;
            public bool EsPermitido
            {
                get { return _EsPermitido; }
                set { _EsPermitido = value; }
            }

            public int Create()
            {
                Hashtable m_params = new Hashtable();
                m_params.Add("Usuario_ID", this.Usuario_ID);
                m_params.Add("Opcion_ID", this.Opcion_ID);
                m_params.Add("EsPermitido", this.EsPermitido);

                return DB.InsertRow("PermisosUsuarios", m_params);
            } // End Create

            public static List<PermisosUsuarios> Read()
            {
                List<PermisosUsuarios> list = new List<PermisosUsuarios>();
                DataTable dt = DB.Select("PermisosUsuarios");
                foreach (DataRow dr in dt.Rows)
                {
                    list.Add(new PermisosUsuarios(Convert.ToString(dr["Usuario_ID"]), Convert.ToInt32(dr["Opcion_ID"]), Convert.ToBoolean(dr["EsPermitido"])));
                }

                return list;
            } // End Read

            public static List<PermisosUsuarios> Read(string usuario_id, int opcion_id)
            {
                List<PermisosUsuarios> list = new List<PermisosUsuarios>();
                Hashtable w_params = new Hashtable();
                w_params.Add("Usuario_ID", usuario_id);
                w_params.Add("Opcion_ID", opcion_id);
                DataTable dt = DB.Select("PermisosUsuarios", w_params);
                foreach (DataRow dr in dt.Rows)
                {
                    list.Add(new PermisosUsuarios(Convert.ToString(dr["Usuario_ID"]), Convert.ToInt32(dr["Opcion_ID"]), Convert.ToBoolean(dr["EsPermitido"])));
                }

                return list;
            } // End Read

            public int Update()
            {
                Hashtable m_params = new Hashtable();
                Hashtable w_params = new Hashtable();
                m_params.Add("Usuario_ID", this.Usuario_ID);
                w_params.Add("Opcion_ID", this.Opcion_ID);
                m_params.Add("EsPermitido", this.EsPermitido);

                return DB.UpdateRow("PermisosUsuarios", m_params, w_params);
            } // End Update

            public int Delete()
            {
                Hashtable w_params = new Hashtable();
                w_params.Add("Usuario_ID", this.Usuario_ID);
                w_params.Add("Opcion_ID", this.Opcion_ID);

                return DB.DeleteRow("PermisosUsuarios", w_params);
            }

        } //End Class PermisosUsuarios

        public class PlanesDeRenta
        {

            public PlanesDeRenta()
            {
            }

            public PlanesDeRenta(int planderenta_id, int modelounidad_id, string usuario_id, int diasdecobro_id, string descripcion, decimal rentabase, decimal? fondoresidual, DateTime fecha, bool activo, int estacion_id, int? referencia_id)
            {
                this.PlanDeRenta_ID = planderenta_id;
                this.ModeloUnidad_ID = modelounidad_id;
                this.Usuario_ID = usuario_id;
                this.DiasDeCobro_ID = diasdecobro_id;
                this.Descripcion = descripcion;
                this.RentaBase = rentabase;
                this.FondoResidual = fondoresidual;
                this.Fecha = fecha;
                this.Activo = activo;
                this.Estacion_ID = estacion_id;
                this.Referencia_ID = referencia_id;
            }

            private int _PlanDeRenta_ID;
            public int PlanDeRenta_ID
            {
                get { return _PlanDeRenta_ID; }
                set { _PlanDeRenta_ID = value; }
            }

            private int _ModeloUnidad_ID;
            public int ModeloUnidad_ID
            {
                get { return _ModeloUnidad_ID; }
                set { _ModeloUnidad_ID = value; }
            }

            private string _Usuario_ID;
            public string Usuario_ID
            {
                get { return _Usuario_ID; }
                set { _Usuario_ID = value; }
            }

            private int _DiasDeCobro_ID;
            public int DiasDeCobro_ID
            {
                get { return _DiasDeCobro_ID; }
                set { _DiasDeCobro_ID = value; }
            }

            private string _Descripcion;
            public string Descripcion
            {
                get { return _Descripcion; }
                set { _Descripcion = value; }
            }

            private decimal _RentaBase;
            public decimal RentaBase
            {
                get { return _RentaBase; }
                set { _RentaBase = value; }
            }

            private decimal? _FondoResidual;
            public decimal? FondoResidual
            {
                get { return _FondoResidual; }
                set { _FondoResidual = value; }
            }

            private DateTime _Fecha;
            public DateTime Fecha
            {
                get { return _Fecha; }
                set { _Fecha = value; }
            }

            private bool _Activo;
            public bool Activo
            {
                get { return _Activo; }
                set { _Activo = value; }
            }

            private int _Estacion_ID;
            public int Estacion_ID
            {
                get { return _Estacion_ID; }
                set { _Estacion_ID = value; }
            }

            private int? _Referencia_ID;
            public int? Referencia_ID
            {
                get { return _Referencia_ID; }
                set { _Referencia_ID = value; }
            }

            public int Create()
            {
                Hashtable m_params = new Hashtable();
                m_params.Add("ModeloUnidad_ID", this.ModeloUnidad_ID);
                m_params.Add("Usuario_ID", this.Usuario_ID);
                m_params.Add("DiasDeCobro_ID", this.DiasDeCobro_ID);
                m_params.Add("Descripcion", this.Descripcion);
                m_params.Add("RentaBase", this.RentaBase);
                if (!AppHelper.IsNullOrEmpty(this.FondoResidual)) m_params.Add("FondoResidual", this.FondoResidual);
                m_params.Add("Fecha", this.Fecha);
                m_params.Add("Activo", this.Activo);
                m_params.Add("Estacion_ID", this.Estacion_ID);
                if (!AppHelper.IsNullOrEmpty(this.Referencia_ID)) m_params.Add("Referencia_ID", this.Referencia_ID);

                return DB.InsertRow("PlanesDeRenta", m_params);
            } // End Create

            public int Create(bool IsIdentityInsert)
            {
                if (!IsIdentityInsert) return Create();
                Hashtable m_params = new Hashtable();
                m_params.Add("PlanDeRenta_ID", this.PlanDeRenta_ID);
                m_params.Add("ModeloUnidad_ID", this.ModeloUnidad_ID);
                m_params.Add("Usuario_ID", this.Usuario_ID);
                m_params.Add("DiasDeCobro_ID", this.DiasDeCobro_ID);
                m_params.Add("Descripcion", this.Descripcion);
                m_params.Add("RentaBase", this.RentaBase);
                if (!AppHelper.IsNullOrEmpty(this.FondoResidual)) m_params.Add("FondoResidual", this.FondoResidual);
                m_params.Add("Fecha", this.Fecha);
                m_params.Add("Activo", this.Activo);
                m_params.Add("Estacion_ID", this.Estacion_ID);
                if (!AppHelper.IsNullOrEmpty(this.Referencia_ID)) m_params.Add("Referencia_ID", this.Referencia_ID);

                return DB.IdentityInsertRow("PlanesDeRenta", m_params);
            } // End Create

            public static List<PlanesDeRenta> Read()
            {
                List<PlanesDeRenta> list = new List<PlanesDeRenta>();
                DataTable dt = DB.Select("PlanesDeRenta");
                foreach (DataRow dr in dt.Rows)
                {
                    list.Add(new PlanesDeRenta(Convert.ToInt32(dr["PlanDeRenta_ID"]), Convert.ToInt32(dr["ModeloUnidad_ID"]), Convert.ToString(dr["Usuario_ID"]), Convert.ToInt32(dr["DiasDeCobro_ID"]), Convert.ToString(dr["Descripcion"]), Convert.ToDecimal(dr["RentaBase"]), DB.GetNullableDecimal(dr["FondoResidual"]), Convert.ToDateTime(dr["Fecha"]), Convert.ToBoolean(dr["Activo"]), Convert.ToInt32(dr["Estacion_ID"]), DB.GetNullableInt32(dr["Referencia_ID"])));
                }

                return list;
            } // End Read

            public static PlanesDeRenta Read(int planderenta_id)
            {
                Hashtable w_params = new Hashtable();
                w_params.Add("PlanDeRenta_ID", planderenta_id);
                DataTable dt = DB.Select("PlanesDeRenta", w_params);
                if (dt.Rows.Count == 0)
                {
                    throw new Exception("No existe PlanesDeRenta con los criterios de búsqueda especificados.");
                }
                DataRow dr = dt.Rows[0];
                return new PlanesDeRenta(Convert.ToInt32(dr["PlanDeRenta_ID"]), Convert.ToInt32(dr["ModeloUnidad_ID"]), Convert.ToString(dr["Usuario_ID"]), Convert.ToInt32(dr["DiasDeCobro_ID"]), Convert.ToString(dr["Descripcion"]), Convert.ToDecimal(dr["RentaBase"]), DB.GetNullableDecimal(dr["FondoResidual"]), Convert.ToDateTime(dr["Fecha"]), Convert.ToBoolean(dr["Activo"]), Convert.ToInt32(dr["Estacion_ID"]), DB.GetNullableInt32(dr["Referencia_ID"]));
            } // End Read

            public static PlanesDeRenta Read(params KeyValuePair<string, object>[] args)
            {
                DataTable dt = DB.Read("PlanesDeRenta", args);
                if (dt.Rows.Count == 0)
                {
                    return null;
                }
                DataRow dr = dt.Rows[0];
                return new PlanesDeRenta(Convert.ToInt32(dr["PlanDeRenta_ID"]), Convert.ToInt32(dr["ModeloUnidad_ID"]), Convert.ToString(dr["Usuario_ID"]), Convert.ToInt32(dr["DiasDeCobro_ID"]), Convert.ToString(dr["Descripcion"]), Convert.ToDecimal(dr["RentaBase"]), DB.GetNullableDecimal(dr["FondoResidual"]), Convert.ToDateTime(dr["Fecha"]), Convert.ToBoolean(dr["Activo"]), Convert.ToInt32(dr["Estacion_ID"]), DB.GetNullableInt32(dr["Referencia_ID"]));
            } // End Read

            public static bool Read(out PlanesDeRenta planesderenta, int top, string filter, string sort, params KeyValuePair<string, object>[] args)
            {
                DataTable dt = DB.Read("PlanesDeRenta", top, filter, sort, args);
                if (dt.Rows.Count == 0)
                {
                    planesderenta = null;
                    return false;
                }
                DataRow dr = dt.Rows[0];
                planesderenta = new PlanesDeRenta(
                    Convert.ToInt32(dr["PlanDeRenta_ID"]), 
                    Convert.ToInt32(dr["ModeloUnidad_ID"]),
                    Convert.ToString(dr["Usuario_ID"]), 
                    Convert.ToInt32(dr["DiasDeCobro_ID"]),
                    Convert.ToString(dr["Descripcion"]), 
                    Convert.ToDecimal(dr["RentaBase"]),
                    DB.GetNullableDecimal(dr["FondoResidual"]),
                    Convert.ToDateTime(dr["Fecha"]), 
                    Convert.ToBoolean(dr["Activo"]), 
                    Convert.ToInt32(dr["Estacion_ID"]),
                    DB.GetNullableInt32(dr["Referencia_ID"]));
                return true;
            } // End Read

            public static DataTable ReadDataTable()
            {
                return DB.Select("PlanesDeRenta");
            } // End Read

            public static DataTable ReadDataTable(int planderenta_id)
            {
                Hashtable w_params = new Hashtable();
                w_params.Add("PlanDeRenta_ID", planderenta_id);
                return DB.Select("PlanesDeRenta", w_params);
            } // End Read

            public int Update()
            {
                Hashtable m_params = new Hashtable();
                Hashtable w_params = new Hashtable();
                w_params.Add("PlanDeRenta_ID", this.PlanDeRenta_ID);
                m_params.Add("ModeloUnidad_ID", this.ModeloUnidad_ID);
                m_params.Add("Usuario_ID", this.Usuario_ID);
                m_params.Add("DiasDeCobro_ID", this.DiasDeCobro_ID);
                m_params.Add("Descripcion", this.Descripcion);
                m_params.Add("RentaBase", this.RentaBase);
                if (!AppHelper.IsNullOrEmpty(this.FondoResidual)) m_params.Add("FondoResidual", this.FondoResidual);
                m_params.Add("Fecha", this.Fecha);
                m_params.Add("Activo", this.Activo);
                m_params.Add("Estacion_ID", this.Estacion_ID);
                if (!AppHelper.IsNullOrEmpty(this.Referencia_ID)) m_params.Add("Referencia_ID", this.Referencia_ID);

                return DB.UpdateRow("PlanesDeRenta", m_params, w_params);
            } // End Update

            public int Delete()
            {
                Hashtable w_params = new Hashtable();
                w_params.Add("PlanDeRenta_ID", this.PlanDeRenta_ID);

                return DB.DeleteRow("PlanesDeRenta", w_params);
            } // End Delete

        } //End Class PlanesDeRenta

        public class PlanillasFiscales
	    {

		    public PlanillasFiscales()
		    {
		    }

		    public PlanillasFiscales(int estacion_id, int estatusplanillafiscal_id, int? ticket_id, string serie, int folio, decimal denominacion, decimal precio, DateTime fecha)
		    {
			    this.Estacion_ID = estacion_id;
			    this.EstatusPlanillaFiscal_ID = estatusplanillafiscal_id;
			    this.Ticket_ID = ticket_id;
			    this.Serie = serie;
			    this.Folio = folio;
			    this.Denominacion = denominacion;
			    this.Precio = precio;
			    this.Fecha = fecha;
		    }

		    private int _Estacion_ID;
		    public int Estacion_ID
		    {
			    get { return _Estacion_ID; }
			    set { _Estacion_ID = value; }
		    }

		    private int _EstatusPlanillaFiscal_ID;
		    public int EstatusPlanillaFiscal_ID
		    {
			    get { return _EstatusPlanillaFiscal_ID; }
			    set { _EstatusPlanillaFiscal_ID = value; }
		    }

		    private int? _Ticket_ID;
		    public int? Ticket_ID
		    {
			    get { return _Ticket_ID; }
			    set { _Ticket_ID = value; }
		    }

		    private string _Serie;
		    public string Serie
		    {
			    get { return _Serie; }
			    set { _Serie = value; }
		    }

		    private int _Folio;
		    public int Folio
		    {
			    get { return _Folio; }
			    set { _Folio = value; }
		    }

		    private decimal _Denominacion;
		    public decimal Denominacion
		    {
			    get { return _Denominacion; }
			    set { _Denominacion = value; }
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

		    public int Create()
		    {
			    Hashtable m_params = new Hashtable();
			    m_params.Add("Estacion_ID", this.Estacion_ID);
			    m_params.Add("EstatusPlanillaFiscal_ID", this.EstatusPlanillaFiscal_ID);
			    if (!AppHelper.IsNullOrEmpty(this.Ticket_ID)) m_params.Add("Ticket_ID", this.Ticket_ID);
			    m_params.Add("Serie", this.Serie);
			    m_params.Add("Folio", this.Folio);
			    m_params.Add("Denominacion", this.Denominacion);
			    m_params.Add("Precio", this.Precio);
			    m_params.Add("Fecha", this.Fecha);

			    return DB.InsertRow("PlanillasFiscales", m_params);
		    } // End Create

		    public static List<PlanillasFiscales> Read()
		    {
			    List<PlanillasFiscales> list = new List<PlanillasFiscales>();
			    DataTable dt = DB.Select("PlanillasFiscales");
			    foreach (DataRow dr in dt.Rows)
			    {
				    list.Add(new PlanillasFiscales(Convert.ToInt32(dr["Estacion_ID"]), Convert.ToInt32(dr["EstatusPlanillaFiscal_ID"]), DB.GetNullableInt32(dr["Ticket_ID"]), Convert.ToString(dr["Serie"]), Convert.ToInt32(dr["Folio"]), Convert.ToDecimal(dr["Denominacion"]), Convert.ToDecimal(dr["Precio"]), Convert.ToDateTime(dr["Fecha"])));
			    }

			    return list;
		    } // End Read

		    public static PlanillasFiscales Read(int estacion_id, string serie, int folio)
		    {
			    Hashtable w_params = new Hashtable();
			    w_params.Add("Estacion_ID", estacion_id);
			    w_params.Add("Serie", serie);
			    w_params.Add("Folio", folio);
			    DataTable dt = DB.Select("PlanillasFiscales", w_params);
			    if ( dt.Rows.Count == 0 )
			    {
                    return null;
			    }
			    DataRow dr = dt.Rows[0];
			    return new PlanillasFiscales(Convert.ToInt32(dr["Estacion_ID"]), Convert.ToInt32(dr["EstatusPlanillaFiscal_ID"]), DB.GetNullableInt32(dr["Ticket_ID"]), Convert.ToString(dr["Serie"]), Convert.ToInt32(dr["Folio"]), Convert.ToDecimal(dr["Denominacion"]), Convert.ToDecimal(dr["Precio"]), Convert.ToDateTime(dr["Fecha"]));
		    } // End Read

		    public static PlanillasFiscales Read(params KeyValuePair<string,object>[] args)		{
			    DataTable dt = DB.Read("PlanillasFiscales", args);
			    if ( dt.Rows.Count == 0 )
			    {
				    return null;
			    }
			    DataRow dr = dt.Rows[0];
			    return new PlanillasFiscales(Convert.ToInt32(dr["Estacion_ID"]), Convert.ToInt32(dr["EstatusPlanillaFiscal_ID"]), DB.GetNullableInt32(dr["Ticket_ID"]), Convert.ToString(dr["Serie"]), Convert.ToInt32(dr["Folio"]), Convert.ToDecimal(dr["Denominacion"]), Convert.ToDecimal(dr["Precio"]), Convert.ToDateTime(dr["Fecha"]));
		    } // End Read

		    public static bool Read(out PlanillasFiscales planillasfiscales, int top, string filter, string sort, params KeyValuePair<string, object>[] args)		{
			    DataTable dt = DB.Read("PlanillasFiscales", top, filter, sort, args);
			    if ( dt.Rows.Count == 0 )
			    {
				    planillasfiscales = null; 
				    return false;
			    }
			    DataRow dr = dt.Rows[0];
			    planillasfiscales = new PlanillasFiscales(Convert.ToInt32(dr["Estacion_ID"]), Convert.ToInt32(dr["EstatusPlanillaFiscal_ID"]), DB.GetNullableInt32(dr["Ticket_ID"]), Convert.ToString(dr["Serie"]), Convert.ToInt32(dr["Folio"]), Convert.ToDecimal(dr["Denominacion"]), Convert.ToDecimal(dr["Precio"]), Convert.ToDateTime(dr["Fecha"]));
			    return true;
		    } // End Read

		    public int Update()
		    {
			    Hashtable m_params = new Hashtable();
			    Hashtable w_params = new Hashtable();
			    w_params.Add("Estacion_ID", this.Estacion_ID);
			    m_params.Add("EstatusPlanillaFiscal_ID", this.EstatusPlanillaFiscal_ID);
			    if (!AppHelper.IsNullOrEmpty(this.Ticket_ID)) m_params.Add("Ticket_ID", this.Ticket_ID);
			    w_params.Add("Serie", this.Serie);
			    w_params.Add("Folio", this.Folio);
			    m_params.Add("Denominacion", this.Denominacion);
			    m_params.Add("Precio", this.Precio);
			    m_params.Add("Fecha", this.Fecha);

			    return DB.UpdateRow("PlanillasFiscales", m_params, w_params);
		    } // End Update

		    public int Delete()
		    {
			    Hashtable w_params = new Hashtable();
			    w_params.Add("Estacion_ID", this.Estacion_ID);
			    w_params.Add("Serie", this.Serie);
			    w_params.Add("Folio", this.Folio);

			    return DB.DeleteRow("PlanillasFiscales", w_params);
		    } // End Delete

	    } //End Class PlanillasFiscales

        public class Refacciones
        {

            #region Constructors

            public Refacciones()
            {
            }

            public Refacciones(
                int refaccion_id,
                int tiporefaccion_id,
                int modelo_id,
                int marcarefaccion_id,
                int? anio,
                string numeroserial,
                string descripcion)
            {
                this.Refaccion_ID = refaccion_id;
                this.TipoRefaccion_ID = tiporefaccion_id;
                this.Modelo_ID = modelo_id;
                this.MarcaRefaccion_ID = marcarefaccion_id;
                this.Anio = anio;
                this.NumeroSerial = numeroserial;
                this.Descripcion = descripcion;
            }

            #endregion

            #region Properties

            private int _Refaccion_ID;
            public int Refaccion_ID
            {
                get { return _Refaccion_ID; }
                set { _Refaccion_ID = value; }
            }

            private int _TipoRefaccion_ID;
            public int TipoRefaccion_ID
            {
                get { return _TipoRefaccion_ID; }
                set { _TipoRefaccion_ID = value; }
            }

            private int _Modelo_ID;
            public int Modelo_ID
            {
                get { return _Modelo_ID; }
                set { _Modelo_ID = value; }
            }

            private int _MarcaRefaccion_ID;
            public int MarcaRefaccion_ID
            {
                get { return _MarcaRefaccion_ID; }
                set { _MarcaRefaccion_ID = value; }
            }

            private int? _Anio;
            public int? Anio
            {
                get { return _Anio; }
                set { _Anio = value; }
            }

            private string _NumeroSerial;
            public string NumeroSerial
            {
                get { return _NumeroSerial; }
                set { _NumeroSerial = value; }
            }

            private string _Descripcion;
            public string Descripcion
            {
                get { return _Descripcion; }
                set { _Descripcion = value; }
            }

            #endregion

            #region Methods
            public void Validate()
            {
                if (this.Refaccion_ID == null) throw new Exception("Refaccion_ID no puede ser nulo.");

                if (this.TipoRefaccion_ID == null) throw new Exception("TipoRefaccion_ID no puede ser nulo.");

                if (this.Modelo_ID == null) throw new Exception("Modelo_ID no puede ser nulo.");

                if (this.MarcaRefaccion_ID == null) throw new Exception("MarcaRefaccion_ID no puede ser nulo.");

                if (this.NumeroSerial.Length > 50)
                {
                    throw new Exception("NumeroSerial debe tener máximo 50 carateres.");
                }

                if (this.Descripcion == null) throw new Exception("Descripcion no puede ser nulo.");

                if (this.Descripcion.Length > 200)
                {
                    throw new Exception("Descripcion debe tener máximo 200 carateres.");
                }


            } // End Validate

            public int Create()
            {
                Hashtable m_params = new Hashtable();
                m_params.Add("TipoRefaccion_ID", this.TipoRefaccion_ID);
                m_params.Add("Modelo_ID", this.Modelo_ID);
                m_params.Add("MarcaRefaccion_ID", this.MarcaRefaccion_ID);
                if (!DB.IsNullOrEmpty(this.Anio)) m_params.Add("Anio", this.Anio);
                if (!DB.IsNullOrEmpty(this.NumeroSerial)) m_params.Add("NumeroSerial", this.NumeroSerial);
                m_params.Add("Descripcion", this.Descripcion);

                return DB.InsertRow("Refacciones", m_params);
            } // End Create

            public int Create(bool IsIdentityInsert)
            {
                if (!IsIdentityInsert) return Create();
                Hashtable m_params = new Hashtable();
                m_params.Add("Refaccion_ID", this.Refaccion_ID);
                m_params.Add("TipoRefaccion_ID", this.TipoRefaccion_ID);
                m_params.Add("Modelo_ID", this.Modelo_ID);
                m_params.Add("MarcaRefaccion_ID", this.MarcaRefaccion_ID);
                if (!DB.IsNullOrEmpty(this.Anio)) m_params.Add("Anio", this.Anio);
                if (!DB.IsNullOrEmpty(this.NumeroSerial)) m_params.Add("NumeroSerial", this.NumeroSerial);
                m_params.Add("Descripcion", this.Descripcion);

                return DB.IdentityInsertRow("Refacciones", m_params);
            } // End Create

            public static List<Refacciones> Read()
            {
                List<Refacciones> list = new List<Refacciones>();
                DataTable dt = DB.Select("Refacciones");
                foreach (DataRow dr in dt.Rows)
                {
                    list.Add(
                        new Refacciones(
                            Convert.ToInt32(dr["Refaccion_ID"]),
                            Convert.ToInt32(dr["TipoRefaccion_ID"]),
                            Convert.ToInt32(dr["Modelo_ID"]),
                            Convert.ToInt32(dr["MarcaRefaccion_ID"]),
                            DB.GetNullableInt32(dr["Anio"]),
                            Convert.ToString(dr["NumeroSerial"]),
                            Convert.ToString(dr["Descripcion"])
                        )
                    );
                }

                return list;
            } // End Read

            public static Refacciones Read(int refaccion_id)
            {
                Hashtable w_params = new Hashtable();
                w_params.Add("Refaccion_ID", refaccion_id);
                DataTable dt = DB.Select("Refacciones", w_params);
                if (dt.Rows.Count == 0)
                {
                    throw new Exception("No existe Refacciones con los criterios de búsqueda especificados.");
                }
                DataRow dr = dt.Rows[0];
                return new Refacciones(
                    Convert.ToInt32(dr["Refaccion_ID"]),
                            Convert.ToInt32(dr["TipoRefaccion_ID"]),
                            Convert.ToInt32(dr["Modelo_ID"]),
                            Convert.ToInt32(dr["MarcaRefaccion_ID"]),
                            DB.GetNullableInt32(dr["Anio"]),
                            Convert.ToString(dr["NumeroSerial"]),
                            Convert.ToString(dr["Descripcion"])
                        );
            } // End Read

            public static Refacciones Read(params KeyValuePair<string, object>[] args)
            {
                DataTable dt = DB.Read("Refacciones", args);
                if (dt.Rows.Count == 0)
                {
                    return null;
                }
                DataRow dr = dt.Rows[0];
                return new Refacciones(
                    Convert.ToInt32(dr["Refaccion_ID"]),
                            Convert.ToInt32(dr["TipoRefaccion_ID"]),
                            Convert.ToInt32(dr["Modelo_ID"]),
                            Convert.ToInt32(dr["MarcaRefaccion_ID"]),
                            DB.GetNullableInt32(dr["Anio"]),
                            Convert.ToString(dr["NumeroSerial"]),
                            Convert.ToString(dr["Descripcion"])
                        );
            } // End Read

            public static bool Read(
                out Refacciones refacciones,
                int top,
                string filter,
                string sort,
                params KeyValuePair<string, object>[] args)
            {
                DataTable dt = DB.Read("Refacciones", top, filter, sort, args);
                if (dt.Rows.Count == 0)
                {
                    refacciones = null;
                    return false;
                }
                DataRow dr = dt.Rows[0];
                refacciones = new Refacciones(
                    Convert.ToInt32(dr["Refaccion_ID"]),
                            Convert.ToInt32(dr["TipoRefaccion_ID"]),
                            Convert.ToInt32(dr["Modelo_ID"]),
                            Convert.ToInt32(dr["MarcaRefaccion_ID"]),
                            DB.GetNullableInt32(dr["Anio"]),
                            Convert.ToString(dr["NumeroSerial"]),
                            Convert.ToString(dr["Descripcion"])
                        );
                return true;
            } // End Read

            public static DataTable ReadDataTable()
            {
                return DB.Select("Refacciones");
            } // End Read

            public static DataTable ReadDataTable(int refaccion_id)
            {
                Hashtable w_params = new Hashtable();
                w_params.Add("Refaccion_ID", refaccion_id);
                return DB.Select("Refacciones", w_params);
            } // End Read

            public int Update()
            {
                Hashtable m_params = new Hashtable();
                Hashtable w_params = new Hashtable();
                w_params.Add("Refaccion_ID", this.Refaccion_ID);
                m_params.Add("TipoRefaccion_ID", this.TipoRefaccion_ID);
                m_params.Add("Modelo_ID", this.Modelo_ID);
                m_params.Add("MarcaRefaccion_ID", this.MarcaRefaccion_ID);
                if (!DB.IsNullOrEmpty(this.Anio)) m_params.Add("Anio", this.Anio);
                if (!DB.IsNullOrEmpty(this.NumeroSerial)) m_params.Add("NumeroSerial", this.NumeroSerial);
                m_params.Add("Descripcion", this.Descripcion);

                return DB.UpdateRow("Refacciones", m_params, w_params);
            } // End Update

            public int Delete()
            {
                Hashtable w_params = new Hashtable();
                w_params.Add("Refaccion_ID", this.Refaccion_ID);

                return DB.DeleteRow("Refacciones", w_params);
            } // End Delete


            #endregion
        } //End Class Refacciones


        public class RegistroIndicadores
        {

            public RegistroIndicadores()
            {
            }

            public RegistroIndicadores(int empresa_id, int estacion_id, int anio, int mes, int semana, int dia, DateTime fecha, int indicador_id, object valor, object estrato)
            {
                this.Empresa_ID = empresa_id;
                this.Estacion_ID = estacion_id;
                this.Anio = anio;
                this.Mes = mes;
                this.Semana = semana;
                this.Dia = dia;
                this.Fecha = fecha;
                this.Indicador_ID = indicador_id;
                this.Valor = valor;
                this.Estrato = estrato;
            }

            private int _Empresa_ID;
            public int Empresa_ID
            {
                get { return _Empresa_ID; }
                set { _Empresa_ID = value; }
            }

            private int _Estacion_ID;
            public int Estacion_ID
            {
                get { return _Estacion_ID; }
                set { _Estacion_ID = value; }
            }

            private int _Anio;
            public int Anio
            {
                get { return _Anio; }
                set { _Anio = value; }
            }

            private int _Mes;
            public int Mes
            {
                get { return _Mes; }
                set { _Mes = value; }
            }

            private int _Semana;
            public int Semana
            {
                get { return _Semana; }
                set { _Semana = value; }
            }

            private int _Dia;
            public int Dia
            {
                get { return _Dia; }
                set { _Dia = value; }
            }

            private DateTime _Fecha;
            public DateTime Fecha
            {
                get { return _Fecha; }
                set { _Fecha = value; }
            }

            private int _Indicador_ID;
            public int Indicador_ID
            {
                get { return _Indicador_ID; }
                set { _Indicador_ID = value; }
            }

            private object _Valor;
            public object Valor
            {
                get { return _Valor; }
                set { _Valor = value; }
            }

            private object _Estrato;
            public object Estrato
            {
                get { return _Estrato; }
                set { _Estrato = value; }
            }

            public int Create()
            {
                Hashtable m_params = new Hashtable();
                m_params.Add("Empresa_ID", this.Empresa_ID);
                m_params.Add("Estacion_ID", this.Estacion_ID);
                m_params.Add("Anio", this.Anio);
                m_params.Add("Mes", this.Mes);
                m_params.Add("Semana", this.Semana);
                m_params.Add("Dia", this.Dia);
                m_params.Add("Fecha", this.Fecha);
                m_params.Add("Indicador_ID", this.Indicador_ID);
                m_params.Add("Valor", this.Valor);
                m_params.Add("Estrato", this.Estrato);

                return DB.InsertRow("RegistroIndicadores", m_params);
            } // End Create

            public static List<RegistroIndicadores> Read()
            {
                List<RegistroIndicadores> list = new List<RegistroIndicadores>();
                DataTable dt = DB.Select("RegistroIndicadores");
                foreach (DataRow dr in dt.Rows)
                {
                    list.Add(new RegistroIndicadores(Convert.ToInt32(dr["Empresa_ID"]), Convert.ToInt32(dr["Estacion_ID"]), Convert.ToInt32(dr["Anio"]), Convert.ToInt32(dr["Mes"]), Convert.ToInt32(dr["Semana"]), Convert.ToInt32(dr["Dia"]), Convert.ToDateTime(dr["Fecha"]), Convert.ToInt32(dr["Indicador_ID"]), (object)(dr["Valor"]), (object)(dr["Estrato"])));
                }

                return list;
            } // End Read

            public int Update()
            {
                Hashtable m_params = new Hashtable();
                Hashtable w_params = new Hashtable();
                m_params.Add("Empresa_ID", this.Empresa_ID);
                m_params.Add("Estacion_ID", this.Estacion_ID);
                m_params.Add("Anio", this.Anio);
                m_params.Add("Mes", this.Mes);
                m_params.Add("Semana", this.Semana);
                m_params.Add("Dia", this.Dia);
                m_params.Add("Fecha", this.Fecha);
                m_params.Add("Indicador_ID", this.Indicador_ID);
                m_params.Add("Valor", this.Valor);
                m_params.Add("Estrato", this.Estrato);

                return DB.UpdateRow("RegistroIndicadores", m_params, w_params);
            } // End Update

            public int Delete()
            {
                Hashtable w_params = new Hashtable();

                return DB.DeleteRow("RegistroIndicadores", w_params);
            }

        } //End Class RegistroIndicadores

        public class Servicios
        {

            public Servicios()
            {
            }

            public Servicios(string servicio_id, int mercado_id, int empresa_id, int? estacion_id, int? caja_id, 
                int? sesion_id, int? zona_id, int? claseservicio_id,
                int? tiposervicio_id, int? tiposervicioconductor_id, int moneda_id, int estatusservicio_id, 
                int? unidad_id, int? conductor_id, string usuario_id, int? cliente_id, int? ticket_id, 
                int? tipoventa_id, int? cuenta_id, int foliodiario, decimal precio, DateTime fecha, 
                DateTime? fechaservicio, DateTime? fechaexpiracion, DateTime? fechapago, decimal? productividad, 
                decimal? pagoconductor, decimal? pagocomisiones, string referencia_payback)
            {
                this.Servicio_ID = servicio_id;
                this.Mercado_ID = mercado_id;
                this.Empresa_ID = empresa_id;
                this.Estacion_ID = estacion_id;
                this.Caja_ID = caja_id;
                this.Sesion_ID = sesion_id;
                this.Zona_ID = zona_id;
                this.ClaseServicio_ID = claseservicio_id;
                this.TipoServicio_ID = tiposervicio_id;
                this.TipoServicioConductor_ID = tiposervicioconductor_id;
                this.Moneda_ID = moneda_id;
                this.EstatusServicio_ID = estatusservicio_id;
                this.Unidad_ID = unidad_id;
                this.Conductor_ID = conductor_id;
                this.Usuario_ID = usuario_id;
                this.Cliente_ID = cliente_id;
                this.Ticket_ID = ticket_id;
                this.TipoVenta_ID = tipoventa_id;
                this.Cuenta_ID = cuenta_id;
                this.FolioDiario = foliodiario;
                this.Precio = precio;
                this.Fecha = fecha;
                this.FechaServicio = fechaservicio;
                this.FechaExpiracion = fechaexpiracion;
                this.FechaPago = fechapago;
                this.Productividad = productividad;
                this.PagoConductor = pagoconductor;
                this.PagoComisiones = pagocomisiones;
			 this.Referencia_PayBack = referencia_payback;
            }

            private string _Servicio_ID;
            public string Servicio_ID
            {
                get { return _Servicio_ID; }
                set { _Servicio_ID = value; }
            }

            private int _Mercado_ID;
            public int Mercado_ID
            {
                get { return _Mercado_ID; }
                set { _Mercado_ID = value; }
            }

            private int _Empresa_ID;
            public int Empresa_ID
            {
                get { return _Empresa_ID; }
                set { _Empresa_ID = value; }
            }

            private int? _Estacion_ID;
            public int? Estacion_ID
            {
                get { return _Estacion_ID; }
                set { _Estacion_ID = value; }
            }

            private int? _Caja_ID;
            public int? Caja_ID
            {
                get { return _Caja_ID; }
                set { _Caja_ID = value; }
            }

            private int? _Sesion_ID;
            public int? Sesion_ID
            {
                get { return _Sesion_ID; }
                set { _Sesion_ID = value; }
            }

            private int? _Zona_ID;
            public int? Zona_ID
            {
                get { return _Zona_ID; }
                set { _Zona_ID = value; }
            }

            private int? _ClaseServicio_ID;
            public int? ClaseServicio_ID
            {
                get { return _ClaseServicio_ID; }
                set { _ClaseServicio_ID = value; }
            }

            private int? _TipoServicio_ID;
            public int? TipoServicio_ID
            {
                get { return _TipoServicio_ID; }
                set { _TipoServicio_ID = value; }
            }

            private int? _TipoServicioConductor_ID;
            public int? TipoServicioConductor_ID
            {
                get { return _TipoServicioConductor_ID; }
                set { _TipoServicioConductor_ID = value; }
            }

            private int _Moneda_ID;
            public int Moneda_ID
            {
                get { return _Moneda_ID; }
                set { _Moneda_ID = value; }
            }

            private int _EstatusServicio_ID;
            public int EstatusServicio_ID
            {
                get { return _EstatusServicio_ID; }
                set { _EstatusServicio_ID = value; }
            }

            private int? _Unidad_ID;
            public int? Unidad_ID
            {
                get { return _Unidad_ID; }
                set { _Unidad_ID = value; }
            }

            private int? _Conductor_ID;
            public int? Conductor_ID
            {
                get { return _Conductor_ID; }
                set { _Conductor_ID = value; }
            }

            private string _Usuario_ID;
            public string Usuario_ID
            {
                get { return _Usuario_ID; }
                set { _Usuario_ID = value; }
            }

            private int? _Cliente_ID;
            public int? Cliente_ID
            {
                get { return _Cliente_ID; }
                set { _Cliente_ID = value; }
            }

            private int? _Ticket_ID;
            public int? Ticket_ID
            {
                get { return _Ticket_ID; }
                set { _Ticket_ID = value; }
            }

            private int? _TipoVenta_ID;
            public int? TipoVenta_ID
            {
                get { return _TipoVenta_ID; }
                set { _TipoVenta_ID = value; }
            }

            private int? _Cuenta_ID;
            public int? Cuenta_ID
            {
                get { return _Cuenta_ID; }
                set { _Cuenta_ID = value; }
            }

            private int _FolioDiario;
            public int FolioDiario
            {
                get { return _FolioDiario; }
                set { _FolioDiario = value; }
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

            private DateTime? _FechaServicio;
            public DateTime? FechaServicio
            {
                get { return _FechaServicio; }
                set { _FechaServicio = value; }
            }

            private DateTime? _FechaExpiracion;
            public DateTime? FechaExpiracion
            {
                get { return _FechaExpiracion; }
                set { _FechaExpiracion = value; }
            }

            private DateTime? _FechaPago;
            public DateTime? FechaPago
            {
                get { return _FechaPago; }
                set { _FechaPago = value; }
            }

            private decimal? _Productividad;
            public decimal? Productividad
            {
                get { return _Productividad; }
                set { _Productividad = value; }
            }

            private decimal? _PagoConductor;
            public decimal? PagoConductor
            {
                get { return _PagoConductor; }
                set { _PagoConductor = value; }
            }

            private decimal? _PagoComisiones;
            public decimal? PagoComisiones
            {
                get { return _PagoComisiones; }
                set { _PagoComisiones = value; }
            }

		  private string _Referencia_PayBack;
		  public string Referencia_PayBack
		  {
			  get { return _Referencia_PayBack; }
			  set { _Referencia_PayBack = value; }
		  }

            public static string GenerarCodigoVenta()
            {
                string codigo = "";

                Random rand = new Random();

                codigo += rand.Next(100, 999).ToString();
                codigo += string.Format("{0:yyMMddHHmm}", DB.GetDate());
                codigo += Strings.Right("0000" + GetFolioDiario().ToString(), 4);

                return codigo;
            }

            public static int GetFolioDiario()
            {
                string sqlstr = "SELECT COUNT(Servicio_ID) + 1 FROM Servicios WHERE Fecha BETWEEN dbo.udf_DateValue(GETDATE()) AND dbo.udf_DateValue(DATEADD(DAY, 1, GETDATE()))";
                return Convert.ToInt32(DB.QueryScalar(sqlstr));
            }

            public int Create()
            {
                Hashtable m_params = new Hashtable();
                m_params.Add("Servicio_ID", this.Servicio_ID);
                m_params.Add("Mercado_ID", this.Mercado_ID);
                m_params.Add("Empresa_ID", this.Empresa_ID);
                if (!AppHelper.IsNullOrEmpty(this.Estacion_ID)) m_params.Add("Estacion_ID", this.Estacion_ID);
                if (!AppHelper.IsNullOrEmpty(this.Caja_ID)) m_params.Add("Caja_ID", this.Caja_ID);
                if (!AppHelper.IsNullOrEmpty(this.ClaseServicio_ID)) m_params.Add("Sesion_ID", this.Sesion_ID);
                if (!AppHelper.IsNullOrEmpty(this.Zona_ID)) m_params.Add("Zona_ID", this.Zona_ID);
                if (!AppHelper.IsNullOrEmpty(this.ClaseServicio_ID)) m_params.Add("ClaseServicio_ID", this.ClaseServicio_ID);
                if (!AppHelper.IsNullOrEmpty(this.TipoServicio_ID)) m_params.Add("TipoServicio_ID", this.TipoServicio_ID);
                if (!AppHelper.IsNullOrEmpty(this.TipoServicioConductor_ID)) m_params.Add("TipoServicioConductor_ID", this.TipoServicioConductor_ID);
                m_params.Add("Moneda_ID", this.Moneda_ID);
                m_params.Add("EstatusServicio_ID", this.EstatusServicio_ID);
                if (!AppHelper.IsNullOrEmpty(this.Unidad_ID)) m_params.Add("Unidad_ID", this.Unidad_ID);
                if (!AppHelper.IsNullOrEmpty(this.Conductor_ID)) m_params.Add("Conductor_ID", this.Conductor_ID);
                m_params.Add("Usuario_ID", this.Usuario_ID);
                if (!AppHelper.IsNullOrEmpty(this.Cliente_ID)) m_params.Add("Cliente_ID", this.Cliente_ID);
                if (!AppHelper.IsNullOrEmpty(this.Ticket_ID)) m_params.Add("Ticket_ID", this.Ticket_ID);
                if (!AppHelper.IsNullOrEmpty(this.TipoVenta_ID)) m_params.Add("TipoVenta_ID", this.TipoVenta_ID);
                m_params.Add("Cuenta_ID", this.Cuenta_ID);
                m_params.Add("FolioDiario", this.FolioDiario);
                m_params.Add("Precio", this.Precio);
                m_params.Add("Fecha", this.Fecha);
                if (!AppHelper.IsNullOrEmpty(this.FechaServicio)) m_params.Add("FechaServicio", this.FechaServicio);
                if (!AppHelper.IsNullOrEmpty(this.FechaExpiracion)) m_params.Add("FechaExpiracion", this.FechaExpiracion);
                if (!AppHelper.IsNullOrEmpty(this.FechaPago)) m_params.Add("FechaPago", this.FechaPago);
                if (!AppHelper.IsNullOrEmpty(this.Productividad)) m_params.Add("Productividad", this.Productividad);
                if (!AppHelper.IsNullOrEmpty(this.PagoConductor)) m_params.Add("PagoConductor", this.PagoConductor);
                if (!AppHelper.IsNullOrEmpty(this.PagoComisiones)) m_params.Add("PagoComisiones", this.PagoComisiones);
			 if (!AppHelper.IsNullOrEmpty(this.Referencia_PayBack)) m_params.Add("Referencia_PayBack", this.Referencia_PayBack);

                return DB.InsertRow("Servicios", m_params);
            } // End Create

            public static List<Servicios> Read()
            {
                List<Servicios> list = new List<Servicios>();
                DataTable dt = DB.Select("Servicios");
                foreach (DataRow dr in dt.Rows)
                {
                    list.Add(new Servicios(Convert.ToString(dr["Servicio_ID"]), Convert.ToInt32(dr["Mercado_ID"]), Convert.ToInt32(dr["Empresa_ID"]),
                                DB.GetNullableInt32(dr["Estacion_ID"]), DB.GetNullableInt32(dr["Caja_ID"]), DB.GetNullableInt32(dr["Sesion_ID"]), DB.GetNullableInt32(dr["Zona_ID"]),
                                    DB.GetNullableInt32(dr["ClaseServicio_ID"]), DB.GetNullableInt32(dr["TipoServicio_ID"]), DB.GetNullableInt32(dr["TipoServicioConductor_ID"]),
                                        Convert.ToInt32(dr["Moneda_ID"]), Convert.ToInt32(dr["EstatusServicio_ID"]), DB.GetNullableInt32(dr["Unidad_ID"]),
                                            DB.GetNullableInt32(dr["Conductor_ID"]), Convert.ToString(dr["Usuario_ID"]), DB.GetNullableInt32(dr["Cliente_ID"]),
                                                DB.GetNullableInt32(dr["Ticket_ID"]), DB.GetNullableInt32(dr["TipoVenta_ID"]), DB.GetNullableInt32(dr["Cuenta_ID"]),
                                                    Convert.ToInt32(dr["FolioDiario"]), Convert.ToDecimal(dr["Precio"]), Convert.ToDateTime(dr["Fecha"]),
                                                        DB.GetNullableDateTime(dr["FechaServicio"]), DB.GetNullableDateTime(dr["FechaExpiracion"]),
                                                            DB.GetNullableDateTime(dr["FechaPago"]), DB.GetNullableDecimal(dr["Productividad"]),
                                                                DB.GetNullableDecimal(dr["PagoConductor"]), DB.GetNullableDecimal(dr["PagoComisiones"]),
												    Convert.ToString(dr["Referencia_PayBack"])));
                }

                return list;
            } // End Read

            public static Servicios Read(string servicio_id)
            {
                Hashtable w_params = new Hashtable();
                w_params.Add("Servicio_ID", servicio_id);
                DataTable dt = DB.Select("Servicios", w_params);
                if (dt.Rows.Count == 0)
                {
                    throw new Exception("No existe Servicios con los criterios de búsqueda especificados.");
                }
                DataRow dr = dt.Rows[0];
                return new Servicios(Convert.ToString(dr["Servicio_ID"]), Convert.ToInt32(dr["Mercado_ID"]), Convert.ToInt32(dr["Empresa_ID"]),
                                DB.GetNullableInt32(dr["Estacion_ID"]), DB.GetNullableInt32(dr["Caja_ID"]), DB.GetNullableInt32(dr["Sesion_ID"]), DB.GetNullableInt32(dr["Zona_ID"]),
                                    DB.GetNullableInt32(dr["ClaseServicio_ID"]), DB.GetNullableInt32(dr["TipoServicio_ID"]), DB.GetNullableInt32(dr["TipoServicioConductor_ID"]),
                                        Convert.ToInt32(dr["Moneda_ID"]), Convert.ToInt32(dr["EstatusServicio_ID"]), DB.GetNullableInt32(dr["Unidad_ID"]),
                                            DB.GetNullableInt32(dr["Conductor_ID"]), Convert.ToString(dr["Usuario_ID"]), DB.GetNullableInt32(dr["Cliente_ID"]),
                                                DB.GetNullableInt32(dr["Ticket_ID"]), DB.GetNullableInt32(dr["TipoVenta_ID"]), DB.GetNullableInt32(dr["Cuenta_ID"]),
                                                    Convert.ToInt32(dr["FolioDiario"]), Convert.ToDecimal(dr["Precio"]), Convert.ToDateTime(dr["Fecha"]),
                                                        DB.GetNullableDateTime(dr["FechaServicio"]), DB.GetNullableDateTime(dr["FechaExpiracion"]),
                                                            DB.GetNullableDateTime(dr["FechaPago"]), DB.GetNullableDecimal(dr["Productividad"]),
                                                                DB.GetNullableDecimal(dr["PagoConductor"]), DB.GetNullableDecimal(dr["PagoComisiones"]),
													Convert.ToString(dr["Referencia_PayBack"]));
            } // End Read

            public int Update()
            {
                Hashtable m_params = new Hashtable();
                Hashtable w_params = new Hashtable();
                w_params.Add("Servicio_ID", this.Servicio_ID);
                m_params.Add("Mercado_ID", this.Mercado_ID);
                m_params.Add("Empresa_ID", this.Empresa_ID);
                if (!AppHelper.IsNullOrEmpty(this.Estacion_ID)) m_params.Add("Estacion_ID", this.Estacion_ID);
                if (!AppHelper.IsNullOrEmpty(this.Caja_ID)) m_params.Add("Caja_ID", this.Caja_ID);
                if (!AppHelper.IsNullOrEmpty(this.ClaseServicio_ID)) m_params.Add("Sesion_ID", this.Sesion_ID);
                if (!AppHelper.IsNullOrEmpty(this.Zona_ID)) m_params.Add("Zona_ID", this.Zona_ID);
                if (!AppHelper.IsNullOrEmpty(this.ClaseServicio_ID)) m_params.Add("ClaseServicio_ID", this.ClaseServicio_ID);
                if (!AppHelper.IsNullOrEmpty(this.TipoServicio_ID)) m_params.Add("TipoServicio_ID", this.TipoServicio_ID);
                if (!AppHelper.IsNullOrEmpty(this.TipoServicioConductor_ID)) m_params.Add("TipoServicioConductor_ID", this.TipoServicioConductor_ID);
                m_params.Add("Moneda_ID", this.Moneda_ID);
                m_params.Add("EstatusServicio_ID", this.EstatusServicio_ID);
                if (!AppHelper.IsNullOrEmpty(this.Unidad_ID)) m_params.Add("Unidad_ID", this.Unidad_ID);
                if (!AppHelper.IsNullOrEmpty(this.Conductor_ID)) m_params.Add("Conductor_ID", this.Conductor_ID);
                m_params.Add("Usuario_ID", this.Usuario_ID);
                if (!AppHelper.IsNullOrEmpty(this.Cliente_ID)) m_params.Add("Cliente_ID", this.Cliente_ID);
                if (!AppHelper.IsNullOrEmpty(this.Ticket_ID)) m_params.Add("Ticket_ID", this.Ticket_ID);
                if (!AppHelper.IsNullOrEmpty(this.TipoVenta_ID)) m_params.Add("TipoVenta_ID", this.TipoVenta_ID);
                m_params.Add("Cuenta_ID", this.Cuenta_ID);
                m_params.Add("FolioDiario", this.FolioDiario);
                m_params.Add("Precio", this.Precio);
                m_params.Add("Fecha", this.Fecha);
                if (!AppHelper.IsNullOrEmpty(this.FechaServicio)) m_params.Add("FechaServicio", this.FechaServicio);
                if (!AppHelper.IsNullOrEmpty(this.FechaExpiracion)) m_params.Add("FechaExpiracion", this.FechaExpiracion);
                if (!AppHelper.IsNullOrEmpty(this.FechaPago)) m_params.Add("FechaPago", this.FechaPago);
                if (!AppHelper.IsNullOrEmpty(this.Productividad)) m_params.Add("Productividad", this.Productividad);
                if (!AppHelper.IsNullOrEmpty(this.PagoConductor)) m_params.Add("PagoConductor", this.PagoConductor);
                if (!AppHelper.IsNullOrEmpty(this.PagoComisiones)) m_params.Add("PagoComisiones", this.PagoComisiones);
			 if (!AppHelper.IsNullOrEmpty(this.Referencia_PayBack)) m_params.Add("Referencia_PayBack", this.Referencia_PayBack);

                return DB.UpdateRow("Servicios", m_params, w_params);
            } // End Update

            public int Delete()
            {
                Hashtable w_params = new Hashtable();
                w_params.Add("Servicio_ID", this.Servicio_ID);

                return DB.DeleteRow("Servicios", w_params);
            } // End Delete

        } //End Class Servicios

        public class Servicios_Comisiones
        {

            public Servicios_Comisiones()
            {
            }

            public Servicios_Comisiones(string servicio_id, int comisionservicio_id, int? ticket_id, decimal monto)
            {
                this.Servicio_ID = servicio_id;
                this.ComisionServicio_ID = comisionservicio_id;
                this.Ticket_ID = ticket_id;
                this.Monto = monto;
            }

            private string _Servicio_ID;
            public string Servicio_ID
            {
                get { return _Servicio_ID; }
                set { _Servicio_ID = value; }
            }

            private int _ComisionServicio_ID;
            public int ComisionServicio_ID
            {
                get { return _ComisionServicio_ID; }
                set { _ComisionServicio_ID = value; }
            }

            private int? _Ticket_ID;
            public int? Ticket_ID
            {
                get { return _Ticket_ID; }
                set { _Ticket_ID = value; }
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
                m_params.Add("Servicio_ID", this.Servicio_ID);
                m_params.Add("ComisionServicio_ID", this.ComisionServicio_ID);
                if (!AppHelper.IsNullOrEmpty(this.Ticket_ID)) m_params.Add("Ticket_ID", this.Ticket_ID);
                m_params.Add("Monto", this.Monto);

                return DB.InsertRow("Servicios_Comisiones", m_params);
            } // End Create

            public static List<Servicios_Comisiones> Read()
            {
                List<Servicios_Comisiones> list = new List<Servicios_Comisiones>();
                DataTable dt = DB.Select("Servicios_Comisiones");
                foreach (DataRow dr in dt.Rows)
                {
                    list.Add(new Servicios_Comisiones(Convert.ToString(dr["Servicio_ID"]),
                        Convert.ToInt32(dr["ComisionServicio_ID"]), DB.GetNullableInt32(dr["Ticket_ID"]), Convert.ToDecimal(dr["Monto"])));
                }

                return list;
            } // End Read

            public static Servicios_Comisiones Read(string servicio_id, int comisionservicio_id)
            {
                Hashtable w_params = new Hashtable();
                w_params.Add("Servicio_ID", servicio_id);
                w_params.Add("ComisionServicio_ID", comisionservicio_id);
                DataTable dt = DB.Select("Servicios_Comisiones", w_params);
                if (dt.Rows.Count == 0)
                {
                    throw new Exception("No existe Servicios_Comisiones con los criterios de búsqueda especificados.");
                }
                DataRow dr = dt.Rows[0];
                return new Servicios_Comisiones(Convert.ToString(dr["Servicio_ID"]), Convert.ToInt32(dr["ComisionServicio_ID"]),
                    DB.GetNullableInt32(dr["Ticket_ID"]), Convert.ToDecimal(dr["Monto"]));
            } // End Read

            public static Servicios_Comisiones Read(params KeyValuePair<string, object>[] args)
            {
                DataTable dt = DB.Read("Servicios_Comisiones", args);
                if (dt.Rows.Count == 0)
                {
                    return null;
                }
                DataRow dr = dt.Rows[0];
                return new Servicios_Comisiones(Convert.ToString(dr["Servicio_ID"]), Convert.ToInt32(dr["ComisionServicio_ID"]),
                    DB.GetNullableInt32(dr["Ticket_ID"]), Convert.ToDecimal(dr["Monto"]));
            } // End Read

            public static bool Read(out Servicios_Comisiones servicios_comisiones, int top, string filter, string sort, params KeyValuePair<string, object>[] args)
            {
                DataTable dt = DB.Read("Servicios_Comisiones", top, filter, sort, args);
                if (dt.Rows.Count == 0)
                {
                    servicios_comisiones = null;
                    return false;
                }
                DataRow dr = dt.Rows[0];
                servicios_comisiones = new Servicios_Comisiones(Convert.ToString(dr["Servicio_ID"]), Convert.ToInt32(dr["ComisionServicio_ID"]),
                    DB.GetNullableInt32(dr["Ticket_ID"]), Convert.ToDecimal(dr["Monto"]));
                return true;
            } // End Read

            public static DataTable ReadDataTable()
            {
                return DB.Select("Servicios_Comisiones");
            } // End Read

            public static DataTable ReadDataTable(string servicio_id, int comisionservicio_id)
            {
                Hashtable w_params = new Hashtable();
                w_params.Add("Servicio_ID", servicio_id);
                w_params.Add("ComisionServicio_ID", comisionservicio_id);
                return DB.Select("Servicios_Comisiones", w_params);
            } // End Read

            public int Update()
            {
                Hashtable m_params = new Hashtable();
                Hashtable w_params = new Hashtable();
                w_params.Add("Servicio_ID", this.Servicio_ID);
                w_params.Add("ComisionServicio_ID", this.ComisionServicio_ID);
                if (!AppHelper.IsNullOrEmpty(this.Ticket_ID)) m_params.Add("Ticket_ID", this.Ticket_ID);
                m_params.Add("Monto", this.Monto);

                return DB.UpdateRow("Servicios_Comisiones", m_params, w_params);
            } // End Update

            public int Delete()
            {
                Hashtable w_params = new Hashtable();
                w_params.Add("Servicio_ID", this.Servicio_ID);
                w_params.Add("ComisionServicio_ID", this.ComisionServicio_ID);

                return DB.DeleteRow("Servicios_Comisiones", w_params);
            } // End Delete

        } //End Class Servicios_Comisiones

        public class ServiciosMantenimientos
        {

            public ServiciosMantenimientos()
            {
            }

            public ServiciosMantenimientos(int serviciomantenimiento_id, int tiposerviciomantenimiento_id, int familia_id, int modelo_id, string nombre, int tiempoaplicado, decimal costomanoobraareaminuto, decimal preciominuto, decimal costo, decimal precio, decimal porcentajeutilidad, decimal cuotamanoobra)
            {
                this.ServicioMantenimiento_ID = serviciomantenimiento_id;
                this.TipoServicioMantenimiento_ID = tiposerviciomantenimiento_id;
                this.Familia_ID = familia_id;
                this.Modelo_ID = modelo_id;
                this.Nombre = nombre;
                this.TiempoAplicado = tiempoaplicado;
                this.CostoManoObraAreaMinuto = costomanoobraareaminuto;
                this.PrecioMinuto = preciominuto;
                this.Costo = costo;
                this.Precio = precio;
                this.PorcentajeUtilidad = porcentajeutilidad;
                this.CuotaManoObra = cuotamanoobra;
            }

            private int _ServicioMantenimiento_ID;
            public int ServicioMantenimiento_ID
            {
                get { return _ServicioMantenimiento_ID; }
                set { _ServicioMantenimiento_ID = value; }
            }

            private int _TipoServicioMantenimiento_ID;
            public int TipoServicioMantenimiento_ID
            {
                get { return _TipoServicioMantenimiento_ID; }
                set { _TipoServicioMantenimiento_ID = value; }
            }

            private int _Familia_ID;
            public int Familia_ID
            {
                get { return _Familia_ID; }
                set { _Familia_ID = value; }
            }

            private int _Modelo_ID;
            public int Modelo_ID
            {
                get { return _Modelo_ID; }
                set { _Modelo_ID = value; }
            }

            private string _Nombre;
            public string Nombre
            {
                get { return _Nombre; }
                set { _Nombre = value; }
            }

            private int _TiempoAplicado;
            public int TiempoAplicado
            {
                get { return _TiempoAplicado; }
                set { _TiempoAplicado = value; }
            }

            private decimal _CostoManoObraAreaMinuto;
            public decimal CostoManoObraAreaMinuto
            {
                get { return _CostoManoObraAreaMinuto; }
                set { _CostoManoObraAreaMinuto = value; }
            }

            private decimal _PrecioMinuto;
            public decimal PrecioMinuto
            {
                get { return _PrecioMinuto; }
                set { _PrecioMinuto = value; }
            }

            private decimal _Costo;
            public decimal Costo
            {
                get { return _Costo; }
                set { _Costo = value; }
            }

            private decimal _Precio;
            public decimal Precio
            {
                get { return _Precio; }
                set { _Precio = value; }
            }

            private decimal _PorcentajeUtilidad;
            public decimal PorcentajeUtilidad
            {
                get { return _PorcentajeUtilidad; }
                set { _PorcentajeUtilidad = value; }
            }

            private decimal _CuotaManoObra;
            public decimal CuotaManoObra
            {
                get { return _CuotaManoObra; }
                set { _CuotaManoObra = value; }
            }

            public int Create(bool IsIdentityInsert)
            {
                if (!IsIdentityInsert) return Create();

                Hashtable m_params = new Hashtable();
                m_params.Add("ServicioMantenimiento_ID", this.ServicioMantenimiento_ID);
                m_params.Add("TipoServicioMantenimiento_ID", this.TipoServicioMantenimiento_ID);
                m_params.Add("Familia_ID", this.Familia_ID);
                m_params.Add("Modelo_ID", this.Modelo_ID);
                m_params.Add("Nombre", this.Nombre);
                m_params.Add("TiempoAplicado", this.TiempoAplicado);
                m_params.Add("CostoManoObraAreaMinuto", this.CostoManoObraAreaMinuto);
                m_params.Add("PrecioMinuto", this.PrecioMinuto);
                m_params.Add("Costo", this.Costo);
                m_params.Add("Precio", this.Precio);
                m_params.Add("PorcentajeUtilidad", this.PorcentajeUtilidad);
                m_params.Add("CuotaManoObra", this.CuotaManoObra);

                return DB.IdentityInsertRow("ServiciosMantenimientos", m_params);
            } // End Create

            public int Create()
            {
                Hashtable m_params = new Hashtable();
                m_params.Add("TipoServicioMantenimiento_ID", this.TipoServicioMantenimiento_ID);
                m_params.Add("Familia_ID", this.Familia_ID);
                m_params.Add("Modelo_ID", this.Modelo_ID);
                m_params.Add("Nombre", this.Nombre);
                m_params.Add("TiempoAplicado", this.TiempoAplicado);
                m_params.Add("CostoManoObraAreaMinuto", this.CostoManoObraAreaMinuto);
                m_params.Add("PrecioMinuto", this.PrecioMinuto);
                m_params.Add("Costo", this.Costo);
                m_params.Add("Precio", this.Precio);
                m_params.Add("PorcentajeUtilidad", this.PorcentajeUtilidad);
                m_params.Add("CuotaManoObra", this.CuotaManoObra);

                return DB.InsertRow("ServiciosMantenimientos", m_params);
            } // End Create

            public static List<ServiciosMantenimientos> Read()
            {
                List<ServiciosMantenimientos> list = new List<ServiciosMantenimientos>();
                DataTable dt = DB.Select("ServiciosMantenimientos");
                foreach (DataRow dr in dt.Rows)
                {
                    list.Add(new ServiciosMantenimientos(Convert.ToInt32(dr["ServicioMantenimiento_ID"]), Convert.ToInt32(dr["TipoServicioMantenimiento_ID"]), Convert.ToInt32(dr["Familia_ID"]), Convert.ToInt32(dr["Modelo_ID"]), Convert.ToString(dr["Nombre"]), Convert.ToInt32(dr["TiempoAplicado"]), Convert.ToDecimal(dr["CostoManoObraAreaMinuto"]), Convert.ToDecimal(dr["PrecioMinuto"]), Convert.ToDecimal(dr["Costo"]), Convert.ToDecimal(dr["Precio"]), Convert.ToDecimal(dr["PorcentajeUtilidad"]), Convert.ToDecimal(dr["CuotaManoObra"])));
                }

                return list;
            } // End Read

            public static ServiciosMantenimientos Read(int serviciomantenimiento_id)
            {
                Hashtable w_params = new Hashtable();
                w_params.Add("ServicioMantenimiento_ID", serviciomantenimiento_id);
                DataTable dt = DB.Select("ServiciosMantenimientos", w_params);
                if (dt.Rows.Count == 0)
                {
                    throw new Exception("No existe ServiciosMantenimientos con los criterios de búsqueda especificados.");
                }
                DataRow dr = dt.Rows[0];
                return new ServiciosMantenimientos(Convert.ToInt32(dr["ServicioMantenimiento_ID"]), Convert.ToInt32(dr["TipoServicioMantenimiento_ID"]), Convert.ToInt32(dr["Familia_ID"]), Convert.ToInt32(dr["Modelo_ID"]), Convert.ToString(dr["Nombre"]), Convert.ToInt32(dr["TiempoAplicado"]), Convert.ToDecimal(dr["CostoManoObraAreaMinuto"]), Convert.ToDecimal(dr["PrecioMinuto"]), Convert.ToDecimal(dr["Costo"]), Convert.ToDecimal(dr["Precio"]), Convert.ToDecimal(dr["PorcentajeUtilidad"]), Convert.ToDecimal(dr["CuotaManoObra"]));
            } // End Read

            public int Update()
            {
                Hashtable m_params = new Hashtable();
                Hashtable w_params = new Hashtable();
                w_params.Add("ServicioMantenimiento_ID", this.ServicioMantenimiento_ID);
                m_params.Add("TipoServicioMantenimiento_ID", this.TipoServicioMantenimiento_ID);
                m_params.Add("Familia_ID", this.Familia_ID);
                m_params.Add("Modelo_ID", this.Modelo_ID);
                m_params.Add("Nombre", this.Nombre);
                m_params.Add("TiempoAplicado", this.TiempoAplicado);
                m_params.Add("CostoManoObraAreaMinuto", this.CostoManoObraAreaMinuto);
                m_params.Add("PrecioMinuto", this.PrecioMinuto);
                m_params.Add("Costo", this.Costo);
                m_params.Add("Precio", this.Precio);
                m_params.Add("PorcentajeUtilidad", this.PorcentajeUtilidad);
                m_params.Add("CuotaManoObra", this.CuotaManoObra);

                return DB.UpdateRow("ServiciosMantenimientos", m_params, w_params);
            } // End Update

            public int Delete()
            {
                Hashtable w_params = new Hashtable();
                w_params.Add("ServicioMantenimiento_ID", this.ServicioMantenimiento_ID);

                return DB.DeleteRow("ServiciosMantenimientos", w_params);
            } // End Delete

        } //End Class ServiciosMantenimientos

        public class ServiciosMantenimientosPrecios
        {

            #region Constructors

            public ServiciosMantenimientosPrecios()
            {
            }

            public ServiciosMantenimientosPrecios(
                int serviciomantenimiento_id,
                int tipoclientetaller_id,
                decimal precio,
                int empresa_id,
                int estacion_id)
            {
                this.ServicioMantenimiento_ID = serviciomantenimiento_id;
                this.TipoClienteTaller_ID = tipoclientetaller_id;
                this.Precio = precio;
                this.Empresa_ID = empresa_id;
                this.Estacion_ID = estacion_id;
            }

            #endregion

            #region Properties

            private int _ServicioMantenimiento_ID;
            public int ServicioMantenimiento_ID
            {
                get { return _ServicioMantenimiento_ID; }
                set { _ServicioMantenimiento_ID = value; }
            }

            private int _TipoClienteTaller_ID;
            public int TipoClienteTaller_ID
            {
                get { return _TipoClienteTaller_ID; }
                set { _TipoClienteTaller_ID = value; }
            }

            private decimal _Precio;
            public decimal Precio
            {
                get { return _Precio; }
                set { _Precio = value; }
            }

            private int _Empresa_ID;
            public int Empresa_ID
            {
                get { return _Empresa_ID; }
                set { _Empresa_ID = value; }
            }

            private int _Estacion_ID;
            public int Estacion_ID
            {
                get { return _Estacion_ID; }
                set { _Estacion_ID = value; }
            }

            #endregion

            #region Methods
            public void Validate()
            {
                if (this.ServicioMantenimiento_ID == null) throw new Exception("ServicioMantenimiento_ID no puede ser nulo.");

                if (this.TipoClienteTaller_ID == null) throw new Exception("TipoClienteTaller_ID no puede ser nulo.");

                if (this.Precio == null) throw new Exception("Precio no puede ser nulo.");

                if (this.Empresa_ID == null) throw new Exception("Empresa_ID no puede ser nulo.");

                if (this.Estacion_ID == null) throw new Exception("Estacion_ID no puede ser nulo.");


            } // End Validate

            public int Create()
            {
                Hashtable m_params = new Hashtable();
                m_params.Add("ServicioMantenimiento_ID", this.ServicioMantenimiento_ID);
                m_params.Add("TipoClienteTaller_ID", this.TipoClienteTaller_ID);
                m_params.Add("Precio", this.Precio);
                m_params.Add("Empresa_ID", this.Empresa_ID);
                m_params.Add("Estacion_ID", this.Estacion_ID);

                return DB.InsertRow("ServiciosMantenimientosPrecios", m_params);
            } // End Create

            public static List<ServiciosMantenimientosPrecios> Read()
            {
                List<ServiciosMantenimientosPrecios> list = new List<ServiciosMantenimientosPrecios>();
                DataTable dt = DB.Select("ServiciosMantenimientosPrecios");
                foreach (DataRow dr in dt.Rows)
                {
                    list.Add(
                        new ServiciosMantenimientosPrecios(
                            Convert.ToInt32(dr["ServicioMantenimiento_ID"]),
                            Convert.ToInt32(dr["TipoClienteTaller_ID"]),
                            Convert.ToDecimal(dr["Precio"]),
                            Convert.ToInt32(dr["Empresa_ID"]),
                            Convert.ToInt32(dr["Estacion_ID"])
                        )
                    );
                }

                return list;
            } // End Read

            public static ServiciosMantenimientosPrecios Read(int serviciomantenimiento_id)
            {
                Hashtable w_params = new Hashtable();
                w_params.Add("ServicioMantenimiento_ID", serviciomantenimiento_id);
                DataTable dt = DB.Select("ServiciosMantenimientosPrecios", w_params);
                if (dt.Rows.Count == 0)
                {
                    throw new Exception("No existe ServiciosMantenimientosPrecios con los criterios de búsqueda especificados.");
                }
                DataRow dr = dt.Rows[0];
                return new ServiciosMantenimientosPrecios(
                    Convert.ToInt32(dr["ServicioMantenimiento_ID"]),
                            Convert.ToInt32(dr["TipoClienteTaller_ID"]),
                            Convert.ToDecimal(dr["Precio"]),
                            Convert.ToInt32(dr["Empresa_ID"]),
                            Convert.ToInt32(dr["Estacion_ID"])
                        );
            } // End Read

            public static ServiciosMantenimientosPrecios Read(params KeyValuePair<string, object>[] args)
            {
                DataTable dt = DB.Read("ServiciosMantenimientosPrecios", args);
                if (dt.Rows.Count == 0)
                {
                    return null;
                }
                DataRow dr = dt.Rows[0];
                return new ServiciosMantenimientosPrecios(
                    Convert.ToInt32(dr["ServicioMantenimiento_ID"]),
                            Convert.ToInt32(dr["TipoClienteTaller_ID"]),
                            Convert.ToDecimal(dr["Precio"]),
                            Convert.ToInt32(dr["Empresa_ID"]),
                            Convert.ToInt32(dr["Estacion_ID"])
                        );
            } // End Read

            public static bool Read(
                out ServiciosMantenimientosPrecios serviciosmantenimientosprecios,
                int top,
                string filter,
                string sort,
                params KeyValuePair<string, object>[] args)
            {
                DataTable dt = DB.Read("ServiciosMantenimientosPrecios", top, filter, sort, args);
                if (dt.Rows.Count == 0)
                {
                    serviciosmantenimientosprecios = null;
                    return false;
                }
                DataRow dr = dt.Rows[0];
                serviciosmantenimientosprecios = new ServiciosMantenimientosPrecios(
                    Convert.ToInt32(dr["ServicioMantenimiento_ID"]),
                            Convert.ToInt32(dr["TipoClienteTaller_ID"]),
                            Convert.ToDecimal(dr["Precio"]),
                            Convert.ToInt32(dr["Empresa_ID"]),
                            Convert.ToInt32(dr["Estacion_ID"])
                        );
                return true;
            } // End Read

            public static DataTable ReadDataTable()
            {
                return DB.Select("ServiciosMantenimientosPrecios");
            } // End Read

            public static DataTable ReadDataTable(int serviciomantenimiento_id)
            {
                Hashtable w_params = new Hashtable();
                w_params.Add("ServicioMantenimiento_ID", serviciomantenimiento_id);
                return DB.Select("ServiciosMantenimientosPrecios", w_params);
            } // End Read

            public int Update()
            {
                Hashtable m_params = new Hashtable();
                Hashtable w_params = new Hashtable();
                w_params.Add("ServicioMantenimiento_ID", this.ServicioMantenimiento_ID);
                w_params.Add("TipoClienteTaller_ID", this.TipoClienteTaller_ID);
                m_params.Add("Precio", this.Precio);
                w_params.Add("Empresa_ID", this.Empresa_ID);
                w_params.Add("Estacion_ID", this.Estacion_ID);

                return DB.UpdateRow("ServiciosMantenimientosPrecios", m_params, w_params);
            } // End Update

            public int Delete()
            {
                Hashtable w_params = new Hashtable();
                w_params.Add("ServicioMantenimiento_ID", this.ServicioMantenimiento_ID);

                return DB.DeleteRow("ServiciosMantenimientosPrecios", w_params);
            } // End Delete


            #endregion
        } //End Class ServiciosMantenimientosPrecios



        public class ServiciosMantenimientos_TiposRefacciones
        {

            public ServiciosMantenimientos_TiposRefacciones()
            {
            }

            public ServiciosMantenimientos_TiposRefacciones(int serviciomantenimiento_id, int tiporefaccion_id, int cantidad)
            {
                this.ServicioMantenimiento_ID = serviciomantenimiento_id;
                this.TipoRefaccion_ID = tiporefaccion_id;
                this.Cantidad = cantidad;
            }

            private int _ServicioMantenimiento_ID;
            public int ServicioMantenimiento_ID
            {
                get { return _ServicioMantenimiento_ID; }
                set { _ServicioMantenimiento_ID = value; }
            }

            private int _TipoRefaccion_ID;
            public int TipoRefaccion_ID
            {
                get { return _TipoRefaccion_ID; }
                set { _TipoRefaccion_ID = value; }
            }

            private int _Cantidad;
            public int Cantidad
            {
                get { return _Cantidad; }
                set { _Cantidad = value; }
            }

            public int Create()
            {
                Hashtable m_params = new Hashtable();
                m_params.Add("ServicioMantenimiento_ID", this.ServicioMantenimiento_ID);
                m_params.Add("TipoRefaccion_ID", this.TipoRefaccion_ID);
                m_params.Add("Cantidad", this.Cantidad);

                return DB.InsertRow("ServiciosMantenimientos_TiposRefacciones", m_params);
            } // End Create

            public static List<ServiciosMantenimientos_TiposRefacciones> Read()
            {
                List<ServiciosMantenimientos_TiposRefacciones> list = new List<ServiciosMantenimientos_TiposRefacciones>();
                DataTable dt = DB.Select("ServiciosMantenimientos_TiposRefacciones");
                foreach (DataRow dr in dt.Rows)
                {
                    list.Add(new ServiciosMantenimientos_TiposRefacciones(Convert.ToInt32(dr["ServicioMantenimiento_ID"]), Convert.ToInt32(dr["TipoRefaccion_ID"]), Convert.ToInt32(dr["Cantidad"])));
                }

                return list;
            } // End Read

            public static ServiciosMantenimientos_TiposRefacciones Read(int serviciomantenimiento_id, int tiporefaccion_id)
            {
                Hashtable w_params = new Hashtable();
                w_params.Add("ServicioMantenimiento_ID", serviciomantenimiento_id);
                w_params.Add("TipoRefaccion_ID", tiporefaccion_id);
                DataTable dt = DB.Select("ServiciosMantenimientos_TiposRefacciones", w_params);
                if (dt.Rows.Count == 0)
                {
                    throw new Exception("No existe ServiciosMantenimientos_TiposRefacciones con los criterios de búsqueda especificados.");
                }
                DataRow dr = dt.Rows[0];
                return new ServiciosMantenimientos_TiposRefacciones(Convert.ToInt32(dr["ServicioMantenimiento_ID"]), Convert.ToInt32(dr["TipoRefaccion_ID"]), Convert.ToInt32(dr["Cantidad"]));
            } // End Read

            public int Update()
            {
                Hashtable m_params = new Hashtable();
                Hashtable w_params = new Hashtable();                
                w_params.Add("ServicioMantenimiento_ID", this.ServicioMantenimiento_ID);                
                w_params.Add("TipoRefaccion_ID", this.TipoRefaccion_ID);
                m_params.Add("Cantidad", this.Cantidad);

                return DB.UpdateRow("ServiciosMantenimientos_TiposRefacciones", m_params, w_params);
            } // End Update

            public int Delete()
            {
                Hashtable w_params = new Hashtable();
                w_params.Add("ServicioMantenimiento_ID", this.ServicioMantenimiento_ID);
                w_params.Add("TipoRefaccion_ID", this.TipoRefaccion_ID);

                return DB.DeleteRow("ServiciosMantenimientos_TiposRefacciones", w_params);
            } // End Delete

        } //End Class ServiciosMantenimientos_TiposRefacciones

        public class Sesiones
        {

            public Sesiones()
            {
            }

            public Sesiones(int sesion_id, int empresa_id, int estacion_id, int? caja_id, string usuario_id, DateTime fechainicial, DateTime? fechafinal, string hostname, string ipaddress, string macaddress, bool activo, int? referencia_id)
            {
                this.Sesion_ID = sesion_id;
                this.Empresa_ID = empresa_id;
                this.Estacion_ID = estacion_id;
                this.Caja_ID = caja_id;
                this.Usuario_ID = usuario_id;
                this.FechaInicial = fechainicial;
                this.FechaFinal = fechafinal;
                this.HostName = hostname;
                this.IPAddress = ipaddress;
                this.MACAddress = macaddress;
                this.Activo = activo;
                this.Referencia_ID = referencia_id;
            }

            private int _Sesion_ID;
            public int Sesion_ID
            {
                get { return _Sesion_ID; }
                set { _Sesion_ID = value; }
            }

            private int _Empresa_ID;
            public int Empresa_ID
            {
                get { return _Empresa_ID; }
                set { _Empresa_ID = value; }
            }

            private int _Estacion_ID;
            public int Estacion_ID
            {
                get { return _Estacion_ID; }
                set { _Estacion_ID = value; }
            }

            private int? _Caja_ID;
            public int? Caja_ID
            {
                get { return _Caja_ID; }
                set { _Caja_ID = value; }
            }

            private string _Usuario_ID;
            public string Usuario_ID
            {
                get { return _Usuario_ID; }
                set { _Usuario_ID = value; }
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

            private string _HostName;
            public string HostName
            {
                get { return _HostName; }
                set { _HostName = value; }
            }

            private string _IPAddress;
            public string IPAddress
            {
                get { return _IPAddress; }
                set { _IPAddress = value; }
            }

            private string _MACAddress;
            public string MACAddress
            {
                get { return _MACAddress; }
                set { _MACAddress = value; }
            }

            private bool _Activo;
            public bool Activo
            {
                get { return _Activo; }
                set { _Activo = value; }
            }

            private int? _Referencia_ID;
            public int? Referencia_ID
            {
                get { return _Referencia_ID; }
                set { _Referencia_ID = value; }
            }

            public int Create()
            {
                Hashtable m_params = new Hashtable();
                m_params.Add("Empresa_ID", this.Empresa_ID);
                m_params.Add("Estacion_ID", this.Estacion_ID);
                if (!AppHelper.IsNullOrEmpty(this.Caja_ID)) m_params.Add("Caja_ID", this.Caja_ID);
                if (!AppHelper.IsNullOrEmpty(this.Usuario_ID)) m_params.Add("Usuario_ID", this.Usuario_ID);
                m_params.Add("FechaInicial", this.FechaInicial);
                if (!AppHelper.IsNullOrEmpty(this.FechaFinal)) m_params.Add("FechaFinal", this.FechaFinal);
                if (!AppHelper.IsNullOrEmpty(this.HostName)) m_params.Add("HostName", this.HostName);
                if (!AppHelper.IsNullOrEmpty(this.IPAddress)) m_params.Add("IPAddress", this.IPAddress);
                if (!AppHelper.IsNullOrEmpty(this.MACAddress)) m_params.Add("MACAddress", this.MACAddress);
                m_params.Add("Activo", this.Activo);
                if (!AppHelper.IsNullOrEmpty(this.Referencia_ID)) m_params.Add("Referencia_ID", this.Referencia_ID);

                return DB.InsertRow("Sesiones", m_params);
            } // End Create

            public int Create(bool IsIdentityInsert)
            {
                if (!IsIdentityInsert) return Create();
                Hashtable m_params = new Hashtable();
                m_params.Add("Sesion_ID", this.Sesion_ID);
                m_params.Add("Empresa_ID", this.Empresa_ID);
                m_params.Add("Estacion_ID", this.Estacion_ID);
                if (!AppHelper.IsNullOrEmpty(this.Caja_ID)) m_params.Add("Caja_ID", this.Caja_ID);
                if (!AppHelper.IsNullOrEmpty(this.Usuario_ID)) m_params.Add("Usuario_ID", this.Usuario_ID);
                m_params.Add("FechaInicial", this.FechaInicial);
                if (!AppHelper.IsNullOrEmpty(this.FechaFinal)) m_params.Add("FechaFinal", this.FechaFinal);
                if (!AppHelper.IsNullOrEmpty(this.HostName)) m_params.Add("HostName", this.HostName);
                if (!AppHelper.IsNullOrEmpty(this.IPAddress)) m_params.Add("IPAddress", this.IPAddress);
                if (!AppHelper.IsNullOrEmpty(this.MACAddress)) m_params.Add("MACAddress", this.MACAddress);
                m_params.Add("Activo", this.Activo);
                if (!AppHelper.IsNullOrEmpty(this.Referencia_ID)) m_params.Add("Referencia_ID", this.Referencia_ID);

                return DB.IdentityInsertRow("Sesiones", m_params);
            } // End Create

            public static List<Sesiones> Read()
            {
                List<Sesiones> list = new List<Sesiones>();
                DataTable dt = DB.Select("Sesiones");
                foreach (DataRow dr in dt.Rows)
                {
                    list.Add(new Sesiones(Convert.ToInt32(dr["Sesion_ID"]), Convert.ToInt32(dr["Empresa_ID"]), Convert.ToInt32(dr["Estacion_ID"]), DB.GetNullableInt32(dr["Caja_ID"]), Convert.ToString(dr["Usuario_ID"]), Convert.ToDateTime(dr["FechaInicial"]), DB.GetNullableDateTime(dr["FechaFinal"]), Convert.ToString(dr["HostName"]), Convert.ToString(dr["IPAddress"]), Convert.ToString(dr["MACAddress"]), Convert.ToBoolean(dr["Activo"]), DB.GetNullableInt32(dr["Referencia_ID"])));
                }

                return list;
            } // End Read

            public static Sesiones Read(int sesion_id)
            {
                Hashtable w_params = new Hashtable();
                w_params.Add("Sesion_ID", sesion_id);
                DataTable dt = DB.Select("Sesiones", w_params);
                if (dt.Rows.Count == 0)
                {
                    throw new Exception("No existe Sesiones con los criterios de búsqueda especificados.");
                }
                DataRow dr = dt.Rows[0];
                return new Sesiones(Convert.ToInt32(dr["Sesion_ID"]), Convert.ToInt32(dr["Empresa_ID"]), Convert.ToInt32(dr["Estacion_ID"]), DB.GetNullableInt32(dr["Caja_ID"]), Convert.ToString(dr["Usuario_ID"]), Convert.ToDateTime(dr["FechaInicial"]), DB.GetNullableDateTime(dr["FechaFinal"]), Convert.ToString(dr["HostName"]), Convert.ToString(dr["IPAddress"]), Convert.ToString(dr["MACAddress"]), Convert.ToBoolean(dr["Activo"]), DB.GetNullableInt32(dr["Referencia_ID"]));
            } // End Read

            public static Sesiones Read(params KeyValuePair<string, object>[] args)
            {
                DataTable dt = DB.Read("Sesiones", args);
                if (dt.Rows.Count == 0)
                {
                    return null;
                }
                DataRow dr = dt.Rows[0];
                return new Sesiones(Convert.ToInt32(dr["Sesion_ID"]), Convert.ToInt32(dr["Empresa_ID"]), Convert.ToInt32(dr["Estacion_ID"]), DB.GetNullableInt32(dr["Caja_ID"]), Convert.ToString(dr["Usuario_ID"]), Convert.ToDateTime(dr["FechaInicial"]), DB.GetNullableDateTime(dr["FechaFinal"]), Convert.ToString(dr["HostName"]), Convert.ToString(dr["IPAddress"]), Convert.ToString(dr["MACAddress"]), Convert.ToBoolean(dr["Activo"]), DB.GetNullableInt32(dr["Referencia_ID"]));
            } // End Read

            public static bool Read(out Sesiones sesiones, int top, string filter, string sort, params KeyValuePair<string, object>[] args)
            {
                DataTable dt = DB.Read("Sesiones", top, filter, sort, args);
                if (dt.Rows.Count == 0)
                {
                    sesiones = null;
                    return false;
                }
                DataRow dr = dt.Rows[0];
                sesiones = new Sesiones(Convert.ToInt32(dr["Sesion_ID"]), Convert.ToInt32(dr["Empresa_ID"]), Convert.ToInt32(dr["Estacion_ID"]), DB.GetNullableInt32(dr["Caja_ID"]), Convert.ToString(dr["Usuario_ID"]), Convert.ToDateTime(dr["FechaInicial"]), DB.GetNullableDateTime(dr["FechaFinal"]), Convert.ToString(dr["HostName"]), Convert.ToString(dr["IPAddress"]), Convert.ToString(dr["MACAddress"]), Convert.ToBoolean(dr["Activo"]), DB.GetNullableInt32(dr["Referencia_ID"]));
                return true;
            } // End Read

            public int Update()
            {
                Hashtable m_params = new Hashtable();
                Hashtable w_params = new Hashtable();
                w_params.Add("Sesion_ID", this.Sesion_ID);
                m_params.Add("Empresa_ID", this.Empresa_ID);
                m_params.Add("Estacion_ID", this.Estacion_ID);
                if (!AppHelper.IsNullOrEmpty(this.Caja_ID)) m_params.Add("Caja_ID", this.Caja_ID);
                if (!AppHelper.IsNullOrEmpty(this.Usuario_ID)) m_params.Add("Usuario_ID", this.Usuario_ID);
                m_params.Add("FechaInicial", this.FechaInicial);
                if (!AppHelper.IsNullOrEmpty(this.FechaFinal)) m_params.Add("FechaFinal", this.FechaFinal);
                if (!AppHelper.IsNullOrEmpty(this.HostName)) m_params.Add("HostName", this.HostName);
                if (!AppHelper.IsNullOrEmpty(this.IPAddress)) m_params.Add("IPAddress", this.IPAddress);
                if (!AppHelper.IsNullOrEmpty(this.MACAddress)) m_params.Add("MACAddress", this.MACAddress);
                m_params.Add("Activo", this.Activo);
                if (!AppHelper.IsNullOrEmpty(this.Referencia_ID)) m_params.Add("Referencia_ID", this.Referencia_ID);

                return DB.UpdateRow("Sesiones", m_params, w_params);
            } // End Update

            public int Delete()
            {
                Hashtable w_params = new Hashtable();
                w_params.Add("Sesion_ID", this.Sesion_ID);

                return DB.DeleteRow("Sesiones", w_params);
            } // End Delete

        } //End Class Sesiones

        public class StatusFinancieros
        {

            public StatusFinancieros()
            {
            }

            public StatusFinancieros(DateTime fecha, string usuario, string statusfinanciero_id, string descripcion)
            {
                this.Fecha = fecha;
                this.Usuario = usuario;
                this.StatusFinanciero_ID = statusfinanciero_id;
                this.Descripcion = descripcion;
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

            private string _StatusFinanciero_ID;
            public string StatusFinanciero_ID
            {
                get { return _StatusFinanciero_ID; }
                set { _StatusFinanciero_ID = value; }
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
                m_params.Add("Fecha", this.Fecha);
                m_params.Add("Usuario", this.Usuario);
                m_params.Add("StatusFinanciero_ID", this.StatusFinanciero_ID);
                m_params.Add("Descripcion", this.Descripcion);

                return DB.InsertRow("StatusFinancieros", m_params);
            } // End Create

            public static List<StatusFinancieros> Read()
            {
                List<StatusFinancieros> list = new List<StatusFinancieros>();
                DataTable dt = DB.Select("StatusFinancieros");
                foreach (DataRow dr in dt.Rows)
                {
                    list.Add(new StatusFinancieros(Convert.ToDateTime(dr["Fecha"]), Convert.ToString(dr["Usuario"]), Convert.ToString(dr["StatusFinanciero_ID"]), Convert.ToString(dr["Descripcion"])));
                }

                return list;
            } // End Read

            public static List<StatusFinancieros> Read(string statusfinanciero_id)
            {
                List<StatusFinancieros> list = new List<StatusFinancieros>();
                Hashtable w_params = new Hashtable();
                w_params.Add("StatusFinanciero_ID", statusfinanciero_id);
                DataTable dt = DB.Select("StatusFinancieros", w_params);
                foreach (DataRow dr in dt.Rows)
                {
                    list.Add(new StatusFinancieros(Convert.ToDateTime(dr["Fecha"]), Convert.ToString(dr["Usuario"]), Convert.ToString(dr["StatusFinanciero_ID"]), Convert.ToString(dr["Descripcion"])));
                }

                return list;
            } // End Read

            public int Update()
            {
                Hashtable m_params = new Hashtable();
                Hashtable w_params = new Hashtable();
                m_params.Add("Fecha", this.Fecha);
                m_params.Add("Usuario", this.Usuario);
                w_params.Add("StatusFinanciero_ID", this.StatusFinanciero_ID);
                m_params.Add("Descripcion", this.Descripcion);

                return DB.UpdateRow("StatusFinancieros", m_params, w_params);
            } // End Update

            public int Delete()
            {
                Hashtable w_params = new Hashtable();
                w_params.Add("StatusFinanciero_ID", this.StatusFinanciero_ID);

                return DB.DeleteRow("StatusFinancieros", w_params);
            }

        } //End Class StatusFinancieros

        public class Tarifas
	    {

		    public Tarifas()
		    {
		    }

		    public Tarifas(int zona_id, int tiposervicio_id, decimal tarifa)
		    {
			    this.Zona_ID = zona_id;
			    this.TipoServicio_ID = tiposervicio_id;
			    this.Tarifa = tarifa;
		    }

		    private int _Zona_ID;
		    public int Zona_ID
		    {
			    get { return _Zona_ID; }
			    set { _Zona_ID = value; }
		    }

		    private int _TipoServicio_ID;
		    public int TipoServicio_ID
		    {
			    get { return _TipoServicio_ID; }
			    set { _TipoServicio_ID = value; }
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
			    m_params.Add("Zona_ID", this.Zona_ID);
			    m_params.Add("TipoServicio_ID", this.TipoServicio_ID);
			    m_params.Add("Tarifa", this.Tarifa);

			    return DB.InsertRow("Tarifas", m_params);
		    } // End Create

		    public static List<Tarifas> Read()
		    {
			    List<Tarifas> list = new List<Tarifas>();
			    DataTable dt = DB.Select("Tarifas");
			    foreach (DataRow dr in dt.Rows)
			    {
				    list.Add(new Tarifas(Convert.ToInt32(dr["Zona_ID"]), Convert.ToInt32(dr["TipoServicio_ID"]), Convert.ToDecimal(dr["Tarifa"])));
			    }

			    return list;
		    } // End Read

		    public static Tarifas Read(int zona_id, int tiposervicio_id)
		    {
			    Hashtable w_params = new Hashtable();
			    w_params.Add("Zona_ID", zona_id);
			    w_params.Add("TipoServicio_ID", tiposervicio_id);
			    DataTable dt = DB.Select("Tarifas", w_params);
			    if ( dt.Rows.Count == 0 )
			    {
				    throw new Exception("No existe Tarifas con los criterios de búsqueda especificados.");
			    }
			    DataRow dr = dt.Rows[0];
			    return new Tarifas(Convert.ToInt32(dr["Zona_ID"]), Convert.ToInt32(dr["TipoServicio_ID"]), Convert.ToDecimal(dr["Tarifa"]));
		    } // End Read

		    public int Update()
		    {
			    Hashtable m_params = new Hashtable();
			    Hashtable w_params = new Hashtable();
			    w_params.Add("Zona_ID", this.Zona_ID);
			    w_params.Add("TipoServicio_ID", this.TipoServicio_ID);
			    m_params.Add("Tarifa", this.Tarifa);

			    return DB.UpdateRow("Tarifas", m_params, w_params);
		    } // End Update

		    public int Delete()
		    {
			    Hashtable w_params = new Hashtable();
			    w_params.Add("Zona_ID", this.Zona_ID);
			    w_params.Add("TipoServicio_ID", this.TipoServicio_ID);

			    return DB.DeleteRow("Tarifas", w_params);
		    } // End Delete

	    } //End Class Tarifas

        public class Tickets
        {

            public Tickets()
            {
            }

            public Tickets(int ticket_id, int sesion_id, int caja_id, string usuario_id, int estatusticket_id, int empresa_id, int estacion_id, 
                int conductor_id, int? unidad_id, DateTime fecha, int? referencia_id)
            {
                this.Ticket_ID = ticket_id;
                this.Sesion_ID = sesion_id;
                this.Caja_ID = caja_id;
                this.Usuario_ID = usuario_id;
                this.EstatusTicket_ID = estatusticket_id;
                this.Empresa_ID = empresa_id;
                this.Estacion_ID = estacion_id;
                this.Conductor_ID = conductor_id;
                this.Unidad_ID = unidad_id;
                this.Fecha = fecha;
                this.Referencia_ID = referencia_id;
            }

            private int _Ticket_ID;
            public int Ticket_ID
            {
                get { return _Ticket_ID; }
                set { _Ticket_ID = value; }
            }

            private int _Sesion_ID;
            public int Sesion_ID
            {
                get { return _Sesion_ID; }
                set { _Sesion_ID = value; }
            }

            private int _Caja_ID;
            public int Caja_ID
            {
                get { return _Caja_ID; }
                set { _Caja_ID = value; }
            }

            private string _Usuario_ID;
            public string Usuario_ID
            {
                get { return _Usuario_ID; }
                set { _Usuario_ID = value; }
            }

            private int _EstatusTicket_ID;
            public int EstatusTicket_ID
            {
                get { return _EstatusTicket_ID; }
                set { _EstatusTicket_ID = value; }
            }

            private int _Empresa_ID;
            public int Empresa_ID
            {
                get { return _Empresa_ID; }
                set { _Empresa_ID = value; }
            }

            private int _Estacion_ID;
            public int Estacion_ID
            {
                get { return _Estacion_ID; }
                set { _Estacion_ID = value; }
            }

            private int _Conductor_ID;
            public int Conductor_ID
            {
                get { return _Conductor_ID; }
                set { _Conductor_ID = value; }
            }

            private int? _Unidad_ID;
            public int? Unidad_ID
            {
                get { return _Unidad_ID; }
                set { _Unidad_ID = value; }
            }

            private DateTime _Fecha;
            public DateTime Fecha
            {
                get { return _Fecha; }
                set { _Fecha = value; }
            }

            private int? _Referencia_ID;
            public int? Referencia_ID
            {
                get { return _Referencia_ID; }
                set { _Referencia_ID = value; }
            }

            public int Create()
            {
                Hashtable m_params = new Hashtable();
                m_params.Add("Sesion_ID", this.Sesion_ID);
                m_params.Add("Caja_ID", this.Caja_ID);
                m_params.Add("Usuario_ID", this.Usuario_ID);
                m_params.Add("EstatusTicket_ID", this.EstatusTicket_ID);
                m_params.Add("Empresa_ID", this.Empresa_ID);
                m_params.Add("Estacion_ID", this.Estacion_ID);
                m_params.Add("Conductor_ID", this.Conductor_ID);
                m_params.Add("Unidad_ID", this.Unidad_ID);
                m_params.Add("Fecha", this.Fecha);
                if (!AppHelper.IsNullOrEmpty(this.Referencia_ID)) m_params.Add("Referencia_ID", this.Referencia_ID);

                int result = DB.InsertRow("Tickets", m_params);
                this.Ticket_ID = DB.Ident_Current("Tickets");
                return result;
            } // End Create

            public int Create(bool IsIdentityInsert)
            {
                if (!IsIdentityInsert) return Create();
                Hashtable m_params = new Hashtable();
                m_params.Add("Ticket_ID", this.Ticket_ID);
                m_params.Add("Sesion_ID", this.Sesion_ID);
                m_params.Add("Caja_ID", this.Caja_ID);
                m_params.Add("Usuario_ID", this.Usuario_ID);
                m_params.Add("EstatusTicket_ID", this.EstatusTicket_ID);
                m_params.Add("Empresa_ID", this.Empresa_ID);
                m_params.Add("Estacion_ID", this.Estacion_ID);
                m_params.Add("Conductor_ID", this.Conductor_ID);
                m_params.Add("Unidad_ID", this.Unidad_ID);
                m_params.Add("Fecha", this.Fecha);
                if (!AppHelper.IsNullOrEmpty(this.Referencia_ID)) m_params.Add("Referencia_ID", this.Referencia_ID);

                return DB.IdentityInsertRow("Tickets", m_params);
            } // End Create

            public static List<Tickets> Read()
            {
                List<Tickets> list = new List<Tickets>();
                DataTable dt = DB.Select("Tickets");
                foreach (DataRow dr in dt.Rows)
                {
                    list.Add(new Tickets(Convert.ToInt32(dr["Ticket_ID"]), Convert.ToInt32(dr["Sesion_ID"]), Convert.ToInt32(dr["Caja_ID"]), 
                        Convert.ToString(dr["Usuario_ID"]), Convert.ToInt32(dr["EstatusTicket_ID"]), Convert.ToInt32(dr["Empresa_ID"]), 
                        Convert.ToInt32(dr["Estacion_ID"]), Convert.ToInt32(dr["Conductor_ID"]), DB.GetNullableInt32(dr["Unidad_ID"]), 
                        Convert.ToDateTime(dr["Fecha"]), DB.GetNullableInt32(dr["Referencia_ID"])));
                }

                return list;
            } // End Read

            public static Tickets Read(int ticket_id)
            {
                Hashtable w_params = new Hashtable();
                w_params.Add("Ticket_ID", ticket_id);
                DataTable dt = DB.Select("Tickets", w_params);
                if (dt.Rows.Count == 0)
                {
                    throw new Exception("No existe Tickets con los criterios de búsqueda especificados.");
                }
                DataRow dr = dt.Rows[0];
                return new Tickets(Convert.ToInt32(dr["Ticket_ID"]), Convert.ToInt32(dr["Sesion_ID"]), Convert.ToInt32(dr["Caja_ID"]), 
                    Convert.ToString(dr["Usuario_ID"]), Convert.ToInt32(dr["EstatusTicket_ID"]), Convert.ToInt32(dr["Empresa_ID"]),
                    Convert.ToInt32(dr["Estacion_ID"]), Convert.ToInt32(dr["Conductor_ID"]), DB.GetNullableInt32(dr["Unidad_ID"]), 
                    Convert.ToDateTime(dr["Fecha"]), DB.GetNullableInt32(dr["Referencia_ID"]));
            } // End Read

            public static Tickets Read(params KeyValuePair<string, object>[] args)
            {
                DataTable dt = DB.Read("Tickets", args);
                if (dt.Rows.Count == 0)
                {
                    return null;
                }
                DataRow dr = dt.Rows[0];
                return new Tickets(Convert.ToInt32(dr["Ticket_ID"]), Convert.ToInt32(dr["Sesion_ID"]), Convert.ToInt32(dr["Caja_ID"]), Convert.ToString(dr["Usuario_ID"]), Convert.ToInt32(dr["EstatusTicket_ID"]), Convert.ToInt32(dr["Empresa_ID"]), Convert.ToInt32(dr["Estacion_ID"]), Convert.ToInt32(dr["Conductor_ID"]), DB.GetNullableInt32(dr["Unidad_ID"]), Convert.ToDateTime(dr["Fecha"]), DB.GetNullableInt32(dr["Referencia_ID"]));
            } // End Read

            public static bool Read(out Tickets tickets, int top, string filter, string sort, params KeyValuePair<string, object>[] args)
            {
                DataTable dt = DB.Read("Tickets", top, filter, sort, args);
                if (dt.Rows.Count == 0)
                {
                    tickets = null;
                    return false;
                }
                DataRow dr = dt.Rows[0];
                tickets = new Tickets(Convert.ToInt32(dr["Ticket_ID"]), Convert.ToInt32(dr["Sesion_ID"]), Convert.ToInt32(dr["Caja_ID"]), Convert.ToString(dr["Usuario_ID"]), Convert.ToInt32(dr["EstatusTicket_ID"]), Convert.ToInt32(dr["Empresa_ID"]), Convert.ToInt32(dr["Estacion_ID"]), Convert.ToInt32(dr["Conductor_ID"]), DB.GetNullableInt32(dr["Unidad_ID"]), Convert.ToDateTime(dr["Fecha"]), DB.GetNullableInt32(dr["Referencia_ID"]));
                return true;
            } // End Read

            public int Update()
            {
                Hashtable m_params = new Hashtable();
                Hashtable w_params = new Hashtable();
                w_params.Add("Ticket_ID", this.Ticket_ID);
                m_params.Add("Sesion_ID", this.Sesion_ID);
                m_params.Add("Caja_ID", this.Caja_ID);
                m_params.Add("Usuario_ID", this.Usuario_ID);
                m_params.Add("EstatusTicket_ID", this.EstatusTicket_ID);
                m_params.Add("Empresa_ID", this.Empresa_ID);
                m_params.Add("Estacion_ID", this.Estacion_ID);
                m_params.Add("Conductor_ID", this.Conductor_ID);
                m_params.Add("Unidad_ID", this.Unidad_ID);
                m_params.Add("Fecha", this.Fecha);
                if (!AppHelper.IsNullOrEmpty(this.Referencia_ID)) m_params.Add("Referencia_ID", this.Referencia_ID);

                return DB.UpdateRow("Tickets", m_params, w_params);
            } // End Update

            public int Delete()
            {
                Hashtable w_params = new Hashtable();
                w_params.Add("Ticket_ID", this.Ticket_ID);

                return DB.DeleteRow("Tickets", w_params);
            } // End Delete

        } //End Class Tickets

        public class TicketsCancelados
        {

            public TicketsCancelados()
            {
            }

            public TicketsCancelados(int ticket_id, string motivo, string usuario_id, DateTime fecha)
            {
                this.Ticket_ID = ticket_id;
                this.Motivo = motivo;
                this.Usuario_ID = usuario_id;
                this.Fecha = fecha;
            }

            private int _Ticket_ID;
            public int Ticket_ID
            {
                get { return _Ticket_ID; }
                set { _Ticket_ID = value; }
            }

            private string _Motivo;
            public string Motivo
            {
                get { return _Motivo; }
                set { _Motivo = value; }
            }

            private string _Usuario_ID;
            public string Usuario_ID
            {
                get { return _Usuario_ID; }
                set { _Usuario_ID = value; }
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
                m_params.Add("Ticket_ID", this.Ticket_ID);
                m_params.Add("Motivo", this.Motivo);
                m_params.Add("Usuario_ID", this.Usuario_ID);
                m_params.Add("Fecha", this.Fecha);

                return DB.InsertRow("TicketsCancelados", m_params);
            } // End Create

            public static List<TicketsCancelados> Read()
            {
                List<TicketsCancelados> list = new List<TicketsCancelados>();
                DataTable dt = DB.Select("TicketsCancelados");
                foreach (DataRow dr in dt.Rows)
                {
                    list.Add(new TicketsCancelados(Convert.ToInt32(dr["Ticket_ID"]), Convert.ToString(dr["Motivo"]), Convert.ToString(dr["Usuario_ID"]), Convert.ToDateTime(dr["Fecha"])));
                }

                return list;
            } // End Read

            public static List<TicketsCancelados> Read(int ticket_id)
            {
                List<TicketsCancelados> list = new List<TicketsCancelados>();
                Hashtable w_params = new Hashtable();
                w_params.Add("Ticket_ID", ticket_id);
                DataTable dt = DB.Select("TicketsCancelados", w_params);
                foreach (DataRow dr in dt.Rows)
                {
                    list.Add(new TicketsCancelados(Convert.ToInt32(dr["Ticket_ID"]), Convert.ToString(dr["Motivo"]), Convert.ToString(dr["Usuario_ID"]), Convert.ToDateTime(dr["Fecha"])));
                }

                return list;
            } // End Read

            public int Update()
            {
                Hashtable m_params = new Hashtable();
                Hashtable w_params = new Hashtable();
                w_params.Add("Ticket_ID", this.Ticket_ID);
                m_params.Add("Motivo", this.Motivo);
                m_params.Add("Usuario_ID", this.Usuario_ID);
                m_params.Add("Fecha", this.Fecha);

                return DB.UpdateRow("TicketsCancelados", m_params, w_params);
            } // End Update

            public int Delete()
            {
                Hashtable w_params = new Hashtable();
                w_params.Add("Ticket_ID", this.Ticket_ID);

                return DB.DeleteRow("TicketsCancelados", w_params);
            }

        } //End Class TicketsCancelados

        public class TiposComisiones
        {

            public TiposComisiones()
            {
            }

            public TiposComisiones(int tipocomision_id, string nombre)
            {
                this.TipoComision_ID = tipocomision_id;
                this.Nombre = nombre;
            }

            private int _TipoComision_ID;
            public int TipoComision_ID
            {
                get { return _TipoComision_ID; }
                set { _TipoComision_ID = value; }
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

                return DB.InsertRow("TiposComisiones", m_params);
            } // End Create

            public static List<TiposComisiones> Read()
            {
                List<TiposComisiones> list = new List<TiposComisiones>();
                DataTable dt = DB.Select("TiposComisiones");
                foreach (DataRow dr in dt.Rows)
                {
                    list.Add(new TiposComisiones(Convert.ToInt32(dr["TipoComision_ID"]), Convert.ToString(dr["Nombre"])));
                }

                return list;
            } // End Read

            public static List<TiposComisiones> Read(int tipocomision_id)
            {
                List<TiposComisiones> list = new List<TiposComisiones>();
                Hashtable w_params = new Hashtable();
                w_params.Add("TipoComision_ID", tipocomision_id);
                DataTable dt = DB.Select("TiposComisiones", w_params);
                foreach (DataRow dr in dt.Rows)
                {
                    list.Add(new TiposComisiones(Convert.ToInt32(dr["TipoComision_ID"]), Convert.ToString(dr["Nombre"])));
                }

                return list;
            } // End Read

            public int Update()
            {
                Hashtable m_params = new Hashtable();
                Hashtable w_params = new Hashtable();
                w_params.Add("TipoComision_ID", this.TipoComision_ID);
                m_params.Add("Nombre", this.Nombre);

                return DB.UpdateRow("TiposComisiones", m_params, w_params);
            } // End Update

            public int Delete()
            {
                Hashtable w_params = new Hashtable();
                w_params.Add("TipoComision_ID", this.TipoComision_ID);

                return DB.DeleteRow("TiposComisiones", w_params);
            }

        } //End Class TiposComisiones

        public class TiposConcesiones
        {

            public TiposConcesiones()
            {
            }

            public TiposConcesiones(int tipoconcesion_id, string nombre)
            {
                this.TipoConcesion_ID = tipoconcesion_id;
                this.Nombre = nombre;
            }

            private int _TipoConcesion_ID;
            public int TipoConcesion_ID
            {
                get { return _TipoConcesion_ID; }
                set { _TipoConcesion_ID = value; }
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

                return DB.InsertRow("TiposConcesiones", m_params);
            } // End Create

            public static List<TiposConcesiones> Read()
            {
                List<TiposConcesiones> list = new List<TiposConcesiones>();
                DataTable dt = DB.Select("TiposConcesiones");
                foreach (DataRow dr in dt.Rows)
                {
                    list.Add(new TiposConcesiones(Convert.ToInt32(dr["TipoConcesion_ID"]), Convert.ToString(dr["Nombre"])));
                }

                return list;
            } // End Read

            public static List<TiposConcesiones> Read(int tipoconcesion_id)
            {
                List<TiposConcesiones> list = new List<TiposConcesiones>();
                Hashtable w_params = new Hashtable();
                w_params.Add("TipoConcesion_ID", tipoconcesion_id);
                DataTable dt = DB.Select("TiposConcesiones", w_params);
                foreach (DataRow dr in dt.Rows)
                {
                    list.Add(new TiposConcesiones(Convert.ToInt32(dr["TipoConcesion_ID"]), Convert.ToString(dr["Nombre"])));
                }

                return list;
            } // End Read

            public int Update()
            {
                Hashtable m_params = new Hashtable();
                Hashtable w_params = new Hashtable();
                w_params.Add("TipoConcesion_ID", this.TipoConcesion_ID);
                m_params.Add("Nombre", this.Nombre);

                return DB.UpdateRow("TiposConcesiones", m_params, w_params);
            } // End Update

            public int Delete()
            {
                Hashtable w_params = new Hashtable();
                w_params.Add("TipoConcesion_ID", this.TipoConcesion_ID);

                return DB.DeleteRow("TiposConcesiones", w_params);
            }

        } //End Class TiposConcesiones

        public class TiposContratos
        {

            public TiposContratos()
            {
            }

            public TiposContratos(int tipocontrato_id, string nombre)
            {
                this.TipoContrato_ID = tipocontrato_id;
                this.Nombre = nombre;
            }

            private int _TipoContrato_ID;
            public int TipoContrato_ID
            {
                get { return _TipoContrato_ID; }
                set { _TipoContrato_ID = value; }
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

                return DB.InsertRow("TiposContratos", m_params);
            } // End Create

            public static List<TiposContratos> Read()
            {
                List<TiposContratos> list = new List<TiposContratos>();
                DataTable dt = DB.Select("TiposContratos");
                foreach (DataRow dr in dt.Rows)
                {
                    list.Add(new TiposContratos(Convert.ToInt32(dr["TipoContrato_ID"]), Convert.ToString(dr["Nombre"])));
                }

                return list;
            } // End Read

            public static List<TiposContratos> Read(int tipocontrato_id)
            {
                List<TiposContratos> list = new List<TiposContratos>();
                Hashtable w_params = new Hashtable();
                w_params.Add("TipoContrato_ID", tipocontrato_id);
                DataTable dt = DB.Select("TiposContratos", w_params);
                foreach (DataRow dr in dt.Rows)
                {
                    list.Add(new TiposContratos(Convert.ToInt32(dr["TipoContrato_ID"]), Convert.ToString(dr["Nombre"])));
                }

                return list;
            } // End Read

            public int Update()
            {
                Hashtable m_params = new Hashtable();
                Hashtable w_params = new Hashtable();
                w_params.Add("TipoContrato_ID", this.TipoContrato_ID);
                m_params.Add("Nombre", this.Nombre);

                return DB.UpdateRow("TiposContratos", m_params, w_params);
            } // End Update

            public int Delete()
            {
                Hashtable w_params = new Hashtable();
                w_params.Add("TipoContrato_ID", this.TipoContrato_ID);

                return DB.DeleteRow("TiposContratos", w_params);
            }

        } //End Class TiposContratos

        public class TiposCuentas
        {

            public TiposCuentas()
            {
            }

            public TiposCuentas(string tipocuenta_id, string descripcion, string comentarios)
            {
                this.TipoCuenta_ID = tipocuenta_id;
                this.Descripcion = descripcion;
                this.Comentarios = comentarios;
            }

            private string _TipoCuenta_ID;
            public string TipoCuenta_ID
            {
                get { return _TipoCuenta_ID; }
                set { _TipoCuenta_ID = value; }
            }

            private string _Descripcion;
            public string Descripcion
            {
                get { return _Descripcion; }
                set { _Descripcion = value; }
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
                m_params.Add("TipoCuenta_ID", this.TipoCuenta_ID);
                m_params.Add("Descripcion", this.Descripcion);
                m_params.Add("Comentarios", this.Comentarios);

                return DB.InsertRow("TiposCuentas", m_params);
            } // End Create

            public static List<TiposCuentas> Read()
            {
                List<TiposCuentas> list = new List<TiposCuentas>();
                DataTable dt = DB.Select("TiposCuentas");
                foreach (DataRow dr in dt.Rows)
                {
                    list.Add(new TiposCuentas(Convert.ToString(dr["TipoCuenta_ID"]), Convert.ToString(dr["Descripcion"]), Convert.ToString(dr["Comentarios"])));
                }

                return list;
            } // End Read

            public static List<TiposCuentas> Read(string tipocuenta_id)
            {
                List<TiposCuentas> list = new List<TiposCuentas>();
                Hashtable w_params = new Hashtable();
                w_params.Add("TipoCuenta_ID", tipocuenta_id);
                DataTable dt = DB.Select("TiposCuentas", w_params);
                foreach (DataRow dr in dt.Rows)
                {
                    list.Add(new TiposCuentas(Convert.ToString(dr["TipoCuenta_ID"]), Convert.ToString(dr["Descripcion"]), Convert.ToString(dr["Comentarios"])));
                }

                return list;
            } // End Read

            public int Update()
            {
                Hashtable m_params = new Hashtable();
                Hashtable w_params = new Hashtable();
                w_params.Add("TipoCuenta_ID", this.TipoCuenta_ID);
                m_params.Add("Descripcion", this.Descripcion);
                m_params.Add("Comentarios", this.Comentarios);

                return DB.UpdateRow("TiposCuentas", m_params, w_params);
            } // End Update

            public int Delete()
            {
                Hashtable w_params = new Hashtable();
                w_params.Add("TipoCuenta_ID", this.TipoCuenta_ID);

                return DB.DeleteRow("TiposCuentas", w_params);
            }

        } //End Class TiposCuentas

        public class TiposEmpresas
        {

            public TiposEmpresas()
            {
            }

            public TiposEmpresas(int tipoempresa_id, string nombre)
            {
                this.TipoEmpresa_ID = tipoempresa_id;
                this.Nombre = nombre;
            }

            private int _TipoEmpresa_ID;
            public int TipoEmpresa_ID
            {
                get { return _TipoEmpresa_ID; }
                set { _TipoEmpresa_ID = value; }
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

                return DB.InsertRow("TiposEmpresas", m_params);
            } // End Create

            public static List<TiposEmpresas> Read()
            {
                List<TiposEmpresas> list = new List<TiposEmpresas>();
                DataTable dt = DB.Select("TiposEmpresas");
                foreach (DataRow dr in dt.Rows)
                {
                    list.Add(new TiposEmpresas(Convert.ToInt32(dr["TipoEmpresa_ID"]), Convert.ToString(dr["Nombre"])));
                }

                return list;
            } // End Read

            public static List<TiposEmpresas> Read(int tipoempresa_id)
            {
                List<TiposEmpresas> list = new List<TiposEmpresas>();
                Hashtable w_params = new Hashtable();
                w_params.Add("TipoEmpresa_ID", tipoempresa_id);
                DataTable dt = DB.Select("TiposEmpresas", w_params);
                foreach (DataRow dr in dt.Rows)
                {
                    list.Add(new TiposEmpresas(Convert.ToInt32(dr["TipoEmpresa_ID"]), Convert.ToString(dr["Nombre"])));
                }

                return list;
            } // End Read

            public int Update()
            {
                Hashtable m_params = new Hashtable();
                Hashtable w_params = new Hashtable();
                w_params.Add("TipoEmpresa_ID", this.TipoEmpresa_ID);
                m_params.Add("Nombre", this.Nombre);

                return DB.UpdateRow("TiposEmpresas", m_params, w_params);
            } // End Update

            public int Delete()
            {
                Hashtable w_params = new Hashtable();
                w_params.Add("TipoEmpresa_ID", this.TipoEmpresa_ID);

                return DB.DeleteRow("TiposEmpresas", w_params);
            }

        } //End Class TiposEmpresas

        public class TiposLicencias
        {

            public TiposLicencias()
            {
            }

            public TiposLicencias(int tipolicencia_id, string nombre)
            {
                this.TipoLicencia_ID = tipolicencia_id;
                this.Nombre = nombre;
            }

            private int _TipoLicencia_ID;
            public int TipoLicencia_ID
            {
                get { return _TipoLicencia_ID; }
                set { _TipoLicencia_ID = value; }
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

                return DB.InsertRow("TiposLicencias", m_params);
            } // End Create

            public static List<TiposLicencias> Read()
            {
                List<TiposLicencias> list = new List<TiposLicencias>();
                DataTable dt = DB.Select("TiposLicencias");
                foreach (DataRow dr in dt.Rows)
                {
                    list.Add(new TiposLicencias(Convert.ToInt32(dr["TipoLicencia_ID"]), Convert.ToString(dr["Nombre"])));
                }

                return list;
            } // End Read

            public static List<TiposLicencias> Read(int tipolicencia_id)
            {
                List<TiposLicencias> list = new List<TiposLicencias>();
                Hashtable w_params = new Hashtable();
                w_params.Add("TipoLicencia_ID", tipolicencia_id);
                DataTable dt = DB.Select("TiposLicencias", w_params);
                foreach (DataRow dr in dt.Rows)
                {
                    list.Add(new TiposLicencias(Convert.ToInt32(dr["TipoLicencia_ID"]), Convert.ToString(dr["Nombre"])));
                }

                return list;
            } // End Read

            public int Update()
            {
                Hashtable m_params = new Hashtable();
                Hashtable w_params = new Hashtable();
                w_params.Add("TipoLicencia_ID", this.TipoLicencia_ID);
                m_params.Add("Nombre", this.Nombre);

                return DB.UpdateRow("TiposLicencias", m_params, w_params);
            } // End Update

            public int Delete()
            {
                Hashtable w_params = new Hashtable();
                w_params.Add("TipoLicencia_ID", this.TipoLicencia_ID);

                return DB.DeleteRow("TiposLicencias", w_params);
            }

        } //End Class TiposLicencias

        public class TiposMantenimientos
        {

            public TiposMantenimientos()
            {
            }

            public TiposMantenimientos(int tipomantenimiento_id, string nombre)
            {
                this.TipoMantenimiento_ID = tipomantenimiento_id;
                this.Nombre = nombre;
            }

            private int _TipoMantenimiento_ID;
            public int TipoMantenimiento_ID
            {
                get { return _TipoMantenimiento_ID; }
                set { _TipoMantenimiento_ID = value; }
            }

            private string _Nombre;
            public string Nombre
            {
                get { return _Nombre; }
                set { _Nombre = value; }
            }

            public int Create(bool IsIdentityInsert)
            {
                if (!IsIdentityInsert) return Create();

                Hashtable m_params = new Hashtable();
                m_params.Add("TipoMantenimiento_ID", this.TipoMantenimiento_ID);
                m_params.Add("Nombre", this.Nombre);

                return DB.IdentityInsertRow("TiposMantenimientos", m_params);
            } // End Create

            public int Create()
            {
                Hashtable m_params = new Hashtable();
                m_params.Add("Nombre", this.Nombre);

                return DB.InsertRow("TiposMantenimientos", m_params);
            } // End Create

            public static List<TiposMantenimientos> Read()
            {
                List<TiposMantenimientos> list = new List<TiposMantenimientos>();
                DataTable dt = DB.Select("TiposMantenimientos");
                foreach (DataRow dr in dt.Rows)
                {
                    list.Add(new TiposMantenimientos(Convert.ToInt32(dr["TipoMantenimiento_ID"]), Convert.ToString(dr["Nombre"])));
                }

                return list;
            } // End Read

            public static TiposMantenimientos Read(int tipomantenimiento_id)
            {
                Hashtable w_params = new Hashtable();
                w_params.Add("TipoMantenimiento_ID", tipomantenimiento_id);
                DataTable dt = DB.Select("TiposMantenimientos", w_params);
                if (dt.Rows.Count == 0)
                {
                    throw new Exception("No existe TiposMantenimientos con los criterios de búsqueda especificados.");
                }
                DataRow dr = dt.Rows[0];
                return new TiposMantenimientos(Convert.ToInt32(dr["TipoMantenimiento_ID"]), Convert.ToString(dr["Nombre"]));
            } // End Read

            public int Update()
            {
                Hashtable m_params = new Hashtable();
                Hashtable w_params = new Hashtable();
                w_params.Add("TipoMantenimiento_ID", this.TipoMantenimiento_ID);
                m_params.Add("Nombre", this.Nombre);

                return DB.UpdateRow("TiposMantenimientos", m_params, w_params);
            } // End Update

            public int Delete()
            {
                Hashtable w_params = new Hashtable();
                w_params.Add("TipoMantenimiento_ID", this.TipoMantenimiento_ID);

                return DB.DeleteRow("TiposMantenimientos", w_params);
            } // End Delete

        } //End Class TiposMantenimientos

        public class TiposMovimientosInventario
        {

            public TiposMovimientosInventario()
            {
            }

            public TiposMovimientosInventario(int tipomovimientoinventario_id, string nombre)
            {
                this.TipoMovimientoInventario_ID = tipomovimientoinventario_id;
                this.Nombre = nombre;
            }

            private int _TipoMovimientoInventario_ID;
            public int TipoMovimientoInventario_ID
            {
                get { return _TipoMovimientoInventario_ID; }
                set { _TipoMovimientoInventario_ID = value; }
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

                return DB.InsertRow("TiposMovimientosInventario", m_params);
            } // End Create

            public static List<TiposMovimientosInventario> Read()
            {
                List<TiposMovimientosInventario> list = new List<TiposMovimientosInventario>();
                DataTable dt = DB.Select("TiposMovimientosInventario");
                foreach (DataRow dr in dt.Rows)
                {
                    list.Add(new TiposMovimientosInventario(Convert.ToInt32(dr["TipoMovimientoInventario_ID"]), Convert.ToString(dr["Nombre"])));
                }

                return list;
            } // End Read

            public static TiposMovimientosInventario Read(int tipomovimientoinventario_id)
            {
                Hashtable w_params = new Hashtable();
                w_params.Add("TipoMovimientoInventario_ID", tipomovimientoinventario_id);
                DataTable dt = DB.Select("TiposMovimientosInventario", w_params);
                if (dt.Rows.Count == 0)
                {
                    throw new Exception("No existe TiposMovimientosInventario con los criterios de búsqueda especificados.");
                }
                DataRow dr = dt.Rows[0];
                return new TiposMovimientosInventario(Convert.ToInt32(dr["TipoMovimientoInventario_ID"]), Convert.ToString(dr["Nombre"]));
            } // End Read

            public int Update()
            {
                Hashtable m_params = new Hashtable();
                Hashtable w_params = new Hashtable();
                w_params.Add("TipoMovimientoInventario_ID", this.TipoMovimientoInventario_ID);
                m_params.Add("Nombre", this.Nombre);

                return DB.UpdateRow("TiposMovimientosInventario", m_params, w_params);
            } // End Update

            public int Delete()
            {
                Hashtable w_params = new Hashtable();
                w_params.Add("TipoMovimientoInventario_ID", this.TipoMovimientoInventario_ID);

                return DB.DeleteRow("TiposMovimientosInventario", w_params);
            } // End Delete

        } //End Class TiposMovimientosInventario

        public class TiposRefacciones
        {

            public TiposRefacciones()
            {
            }

            public TiposRefacciones(int tiporefaccion_id, int familia_id, string nombre)
            {
                this.TipoRefaccion_ID = tiporefaccion_id;
                this.Familia_ID = familia_id;
                this.Nombre = nombre;
            }

            private int _TipoRefaccion_ID;
            public int TipoRefaccion_ID
            {
                get { return _TipoRefaccion_ID; }
                set { _TipoRefaccion_ID = value; }
            }

            private int _Familia_ID;
            public int Familia_ID
            {
                get { return _Familia_ID; }
                set { _Familia_ID = value; }
            }

            private string _Nombre;
            public string Nombre
            {
                get { return _Nombre; }
                set { _Nombre = value; }
            }

            public int Create(bool IsIdentityInsert)
            {
                Hashtable m_params = new Hashtable();
                m_params.Add("TipoRefaccion_ID", this.TipoRefaccion_ID);
                m_params.Add("Familia_ID", this.Familia_ID);
                m_params.Add("Nombre", this.Nombre);

                return DB.IdentityInsertRow("TiposRefacciones", m_params);
            } // End Create

            public int Create()
            {
                Hashtable m_params = new Hashtable();
                m_params.Add("Familia_ID", this.Familia_ID);
                m_params.Add("Nombre", this.Nombre);

                return DB.InsertRow("TiposRefacciones", m_params);
            } // End Create

            public static List<TiposRefacciones> Read()
            {
                List<TiposRefacciones> list = new List<TiposRefacciones>();
                DataTable dt = DB.Select("TiposRefacciones");
                foreach (DataRow dr in dt.Rows)
                {
                    list.Add(new TiposRefacciones(Convert.ToInt32(dr["TipoRefaccion_ID"]), Convert.ToInt32(dr["Familia_ID"]), Convert.ToString(dr["Nombre"])));
                }

                return list;
            } // End Read

            public static TiposRefacciones Read(int tiporefaccion_id)
            {
                Hashtable w_params = new Hashtable();
                w_params.Add("TipoRefaccion_ID", tiporefaccion_id);
                DataTable dt = DB.Select("TiposRefacciones", w_params);
                if (dt.Rows.Count == 0)
                {
                    throw new Exception("No existe TiposRefacciones con los criterios de búsqueda especificados.");
                }
                DataRow dr = dt.Rows[0];
                return new TiposRefacciones(Convert.ToInt32(dr["TipoRefaccion_ID"]), Convert.ToInt32(dr["Familia_ID"]), Convert.ToString(dr["Nombre"]));
            } // End Read

            public int Update()
            {
                Hashtable m_params = new Hashtable();
                Hashtable w_params = new Hashtable();
                w_params.Add("TipoRefaccion_ID", this.TipoRefaccion_ID);
                m_params.Add("Familia_ID", this.Familia_ID);
                m_params.Add("Nombre", this.Nombre);

                return DB.UpdateRow("TiposRefacciones", m_params, w_params);
            } // End Update

            public int Delete()
            {
                Hashtable w_params = new Hashtable();
                w_params.Add("TipoRefaccion_ID", this.TipoRefaccion_ID);

                return DB.DeleteRow("TiposRefacciones", w_params);
            } // End Delete

        } //End Class TiposRefacciones

        public class TiposServicios
        {

            public TiposServicios()
            {
            }

            public TiposServicios(int tiposervicio_id, string nombre, int? cuenta_id)
            {
                this.TipoServicio_ID = tiposervicio_id;
                this.Nombre = nombre;
                this.Cuenta_ID = cuenta_id;
            }

            private int _TipoServicio_ID;
            public int TipoServicio_ID
            {
                get { return _TipoServicio_ID; }
                set { _TipoServicio_ID = value; }
            }

            private string _Nombre;
            public string Nombre
            {
                get { return _Nombre; }
                set { _Nombre = value; }
            }

            private int? _Cuenta_ID;
            public int? Cuenta_ID
            {
                get { return _Cuenta_ID; }
                set { _Cuenta_ID = value; }
            }

            public int Create()
            {
                Hashtable m_params = new Hashtable();
                m_params.Add("Nombre", this.Nombre);
                m_params.Add("Cuenta_ID", this.Cuenta_ID);

                return DB.InsertRow("TiposServicios", m_params);
            } // End Create

            public static List<TiposServicios> Read()
            {
                List<TiposServicios> list = new List<TiposServicios>();
                DataTable dt = DB.Select("TiposServicios");
                foreach (DataRow dr in dt.Rows)
                {
                    list.Add(new TiposServicios(Convert.ToInt32(dr["TipoServicio_ID"]), Convert.ToString(dr["Nombre"]), DB.GetNullableInt32(dr["Cuenta_ID"])));
                }

                return list;
            } // End Read

            public static TiposServicios Read(int tiposervicio_id)
            {
                Hashtable w_params = new Hashtable();
                w_params.Add("TipoServicio_ID", tiposervicio_id);
                DataTable dt = DB.Select("TiposServicios", w_params);
                if (dt.Rows.Count == 0)
                {
                    throw new Exception("No existe TiposServicios con los criterios de búsqueda especificados.");
                }
                DataRow dr = dt.Rows[0];
                return new TiposServicios(Convert.ToInt32(dr["TipoServicio_ID"]), Convert.ToString(dr["Nombre"]), DB.GetNullableInt32(dr["Cuenta_ID"]));
            } // End Read

            public int Update()
            {
                Hashtable m_params = new Hashtable();
                Hashtable w_params = new Hashtable();
                w_params.Add("TipoServicio_ID", this.TipoServicio_ID);
                m_params.Add("Nombre", this.Nombre);
                m_params.Add("Cuenta_ID", this.Cuenta_ID);

                return DB.UpdateRow("TiposServicios", m_params, w_params);
            } // End Update

            public int Delete()
            {
                Hashtable w_params = new Hashtable();
                w_params.Add("TipoServicio_ID", this.TipoServicio_ID);

                return DB.DeleteRow("TiposServicios", w_params);
            } // End Delete

        } //End Class TiposServicios

        public class TiposServiciosConductores
        {

            public TiposServiciosConductores()
            {
            }

            public TiposServiciosConductores(int tiposervicioconductor_id, int? comisionservicio_id, int? cuenta_id, int estatustiposervicioconductor_id, string nombre, decimal? precio, bool esvalidocarrera, bool esexclusivoconductor, bool esesquemaporcentual)
            {
                this.TipoServicioConductor_ID = tiposervicioconductor_id;
                this.ComisionServicio_ID = comisionservicio_id;
                this.Cuenta_ID = cuenta_id;
                this.EstatusTipoServicioConductor_ID = estatustiposervicioconductor_id;
                this.Nombre = nombre;
                this.Precio = precio;
                this.EsValidoCarrera = esvalidocarrera;
                this.EsExclusivoConductor = esexclusivoconductor;
                this.EsEsquemaPorcentual = esesquemaporcentual;
            }

            private int _TipoServicioConductor_ID;
            public int TipoServicioConductor_ID
            {
                get { return _TipoServicioConductor_ID; }
                set { _TipoServicioConductor_ID = value; }
            }

            private int? _ComisionServicio_ID;
            public int? ComisionServicio_ID
            {
                get { return _ComisionServicio_ID; }
                set { _ComisionServicio_ID = value; }
            }

            private int? _Cuenta_ID;
            public int? Cuenta_ID
            {
                get { return _Cuenta_ID; }
                set { _Cuenta_ID = value; }
            }

            private int _EstatusTipoServicioConductor_ID;
            public int EstatusTipoServicioConductor_ID
            {
                get { return _EstatusTipoServicioConductor_ID; }
                set { _EstatusTipoServicioConductor_ID = value; }
            }

            private string _Nombre;
            public string Nombre
            {
                get { return _Nombre; }
                set { _Nombre = value; }
            }

            private decimal? _Precio;
            public decimal? Precio
            {
                get { return _Precio; }
                set { _Precio = value; }
            }

            private bool _EsValidoCarrera;
            public bool EsValidoCarrera
            {
                get { return _EsValidoCarrera; }
                set { _EsValidoCarrera = value; }
            }

            private bool _EsExclusivoConductor;
            public bool EsExclusivoConductor
            {
                get { return _EsExclusivoConductor; }
                set { _EsExclusivoConductor = value; }
            }

            private bool _EsEsquemaPorcentual;
            public bool EsEsquemaPorcentual
            {
                get { return _EsEsquemaPorcentual; }
                set { _EsEsquemaPorcentual = value; }
            }

            public int Create()
            {
                Hashtable m_params = new Hashtable();
                m_params.Add("ComisionServicio_ID", this.ComisionServicio_ID);
                m_params.Add("Cuenta_ID", this.Cuenta_ID);
                m_params.Add("EstatusTipoServicioConductor_ID", this.EstatusTipoServicioConductor_ID);
                m_params.Add("Nombre", this.Nombre);
                m_params.Add("Precio", this.Precio);
                m_params.Add("EsValidoCarrera", this.EsValidoCarrera);
                m_params.Add("EsExclusivoConductor", this.EsExclusivoConductor);
                m_params.Add("EsEsquemaPorcentual", this.EsEsquemaPorcentual);

                return DB.InsertRow("TiposServiciosConductores", m_params);
            } // End Create

            public static List<TiposServiciosConductores> Read()
            {
                List<TiposServiciosConductores> list = new List<TiposServiciosConductores>();
                DataTable dt = DB.Select("TiposServiciosConductores");
                foreach (DataRow dr in dt.Rows)
                {
                    list.Add(new TiposServiciosConductores(Convert.ToInt32(dr["TipoServicioConductor_ID"]), DB.GetNullableInt32(dr["ComisionServicio_ID"]), DB.GetNullableInt32(dr["Cuenta_ID"]), Convert.ToInt32(dr["EstatusTipoServicioConductor_ID"]), Convert.ToString(dr["Nombre"]), DB.GetNullableDecimal(dr["Precio"]), Convert.ToBoolean(dr["EsValidoCarrera"]), Convert.ToBoolean(dr["EsExclusivoConductor"]), Convert.ToBoolean(dr["EsEsquemaPorcentual"])));
                }

                return list;
            } // End Read

            public static TiposServiciosConductores Read(int tiposervicioconductor_id)
            {
                Hashtable w_params = new Hashtable();
                w_params.Add("TipoServicioConductor_ID", tiposervicioconductor_id);
                DataTable dt = DB.Select("TiposServiciosConductores", w_params);
                if (dt.Rows.Count == 0)
                {
                    throw new Exception("No existe TiposServiciosConductores con id = los criterios de búsqueda especificados.");
                }
                DataRow dr = dt.Rows[0];
                return new TiposServiciosConductores(Convert.ToInt32(dr["TipoServicioConductor_ID"]), DB.GetNullableInt32(dr["ComisionServicio_ID"]), DB.GetNullableInt32(dr["Cuenta_ID"]), Convert.ToInt32(dr["EstatusTipoServicioConductor_ID"]), Convert.ToString(dr["Nombre"]), DB.GetNullableDecimal(dr["Precio"]), Convert.ToBoolean(dr["EsValidoCarrera"]), Convert.ToBoolean(dr["EsExclusivoConductor"]), Convert.ToBoolean(dr["EsEsquemaPorcentual"]));
            } // End Read

            public int Update()
            {
                Hashtable m_params = new Hashtable();
                Hashtable w_params = new Hashtable();
                w_params.Add("TipoServicioConductor_ID", this.TipoServicioConductor_ID);
                m_params.Add("ComisionServicio_ID", this.ComisionServicio_ID);
                m_params.Add("Cuenta_ID", this.Cuenta_ID);
                m_params.Add("EstatusTipoServicioConductor_ID", this.EstatusTipoServicioConductor_ID);
                m_params.Add("Nombre", this.Nombre);
                m_params.Add("Precio", this.Precio);
                m_params.Add("EsValidoCarrera", this.EsValidoCarrera);
                m_params.Add("EsExclusivoConductor", this.EsExclusivoConductor);
                m_params.Add("EsEsquemaPorcentual", this.EsEsquemaPorcentual);

                return DB.UpdateRow("TiposServiciosConductores", m_params, w_params);
            } // End Update

            public int Delete()
            {
                Hashtable w_params = new Hashtable();
                w_params.Add("TipoServicioConductor_ID", this.TipoServicioConductor_ID);

                return DB.DeleteRow("TiposServiciosConductores", w_params);
            } // End Delete

        } //End Class TiposServiciosConductores

        public class TiposServiciosMantenimientos
        {

            public TiposServiciosMantenimientos()
            {
            }

            public TiposServiciosMantenimientos(int tiposerviciomantenimiento_id, string nombre)
            {
                this.TipoServicioMantenimiento_ID = tiposerviciomantenimiento_id;
                this.Nombre = nombre;
            }

            private int _TipoServicioMantenimiento_ID;
            public int TipoServicioMantenimiento_ID
            {
                get { return _TipoServicioMantenimiento_ID; }
                set { _TipoServicioMantenimiento_ID = value; }
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

                return DB.InsertRow("TiposServiciosMantenimientos", m_params);
            } // End Create

            public static List<TiposServiciosMantenimientos> Read()
            {
                List<TiposServiciosMantenimientos> list = new List<TiposServiciosMantenimientos>();
                DataTable dt = DB.Select("TiposServiciosMantenimientos");
                foreach (DataRow dr in dt.Rows)
                {
                    list.Add(new TiposServiciosMantenimientos(Convert.ToInt32(dr["TipoServicioMantenimiento_ID"]), Convert.ToString(dr["Nombre"])));
                }

                return list;
            } // End Read

            public static TiposServiciosMantenimientos Read(int tiposerviciomantenimiento_id)
            {
                Hashtable w_params = new Hashtable();
                w_params.Add("TipoServicioMantenimiento_ID", tiposerviciomantenimiento_id);
                DataTable dt = DB.Select("TiposServiciosMantenimientos", w_params);
                if (dt.Rows.Count == 0)
                {
                    throw new Exception("No existe TiposServiciosMantenimientos con los criterios de búsqueda especificados.");
                }
                DataRow dr = dt.Rows[0];
                return new TiposServiciosMantenimientos(Convert.ToInt32(dr["TipoServicioMantenimiento_ID"]), Convert.ToString(dr["Nombre"]));
            } // End Read

            public int Update()
            {
                Hashtable m_params = new Hashtable();
                Hashtable w_params = new Hashtable();
                w_params.Add("TipoServicioMantenimiento_ID", this.TipoServicioMantenimiento_ID);
                m_params.Add("Nombre", this.Nombre);

                return DB.UpdateRow("TiposServiciosMantenimientos", m_params, w_params);
            } // End Update

            public int Delete()
            {
                Hashtable w_params = new Hashtable();
                w_params.Add("TipoServicioMantenimiento_ID", this.TipoServicioMantenimiento_ID);

                return DB.DeleteRow("TiposServiciosMantenimientos", w_params);
            } // End Delete

        } //End Class TiposServiciosMantenimientos

        public class TiposVenta
        {
            public TiposVenta()
            {
            }

            public TiposVenta(int tipoventa_id, int? comisionservicio_id, string nombre)
            {
            }

            private int _TipoVenta_ID;
            public int TipoVenta_ID
            {
                get { return _TipoVenta_ID; }
                set { _TipoVenta_ID = value; }
            }

            private int? _ComisionServicio_ID;
            public int? ComisionServicio_ID
            {
                get { return _ComisionServicio_ID; }
                set { _ComisionServicio_ID = value; }
            }

            private string _Nombre;
            public string Nombre
            {
                get { return _Nombre; }
                set { _Nombre = value; }
            }

            //private ComisionesServicios _ComisionesServicios;
            //public ComisionesServicios ComisionesServicios
            //{
            //    get 
            //    {
            //        List<ComisionesServicios> list = new List<ComisionesServicios>();
            //        Hashtable w_params = new Hashtable();
            //        w_params.Add("ComisionServicio_ID", comisionservicio_id);
            //        DataTable dt = DB.Select("ComisionesServicios", w_params);
            //        foreach (DataRow dr in dt.Rows)
            //        {
            //            list.Add(new ComisionesServicios(Convert.ToInt32(dr["ComisionServicio_ID"]), Convert.ToInt32(dr["Comisionista_ID"]), Convert.ToInt32(dr["TipoComision_ID"]), Convert.ToDecimal(dr["Monto"])));
            //        }

            //        return list;
            //    }
            //}

            public int Create()
            {
                Hashtable m_params = new Hashtable();
                m_params.Add("ComisionServicio_ID", this.ComisionServicio_ID);
                m_params.Add("Nombre", this.Nombre);

                return DB.InsertRow("TiposZonas", m_params);
            } // End Create

            public static List<TiposVenta> Read()
            {
                List<TiposVenta> list = new List<TiposVenta>();
                DataTable dt = DB.Select("TiposVenta");
                foreach (DataRow dr in dt.Rows)
                {
                    list.Add(new TiposVenta(Convert.ToInt32(dr["TipoVenta_ID"]), DB.GetNullableInt32(dr["ComisionServicio_ID"]), Convert.ToString(dr["Nombre"])));
                }

                return list;
            } // End Read

            public static TiposVenta Read(int tipoventa_id)
            {
                List<TiposVenta> list = new List<TiposVenta>();

                Hashtable w_params = new Hashtable();
                w_params.Add("TipoVenta_ID", tipoventa_id);
                DataTable dt = DB.Select("TiposVenta", w_params);

                if (dt.Rows.Count == 0)
                {
                    throw new Exception(String.Format("No existen tipos de venta con el TipoVenta_ID = {0}", tipoventa_id));
                }

                DataRow dr = dt.Rows[0];
                return new TiposVenta(Convert.ToInt32(dr["TipoVenta_ID"]), DB.GetNullableInt32(dr["ComisionServicio_ID"]), Convert.ToString(dr["Nombre"]));

            } // End Read

            public int Update()
            {
                Hashtable m_params = new Hashtable();
                Hashtable w_params = new Hashtable();
                w_params.Add("TipoVenta_ID", this.TipoVenta_ID);
                m_params.Add("ComisionServicio_ID", this.ComisionServicio_ID);
                m_params.Add("Nombre", this.Nombre);

                return DB.UpdateRow("TiposVenta", m_params, w_params);
            } // End Update

            public int Delete()
            {
                Hashtable w_params = new Hashtable();
                w_params.Add("TipoVenta_ID", this.TipoVenta_ID);

                return DB.DeleteRow("TiposVenta", w_params);
            } // End Delete

        } //End Class TiposVenta

        public class TiposZonas
        {

            public TiposZonas()
            {
            }

            public TiposZonas(int tipozona_id, string nombre, bool esacreditable)
            {
                this.TipoZona_ID = tipozona_id;
                this.Nombre = nombre;
                this.EsAcreditable = esacreditable;
            }

            private int _TipoZona_ID;
            public int TipoZona_ID
            {
                get { return _TipoZona_ID; }
                set { _TipoZona_ID = value; }
            }

            private string _Nombre;
            public string Nombre
            {
                get { return _Nombre; }
                set { _Nombre = value; }
            }

            private bool _EsAcreditable;
            public bool EsAcreditable
            {
                get { return _EsAcreditable; }
                set { _EsAcreditable = value; }
            }

            public int Create()
            {
                Hashtable m_params = new Hashtable();
                m_params.Add("Nombre", this.Nombre);
                m_params.Add("EsAcreditable", this.EsAcreditable);

                return DB.InsertRow("TiposZonas", m_params);
            } // End Create

            public static List<TiposZonas> Read()
            {
                List<TiposZonas> list = new List<TiposZonas>();
                DataTable dt = DB.Select("TiposZonas");
                foreach (DataRow dr in dt.Rows)
                {
                    list.Add(new TiposZonas(Convert.ToInt32(dr["TipoZona_ID"]), Convert.ToString(dr["Nombre"]), Convert.ToBoolean(dr["EsAcreditable"])));
                }

                return list;
            } // End Read

            public static TiposZonas Read(int tipozona_id)
            {
                Hashtable w_params = new Hashtable();
                w_params.Add("TipoZona_ID", tipozona_id);
                DataTable dt = DB.Select("TiposZonas", w_params);
                if (dt.Rows.Count == 0)
                {
                    throw new Exception("No existe TiposZonas con los criterios de búsqueda especificados.");
                }
                DataRow dr = dt.Rows[0];
                return new TiposZonas(Convert.ToInt32(dr["TipoZona_ID"]), Convert.ToString(dr["Nombre"]), Convert.ToBoolean(dr["EsAcreditable"]));
            } // End Read

            public int Update()
            {
                Hashtable m_params = new Hashtable();
                Hashtable w_params = new Hashtable();
                w_params.Add("TipoZona_ID", this.TipoZona_ID);
                m_params.Add("Nombre", this.Nombre);
                m_params.Add("EsAcreditable", this.EsAcreditable);

                return DB.UpdateRow("TiposZonas", m_params, w_params);
            } // End Update

            public int Delete()
            {
                Hashtable w_params = new Hashtable();
                w_params.Add("TipoZona_ID", this.TipoZona_ID);

                return DB.DeleteRow("TiposZonas", w_params);
            } // End Delete

        } //End Class TiposZonas

        public class Unidades
        {

            public Unidades()
            {
            }

            public Unidades(int unidad_id, int empresa_id, int estacion_id, int numeroeconomico, int modelounidad_id, decimal preciolista, 
                string numeroserie, string numeroseriemotor, string tarjetacirculacion, int estatusunidad_id, int locacionunidad_id, 
                string placas, int kilometraje, int propietario_id, int? arrendamiento_id, int? concesion_id, int referencia_id)
            {
                this.Unidad_ID = unidad_id;
                this.Empresa_ID = empresa_id;
                this.Estacion_ID = estacion_id;
                this.NumeroEconomico = numeroeconomico;
                this.ModeloUnidad_ID = modelounidad_id;
                this.PrecioLista = preciolista;
                this.NumeroSerie = numeroserie;
                this.NumeroSerieMotor = numeroseriemotor;
                this.TarjetaCirculacion = tarjetacirculacion;
                this.EstatusUnidad_ID = estatusunidad_id;
                this.LocacionUnidad_ID = locacionunidad_id;
                this.Placas = placas;
                this.Kilometraje = kilometraje;
                this.Propietario_ID = propietario_id;
                this.Arrendamiento_ID = arrendamiento_id;
                this.Concesion_ID = concesion_id;
                this.Referencia_ID = referencia_id;
            }

            private int _Unidad_ID;
            public int Unidad_ID
            {
                get { return _Unidad_ID; }
                set { _Unidad_ID = value; }
            }

            private int _Empresa_ID;
            public int Empresa_ID
            {
                get { return _Empresa_ID; }
                set { _Empresa_ID = value; }
            }

            private int _Estacion_ID;
            public int Estacion_ID
            {
                get { return _Estacion_ID; }
                set { _Estacion_ID = value; }
            }

            private int _NumeroEconomico;
            public int NumeroEconomico
            {
                get { return _NumeroEconomico; }
                set { _NumeroEconomico = value; }
            }

            private int _ModeloUnidad_ID;
            public int ModeloUnidad_ID
            {
                get { return _ModeloUnidad_ID; }
                set { _ModeloUnidad_ID = value; }
            }

            private decimal _PrecioLista;
            public decimal PrecioLista
            {
                get { return _PrecioLista; }
                set { _PrecioLista = value; }
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

            private int _EstatusUnidad_ID;
            public int EstatusUnidad_ID
            {
                get { return _EstatusUnidad_ID; }
                set { _EstatusUnidad_ID = value; }
            }

            private int _LocacionUnidad_ID;
            public int LocacionUnidad_ID
            {
                get { return _LocacionUnidad_ID; }
                set { _LocacionUnidad_ID = value; }
            }

            private string _Placas;
            public string Placas
            {
                get { return _Placas; }
                set { _Placas = value; }
            }

            private int _Kilometraje;
            public int Kilometraje
            {
                get { return _Kilometraje; }
                set { _Kilometraje = value; }
            }

            private int _Propietario_ID;
            public int Propietario_ID
            {
                get { return _Propietario_ID; }
                set { _Propietario_ID = value; }
            }

            private int? _Arrendamiento_ID;
            public int? Arrendamiento_ID
            {
                get { return _Arrendamiento_ID; }
                set { _Arrendamiento_ID = value; }
            }

            private int? _Concesion_ID;
            public int? Concesion_ID
            {
                get { return _Concesion_ID; }
                set { _Concesion_ID = value; }
            }

            private int _Referencia_ID;
            public int Referencia_ID
            {
                get { return _Referencia_ID; }
                set { _Referencia_ID = value; }
            }

            public int Create()
            {
                Hashtable m_params = new Hashtable();
                m_params.Add("Empresa_ID", this.Empresa_ID);
                m_params.Add("Estacion_ID", this.Estacion_ID);
                m_params.Add("NumeroEconomico", this.NumeroEconomico);
                m_params.Add("ModeloUnidad_ID", this.ModeloUnidad_ID);
                m_params.Add("PrecioLista", this.PrecioLista);
                m_params.Add("NumeroSerie", this.NumeroSerie);
                m_params.Add("NumeroSerieMotor", this.NumeroSerieMotor);
                m_params.Add("TarjetaCirculacion", this.TarjetaCirculacion);
                m_params.Add("EstatusUnidad_ID", this.EstatusUnidad_ID);
                m_params.Add("LocacionUnidad_ID", this.LocacionUnidad_ID);
                m_params.Add("Placas", this.Placas);
                m_params.Add("Kilometraje", this.Kilometraje);
                m_params.Add("Propietario_ID", this.Propietario_ID);
                m_params.Add("Arrendamiento_ID", this.Arrendamiento_ID);
                m_params.Add("Concesion_ID", this.Concesion_ID);
                m_params.Add("Referencia_ID", this.Referencia_ID);

                return DB.InsertRow("Unidades", m_params);
            } // End Create

            public static List<Unidades> Read()
            {
                List<Unidades> list = new List<Unidades>();
                DataTable dt = DB.Select("Unidades");
                foreach (DataRow dr in dt.Rows)
                {
                    list.Add(new Unidades(Convert.ToInt32(dr["Unidad_ID"]), Convert.ToInt32(dr["Empresa_ID"]), Convert.ToInt32(dr["Estacion_ID"]), 
                        Convert.ToInt32(dr["NumeroEconomico"]), Convert.ToInt32(dr["ModeloUnidad_ID"]), Convert.ToDecimal(dr["PrecioLista"]), 
                            Convert.ToString(dr["NumeroSerie"]), Convert.ToString(dr["NumeroSerieMotor"]), Convert.ToString(dr["TarjetaCirculacion"]), 
                                Convert.ToInt32(dr["EstatusUnidad_ID"]), Convert.ToInt32(dr["LocacionUnidad_ID"]), Convert.ToString(dr["Placas"]), 
                                    Convert.ToInt32(dr["Kilometraje"]), Convert.ToInt32(dr["Propietario_ID"]), DB.GetNullableInt32(dr["Arrendamiento_ID"]),
                                        DB.GetNullableInt32(dr["Concesion_ID"]), Convert.ToInt32(dr["Referencia_ID"])));
                }

                return list;
            } // End Read

            public static Unidades Read(int unidad_id)
            {                
                Hashtable w_params = new Hashtable();
                w_params.Add("Unidad_ID", unidad_id);
                DataTable dt = DB.Select("Unidades", w_params);

                if (dt.Rows.Count == 0)
                {
                    throw new Exception("No existe Unidades con los criterios de búsqueda especificados.");
                }

                DataRow dr = dt.Rows[0];
                return new Unidades(Convert.ToInt32(dr["Unidad_ID"]), Convert.ToInt32(dr["Empresa_ID"]), Convert.ToInt32(dr["Estacion_ID"]),
                        Convert.ToInt32(dr["NumeroEconomico"]), Convert.ToInt32(dr["ModeloUnidad_ID"]), Convert.ToDecimal(dr["PrecioLista"]),
                            Convert.ToString(dr["NumeroSerie"]), Convert.ToString(dr["NumeroSerieMotor"]), Convert.ToString(dr["TarjetaCirculacion"]),
                                Convert.ToInt32(dr["EstatusUnidad_ID"]), Convert.ToInt32(dr["LocacionUnidad_ID"]), Convert.ToString(dr["Placas"]),
                                    Convert.ToInt32(dr["Kilometraje"]), Convert.ToInt32(dr["Propietario_ID"]), DB.GetNullableInt32(dr["Arrendamiento_ID"]),
                                        DB.GetNullableInt32(dr["Concesion_ID"]), Convert.ToInt32(dr["Referencia_ID"]));
            } // End Read

            public static Unidades Read(params KeyValuePair<string, object>[] args)
            {                
                DataTable dt = DB.Read("Unidades", args);

                if (dt.Rows.Count == 0)
                {
                    //throw new Exception("No existe Unidades con los criterios de búsqueda especificados.");
                    return null;
                }

                DataRow dr = dt.Rows[0];
                return new Unidades(Convert.ToInt32(dr["Unidad_ID"]), Convert.ToInt32(dr["Empresa_ID"]), Convert.ToInt32(dr["Estacion_ID"]), 
                    Convert.ToInt32(dr["NumeroEconomico"]), Convert.ToInt32(dr["ModeloUnidad_ID"]), Convert.ToDecimal(dr["PrecioLista"]), 
                    Convert.ToString(dr["NumeroSerie"]), Convert.ToString(dr["NumeroSerieMotor"]), Convert.ToString(dr["TarjetaCirculacion"]), 
                    Convert.ToInt32(dr["EstatusUnidad_ID"]), Convert.ToInt32(dr["LocacionUnidad_ID"]), Convert.ToString(dr["Placas"]), 
                    Convert.ToInt32(dr["Kilometraje"]), Convert.ToInt32(dr["Propietario_ID"]), DB.GetNullableInt32(dr["Arrendamiento_ID"]),
                    DB.GetNullableInt32(dr["Concesion_ID"]), Convert.ToInt32(dr["Referencia_ID"]));                
            }

            public int Update()
            {
                Hashtable m_params = new Hashtable();
                Hashtable w_params = new Hashtable();
                w_params.Add("Unidad_ID", this.Unidad_ID);
                m_params.Add("Empresa_ID", this.Empresa_ID);
                m_params.Add("Estacion_ID", this.Estacion_ID);
                m_params.Add("NumeroEconomico", this.NumeroEconomico);
                m_params.Add("ModeloUnidad_ID", this.ModeloUnidad_ID);
                m_params.Add("PrecioLista", this.PrecioLista);
                m_params.Add("NumeroSerie", this.NumeroSerie);
                m_params.Add("NumeroSerieMotor", this.NumeroSerieMotor);
                m_params.Add("TarjetaCirculacion", this.TarjetaCirculacion);
                m_params.Add("EstatusUnidad_ID", this.EstatusUnidad_ID);
                m_params.Add("LocacionUnidad_ID", this.LocacionUnidad_ID);
                m_params.Add("Placas", this.Placas);
                m_params.Add("Kilometraje", this.Kilometraje);
                m_params.Add("Propietario_ID", this.Propietario_ID);
                m_params.Add("Arrendamiento_ID", this.Arrendamiento_ID);
                m_params.Add("Concesion_ID", this.Concesion_ID);
                m_params.Add("Referencia_ID", this.Referencia_ID);

                return DB.UpdateRow("Unidades", m_params, w_params);
            } // End Update

            public int Delete()
            {
                Hashtable w_params = new Hashtable();
                w_params.Add("Unidad_ID", this.Unidad_ID);

                return DB.DeleteRow("Unidades", w_params);
            }            
        } //End Class Unidades

        public class Unidades_Kilometrajes
        {

            public Unidades_Kilometrajes()
            {
            }

            public Unidades_Kilometrajes(int unidad_kilometraje_id, int unidad_id, int? conductor_id, int kilometraje, DateTime fecha)
            {
                this.Unidad_Kilometraje_ID = unidad_kilometraje_id;
                this.Unidad_ID = unidad_id;
                this.Conductor_ID = conductor_id;
                this.Kilometraje = kilometraje;
                this.Fecha = fecha;
            }

            private int _Unidad_Kilometraje_ID;
            public int Unidad_Kilometraje_ID
            {
                get { return _Unidad_Kilometraje_ID; }
                set { _Unidad_Kilometraje_ID = value; }
            }

            private int _Unidad_ID;
            public int Unidad_ID
            {
                get { return _Unidad_ID; }
                set { _Unidad_ID = value; }
            }

            private int? _Conductor_ID;
            public int? Conductor_ID
            {
                get { return _Conductor_ID; }
                set { _Conductor_ID = value; }
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
                m_params.Add("Unidad_ID", this.Unidad_ID);
                m_params.Add("Conductor_ID", this.Conductor_ID);
                m_params.Add("Kilometraje", this.Kilometraje);
                m_params.Add("Fecha", this.Fecha);

                return DB.InsertRow("Unidades_Kilometrajes", m_params);
            } // End Create

            public static List<Unidades_Kilometrajes> Read()
            {
                List<Unidades_Kilometrajes> list = new List<Unidades_Kilometrajes>();
                DataTable dt = DB.Select("Unidades_Kilometrajes");
                foreach (DataRow dr in dt.Rows)
                {
                    list.Add(new Unidades_Kilometrajes(Convert.ToInt32(dr["Unidad_Kilometraje_ID"]), Convert.ToInt32(dr["Unidad_ID"]), 
                        DB.GetNullableInt32(dr["Conductor_ID"]), Convert.ToInt32(dr["Kilometraje"]), Convert.ToDateTime(dr["Fecha"])));
                }

                return list;
            } // End Read

            public static List<Unidades_Kilometrajes> Read(int unidad_kilometraje_id)
            {
                List<Unidades_Kilometrajes> list = new List<Unidades_Kilometrajes>();
                Hashtable w_params = new Hashtable();
                w_params.Add("Unidad_Kilometraje_ID", unidad_kilometraje_id);
                DataTable dt = DB.Select("Unidades_Kilometrajes", w_params);
                foreach (DataRow dr in dt.Rows)
                {
                    list.Add(new Unidades_Kilometrajes(Convert.ToInt32(dr["Unidad_Kilometraje_ID"]), Convert.ToInt32(dr["Unidad_ID"]),
                        DB.GetNullableInt32(dr["Conductor_ID"]), Convert.ToInt32(dr["Kilometraje"]), Convert.ToDateTime(dr["Fecha"])));
                }

                return list;
            } // End Read

            public int Update()
            {
                Hashtable m_params = new Hashtable();
                Hashtable w_params = new Hashtable();
                w_params.Add("Unidad_Kilometraje_ID", this.Unidad_Kilometraje_ID);
                m_params.Add("Unidad_ID", this.Unidad_ID);
                m_params.Add("Conductor_ID", this.Conductor_ID);
                m_params.Add("Kilometraje", this.Kilometraje);
                m_params.Add("Fecha", this.Fecha);

                return DB.UpdateRow("Unidades_Kilometrajes", m_params, w_params);
            } // End Update

            public int Delete()
            {
                Hashtable w_params = new Hashtable();
                w_params.Add("Unidad_Kilometraje_ID", this.Unidad_Kilometraje_ID);

                return DB.DeleteRow("Unidades_Kilometrajes", w_params);
            }

        } //End Class Unidades_Kilometrajes

        public class Unidades_Locaciones
        {

            public Unidades_Locaciones()
            {
            }

            public Unidades_Locaciones(int unidad_locacion_id, int unidad_id, int locacionunidad_id, DateTime fecha)
            {
                this.Unidad_Locacion_ID = unidad_locacion_id;
                this.Unidad_ID = unidad_id;
                this.LocacionUnidad_ID = locacionunidad_id;
                this.Fecha = fecha;
            }

            private int _Unidad_Locacion_ID;
            public int Unidad_Locacion_ID
            {
                get { return _Unidad_Locacion_ID; }
                set { _Unidad_Locacion_ID = value; }
            }

            private int _Unidad_ID;
            public int Unidad_ID
            {
                get { return _Unidad_ID; }
                set { _Unidad_ID = value; }
            }

            private int _LocacionUnidad_ID;
            public int LocacionUnidad_ID
            {
                get { return _LocacionUnidad_ID; }
                set { _LocacionUnidad_ID = value; }
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
                m_params.Add("Unidad_ID", this.Unidad_ID);
                m_params.Add("LocacionUnidad_ID", this.LocacionUnidad_ID);
                m_params.Add("Fecha", this.Fecha);

                return DB.InsertRow("Unidades_Locaciones", m_params);
            } // End Create

            public static List<Unidades_Locaciones> Read()
            {
                List<Unidades_Locaciones> list = new List<Unidades_Locaciones>();
                DataTable dt = DB.Select("Unidades_Locaciones");
                foreach (DataRow dr in dt.Rows)
                {
                    list.Add(new Unidades_Locaciones(Convert.ToInt32(dr["Unidad_Locacion_ID"]), Convert.ToInt32(dr["Unidad_ID"]), Convert.ToInt32(dr["LocacionUnidad_ID"]), Convert.ToDateTime(dr["Fecha"])));
                }

                return list;
            } // End Read

            public static Unidades_Locaciones Read(int unidad_locacion_id)
            {
                Hashtable w_params = new Hashtable();
                w_params.Add("Unidad_Locacion_ID", unidad_locacion_id);
                DataTable dt = DB.Select("Unidades_Locaciones", w_params);
                if (dt.Rows.Count == 0)
                {
                    throw new Exception("No existe Unidades_Locaciones con los criterios de búsqueda especificados.");
                }
                DataRow dr = dt.Rows[0];
                return new Unidades_Locaciones(Convert.ToInt32(dr["Unidad_Locacion_ID"]), Convert.ToInt32(dr["Unidad_ID"]), Convert.ToInt32(dr["LocacionUnidad_ID"]), Convert.ToDateTime(dr["Fecha"]));
            } // End Read

            public int Update()
            {
                Hashtable m_params = new Hashtable();
                Hashtable w_params = new Hashtable();
                w_params.Add("Unidad_Locacion_ID", this.Unidad_Locacion_ID);
                m_params.Add("Unidad_ID", this.Unidad_ID);
                m_params.Add("LocacionUnidad_ID", this.LocacionUnidad_ID);
                m_params.Add("Fecha", this.Fecha);

                return DB.UpdateRow("Unidades_Locaciones", m_params, w_params);
            } // End Update

            public int Delete()
            {
                Hashtable w_params = new Hashtable();
                w_params.Add("Unidad_Locacion_ID", this.Unidad_Locacion_ID);

                return DB.DeleteRow("Unidades_Locaciones", w_params);
            } // End Delete

        } //End Class Unidades_Locaciones

        public class Usuarios
        {

            public Usuarios()
            {
            }

            public Usuarios(string usuario_id, string nombre, string apellidos, 
                string email, bool activo, byte[] pwd, 
                int? empresa_id, int? estacion_id)
            {
                this.Usuario_ID = usuario_id;
                this.Nombre = nombre;
                this.Apellidos = apellidos;
                this.Email = email;
                this.Activo = activo;
                this.pwd = pwd;
                this.Empresa_ID = empresa_id;
                this.Estacion_ID = estacion_id;
            }

            private string _Usuario_ID;
            public string Usuario_ID
            {
                get { return _Usuario_ID; }
                set { _Usuario_ID = value; }
            }

            private string _Nombre;
            public string Nombre
            {
                get { return _Nombre; }
                set { _Nombre = value; }
            }

            private string _Apellidos;
            public string Apellidos
            {
                get { return _Apellidos; }
                set { _Apellidos = value; }
            }

            private string _Email;
            public string Email
            {
                get { return _Email; }
                set { _Email = value; }
            }

            private bool _Activo;
            public bool Activo
            {
                get { return _Activo; }
                set { _Activo = value; }
            }

            private byte[] _pwd;
            public byte[] pwd
            {
                get { return _pwd; }
                set { _pwd = value; }
            }

            private int? _Empresa_ID;
            public int? Empresa_ID
            {
                get { return _Empresa_ID; }
                set { _Empresa_ID = value; }
            }

            private int? _Estacion_ID;
            public int? Estacion_ID
            {
                get { return _Estacion_ID; }
                set { _Estacion_ID = value; }
            }

            public int Create()
            {
                Hashtable m_params = new Hashtable();
                m_params.Add("Usuario_ID", this.Usuario_ID);
                m_params.Add("Nombre", this.Nombre);
                m_params.Add("Apellidos", this.Apellidos);
                m_params.Add("Email", this.Email);
                m_params.Add("Activo", this.Activo);
                m_params.Add("pwd", this.pwd);
                m_params.Add("Empresa_ID", this.Empresa_ID);
                m_params.Add("Estacion_ID", this.Estacion_ID);

                return DB.InsertRow("Usuarios", m_params);
            } // End Create

            public static List<Usuarios> Read()
            {
                List<Usuarios> list = new List<Usuarios>();
                DataTable dt = DB.Select("Usuarios");
                foreach (DataRow dr in dt.Rows)
                {
                    list.Add(new Usuarios(Convert.ToString(dr["Usuario_ID"]), Convert.ToString(dr["Nombre"]), Convert.ToString(dr["Apellidos"]), 
                        Convert.ToString(dr["Email"]), Convert.ToBoolean(dr["Activo"]), (byte[])(dr["pwd"]),
                        DB.GetNullableInt32(dr["Empresa_ID"]), DB.GetNullableInt32(dr["Estacion_ID"])));
                }

                return list;
            } // End Read

            public static List<Usuarios> Read(string usuario_id)
            {
                List<Usuarios> list = new List<Usuarios>();
                Hashtable w_params = new Hashtable();
                w_params.Add("Usuario_ID", usuario_id);
                DataTable dt = DB.Select("Usuarios", w_params);
                foreach (DataRow dr in dt.Rows)
                {
                    list.Add(new Usuarios(Convert.ToString(dr["Usuario_ID"]), Convert.ToString(dr["Nombre"]), Convert.ToString(dr["Apellidos"]),
                        Convert.ToString(dr["Email"]), Convert.ToBoolean(dr["Activo"]), (byte[])(dr["pwd"]),
                        DB.GetNullableInt32(dr["Empresa_ID"]), DB.GetNullableInt32(dr["Estacion_ID"])));
                }

                return list;
            } // End Read

            public int Update()
            {
                Hashtable m_params = new Hashtable();
                Hashtable w_params = new Hashtable();
                w_params.Add("Usuario_ID", this.Usuario_ID);
                m_params.Add("Nombre", this.Nombre);
                m_params.Add("Apellidos", this.Apellidos);
                m_params.Add("Email", this.Email);
                m_params.Add("Activo", this.Activo);
                m_params.Add("pwd", this.pwd);
                m_params.Add("Empresa_ID", this.Empresa_ID);
                m_params.Add("Estacion_ID", this.Estacion_ID);

                return DB.UpdateRow("Usuarios", m_params, w_params);
            } // End Update

            public int Delete()
            {
                Hashtable w_params = new Hashtable();
                w_params.Add("Usuario_ID", this.Usuario_ID);

                return DB.DeleteRow("Usuarios", w_params);
            }

        } //End Class Usuarios

        public class ValesPrepagados
        {

            public ValesPrepagados()
            {
            }

            public ValesPrepagados(string valeprepagado_id, int empresacliente_id, string usuario_id, int estatusvaleprepagado_id, int? ticket_id, int foliodiario, decimal denominacion, DateTime fechaemision, DateTime fechaexpiracion, DateTime? fechacanje)
            {
                this.ValePrepagado_ID = valeprepagado_id;
                this.EmpresaCliente_ID = empresacliente_id;
                this.Usuario_ID = usuario_id;
                this.EstatusValePrepagado_ID = estatusvaleprepagado_id;
                this.Ticket_ID = ticket_id;
                this.FolioDiario = foliodiario;
                this.Denominacion = denominacion;
                this.FechaEmision = fechaemision;
                this.FechaExpiracion = fechaexpiracion;
                this.FechaCanje = fechacanje;
            }

            private string _ValePrepagado_ID;
            public string ValePrepagado_ID
            {
                get { return _ValePrepagado_ID; }
                set { _ValePrepagado_ID = value; }
            }

            private int _EmpresaCliente_ID;
            public int EmpresaCliente_ID
            {
                get { return _EmpresaCliente_ID; }
                set { _EmpresaCliente_ID = value; }
            }

            private string _Usuario_ID;
            public string Usuario_ID
            {
                get { return _Usuario_ID; }
                set { _Usuario_ID = value; }
            }

            private int _EstatusValePrepagado_ID;
            public int EstatusValePrepagado_ID
            {
                get { return _EstatusValePrepagado_ID; }
                set { _EstatusValePrepagado_ID = value; }
            }

            private int? _Ticket_ID;
            public int? Ticket_ID
            {
                get { return _Ticket_ID; }
                set { _Ticket_ID = value; }
            }

            private int _FolioDiario;
            public int FolioDiario
            {
                get { return _FolioDiario; }
                set { _FolioDiario = value; }
            }

            private decimal _Denominacion;
            public decimal Denominacion
            {
                get { return _Denominacion; }
                set { _Denominacion = value; }
            }

            private DateTime _FechaEmision;
            public DateTime FechaEmision
            {
                get { return _FechaEmision; }
                set { _FechaEmision = value; }
            }

            private DateTime _FechaExpiracion;
            public DateTime FechaExpiracion
            {
                get { return _FechaExpiracion; }
                set { _FechaExpiracion = value; }
            }

            private DateTime? _FechaCanje;
            public DateTime? FechaCanje
            {
                get { return _FechaCanje; }
                set { _FechaCanje = value; }
            }

            public int Create()
            {
                Hashtable m_params = new Hashtable();
                m_params.Add("ValePrepagado_ID", this.ValePrepagado_ID);
                m_params.Add("EmpresaCliente_ID", this.EmpresaCliente_ID);
                m_params.Add("Usuario_ID", this.Usuario_ID);
                m_params.Add("EstatusValePrepagado_ID", this.EstatusValePrepagado_ID);
                if (!AppHelper.IsNullOrEmpty(this.Ticket_ID)) m_params.Add("Ticket_ID", this.Ticket_ID);
                m_params.Add("FolioDiario", this.FolioDiario);
                m_params.Add("Denominacion", this.Denominacion);
                m_params.Add("FechaEmision", this.FechaEmision);
                m_params.Add("FechaExpiracion", this.FechaExpiracion);
                if (!AppHelper.IsNullOrEmpty(this.FechaCanje)) m_params.Add("FechaCanje", this.FechaCanje);

                return DB.InsertRow("ValesPrepagados", m_params);
            } // End Create

            public static List<ValesPrepagados> Read()
            {
                List<ValesPrepagados> list = new List<ValesPrepagados>();
                DataTable dt = DB.Select("ValesPrepagados");
                foreach (DataRow dr in dt.Rows)
                {
                    list.Add(new ValesPrepagados(Convert.ToString(dr["ValePrepagado_ID"]), Convert.ToInt32(dr["EmpresaCliente_ID"]), Convert.ToString(dr["Usuario_ID"]), Convert.ToInt32(dr["EstatusValePrepagado_ID"]), DB.GetNullableInt32(dr["Ticket_ID"]), Convert.ToInt32(dr["FolioDiario"]), Convert.ToDecimal(dr["Denominacion"]), Convert.ToDateTime(dr["FechaEmision"]), Convert.ToDateTime(dr["FechaExpiracion"]), DB.GetNullableDateTime(dr["FechaCanje"])));
                }

                return list;
            } // End Read

            public static ValesPrepagados Read(string valeprepagado_id)
            {
                Hashtable w_params = new Hashtable();
                w_params.Add("ValePrepagado_ID", valeprepagado_id);
                DataTable dt = DB.Select("ValesPrepagados", w_params);
                if (dt.Rows.Count == 0)
                {
                    throw new Exception("No existe ValesPrepagados con los criterios de búsqueda especificados.");
                }
                DataRow dr = dt.Rows[0];
                return new ValesPrepagados(Convert.ToString(dr["ValePrepagado_ID"]), Convert.ToInt32(dr["EmpresaCliente_ID"]), Convert.ToString(dr["Usuario_ID"]), Convert.ToInt32(dr["EstatusValePrepagado_ID"]), DB.GetNullableInt32(dr["Ticket_ID"]), Convert.ToInt32(dr["FolioDiario"]), Convert.ToDecimal(dr["Denominacion"]), Convert.ToDateTime(dr["FechaEmision"]), Convert.ToDateTime(dr["FechaExpiracion"]), DB.GetNullableDateTime(dr["FechaCanje"]));
            } // End Read

            public static ValesPrepagados Read(params KeyValuePair<string, object>[] args)
            {
                DataTable dt = DB.Read("ValesPrepagados", args);
                if (dt.Rows.Count == 0)
                {
                    return null;
                }
                DataRow dr = dt.Rows[0];
                return new ValesPrepagados(Convert.ToString(dr["ValePrepagado_ID"]), Convert.ToInt32(dr["EmpresaCliente_ID"]), Convert.ToString(dr["Usuario_ID"]), Convert.ToInt32(dr["EstatusValePrepagado_ID"]), DB.GetNullableInt32(dr["Ticket_ID"]), Convert.ToInt32(dr["FolioDiario"]), Convert.ToDecimal(dr["Denominacion"]), Convert.ToDateTime(dr["FechaEmision"]), Convert.ToDateTime(dr["FechaExpiracion"]), DB.GetNullableDateTime(dr["FechaCanje"]));
            } // End Read

            public static bool Read(out ValesPrepagados valesprepagados, int top, string filter, string sort, params KeyValuePair<string, object>[] args)
            {
                DataTable dt = DB.Read("ValesPrepagados", top, filter, sort, args);
                if (dt.Rows.Count == 0)
                {
                    valesprepagados = null;
                    return false;
                }
                DataRow dr = dt.Rows[0];
                valesprepagados = new ValesPrepagados(Convert.ToString(dr["ValePrepagado_ID"]), Convert.ToInt32(dr["EmpresaCliente_ID"]), Convert.ToString(dr["Usuario_ID"]), Convert.ToInt32(dr["EstatusValePrepagado_ID"]), DB.GetNullableInt32(dr["Ticket_ID"]), Convert.ToInt32(dr["FolioDiario"]), Convert.ToDecimal(dr["Denominacion"]), Convert.ToDateTime(dr["FechaEmision"]), Convert.ToDateTime(dr["FechaExpiracion"]), DB.GetNullableDateTime(dr["FechaCanje"]));
                return true;
            } // End Read

            public int Update()
            {
                Hashtable m_params = new Hashtable();
                Hashtable w_params = new Hashtable();
                w_params.Add("ValePrepagado_ID", this.ValePrepagado_ID);
                m_params.Add("EmpresaCliente_ID", this.EmpresaCliente_ID);
                m_params.Add("Usuario_ID", this.Usuario_ID);
                m_params.Add("EstatusValePrepagado_ID", this.EstatusValePrepagado_ID);
                if (!AppHelper.IsNullOrEmpty(this.Ticket_ID)) m_params.Add("Ticket_ID", this.Ticket_ID);
                m_params.Add("FolioDiario", this.FolioDiario);
                m_params.Add("Denominacion", this.Denominacion);
                m_params.Add("FechaEmision", this.FechaEmision);
                m_params.Add("FechaExpiracion", this.FechaExpiracion);
                if (!AppHelper.IsNullOrEmpty(this.FechaCanje)) m_params.Add("FechaCanje", this.FechaCanje);

                return DB.UpdateRow("ValesPrepagados", m_params, w_params);
            } // End Update

            public int Delete()
            {
                Hashtable w_params = new Hashtable();
                w_params.Add("ValePrepagado_ID", this.ValePrepagado_ID);

                return DB.DeleteRow("ValesPrepagados", w_params);
            } // End Delete

        } //End Class ValesPrepagados

        public class VariablesNegocio
        {

            public VariablesNegocio()
            {
            }

            public VariablesNegocio(string variablenegocio_id, object valor)
            {
                this.VariableNegocio_ID = variablenegocio_id;
                this.Valor = valor;
            }

            private string _VariableNegocio_ID;
            public string VariableNegocio_ID
            {
                get { return _VariableNegocio_ID; }
                set { _VariableNegocio_ID = value; }
            }

            private object _Valor;
            public object Valor
            {
                get { return _Valor; }
                set { _Valor = value; }
            }

            public int Create()
            {
                Hashtable m_params = new Hashtable();
                m_params.Add("VariableNegocio_ID", this.VariableNegocio_ID);
                m_params.Add("Valor", this.Valor);

                return DB.InsertRow("VariablesNegocio", m_params);
            } // End Create

            public static List<VariablesNegocio> Read()
            {
                List<VariablesNegocio> list = new List<VariablesNegocio>();
                DataTable dt = DB.Select("VariablesNegocio");
                foreach (DataRow dr in dt.Rows)
                {
                    list.Add(new VariablesNegocio(Convert.ToString(dr["VariableNegocio_ID"]), dr["Valor"]));
                }

                return list;
            } // End Read

            public static VariablesNegocio Read(string variablenegocio_id)
            {
                Hashtable w_params = new Hashtable();
                w_params.Add("VariableNegocio_ID", variablenegocio_id);
                DataTable dt = DB.Select("VariablesNegocio", w_params);
                if (dt.Rows.Count == 0)
                {
                    throw new Exception("No existe VariablesNegocio con los criterios de búsqueda especificados.");
                }
                DataRow dr = dt.Rows[0];
                return new VariablesNegocio(Convert.ToString(dr["VariableNegocio_ID"]), dr["Valor"]);
            } // End Read

            public int Update()
            {
                Hashtable m_params = new Hashtable();
                Hashtable w_params = new Hashtable();
                w_params.Add("VariableNegocio_ID", this.VariableNegocio_ID);
                m_params.Add("Valor", this.Valor);

                return DB.UpdateRow("VariablesNegocio", m_params, w_params);
            } // End Update

            public int Delete()
            {
                Hashtable w_params = new Hashtable();
                w_params.Add("VariableNegocio_ID", this.VariableNegocio_ID);

                return DB.DeleteRow("VariablesNegocio", w_params);
            } // End Delete

        } //End Class VariablesNegocio

        public class Zonas
        {

            public Zonas()
            {
            }

            public Zonas(int zona_id, int tipozona_id, int? comisionservicio_id, string nombre)
            {
                this.Zona_ID = zona_id;
                this.TipoZona_ID = tipozona_id;
                this.ComisionServicio_ID = comisionservicio_id;
                this.Nombre = nombre;
            }

            public Zonas(int zona_id, int tipozona_id, int? comisionservicio_id, string nombre, int? folioebssa)
            {
                this.Zona_ID = zona_id;
                this.TipoZona_ID = tipozona_id;
                this.ComisionServicio_ID = comisionservicio_id;
                this.Nombre = nombre;
                this.FolioEBSSA = folioebssa;
            }

            private int _Zona_ID;
            public int Zona_ID
            {
                get { return _Zona_ID; }
                set { _Zona_ID = value; }
            }

            private int _TipoZona_ID;
            public int TipoZona_ID
            {
                get { return _TipoZona_ID; }
                set { _TipoZona_ID = value; }
            }

            private int? _ComisionServicio_ID;
            public int? ComisionServicio_ID
            {
                get { return _ComisionServicio_ID; }
                set { _ComisionServicio_ID = value; }
            }

            private string _Nombre;
            public string Nombre
            {
                get { return _Nombre; }
                set { _Nombre = value; }
            }

            private int? _FolioEBSSA;
            public int? FolioEBSSA
            {
                get { return _FolioEBSSA; }
                set { _FolioEBSSA = value; }
            }

            public int Create()
            {
                Hashtable m_params = new Hashtable();
                m_params.Add("TipoZona_ID", this.TipoZona_ID);
                m_params.Add("ComisionServicio_ID", this.ComisionServicio_ID);
                m_params.Add("Nombre", this.Nombre);
                m_params.Add("FolioEBSSA", this.FolioEBSSA);

                return DB.InsertRow("Zonas", m_params);
            } // End Create

            public int Create(bool IsIdentityInsert)
            {
                if (!IsIdentityInsert) return Create();
                Hashtable m_params = new Hashtable();
                m_params.Add("Zona_ID", this.Zona_ID);
                m_params.Add("TipoZona_ID", this.TipoZona_ID);
                if (!AppHelper.IsNullOrEmpty(this.ComisionServicio_ID)) m_params.Add("ComisionServicio_ID", this.ComisionServicio_ID);
                m_params.Add("Nombre", this.Nombre);
                m_params.Add("FolioEBSSA", this.FolioEBSSA);

                return DB.IdentityInsertRow("Zonas", m_params);
            } // End Create

            public static List<Zonas> Read()
            {
                List<Zonas> list = new List<Zonas>();
                DataTable dt = DB.Select("Zonas");
                foreach (DataRow dr in dt.Rows)
                {
                    list.Add(
                        new Zonas(
                            Convert.ToInt32(dr["Zona_ID"]), 
                            Convert.ToInt32(dr["TipoZona_ID"]), 
                            DB.GetNullableInt32(dr["ComisionServicio_ID"]), 
                            Convert.ToString(dr["Nombre"]),
                            DB.GetNullableInt32(dr["FolioEBSSA"])
                        )
                    );
                }

                return list;
            } // End Read

            public static Zonas Read(int zona_id)
            {
                Hashtable w_params = new Hashtable();
                w_params.Add("Zona_ID", zona_id);

                DataTable dt = DB.Select("Zonas", w_params);

                if (dt.Rows.Count == 0)
                {
                    throw new Exception(String.Format("No existe zona con ID = {0}", zona_id));
                }

                DataRow dr = dt.Rows[0];

                return new Zonas(
                            Convert.ToInt32(dr["Zona_ID"]), 
                            Convert.ToInt32(dr["TipoZona_ID"]), 
                            DB.GetNullableInt32(dr["ComisionServicio_ID"]), 
                            Convert.ToString(dr["Nombre"]),
                            DB.GetNullableInt32(dr["FolioEBSSA"])
                        );
            } // End Read

            public static Zonas ReadByFolioEBSSA(int? folioebssa)
            {
                Hashtable w_params = new Hashtable();
                w_params.Add("FolioEBSSA", folioebssa);

                DataTable dt = DB.Select("Zonas", w_params);

                if (dt.Rows.Count == 0)
                {
                    return null;                        
                }

                DataRow dr = dt.Rows[0];

                return new Zonas(
                            Convert.ToInt32(dr["Zona_ID"]),
                            Convert.ToInt32(dr["TipoZona_ID"]),
                            DB.GetNullableInt32(dr["ComisionServicio_ID"]),
                            Convert.ToString(dr["Nombre"]),
                            DB.GetNullableInt32(dr["FolioEBSSA"])
                        );
            } // End Read

            public int Update()
            {
                Hashtable m_params = new Hashtable();
                Hashtable w_params = new Hashtable();
                w_params.Add("Zona_ID", this.Zona_ID);
                m_params.Add("TipoZona_ID", this.TipoZona_ID);
                m_params.Add("ComisionServicio_ID", this.ComisionServicio_ID);
                m_params.Add("Nombre", this.Nombre);
                m_params.Add("FolioEBSSA", this.FolioEBSSA);

                return DB.UpdateRow("Zonas", m_params, w_params);
            } // End Update

            public int Delete()
            {
                Hashtable w_params = new Hashtable();
                w_params.Add("Zona_ID", this.Zona_ID);

                return DB.DeleteRow("Zonas", w_params);
            }

        } //End Class Zonas

    } // End namespace

}
