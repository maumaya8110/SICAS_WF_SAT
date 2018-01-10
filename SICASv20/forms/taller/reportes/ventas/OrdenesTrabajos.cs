using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Microsoft.VisualBasic;

namespace SICASv20.forms
{
    public partial class OrdenesTrabajos : baseForm
    {
        public OrdenesTrabajos()
        {
            InitializeComponent();
        }

        private void PopulateTiposMantenimientos()
        {
            this.TiposMttoscheckList.Items.Clear();
            tiposMttos = Entities.TiposMantenimientos.Read();
            foreach (Entities.TiposMantenimientos tm in tiposMttos)
            {
                this.TiposMttoscheckList.Items.Add(tm.Nombre, true);                
            }            
        }

        private List<Entities.TiposMantenimientos> tiposMttos;

        public override void BindData()
        {            
            selectEmpresasBindingSource.DataSource = Entities.SelectEmpresas.Get();
            selectTiposMantenimientosBindingSource.DataSource = Entities.SelectTiposMantenimientos.Get();
            selectEmpresasBindingSource.DataSource = Entities.SelectEmpresas.Get();
            selectEstatusOrdenesTrabajosBindingSource.DataSource = Entities.SelectEstatusOrdenesTrabajos.Get();
            PopulateTiposMantenimientos();
            base.BindData();
        }

        public string GetFilters()
        {

            List<string> filtros = new List<string>();


            //'Status
            if (this.otAbiertasCheck.Checked == false)
            {
                filtros.Add("OT.EstatusOrdenTrabajo_ID NOT IN (1,2,6)");
            }

            if (this.otCerradasCheck.Checked == false)
            {
                filtros.Add("OT.EstatusOrdenTrabajo_ID NOT IN (3,4)");
            }

            if (this.otCanceladasCheck.Checked == false)
            {
                filtros.Add("OT.EstatusOrdenTrabajo_ID NOT IN (5)");
            }

            //if (this.otPorSurtirCheck.Checked == true)
            //{
            //    filtros.Add("PS.PorSurtir > 0");
            //}

            //'Tipos Mantenimientos
            List<string> tiposMtto = new List<string>();

            foreach (string s in this.TiposMttoscheckList.CheckedItems)
            {
                //'Obtener el folio
                //string strSQL = "SELECT TipoMantenimiento_ID FROM TiposMantenimientos WHERE Nombre = @Nombre";
                //id = DB.QueryScalar(strSQL, DB.Param("@Nombre", s)).ToString();                
                tiposMtto.Add(
                    tiposMttos.Find(
                        delegate(Entities.TiposMantenimientos tm)
                        {
                            return tm.Nombre == s;
                        }
                    ).TipoMantenimiento_ID.ToString()
                );

            }

            if(tiposMtto.Count>0) filtros.Add("OT.TipoMantenimiento_ID IN (" + string.Join(",", tiposMtto.ToArray()) + ")");            

            if (filtros.Count > 0)
            {
                return string.Join(" AND ", filtros.ToArray());
            }
            else
            {
                return "";
            }

        }

        private void DoQuery()
        {
            Int32? ordentrabajo_id;
            Int32? clientefacturar_id;            
            Int32? numeroeconomico;
            DateTime? fechaaltainicial = null;
            DateTime? fechaaltafinal = null;
            DateTime? fechaterminacioninicial = null;
            DateTime? fechaterminacionfinal = null;
            string filters, cb = null;            

            ordentrabajo_id = DB.GetNullableInt32(OrdenTrabajo_IDTextBox.Text);            
            clientefacturar_id = DB.GetNullableInt32(ClienteFacturar_IDComboBox.SelectedValue);            
            numeroeconomico = DB.GetNullableInt32(NumeroEconomicoTextBox.Text);
            fechaaltainicial = FechaAltaInicialDateTimePicker.Checked ? (DateTime?)AppHelper.FechaInicial(FechaAltaInicialDateTimePicker.Value) : null;
            fechaaltafinal = FechaAltaFinalDateTimePicker.Checked ? (DateTime?)AppHelper.FechaFinal(FechaAltaFinalDateTimePicker.Value) : null;
            fechaterminacioninicial = FechaTerminacionInicialDateTimePicker.Checked ? (DateTime?)AppHelper.FechaInicial(FechaTerminacionInicialDateTimePicker.Value) : null;
            fechaterminacionfinal = FechaTerminacionFinalDateTimePicker.Checked ? (DateTime?)AppHelper.FechaFinal(FechaTerminacionFinalDateTimePicker.Value) : null;
            cb = string.IsNullOrEmpty(this.CBTextBox.Text) ? null : this.CBTextBox.Text;

            filters = GetFilters();

            Vista_OrdenesTrabajosBindingSource.DataSource =
                Entities.Vista_OrdenesTrabajos.Get(filters, ordentrabajo_id, clientefacturar_id, numeroeconomico, cb, fechaaltainicial,
                fechaaltafinal, fechaterminacioninicial, fechaterminacionfinal,
                Sesion.Empresa_ID.Value,
                Sesion.Estacion_ID.Value);
        }

