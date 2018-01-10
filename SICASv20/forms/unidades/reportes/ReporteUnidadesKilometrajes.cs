using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SICASv20.forms
{
    public partial class ReporteUnidadesKilometrajes : baseForm
    {
        public ReporteUnidadesKilometrajes()
        {
            InitializeComponent();
        }

        class ReporteUnidadesKilometrajes_Model
        {
            public ReporteUnidadesKilometrajes_Model()
            { 
            }

            private int? _NumeroEconomico;
            public int? NumeroEconomico
            {
                get { return _NumeroEconomico; }
                set { _NumeroEconomico = value; }
            }

            private DateTime? _FechaInicial;
            public DateTime? FechaInicial
            {
                get { return _FechaInicial; }
                set { _FechaInicial = value; }
            }

            private DateTime? _FechaFinal;
            public DateTime? FechaFinal
            {
                get { return _FechaFinal; }
                set { _FechaFinal = value; }
            }

            private DataTable _Reporte;
            public DataTable Reporte
            {
                get { return _Reporte; }
                set { _Reporte = value; }
            }

            public void ConsultarReporte()
            {
                this.Reporte = 
                    Entities.Vista_ReporteUnidadesKilometrajes.GetDataTable(this.FechaInicial, this.FechaFinal, this.NumeroEconomico);
            }
        }

        private ReporteUnidadesKilometrajes_Model Model;

        public override void BindData()
        {
            this.Model = new ReporteUnidadesKilometrajes_Model();
            base.BindData();
        }

        private void ReporteUnidadesKilometrajes_Load(object sender, EventArgs e)
        {

        }

        private void BuscarButton_Click(object sender, EventArgs e)
        {
            AppHelper.DoMethod(delegate 
            {
                Model.NumeroEconomico = DB.GetNullableInt32(this.UnidadTextBox.Text);
                Model.FechaInicial = AppHelper.FechaInicial(this.FechaInicialDateTimePicker.Value);
                Model.FechaFinal = AppHelper.FechaFinal(this.FechaFinalDateTimePicker.Value);
                Model.ConsultarReporte();
                this.Vista_ReporteUnidadesKilometrajesBindingSource.DataSource = Model.Reporte;

                this.ReporteUnidadesKilometrajesReportViewer.RefreshReport();
            }, this);
        }
    }
}
