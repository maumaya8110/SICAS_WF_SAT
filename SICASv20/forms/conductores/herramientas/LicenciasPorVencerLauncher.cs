using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SICASv20.forms
{
    public partial class LicenciasPorVencerLauncher : baseForm
    {
        /// <summary>
        /// Formulario para "lanzar" la pantalla de "LicenciasPorVencer"
        /// </summary>
        public LicenciasPorVencerLauncher()
        {
            InitializeComponent();
        }

        /// <summary>
        /// El formulario de licencias vencidas
        /// </summary>
        private forms.LicenciasPorVencer LicenciasForm = null;

        /// <summary>
        /// Liga los datos a los controles
        /// </summary>
        public override void BindData()
        {
            LicenciasForm = new LicenciasPorVencer();
            LicenciasForm.WindowState = FormWindowState.Maximized;
            LicenciasForm.Show();
            base.BindData();
        }
    }
}
