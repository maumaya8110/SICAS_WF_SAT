using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SICASv20.forms
{
    public partial class ReporteIndicadoresUnidades : baseForm
    {
        public ReporteIndicadoresUnidades()
        {
            InitializeComponent();
        }

        public override void BindData()
        {
            reporte_IndicadoresTableAdapter.Fill(sICASCentralQuerysDataSet.Reporte_Indicadores, null, null,
                null, null, null, null, null);
            this.reportViewer1.RefreshReport();
            base.BindData();
        }

        private void ReporteIndicadoresUnidades_Load(object sender, EventArgs e)
        {

            
        }
    }
}
