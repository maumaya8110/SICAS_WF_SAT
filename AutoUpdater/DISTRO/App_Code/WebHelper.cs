using System;
using System.Collections.Generic;
using System.Web;
using System.Text;
using System.IO;
using System.Security.Cryptography;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Collections;
using System.Configuration;

public class WebHelper
{
    public static string ResolveUrlImage(string imgname)
    {
        return ConfigurationManager.AppSettings["ImagePath"].ToString() + imgname;            
    }

    public static string ResolveUrlImage(string imgname, bool isElement)
    {
        string imgstr = "<img src=\"@src\" \\>";
        imgstr = imgstr.Replace("@src", ConfigurationManager.AppSettings["ImagePath"].ToString() + imgname);
        return imgstr;
    }

    public static string left(string str, int len)
    {
        return str.Substring(0, len);
    }

    public static string right(string str, int len)
    {
        return str.Substring(str.Length - len);
    }

    public static string mid(string str, int start, int len)
    {
        return str.Substring(start, len);
    }

    private static string _RedirectUrl;
    public static string RedirectUrl
    {
        get { return _RedirectUrl; }
        set { _RedirectUrl = value; }
    }

    public static void FormView_ModeChanged(object sender, EventArgs e)
    {
        try
        {
            SetFormViewLinkButtonsImages((FormView)sender);
        }
        catch
        { 
        }
    }

    public static void SetFormViewLinkButtonsImages(FormView fv)
    {
        LinkButton lbtn;

        //lbtn = (LinkButton)fv.FindControl("UpdateButton");
        //lbtn.Text = ResolveUrlImage("save.png", true);

        //lbtn = (LinkButton)fv.FindControl("UpdateCancelButton");
        //lbtn.Text = ResolveUrlImage("cancel.png", true);

        //lbtn = (LinkButton)fv.FindControl("InsertButton");
        //lbtn.Text = ResolveUrlImage("save.png", true);

        //lbtn = (LinkButton)fv.FindControl("InsertCancelButton");
        //lbtn.Text = ResolveUrlImage("cancel.png", true);

        //lbtn = (LinkButton)fv.FindControl("EditButton");
        //lbtn.Text = ResolveUrlImage("edit.png", true);

        //lbtn = (LinkButton)fv.FindControl("DeleteButton");
        //lbtn.Text = ResolveUrlImage("delete.png", true);

        //lbtn = (LinkButton)fv.FindControl("NewButton");
        //lbtn.Text = ResolveUrlImage("new.png", true);

        foreach (Control c in fv.Controls)
        {
            if (c.GetType() == typeof(LinkButton))
            {
                lbtn = (LinkButton)c;
                switch (lbtn.ID)
                {
                    case "UpdateButton":
                        lbtn.Text = ResolveUrlImage("save.png", true);
                        break;
                    case "UpdateCancelButton":
                        lbtn.Text = ResolveUrlImage("cancel.png", true);
                        break;
                    case "InsertButton":
                        lbtn.Text = ResolveUrlImage("save.png", true);
                        break;
                    case "InsertCancelButton":
                        lbtn.Text = ResolveUrlImage("cancel.png", true);
                        break;
                    case "EditButton":
                        lbtn.Text = ResolveUrlImage("edit.png", true);
                        break;
                    case "DeleteButton":
                        lbtn.Text = ResolveUrlImage("delete.png", true);
                        break;
                    case "NewButton":
                        lbtn.Text = ResolveUrlImage("new.png", true);
                        break;
                }
            }
        }
    }

