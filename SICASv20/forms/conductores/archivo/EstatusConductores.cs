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
    /// Formulario que muestra el listado de estatus de conductores
    /// </summary>
    public partial class EstatusConductores : baseForm
    {
        /// <summary>
        /// Crea una nueva instancia del formulario de estatus de conductores
        /// </summary>
        public EstatusConductores()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Al hacer clic en "Guardar", actualiza la información en la base de datos
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void estatusConductoresBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.estatusConductoresBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.sICASCentralDataSet);
        }

        /// <summary>
        /// Al cargar el formulario, llena la información
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EstatusConductores_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'sICASCentralDataSet.EstatusConductores' table. You can move, or remove it, as needed.
            this.estatusConductoresTableAdapter.Fill(this.sICASCentralDataSet.EstatusConductores);

        }

    } // end class

} // end namespace
