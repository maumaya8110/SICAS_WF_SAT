using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Net;
using System.Security;
using System.Security.Cryptography;
using System.Runtime.InteropServices;
using System.Data;
using System.Drawing;

namespace AutoUpdater
{
    public class Utils
    {
        #region Stlysh

        public static void SetStylish(Control ctrl)
        {
            foreach (Control c in ctrl.Controls)
            {
                if (c.GetType() == typeof(System.Windows.Forms.DataGridView))
                {
                    SetDataGridViewProperties((DataGridView)c);
                    ((DataGridView)c).EditingControlShowing += DataGridView_EditingControlShowing;
                    ((DataGridView)c).CellFormatting += DataGridView_CellFormatting;
                }

                if (c.GetType() == typeof(System.Windows.Forms.GroupBox))
                {
                    SetGroupBoxProperties((GroupBox)c);
                }

                if (c.GetType() == typeof(System.Windows.Forms.TabPage))
                {
                    SetTabPageProperties((TabPage)c);
                }

                SetStylish(c);
            }
        }

        private static void SetTabPageProperties(TabPage tpage)
        {
            tpage.BackColor = Color.GhostWhite;
        }

        private static void SetGroupBoxProperties(GroupBox gbox)
        {
            gbox.Location = new Point(20, 20);
        }

        private static void SetDataGridViewProperties(DataGridView dgv)
        {
            dgv.AutoGenerateColumns = false;
            dgv.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            dgv.BackgroundColor = Color.GhostWhite;
            dgv.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Single;
            //dgv.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgv.GridColor = System.Drawing.Color.LightGray;
            dgv.RowHeadersVisible = false;
            dgv.AllowUserToResizeRows = false;
            dgv.Location = new Point(20, 20);
            dgv.BorderStyle = BorderStyle.None;
        }

        #endregion

        #region DataGridView Methods

        //  Método a configurar para los DataGridViews en el evento EditingControlShowing
        private static void DataGridView_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            DataGridView dgv = (DataGridView)sender;
            if (dgv.Columns[dgv.CurrentCell.ColumnIndex].DataPropertyName == "Pwd")
            {
                TextBox t = e.Control as TextBox;
                if (t != null)
                {
                    t.PasswordChar = Convert.ToChar("?");
                }                
            }            
        }

