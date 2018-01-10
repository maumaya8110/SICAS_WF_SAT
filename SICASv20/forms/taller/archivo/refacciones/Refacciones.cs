using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SICASv20.forms
{
    public partial class Refacciones : baseForm
    {
        public Refacciones()
        {
            InitializeComponent();
        }

        public override void BindData()
        {
            //Vista_RefaccionesBindingSource.DataSource = 
            //    Entities.Vista_Refacciones.Get(null, null, null, null, null, null, null, 
            //    Sesion.Empresa_ID.Value, Sesion.Empresa_ID.Value);

            selectTiposRefaccionesBindingSource.DataSource = Entities.SelectTiposRefacciones.Get();
            selectModelosBindingSource.DataSource = Entities.SelectModelos.Get();
            selectMarcasRefaccionesBindingSource.DataSource = Entities.SelectMarcasRefacciones.Get();
            base.BindData();
        }

        private void DoQuery()
        {
            Int32? refaccion_id;
            Int32? tiporefaccion_id;
            Int32? modelo_id;
            Int32? marcarefaccion_id;
            String descripcion;
            refaccion_id = DB.GetNullableInt32(Refaccion_IDTextBox.Text);
            tiporefaccion_id = DB.GetNullableInt32(TipoRefaccion_IDComboBox.SelectedValue);
            modelo_id = DB.GetNullableInt32(Modelo_IDComboBox.SelectedValue);
            marcarefaccion_id = DB.GetNullableInt32(MarcaRefaccion_IDComboBox.SelectedValue);
            descripcion = DescripcionTextBox.Text;

            Vista_RefaccionesBindingSource.DataSource =
                Entities.Vista_Refacciones.Get(
                    refaccion_id,
                    tiporefaccion_id,
                    null,
                    modelo_id,
                    marcarefaccion_id,
                    descripcion,
                    null,
                    Sesion.Empresa_ID.Value,
                    Sesion.Estacion_ID.Value
                );
        }

        int row, col;
        private void DoNavigate()
        {
            if (Vista_RefaccionesDataGridView.Columns[col].Name == "EditColumn")
            {
                forms.ActualizacionRefacciones RefaccionesForm = new ActualizacionRefacciones();
                Entities.Vista_Refacciones RefaccionesLower = (Entities.Vista_Refacciones)Vista_RefaccionesDataGridView.Rows[row].DataBoundItem;
                RefaccionesForm.Refaccion_ID = RefaccionesLower.Refaccion_ID.Value;

                Padre.SwitchForma("ActualizacionRefacciones", RefaccionesForm);
            }
        }

        private void BuscarButton_Click(object sender, EventArgs e)
        {
            AppHelper.DoMethod(new AppHelper.HelperDelegate(DoQuery), this);
        }

        private void Vista_RefaccionesDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            row = e.RowIndex;
            col = e.ColumnIndex;
            AppHelper.DoMethod(new AppHelper.HelperDelegate(DoNavigate), this);
        }

    }
}
