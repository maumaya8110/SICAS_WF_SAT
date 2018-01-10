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
    /// Formulario para administrar los conceptos de cargos y abonos en el sistema
    /// </summary>
    public partial class Conceptos : baseForm
    {
        /// <summary>
        /// Crea una nueva instancia del formulario para la administración de conceptos
        /// </summary>
        public Conceptos()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Guarda los cambios en la base de datos
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void conceptosBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            AppHelper.DoMethod(
                delegate
                {
                    this.Validate();
                    this.conceptosBindingSource.EndEdit();
                    this.tableAdapterManager.UpdateAll(this.sICASCentralDataSet);
                    AppHelper.Info("Registros actualizados");
                },
                this
            );

        }

        /// <summary>
        /// LLena la información de los controles
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Conceptos_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'sICASCentralDataSet.Cuentas' table. You can move, or remove it, as needed.
            this.cuentasTableAdapter.Fill(this.sICASCentralDataSet.Cuentas);
            // TODO: This line of code loads data into the 'sICASCentralDataSet.Conceptos' table. You can move, or remove it, as needed.
            this.conceptosTableAdapter.Fill(this.sICASCentralDataSet.Conceptos);

        }

    } // end class

} // end namespace
