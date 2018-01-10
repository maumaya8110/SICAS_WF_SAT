﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SICASv20.forms
{
    /// <summary>
    /// Formulario que muestra el reporte de recaudación por estación
    /// </summary>
    public partial class ReporteRecaudacionPorEstacion : baseForm
    {
        /// <summary>
        /// Crea una nueva instancia de la clase <see cref="ReporteRecaudacionPorEstacion"/>
        /// </summary>
        public ReporteRecaudacionPorEstacion()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Proceso llevado a cabo para cargar datos y preparar la forma
        /// </summary>
        public override void BindData()
        {
            selectEstacionesBindingSource.DataSource = Sesion.EstacionesTodas;

            base.BindData();
        }

        /// <summary>
        /// Realiza la consulta a la base de datos
        /// </summary>
        private void DoQuery()
        {
            int? estacion_id;
            if (EstacionesComboBox.SelectedItem != null)
            {
                estacion_id = DB.GetNullableInt32(EstacionesComboBox.SelectedValue);

                this.SaldosCuentaCajasPorFechasBindingSource.DataSource = 
                    Entities.SaldosCuentaCajasPorFechas.GetDataTableByEstacion(
                    estacion_id,
                    this.FechaInicialDateTimePicker.Value.Date, 
                    AppHelper.FechaFinal(this.FechaFinalDateTimePicker.Value),
                    Sesion.Usuario_ID
                    );

                this.IngresosEgresosCajasReportViewer.RefreshReport();
            }            
        }

        /// <summary>
        /// Maneja el evento "Click" del control "ConsultarButton"
        /// </summary>
        /// <param name="sender">El control "ConsultarButton"</param>
        /// <param name="e">Los argumentos del evento</param>
        private void ConsultarButton_Click(object sender, EventArgs e)
        {
            AppHelper.DoMethod(new AppHelper.HelperDelegate(DoQuery), this);
        }

    } // end class ReporteRecaudacionPorEstacion

} // end namespace SICASv20.forms
