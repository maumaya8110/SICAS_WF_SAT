using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SICASv20.forms
{
    public partial class Menues : baseForm
    {
        public Menues()
        {
            InitializeComponent();
        }

        private void menuesBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.menuesBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.sICASCentralDataSet);
        }

        public override void BindData()
        {
            this.modulosTableAdapter.Fill(this.sICASCentralDataSet.Modulos, null);
            this.menuesTableAdapter.Fill(this.sICASCentralDataSet.Menues, null);
            base.BindData();
        }

        private void fillToolStripButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (menu_IDToolStripTextBox.Text != "")
                {
                    this.menuesTableAdapter.Fill(
                        this.sICASCentralDataSet.Menues,
                            ((int)(System.Convert.ChangeType(menu_IDToolStripTextBox.Text, typeof(int)))));
                }
                else
                {
                    this.menuesTableAdapter.Fill(this.sICASCentralDataSet.Menues, null);
                }
            }
            catch (Exception ex)
            {
                AppHelper.Error(ex.Message);
            }
        }
    }
}
