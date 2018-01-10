using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SICASv20.forms
{
    public partial class InputCantidad : Form
    {
        public InputCantidad()
        {
            InitializeComponent();
            CantidadTextBox.Focus();
        }

        public int Cantidad;

        private void CantidadTextBox_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                Cantidad = Convert.ToInt32(this.CantidadTextBox.Text);
                this.CantidadTextBox.Text = string.Empty;
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
                this.Close();
            }
        }
    }
}
