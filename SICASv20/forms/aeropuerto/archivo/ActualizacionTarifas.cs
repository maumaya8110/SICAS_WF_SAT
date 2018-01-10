/*
 * ActualizacionTarifas
 * SICASv20.forms.ActualizacionTarifas
 * 
 * Codificado por Luis Espino
 * Ultima revision 2012-08-08
 * 
 * El propósito es Actualizar las Tarifas de las Zonas
 * de Aeropuerto
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
    /// Formulario para actualizar las tarifas de las zonas de Aeropuerto
    /// </summary>
    public partial class ActualizacionTarifas : baseForm
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public ActualizacionTarifas()
        {
            InitializeComponent();
        }

        private Int32 _Zona_ID;

        /// <summary>
        /// La zona de la tarifa
        /// </summary>
        public Int32 Zona_ID
        {
            get { return _Zona_ID; }
            set { _Zona_ID = value; }
        }
        private Int32 _TipoServicio_ID;

        /// <summary>
        /// El tipo de servicio de la tarifa
        /// </summary>
        public Int32 TipoServicio_ID
        {
            get { return _TipoServicio_ID; }
            set { _TipoServicio_ID = value; }
        }

        /// <summary>
        /// Liga los datos con los controles
        /// </summary>
        public override void BindData()
        {
            //  Carga las zonas
            ZonasBindingSource.DataSource = Entities.Zonas.Read();

            //  Carga los tipos de servicios
            TiposServiciosBindingSource.DataSource = Entities.TiposServicios.Read();

            //  Carga la tarifa a partir de zona y tipo de servicio
            TarifasBindingSource.DataSource = Entities.Tarifas.Read(this.Zona_ID, this.TipoServicio_ID);
            base.BindData();
        }

        /// <summary>
        /// Regresa a la pantalla de lista de tarifas
        /// </summary>
        private void DoBackToList()
        {
            forms.Tarifas TarifasLower = new forms.Tarifas();
            Padre.SwitchForma("Tarifas", TarifasLower);
        }

        /// <summary>
        /// Guarda los cambios en la base de datos
        /// </summary>
        private void DoSave()
        {
            //  Obtenemos la tarifa
            //  y la guardamos en el objeto tarifas
            Entities.Tarifas tarifas = (Entities.Tarifas)TarifasBindingSource.Current;

            //  Llamamos a la actualización
            tarifas.Update();

            //  Regresamos al lista de tarifas
            DoBackToList();

            //  Enviamos mensaje de éxito
            AppHelper.Info("¡Tarifas actualizados!");

            //  Registramos la acción de actualización
            //  en la base de datos
            AppHelper.LogDB(
                "Actualización de tarifas",
                string.Format("TipoServicio {0}, Zona {1}, Tarifa {2}", tarifas.TipoServicio_ID, tarifas.Zona_ID, tarifas.Tarifa),
                this.Name,
                null
            );            
        }

        /// <summary>
        /// Manda llamar el procedimiento para Guardar los cambios
        /// al clic del usuario
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GuardarButton_Click(object sender, EventArgs e)
        {
            AppHelper.DoMethod(new AppHelper.HelperDelegate(DoSave), this);
        } 

    } // end class
} // end namespace
