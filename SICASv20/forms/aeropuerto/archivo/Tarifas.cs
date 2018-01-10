/*
 * Tarifas
 * SICASv20.forms.Tarifas
 * 
 * Codificado por Luis Espino
 * Ultima revision 2012-08-09
 * 
 * Su propósito es mostrar las tarifas
 * de las distintas zonas de Aeropuerto
 * y permitir consulta de las mismas
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
    /// Muestra las tarifas y permite consultas
    /// </summary>
    public partial class Tarifas : baseForm
    {
        public bool MuestraEdicion { get; set; }
        public Tarifas()
        {
            this.MuestraEdicion = false;
            InitializeComponent();            
        }       

        /// <summary>
        /// Liga los datos obtenidos de la base de datos a los controles del formulario
        /// </summary>
        public override void BindData()
        {
            Vista_TarifasBindingSource.DataSource = Entities.Vista_Tarifas.Get(null, null);
            selectTiposServiciosBindingSource.DataSource = Entities.SelectTiposServicios.Get();
            base.BindData();
            if (this.MuestraEdicion)
            {
                this.EditColumn.Visible = true;
            }
            else
            {
                this.EditColumn.Visible = false;
            }
        }

        /// <summary>
        /// Realiza la consulta de información
        /// </summary>
        private void DoQuery()
        {   
            //  El tipo de servicio a consultar
            Int32? tiposervicio_id;

            //  El nombre de la zona a consultar
            string nombre;

            //  Obtenemos el tipo de servicio a partir de la selección del usuario
            tiposervicio_id = DB.GetNullableInt32(TipoServicio_IDComboBox.SelectedValue);

            //  Asignamos el nombre de la zona a buscar a partir del valor del control ZonaTextBox
            nombre = this.ZonaTextBox.Text;

            //  Realizamos la consulta y asignamos el resultado al control de DataSource
            Vista_TarifasBindingSource.DataSource = Entities.Vista_Tarifas.Get(nombre, tiposervicio_id);
        }

        //  Los valores de renglón y columna
        int row, col;

        /// <summary>
        /// Navega a la actualización de tarifas
        /// </summary>
        private void DoNavigate()
        {
            //  Si se hizo clic en la columna para edición
            if (Vista_TarifasDataGridView.Columns[col].Name == "EditColumn")
            {
                //  Creamos un formulario de ActualizacionTarifas
                forms.ActualizacionTarifas TarifasForm = new ActualizacionTarifas();

                //  Obtenemos el objeto Vista_Tarifas seleccionado en la tabla
                Entities.Vista_Tarifas TarifasLower = (Entities.Vista_Tarifas)Vista_TarifasDataGridView.Rows[row].DataBoundItem;

                //  Asignamos los valores de tipos de servicio y zona
                //  al formulario de actualizacion
                TarifasForm.TipoServicio_ID = TarifasLower.TipoServicio_ID;
                TarifasForm.Zona_ID = TarifasLower.Zona_ID;

                //  Cambiamos la forma actual al formulario de actualizacion
                Padre.SwitchForma("ActualizacionTarifas", TarifasForm);
            }
        }

        /// <summary>
        /// Buscar los datos de las tarifas en la base de datos
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BuscarButton_Click(object sender, EventArgs e)
        {
            AppHelper.DoMethod(new AppHelper.HelperDelegate(DoQuery), this);
        }

        /// <summary>
        /// Asigna los valores de renglón y columna seleccionados según la celda que elija el usuario
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Vista_TarifasDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            row = e.RowIndex;
            col = e.ColumnIndex;
            AppHelper.DoMethod(new AppHelper.HelperDelegate(DoNavigate), this);
        } //end void

    } // end class

} // end namespace
