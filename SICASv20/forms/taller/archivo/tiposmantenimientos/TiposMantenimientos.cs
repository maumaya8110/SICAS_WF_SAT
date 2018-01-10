using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SICASv20.forms
{
    public partial class TiposMantenimientos : baseForm
    {
        public TiposMantenimientos()
        {
            InitializeComponent();
        }



        public override void BindData()
        {
            Vista_TiposMantenimientosBindingSource.DataSource = Entities.Vista_TiposMantenimientos.Get(null, null);
            base.BindData();
        }

        private void DoQuery()
        {
            Int32? tipomantenimiento_id;
            String nombre;
            tipomantenimiento_id = DB.GetNullableInt32(TipoMantenimiento_IDTextBox.Text);
            nombre = (NombreTextBox.Text);
            Vista_TiposMantenimientosBindingSource.DataSource = Entities.Vista_TiposMantenimientos.Get(tipomantenimiento_id, nombre);
        }

        int row, col;
        private void DoNavigate()
        {
            if (Vista_TiposMantenimientosDataGridView.Columns[col].Name == "EditColumn")
            {
                forms.ActualizacionTiposMantenimientos TiposMantenimientosForm = new ActualizacionTiposMantenimientos();
                Entities.Vista_TiposMantenimientos TiposMantenimientosLower = (Entities.Vista_TiposMantenimientos)Vista_TiposMantenimientosDataGridView.Rows[row].DataBoundItem;
                TiposMantenimientosForm.TipoMantenimiento_ID = TiposMantenimientosLower.TipoMantenimiento_ID;

                Padre.SwitchForma("ActualizacionTiposMantenimientos", TiposMantenimientosForm);
            }
        }

        private void BuscarButton_Click(object sender, EventArgs e)
        {
            AppHelper.DoMethod(new AppHelper.HelperDelegate(DoQuery), this);
        }

        private void Vista_TiposMantenimientosDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            row = e.RowIndex;
            col = e.ColumnIndex;
            AppHelper.DoMethod(new AppHelper.HelperDelegate(DoNavigate), this);
        }

    }
}
