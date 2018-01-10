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
    /// Formulario que muestra los contratos liquidados en el sistema
    /// </summary>
    public partial class ContratosLiquidados : baseForm
    {
        /// <summary>
        /// Crea una nueva instancia del formulario <see cref="ContratosLiquidados"/>
        /// </summary>
        public ContratosLiquidados()
        {
            InitializeComponent();
        }

        /// <summary>
        /// El modelo de lógica de negocios
        /// que contiene las funciones necesarias
        /// para la operación de <see cref="ContratosLiquidados"/>
        /// </summary>
        ContratoLiquidados_Model Model;

        /// <summary>
        /// Modelo de lógica de negocios de <see cref="ContratosLiquidados"/>
        /// </summary>
        class ContratoLiquidados_Model
        {
            /// <summary>
            /// El listado de contratos liquidados
            /// </summary>
            public List<Entities.Vista_ContratosLiquidados> ContratosLiquidados
            {
                get { return _ContratosLiquidados; }
                set { _ContratosLiquidados = value; }
            }
            private List<Entities.Vista_ContratosLiquidados> _ContratosLiquidados;

            /// <summary>
            /// La empresa seleccionada
            /// </summary>
            public int? Empresa_ID
            {
                get { return _Empresa_ID; }
                set { _Empresa_ID = value; }
            }
            private int? _Empresa_ID;

            /// <summary>
            /// La estación seleccionada
            /// </summary>
            public int? Estacion_ID
            {
                get { return _Estacion_ID; }
                set { _Estacion_ID = value; }
            }
            private int? _Estacion_ID;

            /// <summary>
            /// La fecha inicial seleccionada
            /// </summary>
            public DateTime? FechaInicial
            {
                get { return _FechaInicial; }
                set { _FechaInicial = value; }
            }
            private DateTime? _FechaInicial;

            /// <summary>
            /// La fecha final seleccionada
            /// </summary>
            public DateTime? FechaFinal
            {
                get { return _FechaFinal; }
                set { _FechaFinal = value; }
            }
            private DateTime? _FechaFinal;

            /// <summary>
            /// Consulta la información en la base de datos
            /// </summary>
            public void Consultar()
            {
                this.ContratosLiquidados = 
                    Entities.Vista_ContratosLiquidados.Get(
                    this.Empresa_ID, 
                    this.Estacion_ID, 
                    this.FechaInicial, 
                    this.FechaFinal
                    );
            }
        }

        /// <summary>
        /// Liga los datos a los controles
        /// </summary>
        public override void BindData()
        {
            this.Model = new ContratoLiquidados_Model();
            base.BindData();
        }

        /// <summary>
        /// Maneja el evento "Click" del control "ConsultarButton"
        /// </summary>
        /// <param name="sender">El control "ConsultarButton"</param>
        /// <param name="e">Los datos del evento</param>
        private void ConsultarButton_Click(object sender, EventArgs e)
        {
            AppHelper.DoMethod(delegate 
            {
                Model.Empresa_ID = Sesion.Empresa_ID;
                Model.Estacion_ID = Sesion.Estacion_ID;
                Model.FechaInicial = AppHelper.FechaInicial(this.FechaInicialDateTimePicker.Value);
                Model.FechaFinal = AppHelper.FechaFinal(this.FechaFinalDateTimePicker.Value);
                Model.Consultar();
                this.vista_ContratosLiquidadosBindingSource.DataSource = Model.ContratosLiquidados;
            }, this);
        }

        /// <summary>
        /// Maneja el evento "Click" del control "ExportButton"
        /// </summary>
        /// <param name="sender">El control "ExportButton"</param>
        /// <param name="e">Los datos del evento</param>
        private void ExportButton_Click(object sender, EventArgs e)
        {
            AppHelper.ExportDataGridViewExcel(this.vista_ContratosLiquidadosDataGridView, this);
        }

    } // end class ContratosLiquidados

} // SICASv20.forms