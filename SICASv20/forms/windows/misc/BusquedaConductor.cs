using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SICASv20.forms
{
    public partial class BusquedaConductor : Form
    {
        public BusquedaConductor()
        {
            InitializeComponent();
            AppHelper.SetStylish(this);
        }

        private int _Conductor_ID;
        public int Conductor_ID
        {
            get { return _Conductor_ID; }
            set { _Conductor_ID = value; }
        }

        private string _NombreConductor;
        public string NombreConductor
        {
            get { return _NombreConductor; }
            set { _NombreConductor = value; }
        }
        
        private void ConsultarButton_Click(object sender, EventArgs e)
        {
            try
            {
                int? conductor_id = null, estacion_id = null;
                string nombre = null;

                if (Conductor_IDTextBox.Text != "")
                    if (AppHelper.IsNumeric(Conductor_IDTextBox.Text))
                        conductor_id = Convert.ToInt32(Conductor_IDTextBox.Text);

                if (NombreTextBox.Text != "") nombre = NombreTextBox.Text;

                if (EstacionComboBox.SelectedValue != null && !Convert.IsDBNull(EstacionComboBox.SelectedValue)) estacion_id = Convert.ToInt32(EstacionComboBox.SelectedValue);

                vista_ConductoresTableAdapter.Fill(sICASCentralQuerysDataSet.Vista_Conductores, conductor_id, nombre, estacion_id);
            }
            catch (Exception ex)
            {
                AppHelper.Error(ex.Message);
            }
        }

        private void BusquedaConductor_Load(object sender, EventArgs e)
        {
            AppHelper.Try(
                delegate 
                {
                    this.selectEstacionesBindingSource.DataSource =
                        Entities.SelectEstaciones.Get();
                }
            );
        }

        private void vista_ConductoresDataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                vista_ConductoresDataGridView.Rows[e.RowIndex].Selected = true;
                Conductor_ID = Convert.ToInt32(
                    vista_ConductoresDataGridView.Rows[e.RowIndex].Cells["Conductor_IDColumn"].Value);

                DataGridViewCellCollection cells = vista_ConductoresDataGridView.Rows[e.RowIndex].Cells;
                NombreConductor = cells["NombreColumn"].Value.ToString();

                this.DialogResult = System.Windows.Forms.DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                AppHelper.Error(ex.Message);
            }
        }
    }
}
