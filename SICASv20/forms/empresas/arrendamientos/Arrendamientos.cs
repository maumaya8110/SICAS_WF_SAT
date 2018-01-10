using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Microsoft.VisualBasic;

namespace SICASv20.forms
{
    /// <summary>
    /// Visualiza los arrendamientos en el sistema
    /// </summary>
    public partial class Arrendamientos : baseForm
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Arrendamientos"/> class.
        /// </summary>
        public Arrendamientos()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Proceso llevado a cabo para cargar datos y preparar la forma
        /// </summary>
        public override void BindData()
        {
            this.vista_ArrendamientosTableAdapter.Fill(this.sICASCentralQuerysIIDataSet.Vista_Arrendamientos, null, null);
            base.BindData();
        }

        /// <summary>
        /// Handles the Load event of the Arrendamientos control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void Arrendamientos_Load(object sender, EventArgs e)
        {            
            BindData();
        }

        /// <summary>
        /// Handles the Click event of the BuscarButton control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        /// <exception cref="System.Exception">El arrendamiento debe tener valor numérico</exception>
        private void BuscarButton_Click(object sender, EventArgs e)
        {
            try
            {
                int? arrendamiento_id = null;
                if (!string.IsNullOrEmpty(this.Arrendamiento_IDTextBox.Text))
                { 
                    if(AppHelper.IsNumeric(this.Arrendamiento_IDTextBox.Text))
                    {
                        arrendamiento_id = Convert.ToInt32(this.Arrendamiento_IDTextBox.Text);
                    }
                    else
                    {
                        throw new Exception("El arrendamiento debe tener valor numérico");
                    }
                }

                this.vista_ArrendamientosTableAdapter.Fill(
                    this.sICASCentralQuerysIIDataSet.Vista_Arrendamientos, 
                        arrendamiento_id, this.DescripcionTextBox.Text);
            }
            catch (System.Exception ex)
            {
                AppHelper.Error(ex.Message);
            }
        }

        /// <summary>
        /// Handles the CellContentClick event of the vista_ArrendamientosDataGridView control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="DataGridViewCellEventArgs"/> instance containing the event data.</param>
        private void vista_ArrendamientosDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (vista_ArrendamientosDataGridView.Columns[e.ColumnIndex].Name == "EditColumn")
                {
                    int arrendamiento_ID = Convert.ToInt32(vista_ArrendamientosDataGridView.Rows[e.RowIndex].Cells["Arrendamiento_IDColumn"].Value);
                    forms.ActualizacionArrendamiento actualizacionArr = new ActualizacionArrendamiento();
                    actualizacionArr.Arrendamiento_ID = arrendamiento_ID;
                    Padre.SwitchForma("ActualizacionArrendamiento", actualizacionArr);
                }
            }
            catch (Exception ex)
            {
                AppHelper.Error(ex.Message);
            }
        }

    }
}
