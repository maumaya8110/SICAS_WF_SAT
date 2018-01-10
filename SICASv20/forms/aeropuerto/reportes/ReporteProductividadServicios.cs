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
    /// Despliega el reporte de productividad y servicios
    /// de los conductores de Aeropuerto
    /// </summary>
    public partial class ReporteProductividadServicios : baseForm
    {
        /// <summary>
        /// Crea una instancia de la forma Reporte de Productividad y Servicios
        /// </summary>
        public ReporteProductividadServicios()
        {
            InitializeComponent();
            AppHelper.AddTextBoxOnlyNumbersValidation(ref NumeroEconomicoTextBox);
        }

        /// <summary>
        /// La lógica de negocios del reporte de productividad y servicios
        /// </summary>
        class ReporteProductividadServicios_Model
        {
            /// <summary>
            /// Obtiene la lista de productividad de los servicios
            /// </summary>
            public List<Entities.Vista_ProductividadServicios> ProductividadServicios
            {
                get
                {
                    //  Verificamos que esten configurados empresa y estación
                    if (this.Empresa_ID == null || this.Estacion_ID == null)
                    {
                        throw new Exception("Es necesario tener configurada una empresa y estación para consultar este reporte");
                    }

                    //  Regresamos el resultado de la consulta
                    return Entities.Vista_ProductividadServicios.Get(
                        this.NumeroEconomico,
                        this.Nombre,
                        this.FechaInicial,
                        this.FechaFinal,
                        this.Empresa_ID,
                        this.Estacion_ID
                    );
                }
            } // end List ProductividadServicios

            /// <summary>
            /// El número económico de la unidad
            /// a consultar servicios
            /// </summary>
            public int? NumeroEconomico { get; set; }

            /// <summary>
            /// El nombre del conductor a quien consultaremos
            /// los servicios
            /// </summary>
            public string Nombre { get; set; }

            /// <summary>
            /// La fecha inicial para consultar los servicios
            /// </summary>
            public DateTime? FechaInicial { get; set; }

            /// <summary>
            /// La fecha final para consultar los servicios
            /// </summary>
            public DateTime? FechaFinal { get; set; }

            /// <summary>
            /// La empresa, parámetro de consulta
            /// </summary>
            public int? Empresa_ID { get; set; }

            /// <summary>
            /// La estación, parámetro de consulta
            /// </summary>
            public int? Estacion_ID { get; set; }            
        }

        /// <summary>
        /// La instancia del modelo de lógica de negocios
        /// </summary>
        ReporteProductividadServicios_Model Model;

        /// <summary>
        /// Liga los datos a los controles
        /// </summary>
        public override void BindData()
        {
            //  Intanciamos el modelo
            this.Model = new ReporteProductividadServicios_Model();

            //  Configuramos los parámetros
            this.Model.NumeroEconomico = 
                (string.IsNullOrEmpty(NumeroEconomicoTextBox.Text)) ? null : DB.GetNullableInt32(NumeroEconomicoTextBox.Text);
            this.Model.Nombre = NombreTextBox.Text;
            this.Model.FechaInicial = AppHelper.FechaInicial(FechaInicialDateTimePicker.Value);
            this.Model.FechaFinal = AppHelper.FechaFinal(FechaFinalDateTimePicker.Value);
            this.Model.Empresa_ID = Sesion.Empresa_ID;
            this.Model.Estacion_ID = Sesion.Estacion_ID;

            base.BindData();
        }

        /// <summary>
        /// Al cambiar el texto actualiza el número económico en el modelo
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NumeroEconomicoTextBox_TextChanged(object sender, EventArgs e)
        {
            AppHelper.Try(
                delegate
                {
                    this.Model.NumeroEconomico = 
                        (string.IsNullOrEmpty(NumeroEconomicoTextBox.Text)) ? null : DB.GetNullableInt32(NumeroEconomicoTextBox.Text);
                }
            );
        }

        /// <summary>
        /// Al cambiar el texto actualiza el nombre en el modelo
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NombreTextBox_TextChanged(object sender, EventArgs e)
        {
            AppHelper.Try(
                delegate
                {
                    this.Model.Nombre = NombreTextBox.Text;
                }
            );
        }

        /// <summary>
        /// Al cambiar el valor de la fecha inicial, actualiza la variable en el modelo
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FechaInicialDateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            AppHelper.Try(
                delegate
                {
                    this.Model.FechaInicial = AppHelper.FechaInicial(FechaInicialDateTimePicker.Value);
                }
            );
        }

        /// <summary>
        /// Al cambiar el valor de la fecha final, actualiza la variable en el modelo
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FechaFinalDateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            AppHelper.Try(
                delegate
                {
                    this.Model.FechaFinal = AppHelper.FechaFinal(FechaFinalDateTimePicker.Value);
                }
            );
        }

        /// <summary>
        /// Consulta la base de datos, obtiene el listado de productividad de los servicio
        /// y lo despliega en la forma
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ConsultarButton_Click(object sender, EventArgs e)
        {
            AppHelper.DoMethod(
                delegate
                {
                    this.vista_ProductividadServiciosBindingSource.DataSource = this.Model.ProductividadServicios;
                },
                this
            );
        }

        /// <summary>
        /// Exporta el resultado de la consulta a formato MS Excel
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ExportarButton_Click(object sender, EventArgs e)
        {
            AppHelper.ExportDataGridViewExcel(this.vista_ProductividadServiciosDataGridView, this);
        }
    } // end class
} // end namespace
