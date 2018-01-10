/*
 * Historial
 *  7 de Mayo de 2013, modificado por Luis Espino
 *      Se cambio el uso de la función DatosConductor.GetByConductor_ID(int conductor_id),
 *      a la utilización de DatosConductor.GetByConductor_ID(int conductor_id, int numeroeconomico)
 *      Lineas 96 a 110
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
    /// Ventana para seleccionar una unidad
    /// </summary>
    public partial class SeleccionarUnidadConductor : Form
    {
        /// <summary>
        /// Clase que modela la lógica de negocios
        /// para la seleccion de unidades
        /// </summary>
        public class SeleccionarUnidadConductor_Model
        {
            /// <summary>
            /// El listado de unidades
            /// </summary>
            public List<Entities.DatosConductorUnidad> Unidades
            {
                get
                {
                    return Entities.DatosConductorUnidad.GetList(this.NumeroEconomico);
                }
            }

            /// <summary>
            /// El numero economico de la(s) unidad(es) buscada(s)
            /// </summary>
            public int NumeroEconomico { get; set; }

        }

        /// <summary>
        /// Crea una nueva instancia del formulario para la selección
        /// de unidades
        /// </summary>
        public SeleccionarUnidadConductor()
        {
            InitializeComponent();
            Model = new SeleccionarUnidadConductor_Model();
        }

        /// <summary>
        /// El modelo de la lógica de negocios
        /// </summary>
        private SeleccionarUnidadConductor_Model Model;

        /// <summary>
        /// La clase que representa los datos del conductor
        /// </summary>
        public Entities.DatosConductorUnidad DatosConductor { get; set; }

        /// <summary>
        /// Obtiene las unidades, a partir del número económico
        /// </summary>
        /// <param name="numeroeconomico"></param>
        public void GetUnidades(int numeroeconomico)
        {
            //  Actualizamos el modelo
            this.Model.NumeroEconomico = numeroeconomico;

            //  Liga los datos del modelo a los controles
            BindingSource unidadesBindingSource = new BindingSource(this.Model.Unidades, null);

            //  Configura el control "BindPanel"
            this.UnidadesBindPanel.LayoutType = BindPanel.BindPanelLayoutType.Vertical;
            this.UnidadesBindPanel.DisplayMember = "Descripcion";
            this.UnidadesBindPanel.ValueMember = "Conductor_ID";
            this.UnidadesBindPanel.B_Click = this.click_event;
            this.UnidadesBindPanel.DataSource = unidadesBindingSource;
            this.UnidadesBindPanel.ButtonFontSize = 20F;
            this.UnidadesBindPanel.Databind(); 
        }

        /// <summary>
        /// Evento clic para los botones del BindPanel
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void click_event(object sender, EventArgs e)
        {
            AppHelper.Try(
                delegate
                {
                    //  Obtenemos al conductor
                    Button btn = (Button)sender;
                    int conductor_id = Convert.ToInt32(btn.Tag);

                    /*
                     * Inicia actualización de código
                     * 7 de Mayo de 2013, Modificado por Luis Espino
                     * 
                     * Se actualizó la consulta de "DatosConductor",
                     * utilizando la función misma función "GetByConductorID",
                     * sobrecargada para que utilice también el parámetro
                     * "NumeroEconomico"
                     */
                    //  Obtenmos sus datos
                    this.DatosConductor =
                        Entities.DatosConductorUnidad.GetByConductor_ID(
                            conductor_id,
                            this.Model.NumeroEconomico
                        );
                    
                    //  Cerramos la forma y devolvemos "OK"
                    this.DialogResult = System.Windows.Forms.DialogResult.OK;
                    this.Close();

                } // end delegate

            ); // end method

        } // end void click_event

    } // end class

} // end namespace
