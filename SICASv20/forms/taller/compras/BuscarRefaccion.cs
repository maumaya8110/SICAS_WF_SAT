using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SICASv20.forms
{
    public partial class BuscarRefaccion : Form
    {
        public BuscarRefaccion()
        {
            InitializeComponent();
            AppHelper.SetStylish(this);
        }

        public AltaOrdenCompra Padre;

        private void BuscarRefacciones()
        {                       
            refaccionesBindingSource.DataSource =
                Entities.Vista_Refacciones.Get(null, null, null, null, null, RefaccionTextBox.Text, null, Sesion.Empresa_ID.Value, Sesion.Estacion_ID.Value);
        }

        private void RefaccionesGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (RefaccionesGridView.Columns[e.ColumnIndex].Name == "Seleccionar")
                {
                    Entities.Vista_Refacciones refaccion = (Entities.Vista_Refacciones)RefaccionesGridView.Rows[e.RowIndex].DataBoundItem;
                    Padre.Set_Refaccion(refaccion);
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                AppHelper.Error(ex.Message);
            }
        }

        private void BuscarButton_Click(object sender, EventArgs e)
        {
            try
            {
                BuscarRefacciones();
            }
            catch (Exception ex)
            {
                AppHelper.Error(ex.Message);
            }
        }
    }
}
