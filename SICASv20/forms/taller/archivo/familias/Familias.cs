using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SICASv20.forms
{
    public partial class Familias : baseForm
    {
        public Familias()
        {
            InitializeComponent();
        }

        public override void BindData()
        {
            this.familiasBindingSource.DataSource = Entities.Familias.Read();
            base.BindData();
        }

        private void familiasDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (familiasDataGridView.Columns[e.ColumnIndex].Name == "EditColumn")
            {
                forms.ActualizacionFamilia af = new ActualizacionFamilia();
                Entities.Familias f = (Entities.Familias)familiasDataGridView.Rows[e.RowIndex].DataBoundItem;
                af.Familia_ID = f.Familia_ID;
                Padre.SwitchForma("ActualizacionFamilia", af);
            }
        }
    }
}
