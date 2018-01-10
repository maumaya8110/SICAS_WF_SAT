/*
 * AltaAtencionClientes
 * 
 * Fecha de Creación: 2012-09-12
 * Codificado por Luis Espino
 * 
 * Consolidación de operación de atención a clientes
 */
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SICASv20.forms
{
    public partial class AltaAtencionClientes : baseForm
    {
        /// <summary>
        /// El modelo correspondiente a la lógica de negocios
        /// </summary>
        public class AltaAtencionClientes_Model
        {
            #region Enums

            /// <summary>
            /// Tipos de Atencion a Clientes en el sistema
            /// </summary>
            public enum TiposAtencionClientes
            {
                Incidencias = 1,
                Cortesias = 2,
                ObjetosExtraviados = 3,
                Reembolsos = 4
            }

            #endregion

            #region Properties

            /// <summary>
            /// El listado de Incidencias
            /// </summary>
            //public List<Entities.Vista_AtencionClientes> Incidencias { get; set; }

            /// <summary>
            /// El listado de Cortesias
            /// </summary>
            //public List<Entities.Vista_AtencionClientes> Cortesias { get; set; }

            /// <summary>
            /// El listado de Objetos Extraviados
            /// </summary>
            //public List<Entities.Vista_AtencionClientes> ObjetosExtraviados { get; set; }

            /// <summary>
            /// El listado de Reembolsos
            /// </summary>
            //public List<Entities.Vista_AtencionClientes> Reembolsos { get; set; }

            /// <summary>
            /// El tipo de Atencion Cliente Actual
            /// </summary>
            public TiposAtencionClientes TipoAtencionClientes { get; set; }

            /// <summary>
            /// El folio de la atencion a cliente a buscar
            /// </summary>
            public int? AtencionCliente_ID { get; set; }

            /// <summary>
            /// El numero de confirmación a buscar
            /// </summary>
            public string NumeroConfirmacion { get; set; }

            /// <summary>
            /// La fecha inicial de las atenciones a buscar
            /// </summary>
            public DateTime FechaInicial
            {
                get
                {
                    return _FechaInicial;
                }
                set
                {
                    _FechaInicial = AppHelper.FechaInicial(value);
                }
            }
            private DateTime _FechaInicial;

            /// <summary>
            /// La fecha final de las atenciones a buscar
            /// </summary>
            public DateTime FechaFinal
            {
                get
                {
                    return _FechaFinal;
                }
                set
                {
                    _FechaFinal = AppHelper.FechaFinal(value);
                }
            }
            private DateTime _FechaFinal;

            public int? NumeroEconomico { get; set; }

            public int? Unidad_ID { get; set; }

            Entities.DatosConductorUnidad DatosUnidad { get; set; }

            #endregion

            #region Metodos Publicos

            public int NumeroUnidades()
            {
                //  Consultamos la unidad, en caso de existir
                if (this.NumeroEconomico != null)
                {
                    return Entities.DatosConductorUnidad.GetNumeroUnidades(this.NumeroEconomico.Value);
                } // end if
                else
                {
                    return 0;
                } // end else
            } // end int

            /// <summary>
            /// Consulta la unidad, a partir del número economico
            /// </summary>
            public void ConsultarUnidad()
            {
                this.DatosUnidad = Entities.DatosConductorUnidad.Get(this.NumeroEconomico.Value);
                this.Unidad_ID = this.DatosUnidad.Unidad_ID;
            }

            /// <summary>
            /// Consulta la información de atención a clientes
            /// </summary>
            public void Consultar()
            {                
                //  Realizamos la consulta en una variable local
                List<Entities.Vista_AtencionClientes> vista =
                    Entities.Vista_AtencionClientes.Get(
                        this.AtencionCliente_ID,
                        (int)this.TipoAtencionClientes,
                        this.Unidad_ID,
                        this.NumeroConfirmacion,
                        this.FechaInicial,
                        this.FechaFinal
                    );

                //  Dependiendo del tipo actual de atención a clientes
                //  llenamos la lista adecuada, con la variable previamente cargada
                switch (this.TipoAtencionClientes)
                {

                    case TiposAtencionClientes.Incidencias:

                        this.Incidencias = vista;

                        break;

                    case TiposAtencionClientes.Cortesias:

                        this.Cortesias = vista;

                        break;

                    case TiposAtencionClientes.ObjetosExtraviados:

                        this.ObjetosExtraviados = vista;

                        break;

                    case TiposAtencionClientes.Reembolsos:

                        this.Reembolsos = vista;

                        break;

                } // end switch

            } // end void Consultar

            #endregion

        } // end class AltaAtencionClientes_Model

        public AltaAtencionClientes()
        {
            InitializeComponent();
        }

        #region Properties

        private AltaAtencionClientes_Model Model;

        #endregion

        #region Events

        public override void BindData()
        {
            this.Model = new AltaAtencionClientes_Model();
            this.Model.FechaInicial = this.FechaInicialDateTimePicker.Value;
            this.Model.FechaFinal = this.FechaFinalDateTimePicker.Value;
            this.Model.TipoAtencionClientes = AltaAtencionClientes_Model.TiposAtencionClientes.Incidencias;
            this.IncidenciasBindingSource.DataSource = null;
            this.CortesiasbindingSource.DataSource = null;
            this.ObjetosExtraviadosBindingSource.DataSource = null;
            this.ReembolsosBindingSource.DataSource = null;
            this.Model.Consultar();
            base.BindData();
        }
        /// <summary>
        /// Al cambiar el valor actualiza el folio en el modelo
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AtencionCliente_IDTextBox_TextChanged(object sender, EventArgs e)
        {
            AppHelper.Try(
                delegate
                {
                    this.Model.AtencionCliente_ID = DB.GetNullableInt32(this.AtencionCliente_IDTextBox.Text);
                } // end delegate
            );
        } // end void

        /// <summary>
        /// Al cambiar el valor actualiza la fecha inicial en el modelo
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FechaInicialDateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            AppHelper.Try(
                delegate
                {
                    this.Model.FechaInicial = this.FechaInicialDateTimePicker.Value;
                } // end delegate
            );
        } // end void

        /// <summary>
        /// Al cambiar el valor actualiza el numero de confirmacion en el modelo
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NumeroConfirmacionTextBox_TextChanged(object sender, EventArgs e)
        {
            AppHelper.Try(
                delegate
                {
                    this.Model.NumeroConfirmacion = this.NumeroConfirmacionTextBox.Text;
                } // end delegate
            );
        } // end void

        /// <summary>
        /// Al cambiar el valor actualiza la fecha final en el modelo
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FechaFinalDateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            AppHelper.Try(
                delegate
                {
                    this.Model.FechaFinal = this.FechaFinalDateTimePicker.Value;
                } // end delegate
            );
        } // end void

        /// <summary>
        /// Al cambiar el texto actualiza el numero economico en el modelo
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NumeroEconomicoTextBox_TextChanged(object sender, EventArgs e)
        {
            AppHelper.Try(
                delegate
                {
                    this.Model.NumeroEconomico = DB.GetNullableInt32(this.NumeroEconomicoTextBox.Text);
                } // end delegate
            );
        } // end void

        /// <summary>
        /// Consulta la información en la base de datos y la despliga en la forma
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BuscarButton_Click(object sender, EventArgs e)
        {
            AppHelper.DoMethod(
                delegate
                {
                    //  Get unidad
                    int unidades = this.Model.NumeroUnidades();

                    switch (unidades)
                    {
                        case 0:

                            //  No hay unidades,
                            //  Consultamos directo
                            this.Model.Unidad_ID = null;

                            break;

                        case 1:

                            //  Hay una unidad,
                            //  la consultamos primero antes de consultar
                            //  las incidencias
                            this.Model.ConsultarUnidad();

                            break;

                        default:
                            //  Hay más de una unidad
                            //  primero obtenemos que unidad es
                            //  luego consultamos incidencias

                            SeleccionarUnidadConductor seleccionarUnidadForm = new SeleccionarUnidadConductor();
                            seleccionarUnidadForm.GetUnidades(this.Model.NumeroEconomico.Value);

                            if (seleccionarUnidadForm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                            {                                
                                this.Model.Unidad_ID = seleccionarUnidadForm.DatosConductor.Unidad_ID;
                            }
                            else
                            {
                                this.Model.Unidad_ID = null;
                            }

                            break;
                    }

                    //  Consultamos la información
                    this.Model.Consultar();

                    //  Dependiendo de la pestaña actual, actualizamos la gridview
                    switch (this.Model.TipoAtencionClientes)
                    {
                        case AltaAtencionClientes_Model.TiposAtencionClientes.Incidencias:

                            this.IncidenciasBindingSource.DataSource = this.Model.Incidencias;

                            break;

                        case AltaAtencionClientes_Model.TiposAtencionClientes.Cortesias:

                            this.CortesiasbindingSource.DataSource = this.Model.Cortesias;

                            break;

                        case AltaAtencionClientes_Model.TiposAtencionClientes.ObjetosExtraviados:

                            this.ObjetosExtraviadosBindingSource.DataSource = this.Model.ObjetosExtraviados;

                            break;

                        case AltaAtencionClientes_Model.TiposAtencionClientes.Reembolsos:

                            this.ReembolsosBindingSource.DataSource = this.Model.Reembolsos;

                            break;
                    } // end switch

                }, // end delegate
                this
            );
        } // end void

        /// <summary>
        /// Exporta la información de la forma a formato MS Excel
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ExportarButton_Click(object sender, EventArgs e)
        {
            AppHelper.DoMethod(
                delegate
                {
                    switch (this.Model.TipoAtencionClientes)
                    {
                        case AltaAtencionClientes_Model.TiposAtencionClientes.Incidencias:

                            AppHelper.ExportDataGridViewExcel(this.IncidenciasDataGridView, this);

                            break;

                        case AltaAtencionClientes_Model.TiposAtencionClientes.Cortesias:

                            AppHelper.ExportDataGridViewExcel(this.CortesiasDataGridView, this);

                            break;

                        case AltaAtencionClientes_Model.TiposAtencionClientes.ObjetosExtraviados:

                            AppHelper.ExportDataGridViewExcel(this.ObjetosExtraviadosDataGridView, this);

                            break;

                        case AltaAtencionClientes_Model.TiposAtencionClientes.Reembolsos:

                            AppHelper.ExportDataGridViewExcel(this.ReembolsosDataGridView, this);

                            break;
                    }
                }, // end delegate
                this
            );
        } // end void

        /// <summary>
        /// Si cambiamos de pestaña, actualizamos el modelo
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            AppHelper.Try(
                delegate
                {
                    //  Convertimos el tag de la pestaña al tipo de clientes
                    this.Model.TipoAtencionClientes =
                        (AltaAtencionClientes_Model.TiposAtencionClientes)Enum.Parse(
                            typeof(AltaAtencionClientes_Model.TiposAtencionClientes), 
                            this.tabControl1.SelectedTab.Tag.ToString()
                        );

                    //  Dependiendo de la pestaña actual, actualizamos la gridview
                    switch (this.Model.TipoAtencionClientes)
                    {
                        case AltaAtencionClientes_Model.TiposAtencionClientes.Incidencias:

                            if (this.IncidenciasBindingSource.DataSource == null)
                            {
                                this.Model.Consultar();
                            }

                            break;

                        case AltaAtencionClientes_Model.TiposAtencionClientes.Cortesias:

                            if (this.CortesiasbindingSource.DataSource == null)
                            {
                                this.Model.Consultar();
                            }

                            break;

                        case AltaAtencionClientes_Model.TiposAtencionClientes.ObjetosExtraviados:

                            if (this.ObjetosExtraviadosBindingSource.DataSource == null)
                            {
                                this.Model.Consultar();
                            }

                            break;

                        case AltaAtencionClientes_Model.TiposAtencionClientes.Reembolsos:

                            if (this.ReembolsosBindingSource.DataSource == null)
                            {
                                this.Model.Consultar();
                            }

                            break;
                    } // end switch
                } // end delegate
            );
        } // end void

        #endregion

    } // end class
} // end namespace
