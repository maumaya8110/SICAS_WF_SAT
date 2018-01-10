/*
 * AltaZonas
 * SICASv20.forms.AltaZonas
 * 
 * Codificado por Luis Espino
 * Ultima revision 2012-08-09
 * 
 * El propósito es dar de alta nuevas zonas
 * en el sistema de Aeropuerto
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
    /// Da de alta nuevas zonas en el sistema de Aeropuerto
    /// </summary>
    public partial class AltaZonas : baseForm
    {
        /// <summary>
        /// El constructor
        /// </summary>
        public AltaZonas()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Liga los datos obtenidos de la base de datos con los controles del formulario
        /// </summary>
        public override void BindData()
        {
            //  Ligamos los tipos de zona
            TiposZonasBindingSource.DataSource = Entities.TiposZonas.Read();

            //  Ligamos las comisiones de servicios
            ComisionesServiciosBindingSource.DataSource = Entities.ComisionesServicios.Read();

            //  Prepraramos la entrada de un nuevo registro
            ZonasBindingSource.AddNew();

            //  Llamamos el procedimiento del formulario Padre
            base.BindData();
        }

        /// <summary>
        /// "Limpia" los controles del formulario
        /// </summary>
        private void DoClear()
        {
            //  ClearControl limpia forma
            AppHelper.ClearControl(this);

            //  Prepraramos la entrada de un nuevo registro
            ZonasBindingSource.AddNew();
        }

        /// <summary>
        /// Guarda los datos en la base de datos
        /// </summary>
        private void DoSave()
        {
            //  Obtenemos el objeto Zonas actual
            Entities.Zonas zonas = (Entities.Zonas)ZonasBindingSource.Current;

            //  Mandamos llamar "Create" para la inserción
            zonas.Create();

            //  Limpiamos la forma
            DoClear();

            //  Mostramos el mensaje de éxito
            AppHelper.Info("¡La zona ha sido ingresada!");
        }

        /// <summary>
        /// Al hacer clic manda llamar el procedimiento para Guardar
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GuardarButton_Click(object sender, EventArgs e)
        {
            AppHelper.DoMethod(new AppHelper.HelperDelegate(DoSave), this);
        } 
    }
}