        ReporteOrdenTrabajo reporteOT;

        private void Set_ReporteOT()
        {
            if (reporteOT == null)
            {
                reporteOT = new ReporteOrdenTrabajo();
            }
            else
            {
                if (reporteOT.IsDisposed)
                {
                    reporteOT = new ReporteOrdenTrabajo();
                }
            }
        }

        int row, col;
        private void DoNavigate()
        {
            if (Vista_OrdenesTrabajosDataGridView.Columns[col].Name == "Ver")
            {                
                Entities.Vista_OrdenesTrabajos OT =
                    (Entities.Vista_OrdenesTrabajos)this.Vista_OrdenesTrabajosDataGridView.Rows[row].DataBoundItem;                

                ImprimirOrdenTrabajo(OT.OrdenTrabajo_ID);
            }
        }

        private void BuscarButton_Click(object sender, EventArgs e)
        {
            AppHelper.DoMethod(new AppHelper.HelperDelegate(DoQuery), this);
        }

        private void Vista_OrdenesTrabajosDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            row = e.RowIndex;
            col = e.ColumnIndex;
            AppHelper.DoMethod(new AppHelper.HelperDelegate(DoNavigate), this);
        }

        private void ExportarButton_Click(object sender, EventArgs e)
        {
            AppHelper.DoMethod(delegate
            {
                this.ExportarSaveFileDialog.Title = "Guarde un archivo de excel";
                this.ExportarSaveFileDialog.Filter = "Excel Files|*.xls";
                if (this.ExportarSaveFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    if (ExportarSaveFileDialog.FileName != "")
                    {
                        string ruta = ExportarSaveFileDialog.FileName;
                        AppHelper.GridExport.GridToXls(ref this.Vista_OrdenesTrabajosDataGridView, ruta);
                    }
                }
            }, this);
        }

        private void DoExport()
        {
            if (ExportarSaveFileDialog.FileName != "")
            {
                string ruta = ExportarSaveFileDialog.FileName;
                AppHelper.GridExport.GridToXls(ref this.Vista_OrdenesTrabajosDataGridView, ruta);
            }  
        }

        private void ExportarSaveFileDialog_FileOk(object sender, CancelEventArgs e)
        {
            AppHelper.DoMethod(new AppHelper.HelperDelegate(DoExport), this);
        }

        #region Impresion

        private Entities.OrdenesTrabajos OrdenTrabajo;
        private List<Entities.OrdenesServiciosRefacciones> OrdenesServiciosRefacciones;

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
            _with1.DrawString("FOLIO: " + OrdenTrabajo.OrdenTrabajo_ID.ToString(), _Fuente12Bold, Brushes.Black, 380, y + 65);
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
            _with1.DrawString("FOLIO: " + OrdenTrabajo.OrdenTrabajo_ID.ToString(), _Fuente12Bold, Brushes.Black, 380, y + 65);
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

