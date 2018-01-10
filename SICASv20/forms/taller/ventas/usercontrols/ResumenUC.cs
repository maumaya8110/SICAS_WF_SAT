using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Microsoft.VisualBasic;

namespace SICASv20.forms
{
    public partial class ResumenUC : baseUserControl
    {
        public ResumenUC()
        {
            InitializeComponent();
            AppHelper.SetStylish(this);
        }

        public NuevaOrdenTrabajo Padre;

        private void InsertOrden()
        {
            Padre.OrdenTrabajo.Empresa_ID = Sesion.Empresa_ID.Value;
            Padre.OrdenTrabajo.Estacion_ID = Sesion.Estacion_ID.Value;
            Padre.OrdenTrabajo.FechaAlta = DB.GetDate();
            Padre.OrdenTrabajo.Usuario_ID = Sesion.Usuario_ID;            
            Padre.OrdenTrabajo.EstatusOrdenTrabajo_ID = 1;
            Padre.OrdenTrabajo.CB_Activo = true;

            Padre.OrdenTrabajo.Create();
            int i = 0, j = 0;

            for(i = 0; i < Padre.OrdenTrabajo.OrdenesServicios.Count; i++)
            {                
                Entities.OrdenesServicios os = Padre.OrdenTrabajo.OrdenesServicios[i];
                os.OrdenTrabajo_ID = Padre.OrdenTrabajo.OrdenTrabajo_ID;
                os.Fecha = Padre.OrdenTrabajo.FechaAlta;                
                os.Create();

                for (j = 0; j < os.OrdenesServiciosRefacciones.Count; j++)
                {
                    Entities.OrdenesServiciosRefacciones osr = os.OrdenesServiciosRefacciones[j];                    
                    osr.OrdenServicio_ID = os.OrdenServicio_ID;                    
                    osr.Create();
                }
            }
        }

        public void DisplayReport()
        {
            OrdenesTrabajosBindingSource.DataSource = Padre.OrdenTrabajo;
            OrdenesServiciosBindingSource.DataSource = Padre.OrdenTrabajo.OrdenesServicios;

            List<Entities.OrdenesServiciosRefacciones> ordenesServiciosRefacciones = new List<Entities.OrdenesServiciosRefacciones>();
            foreach (Entities.OrdenesServicios os in Padre.OrdenTrabajo.OrdenesServicios)
            {
                ordenesServiciosRefacciones.AddRange(os.OrdenesServiciosRefacciones);
            }

            OrdenesServiciosRefaccionesBindingSource.DataSource = ordenesServiciosRefacciones;

            OrdenTrabajoReportViewer.RefreshReport();
        }

        public void PrintReport()
        {
            AppHelper.PrintReport(
                OrdenTrabajoReportViewer.LocalReport,
                String.Format(
                    "OrdenTrabajo{0}", 
                    Padre.OrdenTrabajo.CodigoBarras
                    )
                );
        }

        #region Impresion

        private Entities.OrdenesTrabajos OrdenTrabajo;
        private List<Entities.OrdenesServiciosRefacciones> OrdenesServiciosRefacciones;


        public void ImprimirOrdenTrabajo(int p_OrdenTrabajo)
        {
            try
            {

                OrdenTrabajo = Entities.OrdenesTrabajos.Read(p_OrdenTrabajo);
                OrdenesServiciosRefacciones = new List<Entities.OrdenesServiciosRefacciones>();

                foreach (Entities.OrdenesServicios os in OrdenTrabajo.OrdenesServicios)
                {
                    OrdenesServiciosRefacciones.AddRange(os.OrdenesServiciosRefacciones);
                }

                System.Drawing.Printing.PrintDocument PrintDoc2 = new System.Drawing.Printing.PrintDocument();
                System.Drawing.Printing.PrintDocument PrintDoc = new System.Drawing.Printing.PrintDocument();

                PrintDoc2.DocumentName = "OrdenDeTrabajo" + p_OrdenTrabajo.ToString();
                PrintDoc.DocumentName = "OrdenDeTrabajo" + p_OrdenTrabajo.ToString();

                PrintDoc2.PrintPage += PrintDoc_PrintPageSinEncuesta;
                PrintDoc.PrintPage += PrintDoc_PrintPage;

                PrintDoc2.Print();                                              
                PrintDoc.Print();

                //PrintPreviewDialog preview = new PrintPreviewDialog();
                //preview.Document = PrintDoc2;
                //preview.Height = Screen.PrimaryScreen.Bounds.Height;
                //preview.Width = Screen.PrimaryScreen.Bounds.Width;
                //preview.ShowDialog();

            }
            catch (Exception ex)
            {
                AppHelper.Error(ex.Message);
            }

        }

