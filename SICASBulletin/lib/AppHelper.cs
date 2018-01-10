using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using Microsoft.VisualBasic;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Text.RegularExpressions;
using System.CodeDom.Compiler;
using System.Reflection;
using Microsoft.CSharp;
using System.Net.NetworkInformation;
using System.Drawing;

namespace SICASBulletin
{
    class AppHelper
    {
        #region Ping

        public static bool Ping(string address)
        {
            Ping pingSender = new Ping();
            PingOptions options = new PingOptions();

            // Use the default Ttl value which is 128,
            // but change the fragmentation behavior.
            options.DontFragment = true;

            // Create a buffer of 32 bytes of data to be transmitted.
            string data = "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa";
            byte[] buffer = Encoding.ASCII.GetBytes(data);
            int timeout = 120;
            PingReply reply = pingSender.Send(address, timeout, buffer, options);
            if (reply.Status == IPStatus.Success)
            {
                return true;
            }

            return false;
        }

        #endregion

        #region Regex

        public const string MatchEmailPattern =
                  @"^(([\w-]+\.)+[\w-]+|([a-zA-Z]{1}|[\w-]{2,}))@"
           + @"((([0-1]?[0-9]{1,2}|25[0-5]|2[0-4][0-9])\.([0-1]?
				[0-9]{1,2}|25[0-5]|2[0-4][0-9])\."
           + @"([0-1]?[0-9]{1,2}|25[0-5]|2[0-4][0-9])\.([0-1]?
				[0-9]{1,2}|25[0-5]|2[0-4][0-9])){1}|"
           + @"([a-zA-Z]+[\w-]+\.)+[a-zA-Z]{2,4})$";

        public static bool IsEmail(string email)
        {
            if (email != null) return Regex.IsMatch(email, MatchEmailPattern);
            else return false;
        }

        #endregion

        public static void Log(string entry)
        {
            Console.WriteLine(entry);
            StreamWriter sw = new StreamWriter(string.Format("log{0:yyyyMMdd}.txt", DateTime.Today), true);
            sw.WriteLine(string.Format("{0:yyyy-MM-dd HH:mm:ss}\t{1}", DateTime.Now, entry));
            sw.Flush();
            sw.Close();
            sw.Dispose();
        }

        /// <summary>
        /// Agrega espaciones en blanco al final de una cadena
        /// </summary>
        /// <param name="str">La cadena a modificar</param>
        /// <param name="spaces">La cantidad de espacios en blanco a agregar</param>
        /// <returns>string</returns>
        public static string AddSpaces(string str, int spaces)
        {
            string blankspaces = "";
            int i;
            for (i = 0; i <= spaces; i++)
            {
                blankspaces += " ";
            }
            return blankspaces + str + blankspaces;
        }

        /// <summary>
        /// Regresa una cadena con formato "N2"
        /// </summary>
        /// <param name="valor">Valor a aplicar el formato</param>
        /// <returns>string</returns>
        public static string N2(object valor)
        {
            return string.Format("{0:N2}", valor);
        }


        /// <summary>
        /// Determina si una cadena es numerica
        /// </summary>
        /// <param name="valor">El valor a evaluar</param>
        /// <returns>bool</returns>
        public static bool IsNumeric(object valor)
        {
            Decimal d;
            return Decimal.TryParse(valor.ToString(), out d);
        }

        /// <summary>
        /// Evalua una expresion y si esta es nula, regresa un reemplazo
        /// </summary>
        /// <param name="expression">La expresion a evaluar</param>
        /// <param name="replacement">El reemplazo a retornar</param>
        /// <returns>object</returns>
        public static object IsNull(object expression, object replacement)
        {
            if (expression == null || Convert.IsDBNull(expression))
            {
                return replacement;
            }
            else
            {
                if (expression.GetType() == typeof(string))
                {
                    if ((string)expression == "" || (string)expression == string.Empty)
                    {
                        return replacement;
                    }
                }
                return expression;
            }
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

        /// <summary>
        /// Regresa un entero nulable a partir de una expresión evaluada
        /// </summary>
        /// <param name="expression">La expresión a evaluar</param>
        /// <returns>int?</returns>
        public static int? GetNullable(object expression)
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

        /// <summary>
        /// Realiza el envio de un email
        /// </summary>
        /// <param name="from">Remitente</param>
        /// <param name="to">A quien va dirijido</param>
        /// <param name="title">Titulo del mensaje</param>
        /// <param name="body">Cuerpo del mensaje</param>
        /// <param name="isHTML">Especifica si es HTML</param>
        public static void SendEmail(string from, string to,
            string title, string body, bool isHTML)
        {
            System.Net.Mail.MailMessage correo = new System.Net.Mail.MailMessage();

            correo.From = new System.Net.Mail.MailAddress(from);
            correo.To.Add(to);
            correo.Subject = title;
            correo.Body = body;
            correo.IsBodyHtml = isHTML;
            correo.Priority = System.Net.Mail.MailPriority.Normal;

            System.Net.Mail.SmtpClient smtp = new System.Net.Mail.SmtpClient("mail.casco.com.mx");
            smtp.Port = 587;
            smtp.Credentials = new System.Net.NetworkCredential("sicas@casco.com.mx", "Tr1nyt1?");

            smtp.Send(correo);
        }

        /// <summary>
        /// Realiza el envio de un email
        /// </summary>
        /// <param name="from">Remitente</param>
        /// <param name="to">A quien va dirijido</param>
        /// <param name="title">Titulo del mensaje</param>
        /// <param name="body">Cuerpo del mensaje</param>
        /// <param name="attachments">Datos adjuntos</param>
        public static void SendEmail(string from, string to,
            string title, string body, List<string> attachments)
        {
            System.Net.Mail.MailMessage correo = new System.Net.Mail.MailMessage();

            correo.From = new System.Net.Mail.MailAddress(from);
            correo.To.Add(to);
            correo.Subject = title;
            correo.Body = body;
            correo.IsBodyHtml = true;
            correo.Priority = System.Net.Mail.MailPriority.Normal;

            foreach (string attach in attachments)
            {
                correo.Attachments.Add(new System.Net.Mail.Attachment(attach));
            }
            
            System.Net.Mail.SmtpClient smtp = new System.Net.Mail.SmtpClient("mail.casco.com.mx");
            smtp.Port = 587;
            smtp.Credentials = new System.Net.NetworkCredential("sicas@casco.com.mx", "Tr1nyt1?");

            smtp.Send(correo);
        }

        /// <summary>
        /// Realiza la carga de un archivo a una ubicación remota por medio del protocolo FTP
        /// </summary>
        /// <param name="filename">El nombre del archivo</param>
        /// <param name="destination">El destino del archivo</param>
        /// <param name="ftpUserID">ID de usuario FTP</param>
        /// <param name="ftpPassword">La contraseña del usuario</param>
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
                throw new Exception("Upload error");
            }
        }

        public static long FTP_FILESIZE = 0;
        public static int FTP_PERCENT = 0;
        public static bool FTP_ISBUSY = false;

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

        public static string HTTPDownload(string url, string user, string pwd)
        {
            WebClient wc = new WebClient();

            if (!string.IsNullOrEmpty(user) && !string.IsNullOrEmpty(pwd)) wc.Credentials = new NetworkCredential(user, pwd);

            return wc.DownloadString(url);
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


        /// <summary>
        /// Clase que permite exportar el contenido de un DataTable
        /// </summary>
        public class DataTableExport
        {

            private const string TAB = "\t";
            private const string BR = "\r\n";

            public static object IfNull(object obj, object ret)
            {
                if ((obj == null) | Convert.IsDBNull(obj))
                {
                    return ret;
                }
                else
                {
                    return obj;
                }
            }

            public static string TableToHTML(DataTable dt)
            {

                StringBuilder sb = new StringBuilder();

                sb.Append("<table border=\"1\" cellspacing=\"0\" cellpadding=\"1\" rules=\"rows\">" + BR);

                string cols = string.Empty;

                foreach (System.Data.DataColumn dc in dt.Columns)
                {
                    cols += Th(dc.ColumnName);
                }

                sb.Append(Tr(cols));

                foreach (System.Data.DataRow dr in dt.Rows)
                {
                    cols = string.Empty;
                    foreach (System.Data.DataColumn dc in dt.Columns)
                    {
                        cols += Td(AppHelper.IsNull(dr[dc.ColumnName], "").ToString());
                    }
                    sb.Append(Tr(cols));
                }

                sb.Append(BR + "</table>");

                return sb.ToString();
            }

            private static string Th(object dato)
            {
                return "<th styile=\"background-color:#99B3FF\">" + Convert.ToString(dato) + "</th>";
            }

            private static string Td(object dato)
            {
                return "<td>" + Convert.ToString(dato) + "</td>";
            }

            private static string Td(object dato, Color color)
            {
                return "<td style='color: " + System.Drawing.ColorTranslator.ToHtml(color) + "'>" + Convert.ToString(dato) + "</td>";
            }

            private static string Tr(string celdas)
            {
                return "<tr>" + celdas + "</tr>";
            }

        }

        public static DateTime FechaFinal(DateTime fecha)
        {
            return fecha.Date.AddHours(23).AddMinutes(59).AddSeconds(59);
        }

        public static DateTime FechaInicial(DateTime fecha)
        {
            return fecha.Date;
        }


        /// <summary>
        /// Asistente para auditar performance de operaciones
        /// midiendo el tiempo que se necesita para realizarlas
        /// </summary>
        public static class Audit
        {
            #region Variables
            private static DateTime FechaInicial;
            private static DateTime FechaFinal;
            private static TimeSpan Tiempo;
            private static string NombreProcedimiento;
            private static string LogFile =
                System.IO.Path.Combine(System.Environment.CurrentDirectory, "auditlog.log");
            #endregion

            #region Methodos
            /// <summary>
            /// Calcula el tiempo que tomó llevar a cabo la operación auditada
            /// </summary>
            private static void Calcular()
            {
                Tiempo = FechaFinal.Subtract(FechaInicial);
            }

            /// <summary>
            /// Inicia el conteo de tiempo para la operación
            /// </summary>
            public static void Inicia()
            {
                FechaInicial = DateTime.Now;
            }

            /// <summary>
            /// Inicia el conteo de tiempo para la operación
            /// </summary>
            /// <param name="nombreProc">El nombre del procedimiento a auditar</param>
            public static void Inicia(string nombreProc)
            {
                NombreProcedimiento = nombreProc;
                FechaInicial = DateTime.Now;
            }

            /// <summary>
            /// Indica que termina la operación, se calcula el tiempo
            /// y se guardan los datos
            /// </summary>
            public static void Finaliza()
            {
                FechaFinal = DateTime.Now;
                Calcular();
                Log();
            }

            /// <summary>
            /// Registra la operación en un archivo de registro
            /// </summary>
            private static void Log()
            {
                StreamWriter sw =
                    new StreamWriter(
                        LogFile,
                        true
                    );

                sw.WriteLine("-----------------------");
                sw.WriteLine("Proc:\t" + NombreProcedimiento);
                sw.WriteLine("Ms:\t" + Math.Round(Tiempo.TotalMilliseconds, 0).ToString());
                sw.Flush();
                sw.Close();
            }
            #endregion
        }
    } //    end class AppHelper

    public static class StringHelper
    {
        public static string Left(string str, int len)
        {
            if (str.Length < len)
            {
                return str;
            }
            return str.Substring(0, len);
        }

        public static string Right(string str, int len)
        {
            if (str.Length < len)
            {
                return str;
            }
            return str.Substring(str.Length - len);
        }

        public static string Mid(string str, int start, int len)
        {
            if (str.Length < start)
            {
                return str;
            }

            if (str.Length < (start + len))
            {
                return str;
            }

            return str.Substring(start, len);
        }

        public static string Reverse(string s)
        {
            char[] arr = s.ToCharArray();
            Array.Reverse(arr);
            return new string(arr);
        }

        public static int CountStringOccurrences(string text, string pattern)
        {
            // Loop through all instances of the string 'text'.
            int count = 0;
            int i = 0;
            while ((i = text.IndexOf(pattern, i)) != -1)
            {
                i += pattern.Length;
                count++;
            }
            return count;
        }

    } // public class Strings

}
