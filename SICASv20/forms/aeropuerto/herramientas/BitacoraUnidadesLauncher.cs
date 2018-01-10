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
    /// Esta forma al cargarse "lanza" la ventana de Bitácora de Unidades
    /// cuenta ademas con un botón para lanzarla manualmente
    /// </summary>
    public partial class BitacoraUnidadesLauncher : baseForm
    {
        /// <summary>
        /// Crea una nueva instancia de BitácoraUnidades
        /// </summary>
        public BitacoraUnidadesLauncher()
        {
            InitializeComponent();
        }
        
        /// <summary>
        /// El formulario de bitácora de unidades
        /// </summary>
        private forms.BitacoraUnidades bitacora;

        /// <summary>
        /// Liga los datos a los controles
        /// </summary>
        public override void BindData()
        {
            bitacora = new BitacoraUnidades();
            bitacora.Show();
            base.BindData();
        }

        /// <summary>
        /// Al hacer clic en 'Abrir Bitácora', abrimos el formulario
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AbrirBitacoraButton_Click(object sender, EventArgs e)
        {
            if (bitacora == null) 
                bitacora = new BitacoraUnidades();

            if (bitacora.IsDisposed)
                bitacora = new BitacoraUnidades();

            bitacora.Show();
        } // end void

    } // end class

} // end namespace
