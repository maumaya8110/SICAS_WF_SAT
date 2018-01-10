using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SICASv20.forms
{
    public partial class ReporteSaldosCuentasUnidades : baseForm
    {
        /// <summary>
        /// Clase que modela la lógica de negocios del reporte de saldos de cuentas de unidades
        /// </summary>
        public class ReporteSaldosCuentasUnidades_Model
        {
            /// <summary>
            /// Construye la clase
            /// </summary>
            public ReporteSaldosCuentasUnidades_Model()
            {
                //  Toma las empresas y estaciones de la sesión
                this.Empresas = Sesion.Empresas;
                this.Estaciones = Sesion.Estaciones;
            }
            /// <summary>
            /// La Unidad a consultar
            /// </summary>
            public int? Unidad_ID { get; set; }

            /// <summary>
            /// La Empresa a la que pertenecen las unidades a consultar
            /// </summary>
            public int? Empresa_ID { get; set; }

            /// <summary>
            /// La Estacion a la que pertenecen las unidades a consultar
            /// </summary>
            public int? Estacion_ID { get; set; }

            /// <summary>
            /// Los datos de la unidad actual
            /// </summary>
            public Entities.DatosConductorUnidad DatosUnidad { get; set; }

            /// <summary>
            /// El Número Económico de la Unidad Actual a Consultar
            /// </summary>
            public int NumeroEconomico { get; set; }

            /// <summary>
            /// Las Empresas disponibles en la sesión
            /// </summary>
            public List<Entities.SelectEmpresas> Empresas { get; set; }

            /// <summary>
            /// Las Estaciones disponibles en la sesión
            /// </summary>
            public List<Entities.SelectEstaciones> Estaciones { get; set; }

            /// <summary>
            /// Los Saldos de las Unidades
            /// </summary>
            public List<Entities.Vista_SaldosTotalesUnidades> Saldos { get; set; }

            /// <summary>
            /// Consulta los saldos de las unidades desde la base de datos
            /// </summary>
            public void ConsultarSaldos()
            {
                this.Saldos = 
                    Entities.Vista_SaldosTotalesUnidades.Get(
                        this.Unidad_ID, 
                        this.Empresa_ID, 
                        this.Estacion_ID
                    );
            } // end void  

            /// <summary>
            /// Consulta la unidad a partir del número economico, la empresa y la estación
            /// </summary>
            public void BuscarUnidad()
            {
                //  Obtenemos los datos de la unidad
                this.DatosUnidad = 
                    Entities.DatosConductorUnidad.Get(
                        this.NumeroEconomico, 
                        this.Empresa_ID, 
                        this.Estacion_ID,
                        false
                    );

                //  Configuramos la unidad
                this.Unidad_ID = this.DatosUnidad.Unidad_ID;

                //  Consultamos sus saldos
                this.ConsultarSaldos();
            }
            
        } // end class ReporteSaldosCuentasUnidades_Model

        //  La instancia del modelo a utilizar para la lógica del negocio
        private ReporteSaldosCuentasUnidades_Model Model;

        /// <summary>
        /// Construimos la clase
        /// </summary>
        public ReporteSaldosCuentasUnidades()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Ligamos los datos
        /// </summary>
        public override void BindData()
        {
            //  Instanciamos el modelo
            this.Model = new ReporteSaldosCuentasUnidades_Model();

            //  Ligar los datos de las empresas y estaciones
            this.selectEmpresasBindingSource.DataSource = this.Model.Empresas;
            this.selectEstacionesBindingSource.DataSource = this.Model.Estaciones;

            //  Seleccionar la empresa y estacion actuales
            SeleccionarEmpresa();
            SeleccionarEstacion();

            base.BindData();
        }

        /// <summary>
        /// Configura una empresa en el modelo
        /// </summary>
        private void SeleccionarEmpresa()
        {
            this.Model.Empresa_ID = DB.GetNullableInt32(this.empresa_IDComboBox.SelectedValue);
        }

        /// <summary>
        /// Configura una estacion en el modelo
        /// </summary>
        private void SeleccionarEstacion()
        {
            this.Model.Estacion_ID = DB.GetNullableInt32(this.estacion_IDComboBox.SelectedValue);
        }

        /// <summary>
        /// Al Selecciona una Empresa, la configuramos en el modelo
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void empresa_IDComboBox_SelectionChangeCommitted(object sender, EventArgs e)
        {
            AppHelper.Try(
                delegate
                {
                    this.SeleccionarEmpresa();
                } // end delegate
            ); // end AppHelper.Try
        } // end void 

        /// <summary>
        /// Al Seleccionar una Estación, la configuramos en el modelo
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void estacion_IDComboBox_SelectionChangeCommitted(object sender, EventArgs e)
        {
            AppHelper.Try(
                delegate
                {
                    this.SeleccionarEstacion();
                } // end delegate
            ); // end AppHelper.Try
        } // end void 

        /// <summary>
        /// Al hacer enter, consultamos por unidad
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NumeroEconomicoTextBox_KeyUp(object sender, KeyEventArgs e)
        {
            AppHelper.Try(
                delegate
                {
                    //  Si dimos enter
                    if (e.KeyData == Keys.Enter)
                    {
                        //  Si hay datos
                        if (!string.IsNullOrEmpty(this.NumeroEconomicoTextBox.Text))
                        {
                            //  Configuramos el numero economico en el modelo
                            this.Model.NumeroEconomico = Convert.ToInt32(this.NumeroEconomicoTextBox.Text);

                            //  Mandamos consultar por unidad
                            this.Model.BuscarUnidad();

                            //  Ligamos los datos
                            this.vista_SaldosTotalesUnidadesBindingSource.DataSource = this.Model.Saldos;
                        } // end if
                    } // end if
                } // end delegate
            ); // end AppHelper.Try
        } // end void 

        /// <summary>
        /// Consultamos la información
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ConsultarButton_Click(object sender, EventArgs e)
        {
            AppHelper.DoMethod(
                delegate
                {
                    //  Seteamos la unidad a null
                    this.Model.Unidad_ID = null;
                    
                    //  Consultamos los saldos
                    this.Model.ConsultarSaldos();

                    //  Ligamos los datos
                    this.vista_SaldosTotalesUnidadesBindingSource.DataSource = this.Model.Saldos;
                },
                this
            ); // end AppHelper.DoMethod
        } // end void

        /// <summary>
        /// Exporta los datos que hay en la gridview a MS Excel
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ExportarButton_Click(object sender, EventArgs e)
        {
            AppHelper.DoMethod(
                delegate
                {
                    //  exportamos el contenido del data grid
                    AppHelper.ExportDataGridViewExcel(this.vista_SaldosTotalesUnidadesDataGridView, this);
                },
                this
            ); // end AppHelper.DoMethod
        } // end void
    } // end class
} // end namespace
