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
    /// Formulario que contiene el reporte de recaudación
    /// </summary>
    public partial class ReporteRecaudacion : baseForm
    {
        /// <summary>
        /// Crea una nueva instancia de la clase <see cref="ReporteRecaudacion"/>
        /// </summary>
        public ReporteRecaudacion()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Proceso llevado a cabo para cargar datos y preparar la forma
        /// </summary>
        public override void BindData()
        {
            selectEstacionesBindingSource.DataSource = Sesion.EstacionesTodas;
            selectEmpresasBindingSource.DataSource = Sesion.EmpresasTodas;

            base.BindData();
        }


        /// <summary>
        /// Realiza la consulta a la base de datos
        /// </summary>
        private void DoQuery()
        {
            int? estacion_id, empresa_id;
            if (EstacionesComboBox.SelectedItem != null)
            {
                estacion_id = DB.GetNullableInt32(EstacionesComboBox.SelectedValue);
                empresa_id = DB.GetNullableInt32(EmpresasComboBox.SelectedValue);

                this.Vista_CuentaCajasBindingSource.DataSource = 
                    Entities.Vista_CuentaCajas.GetDataTable(
                    empresa_id,
                    estacion_id,
                    Sesion.Usuario_ID,
                    this.FechaInicialDateTimePicker.Value.Date, 
                    AppHelper.FechaFinal(this.FechaFinalDateTimePicker.Value)
                    );

                this.IngresosEgresosCajasReportViewer.RefreshReport();
            }            
        }

        /// <summary>
        /// MAneja el evento "Click" del control "ConsultarButton"
        /// </summary>
        /// <param name="sender">El control "ConsultarButton"</param>
        /// <param name="e">Los argumentos del evento</param>
        private void ConsultarButton_Click(object sender, EventArgs e)
        {
            AppHelper.DoMethod(new AppHelper.HelperDelegate(DoQuery), this);
        }

    } // end class ReporteRecaudacion

} // end namespace SICASv20.forms
