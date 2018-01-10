using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using Microsoft.VisualBasic;
using System.Data;
using System.Diagnostics;
using Microsoft.Reporting.WinForms;
using System.IO;
using System.Drawing.Printing;
using System.Drawing.Imaging;
using System.Drawing;
using System.Net;

namespace SICASBot
{
    class AppHelper
    {
        private static string _Usuario = "adminsys";
        public static string Usuario
        {
            get { return _Usuario; }
            set { _Usuario = value; }
        }

        private static int _Sesion_ID = 1;
        public static int Sesion_ID
        {
            get { return _Sesion_ID; }
            set { _Sesion_ID = value; }
        }

        private static int _Caja_ID = 1;
        public static int Caja_ID
        {
            get { return _Caja_ID; }
            set { _Caja_ID = value; }
        }

        private static int _Empresa_ID = 1;
        public static int Empresa_ID
        {
            get { return _Empresa_ID; }
            set { _Empresa_ID = value; }
        }

        private static int _Estacion_ID = 1;
        public static int Estacion_ID
        {
            get { return _Estacion_ID; }
            set { _Estacion_ID = value; }
        }

        private static int _ConceptoPago = 88;
        public static int ConceptoPago
        {
            get { return _ConceptoPago; }
            set { _ConceptoPago = value; }
        }

        private static int _ConceptoPagoConductores = 89;
        public static int ConceptoPagoConductores
        {
            get { return _ConceptoPagoConductores; }
            set { _ConceptoPagoConductores = value; }
        }

        private static int _CuentaServiciosConductores = 9;
        public static int CuentaServiciosConductores
        {
            get { return _CuentaServiciosConductores; }
            set { _CuentaServiciosConductores = value; }
        }

        private static int _ConceptoAbonoServiciosConductores = 91;
        public static int ConceptoAbonoServiciosConductores
        {
            get { return _ConceptoAbonoServiciosConductores; }
            set { _ConceptoAbonoServiciosConductores = value; }
        }

        private static int _ConceptoCargoServiciosConductores = 90;
        public static int ConceptoCargosServiciosConductores
        {
            get { return _ConceptoCargoServiciosConductores; }
            set { _ConceptoCargoServiciosConductores = value; }
        }

        public static void ReconfigureUsuarios()
        {
            string sql = @"USE SICASSync
GO

UPDATE Usuarios
SET	Empresa_ID = 2, Estacion_ID = 11
WHERE	Usuario_ID IN (
	'pablo.alejos',
	'supervisor.pablolivas',
	'ventas.pablolivas'	
)

UPDATE Usuarios
SET	Empresa_ID = NULL, Estacion_ID = NULL
WHERE	Usuario_ID IN (
	'pedro.rodriguez',
	'ricardo.sanchez',
	'benito.flores',
	'jose.landa',
    'claudia.macias'
)

UPDATE Usuarios
SET	Empresa_ID = 601, Estacion_ID = 13
WHERE	Usuario_ID IN (
	'LUIS.ESCAREÃ‘O',
    'luis.escareÃ±o',
    'luis.escareño'
)

UPDATE Usuarios SET Empresa_ID = 4, Estacion_ID = 1
WHERE Usuario_ID in
(
'armando.guevara',
'oscar.rodriguez',
'salvador.cardenas',
'david.dimas',
'antonio.ariza'
)

GO";
            Central.DB.ExecuteBatch(sql);
            Console.Write("Usuarios Reconfigurados");
        }

        private static string _ImagePath = System.Environment.CurrentDirectory + "\\images\\";
        public static string ImagePath
        {
            get { return _ImagePath; }
        }

        #region Delegate
        public delegate void HelperDelegate();

        //public static void DoMethod(HelperDelegate method, forms.baseForm bForm)
        //{
        //    try
        //    {
        //        bForm.Enabled = false;
        //        bForm.Cursor = Cursors.WaitCursor;

        //        method();
        //    }
        //    catch (Exception ex)
        //    {
        //        Error(ex.Message);
        //    }
        //    finally
        //    {
        //        bForm.Enabled = true;
        //        bForm.Cursor = Cursors.Default;
        //    }
        //}