        public void ImprimirOrdenTrabajoActual()
        {
            try
            {
                Padre.OrdenTrabajo.Empresa_ID = Sesion.Empresa_ID.Value;
                Padre.OrdenTrabajo.Estacion_ID = Sesion.Estacion_ID.Value;
                Padre.OrdenTrabajo.FechaAlta = DB.GetDate();
                Padre.OrdenTrabajo.Usuario_ID = Sesion.Usuario_ID;
                Padre.OrdenTrabajo.EstatusOrdenTrabajo_ID = 1;
                Padre.OrdenTrabajo.CB_Activo = true;
                Padre.OrdenTrabajo.CodigoBarras = "SINCODIGO";

                OrdenTrabajo = Padre.OrdenTrabajo;
                OrdenesServiciosRefacciones = new List<Entities.OrdenesServiciosRefacciones>();

                foreach (Entities.OrdenesServicios os in OrdenTrabajo.OrdenesServicios)
                {
                    OrdenesServiciosRefacciones.AddRange(os.OrdenesServiciosRefacciones);
                }

                System.Drawing.Printing.PrintDocument PrintDoc2 = new System.Drawing.Printing.PrintDocument();
                System.Drawing.Printing.PrintDocument PrintDoc = new System.Drawing.Printing.PrintDocument();

                PrintDoc2.DocumentName = "OrdenDeTrabajo" + OrdenTrabajo.OrdenTrabajo_ID.ToString();
                PrintDoc.DocumentName = "OrdenDeTrabajo" + OrdenTrabajo.OrdenTrabajo_ID.ToString();

                PrintDoc2.PrintPage += PrintDoc_PrintPageSinEncuesta;
                PrintDoc.PrintPage += PrintDoc_PrintPage;

                PrintDoc2.Print();
                PrintDoc.Print();

                
            }
            catch (Exception ex)
            {
                AppHelper.Error(ex.Message);
            }

        }
        private void PrintDoc_PrintPageSinEncuesta(System.Object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            this.DibujaOrdenTrabajoSinEncuesta(e);
        }

        private void PrintDoc_PrintPage(System.Object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            this.DibujaOrdenTrabajo(e);
        }

