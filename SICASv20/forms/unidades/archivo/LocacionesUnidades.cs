using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SICASv20.forms
{
    public partial class LocacionesUnidades : baseForm
    {
        public LocacionesUnidades()
        {
            InitializeComponent();
        }

        private void locacionesUnidadesBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            AppHelper.DoMethod(
                delegate
                {
                    this.Validate();
                    this.locacionesUnidadesBindingSource.EndEdit();
                    this.tableAdapterManager.UpdateAll(this.sICASCentralDataSet);
                    AppHelper.Info("Registros actualizados");
                },
                this
            );
        }

        private void LocacionesUnidades_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'sICASCentralDataSet.LocacionesUnidades' table. You can move, or remove it, as needed.
            this.locacionesUnidadesTableAdapter.Fill(this.sICASCentralDataSet.LocacionesUnidades);

        }
    }
}
