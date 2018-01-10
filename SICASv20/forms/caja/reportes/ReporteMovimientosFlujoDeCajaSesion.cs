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
    /// Muestra un reporte detallado de los movimientos de flujo de caja
    /// de la sesión actual de caja
    /// </summary>
    public partial class ReporteMovimientosFlujoDeCajaSesion : baseForm
    {
        /// <summary>
        /// Crea una nueva instancia del formulario de reporte detallado
        /// de movimientos de flujo de caja
        /// </summary>
        public ReporteMovimientosFlujoDeCajaSesion()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Liga los datos a los controles
        /// </summary>
        public override void BindData()
        {
            //  Obtiene los datos de movimientos de flujo de caja de la sesión
            //  y los liga a los controles
            this.vista_MovimientosFlujoCajaSesionBindingSource.DataSource =
                Entities.Vista_MovimientosFlujoCajaSesion.GetDataTable(Sesion.Sesion_ID);

            base.BindData();
        }

        /// <summary>
        /// Exporta los datos a un archivo de MS Excel
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ExportarButton_Click(object sender, EventArgs e)
        {
            AppHelper.DoMethod(
                delegate
                {
                    //  Manda exportar la información
                    //  del control DataGridView
                    //  a un archivo con formato MS Excel
                    AppHelper.ExportDataGridViewExcel(this.vista_MovimientosFlujoCajaSesionDataGridView, this);
                },
                this
            );

        } // end ExportarButton_Click

    } // end class

} // end namespace
