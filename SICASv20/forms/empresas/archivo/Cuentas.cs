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
    /// Formulario para la administración
    /// de las cuentas del sistema
    /// </summary>
    public partial class Cuentas : baseForm
    {

        /// <summary>
        /// Crea una nueva instancia de la clase <see cref="Cuentas"/>.
        /// </summary>
        public Cuentas()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Manje el evento "Click" del navegador
        /// </summary>
        /// <param name="sender">El botón "Guardar"</param>
        /// <param name="e">El contenedor de argumentos</param>
        private void cuentasBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            AppHelper.DoMethod(
                delegate
                {
                    this.Validate();
                    this.cuentasBindingSource.EndEdit();
                    this.tableAdapterManager.UpdateAll(this.sICASCentralDataSet);
                    AppHelper.Info("Registros actualizados");
                },
                this
            );
        }

        /// <summary>
        /// Maneja el evento "Load" del formulario de la clase <see cref="Cuentas"/>
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void Cuentas_Load(object sender, EventArgs e)
        {
            //  Cargamos los datos de "Cuentas"
            this.cuentasTableAdapter.Fill(this.sICASCentralDataSet.Cuentas);

        }

    } // end class

} // end namespace
