using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SICASv20.forms
{
    public partial class ReporteMatrizDeConsumos : baseForm
    {
        public ReporteMatrizDeConsumos()
        {
            InitializeComponent();
        }

        private void ReporteDeConsumosConsolidados_Load(object sender, EventArgs e)
        {
            this.Vista_ConsumosConsolidadosTallerBindingSource.DataSource =
                Entities.Vista_ConsumosConsolidadosTaller.GetDataTable(
                new DateTime(2008, 4, 1), 
                new DateTime(2008, 5, 1), 
                Sesion.Empresa_ID.Value,
                Sesion.Estacion_ID.Value);

            this.MatrizConsumosReportViewer.RefreshReport();
        }
    }
}
