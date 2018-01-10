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
    /// Formulario para mostrar el reporte de planillas
    /// vendidas en la sesión de caja
    /// </summary>
    public partial class ReportePlanillasVendidas : baseForm
    {
        /// <summary>
        /// Crea una instancia del reporte de planillas vendidas
        /// en la sesión de caja
        /// </summary>
        public ReportePlanillasVendidas()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Liga los datos a los controles
        /// </summary>
        public override void BindData()
        {
            this.Vista_ReportePlanillasVendidasBindingSource.DataSource = 
                Entities.Vista_ReportePlanillasVendidas.GetDataTable(Sesion.Sesion_ID);
            this.reportViewer1.RefreshReport();
            base.BindData();

        } // end BindData

    } // end class ReportePLanillasVendidas

} // end namespace SICASv20.forms
