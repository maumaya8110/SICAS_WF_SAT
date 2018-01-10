using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SICASv20.forms
{
    public partial class Opciones : baseForm
    {
        public Opciones()
        {
            InitializeComponent();
        }

        public override void BindData()
        {
            this.get_ModulosTableAdapter.Fill(
                this.sICASCentralQuerysDataSet.Get_Modulos);

            this.vista_OpcionesTableAdapter.Fill(
                this.sICASCentralQuerysDataSet.Vista_Opciones,
                    null, null, null);

            base.BindData();
        }

        private void Opciones_Load(object sender, EventArgs e)
        {
            
        }

        private void ModuloComboBox_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (ModuloComboBox.SelectedValue != null &&
                !Convert.IsDBNull(ModuloComboBox.SelectedValue))
            {
                this.get_MenuesTableAdapter.Fill(
                    sICASCentralQuerysDataSet.Get_Menues,
                        Convert.ToInt32(ModuloComboBox.SelectedValue));
            }
        }

        private void DoQuery()
        {
            try
            {
                int? modulo, menu, opcion;
                modulo = AppHelper.GetNullable(ModuloComboBox.SelectedValue);
                menu = AppHelper.GetNullable(MenuComboBox.SelectedValue);
                opcion = AppHelper.GetNullable(OpcionIDTextBox.Text);

                this.vista_OpcionesTableAdapter.Fill(
                    this.sICASCentralQuerysDataSet.Vista_Opciones,
                        opcion, menu, modulo);
            }
            catch (Exception ex)
            {
                AppHelper.Error(ex.Message);
            }
        }

        private void ConsultarButton_Click(object sender, EventArgs e)
        {
            DoQuery();
        }

        private void OpcionesGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == OpcionesGridView.Columns["Actualizar"].Index)
                {
                    forms.ActualizacionOpcion ao = new forms.ActualizacionOpcion();
                    ao.Opcion_ID = Convert.ToInt32(this.OpcionesGridView.Rows[e.RowIndex].Cells["Opcion_IDCell"].Value);

                    Padre.SwitchForma("ActualizacionOpcion", ao);
                    return;
                }

                if (e.ColumnIndex == OpcionesGridView.Columns["Eliminar"].Index)
                {
                    if (AppHelper.Confirm("¿Realmente desea eliminar el registro?") == DialogResult.Yes)
                    {
                        int opcionid = Convert.ToInt32(this.OpcionesGridView.Rows[e.RowIndex].Cells["Opcion_IDCell"].Value);

                        SICASCentralDataSetTableAdapters.OpcionesTableAdapter OpcionesTA =
                            new SICASCentralDataSetTableAdapters.OpcionesTableAdapter();

                        OpcionesTA.Delete(opcionid);

                        AppHelper.Info("Registro Eliminado");

                        DoQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                AppHelper.Error(ex.Message);
            }
        }
    }
}