        //  Call this way:  MyMain(new MyDelegate(DoSome));
        #endregion

        public static object Iif(bool condition, object truePart, object falsePart)
        {
            if (condition)
            {
                return truePart;
            }
            else
            {
                return falsePart;
            }
        }

        /// <summary>
        /// Enumeracion de reglas de validacion para controles
        /// </summary>
        public enum ValidateRule
        {
            Required = 1,
            Numeric = 2
        }

        /// <summary>
        /// Aplica opciones de validación a un control
        /// </summary>
        /// <param name="ctrl">El control a validar</param>
        /// <param name="args">Los argumentos de validacion</param>
        public static void ValidateControl(Control ctrl, params ValidateRule[] args)
        {
            if (ctrl.GetType() == typeof(TextBox))
            {
                TextBox txt = (TextBox)ctrl;

                foreach (ValidateRule rule in args)
                {
                    switch (rule)
                    {
                        case ValidateRule.Numeric:
                            if (!IsNumeric(txt.Text))
                            {
                                throw new Exception("El valor debe ser numérico!");
                            }
                            break;
                        case ValidateRule.Required:
                            if (txt.Text == "")
                            {
                                throw new Exception(String.Format("Debe capturar un valor para el control {0}", txt.Name));
                            }
                            break;
                    }
                }
            }
            else if (ctrl.GetType() == typeof(ComboBox))
            {
                ComboBox cbo = (ComboBox)ctrl;

                foreach (ValidateRule rule in args)
                {
                    switch (rule)
                    {
                        case ValidateRule.Required:
                            if (cbo.SelectedValue == null)
                            {
                                throw new Exception(String.Format("Debe capturar un valor para el control {0}", cbo.Name));
                            }
                            break;
                    }
                }
            }
        }

        //private void TestX()
        //{
        //    System.Data.SqlClient.SqlDataReader dr;
        //    while (dr.Read())
        //    {
        //        Console.WriteLine(dr["Eso es"]);
        //    }            
        //}

        /// <summary>
        /// Devuelde la fecha y hora actual del servidor
        /// </summary>
        /// <returns>Datetime</returns>
        //public static DateTime GetDate()
        //{
        //    //SICASCentralQuerysDataSetTableAdapters.Functions functions = new SICASCentralQuerysDataSetTableAdapters.Functions();
        //    //return (DateTime)functions.GetDate();
        //}

