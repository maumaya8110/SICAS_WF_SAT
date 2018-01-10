using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SICASv20.forms
{
    public partial class ReporteAjustesInventario : baseForm
    {
        public ReporteAjustesInventario()
        {
            InitializeComponent();
        }

        #region Properties

        private ReporteAjustesInventario_Model Model;

        #endregion

        #region Model

        class ReporteAjustesInventario_Model
        {
            private Entities.TiposAjustesInventario _TipoAjusteInventario;
            public Entities.TiposAjustesInventario TipoAjusteInventario
            {
                get { return _TipoAjusteInventario; }
                set { _TipoAjusteInventario = value; }
            }

            private List<Entities.TiposAjustesInventario> _TiposAjustesInventario;
            public List<Entities.TiposAjustesInventario> TiposAjustesInventario
            {
                get { return _TiposAjustesInventario; }
                set { _TiposAjustesInventario = value; }
            }

            private List<Entities.Vista_AjustesInventario> _AjustesInventario;
            public List<Entities.Vista_AjustesInventario> AjustesInventario
            {
                get { return _AjustesInventario; }
                set { _AjustesInventario = value; }
            }

            private string _DescripcionRefaccion;
            public string DescripcionRefaccion
            {
                get { return _DescripcionRefaccion; }
                set { _DescripcionRefaccion = value; }
            }

            private int _Empresa_ID;
            public int Empresa_ID
            {
                get { return _Empresa_ID; }
                set { _Empresa_ID = value; }
            }

            private int _Estacion_ID;
            public int Estacion_ID
            {
                get { return _Estacion_ID; }
                set { _Estacion_ID = value; }
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

            public void ConsultarTiposAjustesInventarios()
            {
                this.TiposAjustesInventario = Entities.TiposAjustesInventario.Read();
            }

            public void ConsultarAjustesInventario()
            {
                this.AjustesInventario =
                    Entities.Vista_AjustesInventario.Get(
                        this.TipoAjusteInventario.TipoAjusteInventario_ID,
                        this.DescripcionRefaccion,
                        this.Empresa_ID,
                        this.Estacion_ID,
                        this.FechaInicial,
                        this.FechaFinal
                    );
            }
        }

        #endregion

        #region Eventos

        public override void BindData()
        {
            this.Model = new ReporteAjustesInventario_Model();
            this.Model.Empresa_ID = Sesion.Empresa_ID.Value;
            this.Model.Estacion_ID = Sesion.Estacion_ID.Value;
            this.Model.FechaInicial = AppHelper.FechaInicial(this.FechaInicialDateTimePicker.Value);
            this.Model.FechaFinal = AppHelper.FechaFinal(this.FechaFinalDateTimePicker.Value);

            this.Model.ConsultarTiposAjustesInventarios();
            this.tiposAjustesInventarioBindingSource.DataSource = this.Model.TiposAjustesInventario;

            this.Model.TipoAjusteInventario =
                    (Entities.TiposAjustesInventario)this.TipoMovimientoInventarioComboBox.SelectedItem;

            base.BindData();
        }

        private void BuscarButton_Click(object sender, EventArgs e)
        {
            AppHelper.DoMethod(delegate
            {
                this.Model.ConsultarAjustesInventario();
                this.vista_AjustesInventarioBindingSource.DataSource = this.Model.AjustesInventario;
            }, this);
        }        

        private void TipoMovimientoInventarioComboBox_SelectionChangeCommitted(object sender, EventArgs e)
        {
            AppHelper.Try(delegate
            {
                this.Model.TipoAjusteInventario =
                    (Entities.TiposAjustesInventario)this.TipoMovimientoInventarioComboBox.SelectedItem;
            });
        }

        private void ExportarButton_Click(object sender, EventArgs e)
        {
            AppHelper.ExportDataGridViewExcel(this.ReporteAjustesInventarioDataGridView, this);
        }
        

        private void DescripcionRefaccionTextBox_TextChanged(object sender, EventArgs e)
        {
            AppHelper.Try(delegate
            {
                this.Model.DescripcionRefaccion = this.DescripcionRefaccionTextBox.Text;
            });
        }
        #endregion

        private void FechaInicialDateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            AppHelper.Try(delegate
            {
                this.Model.FechaInicial = AppHelper.FechaInicial(this.FechaInicialDateTimePicker.Value);
            });
        }

        private void FechaFinalDateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            AppHelper.Try(delegate
            {
                this.Model.FechaFinal = AppHelper.FechaFinal(this.FechaFinalDateTimePicker.Value);
            });
        }
    }
}
