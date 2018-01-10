using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SICASv20.forms
{
    public partial class ReporteConsumoCostoDia : baseForm
    {
        public ReporteConsumoCostoDia()
        {
            InitializeComponent();
        }

        private ReporteConsumoCostoDia_Model Model;

        class ReporteConsumoCostoDia_Model
        {
            private List<Entities.Vista_ConsumosCostoDia> _VistaConsumos;
            public List<Entities.Vista_ConsumosCostoDia> VistaConsumos
            {
                get { return _VistaConsumos; }
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

            public void Consultar()
            {
                this._VistaConsumos = Entities.Vista_ConsumosCostoDia.Get(
                    this.FechaInicial, 
                    this.FechaFinal,
                    Sesion.Empresa_ID.Value,
                    Sesion.Estacion_ID.Value);
            }
            
        }

        public override void BindData()
        {
            this.Model = new ReporteConsumoCostoDia_Model();
            base.BindData();
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
                        AppHelper.GridExport.GridToXls(ref this.vista_ConsumosCostoDiaDataGridView, ruta);
                    }
                }
            }, this);
        }

        private void BuscarButton_Click(object sender, EventArgs e)
        {
            AppHelper.DoMethod(delegate 
            {
                Model.FechaInicial = AppHelper.FechaInicial(this.FechaInicialDateTimePicker.Value);
                Model.FechaFinal = AppHelper.FechaFinal(this.FechaFinalDateTimePicker.Value);
                Model.Consultar();
                this.vista_ConsumosCostoDiaBindingSource.DataSource = Model.VistaConsumos;
            }, this);
        }
    }
}
