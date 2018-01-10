using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SICASv20.forms
{
    public partial class ComprasConsolidado : baseForm
    {
        public ComprasConsolidado()
        {
            InitializeComponent();
        }

        private ComprasConsolidado_Model Model;

        class ComprasConsolidado_Model
        {
            private List<Entities.Vista_ComprasConsolidadas> _VistaCompras;
            public List<Entities.Vista_ComprasConsolidadas> VistaCompras
            {
                get { return _VistaCompras; }
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

            public void ConsultarCompras()
            {
                this._VistaCompras = 
                    Entities.Vista_ComprasConsolidadas.Get(
                    this.FechaInicial, 
                    this.FechaFinal,
                    Sesion.Empresa_ID.Value,
                    Sesion.Estacion_ID.Value);
            }
            
        }

        public override void BindData()
        {
            this.Model = new ComprasConsolidado_Model();            
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
                        AppHelper.GridExport.GridToXls(ref this.vista_ComprasConsolidadasDataGridView, ruta);
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
                Model.ConsultarCompras();
                this.vista_ComprasConsolidadasBindingSource.DataSource = Model.VistaCompras;
            }, this);
        }
    }
}
