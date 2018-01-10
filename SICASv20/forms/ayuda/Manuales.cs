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
    /// Formulario para listar los manuales a los que se tiene acceso
    /// </summary>
    public partial class Manuales : baseForm
    {
        /// <summary>
        /// Crea una nueva instancia del formulario de manuales
        /// </summary>
        public Manuales()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Abre un nuevo formulario de ayuda, con el manual elegido desplegado en él
        /// </summary>
        /// <param name="manual"></param>
        private void ShowHelp(string manual)
        {
            //  Verificamos la instancia del formulario de ayuda
            if (Padre.AyudaForm == null)
                Padre.AyudaForm = new Ayuda();

            if (Padre.AyudaForm.IsDisposed)
                Padre.AyudaForm = new Ayuda();

            //  Le configuramos un manual
            Padre.AyudaForm.SetManual(manual);

            //  Mostramos la forma
            Padre.AyudaForm.Show();
        }

        /// <summary>
        /// Muestra el manual de caja
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ManualDeCajaLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            AppHelper.Try(
                delegate
                {
                    ShowHelp("ManualCajaMetropolitano.mht");
                }
            );
        }

        /// <summary>
        /// Muestra el manual de cobranza
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ManualCobranzaLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            AppHelper.Try(
                delegate
                {
                    ShowHelp("ManualCobranzaMetropolitano.mht");
                }
            );
        }

        /// <summary>
        /// Muestra el manual de Caja Supervisión
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ManualCajasupervisionLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            AppHelper.Try(
                delegate
                {
                    ShowHelp("ManualCajaSupervision.pps");
                }
            );

        } // end ManualCajasupervisionLinkLabel_LinkClicked

    } // end class

} // end namespace
