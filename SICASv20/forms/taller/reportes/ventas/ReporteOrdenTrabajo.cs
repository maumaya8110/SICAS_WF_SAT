using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SICASv20.forms
{
    public partial class ReporteOrdenTrabajo : Form
    {
        public ReporteOrdenTrabajo()
        {
            InitializeComponent();
        }

        private int _OrdenTrabajo_ID;
        public int OrdenTrabajo_ID
        {
            get { return _OrdenTrabajo_ID; }
            set { _OrdenTrabajo_ID = value; }
        }

        private void DisplayReport()
        {
            AppHelper.Try(delegate
            {
                Entities.OrdenesTrabajos OrdenTrabajo = Entities.OrdenesTrabajos.Read(this.OrdenTrabajo_ID);

                List<Entities.OrdenesServiciosRefacciones> OrdenesServiciosRefacciones = new List<Entities.OrdenesServiciosRefacciones>();
                foreach (Entities.OrdenesServicios os in OrdenTrabajo.OrdenesServicios)
                {
                    OrdenesServiciosRefacciones.AddRange(os.OrdenesServiciosRefacciones);
                }

                OrdenesTrabajosBindingSource.DataSource = OrdenTrabajo;
                OrdenesServiciosBindingSource.DataSource = OrdenTrabajo.OrdenesServicios;
                OrdenesServiciosRefaccionesBindingSource.DataSource = OrdenesServiciosRefacciones;

                OrdenTrabajoReportViewer.RefreshReport();
                this.Show();
            });            
        }

        public void DisplayReport(int ordentrabajo)
        {
            this.OrdenTrabajo_ID = ordentrabajo;
            DisplayReport();
        }

        public void PrintReport(int? ordentrabajo)
        {
            if (ordentrabajo != null)
            {
                this.DisplayReport(ordentrabajo.Value);
            }

            AppHelper.PrintReport(OrdenTrabajoReportViewer.LocalReport);
        }

        private void ReporteOrdenTrabajo_Load(object sender, EventArgs e)
        {
            this.OrdenTrabajoReportViewer.RefreshReport();
        }
    }
}