    public static void SetFormViewMethods(FormView fv)
    {
        //  Set commands
        fv.ItemCommand += FormView_ItemCommand;
        fv.ItemInserted += FormView_ItemInserted;
        fv.ItemUpdated += FormView_ItemUpdated;
        fv.ItemDeleted += FormView_ItemDeleted;
        fv.ModeChanged += FormView_ModeChanged;
        //  Set images for buttons
        //  SetFormViewLinkButtonsImages(fv);

        //  Add Query_String behavior
        Page page = HttpContext.Current.Handler as Page;

        if (!page.IsPostBack)
        {
            string mode = page.Request.QueryString["Mode"];
            
            switch (mode)
            {
                case "Create":
                    fv.ChangeMode(FormViewMode.Insert);
                    break;
                case "Update":
                    fv.ChangeMode(FormViewMode.Edit);
                    break;
                case "Read":
                    fv.ChangeMode(FormViewMode.ReadOnly);
                    break;
                case "Delete":
                    fv.DeleteItem();
                    break;
            }
        }
    }

    public static void FormView_ItemDeleted(object sender, FormViewDeletedEventArgs e)
    {
        try
        {
            if (e.Exception != null)
            {
                e.ExceptionHandled = true;
                throw new Exception(e.Exception.Message);
            }
            else
            {
                HttpContext.Current.Response.Redirect(RedirectUrl);
            }
        }
        catch (Exception ex)
        {
            WebHelper.AlertRedirect(ex.Message, RedirectUrl);
        }
    }

    public static void FormView_ItemUpdated(object sender, FormViewUpdatedEventArgs e)
    {
        try
        {
            if (e.Exception != null)
            {
                e.ExceptionHandled = true;
                throw new Exception(e.Exception.Message);
            }
            else
            {
                HttpContext.Current.Response.Redirect(RedirectUrl);
            }
        }
        catch (Exception ex)
        {
            WebHelper.AlertRedirect(ex.Message, RedirectUrl);
        }
    }

    public static void FormView_ItemInserted(object sender, FormViewInsertedEventArgs e)
    {
        try
        {
            if (e.Exception != null)
            {
                e.ExceptionHandled = true;
                throw new Exception(e.Exception.Message);
            }
            else
            {
                HttpContext.Current.Response.Redirect(RedirectUrl);
            }
        }
        catch (Exception ex)
        {
            WebHelper.AlertRedirect(ex.Message, RedirectUrl);
        }
    }

    public static void FormView_ItemCommand(object sender, FormViewCommandEventArgs e)
    {
        if (e.CommandName == "Cancel")
        {
            HttpContext.Current.Response.Redirect(RedirectUrl);
        }
    }

    public static void GoBack()
    {
        Page page = HttpContext.Current.Handler as Page;

        string sMsg = "";

        sMsg = "<script language='javascript'>";
        sMsg = sMsg + "history.back(2);";
        sMsg = sMsg + "</script>";

        page.ClientScript.RegisterStartupScript(
            page.GetType(), "sMsg", sMsg.ToString());
    }

    public static void AlertRedirect(string Message, string url)
    {
        Page page = HttpContext.Current.Handler as Page;

        string sMsg = "";
        Message = Message.Replace("'", "\"");
        Message = Message.Replace(System.Environment.NewLine, " ");
        Message = Message.Replace("\r\n", " ");
        Message = Message.Replace("\r", " ");
        Message = Message.Replace("\n", " ");
        if (Message.Length > 100) { Message = WebHelper.left(Message, 100); }

        sMsg = "<script language='javascript'>";
        sMsg = sMsg + "alert('" + Message + "'); ";
        sMsg = sMsg + "window.location.href = '" + url + "';";
        sMsg = sMsg + "</script>";

        page.ClientScript.RegisterStartupScript(
            page.GetType(), "sMsg", sMsg.ToString());
    }

    public static void Alert(string Message)
    {
        Page page = HttpContext.Current.Handler as Page;

        string sMsg = "";
        Message = Message.Replace("'", "\"");
        Message = Message.Replace(System.Environment.NewLine, " ");
        Message = Message.Replace("\r\n", " ");
        Message = Message.Replace("\r", " ");
        Message = Message.Replace("\n", " ");

        if (Message.Length > 100) { Message = WebHelper.left(Message, 100); }

        sMsg = "<script language='javascript'>";
        sMsg = sMsg + "alert('" + Message + "');";
        sMsg = sMsg + "</script>";

        page.ClientScript.RegisterStartupScript(
            page.GetType(), "sMsg", sMsg.ToString());
    }

