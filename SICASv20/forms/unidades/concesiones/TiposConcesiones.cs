using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SICASv20.forms
{
    public partial class TiposConcesiones : baseForm
    {
        public TiposConcesiones()
        {
            InitializeComponent();
        }

        private void tiposConcesionesBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            AppHelper.DoMethod(
                delegate
                {
                    this.Validate();
                    this.tiposConcesionesBindingSource.EndEdit();
                    this.tableAdapterManager.UpdateAll(this.sICASCentralDataSet);
                    AppHelper.Info("Registros actualizados");
                },
                this
            );
        }

        private void TiposConcesiones_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'sICASCentralDataSet.TiposConcesiones' table. You can move, or remove it, as needed.
            this.tiposConcesionesTableAdapter.Fill(this.sICASCentralDataSet.TiposConcesiones);

        }
    }
}
