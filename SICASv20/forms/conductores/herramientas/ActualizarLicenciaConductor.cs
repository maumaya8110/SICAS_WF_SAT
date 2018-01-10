/*
 * ActualizarLicenciaConductor
 * Actualiza los datos de licencias de un conductor seleccionado
 * 
 * **  HISTORIAL  **
 *      2012-10-27, Creado por Luis Espino
 *      
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
    /// Muestra el formulario para actualizar datos de licencia de los conductores
    /// </summary>
    public partial class ActualizarLicenciaConductor : Form
    {
        #region Model

        /// <summary>
        /// Realiza las funciones de lógica de negocios e interacción con la base de datos
        /// para llevar a cabo la actualización de datos de licencias de los conductores
        /// </summary>
        class ActualizarLicenciaConductor_Model
        {

            #region Constructors

            /// <summary>
            /// Crea una instancia de la clase modelo
            /// </summary>
            public ActualizarLicenciaConductor_Model()
            {
                //  TODO
            }

            #endregion


            #region Properties

            /// <summary>
            /// La entidad Conductor a modificar
            /// </summary>
            public Entities.Conductores Conductor { get; set; }

            #endregion


            #region Methods

            /// <summary>
            /// Obtiene al conductor a partir de su ID
            /// </summary>
            /// <param name="conductor_id"></param>
            public void GetConductor(int conductor_id)
            {
                //  Obtenemos al conductor
                this.Conductor = Entities.Conductores.Read(conductor_id);

                //  Actualizamos los datos en caso se nulos
                if (this.Conductor.PrimerCursoLicencia == null)
                    this.Conductor.PrimerCursoLicencia = false;

                if (this.Conductor.SegundoCursoLicencia == null)
                    this.Conductor.SegundoCursoLicencia = false;

                if (this.Conductor.ExamenMedico == null)
                    this.Conductor.ExamenMedico = false;

                if (this.Conductor.Nomina == null)
                    this.Conductor.Nomina = false;
            }

            /// <summary>
            /// Guarda los cambios en la base de datos
            /// </summary>
            public void Guardar()
            {
                bool validaCURP = false;
                if (this.Conductor != null)
                    this.Conductor.Update(validaCURP);
            }

            #endregion				
				
        }

        #endregion

        #region Constructors

        /// <summary>
        /// Muestra el formulario para actualizar datos de licencia de los conductores
        /// </summary>
        public ActualizarLicenciaConductor()
        {
            InitializeComponent();
            this.Model = new ActualizarLicenciaConductor_Model();
        }

        #endregion

        #region Properties

        /// <summary>
        /// El modelo de la forma
        /// </summary>
        private ActualizarLicenciaConductor_Model Model { get; set; }

        #endregion

        #region Methods

        /// <summary>
        /// Establece el conductor a modificar
        /// </summary>
        /// <param name="conductor_id"></param>
        public void SetConductor(int conductor_id)
        {
            AppHelper.Try(
                delegate
                {
                    this.Model.GetConductor(conductor_id);
                }
            );
        }

        #endregion

        #region Events

        /// <summary>
        /// Guarda los datos, cierra la forma y actualiza la información en el formulario
        /// de "Conductores Operativos"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AceptarButton_Click(object sender, EventArgs e)
        {
            AppHelper.Try(
                delegate
                {
                    //  Obtenemos al conductor de la fuente de datos
                    this.Model.Conductor = (Entities.Conductores)this.conductoresBindingSource.Current;

                    //  Posibilitamos la utilización de nulos
                    //  en "VenceLicencia"

                    if (this.VenceLicenciaDatePicker.Checked)
                    {
                        this.Model.Conductor.VenceLicencia = this.VenceLicenciaDatePicker.Value.Date;
                    } // end if Checked
                    else
                    {
                        this.Model.Conductor.VenceLicencia = null;
                    } // end else Checked

                    //  Guardamos los datos
                    this.Model.Guardar();

                    //  Enviamos mensaje de éxito
                    AppHelper.Info("Datos actualizados");

                    //  Configuramos el resultado
                    this.DialogResult = System.Windows.Forms.DialogResult.OK;

                    //  Cerramos la forma
                    this.Close();

                } // end delegate

            ); // end Try

        } // end Click

        /// <summary>
        /// Al cargar la forma, liga los datos
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ActualizarLicenciaConductor_Load(object sender, EventArgs e)
        {
            AppHelper.Try(
                delegate
                {
                    //  Ligamos el conductor a la fuente de datos
                    this.conductoresBindingSource.DataSource = Model.Conductor;

                    //  Verificamos si tiene fecha de vencimiento de la licencia
                    if (this.Model.Conductor.VenceLicencia == null)
                    {
                        this.VenceLicenciaDatePicker.Checked = false;
                    }
                    else
                    {
                        this.VenceLicenciaDatePicker.Checked = true;
                    }
                }
            );
        } // end constructor

        #endregion
    } // end class ActualizarLicenciaConductor
} // end namespace
