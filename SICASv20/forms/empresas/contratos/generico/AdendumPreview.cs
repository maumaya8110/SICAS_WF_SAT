using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SICASv20.forms
{
    public partial class AdendumPreview : Form
    {
        public int AdendumId { get; set; }

        public AdendumPreview()
        {
            InitializeComponent();
        }

        private void AdendumPreview_Load(object sender, EventArgs e)
        {
            SICASv20.Entities.Vista_ReporteAdendums reporte = new Entities.Vista_ReporteAdendums();            
            this.adendumReporteBindingSource.DataSource = reporte.Get(this.AdendumId);

            this.reportViewer1.RefreshReport();
        }
    }
}
