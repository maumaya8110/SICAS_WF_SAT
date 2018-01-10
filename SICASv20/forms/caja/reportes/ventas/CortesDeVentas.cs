/*
 * SICASv20.forms.CortesDeVentas
 * 
 * Codificado por Luis Espino
 * Ultima revisión 7 de Agosto de 2012
 */

//  Namespaces a utilizar
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
    /// CortesDeVentas
    /// Formulario, hereda la clase baseForm
    /// Su funcion es mostrar el listado de cortes de ventas
    /// en la estación Aeropuerto
    /// a partir de parámetros de fechas
    /// </summary>
    public partial class CortesDeVentas : baseForm
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public CortesDeVentas()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Clase de Modelo del funcionamiento
        /// de la lógica de negocios del escenario
        /// </summary>
        class CortesDeVentas_Model
        {            
            private List<Entities.Vista_CortesDeVentas> _Cortes;

            /// <summary>
            /// Lista de entidades del tipo Vista_CortesDeVentas,
            /// representa el listado de cortes
            /// </summary>
            public List<Entities.Vista_CortesDeVentas> Cortes
            {
                get { return _Cortes; }
                set { _Cortes = value; }
            }

            private DateTime _FechaInicial;

            /// <summary>
            /// Fecha inicial a consultar en los cortes
            /// </summary>
            public DateTime FechaInicial
            {
                get { return _FechaInicial; }
                set { _FechaInicial = value; }
            }

            private DateTime _FechaFinal;

            /// <summary>
            /// Fecha final a consultar en los cortes
            /// </summary>
            public DateTime FechaFinal
            {
                get { return _FechaFinal; }
                set { _FechaFinal = value; }
            }

            private int? _Estacion_ID;

            /// <summary>
            /// Estaicon a consultar en los cortes
            /// </summary>
            public int? Estacion_ID
            {
                get { return _Estacion_ID; }
                set { _Estacion_ID = value; }
            }

            /// <summary>
            /// Procedimiento de consulta
            /// </summary>
            public void Consultar()
            {
                //  Obtiene los cortes a partir de los parámetros
                //  y los asigna a la variable de tipo lista Cortes
                this.Cortes = 
                    Entities.Vista_CortesDeVentas.Get( 
                        this.Estacion_ID, 
                        this.FechaInicial, 
                        this.FechaFinal
                    );
            }
        }

        /// <summary>
        /// Variable del Modelo CortesDeVentas_Model a utilizar
        /// </summary>
        private CortesDeVentas_Model Model;

        /// <summary>
        /// Formulario de Servicios de Sesion
        /// </summary>
        private ServiciosDeSesion ServiciosForm;

        /// <summary>
        /// Formulario de ServiciosConductores de Sesion
        /// </summary>
        private ServiciosConductoresDeSesion ServiciosConductoresForm;


        /// <summary>
        /// Formulario de Consolidado de Ventas
        /// </summary>
        private ConsolidadoDeVentasServicios ConsolidadoForm;

        /// <summary>
        /// Instancia el Formulario de Consolidado de Ventas
        /// </summary>
        private void Set_ConsolidadoForm()
        {
            if (ConsolidadoForm == null)
                ConsolidadoForm = new ConsolidadoDeVentasServicios();

            if (ConsolidadoForm.IsDisposed)
                ConsolidadoForm = new ConsolidadoDeVentasServicios();
        }

        /// <summary>
        /// Instancia el Formulario de Servicios de Conductores
        /// </summary>
        private void Set_ServiciosConductoresForm()
        {
            if (ServiciosConductoresForm == null)
                ServiciosConductoresForm = new ServiciosConductoresDeSesion();

            if (ServiciosConductoresForm.IsDisposed)
                ServiciosConductoresForm = new ServiciosConductoresDeSesion();
        }

        /// <summary>
        /// Instancia el Formulario de Servicios
        /// </summary>
        private void Set_ServiciosForm()
        {
            if (ServiciosForm == null)
                ServiciosForm = new ServiciosDeSesion();

            if (ServiciosForm.IsDisposed)
                ServiciosForm = new ServiciosDeSesion();
        }

        /// <summary>
        /// Liga los datos del Modelo con los controles del Formulario
        /// </summary>
        public override void BindData()
        {
            //  Instancia la variable de Modelo
            this.Model = new CortesDeVentas_Model();

            this.estacionesBindingSource.DataSource = Sesion.Estaciones;

            //  Asigna las variables a partir de la variable global de sesión
            //  y los controles del formulario
            this.Model.Estacion_ID = DB.GetNullableInt32(this.Estacion_IDComboBox.SelectedValue);
            this.Model.FechaInicial = AppHelper.FechaInicial(this.FechaInicialDateTimePicker.Value.Date);
            this.Model.FechaFinal = AppHelper.FechaFinal(this.FechaFinalDateTimePicker.Value.Date);

            //  Realiza el procedimiento de consulta
            this.Model.Consultar();

            //  Liga la lista de cortes a la fuente de datos
            //  que a su vez ligará los datos al control DataGridView
            //  lo que poblará la lista y se visualizará en pantalla
            this.vista_CortesDeVentasBindingSource.DataSource = this.Model.Cortes;
            
            //  Ejecuta el procedimiento BindData de la clase Padre baseForm
            base.BindData();
        }

        /// <summary>
        /// Realiza la consulta de informacíón y liga los datos a los controles del formulario
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ConsultarButton_Click(object sender, EventArgs e)
        {
            AppHelper.Try(
                delegate
                {
                    this.Model.Consultar();
                    this.vista_CortesDeVentasBindingSource.DataSource = this.Model.Cortes;
                }
            );
        }

        /// <summary>
        /// Asigna el valor a la variable FechaInicial del Modelo
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FechaInicialDateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            AppHelper.Try(
                delegate
                {
                    this.Model.FechaInicial = this.FechaInicialDateTimePicker.Value.Date;
                }
            );
        }

        /// <summary>
        /// Asigna el valor a la variable FechaFinal del Modelo
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FechaFinalDateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            AppHelper.Try(
                delegate
                {
                    this.Model.FechaFinal = this.FechaFinalDateTimePicker.Value.Date;
                }
            );
        }

        /// <summary>
        /// Muestra el formulario seleccionado, a partir de la columna seleccionada
        /// en el control DataGridView
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void vista_CortesDeVentasDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            AppHelper.Try(
                delegate
                {
                    //  Declaramos la variable de corte
                    Entities.Vista_CortesDeVentas corte;

                    //  Obtenemos el nombre de la columna seleccionada
                    string colName = vista_CortesDeVentasDataGridView.Columns[e.ColumnIndex].Name;

                    //  Declaramos una lista de columnas para mostrar reporte
                    List<string> cols = new List<string> { "VentaCol", "BoletosEspecialesCol", "ConsolidadoCol" };
                    
                    //  Verificamos que haya sido seleccionada una de las columnas para mostrar reportes
                    if (cols.Contains(colName))
                    {
                        //  Si se seleccionó una de las columnas que muestran reporte
                        //  Instanciamos el corte a partir del dato del renglón seleccionado
                        corte = (Entities.Vista_CortesDeVentas)this.vista_CortesDeVentasDataGridView.Rows[e.RowIndex].DataBoundItem;
                    }
                    else // Si no ha sido seleccionada una columna que muestre reporte
                    {
                        //  Salimos del procedimiento
                        return;
                    }

                    //  Determinamos que columna ha sido seleccionada
                    switch (colName)
                    {
                            //  En el caso de "VentaCol"
                        case "VentaCol":

                            //  Instanciamos el formulario de Servicios
                            this.Set_ServiciosForm();

                            //  Asignamos la sesión seleccionada
                            this.ServiciosForm.Sesion_ID = corte.Sesion_ID.Value;

                            //  Mostramos el formulario de Servicios
                            this.ServiciosForm.Show();
                            break;

                            //  En el caso de Boletos Especiales
                        case "BoletosEspecialesCol":

                            //  Instanciamos el formulario de Servicios Conductores
                            this.Set_ServiciosConductoresForm();

                            //  Asignamos la sesión seleccionada
                            this.ServiciosConductoresForm.Sesion_ID = corte.Sesion_ID.Value;

                            //  Mostramos el formulario de Servicios Conductores
                            this.ServiciosConductoresForm.Show();
                            break;

                            //  En el caso de Consolidado
                        case "ConsolidadoCol":

                            //  Instanciamos el formulario de Servicios Consolidado
                            this.Set_ConsolidadoForm();

                            //  Asignamos la fecha correspondiente, la fecha inicial
                            this.ConsolidadoForm.Fecha = corte.FechaInicial.Value;

                            //  Mostramos el formulario
                            this.ConsolidadoForm.Show();
                            break;
                    } // End switch
                } // End delegate
            ); // End AppHelper.Try     
        }


        private void Estacion_IDComboBox_SelectionChangeCommitted(object sender, EventArgs e)
        {
            AppHelper.Try(
                delegate
                {
                    this.Model.Estacion_ID = DB.GetNullableInt32(this.Estacion_IDComboBox.SelectedValue);
                }
            );
        } // End void
    } // End Class
} // End Namespace
