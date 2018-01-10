using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SICASv20.forms
{
    public partial class ModelosUnidades : baseForm
    {
        public ModelosUnidades()
        {
            InitializeComponent();
        }

        private void modelosUnidadesBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            AppHelper.DoMethod(
                delegate
                {
                    this.Validate();
                    this.modelosUnidadesBindingSource.EndEdit();
                    this.tableAdapterManager.UpdateAll(this.sICASCentralDataSet);
                    AppHelper.Info("Registros actualizados");
                },
                this
            );
        }

        private void ModelosUnidades_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'sICASCentralDataSet.MarcasUnidades' table. You can move, or remove it, as needed.
            this.marcasUnidadesTableAdapter.Fill(this.sICASCentralDataSet.MarcasUnidades);
            // TODO: This line of code loads data into the 'sICASCentralDataSet.ModelosUnidades' table. You can move, or remove it, as needed.
            this.modelosUnidadesTableAdapter.Fill(this.sICASCentralDataSet.ModelosUnidades);

        }
    }
}
