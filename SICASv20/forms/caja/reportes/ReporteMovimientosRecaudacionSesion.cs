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
    /// Muestra el reporte detallado de movimientos de recaudación
    /// de la sesión
    /// </summary>
    public partial class ReporteMovimientosRecaudacionSesion : baseForm
    {
        /// <summary>
        /// Crea una nueva instancia del reporte de movimientos de recaudación
        /// de la sesión actual
        /// </summary>
        public ReporteMovimientosRecaudacionSesion()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Liga los datos a los controles
        /// </summary>
        public override void BindData()
        {
            //  Obtiene los datos de movimientos de recaudación
            //  de la sesión actual y los liga a los controles
            this.vista_MovimientosRecaudacionSesionBindingSource.DataSource =
                Entities.Vista_MovimientosRecaudacionSesion.GetDataTable(Sesion.Sesion_ID);

            base.BindData();
        }

        /// <summary>
        /// Exporta los datos de movimientos de recaudación
        /// a un archivo de MS Excel
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
                    AppHelper.ExportDataGridViewExcel(this.vista_MovimientosRecaudacionSesionDataGridView, this);
                },
                this
            );

        } // end ExportarButton_Click

    } // end class

} // end namespace