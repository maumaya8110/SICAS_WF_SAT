using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SICASv20.forms
{
    public partial class CategoriasMecanicos : baseForm
    {
        public CategoriasMecanicos()
        {
            InitializeComponent();
        }

        public override void BindData()
        {
            Vista_CategoriasMecanicosBindingSource.DataSource = Entities.Vista_CategoriasMecanicos.Get(null, null, null);
            selectFamiliasBindingSource.DataSource = Entities.SelectFamilias.Get();
            base.BindData();
        }

        private void DoQuery()
        {
            Int32? categoriamecanico_id;
            Int32? familia_id;
            String nombre;
            categoriamecanico_id = DB.GetNullableInt32(CategoriaMecanico_IDTextBox.Text);
            familia_id = DB.GetNullableInt32(Familia_IDComboBox.SelectedValue);
            nombre = (NombreTextBox.Text);
            Vista_CategoriasMecanicosBindingSource.DataSource = Entities.Vista_CategoriasMecanicos.Get(categoriamecanico_id, familia_id, nombre);
        }

        int row, col;
        private void DoNavigate()
        {
            if (Vista_CategoriasMecanicosDataGridView.Columns[col].Name == "EditColumn")
            {
                forms.ActualizacionCategoriasMecanicos CategoriasMecanicosForm = new ActualizacionCategoriasMecanicos();
                Entities.Vista_CategoriasMecanicos CategoriasMecanicosLower = (Entities.Vista_CategoriasMecanicos)Vista_CategoriasMecanicosDataGridView.Rows[row].DataBoundItem;
                CategoriasMecanicosForm.CategoriaMecanico_ID = CategoriasMecanicosLower.CategoriaMecanico_ID.Value;

                Padre.SwitchForma("ActualizacionCategoriasMecanicos", CategoriasMecanicosForm);
            }
        }

        private void BuscarButton_Click(object sender, EventArgs e)
        {
            AppHelper.DoMethod(new AppHelper.HelperDelegate(DoQuery), this);
        }

        private void Vista_CategoriasMecanicosDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            row = e.RowIndex;
            col = e.ColumnIndex;
            AppHelper.DoMethod(new AppHelper.HelperDelegate(DoNavigate), this);
        }

    }
}
