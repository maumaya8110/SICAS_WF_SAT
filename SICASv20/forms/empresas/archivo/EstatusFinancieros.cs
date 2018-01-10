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
    /// Administra el catálogo de Estatus financieros en el sistema
    /// </summary>
    public partial class EstatusFinancieros : baseForm
    {
        /// <summary>
        /// Crea una nueva instancia de la clase <see cref="EstatusFinancieros"/>.
        /// </summary>
        public EstatusFinancieros()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Maneja el evento click del botón "Guardar" del control "Navegador"
        /// </summary>
        /// <param name="sender">La fuente del evento, el botón "Guardar"</param>
        /// <param name="e">Los eventos del argumento</param>
        private void estatusFinancierosBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            AppHelper.DoMethod(
                delegate
                {
                    this.Validate();

                    //  Guardamos
                    this.estatusFinancierosBindingSource.EndEdit();
                    this.tableAdapterManager.UpdateAll(this.sICASCentralDataSet);

                    //  Enviamos mensaje de éxito
                    AppHelper.Info("Registros actualizados");
                },
                this
            );
        }

        /// <summary>
        /// Maneja el evento "Load" del formulario "Estatus financieros"
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void EstatusFinancieros_Load(object sender, EventArgs e)
        {
            //  Cargamos los datos de estatus financieros
            this.estatusFinancierosTableAdapter.Fill(this.sICASCentralDataSet.EstatusFinancieros);

        }

    } // end class

} // end namespace