        public void DibujaOrdenTrabajoSinEncuesta(System.Drawing.Printing.PrintPageEventArgs e)
        {
            Font _Fuente8 = new Font("Arial", 8);
            Font _Fuente10 = new Font("Arial", 10);
            Font _Fuente12 = new Font("Arial", 12);
            Font _Fuente10Bold = new Font("Arial", 10, FontStyle.Bold);
            Font _Fuente12Bold = new Font("Arial", 12, FontStyle.Bold);
            Font _Fuente14Bold = new Font("Arial", 14, FontStyle.Bold);
            Font _FuenteCodBar = new Font("Code 39", 12);
            double TotalServicios = 0;
            double TotalRefacciones = 0;

            //Me.PrintDoc.DefaultPageSettings.PaperSize = New PaperSize("Boleto", 787, 196)
            //Dim dtFiscales As New DataTable

            //dtFiscales = TL.DatosFiscales()
            Bitmap img = new Bitmap(global::SICASv20.Properties.Resources.CSC, 114, 73);
            Bitmap enc = new Bitmap(global::SICASv20.Properties.Resources.encuesta, 400, 500);
            var _with1 = e.Graphics;

            float x1 = 0;
            float y = 0;
            float x2 = 0;
            float x3 = 0;
            float x4 = 0;
            y = 10;
            x1 = 10;
            x2 = 340;
            x3 = 490;
            x4 = 625;

            _with1.DrawLine(Pens.Black, x1, y, 900, y);
            _with1.DrawImage(img, x1 + 1, y + 1);
            _with1.DrawString("*" + OrdenTrabajo.CodigoBarras + "*", _FuenteCodBar, Brushes.Black, x1, y + 80);
            _with1.DrawString(OrdenTrabajo.CodigoBarras, _Fuente8, Brushes.Black, x1, y + 95);
            _with1.DrawLine(Pens.Black, x1, y + 105, 900, y + 108);

            _with1.DrawString("CASCO SERVICE CENTER", _Fuente14Bold, Brushes.Black, 300, y + 30);
            _with1.DrawString("ORDEN DE TRABAJO", _Fuente12Bold, Brushes.Black, 350, y + 50);

            if (!(Padre.OrdenTrabajo.TipoMantenimiento_ID == 19))
            {
                _with1.DrawString("FOLIO: " + OrdenTrabajo.OrdenTrabajo_ID.ToString(), _Fuente12Bold, Brushes.Black, 380, y + 65);
            }
            else
            {
                _with1.DrawString("===   COTIZACION   ===", _Fuente12Bold, Brushes.Black, 380, y + 65);
            }
                        
            _with1.DrawString(DateAndTime.Now.ToShortDateString(), _Fuente10, Brushes.Black, 350, y + 80);
            _with1.DrawString(DateAndTime.Now.ToShortTimeString(), _Fuente10, Brushes.Black, 450, y + 80);

            _with1.DrawString("Unidad:" + Strings.Chr(9) + OrdenTrabajo.NumeroEconomico.ToString(), _Fuente10, Brushes.Black, x1, y + 115);
            _with1.DrawString("Cliente: " + OrdenTrabajo.Cliente_Nombre, _Fuente10, Brushes.Black, x1, y + 140);
            _with1.DrawString("Mecánico: " + OrdenTrabajo.OrdenesServicios[0].Mecanico_Nombre, _Fuente10, Brushes.Black, x1, y + 165);
            _with1.DrawString("Kilometraje: " + OrdenTrabajo.Kilometraje.ToString(), _Fuente10, Brushes.Black, x1, y + 185);
            y += 85;

            _with1.DrawString("SERVICIOS DE MANO DE OBRA:", _Fuente10Bold, Brushes.Black, x1, y + 130);
            _with1.DrawLine(Pens.Black, x1, y + 145, 700, y + 145);
            _with1.DrawString("SERVICIO", _Fuente10, Brushes.Black, x1, y + 146);
            _with1.DrawString("CANTIDAD", _Fuente10, Brushes.Black, x2, y + 146);
            _with1.DrawString("P.U.", _Fuente10, Brushes.Black, x3, y + 146);
            _with1.DrawString("TOTAL", _Fuente10, Brushes.Black, x4, y + 146);
            _with1.DrawLine(Pens.Black, x1, y + 160, 700, y + 160);

            TotalServicios = 0;
            y = y + 161;
            foreach (Entities.OrdenesServicios os in OrdenTrabajo.OrdenesServicios)
            {
                _with1.DrawString(Strings.UCase(os.ServicioMantenimiento_Descripcion), _Fuente10, Brushes.Black, x1, y);
                _with1.DrawString(Strings.Format(os.Cantidad, "###,###.00"), _Fuente10, Brushes.Black, x2, y);
                _with1.DrawString(Strings.Format(os.Precio, "$ #,###.00"), _Fuente10, Brushes.Black, x3, y);
                _with1.DrawString(Strings.Format(os.Total, "$ #,###.00"), _Fuente10, Brushes.Black, x4, y);
                y += 15;
                TotalServicios += Convert.ToDouble(os.Total);
            }
            _with1.DrawLine(Pens.Black, x1, y, 700, y);
            _with1.DrawString("TOTAL MANO DE OBRA:", _Fuente10, Brushes.Black, x2 + 70, y + 1);
            _with1.DrawString(Strings.Format(TotalServicios, "$ ##,###.00"), _Fuente10Bold, Brushes.Black, x4, y + 1);

            _with1.DrawString("REFACCIONES:", _Fuente10Bold, Brushes.Black, x1, y + 20);
            _with1.DrawLine(Pens.Black, x1, y + 35, 700, y + 35);
            _with1.DrawString("REFACCION", _Fuente10, Brushes.Black, x1, y + 36);
            _with1.DrawString("CANTIDAD", _Fuente10, Brushes.Black, x2, y + 36);
            _with1.DrawString("P.U.", _Fuente10, Brushes.Black, x3, y + 36);
            _with1.DrawString("TOTAL", _Fuente10, Brushes.Black, x4, y + 36);
            _with1.DrawLine(Pens.Black, x1, y + 50, 700, y + 50);

            TotalRefacciones = 0;
            y += 51;

            foreach (Entities.OrdenesServiciosRefacciones osr in OrdenesServiciosRefacciones)
            {
                _with1.DrawString(Strings.UCase(osr.Refaccion_Descripcion), _Fuente10, Brushes.Black, x1, y);
                _with1.DrawString(Strings.Format(osr.Cantidad, "###,###.00"), _Fuente10, Brushes.Black, x2, y);
                _with1.DrawString(Strings.Format(osr.PrecioUnitario, "$ #,###.00"), _Fuente10, Brushes.Black, x3, y);
                _with1.DrawString(Strings.Format(osr.Total, "$ #,###.00"), _Fuente10, Brushes.Black, x4, y);
                y += 15;
                TotalRefacciones += Convert.ToDouble(osr.Total);
            }

            _with1.DrawLine(Pens.Black, x1, y, 700, y);
            _with1.DrawString("TOTAL REFACCIONES:", _Fuente10, Brushes.Black, x2 + 70, y + 1);
            _with1.DrawString(Strings.Format(TotalRefacciones, "$ ##,###.00"), _Fuente10Bold, Brushes.Black, x4, y + 1);

            _with1.DrawLine(Pens.Black, x1, y + 15, 700, y + 15);
            _with1.DrawString("SUBTOTAL:", _Fuente10, Brushes.Black, x2 + 70, y + 16);
            _with1.DrawString(Strings.Format(OrdenTrabajo.Subtotal, "$ ##,###.00"), _Fuente10Bold, Brushes.Black, x4, y + 16);

            _with1.DrawString("IVA:", _Fuente10, Brushes.Black, x2 + 70, y + 31);
            _with1.DrawString(Strings.Format(OrdenTrabajo.IVA, "$ ##,###.00"), _Fuente10Bold, Brushes.Black, x4, y + 31);

            _with1.DrawString("TOTAL:", _Fuente10, Brushes.Black, x2 + 70, y + 46);
            _with1.DrawString(Strings.Format(OrdenTrabajo.Total, "$ ##,###.00"), _Fuente10Bold, Brushes.Black, x4, y + 46);

            _with1.DrawString("__________________________________________", _Fuente10, Brushes.Black, x1, y + 140);
            _with1.DrawString("ASISTENTE TALLER", _Fuente10Bold, Brushes.Black, x1, y + 160);

            _with1.DrawString("__________________________________________", _Fuente10, Brushes.Black, x3, y + 140);
            _with1.DrawString("CLIENTE", _Fuente10Bold, Brushes.Black, x3, y + 160);


            // La segunda página

            y += 200;
            _with1.DrawLine(Pens.Black, x1, y, 900, y);
            _with1.DrawImage(img, x1 + 1, y + 1);
            _with1.DrawString("*" + OrdenTrabajo.CodigoBarras + "*", _FuenteCodBar, Brushes.Black, x1, y + 80);
            _with1.DrawString(OrdenTrabajo.CodigoBarras.ToString(), _Fuente8, Brushes.Black, x1, y + 95);
            _with1.DrawLine(Pens.Black, x1, y + 105, 900, y + 108);

            _with1.DrawString("CASCO SERVICE CENTER", _Fuente14Bold, Brushes.Black, 300, y + 30);
            _with1.DrawString("ORDEN DE TRABAJO", _Fuente12Bold, Brushes.Black, 350, y + 50);

            if (!(Padre.OrdenTrabajo.TipoMantenimiento_ID == 19))
            {
                _with1.DrawString("FOLIO: " + OrdenTrabajo.OrdenTrabajo_ID.ToString(), _Fuente12Bold, Brushes.Black, 380, y + 65);
            }
            else
            {
                _with1.DrawString("===   COTIZACION   ===", _Fuente12Bold, Brushes.Black, 380, y + 65);
            }
            
            _with1.DrawString(DateAndTime.Now.ToShortDateString(), _Fuente10, Brushes.Black, 350, y + 80);
            _with1.DrawString(DateAndTime.Now.ToShortTimeString(), _Fuente10, Brushes.Black, 450, y + 80);

            _with1.DrawString("Unidad:" + Strings.Chr(9) + OrdenTrabajo.NumeroEconomico.ToString(), _Fuente10, Brushes.Black, x1, y + 115);
            _with1.DrawString("Cliente: " + OrdenTrabajo.Cliente_Nombre.ToString(), _Fuente10, Brushes.Black, x1, y + 140);
            _with1.DrawString("Mecánico: " + OrdenTrabajo.OrdenesServicios[0].Mecanico_Nombre, _Fuente10, Brushes.Black, x1, y + 165);
            _with1.DrawString("Kilometraje: " + Convert.ToString(Convert.ToInt32(OrdenTrabajo.Kilometraje)), _Fuente10, Brushes.Black, x1, y + 185);
            y += 85;

            _with1.DrawString("SERVICIOS DE MANO DE OBRA:", _Fuente10Bold, Brushes.Black, x1, y + 130);
            _with1.DrawLine(Pens.Black, x1, y + 145, 700, y + 145);
            _with1.DrawString("SERVICIO", _Fuente10, Brushes.Black, x1, y + 146);
            _with1.DrawString("CANTIDAD", _Fuente10, Brushes.Black, x2, y + 146);
            _with1.DrawString("P.U.", _Fuente10, Brushes.Black, x3, y + 146);
            _with1.DrawString("TOTAL", _Fuente10, Brushes.Black, x4, y + 146);
            _with1.DrawLine(Pens.Black, x1, y + 160, 700, y + 160);

            TotalServicios = 0;
            y = y + 161;
            foreach (Entities.OrdenesServicios os in OrdenTrabajo.OrdenesServicios)
            {
                _with1.DrawString(Strings.UCase(os.ServicioMantenimiento_Descripcion), _Fuente10, Brushes.Black, x1, y);
                _with1.DrawString(Strings.Format(os.Cantidad, "###,###.00"), _Fuente10, Brushes.Black, x2, y);
                _with1.DrawString(Strings.Format(os.Precio, "$ #,###.00"), _Fuente10, Brushes.Black, x3, y);
                _with1.DrawString(Strings.Format(os.Total, "$ #,###.00"), _Fuente10, Brushes.Black, x4, y);
                y += 15;
                TotalServicios += Convert.ToDouble(os.Total);
            }
            _with1.DrawLine(Pens.Black, x1, y, 700, y);
            _with1.DrawString("TOTAL MANO DE OBRA:", _Fuente10, Brushes.Black, x2 + 70, y + 1);
            _with1.DrawString(Strings.Format(TotalServicios, "$ ##,###.00"), _Fuente10Bold, Brushes.Black, x4, y + 1);

            _with1.DrawString("REFACCIONES:", _Fuente10Bold, Brushes.Black, x1, y + 20);
            _with1.DrawLine(Pens.Black, x1, y + 35, 700, y + 35);
            _with1.DrawString("REFACCION", _Fuente10, Brushes.Black, x1, y + 36);
            _with1.DrawString("CANTIDAD", _Fuente10, Brushes.Black, x2, y + 36);
            _with1.DrawString("P.U.", _Fuente10, Brushes.Black, x3, y + 36);
            _with1.DrawString("TOTAL", _Fuente10, Brushes.Black, x4, y + 36);
            _with1.DrawLine(Pens.Black, x1, y + 50, 700, y + 50);

            TotalRefacciones = 0;
            y += 51;

            foreach (Entities.OrdenesServiciosRefacciones osr in OrdenesServiciosRefacciones)
            {
                _with1.DrawString(Strings.UCase(osr.Refaccion_Descripcion), _Fuente10, Brushes.Black, x1, y);
                _with1.DrawString(Strings.Format(osr.Cantidad, "###,###.00"), _Fuente10, Brushes.Black, x2, y);
                _with1.DrawString(Strings.Format(osr.PrecioUnitario, "$ #,###.00"), _Fuente10, Brushes.Black, x3, y);
                _with1.DrawString(Strings.Format(osr.Total, "$ #,###.00"), _Fuente10, Brushes.Black, x4, y);
                y += 15;
                TotalRefacciones += Convert.ToDouble(osr.Total);
            }
            _with1.DrawLine(Pens.Black, x1, y, 700, y);
            _with1.DrawString("TOTAL REFACCIONES:", _Fuente10, Brushes.Black, x2 + 70, y + 1);
            _with1.DrawString(Strings.Format(TotalRefacciones, "$ ##,###.00"), _Fuente10Bold, Brushes.Black, x4, y + 1);

            _with1.DrawLine(Pens.Black, x1, y + 15, 700, y + 15);
            _with1.DrawString("SUBTOTAL:", _Fuente10, Brushes.Black, x2 + 70, y + 16);
            _with1.DrawString(Strings.Format(OrdenTrabajo.Subtotal, "$ ##,###.00"), _Fuente10Bold, Brushes.Black, x4, y + 16);

            _with1.DrawString("IVA:", _Fuente10, Brushes.Black, x2 + 70, y + 31);
            _with1.DrawString(Strings.Format(OrdenTrabajo.IVA, "$ ##,###.00"), _Fuente10Bold, Brushes.Black, x4, y + 31);

            _with1.DrawString("TOTAL:", _Fuente10, Brushes.Black, x2 + 70, y + 46);
            _with1.DrawString(Strings.Format(OrdenTrabajo.Total, "$ ##,###.00"), _Fuente10Bold, Brushes.Black, x4, y + 46);

            _with1.DrawString("__________________________________________", _Fuente10, Brushes.Black, x1, y + 140);
            _with1.DrawString("ASISTENTE TALLER", _Fuente10Bold, Brushes.Black, x1, y + 160);

            _with1.DrawString("__________________________________________", _Fuente10, Brushes.Black, x3, y + 140);
            _with1.DrawString("CLIENTE", _Fuente10Bold, Brushes.Black, x3, y + 160);


        }

