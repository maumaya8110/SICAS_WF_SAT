/*
 * AltaTarifas
 * SICASv20.forms.AltaTarifas
 * 
 * Codificado por Luis Espino
 * Ultima revision 2012-08-09
 * 
 * El propósito es ingresar nuevas tarifas al
 * sistema de Aeropuerto
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
    /// El formulario para dar de alta las tarifas
    /// </summary>
    public partial class AltaTarifas : baseForm
    {
        /// <summary>
        /// El constructor
        /// </summary>
        public AltaTarifas()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Liga los datos obtenidos de la base de datos a los controles
        /// </summary>
        public override void BindData()
        {
            //  Ligamos las zonas
            ZonasBindingSource.DataSource = Entities.Zonas.Read();

            //  Ligamos los tipos de servicios
            TiposServiciosBindingSource.DataSource = Entities.TiposServicios.Read();

            //  Preparamos un nuevo registro
            TarifasBindingSource.AddNew();  
          
            //  Mandamos llamar BindData de la clase padre
            base.BindData();
        }

        /// <summary>
        /// "Limpia" los controles del formulario
        /// </summary>
        private void DoClear()
        {
            AppHelper.ClearControl(this);
            TarifasBindingSource.AddNew();
        }

        /// <summary>
        /// Guarda los datos
        /// </summary>
        private void DoSave()
        {
            //  Obtenemos el objeto Tarifas actual
            Entities.Tarifas tarifas = (Entities.Tarifas)TarifasBindingSource.Current;

            //  Mandamos llamar "Create" para la inserción
            tarifas.Create();

            //  Limpiamos la forma
            DoClear();

            //  Mostramos mensaje de éxito
            AppHelper.Info("¡Tarifas actualizados!");
        }

        /// <summary>
        /// Al hacer clic manda a guardar los datos
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GuardarButton_Click(object sender, EventArgs e)
        {
            AppHelper.DoMethod(new AppHelper.HelperDelegate(DoSave), this);
        } 

    }
}
