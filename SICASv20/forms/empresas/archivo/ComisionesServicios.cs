using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SICASv20.forms
{
    /// <summary>
    /// Formulario para visualizar las comisiones de servicio
    /// </summary>
    public partial class ComisionesServicios : baseForm
    {
        /// <summary>
        /// Crea una nueva instancia del formulario de comisiones de servicio
        /// </summary>
        public ComisionesServicios()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Liga los datos a los controles
        /// </summary>
        public override void BindData()
        {
            this.tiposComisionesBindingSource.DataSource = Entities.TiposComisiones.Read();
            this.vista_ComisionistasServiciosBindingSource.DataSource = Entities.Vista_ComisionistasServicios.Get();
            this.vista_ComisionesServiciosBindingSource.DataSource = Entities.Vista_ComisionesServicios.Get(null, null, null, null, null);
            base.BindData();
        }

        /// <summary>
        /// Consulta la información en la base de datos
        /// </summary>
        private void DoQuery()
        {
            this.vista_ComisionesServiciosBindingSource.DataSource = 
                Entities.Vista_ComisionesServicios.Get(
                    DB.GetNullableInt32(this.comisionServicio_IDTextBox.Text), 
                        DB.GetNullableInt32(this.comisionista_IDComboBox.SelectedValue), 
                            DB.GetNullableInt32(this.tipoComision_IDComboBox.SelectedValue), 
                                (this.nombreTextBox.Text == "") ? null : this.nombreTextBox.Text, 
                                    DB.GetNullableDecimal(this.montoTextBox.Text));
        }

        /// <summary>
        /// Solicita buscar la información en la base de datos
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BuscarButton_Click(object sender, EventArgs e)
        {
            AppHelper.DoMethod(new AppHelper.HelperDelegate(DoQuery), this);
        }

        /// <summary>
        /// Despliega el formulario de actualización de información de comisiones de servicios
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void vista_ComisionesServiciosDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (this.vista_ComisionesServiciosDataGridView.Columns[e.ColumnIndex].Name == "EditColumn")
                {
                    forms.ActualizacionComisionServicio acs = new forms.ActualizacionComisionServicio();
                    acs.ComisionServicio_ID = Convert.ToInt32(this.vista_ComisionesServiciosDataGridView.Rows[e.RowIndex].Cells["ComisionServicio_IDColumn"].Value);
                    Padre.SwitchForma("ActualizacionComisionServicio", acs);
                }                
            }
            catch (Exception ex)
            {
                AppHelper.Error(ex.Message);
            }
        }

    } // end class

} // end namespace
