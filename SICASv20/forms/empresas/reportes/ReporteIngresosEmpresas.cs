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
    /// Formulario que muestra el reporte de ingresos de las empresas
    /// </summary>
    public partial class ReporteIngresosEmpresas : baseForm
    {
        /// <summary>
        /// Crea una nueva instancia de la clase <see cref="ReporteIngresosEmpresas"/>
        /// </summary>
        public ReporteIngresosEmpresas()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Modelo de lógica de negocios. Contiene la funcionalidad del
        /// reporte de ingresos de empresas.
        /// </summary>
        class ReporteIngresosEmpresas_Model
        {
            /// <summary>
            /// Listado de recuadaciones
            /// </summary>
            public List<Entities.Vista_CuentaEmpresasConsolidado> Recaudaciones
            {
                get
                {
                    return Entities.Vista_CuentaEmpresasConsolidado.Get(this.Empresa_ID, this.FechaInicial, this.FechaFinal);
                }
            }

            /// <summary>
            /// Listado de empresas
            /// </summary>
            public List<Entities.SelectEmpresas> Empresas
            {
                get
                {
                    return Sesion.Empresas;
                }
            }

            /// <summary>
            /// La fecha inicial del reporte
            /// </summary>
            public DateTime FechaInicial { get; set; }

            /// <summary>
            /// La fecha final del reporte
            /// </summary>
            public DateTime FechaFinal { get; set; }

            /// <summary>
            /// Empresa seleccionada para obtener el reporte
            /// </summary>
            public Int32? Empresa_ID { get; set; }
        }

        /// <summary>
        /// El modelo de lógica de negocios <see cref="ReporteIngresosEmpresas_Model"/>
        /// </summary>
        private ReporteIngresosEmpresas_Model Model;


        /// <summary>
        /// Proceso llevado a cabo para cargar datos y preparar la forma
        /// </summary>
        public override void BindData()
        {
            this.Model = new ReporteIngresosEmpresas_Model();
            this.selectEmpresasBindingSource.DataSource = Model.Empresas;
            this.Model.FechaInicial = AppHelper.FechaInicial(this.FechaInicialDateTimePicker.Value);
            this.Model.FechaFinal = AppHelper.FechaFinal(this.FechaFinalDateTimePicker.Value);
            this.Model.Empresa_ID = ((Entities.SelectEmpresas)EmpresasComboBox.SelectedItem).Empresa_ID;

            base.BindData();
        }

        /// <summary>
        /// MAneja el evento "ValueChanged" del control "FechaInicialDateTimePicker"
        /// </summary>
        /// <param name="sender">El control "FechaInicialDateTimePicker"</param>
        /// <param name="e">Los argumentos del evento</param>
        private void FechaInicialDateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            AppHelper.Try(
                delegate
                {
                    this.Model.FechaInicial = AppHelper.FechaInicial(this.FechaInicialDateTimePicker.Value);
                }
            );
        }

        /// <summary>
        /// MAneja el evento "ValueChanged" del control "FechaFinalDateTimePicker"
        /// </summary>
        /// <param name="sender">El control "FechaFinalDateTimePicker"</param>
        /// <param name="e">Los argumentos del evento</param>
        private void FechaFinalDateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            AppHelper.Try(
                delegate
                {
                    this.Model.FechaFinal = AppHelper.FechaFinal(this.FechaFinalDateTimePicker.Value);
                }
            );
        }

        /// <summary>
        /// MAneja el evento "Click" del control "ConsultarButton"
        /// </summary>
        /// <param name="sender">El control "ConsultarButton"</param>
        /// <param name="e">Los argumentos del evento</param>
        private void ConsultarButton_Click(object sender, EventArgs e)
        {
            AppHelper.Try(
                delegate
                {
                    this.Vista_CuentaEmpresasConsolidadoBindingSource.DataSource = Model.Recaudaciones;
                    this.IngresosEmpresasConsolidadoReportViewer.RefreshReport();
                }
            );
        }

        /// <summary>
        /// MAneja el evento "SelectionChangeCommitted" del control "EmpresasComboBox"
        /// </summary>
        /// <param name="sender">El control "EmpresasComboBox"</param>
        /// <param name="e">Los argumentos del evento</param>
        private void EmpresasComboBox_SelectionChangeCommitted(object sender, EventArgs e)
        {
            AppHelper.Try(
                delegate
                {
                    this.Model.Empresa_ID = ((Entities.SelectEmpresas)EmpresasComboBox.SelectedItem).Empresa_ID;
                }
            );
        }

    } // end class
} // end namespace
