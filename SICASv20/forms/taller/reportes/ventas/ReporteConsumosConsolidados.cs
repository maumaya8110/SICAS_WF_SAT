using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SICASv20.forms
{
    public partial class ReporteConsumosConsolidados : baseForm
    {
        public ReporteConsumosConsolidados()
        {
            InitializeComponent();
        }

        class ReporteConsumosConsolidados_Model
        {
            private List<Entities.Vista_MatrizVentasTaller> _VistaVentas;
            public List<Entities.Vista_MatrizVentasTaller> VistaVentas
            {
                get { return _VistaVentas; }
            }

            private DateTime _FechaInicial;
            public DateTime FechaInicial
            {
                get { return _FechaInicial; }
                set { _FechaInicial = value; }
            }

            private DateTime _FechaFinal;
            public DateTime FechaFinal
            {
                get { return _FechaFinal; }
                set { _FechaFinal = value; }
            }

            public void ConsultarVentas()
            {
                this._VistaVentas =
                    Entities.Vista_MatrizVentasTaller.Get(
                    this.FechaInicial, 
                    this.FechaFinal, 
                    Sesion.Empresa_ID.Value,
                    Sesion.Estacion_ID.Value);
            }
        }

        private ReporteConsumosConsolidados_Model Model;
        public override void BindData()
        {
            this.Model = new ReporteConsumosConsolidados_Model();
            base.BindData();
        }

        private void ReporteMatrizDeVentas_Load(object sender, EventArgs e)
        {

        }

        private void BuscarButton_Click(object sender, EventArgs e)
        {
            AppHelper.DoMethod(delegate 
            {
                Model.FechaInicial = AppHelper.FechaInicial(this.FechaInicialDateTimePicker.Value);
                Model.FechaFinal = AppHelper.FechaFinal(this.FechaFinalDateTimePicker.Value);
                Model.ConsultarVentas();
                this.Vista_MatrizVentasTallerBindingSource.DataSource = Model.VistaVentas;
                this.MatrizVentasReportViewer.RefreshReport();
            }, this);
        }
    }
}
