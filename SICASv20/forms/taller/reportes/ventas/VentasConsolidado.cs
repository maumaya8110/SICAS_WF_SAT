using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SICASv20.forms
{
    public partial class VentasConsolidado : baseForm
    {
        public VentasConsolidado()
        {
            InitializeComponent();
        }

        private VentasConsolidado_Model Model;

        class VentasConsolidado_Model
        {
            private List<Entities.Vista_ConsumosConsolidadosTaller> _VistaVentas;
            public List<Entities.Vista_ConsumosConsolidadosTaller> VistaVentas
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
                this._VistaVentas = Entities.Vista_ConsumosConsolidadosTaller.Get(
                    this.FechaInicial, 
                    this.FechaFinal, 
                    Sesion.Empresa_ID.Value,
                    Sesion.Estacion_ID.Value);
            }
            
        }

        public override void BindData()
        {
            this.Model = new VentasConsolidado_Model();
            base.BindData();
        }

        private void ExportarButton_Click(object sender, EventArgs e)
        {
            AppHelper.ExportDataGridViewExcel(this.vista_ConsumosConsolidadosTallerDataGridView, this);
        }

        private void BuscarButton_Click(object sender, EventArgs e)
        {
            AppHelper.DoMethod(delegate 
            {
                Model.FechaInicial = AppHelper.FechaInicial(this.FechaInicialDateTimePicker.Value);
                Model.FechaFinal = AppHelper.FechaFinal(this.FechaFinalDateTimePicker.Value);
                Model.ConsultarVentas();
                this.vista_ConsumosConsolidadosTallerBindingSource.DataSource = Model.VistaVentas;
            }, this);
        }
    }
}
