using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SICASv20.forms
{
    public partial class Modulos : baseForm
    {
        public Modulos()
        {
            InitializeComponent();
        }

        private void modulosBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.modulosBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.sICASCentralDataSet);
        }

        public override void BindData()
        {
            this.modulosTableAdapter.Fill(this.sICASCentralDataSet.Modulos, null);
            base.BindData();
        }

        private void fillToolStripButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (modulo_IDToolStripTextBox.Text != "")
                {
                    this.modulosTableAdapter.Fill(
                        this.sICASCentralDataSet.Modulos, 
                            ((int)(System.Convert.ChangeType(modulo_IDToolStripTextBox.Text, typeof(int)))));
                }
                else
                {
                    this.modulosTableAdapter.Fill(this.sICASCentralDataSet.Modulos, null);
                }
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
        }
    }
}
