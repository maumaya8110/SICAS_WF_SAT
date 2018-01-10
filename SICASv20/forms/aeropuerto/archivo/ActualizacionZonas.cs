/*
 * ActualizacionZonas
 * SICASv20.forms.ActualizacioZonas
 * 
 * Codificado por Luis Espino
 * Ultima revision 2012-08-08
 * 
 * El propósito es actualizar las zonas de Aeropuerto
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
    /// Actualiza las zonas del Aeropuerto
    /// </summary>
    public partial class ActualizacionZonas : baseForm
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public ActualizacionZonas()
        {
            InitializeComponent();
        }

        private Int32 _Zona_ID;

        /// <summary>
        /// El ID de la zona
        /// </summary>
        public Int32 Zona_ID
        {
            get { return _Zona_ID; }
            set { _Zona_ID = value; }
        }

        /// <summary>
        /// Liga los datos obtenidos de la base de datos a los controles
        /// </summary>
        public override void BindData()
        {
            TiposZonasBindingSource.DataSource = Entities.TiposZonas.Read();
            ComisionesServiciosBindingSource.DataSource = Entities.ComisionesServicios.Read();
            ZonasBindingSource.DataSource = Entities.Zonas.Read(this.Zona_ID);
            base.BindData();
        }

        /// <summary>
        /// Navega a la pantalla de listado de Zonas
        /// </summary>
        private void DoBackToList()
        {
            forms.Zonas ZonasLower = new forms.Zonas();
            Padre.SwitchForma("Zonas", ZonasLower);
        }

        /// <summary>
        /// Guarda los cambios en la base de datos
        /// </summary>
        private void DoSave()
        {
            //  Obtenemos la zona actual
            //  y la asignamos a la variable zonas
            Entities.Zonas zonas = (Entities.Zonas)ZonasBindingSource.Current;

            //  Llamamos "Update" para actualizar los datos en la base de datos
            zonas.Update();

            //  Regresamos a la pantalla de listado de Zonas
            DoBackToList();

            //  Enviamos mensaje de éxito
            AppHelper.Info("¡Zona actualizada!");

            //  Registramos la acción de actualización en la base de datos
            AppHelper.LogDB(
                "Actualización de zonas",
                string.Format("Zona ID {0}, Nombre", zonas.Zona_ID, zonas.Nombre),
                this.Name,
                null
            );
        }

        /// <summary>
        /// Guarda los datos en la base de datos al clic del usuario
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GuardarButton_Click(object sender, EventArgs e)
        {
            AppHelper.DoMethod(new AppHelper.HelperDelegate(DoSave), this);
        } // end void

    } // end class

} // end namespace