        /// <summary>
        /// Muestra un cuadro de dialogo de error
        /// </summary>
        /// <param name="msg">El mensaje a desplegar</param>
        public static void Error(string msg)
        {
            MessageBox.Show(msg, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        /// <summary>
        /// Muestra un cuadro de dialogo informativo
        /// </summary>
        /// <param name="msg">El mensaje a desplegar</param>
        public static void Info(string msg)
        {
            MessageBox.Show(msg, "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        /// <summary>
        /// Devuelve un cuadro de dialogo de confirmacion
        /// </summary>
        /// <param name="msg">El mensaje a desplegar</param>
        /// <returns>DialogResult</returns>
        public static DialogResult Confirm(string msg)
        {
            return MessageBox.Show(msg, "Info", MessageBoxButtons.YesNo);
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
        /// Realiza la sumatoria de todos los valores de una columna en un DataGridView
        /// </summary>
        /// <param name="dgv">El DataGridView sobre el cual se realizará la operación</param>
        /// <param name="column">La columna a sumar</param>
        /// <returns></returns>
        public static decimal DGVSum(DataGridView dgv, string column)
        {
            decimal ret = 0;

            foreach (DataGridViewRow row in dgv.Rows)
            {
                if (row.Cells[column].Value != null &&
                        !Convert.IsDBNull(row.Cells[column]))
                {
                    ret += Convert.ToDecimal(row.Cells[column].Value);
                }
            }

            return ret;
        }

        /// <summary>
        /// Pone en blanco los controles de tipo TextBox pertenecientes al control especificado
        /// </summary>
        /// <param name="ctrl">El control al que se le limpiaran las cajas de texto</param>
        public static void ClearControl(Control ctrl)
        {
            foreach (Control c in ctrl.Controls)
            {
                if (c.GetType() == typeof(System.Windows.Forms.TextBox))
                {
                    c.Text = "";
                }

                if (c.GetType() == typeof(System.Windows.Forms.ComboBox))
                {
                    ComboBox cbo = (ComboBox)c;
                    cbo.SelectedIndex = 0;
                }

                if (c.GetType() == typeof(System.Windows.Forms.ListBox))
                {
                    ListBox list = (ListBox)c;
                    if (!IsNullOrEmpty(list.DataSource))
                    {
                        list.DataSource = null;
                    }
                    list.Items.Clear();
                }

                ClearControl(c);
            }
        }

        /// <summary>
        /// Aplica estilos a los controles, de manera recursiva
        /// </summary>
        /// <param name="ctrl">El control al que se aplicaran los estilos</param>
        public static void SetStylish(Control ctrl)
        {
            foreach (Control c in ctrl.Controls)
            {
                if (c.GetType() == typeof(System.Windows.Forms.DataGridView))
                {
                    SetDataGridViewProperties((DataGridView)c);
                }

                if (c.GetType() == typeof(System.Windows.Forms.Label))
                {
                    Strip_IDLabel((Label)c);
                }

                SetStylish(c);
            }
        }

        /// <summary>
        /// Elimina la cadena " ID" del texto de un control Label
        /// </summary>
        /// <param name="lbl">El control label que será modificado</param>
        public static void Strip_IDLabel(Label lbl)
        {
            lbl.Text = lbl.Text.Replace(" ID", "");
        }

        /// <summary>
        /// Configura las propiedades estandar de la aplicación a un control DataGridView
        /// </summary>
        /// <param name="dgv">Control <remarks>DataGridView</remarks> que será configurado</param>
        public static void SetDataGridViewProperties(DataGridView dgv)
        {
            dgv.AutoGenerateColumns = false;
            dgv.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            dgv.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            dgv.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleVertical;
            dgv.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgv.GridColor = System.Drawing.Color.Gainsboro;
            dgv.RowHeadersVisible = false;
            dgv.AllowUserToResizeRows = false;
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
        public static bool IsNumeric(string valor)
        {
            Decimal d;
            return Decimal.TryParse(valor, out d);
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

        public static string NewAccountMailTemplate = "Estimado {0}:\r\n" +
        "\r\n" +
        "Se ha creado una cuenta para su uso personal en el sistema \"SICAS\".\r\n" +
        "Su nombre de usuario es: {1}\r\n" +
        "Su contraseña es: {2}\r\n" +
        "\r\n" +
        "Si aun no tiene instalado el sistema o no tiene acceso, favor de \r\n" +
        "comunicarse con el administrador del sistema.\r\n" +
        "\r\n" +
        "Este mensaje a sido generado automáticamente. Por favor, no lo responda.\r\n" +
        "Gracias.";

        /// <summary>
        /// Envia un mensaje a nuevos usuarios
        /// </summary>
        /// <param name="to">A quien va dirijido</param>
        /// <param name="name">Nombre</param>
        /// <param name="username">Nombre de usuario</param>
        /// <param name="pwd">Constraseña</param>
        public static void SendNewAccountMail(string to, string name, string username, string pwd)
        {
            //  Pasar los parámetros al template
            string body = string.Format(NewAccountMailTemplate, name, username, pwd);

            //  Enviar el correo
            SendEmail("sicas@casco.com.mx", to, "Nueva cuenta de SICAS", body, false);
        }

        private static string SMTP_Server = "mail.casco.com.mx";
        private static int SMTP_Port = 587;
        private static string SMTP_Usr = "sicas@casco.com.mx";
        private static string SMTP_Pwd = "casco";
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

            System.Net.Mail.SmtpClient smtp = new System.Net.Mail.SmtpClient(SMTP_Server);
            smtp.Port = SMTP_Port;
            smtp.Credentials = new System.Net.NetworkCredential(SMTP_Usr, SMTP_Pwd);

            smtp.Send(correo);
        }

        /// <summary>
        /// Realiza el envio de un email
        /// </summary>
        /// <param name="from">Remitente</param>
        /// <param name="to">A quien va dirijido</param>
        /// <param name="title">Titulo del mensaje</param>
        /// <param name="body">Cuerpo del mensaje</param>
        /// <param name="attach">Datos adjuntos</param>
        public static void SendEmail(string from, string to,
            string title, string body, string attach)
        {
            System.Net.Mail.MailMessage correo = new System.Net.Mail.MailMessage();

            correo.From = new System.Net.Mail.MailAddress(from);
            correo.To.Add(to);
            correo.Subject = title;
            correo.Body = body;
            correo.IsBodyHtml = true;
            correo.Priority = System.Net.Mail.MailPriority.Normal;
            correo.Attachments.Add(new System.Net.Mail.Attachment(attach));

            System.Net.Mail.SmtpClient smtp = new System.Net.Mail.SmtpClient("mail.casco.com.mx");
            smtp.Port = 587;
            smtp.Credentials = new System.Net.NetworkCredential("sicas@casco.com.mx", "casco");

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
                MessageBox.Show(ex.Message, "Upload Error");
            }
        }

        /// <summary>
        /// Exporta un reporte local a una ubicación en el archivo
        /// </summary>
        /// <param name="localReport">EL reporte a exportar</param>
        /// <returns>string</returns>
        public static string ExportReport(LocalReport localReport)
        {
            Warning[] warnings;
            string[] streamids;
            string mimeType;
            string encoding;
            string filenameExtension;

            //"Excel" or "Image" or "PDF"
            byte[] bytes = localReport.Render(
                "Image", null, out mimeType, out encoding, out filenameExtension,
                 out streamids, out warnings);

            string filename = Path.Combine(Path.GetTempPath(), "ticket.emf");

            using (FileStream fs = new FileStream(filename, FileMode.Create))
            {
                fs.Write(bytes, 0, bytes.Length);
            }

            return filename;
        }

        private static string fileToPrint;
        private static LocalReport _TicketReport;
        public static LocalReport TicketReport
        {
            get { return _TicketReport; }
            set { _TicketReport = value; }
        }

        public static void PrintTicket()
        {
            Warning[] warnings;
            string[] streamids;
            string mimeType;
            string encoding;
            string filenameExtension;
            string deviceInfo = "<DeviceInfo>" +
            "  <OutputFormat>Image</OutputFormat>" +
            "  <PageWidth>" + TicketReport.GetDefaultPageSettings().PaperSize.Width.ToString() + "cm</PageWidth>" +
            "  <PageHeight>" + TicketReport.GetDefaultPageSettings().PaperSize.Height.ToString() + "cm</PageHeight>" +
            "  <MarginTop>" + TicketReport.GetDefaultPageSettings().Margins.Top.ToString() + "cm</MarginTop>" +
            "  <MarginLeft>" + TicketReport.GetDefaultPageSettings().Margins.Left.ToString() + "cm</MarginLeft>" +
            "  <MarginRight>" + TicketReport.GetDefaultPageSettings().Margins.Right.ToString() + "cm</MarginRight>" +
            "  <MarginBottom>" + TicketReport.GetDefaultPageSettings().Margins.Bottom.ToString() + "cm</MarginBottom>" +
            "</DeviceInfo>";

            // "Excel" or "Image" or "PDF"
            byte[] bytes = TicketReport.Render(
                "Image", null, out mimeType, out encoding, out filenameExtension,
                    out streamids, out warnings);

            fileToPrint = Path.Combine(Path.GetTempPath(), "ticket.tiff");

            using (FileStream fs = new FileStream(fileToPrint, FileMode.Create))
            {
                fs.Write(bytes, 0, bytes.Length);
            }

            PrintDocument pd = new PrintDocument();
            pd.PrintPage += new PrintPageEventHandler(PrintPage);
            pd.Print();
        }

        private static void PrintPage(object sender, PrintPageEventArgs ev)
        {
            //Metafile pageImage = new Metafile(fileToPrint);
            Bitmap pageImage = new Bitmap(fileToPrint);
            ev.Graphics.DrawImage(pageImage, ev.PageBounds);
        }

        /// <summary>
        /// Clase que permite exportar el contenido de un DataGridView
        /// </summary>
        public class GridExport
        {

            private const string TAB = "    ";
            private const string BR = Constants.vbCrLf;

            public static object IfNull(object obj, object ret)
            {
                if ((obj == null) | Information.IsDBNull(obj))
                {
                    return ret;
                }
                else
                {
                    return obj;
                }
            }

            public static void GridToXls(ref DataGridView dgv, string ruta)
            {

                StringBuilder sb = new StringBuilder();

                sb.Append("<table border=\"1\" cellspacing=\"0\" cellpadding=\"1\" rules=\"rows\">" + BR);

                string cols = string.Empty;

                foreach (DataGridViewColumn col in dgv.Columns)
                {
                    if (col.Visible == true)
                    {
                        cols += Th(col.Name);
                    }
                }

                sb.Append(Tr(cols));

                foreach (DataGridViewRow row in dgv.Rows)
                {
                    cols = string.Empty;
                    foreach (DataGridViewCell cel in row.Cells)
                    {
                        if (dgv.Columns[cel.ColumnIndex].Visible == true)
                        {
                            cols += Td(cel.Value.ToString());
                        }
                    }
                    sb.Append(Tr(cols));
                }

                sb.Append(BR + "</table>");

                StreamWriter sw = new StreamWriter(ruta, false);
                sw.Write(sb.ToString());
                sw.Flush();
                sw.Close();

                Process.Start(ruta);
            }

            public static string GridToHTML(ref DataGridView dgv)
            {

                StringBuilder sb = new StringBuilder();

                sb.Append("<table border=\"1\" cellspacing=\"0\" cellpadding=\"1\" rules=\"rows\">" + BR);

                string cols = string.Empty;

                foreach (DataGridViewColumn col in dgv.Columns)
                {
                    if (col.Visible == true)
                    {
                        cols += Th(col.Name);
                    }
                }

                sb.Append(Tr(cols));

                foreach (DataGridViewRow row in dgv.Rows)
                {
                    cols = string.Empty;
                    foreach (DataGridViewCell cel in row.Cells)
                    {
                        if (dgv.Columns[cel.ColumnIndex].Visible == true)
                        {
                            cols += Td(cel.Value.ToString());
                        }
                    }
                    sb.Append(Tr(cols));
                }

                sb.Append(BR + "</table>");

                return sb.ToString();
            }

            public static string DataTableToHTML(DataTable dt)
            {

                StringBuilder sb = new StringBuilder();

                sb.Append("<table border=\"1\" cellspacing=\"0\" cellpadding=\"1\" rules=\"rows\">" + BR);

                string cols = string.Empty;

                foreach (DataColumn col in dt.Columns)
                {
                    cols += Th(col.ColumnName);
                }

                sb.Append(Tr(cols));

                foreach (DataRow row in dt.Rows)
                {
                    cols = string.Empty;
                    foreach (DataColumn cel in dt.Columns)
                    {
                        cols += Td(row[cel.ColumnName].ToString());                       
                    }
                    sb.Append(Tr(cols));
                }

                sb.Append(BR + "</table>");

                return sb.ToString();
            }

            private static string Th(object dato)
            {
                return "<th>" + Convert.ToString(dato) + "</th>";
            }

            private static string Td(object dato)
            {
                return "<td>" + Convert.ToString(dato) + "</td>";
            }

            private static string Tr(string celdas)
            {
                return "<tr>" + celdas + "</tr>";
            }

        }

        //public class Formulario
        //{
        //    private string _key;
        //    public string Key
        //    {
        //        get { return _key; }
        //        set { _key = value; }
        //    }

        //    private forms.baseForm _forma;
        //    public forms.baseForm Forma
        //    {
        //        get { return _forma; }
        //        set { _forma = value; }
        //    }

        //    private string _formClass;
        //    public string FormClass
        //    {
        //        get { return _formClass; }
        //        set { _formClass = value; }
        //    }

        //    public Formulario(string key, forms.baseForm forma, string formClass)
        //    {
        //        Key = key;
        //        Forma = forma;
        //        FormClass = formClass;
        //    }
        //}

        //public class Formularios : IEnumerable
        //{
        //    private Collection c = new Collection();

        //    public void Add(Formulario formulario)
        //    {
        //        c.Add(formulario);
        //    }

        //    public void Remove(Formulario formulario)
        //    {
        //        int itemCount = 0;
        //        for (itemCount = 1; itemCount <= c.Count; itemCount++)
        //        {
        //            if (object.ReferenceEquals(formulario, c[itemCount]))
        //            {
        //                c.Remove(itemCount);
        //                break;
        //            }
        //        }
        //    }

        //    public void Clear()
        //    {
        //        c.Clear();
        //    }

        //    public Formulario Item(int index)
        //    {
        //        return (Formulario)c[index];
        //    }

        //    public int IndexOf(Formulario formulario)
        //    {
        //        int itemCount = 0;
        //        for (itemCount = 1; itemCount <= c.Count; itemCount++)
        //        {
        //            if (object.ReferenceEquals(formulario, c[itemCount]))
        //            {
        //                return itemCount;
        //            }
        //        }
        //        return -1;
        //    }

        //    public Formulario Find(string key)
        //    {
        //        int itemCount = 0;
        //        for (itemCount = 1; itemCount <= c.Count; itemCount++)
        //        {
        //            Formulario f = (Formulario)c[itemCount];
        //            if (f.Key == key)
        //            {
        //                return f;
        //            }
        //        }
        //        return null;
        //    }

        //    public int Count
        //    {
        //        get { return c.Count; }
        //    }

        //    public System.Collections.IEnumerator GetEnumerator()
        //    {
        //        return c.GetEnumerator();
        //    }

        //}
    }

    public static class Strings
    {
        public static string Left(string str, int len)
        {
            if (str.Length >= len)
            {
                return str.Substring(0, len);
            }
            else
            {
                return str;
            }            
        }

        public static string Right(string str, int len)
        {
            if (str.Length >= len)
            {
                return str.Substring(str.Length - len);
            }
            else
            {
                return str;
            }            
        }

        public static string Mid(string str, int start, int len)
        {
            return str.Substring(start, len);
        }

        public static string Reverse(string s)
        {
            char[] arr = s.ToCharArray();
            Array.Reverse(arr);
            return new string(arr);
        }

    } // public class Strings
    class SICASException : Exception
    {
        public SICASException()
        {
        }

        public SICASException(string message)
            : base(message)
        {
        }

        public SICASException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

    }

    public static class SICASHelper
    {
        public enum EstacionesSICAS
        { 
            LA,
            Apto,
            PabloLivas,
            Aztlan,
            SantaCatarina
        }

        public static EstacionesSICAS Estaciones;

        public static int ConvertCuenta(int cuenta, EstacionesSICAS estacion)
        {
            Dictionary<int, int> dicApto = new Dictionary<int, int>();
            dicApto.Add(1, 9);
            dicApto.Add(2, 10);
            dicApto.Add(3, 11);
            dicApto.Add(4, 4);
            dicApto.Add(5, 12);
            dicApto.Add(6, 13);
            dicApto.Add(7, 14);
            dicApto.Add(8, 14);
            dicApto.Add(10, 1);
            dicApto.Add(11, 15);
            dicApto.Add(12, 16);
            dicApto.Add(13, 17);
            dicApto.Add(14, 18);
            dicApto.Add(15, 19);

            int ret = 0;

            switch (estacion)
            {
                case EstacionesSICAS.Apto:
                    ret = dicApto[cuenta];            
                    break;
                case EstacionesSICAS.Aztlan:
                    break;
                case EstacionesSICAS.LA:
                    break;
                case EstacionesSICAS.PabloLivas:
                    break;
                case EstacionesSICAS.SantaCatarina:
                    break;
            }

            if (ret == 0) throw new Exception("No hay valor correspondiente");
            return ret;
        }
    }
}
