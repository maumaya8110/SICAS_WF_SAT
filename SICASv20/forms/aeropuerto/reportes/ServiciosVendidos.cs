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
    /// Formulario para consultar los servicios vendidos
    /// </summary>
    public partial class ServiciosVendidos : baseForm
    {
        /// <summary>
        /// Crea una nueva instancia del formulario de consulta
        /// de servicios vendidos
        /// </summary>
        public ServiciosVendidos()
        {
            InitializeComponent();
        }        

        #region Properties

        /// <summary>
        /// El modelo de la lógica de negocios
        /// </summary>
        private ServiciosVendidos_Model Model;

        #endregion

        #region Events

        /// <summary>
        /// Liga los datos a los controles
        /// </summary>
        public override void BindData()
        {
            //  Instanciamos el modelo
            this.Model = new ServiciosVendidos_Model();

            //  Consultamos los catálagos iniciales necesarios
            this.Model.ConsultarCatalogos();

            //  Configuramos las fuentes de datos
            this.selectClasesServiciosBindingSource.DataSource = this.Model.ClasesServicios;
            this.selectTiposServiciosBindingSource.DataSource = this.Model.TiposServicios;
            this.selectMonedasBindingSource.DataSource = this.Model.Monedas;

            //  Configuramos los parámemtros
            this.Model.FechaInicial =
                        AppHelper.FechaInicial(this.FechaInicialDateTimePicker.Value);
            this.Model.FechaFinal =
                        AppHelper.FechaFinal(this.FechaFinalDateTimePicker.Value);

            base.BindData();
        }

        /// <summary>
        /// Al cambiar el texto de número económico,
        /// actualiza el modelo
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UnidadTextBox_TextChanged(object sender, EventArgs e)
        {
            AppHelper.Try(
                delegate
                {
                    //  Verificamos que el dato exista
                    if (!string.IsNullOrEmpty(this.UnidadTextBox.Text))
                    {
                        //  Actualizamos el modelo
                        this.Model.NumeroEconomico =
                            Convert.ToInt32(this.UnidadTextBox.Text);
                    }
                    else
                    {
                        //  Si el dato no existe
                        //  la variable es nula
                        this.Model.NumeroEconomico = null;

                    } // end if

                } // end delegate

            );
        } // end UnidadTextBox_TextChanged

        /// <summary>
        /// Al cambiar el texto actualiza el nombre del conductor
        /// en el modelo
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ConductorTextBox_TextChanged(object sender, EventArgs e)
        {
            AppHelper.Try(
                delegate
                {
                    this.Model.NombreConductor = this.ConductorTextBox.Text;
                }
            );
        }

        /// <summary>
        /// Al modificar la zona,
        /// actualiza el modelo
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ZonaTextBox_TextChanged(object sender, EventArgs e)
        {
            AppHelper.Try(
                delegate
                {
                    this.Model.NombreZona = this.ZonaTextBox.Text;
                }
            );
        }

        /// <summary>
        /// Al actualizar la fecha inicial,
        /// actualiza la variable en el modelo
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FechaInicialDateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            AppHelper.Try(
                delegate
                {
                    this.Model.FechaInicial = 
                        AppHelper.FechaInicial(this.FechaInicialDateTimePicker.Value);
                }
            );
        }

        /// <summary>
        /// Al actualizar la fecha final
        /// actualiza la variable en el modelo
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FechaFinalDateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            AppHelper.Try(
                delegate
                {
                    this.Model.FechaFinal =
                        AppHelper.FechaFinal(this.FechaFinalDateTimePicker.Value);
                }
            );
        }

        /// <summary>
        /// Al actualizar el tipo de servicio,
        /// actualiza la variable en el modelo
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TipoServicioComboBox_SelectionChangeCommitted(object sender, EventArgs e)
        {
            AppHelper.Try(
                delegate
                {
                    this.Model.TipoServicio_ID =
                        DB.GetNullableInt32(this.TipoServicioComboBox.SelectedValue);
                }
            );
        }

        /// <summary>
        /// Al actualiza la clase de servicio
        /// actualiza la variable en el modelo
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ClaseServicioComboBox_SelectionChangeCommitted(object sender, EventArgs e)
        {
            AppHelper.Try(
                delegate
                {
                    this.Model.ClaseServicio_ID =
                        DB.GetNullableInt32(this.ClaseServicioComboBox.SelectedValue);
                }
            );
        }

        /// <summary>
        /// Al actualizar la forma de pago de los servicios,
        /// actualiza la variable en el modelo
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormaPagoComboBox_SelectionChangeCommitted(object sender, EventArgs e)
        {
            AppHelper.Try(
                delegate
                {
                    this.Model.Moneda_ID =
                        DB.GetNullableInt32(this.FormaPagoComboBox.SelectedValue);
                }
            );
        }

        /// <summary>
        /// Consulta la información en la base de datos y la muestra al usuario
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BuscarButton_Click(object sender, EventArgs e)
        {
            AppHelper.DoMethod(
                delegate
                {
                    this.Model.Consultar();
                    this.vista_ServiciosBindingSource.DataSource = this.Model.Servicios;
                },
                this
            );
        }

        /// <summary>
        /// Exporta la información a formato MS Excel
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ExportarButton_Click(object sender, EventArgs e)
        {
            AppHelper.ExportDataGridViewExcel(this.vista_ServiciosDataGridView, this);
        }

        #endregion
    } // End Class ServiciosVendidos
} // End Namespace
