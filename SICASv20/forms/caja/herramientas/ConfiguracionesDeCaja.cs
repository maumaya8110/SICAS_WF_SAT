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
    /// Formulario que contiene opciones de configuración para las cajas
    /// </summary>
    public partial class ConfiguracionesDeCaja : baseForm
    {
        /// <summary>
        /// Crea una nueva instancia del formulario de ConfiguracionesDeCaja
        /// </summary>
        public ConfiguracionesDeCaja()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Representa el modelo de lógica de negocios para la operación
        /// de configuraciones de caja
        /// </summary>
        class ConfiguracionesDeCaja_Model
        {
            /// <summary>
            /// Los datos de caja para visualicación
            /// </summary>
            public Entities.Vista_Cajas VistaCaja { get; set; }

            /// <summary>
            /// La entidad caja a configurar
            /// </summary>
            public Entities.Cajas Caja { get; set; }

            /// <summary>
            /// Crea una nueva instancia del modelo a partir de un
            /// identificador de caja
            /// </summary>
            /// <param name="caja_id"></param>
            public ConfiguracionesDeCaja_Model(int caja_id)
            {
                //  Carga los datos de caja
                this.Caja = Entities.Cajas.Read(caja_id);

                //  Carga los datos de caja para visualización
                this.VistaCaja = Entities.Vista_Cajas.Get(caja_id)[0];
            }

            /// <summary>
            /// Guarda la información en la base de datos
            /// </summary>
            public void Guardar()
            {
                //  Mandamos a actualizar los datos de caja
                this.Caja.Update();
            }

        } // end class ConfiguracionesCaja_Model

        /// <summary>
        /// El modelo de lógica de negocios utilizar en el formulario
        /// </summary>
        ConfiguracionesDeCaja_Model Model;

        /// <summary>
        /// Liga los datos a los controles
        /// </summary>
        public override void BindData()
        {
            //  Verificamos que la caja tenga datos
            if (Sesion.Caja_ID == null) // Si no, arrojamos error
                AppHelper.ThrowException("No tiene caja configurada, no puede utilizar esta opcion");

            //  Instanciamos el modelo
            Model = new ConfiguracionesDeCaja_Model(Sesion.Caja_ID.Value);

            //  Ligamos los datos de visualización
            this.vista_CajasBindingSource.DataSource = Model.VistaCaja;
            base.BindData();
        }

        /// <summary>
        /// Manda guardar los datos en la base de datos
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GuardarButton_Click(object sender, EventArgs e)
        {
            AppHelper.DoMethod(
                delegate
                {
                    //  Configuramos los datos no ligados
                    Model.Caja.EnClave = this.enClaveCheckBox.Checked;
                    Model.Caja.ImpresionDoble = this.impresionDobleCheckBox.Checked;

                    //  Guardamos los datos
                    Model.Guardar();

                    //  Emitimos mensaje de éxito
                    AppHelper.Info("Configuraciones guardadas");
                },
                this
            );
        }
    } // end class
} // end namespace
