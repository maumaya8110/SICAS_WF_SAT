using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Drawing.Imaging;
using System.Drawing.Printing;
using Microsoft.Reporting.WinForms;
using System.Windows.Forms;

namespace SICASv20
{
    public class PrintReportHelper : IDisposable
    {

        public int m_currentPageIndex;

        public IList<Stream> m_streams;
        private string _Impresora;
        public string Impresora
        {
            get { return _Impresora; }
            set { _Impresora = value; }
        }

        private double _Ancho;
        public double Ancho
        {
            get { return _Ancho; }
            set { _Ancho = value; }
        }

        private double _Alto;
        public double Alto
        {
            get { return _Alto; }
            set { _Alto = value; }
        }

        private Stream CreateStream(string name, string fileNameExtension, Encoding encoding, string mimeType, bool willSeek)
        {

            Stream stream = new FileStream(Application.StartupPath + name + "." + fileNameExtension, FileMode.Create);

            m_streams.Add(stream);
            return stream;

        }

        public void Export(LocalReport report)
        {
            string deviceInfo = "<DeviceInfo>" + "  <OutputFormat>EMF</OutputFormat>" + "  <PageWidth>" + Convert.ToString(this.Ancho) + "in</PageWidth>" + "  <PageHeight>" + Convert.ToString(this.Alto) + "in</PageHeight>" + "  <MarginTop>0.039in</MarginTop>" + "  <MarginLeft>0.118in</MarginLeft>" + "  <MarginRight>0.039in</MarginRight>" + "  <MarginBottom>0.275in</MarginBottom>" + "</DeviceInfo>";
            Warning[] warnings = null;
            m_streams = new List<Stream>();
            report.Render("Image", deviceInfo, CreateStream, out warnings);
            Stream stream = null;
            foreach (Stream stream_loopVariable in m_streams)
            {
                stream = stream_loopVariable;
                stream.Position = 0;
            }
        }

        private void PrintPage(object sender, PrintPageEventArgs ev)
        {
            Metafile pageImage = new Metafile(m_streams[m_currentPageIndex]);
            ev.Graphics.DrawImage(pageImage, ev.PageBounds);

            m_currentPageIndex += 1;
            ev.HasMorePages = (m_currentPageIndex < m_streams.Count);
        }

        public void Print()
        {
            //Dim printerName As String = Me.Impresora

            if (m_streams == null | m_streams.Count == 0)
            {
                return;
            }

            PrintDocument printDoc = new PrintDocument();
            //printDoc.DefaultPageSettings.Margins.Top = 0
            //printDoc.DefaultPageSettings.Margins.Left = 0
            //printDoc.DefaultPageSettings.Margins.Bottom = 0
            //printDoc.DefaultPageSettings.Margins.Right = 0
            printDoc.DefaultPageSettings.Landscape = true;

            //printDoc.PrinterSettings.PrinterName = Me.Impresora
            //If Not printDoc.PrinterSettings.IsValid Then
            //    Dim msg As String = String.Format("Can't find printer ""{0}"".", Me.Impresora)
            //    MsgBox(msg)
            //    Return
            //End If
            printDoc.PrintPage += PrintPage;
            printDoc.Print();

            if ((m_streams != null))
            {
                Stream stream = null;
                foreach (Stream stream_loopVariable in m_streams)
                {
                    stream = stream_loopVariable;
                    FileStream f = (FileStream)stream;
                    string fname = f.Name;
                    //MsgBox(f.Name)
                    //f.Flush()
                    //f.Close()
                    stream.Flush();
                    stream.Close();
                    File.Delete(fname);
                }
                m_streams = null;
            }

        }

        public void Dispose()
        {
            if ((m_streams != null))
            {
                Stream stream = null;
                foreach (Stream stream_loopVariable in m_streams)
                {
                    stream = stream_loopVariable;
                    FileStream f = (FileStream)stream;
                    string fname = f.Name;
                    //MsgBox(f.Name)
                    //f.Flush()
                    //f.Close()
                    stream.Flush();
                    stream.Close();
                    File.Delete(fname);
                }
                m_streams = null;

            }
        }


        #region "Funciones"

        public object Currency(object p_Objeto)
        {
            return string.Format("{0:c}", p_Objeto);
        }

        public string GetAppPath()
        {
            return System.IO.Directory.GetCurrentDirectory();
        }

        //Using this function, here's how you can set up the Value 
        //property of the logo image to point to the external AWC.jpg file.


        //=String.Format("file:///{0}\{1}", Code.GetAppPath(), "AWC.jpg")

        #endregion

    } // end class

}