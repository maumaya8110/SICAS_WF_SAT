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
    /// Formulario para consultar y visualizar las cajas
    /// </summary>
    public partial class Cajas : baseForm
    {
        /// <summary>
        /// Crea una nueva instancia del formulario de cajas
        /// </summary>
        public Cajas()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Modelo de lógica de negocios para la consulta de cjas
        /// </summary>
        class Cajas_Model
        {
            /// <summary>
            /// El listado de cajas
            /// </summary>
            public List<Entities.Vista_Cajas> Cajas { get; set; }

            /// <summary>
            /// Consulta las cajas en la base de datos
            /// </summary>
            public void Consultar()
            {
                this.Cajas = Entities.Vista_Cajas.Get(null);
            }
        }

        /// <summary>
        /// Variable del modelo de lógica de negocios
        /// </summary>
        private Cajas_Model Model;

        /// <summary>
        /// Liga los datos a los controles
        /// </summary>
        public override void BindData()
        {
            //  Inicializamos el modelo
            this.Model = new Cajas_Model();

            //  Consultamos la información
            this.Model.Consultar();
            
            //  Ligamos los datos
            this.vista_CajasBindingSource.DataSource = this.Model.Cajas;

            base.BindData();
        }

        /// <summary>
        /// Muestra el formulario para actualizar los datos de la caja
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void vista_CajasDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            AppHelper.Try(
                delegate
                {
                    //  Si es la columna "Actualizar"
                    if (vista_CajasDataGridView.Columns[e.ColumnIndex].Name == "ActualizarColumn")
                    {
                        //  Obtenemos el dato de caja
                        Entities.Vista_Cajas vc = (Entities.Vista_Cajas)this.vista_CajasDataGridView.Rows[e.RowIndex].DataBoundItem;

                        //  Inicializamos el formulario de actualización
                        forms.ActualizacionCajas ac = new ActualizacionCajas();

                        //  Configuramos la caja a actualizar
                        ac.Caja_ID = vc.Caja_ID.Value;

                        //  Navegamos al formulario
                        Padre.SwitchForma("ActualizacionCajas", ac);
                    }
                }
            );
        } // end void
    } // end class
} // end namespace
