using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace SICASv20.forms
{
    /// <summary>
    /// Presenta un resumen de los datos del contrato
    /// </summary>
    public partial class Contratos_ResumenUC : baseUserControl
    {
        /// <summary>
        /// Crea una nueva instancia de la clase "Contratos_ResumenUC"
        /// </summary>
        public Contratos_ResumenUC()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Referencia a la forma Padre, el "AsistenteContratos"
        /// </summary>
        public AsistenteContratos Padre;

        /// <summary>
        /// Liga los datos a los controles
        /// </summary>
        public void BindData()
        {
            //  Paramos el resumen a una lista
            List<KeyValuePair<string, string>> list = new List<KeyValuePair<string, string>>();
            list.AddRange(Padre.Summary);

            //  La asignamos al control GridView
            this.resumenGridView.AutoGenerateColumns = true;
            this.resumenGridView.DataSource = list;
        }

        /// <summary>
        /// Maneja el evento "Click" del botón "Finalizar"
        /// </summary>
        /// <param name="sender">El botón "Finalizar"</param>
        /// <param name="e">Los argumentos del evento</param>
        private void FinalizarButton_Click(object sender, EventArgs e)
        {
            try
            {
                //  Crea el contrato y lo registra en la base de datos
                Padre.InsertarContrato();                
            }
            catch (Exception ex)
            {
                AppHelper.Error(ex.Message);
            }
        }

        /// <summary>
        /// Maneja el evento "Click" del botón "Atras"
        /// </summary>
        /// <param name="sender">El botón "Atras"</param>
        /// <param name="e">Los argumentos del evento</param>
        private void AtrasButton_Click(object sender, EventArgs e)
        {
            try
            {
                Padre.SwitchPanel("DatosCuentaFechas");
            }
            catch (Exception ex)
            {
                AppHelper.Error(ex.Message);
            }
        }

    } // end class Contratos_ResumenUC

} // end namespace SICASv20.forms