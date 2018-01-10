/*
 * Actualización Estaciones
 * 
 * Actualiza una estación en el sistema
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
    /// Formulario para la actualización de estaciones
    /// </summary>
    public partial class ActualizacionEstaciones : baseForm
    {
        /// <summary>
        /// Crea una nueva instancia del formulario para la actualización
        /// de estaciones
        /// </summary>
        public ActualizacionEstaciones()
        {
            InitializeComponent();
        }

        #region Properties

        /// <summary>
        /// El ID de la estación a actualizar
        /// </summary>
        public int Estacion_ID
        {
            get { return _Estacion_ID; }
            set { _Estacion_ID = value; }
        }
        private int _Estacion_ID;

        /// <summary>
        /// El modelo de la lógica de negocios
        /// </summary>
        private ActualizacionEstaciones_Model Model;
        
        #endregion

        #region Model

        /// <summary>
        /// Modela la lógica de negocios para la actualización de una estación
        /// </summary>
        class ActualizacionEstaciones_Model
        {
            /// <summary>
            /// El ID de la estación a modificar
            /// </summary>
            public int Estacion_ID
            {
                get { return _Estacion_ID; }
                set { _Estacion_ID = value; }
            }
            private int _Estacion_ID;

            /// <summary>
            /// La entidad Estación a modificar
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
                this.Estacion.Update();
            }

            /// <summary>
            /// Consulta la información de la estación
            /// </summary>
            public void ConsultarEstacion()
            {
                this.Estacion = Entities.Estaciones.Read(this.Estacion_ID);
            }
        }
        #endregion

        #region Events

        /// <summary>
        /// Liga los datos a los controles
        /// </summary>
        public override void BindData()
        {
            this.Model = new ActualizacionEstaciones_Model();

            if (this.Estacion_ID > 0)
            {
                this.Model.Estacion_ID = this.Estacion_ID;
                this.Model.ConsultarEstacion();
                this.estacionesBindingSource.DataSource = this.Model.Estacion;
            }
            AppHelper.SetContainerDBValidations(this, "Estaciones");
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
                    Model.Guardar();
                    AppHelper.ClearControl(this);
                    AppHelper.Info("Estacion actualizada");
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
    }
}