    public static void Alert(string Message, System.Web.UI.Page page)
    {
        string sMsg = "";
        Message = Message.Replace("'", "\"");

        Message = Message.Replace(System.Environment.NewLine, " ");
        Message = Message.Replace("\r\n", " ");
        Message = Message.Replace("\r", " ");
        Message = Message.Replace("\n", " ");

        if (Message.Length > 100) { Message = WebHelper.left(Message, 100); }

        sMsg = "<script language='javascript'>";
        sMsg = sMsg + "alert('" + Message + "');";
        sMsg = sMsg + "</script>";

        page.ClientScript.RegisterStartupScript(
            page.GetType(), "sMsg", sMsg.ToString());
    }

    public static void Close()
    {
        Page page = HttpContext.Current.Handler as Page;

        string sMsg = "";

        sMsg = "<script language='javascript'>" +
                "window.opener = window; " +
                "window.close(); </script>";

        page.ClientScript.RegisterStartupScript(
            page.GetType(), "sMsg", sMsg.ToString());
    }

    public static void ReloadParent()
    {
        Page page = HttpContext.Current.Handler as Page;

        string sMsg = "";

        sMsg = "<script language='javascript'>" +
                "window.opener.location.reload(); </script>";

        page.ClientScript.RegisterStartupScript(
            page.GetType(), "sMsg", sMsg.ToString());
    }

    public static void Redirect(string url)
    {
        Page page = HttpContext.Current.Handler as Page;

        string sMsg = "";

        sMsg = "<script language='javascript'>" +
                "window.location.href = '_url'; </script>";
        sMsg = sMsg.Replace("_url", url);

        page.ClientScript.RegisterStartupScript(
            page.GetType(), "sMsg", sMsg.ToString());
    }

    public static void OpenWindow(string url)
    {
        Page page = HttpContext.Current.Handler as Page;

        string sMsg = "";

        sMsg = "<script language='javascript'>" +
                "window.open('url', '_blank', " +
                "'location=no resizable=yes fullscreen=yes " +
                "toolbar=no directories=no menubar=no');</script>";
        sMsg = sMsg.Replace("_url", url);

        page.ClientScript.RegisterStartupScript(
            page.GetType(), "sMsg", sMsg.ToString());
    }

    public static string GetDate()
    {
        string result = string.Format("{0:yyyy-MM-dd HH:mm:ss}", DateTime.Now);
        return result;
    }

    public static string GetUser()
    {
        string result = Crypter.DesEncryptar(HttpContext.Current.Request.Cookies.Get("VARSESSION").Value);
        return result;
    }

    public static string GetRol()
    {
        string result = Crypter.DesEncryptar(HttpContext.Current.Request.Cookies.Get("VARSESSION_R").Value);
        return result;
    }

    public static void ValidateRol(string rol)
    {
        if (GetRol() != rol)
        {
            HttpContext.Current.Response.Redirect("~/Default.aspx");
        }
    }

    public static void AllowRows(params object[] args)
    {
        foreach (object arg in args)
        {
            if ((string)arg == GetRol())
            {
                return;
            }
        }

        HttpContext.Current.Response.Redirect("~/Default.aspx");
    }

    /// <summary>
    /// Finds a Control recursively. Note finds the first match and exists
    /// </summary>
    /// <param name="Root"></param>
    /// <param name="Id"></param>
    /// <param name="includeAnonymous"></param>
    /// <returns></returns>
    protected static Control FindControlRecursiveNoRoot(Control Root, string Id, bool includeAnonymous)
    {
        // convertir NULL a cadena vacia
        string RootId = (Root.ID == null) ? "" : Root.ID;

        // detectar cuando cada control no tenga ID asignado
        bool CanFind = ((RootId != "") || includeAnonymous);
        if (CanFind)
        {
            if (RootId == Id)
                return Root;

            if (Root.Controls.Count > 0)
            {
                foreach (Control Ctl in Root.Controls)
                {
                    Control FoundCtl = FindControlRecursiveNoRoot(Ctl, Id, includeAnonymous);
                    if (FoundCtl != null)
                        return FoundCtl;
                } // foreach
            }
        } // if (CanFind)

        return null;
    } // static Control FindControlRecursiveNoRoot

