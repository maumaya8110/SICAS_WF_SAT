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
    /// Formulario para cancelar un servicio de transportación
    /// terrestre
    /// </summary>
    public partial class CancelarServicio : baseForm
    {
        /// <summary>
        /// Crea una nueva instancia del formulario
        /// para cancelar un servicio
        /// </summary>
        public CancelarServicio()
        {
            InitializeComponent();
        }

        #region Model

        /// <summary>
        /// Modelo de la lógica de negocios para
        /// cancelar un servicio
        /// </summary>
        class CancelarServicio_Model
        {
            /// <summary>
            /// Código del boleto de servicio de transportación terrestre
            /// </summary>
            public string Servicio_ID { get; set; }

            /// <summary>
            /// El número de folio de la sesión
            /// </summary>
            public int Sesion_ID { get; set; }

            /// <summary>
            /// La instancia del servicio a modificar
            /// </summary>
            private Entities.Servicios servicio;

            /// <summary>
            /// Valida los datos del servicio a cancelar
            /// </summary>
            private void ValidadServicio()
            {
                //  Obtenemos el servicio a partir de su código de identificación
                servicio = Entities.Servicios.Read(this.Servicio_ID);

                //  Verificar que el servicio pertenezca a la sesión
                if (servicio.Sesion_ID != this.Sesion_ID)
                {
                    throw new Exception("El servicio no pertenece a esta sesión");
                }

                //  Verificar que los servicios no hayan sido pagados
                if (servicio.EstatusServicio_ID == 3)
                {
                    throw new Exception("El servicio ya ha sido pagado, no puede cancelarse");
                }
            }

            /// <summary>
            /// Cancela el servicio y registra los cambios
            /// en la base de datos
            /// </summary>
            public void CancelarServicio()
            {
                ValidadServicio();
                servicio.EstatusServicio_ID = 4;
                servicio.Update();
            }

        } // end class CancelarServicio_Model

        #endregion Model

        #region Properties

        /// <summary>
        /// El modelo de lógica de negocios
        /// </summary>
        private CancelarServicio_Model Model;

        #endregion

        #region Methods

        /// <summary>
        /// Liga los datos a los controles
        /// </summary>
        public override void BindData()
        {
            this.Model = new CancelarServicio_Model();
            base.BindData();
        }

        #endregion

        #region Events

        /// <summary>
        /// Al cambiar el número de servicio, actualizamos el modelo
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Servicio_IDTextBox_TextChanged(object sender, EventArgs e)
        {
            AppHelper.Try(
                delegate
                {
                    this.Model.Servicio_ID = this.Servicio_IDTextBox.Text;
                }
            );
        }

        /// <summary>
        /// Al hacer click en "Cancelar", cancela el servicio
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CancelarButton_Click(object sender, EventArgs e)
        {
            AppHelper.DoMethod(
                delegate
                {
                    Model.Sesion_ID = Sesion.Sesion_ID;
                    Model.CancelarServicio();
                    AppHelper.ClearControl(this);
                    AppHelper.Info("Servicio cancelado");
                },
                this
            );
        }

        #endregion Events
    } // end class CancelarServicio

} // end namespace SICASv20.forms
