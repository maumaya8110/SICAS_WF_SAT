using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SICASv20.forms
{
    public partial class Mecanicos : baseForm
    {
        public Mecanicos()
        {
            InitializeComponent();
        }



        public override void BindData()
        {
            Vista_MecanicosBindingSource.DataSource = Entities.Vista_Mecanicos.Get(null, null, null, null, Sesion.Empresa_ID.Value, Sesion.Estacion_ID.Value);
            selectCategoriasMecanicosBindingSource.DataSource = Entities.SelectCategoriasMecanicos.Get();
            base.BindData();
        }

        private void DoQuery()
        {
            Int32? mecanico_id;
            Int32? categoriamecanico_id;
            String nombres;
            String apellidos;
            mecanico_id = DB.GetNullableInt32(Mecanico_IDTextBox.Text);
            categoriamecanico_id = DB.GetNullableInt32(CategoriaMecanico_IDComboBox.SelectedValue);
            nombres = (NombresTextBox.Text);
            apellidos = (ApellidosTextBox.Text);
            Vista_MecanicosBindingSource.DataSource = Entities.Vista_Mecanicos.Get(mecanico_id, categoriamecanico_id, nombres, apellidos, Sesion.Empresa_ID.Value, Sesion.Estacion_ID.Value);
        }

        int row, col;
        private void DoNavigate()
        {
            if (Vista_MecanicosDataGridView.Columns[col].Name == "EditColumn")
            {
                forms.ActualizacionMecanicos MecanicosForm = new ActualizacionMecanicos();
                Entities.Vista_Mecanicos MecanicosLower = (Entities.Vista_Mecanicos)Vista_MecanicosDataGridView.Rows[row].DataBoundItem;
                MecanicosForm.Mecanico_ID = MecanicosLower.Mecanico_ID;

                Padre.SwitchForma("ActualizacionMecanicos", MecanicosForm);
            }
        }

        private void BuscarButton_Click(object sender, EventArgs e)
        {
            AppHelper.DoMethod(new AppHelper.HelperDelegate(DoQuery), this);
        }

        private void Vista_MecanicosDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            row = e.RowIndex;
            col = e.ColumnIndex;
            AppHelper.DoMethod(new AppHelper.HelperDelegate(DoNavigate), this);
        }


    }
}
