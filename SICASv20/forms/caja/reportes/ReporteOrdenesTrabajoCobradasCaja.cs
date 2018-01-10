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
    /// Formulario de reporte de ordenes de trabajo cobradas en caja
    /// </summary>
    public partial class ReporteOrdenesTrabajoCobradasCaja : baseForm
    {
        /// <summary>
        /// Crea una nueva instancia del reporte de ordenes de trabajo
        /// cobradas en caja
        /// </summary>
        public ReporteOrdenesTrabajoCobradasCaja()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Liga los datos a los controles
        /// </summary>
        public override void BindData()
        {
            this.Vista_ReporteOrdenesTrabajoCobradasCajaBindingSource.DataSource =
                Entities.Vista_ReporteOrdenesTrabajoCobradasCaja.GetDataTable(Sesion.Sesion_ID);
            
            this.reportViewer1.RefreshReport();
            
            base.BindData();

        } // end BindData

    } // end class ReporteOrdenesTrabajoCobradasCaja

} // end SICASv20.forms
