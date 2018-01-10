/*
 * AltaEstaciones
 * 
 * Da de alta una estación en el sistema
 * 
 * Modificado el 17 de Octubre de 2012
 * por Luis Espino
 * 
 * Se eliminó el campo Empresa_ID y sus funciones
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
    /// <summary>
    /// Formulario para el alta de estaciones
    /// </summary>
    public partial class AltaEstaciones : baseForm
    {
        /// <summary>
        /// Crea una nueva instancia del formulario para el alta de estaciones
        /// </summary>
        public AltaEstaciones()
        {
            InitializeComponent();
        }

        #region Properties

        /// <summary>
        /// Modelo de lógica de negocios
        /// </summary>
        private AltaEstaciones_Model Model;

        #endregion

        #region Model

        /// <summary>
        /// Modela la lógica de negocios para el alta de estaciones
        /// </summary>
        class AltaEstaciones_Model
        {
            /// <summary>
            /// La entidad estación a dar de alta
            /// </summary>
            public Entities.Estaciones Estacion
            {
                get { return _Estacion; }
                set { _Estacion = value; }
            }
            private Entities.Estaciones _Estacion;

            /// <summary>
            /// Guarda los cambios en la base de datos
            /// </summary>
            public void Guardar()
            {
                this.Estacion.Create();
            }
        }

        #endregion

        #region Events

        /// <summary>
        /// Liga los datos a los controles
        /// </summary>
        public override void BindData()
        {
            this.Model = new AltaEstaciones_Model();            
            AppHelper.SetContainerDBValidations(this, "Estaciones");
            this.estacionesBindingSource.AddNew();
            base.BindData();
        }

        /// <summary>
        /// Guarda los cambios en la base de datos
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GuardarButton_Click(object sender, EventArgs e)
        {
            AppHelper.DoMethod(
                delegate
                {
                    Model.Estacion = (Entities.Estaciones)estacionesBindingSource.Current;
                    Model.Estacion.Activo = true;
                    Model.Guardar();
                    AppHelper.ClearControl(this);
                    AppHelper.Info("Estacion registrada");
                },
                this
            );
        }
        
        /// <summary>
        /// Cierra la forma
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CancelarButton_Click(object sender, EventArgs e)
        {
            AppHelper.DoMethod(
                delegate
                {
                    this.Padre.CancelCurrentForm();
                },
                this
            );
        }

        #endregion

    } // end class
} // end namespace
