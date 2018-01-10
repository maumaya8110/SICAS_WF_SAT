/*
 * ConductoresOperativos
 * Creado el 25 de Octubre de 2012
 * por Luis Espino
 * 
 * Muestra los conductores operativos y los modifica
 * 
 * **  HISTORIAL **
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
    public partial class ConductoresOperativos : baseForm
    {
        #region Model
        /// <summary>
        /// Consulta los conductores operativos y se encarga de modificarlos
        /// </summary>
        class ConductoresOperativos_Model
        {

            #region Constructors

            /// <summary>
            /// Consulta los conductores operativos y se encarga de modificarlos
            /// </summary>
            public ConductoresOperativos_Model()
            {
                this.Empresas = Sesion.Empresas;
                this.Estaciones = Sesion.Estaciones;
            }

            #endregion


            #region Properties

            /// <summary>
            /// El listado de conductores
            /// </summary>
            public List<Entities.Vista_ConductoresOperativos> Conductores { get; set; }

            /// <summary>
            /// Listado de Empresas
            /// </summary>
            public List<Entities.SelectEmpresas> Empresas { get; set; }

            /// <summary>
            /// Listado de Estaciones
            /// </summary>
            public List<Entities.SelectEstaciones> Estaciones { get; set; }

            /// <summary>
            /// La empresa para la cual se consultarán los conductores
            /// </summary>
            public int? Empresa_ID { get; set; }

            /// <summary>
            /// La estación para la cual se consultarán los conductores
            /// </summary>
            public int? Estacion_ID { get; set; }

            /// <summary>
            /// El nombre del conductor a buscar
            /// </summary>
            public string Nombre { get; set; }

            /// <summary>
            /// El número de unidad a buscar
            /// </summary>
            public int? NumeroEconomico { get; set; }

            #endregion


            #region Methods

            public void Consultar()
            {
                this.Conductores = 
                    Entities.Vista_ConductoresOperativos.Get(
                        this.Empresa_ID, 
                        this.Estacion_ID, 
                        this.Nombre, 
                        this.NumeroEconomico
                    );
            }

            #endregion				
				
        }

        #endregion

        #region Constructors

        public ConductoresOperativos()
        {
            InitializeComponent();            
        }

        #endregion

        #region Properties

        /// <summary>
        /// El modelo de lógica de negocios
        /// </summary>
        ConductoresOperativos_Model Model { get; set; }

        /// <summary>
        /// El formulario para actualizar los datos
        /// </summary>
        forms.ActualizarLicenciaConductor ActualizarLicenciaForm 
        {
            get
            {
                if (_ActualizarLicenciaForm == null)
                    _ActualizarLicenciaForm = new ActualizarLicenciaConductor();

                if (_ActualizarLicenciaForm.IsDisposed)
                    _ActualizarLicenciaForm = new ActualizarLicenciaConductor();

                return _ActualizarLicenciaForm;
            }
            set
            {
                this._ActualizarLicenciaForm = value;
            }
        }
        forms.ActualizarLicenciaConductor _ActualizarLicenciaForm;

        #endregion

        #region Events

        /// <summary>
        /// Ligamos los datos a los controles
        /// </summary>
        public override void BindData()
        {
            //  Instanciamos el modelo
            this.Model = new ConductoresOperativos_Model();
            this.ActualizarLicenciaForm = new ActualizarLicenciaConductor();

            //  Ligamos los datos de las empresas y las estaciones
            this.selectEmpresasBindingSource.DataSource = this.Model.Empresas;
            this.selectEstacionesBindingSource.DataSource = this.Model.Estaciones;

            //  Actualizamos los datos del modelo, en empresa y estación
            this.Model.Empresa_ID = ((Entities.SelectEmpresas)this.EmpresasComboBox.SelectedItem).Empresa_ID;
            this.Model.Estacion_ID = ((Entities.SelectEstaciones)this.EstacionesComboBox.SelectedItem).Estacion_ID;

            base.BindData();
        }

        /// <summary>
        /// Actualizamos la empresa en el modelo
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EmpresasComboBox_SelectionChangeCommitted(object sender, EventArgs e)
        {
            AppHelper.Try(
                delegate
                {
                    this.Model.Empresa_ID = ((Entities.SelectEmpresas)this.EmpresasComboBox.SelectedItem).Empresa_ID;
                }
            );
        }

        /// <summary>
        /// Actualiza la estación en el modelo
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EstacionesComboBox_SelectionChangeCommitted(object sender, EventArgs e)
        {
            AppHelper.Try(
               delegate
               {
                   this.Model.Estacion_ID = ((Entities.SelectEstaciones)this.EstacionesComboBox.SelectedItem).Estacion_ID;
               }
           );
        }

        /// <summary>
        /// Actualiza el nombre del conductor en el modelo
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NombreTextBox_TextChanged(object sender, EventArgs e)
        {
            AppHelper.Try(
               delegate
               {
                   this.Model.Nombre = this.NombreTextBox.Text;
               }
           );
        }

        /// <summary>
        /// Actualiza el número económico en el modelo
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NumeroEconomicoTextBox_TextChanged(object sender, EventArgs e)
        {
            AppHelper.Try(
               delegate
               {
                   this.Model.NumeroEconomico = DB.GetNullableInt32(this.NumeroEconomicoTextBox.Text);
               }
           );
        }

        /// <summary>
        /// Consulta los datos y los despliega en la tabla
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BuscarButton_Click(object sender, EventArgs e)
        {
            AppHelper.DoMethod(
                delegate
                {
                    //  Consultamos los datos
                    this.Model.Consultar();

                    //  Los ligamos a la fuente de datos
                    this.vista_ConductoresOperativosBindingSource.DataSource = this.Model.Conductores;
                },
                this
            );
        }

        /// <summary>
        /// Exporta los datos de la tabla a formato MS Excel
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ExportarButton_Click(object sender, EventArgs e)
        {
            //  Exportamos los datos de la tabla a Excel
            //  no necesita try, la función lo genera
            AppHelper.ExportDataGridViewExcel(this.vista_ConductoresOperativosDataGridView, this);
        }        

        /// <summary>
        /// Despliega la forma de actualización
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void vista_ConductoresOperativosDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            AppHelper.Try(
                delegate
                {
                    //  Obtenemos al conductor
                    Entities.Vista_ConductoresOperativos conductor =
                        (Entities.Vista_ConductoresOperativos)vista_ConductoresOperativosDataGridView.Rows[e.RowIndex].DataBoundItem;

                    //  Configuramos al conductor en la forma de actualización
                    this.ActualizarLicenciaForm.SetConductor(conductor.Conductor_ID.Value);

                    //  Mostramos la forma de actualización
                    if (this.ActualizarLicenciaForm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    {
                        //  Actualizamos los datos
                        this.BuscarButton.PerformClick();
                    } // end if

                } // end delgate

            ); // end Try
        } // end CellClick

        #endregion Events

    } // end class

} // end namespace