        //  Método a configurar para los DataGridViews en el evento CellFormatting
        private static void DataGridView_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (((DataGridView)sender).Columns[e.ColumnIndex].DataPropertyName == "Pwd"
                && e.Value != null)
            {
                e.Value = new String('?', e.Value.ToString().Length);
            }
        }
        #endregion

        public static bool TryHTTP(string host)
        {
            try
            {
                if (!host.Contains("http://")) host = "http://" + host;

                WebRequest wreq = WebRequest.Create(host);
                WebResponse wresp;
                wreq.Timeout = 3000;
                wresp = wreq.GetResponse();
                string result = wresp.ToString();
                wresp.Close();

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public static bool TryFTP(string host)
        {
            try
            {
                if (!host.Contains("ftp://")) host = "ftp://" + host;

                FtpWebRequest wreq = (FtpWebRequest)WebRequest.Create(new Uri(host));
                FtpWebResponse wresp;
                wreq.Timeout = 3000;
                wreq.UseBinary = true;
                wreq.UsePassive = false;
                //wreq.Credentials = new NetworkCredential("user", "pass");
                wreq.Method = WebRequestMethods.Ftp.ListDirectoryDetails;
                wresp = (FtpWebResponse)wreq.GetResponse();
                string result = wresp.ToString();
                wresp.Close();

                return true;
            }
            catch (WebException wex)
            {
                if (wex.Message.Contains("530"))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public static void Log(string entry)
        {
            StreamWriter sw = new StreamWriter(
                String.Format(System.Environment.CurrentDirectory + @"\{0:yyyyMM}log.log", DateTime.Now), true);

            sw.WriteLine(String.Format("{0:yyyyMMdd HH:mm:ss}   {1}", DateTime.Now, entry));
            sw.Flush();
            sw.Close();
        }

        public static void ClearControl(Control ctrl)
        {
            foreach (Control c in ctrl.Controls)
            {
                if (c.GetType() == typeof(System.Windows.Forms.TextBox))
                {
                    c.Text = "";
                }

                ClearControl(c);
            }
        }

        public static string N2(object valor)
        {
            return string.Format("{0:N2}", valor);
        }

        public static bool IsNumeric(string valor)
        {
            Decimal d;
            return Decimal.TryParse(valor, out d);
        }

        public static long FTP_FILESIZE = 0;
        public static int FTP_PERCENT = 0;
        public static bool FTP_ISBUSY = false;

        public static void FTPUpload(string filename, string destination, string ftpUserID, string ftpPassword)
        {
            FileInfo fileInf = new FileInfo(filename);
            string uri = "ftp://" + destination;
            FtpWebRequest reqFTP;

            reqFTP = (FtpWebRequest)FtpWebRequest.Create
                     (new Uri(uri));
            reqFTP.Credentials = new NetworkCredential(ftpUserID, ftpPassword);
            reqFTP.KeepAlive = false;
            reqFTP.Method = WebRequestMethods.Ftp.UploadFile;
            reqFTP.UseBinary = true;
            reqFTP.ContentLength = fileInf.Length;
            reqFTP.UsePassive = false;
            int buffLength = 2048;
            byte[] buff = new byte[buffLength];
            int contentLen;

            FileStream fs = fileInf.OpenRead();

            try
            {
                Stream strm = reqFTP.GetRequestStream();
                contentLen = fs.Read(buff, 0, buffLength);

                while (contentLen != 0)
                {
                    strm.Write(buff, 0, contentLen);
                    contentLen = fs.Read(buff, 0, buffLength);
                }

                strm.Close();
                fs.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Upload Error");
            }
        }

        public static volatile System.Windows.Forms.ProgressBar pb;
        public static void FTPDownload(string ftpSource, string localDest, string ftpUserID, string ftpPassword)
        {
            FTP_ISBUSY = true;
            try
            {
                FtpWebRequest reqFTP;
                FileStream outputStream = new FileStream(localDest, FileMode.Create);

                reqFTP = (FtpWebRequest)FtpWebRequest.Create(new Uri(ftpSource));                
                reqFTP.UseBinary = true;
                reqFTP.Credentials = new NetworkCredential(ftpUserID,
                                                            ftpPassword);
                reqFTP.UsePassive = false;

                reqFTP.Method = WebRequestMethods.Ftp.GetFileSize;                
                FtpWebResponse response = (FtpWebResponse)reqFTP.GetResponse();
                FTP_FILESIZE = response.ContentLength;

                //  Volver a crear
                reqFTP = (FtpWebRequest)FtpWebRequest.Create(new Uri(ftpSource));
                reqFTP.UseBinary = true;
                reqFTP.Credentials = new NetworkCredential(ftpUserID,
                                                            ftpPassword);
                reqFTP.UsePassive = false;

                reqFTP.Method = WebRequestMethods.Ftp.DownloadFile;
                response = (FtpWebResponse)reqFTP.GetResponse();
                Stream ftpStream = response.GetResponseStream();
                                
                int bufferSize = 2048;
                int readCount;
                byte[] buffer = new byte[bufferSize];

                readCount = ftpStream.Read(buffer, 0, bufferSize);

                long cont = readCount;
                
                while (readCount > 0)
                {
                    outputStream.Write(buffer, 0, readCount);                    
                    readCount = ftpStream.Read(buffer, 0, bufferSize);
                    
                    FTP_PERCENT = Convert.ToInt32((cont * 100) / Math.Abs(FTP_FILESIZE));
                    cont += readCount;

                    if (FTP_PERCENT > 0)
                    {
                        Console.WriteLine(String.Format("{0} * 100 / {1} = {2}", cont, FTP_FILESIZE, FTP_PERCENT));
                        pb.Value = FTP_PERCENT;
                    }
                    else
                    {
                        Console.WriteLine("MENOR QUE 0");
                    }
                }

                ftpStream.Close();
                outputStream.Close();
                response.Close(); 
            }
            finally
            {
                FTP_ISBUSY = false;
                FTP_FILESIZE = 0;
                FTP_PERCENT = 0;
            }                       
        }

        public static void HTTPDownload(string url, string destination, string user, string pwd)
        {
            WebClient wc = new WebClient();

            wc.Credentials = new NetworkCredential(user, pwd);
            wc.DownloadFile(url, destination);
        }

        public static void HTTPUpload(string filePath, string urlDest, string user, string pwd)
        {
            WebClient wc = new WebClient();

            wc.Credentials = new NetworkCredential(user, pwd);
            wc.UploadFile(urlDest, filePath);
        }

        private static string _WSUrl;
        public static string WSUrl
        {
            get { return _WSUrl; }
            set { _WSUrl = value; }
        }

        private static CookieContainer cc = new CookieContainer();

        public static string HttpGet(string url, string GetData)
        {

            HttpWebRequest request = null;
            Uri uri = new Uri(url + "?" + GetData);

            request = (HttpWebRequest)WebRequest.Create(uri);
            request.Method = "GET";
            request.CookieContainer = cc;

            string result = string.Empty;
            CookieCollection cookies = default(CookieCollection);

            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            {
                cc.Add(new Uri(url), response.Cookies);
                using (Stream responseStream = response.GetResponseStream())
                {
                    using (StreamReader readStream = new StreamReader(responseStream, Encoding.UTF8))
                    {
                        result = readStream.ReadToEnd();
                    }
                }
            }


            cookies = cc.GetCookies(new Uri(url));
            string cookiesCol = "";
            foreach (Cookie cookie in cookies)
            {
                cookiesCol += cookie.Name + "=" + cookie.Value;
            }

            return result;
        }

        public static string HttpGet(string url, string GetData, string user, string pwd)
        {

            HttpWebRequest request = null;
            Uri uri = new Uri(url + "?" + GetData);

            request = (HttpWebRequest)WebRequest.Create(uri);
            request.Method = "GET";
            request.CookieContainer = cc;
            request.Credentials = new NetworkCredential(user, pwd);

            string result = string.Empty;
            CookieCollection cookies = default(CookieCollection);

            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            {
                cc.Add(new Uri(url), response.Cookies);
                using (Stream responseStream = response.GetResponseStream())
                {
                    using (StreamReader readStream = new StreamReader(responseStream, Encoding.UTF8))
                    {
                        result = readStream.ReadToEnd();
                    }
                }
            }


            cookies = cc.GetCookies(new Uri(url));
            string cookiesCol = "";
            foreach (Cookie cookie in cookies)
            {
                cookiesCol += cookie.Name + "=" + cookie.Value;
            }

            return result;
        }

        public static string HttpGet(string url, string user, string pwd)
        {

            HttpWebRequest request = null;
            Uri uri = new Uri(url);

            request = (HttpWebRequest)WebRequest.Create(uri);
            request.Method = "GET";
            request.CookieContainer = cc;
            request.Credentials = new NetworkCredential(user, pwd);

            string result = string.Empty;
            CookieCollection cookies = default(CookieCollection);

            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            {
                cc.Add(new Uri(url), response.Cookies);
                using (Stream responseStream = response.GetResponseStream())
                {
                    using (StreamReader readStream = new StreamReader(responseStream, Encoding.UTF8))
                    {
                        result = readStream.ReadToEnd();
                    }
                }
            }


            cookies = cc.GetCookies(new Uri(url));
            string cookiesCol = "";
            foreach (Cookie cookie in cookies)
            {
                cookiesCol += cookie.Name + "=" + cookie.Value;
            }

            return result;
        }

        public static string HttpPost(string url, string PostData)
        {

            HttpWebRequest request = null;
            Uri uri = new Uri(url);

            request = (HttpWebRequest)WebRequest.Create(uri);
            request.Method = "POST";
            request.ContentType = "application/x-www-form-urlencoded";
            request.CookieContainer = cc;
            request.ContentLength = PostData.Length;

            using (Stream writeStream = request.GetRequestStream())
            {
                UTF8Encoding encoding__1 = new UTF8Encoding();
                byte[] bytes = encoding__1.GetBytes(PostData);
                writeStream.Write(bytes, 0, bytes.Length);
            }

            string result = string.Empty;
            CookieCollection cookies = default(CookieCollection);

            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            {
                cc.Add(new Uri(url), response.Cookies);
                using (Stream responseStream = response.GetResponseStream())
                {
                    using (StreamReader readStream = new StreamReader(responseStream, Encoding.UTF8))
                    {
                        result = readStream.ReadToEnd();
                    }
                }
            }

            cookies = cc.GetCookies(new Uri(url));
            string cookiesCol = "";
            foreach (Cookie cookie in cookies)
            {
                cookiesCol += cookie.Name + "=" + cookie.Value;
            }

            return result;
        }

        public static string HttpPost(string url, string PostData, string user, string pwd)
        {

            HttpWebRequest request = null;
            Uri uri = new Uri(url);

            request = (HttpWebRequest)WebRequest.Create(uri);
            request.Method = "POST";
            request.ContentType = "application/x-www-form-urlencoded";
            request.CookieContainer = cc;
            request.ContentLength = PostData.Length;
            request.Credentials = new NetworkCredential(user, pwd);

            using (Stream writeStream = request.GetRequestStream())
            {
                UTF8Encoding encoding__1 = new UTF8Encoding();
                byte[] bytes = encoding__1.GetBytes(PostData);
                writeStream.Write(bytes, 0, bytes.Length);
            }

            string result = string.Empty;
            CookieCollection cookies = default(CookieCollection);

            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            {
                cc.Add(new Uri(url), response.Cookies);
                using (Stream responseStream = response.GetResponseStream())
                {
                    using (StreamReader readStream = new StreamReader(responseStream, Encoding.UTF8))
                    {
                        result = readStream.ReadToEnd();
                    }
                }
            }

            cookies = cc.GetCookies(new Uri(url));
            string cookiesCol = "";
            foreach (Cookie cookie in cookies)
            {
                cookiesCol += cookie.Name + "=" + cookie.Value;
            }

            return result;
        }
    }

    class CryptHelper
    {
        static byte[] key;
        static byte[] IV;
        static string str_key = "C28y6ovpJ4OrZ148H0vLh42J";
        static string str_IV = "bNxlxD8c05Zw4t5DR857043z";
        private static TripleDESCryptoServiceProvider des =
            new TripleDESCryptoServiceProvider();

        public CryptHelper()
        {
            ASCIIEncoding textConverter = new ASCIIEncoding();
            key = textConverter.GetBytes(str_key);
            IV = textConverter.GetBytes(str_IV);
        }

        public static void SetKeys()
        {
            ASCIIEncoding textConverter = new ASCIIEncoding();
            key = textConverter.GetBytes(str_key);
            IV = textConverter.GetBytes(str_IV);
        }

        public static String Encrypt(String strEnc)
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


        public static String Decrypt(String strDesEnc)
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
        /// Aun presenta bugs: No utilizar
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

            fsread.Flush();
            fsread.Close();
            fsread.Dispose();
            sr.Close();
            sr.Dispose();

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
            ICryptoTransform desdecrypt = des.CreateDecryptor(key,IV);

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
    }
}