    /// <summary>
    /// Finds a Control recursively. Note finds the first match and exists
    /// </summary>
    /// <param name="Root"></param>
    /// <param name="Id"></param>
    /// <param name="includeAnonymous"></param>
    /// <returns>Referencia a control o <code>null</code></returns>
    public static Control FindControlRecursive(Control Root, string Id, bool includeAnonymous)
    {
        if (Id != "")
        {
            // convertir NULL a cadena vacia
            string RootId = (Root.ID == null) ? "" : Root.ID;

            if (RootId == Id)
                return Root;

            if (Root.Controls.Count > 0)
            {
                foreach (Control Ctl in Root.Controls)
                {
                    Control FoundCtl = FindControlRecursiveNoRoot(Ctl, Id, includeAnonymous);
                    if (FoundCtl != null)
                        return FoundCtl;
                } // end foreach
            } // end if
        } // end if

        return null;
    } // endt FindControlRecursive

    /// <summary>
    /// Clase encargada de encriptar cadenas y archivos
    /// </summary>
    public class Crypter
    {
        static byte[] key;
        static byte[] IV;
        static string str_key = "WNtS8qt14KpJ4NuN633W95V4";
        static string str_IV = "1734h6W7P48109529Xu7ic3L";
        private static TripleDESCryptoServiceProvider des =
            new TripleDESCryptoServiceProvider();

        public Crypter()
        {
            ASCIIEncoding textConverter = new ASCIIEncoding();
            key = textConverter.GetBytes(str_key);
            IV = textConverter.GetBytes(str_IV);
        }

        /// <summary>
        /// Configura el KEY y el factor IV como arreglos de bytes
        /// </summary>
        public static void SetKeys()
        {
            ASCIIEncoding textConverter = new ASCIIEncoding();
            key = textConverter.GetBytes(str_key);
            IV = textConverter.GetBytes(str_IV);
        }

        /// <summary>
        /// Encripta una cadena
        /// </summary>
        /// <param name="strEnc">Cadena a encriptar</param>
        /// <returns>String</returns>
        public static String Encryptar(String strEnc)
        {
            SetKeys();

            ASCIIEncoding textConverter = new ASCIIEncoding();
            byte[] toEncrypt;

            MemoryStream msEncrypt = new MemoryStream();
            CryptoStream csEncrypt = new CryptoStream(msEncrypt,
                des.CreateEncryptor(key, IV), CryptoStreamMode.Write);

            toEncrypt = textConverter.GetBytes(strEnc);

            csEncrypt.Write(toEncrypt, 0, toEncrypt.Length);
            csEncrypt.FlushFinalBlock();

            return Convert.ToBase64String(msEncrypt.ToArray());
        }

        /// <summary>
        /// Desencripta una cadena
        /// </summary>
        /// <param name="strDesEnc">La cadena a desencriptar</param>
        /// <returns>String</returns>
        public static String DesEncryptar(String strDesEnc)
        {
            SetKeys();

            ASCIIEncoding textConverter = new ASCIIEncoding();
            byte[] fromEncrypt;
            byte[] encrypted;
            byte[] ret;

            encrypted = Convert.FromBase64String(strDesEnc);

            MemoryStream msDecrypt = new MemoryStream(encrypted);
            CryptoStream csDecrypt = new CryptoStream(msDecrypt,
                des.CreateDecryptor(key, IV), CryptoStreamMode.Read);

            fromEncrypt = new byte[encrypted.Length];

            csDecrypt.Read(fromEncrypt, 0, fromEncrypt.Length);

            ret = StripZeros(fromEncrypt);

            strDesEnc = textConverter.GetString(ret);

            return strDesEnc;
        }

