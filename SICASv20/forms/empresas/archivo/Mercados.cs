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
    /// Administra las altas, bajas y cambios de los mercados en el sistema
    /// </summary>
    public partial class Mercados : baseForm
    {
        /// <summary>
        /// Crea una nueva instancia de la clase <see cref="Mercados"/>.
        /// </summary>
        public Mercados()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Maneja el evento "Click", del botón "Guardar" del contol "Navegado"
        /// </summary>
        /// <param name="sender">La fuente del evento, el botón "Guardar"</param>
        /// <param name="e">Los argumentos del evento</param>
        private void mercadosBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            AppHelper.DoMethod(
                delegate
                {
                    this.Validate();

                    //  Guardamos los datos
                    this.mercadosBindingSource.EndEdit();
                    this.tableAdapterManager.UpdateAll(this.sICASCentralDataSet);

                    //  Enviamos mensaje de éxito
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
        private void Mercados_Load(object sender, EventArgs e)
        {
            //  Cargamos los datos de mercados
            this.mercadosTableAdapter.Fill(this.sICASCentralDataSet.Mercados);

        }

    } // end class

} // end namespace
