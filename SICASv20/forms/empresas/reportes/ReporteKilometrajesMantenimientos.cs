/*%YAML 1.2
---
Meta:
  Name   :  "ReporteKilometrajesMantenimientos"
  Created:  2013/03/21
  Author :  Luis Espino 
---
  
...*/
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
    /// Formulario que contiene el reporte comparativo
    /// de kilometrajes, mantenimientos y recaudaciones
    /// </summary>
    public partial class ReporteKilometrajesMantenimientos : baseForm
    {

        /// <summary>
        /// Contiene el modelo de lógica de negocios para el 
        /// reporte comparativo de kilometrajes, mantenimientos
        /// y recaudaciones
        /// </summary>
        private class ReporteKilometrajesMantenimientos_Model
        {
            /// <summary>
            /// El reporte a mostrar
            /// </summary>
            public List<Entities.Vista_ReporteKilometrajesMantenimientos> Reporte;

            /// <summary>
            /// La fecha inicial del reporte
            /// </summary>
            public DateTime FechaInicial { get; set; }

            /// <summary>
            /// La fecha final del reporte
            /// </summary>
            public DateTime FechaFinal { get; set; }

            /// <summary>
            /// Consulta el reporte en la base de datos
            /// </summary>
            public void Consultar()
            {
                this.Reporte =
                    Entities.Vista_ReporteKilometrajesMantenimientos.Get(
                        FechaInicial,
                        FechaFinal
                    );
            }
        }

        #region Constructors

        /// <summary>
        /// Crea una nueva instancia de la clase <see cref="ReporteKilometrajesMantenimientos"/>
        /// </summary>
        public ReporteKilometrajesMantenimientos()
        {
            InitializeComponent();
        }

        #endregion


        #region Properties

        /// <summary>
        /// El modelo de la lógica de negocios
        /// </summary>
        private ReporteKilometrajesMantenimientos_Model Model { get; set; }

        #endregion


        #region Methods

        /// <summary>
        /// Proceso llevado a cabo para cargar datos y preparar la forma
        /// </summary>
        public override void BindData()
        {
            this.Model = new ReporteKilometrajesMantenimientos_Model();

            this.Model.FechaInicial =
                AppHelper.FechaInicial(this.FechaInicialDatePicker.Value);
            
            this.Model.FechaFinal =
                AppHelper.FechaFinal(this.FechaFinalDatePicker.Value);

            base.BindData();
        }

        #endregion


        #region Events

        /// <summary>
        /// Maneja el evento "ValueChanged" del control "FechaInicialDatePicker"
        /// </summary>
        /// <param name="sender">El control "FechaInicialDatePicker"</param>
        /// <param name="e">Los argumentos del evento</param>
        private void FechaInicialDatePicker_ValueChanged(object sender, EventArgs e)
        {
            AppHelper.Try(
                delegate
                {
                    //  Actualizamos la fecha inicial en el modelo
                    this.Model.FechaInicial =
                        AppHelper.FechaInicial(this.FechaInicialDatePicker.Value);
                }
            );
        }

        /// <summary>
        /// Maneja el evento "ValueChanged" del control "FechaFinalDatePicker"
        /// </summary>
        /// <param name="sender">El control "FechaFinalDatePicker"</param>
        /// <param name="e">Los argumentos del evento</param>
        private void FechaFinalDatePicker_ValueChanged(object sender, EventArgs e)
        {
            AppHelper.Try(
                delegate
                {
                    //  Actualizamos la fecha final en el modelo
                    this.Model.FechaFinal =
                        AppHelper.FechaFinal(this.FechaFinalDatePicker.Value);
                }
            );
        }

        /// <summary>
        /// Maneja el evento "Click" del control "ConsultarButton"
        /// </summary>
        /// <param name="sender">El control "ConsultarButton"</param>
        /// <param name="e">Los argumentos del evento</param>
        private void ConsultarButton_Click(object sender, EventArgs e)
        {
            AppHelper.DoMethod(
                delegate
                {
                    //  Consultamos la información
                    this.Model.Consultar();

                    //  La desplegamos en pantalla
                    this.vista_ReporteKilometrajesMantenimientosBindingSource.DataSource = 
                        this.Model.Reporte;
                },
                this
            );
        }

        /// <summary>
        /// Maneja el evento "Click" del control "ExportarButton"
        /// </summary>
        /// <param name="sender">El control "ConsultarButton"</param>
        /// <param name="e">Los argumentos del evento</param>
        private void ExportarButton_Click(object sender, EventArgs e)
        {
            //  Exportamos la información actualmente en pantalla
            AppHelper.ExportDataGridViewExcel(
                this.vista_ReporteKilometrajesMantenimientosDataGridView,
                this
            );
        }

        #endregion				
		

    } // end class ReporteKilometrajesMantenimientos

} // end namespace SICASv20.forms