        /// <summary>
        /// Elimina los zeros en un arreglo de bytes.
        /// </summary>
        /// <param name="bites"></param>
        /// <returns>Byte[]</returns>
        private static byte[] StripZeros(byte[] bites)
        {
            List<byte> list = new List<byte>();

            foreach (byte b in bites)
            {
                if (b != (byte)0)
                {
                    list.Add(b);
                }
            }

            return list.ToArray();

        }

        /// <summary>
        /// Determina si una expresión es base 64
        /// </summary>
        /// <param name="Expression">Expresión a evaluar</param>
        /// <returns></returns>
        public static bool IsBase64(string Expression)
        {
            try
            {
                byte[] tt = Convert.FromBase64String(Expression);
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Sigue sin funcionar
        /// </summary>
        /// <param name="sInputFilename"></param>
        /// <returns></returns>
        public static MemoryStream EncryptFile(string sInputFilename)
        {
            SetKeys();

            FileStream fsInput = new FileStream(sInputFilename, FileMode.Open, FileAccess.Read);
            MemoryStream temp = new MemoryStream();
            MemoryStream output = new MemoryStream();

            ICryptoTransform desencrypt = des.CreateEncryptor(key, IV);
            CryptoStream cryptostream = new CryptoStream(temp, desencrypt, CryptoStreamMode.Write);

            byte[] bytearrayinput = new byte[fsInput.Length];

            fsInput.Read(bytearrayinput, 0, bytearrayinput.Length);

            cryptostream.Write(bytearrayinput, 0, bytearrayinput.Length);

            //Imprimir el contenido del archivo descifrado.             
            temp.WriteTo(output);

            //Cerrar los streams
            cryptostream.Close();
            fsInput.Close();

            return output;
        }

        /// <summary>
        /// Desencripta el archivo especificado
        /// </summary>
        /// <param name="sInputFilename">El archivo a desencriptar</param>
        /// <returns>MemoryStream</returns>
        public static MemoryStream DecryptFile(string sInputFilename)
        {
            SetKeys();

            //Crear una secuencia de archivo para volver a leer el archivo cifrado. 
            FileStream fsread = new FileStream(sInputFilename, FileMode.Open, FileAccess.Read);

            //Crear un descriptor de DES desde la instancia de DES. 
            ICryptoTransform desdecrypt = des.CreateDecryptor(key, IV);

            //Crear una secuencia de cifrado para leer y 
            //realizar una transformación de cifrado DES en los bytes de entrada. 
            CryptoStream cryptostreamDecr = new CryptoStream(fsread, desdecrypt, CryptoStreamMode.Read);

            //Imprimir el contenido del archivo descifrado. 
            StreamReader sr = new StreamReader(cryptostreamDecr);
            byte[] buff = Encoding.ASCII.GetBytes(sr.ReadToEnd());
            return new MemoryStream(buff);
        }

        public static void EncryptFile(string sInputFilename, string sOutputFilename)
        {
            SetKeys();

            FileStream fsInput = new FileStream(sInputFilename, FileMode.Open, FileAccess.Read);
            FileStream fsEncrypted = new FileStream(sOutputFilename, FileMode.Create, FileAccess.Write);

            ICryptoTransform desencrypt = des.CreateEncryptor(key, IV);
            CryptoStream cryptostream = new CryptoStream(fsEncrypted, desencrypt, CryptoStreamMode.Write);

            byte[] bytearrayinput = new byte[fsInput.Length];

            fsInput.Read(bytearrayinput, 0, bytearrayinput.Length);

            cryptostream.Write(bytearrayinput, 0, bytearrayinput.Length);

            cryptostream.Close();
            fsInput.Close();
            fsEncrypted.Close();
        }

        public static void DecryptFile(string sInputFilename, string sOutputFilename)
        {
            SetKeys();

            //Crear una secuencia de archivo para volver a leer el archivo cifrado. 
            FileStream fsread = new FileStream(sInputFilename, FileMode.Open, FileAccess.Read);

            //Crear un descriptor de DES desde la instancia de DES. 
            ICryptoTransform desdecrypt = des.CreateDecryptor(key, IV);

            //Crear una secuencia de cifrado para leer y 
            //realizar una transformación de cifrado DES en los bytes de entrada. 
            CryptoStream cryptostreamDecr = new CryptoStream(fsread, desdecrypt, CryptoStreamMode.Read);

            //Imprimir el contenido del archivo descifrado. 
            StreamWriter fsDecrypted = new StreamWriter(sOutputFilename);
            fsDecrypted.Write(new StreamReader(cryptostreamDecr).ReadToEnd());
            fsDecrypted.Flush();
            fsDecrypted.Close();
        }

        public static void EncryptFile(Stream inputData, string sOutputFilename)
        {
            SetKeys();

            FileStream fsEncrypted = new FileStream(sOutputFilename, FileMode.Create, FileAccess.Write);

            ICryptoTransform desencrypt = des.CreateEncryptor(key, IV);
            CryptoStream cryptostream = new CryptoStream(fsEncrypted, desencrypt, CryptoStreamMode.Write);

            byte[] bytearrayinput = new byte[inputData.Length];

            inputData.Read(bytearrayinput, 0, bytearrayinput.Length);

            cryptostream.Write(bytearrayinput, 0, bytearrayinput.Length);

            cryptostream.Close();
            inputData.Close();
            fsEncrypted.Close();
        }

        public static Stream DataSetAsStream(DataSet ds)
        {
            MemoryStream result = new MemoryStream();
            ds.WriteXml(result);

            // Rewind the stream.
            result.Position = 0;
            return result;
        }
    }   // Class Crypter

    public class Data
    {
        public Data()
        {
        }

        public static string connStr =
            System.Configuration.ConfigurationManager.ConnectionStrings["constrITMAN"].ConnectionString;
        private static SqlConnection conn;

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
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                command.Connection.Close();
                command.Dispose();
            }
        }

