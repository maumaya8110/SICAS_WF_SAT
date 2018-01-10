using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SICASv20.forms
{
    public partial class ServiciosMantenimientos : baseForm
    {
        public ServiciosMantenimientos()
        {
            InitializeComponent();
        }

        public override void BindData()
        {
            //Vista_ServiciosMantenimientosBindingSource.DataSource = Entities.Vista_ServiciosMantenimientos.Get(null, null, null, null);
            selectTiposServiciosMantenimientosBindingSource.DataSource = Entities.SelectTiposServiciosMantenimientos.Get();
            selectFamiliasBindingSource.DataSource = Entities.SelectFamilias.Get();
            selectModelosBindingSource.DataSource = Entities.SelectModelos.Get();
            base.BindData();
        }

        private void DoQuery()
        {
            Int32? serviciomantenimiento_id = null;
            Int32? tiposerviciomantenimiento_id;
            Int32? familia_id;
            Int32? modelo_id;
            String nombre;

            nombre = NombreTextBox.Text;
            tiposerviciomantenimiento_id = DB.GetNullableInt32(TipoServicioMantenimiento_IDComboBox.SelectedValue);
            familia_id = DB.GetNullableInt32(Familia_IDComboBox.SelectedValue);
            modelo_id = null;
            Vista_ServiciosMantenimientosBindingSource.DataSource = 
                Entities.Vista_ServiciosMantenimientos.Get(
                    nombre,
                    serviciomantenimiento_id, 
                    tiposerviciomantenimiento_id, 
                    familia_id, 
                    modelo_id
                );
        }

        int row, col;
        private void DoNavigate()
        {
            if (Vista_ServiciosMantenimientosDataGridView.Columns[col].Name == "EditColumn")
            {
                forms.ActualizacionServiciosMantenimientos ServiciosMantenimientosForm = new ActualizacionServiciosMantenimientos();
                Entities.Vista_ServiciosMantenimientos ServiciosMantenimientosLower = (Entities.Vista_ServiciosMantenimientos)Vista_ServiciosMantenimientosDataGridView.Rows[row].DataBoundItem;
                ServiciosMantenimientosForm.ServicioMantenimiento_ID = ServiciosMantenimientosLower.ServicioMantenimiento_ID;

                Padre.SwitchForma("ActualizacionServiciosMantenimientos", ServiciosMantenimientosForm);
                
                return;
            }

            if (Vista_ServiciosMantenimientosDataGridView.Columns[col].Name == "PreciosColumn")
            {
                forms.ServiciosMantenimientosPrecios ServiciosMantenimientosForm = new ServiciosMantenimientosPrecios();
                Entities.Vista_ServiciosMantenimientos ServiciosMantenimientosLower = (Entities.Vista_ServiciosMantenimientos)Vista_ServiciosMantenimientosDataGridView.Rows[row].DataBoundItem;
                ServiciosMantenimientosForm.ServicioMantenimiento_ID = ServiciosMantenimientosLower.ServicioMantenimiento_ID;

                Padre.SwitchForma("ServiciosMantenimientosPrecios", ServiciosMantenimientosForm);

                return;
            }

            if (Vista_ServiciosMantenimientosDataGridView.Columns[col].Name == "TiposRefaccionesColumn")
            {
                forms.ServiciosMantenimientosTiposRefacciones ServiciosMantenimientosTiposRefaccionesForm = new ServiciosMantenimientosTiposRefacciones();
                Entities.Vista_ServiciosMantenimientos ServiciosMantenimientosLower = 
                    (Entities.Vista_ServiciosMantenimientos)Vista_ServiciosMantenimientosDataGridView.Rows[row].DataBoundItem;
                ServiciosMantenimientosTiposRefaccionesForm.ServicioMantenimiento_ID = ServiciosMantenimientosLower.ServicioMantenimiento_ID;

                Padre.SwitchForma("ServiciosMantenimientosTiposRefacciones", ServiciosMantenimientosTiposRefaccionesForm);

                return;
            }
        }

        private void BuscarButton_Click(object sender, EventArgs e)
        {
            AppHelper.DoMethod(new AppHelper.HelperDelegate(DoQuery), this);
        }

        private void Vista_ServiciosMantenimientosDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            row = e.RowIndex;
            col = e.ColumnIndex;
            AppHelper.DoMethod(new AppHelper.HelperDelegate(DoNavigate), this);
        }

    }
}
