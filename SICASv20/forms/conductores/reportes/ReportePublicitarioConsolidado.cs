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
    /// Formulario que muestra el reporte publicitario consilidad
    /// </summary>
    public partial class ReportePublicitarioConsolidado : baseForm
    {
        /// <summary>
        /// Crea una nueva instancia del formulario
        /// de reporte publicitario consolidado
        /// </summary>
        public ReportePublicitarioConsolidado()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Liga los datos a los controles
        /// </summary>
        public override void BindData()
        {
            this.selectEstacionesBindingSource.DataSource =
                Sesion.Estaciones;
            
            base.BindData();
        }

        /// <summary>
        /// Consulta la información en la base de datos
        /// y la muestra en pantalla
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ConsultarButton_Click(object sender, EventArgs e)
        {
            AppHelper.DoMethod(
                delegate
                {
                    //  Consultamos los medioa publicitarios
                    //  y los asignamos la fuente de datos
                    this.reporteRegistroPublicitarioBindingSource.DataSource =
                        Entities.Vista_MediosPublicitarios.GetDataTable(
                        AppHelper.FechaInicial(this.FechaInicialDateTimePicker.Value),
                        AppHelper.FechaFinal(this.FechaFinalDateTimePicker.Value),
                        DB.GetNullableInt32(this.Estacion_IDComboBox.SelectedValue)
                    );

                    //  Refrecamos el reporte
                    this.PublicitarioConsolidadoReportViewer.RefreshReport();
                },
                this
            );
        }
    } // end class

} // end namespace