        public void DibujaOrdenTrabajo(System.Drawing.Printing.PrintPageEventArgs e)
        {
            Font _Fuente8 = new Font("Arial", 8);
            Font _Fuente10 = new Font("Arial", 10);
            Font _Fuente12 = new Font("Arial", 12);
            Font _Fuente10Bold = new Font("Arial", 10, FontStyle.Bold);
            Font _Fuente12Bold = new Font("Arial", 12, FontStyle.Bold);
            Font _Fuente14Bold = new Font("Arial", 14, FontStyle.Bold);
            Font _FuenteCodBar = new Font("Code 39", 12);
            double TotalServicios = 0;
            double TotalRefacciones = 0;

            //Me.PrintDoc.DefaultPageSettings.PaperSize = New PaperSize("Boleto", 787, 196)
            //Dim dtFiscales As New DataTable

            //dtFiscales = TL.DatosFiscales()
            Bitmap img = new Bitmap(global::SICASv20.Properties.Resources.CSC, 114, 73);
            Bitmap enc = new Bitmap(global::SICASv20.Properties.Resources.encuesta, 400, 500);
            var _with1 = e.Graphics;

            float x1 = 0;
            float y = 0;
            float x2 = 0;
            float x3 = 0;
            float x4 = 0;
            y = 10;
            x1 = 10;
            x2 = 340;
            x3 = 490;
            x4 = 625;

            _with1.DrawLine(Pens.Black, x1, y, 900, y);
            _with1.DrawImage(img, x1 + 1, y + 1);
            _with1.DrawString("*" + OrdenTrabajo.CodigoBarras + "*", _FuenteCodBar, Brushes.Black, x1, y + 80);
            _with1.DrawString(OrdenTrabajo.CodigoBarras, _Fuente8, Brushes.Black, x1, y + 95);
            _with1.DrawLine(Pens.Black, x1, y + 105, 900, y + 108);

            _with1.DrawString("CASCO SERVICE CENTER", _Fuente14Bold, Brushes.Black, 300, y + 30);
            _with1.DrawString("ORDEN DE TRABAJO", _Fuente12Bold, Brushes.Black, 350, y + 50);

            if (!(Padre.OrdenTrabajo.TipoMantenimiento_ID == 19))
            {
                _with1.DrawString("FOLIO: " + OrdenTrabajo.OrdenTrabajo_ID.ToString(), _Fuente12Bold, Brushes.Black, 380, y + 65);
            }
            else
            {
                _with1.DrawString("===   COTIZACION   ===", _Fuente12Bold, Brushes.Black, 380, y + 65);
            }

            
            _with1.DrawString(DateAndTime.Now.ToShortDateString(), _Fuente10, Brushes.Black, 350, y + 80);
            _with1.DrawString(DateAndTime.Now.ToShortTimeString(), _Fuente10, Brushes.Black, 450, y + 80);

            _with1.DrawString("Unidad:" + Strings.Chr(9) + OrdenTrabajo.NumeroEconomico.ToString(), _Fuente10, Brushes.Black, x1, y + 115);
            _with1.DrawString("Cliente: " + OrdenTrabajo.Cliente_Nombre, _Fuente10, Brushes.Black, x1, y + 140);
            _with1.DrawString("Mecánico: " + OrdenTrabajo.OrdenesServicios[0].Mecanico_Nombre, _Fuente10, Brushes.Black, x1, y + 165);
            _with1.DrawString("Kilometraje: " + OrdenTrabajo.Kilometraje.ToString(), _Fuente10, Brushes.Black, x1, y + 185);
            y += 85;

            _with1.DrawString("SERVICIOS DE MANO DE OBRA:", _Fuente10Bold, Brushes.Black, x1, y + 130);
            _with1.DrawLine(Pens.Black, x1, y + 145, 700, y + 145);
            _with1.DrawString("SERVICIO", _Fuente10, Brushes.Black, x1, y + 146);
            _with1.DrawString("CANTIDAD", _Fuente10, Brushes.Black, x2, y + 146);
            _with1.DrawString("P.U.", _Fuente10, Brushes.Black, x3, y + 146);
            _with1.DrawString("TOTAL", _Fuente10, Brushes.Black, x4, y + 146);
            _with1.DrawLine(Pens.Black, x1, y + 160, 700, y + 160);

            TotalServicios = 0;
            y = y + 161;
            foreach (Entities.OrdenesServicios os in OrdenTrabajo.OrdenesServicios)
            {
                _with1.DrawString(Strings.UCase(os.ServicioMantenimiento_Descripcion), _Fuente10, Brushes.Black, x1, y);
                _with1.DrawString(Strings.Format(os.Cantidad, "###,###.00"), _Fuente10, Brushes.Black, x2, y);
                _with1.DrawString(Strings.Format(os.Precio, "$ #,###.00"), _Fuente10, Brushes.Black, x3, y);
                _with1.DrawString(Strings.Format(os.Total, "$ #,###.00"), _Fuente10, Brushes.Black, x4, y);
                y += 15;
                TotalServicios += Convert.ToDouble(os.Total);
            }
            _with1.DrawLine(Pens.Black, x1, y, 700, y);
            _with1.DrawString("TOTAL MANO DE OBRA:", _Fuente10, Brushes.Black, x2 + 70, y + 1);
            _with1.DrawString(Strings.Format(TotalServicios, "$ ##,###.00"), _Fuente10Bold, Brushes.Black, x4, y + 1);

            _with1.DrawString("REFACCIONES:", _Fuente10Bold, Brushes.Black, x1, y + 20);
            _with1.DrawLine(Pens.Black, x1, y + 35, 700, y + 35);
            _with1.DrawString("REFACCION", _Fuente10, Brushes.Black, x1, y + 36);
            _with1.DrawString("CANTIDAD", _Fuente10, Brushes.Black, x2, y + 36);
            _with1.DrawString("P.U.", _Fuente10, Brushes.Black, x3, y + 36);
            _with1.DrawString("TOTAL", _Fuente10, Brushes.Black, x4, y + 36);
            _with1.DrawLine(Pens.Black, x1, y + 50, 700, y + 50);

            TotalRefacciones = 0;
            y += 51;

            foreach (Entities.OrdenesServiciosRefacciones osr in OrdenesServiciosRefacciones)
            {
                _with1.DrawString(Strings.UCase(osr.Refaccion_Descripcion), _Fuente10, Brushes.Black, x1, y);
                _with1.DrawString(Strings.Format(osr.Cantidad, "###,###.00"), _Fuente10, Brushes.Black, x2, y);
                _with1.DrawString(Strings.Format(osr.PrecioUnitario, "$ #,###.00"), _Fuente10, Brushes.Black, x3, y);
                _with1.DrawString(Strings.Format(osr.Total, "$ #,###.00"), _Fuente10, Brushes.Black, x4, y);
                y += 15;
                TotalRefacciones += Convert.ToDouble(osr.Total);
            }

            _with1.DrawLine(Pens.Black, x1, y, 700, y);
            _with1.DrawString("TOTAL REFACCIONES:", _Fuente10, Brushes.Black, x2 + 70, y + 1);
            _with1.DrawString(Strings.Format(TotalRefacciones, "$ ##,###.00"), _Fuente10Bold, Brushes.Black, x4, y + 1);

            _with1.DrawLine(Pens.Black, x1, y + 15, 700, y + 15);
            _with1.DrawString("SUBTOTAL:", _Fuente10, Brushes.Black, x2 + 70, y + 16);
            _with1.DrawString(Strings.Format(OrdenTrabajo.Subtotal, "$ ##,###.00"), _Fuente10Bold, Brushes.Black, x4, y + 16);

            _with1.DrawString("IVA:", _Fuente10, Brushes.Black, x2 + 70, y + 31);
            _with1.DrawString(Strings.Format(OrdenTrabajo.IVA, "$ ##,###.00"), _Fuente10Bold, Brushes.Black, x4, y + 31);

            _with1.DrawString("TOTAL:", _Fuente10, Brushes.Black, x2 + 70, y + 46);
            _with1.DrawString(Strings.Format(OrdenTrabajo.Total, "$ ##,###.00"), _Fuente10Bold, Brushes.Black, x4, y + 46);

            _with1.DrawString("__________________________________________", _Fuente10, Brushes.Black, x1, y + 140);
            _with1.DrawString("ASISTENTE TALLER", _Fuente10Bold, Brushes.Black, x1, y + 160);

            _with1.DrawString("__________________________________________", _Fuente10, Brushes.Black, x3, y + 140);
            _with1.DrawString("CLIENTE", _Fuente10Bold, Brushes.Black, x3, y + 160);

            _with1.DrawImage(enc, x1, y + 210, 300, 300);
        }
        