        public static object QueryScalar(string sqlQry)
        {
            SqlCommand command = new SqlCommand();
            command.Connection = new SqlConnection(connStr);
            try
            {
                command.Connection.Open();
                command.CommandType = CommandType.Text;
                command.CommandText = sqlQry;

                return command.ExecuteScalar();
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                command.Connection.Close();
                command.Dispose();
            }
        }

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
                da.Fill(ds, "ITMANDATA");

                return ds.Tables[0];
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                command.Connection.Close();
                command.Dispose();
            }
        }

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
                    command.Parameters.AddWithValue(key, m_params[key]);
                }

                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter(command);
                da.Fill(ds, "ITMANDATA");

                return ds.Tables[0];
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                command.Connection.Close();
                command.Dispose();
            }
        }

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
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                conn.Close();
            }
        }

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
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                conn.Close();
            }
        }

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
                command.Parameters.AddWithValue("@" + k, @params[k]);
            }

            try
            {
                return command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                command.Connection.Close();
                command.Dispose();
            }
        }

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
        }

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
                command.Parameters.AddWithValue("@" + k, @whereParams[k]);
            }

            try
            {
                return command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                command.Connection.Close();
                command.Dispose();
            }
        }

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
                command.Parameters.AddWithValue("@" + k, @params[k]);
            }

            try
            {
                return command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                command.Connection.Close();
                command.Dispose();
            }
        }


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
                command.Parameters.AddWithValue("@" + k, @params[k]);
            }

            foreach (string k in @whereParams.Keys)
            {
                command.Parameters.AddWithValue("@" + k, @whereParams[k]);
            }

            try
            {
                return command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                command.Connection.Close();
                command.Dispose();
            }
        }

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
    } //    Data Class
}   //  WebHelper Class