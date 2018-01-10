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
    /// Formulario que muestra el reporte de recaudación
    /// de sesión de caja
    /// </summary>
    public partial class ReporteRecaudacionCajaSesion : baseForm
    {
        /// <summary>
        /// Crea una instancia del formulario de reporte
        /// de recaudación de sesión de caja
        /// </summary>
        public ReporteRecaudacionCajaSesion()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Liga los datos a los controles
        /// </summary>
        public override void BindData()
        {
            reporte_CuentaCajaEmpresasTableAdapter.Fill(sICASCentralQuerysDataSet.Reporte_CuentaCajaEmpresas, 
                Sesion.Sesion_ID);
            this.ReporteRecaudacionReportViewer.RefreshReport();
            base.BindData();
        } // end BindData

    } // end class ReporteRecaudacionCajaSesion

} // end namespace SICASv20.forms
