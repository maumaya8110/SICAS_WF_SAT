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
    /// Formulario que muestra el reporte de recaudación por empresa
    /// </summary>
    public partial class ReporteRecaudacionPorEmpresa : baseForm
    {
        /// <summary>
        /// Crea una nueva instancia de la clase <see cref="ReporteRecaudacionPorEmpresa"/>
        /// </summary>
        public ReporteRecaudacionPorEmpresa()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Modelo de lógica de negocios que contiene las funciones para realizar
        /// el reporte de recaudación por empresa
        /// </summary>
        class ReporteRecaudacionPorEmpresa_Model
        {
            /// <summary>
            /// La empresa sobre la que se efectuará el reporte
            /// </summary>
            public int Empresa_ID { get; set; }

            /// <summary>
            /// La fecha inicial del reporte
            /// </summary>
            public DateTime FechaInicial { get; set; }

            /// <summary>
            /// La fecha final del reporte
            /// </summary>
            public DateTime FechaFinal { get; set; }

            /// <summary>
            /// El listado de recaudaciones
            /// </summary>
            public List<Entities.Vista_ReporteRecaudacionPorEmpresa> Recaudaciones
            {
                get
                {
                    return Entities.Vista_ReporteRecaudacionPorEmpresa.Get(
                        Empresa_ID, 
                        FechaInicial, 
                        FechaFinal
                    );
                }
            }

            /// <summary>
            /// EL listado de empresas disponibles
            /// </summary>
            public List<Entities.SelectEmpresas> Empresas
            {
                get
                {
                    return Sesion.Empresas;
                }
            }

        } // end class ReporteRecaudacionPorEmpresa_Model

        /// <summary>
        /// El objeto del modelo de lógica de negocios
        /// </summary>
        private ReporteRecaudacionPorEmpresa_Model Model;

        /// <summary>
        /// Proceso llevado a cabo para cargar datos y preparar la forma
        /// </summary>
        public override void BindData()
        {
            this.Model = new ReporteRecaudacionPorEmpresa_Model();

            this.selectEmpresasBindingSource.DataSource = Model.Empresas;

            this.Model.FechaInicial = AppHelper.FechaInicial(this.FechaInicialDateTimePicker.Value);
            this.Model.FechaFinal = AppHelper.FechaFinal(this.FechaFinalDateTimePicker.Value);

            Entities.SelectEmpresas empresa_id = (Entities.SelectEmpresas)this.EmpresasComboBox.SelectedItem;            
            this.Model.Empresa_ID = (empresa_id.Empresa_ID == null) ? 0 : empresa_id.Empresa_ID.Value;

            base.BindData();
        }

        /// <summary>
        /// Maneja el evento "Click" del control "ConsultarButton"
        /// </summary>
        /// <param name="sender">El control "ConsultarButton"</param>
        /// <param name="e">Los datos del argumento</param>
        private void ConsultarButton_Click(object sender, EventArgs e)
        {
            AppHelper.DoMethod(
                delegate
                {
                    if (Model.Empresa_ID == 0)
                        AppHelper.ThrowException("Debe seleccionar una empresa");

                    this.vista_ReporteRecaudacionPorEmpresaBindingSource.DataSource = Model.Recaudaciones;
                    this.RecaudacionReportViewer.RefreshReport();
                },
                this);
        }

        /// <summary>
        /// Maneja el evento "ValueChanged" del control "FechaInicialDateTimePicker"
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
        /// Maneja el evento "ValueChanged" del control "FechaFinalDateTimePicker"
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
        /// Maneja el evento "SelectionChangeCommitted" del control "EstacionesComboBox"
        /// </summary>
        /// <param name="sender">El control "EstacionesComboBox"</param>
        /// <param name="e">Los argumentos del evento</param>
        private void EstacionesComboBox_SelectionChangeCommitted(object sender, EventArgs e)
        {
            AppHelper.Try(
                delegate
                {
                    Entities.SelectEmpresas empresa_id = (Entities.SelectEmpresas)this.EmpresasComboBox.SelectedItem;
                    if (empresa_id.Empresa_ID == null)
                        AppHelper.ThrowException("Debe seleccionar una sola empresa");

                    this.Model.Empresa_ID = empresa_id.Empresa_ID.Value;
                }
            );
        }

    } // end class ReporteRecaudacionPorEmpresa
} // end namespace SICASv20.forms