        #endregion


        private void AceptarButton_Click(object sender, EventArgs e)
        {            
            AppHelper.DoTransactions(
                delegate
                {
                    if (!(Padre.OrdenTrabajo.TipoMantenimiento_ID == 19))
                    {
                        InsertOrden();
                        
                        Entities.RegistroAccionesSistema registro = new Entities.RegistroAccionesSistema();
                        registro.Accion = "NUEVA ORDEN TRABAJO";
                        registro.Comentarios = "ORDEN ID: " + this.Padre.OrdenTrabajo.OrdenTrabajo_ID.ToString();
                        registro.Fecha = DB.GetDate();
                        registro.Formulario = this.Name;
                        registro.Opcion_ID = null;
                        registro.Usuario_ID = Sesion.Usuario_ID;
                        registro.Create();

                        int orden = Padre.OrdenTrabajo.OrdenTrabajo_ID;
                        Padre.Clear();
                        ImprimirOrdenTrabajo(orden);
                    }
                    else
                    {
                        Padre.Clear();
                        ImprimirOrdenTrabajoActual();
                    }
                    
                    AppHelper.Info("Orden Registrada");
                }, 
                this
            );
        }

        private void AnteriorButton_Click(object sender, EventArgs e)
        {
            try
            {
                Padre.SwitchPanel("Mecanico");
            }
            catch (Exception ex)
            {
                AppHelper.Error(ex.Message);
            }   
        }
    }
}
