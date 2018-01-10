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
    /// Administra las altas, bajas y cambios de los Tipos de Empresas en el sistema
    /// </summary>
    public partial class TiposEmpresas : baseForm
    {
        /// <summary>
        /// Crea una nueva instancia de la clase <see cref="TiposEmpresas"/>.
        /// </summary>
        public TiposEmpresas()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Maneja el evento "Click", del botón "Guardar" del contol "Navegado"
        /// </summary>
        /// <param name="sender">La fuente del evento, el botón "Guardar"</param>
        /// <param name="e">Los argumentos del evento</param>
        private void tiposEmpresasBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            AppHelper.DoMethod(
                delegate
                {
                    this.Validate();
                    this.tiposEmpresasBindingSource.EndEdit();
                    this.tableAdapterManager.UpdateAll(this.sICASCentralDataSet);
                    AppHelper.Info("Registros actualizados");
                },
                this
            );
        }

        /// <summary>
        /// Maneja el evento "Load" del formulario "Mercados"
        /// </summary>
        /// <param name="sender">La fuente del evento, el formulario "Mercados"</param>
        /// <param name="e">Los argumentos del evento</param>
        private void TiposEmpresas_Load(object sender, EventArgs e)
        {
            //  Cargamos los datos de mercados
            this.tiposEmpresasTableAdapter.Fill(this.sICASCentralDataSet.TiposEmpresas);

        }

    } // end class

} // end namespace