            /*
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
            var _with2 = e.Graphics;

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

            _with2.DrawLine(Pens.Black, x1, y, 700, y);
            _with2.DrawImage(img, x1 + 1, y + 1);
            _with2.DrawString("*" + dtOT.Rows[0]["CodigoBarras"].ToString() + "*", _FuenteCodBar, Brushes.Black, x1, y + 80);
            _with2.DrawString(dtOT.Rows[0]["CodigoBarras"].ToString(), _Fuente8, Brushes.Black, x1, y + 95);
            _with2.DrawLine(Pens.Black, x1, y + 105, 700, y + 108);

            _with2.DrawString("CASCO SERVICE CENTER", _Fuente14Bold, Brushes.Black, 300, y + 30);
            _with2.DrawString("ORDEN DE TRABAJO", _Fuente12Bold, Brushes.Black, 350, y + 50);
            _with2.DrawString("FOLIO: " + dtOT.Rows[0]["OrdenTrabajo_ID"].ToString(), _Fuente12Bold, Brushes.Black, 380, y + 65);
            _with2.DrawString(DateAndTime.Now.ToShortDateString(), _Fuente10, Brushes.Black, 350, y + 80);
            _with2.DrawString(DateAndTime.Now.ToShortTimeString(), _Fuente10, Brushes.Black, 450, y + 80);

            _with2.DrawString("Unidad:" + Strings.Chr(9) + dtOT.Rows[0]["Unidad"].ToString(), _Fuente10, Brushes.Black, x1, y + 115);
            _with2.DrawString("Cliente: " + dtOT.Rows[0]["Cliente"].ToString(), _Fuente10, Brushes.Black, x1, y + 140);
            _with2.DrawString("Mecánico: " + dtOS.Rows[0]["Mecanico"].ToString(), _Fuente10, Brushes.Black, x1, y + 165);
            _with2.DrawString("Kilometraje: " + Convert.ToString(Convert.ToInt32(dtOT.Rows[0]["Kilometraje"])), _Fuente10, Brushes.Black, x1, y + 185);
            y += 85;

            _with2.DrawString("SERVICIOS DE MANO DE OBRA:", _Fuente10Bold, Brushes.Black, x1, y + 130);
            _with2.DrawLine(Pens.Black, x1, y + 145, 700, y + 145);
            _with2.DrawString("SERVICIO", _Fuente10, Brushes.Black, x1, y + 146);
            _with2.DrawString("CANTIDAD", _Fuente10, Brushes.Black, x2, y + 146);
            _with2.DrawString("P.U.", _Fuente10, Brushes.Black, x3, y + 146);
            _with2.DrawString("TOTAL", _Fuente10, Brushes.Black, x4, y + 146);
            _with2.DrawLine(Pens.Black, x1, y + 160, 700, y + 160);

            TotalServicios = 0;
            y = y + 161;
            foreach (DataRow orden in dtOS.Rows)
            {
                _with2.DrawString(Strings.Left(Strings.UCase(orden["Servicio"].ToString()), 39), _Fuente10, Brushes.Black, x1, y);
                _with2.DrawString(Strings.Format(orden["Cantidad"], "###,###.00"), _Fuente10, Brushes.Black, x2, y);
                _with2.DrawString(Strings.Format(orden["PrecioUnitario"], "$ #,###.00"), _Fuente10, Brushes.Black, x3, y);
                _with2.DrawString(Strings.Format(orden["Total"], "$ #,###.00"), _Fuente10, Brushes.Black, x4, y);
                y += 15;
                TotalServicios += Convert.ToDouble(orden["Total"]);
            }
            _with2.DrawLine(Pens.Black, x1, y, 700, y);
            _with2.DrawString("TOTAL MANO DE OBRA:", _Fuente10, Brushes.Black, x2 + 70, y + 1);
            _with2.DrawString(Strings.Format(TotalServicios, "$ ##,###.00"), _Fuente10Bold, Brushes.Black, x4, y + 1);

            _with2.DrawString("REFACCIONES:", _Fuente10Bold, Brushes.Black, x1, y + 20);
            _with2.DrawLine(Pens.Black, x1, y + 35, 700, y + 35);
            _with2.DrawString("REFACCION", _Fuente10, Brushes.Black, x1, y + 36);
            _with2.DrawString("CANTIDAD", _Fuente10, Brushes.Black, x2, y + 36);
            _with2.DrawString("P.U.", _Fuente10, Brushes.Black, x3, y + 36);
            _with2.DrawString("TOTAL", _Fuente10, Brushes.Black, x4, y + 36);
            _with2.DrawLine(Pens.Black, x1, y + 50, 700, y + 50);

            TotalRefacciones = 0;
            y += 51;

            foreach (DataRow @ref in dtOSR.Rows)
            {
                _with2.DrawString(Strings.Left(Strings.UCase(@ref["Refaccion"].ToString()), 39), _Fuente10, Brushes.Black, x1, y);
                _with2.DrawString(Strings.Format(@ref["Cantidad"], "###,###.00"), _Fuente10, Brushes.Black, x2, y);
                _with2.DrawString(Strings.Format(@ref["PrecioUnitario"], "$ #,###.00"), _Fuente10, Brushes.Black, x3, y);
                _with2.DrawString(Strings.Format(@ref["Total"], "$ #,###.00"), _Fuente10, Brushes.Black, x4, y);
                y += 15;
                TotalRefacciones += Convert.ToDouble(@ref["total"]);
            }
            _with2.DrawLine(Pens.Black, x1, y, 700, y);
            _with2.DrawString("TOTAL REFACCIONES:", _Fuente10, Brushes.Black, x2 + 70, y + 1);
            _with2.DrawString(Strings.Format(TotalRefacciones, "$ ##,###.00"), _Fuente10Bold, Brushes.Black, x4, y + 1);

            //SubTotal = TotalServicios + TotalRefacciones
            //IVA = SubTotal * 0.15
            //Total = SubTotal + IVA

            _with2.DrawLine(Pens.Black, x1, y + 15, 700, y + 15);
            _with2.DrawString("SUBTOTAL:", _Fuente10, Brushes.Black, x2 + 70, y + 16);
            _with2.DrawString(Strings.Format(dtOT.Rows[0]["Subtotal"], "$ ##,###.00"), _Fuente10Bold, Brushes.Black, x4, y + 16);

            _with2.DrawString("IVA:", _Fuente10, Brushes.Black, x2 + 70, y + 31);
            _with2.DrawString(Strings.Format(dtOT.Rows[0]["IVA"], "$ ##,###.00"), _Fuente10Bold, Brushes.Black, x4, y + 31);

            _with2.DrawString("TOTAL:", _Fuente10, Brushes.Black, x2 + 70, y + 46);
            _with2.DrawString(Strings.Format(dtOT.Rows[0]["TOTAL"], "$ ##,###.00"), _Fuente10Bold, Brushes.Black, x4, y + 46);

            _with2.DrawString("__________________________________________", _Fuente10, Brushes.Black, x1, y + 140);
            _with2.DrawString("ASISTENTE TALLER", _Fuente10Bold, Brushes.Black, x1, y + 160);

            _with2.DrawString("__________________________________________", _Fuente10, Brushes.Black, x3, y + 140);
            _with2.DrawString("CLIENTE", _Fuente10Bold, Brushes.Black, x3, y + 160);

            _with2.DrawImage(enc, x1, y + 210, 300, 300);
             */
        }        

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

                //System.Drawing.Printing.PrintDocument PrintDoc = new System.Drawing.Printing.PrintDocument();
                System.Drawing.Printing.PrintDocument PrintDoc2 = new System.Drawing.Printing.PrintDocument();

                //PrintDoc.DocumentName = "OrdenDeTrabajo" + p_OrdenTrabajo.ToString();
                PrintDoc2.DocumentName = "OrdenDeTrabajo" + p_OrdenTrabajo.ToString();

                //PrintDoc.PrintPage += PrintDoc_PrintPage;
                PrintDoc2.PrintPage += PrintDoc_PrintPageSinEncuesta;

                PrintPreviewDialog preview = new PrintPreviewDialog();
                preview.Document = PrintDoc2;
                preview.Height = Screen.PrimaryScreen.Bounds.Height;
                preview.Width = Screen.PrimaryScreen.Bounds.Width;
                preview.ShowDialog();
                //PrintDoc.Print();
                //PrintDoc2.Print();
                //PrintDoc2.Print()

            }
            catch (Exception ex)
            {
                Interaction.MsgBox(ex.Message, MsgBoxStyle.Critical);
            }

        }

        private void PrintDoc_PrintPage(System.Object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            DibujaOrdenTrabajo(e);
        }

        private void PrintDoc_PrintPageSinEncuesta(System.Object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            this.DibujaOrdenTrabajoSinEncuesta(e);
        }

        #endregion

        private void Vista_OrdenesTrabajosDataGridView_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            AppHelper.Try(
                delegate
                {
                    AppHelper.AutoColorDataGridViewRows(ref this.Vista_OrdenesTrabajosDataGridView, "Estatus");
                }
            );
        }

    } // End class
} // End namespace
