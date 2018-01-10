using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SICASv20.forms
{
    public partial class ReporteDeVentasTotales : baseForm
    {
        public ReporteDeVentasTotales()
        {
            InitializeComponent();
        }

        private void DoQuery()
        {
            DateTime? fechaInicial = null, fechaFinal = null;
            fechaInicial = AppHelper.FechaInicial(FechaTerminacionInicialDateTimePicker.Value);
            fechaFinal = AppHelper.FechaFinal(FechaTerminacionFinalDateTimePicker.Value);

            DataTable reporteVentas;
            reporteVentas = Entities.Vista_ReporteVentasTaller.GetDataTable(
                fechaInicial, 
                fechaFinal,
                Sesion.Empresa_ID,
                Sesion.Estacion_ID
            );

            this.Vista_ReporteVentasTallerBindingSource.DataSource = reporteVentas;
            this.VentasTotalesReporteViewer.RefreshReport();

        }

        private void ReporteDeVentasTotales_Load(object sender, EventArgs e)
        {
            
        }

        private void ConsultarButton_Click(object sender, EventArgs e)
        {
            AppHelper.DoMethod(delegate
            {
                DoQuery();
            }, this);
        }
    }
}
