using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SICASv20.forms
{
    public partial class ReporteMovimientosInventario : baseForm
    {
        public ReporteMovimientosInventario()
        {
            InitializeComponent();
        }

        #region Properties

        private ReporteMovimientosInventario_Model Model;
        #endregion

        #region Model

        class ReporteMovimientosInventario_Model
        {
            private System.Int32? _TipoMovimientoInventario;
            public System.Int32? TipoMovimientoInventario
            {
                get { return _TipoMovimientoInventario; }
                set { _TipoMovimientoInventario = value; }
            }

            private System.Int32? _OrdenCompra;
            public System.Int32? OrdenCompra
            {
                get { return _OrdenCompra; }
                set { _OrdenCompra = value; }
            }

            private System.Int32? _OrdenTrabajo;
            public System.Int32? OrdenTrabajo
            {
                get { return _OrdenTrabajo; }
                set { _OrdenTrabajo = value; }
            }

            private System.Int32? _Ajuste;
            public System.Int32? Ajuste
            {
                get { return _Ajuste; }
                set { _Ajuste = value; }
            }

            private System.String _DescripcionRefaccion;
            public System.String DescripcionRefaccion
            {
                get { return _DescripcionRefaccion; }
                set { _DescripcionRefaccion = value; }
            }

            private System.DateTime? _FechaInicial;
            public System.DateTime? FechaInicial
            {
                get { return _FechaInicial; }
                set { _FechaInicial = value; }
            }

            private System.DateTime? _FechaFinal;
            public System.DateTime? FechaFinal
            {
                get { return _FechaFinal; }
                set { _FechaFinal = value; }
            }

            private List<Entities.SelectTiposMovimientosInventario> _TiposMovimientosInventario;
            public List<Entities.SelectTiposMovimientosInventario> TiposMovimientosInventario
            {
                get { return _TiposMovimientosInventario; }
                set { _TiposMovimientosInventario = value; }
            }

            private List<Entities.Vista_MovimientosInventario> _MovimientosInventario;
            public List<Entities.Vista_MovimientosInventario> MovimientosInventario
            {
                get { return _MovimientosInventario; }
                set { _MovimientosInventario = value; }
            }

            public void ConsultarTiposMovimientosInventarios()
            {
                this.TiposMovimientosInventario = Entities.SelectTiposMovimientosInventario.Get();
            }

            public void ConsultarMovimientosInventario()
            {
                this.MovimientosInventario =
                    Entities.Vista_MovimientosInventario.Get(this.TipoMovimientoInventario,
                        this.DescripcionRefaccion,
                        this.OrdenCompra,
                        this.OrdenTrabajo,
                        this.Ajuste,
                        this.FechaInicial,
                        this.FechaFinal,
                        Sesion.Empresa_ID.Value,
                        Sesion.Estacion_ID.Value
                    );
            }
        }

        #endregion

        #region Eventos

        public override void BindData()
        {
            this.Model = new ReporteMovimientosInventario_Model();
            this.Model.ConsultarTiposMovimientosInventarios();
            this.selectTiposMovimientosInventarioBindingSource.DataSource = this.Model.TiposMovimientosInventario;
            this.Model.FechaInicial = AppHelper.FechaInicial(this.FechaInicialDateTimePicker.Value);
            this.Model.FechaFinal = AppHelper.FechaFinal(this.FechaFinalDateTimePicker.Value);
            base.BindData();
        }

        private void TipoMovimientoInventarioComboBox_SelectionChangeCommitted(object sender, EventArgs e)
        {
            AppHelper.Try(delegate 
            {
                this.Model.TipoMovimientoInventario =
                    DB.GetNullableInt32(this.TipoMovimientoInventarioComboBox.SelectedValue);
            });
        }

        private void DescripcionRefaccionTextBox_TextChanged(object sender, EventArgs e)
        {
            AppHelper.Try(delegate
            {
                this.Model.DescripcionRefaccion = this.DescripcionRefaccionTextBox.Text;
            });
        }

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

        private void OrdenCompra_IDTextBox_TextChanged(object sender, EventArgs e)
        {
            AppHelper.Try(delegate
            {
                this.Model.OrdenCompra = DB.GetNullableInt32(this.OrdenCompra_IDTextBox.Text);
            });
        }

        private void OrdenTrabajo_IDTextBox_TextChanged(object sender, EventArgs e)
        {
            AppHelper.Try(delegate
            {
                this.Model.OrdenTrabajo = DB.GetNullableInt32(this.OrdenTrabajo_IDTextBox.Text);
            });
        }

        private void AjusteInventario_IDTextBox_TextChanged(object sender, EventArgs e)
        {
            AppHelper.Try(delegate
            {
                this.Model.Ajuste = DB.GetNullableInt32(this.AjusteInventario_IDTextBox.Text);
            });
        }

        private void BuscarButton_Click(object sender, EventArgs e)
        {
            AppHelper.DoMethod(delegate
            {
                this.Model.ConsultarMovimientosInventario();
                this.vista_MovimientosInventarioBindingSource.DataSource = this.Model.MovimientosInventario;
            }, this);
        }

        private void ExportarButton_Click(object sender, EventArgs e)
        {
            AppHelper.ExportDataGridViewExcel(this.ReporteMovimientosInventarioDataGridView, this);
        }
        #endregion
    }
}
