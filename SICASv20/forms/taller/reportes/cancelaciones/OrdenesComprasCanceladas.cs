using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SICASv20.forms
{
    public partial class OrdenesComprasCanceladas : baseForm
    {
        public OrdenesComprasCanceladas()
        {
            InitializeComponent();
        }

        class Model
        {
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

            private List<Entities.Vista_OrdenesComprasCanceladas> _Cancelaciones;
            public List<Entities.Vista_OrdenesComprasCanceladas> Cancelaciones
            {
                get { return _Cancelaciones; }
                set { _Cancelaciones = value; }
            }

            public void ConsultarCancelaciones()
            {
                this.Cancelaciones = Entities.Vista_OrdenesComprasCanceladas.Get(this.FechaInicial, this.FechaFinal, Sesion.Empresa_ID.Value, Sesion.Estacion_ID.Value);
            }
        }

        private Model model;

        public override void BindData()
        {
            model = new Model();
            base.BindData();
        }

        private void BuscarButton_Click(object sender, EventArgs e)
        {
            AppHelper.DoMethod(delegate
            {
                model.FechaInicial = AppHelper.FechaInicial(FechaInicialDateTimePicker.Value);
                model.FechaFinal = AppHelper.FechaFinal(FechaFinalDateTimePicker.Value);

                model.ConsultarCancelaciones();
                this.vista_OrdenesComprasCanceladasBindingSource.DataSource = model.Cancelaciones;

            }, this);
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
                        AppHelper.GridExport.GridToXls(ref this.vista_OrdenesComprasCanceladasDataGridView, ruta);
                    }
                }
            },this);
        }
    }
}
