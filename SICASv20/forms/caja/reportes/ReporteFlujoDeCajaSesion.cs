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
    /// Muestra el reporte de flujo de caja de una sesión
    /// de caja en particular
    /// </summary>
    public partial class ReporteFlujoDeCajaSesion : baseForm
    {
        /// <summary>
        /// Crea una instancia del reporte de flujo de caja
        /// </summary>
        public ReporteFlujoDeCajaSesion()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Liga los datos a los controles
        /// </summary>
        public override void BindData()
        {

            //  Obtenemos los datos de flujo de caja de la sesión
            //  y los ligamos a los controles
            reporteFlujoCajaBindingSource.DataSource = 
                Entities.Vista_Reporte_FlujoCaja.GetDataTable(Sesion.Sesion_ID);

            //  Refresamos la visualización del reporte
            this.reportViewer1.RefreshReport();

            base.BindData();            

        } // end BindData

    } // end class

} // end namespace
