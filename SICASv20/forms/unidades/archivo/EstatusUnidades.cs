using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SICASv20.forms
{
    public partial class EstatusUnidades : baseForm
    {
        public EstatusUnidades()
        {
            InitializeComponent();
        }

        private void estatusUnidadesBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            AppHelper.DoMethod(
                delegate
                {
                    this.Validate();
                    this.estatusUnidadesBindingSource.EndEdit();
                    this.tableAdapterManager.UpdateAll(this.sICASCentralDataSet);
                    AppHelper.Info("Registros actualizados");
                },
                this
            );
        }

        private void EstatusUnidades_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'sICASCentralDataSet.EstatusUnidades' table. You can move, or remove it, as needed.
            this.estatusUnidadesTableAdapter.Fill(this.sICASCentralDataSet.EstatusUnidades);

        }
    }
}
